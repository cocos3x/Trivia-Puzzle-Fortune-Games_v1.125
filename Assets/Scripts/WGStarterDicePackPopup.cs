using UnityEngine;
public class WGStarterDicePackPopup : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton purchaseButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text timeRemaining;
    private UnityEngine.UI.Text text_coins_amount;
    private UnityEngine.UI.Text text_dice_amount;
    private UnityEngine.UI.Text text_purchase_price;
    private UnityEngine.UI.Text text_dollar_value;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private DiceRollAnimationInstantiator diceAnim;
    private PurchaseModel starterPack;
    private FrameSkipper frameSkipper;
    
    // Methods
    private void Awake()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  this.purchaseButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGStarterDicePackPopup::OnPurchaseClicked(bool success)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.purchaseButton.OnConnectionClick = val_2;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGStarterDicePackPopup::Close()));
        return;
        label_3:
    }
    private void OnEnable()
    {
        PurchaseModel val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetStarterDicePack();
        this.starterPack = val_1;
        decimal val_2 = val_1.Credits;
        string val_3 = val_2.flags.ToString();
        decimal val_4 = this.starterPack.DiceRolls;
        string val_5 = val_4.flags.ToString();
        string val_6 = this.starterPack.LocalPrice;
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_8.updateLogic = new System.Action(object:  this, method:  System.Void WGStarterDicePackPopup::UpdateTimeLeft());
    }
    private void OnPurchaseClicked(bool success)
    {
        string val_13;
        int val_14;
        var val_15;
        System.Func<System.Boolean> val_17;
        var val_18;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if(success != false)
        {
                this.purchaseButton.interactable = false;
            SnakesAndLaddersEventHandler.<Instance>k__BackingField.AddPurchaseCompleteListener(purchaseCompleteAction:  new System.Action<System.Boolean, PurchaseModel>(object:  this, method:  System.Void WGStarterDicePackPopup::OnPurchaseComplete(bool success, PurchaseModel purchase)));
            SnakesAndLaddersEventHandler.<Instance>k__BackingField.TryPurchase(purchase:  this.starterPack);
            return;
        }
        
            val_13 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
            bool[] val_7 = new bool[2];
            val_7[0] = true;
            string[] val_8 = new string[2];
            val_14 = val_8.Length;
            val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_14 = val_8.Length;
            val_8[1] = "NULL";
            System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
            val_15 = null;
            val_15 = null;
            val_17 = WGStarterDicePackPopup.<>c.<>9__13_0;
            if(val_17 == null)
        {
                System.Func<System.Boolean> val_11 = null;
            val_17 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  WGStarterDicePackPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGStarterDicePackPopup.<>c::<OnPurchaseClicked>b__13_0());
            WGStarterDicePackPopup.<>c.<>9__13_0 = val_17;
        }
        
            val_10[0] = val_17;
            val_18 = null;
            val_18 = null;
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  val_13, messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPurchaseComplete(bool success, PurchaseModel purchase)
    {
        if((System.String.op_Inequality(a:  purchase.id, b:  this.starterPack.id)) != false)
        {
                return;
        }
        
        if(success != false)
        {
                this.OnPurchaseSuccess();
            return;
        }
        
        this.purchaseButton.interactable = true;
    }
    private void OnPurchaseSuccess()
    {
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.MarkStarterPackPurchased();
        System.Delegate val_2 = System.Delegate.Combine(a:  static_value_02807000, b:  new System.Action(object:  this, method:  System.Void WGStarterDicePackPopup::<OnPurchaseSuccess>b__15_0()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        mem2[0] = val_2;
        int val_3 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        decimal val_4 = this.starterPack.DiceRolls;
        decimal val_6 = System.Decimal.op_Implicit(value:  val_3);
        this.diceAnim.Play(fromValue:  val_3 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})), toValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        System.Delegate val_9 = System.Delegate.Combine(a:  this.coinAnim.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void WGStarterDicePackPopup::Close()));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        this.coinAnim.OnCompleteCallback = val_9;
        return;
        label_14:
    }
    private void UpdateTimeLeft()
    {
        System.TimeSpan val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetStarterPackTimeLeft();
        string val_3 = Localization.Localize(key:  "limited_time_upper", defaultValue:  "LIMITED TIME", useSingularKey:  false);
        if(val_1._ticks.TotalSeconds > 0f)
        {
                this = val_1._ticks.Minutes.ToString(format:  "00");
            string val_8 = System.String.Format(format:  "{0}: {1}:{2}", arg0:  val_3, arg1:  this, arg2:  val_1._ticks.Seconds.ToString(format:  "00"));
            return;
        }
        
        string val_9 = System.String.Format(format:  "{0}: {1}", arg0:  val_3, arg1:  "00:00");
        this.frameSkipper.updateLogic = 0;
        this.frameSkipper.enabled = false;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGStarterDicePackPopup()
    {
    
    }
    private void <OnPurchaseSuccess>b__15_0()
    {
        Player val_1 = App.Player;
        decimal val_2 = this.starterPack.Credits;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        this.coinAnim.Set(instantValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_4 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }

}
