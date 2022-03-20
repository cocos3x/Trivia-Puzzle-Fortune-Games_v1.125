using UnityEngine;
public class DeeplinkDelegate : MonoSingleton<DeeplinkDelegate>
{
    // Fields
    private DeeplinkComponent deeplinkComponent;
    private bool isAsyncing;
    private System.Action sceneLoadedCallBack;
    private bool isShowingAward;
    
    // Properties
    public DeeplinkComponent DeeplinkComponent { get; set; }
    
    // Methods
    public DeeplinkComponent get_DeeplinkComponent()
    {
        return (DeeplinkComponent)this.deeplinkComponent;
    }
    public void set_DeeplinkComponent(DeeplinkComponent value)
    {
        this.deeplinkComponent = value;
    }
    public override void InitMonoSingleton()
    {
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        this.gameObject.name = "DeeplinkDelegate";
        Player val_3 = App.Player;
        if(val_3.properties.ShouldShowGdprConsent() != false)
        {
                NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "GDPRConsented");
        }
        
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void DeeplinkDelegate::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void GDPRConsented()
    {
        this.QueryDeeplinkComponent();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if(this.sceneLoadedCallBack == null)
        {
                return;
        }
        
        this.sceneLoadedCallBack.Invoke();
        this.sceneLoadedCallBack = 0;
    }
    private void OnDestroy()
    {
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnDeeplinkNotification");
    }
    private void Start()
    {
        this.QueryDeeplinkComponent();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus != false)
        {
                return;
        }
        
