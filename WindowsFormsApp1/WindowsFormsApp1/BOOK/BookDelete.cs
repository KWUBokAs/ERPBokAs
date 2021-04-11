using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;

namespace WindowsFormsApp1.BOOK
{
    class BookDelete
    {
        // *Input*
        // 입력값은 반드시 BookSearch.Search에서 받아온 List<BookInfo>의 element중에서 있어야한다.
        public bool Delete(BookInfo bi)
        {
            // 실행시 사용자가 선택한 BookInfo의 정보를 받아서 DB에 있는 해당 정보 삭제
            // DB delete
            DeleteSQL mysqlObj = new DeleteSQL();

            //필수적인 정보가 있는지 검사
            //=>여기서하고 넘기거나, 넘긴곳에서 하거나
            return mysqlObj.DeleteBook(bi);

            // BookSearch.Search를 통해서 반드시 있는 정보만 삭제하는데
            // 부족한 정보가 있는지 검사할 필요가 있나?

            //삭제 성공 response가 돌아오면 return true
            //return true;

            //삭제 실패 response가 돌아오면 return false
            //return false;
        }
    }
}
