using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class Hashtag
    {
        public int HashtagId { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public int BlrbId { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}