using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MEMBER
{
    class MemberList : List<IMember>, IMember
    {
        public enum ClassIndex : short
        {
            BOOK_MANAGER =0,
            BOOK_SEARTCH,
            BOOK_RENT,
            READDING_MANAGE,
            READDING_RENT,
            MEETTING_MANAGE,
            MEETTING_RENT,
        };
        public void Logout()
        {
            foreach (var item in this)
            {
                item.Logout();
            }
        }

        public void ReadDatabase()
        {
            foreach (var item in this)
            {
                item.ReadDatabase();
            }
        }
    }
}
