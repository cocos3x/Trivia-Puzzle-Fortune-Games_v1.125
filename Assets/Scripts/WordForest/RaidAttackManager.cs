using UnityEngine;

namespace WordForest
{
    public class RaidAttackManager : MonoSingleton<WordForest.RaidAttackManager>
    {
        // Fields
        private const float REFRESH_REQUEST_INTERVAL = 30;
        private const float REFRESH_ECON_INTERVAL = 600;
        public static bool queueNewsPopup;
        public static bool lastAttackResult;
        public static bool lastRaidPerfect;
        public bool isEligibleForRevengeFtux;
        private SLC.Social.AvatarConfig avatarConfig;
        private WordForest.RaidAttackDataController dataController;
        private WordForest.RaidAttackServerController serverController;
        private WordForest.RaidAttackNotifyController notifyController;
        private float nextRefresh;
        private float nextRefreshEcon;
        private string currentRaidId;
        private WordForest.UserForestProfile <currentRaidOpponent>k__BackingField;
        private System.Collections.Generic.List<int> <currentRaidPickerOptions>k__BackingField;
        private WordForest.UserForestProfile <currentAttackOpponent>k__BackingField;
        
        // Properties
        public SLC.Social.AvatarConfig AvatarSpriteConfig { get; }
        public WordForest.RaidAttackDataController Data { get; }
        public WordForest.RaidAttackServerController ServerAPI { get; }
        public WordForest.RaidAttackNotifyController NotifyAPI { get; }
        public WordForest.UserForestProfile currentRaidOpponent { get; set; }
        public System.Collections.Generic.List<int> currentRaidPickerOptions { get; set; }
        public WordForest.UserForestProfile currentAttackOpponent { get; set; }
        
