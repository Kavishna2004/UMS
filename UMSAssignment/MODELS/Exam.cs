using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Exam 
    {
        public int ExamId { get; set; }
        public UserExam ExamName { get; set; }
        public UserSubject SubjectId { get; set; }
    }
}
