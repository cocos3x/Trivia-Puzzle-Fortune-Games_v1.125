using UnityEngine;
public class WGOnTheTrailPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform tooltip;
    private UnityEngine.UI.Text tooltipText;
    private UnityEngine.UI.Slider progressSlider;
    private UnityEngine.Sprite checkMark;
    private UnityEngine.Sprite crossMark;
    private UnityEngine.UI.Image completionStatusImg;
    private UnityEngine.Transform wagonTransform;
    private UnityEngine.UI.Text dayTimeInfo;
    private WGOnTheTrailDayTracking days3Tracking;
    private WGOnTheTrailDayTracking days4Tracking;
    private WGOnTheTrailDayTracking days5Tracking;
    private UnityEngine.UI.Text description;
    private UnityEngine.GameObject rewardGroup;
    private UnityEngine.UI.Text rewardAmount;
    private UGUINetworkedButton greenButton;
    private UnityEngine.UI.Text greenButtonText;
    private UnityEngine.UI.Button blueButton;
    private UnityEngine.UI.Text blueButtonText;
    private UnityEngine.GameObject fixWagonCostGroup;
    private UnityEngine.UI.Text fixWagonCostText;
    private UnityEngine.UI.Button closeButton;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private UnityEngine.GameObject coinCurrencyStatView;
    private FrameSkipper frameSkipper;
    private System.DateTime endTime;
    private string dayTimePrefix;
    private bool isShowingDayCompleted;
    private int wagonFixPrice;
    private int completionReward;
    private bool isFinalDay;
    private const float WAGON_FAR_LEFT_POS_X = -347.5;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGOnTheTrailPopup::Close()));
    }
    public void Setup(OnTheTrailEvent.PopupUIParameters_Basic param)
    {
        System.Type val_1 = param.GetType();
        this.UpdateWagonProgressUI(today:  param.Day, completedLevels:  param.CompletedLevels, goal:  param.Goal, timeLeft:  new System.TimeSpan() {_ticks = param.TimeLeft}, paramType:  val_1);
        this.UpdateDayTrackingUI(today:  param.Day, daysRewarded:  param.DaysRewarded, rewards:  param.Rewards);
        this.UpdateRewardUI(param:  param, paramType:  val_1);
    }
    private void UpdateWagonProgressUI(int today, int completedLevels, int goal, System.TimeSpan timeLeft, System.Type paramType)
    {
        string val_37;
        UnityEngine.Sprite val_38;
        string val_39;
        string val_40;
        float val_1 = (float)completedLevels / (float)goal;
        UnityEngine.Rect val_3 = this.wagonTransform.GetComponent<UnityEngine.RectTransform>().rect;
        float val_4 = val_3.m_XMin.width;
        float val_37 = val_4;
        val_4 = val_37 * (-0.5f);
        val_37 = val_4 + 20f;
        UnityEngine.Rect val_6 = this.progressSlider.GetComponent<UnityEngine.RectTransform>().rect;
        float val_7 = val_6.m_XMin.width;
        val_7 = val_7 * (-0.5f);
        val_7 = (val_1 * val_7) + val_7;
        val_1 = val_37 + val_7;
        UnityEngine.Vector3 val_10 = this.wagonTransform.localPosition;
        UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Max(a:  val_1, b:  -347.5f), y:  val_10.y, z:  0f);
        this.wagonTransform.localPosition = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
        System.Type val_12 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        val_37 = paramType;
        System.Type val_13 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        System.Type val_14 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (val_37 != 1) ? -10f : 0f);
        this.wagonTransform.localEulerAngles = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
        UnityEngine.Vector3 val_17 = this.wagonTransform.localPosition;
        UnityEngine.Vector3 val_18 = this.tooltip.localPosition;
        UnityEngine.Vector3 val_19 = this.tooltip.localPosition;
        UnityEngine.Vector3 val_20 = new UnityEngine.Vector3(x:  val_17.x, y:  val_18.y, z:  val_19.z);
        this.tooltip.localPosition = new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z};
        if((val_37 & 1) == 0)
        {
            goto label_18;
        }
        
        string val_21 = Localization.Localize(key:  "broken_wagon_tooltip_upper", defaultValue:  "WAGON BROKE!", useSingularKey:  false);
        val_38 = this.crossMark;
        goto label_20;
        label_18:
        if((paramType & 1) == 0)
        {
            goto label_21;
        }
        
        val_39 = "complete_wagon_tooltip_upper";
        val_40 = "CONTINUE TOMORROW!";
        goto label_22;
        label_21:
        if((paramType & 1) == 0)
        {
            goto label_23;
        }
        
        val_39 = "reward_wagon_tooltip_upper";
        val_40 = "COLLECT REWARD";
        label_22:
        string val_22 = Localization.Localize(key:  val_39, defaultValue:  val_40, useSingularKey:  false);
        if(this.tooltipText != null)
        {
            goto label_24;
        }
        
        label_23:
        val_37 = Localization.Localize(key:  "trail_wagon_tooltip_upper", defaultValue:  "COMPLETE {0} LEVELS", useSingularKey:  false);
        string val_24 = System.String.Format(format:  val_37, arg0:  goal);
        label_24:
        val_38 = this.checkMark;
        label_20:
        this.completionStatusImg.sprite = mem[this.checkMark];
        if((paramType & 1) != 0)
        {
                string val_27 = System.String.Format(format:  Localization.Localize(key:  "day_x_begin_upper", defaultValue:  "DAY {0} BEGIN", useSingularKey:  false), arg0:  today + 1);
        }
        
        this.dayTimePrefix = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "day_upper", defaultValue:  "DAY", useSingularKey:  false), arg1:  today);
        this.isShowingDayCompleted = paramType & 1;
        System.DateTime val_31 = DateTimeCheat.UtcNow;
        System.DateTime val_32 = val_31.dateData.Add(value:  new System.TimeSpan() {_ticks = timeLeft._ticks});
        this.endTime = val_32;
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_36 = System.Delegate.Combine(a:  val_34.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGOnTheTrailPopup::UpdateTimer()));
        if(val_36 != null)
        {
                if(null != null)
        {
            goto label_34;
        }
        
        }
        
        val_34.updateLogic = val_36;
        return;
        label_34:
    }
    private void UpdateDayTrackingUI(int today, System.Collections.Generic.List<bool> daysRewarded, System.Collections.Generic.List<int> rewards)
    {
        WGOnTheTrailDayTracking val_3;
        if(true == 5)
        {
            goto label_2;
        }
        
        if(true == 4)
        {
            goto label_3;
        }
        
        if(true != 3)
        {
            goto label_4;
        }
        
        val_3 = this.days3Tracking;
        goto label_7;
        label_3:
        val_3 = this.days4Tracking;
        goto label_7;
        label_2:
        val_3 = this.days5Tracking;
        goto label_7;
        label_4:
        val_3 = 0;
        label_7:
        if(val_3 == 0)
        {
                return;
        }
        
        val_3.Setup(today:  today, daysRewarded:  daysRewarded, rewards:  rewards);
        val_3.gameObject.SetActive(value:  true);
    }
    private void UpdateRewardUI(OnTheTrailEvent.PopupUIParameters_Basic param, System.Type paramType)
    {
        UnityEngine.Events.UnityAction val_32;
        UnityEngine.UI.Text val_33;
        var val_34;
        val_32 = paramType;
        val_33 = param;
        this.PrepareRewardUI();
        System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if((val_32 & 1) == 0)
        {
            goto label_4;
        }
        
        string val_2 = Localization.Localize(key:  "day_in_progress_popup", defaultValue:  "Complete levels to move the Wagon! Reach the destination to earn a reward and unlock the event for another day.\nMiss the destination and the wagon breaks!", useSingularKey:  false);
        this.description.gameObject.SetActive(value:  true);
        if(SceneDictator.IsInGameScene() != false)
        {
                if(CategoryPacksManager.IsPlaying != true)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_17;
        }
        
        }
        
        }
        
        string val_10 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "LEVEL", useSingularKey:  false), arg1:  App.Player);
        this.SetupButtonColor(color:  1);
        this.RemoveAllListeners();
        label_88:
        this.greenButtonText.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGOnTheTrailPopup::OnClick_Level()));
        this.coinCurrencyStatView.SetActive(value:  false);
        this.fixWagonCostGroup.SetActive(value:  false);
        return;
        label_4:
        System.Type val_12 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if((val_32 & 1) == 0)
        {
            goto label_30;
        }
        
        this.rewardGroup.SetActive(value:  false);
        this.closeButton.gameObject.SetActive(value:  true);
        string val_14 = Localization.Localize(key:  "day_complete_popup", defaultValue:  "You completed the trail for today! Come back tomorrow to continue.\nMiss a day and your wagon might break!", useSingularKey:  false);
        this.description.gameObject.SetActive(value:  true);
        this.blueButtonText.resizeTextMaxSize = 60;
        this.SetupButtonColor(color:  0);
        this.blueButton.interactable = false;
        UnityEngine.GameObject val_16 = this.blueButton.gameObject;
        val_34 = 0;
        goto label_42;
        label_30:
        System.Type val_17 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if((val_32 & 1) == 0)
        {
            goto label_45;
        }
        
        this.closeButton.gameObject.SetActive(value:  false);
        bool val_19 = (param.Day == param.DaysRewarded) ? 1 : 0;
        this.isFinalDay = val_19;
        this.description.gameObject.SetActive(value:  false);
        this.completionReward = val_19;
        string val_21 = param + 56.ToString();
        this.rewardGroup.SetActive(value:  true);
        string val_22 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        this.SetupButtonColor(color:  1);
        this.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_23 = null;
        val_32 = val_23;
        val_23 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGOnTheTrailPopup::OnClick_Collect());
        this.greenButtonText.AddListener(call:  val_23);
        val_34 = 1;
        label_42:
        this.greenButtonText.gameObject.SetActive(value:  true);
        return;
        label_45:
        System.Type val_25 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if((val_32 & 1) == 0)
        {
                return;
        }
        
        string val_26 = Localization.Localize(key:  "broken_wagon_popup", defaultValue:  "Oh no! Your wagon broke. Fix your wagon to keep moving on the trail today", useSingularKey:  false);
        this.description.gameObject.SetActive(value:  true);
        this.greenButtonText.gameObject.SetActive(value:  false);
        this.wagonFixPrice = null;
        string val_29 = param + 56.ToString();
        this.fixWagonCostGroup.SetActive(value:  true);
        this.SetupButtonColor(color:  1);
        this.coinCurrencyStatView.SetActive(value:  true);
        this.coinCurrencyStatView.RemoveAllListeners();
        this.greenButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGOnTheTrailPopup::OnClick_FixWagon(bool connected));
        return;
        label_17:
        val_33 = this.blueButtonText;
        string val_31 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        this.SetupButtonColor(color:  0);
        this.RemoveAllListeners();
        this.blueButton.m_OnClick.RemoveAllListeners();
        if(this.blueButton != null)
        {
            goto label_88;
        }
        
        throw new NullReferenceException();
    }
    private void PrepareRewardUI()
    {
        this.goldenCurrencyAnimControl.Create();
        this.greenButton.gameObject.SetActive(value:  false);
        this.greenButtonText.gameObject.SetActive(value:  true);
        this.blueButton.gameObject.SetActive(value:  false);
    }
    private void SetupButtonColor(WGOnTheTrailPopup.ButtonColor color)
    {
        this.greenButton.gameObject.SetActive(value:  (color == 1) ? 1 : 0);
        this.blueButton.gameObject.SetActive(value:  (color == 0) ? 1 : 0);
    }
    private void OnClick_Level()
    {
        this.Close();
        if(SceneDictator.GetActiveSceneType() == 2)
        {
                if(CategoryPacksManager.IsPlaying != true)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return;
        }
        
        }
        
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        GameBehavior val_8 = App.getBehavior;
        this = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_410;
    }
    private void OnClick_Collect()
    {
        this.greenButton.interactable = false;
        RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGOnTheTrailPopup::OnClick_Collect()));
        OnTheTrailEventHandler.<Instance>k__BackingField.CollectReward(rewardAmount:  this.completionReward);
        mem2[0] = new System.Action(object:  this, method:  System.Void WGOnTheTrailPopup::OnGoldenCurrencyAnimFinished());
        Player val_3 = App.Player;
        Player val_4 = App.Player;
        decimal val_5 = System.Decimal.op_Implicit(value:  val_4._stars);
        this.goldenCurrencyAnimControl.Play(fromValue:  val_3._stars - this.completionReward, toValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void OnClick_FixWagon(bool connected)
    {
        System.Action val_7;
        var val_8;
        if(connected == false)
        {
            goto label_1;
        }
        
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  this.wagonFixPrice);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = connected, mid = connected}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid})) == false)
        {
            goto label_7;
        }
        
        val_8 = null;
        val_8 = null;
        PurchaseProxy.currentPurchasePoint = 78;
        GameBehavior val_4 = App.getBehavior;
        System.Action val_6 = null;
        val_7 = val_6;
        val_6 = new System.Action(object:  this, method:  System.Void WGOnTheTrailPopup::<OnClick_FixWagon>b__41_0());
        val_4.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_6);
        goto label_18;
        label_1:
        this.ShowConnectionRequired();
        label_18:
        this.Close();
        return;
        label_7:
        OnTheTrailEventHandler.<Instance>k__BackingField.FixWagon();
        OnTheTrailEventHandler.<Instance>k__BackingField.ReinitializePopup();
    }
    private void OnGoldenCurrencyAnimFinished()
    {
        if(this.isFinalDay != false)
        {
                this.Close();
            return;
        }
        
        this.ReinitializePopup();
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[1];
        val_8[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGOnTheTrailPopup::<ShowConnectionRequired>b__43_0());
        val_11 = null;
        val_11 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ReinitializePopup()
    {
        OnTheTrailEventHandler.<Instance>k__BackingField.OnEventButtonPressed();
    }
    private void UpdateTimer()
    {
        object val_25;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.endTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        val_25 = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0).ToString(format:  "00");
        string val_13 = System.String.Format(format:  "{0} - {1}", arg0:  this.dayTimePrefix, arg1:  System.String.Format(format:  "{0}h {1}m {2}s", arg0:  UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0).ToString(format:  "00"), arg1:  val_25, arg2:  UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0).ToString(format:  "00")));
        if(this.isShowingDayCompleted == false)
        {
                return;
        }
        
        val_25 = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0).ToString(format:  "00");
        string val_24 = System.String.Format(format:  "{0} {1}", arg0:  this.dayTimePrefix, arg1:  System.String.Format(format:  "{0}:{1}:{2}", arg0:  UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0).ToString(format:  "00"), arg1:  val_25, arg2:  UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0).ToString(format:  "00")));
    }
    private void Close()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  this.frameSkipper.updateLogic, value:  new System.Action(object:  this, method:  System.Void WGOnTheTrailPopup::UpdateTimer()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_2;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_3:
    }
    public WGOnTheTrailPopup()
    {
    
    }
    private void <OnClick_FixWagon>b__41_0()
    {
        this.ReinitializePopup();
    }
    private bool <ShowConnectionRequired>b__43_0()
    {
        this.ReinitializePopup();
        return true;
    }

}
