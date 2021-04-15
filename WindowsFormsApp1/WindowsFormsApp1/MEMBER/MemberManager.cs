using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MEMBER
{
    class MemberManager
    {
        private MemberManager()
        {
            List<IMember> list = new List<IMember>();
            canReadDatabase = false;
            //추가되어야하는 기능을 담고있는 class를 이곳에 추가해 주세요.
            //MemberList의 enum classIndex를 참고하여 추가해 주세요.
            list[(int)MemberList.ClassIndex.BASE] = BaseMember.GetBaseMember();
            
        }
        public static MemberManager GetMemberManager()
        {
            if(mm == null)
            {
                mm = new MemberManager();
            }
            return mm;
        }
        /// <summary>
        /// 로그인되어 있는 상태일 때 호출하면
        /// </summary>
        public void Logout()
        {
            if (canReadDatabase) memberList.Logout();
            canReadDatabase = false;
        }
        /// <summary>
        /// 로그인이 되어 있는 상태라면
        /// 각 member들을 ReadDatabase해준다.
        /// </summary>
        public void ReadDatabase()
        {
           if(canReadDatabase)
                memberList.ReadDatabase();
        }
        //field 정의
        private static MemberManager mm = null;
        public MemberList memberList;
        private bool canReadDatabase;
    }
}
