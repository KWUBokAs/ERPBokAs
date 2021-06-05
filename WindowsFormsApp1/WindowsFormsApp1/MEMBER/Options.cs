using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Data;

namespace WindowsFormsApp1.MEMBER
{
    class Options
    {
        private static Options option = null;

        private Options()
        {
            ReadDatabase();
        }

        public static Options GetInstance()
        {
            if (option == null)
            {
                option= new Options();
            }
            return option;
        }
        public int GetOverDue(string rent_dt, int rent_cnt)
        {
            int date = 0;
            DateTime dateTime = DateTime.Parse(GetBookReturnDate(rent_dt, rent_cnt)).AddDays(1);
            DateTime dateNow = DateTime.Now;
            TimeSpan ts;
            if (dateTime < dateNow){
                dateTime.AddDays(-1);
                ts = (dateNow - dateTime);
                date = ts.Days;
            }

            return date;
        }
        public string GetBookReturnDate(string rent_dt, int rent_cnt)
        {
            string startDate = DateTime.Parse(rent_dt).ToString("yyyy-MM-dd");
            string date = DateTime.Parse(startDate).AddDays(RD + RDADD * rent_cnt).ToString("yyyy-MM-dd");

            return date;
        }
        private void ReadDatabase()
        {
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT OPT_CD, OPT_VAL " +
                                    "from OPTIONS ");
                selectSQL.Go();
                //selectsql
                JArray jarray = selectSQL.ToJArray();
                table = JsonConvert.DeserializeObject<OptionTable.optionDataTable>(jarray.ToString());
            }
            catch
            {
                throw new ERPSQLException();
            }
        }
        /// <summary>
        /// 예약후 대여 안할 시 자동 취소
        /// </summary>
        public int AC
        {
            get 
            {
                DataRow a = table.Rows.Find("AC");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        /// <summary>
        /// 최대 도서 연장횟수
        /// </summary>
        public int EC
        {
            get
            {
                DataRow a = table.Rows.Find("EC");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        /// <summary>
        /// 도서 최대 연장기간
        /// </summary>
        public int ED
        {
            get
            {
                DataRow a = table.Rows.Find("ED");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        /// <summary>
        /// 도서관 이미지 경로
        /// </summary>
        public string IM
        {
            get
            {
                DataRow a = table.Rows.Find("IM");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return temp;
                }
                return null;
            }
        }
        /// <summary>
        /// 도서관 이름
        /// </summary>
        public string NM
        {
            get
            {
                DataRow a = table.Rows.Find("NM");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return temp;
                }
                return null;
            }
        }
        /// <summary>
        /// 기본 대여일
        /// </summary>
        public int RD
        {
            get
            {
                DataRow a = table.Rows.Find("RD");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        /// <summary>
        /// 연장시 추가 대여기간
        /// </summary>
        public int RDADD
        {
            get { return 7; }
        }
        /// <summary>
        /// 최대 대여권수
        /// </summary>
        public int RM
        {
            get
            {
                DataRow a = table.Rows.Find("RM");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        /// <summary>
        /// 하루당 연체 기초비
        /// </summary>
        public int RV
        {
            get
            {
                DataRow a = table.Rows.Find("RV");
                if (a != null)
                {
                    string temp = a.Field<string>("OPT_VAL");
                    return Convert.ToInt32(temp);
                }
                return 0;
            }
        }
        private OptionTable.optionDataTable table;
    }
}
