using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Lecturer : CommonModel
    {
       /* public int LecturerId { get; set; }*/
        public string LecturerName { get; set; }
        public string LecturerNIC { get; set; }
        public UserGender LecturerGender { get; set; }
        public string LecturerAddress { get; set; }
        public string LecturerPhone { get; set; }
        public string  LecturerEmail {  get; set; }
        public UserCourse CourseId { get; set; }
        public int TimetableId { get; set; }
        public int UserId { get; set; }
    }
}
