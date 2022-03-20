using UnityEngine;
public class PackageDefinitions
{
    // Fields
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _StandardCreditsScheme;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _GemsPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _PetsFoodPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _SpinPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _DiceRollPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _BundlesPackages;
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> _SpecialPackages;
    
    // Properties
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> StandardCreditsScheme { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> GemsPackages { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> PetsFoodPackages { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> SpinPackages { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> DiceRollPackages { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> BundlesPackages { get; }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> SpecialPackages { get; }
    
    // Methods
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_StandardCreditsScheme()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._StandardCreditsScheme;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_GemsPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._GemsPackages;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_PetsFoodPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._PetsFoodPackages;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_SpinPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._SpinPackages;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_DiceRollPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._DiceRollPackages;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_BundlesPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._BundlesPackages;
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> get_SpecialPackages()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)this._SpecialPackages;
    }
    public PackageDefinitions()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "id", value:  "id_removeAds1");
        val_2.Add(key:  "credits", value:  40);
        val_2.Add(key:  "sale_price", value:  2.99f);
        val_1.Add(item:  val_2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "id", value:  "id_removeAds2");
        val_3.Add(key:  "credits", value:  160);
        val_3.Add(key:  "sale_price", value:  9.99f);
        val_1.Add(item:  val_3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "id", value:  "id_removeAds3");
        val_4.Add(key:  "credits", value:  85);
        val_4.Add(key:  "sale_price", value:  5.99f);
        val_1.Add(item:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "id", value:  "id_removeAds4");
        val_5.Add(key:  "credits", value:  120);
        val_5.Add(key:  "sale_price", value:  7.99f);
        val_1.Add(item:  val_5);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "id", value:  "id_credits1");
        val_6.Add(key:  "credits", value:  24);
        val_6.Add(key:  "sale_price", value:  0.99f);
        val_1.Add(item:  val_6);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7.Add(key:  "id", value:  "id_credits199");
        val_7.Add(key:  "credits", value:  48);
        val_7.Add(key:  "sale_price", value:  1.99f);
        val_1.Add(item:  val_7);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_8.Add(key:  "id", value:  "id_credits2");
        val_8.Add(key:  "credits", value:  72);
        val_8.Add(key:  "sale_price", value:  2.99f);
        val_1.Add(item:  val_8);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_9.Add(key:  "id", value:  "id_credits3");
        val_9.Add(key:  "credits", value:  133);
        val_9.Add(key:  "sale_price", value:  4.99f);
        val_1.Add(item:  val_9);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_10.Add(key:  "id", value:  "id_credits4");
        val_10.Add(key:  "credits", value:  290);
        val_10.Add(key:  "sale_price", value:  9.99f);
        val_1.Add(item:  val_10);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_11.Add(key:  "id", value:  "id_credits5");
        val_11.Add(key:  "credits", value:  630);
        val_11.Add(key:  "sale_price", value:  19.99f);
        val_1.Add(item:  val_11);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_12.Add(key:  "id", value:  "id_credits6");
        val_12.Add(key:  "credits", value:  1700);
        val_12.Add(key:  "sale_price", value:  49.99f);
        val_1.Add(item:  val_12);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_13.Add(key:  "id", value:  "id_credits7");
        val_13.Add(key:  "credits", value:  940);
        val_13.Add(key:  "sale_price", value:  29.99f);
        val_1.Add(item:  val_13);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_14.Add(key:  "id", value:  "id_credits8");
        val_14.Add(key:  "credits", value:  2600);
        val_14.Add(key:  "sale_price", value:  74.99f);
        val_1.Add(item:  val_14);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_15 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_15.Add(key:  "id", value:  "id_credits9");
        val_15.Add(key:  "credits", value:  3600);
        val_15.Add(key:  "sale_price", value:  99.99f);
        val_1.Add(item:  val_15);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_16 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_16.Add(key:  "id", value:  "id_credits10");
        val_16.Add(key:  "credits", value:  8000);
        val_16.Add(key:  "sale_price", value:  199.99f);
        val_1.Add(item:  val_16);
        mem[1152921515759446752] = val_1;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_17 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_18.Add(key:  "id", value:  "id_gems1");
        val_18.Add(key:  "gems", value:  7);
        val_18.Add(key:  "sale_price", value:  4.99f);
        val_17.Add(item:  val_18);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_19 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_19.Add(key:  "id", value:  "id_gems2");
        val_19.Add(key:  "gems", value:  16);
        val_19.Add(key:  "sale_price", value:  9.99f);
        val_17.Add(item:  val_19);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_20 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_20.Add(key:  "id", value:  "id_gems3");
        val_20.Add(key:  "gems", value:  34);
        val_20.Add(key:  "sale_price", value:  19.99f);
        val_17.Add(item:  val_20);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_21 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_21.Add(key:  "id", value:  "id_gems4");
        val_21.Add(key:  "gems", value:  112);
        val_21.Add(key:  "sale_price", value:  49.99f);
        val_17.Add(item:  val_21);
        mem[1152921515759446760] = val_17;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_22 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_23 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_23.Add(key:  "id", value:  "id_pets_food5");
        val_23.Add(key:  "pets_food", value:  3);
        val_23.Add(key:  "sale_price", value:  1.99f);
        val_22.Add(item:  val_23);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_24 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_24.Add(key:  "id", value:  "id_pets_food6");
        val_24.Add(key:  "pets_food", value:  8);
        val_24.Add(key:  "sale_price", value:  4.99f);
        val_22.Add(item:  val_24);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_25 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_25.Add(key:  "id", value:  "id_pets_food7");
        val_25.Add(key:  "pets_food", value:  18);
        val_25.Add(key:  "sale_price", value:  9.99f);
        val_22.Add(item:  val_25);
        mem[1152921515759446768] = val_22;
        mem[1152921515759446776] = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_27 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_28 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_28.Add(key:  "id", value:  "id_dice_roll1");
        val_28.Add(key:  "dice_rolls", value:  7);
        val_28.Add(key:  "sale_price", value:  1.99f);
        val_27.Add(item:  val_28);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_29 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_29.Add(key:  "id", value:  "id_dice_roll2");
        val_29.Add(key:  "dice_rolls", value:  20);
        val_29.Add(key:  "sale_price", value:  4.99f);
        val_27.Add(item:  val_29);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_30 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_30.Add(key:  "id", value:  "id_dice_roll3");
        val_30.Add(key:  "dice_rolls", value:  45);
        val_30.Add(key:  "sale_price", value:  9.99f);
        val_27.Add(item:  val_30);
        mem[1152921515759446784] = val_27;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_31 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_32 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_32.Add(key:  "id", value:  "id_bundles5");
        val_32.Add(key:  "sale_price", value:  9.99f);
        decimal val_33 = new System.Decimal(value:  220);
        val_32.Add(key:  "credits", value:  val_33.flags);
        val_32.Add(key:  "sb_pc", value:  5);
        val_32.Add(key:  "xtra", value:  40);
        val_32.Add(key:  "credit_package", value:  "id_piggy_bank_lapse3");
        val_32.Add(key:  "pets_food", value:  8);
        val_32.Add(key:  "gems", value:  3);
        val_32.Add(key:  "pet_cards", value:  3);
        val_31.Add(item:  val_32);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_34 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_34.Add(key:  "id", value:  "id_bundles6");
        val_34.Add(key:  "sale_price", value:  9.99f);
        decimal val_35 = new System.Decimal(value:  240);
        val_34.Add(key:  "credits", value:  val_35.flags);
        val_34.Add(key:  "sb_pc", value:  2147483647);
        val_34.Add(key:  "xtra", value:  40);
        val_34.Add(key:  "credit_package", value:  "id_piggy_bank_lapse3");
        val_34.Add(key:  "pets_food", value:  1);
        val_34.Add(key:  "pet_cards", value:  3);
        val_34.Add(key:  "dice_rolls", value:  40);
        val_31.Add(item:  val_34);
        mem[1152921515759446792] = val_31;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_36 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_37 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_37.Add(key:  "id", value:  "id_waterfall_7");
        val_37.Add(key:  "price", value:  49.99f);
        val_37.Add(key:  "sale_price", value:  49.99f);
        val_37.Add(key:  "credit_package", value:  "id_credits8");
        val_36.Add(item:  val_37);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_38 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_38.Add(key:  "id", value:  "id_waterfall_6");
        val_38.Add(key:  "price", value:  19.99f);
        val_38.Add(key:  "sale_price", value:  19.99f);
        val_38.Add(key:  "credit_package", value:  "id_credits7");
        val_36.Add(item:  val_38);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_39 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_39.Add(key:  "id", value:  "id_waterfall_5");
        val_39.Add(key:  "price", value:  9.99f);
        val_39.Add(key:  "sale_price", value:  9.99f);
        val_39.Add(key:  "credit_package", value:  "id_credits5");
        val_36.Add(item:  val_39);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_40 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_40.Add(key:  "id", value:  "id_waterfall_0");
        val_40.Add(key:  "price", value:  4.99f);
        val_40.Add(key:  "sale_price", value:  4.99f);
        val_40.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_40);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_41 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_41.Add(key:  "id", value:  "id_waterfall_1");
        val_41.Add(key:  "price", value:  2.99f);
        val_41.Add(key:  "sale_price", value:  2.99f);
        val_41.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_41);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_42 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_42.Add(key:  "id", value:  "id_waterfall_2");
        val_42.Add(key:  "price", value:  0.99f);
        val_42.Add(key:  "sale_price", value:  0.99f);
        val_42.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_42);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_43 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_43.Add(key:  "id", value:  "id_waterfall_3");
        val_43.Add(key:  "price", value:  1.99f);
        val_43.Add(key:  "sale_price", value:  1.99f);
        val_43.Add(key:  "credit_package", value:  "id_credits5");
        val_36.Add(item:  val_43);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_44 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_44.Add(key:  "id", value:  "id_waterfall_4");
        val_44.Add(key:  "price", value:  0.99f);
        val_44.Add(key:  "sale_price", value:  0.99f);
        val_44.Add(key:  "credit_package", value:  "id_credits5");
        val_36.Add(item:  val_44);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_45 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_45.Add(key:  "id", value:  "id_starter_pack");
        val_45.Add(key:  "price", value:  4.99f);
        val_45.Add(key:  "sale_price", value:  4.99f);
        val_45.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_45);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_46 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_46.Add(key:  "id", value:  "id_starter_dice_pack");
        val_46.Add(key:  "price", value:  4.99f);
        val_46.Add(key:  "sale_price", value:  2.99f);
        val_46.Add(key:  "dice_rolls", value:  15);
        val_46.Add(key:  "credits", value:  120);
        val_46.Add(key:  "credit_package", value:  "id_credits2");
        val_36.Add(item:  val_46);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_47 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_47.Add(key:  "id", value:  "id_fomo_pack");
        val_47.Add(key:  "price", value:  0.99f);
        val_47.Add(key:  "sale_price", value:  0.99f);
        val_47.Add(key:  "credit_package", value:  "id_credits5");
        val_36.Add(item:  val_47);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_48 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_48.Add(key:  "id", value:  "id_piggy_bank_nonbuyer");
        val_48.Add(key:  "sale_price", value:  0.99f);
        val_48.Add(key:  "credit_package", value:  "id_credits2");
        val_36.Add(item:  val_48);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_49 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_49.Add(key:  "id", value:  "id_piggy_bank_lapse1");
        val_49.Add(key:  "sale_price", value:  1.99f);
        val_49.Add(key:  "credit_package", value:  "id_credits2");
        val_36.Add(item:  val_49);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_50 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_50.Add(key:  "id", value:  "id_piggy_bank_lapse2");
        val_50.Add(key:  "sale_price", value:  5.99f);
        val_50.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_50);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_51 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_51.Add(key:  "id", value:  "id_piggy_bank_lapse3");
        val_51.Add(key:  "sale_price", value:  14.99f);
        val_51.Add(key:  "credit_package", value:  "id_credits7");
        val_36.Add(item:  val_51);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_52 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_52.Add(key:  "id", value:  "id_piggy_bank_tier0");
        val_52.Add(key:  "sale_price", value:  0.99f);
        val_36.Add(item:  val_52);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_53 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_53.Add(key:  "id", value:  "id_piggy_bank_tier1");
        val_53.Add(key:  "sale_price", value:  2.99f);
        val_36.Add(item:  val_53);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_54 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_54.Add(key:  "id", value:  "id_piggy_bank_tier2");
        val_54.Add(key:  "sale_price", value:  4.99f);
        val_36.Add(item:  val_54);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_55 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_55.Add(key:  "id", value:  "id_piggy_bank_tier3");
        val_55.Add(key:  "sale_price", value:  9.99f);
        val_36.Add(item:  val_55);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_56 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_56.Add(key:  "id", value:  "id_piggy_bank_tier4");
        val_56.Add(key:  "sale_price", value:  19.99f);
        val_36.Add(item:  val_56);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_57 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_57.Add(key:  "id", value:  "id_piggy_bank_tier5");
        val_57.Add(key:  "sale_price", value:  24.99f);
        val_36.Add(item:  val_57);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_58 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_58.Add(key:  "id", value:  "id_silver_ticket_subscription");
        val_58.Add(key:  "sale_price", value:  2.99f);
        val_36.Add(item:  val_58);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_59 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_59.Add(key:  "id", value:  "id_golden_ticket_subscription");
        val_59.Add(key:  "sale_price", value:  7.99f);
        val_36.Add(item:  val_59);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_60 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_60.Add(key:  "id", value:  "id_keyPack1");
        val_60.Add(key:  "sale_price", value:  0.99f);
        val_60.Add(key:  "keys", value:  1);
        val_36.Add(item:  val_60);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_61 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_61.Add(key:  "id", value:  "id_keyPack2");
        val_61.Add(key:  "sale_price", value:  1.99f);
        val_61.Add(key:  "keys", value:  2);
        val_36.Add(item:  val_61);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_62 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_62.Add(key:  "id", value:  "id_keyPack3");
        val_62.Add(key:  "sale_price", value:  2.99f);
        val_62.Add(key:  "keys", value:  3);
        val_36.Add(item:  val_62);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_63 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_63.Add(key:  "id", value:  "id_super_bundle_nonbuyer");
        val_63.Add(key:  "sale_price", value:  0.99f);
        val_63.Add(key:  "credit_package", value:  "id_credits2");
        val_36.Add(item:  val_63);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_64 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_64.Add(key:  "id", value:  "id_super_bundle_lapse1");
        val_64.Add(key:  "sale_price", value:  1.99f);
        val_64.Add(key:  "credit_package", value:  "id_credits2");
        val_36.Add(item:  val_64);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_65 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_65.Add(key:  "id", value:  "id_super_bundle_lapse2");
        val_65.Add(key:  "sale_price", value:  5.99f);
        val_65.Add(key:  "credit_package", value:  "id_credits4");
        val_36.Add(item:  val_65);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_66 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_66.Add(key:  "id", value:  "id_super_bundle_lapse3");
        val_66.Add(key:  "sale_price", value:  14.99f);
        val_66.Add(key:  "credit_package", value:  "id_credits7");
        val_36.Add(item:  val_66);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_67 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_67.Add(key:  "id", value:  "id_piggybank_raid_1");
        val_67.Add(key:  "sale_price", value:  1.99f);
        val_36.Add(item:  val_67);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_68 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_68.Add(key:  "id", value:  "id_piggybank_raid_2");
        val_68.Add(key:  "sale_price", value:  3.99f);
        val_36.Add(item:  val_68);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_69 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_69.Add(key:  "id", value:  "id_piggybank_raid_3");
        val_69.Add(key:  "sale_price", value:  7.99f);
        val_36.Add(item:  val_69);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_70 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_70.Add(key:  "id", value:  "id_piggybank_raid_4");
        val_70.Add(key:  "sale_price", value:  14.99f);
        val_36.Add(item:  val_70);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_71 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_71.Add(key:  "id", value:  "id_piggybank_raid_5");
        val_71.Add(key:  "sale_price", value:  29.99f);
        val_36.Add(item:  val_71);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_72 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_72.Add(key:  "id", value:  "id_season_plus_pass");
        val_72.Add(key:  "sale_price", value:  4.99f);
        val_36.Add(item:  val_72);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_73 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_73.Add(key:  "id", value:  "progressive_sale_1");
        val_73.Add(key:  "sale_price", value:  5.99f);
        val_73.Add(key:  "credits", value:  2140);
        val_73.Add(key:  "BonusMulti", value:  0.3f);
        val_36.Add(item:  val_73);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_74 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_74.Add(key:  "id", value:  "progressive_sale_2");
        val_74.Add(key:  "sale_price", value:  5.99f);
        val_74.Add(key:  "credits", value:  2400);
        val_74.Add(key:  "BonusMulti", value:  0.5f);
        val_36.Add(item:  val_74);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_75 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_75.Add(key:  "id", value:  "progressive_sale_3");
        val_75.Add(key:  "sale_price", value:  5.99f);
        val_75.Add(key:  "credits", value:  3200);
        val_75.Add(key:  "BonusMulti", value:  1f);
        val_36.Add(item:  val_75);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_76 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_76.Add(key:  "id", value:  "progressive_sale_4");
        val_76.Add(key:  "sale_price", value:  19.99f);
        val_76.Add(key:  "credits", value:  8200);
        val_76.Add(key:  "BonusMulti", value:  0.3f);
        val_36.Add(item:  val_76);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_77 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_77.Add(key:  "id", value:  "progressive_sale_5");
        val_77.Add(key:  "sale_price", value:  19.99f);
        val_77.Add(key:  "credits", value:  9500);
        val_77.Add(key:  "BonusMulti", value:  0.5f);
        val_36.Add(item:  val_77);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_78 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_78.Add(key:  "id", value:  "progressive_sale_6");
        val_78.Add(key:  "sale_price", value:  19.99f);
        val_78.Add(key:  "credits", value:  12650);
        val_78.Add(key:  "BonusMulti", value:  1f);
        val_36.Add(item:  val_78);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_79 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_79.Add(key:  "id", value:  "progressive_sale_7");
        val_79.Add(key:  "sale_price", value:  49.99f);
        val_79.Add(key:  "credits", value:  22100);
        val_79.Add(key:  "BonusMulti", value:  0.3f);
        val_36.Add(item:  val_79);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_80 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_80.Add(key:  "id", value:  "progressive_sale_8");
        val_80.Add(key:  "sale_price", value:  49.99f);
        val_80.Add(key:  "credits", value:  25500);
        val_80.Add(key:  "BonusMulti", value:  0.5f);
        val_36.Add(item:  val_80);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_81 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_81.Add(key:  "id", value:  "progressive_sale_9");
        val_81.Add(key:  "sale_price", value:  49.99f);
        val_81.Add(key:  "credits", value:  34000);
        val_81.Add(key:  "BonusMulti", value:  1f);
        val_36.Add(item:  val_81);
        mem[1152921515759446800] = val_36;
    }

}
