using System;

namespace Library
{
    class StartLibraryProgram
    {
        static void Main(string[] args)
        {
            ShowMain showMain = new ShowMain();
            showMain.ShowPage();
        }
    }
    
    // 관리자 id = Administrator1
    // 관리자 pw = 1234

    // 문제점 : 데이터 유지가 안됐음
}
