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
        MemberDTO memberDTO;
        Exception exception;
        DatabaseLog databaseLog;
        LogDTO logDTO;

        public MemberAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, Exception exception, DatabaseLog databaseLog, LogDTO logDTO)
        {
            memberViewElement = new MemberViewElement();
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.memberDTO = memberDTO;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
        }

        public void SelectMemberAdministration() // 회원 관리모드에서 메뉴 고르기
        {
            Console.SetWindowSize(60, 28);
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
                case Constant.MEMBER_LIST:
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

        private void RegisterMember() // 회원 등록
        {
            Console.SetWindowSize(65, 30);
            memberViewElement.PrintRegistration();
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(40, 13);
                memberDTO.Id = Console.ReadLine(); // 아이디 입력
                isMemberValue = databaseMember.IsMemberId(memberDTO.Id);

                if (isMemberValue == true)
                {
                    viewElement.PrintSameDataSentence(6, 11);
                    Console.SetCursorPosition(40, 13);
                    viewElement.ClearLine(0, 40);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberDTO.Id);
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
                memberDTO.Password = Console.ReadLine(); // 비밀번호

                isMemberValue = exception.IsPassword(memberDTO.Password);
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
                memberDTO.Name = Console.ReadLine(); // 이름

                isMemberValue = exception.IsMemberName(memberDTO.Name);
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
                memberDTO.Age = Console.ReadLine(); // 나이

                isMemberValue = exception.IsAge(memberDTO.Age);
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
                memberDTO.PhoneNumber = Console.ReadLine(); // 번호

                isMemberValue = exception.IsPhoneNumber(memberDTO.PhoneNumber);
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
                memberDTO.Address = Console.ReadLine(); // 주소

                isMemberValue = exception.IsAddress(memberDTO.Address);
                if (isMemberValue == false)
                {
                    PrintFalse(40, 23);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            databaseMember.InsertMember(memberDTO); // 조건에 전부 맞았을 경우 VO를 데베로 보내기
            memberViewElement.PrintRegistrationSuccessMessage();

            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberDTO.Id + "'' 회원 추가";
            databaseLog.InsertLog(logDTO); // 로그 기록
        }

        private void EditMember() // 회원정보 수정
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMemberForm();
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "", memberAddress = "", memberNumber = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 13);
                memberId = Console.ReadLine(); // 아이디
                isMemberValue = databaseMember.IsMemberId(memberId); // 존재하는 아이디인지 체크

                if (isMemberValue == false) 
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId); // 아이디 입력 예외처리
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
                memberAddress = Console.ReadLine(); // 주소

                if (memberAddress == "") // 주소에 아무것도 입력되지 않았을 경우
                {
                    break; // 종료 (수정 x)
                }

                isMemberValue = exception.IsCtrlZ(memberAddress); // 터지지 않기 위함
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 15);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                isMemberValue = exception.IsAddress(memberAddress); // 입력 예외처리
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
                memberNumber = Console.ReadLine(); // 번호

                if (memberNumber == "") // 번호에 아무것도 입력 안되었을 경우
                {
                    break; // 종료(수정x)
                }

                isMemberValue = exception.IsCtrlZ(memberNumber); // 프로그램 터지지 않도록
                if (isMemberValue == false)
                {
                    viewElement.PrintWarningSentence(2, 11);
                    Console.SetCursorPosition(30, 17);
                    viewElement.ClearLine(0, 30);
                    continue;
                }

                isMemberValue = exception.IsPhoneNumber(memberNumber); // 입력 예외처리
                if (isMemberValue == false)
                {
                    PrintFalse(30, 17);
                }
            }

            viewElement.ClearLineEasy(11, 6);

            if (memberAddress.Length > 0 || memberNumber.Length > 0)
            { // 수정 요청이 하나라도 들어올 경우 데이터베이스로 넘겨서 수정함
                databaseMember.UpdateMember(memberAddress, memberNumber, memberId);
                memberViewElement.PrintEditSuccessMessage();
                AddEditLogToDatabase(memberId, memberAddress, memberNumber); // 로그기록 함수
            }

            else
            { // 수정 요청이 하나도 없을 경우 수정이 안되었다는 문구 출력
                memberViewElement.PrintEditFailMessage();
            }

        }

        private void DeleteMember() // 회원 삭제
        {
            memberViewElement.PrintDeleteMember();
            memberViewElement.PrintDeleteMemberForm();
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                Console.SetCursorPosition(30, 13);
                memberId = Console.ReadLine(); // 아이디 
                isMemberValue = databaseMember.IsMemberId(memberId);
                if (isMemberValue == false) // 실제 존재하는 아이디인지 체크
                {
                    PrintFalse(30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId);
                if (isMemberValue == false) // 입력 예외처리
                {
                    PrintFalse(30, 13);
                }

                // 멤버가 대출한 책이 있는지 확인
                isMemberValue = DatabaseMemberBook.databaseMemberBook.IsMemberCheckedOut(memberId, "memberId");
                if (isMemberValue == false) // 대출 책 있을 경우 삭제 불가
                {
                    memberViewElement.PrintDeleteWarningMessage(3, 11);
                    Console.SetCursorPosition(30, 13);
                    viewElement.ClearLine(0, 30);
                }


            }

            viewElement.ClearLineEasy(11, 3);
            databaseMember.DeleteMember(memberId);
            memberViewElement.PrintDeleteSuccessMessage();

            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberId + "'' 회원 삭제";
            databaseLog.InsertLog(logDTO); // 로그 기록
        }

        private void SearchMember() // 회원 검색
        {
            string memberId = "";
            bool isMemberId = false;
            memberViewElement.InformMemberList();
            memberViewElement.SearchMember();
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            while (isMemberId == false)
            {
                Console.SetCursorPosition(18, 6);
                memberId = Console.ReadLine();

                isMemberId = databaseMember.IsSearchedMemberId(memberId);
                if (isMemberId == false) // 회원아이디 실제 존재 여부
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
            Console.SetCursorPosition(0, 4);
            viewElement.ClearLine(0, 0);

            Console.SetCursorPosition(18, 0);
            viewElement.ClearButtomLine(11, 8);
            viewElement.PrintLine();
            databaseMember.SelectMemberOfList(memberId);
            Console.SetCursorPosition(0, 0);
            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberId + "'' 회원 검색";
            databaseLog.InsertLog(logDTO); // 로그기록
        }

        private void AddEditLogToDatabase(string memberId, string address, string number)
        { // 회원 수정 메뉴에서 로그 기록하는 함수
            logDTO.User = "관리자";

            if (address.Length > 0 && number.Length == 0)
            {
                logDTO.History = "회원 ''" + memberId + "''의 주소를 ''" + address + "''(으)로 수정";
            }

            else if (address.Length == 0 && number.Length > 0)
            {
                logDTO.History = "회원 ''" + memberId + "''의 전화번호를 ''" + number + "''(으)로 수정";
            }

            else if (address.Length > 0 && number.Length > 0)
            { // 둘다 수정할 경우 (위의 두 경우는 하나씩 수정)
                logDTO.History = "회원 ''" + memberId + "''의 주소를 ''" + address + "''(으)로 수정, " +
                    "전화번호를 ''" + number + "''(으)로 수정";
            }

            databaseLog.InsertLog(logDTO); // 로그 기록 성공
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
        { // bool 함수를 이용해 확인한 후 false 상황일 때 사용 (메시지 출력, UI청소)
            Console.SetCursorPosition(20, 10);
            memberViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
