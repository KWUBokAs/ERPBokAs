using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BookInfo : BOOK.BaseBook
    {
        public BookInfo(string _title = "", string _author = "", string _creator = "", string _publisher = "", string _location = "", string _requestNumber = "")
            :base(_title, _requestNumber,null)
        {
            //this.publicationDate = _publicationDate;
            //this.title = _title;
            this.author = _author;
            this.creator = _creator;
            this.publisher = _publisher;
            this.location = _location;
            //this.requestNumber = _requestNumber;
        }

       // public string Title
       // {
       //     get { return this.title; }
       // }
        // 일단 표시만 가능하도록
        // 검색하면 출력하는 부분
        //private string title;
        private string author;
        private string creator;
        private string publisher;
        private DateTime publicationDate;
        private string location;
        //private string requestNumber;
        // loanStatus
        // 책 이미지 => 어떻게 처리하지?
        // 여기까지

        //더 세부  // due date?
        // ISBN

        // 자료유형

        public bool findBook(string input) // 나중에수정
        {
            return this.Title.Contains(input);
        }
    }
}
