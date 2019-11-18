using System;

namespace PlagCheck_Server
{
    [Serializable]
    public class Solution
    {
        private int id;
        private int problemId;
        private string lang;
        private string content;

        public Solution()
        {
            id = -1; problemId = -1;
            lang = "N/A"; content = "N/A";
        }

        public Solution(int sid, int spid, string sl, string sc)
        {
            id = sid; problemId = spid;
            lang = sl; content = sc;
        }

        public int Id { get => id; set => id = value; }
        public int ProblemId { get => problemId; set => problemId = value; }
        public string Lang { get => lang; set => lang = value; }
        public string Content { get => content; set => content = value; }

        public static Solution Parse(string content)
        {
            Solution result = new Solution();
            try
            {
                string[] seperators = { " | " };
                string[] Token = content.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                result.Id = int.Parse(Token[0].Substring(1));
                result.Lang = Token[1];
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return result;
        }

        public new string ToString => string.Format("#{0} | {1}", id, lang);
    }
}
