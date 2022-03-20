using UnityEngine;
public class RaidMadnessPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button buttonClose;
    protected UnityEngine.UI.Text raidTimesText;
    protected UnityEngine.UI.Slider progressBar;
    protected UnityEngine.UI.Text progressText;
    protected UnityEngine.UI.Text rewardAmountText;
    protected UnityEngine.UI.Image rewardIconImage;
    protected UnityEngine.UI.Text finalPrizeText;
    protected UnityEngine.UI.Button raidNowButton;
    protected UnityEngine.UI.Text timerText;
    protected UnityEngine.Sprite iconCoins;
    protected UnityEngine.Sprite iconSpins;
    protected UnityEngine.Sprite iconGold;
    protected UnityEngine.Sprite iconGoldPrize;
    protected UnityEngine.Sprite iconFood;
    protected DG.Tweening.Sequence timerSequence;
    
    // Properties
    protected RaidMadnessEventHandler Handler { get; }
    
    // Methods
    protected RaidMadnessEventHandler get_Handler()
    {
        return (RaidMadnessEventHandler)RaidMadnessEventHandler.<Instance>k__BackingField;
    }
    private void Start()
    {
        object val_17;
        RaidMadnessEventHandler val_18;
        object val_19;
        int val_22;
        int val_23;
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void RaidMadnessPopup::Close()));
        this.raidNowButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(RaidMadnessPopup).__il2cppRuntimeField_188));
        val_18 = RaidMadnessEventHandler.<Instance>k__BackingField;
        if((RaidMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) != false)
        {
                RESEventRewardData val_4 = val_18.GetFinalPrize();
        }
        
        val_19 = X23.ToString();
        mem2[0] = X23;
        var val_17 = X23;
        object val_7 = ((RaidMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) != true) ? (RaidMadnessEventHandler.<Instance>k__BackingField + 20) : RaidMadnessEventHandler.<Instance>k__BackingField;
        val_17 = val_17 - 1;
        if(val_17 <= 3)
        {
                var val_18 = 32556672 + ((X23 - 1)) << 2;
            val_18 = val_18 + 32556672;
        }
        else
        {
                if((RaidMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) != false)
        {
            
        }
        else
        {
                object[] val_10 = new object[4];
            int val_11 = (RaidMadnessEventHandler.<Instance>k__BackingField + 20) - val_7;
            val_22 = val_10.Length;
            val_10[0] = UnityEngine.Mathf.Max(a:  0, b:  val_11);
            object val_13 = (val_11 > 1) ? "s" : "";
            if(val_13 != 0)
        {
                val_22 = val_10.Length;
        }
        
            val_10[1] = val_13;
            val_17 = X0.ToString(format:  "G29");
            val_23 = val_10.Length;
            val_10[2] = val_17;
            if( != null)
        {
                val_23 = val_10.Length;
        }
        
            val_10[3] = ;
            string val_15 = System.String.Format(format:  "Raid {0} time{1} to get {2} {3}", args:  val_10);
        }
        
            float val_19 = (float)val_7;
            val_19 = val_19 / ((float)RaidMadnessEventHandler.<Instance>k__BackingField + 20);
            string val_16 = System.String.Format(format:  "{0}/{1}", arg0:  val_7, arg1:  RaidMadnessEventHandler.<Instance>k__BackingField + 20);
            this.SetTimer();
        }
    
    }
    protected virtual void Initialize()
    {
        RESEventRewardData val_1 = RaidMadnessEventHandler.<Instance>k__BackingField.GetFinalPrize();
        mem2[0] = val_1.rewardType;
        string val_4 = System.String.Format(format:  "{0} {1}", arg0:  this, arg1:  val_1.rewardType.ToString().ToUpper());
        if((RaidMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) == false)
        {
                return;
        }
        
        this.rewardIconImage.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void OnDestroy()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected virtual void OnMainButtonClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void SetTimer()
    {
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_1;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void RaidMadnessPopup::<SetTimer>b__23_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    protected virtual string GetTimerText()
    {
        System.TimeSpan val_1 = RaidMadnessEventHandler.<Instance>k__BackingField.GetTimeLeft();
        int val_7 = 24;
        val_7 = val_1._ticks.Hours + (val_1._ticks.Days * val_7);
        return (string)System.String.Format(format:  "Time Left: {0}:{1:00}:{2:00}", arg0:  val_7, arg1:  val_1._ticks.Minutes, arg2:  val_1._ticks.Seconds);
    }
    protected virtual string GetAmountString(decimal amount)
    {
        decimal val_1 = new System.Decimal(value:  232);
        return (string)MetricSystem.Abbreviate(number:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_1.flags, hi = val_1.flags, lo = val_1.lo, mid = val_1.lo}, useRichText:  false, withSpaces:  false);
    }
    public RaidMadnessPopup()
    {
    
    }
    private void <SetTimer>b__23_0()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
