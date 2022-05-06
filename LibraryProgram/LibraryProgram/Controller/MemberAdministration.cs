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
        KeyReader keyReader;

        public MemberAdministration(BasicViewElement viewElement, MemberViewElement memberViewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberDTO memberDTO, Exception exception, DatabaseLog databaseLog, LogDTO logDTO, KeyReader keyReader)
        { 
            this.viewElement = viewElement;
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

            while (isMemberValue == false)
            {
                memberDTO.Id = keyReader.ReadKeyBasic(42, 13, memberDTO.Id);
                if (memberDTO.Id == "\\n") return "\\n";

                isMemberValue = databaseMember.IsMemberId(memberDTO.Id);

                if (isMemberValue == true)
                {
                    viewElement.PrintSameDataSentence(6, 11);
                    Console.SetCursorPosition(42, 13);
                    viewElement.ClearLine(0, 42);
                    isMemberValue = false;
                    continue;
                }

                isMemberValue = exception.IsMemberId(memberDTO.Id);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 13);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                memberDTO.Password = keyReader.ReadKeyBasic(42, 15, memberDTO.Password);
                if (memberDTO.Password == "\\n") return "\\n";

                isMemberValue = exception.IsPassword(memberDTO.Password);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 15);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                memberDTO.Name = keyReader.ReadKeyBasic(42, 17, memberDTO.Name);
                if (memberDTO.Name == "\\n") return "\\n";

                isMemberValue = exception.IsMemberName(memberDTO.Name);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 17);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                memberDTO.Age = keyReader.ReadKeyBasic(42, 19, memberDTO.Age);
                if (memberDTO.Age == "\\n") return "\\n";

                isMemberValue = exception.IsAge(memberDTO.Age);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 19);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                memberDTO.PhoneNumber = keyReader.ReadKeyBasic(42, 21, memberDTO.PhoneNumber);
                if (memberDTO.PhoneNumber == "\\n") return "\\n";

                isMemberValue = exception.IsPhoneNumber(memberDTO.PhoneNumber);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 21);
                }
            }

            viewElement.ClearLineEasy(11, 6);
            isMemberValue = false;

            while (isMemberValue == false)
            {
                memberDTO.Address = keyReader.ReadKeyBasic(42, 23, memberDTO.Address);
                if (memberDTO.Address == "\\n") return "\\n";

                isMemberValue = exception.IsAddress(memberDTO.Address);
                if (isMemberValue == false)
                {
                    PrintFalse(42, 23);
                }
            }

            viewElement.ClearLineEasy(11, 6);
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
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "", memberAddress = "", memberNumber = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                memberId = keyReader.ReadKeyBasic(39, 13, memberId);
                if (memberId == "\\n") return "\\n";

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
                memberAddress = keyReader.ReadKeyBasic(30, 15, memberAddress);
                if (memberAddress == "\\n") return "\\n";

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
                memberNumber = keyReader.ReadKeyBasic(30, 17, memberNumber);
                if (memberNumber == "\\n") return "\\n";

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

            return "";
        }

        public string DeleteMember() // 회원 삭제
        {
            memberViewElement.PrintDeleteMember();
            memberViewElement.PrintDeleteMemberForm();
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            string memberId = "";
            bool isMemberValue = false;

            while (isMemberValue == false)
            {
                memberId = keyReader.ReadKeyBasic(30, 13, memberId);
                if (memberId == "\\n") return "\\n";

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

            return "";
        }

        public string SearchMember() // 회원 검색
        {
            string memberId = "";
            bool isMemberId = false;
            memberViewElement.InformMemberList();
            memberViewElement.SearchMember();
            viewElement.PrintLine();
            databaseMember.SelectMemberList();

            while (isMemberId == false)
            {
                memberId = keyReader.ReadKeyBasic(18, 6, memberId);
                if (memberId == "\\n") return "\\n";

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

        private void PrintFalse(int x, int y)
        { // bool 함수를 이용해 확인한 후 false 상황일 때 사용 (메시지 출력, UI청소)
            Console.SetCursorPosition(20, 10);
            memberViewElement.PrintWarningMessage();
            Console.SetCursorPosition(x, y);
            viewElement.ClearLine(0, x);
        }
    }
}
