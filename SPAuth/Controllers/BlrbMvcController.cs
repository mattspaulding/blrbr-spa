using SPAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blrbr.Utils;
using MediaToolkit.Options;
using MediaToolkit.Model;
using MediaToolkit;
using System.Configuration;
using Blrbr.Models;
using Blrbr.Hubs;

namespace SPAuth.Controllers
{
    public class BlrbMvcController : Controller
    {

        private AppContext db = new AppContext();

      
        // POST: /Blrb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
       // [Authorize]
        public JsonResult Create(HttpPostedFileBase request, string channel = "", string text = "", bool isTweet = false)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                 CreateService(request, username, channel, text, isTweet);
                //var textWithMarkup = text.ToTextWithMarkup();
                //var hashtags = text.ToListOfHashtags();
                //var dateTime = DateTime.Now;
                //var timeStamp = dateTime.ToFileTimeUtc();
                //var fileName = User.Identity.Name + "_" + timeStamp + ".mp3";
                //string fileNameWithPath = Server.MapPath("~/Voice/" + fileName);

                //request.SaveAs(fileNameWithPath);

                //var userProfile = db.UserProfiles.Where(x => x.Username == User.Identity.Name).Single();
                //var blrb = new Blrb
                //{
                //    Sound = "http://" + Request.Url.Authority + "/Voice/" + fileName,
                //    Text = text,
                //    TimeStamp = dateTime,
                //    UserName = userProfile.Username,
                //    ScreenName = userProfile.ScreenName,
                //    TwitterId = userProfile.TwitterId.ToString(),
                //    Channel = channel
                //};

                //userProfile.Blrbs.Add(blrb);
                //await db.SaveChangesAsync();

                //foreach (var hashtag in hashtags)
                //{
                //    var tag = new Hashtag
                //    {
                //        Username=userProfile.Username,
                //        BlrbId=blrb.BlrbId,
                //        Text = hashtag,
                //        TimeStamp = dateTime
                //    };
                //    db.Hashtags.Add(tag);
                //}

                //await db.SaveChangesAsync();
                //var response = new BlrbStreamItem
                //{
                //    UserName = userProfile.Username,
                //    ScreenName = userProfile.ScreenName,
                //    TextWithMarkup = textWithMarkup,
                //    Text = text,
                //    Sound = blrb.Sound,
                //    Img = userProfile.ProfileImageUrlNormal,
                //    Color = userProfile.ProfileBackgroundColor
                //};

                //var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<BlrbHub>();
                //context.Clients.Group(userProfile.TwitterId.ToString()).showBlrb(response);
                ////if (channel != null)
                ////{
                ////    context.Clients.Group("channel_" + channel).showBlrb(response);
                ////}
                //foreach (var hashtag in hashtags)
                //{
                //    context.Clients.Group("channel_" + hashtag).showBlrb(response);
                //}

                //if(isTweet)
                //{
                //    userProfile.SendTweet(text+" http://" + Request.Url.Authority+"/Blrb/Details/"+blrb.BlrbId);
                //}

                return Json(true);
            }

