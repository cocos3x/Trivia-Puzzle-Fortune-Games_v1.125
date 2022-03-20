using UnityEngine;
public class WGSnakesAndLaddersBoardPopup : MonoBehaviour
{
    // Fields
    private WGSnakesAndLaddersBoardPopupHeader header;
    private UnityEngine.GameObject boardWindow;
    private UnityEngine.GameObject videoFeedbackWindow;
    private SnakesAndLaddersEvent.WGSnakesAndLaddersBoardUI boardUI;
    private SnakesAndLaddersSpaceRewardUI rewardGroup;
    private UnityEngine.UI.Text rewardAmount;
    private UnityEngine.UI.Image rewardIcon;
    private UnityEngine.Sprite coinSp;
    private UnityEngine.Sprite diceSp;
    private UnityEngine.Sprite goldenCurrencySp;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button starterPackButton;
    private UGUINetworkedButton videoButton;
    private UnityEngine.UI.Button rollButton;
    private UnityEngine.UI.Text rollButtonText;
    private UnityEngine.UI.Text rollsLeftText;
    private UnityEngine.UI.Text timeLeftText;
    private UnityEngine.UI.Button diceRollCollectButton;
    private WGSnakesAndLaddersDiceRollAnim diceRollAnim;
    private UnityEngine.Transform diceRollTarget;
    private CoinCurrencyCollectAnimationInstantiator coinAnim;
    private DiceRollAnimationInstantiator diceAnim;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnim;
    private FrameSkipper frameSkipper;
    private UnityEngine.Coroutine showDiceRollResultCoroutine;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::Close()));
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::OnClick_Info()));
        this.starterPackButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::OnClick_StarterPack()));
        System.Delegate val_5 = System.Delegate.Combine(a:  this.videoButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::OnClick_Video(bool success)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.videoButton.OnConnectionClick = val_5;
        this.rollButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::OnClick_Roll()));
        this.HideSpaceRewardUI();
        return;
        label_9:
    }
    private void OnEnable()
    {
        this.SetupWindows();
        this.SetupHeader();
        this.SetupDescriptions();
        this.UpdateStarterPackAccess();
    }
    private void SetupWindows()
    {
        this.boardWindow.SetActive(value:  true);
        this.videoFeedbackWindow.SetActive(value:  false);
    }
    private void SetupHeader()
    {
        this.header.Setup(boards:  SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetAllBoards());
    }
    private void SetupDescriptions()
    {
        this.UpdateDiceRollsInfo();
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::UpdateTimeLeft()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        val_2.updateLogic = val_4;
        return;
        label_3:
    }
    private void UpdateDiceRollsInfo()
    {
        int val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        string val_5 = Localization.Localize(key:  (val_1 == 0) ? "get_dice_exclamation" : "roll_upper", defaultValue:  (val_1 == 0) ? "GET DICE!" : "ROLL", useSingularKey:  false).ToUpper();
        string val_7 = System.String.Format(format:  "{0}: {1}", arg0:  Localization.Localize(key:  "rolls_left_upper", defaultValue:  "ROLLS LEFT", useSingularKey:  false), arg1:  val_1);
    }
    private void UpdateTimeLeft()
    {
        System.TimeSpan val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeLeft();
        object[] val_2 = new object[5];
        val_2[0] = Localization.Localize(key:  "time_left_upper", defaultValue:  "TIME LEFT", useSingularKey:  false);
        val_2[1] = val_1._ticks.Days.ToString(format:  "0");
        val_2[2] = val_1._ticks.Hours.ToString(format:  "0");
        val_2[3] = val_1._ticks.Minutes.ToString(format:  "0");
        val_2[4] = val_1._ticks.Seconds.ToString(format:  "0");
        string val_12 = System.String.Format(format:  "{0}: {1}d {2}h {3}m {4}s", args:  val_2);
        if(val_1._ticks.TotalSeconds > 0f)
        {
                return;
        }
        
        this.frameSkipper.updateLogic = 0;
    }
    private void OnClick_Info()
    {
        var val_6;
        System.Action val_8;
        this.infoButton.interactable = false;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                SLCWindow val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSnakesAndLaddersInfoPopup>(showNext:  true).GetComponent<SLCWindow>();
            val_6 = null;
            val_6 = null;
            val_8 = WGSnakesAndLaddersBoardPopup.<>c.<>9__33_0;
            if(val_8 == null)
        {
                System.Action val_5 = null;
            val_8 = val_5;
            val_5 = new System.Action(object:  WGSnakesAndLaddersBoardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSnakesAndLaddersBoardPopup.<>c::<OnClick_Info>b__33_0());
            WGSnakesAndLaddersBoardPopup.<>c.<>9__33_0 = val_8;
        }
        
            val_4.Action_OnClose = val_8;
        }
        
        this.Close();
    }
    private void OnClick_StarterPack()
    {
        var val_6;
        System.Action val_8;
        this.starterPackButton.interactable = false;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                SLCWindow val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterDicePackPopup>(showNext:  true).GetComponent<SLCWindow>();
            val_6 = null;
            val_6 = null;
            val_8 = WGSnakesAndLaddersBoardPopup.<>c.<>9__34_0;
            if(val_8 == null)
        {
                System.Action val_5 = null;
            val_8 = val_5;
            val_5 = new System.Action(object:  WGSnakesAndLaddersBoardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSnakesAndLaddersBoardPopup.<>c::<OnClick_StarterPack>b__34_0());
            WGSnakesAndLaddersBoardPopup.<>c.<>9__34_0 = val_8;
        }
        
            val_4.Action_OnClose = val_8;
        }
        
        this.Close();
    }
    private void OnClick_Video(bool success)
    {
        this.videoButton.interactable = false;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if(success != false)
        {
                this.boardWindow.SetActive(value:  false);
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
            if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
                return;
        }
        
            bool val_6 = MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  18, adCapExempt:  false);
            return;
        }
        
            val_1.<metaGameBehavior>k__BackingField.ShowConnectionRequired();
        }
        
        this.Close();
    }
    private void OnClick_Roll()
    {
        var val_15;
        var val_16;
        System.Action val_18;
        var val_19;
        this.rollButton.interactable = false;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_6;
        }
        
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsOutOfDice()) == false)
        {
            goto label_11;
        }
        
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsEligibleToShowStarterPack()) == false)
        {
            goto label_12;
        }
        
        this.UpdateStarterPackAccess();
        val_15 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterDicePackPopup>(showNext:  true).GetComponent<SLCWindow>();
        val_16 = null;
        val_16 = null;
        val_18 = WGSnakesAndLaddersBoardPopup.<>c.<>9__36_0;
        if(val_18 != null)
        {
            goto label_32;
        }
        
        System.Action val_7 = null;
        val_18 = val_7;
        val_7 = new System.Action(object:  WGSnakesAndLaddersBoardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSnakesAndLaddersBoardPopup.<>c::<OnClick_Roll>b__36_0());
        WGSnakesAndLaddersBoardPopup.<>c.<>9__36_0 = val_18;
        if(val_15 != null)
        {
            goto label_22;
        }
        
        label_11:
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.OnDiceRollUsed();
        this.UpdateDiceRollsInfo();
        this.showDiceRollResultCoroutine = this.StartCoroutine(routine:  this.ShowDiceRollResult(result:  SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceRollResult()));
        return;
        label_12:
        val_15 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStore_DicePacksPopup>(showNext:  true).GetComponent<SLCWindow>();
        val_19 = null;
        val_19 = null;
        val_18 = WGSnakesAndLaddersBoardPopup.<>c.<>9__36_1;
        if(val_18 == null)
        {
                System.Action val_14 = null;
            val_18 = val_14;
            val_14 = new System.Action(object:  WGSnakesAndLaddersBoardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSnakesAndLaddersBoardPopup.<>c::<OnClick_Roll>b__36_1());
            WGSnakesAndLaddersBoardPopup.<>c.<>9__36_1 = val_18;
        }
        
        label_32:
        label_22:
        val_13.Action_OnClose = val_18;
        label_6:
        this.Close();
    }
    private System.Collections.IEnumerator ShowDiceRollResult(SnakesAndLaddersEvent.DiceRollResult result)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .result = result;
        return (System.Collections.IEnumerator)new WGSnakesAndLaddersBoardPopup.<ShowDiceRollResult>d__37();
    }
    private void ShowSpaceRewardUI(int rewardValue, UnityEngine.Sprite icon, SnakesAndLaddersBoardSpace space)
    {
        this.rewardGroup.transform.parent = space.transform;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        this.rewardGroup.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        this.rewardGroup.transform.parent = this.rewardGroup.transform.parent;
        string val_8 = rewardValue.ToString();
        this.rewardIcon.sprite = icon;
        this.rewardGroup.gameObject.SetActive(value:  true);
    }
    private void HideSpaceRewardUI()
    {
        this.rewardGroup.gameObject.SetActive(value:  false);
    }
    private System.Collections.IEnumerator ShowRewardOnPawnLanded(SnakesAndLaddersEvent.BoardSpaceReward reward, SnakesAndLaddersBoardSpace space)
    {
        .<>1__state = 0;
        .reward = reward;
        .<>4__this = this;
        .space = space;
        return (System.Collections.IEnumerator)new WGSnakesAndLaddersBoardPopup.<ShowRewardOnPawnLanded>d__40();
    }
    private void ValidateBoard(SnakesAndLaddersEvent.Board board)
    {
        if(this.boardUI != null)
        {
                this.boardUI.UpdateBoard(forceUpdateBoard:  board);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void UpdateStarterPackAccess()
    {
        bool val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsStarterPackActive();
        this.starterPackButton.gameObject.SetActive(value:  val_1);
        this.infoButton.gameObject.SetActive(value:  (~val_1) & 1);
        if(((~val_1) & 1) != 0)
        {
                return;
        }
        
        if(this.frameSkipper == 0)
        {
                return;
        }
        
        System.Delegate val_8 = System.Delegate.Combine(a:  this.frameSkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::UpdateStarterPackStatus()));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_8;
        return;
        label_13:
    }
    private void UpdateStarterPackStatus()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsStarterPackActive()) == true)
        {
                return;
        }
        
        this.UpdateStarterPackAccess();
        System.Delegate val_3 = System.Delegate.Remove(source:  this.frameSkipper.updateLogic, value:  new System.Action(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::UpdateStarterPackStatus()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_3;
        return;
        label_6:
    }
    private void OnVideoResponse(Notification notif)
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        bool val_3 = System.Boolean.Parse(value:  notif.data.ToString());
        this.boardWindow.SetActive(value:  (~val_3) & 1);
        this.videoFeedbackWindow.SetActive(value:  val_3);
        if(val_3 == false)
        {
                return;
        }
        
        this.diceRollCollectButton.interactable = true;
        this.diceRollCollectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::OnClick_Collect()));
    }
    private void OnClick_Collect()
    {
        this.diceRollCollectButton.m_OnClick.RemoveAllListeners();
        this.diceRollCollectButton.interactable = false;
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  1, source:  "Snakes and Ladders Event");
        mem2[0] = new System.Action(object:  this, method:  System.Void WGSnakesAndLaddersBoardPopup::<OnClick_Collect>b__45_0());
        int val_2 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2);
        this.diceAnim.Play(fromValue:  val_2 - 1, toValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = WGSnakesAndLaddersBoardPopup.<>c.<>9__46_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  WGSnakesAndLaddersBoardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGSnakesAndLaddersBoardPopup.<>c::<ShowConnectionRequired>b__46_0());
            WGSnakesAndLaddersBoardPopup.<>c.<>9__46_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void Close()
    {
        if(this.showDiceRollResultCoroutine != null)
        {
                this.StopCoroutine(routine:  this.showDiceRollResultCoroutine);
            this.showDiceRollResultCoroutine = 0;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGSnakesAndLaddersBoardPopup()
    {
    
    }
    private void <ShowRewardOnPawnLanded>b__40_0()
    {
        this.HideSpaceRewardUI();
        this.gameObject.SetActive(value:  false);
    }
    private void <ShowRewardOnPawnLanded>b__40_1()
    {
        this.HideSpaceRewardUI();
        this.gameObject.SetActive(value:  false);
    }
    private void <ShowRewardOnPawnLanded>b__40_2()
    {
        this.HideSpaceRewardUI();
        this.gameObject.SetActive(value:  false);
    }
    private void <OnClick_Collect>b__45_0()
    {
        this.UpdateDiceRollsInfo();
        this.videoFeedbackWindow.SetActive(value:  false);
        this.boardWindow.SetActive(value:  true);
        this.boardWindow.gameObject.SetActive(value:  false);
    }

}
