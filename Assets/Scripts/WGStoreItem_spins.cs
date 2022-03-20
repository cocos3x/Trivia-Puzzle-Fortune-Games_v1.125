using UnityEngine;
public class WGStoreItem_spins : WGStoreItem
{
    // Methods
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        UnityEngine.Object val_42;
        var val_43;
        var val_45;
        var val_46;
        var val_48;
        UnityEngine.Object val_49;
        float val_50;
        var val_51;
        var val_52;
        val_42 = packIndex;
        val_43 = this;
        mem[1152921517108189576] = pack;
        mem[1152921517108189584] = storeUI;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  storeUI, y:  0);
        if(val_1 != false)
        {
                val_1.sprite = 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) != false)
        {
                decimal val_3 = pack.Spins;
            GameEcon val_4 = App.getGameEcon;
            string val_5 = val_3.flags.ToString(format:  val_4.numberFormatInt);
        }
        
        val_45 = null;
        val_45 = null;
        bool val_6 = UnityEngine.Object.op_Implicit(exists:  X25);
        if(val_6 != false)
        {
                UnityEngine.GameObject val_7 = val_6.gameObject;
            val_46 = null;
            val_46 = null;
            int val_40 = System.Decimal.Powers10.__il2cppRuntimeField_20;
            val_40 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = val_40, mid = val_40}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
            val_7.SetActive(value:  val_40);
        }
        
        bool val_9 = UnityEngine.Object.op_Implicit(exists:  val_7);
        if(val_9 != false)
        {
                val_48 = null;
            val_48 = null;
            int val_41 = System.Decimal.Powers10.__il2cppRuntimeField_20;
            val_41 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = val_41, mid = val_41}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
            val_9.gameObject.SetActive(value:  val_41);
            GameBehavior val_12 = App.getBehavior;
        }
        
        bool val_13 = UnityEngine.Object.op_Implicit(exists:  System.Decimal.Powers10.__il2cppRuntimeField_20);
        if(val_13 != false)
        {
                val_13.SetActive(value:  false);
        }
        
        if((pack.id.Contains(value:  "removeAds")) == false)
        {
            goto label_77;
        }
        
        val_49 = 1152921504884269056;
        GameEcon val_15 = App.getGameEcon;
        val_50 = val_15.NoAdsPackagePriceToUse;
        if((pack.sale_price.Equals(obj:  val_50)) != false)
        {
                if(App.Player.RemovedAds == false)
        {
            goto label_49;
        }
        
        }
        
        UnityEngine.GameObject val_19 = this.gameObject;
        val_51 = 0;
        goto label_51;
        label_49:
        if(val_49 != 0)
        {
                UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.left = 0;
            UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.bottom = 0;
            UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.spacing = val_50;
        }
        
        bool val_21 = UnityEngine.Object.op_Inequality(x:  val_49, y:  0);
        if(val_21 != false)
        {
                UnityEngine.GameObject val_22 = val_21.gameObject;
            val_22.SetActive(value:  true);
            val_22.fontSize = 26;
            string val_23 = Localization.Localize(key:  "no_ads_forever_upper", defaultValue:  "NO ADS FOREVER!", useSingularKey:  false);
        }
        
        bool val_24 = UnityEngine.Object.op_Inequality(x:  val_49, y:  0);
        if(val_24 != false)
        {
                val_24.SetActive(value:  true);
        }
        
        bool val_25 = UnityEngine.Object.op_Inequality(x:  val_49, y:  0);
        if(val_25 != false)
        {
                val_25.SetActive(value:  true);
        }
        
        bool val_26 = UnityEngine.Object.op_Inequality(x:  val_49, y:  0);
        if(val_26 != false)
        {
                val_26.sprite = 0;
        }
        
        label_77:
        if((UnityEngine.Object.op_Implicit(exists:  val_49)) != false)
        {
                string val_28 = pack.LocalPrice;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_49)) != false)
        {
                val_49 = mem[UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192];
            val_49 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192;
            if(val_49 == 0)
        {
                if(totalPackItems >= 1)
        {
                val_52 = System.Decimal.One + ((UnityEngine.Mathf.Max(a:  (val_42 - totalPackItems) + (System.Decimal.One + 24), b:  0)) << 3);
        }
        else
        {
                val_52 = System.Decimal.One + (val_42 << 3);
        }
        
            val_49.sprite = (System.Decimal.One + (packIndex) << 3) + 32;
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_42)) != false)
        {
                AppConfigs val_35 = App.Configuration;
            val_50 = val_35.storeConfig.MostPopularPackPrice;
            val_42.SetActive(value:  (pack.sale_price == val_50) ? 1 : 0);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_42)) == false)
        {
                return;
        }
        
        label_51:
        this.SetActive(value:  (pack.sale_price == (PackagesManager.GetBestValuePackPrice(unfiltered:  0))) ? 1 : 0);
    }
    public WGStoreItem_spins()
    {
        mem[1152921517108375208] = 1;
        val_1 = new MyButton();
    }

}
