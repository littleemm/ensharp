﻿using System;
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

        public MemberAdministration(BasicViewElement viewElement, MenuSelection menuSelection, DatabaseMember databaseMember, MemberVO memberVO)
        {
            memberViewElement = new MemberViewElement();
            this.viewElement = viewElement;
            this.menuSelection = menuSelection;
            this.databaseMember = databaseMember;
            this.memberVO = memberVO;
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
        }

        private void RegisterMember()
        {
            memberViewElement.PrintRegistration();

            Console.SetCursorPosition(41, 15);
            memberVO.Id = Console.ReadLine();

            Console.SetCursorPosition(41, 16);
            memberVO.Password = Console.ReadLine();

            Console.SetCursorPosition(41, 17);
            memberVO.Name = Console.ReadLine();

            Console.SetCursorPosition(41, 18);
            memberVO.Age = Console.ReadLine();

            Console.SetCursorPosition(41, 19);
            memberVO.PhoneNumber = Console.ReadLine();

            Console.SetCursorPosition(41, 20);
            memberVO.Address = Console.ReadLine();

            databaseMember.InsertMember(memberVO);
        }

        private void EditMember()
        {
            memberViewElement.PrintEditMember();
        }

        private void DeleteMember()
        {
            memberViewElement.PrintDeleteMember();
        }

        private void SearchMember()
        {
            memberViewElement.InformMemberList();
        }

        private void PrintList()
        {
            memberViewElement.InformMemberList();
        }
    }
}