        // Methods
        public SLC.Social.AvatarConfig get_AvatarSpriteConfig()
        {
            return (SLC.Social.AvatarConfig)this.avatarConfig;
        }
        public WordForest.RaidAttackDataController get_Data()
        {
            return (WordForest.RaidAttackDataController)this.dataController;
        }
        public WordForest.RaidAttackServerController get_ServerAPI()
        {
            return (WordForest.RaidAttackServerController)this.serverController;
        }
        public WordForest.RaidAttackNotifyController get_NotifyAPI()
        {
            return (WordForest.RaidAttackNotifyController)this.notifyController;
        }
        public WordForest.UserForestProfile get_currentRaidOpponent()
        {
            return (WordForest.UserForestProfile)this.<currentRaidOpponent>k__BackingField;
        }
        private void set_currentRaidOpponent(WordForest.UserForestProfile value)
        {
            this.<currentRaidOpponent>k__BackingField = value;
        }
        public System.Collections.Generic.List<int> get_currentRaidPickerOptions()
        {
            return (System.Collections.Generic.List<System.Int32>)this.<currentRaidPickerOptions>k__BackingField;
        }
        private void set_currentRaidPickerOptions(System.Collections.Generic.List<int> value)
        {
            this.<currentRaidPickerOptions>k__BackingField = value;
        }
        public WordForest.UserForestProfile get_currentAttackOpponent()
        {
            return (WordForest.UserForestProfile)this.<currentAttackOpponent>k__BackingField;
        }
        private void set_currentAttackOpponent(WordForest.UserForestProfile value)
        {
            this.<currentAttackOpponent>k__BackingField = value;
        }
        private void OnServerResponded()
        {
            var val_4 = null;
            if(WordForest.RaidAttackServerController.IsInitialResponseSuccess != false)
            {
                    System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_2 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WordForest.RaidAttackManager::<OnServerResponded>b__33_1(System.Collections.Generic.Dictionary<string, object> resp));
                this.serverController.GetForestProfile(responseCallback:  null);
                return;
            }
            
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_3 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WordForest.RaidAttackManager::<OnServerResponded>b__33_0(System.Collections.Generic.Dictionary<string, object> resp));
            this.serverController.InitialRequest(responseCallback:  null);
        }
        public override void InitMonoSingleton()
        {
            this.dataController = this.gameObject.AddComponent<WordForest.RaidAttackDataController>();
            this.serverController = this.gameObject.AddComponent<WordForest.RaidAttackServerController>();
            this.notifyController = this.gameObject.AddComponent<WordForest.RaidAttackNotifyController>();
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnStarsChanged");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  3.ToString());
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnServerResponded");
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnStarsChanged");
        }
        private void OnApplicationPause(bool pause)
        {
            var val_3;
            if(pause == true)
            {
                    return;
            }
            
            val_3 = null;
            if(WordForest.RaidAttackServerController.IsInitialResponseSuccess == false)
            {
                    return;
            }
            
            this.serverController.GetForestProfile(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WordForest.RaidAttackManager::<OnApplicationPause>b__36_0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public void GrowTree(int treeId, int growthCost, System.Action<bool, System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            if(this.serverController != null)
            {
                    this.serverController.GrowTree(treeId:  treeId, growthCost:  growthCost, responseCallback:  responseCallback);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void SetShields(int amount)
        {
            System.Nullable<System.Int32> val_1 = new System.Nullable<System.Int32>(value:  amount);
            this.serverController.SetForestProfile(forestLevel:  new System.Nullable<System.Int32>() {HasValue = false}, map:  0, acorns:  new System.Nullable<System.Int32>() {HasValue = false}, shields:  new System.Nullable<System.Int32>() {HasValue = val_1.HasValue}, fbid:  0, responseCallback:  0);
        }
        public void GetEcon()
        {
            if(this.serverController != null)
            {
                    this.serverController.GetEcon();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void GetRaidOpponentPool()
        {
            .<>4__this = this;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.List<WordForest.UserForestProfile> val_3 = new System.Collections.Generic.List<WordForest.UserForestProfile>();
            .opponentList = val_3;
            val_3.Add(item:  WordForest.UserForestProfile.CreateDummyProfile(baseLevel:  UnityEngine.Random.Range(min:  val_2.currentForestID - 1, max:  val_2.currentForestID + 2), flexibleBaseLevel:  true, minTreesNormalized:  0f, maxTreesNormalized:  0.99f));
            this.dataController.CacheRaidOpponents(profiles:  (RaidAttackManager.<>c__DisplayClass40_0)[1152921518076119872].opponentList, isDummies:  true);
            this.serverController.GetRaidOpponentPool(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new RaidAttackManager.<>c__DisplayClass40_0(), method:  System.Void RaidAttackManager.<>c__DisplayClass40_0::<GetRaidOpponentPool>b__0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public bool CanAttack()
        {
            return (bool)(this.dataController.GetRandomAttackOpponent() != 0) ? 1 : 0;
        }
        public bool CanRaid()
        {
            return (bool)(this.dataController.GetRandomRaidOpponent() != 0) ? 1 : 0;
        }
        public WordForest.UserForestProfile GetRaidRandomOpponent()
        {
            WordForest.UserForestProfile val_1 = this.dataController.GetRandomRaidOpponent();
            this.<currentRaidOpponent>k__BackingField = val_1;
            return val_1;
        }
        public void InitializeFtuxRaid(System.Action onInitialized)
        {
            UnityEngine.Vector2Int val_1 = WordForest.WFOGameEconHelper.GetRaidEligibleAcornsMinMax(forestLevel:  3);
            System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
            val_3.Add(item:  0);
            val_3.Add(item:  0);
            int val_4 = val_1.m_X.y << 1;
            val_4 = val_4 >> 32;
            val_3.Add(item:  val_4 + (val_4 >> 63));
            val_3.Add(item:  0);
            this.<currentRaidPickerOptions>k__BackingField = val_3;
            if(onInitialized == null)
            {
                    return;
            }
            
            onInitialized.Invoke();
        }
        public void InitializeRaid(int opponentId, System.Action onInitialized)
        {
            .<>4__this = this;
            .onInitialized = onInitialized;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            this.<currentRaidPickerOptions>k__BackingField = WordForest.WFOGameEconHelper.GeneratePickerOptionsFromEligibleAcorns(eligibleAcorns:  WordForest.WFOGameEconHelper.GetRandomRaidEligibleAcorns(forestLevel:  val_2.currentForestID));
            this.serverController.InitializeRaid(opponentId:  opponentId, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new RaidAttackManager.<>c__DisplayClass45_0(), method:  System.Void RaidAttackManager.<>c__DisplayClass45_0::<InitializeRaid>b__0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public void ConcludeRaid(System.Collections.Generic.List<int> chosenRewardIndexes)
        {
            if((System.String.IsNullOrEmpty(value:  this.currentRaidId)) != false)
            {
                    return;
            }
            
            this.serverController.ConcludeRaid(raidId:  this.currentRaidId, chosenRewardIndexes:  chosenRewardIndexes, responseCallback:  0);
        }
        public void GetAttackOpponentPool()
        {
            .<>4__this = this;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.List<WordForest.UserForestProfile> val_3 = new System.Collections.Generic.List<WordForest.UserForestProfile>();
            .opponentList = val_3;
            val_3.Add(item:  WordForest.UserForestProfile.CreateDummyProfile(baseLevel:  UnityEngine.Random.Range(min:  val_2.currentForestID - 1, max:  val_2.currentForestID + 2), flexibleBaseLevel:  true, minTreesNormalized:  0.1f, maxTreesNormalized:  0.99f));
            this.dataController.CacheAttackOpponents(profiles:  (RaidAttackManager.<>c__DisplayClass47_0)[1152921518077118912].opponentList, isDummies:  true);
            this.serverController.GetAttackOpponentPool(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new RaidAttackManager.<>c__DisplayClass47_0(), method:  System.Void RaidAttackManager.<>c__DisplayClass47_0::<GetAttackOpponentPool>b__0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public WordForest.UserForestProfile GetAttackRandomOpponent()
        {
            WordForest.UserForestProfile val_1 = this.dataController.GetRandomAttackOpponent();
            this.<currentAttackOpponent>k__BackingField = val_1;
            return val_1;
        }
        public void GetRevengeOpponentPool(System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>> onRevengeListRetrieved)
        {
            .onRevengeListRetrieved = onRevengeListRetrieved;
            this.serverController.GetRevengeOpponentPool(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new RaidAttackManager.<>c__DisplayClass49_0(), method:  System.Void RaidAttackManager.<>c__DisplayClass49_0::<GetRevengeOpponentPool>b__0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public void GetFriendsOpponentPool(string[] friendFbidList, System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>> onListRetrieved)
        {
            .onListRetrieved = onListRetrieved;
            this.serverController.GetFriendsOpponentPool(fbidList:  friendFbidList, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new RaidAttackManager.<>c__DisplayClass50_0(), method:  System.Void RaidAttackManager.<>c__DisplayClass50_0::<GetFriendsOpponentPool>b__0(System.Collections.Generic.Dictionary<string, object> resp)));
        }
        public void ResolveAttack(int opponentId, int treeId, System.Nullable<bool> autoSuccess)
        {
            var val_3;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_5;
            val_3 = null;
            val_3 = null;
            val_5 = RaidAttackManager.<>c.<>9__51_0;
            if(val_5 == null)
            {
                    System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = null;
                val_5 = val_1;
                val_1 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  RaidAttackManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RaidAttackManager.<>c::<ResolveAttack>b__51_0(System.Collections.Generic.Dictionary<string, object> resp));
                RaidAttackManager.<>c.<>9__51_0 = val_5;
            }
            
            this.serverController.ResolveAttack(opponentId:  opponentId, treeId:  treeId, autoSuccess:  new System.Nullable<System.Boolean>() {HasValue = autoSuccess.HasValue & 65535}, responseCallback:  val_1);
        }
        public void FlushPlayerData()
        {
            this.Refresh(forced:  true);
        }
        private void OnAttackReceived()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  12)) == true)
            {
                    return;
            }
            
            this.isEligibleForRevengeFtux = true;
        }
        public void ShowConnectionRequired()
        {
            int val_8;
            var val_9;
            GameBehavior val_1 = App.getBehavior;
            bool[] val_5 = new bool[2];
            val_5[0] = true;
            string[] val_6 = new string[2];
            val_8 = val_6.Length;
            val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_8 = val_6.Length;
            val_6[1] = "NULL";
            val_9 = null;
            val_9 = null;
            val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public static void HandleDeeplinkShowNews()
        {
            var val_7;
            var val_8;
            bool val_9;
            if((MonoSingleton<WordForest.RaidAttackManager>.Instance) != 0)
            {
                    if((MonoSingleton<WGWindowManager>.Instance) != 0)
            {
                goto label_10;
            }
            
            }
            
            val_7 = 1152921504999550976;
            val_8 = null;
            val_8 = null;
            val_9 = 1;
            goto label_13;
            label_10:
            GameBehavior val_5 = App.getBehavior;
            val_7 = 1152921504999550976;
            val_8 = null;
            val_8 = null;
            val_9 = false;
            label_13:
            WordForest.RaidAttackManager.queueNewsPopup = val_9;
        }
        private void Refresh(bool forced = False)
        {
            WordForest.Map val_11;
            if(UnityEngine.Time.time <= this.nextRefresh)
            {
                    if(forced == false)
            {
                goto label_2;
            }
            
            }
            
            float val_2 = UnityEngine.Time.time;
            val_2 = val_2 + 30f;
            this.nextRefresh = val_2;
            System.Nullable<System.Int32> val_4 = new System.Nullable<System.Int32>(value:  val_3.currentForestID);
            val_11 = val_3.forestMapData;
            System.Nullable<System.Int32> val_6 = new System.Nullable<System.Int32>(value:  WordForest.WFOPlayer.Instance.acorns);
            System.Nullable<System.Int32> val_7 = new System.Nullable<System.Int32>(value:  val_3.shields);
            Player val_8 = App.Player;
            this.serverController.SetForestProfile(forestLevel:  new System.Nullable<System.Int32>() {HasValue = val_4.HasValue}, map:  val_11, acorns:  new System.Nullable<System.Int32>() {HasValue = val_6.HasValue}, shields:  new System.Nullable<System.Int32>() {HasValue = val_7.HasValue}, fbid:  val_8.properties.online_fb_id, responseCallback:  0);
            label_2:
            if(UnityEngine.Time.time <= this.nextRefreshEcon)
            {
                    return;
            }
            
            float val_10 = UnityEngine.Time.time;
            val_10 = val_10 + 600f;
            this.nextRefreshEcon = val_10;
            this.serverController.GetEcon();
        }
        private void OnStarsChanged()
        {
            this.Refresh(forced:  true);
        }
        public RaidAttackManager()
        {
        
        }
        private static RaidAttackManager()
        {
        
        }
        private void <OnServerResponded>b__33_0(System.Collections.Generic.Dictionary<string, object> resp)
        {
            this.GetRaidOpponentPool();
            this.GetAttackOpponentPool();
        }
        private void <OnServerResponded>b__33_1(System.Collections.Generic.Dictionary<string, object> resp)
        {
            this.GetRaidOpponentPool();
            this.GetAttackOpponentPool();
            this.Refresh(forced:  true);
        }
        private void <OnApplicationPause>b__36_0(System.Collections.Generic.Dictionary<string, object> resp)
        {
            this.GetRaidOpponentPool();
            this.GetAttackOpponentPool();
        }
    
    }

}
