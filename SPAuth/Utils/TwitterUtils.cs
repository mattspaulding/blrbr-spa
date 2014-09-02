using Blrbr.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
//using TweetSharp;

namespace Blrbr.Utils
{
//    public static class TwitterUtils
//    {
//        public static TwitterResponse SendTweet(this UserProfile userProfile, string tweet)
//        {

////            var credentials = TwitterCredentials.CreateCredentials(
////                userProfile.AccessToken,
////userProfile.AccessTokenSecret,
////ConfigurationManager.AppSettings["token_ConsumerKey"],
////ConfigurationManager.AppSettings["token_ConsumerSecret"]);
////            TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
////            {
////                Tweet.PublishTweet(tweet);
////            });

           
//                var service = new TwitterService(ConfigurationManager.AppSettings["token_ConsumerKey"],
//                ConfigurationManager.AppSettings["token_ConsumerSecret"]);
          
//                service.AuthenticateWith(userProfile.AccessToken, userProfile.AccessTokenSecret);
//               // service.VerifyCredentials(new VerifyCredentialsOptions());
//                TwitterStatus result = service.SendTweet(new SendTweetOptions
//                {
//                    Status = tweet
//                });
//                return service.Response;
         
//        }
//    }
}