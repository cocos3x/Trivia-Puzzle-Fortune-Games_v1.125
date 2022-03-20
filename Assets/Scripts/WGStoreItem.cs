using UnityEngine;
public class WGStoreItem : MyButton
{
    // Fields
    protected UnityEngine.UI.Text coinsAmount;
    protected UnityEngine.UI.VerticalLayoutGroup amountGroupLayout;
    protected int amountGroupLayout_paddingLeft;
    protected int amountGroupLayout_paddingBottom;
    protected float amountGroupLayout_spacing;
    protected UnityEngine.UI.Text bonusAmount;
    protected UnityEngine.GameObject bonusGroup;
    protected UnityEngine.UI.Text price;
    protected UnityEngine.UI.Image coinsImg;
    protected bool setCoinNativeSize;
    protected UnityEngine.Sprite[] coinLevelSprites;
    protected UnityEngine.GameObject mostPopular;
    protected UnityEngine.GameObject bestValue;
    protected UnityEngine.GameObject noAdsIcon;
    protected UGUINetworkedButton networkedButton;
    protected UnityEngine.Sprite altBuyButtonSprite;
    protected UnityEngine.UI.Image buyButtonBaseImage;
    protected UnityEngine.UI.Image buyButtonBaseImageOverlay;
    protected UnityEngine.GameObject bonusRewardGroup;
    protected UnityEngine.UI.Text bonusRewardText;
    protected UnityEngine.Sprite noAdsForeverSprite;
    protected PurchaseModel purchasePack;
    protected IStoreUI storeUIView;
    
    // Properties
    public string PackID { get; }
    
    // Methods
    public string get_PackID()
    {
        return (string)(this.purchasePack == 0) ? "unknown" : this.purchasePack.id;
    }
    public virtual void Awake()
    {
        UGUINetworkedButton val_6;
        if(this.networkedButton != 0)
        {
            goto label_3;
        }
        
        UGUINetworkedButton val_2 = this.GetComponent<UGUINetworkedButton>();
        val_6 = val_2;
        this.networkedButton = val_2;
        if(val_6 != null)
        {
            goto label_4;
        }
        
        label_3:
        val_6 = this.networkedButton;
        label_4:
        System.Delegate val_4 = System.Delegate.Combine(a:  this.networkedButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  typeof(WGStoreItem).__il2cppRuntimeField_1B8));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        this.networkedButton.OnConnectionClick = val_4;
        if(this.noAdsIcon == 0)
        {
                return;
        }
        
