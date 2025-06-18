using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Staff : CommonModel
    {
        //public  int StaffId { get; set; }
        public string StaffName {  get; set; }
        public string StaffNIC { get; set; }
        public UserGender StaffGender {  get; set; }
        public string StaffAddress { get; set; } 
        public UserCourse CourseId { get; set; }
        public int StaffTimeslot { get; set; }
        public int UserId { get; set; }
    }
}
