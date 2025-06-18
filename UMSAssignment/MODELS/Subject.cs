using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Subject : CommonModel
    {
       /* public int SubjectId {  get; set; }*/
        public UserSubject SubjectName { get; set; }
        public int CourseId { get; set; }
    }
}
