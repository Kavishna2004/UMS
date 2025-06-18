using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMSAssignment.MODELS
{
    internal class Exam : CommonModel
    {
        /*public int ExamId { get; set; }*/
        public string ExamName { get; set; }
        public int SubjectId { get; set; }
    }
}
