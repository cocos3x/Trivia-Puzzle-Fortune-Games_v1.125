using UnityEngine;
public class DeeplinkComponentHelper
{
    // Fields
    public const string WallpostNotificationType = "1001";
    public const int CurrentGiftVersion = 5;
    public const float DefaultPromoPrice = 1.99;
    private const int DefaultPromoDuration = 60;
    private const int DefaultPerk = -1;
    private const int DefaultPerkDuration = 60;
    private const string WallPostAction = "wallpost";
    private const string KGift = "v";
    private const string KOneTime = "onetimekey";
    private const string KExpires = "expires";
    private const string KReferal = "ref";
    private const string KPromo = "promo";
    private const string KPromoPrice = "promo_price";
    private const string KPromoDuration = "promo_duration";
    private const string KPerk = "perk";
    private const string KHint = "hint";
    private const string KDailyChallenge = "daily_challenge";
    private const string KPerkDuration = "perk_duration";
    private const string KRPN = "rpn";
    private const string KScene = "scene";
    private const string KNotificationType = "notification_type";
    private const string KCredits = "credits";
    private const string KTickets = "tickets";
    private const string KMonolith = "monolith";
    private const string KTEncoded = "encoded";
    private const string KTSource = "source";
    private const string KTDeeplinkData = "deeplink data";
    private const string KTCampaignType = "campaign_type";
    private const string KPromoCode = "promo_code";
    private const string KInviteCode = "a";
    private const string KMiniGame = "mini_game";
    private const string KUrl = "url";
    private const string KNoAds = "no_ads";
    private const string KNoAdsEnd = "no_ads_end";
    public const string KChallengeFriend = "challenge_friend";
    private System.Collections.Generic.Dictionary<string, DeeplinkAction> actionDictionary;
    private System.Collections.Generic.Dictionary<string, object> json;
    private string referal;
    private float promoPrice;
    private int promoDuration;
    private int perk;
    private int hints;
    private string dailyChallenge;
    private int perkDuration;
    private string notificationType;
    private string scene;
    private string profileAction;
    private System.Collections.Generic.List<ConsumableAmountPair> currentRewards;
    private string monolith;
    private string promoCode;
    private string currentDeeplinkAction;
    private string <OpenUrl>k__BackingField;
    private string <inviteCode>k__BackingField;
    private int <MiniGame>k__BackingField;
    private int <NoAds>k__BackingField;
    private int <NoAdsDuration>k__BackingField;
    private string <challengeFriendCode>k__BackingField;
    private static System.Collections.Generic.Dictionary<string, object> cachedTrackingData;
    private bool consumed;
    
    // Properties
    public bool HasReferal { get; }
    public string Referal { get; set; }
    public float PromoPrice { get; set; }
    public int PromoDuration { get; }
    public bool HasPerk { get; }
    public int Perk { get; set; }
    public bool HasHint { get; }
    public int Hint { get; set; }
    public bool HasDailyChallenge { get; }
    public string DailyChallenge { get; set; }
    public int PerkDuration { get; set; }
    public bool HasNotificationType { get; }
    public string NotificationType { get; set; }
    public bool HasScene { get; }
    public string Scene { get; set; }
    public bool HasHelpshift { get; }
    public bool HasLobby { get; }
    public bool HasProfileAction { get; }
    public string ProfileAction { get; set; }
    public bool HasCurrentRewards { get; }
    public System.Collections.Generic.List<ConsumableAmountPair> CurrentRewards { get; set; }
    public bool HasMonolith { get; }
    public string Monolith { get; set; }
    public bool HasForestNews { get; }
    public bool HasPiggyBankRaid { get; }
    public string PromoCode { get; set; }
    public string OpenUrl { get; set; }
    public string inviteCode { get; set; }
    public int MiniGame { get; set; }
    public int NoAds { get; set; }
    public int NoAdsDuration { get; set; }
    public string challengeFriendCode { get; set; }
    public bool Consumed { get; set; }
    public bool IsValidJSON { get; }
    public string GiftVersion { get; }
    public bool HasOneTimeKey { get; }
    public bool HasExpired { get; }
    