        this.noAdsIcon.SetActive(value:  false);
        return;
        label_8:
    }
    public virtual void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        UnityEngine.Sprite val_69;
        var val_70;
        float val_71;
        var val_72;
        var val_74;
        var val_75;
        UnityEngine.UI.Text val_76;
        var val_77;
        UnityEngine.GameObject val_78;
        var val_80;
        val_69 = totalPackItems;
        val_70 = packIndex;
        this.purchasePack = pack;
        this.storeUIView = storeUI;
        if(this.coinsImg != 0)
        {
                this.coinsImg.sprite = 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.coinsAmount)) != false)
        {
                this.coinsAmount.alignment = 4;
            if((UnityEngine.Object.op_Implicit(exists:  this.amountGroupLayout)) != false)
        {
                this.amountGroupLayout.spacing = -20f;
        }
        
            decimal val_4 = pack.Credits;
            GameEcon val_5 = App.getGameEcon;
            string val_6 = val_4.flags.ToString(format:  val_5.numberFormatInt);
        }
        
        val_71 = pack.sale_price;
        val_72 = 1152921504884269056;
        var val_7 = (val_71 > 99.99f) ? 2 : (0 + 1);
        GameBehavior val_8 = App.getBehavior;
        if((UnityEngine.Object.op_Implicit(exists:  this.bonusGroup)) == false)
        {
            goto label_26;
        }
        
        UnityEngine.GameObject val_10 = this.bonusGroup.gameObject;
        val_74 = null;
        val_74 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_8.<gameplayBehavior>k__BackingField, hi = val_8.<gameplayBehavior>k__BackingField, lo = pack, mid = pack}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_30;
        }
        
        GameBehavior val_12 = App.getBehavior;
        val_75 = (~(val_12.<metaGameBehavior>k__BackingField)) & 1;
        if(val_10 != null)
        {
            goto label_35;
        }
        
        label_30:
        val_75 = 0;
        label_35:
        val_10.SetActive(value:  false);
        label_26:
        val_76 = this.bonusAmount;
        if((UnityEngine.Object.op_Implicit(exists:  val_76)) != false)
        {
                GameBehavior val_14 = App.getBehavior;
            if(((val_14.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                val_77 = null;
            val_77 = null;
            PurchaseModel val_68 = pack;
            val_68 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_8.<gameplayBehavior>k__BackingField, hi = val_8.<gameplayBehavior>k__BackingField, lo = val_68, mid = val_68}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
            this.bonusAmount.gameObject.SetActive(value:  val_68);
            val_76 = this.bonusAmount;
            GameBehavior val_17 = App.getBehavior;
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bonusRewardGroup)) != false)
        {
                GameBehavior val_19 = App.getBehavior;
            if(((val_19.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_76 = 1152921504889913344;
            if((DefaultHandler<WGBonusRewardsHandler>.Instance) != 0)
        {
                this.coinsAmount.alignment = 1;
            val_71 = -35f;
            this.amountGroupLayout.spacing = val_71;
            this.bonusRewardGroup.gameObject.SetActive(value:  true);
            GameEcon val_25 = App.getGameEcon;
            string val_26 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetPointsForPurchase(pack:  pack).ToString(format:  val_25.numberFormatInt);
            decimal val_28 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetBonusCoins(pack:  pack);
            val_76 = val_28.lo;
            decimal val_29 = pack.Credits;
            decimal val_30 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_29.flags, hi = val_29.hi, lo = val_29.lo, mid = val_29.mid}, d2:  new System.Decimal() {flags = val_28.flags, hi = val_28.hi, lo = val_76, mid = val_28.mid});
            GameEcon val_31 = App.getGameEcon;
            string val_32 = val_30.flags.ToString(format:  val_31.numberFormatInt);
            val_70 = val_70;
            val_69 = val_69;
            val_72 = 1152921504884269056;
        }
        
        }
        
        }
        
        val_78 = this.noAdsIcon;
        if((UnityEngine.Object.op_Implicit(exists:  val_78)) != false)
        {
                this.noAdsIcon.SetActive(value:  false);
        }
        
        if((pack.id.Contains(value:  "removeAds")) == false)
        {
            goto label_141;
        }
        
        GameBehavior val_35 = App.getBehavior;
        if(((val_35.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                GameEcon val_36 = App.getGameEcon;
            val_71 = val_36.NoAdsPackagePriceToUse;
            if((pack.sale_price.Equals(obj:  val_71)) != false)
        {
                if(App.Player.RemovedAds == false)
        {
            goto label_102;
        }
        
        }
        
        }
        
        this.gameObject.SetActive(value:  false);
        return;
        label_102:
        if((UnityEngine.Object.op_Implicit(exists:  this.bonusRewardGroup)) != false)
        {
                this.bonusRewardGroup.gameObject.SetActive(value:  false);
        }
        
        bool val_43 = UnityEngine.Object.op_Inequality(x:  this.amountGroupLayout, y:  0);
        if(val_43 != false)
        {
                val_43.left = this.amountGroupLayout_paddingLeft;
            val_43.bottom = this.amountGroupLayout_paddingBottom;
            val_71 = this.amountGroupLayout_spacing;
            this.amountGroupLayout.spacing = val_71;
        }
        
        if(this.coinsAmount != 0)
        {
                UnityEngine.Vector2 val_46 = new UnityEngine.Vector2(x:  340f, y:  100f);
            val_71 = val_46.x;
            this.coinsAmount.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_71, y = val_46.y};
            this.coinsAmount.resizeTextMaxSize = 90;
        }
        
        if(this.bonusAmount != 0)
        {
                this.bonusAmount.gameObject.SetActive(value:  true);
            this.bonusAmount.fontSize = 26;
            string val_49 = Localization.Localize(key:  "no_ads_forever_upper", defaultValue:  "NO ADS FOREVER!", useSingularKey:  false);
        }
        
        if(this.bonusGroup != 0)
        {
                this.bonusGroup.SetActive(value:  true);
        }
        
        if(this.noAdsIcon != 0)
        {
                this.noAdsIcon.SetActive(value:  true);
        }
        
        if(this.noAdsForeverSprite != 0)
        {
                this.coinsImg.sprite = this.noAdsForeverSprite;
        }
        
        label_141:
        if((UnityEngine.Object.op_Implicit(exists:  this.price)) != false)
        {
                string val_54 = pack.LocalPrice;
        }
        
        val_78 = this.coinsImg;
        if((UnityEngine.Object.op_Implicit(exists:  val_78)) != false)
        {
                val_78 = this.coinsImg.m_Sprite;
            if(val_78 == 0)
        {
                val_78 = this.coinsImg;
            val_76 = this.coinLevelSprites;
            if(val_69 >= 1)
        {
            
        }
        else
        {
            
        }
        
            val_78.sprite = val_76[val_70];
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.mostPopular)) == false)
        {
            goto label_168;
        }
        
        AppConfigs val_61 = App.Configuration;
        val_71 = val_61.storeConfig.MostPopularPackPrice;
        if(pack.sale_price != val_71)
        {
            goto label_173;
        }
        
        val_80 = (~(pack.id.Contains(value:  "removeAds"))) & 1;
        if(this.mostPopular != null)
        {
            goto label_175;
        }
        
        label_173:
        val_80 = 0;
        label_175:
        this.mostPopular.SetActive(value:  false);
        label_168:
        if((UnityEngine.Object.op_Implicit(exists:  this.bestValue)) != false)
        {
                this.bestValue.SetActive(value:  (pack.sale_price == (PackagesManager.GetBestValuePackPrice(unfiltered:  0))) ? 1 : 0);
        }
        
        val_69 = this.altBuyButtonSprite;
        if(val_69 == 0)
        {
                return;
        }
        
        val_69 = this.buyButtonBaseImage;
        if(val_69 == 0)
        {
                return;
        }
        
        if(pack.sale_price != 9.99f)
        {
                if(pack.sale_price != 49.99f)
        {
                return;
        }
        
        }
        
        this.buyButtonBaseImage.sprite = this.altBuyButtonSprite;
        this.buyButtonBaseImageOverlay.sprite = this.altBuyButtonSprite;
    }
    protected virtual void HandleConnectionClick(bool result)
    {
        IStoreUI val_8;
        var val_10;
        PurchaseModel val_12;
        val_8 = this.storeUIView;
        if(result == false)
        {
            goto label_1;
        }
        
        if(val_8 == null)
        {
                return;
        }
        
        var val_2 = 0;
        val_10 = 1152921504976584712;
        val_2 = val_2 + 1;
        val_10 = 1152921504976584728;
        goto label_6;
        label_1:
        if(val_8 == null)
        {
                return;
        }
        
        val_12 = null;
        var val_3 = 0;
        val_10 = 1152921504976584712;
        val_3 = val_3 + 1;
        goto label_11;
        label_6:
        val_12 = this.purchasePack;
        val_8 = ???;
        val_8.PurchaseItemModel(pack:  val_12);
        return;
        label_11:
        val_8.ShowConnectionRequired();
    }
    public WGStoreItem()
    {
        this.setCoinNativeSize = true;
    }

}
