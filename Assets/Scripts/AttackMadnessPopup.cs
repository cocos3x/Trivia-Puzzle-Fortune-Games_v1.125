using UnityEngine;
public class AttackMadnessPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button buttonClose;
    protected UnityEngine.UI.Text attackTimesText;
    protected UnityEngine.UI.Slider progressBar;
    protected UnityEngine.UI.Text progressText;
    protected UnityEngine.UI.Text rewardAmountText;
    protected UnityEngine.UI.Image rewardIconImage;
    protected UnityEngine.UI.Text grandPrizeText;
    protected UnityEngine.UI.Button attackNowButton;
    protected UnityEngine.UI.Text timerText;
    protected UnityEngine.Sprite iconCoins;
    protected UnityEngine.Sprite iconSpins;
    protected UnityEngine.Sprite iconGold;
    protected UnityEngine.Sprite iconGoldPrize;
    protected UnityEngine.Sprite iconFood;
    protected DG.Tweening.Sequence timerSequence;
    
    // Properties
    protected AttackMadnessEventHandler Handler { get; }
    
    // Methods
    protected AttackMadnessEventHandler get_Handler()
    {
        return (AttackMadnessEventHandler)AttackMadnessEventHandler.<Instance>k__BackingField;
    }
    private void Start()
    {
        object val_14;
        object val_15;
        int val_18;
        int val_19;
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AttackMadnessPopup::Close()));
        this.attackNowButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(AttackMadnessPopup).__il2cppRuntimeField_188));
        val_15 = X23.ToString();
        mem2[0] = X23;
        var val_14 = X23;
        object val_5 = ((AttackMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) != true) ? (AttackMadnessEventHandler.<Instance>k__BackingField + 20) : AttackMadnessEventHandler.<Instance>k__BackingField;
        val_14 = val_14 - 1;
        if(val_14 <= 3)
        {
                var val_15 = 32556988 + ((X23 - 1)) << 2;
            val_15 = val_15 + 32556988;
        }
        else
        {
                if((AttackMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) != false)
        {
            
        }
        else
        {
                object[] val_8 = new object[4];
            object val_9 = (AttackMadnessEventHandler.<Instance>k__BackingField + 20) - val_5;
            val_18 = val_8.Length;
            val_8[0] = val_9;
            object val_10 = (val_9 > 1) ? "s" : "";
            if(val_10 != 0)
        {
                val_18 = val_8.Length;
        }
        
            val_8[1] = val_10;
            val_14 = X0.ToString(format:  "G29");
            val_19 = val_8.Length;
            val_8[2] = val_14;
            if( != null)
        {
                val_19 = val_8.Length;
        }
        
            val_8[3] = ;
            string val_12 = System.String.Format(format:  "Attack {0} time{1} to get {2} {3}", args:  val_8);
        }
        
            float val_16 = (float)val_5;
            val_16 = val_16 / ((float)AttackMadnessEventHandler.<Instance>k__BackingField + 20);
            string val_13 = System.String.Format(format:  "{0}/{1}", arg0:  val_5, arg1:  AttackMadnessEventHandler.<Instance>k__BackingField + 20);
            this.SetTimer();
        }
    
    }
    protected virtual void Initialize()
    {
        decimal val_1 = AttackMadnessEventHandler.<Instance>k__BackingField.GetGrandPrizeSpinAmount();
        string val_2 = System.String.Format(format:  "{0} SPINS", arg0:  this);
        if((AttackMadnessEventHandler.<Instance>k__BackingField.HasCollectedAllRewards()) == false)
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
    protected void SetTimer()
    {
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_1;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void AttackMadnessPopup::<SetTimer>b__23_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    protected virtual string GetTimerText()
    {
        int val_6 = 24;
        val_6 = (AttackMadnessEventHandler.<Instance>k__BackingField.Hours) + ((AttackMadnessEventHandler.<Instance>k__BackingField.Days) * val_6);
        return (string)System.String.Format(format:  "Time Left: {0}:{1:00}:{2:00}", arg0:  val_6, arg1:  AttackMadnessEventHandler.<Instance>k__BackingField.Minutes, arg2:  AttackMadnessEventHandler.<Instance>k__BackingField.Seconds);
    }
    protected virtual string GetAmountString(decimal amount)
    {
        decimal val_1 = new System.Decimal(value:  232);
        return (string)MetricSystem.Abbreviate(number:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_1.flags, hi = val_1.flags, lo = val_1.lo, mid = val_1.lo}, useRichText:  false, withSpaces:  false);
    }
    public AttackMadnessPopup()
    {
    
    }
    private void <SetTimer>b__23_0()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
