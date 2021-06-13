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
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp1.MEMBER
{
    public class BaseMember : IMember
    {
        const int TIMEGAP = 10;//비상으로 꺼졌을 때 복구 갭
        public enum LOGINTYPE : short
        {
            SUCCESS,
            ID_NOT_INPUT,
            PW_NOT_INPUT,
            ID_NOT_EXIST,
            PW_INCONSIST,
            ID_STAT_LOGIN,
            DB_CONNECT_FALL,
        };
        [Flags]
        public enum PERM : short
        {
            ANONY_USR = 0,//로그아웃 상태 || 비회원
            NOMAL_USR = 1,//로그인 상태   || 일반회원
            BOOK_ADMIN = 2,//서서 관리자
            READ_ADMIN = 4,//열람실 관리자
            MEET_ADMIN = 8,//회의실 관리자
            MEMBER_ADMIN = 16,//회원 관리자자
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
            this.badmember = 'n';
            this.loginTime = "";
        }
        public static BaseMember GetInstance()
        {
            if (baseMember == null)
            {
                baseMember = new BaseMember();
            }
            return baseMember;
        }
        public void Logout()
        {
            if (ID == "Anonymous") return;
            try
            {
                SQLObject updateSQL = new BACK.SQLObject();
                updateSQL.setQuery("UPDATE " +
                                        "`USER` " +
                                   "SET " +
                                        "LOGTIME=@LOGTIME, " +
                                        "SUMMARY=@SUMMARY " +
                                   "WHERE " +
                                        "USER_ID=@USER_ID");
                updateSQL.AddParam("USER_ID", ID);
                updateSQL.AddParam("LOGTIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                updateSQL.AddParam("SUMMARY", summary);
                updateSQL.Go();
            }
            catch
            {
                MessageBox.Show("인터넷이 불안정합니다.", "DB 접속 오류");
            }
            ID = "Anonymous";
            Name = "Anonymous";
            Email = null;
            PhoneNumber = null;
            this.permission = PERM.ANONY_USR;
            this.badmember = 'n';
            summary = "";
            loginTime = "";
        }
        /// <summary>
        /// 이름, 전화번호, email, 권한을 DB에서 받아와 세팅해 준다.
        /// 사용전 TryLogin을 사용하여여
        /// </summary>
        /// <returns>ID가 anonymous이면 false / 설정되어 있으면 true</returns>
        public bool ReadDatabase()
        {
            if (ID == "Anonymous") return false; //회원로그인이 승인되지 않았을 경우
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT " +
                                        "NAME, CALLNUM, EMAIL, MANAGE_YN, BAD_YN " +
                                   "FROM " +
                                        "USER " +
                                   "WHERE " +
                                        "USER_ID=@USER_ID");
                selectSQL.AddParam("USER_ID", ID);
                selectSQL.Go();
                //selectsql
                JArray jarray = selectSQL.ToJArray();
                this.name = jarray[0].Value<string>("NAME");
                this.e_mail = jarray[0].Value<string>("EMAIL");
                this.phoneNumber = jarray[0].Value<string>("CALLNUM");
                this.permission = (PERM)jarray[0].Value<int>("MANAGE_YN");
                this.badmember = jarray[0].Value<char>("BAD_YN");
                loginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                return true;
            }
            catch
            {
                return false;
            }
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
            SQLObject selectSQL;
            try
            {
                //-1 : 아이디 없음
                //0 : pw 틀림
                //1 : 로그인 성공
                selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("select COUNT(DUSER.USER_ID) AS DCnt, " +
                                        "COUNT(CUSER.USER_ID) AS Cnt, " +
                                        "CUSER.SUMMARY AS SUMMARY, " +
                                        "CUSER.LOGTIME AS LOGTIME " +
                                  //", DUSER.USER_ID " +
                                  "FROM USER AS DUSER " +
                                  "LEFT JOIN USER AS CUSER ON CUSER.USER_ID = DUSER.USER_ID " +
                                  "AND CUSER.PW=@PW " +
                                  "WHERE DUSER.USER_ID=@USER_ID");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.AddParam("PW", EncodingPassward(pw));
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
                string temp = jarray[0].Value<string>("SUMMARY");
                if (temp == "로그인중...")//로그인 중이면
                {
                    DateTime last =DateTime.Parse(jarray[0].Value<string>("LOGTIME"));
                    DateTime now = DateTime.Now;
                    TimeSpan gap = now - last;
                    if (gap.TotalMinutes < TIMEGAP)
                    {
                        return LOGINTYPE.ID_STAT_LOGIN;
                    }
                }
                else
                {
                    summary = temp;
                }
                try//로그인 시간 추가
                {
                    SQLObject updateSQL = new BACK.SQLObject();
                    updateSQL.setQuery("UPDATE `USER` " +
                                            "SET " +
                                            "`SUMMARY`=@SUMMARY, " +
                                            "`LOGTIME`=@LOGTIME " +
                                        "WHERE USER_ID=@USER_ID");
                    updateSQL.AddParam("USER_ID", id);
                    updateSQL.AddParam("LOGTIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    updateSQL.AddParam("SUMMARY", "로그인중...");
                    updateSQL.Go();
                    //정상이여서 로그인 가능할 때
                    ID = id;
                }
                catch
                {
                    return LOGINTYPE.DB_CONNECT_FALL;
                }
            }
            catch
            {
                return LOGINTYPE.DB_CONNECT_FALL;
            }
            //ReadDatabase();
            return LOGINTYPE.SUCCESS;
        }
        public LOGINTYPE ChangePassward(string newpw)
        {
            if (newpw == null || newpw.Length < 4) return LOGINTYPE.PW_NOT_INPUT;
            try
            {
                SQLObject updateSQL= new BACK.SQLObject();
                updateSQL.setQuery("UPDATE `USER` " +
                                    "SET `PW`=@PW " +
                                    "Where USER_ID=@USER_ID");
                updateSQL.AddParam("USER_ID", id);
                updateSQL.AddParam("PW", EncodingPassward(newpw));
                updateSQL.Go();
            }
            catch
            {
                return LOGINTYPE.DB_CONNECT_FALL;
            }

            return LOGINTYPE.SUCCESS;
        }
        public LOGINTYPE MakeUser(string id, string pw, string name, string phnum, string email, PERM perm, string summery)
        {
            if (id == null || id.Length < 4 || pw==null || pw.Length < 4 || name ==null || name.Length < 1 || perm == PERM.ANONY_USR) return LOGINTYPE.ID_NOT_INPUT;//실패
            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT COUNT(auser.USER_ID) AS ACNT " +
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
                selectSQL.setQuery("INSERT into `USER`(`USER_ID`, `PW`, `NAME`, `CALLNUM`, `EMAIL`, `MANAGE_YN`, `BAD_YN`, `SUMMARY`, `LOGTIME`) " +
                                    "VALUES (@USER_ID, @PW, @NAME, @CALLNUM, @EMAIL, @PERM, @BAD_YN, @SUMMARY, @LOGTIME)");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.AddParam("PW", EncodingPassward(pw));
                selectSQL.AddParam("NAME", name);
                selectSQL.AddParam("CALLNUM", phnum);
                selectSQL.AddParam("EMAIL", email);
                selectSQL.AddParam("PERM", ((short)perm).ToString());
                selectSQL.AddParam("BAD_YN", "n");
                selectSQL.AddParam("LOGTIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
        /// 불량사용자 즉 연체된 사용자면 true를
        /// 정상사용자면 false을 반환한다.
        /// </summary>
        /// <returns></returns>
        public bool IsBadMember
        {
            get
            {
                if (badmember == 'n' || badmember == 'N') return false;
                else return true;
            }
        }
        /// <summary>
        /// 로그인이 되었다면 로그인한 시간은
        /// 로그아웃되었으면 ""반환
        /// </summary>
        public string LoginTime
        {
            get
            {
                if (IsLogin) { return loginTime; }
                else return "";
            }
        }
        /// <summary>
        /// 빌린 책의 개수를 반환한다
        /// 만약 실패하면 100을 반환한다.
        /// </summary>
        public int RentBookCount
        {
            get
            {
                int num = 100;
                if (IsLogin)
                {
                    try
                    {
                        SQLObject select = new BACK.SQLObject();
                        select.setQuery("SELECT " +
                                            "COUNT(USER_ID) AS CNT " +
                                        "FROM " +
                                            "BOOKRENTS " +
                                        "WHERE " +
                                            "USER_ID=@USER_ID " +
                                            "AND RENT_YN='0' ");
                        select.AddParam("USER_ID", id);
                        select.Go();
                        JArray jarray = select.ToJArray();
                        if (jarray != null)
                        {
                            num = jarray[0].Value<int>("CNT");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("DB접속이 불량합니다.");

                    }
                }
                return num;
            }
        }
        /// <summary>
        /// 도서대여가 가능한 상태이면 true를
        /// 불가능한 상태이면 false을 반환
        /// </summary>
        public bool CanRentBook
        {
            get
            {
                if (IsLogin)
                {
                    if (IsBadMember) return false;
                    Options options = Options.GetInstance();
                    if (RentBookCount < options.RM) return true;//최대개수보다 작을 경수
                }
                return false;
            }
        }
        public void ResetLoginTime()
        {
            loginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
        private char badmember;
        public string summary;
        private string loginTime;

        // 테스트 함수
        public virtual void PrintData()
        {
            Console.WriteLine("회원 정보");
            Console.WriteLine("ID\t\t: {0}", ID);
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
