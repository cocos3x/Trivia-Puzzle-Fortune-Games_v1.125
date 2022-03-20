using UnityEngine;
public class BonusGameSlotMachinePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button mainButton;
    private UnityEngine.UI.Text mainButtonText;
    private UnityEngine.UI.Text amountText;
    private UnityEngine.GameObject coinIcon;
    private UnityEngine.GameObject appleIcon;
    private SlotMachineReel amountReel1;
    private SlotMachineReel amountReel2;
    private SlotMachineReel typeReel;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private GoldenCurrencyCollectAnimationInstantiator starsAnim;
    private bool hasPrize;
    private int prizeAmount;
    private BonusGameSlotMachineRewardType rewardType;
    public string trackEventSource;
    public System.Action OnRewarded;
    private static GameEventRewardType qaHackFlagAwardType;
    
    // Properties
    public static GameEventRewardType QAHACK_ForceAwardType { get; set; }
    
    // Methods
    public void SetOnClose(System.Action onClose)
    {
        System.Delegate val_3 = System.Delegate.Combine(a:  this.gameObject.GetComponent<WGWindow>(), b:  onClose);
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        mem2[0] = val_3;
        return;
        label_4:
    }
    public void OnButtonPressed()
    {
        if(this.hasPrize != false)
        {
                this.OnCollectPressed();
            return;
        }
        
        this.SpinReels();
    }
    private void OnEnable()
    {
        string val_1 = Localization.Localize(key:  "spin_upper", defaultValue:  "SPIN", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SpinReels()
    {
        var val_20;
        IntPtr val_22;
        BonusGameSlotMachinePopup.<>c__DisplayClass18_0 val_1 = new BonusGameSlotMachinePopup.<>c__DisplayClass18_0();
        .<>4__this = this;
        this.mainButton.interactable = false;
        SlotMachineEconomy val_2 = new SlotMachineEconomy();
        this.rewardType = ((UnityEngine.Random.Range(min:  0f, max:  100f)) >= 0) ? 1 : 0;
        if((CompanyDevices.Instance.CompanyDevice() == false) || (BonusGameSlotMachinePopup.QAHACK_ForceAwardType == 0))
        {
            goto label_16;
        }
        
        if(BonusGameSlotMachinePopup.QAHACK_ForceAwardType != 1)
        {
            goto label_12;
        }
        
        this.rewardType = 0;
        goto label_19;
        label_12:
        if(BonusGameSlotMachinePopup.QAHACK_ForceAwardType != 2)
        {
            goto label_16;
        }
        
        this.rewardType = 1;
        if(val_2 != null)
        {
            goto label_17;
        }
        
        label_16:
        if(this.rewardType == 0)
        {
            goto label_19;
        }
        
        if(this.rewardType != 1)
        {
            goto label_20;
        }
        
        label_17:
        val_20 = val_2;
        int val_10 = val_2.GetStarReward();
        goto label_22;
        label_19:
        val_20 = val_2;
        label_22:
        this.prizeAmount = val_2.GetCoinReward();
        label_20:
        .secondReelExtraSpin = 2;
        .typeReelExtraSpin = 8;
        int val_20 = this.prizeAmount;
        if(val_20 < 100)
        {
                val_20 = val_20 >> 34;
            val_20 = val_20 + (val_20 >> 63);
            this.amountReel1.SpinToIndex(targetIndex:  val_20 - 1, extraRounds:  1, callBack:  0);
            val_22 = 1152921516096120080;
        }
        else
        {
                val_20 = val_20 >> 37;
            this.amountReel1.SpinToIndex(targetIndex:  val_20 - 1, extraRounds:  1, callBack:  0);
            DG.Tweening.TweenCallback val_15 = null;
            val_22 = 1152921516096125200;
        }
        
        val_15 = new DG.Tweening.TweenCallback(object:  val_1, method:  val_22);
        DG.Tweening.Tween val_16 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.15f, callback:  val_15, ignoreTimeScale:  true);
        .targetIndex = 0;
        .targetIndex = (this.rewardType == 0) ? 1 : 0;
        DG.Tweening.Tween val_19 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.3f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void BonusGameSlotMachinePopup.<>c__DisplayClass18_0::<SpinReels>b__2()), ignoreTimeScale:  true);
        this.hasPrize = true;
    }
    private void OnSpinPressed()
    {
        this.SpinReels();
    }
    private void OnCollectPressed()
    {
        this.mainButton.interactable = false;
        if(this.rewardType != 1)
        {
                if(this.rewardType != 0)
        {
                return;
        }
        
            decimal val_2 = System.Decimal.op_Implicit(value:  this.prizeAmount);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  this.trackEventSource, subSource:  "Bonus Game Slot Machine", externalParams:  0, doTrack:  true);
            if(this.OnRewarded != null)
        {
                this.OnRewarded.Invoke();
        }
        
            this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void BonusGameSlotMachinePopup::OnRewardAnimationComplete());
            Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Implicit(value:  this.prizeAmount);
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = this.coinsAnim, mid = this.coinsAnim}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
            Player val_7 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        GoldenApplesManager val_8 = MonoSingleton<GoldenApplesManager>.Instance;
        WGWindow val_10 = this.gameObject.GetComponent<WGWindow>();
        System.Delegate val_13 = System.Delegate.Combine(a:  X21, b:  new System.Action(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnBonusGameGoldCurrencyRewardGranted()));
        if(val_13 != null)
        {
                if(null != null)
        {
            goto label_26;
        }
        
        }
        
        mem2[0] = val_13;
        if(this.OnRewarded != null)
        {
                this.OnRewarded.Invoke();
        }
        
        DG.Tweening.Tween val_15 = DG.Tweening.DOVirtual.DelayedCall(delay:  2f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BonusGameSlotMachinePopup::OnRewardAnimationComplete()), ignoreTimeScale:  true);
        mem2[0] = new System.Action(object:  this, method:  System.Void BonusGameSlotMachinePopup::OnRewardAnimationComplete());
        Player val_17 = App.Player;
        Player val_18 = App.Player;
        decimal val_19 = System.Decimal.op_Implicit(value:  val_18._stars);
        this.starsAnim.Play(fromValue:  val_17._stars - this.prizeAmount, toValue:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_26:
    }
    private void OnRewardAnimationComplete()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public static GameEventRewardType get_QAHACK_ForceAwardType()
    {
        var val_3;
        GameEventRewardType val_4;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_3 = null;
            val_3 = null;
            val_4 = BonusGameSlotMachinePopup.qaHackFlagAwardType;
            return (GameEventRewardType)val_4;
        }
        
        val_4 = 0;
        return (GameEventRewardType)val_4;
    }
    public static void set_QAHACK_ForceAwardType(GameEventRewardType value)
    {
        var val_3;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        BonusGameSlotMachinePopup.qaHackFlagAwardType = value;
    }
    public BonusGameSlotMachinePopup()
    {
        this.trackEventSource = "Bonus Game Slot Machine";
    }
    private static BonusGameSlotMachinePopup()
    {
    
    }

}
