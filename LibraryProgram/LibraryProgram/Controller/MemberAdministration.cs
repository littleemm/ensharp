using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberAdministration
    {
        MemberViewElement memberViewElement;
        BasicViewElement viewElement;
        MenuSelection menuSelection;
        DatabaseMember databaseMember;
        MemberVO memberVO;
        Exception exception;

        public MemberAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberVO memberVO, Exception exception)
        {
            memberViewElement = new MemberViewElement();
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.memberVO = memberVO;
            this.exception = exception;
        }

        public void SelectMemberAdministration()
        {
            memberViewElement.PrintManageMemberMenu();
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case Constant.REGISTRATION:
                    {
                        RegisterMember();
                        break;
                    }
                case Constant.EDIT:
                    {
                        EditMember();
                        break;
                    }
                case Constant.DELETE:
                    {
                        DeleteMember();
                        break;
                    }
                case Constant.SEARCH:
                    {
                        SearchMember();
                        break;
                    }
                case Constant.LIST:
                    {
                        PrintList();
                        break;
                    }
            }

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                SelectMemberAdministration();
            }
        }

        private void RegisterMember()
        {
            memberViewElement.PrintRegistration();

            Console.SetCursorPosition(40, 13);
            memberVO.Id = Console.ReadLine();

            Console.SetCursorPosition(40, 15);
            memberVO.Password = Console.ReadLine();

            Console.SetCursorPosition(40, 17);
            memberVO.Name = Console.ReadLine();

            Console.SetCursorPosition(40, 19);
            memberVO.Age = Console.ReadLine();

            Console.SetCursorPosition(40, 21);
            memberVO.PhoneNumber = Console.ReadLine();

            Console.SetCursorPosition(40, 23);
            memberVO.Address = Console.ReadLine();

            databaseMember.InsertMember(memberVO);
            memberViewElement.PrintRegistrationSuccessMessage();
        }

        private void EditMember()
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMemberForm();

            string memberId, memberAddress, memberNumber;

            Console.SetCursorPosition(30, 13);
            memberId = Console.ReadLine();

            Console.SetCursorPosition(30, 15);
            memberAddress = Console.ReadLine();

            Console.SetCursorPosition(30, 17);
            memberNumber = Console.ReadLine();

            if (memberAddress.Length > 0 || memberNumber.Length > 0)
            {
                databaseMember.UpdateMember(memberAddress, memberNumber, memberId);
                memberViewElement.PrintEditSuccessMessage();
            }

            else
            {
                memberViewElement.PrintEditFailMessage();
            }

        }

        private void DeleteMember()
        {
            memberViewElement.PrintDeleteMember();
            memberViewElement.PrintDeleteMemberForm();

            string memberId;
            Console.SetCursorPosition(30, 13);
            memberId = Console.ReadLine();

            databaseMember.DeleteMember(memberId);
            memberViewElement.PrintDeleteSuccessMessage();
        }

        private void SearchMember()
        {
            string memberId;
            memberViewElement.InformMemberList();
            memberViewElement.SearchMember();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();
            
            Console.SetCursorPosition(18, 6);
            memberId = Console.ReadLine();
            viewElement.ClearButtomLine(11, 8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberOfList(memberId);


        }

        private void PrintList()
        {
            memberViewElement.InformMemberList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();
            Console.SetCursorPosition(0, 0);
        }
    }
}
