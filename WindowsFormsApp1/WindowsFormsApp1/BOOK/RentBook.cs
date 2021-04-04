using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BOOK
{
    class RentalBook : BaseBook
    {


        /// <summary>
        /// properties
        /// </summary>
        public bool RentalAble
        {
            get { return retalAble; }
        }
        public int ReservationCount
        {
            get { return reservationCount; }
            private set 
            {
                if (value >= 0) reservationCount = value;
                else new Exception();
            }
        }

        private bool retalAble;//렌탈가능한 책인지 확인
        private int reservationCount;//예약된 인원확인

    }
}
