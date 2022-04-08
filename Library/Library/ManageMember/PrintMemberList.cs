using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class PrintMemberList
    {
        SetMemberData printMemberData = new SetMemberData();
        public PrintMemberList()
        {

        }
        public void PrintMemberMain()
        {
            Console.Clear();
            InformMemberList();
            PrintMembers();
        }

        public void InformMemberList()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("                     M E M B E R L I S T                     ");
            Console.WriteLine("=============================================================");
            Console.WriteLine();

        }
        public void PrintMembers()
        {
            for (int i = 0; i < printMemberData.memberList.Count; i++)
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("       아  이  디 : " + printMemberData.memberList[i].Id);
                Console.WriteLine("       이      름 : " + printMemberData.memberList[i].Name);
                Console.WriteLine("       출  생  일 : " + printMemberData.memberList[i].Birth);
                Console.WriteLine("       주      소 : " + printMemberData.memberList[i].Address);
                Console.WriteLine("       폰  번  호 : " + printMemberData.memberList[i].PhoneNumber);

            }
            Console.WriteLine("=============================================================");
        }
    }
}
