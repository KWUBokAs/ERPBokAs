using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql; // 어떤것 사용?

namespace WindowsFormsApp1
{
    class BookSearch
    {
        //필요한가..?
        //private List<BookInfo> bookInfoList = new List<BookInfo>();
        //private BookInfo searchInfo;

        //public BookSearch(BookInfo _searchInfo)
        //{
        //    this.searchInfo = _searchInfo;
        //}


        // 각 화면에서 [버튼 클릭]이벤트가 발생했을 때, 검색이 필요하면 한번 실행
        public List<BookInfo> Search(BookInfo bi)
        {
            List<BookInfo> bookInfoList = new List<BookInfo>();
            // 실행시 DB에 BookInfo에 입력된 정보를 기반으로 검색
            // DB get
            // ex) getManyBookInfo => 이 방식이 아닌가? 웹만 해봤다보니...
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "~~";
            //SqlCommand cmd = new SqlCommand()
            //cmd.Connection = conn

            //cmd.CommandText = "~~"; --> 이 부분이 bookInfo에 있는 정보 확인해야하는 부분
            //필수적인 정보가 없다면 여기서 return; 해주고
            //필수적인 정보가 있다면 있는 정보만으로 query문을 만들어서 보냄
            //받아온 json 정보를 List<BookInfo>에 넣어서 리턴 
            //if문 사용

            return bookInfoList;
        }
    }
}
