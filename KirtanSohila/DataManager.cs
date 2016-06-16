using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirtanSohila
{
    public sealed class DataManager
    {
        private static readonly DataManager instance = new DataManager();
        private SQLiteConnection dbConnection;
        private string sql;
        private SQLiteCommand command;
        private string conn = "Data Source=MyDatabase.sqlite;Version=3;";

        private DataManager() {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
                dbConnection = new SQLiteConnection(conn);
                dbConnection.Open();
                string script = File.ReadAllText("setupdb.sql");
                command = new SQLiteCommand(script, dbConnection);
                command.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        public static DataManager Instance
        {
            get
            {
                return instance;
            }
        }

        public bool GetDef(string gurmukhi, List<string> trans, List<string> eng)
        {
            bool found = false;
           
                     
                using (SQLiteConnection myConnection = new SQLiteConnection(conn))
                {
                    string oString = "Select * from DICTIONARY where gurmukhi=@fName";
                    SQLiteCommand oCmd = new SQLiteCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@Fname", gurmukhi);
                    myConnection.Open();
                    using (SQLiteDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            trans.Add(oReader["trans"].ToString());
                            eng.Add(oReader["eng"].ToString());
                            found = true;
                        }
                        myConnection.Close();
                    }
                }
            
            return found;
        }


        
    }
}
