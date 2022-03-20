using UnityEngine;
public class HotNSpicyPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Image rewardIconImage;
    private UnityEngine.UI.Text rewardAmountText;
    private UnityEngine.UI.Text collectFireText;
    private UnityEngine.UI.Text attackAmountText;
    private UnityEngine.UI.Text attackBlockedAmountText;
    private UnityEngine.UI.Text raidAmountText;
    private UnityEngine.UI.Text perfectRaidAmountText;
    private UnityEngine.UI.Text threeSymbolsAmountText;
    private UnityEngine.UI.Button burningHotButton;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.Sprite iconCoins;
    private UnityEngine.Sprite iconSpins;
    private DG.Tweening.Sequence timerSequence;
    
    // Methods
    private void Start()
    {
        UnityEngine.Sprite val_14;
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void HotNSpicyPopup::Close()));
        this.burningHotButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void HotNSpicyPopup::Close()));
        if(((HotNSpicyEventHandler.<Instance>k__BackingField) & 1) != 0)
        {
            
        }
        else
        {
                string val_4 = System.String.Format(format:  "Collect {0}    \nto win!", arg0:  (HotNSpicyEventHandler.<Instance>k__BackingField + 20) - (HotNSpicyEventHandler.<Instance>k__BackingField));
        }
        
        float val_13 = (float)HotNSpicyEventHandler.<Instance>k__BackingField;
        val_13 = val_13 / ((float)HotNSpicyEventHandler.<Instance>k__BackingField + 20);
        string val_5 = System.String.Format(format:  "{0}/{1}", arg0:  HotNSpicyEventHandler.<Instance>k__BackingField, arg1:  HotNSpicyEventHandler.<Instance>k__BackingField + 20);
        decimal val_6 = new System.Decimal(value:  232);
        string val_7 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = HotNSpicyEventHandler.<Instance>k__BackingField + 24, hi = HotNSpicyEventHandler.<Instance>k__BackingField + 24, lo = 317624320, mid = 268435456}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo}, useRichText:  false, withSpaces:  false);
        if((HotNSpicyEventHandler.<Instance>k__BackingField + 16) == 2)
        {
            goto label_17;
        }
        
        if((HotNSpicyEventHandler.<Instance>k__BackingField + 16) != 1)
        {
            goto label_18;
        }
        
        val_14 = this.iconCoins;
        goto label_20;
        label_17:
        val_14 = this.iconSpins;
        label_20:
        this.rewardIconImage.sprite = val_14;
        label_18:
        string val_8 = HotNSpicyEventHandler.<Instance>k__BackingField.econ.pointsGainPerAttack.ToString();
        string val_9 = HotNSpicyEventHandler.<Instance>k__BackingField.econ.pointsGainPerAttackBlocked.ToString();
        string val_10 = HotNSpicyEventHandler.<Instance>k__BackingField.econ.pointsGainPerRaid.ToString();
        string val_11 = HotNSpicyEventHandler.<Instance>k__BackingField.econ.pointsGainPerRaidPerfect.ToString();
        string val_12 = HotNSpicyEventHandler.<Instance>k__BackingField.econ.pointsGainPerHit3Symbols.ToString();
        this.SetTimer();
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
    public void Close()
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
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void HotNSpicyPopup::<SetTimer>b__20_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    private string GetTimerText()
    {
        System.TimeSpan val_1 = HotNSpicyEventHandler.<Instance>k__BackingField.GetTimeLeft();
        return (string)System.String.Format(format:  "Time Left: {0}:{1:00}:{2:00}", arg0:  val_1._ticks.Hours, arg1:  val_1._ticks.Minutes, arg2:  val_1._ticks.Seconds);
    }
    public HotNSpicyPopup()
    {
    
    }
    private void <SetTimer>b__20_0()
    {
        string val_1 = this.GetTimerText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
