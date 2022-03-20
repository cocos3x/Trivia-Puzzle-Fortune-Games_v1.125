using UnityEngine;
public class TRVAskExpertDisplay : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Image expertImage;
    private UnityEngine.UI.Image lockImage;
    private UnityEngine.UI.Image cooldownOverlay;
    private UnityEngine.UI.Text expertName;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text speedupCostText;
    private TRVExpertProficiencyDisplay proficiencyDisplay;
    private UnityEngine.UI.Button speedUpButton;
    private UnityEngine.UI.Button askExpertButton;
    private UnityEngine.GameObject timerParent;
    private TRVExpert _expert;
    private TRVExpertProgressData myProgressData;
    private string displayingProf;
    public System.Action onClickAction;
    public System.Action onClickSpeedUp;
    
    // Methods
    public void Init(TRVExpert expert, TRVExpertProgressData progData, string profToDisplay)
    {
        object val_25;
        object val_26;
        TRVExpertProficiencyDisplay val_27;
        System.Collections.Generic.List<TRVCategoryProficiencies> val_28;
        IntPtr val_30;
        val_25 = this;
        TRVAskExpertDisplay.<>c__DisplayClass15_0 val_1 = null;
        val_26 = val_1;
        val_1 = new TRVAskExpertDisplay.<>c__DisplayClass15_0();
        .profToDisplay = profToDisplay;
        this._expert = expert;
        this.myProgressData = progData;
        this.displayingProf = (TRVAskExpertDisplay.<>c__DisplayClass15_0)[1152921517135374464].profToDisplay;
        this.cooldownOverlay.gameObject.SetActive(value:  false);
        this.expertImage.sprite = expert.mySprite;
        string val_3 = expert.GetLocalizedName;
        this.timerParent.SetActive(value:  false);
        val_27 = this.proficiencyDisplay;
        if(progData != null)
        {
                val_28 = progData.<proficiencies>k__BackingField;
            val_30 = 1152921517135139264;
        }
        else
        {
                val_28 = expert.myProfs;
            System.Func<TRVCategoryProficiencies, System.Boolean> val_4 = null;
            val_30 = 1152921517135148480;
        }
        
        val_4 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  val_1, method:  val_30);
        val_27.DisplayProf(data:  System.Linq.Enumerable.FirstOrDefault<TRVCategoryProficiencies>(source:  val_28, predicate:  val_4));
        UnityEngine.GameObject val_6 = this.lockImage.gameObject;
        if(progData == null)
        {
            goto label_13;
        }
        
        val_6.SetActive(value:  false);
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7.dateData}, d2:  new System.DateTime() {dateData = progData.<lastHelpUsed>k__BackingField});
        val_27 = 1152921516941158704;
        TRVExpertsController val_10 = MonoSingleton<TRVExpertsController>.Instance;
        int val_12 = val_10.myEcon.getExpertCooldown * 3600;
        if(val_8._ticks.TotalSeconds >= 0)
        {
            goto label_22;
        }
        
        this.timerParent.SetActive(value:  true);
        mem[1152921517135330216] = new System.Action(object:  this, method:  System.Void TRVAskExpertDisplay::UpdateTimeRemaining());
        this.askExpertButton.interactable = false;
        this.speedUpButton.gameObject.SetActive(value:  true);
        this.cooldownOverlay.gameObject.SetActive(value:  true);
        this.lockImage.gameObject.SetActive(value:  false);
        this.speedUpButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_17 = null;
        val_26 = val_17;
        val_17 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVAskExpertDisplay::PressSpeedUp());
        this.speedUpButton.m_OnClick.AddListener(call:  val_17);
        val_25 = this.speedupCostText;
        TRVExpertsController val_18 = MonoSingleton<TRVExpertsController>.Instance;
        string val_19 = val_18.myEcon.expertSpeedUpCost.ToString();
        return;
        label_13:
        val_6.SetActive(value:  true);
        this.timerText.gameObject.SetActive(value:  false);
        this.speedUpButton.gameObject.SetActive(value:  false);
        this.askExpertButton.interactable = false;
        return;
        label_22:
        mem[1152921517135330216] = 0;
        this.speedUpButton.gameObject.SetActive(value:  false);
        this.timerText.gameObject.SetActive(value:  false);
        this.askExpertButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_24 = null;
        val_26 = val_24;
        val_24 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVAskExpertDisplay::PressAskExpert());
        this.askExpertButton.m_OnClick.AddListener(call:  val_24);
    }
    private void UpdateTimeRemaining()
    {
        UnityEngine.UI.Text val_19;
        object val_20;
        val_19 = this;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.myProgressData.<lastHelpUsed>k__BackingField});
        val_20 = 1152921516941158704;
        TRVExpertsController val_4 = MonoSingleton<TRVExpertsController>.Instance;
        int val_6 = val_4.myEcon.getExpertCooldown * 3600;
        if(val_2._ticks.TotalSeconds < 0)
        {
                TRVExpertsController val_7 = MonoSingleton<TRVExpertsController>.Instance;
            System.DateTime val_9 = this.myProgressData.<lastHelpUsed>k__BackingField.AddHours(value:  (double)val_7.myEcon.getExpertCooldown);
            System.DateTime val_10 = DateTimeCheat.UtcNow;
            System.TimeSpan val_11 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_9.dateData}, d2:  new System.DateTime() {dateData = val_10.dateData});
            val_19 = this.timerText;
            val_20 = val_11._ticks.Minutes.ToString(format:  "0");
            string val_18 = System.String.Format(format:  "{00}:{01}:{02}", arg0:  val_11._ticks.Hours.ToString(format:  "0"), arg1:  val_20, arg2:  val_11._ticks.Seconds.ToString(format:  "0"));
            return;
        }
        
        this.Init(expert:  this._expert, progData:  this.myProgressData, profToDisplay:  this.displayingProf);
    }
    private void PressSpeedUp()
    {
        if(this.onClickSpeedUp == null)
        {
                return;
        }
        
        this.onClickSpeedUp.Invoke();
    }
    private void PressAskExpert()
    {
        if(this.onClickAction == null)
        {
                return;
        }
        
        this.onClickAction.Invoke();
    }
    public TRVAskExpertDisplay()
    {
    
    }

}
