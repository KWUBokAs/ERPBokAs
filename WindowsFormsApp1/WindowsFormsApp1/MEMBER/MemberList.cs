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
            BASE = 0,
            BOOK_MANAGER,
            BOOK_SEARTCH,
            BOOK_RENT,
            READDING_MANAGE,
            READDING_RENT,
            MEETTING_MANAGE,
            MEETTING_RENT,
            OUT_OF_INDEX,
        };
        public MemberList() : base((int)ClassIndex.OUT_OF_INDEX){ }
        public void Logout()
        {
            foreach (var item in this)
            {
                if(item != null )item.Logout();
            }
        }

        public void ReadDatabase()
        {
            foreach (var item in this)
            {
                if (item != null) item.ReadDatabase();
            }
        }
        /*
        public IMember this[ClassIndex index]
        {
            get
            {
                if ((int)index < (int)ClassIndex.BASE || (int)index >= (int)ClassIndex.OUT_OF_INDEX)
                {
                    new Exception();
                    return null;
                }
                return base[(int)index];
            }
            set
            {
                if ((int)index < (int)ClassIndex.BASE || (int)index >= (int)ClassIndex.OUT_OF_INDEX)
                {
                    new Exception();
                }
                base[(int)index] = value;
            }
        }*/
    }
}
