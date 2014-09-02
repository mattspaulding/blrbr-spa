namespace SPAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlrbrModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blrbs",
                c => new
                    {
                        BlrbId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Sound = c.String(),
                        UserName = c.String(),
                        TwitterId = c.String(),
                        ScreenName = c.String(),
                        Channel = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        UserProfile_UserProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.BlrbId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserProfileId)
                .Index(t => t.UserProfile_UserProfileId);
            
            CreateTable(
                "dbo.BlrbStreamItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        TextWithMarkup = c.String(),
                        Sound = c.String(),
                        UserName = c.String(),
                        ScreenName = c.String(),
                        Img = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        ChannelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hashtag = c.String(),
                        Owner = c.String(),
                        ProfileImg = c.String(),
                        BannerImg = c.String(),
                        Color1 = c.String(),
                        Color2 = c.String(),
                    })
                .PrimaryKey(t => t.ChannelId);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        TwitterFriendId = c.Long(nullable: false),
                        UserName = c.String(),
                        UserProfile_UserProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserProfileId)
                .Index(t => t.UserProfile_UserProfileId);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashtagId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Username = c.String(),
                        BlrbId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HashtagId);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        InvitationID = c.Int(nullable: false, identity: true),
                        Inviter = c.String(),
                        TwitterHandle = c.String(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationID);
            
            CreateTable(
                "dbo.JoinAttempts",
                c => new
                    {
                        JoinAttemptID = c.Int(nullable: false, identity: true),
                        ScreenName = c.String(),
                        RawSource = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JoinAttemptID);
            
            CreateTable(
                "dbo.Mentions",
                c => new
                    {
                        MentionId = c.Int(nullable: false, identity: true),
                        Mentioner = c.String(),
                        Mentionee = c.String(),
                        BlrbId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MentionId);
            
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                        SignUpId = c.Int(nullable: false, identity: true),
                        TwitterHandle = c.String(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SignUpId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        AspNetId = c.String(),
                        TwitterId = c.Long(nullable: false),
                        Name = c.String(),
                        ScreenName = c.String(),
                        AccessToken = c.String(),
                        AccessTokenSecret = c.String(),
                        Username = c.String(),
                        ProfileImageUrlNormal = c.String(),
                        ProfileImageUrlBigger = c.String(),
                        ProfileImageUrlBiggest = c.String(),
                        ProfileUseBackgroundImage = c.Boolean(),
                        ProfileBackgroundImageURL = c.String(),
                        ProfileBackgroundColor = c.String(),
                        ProfileBackgroundTile = c.Boolean(),
                        Location = c.String(),
                        Description = c.String(),
                        Verified = c.Boolean(),
                        FriendsBlob = c.String(),
                        NumberOfBlrbrFriends = c.Int(nullable: false),
                        NumberOfBlrbrFollowers = c.Int(nullable: false),
                        NumberOfInvitationsAllowed = c.Int(nullable: false),
                        LastTimeStream = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Blrbs", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Friends", new[] { "UserProfile_UserProfileId" });
            DropIndex("dbo.Blrbs", new[] { "UserProfile_UserProfileId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.SignUps");
            DropTable("dbo.Mentions");
            DropTable("dbo.JoinAttempts");
            DropTable("dbo.Invitations");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Friends");
            DropTable("dbo.Channels");
            DropTable("dbo.BlrbStreamItems");
            DropTable("dbo.Blrbs");
        }
    }
}
