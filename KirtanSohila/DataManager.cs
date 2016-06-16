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

                sql = "create table DICTIONARY (gurmukhi varchar(20), trans varchar(20)," +
                    "eng varchar(20), def varchar(50))";

                command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();

                sql = "insert into dictionary (gurmukhi, trans,eng,def) values" +
                    "('ਸੋਹਿਲਾ','Sohilā','Song of praise', 'Refers to the song of praise')";

                command = new SQLiteCommand(sql, dbConnection);
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

        public bool GetDef(string gurmukhi, out  string trans, out string eng, out string def)
        {
            bool found = false;
            trans = "";
            eng = "";
            def = "";
            {         
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
                            trans = oReader["trans"].ToString();
                            eng = oReader["eng"].ToString();
                            def = oReader["def"].ToString();
                            found = true;
                        }
                        myConnection.Close();
                    }
                }
            }
            return found;
        }
        
    }
}
