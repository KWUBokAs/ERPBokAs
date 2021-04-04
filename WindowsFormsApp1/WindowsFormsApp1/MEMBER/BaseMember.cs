using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MEMBER
{
    [Flags]
    public enum PERM : short
    {
        ANONY_USR=0,
        NOMAL_USR=1,
        BOOK_ADMIN=2,
        READ_ADMIN=4,
        MEET_ADMIN=8
    };
    class BaseMember
    {
        private string id;//회원 ID = 학번
        private string name;//회원이름
        private string e_mail;
        private string phoneNumber;//-는 제거한 순수한 휴대폰 번호
        private PERM permission;
        
        protected BaseMember(string id, string name, string e_mail, string phoneNum, PERM permission)
        {
            ID = id;
            Name = name;
            Email = e_mail;
            PhoneNumber = phoneNum;
            this.permission = permission;
        }
        //로그인 함수(static)에 의하여 생성자를 호출하도록하겠다. 다시말해 로그인을 성공해야 member를 생성해주겠다
        protected BaseMember(string id = null)
        {
            ID = id;
        }
        public static BaseMember Login(string id=null, string pw=null)
        {
            if (id == null)
            {
                return new BaseMember("Anonymous", "Anonymous", "none", "00000000000", PERM.ANONY_USR);
            }
            else
            {
                return ReadDatabase(id, pw);
            }
        }
        private static BaseMember ReadDatabase(string id, string pw)
        {
            //차후에 DB와 연동하여 member를 생성하는 함수로 만들겠음
            return new BaseMember(id, id, "none", "00000000000", PERM.BOOK_ADMIN | PERM.MEET_ADMIN | PERM.READ_ADMIN);
        }
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
        protected bool IsLogin
        {
            get { return ((permission & PERM.ANONY_USR) == PERM.ANONY_USR); }
        }
        public PERM Permission
        {
            get { return permission; }
        }
        /// <summary>
        /// get : book_admin 이라면 1 / 일반사용자면 0을 반환한다.
        /// </summary>
        protected bool PermBook
        {
            get { return ((permission & PERM.BOOK_ADMIN) == PERM.BOOK_ADMIN); }
            set { if (value) permission = (PERM)((int)permission + (int)PERM.BOOK_ADMIN); }
        }
        /// <summary>
        /// get : meeting room admin 이라면 1 / 일반사용자면 0을 반환한다.
        /// </summary>
        protected bool PermMeetingRoom
        {
            get { return ((permission & PERM.MEET_ADMIN) == PERM.MEET_ADMIN); }
            set { if (value) permission = (PERM)((int)permission + (int)PERM.MEET_ADMIN); }
        }
        /// <summary>
        /// get : readding room admin 이라면 1 / 일반사용자면 0을 반환한다.
        /// </summary>
        protected bool PermReadingRoom
        {
            get { return ((permission & PERM.READ_ADMIN) == PERM.READ_ADMIN); }
            set { if (value) permission = (PERM)((int)permission + (int)PERM.READ_ADMIN); }
        }

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
            if (PermBook) Console.WriteLine("사서사용자");
            else Console.WriteLine("일반사용자");
            Console.Write("열람실권한\t: ");
            if (PermReadingRoom) Console.WriteLine("관리사용자");
            else Console.WriteLine("일반사용자");
            Console.Write("회의실권한\t: ");
            if (PermMeetingRoom) Console.WriteLine("관리사용자");
            else Console.WriteLine("일반사용자");
        }
    }
}
