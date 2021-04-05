using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1.BACK {
    class SQLObject {
        public Dictionary<String, String> param { get; protected set; }
        
        public string query { get; protected set; }
        public SQLObject() {
            param = new Dictionary<string, string>();
        }
        public virtual void Go() {
            ReplaceParam();
            if (String.IsNullOrEmpty(query))
                return;
            using(MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=HotelDangDang;Uid=kwUSS;Pwd=klas.kw.ac.kr;")) {
                try {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader table = cmd.ExecuteReader();
                    while (table.Read()) {
                        Console.WriteLine("{0} {1}", table["NAME"], table["SCORE"]);
                    }
                    table.Close();
                }
                catch (Exception e) {
                    Console.WriteLine("Fail Error: " + e.ToString());
                }
            }
        }
        public void AddParam(string key, string value) {
            param.Add(key, value);
        }
        public void setQuery(string value) {
            if (String.IsNullOrEmpty(value))
                return;
            query = value;
        }
        void ReplaceParam() {
            if (String.IsNullOrEmpty(query))
                return;
            if (param.Count <= 0)
                return;
            foreach(KeyValuePair<string,string> pair in param) {
                query = query.Replace("#" + pair.Key + "#", pair.Value);
            }
        }
    }
    class UpdateSQL : SQLObject {

    }
    class SelectSQL : SQLObject {

    }
    class InsertSQL : SQLObject {

    }
    class DeleteSQL : SQLObject {

    }
    class SQLCon {

    }
}
