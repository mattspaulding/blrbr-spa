using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Blrbr.Models;
using System.Threading.Tasks;
using SPAuth.Models;

namespace Blrbr.Hubs
{
    public class BlrbHub : Hub
    {
        private AppContext db = new AppContext();

        public void Go(string test)
        {
          var blrb = new BlrbStreamItem { ScreenName = test,Img="http://www.tanmonkey.com/images/monkey/Funny-MonkeyReaction%20small.jpg",Sound="http://localhost:49379/Voice/blrbr_130307861567883285.mp3" };
            Clients.All.showBlrb(blrb);
         }

        public void Subscribe(string username)
        {
            var userProfile = db.UserProfiles.Where(x => x.Username == username).Single();
            if (userProfile.FriendsBlob != null)
            {
                var friendIds = userProfile.FriendsBlob.Split(',');
                foreach (var friendId in friendIds)
                {
                    Groups.Add(Context.ConnectionId, friendId);
                }
            }
        }
        public void SubscribeToChannel(string channel)
        {
                          Groups.Add(Context.ConnectionId, "channel_"+channel);
                    }

    }
}