using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blrbr.Utils
{
    public static class Utils
    {
        public static string ToTextWithMarkup(this string text)
        {
            string textWithMarkup = "";
            foreach (var word in text.Split(null).ToList())
            {
                string newWord = "";
                if (word.StartsWith("#"))
                {
                    newWord = "<a href=http://" + HttpContext.Current.Request.Url.Authority + "/" + word.Replace("#", "") + ">" + word + "</a>";
                }
                else if (word.StartsWith("@"))
                {
                    newWord = "<a href=http://" + HttpContext.Current.Request.Url.Authority + "/blrbr/" + word.Replace("@", "") + ">" + word + "</a>";
                }
                else
                {
                    newWord = word;
                }
                textWithMarkup += newWord + " ";
            }
            textWithMarkup = textWithMarkup.TrimEnd();
            return textWithMarkup;
        }
        public static List<string> ToListOfHashtags(this string text)
        {
            var hashtags = new List<string>();
            foreach (var word in text.Split(null).ToList())
            {
                if (word.StartsWith("#"))
                {
                    hashtags.Add(word.Replace("#", ""));
                }
            }
            return hashtags;
        }
        public static List<string> ToListOfMentions(this string text)
        {
            var mentions = new List<string>();
            foreach (var word in text.Split(null).ToList())
            {
                if (word.StartsWith("@"))
                {
                    mentions.Add(word.Replace("@", ""));
                }
            }
            return mentions;
        }
    }
}