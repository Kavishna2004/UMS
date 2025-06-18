using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMSAssignment.MODELS
{
    internal class Attendance : CommonModel
    {
      /*  public  int AttendanceId { get; set; }*/
        public int StudentId { get; set; }
        public int TimetableId { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
    }
}
