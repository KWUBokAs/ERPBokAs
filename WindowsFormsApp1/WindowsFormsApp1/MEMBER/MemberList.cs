using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MEMBER
{
    class MemberList : List<IMember>, IMember
    {
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
