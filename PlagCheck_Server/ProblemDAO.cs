using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PlagCheck_Server
{
    class ProblemDAO : DAO
    {
        public ProblemDAO() : base()
        {

        }

        public void AddProblem(Problem p)
        {
            string query = string.Format("INSERT INTO problems (id, name, timeLimit, memoryLimit) VALUES(\'{0}\', \'{1}\', \'{2}\', \'{3}\')", p.Id, p.Name, p.TimeLimit, p.MemoryLimit);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void EditProblem(Problem oldProblem, Problem newProblem)
        {
            string query = string.Format("UPDATE problems SET name=\'{0}\', timeLimit=\'{1}\', memoryLimit=\'{2}\' WHERE id=\'{3}\'", newProblem.Name, newProblem.TimeLimit, newProblem.MemoryLimit, oldProblem.Id);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void DeleteProblem(int id)
        {
            string query = "DELETE FROM problems WHERE id=" + id.ToString();

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void DeleteProblem(Problem prob)
        {
            DeleteProblem(prob.Id);
        }

        public Problem GetProblem(int id)
        {
            Problem prob = new Problem();
            string query = string.Format("SELECT * FROM problems WHERE id=\'{0}\'", id);

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data
                while (dataReader.Read())
                {
                    prob.Id = (int)dataReader["id"];
                    prob.Name = (string)dataReader["name"];
                    prob.TimeLimit = (float)dataReader["timeLimit"];
                    prob.MemoryLimit = (float)dataReader["memoryLimit"];
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return prob;
        }

        public List<Problem> ListAllProblems()
        {
            List<Problem> list = new List<Problem>();
            string query = "SELECT * FROM problems";

            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new Problem(
                        (int)dataReader["id"],
                        (string)dataReader["name"],
                        (float)dataReader["timeLimit"],
                        (float)dataReader["memoryLimit"]));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }

            return list;
        }

        public int GetNextProblemId()
        {
            int res = 1;
            List<Problem> pList = ListAllProblems();
            HashSet<int> IdSet = new HashSet<int>();
            for (int i=0; i<pList.Count; i++)
            {
                IdSet.Add(pList[i].Id);
            }
            while (IdSet.Contains(res)) res += 1;
            return res;
        }
    }
}
