using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LogAdministration
    {
        BasicViewElement viewElement;
        MenuSelection menuSelection;
        DatabaseLog databaseLog;
        LogViewElement logViewElement;

        public LogAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseLog databaseLog)
        {
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseLog = databaseLog;

            logViewElement = new LogViewElement();
        }
        public void SelectLogAdministration() // 로그 관리 모드에서 메뉴 선택
        {
            Console.Clear();
            Console.SetWindowSize(60, 28);
            logViewElement.PrintManageLogMenu();
            string number = menuSelection.CheckMenuNumber(46, 23, Constant.ARRAY_FIVE);
            Console.Clear();
            switch (int.Parse(number))
            {
                case Constant.EDIT_LOG:
                    {
                        EditLog();
                        break;
                    }
                case Constant.INIT_LOG:
                    {
                        InitializeLog();
                        break;
                    }
                case Constant.SAVE_LOG:
                    {
                        SaveLogFile();
                        break;
                    }
                case Constant.DELETE_LOG:
                    {
                        DeleteLogFile();
                        break;
                    }
                case Constant.LOG_LIST:
                    {
                        PrintLogList();
                        break;
                    }
            }

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                SelectLogAdministration();
            }
        }

        private void EditLog() // 로그 일부 삭제
        {
            string id = "";
            bool isLogId = false;
            Console.SetWindowSize(85, 28);
            logViewElement.PrintLogListSign();
            logViewElement.PrintEditForm();
            logViewElement.PrintLogListColumn();
            databaseLog.SelectLogList();

            while (isLogId == false)
            {
                Console.SetCursorPosition(24, 6);
                id = Console.ReadLine();
                isLogId = databaseLog.IsLogId(id);
                if (isLogId == false)
                {
                    Console.SetCursorPosition(24, 6);
                    viewElement.ClearLine(0, 24);
                    Console.SetCursorPosition(0, 4);
                    logViewElement.PrintWarningMessage();
                }
            }
            databaseLog.DeleteLogList(id);
            Console.SetCursorPosition(0, 4);
            viewElement.ClearLine(0, 0);
            logViewElement.PrintSuccessMessage("부분 삭제", 14, 4);

        }

        private void InitializeLog() // 로그 초기화
        {
            logViewElement.PrintDeleteLogList(" 전부 삭제");
            string number = menuSelection.CheckMenuNumber(46, 20, Constant.ARRAY_TWO);
            switch (int.Parse(number))
            {
                case Constant.LOG_DELETE:
                    {
                        databaseLog.TruncateLogList();
                        logViewElement.PrintSuccessMessage("전면 삭제", 0, 18);
                        break;
                    }   
                case Constant.GOBACK:
                    {
                        SelectLogAdministration();
                        break;
                    }
            }
        }

        private void SaveLogFile()
        {
            logViewElement.PrintDeleteLogList("파일을 저장");
            string number = menuSelection.CheckMenuNumber(46, 20, Constant.ARRAY_TWO);
            switch (int.Parse(number))
            {
                case Constant.LOG_DELETE:
                    {
                        databaseLog.WriteLog();
                        logViewElement.PrintSuccessMessage("파일 저장", 0, 18);
                        break;
                    }
                case Constant.GOBACK:
                    {
                        SelectLogAdministration();
                        break;
                    }
            }
        }

        private void DeleteLogFile()
        {
            logViewElement.PrintDeleteLogList("파일을 삭제");
            string number = menuSelection.CheckMenuNumber(46, 20, Constant.ARRAY_TWO);
            switch (int.Parse(number))
            {
                case Constant.LOG_DELETE:
                    {
                        ConfirmLogFile();
                        break;
                    }
                case Constant.GOBACK:
                    {
                        SelectLogAdministration();
                        break;
                    }
            }
        }
        private void PrintLogList() // 로그 내역을 전부 출력해주는 함수
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
