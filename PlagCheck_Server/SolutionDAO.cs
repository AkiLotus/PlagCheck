using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace PlagCheck_Server
{
    class SolutionDAO : DAO
    {
        public SolutionDAO() : base()
        {

        }

        public void AddSolution(Solution s)
        {
            string query = string.Format("INSERT INTO solutions (id, problem_id, lang, content) VALUES(\'{0}\', \'{1}\', \'{2}\', @content)", s.Id, s.ProblemId, s.Lang, Encoding.UTF8.GetBytes(s.Content));

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand("", conn);
                MySqlParameter sourceCodeContent = new MySqlParameter("@content", MySqlDbType.Blob, Encoding.UTF8.GetBytes(s.Content).Length);
                cmd.CommandText = query;
                sourceCodeContent.Value = Encoding.UTF8.GetBytes(s.Content);
                cmd.Parameters.Add(sourceCodeContent);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void EditSolution(Solution oldSolution, Solution newSolution)
        {
            string query = string.Format("UPDATE solutions SET problem_id=\'{0}\', lang=\'{1}\', content=@content WHERE id=\'{2}\'", newSolution.ProblemId, newSolution.Lang, oldSolution.Id);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand("", conn);
                MySqlParameter sourceCodeContent = new MySqlParameter("@content", MySqlDbType.Blob, Encoding.UTF8.GetBytes(newSolution.Content).Length);
                cmd.CommandText = query;
                sourceCodeContent.Value = Encoding.UTF8.GetBytes(newSolution.Content);
                cmd.Parameters.Add(sourceCodeContent);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void DeleteSolution(int id)
        {
            string query = "DELETE FROM solutions WHERE id=" + id.ToString();

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void DeleteSolution(Solution sol)
        {
            DeleteSolution(sol.Id);
        }

        public Solution GetSolution(int id)
        {
            Solution sol = new Solution();
            string query = string.Format("SELECT * FROM solutions WHERE id=\'{0}\'", id);

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data
                while (dataReader.Read())
                {
                    sol.Id = (int)dataReader["id"];
                    sol.ProblemId = (int)dataReader["problem_id"];
                    sol.Lang = (string)dataReader["lang"];
                    sol.Content = Encoding.UTF8.GetString((byte[])dataReader["content"]);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return sol;
        }

        public List<Solution> ListAllSolutions()
        {
            List<Solution> list = new List<Solution>();
            string query = "SELECT * FROM solutions";

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new Solution(
                        (int)dataReader["id"],
                        (int)dataReader["problem_id"],
                        (string)dataReader["lang"],
                        Encoding.UTF8.GetString((byte[])dataReader["content"])));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return list;
        }

        public List<string> ListAllLanguages()
        {
            List<string> list = new List<string>();
            string query = "SELECT DISTINCT lang FROM solutions";

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add((string)dataReader["lang"]);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return list;
        }

        public List<Solution> ListSolutionsFromProblem(int pid)
        {
            List<Solution> list = new List<Solution>();
            string query = string.Format("SELECT * FROM solutions where problem_id=\'{0}\'", pid);

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new Solution(
                        (int)dataReader["id"],
                        (int)dataReader["problem_id"],
                        (string)dataReader["lang"],
                        Encoding.UTF8.GetString((byte[])dataReader["content"])));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return list;
        }

        public List<Solution> ListSolutionsFromProblem(Problem prob)
        {
            return ListSolutionsFromProblem(prob.Id);
        }

        public int GetNextSolutionId()
        {
            int res = 1;
            List<Solution> pList = ListAllSolutions();
            HashSet<int> IdSet = new HashSet<int>();
            for (int i = 0; i < pList.Count; i++)
            {
                IdSet.Add(pList[i].Id);
            }
            while (IdSet.Contains(res)) res += 1;
            return res;
        }
    }
}
