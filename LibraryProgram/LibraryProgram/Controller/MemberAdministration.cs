using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class MemberAdministration
    {
        MemberPage memberViewElement;
        BasicPage basicPage;
        MenuSelection menuSelection;
        DatabaseMember databaseMember;
        MemberDTO memberDTO;
        Exception exception;
        DatabaseLog databaseLog;
        LogDTO logDTO;
        KeyReader keyReader;

        public MemberAdministration(BasicPage basicPage, MemberPage memberViewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        { 
            this.basicPage = basicPage;
            this.memberViewElement = memberViewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.memberDTO = memberDTO;
            this.exception = exception;
            this.databaseLog = databaseLog;
            this.logDTO = logDTO;
            this.keyReader = keyReader;
        }

        public string RegisterMember() // 회원 등록
        {
            Console.SetWindowSize(74, 33);
            memberViewElement.PrintRegistration();
            bool isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Id = keyReader.ReadKeyBasic(42, 13, memberDTO.Id);
                if (memberDTO.Id == "\\n") return "\\n";

                isMemberValue = databaseMember.IsMemberId(memberDTO.Id);

                if (isMemberValue)
                {
                    basicPage.PrintWarningSentence(6, 11, "이미 존재하는 아이디입니다.");
                    Console.SetCursorPosition(42, 13);
                    basicPage.ClearLine(0, 42);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberDTO.Id);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 13);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Password = keyReader.ReadKeySecret(42, 15, memberDTO.Password);
                if (memberDTO.Password == "\\n") return "\\n";

                isMemberValue = exception.IsPassword(memberDTO.Password);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 15);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Name = keyReader.ReadKeyBasic(42, 17, memberDTO.Name);
                if (memberDTO.Name == "\\n") return "\\n";

                isMemberValue = exception.IsMemberName(memberDTO.Name);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 17);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Age = keyReader.ReadKeyBasic(42, 19, memberDTO.Age);
                if (memberDTO.Age == "\\n") return "\\n";

                isMemberValue = exception.IsAge(memberDTO.Age);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 19);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.PhoneNumber = keyReader.ReadKeyBasic(42, 21, memberDTO.PhoneNumber);
                if (memberDTO.PhoneNumber == "\\n") return "\\n";

                isMemberValue = exception.IsPhoneNumber(memberDTO.PhoneNumber);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 21);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (!isMemberValue)
            {
                memberDTO.Address = keyReader.ReadKeyBasic(42, 23, memberDTO.Address);
                if (memberDTO.Address == "\\n") return "\\n";

                isMemberValue = exception.IsAddress(memberDTO.Address);
                if (!isMemberValue)
                {
                    PrintFalse(10, 11, 42, 23);
                }
            }

            basicPage.ClearLineEasy(11, 6);
            databaseMember.InsertMember(memberDTO); // 조건에 전부 맞았을 경우 VO를 데베로 보내기
            memberViewElement.PrintRegistrationSuccessMessage();

            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberDTO.Id + "'' 회원 추가";
            databaseLog.InsertLog(logDTO); // 로그 기록

            return "";
        }

        public string EditMember() // 회원정보 수정
        {
            memberViewElement.PrintEditMember();
            memberViewElement.PrintEditMemberForm();
            basicPage.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "", memberAddress = "", memberNumber = "";
            bool isMemberValue = false;

            while (!isMemberValue)
            {
                memberId = keyReader.ReadKeyBasic(30, 13, memberId);
                if (memberId == "\\n") return "\\n";

                isMemberValue = databaseMember.IsMemberId(memberId); // 존재하는 아이디인지 체크

                if (!isMemberValue) 
                {
                    PrintFalse(5, 11, 30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId); // 아이디 입력 예외처리
                if (!isMemberValue)
                {
                    PrintFalse(5, 11, 30, 13);
                }
            }

            isMemberValue = false;
            basicPage.ClearLineEasy(11, 6);

            while (!isMemberValue)
            {
                memberAddress = keyReader.ReadKeyBasic(30, 15, memberAddress);
                if (memberAddress == "\\n") return "\\n";

                if (memberAddress == "") // 주소에 아무것도 입력되지 않았을 경우
                {
                    break; // 종료 (수정 x)
                }

                isMemberValue = exception.IsAddress(memberAddress); // 입력 예외처리
                if (!isMemberValue)
                {
                    PrintFalse(5, 11, 30, 15);
                }
            }

            isMemberValue = false;
            basicPage.ClearLineEasy(11, 6);

            while (!isMemberValue)
            {
                memberNumber = keyReader.ReadKeyBasic(30, 17, memberNumber);
                if (memberNumber == "\\n") return "\\n";

                if (memberNumber == "") // 번호에 아무것도 입력 안되었을 경우
                {
                    break; // 종료(수정x)
                }


                isMemberValue = exception.IsPhoneNumber(memberNumber); // 입력 예외처리
                if (!isMemberValue)
                {
                    PrintFalse(5, 11, 30, 17);
                }
            }

            basicPage.ClearLineEasy(11, 6);

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

            return "";
        }

        public string DeleteMember() // 회원 삭제
        {
            memberViewElement.PrintDeleteMember();
            memberViewElement.PrintDeleteMemberForm();
            basicPage.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "";
            bool isMemberValue = false;

            while (!isMemberValue)
            {
                memberId = keyReader.ReadKeyBasic(30, 13, memberId);
                if (memberId == "\\n") return "\\n";

                isMemberValue = databaseMember.IsMemberId(memberId);
                if (!isMemberValue) // 실제 존재하는 아이디인지 체크
                {
                    PrintFalse(5, 11, 30, 13);
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberId);
                if (!isMemberValue) // 입력 예외처리
                {
                    PrintFalse(5, 11, 30, 13);
                }

                // 멤버가 대출한 책이 있는지 확인
                isMemberValue = DatabaseMemberBook.databaseMemberBook.IsMemberCheckedOut(memberId, "memberId");
                if (!isMemberValue) // 대출 책 있을 경우 삭제 불가
                {
                    memberViewElement.PrintDeleteWarningMessage(3, 11);
                    Console.SetCursorPosition(30, 13);
                    basicPage.ClearLine(0, 30);
                }


            }

            basicPage.ClearLineEasy(11, 3);
            databaseMember.DeleteMember(memberId);
            memberViewElement.PrintDeleteSuccessMessage();

            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberId + "'' 회원 삭제";
            databaseLog.InsertLog(logDTO); // 로그 기록

            return "";
        }

        public string SearchMember() // 회원 검색
        {
            string memberId = "";
            bool isMemberId = false;
            memberViewElement.InformMemberList();
            memberViewElement.SearchMember();
            basicPage.PrintLine();
            databaseMember.SelectMemberList();

            while (!isMemberId)
            {
                memberId = keyReader.ReadKeyBasic(18, 6, memberId);
                if (memberId == "\\n") return "\\n";

                isMemberId = databaseMember.IsSearchedMemberId(memberId);
                if (!isMemberId) // 회원아이디 실제 존재 여부
                {
                    memberViewElement.PrintSearchWarningMessage(9, 4);
                    Console.SetCursorPosition(18, 6);
                    basicPage.ClearLine(0, 18);
                    continue;
                }

                isMemberId = exception.IsMemberId(memberId);
                if (!isMemberId)
                {
                    memberViewElement.PrintSearchWarningMessage(9, 4);
                    Console.SetCursorPosition(18, 6);
                    basicPage.ClearLine(0, 18);
                }
            }
            Console.SetCursorPosition(0, 4);
            basicPage.ClearLine(0, 0);

            Console.SetCursorPosition(18, 0);
            basicPage.ClearButtomLine(11, 8);
            basicPage.PrintLine();
            databaseMember.SelectMemberOfList(memberId);
            Console.SetCursorPosition(0, 0);
            logDTO.User = "관리자";
            logDTO.History = "ID ''" + memberId + "'' 회원 검색";
            databaseLog.InsertLog(logDTO); // 로그기록

            return "";
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

        public void PrintList()
        { 
            memberViewElement.InformMemberList();
            Console.WriteLine();
            Console.WriteLine("==============================================================================");
            databaseMember.SelectMemberList();
            Console.SetCursorPosition(0, 0);
        }

        private void PrintFalse(int printX, int printY, int x, int y)
        { // bool 함수를 이용해 확인한 후 false 상황일 때 사용 (메시지 출력, UI청소)
            Console.SetCursorPosition(printX, printY);
            memberViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            basicPage.ClearLine(0, x);
        }
    }
}
