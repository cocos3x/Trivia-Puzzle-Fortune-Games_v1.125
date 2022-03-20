using UnityEngine;
public class PvPCrownClashPopup : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.UI.Text primaryWindowText;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Text secondaryButtonText;
    private UnityEngine.UI.Text rewardHeaderText;
    private UnityEngine.UI.Text coinRewardText;
    private UnityEngine.UI.Text appleRewardText;
    private UnityEngine.UI.Text playerNameText;
    private UnityEngine.UI.Text opposingNameText;
    private UnityEngine.UI.Text playerPointsText;
    private UnityEngine.UI.Text opposingPointsText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.GameObject rewardBox;
    private UnityEngine.GameObject timerParent;
    private UnityEngine.GameObject infoPopup;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button primaryButton;
    private UnityEngine.UI.Button secondaryButton;
    private UnityEngine.UI.Image playerBarImage;
    private UnityEngine.UI.Image playerClubImage;
    private UnityEngine.UI.Image opposingClubImage;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoReqText;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoRewardText;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoAppleRewardText;
    public SLC.Social.AvatarConfig playerAvatarHandler;
    public System.Action onStartAction;
    public GameEventV2 myEvent;
    private FrameSkipper mySkipper;
    private GridCoinCollectAnimationInstantiator coinCollector;
    private GoldenCurrencyCollectAnimationInstantiator appleCollector;
    private UnityEngine.UI.RawImage facebookImage;
    private UnityEngine.ParticleSystem victorySystem;
    
    // Methods
    private void Start()
    {
        this.mySkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2._framesToSkip = 10;
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        if(PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY != null)
        {
                PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.SetWindowSeen();
        }
        
        PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.UpdateFeaturePoint();
        if(this.coinCollector == 0)
        {
                return;
        }
        
        if(this.coinCollector == 0)
        {
                return;
        }
        
        mem2[0] = 0;
    }
    public void SetUpWindow(bool fromGameButton = False)
    {
        System.Action val_5;
        var val_6;
        IntPtr val_8;
        PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.CheckCalculateReward();
        if(this.myEvent != null)
        {
            
        }
        else
        {
                this.myEvent = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.m_stringLength;
        }
        
        if((PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.canCollectReward() != false) && (PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.rewardData != null))
        {
                val_5 = this.onStartAction;
            val_6 = 1152921504614301696;
            val_8 = 1152921516175348048;
        }
        else
        {
                val_5 = this.onStartAction;
            val_6 = 1152921504614301696;
            System.Action val_3 = null;
            val_8 = 1152921516175357264;
        }
        
        val_3 = new System.Action(object:  this, method:  val_8);
        System.Delegate val_4 = System.Delegate.Combine(a:  val_5, b:  val_3);
        if(val_4 != null)
        {
                if(null != val_6)
        {
            goto label_15;
        }
        
        }
        
        this.onStartAction = val_4;
        return;
        label_15:
    }
    public void DisplayEvent()
    {
        var val_19;
        string val_20;
        string val_21;
        UnityEngine.Events.UnityAction val_22;
        this.CleanUI();
        this.timerParent.SetActive(value:  true);
        this.mySkipper.updateLogic = new System.Action(object:  this, method:  System.Void PvPCrownClashPopup::UpdateTimerText());
        this.DisplayPlayerValues();
        System.Delegate val_3 = System.Delegate.Combine(a:  this.mySkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void PvPCrownClashPopup::DisplayPlayerValues()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.mySkipper.updateLogic = val_3;
        string val_4 = Localization.Localize(key:  "prize_pool_upper", defaultValue:  "PRIZE POOL", useSingularKey:  false);
        System.Delegate val_6 = System.Delegate.Combine(a:  this.mySkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void PvPCrownClashPopup::DisplayCurrentPrize()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.mySkipper.updateLogic = val_6;
        val_19 = null;
        val_19 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                val_20 = "apple_picking_popup_info";
            val_21 = "The player that earns the most Golden Apples wins!";
        }
        else
        {
                val_20 = "internet_required_updates";
            val_21 = "Internet required for updates!";
        }
        
        string val_7 = Localization.Localize(key:  val_20, defaultValue:  val_21, useSingularKey:  false);
        this.rewardBox.SetActive(value:  true);
        this.infoButton.gameObject.SetActive(value:  true);
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void PvPCrownClashPopup::ToggleInfo()));
        GameBehavior val_10 = App.getBehavior;
        if((val_10.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_27;
        }
        
        string val_13 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        UnityEngine.Events.UnityAction val_14 = null;
        val_22 = val_14;
        val_14 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PvPCrownClashPopup::LoadGameplayScene());
        this.primaryButton.m_OnClick.AddListener(call:  val_14);
        if(this.primaryButton != null)
        {
            goto label_34;
        }
        
        label_27:
        string val_15 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        UnityEngine.Events.UnityAction val_16 = null;
        val_22 = val_16;
        val_16 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PvPCrownClashPopup::LoadGameplayScene());
        this.secondaryButton.m_OnClick.AddListener(call:  val_16);
        label_34:
        this.secondaryButton.gameObject.SetActive(value:  true);
        this.closeButton.gameObject.SetActive(value:  true);
        return;
        label_9:
    }
    public void DisplayCrownClashResult()
    {
        object val_1 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.rewardData;
        UnityEngine.Debug.LogError(message:  "trying to open crown clash pvp reward window without any valid reward available. How did we get this far?");
        this.CloseWindow();
    }
    private void DisplayPlayerValues()
    {
        object val_19;
        var val_21;
        string val_1 = 22259.playerName;
        this.playerPointsText.gameObject.SetActive(value:  true);
        if((PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) <= 999)
        {
            goto label_8;
        }
        
        float val_19 = 1000f;
        val_19 = ((float)PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) / val_19;
        val_19 = val_19.ToString(format:  "######.##");
        if((System.String.Format(format:  "{0}K", arg0:  val_19)) != null)
        {
            goto label_9;
        }
        
        label_8:
        val_19 = 0;
        string val_5 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44.ToString();
        label_9:
        val_21 = this.playerPointsText;
        this.playerClubImage.sprite = this.playerAvatarHandler.GetAvatarSpriteByID(id:  22259.playerSprite, portraitID:  0);
        this.OnMyProfileUpdate();
        int val_8 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.getOpponentCrowns();
        if(val_8 > 999)
        {
                float val_20 = 1000f;
            val_20 = (float)val_8 / val_20;
            string val_10 = System.String.Format(format:  "{0}K", arg0:  val_20.ToString(format:  "######.##"));
        }
        else
        {
                string val_11 = val_8.ToString();
        }
        
        this.opposingPointsText.gameObject.SetActive(value:  true);
        string val_13 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.opponentName;
        this.opposingClubImage.sprite = this.playerAvatarHandler.GetAvatarSpriteByID(id:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.opponentPlayerSprite, portraitID:  0);
        if((val_8 | (PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44)) == 0)
        {
            goto label_31;
        }
        
        float val_17 = ((float)PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) + (float)val_8;
        val_17 = ((float)PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) / val_17;
        float val_18 = UnityEngine.Mathf.Clamp(value:  val_17, min:  0.1f, max:  0.9f);
        if(this.playerBarImage != null)
        {
            goto label_34;
        }
        
        label_31:
        label_34:
        this.playerBarImage.fillAmount = 0.5f;
    }
    private void OnMyProfileUpdate()
    {
        this.facebookImage.gameObject.SetActive(value:  false);
        SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.IsNullOrEmpty(value:  val_3.FacebookId)) == true)
        {
                return;
        }
        
        if(val_3.UseFacebook == false)
        {
                return;
        }
        
        FacebookAvatarHelper.RequestProfilePic(fbid:  val_3.FacebookId, successCallback:  new System.Action<System.String, UnityEngine.Texture2D>(object:  this, method:  public System.Void PvPCrownClashPopup::OnResponseSuccess(string fileName, UnityEngine.Texture2D texture)), failureCallback:  new System.Action(object:  this, method:  public System.Void PvPCrownClashPopup::OnResponseFail()));
    }
    public void OnResponseSuccess(string fileName, UnityEngine.Texture2D texture)
    {
        if(texture != 0)
        {
                if(texture.width > 255)
        {
            goto label_5;
        }
        
        }
        
        label_13:
        this.OnResponseFail();
        return;
        label_5:
        if(this.gameObject == 0)
        {
                return;
        }
        
        if(this.facebookImage == 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  fileName.Replace(oldValue:  "fbavatar_", newValue:  ""))) == true)
        {
            goto label_13;
        }
        
        this.facebookImage.texture = texture;
        this.facebookImage.gameObject.SetActive(value:  true);
    }
    public void OnResponseFail()
    {
        if(this.gameObject == 0)
        {
                return;
        }
        
        if(this.facebookImage == 0)
        {
                return;
        }
        
        this.facebookImage.gameObject.SetActive(value:  false);
    }
    private void CollectReward()
    {
        this.primaryButton.interactable = false;
        object val_1 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.rewardData;
        UnityEngine.Debug.LogError(message:  "trying to reward crown clash pvp reward window without any valid reward available. How did we get this far?");
        this.CloseWindow();
    }
    private void LoadGameplayScene()
    {
        this.UpdateFeaturePoint();
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void UpdateFeaturePoint()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 41;
        }
        else
        {
                GameBehavior val_2 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
            val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 42;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 42;
    }
    private void UpdateTimerText()
    {
        object val_22;
        string val_23;
        System.Delegate val_24;
        int val_27;
        val_22 = this;
        if(this.myEvent == null)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.myEvent.timeEnd}, d2:  new System.DateTime() {dateData = val_1.dateData});
        if(val_2._ticks.TotalSeconds < 0)
        {
                this.closeButton.interactable = false;
            this.primaryButton.interactable = false;
        }
        
        if(val_2._ticks.TotalSeconds < 0)
        {
                this.CleanUI();
            val_23 = 1152921504614301696;
            System.Action val_5 = null;
            val_24 = val_5;
            val_5 = new System.Action(object:  this, method:  System.Void PvPCrownClashPopup::UpdateTimerText());
            System.Delegate val_6 = System.Delegate.Remove(source:  this.mySkipper.updateLogic, value:  val_5);
            if(val_6 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
            this.mySkipper.updateLogic = val_6;
            PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.CheckCalculateReward();
            return;
        }
        
        int val_8 = val_2._ticks.Seconds;
        if(val_2._ticks.Seconds > 9)
        {
                string val_9 = val_8.ToString();
        }
        else
        {
                string val_10 = "0" + val_8;
        }
        
        int val_12 = val_2._ticks.Minutes;
        if(val_2._ticks.Minutes > 9)
        {
                string val_13 = val_12.ToString();
        }
        else
        {
            
        }
        
        val_24 = "0" + val_12;
        val_23 = val_2._ticks.Hours.ToString();
        if(val_2._ticks.Hours <= 9)
        {
                val_23 = "0" + val_23;
        }
        
        val_22 = this.timerText;
        object[] val_19 = new object[4];
        val_27 = val_19.Length;
        val_19[0] = val_2._ticks.Days;
        if(val_23 != null)
        {
                val_27 = val_19.Length;
        }
        
        val_19[1] = val_23;
        if(val_24 != null)
        {
                val_27 = val_19.Length;
        }
        
        val_19[2] = val_24;
        if(val_10 != null)
        {
                val_27 = val_19.Length;
        }
        
        val_19[3] = val_10;
        string val_21 = System.String.Format(format:  "{0}:{1}:{2}:{3}", args:  val_19);
        return;
        label_12:
    }
    private void DisplayCurrentPrize()
    {
        string val_12;
        int val_12 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.getOpponentCrowns();
        System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<System.String>(source:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 64.Keys);
        val_12 = "0";
        if(1152921510375394352 >= 1)
        {
                var val_13 = 0;
            val_12 = (PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) + val_12;
            do
        {
            if(1152921510375394352 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_12 >= (System.Int32.Parse(s:  ToString())))
        {
                if(null <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_12 = mem[.SyncRoot + 32];
        }
        
            val_13 = val_13 + 1;
        }
        while(val_13 < null);
        
        }
        
        System.Text.StringBuilder val_6 = new System.Text.StringBuilder();
        if(null == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        object val_8 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 64.Item[val_12];
        object val_9 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 72.Item[val_12];
        if((System.String.op_Equality(a:  val_12, b:  mem[398631840])) != false)
        {
                return;
        }
        
        string val_10 = this.coinRewardText + "+"("+");
        string val_11 = this.appleRewardText + "+"("+");
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void ToggleInfo()
    {
        var val_13;
        this.infoPopup.SetActive(value:  (~this.infoPopup.activeSelf) & 1);
        if(this.infoPopup.activeSelf == false)
        {
                return;
        }
        
        System.Collections.Generic.List<TSource> val_5 = System.Linq.Enumerable.ToList<System.String>(source:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 64.Keys);
        val_13 = "0";
        if((val_5.Contains(item:  "0")) != false)
        {
                bool val_7 = val_5.Remove(item:  "0");
        }
        
        int val_8 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.getOpponentCrowns();
        var val_15 = 4;
        val_13 = "not enough ui elements for the crown clash rewards";
        var val_9 = val_15 - 4;
        if((val_9 >= this.infoReqText) || (val_9 >= this.infoRewardText))
        {
            goto label_15;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((System.Int32.TryParse(s:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.__il2cppRuntimeField_20, result: out  0)) == false)
        {
            goto label_41;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if(val_9 >= this.infoRewardText)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        object val_12 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 64.Item[PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 32];
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        object val_13 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 72.Item[PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 32];
        goto label_41;
        label_15:
        UnityEngine.Debug.LogError(message:  "not enough ui elements for the crown clash rewards");
        label_41:
        var val_14 = val_15 - 3;
        val_15 = val_15 + 1;
    }
    private void CleanUI()
    {
        this.rewardBox.gameObject.SetActive(value:  false);
        this.infoButton.gameObject.SetActive(value:  false);
        this.infoPopup.SetActive(value:  false);
        this.playerPointsText.gameObject.SetActive(value:  false);
        this.opposingPointsText.gameObject.SetActive(value:  false);
        this.closeButton.gameObject.SetActive(value:  false);
        this.timerParent.SetActive(value:  false);
        this.primaryButton.m_OnClick.RemoveAllListeners();
        this.primaryButton.gameObject.SetActive(value:  false);
        this.secondaryButton.gameObject.SetActive(value:  false);
        this.mySkipper.updateLogic = 0;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PvPCrownClashPopup::CloseWindow()));
        this.victorySystem.gameObject.SetActive(value:  false);
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if((PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY & 1) == 0)
        {
            goto typeof(System.String).__il2cppRuntimeField_540;
        }
    
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        UnityEngine.Object val_8;
        if(this.infoPopup.activeSelf == false)
        {
                return;
        }
        
        val_8 = eventData.selectedObject;
        if(val_8 == this.infoButton.gameObject)
        {
                return;
        }
        
        val_8 = this.infoPopup.gameObject;
        if(eventData.selectedObject == val_8)
        {
                return;
        }
        
        this.infoPopup.SetActive(value:  false);
    }
    public PvPCrownClashPopup()
    {
        this.infoReqText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.infoRewardText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.infoAppleRewardText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
    }

}
