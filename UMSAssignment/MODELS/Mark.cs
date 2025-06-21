using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMSAssignment.MODELS
{
    internal class Mark 
    {
        public int MarkId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
    }
}
