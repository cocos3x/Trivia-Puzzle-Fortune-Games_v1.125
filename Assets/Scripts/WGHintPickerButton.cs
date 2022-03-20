using UnityEngine;
public class WGHintPickerButton : MyButton
{
    // Fields
    private UnityEngine.GameObject mainGroup;
    private WGHintPickerButton.HintPickerButtonType buttonType;
    private UnityEngine.UI.Text hintCostText;
    private UnityEngine.GameObject crossedOutCost;
    private UnityEngine.UI.Text crossedOutText;
    private UnityEngine.GameObject discountTimerGroup;
    private UnityEngine.UI.Text discountTimerText;
    private bool alwaysShowDiscount;
    private UnityEngine.GameObject unlockedGroup;
    private UnityEngine.GameObject lockedGroup;
    private UnityEngine.UI.Text unlockLevelText;
    private UnityEngine.GameObject petIcon;
    private UnityEngine.GameObject seasonPassIcon;
    private FrameSkipper frameSkipper;
    
    // Methods
    private void Awake()
    {
        if(this.alwaysShowDiscount == true)
        {
                return;
        }
        
        if(this.discountTimerGroup == 0)
        {
                return;
        }
        
        if(this.discountTimerText == 0)
        {
                return;
        }
        
        this.frameSkipper = this.gameObject.AddComponent<FrameSkipper>();
        val_4.updateLogic = new System.Action(object:  this, method:  System.Void WGHintPickerButton::UpdateFrameSkip());
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnPetsStatusUpdated");
    }
    protected override void Start()
    {
        this.Start();
        this.UpdateDisplay();
    }
    public override void OnButtonClick()
    {
        this.OnButtonClick();
        if(this.buttonType > 3)
        {
                return;
        }
        
        var val_17 = 32497444 + (this.buttonType) << 2;
        val_17 = val_17 + 32497444;
        goto (32497444 + (this.buttonType) << 2 + 32497444);
    }
    private void OnHintDiscountAvailable()
    {
        this.UpdateDisplay();
    }
    private void OnHintDiscountExpire()
    {
        this.UpdateDisplay();
    }
    private void OnPetsStatusUpdated()
    {
        this.UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        UnityEngine.GameObject val_30;
        int val_31;
        var val_32;
        bool val_33;
        val_30 = this;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) <= 0)
        {
            goto label_5;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((UnityEngine.Object.op_Implicit(exists:  this.unlockLevelText)) != false)
        {
                string val_5 = System.String.Format(format:  Localization.Localize(key:  "unlock_at_level_#_upper", defaultValue:  "UNLOCK AT LEVEL {0}", useSingularKey:  false), arg0:  val_2.<metaGameBehavior>k__BackingField);
        }
        
        GameBehavior val_6 = App.getBehavior;
        val_31 = val_6.<metaGameBehavior>k__BackingField;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_31, knobValue:  val_2.<metaGameBehavior>k__BackingField)) == false)
        {
            goto label_20;
        }
        
        val_32 = 1;
        goto label_21;
        label_5:
        val_33 = 0;
        goto label_23;
        label_20:
        val_31 = 1;
        val_32 = WADPetsManager.GetUnlockedPetByAbility(ability:  val_31);
        label_21:
        bool val_29 = WGHintPickerDemoPopup.IsShowing;
        val_29 = val_32 | val_29;
        if((UnityEngine.Object.op_Implicit(exists:  this.unlockedGroup)) != false)
        {
                this.unlockedGroup.SetActive(value:  val_29);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.lockedGroup)) != false)
        {
                this.lockedGroup.SetActive(value:  (~val_29) & 1);
        }
        
        this.lockedGroup.interactable = val_29;
        if((val_29 != false) && (this.hintCostText != 0))
        {
                if(WGHintPickerDemoPopup.IsShowing != false)
        {
                string val_17 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
        }
        else
        {
                if(this.alwaysShowDiscount != false)
        {
                string val_18 = this.GetDiscountedHintCost();
        }
        else
        {
                string val_19 = this.GetRegularHintCost();
        }
        
        }
        
        }
        
        if(this.crossedOutText != 0)
        {
                GameEcon val_21 = App.getGameEcon;
            GameEcon val_22 = App.getGameEcon;
            string val_23 = val_21._HintPickerCost.ToString(format:  val_22.numberFormatInt);
        }
        
        if(this.crossedOutCost != 0)
        {
                this.crossedOutCost.SetActive(value:  false);
        }
        
        if(this.discountTimerGroup != 0)
        {
                this.discountTimerGroup.SetActive(value:  false);
        }
        
        if(this.petIcon != 0)
        {
                this.petIcon.SetActive(value:  false);
        }
        
        if(this.seasonPassIcon == 0)
        {
                return;
        }
        
        val_30 = this.seasonPassIcon;
        val_33 = SeasonPassEventHandler.IsPlusPassActive;
        label_23:
        val_30.SetActive(value:  val_33);
    }
    private string GetDiscountedHintCost()
    {
        int val_15;
        int val_16;
        decimal val_2 = App.getGameEcon.HintPickerCostDiscounted;
        val_15 = val_2.flags;
        val_16 = val_2.lo;
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_3.<metaGameBehavior>k__BackingField.IsPlayingDailyChallenge()) != true)
        {
                decimal val_6 = System.Decimal.op_Explicit(value:  WADPetsManager.GetLevelCurveModifier(ability:  1));
            decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15, hi = val_2.hi, lo = val_16, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
            val_15 = val_7.flags;
            val_16 = val_7.lo;
        }
        
        }
        
        bool val_8 = SeasonPassEventHandler.IsPlusPassActive;
        if(val_8 != false)
        {
                if(val_8.IsPlayingDailyChallenge() != true)
        {
                decimal val_11 = System.Decimal.op_Implicit(value:  SeasonPassEventHandler.PassPickHintDiscount);
            decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15, hi = val_7.hi, lo = val_16, mid = val_7.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
        }
        
        }
        
        GameEcon val_13 = App.getGameEcon;
        return (string)val_12.flags.ToString(format:  val_13.numberFormatInt);
    }
    private string GetRegularHintCost()
    {
        decimal val_14;
        int val_15;
        GameEcon val_1 = App.getGameEcon;
        val_14 = val_1._HintPickerCost;
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_2.<metaGameBehavior>k__BackingField.IsPlayingDailyChallenge()) != true)
        {
                decimal val_5 = System.Decimal.op_Explicit(value:  WADPetsManager.GetLevelCurveModifier(ability:  1));
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_14, hi = val_14, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
            val_14 = val_6.flags;
            val_15 = val_6.lo;
        }
        
        }
        
        bool val_7 = SeasonPassEventHandler.IsPlusPassActive;
        if(val_7 != false)
        {
                if(val_7.IsPlayingDailyChallenge() != true)
        {
                decimal val_10 = System.Decimal.op_Implicit(value:  SeasonPassEventHandler.PassPickHintDiscount);
            decimal val_11 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_14, hi = val_6.hi, lo = val_15, mid = val_6.mid}, d2:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
        }
        
        }
        
        GameEcon val_12 = App.getGameEcon;
        return (string)val_11.flags.ToString(format:  val_12.numberFormatInt);
    }
    private void UpdateFrameSkip()
    {
    
    }
    private void UpdateTimer()
    {
    
    }
    private bool IsPlayingDailyChallenge()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return false;
        }
        
        return MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
    }
    public WGHintPickerButton()
    {
    
    }

}
