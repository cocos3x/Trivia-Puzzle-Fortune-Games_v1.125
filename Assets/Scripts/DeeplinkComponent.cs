using UnityEngine;
public class DeeplinkComponent : AppComponent
{
    // Fields
    protected DeeplinkComponentHelper helper;
    private static DeeplinkComponent instance;
    public static string HACK_actionString;
    protected DeeplinkDelegate listener;
    public const string OnDeeplinkNotification = "OnDeeplinkNotification";
    public const string OnDeeplinkShowScene = "OnDeepLinkShowScene";
    private bool mustUpdate;
    
    // Properties
    public static DeeplinkComponent Instance { get; }
    public override bool RunInMainThread { get; }
    public bool MustUpdate { get; set; }
    public bool HasCurrentReward { get; }
    public System.Collections.Generic.List<ConsumableAmountPair> CurrentReward { get; set; }
    public bool HasScene { get; }
    public string Scene { get; set; }
    public bool HasHelpshift { get; }
    public bool HasLobby { get; }
    public bool HasReferal { get; }
    public string Referal { get; set; }
    public bool HasMonolith { get; }
    public string Monolith { get; set; }
    public bool HasForestNews { get; }
    public bool HasPiggyBankRaid { get; }
    public bool HasNotificationType { get; }
    public string NotificationType { get; set; }
    public bool HasProfileAction { get; }
    public string ProfileAction { get; set; }
    public bool HasPromoCode { get; }
    public string PromoCode { get; set; }
    public bool HasOpenUrl { get; }
    public string OpenUrl { get; set; }
    public bool Consumed { get; set; }
    public bool HasHint { get; }
    public int Hint { get; set; }
    public bool HasDailyChallenge { get; }
    public string DailyChallenge { get; set; }
    public bool HasInviteCode { get; }
    public string InviteCode { get; set; }
    public bool HasMiniGame { get; }
    public int MiniGame { get; set; }
    public bool HasNoAds { get; }
    public int NoAdsDuration { get; set; }
    public float PromoPrice { get; set; }
    public bool HasPerk { get; }
    public int Perk { get; set; }
    public int PerkDuration { get; set; }
    public bool HasChallengeFriendCode { get; }
    public string ChallengeFriendCode { get; set; }
    
