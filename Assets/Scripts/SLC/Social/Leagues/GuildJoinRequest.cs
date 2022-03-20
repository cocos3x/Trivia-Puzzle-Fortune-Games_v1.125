using UnityEngine;

namespace SLC.Social.Leagues
{
    public class GuildJoinRequest
    {
        // Fields
        public SLC.Social.Profile sender;
        public SLC.Social.Leagues.Guild requestedGuild;
        public int ServerId;
        
        // Methods
        public GuildJoinRequest(SLC.Social.Profile requestingMember, SLC.Social.Leagues.Guild requestingGuild)
        {
            val_1 = new System.Object();
            this.sender = requestingMember;
            this.requestedGuild = val_1;
        }
        public void AcceptRequest()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.AcceptGuildRequest(inviteRequest:  this);
            this.requestedGuild.AddMember(toAdd:  this.sender);
            this.requestedGuild.RemoveInvite(toRemove:  this);
        }
        public void RejectRequest()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.RejectGuildRequest(inviteRequest:  this);
            this.requestedGuild.RemoveInvite(toRemove:  this);
        }
    
    }

}
