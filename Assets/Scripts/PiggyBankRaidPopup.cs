using UnityEngine;
public class PiggyBankRaidPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject inProgressGroup;
    private UnityEngine.GameObject fullGroup;
    private UnityEngine.UI.Text bannerText;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.Transform piggyImageTransform;
    private UnityEngine.GameObject piggyImageInProgress;
    private UnityEngine.GameObject piggyImageFull;
    private UnityEngine.GameObject piggyImageOverflow;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressBarText;
    private UnityEngine.GameObject ProgressBarCoinIcon;
    private UnityEngine.UI.Text piggyLevelText;
    private UnityEngine.Transform raidHistoryParent;
    private UnityEngine.UI.Text infoTextFull;
    private UGUINetworkedButton openButtonFull;
    private UnityEngine.UI.Text openButtonFullText;
    private UnityEngine.UI.Button discardButton;
    private UnityEngine.UI.Text discardButtonText;
    private UnityEngine.UI.Text discardButtonTextAmountOnly;
    private GridCoinCollectAnimationInstantiator coinAnimation;
    private PiggyBankRaidHistoryItem raidHistoryItemPrefab;
    private SLC.Social.AvatarConfig avatarConfig;
    private UnityEngine.Vector3 progressBarPositionInProgress;
    private UnityEngine.Vector3 progressBarPositionFull;
    private UnityEngine.Vector3 piggyImagePositionInProgress;
    private UnityEngine.Vector3 piggyImagePositionFull;
    private PiggyBankRaidEventHandler eventHandler;
    
    // Methods
    private void Start()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPopup::OnCloseButtonClicked()));
        this.discardButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPopup::OnCloseButtonClicked()));
        System.Delegate val_4 = System.Delegate.Combine(a:  this.openButtonFull.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankRaidPopup::OnOpenButtonClicked(bool connected)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        this.openButtonFull.OnConnectionClick = val_4;
        System.Delegate val_6 = System.Delegate.Combine(a:  this.eventHandler.OnPurchaseAttempt, b:  new System.Action<System.Boolean, System.Decimal>(object:  this, method:  System.Void PiggyBankRaidPopup::OnPurchaseAttempt(bool isSuccess, decimal amount)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        this.eventHandler.OnPurchaseAttempt = val_6;
        this.RefreshState();
        return;
        label_10:
    }
    private void OnDestroy()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  this.eventHandler.OnPurchaseAttempt, value:  new System.Action<System.Boolean, System.Decimal>(object:  this, method:  System.Void PiggyBankRaidPopup::OnPurchaseAttempt(bool isSuccess, decimal amount)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.eventHandler.OnPurchaseAttempt = val_2;
        return;
        label_3:
    }
    public void PlayAddCoinAnimation(decimal addedAmount)
    {
        PiggyBankRaidPopup.<>c__DisplayClass29_0 val_1 = new PiggyBankRaidPopup.<>c__DisplayClass29_0();
        .<>4__this = this;
        decimal val_2 = this.eventHandler.PiggyBankCoins;
        float val_3 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        float val_4 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = addedAmount.flags, hi = addedAmount.hi, lo = addedAmount.lo, mid = addedAmount.mid});
        val_4 = val_3 - val_4;
        .startAmount = val_4;
        decimal val_6 = this.eventHandler.econ.bankMaxCoins.Item[this.eventHandler.PiggyBankLevel];
        .maxAmount = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        decimal val_8 = System.Decimal.op_Explicit(value:  (PiggyBankRaidPopup.<>c__DisplayClass29_0)[1152921516589974384].startAmount);
        decimal val_9 = System.Decimal.op_Explicit(value:  (PiggyBankRaidPopup.<>c__DisplayClass29_0)[1152921516589974384].maxAmount);
        string val_10 = val_9.flags.GetProgressBarText(currentAmount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, bankMaxAmount:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        float val_15 = (PiggyBankRaidPopup.<>c__DisplayClass29_0)[1152921516589974384].maxAmount;
        val_15 = ((PiggyBankRaidPopup.<>c__DisplayClass29_0)[1152921516589974384].startAmount) / val_15;
        float val_16 = (PiggyBankRaidPopup.<>c__DisplayClass29_0)[1152921516589974384].maxAmount;
        val_16 = val_3 / val_16;
        DG.Tweening.Tweener val_11 = DG.Tweening.ShortcutExtensions46.DOValue(target:  this.progressBar, endValue:  val_16, duration:  1f, snapping:  false);
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_14 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single PiggyBankRaidPopup.<>c__DisplayClass29_0::<PlayAddCoinAnimation>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void PiggyBankRaidPopup.<>c__DisplayClass29_0::<PlayAddCoinAnimation>b__1(float x)), endValue:  val_3, duration:  1f);
    }
    private string GetCurrentProgressBarText()
    {
        decimal val_1 = this.eventHandler.PiggyBankCoins;
        decimal val_3 = this.eventHandler.econ.bankMaxCoins.Item[this.eventHandler.PiggyBankLevel];
        return val_3.flags.GetProgressBarText(currentAmount:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, bankMaxAmount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
    }
    private string GetProgressBarText(decimal currentAmount, decimal bankMaxAmount)
    {
        int val_16;
        int val_17;
        string val_19;
        val_16 = bankMaxAmount.lo;
        val_17 = currentAmount.lo;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = currentAmount.flags, hi = currentAmount.hi, lo = val_17, mid = currentAmount.mid}, d2:  new System.Decimal() {flags = bankMaxAmount.flags, hi = bankMaxAmount.hi, lo = val_16, mid = bankMaxAmount.mid})) == false)
        {
            goto label_3;
        }
        
        GameEcon val_2 = App.getGameEcon;
        val_16 = currentAmount.flags.ToString(format:  val_2.numberFormatInt);
        GameEcon val_4 = App.getGameEcon;
        string val_5 = bankMaxAmount.flags.ToString(format:  val_4.numberFormatInt);
        val_19 = "{0}/{1}";
        goto label_8;
        label_3:
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = currentAmount.flags, hi = currentAmount.hi, lo = val_17, mid = currentAmount.mid}, d2:  new System.Decimal() {flags = bankMaxAmount.flags, hi = bankMaxAmount.hi, lo = val_16, mid = bankMaxAmount.mid})) == false)
        {
            goto label_11;
        }
        
        GameEcon val_7 = App.getGameEcon;
        val_17 = bankMaxAmount.lo;
        val_16 = bankMaxAmount.flags.ToString(format:  val_7.numberFormatInt);
        decimal val_9 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = currentAmount.flags, hi = currentAmount.hi, lo = currentAmount.lo, mid = currentAmount.mid}, d2:  new System.Decimal() {flags = bankMaxAmount.flags, hi = bankMaxAmount.hi, lo = val_17, mid = bankMaxAmount.mid});
        GameEcon val_10 = App.getGameEcon;
        val_19 = "{0} + {1}";
        label_8:
        string val_12 = System.String.Format(format:  val_19, arg0:  val_16, arg1:  val_9.flags.ToString(format:  val_10.numberFormatInt));
        return (string)System.String.Format(format:  "{0}", arg0:  bankMaxAmount.flags.ToString(format:  val_13.numberFormatInt));
        label_11:
        GameEcon val_13 = App.getGameEcon;
        return (string)System.String.Format(format:  "{0}", arg0:  bankMaxAmount.flags.ToString(format:  val_13.numberFormatInt));
    }
    private string GetPurchasePriceString(decimal price)
    {
        return this.eventHandler.GetPiggyPurchaseModel().LocalPrice;
    }
    private void RefreshState()
    {
        if(this.eventHandler.progressData.isMaxPiggyPurchased != false)
        {
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        if(this.eventHandler.IsPiggyBankFull() != false)
        {
                this.InitializeFull();
            return;
        }
        
        this.InitializeInProgress();
    }
    private void InitializeInProgress()
    {
        this.inProgressGroup.SetActive(value:  true);
        this.fullGroup.SetActive(value:  false);
        this.progressBar.transform.localPosition = new UnityEngine.Vector3() {x = this.progressBarPositionInProgress};
        this.piggyImageTransform.localPosition = new UnityEngine.Vector3() {x = this.piggyImagePositionInProgress};
        this.piggyImageInProgress.SetActive(value:  true);
        this.piggyImageFull.SetActive(value:  false);
        this.piggyImageOverflow.SetActive(value:  false);
        string val_2 = Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false);
        decimal val_3 = this.eventHandler.PiggyBankCoins;
        decimal val_5 = this.eventHandler.econ.bankMaxCoins.Item[this.eventHandler.PiggyBankLevel];
        decimal val_6 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        float val_7 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        string val_8 = this.progressBar.GetProgressBarText(currentAmount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, bankMaxAmount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        this.ProgressBarCoinIcon.SetActive(value:  false);
        string val_11 = System.String.Format(format:  Localization.Localize(key:  "piggy_raid_level", defaultValue:  "Piggy level {0}/{1}", useSingularKey:  false), arg0:  this.eventHandler.PiggyBankLevel, arg1:  5);
        this.GenerateRaidHistory();
    }
    private void InitializeFull()
    {
        int val_27;
        var val_28;
        this.inProgressGroup.SetActive(value:  false);
        this.fullGroup.SetActive(value:  true);
        this.progressBar.transform.localPosition = new UnityEngine.Vector3() {x = this.progressBarPositionFull};
        this.piggyImageTransform.localPosition = new UnityEngine.Vector3() {x = this.piggyImagePositionFull};
        this.piggyImageInProgress.SetActive(value:  false);
        string val_2 = Localization.Localize(key:  "piggy_raid_full_upper", defaultValue:  "FULL PIGGY!", useSingularKey:  false);
        string val_3 = this.GetCurrentProgressBarText();
        decimal val_6 = this.eventHandler.econ.bankPriceTier.Item[this.eventHandler.PiggyBankLevel];
        string val_8 = System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "piggy_raid_open", defaultValue:  "OPEN PIGGY", useSingularKey:  false), arg1:  this.GetPurchasePriceString(price:  new System.Decimal() {flags = val_6.lo, hi = val_6.mid, lo = -915989072, mid = 268435458}));
        this.ProgressBarCoinIcon.SetActive(value:  true);
        decimal val_9 = this.eventHandler.GetPiggyBankOverflowAmount();
        val_27 = val_9.lo;
        val_28 = null;
        val_28 = null;
        bool val_10 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_27, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        if(val_10 != false)
        {
                decimal val_11 = this.eventHandler.GetPiggyBankOverflowAmount();
            if(this.discardButtonText != 0)
        {
                GameEcon val_14 = App.getGameEcon;
            string val_16 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "discard_upper", defaultValue:  "DISCARD", useSingularKey:  false), arg1:  val_11.flags.ToString(format:  val_14.numberFormatInt));
        }
        
            val_27 = this.discardButtonTextAmountOnly;
            if(val_27 != 0)
        {
                val_27 = this.discardButtonTextAmountOnly;
            GameEcon val_18 = App.getGameEcon;
            string val_19 = val_11.flags.ToString(format:  val_18.numberFormatInt);
        }
        
        }
        
        this.piggyImageFull.SetActive(value:  (~val_10) & 1);
        this.piggyImageOverflow.SetActive(value:  val_10);
        this.discardButton.gameObject.SetActive(value:  val_10);
        string val_26 = Localization.Localize(key:  (val_10 != true) ? "piggy_raid_overflow_body" : "piggy_raid_full_body", defaultValue:  (val_10 != true) ? "Piggy Bank is too full! Purchase now keep the overflowing coins." : "Open your piggy bank to claim the coins before you get raided!", useSingularKey:  false);
    }
    private void GenerateRaidHistory()
    {
        string val_3;
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        var val_5 = 4;
        var val_1 = val_5 - 4;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_5 = mem[typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32];
        val_5 = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32;
        val_3 = mem[typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 16];
        val_3 = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 16;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_5 = mem[typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32];
        val_5 = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_5 = mem[typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32];
        val_5 = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32;
        UnityEngine.Object.Instantiate<PiggyBankRaidHistoryItem>(original:  this.raidHistoryItemPrefab, parent:  this.raidHistoryParent).InitialiseMessage(senderName:  val_3, stoleAmount:  new System.Decimal() {flags = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 36, hi = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 36, lo = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 44, mid = typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 44}, avatarSprite:  this.avatarConfig.GetAvatarSpriteByID(id:  typeof(PiggyBankRaidProgress).__il2cppRuntimeField_38 + 16 + 32 + 32, portraitID:  0));
        val_5 = val_5 + 1;
        var val_4 = val_5 - 4;
    }
    private void OnOpenButtonClicked(bool connected)
    {
        null = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.DoPurchasePiggyBank();
    }
    private void OnCloseButtonClicked()
    {
        var val_5;
        if((MonoSingleton<PiggyBankRaidGameplayUIController>.Instance) != 0)
        {
                MonoSingleton<PiggyBankRaidGameplayUIController>.Instance.RefreshEventProgressButton();
        }
        
        val_5 = null;
        val_5 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.DiscardOverflowAmount();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPurchaseAttempt(bool isSuccess, decimal amount)
    {
        if(isSuccess == false)
        {
                return;
        }
        
        this.coinAnimation.OnCompleteCallback = new System.Action(object:  this, method:  System.Void PiggyBankRaidPopup::RefreshState());
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = -899777392, mid = 268435458}, d2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
        Player val_4 = App.Player;
        this.coinAnimation.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    public PiggyBankRaidPopup()
    {
        null = null;
        this.eventHandler = PiggyBankRaidEventHandler.<Instance>k__BackingField;
    }

}
