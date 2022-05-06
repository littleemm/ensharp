using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LogAdministration
    {
        BasicPage basicPage;
        MenuSelection menuSelection;
        LogDAO databaseLog;
        LogPage logViewElement;
        KeyReader keyReader;

        public LogAdministration(BasicPage basicPage, LogPage logViewElement, MenuSelection menuSelection, LogDAO databaseLog, KeyReader keyReader)
        {
            this.basicPage = basicPage;
            this.logViewElement = logViewElement;
            this.menuSelection = menuSelection;
            this.databaseLog = databaseLog;
            this.keyReader = keyReader;
        }
        public string EditLog() // 로그 일부 삭제
        {
            string id = "";
            bool isLogId = false;
            Console.SetWindowSize(85, 28);
            logViewElement.PrintLogListSign();
            logViewElement.PrintEditForm();
            logViewElement.PrintLogListColumn();
            databaseLog.SelectLogList();

            while (!isLogId)
            {
                id = keyReader.ReadKeyBasic(24, 6, id);
                if (id == "\\n") return "\\n";
                isLogId = databaseLog.IsLogId(id);
                if (!isLogId)
                {
                    Console.SetCursorPosition(24, 6);
                    basicPage.ClearLine(0, 24);
                    Console.SetCursorPosition(0, 4);
                    logViewElement.PrintWarningMessage();
                }
            }
            databaseLog.DeleteLogList(id);
            Console.SetCursorPosition(0, 4);
            basicPage.ClearLine(0, 0);
            logViewElement.PrintSuccessMessage("부분 삭제", 14, 4);

            return "";
        }

        public string InitializeLog() // 로그 초기화
        {
            logViewElement.PrintDeleteLogList(" 전부 삭제");
            string number = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            while (Constant.EXIT_WHEN_GO_BACK)
            {
                switch (int.Parse(number))
                {
                    case Constant.LOG_INIT:
                        {
                            databaseLog.TruncateLogList();
                            logViewElement.PrintSuccessMessage("전면 삭제", 0, 18);
                            return "";
                        }
                    case Constant.GOBACK:
                        {
                            return "\\n";
                        }
                }
            }
        }

        public string SaveLogFile() // 로그 파일 저장(이미 존재하는 경우에는 파일 덮어쓰기)
        {
            logViewElement.PrintDeleteLogList("파일을 저장");
            string number = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            while (Constant.EXIT_WHEN_GO_BACK)
            {
                switch (int.Parse(number))
                {
                    case Constant.LOG_SAVE:
                        {
                            databaseLog.WriteLog();
                            logViewElement.PrintSuccessMessage("파일 저장", 0, 18);
                            return "";
                        }
                    case Constant.GOBACK:
                        {

                            return "\\n";
                        }
                }
            }
        }

        public string DeleteLogFile() // 로그 파일 삭제
        {
            logViewElement.PrintDeleteLogList("파일을 삭제");
            string number = menuSelection.CheckMenuNumber(46, 21, Constant.ARRAY_TWO);
            while (Constant.EXIT_WHEN_GO_BACK)
            {
                switch (int.Parse(number))
                {
                    case Constant.LOG_DELETE:
                        {
                            ConfirmLogFile();
                            return "";
                        }
                    case Constant.GOBACK:
                        {
                            return "\\n";
                        }
                }
            }
        }

        public void PrintLogList() // 로그 내역을 전부 출력해주는 함수
        {
            Console.SetWindowSize(85, 28);
            logViewElement.PrintLogListSign();
            logViewElement.PrintLogListColumn();
            databaseLog.SelectLogList();
        }

        private void ConfirmLogFile()
        {
            if (databaseLog.IsLogFile())
            {
                logViewElement.PrintSuccessMessage("파일 삭제", 0, 18);
            }
            else
            {
                logViewElement.PrintFailMessage(0, 18);
            }
        }
    }
}
