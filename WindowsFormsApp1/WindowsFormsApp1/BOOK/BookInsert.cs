using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;

namespace WindowsFormsApp1.BOOK
{
    class BookInsert
    {
        public bool Insert(BookInfo bi)
        {
            // 실행시 DB에 BookInfo에 입력된 정보를 기반으로 등록
            InsertSQL mysqlObj = new InsertSQL();

            //필수적인 정보가 있는지 검사
            //=>여기서하고 넘기거나, 넘긴곳에서 하거나
            mysqlObj.InsertBook(bi);

            //등록 성공 response가 돌아오면 return true
            return true;

            //등록 실패 response가 돌아오면 return false
            //return false;
        }
    }
}