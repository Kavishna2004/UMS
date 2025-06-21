using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Timetable 
    {
        public int TimetableId { get; set; }
        public int SubjectId { get; set; }
        public UserTimeslot TimeSlot { get; set; }
        public UserRoom RoomId { get; set; }
    }
}
