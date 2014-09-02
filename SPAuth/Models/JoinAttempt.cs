using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class JoinAttempt
    {
        public int JoinAttemptID { get; set; }
        public string ScreenName { get; set; }
        public string RawSource { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}