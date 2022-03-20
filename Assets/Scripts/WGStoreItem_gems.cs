using UnityEngine;
public class WGStoreItem_gems : WGStoreItem
{
    // Methods
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        var val_69;
        float val_70;
        UnityEngine.Object val_71;
        var val_72;
        int val_73;
        UnityEngine.Object val_74;
        var val_75;
        var val_76;
        var val_77;
        val_69 = this;
        mem[1152921517987624328] = pack;
        mem[1152921517987624336] = storeUI;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  storeUI, y:  0);
        if(val_1 != false)
        {
                val_1.sprite = 0;
        }
        
        bool val_2 = UnityEngine.Object.op_Implicit(exists:  storeUI);
        if(val_2 != false)
        {
                val_2.alignment = 4;
            val_70 = -20f;
            val_2.spacing = val_70;
            decimal val_3 = pack.Gems;
            GameEcon val_4 = App.getGameEcon;
            string val_5 = val_3.flags.ToString(format:  val_4.numberFormatInt);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) != false)
        {
                string val_7 = pack.LocalPrice;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) != false)
        {
                val_71 = mem[UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192];
            val_71 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192;
            if(val_71 == 0)
        {
                if(totalPackItems >= 1)
        {
                val_72 = 41971712 + ((UnityEngine.Mathf.Max(a:  (packIndex - totalPackItems) + static_value_02807018, b:  0)) << 3);
        }
        else
        {
                val_72 = 41971712 + (packIndex << 3);
        }
        
            val_71.sprite = (41971712 + (packIndex) << 3) + 32;
        }
        
        }
        
        bool val_13 = UnityEngine.Object.op_Implicit(exists:  packIndex);
        if(val_13 != false)
        {
                val_13.gameObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  packIndex)) == false)
        {
            goto label_56;
        }
        
        GameBehavior val_16 = App.getBehavior;
        if(((val_16.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_56;
        }
        
        val_71 = 1152921516412431344;
        bool val_18 = UnityEngine.Object.op_Inequality(x:  DefaultHandler<WGBonusRewardsHandler>.Instance, y:  0);
        if(val_18 == false)
        {
            goto label_56;
        }
        
        val_18.alignment = 1;
        val_70 = -35f;
        val_18.spacing = val_70;
        val_18.gameObject.SetActive(value:  true);
        GameEcon val_22 = App.getGameEcon;
        string val_23 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetPointsForPurchase(pack:  pack).ToString(format:  val_22.numberFormatInt);
        decimal val_25 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetBonusGems(pack:  pack);
        val_71 = val_25.lo;
        decimal val_26 = pack.Gems;
        val_73 = val_26.lo;
        decimal val_27 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_73, mid = val_26.mid}, d2:  new System.Decimal() {flags = val_25.flags, hi = val_25.hi, lo = val_71, mid = val_25.mid});
        GameEcon val_28 = App.getGameEcon;
        string val_29 = val_27.flags.ToString(format:  val_28.numberFormatInt);
        goto label_74;
        label_56:
        label_74:
        if((pack.id.Contains(value:  "removeAds")) == false)
        {
            goto label_77;
        }
        
        val_74 = 1152921504884269056;
        GameEcon val_31 = App.getGameEcon;
        val_70 = val_31.NoAdsPackagePriceToUse;
        if((pack.sale_price.Equals(obj:  val_70)) != false)
        {
                GameBehavior val_33 = App.getBehavior;
            if(((val_33.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                if(App.Player.RemovedAds == false)
        {
            goto label_90;
        }
        
        }
        
        }
        
        UnityEngine.GameObject val_36 = this.gameObject;
        val_75 = 0;
        goto label_92;
        label_77:
        val_76 = null;
        val_76 = null;
        if(App.game == 17)
        {
            goto label_98;
        }
        
        val_77 = null;
        val_77 = null;
        if(App.game != 19)
        {
            goto label_153;
        }
        
        label_98:
        if((UnityEngine.Object.op_Implicit(exists:  41963520)) == false)
        {
            goto label_153;
        }
        
        GameBehavior val_38 = App.getBehavior;
        if(((val_38.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
            goto label_153;
        }
        
        decimal val_40 = pack.Gems;
        val_70 = pack.sale_price;
        decimal val_41 = System.Decimal.op_Explicit(value:  val_70);
        decimal val_42 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_40.flags, hi = val_40.hi, lo = val_40.lo, mid = val_40.mid}, d2:  new System.Decimal() {flags = val_41.flags, hi = val_41.hi, lo = val_41.lo, mid = val_41.mid});
        decimal val_44 = App.getGameEcon.base099GemPackSize;
        val_73 = val_44.lo;
        decimal val_45 = new System.Decimal(lo:  99, mid:  0, hi:  0, isNegative:  false, scale:  2);
        decimal val_46 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_44.flags, hi = val_44.hi, lo = val_73, mid = val_44.mid}, d2:  new System.Decimal() {flags = val_45.flags, hi = val_45.flags, lo = val_45.lo, mid = val_45.lo});
        decimal val_47 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_42.flags, hi = val_42.hi, lo = val_42.lo, mid = val_42.mid}, d2:  new System.Decimal() {flags = val_46.flags, hi = val_46.hi, lo = val_46.lo, mid = val_46.mid});
        decimal val_48 = System.Decimal.Round(d:  new System.Decimal() {flags = val_47.flags, hi = val_47.hi, lo = val_47.lo, mid = val_47.mid}, decimals:  (pack.sale_price > 99.99f) ? 2 : (0 + 1));
        decimal val_49 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_48.flags, hi = val_48.hi, lo = val_48.lo, mid = val_48.mid}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        int val_67 = val_49.lo;
        val_67 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_49.flags, hi = val_49.hi, lo = val_67, mid = val_49.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        val_49.flags.gameObject.SetActive(value:  val_67);
        GameBehavior val_52 = App.getBehavior;
        goto label_153;
        label_90:
        if(val_74 != 0)
        {
                UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.left = 0;
            UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.bottom = 0;
            UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24.spacing = val_70;
        }
        
        bool val_54 = UnityEngine.Object.op_Inequality(x:  val_74, y:  0);
        if(val_54 != false)
        {
                UnityEngine.GameObject val_55 = val_54.gameObject;
            val_55.SetActive(value:  true);
            val_55.fontSize = 26;
            string val_56 = Localization.Localize(key:  "no_ads_forever_upper", defaultValue:  "NO ADS FOREVER!", useSingularKey:  false);
        }
        
        bool val_57 = UnityEngine.Object.op_Inequality(x:  val_74, y:  0);
        if(val_57 != false)
        {
                val_57.SetActive(value:  true);
        }
        
        bool val_58 = UnityEngine.Object.op_Implicit(exists:  val_74);
        if(val_58 != false)
        {
                val_58.SetActive(value:  false);
        }
        
        bool val_59 = UnityEngine.Object.op_Inequality(x:  val_74, y:  0);
        if(val_59 != false)
        {
                val_59.SetActive(value:  true);
        }
        
        bool val_60 = UnityEngine.Object.op_Inequality(x:  val_74, y:  0);
        if(val_60 != false)
        {
                val_60.sprite = 0;
        }
        
        label_153:
        if((UnityEngine.Object.op_Implicit(exists:  val_74)) != false)
        {
                AppConfigs val_62 = App.Configuration;
            val_70 = val_62.storeConfig.MostPopularPackPrice;
            SetActive(value:  (pack.sale_price == val_70) ? 1 : 0);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_74)) == false)
        {
                return;
        }
        
        label_92:
        this.SetActive(value:  (pack.sale_price == (PackagesManager.GetBestValuePackPrice(unfiltered:  0))) ? 1 : 0);
    }
    public WGStoreItem_gems()
    {
        mem[1152921517987879592] = 1;
        val_1 = new MyButton();
    }

}