        this.QueryDeeplinkComponent();
    }
    public void QueryDeeplinkComponent()
    {
        if(this.isAsyncing != false)
        {
                return;
        }
        
        this.isAsyncing = true;
        MonoSingletonSelfGenerating<AsyncExecution>.Instance.Async(callback:  new System.Action(object:  this, method:  System.Void DeeplinkDelegate::DoDeeplinkLogic()), when:  0.1f);
    }
    private void DoDeeplinkLogic()
    {
        var val_32;
        string val_33;
        string val_34;
        var val_35;
        var val_36;
        DeeplinkComponent val_37;
        string val_38;
        var val_39;
        System.Action val_41;
        var val_42;
        mem[1152921515625875632] = 0;
        if(this.deeplinkComponent.mustUpdate != false)
        {
                this.deeplinkComponent.mustUpdate = false;
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGUpdatePromptPopup>(showNext:  false).Setup(url:  DeeplinkDelegate.GetStoreURL(), mustUpdate:  true);
            return;
        }
        
        val_32 = "";
        if(this.deeplinkComponent.HasNotificationType != false)
        {
                val_33 = this.deeplinkComponent.helper.notificationType;
        }
        else
        {
                val_33 = "";
        }
        
        if(this.deeplinkComponent.helper.DequeueAction() == false)
        {
            goto label_13;
        }
        
        bool val_6 = this.deeplinkComponent.HasNotificationType;
        if(val_6 == false)
        {
            goto label_15;
        }
        
        val_34 = this.deeplinkComponent.helper.notificationType;
        val_35 = this;
        this.sceneLoadedCallBack = 0;
        goto label_18;
        label_13:
        MonoSingleton<Bootstrapper>.Instance.HandleNoDeeplinkMinigame();
        goto label_22;
        label_15:
        val_34 = "";
        val_35 = this;
        this.sceneLoadedCallBack = 0;
        label_18:
        val_6.TrackDeeplinkParsed();
        if(this.deeplinkComponent.helper.HasHelpshift != false)
        {
                MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.ShowSupport(prefillText:  "");
        }
        
        if(this.deeplinkComponent.helper.HasLobby != false)
        {
                GameBehavior val_11 = App.getBehavior;
        }
        
        if(this.deeplinkComponent.HasOpenUrl != false)
        {
                val_36 = "Open_URL";
            UnityEngine.Application.OpenURL(url:  this.deeplinkComponent.helper.<OpenUrl>k__BackingField);
            this.deeplinkComponent.helper.<OpenUrl>k__BackingField = 0;
        }
        
        if((this.deeplinkComponent.helper.<NoAds>k__BackingField) >= 1)
        {
                if((this.deeplinkComponent.helper.<NoAdsDuration>k__BackingField) >= 1)
        {
                AdsManager.AddNoAdsCooldown(seconds:  (double)this.deeplinkComponent.helper.<NoAdsDuration>k__BackingField);
        }
        else
        {
                App.Player.RemovedAds = true;
        }
        
        }
        
        if((this.deeplinkComponent.HasCurrentReward != false) && (this.isShowingAward != true))
        {
                val_36 = "Currency_Reward";
            UnityEngine.Coroutine val_16 = this.StartCoroutine(routine:  this.ShowAward());
        }
        
        val_37 = this.deeplinkComponent;
        var val_18 = (this.deeplinkComponent.HasDailyChallenge != true) ? "Daily_Challenge" : (val_36);
        if(this.deeplinkComponent.helper.hints != 1)
        {
                val_39 = null;
            val_38 = "Show_Hint";
            val_39 = null;
            val_41 = DeeplinkDelegate.<>c.<>9__13_0;
            if(val_41 == null)
        {
                System.Action val_19 = null;
            val_41 = val_19;
            val_19 = new System.Action(object:  DeeplinkDelegate.<>c.__il2cppRuntimeField_static_fields, method:  System.Void DeeplinkDelegate.<>c::<DoDeeplinkLogic>b__13_0());
            DeeplinkDelegate.<>c.<>9__13_0 = val_41;
        }
        
            mem[1152921515625875640] = val_41;
            val_37 = this.deeplinkComponent;
        }
        
        if(val_37.HasInviteCode != false)
        {
                val_38 = "Invite_Code";
            WGInviteManager.SafeSaveAndSend(installCodeParam:  this.deeplinkComponent.helper.<inviteCode>k__BackingField);
        }
        
        if(this.deeplinkComponent.HasChallengeFriendCode != false)
        {
                val_42 = 1152921504893161472;
            val_38 = "Friend_Challenge";
            val_35 = 1152921515625797136;
            if((MonoSingleton<ChallengeFriendController>.Instance) != 0)
        {
                MonoSingleton<ChallengeFriendController>.Instance.HandleLinkerAppDeeplink(linkerUrlDataSerialized:  this.deeplinkComponent.helper.<challengeFriendCode>k__BackingField);
        }
        
        }
        
        bool val_25 = this.deeplinkComponent.HasScene;
        if(val_25 != false)
        {
                val_38 = "Load_Scene";
            UnityEngine.Coroutine val_27 = this.StartCoroutine(routine:  val_25.DelayedShowScene());
        }
        else
        {
                if((this.deeplinkComponent.helper.<MiniGame>k__BackingField) >= 1)
        {
                val_38 = "Load_Minigame";
            MonoSingleton<Bootstrapper>.Instance.HandleDeeplinkIntoMinigame(minigame:  this.deeplinkComponent.helper.<MiniGame>k__BackingField);
        }
        else
        {
                MonoSingleton<Bootstrapper>.Instance.HandleNoDeeplinkMinigame();
        }
        
        }
        
        if(this.deeplinkComponent.helper.HasForestNews != false)
        {
                WordForest.RaidAttackManager.HandleDeeplinkShowNews();
        }
        
        if(this.deeplinkComponent.helper.HasPiggyBankRaid != false)
        {
                PiggyBankRaidEventHandler.HandleDeeplinkShowRaid();
        }
        
        this.deeplinkComponent.helper.Consumed = true;
        label_22:
        TrackingComponent.TrackSession(sessionEnded:  false, quitButton:  false);
        TrackingComponent.TrackLogin(fromDeeplink:  val_38, notificationType:  val_34);
    }
    private System.Collections.IEnumerator DelayedShowScene()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new DeeplinkDelegate.<DelayedShowScene>d__14();
    }
    private System.Collections.IEnumerator ShowAward()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DeeplinkDelegate.<ShowAward>d__16();
    }
    private static string GetStoreURL()
    {
        null = null;
        return getUpdatePromptConfiguration().getString(key:  "android_url", defaultValue:  "");
    }
    public DeeplinkDelegate()
    {
    
    }

}
