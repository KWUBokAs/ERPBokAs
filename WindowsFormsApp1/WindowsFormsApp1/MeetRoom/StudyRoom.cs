using System;
using System.Collections.Generic;

namespace WindowsFormapp1.ROOM{
{
    class Studyroom//열람실에 대한 클래스(외부클래스)
    {
        List<Rooms> listSr = new List<Rooms>();

        public void SetRoom(int roomNum, bool u)
        {
            Rooms rs = new Rooms();
            rs.SetValue(this, roomNum, u);
        }// 각 자리에 대해 자리번호와 사용여부 입력

        public int CountRoom(bool s)
        {
            int total = 0;
            foreach (Rooms rs in listSr)
            {
                if (rs.GetUsed() == s)
                    total++;
            }
            return total;
        }// 남은 자리수를 나타내주는 기능

        public string GetRoomInfo(int num) // 자리 정보를 나타내는 기능
        {
            string word = "";
            foreach (Rooms rs in listSr)
            {
                if (rs.GetRoomNum() == num && rs.GetUsed() == true)
                    word = rs.GetRoomNum().ToString() + "번 자리는 여석입니다.";
                else if (rs.GetRoomNum() == num && rs.GetUsed() == false)
                    word = rs.GetRoomNum().ToString() + "번 자리는 사용중 입니다.";
            }
            return word;
        }
        private class Rooms//개별 자리에 대한 (내부클래스) 
        {
            private int roomNum;
            private bool used;

            public void SetValue(Studyroom study, int rn, bool u)
            {
                this.roomNum = rn;
                this.used = u;

                study.listSr.Add(this);
            }
            public int GetRoomNum()
            { return roomNum; }
            public bool GetUsed()
            { return used; }
        }

    }
}
