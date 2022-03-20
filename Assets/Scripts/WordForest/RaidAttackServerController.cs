using UnityEngine;

namespace WordForest
{
    public class RaidAttackServerController : MonoBehaviour
    {
        // Fields
        private static int REQUEST_TIMEOUT;
        private const string SERVER_URL_PRODUCTION = "https://word-forest-api-raids.12gigs.com";
        private const string SERVER_URL_STAGING = "https://word-forest-stage-raids.12gigs.com";
        protected const string api_ns = "/api/words/forests";
        protected const string acorns_index = "/acorns/";
        protected const string raid_index = "/raid/";
        protected const string attack_index = "/attack/";
        protected const string attack_friends_index = "/attack/friends/";
        protected const string revenges_index = "/revenges/";
        protected const string grow_index = "/grow/";
        protected const string shields_index = "/shields/";
        private twelvegigs.net.JsonApiRequester apiRequester;
        private int <shieldsLostBetweenSessions>k__BackingField;
        private int <acornsLostBetweenSessions>k__BackingField;
        private System.Collections.Generic.List<string> serverLogs;
        
        // Properties
        public static bool IsInitialResponseSuccess { get; set; }
        private string ServerURL { get; }
        public int shieldsLostBetweenSessions { get; set; }
        public int acornsLostBetweenSessions { get; set; }
        
