using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class CourseVO
    {
        private string major;
        private string division;
        private string nameOfCourse;
        private string nameOfProfessor;
        private string grade;

        public CourseVO(string major, string division, string nameOfCourse, string nameOfProfessor, string grade)
        {
            this.major = major;
            this.division = division;
            this.nameOfCourse = nameOfCourse;
            this.nameOfProfessor = nameOfProfessor;
            this.grade = grade;
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public string Division
        {
            get { return division; }
            set { division = value; }
        }

        public string NameOfCourse
        {
            get { return nameOfCourse; }
            set { nameOfCourse = value; }
        }

        public string NameOfProfessor
        {
            get { return nameOfProfessor; }
            set { nameOfProfessor = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
