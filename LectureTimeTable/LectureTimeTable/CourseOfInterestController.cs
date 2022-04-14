﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseOfInterestController 
    {
        int positionX;
        int positionY;
        
        public CourseOfInterestController(int positionX, int positionY) 
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public void SelectCondition(int x, int y)
        {
            Console.SetCursorPosition(5, 7);
            Console.BackgroundColor = ConsoleColor.Blue;
            //ScanMenuNumber(58, 16);
        }

        public void SelectMenu(int number) 
        {
            switch (number) ///// 매직넘버 수정하ㅏ기
            {
                case Constant.COURSE_TIME_INQUIRY: // 강의시간표 조회
                    {

                        break;
                    }
                case Constant.COURSE_OF_INTEREST: // 관심과목 담기
                    {
                        
                        break;
                    }
                case Constant.COURSE_REGISTRATION: // 수강신청
                    {
                        break;
                    }
                case Constant.MY_COURSE: // 수강 내역
                    {
                        break;
                    }
            }
        } 
    }
}
