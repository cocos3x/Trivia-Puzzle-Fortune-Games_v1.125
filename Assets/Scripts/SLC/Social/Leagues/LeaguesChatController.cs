using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesChatController : LeaguesServerController
    {
        // Fields
        private const string chat_index = "/chat/";
        private const string log_index = "/log/";
        
        // Methods
        public void GetGuildLog(SLC.Social.Profile myself, SLC.Social.Leagues.Guild guild, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "membership_id", value:  myself.ServerId);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + guild.ServerId + "/log/"("/log/");
        }
        public void GetGuildChat(SLC.Social.Profile myself, int guildServerId, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            SLC.Social.Leagues.Guild val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_1.Add(key:  "count", value:  val_3.chat);
            string val_4 = "/api/league/clubs/"("/api/league/clubs/") + guildServerId + "/chat/"("/chat/");
        }
        public void SendChat(SLC.Social.Profile myself, SLC.Social.Leagues.Guild guild, string messageToPost, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback, System.Action<string> onRequestFails)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            val_1.Add(key:  "message", value:  messageToPost);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + guild.ServerId + "/chat/"("/chat/");
        }
        public LeaguesChatController()
        {
        
        }
    
    }

}
