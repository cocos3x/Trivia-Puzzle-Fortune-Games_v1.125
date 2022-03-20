using UnityEngine;
public class WGHintButton : MyButton
{
    // Fields
    private UnityEngine.UI.Text hintCostText;
    private UnityEngine.GameObject crossedOutCost;
    private UnityEngine.UI.Text crossedOutText;
    private bool alwaysShowDiscount;
    private UnityEngine.UI.Image hintImage;
    private UnityEngine.GameObject popUp;
    private UnityEngine.UI.Text popupText;
    private UnityEngine.GameObject petIcon;
    private UnityEngine.GameObject seasonPassIcon;
    private bool isChallengingLevelLoaded;
    
    // Methods
    protected override void Start()
    {
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WGHintButton::OnLevelLoaded(GameLevel level)));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnPetsStatusUpdated");
        this.Start();
        this.UpdateDisplay();
        MonoSingleton<HintFeatureManager>.Instance.DoHintButtonStartBehavior(button:  this);
    }
    public override void OnButtonClick()
    {
        this.OnButtonClick();
        GameBehavior val_1 = App.getBehavior;
        this.UpdateDisplay();
    }
    public void ToggleInteractable(bool state)
    {
        if(this != null)
        {
                this.interactable = state;
            return;
        }
        
        throw new NullReferenceException();
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
    private void OnLevelLoaded(GameLevel level)
    {
        if(level != null)
        {
                this.isChallengingLevelLoaded = level.isChallengingLevel;
            this.UpdateDisplay();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void UpdateDisplay()
    {
        this.popUp.SetActive(value:  false);
        if(this.petIcon != 0)
        {
                this.petIcon.SetActive(value:  false);
        }
        
        if(this.hintCostText != 0)
        {
                if(this.alwaysShowDiscount != false)
        {
                string val_3 = this.GetDiscountedHintCost();
        }
        else
        {
                string val_4 = this.GetRegularHintCost();
        }
        
        }
        
        if(this.crossedOutText != 0)
        {
                GameEcon val_6 = App.getGameEcon;
            GameEcon val_7 = App.getGameEcon;
            string val_8 = val_6._HintCost.ToString(format:  val_7.numberFormatInt);
        }
        
        if(this.crossedOutCost != 0)
        {
                this.crossedOutCost.SetActive(value:  false);
        }
        
        if(this.seasonPassIcon != 0)
        {
                this.seasonPassIcon.SetActive(value:  SeasonPassEventHandler.IsPlusPassActive);
        }
        
        this.CheckFreeHinting();
    }
    public void CheckFreeHinting()
    {
        var val_5;
        var val_6;
        val_5 = this;
        HintFeatureManager val_1 = MonoSingleton<HintFeatureManager>.Instance;
        if(val_1.freeHintOnLastCheck == true)
        {
            goto label_4;
        }
        
        val_6 = null;
        if(WGHintButtonDemoPopup.IsShowing == false)
        {
            goto label_7;
        }
        
        label_4:
        string val_3 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
        label_10:
        val_5 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_7:
        string val_4 = val_5.GetRegularHintCost();
        goto label_10;
    }
    public void SetPopup(string message, bool interactablePopup)
    {
        this.StopAllCoroutines();
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.popUp).blocksRaycasts = interactablePopup;
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.WaitThenShow());
    }
    private string GetDiscountedHintCost()
    {
        int val_15;
        int val_16;
        decimal val_2 = App.getGameEcon.HintCostDiscounted;
        val_15 = val_2.flags;
        val_16 = val_2.lo;
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_3.<metaGameBehavior>k__BackingField.IsPlayingDailyChallenge()) != true)
        {
                decimal val_6 = System.Decimal.op_Explicit(value:  WADPetsManager.GetLevelCurveModifier(ability:  0));
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
                decimal val_11 = System.Decimal.op_Implicit(value:  SeasonPassEventHandler.PassHintDiscount);
            decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15, hi = val_7.hi, lo = val_16, mid = val_7.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
        }
        
        }
        
        GameEcon val_13 = App.getGameEcon;
        return (string)val_12.flags.ToString(format:  val_13.numberFormatInt);
    }
    private string GetRegularHintCost()
    {
        int val_17;
        decimal val_18;
        int val_19;
        val_17 = this;
        GameEcon val_1 = App.getGameEcon;
        val_18 = val_1._HintCost;
        if(this.isChallengingLevelLoaded != false)
        {
                GameEcon val_2 = App.getGameEcon;
            val_17 = val_2.difficultySettingHintDiscount;
            decimal val_3 = System.Decimal.op_Implicit(value:  val_17);
            decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_18, hi = val_18, lo = 41963520}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            val_18 = val_4.flags;
            val_19 = val_4.lo;
        }
        
        GameBehavior val_5 = App.getBehavior;
        if(((val_5.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_5.<metaGameBehavior>k__BackingField.IsPlayingDailyChallenge()) != true)
        {
                decimal val_8 = System.Decimal.op_Explicit(value:  WADPetsManager.GetLevelCurveModifier(ability:  0));
            decimal val_9 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_18, hi = val_4.hi, lo = val_19, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            val_18 = val_9.flags;
            val_19 = val_9.lo;
        }
        
        }
        
        bool val_10 = SeasonPassEventHandler.IsPlusPassActive;
        if(val_10 != false)
        {
                if(val_10.IsPlayingDailyChallenge() != true)
        {
                val_17 = SeasonPassEventHandler.PassHintDiscount;
            decimal val_13 = System.Decimal.op_Implicit(value:  val_17);
            decimal val_14 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_18, hi = val_9.hi, lo = val_19, mid = val_9.mid}, d2:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid});
        }
        
        }
        
        GameEcon val_15 = App.getGameEcon;
        return (string)val_14.flags.ToString(format:  val_15.numberFormatInt);
    }
    private System.Collections.IEnumerator WaitThenShow()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGHintButton.<WaitThenShow>d__22();
    }
    private bool IsPlayingDailyChallenge()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return false;
        }
        
        return MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
    }
    public WGHintButton()
    {
    
    }
    private void <WaitThenShow>b__22_0()
    {
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
        this.hintImage.transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    private void <WaitThenShow>b__22_1()
    {
        if(this.popUp != null)
        {
                this.popUp.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
