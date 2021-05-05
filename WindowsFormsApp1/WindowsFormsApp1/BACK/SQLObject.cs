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

namespace WindowsFormsApp1.BACK {

    
    class SQLObject {
        // value가 string이 아닌 자료형이면 어떻게 받을까요?
        public Dictionary<String, String> param { get; protected set; }
        public JArray jArray;
        public string query { get; protected set; }
        public SQLObject() {
            param = new Dictionary<string, string>();
            jArray = new JArray();
        }
        public virtual void Go() {
            ReplaceParam();
            if (String.IsNullOrEmpty(query))
                return;
            
            using(MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=kwUSS;Uid=kwUSS;Pwd=klas.kw.ac.kr;")) {
                try {
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
                }
                catch (Exception e) {
                    Console.WriteLine("Fail Error: " + e.Message);
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
        public void ReplaceParam() {
            if (String.IsNullOrEmpty(query))
                return;
            if (param.Count <= 0)
                return;
            foreach(KeyValuePair<string,string> pair in param) {
                query = query.Replace("#" + pair.Key + "#", "'"+pair.Value+"'");
                query = query.Replace("@" + pair.Key, "'" + pair.Value + "'");
            }
        }
    }
    class UpdateSQL : SQLObject {
        public UpdateSQL() : base() { }

        public bool UpdateBook(BOOK.BookInfo bbi, BOOK.BookInfo abi)
        {
            // 
            // input으로 들어온 BookInfo가 Update하기에 충분한 정보를 가지고 있는지
            using (MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=HotelDangDang;Uid=kwUSS;Pwd=klas.kw.ac.kr;"))
            {
                try
                { 
                    // 둘다 수정? TB BOOKINFS + TB BOOKS

                    con.Open();
                    // table명 매개 인자 수정
                    // set에는 abi의 인자들을
                    // where에는 bbi의 인자들을
                    setQuery("update CHIKORITA set NAME = @aNAME where NAME = @bNAME");
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    // bi를 이용하여 정보 검색
                    cmd.Parameters.AddWithValue("@aNAME", "lll");
                    cmd.Parameters.AddWithValue("@bNAME", "ll");
                    //cmd.Parameters.AddWithValue("@SCORE", 11);
                    // Query 실행
                    cmd.ExecuteNonQuery();

                    // 조건 설정 필요 => ExecuteNonQuery 리턴값이 있는지 찾아보기
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail Error: " + e.ToString());
                }
                return false;
            }
        }
    }
    class SelectSQL : SQLObject {
        public SelectSQL() : base() { }

        // 이걸과연 여러사람이 쓸 수 있을까? => 좀더 수정할 수 있을까?
        public List<BOOK.BookInfo> SearchBook(BOOK.BookInfo bi)
        {
            List<BOOK.BookInfo> bookInfos = new List<BOOK.BookInfo>();
            // input으로 들어온 BookInfo가 Search하기에 충분한 정보를 가지고 있는지
            using (MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=HotelDangDang;Uid=kwUSS;Pwd=klas.kw.ac.kr;"))
            {
                try
                {
                    con.Open();
                    // table명 매개 인자 수정
                    setQuery("select * from CHIKORITA where NAME=@NAME");
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    // bi를 이용하여 정보 검색
                    cmd.Parameters.AddWithValue("@NAME", "ll");
                    // Query 실행
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    Console.WriteLine("{0}: {1}",rdr[0],rdr[1]);
                    //while (rdr.Read())
                    //{
                    //    bookInfos.Add();
                    //}
                    rdr.Close();

                    return bookInfos;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail Error: " + e.ToString());
                }
            }
            return null;
        }
    }
    class InsertSQL : SQLObject {
        public InsertSQL():base(){  }

        public void InsertBook(BOOK.BookInfo bi)
        {
            // input으로 들어온 BookInfo가 Insert하기에 충분한 정보를 가지고 있는지
            using (MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=HotelDangDang;Uid=kwUSS;Pwd=klas.kw.ac.kr;"))
            {
                try
                {
                    // if else문을 이용
                    // 기존에 없던 책을 추가하는 거면 TB BOOKINFS + TB BOOKS
                    // 기존에 있던 책을 추가하는 거면 TB  BOOKS

                    con.Open();
                    // table명 매개 인자 수정
                    setQuery("insert into CHIKORITA values(@NAME, @SCORE)");
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    // bi를 이용하여 정보 검색
                    cmd.Parameters.AddWithValue("@NAME", "ll");
                    cmd.Parameters.AddWithValue("@SCORE", 11);
                    // Query 실행
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail Error: " + e.ToString());
                }
            }
        }
    }
    class DeleteSQL : SQLObject {
        public DeleteSQL() : base() { }

        public bool DeleteBook(BOOK.BookInfo bi)
        {
            using (MySqlConnection con = new MySqlConnection("Server=mam675.synology.me;Port=3307;Database=HotelDangDang;Uid=kwUSS;Pwd=klas.kw.ac.kr;"))
            {
                try
                {
                    // if else문을 이용
                    // 마지막 책을 삭제하는 거면 TB BOOKINFS + TB BOOKS
                    // 하나를 삭제해도 한권이상 남아있다면 TB  BOOKS

                    con.Open();
                    // table명 매개 인자 수정
                    setQuery("delete from CHIKORITA where NAME = @NAME");
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    // bi를 이용
                    cmd.Parameters.AddWithValue("@NAME", "lll");
                    //cmd.Parameters.AddWithValue("@SCORE", 11);
                    // Query 실행
                    cmd.ExecuteNonQuery();

                    //ExecuteNonQuery 리턴값?
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail Error: " + e.ToString());
                }
            }
            return false;
        }
    }

    class SQLJson {

    }
}