    // Methods
    public static DeeplinkComponent get_Instance()
    {
        null = null;
        return (DeeplinkComponent)DeeplinkComponent.OnDeeplinkShowScene;
    }
    public DeeplinkComponent(string gameName, string gameObjectName)
    {
        var val_4;
        mem[1152921515570368464] = "DeeplinkComponent";
        val_4 = null;
        val_4 = null;
        DeeplinkComponent.OnDeeplinkShowScene = this;
        this.helper = new DeeplinkComponentHelper();
        this.listener = new UnityEngine.GameObject().AddComponent<DeeplinkDelegate>();
        val_3.deeplinkComponent = this;
    }
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public override void initializeOnMainThread()
    {
        goto typeof(DeeplinkComponent).__il2cppRuntimeField_1E0;
    }
    public override void onApplicationPause(bool pauseStatus)
    {
        if(pauseStatus == false)
        {
            goto typeof(DeeplinkComponent).__il2cppRuntimeField_1E0;
        }
    
    }
    protected virtual void PerformAction()
    {
        this.CheckForNormalDeeplink();
    }
    public void CheckForDeeplinkUrl(string url, DeeplinkSource source)
    {
        var val_39;
        var val_40;
        var val_41;
        string val_42;
        System.Char[] val_43;
        DeeplinkAction val_44;
        if((System.String.IsNullOrEmpty(value:  url)) == true)
        {
                return;
        }
        
        DeeplinkUri val_2 = null;
        val_39 = val_2;
        val_2 = new DeeplinkUri(uri:  url, useParser:  false);
        if((System.String.IsNullOrEmpty(value:  val_2.Scheme)) == true)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  val_2.Host)) == true)
        {
                return;
        }
        
        if((val_2.Scheme.Contains(value:  "http")) == false)
        {
            goto label_6;
        }
        
        if((System.String.IsNullOrEmpty(value:  val_2.Query)) == true)
        {
            goto label_15;
        }
        
        char[] val_12 = new char[1];
        val_12[0] = 63;
        char[] val_14 = new char[1];
        val_14[0] = '&';
        val_40 = val_2.Query.TrimStart(trimChars:  val_12).Split(separator:  val_14);
        if(val_15.Length < 1)
        {
            goto label_15;
        }
        
        val_41 = 0;
        label_24:
        char[] val_16 = new char[1];
        val_16[0] = '=';
        System.String[] val_17 = val_40[val_41].Split(separator:  val_16);
        if(val_17.Length < 2)
        {
            goto label_21;
        }
        
        val_42 = val_17[0];
        if((val_42.Equals(value:  "g")) == true)
        {
            goto label_23;
        }
        
        label_21:
        val_41 = val_41 + 1;
        if(val_41 < val_15.Length)
        {
            goto label_24;
        }
        
        label_15:
        if((System.String.IsNullOrEmpty(value:  val_2.AbsolutePath)) == false)
        {
            goto label_25;
        }
        
        label_6:
        val_43 = val_2.Scheme;
        AppConfigs val_22 = App.Configuration;
        if((val_43.Contains(value:  val_22.appConfig.deeplinkScheme)) != false)
        {
                DeeplinkUri val_24 = null;
            val_39 = val_24;
            val_24 = new DeeplinkUri(uri:  url, useParser:  true);
            if((System.String.IsNullOrEmpty(value:  val_24.Scheme)) == true)
        {
                return;
        }
        
            if((System.String.IsNullOrEmpty(value:  val_24.Host)) == true)
        {
                return;
        }
        
        }
        
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        DeeplinkAction val_30 = null;
        val_44 = val_30;
        val_30 = new DeeplinkAction(maybeJson:  val_24.Host);
        this.ParseDeeplink(action:  val_30, source:  source);
        return;
        label_25:
        char[] val_31 = new char[1];
        val_43 = val_31;
        val_43[0] = '/';
        if(val_35.Length == 0)
        {
                return;
        }
        
        if(val_35.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_44 = val_2.AbsolutePath.TrimStart(trimChars:  val_31).TrimEnd(trimChars:  val_31).Split(separator:  val_31)[0];
        this.ParseDeeplink(action:  new DeeplinkAction(maybeJson:  val_44), source:  source);
        return;
        label_23:
        if(val_17.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_44 = val_17[1];
        this.ParseDeeplink(action:  new DeeplinkAction(maybeJson:  val_44), source:  source);
    }
    private void CheckForNormalDeeplink()
    {
        DeeplinkAction val_7;
        var val_8;
        var val_9;
        DeeplinkSource val_10;
        val_7 = DeeplinkPlugin.GetAction();
        val_8 = null;
        val_8 = null;
        if((System.String.IsNullOrEmpty(value:  DeeplinkComponent.HACK_actionString)) != true)
        {
                val_9 = null;
            val_9 = null;
            DeeplinkAction val_3 = null;
            val_7 = val_3;
            val_3 = new DeeplinkAction(maybeJson:  DeeplinkComponent.HACK_actionString);
        }
        
        string val_4 = DeeplinkPlugin.GetAndroidNotificationData();
        if((System.String.IsNullOrEmpty(value:  (DeeplinkAction)[1152921515571605376].decodedAction)) != false)
        {
                if((System.String.IsNullOrEmpty(value:  val_4)) == false)
        {
            goto label_8;
        }
        
        }
        
        val_10 = 3;
        goto label_9;
        label_8:
        val_3.ForceJson(forcedJson:  val_4);
        val_10 = 1;
        label_9:
        this.ParseDeeplink(action:  val_3, source:  val_10);
    }
    protected void ParseDeeplink(DeeplinkAction action, DeeplinkSource source)
    {
        if(action == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.IsNullOrEmpty(value:  action.decodedAction)) != false)
        {
                DeeplinkPlugin.NotifyActionConsumed(identifier:  action.identifier);
            return;
        }
        
        this.helper.EnqueueAction(action:  action, source:  source);
        this.Notify();
    }
    public void Flush()
    {
        if(this.helper != null)
        {
                if(this.helper.consumed == false)
        {
                return;
        }
        
            this.helper.promoPrice = 1.99f;
            this.helper.hints = 0;
            this.helper.json = 0;
            this.helper.referal = 0;
            this.helper.dailyChallenge = 0;
            this.helper.<MiniGame>k__BackingField = 0;
            this.helper.<NoAds>k__BackingField = 0;
            this.helper.<NoAdsDuration>k__BackingField = 0;
            this.helper.notificationType = 0;
            this.helper.scene = 0;
            this.helper.perkDuration = 60;
            this.helper.promoDuration = 60;
            this.helper.perk = -1;
            this.helper.monolith = 0;
            this.helper.promoCode = 0;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool DequeueDeeplinkAction()
    {
        if(this.helper != null)
        {
                return this.helper.DequeueAction();
        }
        
        throw new NullReferenceException();
    }
    public void TrackDeeplinkParsed()
    {
        if(this.helper != null)
        {
                this.helper.TrackDeeplinkParsed();
            return;
        }
        
        throw new NullReferenceException();
    }
    protected void Notify()
    {
        if(this.listener == 0)
        {
                return;
        }
        
        this.listener.QueryDeeplinkComponent();
    }
    public bool get_MustUpdate()
    {
        return (bool)this.mustUpdate;
    }
    public void set_MustUpdate(bool value)
    {
        this.mustUpdate = value;
    }
    public bool get_HasCurrentReward()
    {
        var val_2;
        if(this.helper.currentRewards != null)
        {
                var val_1 = (this.helper.currentRewards > 0) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public System.Collections.Generic.List<ConsumableAmountPair> get_CurrentReward()
    {
        if(this.helper != null)
        {
                return (System.Collections.Generic.List<ConsumableAmountPair>)this.helper.currentRewards;
        }
        
        throw new NullReferenceException();
    }
    public void set_CurrentReward(System.Collections.Generic.List<ConsumableAmountPair> value)
    {
        if(this.helper != null)
        {
                this.helper.currentRewards = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasScene()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.scene);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Scene()
    {
        if(this.helper != null)
        {
                return (string)this.helper.scene;
        }
        
        throw new NullReferenceException();
    }
    public void set_Scene(string value)
    {
        if(this.helper != null)
        {
                this.helper.scene = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasHelpshift()
    {
        if(this.helper != null)
        {
                return this.helper.HasHelpshift;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasLobby()
    {
        if(this.helper != null)
        {
                return this.helper.HasLobby;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasReferal()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.referal);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Referal()
    {
        if(this.helper != null)
        {
                return (string)this.helper.referal;
        }
        
        throw new NullReferenceException();
    }
    public void set_Referal(string value)
    {
        if(this.helper != null)
        {
                this.helper.referal = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasMonolith()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.monolith);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_Monolith()
    {
        if(this.helper != null)
        {
                return (string)this.helper.monolith;
        }
        
        throw new NullReferenceException();
    }
    public void set_Monolith(string value)
    {
        if(this.helper != null)
        {
                this.helper.monolith = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasForestNews()
    {
        if(this.helper != null)
        {
                return this.helper.HasForestNews;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasPiggyBankRaid()
    {
        if(this.helper != null)
        {
                return this.helper.HasPiggyBankRaid;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasNotificationType()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.notificationType);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_NotificationType()
    {
        if(this.helper != null)
        {
                return (string)this.helper.notificationType;
        }
        
        throw new NullReferenceException();
    }
    public void set_NotificationType(string value)
    {
        if(this.helper != null)
        {
                this.helper.notificationType = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasProfileAction()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.profileAction);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_ProfileAction()
    {
        if(this.helper != null)
        {
                return (string)this.helper.profileAction;
        }
        
        throw new NullReferenceException();
    }
    public void set_ProfileAction(string value)
    {
        if(this.helper != null)
        {
                this.helper.profileAction = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasPromoCode()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.promoCode);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_PromoCode()
    {
        if(this.helper != null)
        {
                return (string)this.helper.promoCode;
        }
        
        throw new NullReferenceException();
    }
    public void set_PromoCode(string value)
    {
        if(this.helper != null)
        {
                this.helper.promoCode = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasOpenUrl()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.<OpenUrl>k__BackingField);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_OpenUrl()
    {
        if(this.helper != null)
        {
                return (string)this.helper.<OpenUrl>k__BackingField;
        }
        
        throw new NullReferenceException();
    }
    public void set_OpenUrl(string value)
    {
        if(this.helper != null)
        {
                this.helper.<OpenUrl>k__BackingField = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_Consumed()
    {
        if(this.helper != null)
        {
                return (bool)this.helper.consumed;
        }
        
        throw new NullReferenceException();
    }
    public void set_Consumed(bool value)
    {
        if(this.helper != null)
        {
                this.helper.Consumed = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasHint()
    {
        if(this.helper != null)
        {
                return (bool)(this.helper.hints != 1) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public int get_Hint()
    {
        if(this.helper != null)
        {
                return (int)this.helper.hints;
        }
        
        throw new NullReferenceException();
    }
    public void set_Hint(int value)
    {
        if(this.helper != null)
        {
                this.helper.hints = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasDailyChallenge()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.dailyChallenge);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_DailyChallenge()
    {
        if(this.helper != null)
        {
                return (string)this.helper.dailyChallenge;
        }
        
        throw new NullReferenceException();
    }
    public void set_DailyChallenge(string value)
    {
        if(this.helper != null)
        {
                this.helper.dailyChallenge = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasInviteCode()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.<inviteCode>k__BackingField);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_InviteCode()
    {
        if(this.helper != null)
        {
                return (string)this.helper.<inviteCode>k__BackingField;
        }
        
        throw new NullReferenceException();
    }
    public void set_InviteCode(string value)
    {
        if(this.helper != null)
        {
                this.helper.<inviteCode>k__BackingField = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasMiniGame()
    {
        if(this.helper != null)
        {
                return (bool)((this.helper.<MiniGame>k__BackingField) > 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public int get_MiniGame()
    {
        if(this.helper != null)
        {
                return (int)this.helper.<MiniGame>k__BackingField;
        }
        
        throw new NullReferenceException();
    }
    public void set_MiniGame(int value)
    {
        if(this.helper != null)
        {
                this.helper.<MiniGame>k__BackingField = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasNoAds()
    {
        if(this.helper != null)
        {
                return (bool)((this.helper.<NoAds>k__BackingField) > 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public int get_NoAdsDuration()
    {
        if(this.helper != null)
        {
                return (int)this.helper.<NoAdsDuration>k__BackingField;
        }
        
        throw new NullReferenceException();
    }
    public void set_NoAdsDuration(int value)
    {
        if(this.helper != null)
        {
                this.helper.<NoAdsDuration>k__BackingField = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public float get_PromoPrice()
    {
        if(this.helper != null)
        {
                return (float)this.helper.promoPrice;
        }
        
        throw new NullReferenceException();
    }
    public void set_PromoPrice(float value)
    {
        if(this.helper != null)
        {
                this.helper.promoPrice = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasPerk()
    {
        if(this.helper != null)
        {
                return (bool)(this.helper.perk != 1) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public int get_Perk()
    {
        if(this.helper != null)
        {
                return (int)this.helper.perk;
        }
        
        throw new NullReferenceException();
    }
    public void set_Perk(int value)
    {
        if(this.helper != null)
        {
                this.helper.perk = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public int get_PerkDuration()
    {
        if(this.helper != null)
        {
                return (int)this.helper.perkDuration;
        }
        
        throw new NullReferenceException();
    }
    public void set_PerkDuration(int value)
    {
        if(this.helper != null)
        {
                this.helper.perkDuration = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasChallengeFriendCode()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.helper.<challengeFriendCode>k__BackingField);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public string get_ChallengeFriendCode()
    {
        if(this.helper != null)
        {
                return (string)this.helper.<challengeFriendCode>k__BackingField;
        }
        
        throw new NullReferenceException();
    }
    public void set_ChallengeFriendCode(string value)
    {
        if(this.helper != null)
        {
                this.helper.<challengeFriendCode>k__BackingField = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    private static DeeplinkComponent()
    {
        DeeplinkComponent.OnDeeplinkShowScene = 0;
        DeeplinkComponent.HACK_actionString = "";
    }

}
