using UnityEngine;
public class TRVProgressiveIAPPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text coinText;
    private UnityEngine.UI.Text gemText;
    private UnityEngine.UI.Text priceText;
    private UnityEngine.UI.Text freeText;
    private UnityEngine.UI.Text valueText;
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.UI.Text nextTierText;
    private UnityEngine.UI.Image coinImage;
    private UnityEngine.UI.Image gemImage;
    private UnityEngine.GameObject gemGroup;
    private UnityEngine.GameObject maxValueGroup;
    private UnityEngine.Sprite coinLowSprite;
    private UnityEngine.Sprite coinMedSprite;
    private UnityEngine.Sprite coinMaxSprite;
    private UnityEngine.Sprite gemLowSprite;
    private UnityEngine.Sprite gemMedSprite;
    private UnityEngine.Sprite gemMaxSprite;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button purchaseButton;
    private CoinCurrencyCollectAnimationInstantiator coinAnimation;
    private GemsCollectAnimationInstantiator gemAnimation;
    private PurchaseModel currentModel;
    private bool supportsGems;
    
    // Methods
    private void Start()
    {
        this.SetupUI();
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void TRVProgressiveIAPPopup::UpdateTimerText());
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVProgressiveIAPPopup::Close()));
        this.purchaseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVProgressiveIAPPopup::OnClickPurchase()));
    }
    private void SetupUI()
    {
        var val_34;
        string val_35;
        UnityEngine.Sprite val_36;
        float val_37;
        UnityEngine.UI.Text val_38;
        var val_39;
        System.Func<System.Int32, System.Int32> val_41;
        string val_42;
        string val_43;
        this.supportsGems = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.SupportsGems();
        val_34 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.gemGroup)) != false)
        {
                this.gemGroup.SetActive(value:  this.supportsGems);
        }
        
        this.gemAnimation.gameObject.SetActive(value:  this.supportsGems);
        int val_5 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.GetCurrentTier(calculatedProgress:  TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56);
        val_35 = val_5;
        if(val_5 == 3)
        {
            goto label_11;
        }
        
        if(val_35 == 2)
        {
            goto label_12;
        }
        
        if(val_35 != 1)
        {
            goto label_13;
        }
        
        this.coinImage.sprite = this.coinLowSprite;
        val_36 = this.gemLowSprite;
        goto label_19;
        label_11:
        this.coinImage.sprite = this.coinMaxSprite;
        val_36 = this.gemMaxSprite;
        goto label_19;
        label_12:
        this.coinImage.sprite = this.coinMedSprite;
        val_36 = this.gemMedSprite;
        label_19:
        this.gemImage.sprite = val_36;
        goto label_22;
        label_13:
        val_36 = 0;
        UnityEngine.Debug.LogError(message:  "no tier pictures available?");
        label_22:
        this.currentModel = 0;
        PurchaseModel val_6 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.GetCurrentPurchaseModel(tierOverride:  0);
        this.currentModel = val_6;
        decimal val_7 = val_6.Credits;
        string val_9 = System.String.Format(format:  "x{0}", arg0:  val_7.flags.ToString());
        decimal val_10 = this.currentModel.Gems;
        string val_12 = System.String.Format(format:  "x{0}", arg0:  val_10.flags.ToString());
        string val_13 = this.currentModel.LocalPrice;
        val_37 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.GetCurrentJsonDictionary(tier:  0).getFloat(key:  "BonusMulti", defaultValue:  0f);
        float val_34 = 1f;
        val_34 = val_37 + val_34;
        val_34 = val_34 * this.currentModel.sale_price;
        float val_35 = -0.01f;
        val_35 = ((float)UnityEngine.Mathf.CeilToInt(f:  val_34)) + val_35;
        string val_17 = val_35.ToString(format:  "$0.00");
        float val_18 = val_37 * 100f;
        string val_21 = System.String.Format(format:  "{0}%", arg0:  (int)(val_18 == Infinityf) ? (-(double)val_18) : ((double)val_18).ToString());
        if(val_35 == 3)
        {
                if((UnityEngine.Object.op_Implicit(exists:  this.maxValueGroup)) != false)
        {
                this.maxValueGroup.SetActive(value:  true);
        }
        
            this.nextTierText.gameObject.SetActive(value:  false);
            val_38 = this.nextTierText;
            string val_24 = Localization.Localize(key:  "get_more_popup_body_max", defaultValue:  "Maximum value reached!", useSingularKey:  false);
            return;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.maxValueGroup)) != false)
        {
                this.maxValueGroup.SetActive(value:  false);
        }
        
        float val_27 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.GetCurrentJsonDictionary(tier:  3).getFloat(key:  "BonusMulti", defaultValue:  0f);
        val_37 = val_27;
        val_27 = val_37 * 100f;
        val_39 = null;
        val_39 = null;
        val_41 = TRVProgressiveIAPPopup.<>c.<>9__24_0;
        if(val_41 == null)
        {
                System.Func<System.Int32, System.Int32> val_29 = null;
            val_41 = val_29;
            val_29 = new System.Func<System.Int32, System.Int32>(object:  TRVProgressiveIAPPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVProgressiveIAPPopup.<>c::<SetupUI>b__24_0(int x));
            TRVProgressiveIAPPopup.<>c.<>9__24_0 = val_41;
        }
        
        int val_36 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56;
        val_36 = (System.Linq.Enumerable.Sum<System.Int32>(source:  TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 48, selector:  val_29)) - val_36;
        this.nextTierText.gameObject.SetActive(value:  true);
        val_38 = this.nextTierText;
        if(val_36 > 1)
        {
                val_42 = "get_more_popup_body";
            val_43 = "Get up to {0}% by finishing {1} levels!";
        }
        else
        {
                val_42 = "get_more_popup_body_singular";
            val_43 = "Get up to {0}% by finishing {1} level!";
        }
        
        val_34 = 1152921504619999232;
        val_35 = Localization.Localize(key:  val_42, defaultValue:  val_43, useSingularKey:  false);
        string val_33 = System.String.Format(format:  val_35, arg0:  UnityEngine.Mathf.FloorToInt(f:  val_27), arg1:  val_36);
    }
    private void SetBaseText()
    {
    
    }
    private void OnClickPurchase()
    {
        var val_4;
        TrackerPurchasePoints val_5;
        TRVProgressiveIAPHandler.BONUS_MULTIPLIER.__unknownFiledOffset_50 = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVProgressiveIAPPopup::OnPurchaseResult(bool purchased));
        this.purchaseButton.interactable = false;
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 1)
        {
                val_4 = null;
            val_5 = 118;
        }
        else
        {
                val_4 = null;
            if((val_2.<metaGameBehavior>k__BackingField.IsDuringLevelComplete()) != false)
        {
                val_5 = 119;
        }
        else
        {
                val_5 = 120;
        }
        
        }
        
        TRVProgressiveIAPHandler.purchasePoint = val_5;
        val_4 = null;
        TRVProgressiveIAPHandler.BONUS_MULTIPLIER.TryPurchase();
    }
    private void OnPurchaseResult(bool purchased)
    {
        int val_24;
        var val_25;
        System.Func<System.Boolean> val_27;
        var val_28;
        if(purchased != false)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void TRVProgressiveIAPPopup::Close());
            Player val_2 = App.Player;
            decimal val_3 = this.currentModel.Credits;
            decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            Player val_6 = App.Player;
            this.coinAnimation.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}), toValue:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = val_3.lo, mid = val_3.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
            if(this.supportsGems == false)
        {
                return;
        }
        
            Player val_7 = App.Player;
            decimal val_8 = System.Decimal.op_Implicit(value:  val_7._gems);
            decimal val_9 = this.currentModel.Gems;
            decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            Player val_12 = App.Player;
            decimal val_13 = System.Decimal.op_Implicit(value:  val_12._gems);
            this.gemAnimation.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}), toValue:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
            return;
        }
        
        GameBehavior val_14 = App.getBehavior;
        bool[] val_18 = new bool[2];
        val_18[0] = true;
        string[] val_19 = new string[2];
        val_24 = val_19.Length;
        val_19[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_24 = val_19.Length;
        val_19[1] = "NO";
        System.Func<System.Boolean>[] val_21 = new System.Func<System.Boolean>[2];
        val_25 = null;
        val_25 = null;
        val_27 = TRVProgressiveIAPPopup.<>c.<>9__27_0;
        if(val_27 == null)
        {
                System.Func<System.Boolean> val_22 = null;
            val_27 = val_22;
            val_22 = new System.Func<System.Boolean>(object:  TRVProgressiveIAPPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVProgressiveIAPPopup.<>c::<OnPurchaseResult>b__27_0());
            TRVProgressiveIAPPopup.<>c.<>9__27_0 = val_27;
        }
        
        val_21[0] = val_27;
        val_28 = null;
        val_28 = null;
        val_14.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_18, buttonTexts:  val_19, showClose:  false, buttonCallbacks:  val_21, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        this.purchaseButton.interactable = true;
    }
    private void UpdateTimerText()
    {
        if(TRVProgressiveIAPHandler.BONUS_MULTIPLIER == null)
        {
                return;
        }
        
        this = this.timeRemainingText;
        object[] val_1 = new object[4];
        val_1[0] = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.Days.ToString(format:  "0");
        val_1[1] = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.Hours.ToString(format:  "0");
        val_1[2] = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.Minutes.ToString(format:  "0");
        val_1[3] = Localization.Localize(key:  "deal_ends_in", defaultValue:  "Deal ends in", useSingularKey:  false);
        string val_9 = System.String.Format(format:  "{3} {0}d {1}h {2}m", args:  val_1);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private bool IsDuringLevelComplete()
    {
        var val_8;
        UnityEngine.Object val_9;
        var val_10;
        val_8 = null;
        val_8 = null;
        if(App.game != 17)
        {
            goto label_6;
        }
        
        val_9 = MonoSingleton<WGWindowManager>.Instance;
        if(val_9 == 0)
        {
            goto label_19;
        }
        
        return MonoSingleton<WGWindowManager>.Instance.ShowingWindow<TRVLevelComplete>();
        label_6:
        val_9 = MainController.instance;
        if(val_9 != 0)
        {
                MainController val_6 = MainController.instance;
            var val_7 = (val_6.isGameComplete == true) ? 1 : 0;
            return (bool)val_10;
        }
        
        label_19:
        val_10 = 0;
        return (bool)val_10;
    }
    public TRVProgressiveIAPPopup()
    {
        this.supportsGems = true;
    }

}
