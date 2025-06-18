using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.ENUMS;

namespace UMSAssignment.MODELS
{
    internal class Room : CommonModel
    {
      /*  public int RoomId { get; set; }*/
        public UserRoom RoomName { get; set; }
        public string RoomType { get; set; }
    }
}
