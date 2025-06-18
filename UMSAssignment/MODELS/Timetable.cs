using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Timetable : CommonModel
    {
        /*public int TimetableId { get; set; }*/
        public UserSubject SubjectId { get; set; }
        public string TimeSlot { get; set; }
        public UserRoom RoomId { get; set; }
    }
}
