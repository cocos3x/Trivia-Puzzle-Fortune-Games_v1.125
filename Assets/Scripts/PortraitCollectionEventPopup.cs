using UnityEngine;
public class PortraitCollectionEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text timerText;
    private PortraitCollectionPortraitItem portraitPrefab;
    private UnityEngine.Transform portraitParent;
    private FPHPlayButton playButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button avatarButton;
    private UnityEngine.UI.Image currentAvatar;
    private UnityEngine.UI.Image avatarBackground;
    private System.Collections.Generic.Dictionary<string, PortraitCollectionPortraitItem> myPortraits;
    private string displayingCollection;
    
    // Properties
    public FPHPlayButton getPlayButton { get; }
    
    // Methods
    public FPHPlayButton get_getPlayButton()
    {
        return (FPHPlayButton)this.playButton;
    }
    public void Start()
    {
        object val_19;
        var val_20;
        System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem> val_39;
        UnityEngine.Transform val_40;
        System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem> val_41;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAvatarChanged");
        val_39 = 1152921516615594896;
        FPHPortraitCollectionController val_2 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_2.progress == null)
        {
            goto label_7;
        }
        
        this.displayingCollection = val_2.progress.chosenCollection;
        this.playButton.onPlayResult = new System.Action<System.Boolean>(object:  this, method:  System.Void PortraitCollectionEventPopup::OnPressPlayResult(bool result));
        string val_4 = val_2.progress.chosenCollection.ToUpper();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionEventPopup::OnClose()));
        System.Collections.Generic.List<System.String> val_9 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  val_2.progress.chosenCollection);
        SLC.Social.Profile val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        FPHPortraitCollectionController val_16 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        int val_38 = val_16.progress.starsCollected;
        System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem> val_17 = null;
        val_39 = val_17;
        val_17 = new System.Collections.Generic.Dictionary<System.String, PortraitCollectionPortraitItem>();
        this.myPortraits = val_39;
        val_38 = (float)val_38 / ((float)MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionNextUnlockCost(collection:  val_2.progress.chosenCollection));
        List.Enumerator<T> val_18 = MonoSingleton<WGPortraitDataController>.Instance.GetPortraitNamesByCollection(collection:  val_2.progress.chosenCollection).GetEnumerator();
        label_36:
        if(val_20.MoveNext() == false)
        {
            goto label_29;
        }
        
        val_40 = this.portraitParent;
        PortraitCollectionPortraitItem val_22 = UnityEngine.Object.Instantiate<PortraitCollectionPortraitItem>(original:  this.portraitPrefab, parent:  val_40);
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_23 = val_22.transform;
        val_40 = System.String.Format(format:  "{0}_display", arg0:  val_19);
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_23;
        val_41.name = val_40;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40 = val_19;
        val_22.Init(portraitName:  val_40, unlocked:  val_9.Contains(item:  val_19), inUse:  System.String.op_Equality(a:  val_11.Portrait_ID, b:  val_19), progress:  ((System.String.op_Equality(a:  val_19, b:  MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait())) != true) ? (val_38) : 0f);
        val_41 = this.myPortraits;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.Add(key:  val_19, value:  val_22);
        goto label_36;
        label_29:
        val_20.Dispose();
        if(val_31.progress.showUnlockedPortrait != false)
        {
                UnityEngine.Coroutine val_33 = this.StartCoroutine(routine:  MonoSingleton<FPHPortraitCollectionController>.Instance.PlayPortraitEarnedAnimation());
        }
        
        this.OnAvatarChanged();
        FrameSkipper val_34 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this);
        val_34.updateLogic = new System.Action(object:  this, method:  System.Void PortraitCollectionEventPopup::UpdateTimerText());
        this.avatarButton.m_OnClick.RemoveAllListeners();
        this.avatarButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionEventPopup::OnAvatarPressed()));
        return;
        label_7:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnAvatarChanged()
    {
        string val_24;
        var val_25;
        string val_39;
        string val_40;
        int val_41;
        val_39 = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler;
        SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        if(val_2.MyProfile == null)
        {
                throw new NullReferenceException();
        }
        
        SLC.Social.Leagues.LeaguesDataController val_4 = SLC.Social.Leagues.LeaguesManager.DAO;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        if(val_4.MyProfile == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_3.AvatarId;
        if(this.currentAvatar == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_39.GetAvatarSpriteByID(id:  val_41, portraitID:  val_5.Portrait_ID);
        this.currentAvatar.sprite = val_41;
        SLC.Social.Leagues.LeaguesDataController val_7 = SLC.Social.Leagues.LeaguesManager.DAO;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        if(val_7.MyProfile == null)
        {
                throw new NullReferenceException();
        }
        
        val_40 = val_8.Portrait_ID;
        val_41 = 0;
        if(this.avatarBackground == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = System.String.IsNullOrEmpty(value:  val_40);
        this.avatarBackground.enabled = val_41;
        if(this.myPortraits == null)
        {
                return;
        }
        
        if((MonoSingleton<FPHPortraitCollectionController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        WGPortraitDataController val_11 = MonoSingleton<WGPortraitDataController>.Instance;
        if(val_10.progress == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_10.progress.chosenCollection;
        System.Collections.Generic.List<System.String> val_12 = val_11.GetPortraitNamesByCollection(collection:  val_41);
        WGPortraitDataController val_13 = MonoSingleton<WGPortraitDataController>.Instance;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_10.progress.chosenCollection;
        SLC.Social.Leagues.LeaguesDataController val_15 = SLC.Social.Leagues.LeaguesManager.DAO;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        if(val_15.MyProfile == null)
        {
                throw new NullReferenceException();
        }
        
        val_39 = val_16.Portrait_ID;
        FPHPortraitCollectionController val_17 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        FPHPortraitCollectionController val_19 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_10.progress.chosenCollection;
        if((MonoSingleton<FPHPortraitCollectionController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_21.progress == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_23 = val_12.GetEnumerator();
        label_39:
        val_41 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_25.MoveNext() == false)
        {
            goto label_32;
        }
        
        val_40 = this.myPortraits;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_24;
        if((val_40.ContainsKey(key:  val_41)) == false)
        {
            goto label_39;
        }
        
        val_40 = this.myPortraits;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_24;
        PortraitCollectionPortraitItem val_28 = val_40.Item[val_41];
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_29 = val_28.transform;
        val_41 = System.String.Format(format:  "{0}_display", arg0:  val_24);
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.name = val_41;
        val_28.Init(portraitName:  val_24, unlocked:  val_13.GetUnlockedPortraitsByCollection(collection:  val_41).Contains(item:  val_24), inUse:  System.String.op_Equality(a:  val_39, b:  val_24), progress:  ((System.String.op_Equality(a:  val_24, b:  val_17.GetNextUnlockedPortrait())) != true) ? ((float)val_21.progress.starsCollected / ((float)val_19.GetCollectionNextUnlockCost(collection:  val_41))) : 0f);
        goto label_39;
        label_32:
        val_25.Dispose();
    }
    private System.Collections.IEnumerator PlayPortraitEarnedAnimation()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new PortraitCollectionEventPopup.<PlayPortraitEarnedAnimation>d__16();
    }
    private void OnAvatarPressed()
    {
        bool val_4 = UnityEngine.Object.op_Inequality(x:  this.gameObject.GetComponent<WGFlyoutWindow>(), y:  0);
        .inFlyoutMode = val_4;
        if(val_4 == false)
        {
            goto label_5;
        }
        
        GameBehavior val_6 = App.getBehavior;
        if((val_6.<metaGameBehavior>k__BackingField) != null)
        {
            goto label_10;
        }
        
        label_5:
        GameBehavior val_8 = App.getBehavior;
        label_10:
        SLCWindow val_10 = val_8.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_10.Action_OnClose = new System.Action(object:  new PortraitCollectionEventPopup.<>c__DisplayClass17_0(), method:  System.Void PortraitCollectionEventPopup.<>c__DisplayClass17_0::<OnAvatarPressed>b__0());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPressPlayResult(bool result)
    {
        System.Action val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) == 1) && (result != true))
        {
                WGStoreProxy val_2 = UnityEngine.Object.FindObjectOfType<WGStoreProxy>();
            if(val_2 != 0)
        {
                val_7 = null;
            val_7 = null;
            val_6 = PortraitCollectionEventPopup.<>c.<>9__18_0;
            if(val_6 == null)
        {
                System.Action val_4 = null;
            val_6 = val_4;
            val_4 = new System.Action(object:  PortraitCollectionEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void PortraitCollectionEventPopup.<>c::<OnPressPlayResult>b__18_0());
            PortraitCollectionEventPopup.<>c.<>9__18_0 = val_6;
        }
        
            val_2.Init(outOfCredits:  true, onCloseAction:  val_4);
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void UpdateTimerText()
    {
        System.TimeSpan val_2 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetTimeRemaining();
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days.ToString(format:  "0");
        val_3[1] = val_2._ticks.Hours.ToString(format:  "0");
        val_3[2] = val_2._ticks.Minutes.ToString(format:  "0");
        val_3[3] = val_2._ticks.Seconds.ToString(format:  "0");
        string val_12 = System.String.Format(format:  "{0}d {1}h {2}m {3}s", args:  val_3);
        if(val_2._ticks.TotalSeconds > 1)
        {
                FPHPortraitCollectionController val_14 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            if(val_14.progress == null)
        {
                return;
        }
        
            FPHPortraitCollectionController val_15 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            if((System.String.op_Inequality(a:  val_15.progress.chosenCollection, b:  this.displayingCollection)) == false)
        {
                return;
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClose()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnAvatarChanged");
    }
    public PortraitCollectionEventPopup()
    {
    
    }

}
