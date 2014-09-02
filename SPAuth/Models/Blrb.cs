using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class Blrb
    {
        public int BlrbId { get; set; }
        //public long TwitterStatusId { get; set; }
        //public long TwitterAuthorId { get; set; }
        public string Text { get; set; }
        public string Sound { get; set; }
        public string UserName { get; set; }
        public string TwitterId { get; set; }
        public string ScreenName { get; set; }
        public string Channel { get; set; }
        public DateTime TimeStamp { get; set; }
  }

    public class BlrbCreateRequest
    {
        public string username { get; set; }
        public string channel { get; set; }
        public HttpPostedFileBase request {get;set;}
    }

    //public class BlrbCreateRequest
    //{
    //    public string key { get; set; }
    //    public HttpPostedFileBase blob { get; set; }
    //}

    public class BlrbStreamResponse
    {
        public UserProfile UserProfile { get; set; }
        public int NumberOfBlrbs { get; set; }
        public List<BlrbStreamItem> BlrbStreamItems { get; set; }
        public Channel Channel { get; set; }
        public bool IsMe { get; set; }

    }
    public class BlrbStreamItem
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string TextWithMarkup { get; set; }
        public string Sound { get; set; }
        public string UserName { get; set; }
        public string ScreenName { get; set; }
        public string Img { get; set; }
        public string Color { get; set; }
    }
    public class TweetRequest
    {
        [StringLength(140, MinimumLength = 1, ErrorMessage = "Too loooong")]
        public string Status { get; set; }
        public long InReplyToAuthorId { get; set; }
        public long InReplyToStatusId { get; set; }
    }
}