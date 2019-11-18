using System.Windows.Forms;
using MySql.Data.MySqlClient;

public class DAO
{
    protected MySqlConnection conn;
    protected string server;
    protected string database;
    protected string uid;
    protected string password;

    public DAO()
	{
        InitializeConnection();
	}

    public void InitializeConnection()
    {
        server = "localhost";
        database = "plagcheck";
        uid = "root";
        password = "root";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        conn = new MySqlConnection(connectionString);
    }

    //open connection to database
    protected bool OpenConnection()
    {
        try
        {
            conn.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    //Close connection
    protected bool CloseConnection()
    {
        try
        {
            conn.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }
}
