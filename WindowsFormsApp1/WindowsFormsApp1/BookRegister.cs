using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BookRegister
    {

        public bool Register(BookInfo bi)
        {
            // 실행시 DB에 BookInfo에 입력된 정보를 기반으로 등록
            // DB post
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "~~";
            //SqlCommand cmd = new SqlCommand()
            //cmd.Connection = conn

            //필수적인 정보가 있는지 검사
            //없다면 바로 return false; => 이 경우 사용자 입력이 부족한지 아니면 DB 통신 문제인지 알 수 없다
            // => 그렇다면 입력부족은 front에서 걸러야하나?
            //있다면 DB에 SQL문 보냄
            
            //등록 성공 response가 돌아오면 return true
            return true;

            //등록 실패 response가 돌아오면 return false
            //return false;
        }
    }
}
