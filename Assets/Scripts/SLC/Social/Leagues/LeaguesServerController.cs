using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesServerController : MonoBehaviour
    {
        // Fields
        private static int REQUEST_TIMEOUT;
        private static object BlockingRequest;
        protected System.Action<System.Collections.Generic.Dictionary<string, object>> dataFilter;
        protected const string api_ns = "/api/league";
        protected const string clubs_index = "/clubs/";
        protected const string clubs_open = "/clubs/open/";
        protected const string clubs_ranks = "/ranks/";
        protected const string clubs_search = "/clubs/search/";
        protected const string clubs_join = "/join/";
        protected const string clubs_private_join = "/invites/";
        protected const string clubs_members = "/members/";
        protected const string accept_invite = "/accept/";
        protected const string reject_invite = "/reject/";
        protected const string co_leaders = "/co_leaders/";
        protected const string points_index = "/points/";
        protected const string memberships_index = "/memberships/";
        protected const string coins_index = "/coins/";
        protected const string reset_index = "/resets/";
        protected const string multiplier_index = "/points_multiplier/";
        
        // Methods
        public void ContributePoints(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, int pointsToContribute, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "points", value:  pointsToContribute);
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/points/"("/points/");
        }
        public void ContributePointsNoGuild(SLC.Social.Profile myself, int pointsToContribute, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "points", value:  pointsToContribute);
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
        }
        public void ContributeCoins(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, decimal coinsToContribute, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "coins", value:  coinsToContribute.flags.ToString());
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/coins/"("/coins/");
        }
        public void ContributeMultiplier(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, decimal multiplierToContribute, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "multiplier", value:  multiplierToContribute.flags.ToString(provider:  System.Globalization.CultureInfo.InvariantCulture));
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            string val_4 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/points_multiplier/"("/points_multiplier/");
        }
        public void UpdateUserInfo(SLC.Social.Profile myself, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback, bool hasCollectedFirstGuildReward)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            val_1.Add(key:  "name", value:  myself.Name);
            val_1.Add(key:  "avatar", value:  myself.AvatarId);
            val_1.Add(key:  "portrait_id", value:  myself.Portrait_ID);
            val_1.Add(key:  "fbid", value:  myself.FacebookId);
            val_1.Add(key:  "level", value:  myself.Level);
            val_1.Add(key:  "first_rew", value:  hasCollectedFirstGuildReward);
            val_1.Add(key:  "golden_currency", value:  myself.goldenCurrency);
            val_1.Add(key:  "use_fb_pic", value:  myself.UseFacebook);
            string val_4 = "/api/league/memberships/"("/api/league/memberships/") + myself.ServerId;
        }
        public void UpdateGuildInfo(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "guild", value:  myGuild.Encode(destination:  0));
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId;
        }
        public void DemoteMember(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, SLC.Social.Profile toDemote, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            val_1.Add(key:  "co_leader_membership_id", value:  toDemote.ServerId);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/co_leaders/"("/co_leaders/");
        }
        public void PromoteMember(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, SLC.Social.Profile toPromote, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "membership_id", value:  myself.ServerId);
            val_1.Add(key:  "co_leader_membership_id", value:  toPromote.ServerId);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/co_leaders/"("/co_leaders/");
        }
        public void RemoveGuildMember(SLC.Social.Profile myself, SLC.Social.Leagues.Guild myGuild, SLC.Social.Profile toDelete, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_4 = null;
            SLC.Social.Leagues.LeaguesServerController.BlockingRequest = new UnityEngine.GameObject();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "membership_id", value:  myself.ServerId);
            val_2.Add(key:  "membership_id_to_remove", value:  toDelete.ServerId);
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + myGuild.ServerId + "/members/"("/members/");
        }
        public void RejectInviteRequest(SLC.Social.Profile myself, SLC.Social.Leagues.GuildJoinRequest requested, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "membership_id", value:  myself.ServerId);
            string val_2 = "/api/league/invites/"("/api/league/invites/") + requested.ServerId + "/reject/"("/reject/");
        }
        public void AcceptInviteRequest(SLC.Social.Profile myself, SLC.Social.Leagues.GuildJoinRequest requested, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "membership_id", value:  myself.ServerId);
            string val_2 = "/api/league/invites/"("/api/league/invites/") + requested.ServerId + "/accept/"("/accept/");
        }
        public void GetOtherGuild(SLC.Social.Profile member, int guildServerId, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            string val_4;
            string val_5;
            if(member.ServerId != 1)
            {
                    val_4 = "membership_id";
                val_5 = member.ServerId;
            }
            else
            {
                    Player val_2 = App.Player;
                val_5 = val_2.id;
                val_4 = "user_id";
            }
            
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  val_4, value:  val_5);
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + guildServerId;
        }
        public void JoinPrivateGuild(SLC.Social.Leagues.Guild toJoin, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            val_1.Add(key:  "guild_id", value:  toJoin.ServerId);
        }
        public void JoinGuild(SLC.Social.Leagues.Guild toJoin, SLC.Social.Leagues.Guild oldGuild, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            Player val_2 = App.Player;
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "user_id", value:  val_2.id);
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + toJoin.ServerId + "/join/"("/join/");
        }
        public void InitialRequest(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_5;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = null;
            val_5 = val_3;
            val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_4 = App.Player;
            val_3.Add(key:  "user_id", value:  val_4.id);
        }
        public void CreateGuild(SLC.Social.Profile member, SLC.Social.Leagues.Guild guild, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            16751 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "guild", value:  guild.Encode(destination:  0));
            Player val_3 = App.Player;
            val_1.Add(key:  "user_id", value:  val_3.id);
        }
        public void GetEligibleGuildsToJoin(SLC.Social.Profile member, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            Player val_2 = App.Player;
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "user_id", value:  val_2.id);
        }
        public void GetMyGuildInvites(SLC.Social.Profile member, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            string val_2 = "/api/league/memberships/"("/api/league/memberships/") + member.ServerId + "/invites/"("/invites/");
        }
        public void InviteToMyGuild(SLC.Social.Profile me, int myClubId, int idToInvite, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "membership_id", value:  me.ServerId);
            val_1.Add(key:  "invited_membership_id", value:  idToInvite);
            string val_2 = "/api/league/clubs/"("/api/league/clubs/") + myClubId + "/invites/"("/invites/");
        }
        public void ConsumeClubInvite(SLC.Social.Profile me, int inviteClubId, bool accepted, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            int val_6;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            val_1.Add(key:  "guild_id", value:  inviteClubId);
            object val_3 = (accepted != true) ? "accept" : "reject";
            object[] val_4 = new object[4];
            val_4[0] = "/api/league/memberships/";
            val_6 = val_4.Length;
            val_4[1] = me.ServerId;
            val_6 = val_4.Length;
            val_4[2] = "/invites/";
            if(val_3 != 0)
            {
                    val_6 = val_4.Length;
            }
            
            val_4[3] = val_3;
            string val_5 = +val_4;
        }
        public void GetGuildsByName(SLC.Social.Profile member, string queryString, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            val_1.Add(key:  "q", value:  queryString);
        }
        public void GetGuildsInMyTier(int serverId, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            string val_3 = "/api/league/clubs/"("/api/league/clubs/") + serverId.ToString() + "/ranks/"("/ranks/");
        }
        public void GetGuildsInThisTier(int tier, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            val_1.Add(key:  "tier", value:  tier);
        }
        public void PurchaseProMembership(SLC.Social.Profile myself, string membershipLevel, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "level", value:  membershipLevel);
            string val_2 = "/api/league/memberships/"("/api/league/memberships/") + myself.ServerId + "/pro/"("/pro/");
        }
        public void CollectProMembershipBonus(SLC.Social.Profile myself, string membershipLevel, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            string val_2 = "/api/league/memberships/"("/api/league/memberships/") + myself.ServerId + "/pro/collect"("/pro/collect");
        }
        public void ResetMembership(SLC.Social.Profile member, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback, string fields)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_2 = App.Player;
            val_1.Add(key:  "user_id", value:  val_2.id);
            if((System.String.IsNullOrEmpty(value:  fields)) != true)
            {
                    val_1.Add(key:  "fields", value:  fields);
            }
            
            string val_4 = "/api/league/resets/"("/api/league/resets/") + member.ServerId;
        }
        protected virtual bool PreProcessFilter(string apiCall, System.Collections.Generic.Dictionary<string, object> response)
        {
            var val_10;
            var val_11;
            if(((apiCall.Contains(value:  "/log/")) != true) && ((apiCall.Contains(value:  "/chat/")) != true))
            {
                    val_10 = null;
                val_10 = null;
                if(Logger.Leagues != false)
            {
                    UnityEngine.Debug.Log(message:  "LEAGUES API RESPONSE: "("LEAGUES API RESPONSE: ") + apiCall + " :: "(" :: ") + Newtonsoft.Json.JsonConvert.SerializeObject(value:  response, formatting:  1)(Newtonsoft.Json.JsonConvert.SerializeObject(value:  response, formatting:  1)));
            }
            
            }
            
            if(response == null)
            {
                goto label_15;
            }
            
            if((response.ContainsKey(key:  "success")) == false)
            {
                goto label_12;
            }
            
            object val_6 = response.Item["success"];
            if(null == null)
            {
                goto label_15;
            }
            
            label_12:
            if(this.dataFilter != null)
            {
                    this.dataFilter.Invoke(obj:  response);
            }
            
            if((response.ContainsKey(key:  "data_flush")) == false)
            {
                goto label_17;
            }
            
            object val_8 = response.Item["data_flush"];
            if(null != null)
            {
                goto label_20;
            }
            
            label_17:
            val_11 = 1;
            return (bool)val_11;
            label_15:
            MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.HandleError(apiCall:  apiCall, responseObject:  response);
            label_20:
            val_11 = 0;
            return (bool)val_11;
        }
        public virtual void RegisterDataFilter(System.Action<System.Collections.Generic.Dictionary<string, object>> callback)
        {
            this.dataFilter = callback;
        }
        protected virtual void DoRequest(SLC.Social.Leagues.RequestType verb, string uri, System.Collections.Generic.Dictionary<string, object> requestParameters, System.Action<System.Collections.Generic.Dictionary<string, object>> onCompleteCallback, bool doPostUpdate = True, object request, System.Action<string> onRequestFails)
        {
            System.Action<System.String> val_13;
            SLC.Social.Leagues.RequestType val_14;
            object val_15;
            var val_16;
            int val_17;
            int val_18;
            val_13 = onRequestFails;
            val_14 = verb;
            LeaguesServerController.<>c__DisplayClass31_0 val_1 = null;
            val_15 = val_1;
            val_1 = new LeaguesServerController.<>c__DisplayClass31_0();
            .<>4__this = this;
            .onCompleteCallback = onCompleteCallback;
            .doPostUpdate = doPostUpdate;
            .request = request;
            .onRequestFails = val_13;
            if(((uri.Contains(value:  "/log/")) != true) && ((uri.Contains(value:  "/chat/")) != true))
            {
                    val_13 = 1152921504884002816;
                val_16 = null;
                val_16 = null;
                if(Logger.Leagues != false)
            {
                    string[] val_5 = new string[6];
                val_5[0] = "LEAGUES API REQUEST ";
                val_17 = val_5.Length;
                val_5[1] = verb.ToString();
                val_17 = val_5.Length;
                val_5[2] = ": ";
                val_18 = val_5.Length;
                val_5[3] = uri;
                val_18 = val_5.Length;
                val_5[4] = " ";
                val_13 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  requestParameters);
                val_5[5] = val_13;
                UnityEngine.Debug.Log(message:  +val_5);
                val_14 = verb;
            }
            
            }
            
            if(val_14 > 3)
            {
                    return;
            }
            
            var val_13 = 32561536 + (verb) << 2;
            val_13 = val_13 + 32561536;
            goto (32561536 + (verb) << 2 + 32561536);
        }
        private void TryPostUpdate(System.Collections.Generic.Dictionary<string, object> responseObject, object request)
        {
            object val_24;
            var val_25;
            object val_26;
            var val_27;
            UnityEngine.Object val_28;
            val_24 = responseObject;
            val_25 = null;
            val_25 = null;
            val_26 = SLC.Social.Leagues.LeaguesServerController.BlockingRequest;
            if(val_26 != null)
            {
                    val_26 = SLC.Social.Leagues.LeaguesServerController.BlockingRequest;
                if(val_26 != request)
            {
                    return;
            }
            
            }
            
            if((val_24.ContainsKey(key:  "myself")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  1);
            }
            
            if((val_24.ContainsKey(key:  "guild")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  2);
            }
            
            if((val_24.ContainsKey(key:  "chat")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  4);
            }
            
            if((val_24.ContainsKey(key:  "log")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  5);
            }
            
            if((val_24.ContainsKey(key:  "events")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  6);
            }
            
            if((val_24.ContainsKey(key:  "event")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  6);
            }
            
            if((val_24.ContainsKey(key:  "event_rewards")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  6);
                SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  10);
            }
            
            if((val_24.ContainsKey(key:  "guilds")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  7);
            }
            
            if((val_24.ContainsKey(key:  "memberships")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  3);
            }
            
            if((val_24.ContainsKey(key:  "membership")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  3);
            }
            
            SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  0);
            val_27 = null;
            val_27 = null;
            val_24 = SLC.Social.Leagues.LeaguesServerController.BlockingRequest;
            if(val_24 != null)
            {
                    var val_23 = (null == null) ? (val_24) : 0;
            }
            else
            {
                    val_28 = 0;
            }
            
            UnityEngine.Object.DestroyImmediate(obj:  val_28);
            SLC.Social.Leagues.LeaguesServerController.BlockingRequest = 0;
        }
        private void Awake()
        {
            goto typeof(SLC.Social.Leagues.LeaguesServerController).__il2cppRuntimeField_1A0;
        }
        protected virtual void AwakeLogic()
        {
        
        }
        public LeaguesServerController()
        {
        
        }
        private static LeaguesServerController()
        {
            SLC.Social.Leagues.LeaguesServerController.multiplier_index = null;
            SLC.Social.Leagues.LeaguesServerController.BlockingRequest = 0;
        }
    
    }

}
