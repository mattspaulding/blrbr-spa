using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class Channel
    {
        public int ChannelId { get; set; }
         public string Name { get; set; }
        public string Hashtag { get; set; }
        public string Owner { get; set; }
        public string ProfileImg { get; set; }
        public string BannerImg { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
    }
}