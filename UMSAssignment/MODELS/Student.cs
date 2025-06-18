using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Student : CommonModel
    {
        //public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentNIC {  get; set; }
        public UserGender StudentGender { get; set; }
        public string StudentAddress { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string DOB { get; set; }
        public UserCourse CourseId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
