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
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 13);
                memberVO.Id = Console.ReadLine();
                isMemberValue = databaseMember.IsMemberId(memberVO.Id);

                if (isMemberValue == true)
                {
                    viewElement.PrintSameDataSentence(6, 11);
                    Console.SetCursorPosition(40, 13);
                    viewElement.ClearLine(0, 40);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberVO.Id);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 13);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 15);
                memberVO.Password = Console.ReadLine();

                isMemberValue = exception.IsPassword(memberVO.Password);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 15);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 17);
                memberVO.Name = Console.ReadLine();

                isMemberValue = exception.IsMemberName(memberVO.Name);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 17);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 19);
                memberVO.Age = Console.ReadLine();

                isMemberValue = exception.IsAge(memberVO.Age);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 19);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 21);
                memberVO.PhoneNumber = Console.ReadLine();

                isMemberValue = exception.IsPhoneNumber(memberVO.PhoneNumber);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 21);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 23);
                memberVO.Address = Console.ReadLine();

                isMemberValue = exception.IsAddress(memberVO.Address);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 23);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            databaseMember.InsertMember(memberVO);
            memberViewElement.PrintRegistrationSuccessMessage();
        }

        private void EditMember()
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMemberForm();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();

            string memberId = "", memberAddress = "", memberNumber = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 13);
                memberId = Console.ReadLine();
                isMemberValue = databaseMember.IsMemberId(memberId);

                if (isMemberValue == false)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId);
                if (isMemberValue == false)
                {
                    PrintFalse(30, 13);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(11, 6);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 15);
                memberAddress = Console.ReadLine();

                isMemberValue = exception.IsCtrlZ(memberAddress);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 15);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                if (memberAddress.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsAddress(memberAddress);
                if (isMemberValue == false)
                {
                    PrintFalse(30, 15);
                }
            }

            isMemberValue = false;
            viewElement.ClearLineEasy(11, 6);

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 17);
                memberNumber = Console.ReadLine();

                isMemberValue = exception.IsCtrlZ(memberNumber);
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 17);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                if (memberNumber.Length == 0)
                {
                    break;
                }

                isMemberValue = exception.IsPhoneNumber(memberNumber);
                if (isMemberValue == false)
                {
                    PrintFalse(30, 17);
                }
            }

            viewElement.ClearLineEasy(11, 6);

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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();

            string memberId = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 13);
                memberId = Console.ReadLine();
                isMemberValue = databaseMember.IsMemberId(memberId);
                if (isMemberValue == false)
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId);
                if (isMemberValue == false)
                {
                    PrintFalse(30, 13);
                }

                isMemberValue = DatabaseMemberBook.databaseMemberBook.IsMemberCheckedOut(memberId, "memberId");
                if (isMemberValue == false)
                {
                    memberViewElement.PrintDeleteWarningMessage(3, 11);
                    Console.SetCursorPosition(30, 13);
                    viewElement.ClearLine(0, 30);
                }


            }

            viewElement.ClearLineEasy(11, 3);
            databaseMember.DeleteMember(memberId);
            memberViewElement.PrintDeleteSuccessMessage();
        }

        private void SearchMember()
        {
            string memberId = "";
            bool isMemberId = false;
            memberViewElement.InformMemberList();
            memberViewElement.SearchMember();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();

            while (isMemberId == false)
            {
                Console.SetCursorPosition(18, 6);
                memberId = Console.ReadLine();

                isMemberId = databaseMember.IsSearchedMemberId(memberId);
                if (isMemberId == false)
                {
                    memberViewElement.PrintSearchWarningMessage(9, 4);
                    Console.SetCursorPosition(18, 6);
                    viewElement.ClearLine(0, 18);
                    continue;
                }

                isMemberId = exception.IsMemberId(memberId);
                if (isMemberId == false)
                {
                    memberViewElement.PrintSearchWarningMessage(9, 4);
                    Console.SetCursorPosition(18, 6);
                    viewElement.ClearLine(0, 18);
                }
            }

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

        private void PrintFalse(int x, int y)
        {
            Console.SetCursorPosition(20, 10);
            memberViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
