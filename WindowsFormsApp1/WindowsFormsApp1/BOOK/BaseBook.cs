using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BOOK
{
    class BaseBook
    {

        public BaseBook(string title=null, string num=null, string isbn=null)
        {
            this.title = title;
            this.requestNumber = num;
            this.isbn = isbn;
        }

        public string Title
        {
            get { return title; }
        }
        public string RequsetNumber
        {
            get { return requestNumber; }
        }
        public string ISBN
        {
            get { return isbn; }
        }
        private string title;
        private string requestNumber;
        private string isbn;
    }
}
