using UnityEngine;
public class LimitedTimeBundlePackDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text text_pack_title;
    private UnityEngine.UI.Text text_amount_coins;
    private UnityEngine.UI.Text text_amount_food;
    private UnityEngine.UI.Text text_amount_card;
    private UnityEngine.UI.Text text_current_price;
    private UnityEngine.UI.Text text_price_value;
    private UnityEngine.UI.Text text_gem_amount;
    private UnityEngine.UI.Text text_goldenCurrency_amount;
    private UnityEngine.UI.Text text_amount_dice;
    private UnityEngine.GameObject[] objs_tile_amounts;
    private UnityEngine.UI.Text[] texts_tile_amounts;
    private UnityEngine.UI.Text text_limited_purchase;
    private UGUINetworkedButton networked_button_purchase;
    private UnityEngine.GameObject obj_percent_more;
    private UnityEngine.UI.Text text_percent_more;
    private UnityEngine.GameObject obj_hot_border;
    private UnityEngine.GameObject obj_best_border;
    private UnityEngine.GameObject gem_group;
    private UnityEngine.GameObject dice_group;
    private PurchaseModel purchaseModel;
    
    // Methods
    protected virtual void HandleConnectionClick(bool result)
    {
        var val_22;
        var val_23;
        var val_24;
        decimal val_1 = this.purchaseModel.DiceRolls;
        val_22 = null;
        val_22 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_4;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_9;
        }
        
        label_4:
        val_23 = 1152921504893161472;
        val_24 = null;
        if(result == false)
        {
            goto label_10;
        }
        
        if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance) == 0)
        {
            goto label_15;
        }
        
        GameStoreUI val_6 = MonoSingleton<GameStoreUI>.Instance;
        val_23 = ???;
        goto typeof(GameStoreUI).__il2cppRuntimeField_1F0;
        label_10:
        if((MonoSingleton<GameStoreUI>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GameStoreUI>.Instance.ShowConnectionRequired();
        return;
        label_9:
        if((MonoSingleton<GameStoreUI>.Instance) == 0)
        {
            goto label_31;
        }
        
        MonoSingleton<GameStoreUI>.Instance.RefreshPackItemDisplays();
        return;
        label_15:
        bool val_20 = PurchaseProxy.Purchase(purchase:  this.purchaseModel);
        return;
        label_31:
        SLCWindow.CloseWindow(window:  MonoSingleton<WGWindowManager>.Instance, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Awake()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  this.networked_button_purchase.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  typeof(LimitedTimeBundlePackDisplay).__il2cppRuntimeField_178));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.networked_button_purchase.OnConnectionClick = val_2;
        return;
        label_3:
    }
    public void Setup(PurchaseModel purchase, PurchaseModel valueModel, System.Collections.Generic.Dictionary<string, object> bundlePack, int timesPurchased, bool isHot, bool isBest)
    {
        UnityEngine.UI.Text val_55;
        var val_56;
        this.purchaseModel = purchase;
        decimal val_1 = purchase.Credits;
        decimal val_2 = new System.Decimal(value:  231);
        decimal val_4 = purchase.Credits;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo})) != false)
        {
                string val_5 = val_4.flags.ToString(format:  "0,000");
        }
        else
        {
                string val_6 = val_4.flags.ToString();
        }
        
        string val_7 = purchase.LocalPrice;
        val_55 = this.text_price_value;
        string val_8 = valueModel.LocalPrice;
        if((bundlePack.ContainsKey(key:  "pets_food")) != false)
        {
                if(this.text_amount_food != 0)
        {
                decimal val_11 = purchase.PetsFood;
            string val_12 = val_11.flags.ToString();
        }
        
        }
        
        if((bundlePack.ContainsKey(key:  "pet_cards")) != false)
        {
                if(this.text_amount_card != 0)
        {
                decimal val_15 = purchase.PetCards;
            string val_16 = val_15.flags.ToString();
        }
        
        }
        
        if((this.text_gem_amount != 0) && ((bundlePack.ContainsKey(key:  "gems")) != false))
        {
                object val_19 = bundlePack.Item["gems"];
            if(this.gem_group != 0)
        {
                this.gem_group.SetActive(value:  true);
        }
        
            if(this.dice_group != 0)
        {
                this.dice_group.SetActive(value:  false);
        }
        
        }
        
        if((this.text_amount_dice != 0) && ((bundlePack.ContainsKey(key:  "dice_rolls")) != false))
        {
                object val_24 = bundlePack.Item["dice_rolls"];
            if(this.gem_group != 0)
        {
                this.gem_group.SetActive(value:  false);
        }
        
            if(this.dice_group != 0)
        {
                this.dice_group.SetActive(value:  true);
        }
        
        }
        
        if(this.text_goldenCurrency_amount != 0)
        {
                if((bundlePack.ContainsKey(key:  "golden_currency")) != false)
        {
                object val_29 = bundlePack.Item["golden_currency"];
        }
        
        }
        
        if(this.objs_tile_amounts == null)
        {
            goto label_56;
        }
        
        var val_58 = 4;
        label_71:
        if((val_58 - 4) >= this.objs_tile_amounts.Length)
        {
            goto label_56;
        }
        
        string val_32 = val_58 - 4.ToString();
        bool val_33 = bundlePack.ContainsKey(key:  val_32);
        val_55 = this.objs_tile_amounts[0];
        if(val_55 != 0)
        {
                this.objs_tile_amounts[0].SetActive(value:  val_33);
        }
        
        if(val_33 != false)
        {
                UnityEngine.UI.Text val_57 = this.texts_tile_amounts[0];
            object val_36 = bundlePack.Item[val_32];
        }
        
        val_58 = val_58 + 1;
        if(this.objs_tile_amounts != null)
        {
            goto label_71;
        }
        
        throw new NullReferenceException();
        label_56:
        object val_37 = bundlePack.Item["sb_pc"];
        if(null == 2147483647)
        {
            
        }
        else
        {
                val_55 = timesPurchased.ToString();
            string val_41 = System.String.Format(format:  "{0} {1}/{2}", arg0:  Localization.Localize(key:  "limited_purchase", defaultValue:  "Limited Purchase", useSingularKey:  false), arg1:  val_55, arg2:  bundlePack.Item["sb_pc"]);
        }
        
        this.obj_percent_more.SetActive(value:  isHot | isBest);
        string val_45 = bundlePack.Item["xtra"] + "%"("%");
        if(this.obj_hot_border != 0)
        {
                this.obj_hot_border.SetActive(value:  isHot);
        }
        
        if(this.obj_best_border != 0)
        {
                this.obj_best_border.SetActive(value:  isBest);
        }
        
        val_56 = null;
        val_56 = null;
        string val_55 = Localization.Localize(key:  LimitedTimeBundlesManager.BundleLocKeys.Item[bundlePack.Item["id"]], defaultValue:  LimitedTimeBundlesManager.BundleTitles.Item[bundlePack.Item["id"]].ToUpper(), useSingularKey:  false);
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = LimitedTimeBundlePackDisplay.<>c.<>9__23_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  LimitedTimeBundlePackDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LimitedTimeBundlePackDisplay.<>c::<ShowConnectionRequired>b__23_0());
            LimitedTimeBundlePackDisplay.<>c.<>9__23_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public LimitedTimeBundlePackDisplay()
    {
    
    }

}
