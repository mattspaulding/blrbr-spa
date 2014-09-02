using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blrbr.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string AspNetId { get; set; }
       public long TwitterId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Username { get; set; }
        public string ProfileImageUrlNormal { get; set; }
        public string ProfileImageUrlBigger { get; set; }
        public string ProfileImageUrlBiggest { get; set; }
        public bool? ProfileUseBackgroundImage { get; set; }
        public string ProfileBackgroundImageURL { get; set; }
        public string ProfileBackgroundColor { get; set; }
        public bool? ProfileBackgroundTile { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool? Verified { get; set; }      
        public string FriendsBlob { get; set; }
        public int NumberOfBlrbrFriends { get; set; }
        public int NumberOfBlrbrFollowers { get; set; }
        public int NumberOfInvitationsAllowed { get; set; }
        public DateTime LastTimeStream { get; set; }
     
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Blrb> Blrbs { get; set; }
    }

    public class Friend
    {
        public int FriendId { get; set; }
        public long TwitterFriendId { get; set; }
        public string UserName { get; set; }
     }

    
}