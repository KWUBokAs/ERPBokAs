using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;

namespace WindowsFormsApp1.BOOK
{
    class BookSearch
    {
        // 각 화면에서 [버튼 클릭]이벤트가 발생했을 때, 검색이 필요하면 한번 실행
        public List<BookInfo> Search(BookInfo bi)
        {
            // 실행시 DB에 BookInfo에 입력된 정보를 기반으로 등록
            SelectSQL mysqlObj = new SelectSQL();
            return mysqlObj.SearchBook(bi);
        }
    }
}