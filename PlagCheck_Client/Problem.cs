using System;

namespace PlagCheck_Server
{
    [Serializable]
    public class Problem
    {
        private int id;
        private string name;
        private float timeLimit;
        private float memoryLimit;

        public Problem()
        {
            id = -1; name = "N/A";
            timeLimit = -1;
            memoryLimit = -1;
        }

        public Problem(int pid, string pname, float ptl, float pml)
        {
            id = pid; name = pname;
            timeLimit = ptl;
            memoryLimit = pml;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float TimeLimit { get => timeLimit; set => timeLimit = value; }
        public float MemoryLimit { get => memoryLimit; set => memoryLimit = value; }

        public static Problem Parse(string content)
        {
            Problem result = new Problem();
            try
            {
                string[] seperators = { " | " };
                string[] Token = content.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                result.Id = int.Parse(Token[0].Substring(1));
                result.Name = Token[1];
                result.TimeLimit = float.Parse(Token[2].Substring(0, Token[2].Length - 1));
                result.MemoryLimit = float.Parse(Token[3].Substring(0, Token[3].Length - 2));
            } catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return result;
        }

        public new string ToString => string.Format("#{0} | {1} | {2}s | {3}MB", id, name, timeLimit, memoryLimit);

        public bool Equals(Problem p)
        {
            return (this.Id == p.Id && this.Name == p.Name && this.TimeLimit == p.TimeLimit && this.MemoryLimit == p.MemoryLimit);
        }
    }
}
