using UnityEngine;
public class FPHPackageDefinitions : PackageDefinitions
{
    // Fields
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _StandardCreditsScheme;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _GemsPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _BundlesPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _SpecialPackages;
    
    // Properties
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> StandardCreditsScheme { get; }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> GemsPackages { get; }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> BundlesPackages { get; }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> SpecialPackages { get; }
    
    // Methods
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_StandardCreditsScheme()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._StandardCreditsScheme;
    }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_GemsPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._GemsPackages;
    }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_BundlesPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._BundlesPackages;
    }
    public override System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_SpecialPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._SpecialPackages;
    }
    public FPHPackageDefinitions()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "id", value:  "id_credits1");
        val_2.Add(key:  "credits", value:  110);
        val_2.Add(key:  "sale_price", value:  0.99f);
        val_1.Add(item:  val_2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "id", value:  "id_credits2");
        val_3.Add(key:  "credits", value:  330);
        val_3.Add(key:  "sale_price", value:  2.99f);
        val_1.Add(item:  val_3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "id", value:  "id_credits3");
        val_4.Add(key:  "credits", value:  640);
        val_4.Add(key:  "sale_price", value:  4.99f);
        val_1.Add(item:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "id", value:  "id_credits4");
        val_5.Add(key:  "credits", value:  1400);
        val_5.Add(key:  "sale_price", value:  9.99f);
        val_1.Add(item:  val_5);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "id", value:  "id_credits5");
        val_6.Add(key:  "credits", value:  3000);
        val_6.Add(key:  "sale_price", value:  19.99f);
        val_1.Add(item:  val_6);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7.Add(key:  "id", value:  "id_credits6");
        val_7.Add(key:  "credits", value:  8000);
        val_7.Add(key:  "sale_price", value:  49.99f);
        val_1.Add(item:  val_7);
        mem[1152921517018939960] = val_1;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_8 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_9.Add(key:  "id", value:  "id_removeAds4");
        val_9.Add(key:  "gems", value:  400);
        val_9.Add(key:  "credits", value:  850);
        val_9.Add(key:  "sale_price", value:  4.99f);
        val_8.Add(item:  val_9);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_10.Add(key:  "id", value:  "id_removeAds5");
        val_10.Add(key:  "gems", value:  600);
        val_10.Add(key:  "credits", value:  1200);
        val_10.Add(key:  "sale_price", value:  6.99f);
        val_8.Add(item:  val_10);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_11.Add(key:  "id", value:  "id_gems1");
        val_11.Add(key:  "gems", value:  50);
        val_11.Add(key:  "sale_price", value:  0.99f);
        val_8.Add(item:  val_11);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_12.Add(key:  "id", value:  "id_gems2");
        val_12.Add(key:  "gems", value:  150);
        val_12.Add(key:  "sale_price", value:  2.99f);
        val_8.Add(item:  val_12);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_13.Add(key:  "id", value:  "id_gems3");
        val_13.Add(key:  "gems", value:  300);
        val_13.Add(key:  "sale_price", value:  4.99f);
        val_8.Add(item:  val_13);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_14.Add(key:  "id", value:  "id_gems4");
        val_14.Add(key:  "gems", value:  650);
        val_14.Add(key:  "sale_price", value:  9.99f);
        val_8.Add(item:  val_14);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_15 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_15.Add(key:  "id", value:  "id_gems5");
        val_15.Add(key:  "gems", value:  1400);
        val_15.Add(key:  "sale_price", value:  19.99f);
        val_8.Add(item:  val_15);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_16 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_16.Add(key:  "id", value:  "id_gems6");
        val_16.Add(key:  "gems", value:  4000);
        val_16.Add(key:  "sale_price", value:  49.99f);
        val_8.Add(item:  val_16);
        mem[1152921517018939968] = val_8;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_17 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_18.Add(key:  "id", value:  "trivia_star_bundle1");
        val_18.Add(key:  "sale_price", value:  9.99f);
        val_18.Add(key:  "credits", value:  1700);
        val_18.Add(key:  "sb_pc", value:  8);
        val_18.Add(key:  "xtra", value:  50);
        val_18.Add(key:  "credit_package", value:  "id_piggy_bank_lapse3");
        val_18.Add(key:  "gems", value:  850);
        val_18.Add(key:  "golden_currency", value:  5000);
        val_17.Add(item:  val_18);
        mem[1152921517018939976] = val_17;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_19 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_20 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_20.Add(key:  "id", value:  "id_waterfall_7");
        val_20.Add(key:  "price", value:  49.99f);
        val_20.Add(key:  "sale_price", value:  49.99f);
        val_20.Add(key:  "credit_package", value:  "id_credits8");
        val_19.Add(item:  val_20);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_21 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_21.Add(key:  "id", value:  "id_waterfall_6");
        val_21.Add(key:  "price", value:  19.99f);
        val_21.Add(key:  "sale_price", value:  19.99f);
        val_21.Add(key:  "credit_package", value:  "id_credits7");
        val_19.Add(item:  val_21);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_22 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_22.Add(key:  "id", value:  "id_waterfall_5");
        val_22.Add(key:  "price", value:  9.99f);
        val_22.Add(key:  "sale_price", value:  9.99f);
        val_22.Add(key:  "credit_package", value:  "id_credits5");
        val_19.Add(item:  val_22);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_23 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_23.Add(key:  "id", value:  "id_waterfall_0");
        val_23.Add(key:  "price", value:  4.99f);
        val_23.Add(key:  "sale_price", value:  4.99f);
        val_23.Add(key:  "credit_package", value:  "id_credits4");
        val_19.Add(item:  val_23);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_24 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_24.Add(key:  "id", value:  "id_waterfall_1");
        val_24.Add(key:  "price", value:  2.99f);
        val_24.Add(key:  "sale_price", value:  2.99f);
        val_24.Add(key:  "credit_package", value:  "id_credits4");
        val_19.Add(item:  val_24);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_25 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_25.Add(key:  "id", value:  "id_waterfall_2");
        val_25.Add(key:  "price", value:  0.99f);
        val_25.Add(key:  "sale_price", value:  0.99f);
        val_25.Add(key:  "credit_package", value:  "id_credits4");
        val_19.Add(item:  val_25);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_26 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_26.Add(key:  "id", value:  "id_waterfall_3");
        val_26.Add(key:  "price", value:  1.99f);
        val_26.Add(key:  "sale_price", value:  1.99f);
        val_26.Add(key:  "credit_package", value:  "id_credits5");
        val_19.Add(item:  val_26);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_27 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_27.Add(key:  "id", value:  "id_waterfall_4");
        val_27.Add(key:  "price", value:  0.99f);
        val_27.Add(key:  "sale_price", value:  0.99f);
        val_27.Add(key:  "credit_package", value:  "id_credits5");
        val_19.Add(item:  val_27);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_28 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_28.Add(key:  "id", value:  "id_starter_pack");
        val_28.Add(key:  "price", value:  4.99f);
        val_28.Add(key:  "sale_price", value:  4.99f);
        val_28.Add(key:  "credit_package", value:  "id_credits4");
        val_19.Add(item:  val_28);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_29 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_29.Add(key:  "id", value:  "id_piggy_bank_nonbuyer");
        val_29.Add(key:  "sale_price", value:  0.99f);
        val_29.Add(key:  "credit_package", value:  "id_credits2");
        val_19.Add(item:  val_29);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_30 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_30.Add(key:  "id", value:  "id_piggy_bank_lapse1");
        val_30.Add(key:  "sale_price", value:  1.99f);
        val_30.Add(key:  "credit_package", value:  "id_credits2");
        val_19.Add(item:  val_30);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_31 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_31.Add(key:  "id", value:  "id_piggy_bank_lapse2");
        val_31.Add(key:  "sale_price", value:  5.99f);
        val_31.Add(key:  "credit_package", value:  "id_credits4");
        val_19.Add(item:  val_31);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_32 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_32.Add(key:  "id", value:  "id_piggy_bank_lapse3");
        val_32.Add(key:  "sale_price", value:  14.99f);
        val_32.Add(key:  "credit_package", value:  "id_credits6");
        val_19.Add(item:  val_32);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_33 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_33.Add(key:  "id", value:  "id_silver_ticket_subscription");
        val_33.Add(key:  "sale_price", value:  3.99f);
        val_33.Add(key:  "initial", value:  0f);
        val_19.Add(item:  val_33);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_34 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_34.Add(key:  "id", value:  "id_golden_ticket_subscription");
        val_34.Add(key:  "sale_price", value:  16.99f);
        val_34.Add(key:  "initial", value:  0.99f);
        val_19.Add(item:  val_34);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_35 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_35.Add(key:  "id", value:  "progressive_sale_1");
        val_35.Add(key:  "sale_price", value:  5.99f);
        val_35.Add(key:  "credits", value:  2140);
        val_35.Add(key:  "BonusMulti", value:  0.3f);
        val_19.Add(item:  val_35);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_36 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_36.Add(key:  "id", value:  "progressive_sale_2");
        val_36.Add(key:  "sale_price", value:  5.99f);
        val_36.Add(key:  "credits", value:  2400);
        val_36.Add(key:  "BonusMulti", value:  0.5f);
        val_19.Add(item:  val_36);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_37 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_37.Add(key:  "id", value:  "progressive_sale_3");
        val_37.Add(key:  "sale_price", value:  5.99f);
        val_37.Add(key:  "credits", value:  3200);
        val_37.Add(key:  "BonusMulti", value:  1f);
        val_19.Add(item:  val_37);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_38 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_38.Add(key:  "id", value:  "progressive_sale_4");
        val_38.Add(key:  "sale_price", value:  19.99f);
        val_38.Add(key:  "credits", value:  8200);
        val_38.Add(key:  "BonusMulti", value:  0.3f);
        val_19.Add(item:  val_38);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_39 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_39.Add(key:  "id", value:  "progressive_sale_5");
        val_39.Add(key:  "sale_price", value:  19.99f);
        val_39.Add(key:  "credits", value:  9500);
        val_39.Add(key:  "BonusMulti", value:  0.5f);
        val_19.Add(item:  val_39);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_40 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_40.Add(key:  "id", value:  "progressive_sale_6");
        val_40.Add(key:  "sale_price", value:  19.99f);
        val_40.Add(key:  "credits", value:  12650);
        val_40.Add(key:  "BonusMulti", value:  1f);
        val_19.Add(item:  val_40);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_41 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_41.Add(key:  "id", value:  "progressive_sale_7");
        val_41.Add(key:  "sale_price", value:  49.99f);
        val_41.Add(key:  "credits", value:  22100);
        val_41.Add(key:  "BonusMulti", value:  0.3f);
        val_19.Add(item:  val_41);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_42 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_42.Add(key:  "id", value:  "progressive_sale_8");
        val_42.Add(key:  "sale_price", value:  49.99f);
        val_42.Add(key:  "credits", value:  25500);
        val_42.Add(key:  "BonusMulti", value:  0.5f);
        val_19.Add(item:  val_42);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_43 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_43.Add(key:  "id", value:  "progressive_sale_9");
        val_43.Add(key:  "sale_price", value:  49.99f);
        val_43.Add(key:  "credits", value:  34000);
        val_43.Add(key:  "BonusMulti", value:  1f);
        val_19.Add(item:  val_43);
        mem[1152921517018939984] = val_19;
    }

}