            return Json(false);
        }

      

        private object CreateService(HttpPostedFileBase request, string username, string channel = "", string text = "", bool isTweet = false)
        {
            var textWithMarkup = text.ToTextWithMarkup();
            var hashtags = text.ToListOfHashtags();
            var mentions = text.ToListOfMentions();
            var dateTime = DateTime.Now;
            var timeStamp = dateTime.ToFileTimeUtc();
            var fileName = username + "_" + timeStamp + ".mp3";
            string fileNameWithPath = Server.MapPath("~/Voice/" + fileName);

            if (request.FileName.EndsWith(".amr"))
            {
                var amrFileName = username + "_" + timeStamp + ".amr";
                string amrFileNameWithPath = Server.MapPath("~/Voice/Amr/" + amrFileName);
                request.SaveAs(amrFileNameWithPath);

                var conversionOptions = new ConversionOptions
                {
                    AudioSampleRate = AudioSampleRate.Hz44100
                };


                var inputFile = new MediaFile { Filename = amrFileNameWithPath };
                var outputFile = new MediaFile { Filename = fileNameWithPath };

                using (var engine = new Engine())
                {
                    engine.Convert(inputFile, outputFile, conversionOptions);
                }

            }
            else if (request.FileName.EndsWith(".wav"))
            {
                var wavFileName = username + "_" + timeStamp + ".wav";
                string wavFileNameWithPath = Server.MapPath("~/Voice/Wav/" + wavFileName);
                request.SaveAs(wavFileNameWithPath);

                var inputFile = new MediaFile { Filename = wavFileNameWithPath };
                var outputFile = new MediaFile { Filename = fileNameWithPath };

                using (var engine = new Engine())
                {
                    engine.Convert(inputFile, outputFile);
                }

            }
            else
            {
                request.SaveAs(fileNameWithPath);
            }

            var userProfile = db.UserProfiles.Where(x => x.Username == username).Single();

            if (Session["token"] != null)
            {
                userProfile.AccessToken = Session["token"] as string;
                userProfile.AccessTokenSecret = Session["tokenSecret"] as string;
            }
            var blrb = new Blrb
            {
                Sound = "http://" + Request.Url.Authority + "/Voice/" + fileName,
                Text = text,
                TimeStamp = dateTime,
                UserName = userProfile.Username,
                ScreenName = userProfile.ScreenName,
                TwitterId = userProfile.TwitterId.ToString(),
                Channel = channel
            };

            userProfile.Blrbs.Add(blrb);
             db.SaveChanges();

            foreach (var hashtag in hashtags)
            {
                var tag = new Hashtag
                {
                    Username = userProfile.Username,
                    BlrbId = blrb.BlrbId,
                    Text = hashtag,
                    TimeStamp = dateTime
                };
                db.Hashtags.Add(tag);
            }
            foreach (var mention in mentions)
            {
                var m = new Mention
                {
                    Mentioner = userProfile.Username,
                    BlrbId = blrb.BlrbId,
                    Mentionee = mention,
                    TimeStamp = dateTime
                };
                db.Mentions.Add(m);
            }

            db.SaveChangesAsync();
            var response = new BlrbStreamItem
            {
                UserName = userProfile.Username,
                ScreenName = userProfile.ScreenName,
                TextWithMarkup = textWithMarkup,
                Text = text,
                Sound = blrb.Sound,
                Img = userProfile.ProfileImageUrlNormal,
                Color = userProfile.ProfileBackgroundColor
            };

            var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<BlrbHub>();
            context.Clients.Group(userProfile.TwitterId.ToString()).showBlrb(response);
            //if (channel != null)
            //{
            //    context.Clients.Group("channel_" + channel).showBlrb(response);
            //}
            foreach (var hashtag in hashtags)
            {
                context.Clients.Group("channel_" + hashtag).showBlrb(response);
            }
            string tweetStatus = "none";
            //TwitterResponse twitterResponse = null;
            //if (isTweet)
            //{
            //    try
            //    {
            //        twitterResponse = userProfile.SendTweet(text + " http://" + Request.Url.Authority + "/Blrb/Details/" + blrb.BlrbId);
            //    }
            //    catch (Exception e)
            //    {
            //        tweetStatus = e.Message;
            //    }
            //}
            return new
            {
                username = username,
                //twitterResponse = twitterResponse.Error.RawSource,
                authority = Request.Url.Authority,
                AccessToken = userProfile.AccessToken,
                AccessTokenSecret = userProfile.AccessTokenSecret,
                SessionToken = Session["token"],
                SessionTokenSecret = Session["tokenSecret"],
                token_ConsumerKey = ConfigurationManager.AppSettings["token_ConsumerKey"],
                token_ConsumerSecret = ConfigurationManager.AppSettings["token_ConsumerSecret"]
            };
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}