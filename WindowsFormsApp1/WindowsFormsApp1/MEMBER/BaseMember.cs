using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace WindowsFormsApp1.MEMBER
{
    public class BaseMember : IMember
    {
        public enum LOGINTYPE : short
        {
            SUCCESS,
            ID_NOT_INPUT,
            PW_NOT_INPUT,
            ID_NOT_EXIST,
            PW_INCONSIST,
            DB_CONNECT_FALL,
        };
        [Flags]
        public enum PERM : short
        {
            ANONY_USR = 0,
            NOMAL_USR = 1,
            BOOK_ADMIN = 2,
            READ_ADMIN = 4,
            MEET_ADMIN = 8,
            MEMBER_ADMIN = 16,
            ALL_ADMIN = MEMBER_ADMIN| MEET_ADMIN| READ_ADMIN| BOOK_ADMIN | NOMAL_USR,
        };
        /// <summary>
        /// 싱글톤 constructor
        /// </summary>
        private BaseMember(string id = "Anonymous", string name = "Anonymous", string e_mail = null, string phoneNum = null, PERM permission = PERM.ANONY_USR)
        {
            ID = id;
            Name = name;
            Email = e_mail;
            PhoneNumber = phoneNum;
            this.permission = permission;
        }
        public void Logout()
        {
            ID = "Anonymous";
            Name = "Anonymous";
            Email = null;
            PhoneNumber = null;
            this.permission = PERM.ANONY_USR;
        }
        /// <summary>
        /// 이름, 전화번호, email, 권한을 DB에서 받아와 세팅해 준다.
        /// 사용전 TryLogin을 사용하여여
        /// </summary>
        /// <returns>ID가 anonymous이면 false / 설정되어 있으면 true</returns>
        public bool ReadDatabase()
        {
            if (ID == "Anonymous") return false; //회원로그인이 승인되지 않았을 경우
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT NAME, CALLNUM, EMAIL, MANAGE_YN from USER where USER_ID=@USER_ID");
            selectSQL.AddParam("USER_ID", ID);
            selectSQL.Go();
            //selectsql
            JArray jarray = selectSQL.ToJArray();
            this.name = jarray[0].Value<string>("NAME");
            this.e_mail = jarray[0].Value<string>("EMAIL");
            this.phoneNumber = jarray[0].Value<string>("CALLNUM");
            this.permission = (PERM)jarray[0].Value<int>("MANAGE_YN");

            return true;
        }
        public static BaseMember GetInstance()
        {
            if(baseMember == null)
            {
                baseMember = new BaseMember();
            }
            return baseMember;
        }
        /// <summary>
        /// 로그인을 시도해서 시도한 user가 존재하는지 확인 할수 있다.
        /// 실제로 회원 id-pw가 존재하면 ReadData를 할 수 있는 상태로 세팅까지 해준다
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <returns>logintype를 잘 확인 하시면 어떤 값이 돌아올지 알 것입니다.</returns>
        public LOGINTYPE TryLogin(string id, string pw)
        {
            if(id == null || id == "")
            {
                return LOGINTYPE.ID_NOT_INPUT;//id를 입력하지 않았을 때
            }
            else if(pw == null || pw == "")
            {
                return LOGINTYPE.PW_NOT_INPUT;//pw를 입력하지 않았을 때
            }
            try
            {
                //-1 : 아이디 없음
                //0 : pw 틀림
                //1 : 로그인 성공
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("select COUNT(DUSER.USER_ID) AS DCnt" +
                                        ", COUNT(CUSER.USER_ID) AS Cnt " +
                                  //", DUSER.USER_ID " +
                                  "FROM USER AS DUSER " +
                                  "LEFT JOIN USER AS CUSER ON CUSER.USER_ID = DUSER.USER_ID " +
                                  "AND CUSER.PW=@PW " +
                                  "WHERE DUSER.USER_ID=@USER_ID");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.AddParam("PW", pw);
                selectSQL.Go();
                JArray jarray = selectSQL.ToJArray();
                if (jarray[0].Value<int>("DCnt") == 0)//ID가 존재하지 않을 때
                {
                    return LOGINTYPE.ID_NOT_EXIST;
                }
                //이하 구절은 ID가 존재하는 경우중에
                if (jarray[0].Value<int>("Cnt") == 0)//pw가 입력값과 다를때
                {
                    return LOGINTYPE.PW_INCONSIST;
                }
                //정상이여서 로그인 가능할 때
                ID = id;
            }
            catch
            {
                return LOGINTYPE.DB_CONNECT_FALL;
            }            
            //ReadDatabase();
            return LOGINTYPE.SUCCESS;
        }
        public LOGINTYPE MakeUser(string id, string pw, string name, string phnum, string email, PERM perm, string summery)
        {
            if (id == null || id.Length < 4 || pw==null || pw.Length < 4 || name ==null || name.Length < 1 || perm == PERM.ANONY_USR) return LOGINTYPE.ID_NOT_INPUT;//실패
            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT COUNT(auser.USER_ID) AS ACNT" +
                                    "FROM USER AS auser " +
                                    "WHERE auser.USER_ID=@USER_ID");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.Go();
                JArray idnum = selectSQL.ToJArray();
                if (idnum[0].Value<int>("ACNT") == 1) return LOGINTYPE.ID_NOT_EXIST;
            }
            catch
            {
                return LOGINTYPE.DB_CONNECT_FALL;
            }
            if (phnum == null || email == null) return LOGINTYPE.PW_NOT_INPUT;

            try
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("INSERT into USER " +
                                    "valuse(USER_ID=@USER_ID, PW=@PW, NAME=@NAME, " +
                                    "CALLNUM=@CALLNUM, EMAIL=@EMAIL, MANAGE_YN=@PERM, SUMMARY=@SUMMARY)");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.AddParam("PW", EncodingPassward(pw));
                selectSQL.AddParam("NAME", name);
                selectSQL.AddParam("CALLNUM", phnum);
                selectSQL.AddParam("EMAIL", email);
                selectSQL.AddParam("PERM", ((short)perm).ToString());
                selectSQL.AddParam("SUMMARY", summery);
                selectSQL.Go();
            }
            catch
            {
                return LOGINTYPE.DB_CONNECT_FALL;
            }
            return LOGINTYPE.SUCCESS;
        }
        public ListViewItem GetListViewItem()
        {
            ListViewItem liItem = new ListViewItem();
            liItem.SubItems.Add(id);
            liItem.SubItems.Add(name);
            liItem.SubItems.Add(e_mail);
            liItem.SubItems.Add(phoneNumber);
            liItem.SubItems.Add(GetStringPermission());
            return liItem;
        }
        /// <summary>
        /// passward를 encoding 한뒤에 반환함
        /// </summary>
        /// <param name="passward"></param>
        /// <returns></returns>
        private string EncodingPassward(string passward)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(passward));
            return Convert.ToBase64String(hash);
        }
        /// <summary>
        /// properties
        /// </summary>
        public string ID
        {
            get { return id; }
            protected set { id = value; }
        }
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public string Email
        {
            get { return e_mail; }
            protected set { e_mail = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            protected set { phoneNumber = value; }
        }
        /// <summary>
        /// get : 로그인한 경우 1 / 로그아웃인 경우 0
        /// </summary>
        public bool IsLogin
        {
            get { return ((permission & PERM.NOMAL_USR) == PERM.NOMAL_USR); }
        }
        public PERM Permission
        {
            get { return permission; }
        }
        public bool IsBookAdmin
        {
            get { return ((permission & PERM.BOOK_ADMIN) == PERM.BOOK_ADMIN); }
            private set { if (value) permission = permission|PERM.BOOK_ADMIN; }
        }
        public bool IsMeetingRoomAdmin
        {
            get { return ((permission & PERM.MEET_ADMIN) == PERM.MEET_ADMIN); }
            private set { if (value) permission = permission | PERM.MEET_ADMIN; }
        }
        public bool IsReadingRoomAdmin
        {
            get { return ((permission & PERM.READ_ADMIN) == PERM.READ_ADMIN); }
            private set { if (value) permission = permission|PERM.READ_ADMIN; }
        }

        /// <summary>
        /// field
        /// </summary>
        private string id;//회원 ID = 학번
        private string name;//회원이름
        private string e_mail;
        private string phoneNumber;//-는 제거한 순수한 휴대폰 번호
        private PERM permission;
        private static BaseMember baseMember= null;

        // 테스트 함수
        public virtual void PrintData()
        {
            Console.WriteLine("회원 정보");
            Console.WriteLine("ID\t\t: {0}", id);
            Console.WriteLine("NAME\t\t: {0}", name);
            Console.WriteLine("E-Mail\t\t: {0}", e_mail);
            Console.WriteLine("PHONE\t\t: {0}", phoneNumber);
            PrintPermission();
        }
        private void PrintPermission()
        {
            Console.Write("도서권한\t: ");
            if (IsBookAdmin) Console.WriteLine("사서사용자");
            else Console.WriteLine("일반사용자");
            Console.Write("열람실권한\t: ");
            if (IsReadingRoomAdmin) Console.WriteLine("관리사용자");
            else Console.WriteLine("일반사용자");
            Console.Write("회의실권한\t: ");
            if (IsMeetingRoomAdmin) Console.WriteLine("관리사용자");
            else Console.WriteLine("일반사용자");
        }
        private string GetStringPermission()
        {
            string value ="";
            switch (permission)
            {
                case PERM.ALL_ADMIN:
                    value = "관리자";
                    break;
                case PERM.BOOK_ADMIN:
                    value = "사서사용자";
                    break;
                case PERM.READ_ADMIN:
                    value = "열람실관리자";
                    break;
                case PERM.MEMBER_ADMIN:
                    value = "회의실관리자";
                    break;
                default: 
                    value = "일반사용자";
                    break;
            }
            return value;
        }
    }
}