    // Methods
    public bool get_HasReferal()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.referal);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Referal()
    {
        return (string)this.referal;
    }
    public void set_Referal(string value)
    {
        this.referal = value;
    }
    public float get_PromoPrice()
    {
        return (float)this.promoPrice;
    }
    public void set_PromoPrice(float value)
    {
        this.promoPrice = value;
    }
    public int get_PromoDuration()
    {
        return (int)this.promoDuration;
    }
    public bool get_HasPerk()
    {
        return (bool)(this.perk != 1) ? 1 : 0;
    }
    public int get_Perk()
    {
        return (int)this.perk;
    }
    public void set_Perk(int value)
    {
        this.perk = value;
    }
    public bool get_HasHint()
    {
        return (bool)(this.hints != 1) ? 1 : 0;
    }
    public int get_Hint()
    {
        return (int)this.hints;
    }
    public void set_Hint(int value)
    {
        this.hints = value;
    }
    public bool get_HasDailyChallenge()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.dailyChallenge);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_DailyChallenge()
    {
        return (string)this.dailyChallenge;
    }
    public void set_DailyChallenge(string value)
    {
        this.dailyChallenge = value;
    }
    public int get_PerkDuration()
    {
        return (int)this.perkDuration;
    }
    public void set_PerkDuration(int value)
    {
        this.perkDuration = value;
    }
    public bool get_HasNotificationType()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.notificationType);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_NotificationType()
    {
        return (string)this.notificationType;
    }
    public void set_NotificationType(string value)
    {
        this.notificationType = value;
    }
    public bool get_HasScene()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.scene);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Scene()
    {
        return (string)this.scene;
    }
    public void set_Scene(string value)
    {
        this.scene = value;
    }
    public bool get_HasHelpshift()
    {
        if((System.String.IsNullOrEmpty(value:  this.notificationType)) == false)
        {
                return this.notificationType.Equals(value:  "helpshift");
        }
        
        return false;
    }
    public bool get_HasLobby()
    {
        if((System.String.IsNullOrEmpty(value:  this.notificationType)) == false)
        {
                return this.notificationType.Equals(value:  "lobby");
        }
        
        return false;
    }
    public bool get_HasProfileAction()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.profileAction);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_ProfileAction()
    {
        return (string)this.profileAction;
    }
    public void set_ProfileAction(string value)
    {
        this.profileAction = value;
    }
    public bool get_HasCurrentRewards()
    {
        var val_2;
        if(this.currentRewards != null)
        {
                var val_1 = (this.currentRewards > 0) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public System.Collections.Generic.List<ConsumableAmountPair> get_CurrentRewards()
    {
        return (System.Collections.Generic.List<ConsumableAmountPair>)this.currentRewards;
    }
    public void set_CurrentRewards(System.Collections.Generic.List<ConsumableAmountPair> value)
    {
        this.currentRewards = value;
    }
    public bool get_HasMonolith()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.monolith);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Monolith()
    {
        return (string)this.monolith;
    }
    public void set_Monolith(string value)
    {
        this.monolith = value;
    }
    public bool get_HasForestNews()
    {
        if((System.String.IsNullOrEmpty(value:  this.notificationType)) == false)
        {
                return this.notificationType.Equals(value:  "word_forests_news");
        }
        
        return false;
    }
    public bool get_HasPiggyBankRaid()
    {
        if((System.String.IsNullOrEmpty(value:  this.notificationType)) == false)
        {
                return this.notificationType.Equals(value:  "piggy_bank_raid_event");
        }
        
        return false;
    }
    public string get_PromoCode()
    {
        return (string)this.promoCode;
    }
    public void set_PromoCode(string value)
    {
        this.promoCode = value;
    }
    public string get_OpenUrl()
    {
        return (string)this.<OpenUrl>k__BackingField;
    }
    public void set_OpenUrl(string value)
    {
        this.<OpenUrl>k__BackingField = value;
    }
    public string get_inviteCode()
    {
        return (string)this.<inviteCode>k__BackingField;
    }
    public void set_inviteCode(string value)
    {
        this.<inviteCode>k__BackingField = value;
    }
    public int get_MiniGame()
    {
        return (int)this.<MiniGame>k__BackingField;
    }
    public void set_MiniGame(int value)
    {
        this.<MiniGame>k__BackingField = value;
    }
    public int get_NoAds()
    {
        return (int)this.<NoAds>k__BackingField;
    }
    public void set_NoAds(int value)
    {
        this.<NoAds>k__BackingField = value;
    }
    public int get_NoAdsDuration()
    {
        return (int)this.<NoAdsDuration>k__BackingField;
    }
    public void set_NoAdsDuration(int value)
    {
        this.<NoAdsDuration>k__BackingField = value;
    }
    public string get_challengeFriendCode()
    {
        return (string)this.<challengeFriendCode>k__BackingField;
    }
    public void set_challengeFriendCode(string value)
    {
        this.<challengeFriendCode>k__BackingField = value;
    }
    public DeeplinkComponentHelper()
    {
        this.promoPrice = 1.99f;
        this.hints = 0;
        this.promoDuration = 60;
        this.perk = -1;
        this.perkDuration = 60;
        this.actionDictionary = new System.Collections.Generic.Dictionary<System.String, DeeplinkAction>();
    }
    public bool get_Consumed()
    {
        return (bool)this.consumed;
    }
    public void set_Consumed(bool value)
    {
        var val_1 = (this.consumed == false) ? 1 : 0;
        val_1 = val_1 ^ value;
        if(val_1 == true)
        {
                return;
        }
        
        this.consumed = value;
        if(value == false)
        {
                return;
        }
        
        if(this.currentDeeplinkAction == null)
        {
                return;
        }
        
        DeeplinkAction val_3 = this.actionDictionary.Item[this.currentDeeplinkAction];
        DeeplinkPlugin.NotifyActionConsumed(identifier:  val_3.identifier);
        bool val_4 = this.actionDictionary.Remove(key:  this.currentDeeplinkAction);
        this.currentDeeplinkAction = 0;
    }
    public void Cleanup()
    {
        if(this.consumed == false)
        {
                return;
        }
        
        this.promoPrice = 1.99f;
        this.hints = 0;
        this.json = 0;
        this.referal = 0;
        this.dailyChallenge = 0;
        this.<MiniGame>k__BackingField = 0;
        this.<NoAds>k__BackingField = 0;
        this.<NoAdsDuration>k__BackingField = 0;
        this.notificationType = 0;
        this.scene = 0;
        this.perkDuration = 60;
        this.promoDuration = 60;
        this.perk = -1;
        this.monolith = 0;
        this.promoCode = 0;
    }
    public bool get_IsValidJSON()
    {
        return (bool)(this.json != 0) ? 1 : 0;
    }
    public void EnqueueAction(DeeplinkAction action, DeeplinkSource source)
    {
        var val_3;
        if((this.actionDictionary.ContainsKey(key:  action.identifier)) == true)
        {
                return;
        }
        
        val_3 = source;
        action.source = source.ToString();
        this.actionDictionary.Add(key:  action.identifier, value:  action);
    }
    public bool DequeueAction()
    {
        var val_3;
        var val_4;
        System.Collections.Generic.Dictionary<System.String, DeeplinkAction> val_5;
        var val_6;
        val_3 = this;
        if(this.currentDeeplinkAction != null)
        {
                val_4 = 0;
            return (bool)val_4;
        }
        
        val_5 = this.actionDictionary;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_1 = val_5.GetEnumerator();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(11993091 != 1)
        {
            goto label_6;
        }
        
        val_6 = 0;
        val_3 = 1;
        goto label_8;
        label_4:
        val_3 = 0;
        val_6 = 0;
        goto label_8;
        label_6:
        if(this.consumed != false)
        {
                this.consumed = false;
        }
        
        mem[16] = 1;
        this.currentDeeplinkAction = 0;
        this.DeserializeJson(serializedJson:  41868256, source:  4194311, encodedJson:  64);
        val_3 = 1;
        val_6 = 1;
        label_8:
        0.Dispose();
        val_4 = val_6 & val_3;
        return (bool)val_4;
    }
    public void DeserializeJson(string serializedJson, string source, string encodedJson)
    {
        object val_60;
        string val_61 = source;
        if(this.consumed != false)
        {
                this.promoPrice = 1.99f;
            this.hints = 0;
            this.json = 0;
            this.referal = 0;
            this.dailyChallenge = 0;
            this.<MiniGame>k__BackingField = 0;
            this.<NoAds>k__BackingField = 0;
            this.<NoAdsDuration>k__BackingField = 0;
            this.notificationType = 0;
            this.scene = 0;
            this.perkDuration = 60;
            this.promoDuration = 60;
            this.perk = -1;
            this.monolith = 0;
            this.promoCode = 0;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_60 = "DeeplinkComponentHelper::DeserializeJson data: "("DeeplinkComponentHelper::DeserializeJson data: ") + serializedJson;
            UnityEngine.Debug.Log(message:  val_60);
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  serializedJson);
        this.json = 0;
        this.Consumed = true;
    }
    public string get_GiftVersion()
    {
        if(this.json == null)
        {
                return (string)System.String.alignConst;
        }
        
        if((this.HasKey(key:  "v", dict:  this.json)) == false)
        {
                return (string)System.String.alignConst;
        }
        
        object val_2 = this.json.Item["v"];
        this = ???;
        goto typeof(System.Object).__il2cppRuntimeField_160;
    }
    public bool get_HasOneTimeKey()
    {
        string val_6;
        var val_7;
        val_6 = this;
        if((this.json != null) && ((this.HasKey(key:  "onetimekey", dict:  this.json)) != false))
        {
                val_6 = this.json.Item["onetimekey"];
            string val_3 = UnityEngine.PlayerPrefs.GetString(key:  "onetimekeys", defaultValue:  "");
            if((val_3.Contains(value:  val_6)) != false)
        {
                val_7 = 1;
            return (bool)val_7;
        }
        
            UnityEngine.PlayerPrefs.SetString(key:  "onetimekeys", value:  System.String.Format(format:  "{0},{1}", arg0:  val_3, arg1:  val_6));
        }
        
        val_7 = 0;
        return (bool)val_7;
    }
    public bool get_HasExpired()
    {
        var val_8;
        ulong val_9;
        val_8 = this;
        if((this.json != null) && ((this.HasKey(key:  "expires", dict:  this.json)) != false))
        {
                val_8 = System.Int32.Parse(s:  this.json.Item["expires"]);
            System.DateTime val_4 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            System.DateTime val_5 = System.DateTime.UtcNow;
            System.DateTime val_6 = val_4.dateData.AddSeconds(value:  (double)val_8);
            val_9 = val_5.dateData;
            bool val_7 = System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_9}, t2:  new System.DateTime() {dateData = val_6.dateData});
        }
        else
        {
                val_9 = 0;
        }
        
        val_9 = val_9 & 1;
        return (bool)val_9;
    }
    private void CacheTrackingData(string dataJson, string source, string base64EncodedJson)
    {
        var val_6;
        var val_7;
        var val_8;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "encoded", value:  base64EncodedJson);
        val_1.Add(key:  "source", value:  source);
        val_1.Add(key:  "deeplink data", value:  dataJson);
        val_6 = null;
        val_6 = null;
        DeeplinkComponentHelper.cachedTrackingData = val_1;
        if(this.json == null)
        {
                return;
        }
        
        if((HasKey(key:  "source", dict:  this.json)) != false)
        {
                val_7 = null;
            val_7 = null;
            val_6 = DeeplinkComponentHelper.cachedTrackingData;
            val_1.set_Item(key:  "source", value:  this.json.Item["source"]);
        }
        
        if(this.json == null)
        {
                return;
        }
        
        if((val_1.HasKey(key:  "campaign_type", dict:  this.json)) == false)
        {
                return;
        }
        
        val_8 = null;
        val_8 = null;
        val_1.set_Item(key:  "campaign_type", value:  this.json.Item["campaign_type"]);
    }
    public void TrackDeeplinkParsed()
    {
        TrackerManager val_1;
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(DeeplinkComponentHelper.cachedTrackingData == null)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        val_1 = App.trackerManager;
        val_1.track(eventName:  "Deeplink Parsed", data:  DeeplinkComponentHelper.cachedTrackingData);
        DeeplinkComponentHelper.cachedTrackingData = 0;
    }
    private bool HasKey(string key)
    {
        if(this.json == null)
        {
                return false;
        }
        
        return this.HasKey(key:  key, dict:  this.json);
    }
    private bool HasKey(string key, System.Collections.Generic.Dictionary<string, object> dict)
    {
        var val_4;
        if((dict.ContainsKey(key:  key)) != false)
        {
                val_4 = (~(System.String.IsNullOrEmpty(value:  dict.Item[key]))) & 1;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    private int ParseInt(string sInt)
    {
        return System.Int32.Parse(s:  sInt, style:  511);
    }
    private static DeeplinkComponentHelper()
    {
    
    }

}
