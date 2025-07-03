using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Attendances 
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public string Timestamp { get; set; }
        public UserAttendance Status { get; set; }
    }
}
