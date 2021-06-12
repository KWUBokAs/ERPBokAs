﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WindowsFormsApp1.BACK {
    class ERPSQLException : Exception {
        public ERPSQLException() { }
        public ERPSQLException(string message) : base(message) { }
        public ERPSQLException(string message, Exception inner) : base(message, inner) { }
    }
    class SqlCon {
        private string serverName;
        private string uid;
        private string dataBase;
        private string pwd;
        private string port;

        public SqlCon() {
            
        }
        internal string ToString() {
            //"Server=mam675.synology.me;Port=3307;Database=kwUSS;Uid=kwUSS;Pwd=klas.kw.ac.kr;"
            string data = "";
            data += "Server=" + serverName+";";
            data += "Port=" + port + ";";
            data += "Database=" + dataBase + ";";
            data += "Uid=" + uid + ";";
            data += "Pwd=" + pwd + ";";
            return data;
        }
        public void set(string server, string mport, string database, string muid, string mpwd) {
            serverName = server;
            this.dataBase = database;
            this.port = mport;
            this.uid = muid;
            this.pwd = mpwd;
            this.Save();
        }
        private void Save() {
            JObject fileObject = new JObject();
            fileObject.Add("Server", serverName);
            fileObject.Add("Port", port);
            fileObject.Add("DataBase", dataBase);
            fileObject.Add("UID", uid);
            fileObject.Add("Pwd", pwd);
            Console.WriteLine(""+ Path.GetFullPath("Resources/Server.json"));
            //File.WriteAllText(Path.GetFullPath,fileObject.ToString());
        }
        private void Load() {

        }
    }
    class SQLObject : IDisposable{
        /// <summary>
        /// Query Parameter.
        /// Use In Query #param#
        /// </summary>
        protected Dictionary<String, String> param;
        private JArray jArray;
        
        public string query { get; protected set; }

        public Form parent { get; private set; }

        public bool isStop { get; private set; }

        public DataTable resultTable;
        public Form loadingForm;
        SqlCon data = new SqlCon();
        public bool isDoneQuery { get; private set; }
        public SQLObject() {
            param = new Dictionary<string, string>();
            jArray = new JArray();
            parent = Form.ActiveForm;
            isStop = true;
            resultTable = new DataTable();
            data.set("mam675.synology.me", "3307", "kwUSS", "kwUSS", "klas.kw.ac.kr");
        }
        public void setisStop(bool a) {
            this.isStop = a;
        }

        public JArray ToJArray() {
            if (!isDoneQuery)
                throw new ERPSQLException("Query Object Does not Ended Yet");
            return jArray;
        }
        public void ToJArray(out JArray marray) {
            if (!isDoneQuery)
                throw new ERPSQLException("Query Object Does not Ended Yet");
            marray = jArray;
        }
        public DataTable ToDataTable() {
            if (!isDoneQuery)
                throw new ERPSQLException("Query Object Does not Ended Yet");
            return resultTable;
        }
        public void ToDataTable(out DataTable mtable) {
            if (!isDoneQuery)
                throw new ERPSQLException("Query Object Does not Ended Yet");
            mtable = resultTable;
        }

        public void StopFormAndModal() {
            if (!isStop)
                return;
            if (loadingForm != null)
                return;
            loadingForm = new LoadingForm();
            if (loadingForm.ContainsFocus)
            {
                Form.ActiveForm.Opacity = 0.50;
                loadingForm.Show();
            }
        }
        public void ModalEnd() {
            if (!isStop)
                return;
            if (loadingForm == null)
                return;
            loadingForm.Close();
            if (loadingForm.ContainsFocus)
            {
                Form.ActiveForm.Opacity = 1;
            }
        }
        public virtual void Go() {
            ReplaceParam();
            if (String.IsNullOrEmpty(query))
                return;
            StopFormAndModal();
            using (MySqlConnection con = new MySqlConnection(data.ToString())) {
                try {
                    resultTable.Clear();
                    con.Open();
                    Console.WriteLine("QUERY: "+query);
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader table = cmd.ExecuteReader();
                    Console.WriteLine("Read Complete");
                    
                    while (table.Read()) {
                        JObject mObj = new JObject();
                        
                        for (int i =0; i<table.FieldCount; i++) {
                            Console.WriteLine(table.GetName(i)+": "+table[i].ToString());
                            mObj.Add(table.GetName(i).ToString(), table[i].ToString());
                        }
                        jArray.Add(mObj);
                    }
                    table.Close();
                    resultTable = JsonConvert.DeserializeObject<DataTable>(jArray.ToString());
                    isDoneQuery = true;
                }
                catch (Exception e) {
                    Console.WriteLine("Fail Error: " + e.Message);
                    
                }
                finally {
                    ModalEnd();
                }
            }
            Console.WriteLine("JSON COMPELTE");
            Console.WriteLine("JSON TO STRING: "+jArray.ToString());
        }
        public void AddParam(string key, string value) {
            param.Add(key, value);
        }
        public void setQuery(string value) {
            if (String.IsNullOrEmpty(value))
                return;
            query = value;
        }
        public virtual void ReplaceParam() {
            if (String.IsNullOrEmpty(query))
                return;
            if (param.Count <= 0)
                return;
            foreach(KeyValuePair<string,string> pair in param) {
                query = query.Replace("#" + pair.Key + "#", "'"+pair.Value+"'");
                query = query.Replace("@" + pair.Key, "'" + pair.Value + "'");
            }
        }
        public void Dispose() {
            //강제 소멸
        }
    }
}
