using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class Mention
    {
        public int MentionId { get; set; }
        public string Mentioner { get; set; }
        public string Mentionee { get; set; }
        public int BlrbId { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}