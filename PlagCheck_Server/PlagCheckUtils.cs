using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagCheck_Server
{
    class PlagCheckUtils
    {
        public static void GenerateSimilaritiesValue(ServerMainForm smf, Response res)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string temporalDir = Path.Combine(currentDir, "temporal_work");
            Directory.CreateDirectory(temporalDir);
            string sourceDir = Path.Combine(temporalDir, "sources");
            string resultDir = Path.Combine(temporalDir, "plagcheck_result");
            Directory.CreateDirectory(sourceDir);

            List<string> fileNameList = new List<string>();
            SortedDictionary<string, int> map = new SortedDictionary<string, int>();
            for (int i = 0; i < res.SourceRequest.SolutionList.Count; i++)
            {
                res.SimilarityMatrix[i][i] = -1;
                string fileDir = Path.Combine(sourceDir, string.Format("clientsent_{0}.{1}", i + 1, (res.SourceRequest.ChosenLanguage.Equals("C++")) ? "cpp" : "java"));
                map[fileDir] = i;
                fileNameList.Add(fileDir);
                using StreamWriter file = new StreamWriter(fileDir);
                file.Write(res.SourceRequest.SolutionList[i].Content);
            }
            for (int i = 0; i < res.ServerSolutionList.Count; i++)
            {
                string fileDir = Path.Combine(sourceDir, string.Format("server_{0}.{1}", i + 1, (res.SourceRequest.ChosenLanguage.Equals("C++")) ? "cpp" : "java"));
                map[fileDir] = res.SourceRequest.SolutionList.Count + i;
                fileNameList.Add(fileDir);
                using StreamWriter file = new StreamWriter(fileDir);
                file.Write(res.ServerSolutionList[i].Content);
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = string.Format("/C java -jar {0} -vqlpd -l {1} -r \"{2}\" -s \"{3}\"", smf.JplagDir, (res.SourceRequest.ChosenLanguage.Equals("C++")) ? "c/c++" : "java17", resultDir, sourceDir);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string originalContent = "";
            using (TextReader tr = new StringReader(output))
            {
                string line = "";
                while ((line = tr.ReadLine()) != null)
                {
                    originalContent += line;
                    originalContent += "\r\n";
                    if (line.Length < 9 || !line.Substring(0, 9).Equals("Comparing")) continue;
                    string[] Tokens = line.Split();
                    int dashId = Tokens[1].IndexOf("-");
                    float percentile = float.Parse(Tokens[2]);
                    string file1 = Path.Combine(sourceDir, Tokens[1].Substring(0, dashId));
                    string file2 = Path.Combine(sourceDir, Tokens[1].Substring(dashId + 1, Tokens[1].Length - dashId - 2));
                    int sol_id1 = map[file1];
                    int sol_id2 = map[file2];
                    res.SimilarityMatrix[sol_id1][sol_id2] = percentile;
                    res.SimilarityMatrix[sol_id2][sol_id1] = percentile;
                }
            }

            Directory.Delete(temporalDir, true);
            smf.WriteLogs(originalContent);
        }
        public static Response GenerateResponse(ServerMainForm smf, PlagCheck_Client.Request req, SolutionDAO sdao)
        {
            List<Solution> serverSolList = sdao.ListSolutionsFromProblem(req.ChosenProblem.Id);
            if (req.IsInternalCheck) serverSolList = new List<Solution>();
            Response res = new Response(req, serverSolList);
            GenerateSimilaritiesValue(smf, res);
            return res;
        }
    }
}
