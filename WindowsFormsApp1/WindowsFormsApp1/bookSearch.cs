using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class bookSearchPage : Form
    {
        List<BookInfo> bookInfoList = new List<BookInfo>();
        List<BookInfo> searchRes = new List<BookInfo>();
        public bookSearchPage()
        {
            InitializeComponent();
            // page 처음 들어왔을 때만 백엔드에서 모든 책의 정보를 가져옴
            // bookInfoList = getBookInfo();
            // getBookInfo를 대신한 Hard Coding

            for (int i = 0; i < 30; i++)
                bookInfoList.Add(new BookInfo(i.ToString()));
        }
        // 리스트 형식을 return 해서 copy to 하던가
        // 배열 형식을 return해서 for문 돌면서 Add()하던가
        private BookInfo[] getBookInfo()
        {
            BookInfo[] bookInfoList = null; // 백엔드에 요청
            return bookInfoList;
        }
        // 검색창에 텍스트를 칠때마다 실행
        private void searchBoxChanged(object sender, EventArgs e)
        {
            string input = this.bookSearchBox.Text;
            // 페이지 들어올때 가져왔던 BookInfo 배열 중에서 검색 내용과 일치하는것들을 찾음
            searchRes.Clear();
            searchRes = bookInfoList.FindAll(b => b.findBook(input));

            if (searchRes != null)
            {
                this.lvwBookInfo.Clear();
                var lvwItem = new ListViewItem(new string[lvwBookInfo.Columns.Count]);
                foreach (BookInfo b in searchRes)
                    // list view에 띄워야하는데 너무 귀찮아서 일단 콘솔출력, 올바르게 검색한것만 나옴
                    Console.WriteLine("Title : {0}", b.Title);
            }
        }
    }
}
