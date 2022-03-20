using UnityEngine;
public class LimitedTimeBundlesPopup : MonoBehaviour
{
    // Fields
    private LimitedTimeBundlesHeader bundles_header;
    private UnityEngine.Transform xfm_pack_container;
    private LimitedTimeBundlesPackDisplayManager pack_display_manager;
    private UnityEngine.UI.Button button_close;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private WADPetFoodAnimationInstantiator foodAnimControl;
    private CurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private CurrencyCollectAnimationInstantiator gemCurrencyAnimControl;
    private DiceRollAnimationInstantiator diceAnimControl;
    public System.Action OnAnimationsComplete;
    
    // Methods
    private void Start()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void LimitedTimeBundlesPopup::PurchasesHandler_OnPurchaseCompleted(PurchaseModel obj)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void LimitedTimeBundlesPopup::PurchasesHandler_OnPurchaseFailure(PurchaseModel obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnCloseClicked()));
        this.pack_display_manager.CreatePackItems(packItemContainer:  this.xfm_pack_container, popupContainer:  this);
        LimitedTimeBundlesStatus val_7 = MonoSingleton<LimitedTimeBundlesManager>.Instance.Status;
        val_7.LevelsSincePopupShown = 0;
        LimitedTimeBundlesStatus val_9 = MonoSingleton<LimitedTimeBundlesManager>.Instance.Status;
        int val_17 = val_9.TimesPopupShown;
        val_17 = val_17 + 1;
        val_9.TimesPopupShown = val_17;
        LimitedTimeBundlesStatus val_11 = MonoSingleton<LimitedTimeBundlesManager>.Instance.Status;
        System.DateTime val_16 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetCurrentOfferEndTime();
        this.bundles_header.Setup(freeAmount:  MonoSingleton<LimitedTimeBundlesManager>.Instance.GetHighestExtraDisplay().ToString(), endTime:  new System.DateTime() {dateData = val_16.dateData});
        return;
        label_6:
    }
    private void OnEnable()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = 75;
    }
    private void OnDestroy()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void LimitedTimeBundlesPopup::PurchasesHandler_OnPurchaseCompleted(PurchaseModel obj)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseFailure, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void LimitedTimeBundlesPopup::PurchasesHandler_OnPurchaseFailure(PurchaseModel obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        return;
        label_6:
    }
    private void PurchasesHandler_OnPurchaseCompleted(PurchaseModel obj)
    {
        if((obj.ContainsInstruction(instruction:  2)) != false)
        {
                return;
        }
        
        this.DisplayPurchaseSuccess(purchase:  obj);
    }
    private void PurchasesHandler_OnPurchaseFailure(PurchaseModel obj)
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        if((obj.ContainsInstruction(instruction:  2)) != false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        bool[] val_6 = new bool[2];
        val_6[0] = true;
        string[] val_7 = new string[2];
        val_12 = val_7.Length;
        val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_7.Length;
        val_7[1] = "NO";
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = LimitedTimeBundlesPopup.<>c.<>9__14_0;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_10 = null;
            val_15 = val_10;
            val_10 = new System.Func<System.Boolean>(object:  LimitedTimeBundlesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LimitedTimeBundlesPopup.<>c::<PurchasesHandler_OnPurchaseFailure>b__14_0());
            LimitedTimeBundlesPopup.<>c.<>9__14_0 = val_15;
        }
        
        val_9[0] = val_15;
        val_16 = null;
        val_16 = null;
        val_2.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void DisplayPurchaseSuccess(PurchaseModel purchase)
    {
        int val_73;
        var val_74;
        var val_75;
        var val_76;
        var val_77;
        var val_78;
        var val_79;
        System.Action val_80;
        int val_81;
        int val_82;
        var val_83;
        int val_84;
        float val_85;
        int val_86;
        int val_87;
        int val_88;
        System.Action val_89;
        System.Action val_90;
        var val_91;
        int val_92;
        int val_93;
        int val_94;
        int val_95;
        System.Action val_96;
        var val_97;
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        decimal val_3 = purchase.Credits;
        val_74 = null;
        val_74 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_5 = purchase.Gems;
            val_76 = null;
            val_76 = null;
            float val_7 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? 1.5f : 1f;
            decimal val_8 = purchase.GoldenCurrency;
            val_77 = null;
            val_77 = null;
            float val_72 = 0.5f;
            val_72 = val_7 + val_72;
            val_7 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? (val_72) : (val_7);
            Player val_10 = App.Player;
            decimal val_11 = purchase.Credits;
            decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
            Player val_13 = App.Player;
            this.AnimateCoins(fromAmount:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, toAmount:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits}, actionOnComplete:  null);
            System.Action val_14 = null;
            val_75 = 0;
            val_14 = new System.Action(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnAnimFinished());
            UnityEngine.Coroutine val_16 = this.StartCoroutine(routine:  val_14.CollectCoinsDelayComplete(waitTime:  val_7, onCompleteAction:  val_14));
            val_78 = 1;
        }
        else
        {
                val_78 = 0;
        }
        
        decimal val_17 = purchase.PetsFood;
        val_79 = null;
        val_79 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                if(val_78 != 0)
        {
                Player val_19 = App.Player;
            decimal val_20 = purchase.PetsFood;
            Player val_22 = App.Player;
            val_81 = val_22._food;
            val_82 = val_19._food - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid}));
            val_80 = 0;
        }
        else
        {
                Player val_23 = App.Player;
            decimal val_24 = purchase.PetsFood;
            Player val_26 = App.Player;
            System.Action val_27 = new System.Action(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnAnimFinished());
            val_82 = val_23._food - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid}));
            val_81 = val_26._food;
            val_80 = val_27;
        }
        
            this.AnimateFood(fromAmount:  val_82, toAmount:  val_81, actionOnComplete:  val_27);
            val_78 = 1;
        }
        
        decimal val_28 = purchase.Gems;
        val_83 = null;
        val_83 = null;
        val_85 = 0f;
        if(((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_28.flags, hi = val_28.hi, lo = val_28.lo, mid = val_28.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false) && (this.gemCurrencyAnimControl != 0))
        {
                if(val_78 != 0)
        {
                Player val_31 = App.Player;
            decimal val_32 = purchase.Gems;
            int val_33 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_32.flags, hi = val_32.hi, lo = val_32.lo, mid = val_32.mid});
            val_33 = val_31._gems - val_33;
            decimal val_34 = System.Decimal.op_Implicit(value:  val_33);
            Player val_35 = App.Player;
            decimal val_36 = System.Decimal.op_Implicit(value:  val_35._gems);
            val_85 = 0.5f;
            val_84 = val_36.flags;
            val_86 = val_36.lo;
            val_87 = val_34.flags;
            val_88 = val_34.lo;
            val_89 = 0;
        }
        else
        {
                Player val_37 = App.Player;
            decimal val_38 = purchase.Gems;
            int val_39 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_38.flags, hi = val_38.hi, lo = val_38.lo, mid = val_38.mid});
            val_39 = val_37._gems - val_39;
            decimal val_40 = System.Decimal.op_Implicit(value:  val_39);
            Player val_41 = App.Player;
            decimal val_42 = System.Decimal.op_Implicit(value:  val_41._gems);
            System.Action val_43 = null;
            val_90 = val_43;
            val_43 = new System.Action(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnAnimFinished());
            val_85 = 0.5f;
            val_87 = val_40.flags;
            val_88 = val_40.lo;
            val_84 = val_42.flags;
            val_86 = val_42.lo;
            val_89 = val_90;
        }
        
            this.AnimateGems(fromAmount:  new System.Decimal() {flags = val_87, hi = val_40.hi, lo = val_88, mid = val_40.mid}, toAmount:  new System.Decimal() {flags = val_84, hi = val_42.hi, lo = val_86, mid = val_42.mid}, delay:  val_85, actionOnComplete:  val_43);
            val_78 = 1;
        }
        
        decimal val_44 = purchase.GoldenCurrency;
        val_91 = null;
        val_91 = null;
        if(((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_44.flags, hi = val_44.hi, lo = val_44.lo, mid = val_44.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false) && (this.goldenCurrencyAnimControl != 0))
        {
                val_85 = val_85 + 0.5f;
            if(val_78 != 0)
        {
                Player val_47 = App.Player;
            decimal val_48 = purchase.GoldenCurrency;
            int val_49 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_48.flags, hi = val_48.hi, lo = val_48.lo, mid = val_48.mid});
            val_49 = val_47._stars - val_49;
            decimal val_50 = System.Decimal.op_Implicit(value:  val_49);
            Player val_51 = App.Player;
            decimal val_52 = System.Decimal.op_Implicit(value:  val_51._stars);
            val_92 = val_52.flags;
            val_93 = val_52.lo;
            val_94 = val_50.flags;
            val_95 = val_50.lo;
            val_96 = 0;
        }
        else
        {
                Player val_53 = App.Player;
            decimal val_54 = purchase.GoldenCurrency;
            int val_55 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_54.flags, hi = val_54.hi, lo = val_54.lo, mid = val_54.mid});
            val_55 = val_53._stars - val_55;
            decimal val_56 = System.Decimal.op_Implicit(value:  val_55);
            Player val_57 = App.Player;
            decimal val_58 = System.Decimal.op_Implicit(value:  val_57._stars);
            System.Action val_59 = null;
            val_90 = val_59;
            val_59 = new System.Action(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnAnimFinished());
            val_94 = val_56.flags;
            val_95 = val_56.lo;
            val_92 = val_58.flags;
            val_93 = val_58.lo;
            val_96 = val_90;
        }
        
            this.AnimateGoldenCurrency(fromAmount:  new System.Decimal() {flags = val_94, hi = val_56.hi, lo = val_95, mid = val_56.mid}, toAmount:  new System.Decimal() {flags = val_92, hi = val_58.hi, lo = val_93, mid = val_58.mid}, delay:  val_85, actionOnComplete:  val_59);
            val_78 = 1;
        }
        
        decimal val_60 = purchase.DiceRolls;
        val_73 = val_60.flags;
        val_97 = null;
        val_97 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_73, hi = val_60.hi, lo = val_60.lo, mid = val_60.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
                return;
        }
        
        val_73 = this.diceAnimControl;
        if(val_73 == 0)
        {
                return;
        }
        
        val_85 = val_85 + 0.5f;
        int val_63 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        decimal val_64 = purchase.DiceRolls;
        if(val_78 != 0)
        {
                int val_65 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_64.flags, hi = val_64.hi, lo = val_64.lo, mid = val_64.mid});
            val_65 = val_63 - val_65;
            decimal val_66 = System.Decimal.op_Implicit(value:  val_65);
            decimal val_67 = System.Decimal.op_Implicit(value:  val_63);
            this.AnimateDice(fromAmount:  new System.Decimal() {flags = val_66.flags, hi = val_66.hi, lo = val_66.lo, mid = val_66.mid}, toAmount:  new System.Decimal() {flags = val_67.flags, hi = val_67.hi, lo = val_67.lo, mid = val_67.mid}, delay:  val_85, actionOnComplete:  0);
            return;
        }
        
        int val_68 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_64.flags, hi = val_64.hi, lo = val_64.lo, mid = val_64.mid});
        val_68 = val_63 - val_68;
        decimal val_69 = System.Decimal.op_Implicit(value:  val_68);
        decimal val_70 = System.Decimal.op_Implicit(value:  val_63);
        this.AnimateGoldenCurrency(fromAmount:  new System.Decimal() {flags = val_69.flags, hi = val_69.hi, lo = val_69.lo, mid = val_69.mid}, toAmount:  new System.Decimal() {flags = val_70.flags, hi = val_70.hi, lo = val_70.lo, mid = val_70.mid}, delay:  val_85, actionOnComplete:  new System.Action(object:  this, method:  System.Void LimitedTimeBundlesPopup::OnAnimFinished()));
    }
    private void OnAnimFinished()
    {
        if(this.OnAnimationsComplete != null)
        {
                this.OnAnimationsComplete.Invoke();
        }
        
        this.OnAnimationsComplete = 0;
    }
    private void AnimateCoins(decimal fromAmount, decimal toAmount, System.Action actionOnComplete)
    {
        this.coinsAnimControl.OnCompleteCallback = 0;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}, toValue:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void AnimateFood(int fromAmount, int toAmount, System.Action actionOnComplete)
    {
        mem2[0] = actionOnComplete;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartFoodAnim(fromAmount:  fromAmount, toAmount:  toAmount));
    }
    private void AnimateGems(decimal fromAmount, decimal toAmount, float delay, System.Action actionOnComplete)
    {
        this.gemCurrencyAnimControl.OnCompleteCallback = actionOnComplete;
        int val_2 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid});
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  val_2.PlayCollectAnimWithDelay(anim:  this.gemCurrencyAnimControl, fromAmount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}), toAmount:  val_2, delay:  delay));
    }
    private void AnimateGoldenCurrency(decimal fromAmount, decimal toAmount, float delay, System.Action actionOnComplete)
    {
        this.goldenCurrencyAnimControl.OnCompleteCallback = actionOnComplete;
        int val_2 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid});
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  val_2.PlayCollectAnimWithDelay(anim:  this.goldenCurrencyAnimControl, fromAmount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}), toAmount:  val_2, delay:  delay));
    }
    private void AnimateDice(decimal fromAmount, decimal toAmount, float delay, System.Action actionOnComplete)
    {
        mem2[0] = actionOnComplete;
        int val_2 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid});
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  val_2.PlayCollectAnimWithDelay(anim:  this.diceAnimControl, fromAmount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}), toAmount:  val_2, delay:  delay));
    }
    private System.Collections.IEnumerator StartFoodAnim(int fromAmount, int toAmount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .fromAmount = fromAmount;
        .toAmount = toAmount;
        return (System.Collections.IEnumerator)new LimitedTimeBundlesPopup.<StartFoodAnim>d__22();
    }
    private System.Collections.IEnumerator CollectCoinsDelayComplete(float waitTime, System.Action onCompleteAction)
    {
        .<>1__state = 0;
        .waitTime = waitTime;
        .onCompleteAction = onCompleteAction;
        return (System.Collections.IEnumerator)new LimitedTimeBundlesPopup.<CollectCoinsDelayComplete>d__23();
    }
    private System.Collections.IEnumerator PlayCollectAnimWithDelay(CurrencyCollectAnimationInstantiator anim, int fromAmount, int toAmount, float delay)
    {
        .<>1__state = 0;
        .anim = anim;
        .fromAmount = fromAmount;
        .toAmount = toAmount;
        .delay = delay;
        return (System.Collections.IEnumerator)new LimitedTimeBundlesPopup.<PlayCollectAnimWithDelay>d__24();
    }
    private void OnCloseClicked()
    {
        if(this.OnAnimationsComplete != null)
        {
                this.OnAnimationsComplete.Invoke();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public LimitedTimeBundlesPopup()
    {
    
    }

}
