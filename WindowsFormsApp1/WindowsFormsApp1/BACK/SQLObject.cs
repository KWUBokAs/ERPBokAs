using System;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Reflection;
using System.Resources;
namespace WindowsFormsApp1.BACK {
    public class Crypto {
        public static readonly string key = "01234567890123456789012345678901";
        public static readonly string iv = "0123456789012345";

        //AES 암호화
        public static string AESEncrypt(string input) {
            try {
                RijndaelManaged aes = new RijndaelManaged();
                //aes.KeySize = 256; //AES256으로 사용시 
                aes.KeySize = 128; //AES128로 사용시 
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);
                var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] buf = null;
                using (var ms = new MemoryStream()) {
                    using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write)) {
                        byte[] xXml = Encoding.UTF8.GetBytes(input);
                        cs.Write(xXml, 0, xXml.Length);
                    }
                    buf = ms.ToArray();
                }
                string Output = Convert.ToBase64String(buf);
                return Output;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        //AES 복호화
        public static string AESDecrypt(string input) {
            try {
                RijndaelManaged aes = new RijndaelManaged();
                //aes.KeySize = 256; //AES256으로 사용시 
                aes.KeySize = 128; //AES128로 사용시 
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);
                var decrypt = aes.CreateDecryptor();
                byte[] buf = null;
                using (var ms = new MemoryStream()) {
                    using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write)) {
                        byte[] xXml = Convert.FromBase64String(input);
                        cs.Write(xXml, 0, xXml.Length);
                    }
                    buf = ms.ToArray();
                }
                string Output = Encoding.UTF8.GetString(buf);
                return Output;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
    class ERPSQLException : Exception {
        public ERPSQLException() { }
        public ERPSQLException(string message) : base(message) { }
        public ERPSQLException(string message, Exception inner) : base(message, inner) { }
    }
    static class SqlCon {
        private static string serverName;
        private static string uid;
        private static string dataBase;
        private static string pwd;
        private static string port;

        internal static string ToString() {
            string data = "";
            data += "Server=" + serverName+";";
            data += "Port=" + port + ";";
            data += "Database=" + dataBase + ";";
            data += "Uid=" + uid + ";";
            data += "Pwd=" + pwd + ";";
            return data;
        }
        public static void set(string server, string mport, string database, string muid, string mpwd) {
            serverName = server;
            dataBase = database;
            port = mport;
            uid = muid;
            pwd = mpwd;
        }
        public static void Save() {
            string val = serverName + ";\n";
            val += dataBase + ";\n";
            val += port + ";\n";
            val += uid + ";\n";
            val += pwd + ";\n";
            string encrypte = Crypto.AESEncrypt(val);
            File.WriteAllText("D://khTest.BokA", encrypte);
        }
        public static void Load() {
            string dec;
            
            string resorce_data = Encoding.UTF8.GetString(Properties.Resources.kh);
            //MessageBox.Show(resorce_data);
            
            
            
            string fullcode = Crypto.AESDecrypt(resorce_data);
            //MessageBox.Show(fullcode);
            fullcode = fullcode.Replace("\n", "");
            serverName = fullcode.Substring(0, fullcode.IndexOf(";"));
            fullcode = fullcode.Substring(fullcode.IndexOf(";")+1);
            //MessageBox.Show(fullcode);
            dataBase = fullcode.Substring(0, fullcode.IndexOf(";"));
            fullcode = fullcode.Substring(fullcode.IndexOf(";") + 1);
            //MessageBox.Show(fullcode);
            port = fullcode.Substring(0, fullcode.IndexOf(";"));
            fullcode = fullcode.Substring(fullcode.IndexOf(";") + 1);
            //MessageBox.Show(fullcode);
            uid = fullcode.Substring(0, fullcode.IndexOf(";"));
            fullcode = fullcode.Substring(fullcode.IndexOf(";") + 1);
            //MessageBox.Show(fullcode);
            pwd = fullcode.Substring(0,fullcode.IndexOf(";"));
            //MessageBox.Show(SqlCon.ToString());
        }
    }
    class SQLObject : IDisposable{
        /// <summary>
        /// Query Parameter.
        /// Use In Query #param#
        /// </summary>
        protected Dictionary<String, String> param;
        protected JArray jArray;
        
        public string query { get; protected set; }

        public Form parent { get; private set; }

        public bool isStop { get; private set; }

        public DataTable resultTable;
        public Form loadingForm;
        //protected SqlCon data = new SqlCon();
        public bool isDoneQuery { get; protected set; }
        public SQLObject() {
            param = new Dictionary<string, string>();
            jArray = new JArray();
            parent = Form.ActiveForm;
            isStop = true;
            resultTable = new DataTable();
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
            using (MySqlConnection con = new MySqlConnection(SqlCon.ToString())) {
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
        public void AddImageParam(string key, Image image) {
            //FileStream fs = new FileStream(image.Tag.ToString(), FileMode.Open, FileAccess.Read);
            //byte[] bImage = new byte[fs.Length];
            //fs.Read(bImage, 0, (int)fs.Length);
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);
            param.Add(key, Encoding.Default.GetString(ms.ToArray()));
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
                query = query.Replace("#" + pair.Key + "#", "'"+pair.Value.Replace("'","\\'")+"'");
                query = query.Replace("@" + pair.Key, "'" + pair.Value.Replace("'", "\\'") + "'");
            }
        }
        public void Dispose() {
            //강제 소멸
        }
    }
    /// <summary>
    /// 이미지는 쿼리당 하나!
    /// </summary>
    class IMGSQLObject : SQLObject {
        public Image image { get; private set; }
        /// <summary>
        /// Go 대신 GoImage 함수를 사용해주시길 바랍니다.
        /// GoImage 함수는 Image를 리턴시킵니다.
        /// </summary>
        /// <returns>쿼리 후 가져온 이미지 리턴</returns>
        private void GoImage() {
            ReplaceParam();
            if (String.IsNullOrEmpty(query))
                return;
            StopFormAndModal();
            using (MySqlConnection con = new MySqlConnection(SqlCon.ToString())) {
                try {
                    resultTable.Clear();
                    con.Open();
                    Console.WriteLine("QUERY: " + query);
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader table = cmd.ExecuteReader();
                    Console.WriteLine("Read Complete");
                    while (table.Read()) {
                        Byte[] byteBlobImage = new Byte[0];
                        try {

                            byteBlobImage = (Byte[])(table.GetValue(0));
                            MemoryStream stmBLOBData = new MemoryStream(byteBlobImage);
                            ImageConverter convert = new ImageConverter();
                            //image = Image.FromStream(stmBLOBData);
                            image = (Image)convert.ConvertFrom(byteBlobImage);
                        }
                        catch (Exception e) {
                            Console.WriteLine("Fail Error: " + e.Message + e.StackTrace);
                            image = Properties.Resources.NoImage;
                            //throw new ERPSQLException("Image Query Error");
                        }
                    }
                    table.Close();
                    isDoneQuery = true;

                }
                catch (Exception e) {
                    Console.WriteLine("Fail Error: " + e.Message);
                    image = null;
                    throw new ERPSQLException("Query Error");
                }
                finally {
                    ModalEnd();
                }
            }
        }
        //Go 대신 GoImage 사용 권장
        [Obsolete("더 이상 사용하지 않습니다. GoImage 함수를 대신 사용해주시길 바랍니다.",true)]
        public override void Go() {
            return;
        }

        public void GoImage2(PictureBox picbox) {
            picbox.Image = Properties.Resources.NoImage;
            Thread thread = new Thread(new ThreadStart(GoImage));
            thread.Start();
            thread.Join();
            if(this.image != null) {
                picbox.Image = image;
            }
        }

    }
}
