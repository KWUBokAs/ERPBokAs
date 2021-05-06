using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;

namespace WindowsFormsApp1.BOOK
{
    class BookPatchInfo
    {
        // 기존 BookInfo의 모든 정보를 수정가능하다고 하면 
        // BookInfo 2개를 받아야 하지 않을까
        // 기존 Info DB검색용, 해당 Info DB패치용
        public bool PatchInfo(BookInfo bbi, BookInfo abi) //before, after
        {
            // 실행시 사용자가 선택한 BookInfo의 정보를 받아서 DB에 있는 해당 정보 삭제
            // DB patch
            //UpdateSQL mysqlObj = new UpdateSQL();
            //return mysqlObj.UpdateBook(bbi, abi);
            return true;
            // abi중 필수적인 부분이 비어있거나 잘못된 입력이면
            // front든 여기서든 걸러줘야함
            // +) 비어있는 부분은 bbi에서 가져와도 무관

            // bbi를 통해 해당 tuple검색
            // abi를 통해 해당 tuple패치



            //패치 성공 response가 돌아오면 return true
            //return true;

            //패치 실패 response가 돌아오면 return false
            //return false;
        }
    }
}