        // Methods
        public static bool get_IsInitialResponseSuccess()
        {
            return UnityEngine.PlayerPrefs.HasKey(key:  "PP_Raids_InitCall");
        }
        public static void set_IsInitialResponseSuccess(bool value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "PP_Raids_InitCall", value:  10);
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        private string get_ServerURL()
        {
            return "https://word-forest-api-raids.12gigs.com";
        }
        private void Start()
        {
            this.apiRequester = new twelvegigs.net.JsonApiRequester(ServerURL:  "https://word-forest-api-raids.12gigs.com", dequeueHandler:  new System.Action(object:  this, method:  System.Void WordForest.RaidAttackServerController::<Start>b__17_0()), logStuff:  true, adminServerURL:  0, throwExceptionsOnRequestFailures:  true);
        }
        public void InitialRequest(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_6;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
            val_6 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_5 = App.Player;
            val_4.Add(key:  "user_id", value:  val_5.id);
            val_4.Add(key:  "map", value:  val_3.forestMapData);
        }
        public void GetForestProfile(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_8;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if(val_3.forestServerId < 1)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
            val_8 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_5 = App.Player;
            val_4.Add(key:  "user_id", value:  val_5.id);
            WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
            string val_7 = "/"("/") + val_6.forestServerId;
        }
        public void SetForestProfile(System.Nullable<int> forestLevel, WordForest.Map map, System.Nullable<int> acorns, System.Nullable<int> shields, string fbid, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_6;
            var val_8;
            var val_13;
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if(val_1.forestServerId < 1)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
            val_13 = val_2;
            val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_3 = App.Player;
            val_2.Add(key:  "user_id", value:  val_3.id);
            if((forestLevel.HasValue & true) == 0)
            {
                    val_2.Add(key:  "level", value:  forestLevel.HasValue.Value);
            }
            
            if(map != null)
            {
                    val_2.Add(key:  "map", value:  map.Encode());
            }
            
            if(val_6 != false)
            {
                    val_2.Add(key:  "acorns", value:  acorns.HasValue.Value);
            }
            
            if(val_8 != false)
            {
                    val_2.Add(key:  "shields", value:  shields.HasValue.Value);
            }
            
            if((System.String.IsNullOrEmpty(value:  fbid)) != true)
            {
                    val_2.Add(key:  "fbid", value:  fbid);
            }
            
            WordForest.WFOPlayer val_11 = WordForest.WFOPlayer.Instance;
            string val_12 = "/"("/") + val_11.forestServerId;
        }
        public void GrowTree(int treeId, int growthCost, System.Action<bool, System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            int val_12;
            int val_13;
            int val_14;
            val_12 = growthCost;
            val_13 = treeId;
            RaidAttackServerController.<>c__DisplayClass21_0 val_1 = new RaidAttackServerController.<>c__DisplayClass21_0();
            .responseCallback = responseCallback;
            Player val_2 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_2.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            if(val_4.forestServerId < 1)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_6 = App.Player;
            val_5.Add(key:  "user_id", value:  val_6.id);
            val_5.Add(key:  "acorns", value:  val_12);
            object[] val_7 = new object[4];
            val_7[0] = "/";
            WordForest.WFOPlayer val_8 = WordForest.WFOPlayer.Instance;
            val_14 = val_7.Length;
            val_7[1] = val_8.forestServerId;
            val_14 = val_7.Length;
            val_7[2] = "/grow/";
            val_7[3] = val_13;
            val_13 = +val_7;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_10 = null;
            val_12 = val_10;
            val_10 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void RaidAttackServerController.<>c__DisplayClass21_0::<GrowTree>b__0(System.Collections.Generic.Dictionary<string, object> resp));
            System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_11 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void RaidAttackServerController.<>c__DisplayClass21_0::<GrowTree>b__1(string apicall, System.Collections.Generic.Dictionary<string, object> resp));
        }
        public void GetEcon()
        {
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            Player val_4 = App.Player;
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "user_id", value:  val_4.id);
        }
        public void GetRaidOpponentPool(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_9;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if(val_3.forestServerId < 1)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
            val_9 = val_5;
            val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_6 = App.Player;
            1152921504884269056 = 1152921515419383392;
            val_5.Add(key:  "user_id", value:  val_6.id);
            val_5.Add(key:  "forest_id", value:  val_4.forestServerId);
            UnityEngine.Vector2Int val_7 = WordForest.WFOGameEconHelper.GetRaidEligibleAcornsMinMax(forestLevel:  val_4.currentForestID);
            val_5.Add(key:  "acorns", value:  val_7.m_X.y);
            val_5.Add(key:  "base_level", value:  val_4.currentForestID);
        }
        public void InitializeRaid(int opponentId, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if(val_3.forestServerId < 1)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_6 = App.Player;
            val_5.Add(key:  "user_id", value:  val_6.id);
            val_5.Add(key:  "receiver_forest_id", value:  opponentId);
        }
        public void ConcludeRaid(string raidId, System.Collections.Generic.List<int> chosenRewardIndexes, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            object val_12;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            int val_12 = val_3.forestServerId;
            if(val_12 < 1)
            {
                    return;
            }
            
            if(chosenRewardIndexes == null)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  raidId)) == true)
            {
                    return;
            }
            
            if(val_12 < 1)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
            if(val_12 >= 1)
            {
                    var val_13 = 0;
                do
            {
                if(val_13 >= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_12 = val_12 + 0;
                if(val_13 < ((long)val_12 - 1))
            {
                    string val_7 = 0 + (val_3.forestServerId + 0) + 32((val_3.forestServerId + 0) + 32) + "|"("|");
            }
            
                val_13 = val_13 + 1;
                val_12 = 0 + (val_3.forestServerId + 0) + 32((val_3.forestServerId + 0) + 32);
            }
            while(val_13 < ((val_3.forestServerId + 0) + 32));
            
            }
            else
            {
                    val_12 = 0;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_10 = App.Player;
            val_9.Add(key:  "user_id", value:  val_10.id);
            val_9.Add(key:  "selected_option_indexes", value:  val_12);
            string val_11 = "/raid/"("/raid/") + raidId;
        }
        public void GetAttackOpponentPool(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_7;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if(val_3.forestServerId < 1)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
            val_7 = val_5;
            val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_6 = App.Player;
            1152921504884269056 = 1152921515419383392;
            val_5.Add(key:  "user_id", value:  val_6.id);
            val_5.Add(key:  "forest_id", value:  val_4.forestServerId);
            val_5.Add(key:  "base_level", value:  val_4.currentForestID);
        }
        public void ResolveAttack(int opponentId, int treeId, System.Nullable<bool> autoSuccess, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_10;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
            val_10 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_5 = App.Player;
            1152921504884269056 = 1152921515419383392;
            val_4.Add(key:  "user_id", value:  val_5.id);
            val_4.Add(key:  "tree_id", value:  treeId);
            if((autoSuccess.HasValue & 65535) >= true)
            {
                    val_4.Add(key:  "auto_success", value:  autoSuccess.HasValue.Value);
            }
            
            string val_9 = "/attack/"("/attack/") + opponentId;
        }
        public void GetRevengeOpponentPool(System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            var val_7;
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
            val_7 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_5 = App.Player;
            val_4.Add(key:  "user_id", value:  val_5.id);
            string val_6 = "/"("/") + val_3.forestServerId + "/revenges/"("/revenges/");
        }
        public void GetFriendsOpponentPool(string[] fbidList, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            Player val_1 = App.Player;
            if(fbidList == null)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            if(fbidList.Length == 0)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Player val_5 = App.Player;
            val_4.Add(key:  "user_id", value:  val_5.id);
            val_4.Add(key:  "fbids", value:  fbidList);
        }
        protected virtual bool PreProcessFilter(string apiCall, System.Collections.Generic.Dictionary<string, object> response)
        {
            var val_4;
            if(response == null)
            {
                goto label_5;
            }
            
            if((response.ContainsKey(key:  "success")) == false)
            {
                goto label_2;
            }
            
            object val_2 = response.Item["success"];
            if(null == null)
            {
                goto label_5;
            }
            
            label_2:
            val_4 = 1;
            this.AddToServerLogsResponse(endpoint:  apiCall, isSuccess:  true, val:  "success");
            return (bool)val_4;
            label_5:
            this.AddToServerLogsResponse(endpoint:  apiCall, isSuccess:  false, val:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  response));
            this.HandleError(apiCall:  apiCall, response:  response);
            val_4 = 0;
            return (bool)val_4;
        }
        protected virtual void DoRequest(WordForest.RequestType verb, string uri, System.Collections.Generic.Dictionary<string, object> requestParameters, System.Action<System.Collections.Generic.Dictionary<string, object>> onCompleteCallback, bool doPostUpdate = True, object request, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onRequestFails)
        {
            object val_9;
            System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_10;
            RaidAttackServerController.<>c__DisplayClass31_0 val_1 = null;
            val_9 = val_1;
            val_1 = new RaidAttackServerController.<>c__DisplayClass31_0();
            .<>4__this = this;
            .onCompleteCallback = onCompleteCallback;
            .request = request;
            .onRequestFails = onRequestFails;
            .doPostUpdate = doPostUpdate;
            val_10 = verb;
            this.AddToServerLogs(verbType:  verb.ToString(), endpoint:  uri, requestParams:  requestParameters);
            string val_4 = "/api/words/forests"("/api/words/forests") + uri;
            if(verb > 3)
            {
                    return;
            }
            
            var val_9 = 32558632 + (verb) << 2;
            val_9 = val_9 + 32558632;
            goto (32558632 + (verb) << 2 + 32558632);
        }
        private void TryPostUpdate(System.Collections.Generic.Dictionary<string, object> responseObject, object request)
        {
            var val_7;
            var val_8;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = responseObject;
            if((val_8.ContainsKey(key:  "myself")) != false)
            {
                    object val_2 = val_8.Item["myself"];
                val_7 = 0;
                this.ProcessMyselfData(myselfDict:  null);
            }
            
            if((val_8.ContainsKey(key:  "econ")) == false)
            {
                    return;
            }
            
            object val_4 = val_8.Item["econ"];
            val_8 = 0;
            WordForest.WFOGameEcon.Instance.ParseServerJsonKnobs(jsonDict:  null);
            WordForest.WFOGameEcon.Instance.CacheServerJsonKnobs(jsonDict:  null);
        }
        private void ProcessMyselfData(System.Collections.Generic.Dictionary<string, object> myselfDict)
        {
            var val_10;
            var val_11;
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.UserForestProfile val_2 = new WordForest.UserForestProfile();
            WordForest.RaidAttackManager val_3 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            val_3.dataController.<QA_myself>k__BackingField = val_2;
            val_10 = null;
            bool val_4 = WordForest.RaidAttackServerController.IsInitialResponseSuccess;
            if(val_4 != false)
            {
                    val_4.ApplyPossibleAttacksOnMap(localPlayer:  val_1, myselfDict:  myselfDict);
                val_4.ApplyPossibleShieldsLost(localPlayer:  val_1, myDataFromServer:  val_2);
                this.ApplyOtherShits(player:  val_1, myDataFromServer:  val_2, overrideMapInfo:  false);
                WordForest.RaidAttackManager val_5 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_5.dataController.ProcessNewsArticles(news:  (WordForest.UserForestProfile)[1152921518088803008].news);
                return;
            }
            
            val_11 = null;
            if(WordForest.RaidAttackServerController.IsInitialResponseSuccess != false)
            {
                    return;
            }
            
            val_1.forestServerId = (WordForest.UserForestProfile)[1152921518088803008].serverId;
            bool val_7 = val_1.UpgradePlayer;
            if(val_7 != false)
            {
                    val_1.forestServerId = (WordForest.UserForestProfile)[1152921518088803008].serverId;
                WordForest.RaidAttackManager val_8 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_8.dataController.ProcessNewsArticles(news:  (WordForest.UserForestProfile)[1152921518088803008].news);
            }
            else
            {
                    val_7.ApplyPossibleAttacksOnMap(localPlayer:  val_1, myselfDict:  myselfDict);
                val_7.ApplyPossibleShieldsLost(localPlayer:  val_1, myDataFromServer:  val_2);
                this.ApplyOtherShits(player:  val_1, myDataFromServer:  val_2, overrideMapInfo:  true);
                WordForest.RaidAttackManager val_9 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_9.notifyController.Notify(note:  0, data:  0);
            }
            
            WordForest.RaidAttackServerController.IsInitialResponseSuccess = false;
        }
        private void ApplyOtherShits(WordForest.WFOPlayer player, WordForest.UserForestProfile myDataFromServer, bool overrideMapInfo = False)
        {
            var val_7;
            int val_2 = player.acorns - myDataFromServer.acorns;
            if(val_2 >= 1)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                val_3.Add(key:  "Amount Spent", value:  UnityEngine.Mathf.Abs(value:  val_2));
                val_3.Add(key:  "Source", value:  "Raided");
                val_7 = null;
                val_7 = null;
                App.trackerManager.track(eventName:  "Golden Currency Spent", data:  val_3);
                this.<acornsLostBetweenSessions>k__BackingField = val_2;
            }
            
            player.currentChestID = myDataFromServer.level;
            player.currentForestID = myDataFromServer.level;
            if(((overrideMapInfo != false) && (myDataFromServer.map != null)) && (myDataFromServer.map.GetForestData() != null))
            {
                    System.Collections.Generic.List<WordForest.MapItem> val_6 = myDataFromServer.map.GetForestData();
                if(myDataFromServer.level >= 1)
            {
                    player.forestMapData = myDataFromServer.map;
            }
            
            }
            
            player.acorns = myDataFromServer.acorns;
            player.raidsSent = myDataFromServer.raidsSent;
            player.raidsReceived = myDataFromServer.raidsReceived;
            player.attacksSent = myDataFromServer.attacksSent;
            player.attacksReceived = myDataFromServer.attacksReceived;
        }
        private void ApplyPossibleShieldsLost(WordForest.WFOPlayer localPlayer, WordForest.UserForestProfile myDataFromServer)
        {
            localPlayer.shields = System.Math.Min(val1:  localPlayer.shields, val2:  myDataFromServer.shields);
        }
        private void ApplyPossibleAttacksOnMap(WordForest.WFOPlayer localPlayer, System.Collections.Generic.Dictionary<string, object> myselfDict)
        {
            var val_8;
            var val_9;
            System.Collections.Generic.List<WordForest.MapItem> val_1 = localPlayer.forestMapData.GetForestData();
            val_8 = "attacks_to_apply";
            if((myselfDict.ContainsKey(key:  "attacks_to_apply")) == false)
            {
                    return;
            }
            
            int val_4 = System.Int32.Parse(s:  myselfDict.Item["attacks_to_apply"], style:  511);
            if(val_4 < 1)
            {
                    return;
            }
            
            var val_10 = val_4;
            label_19:
            int val_5 = UnityEngine.Random.Range(min:  0, max:  511);
            val_8 = val_5;
            if(null <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            object val_6 = 1152921504626761728 + (val_8 << 3);
            var val_9 = mem[(1152921504626761728 + (val_5) << 3) + 32];
            var val_7 = 10 - 1;
            if((System.String.op_Inequality(a:  mem[(1152921504626761728 + (val_5) << 3) + 32] + 16, b:  "tree")) == true)
            {
                goto label_10;
            }
            
            if(val_9 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + (((long)(int)(val_5)) << 3);
            val_9 = mem[(mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32];
            val_9 = (mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32;
            if(((mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32 + 28) == 1)
            {
                goto label_13;
            }
            
            label_10:
            if(val_7 >= 1)
            {
                goto label_19;
            }
            
            return;
            label_13:
            if(((mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32 + 28) <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_9 = val_9 + (((long)(int)(val_5)) << 3);
                val_9 = mem[((mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32 + ((long)(int)(val_5)) << 3) + 32];
                val_9 = ((mem[(1152921504626761728 + (val_5) << 3) + 32] + ((long)(int)(val_5)) << 3) + 32 + ((long)(int)(val_5)) << 3) + 32;
            }
            
            mem2[0] = 2;
            if(val_7 < 1)
            {
                    return;
            }
            
            val_10 = val_10 - 1;
            if(val_10 >= 2)
            {
                goto label_19;
            }
        
        }
        private void HandleError(string apiCall, System.Collections.Generic.Dictionary<string, object> response)
        {
            if(CompanyDevices.Instance.CompanyDevice() == false)
            {
                    return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[RaidAttack] \'" + apiCall + "\' response: "("\' response: ") + Newtonsoft.Json.JsonConvert.SerializeObject(value:  response)(Newtonsoft.Json.JsonConvert.SerializeObject(value:  response)));
        }
        public int get_shieldsLostBetweenSessions()
        {
            return (int)this.<shieldsLostBetweenSessions>k__BackingField;
        }
        private void set_shieldsLostBetweenSessions(int value)
        {
            this.<shieldsLostBetweenSessions>k__BackingField = value;
        }
        public int get_acornsLostBetweenSessions()
        {
            return (int)this.<acornsLostBetweenSessions>k__BackingField;
        }
        private void set_acornsLostBetweenSessions(int value)
        {
            this.<acornsLostBetweenSessions>k__BackingField = value;
        }
        public string GetServerLogs()
        {
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            List.Enumerator<T> val_2 = this.serverLogs.GetEnumerator();
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_4 = val_1.AppendLine(value:  0);
            goto label_4;
            label_2:
            0.Dispose();
            return (string)val_1;
        }
        private void AddToServerLogs(string verbType, string endpoint, System.Collections.Generic.Dictionary<string, object> requestParams)
        {
            string val_12 = endpoint;
            if(((val_12.IndexOf(value:  "/api/words/forests")) & 2147483648) == 0)
            {
                    val_12 = val_12.Substring(startIndex:  ("/api/words/forests".__il2cppRuntimeField_10 + val_1)>>0&0xFFFFFFFF);
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>(dictionary:  requestParams);
            bool val_4 = val_3.Remove(key:  "user_id");
            if((System.String.op_Equality(a:  verbType, b:  "PUT")) != false)
            {
                    WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
                if((System.String.op_Equality(a:  val_12, b:  "/"("/") + val_6.forestServerId)) != false)
            {
                    bool val_9 = val_3.Remove(key:  "map");
            }
            
            }
            
            this.serverLogs.Add(item:  System.String.Format(format:  "<color=#ffef00><b>[{0}] {1}</b></color> Params: {2}", arg0:  verbType, arg1:  val_12, arg2:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_3)));
        }
        private void AddToServerLogsResponse(string endpoint, bool isSuccess, string val)
        {
            string val_7 = endpoint;
            if(((val_7.IndexOf(value:  "/api/words/forests")) & 2147483648) == 0)
            {
                    val_7 = val_7.Substring(startIndex:  ("/api/words/forests".__il2cppRuntimeField_10 + val_1)>>0&0xFFFFFFFF);
            }
            
            int val_3 = val_7.LastIndexOf(value:  '?');
            if((val_3 & 2147483648) == 0)
            {
                    val_7 = val_7.Substring(startIndex:  0, length:  val_3);
            }
            
            this.serverLogs.Add(item:  System.String.Format(format:  "    <color=#{0}><b>[reply] {1}</b></color> {2}", arg0:  (isSuccess != true) ? "00ee00" : "ee0000", arg1:  val_7, arg2:  val));
        }
        public void ResetForest()
        {
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if(val_3.forestServerId < 1)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            Player val_6 = App.Player;
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "user_id", value:  val_6.id);
            WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
            string val_8 = "/"("/") + val_7.forestServerId + "/reset"("/reset");
        }
        public RaidAttackServerController()
        {
            this.serverLogs = new System.Collections.Generic.List<System.String>();
        }
        private static RaidAttackServerController()
        {
            WordForest.RaidAttackServerController.shields_index = null;
        }
        private void <Start>b__17_0()
        {
            if(this.apiRequester != null)
            {
                    this.apiRequester.Dequeue();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
