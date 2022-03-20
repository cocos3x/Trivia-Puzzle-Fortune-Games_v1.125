using UnityEngine;
public class StoreConfig : ScriptableObject
{
    // Fields
    public GameCurrencyTheme CurrencyTheme;
    public float MostPopularPackPrice;
    protected float ScratchCardPriceThreshold;
    protected string[] purchasePackages;
    public ProductDetails id_credits1;
    public ProductDetails id_credits199;
    public ProductDetails id_credits2;
    public ProductDetails id_credits3;
    public ProductDetails id_credits4;
    public ProductDetails id_credits5;
    public ProductDetails id_credits6;
    public ProductDetails id_credits7;
    public ProductDetails id_credits8;
    public ProductDetails id_credits9;
    public ProductDetails id_credits10;
    public ProductDetails id_removeAds1;
    public ProductDetails id_removeAds2;
    public ProductDetails id_removeAds3;
    public ProductDetails id_removeAds4;
    public ProductDetails id_removeAds5;
    public ProductDetails id_waterfall_0;
    public ProductDetails id_waterfall_1;
    public ProductDetails id_waterfall_2;
    public ProductDetails id_waterfall_3;
    public ProductDetails id_waterfall_4;
    public ProductDetails id_waterfall_5;
    public ProductDetails id_waterfall_6;
    public ProductDetails id_waterfall_7;
    public ProductDetails id_golden_ticket_subscription;
    public ProductDetails id_silver_ticket_subscription;
    public string golden_ticket_ios_override;
    public string silver_ticket_ios_override;
    public ProductDetails id_starter_pack;
    public ProductDetails id_starter_dice_pack;
    public ProductDetails id_fomo_pack;
    public ProductDetails id_piggy_bank_nonbuyer;
    public ProductDetails id_piggy_bank_lapse1;
    public ProductDetails id_piggy_bank_lapse2;
    public ProductDetails id_piggy_bank_lapse3;
    public ProductDetails id_piggy_bank_tier0;
    public ProductDetails id_piggy_bank_tier1;
    public ProductDetails id_piggy_bank_tier2;
    public ProductDetails id_piggy_bank_tier3;
    public ProductDetails id_piggy_bank_tier4;
    public ProductDetails id_piggy_bank_tier5;
    public ProductDetails id_super_bundle_nonbuyer;
    public ProductDetails id_super_bundle_lapse1;
    public ProductDetails id_super_bundle_lapse2;
    public ProductDetails id_super_bundle_lapse3;
    public ProductDetails id_gems1;
    public ProductDetails id_gems2;
    public ProductDetails id_gems3;
    public ProductDetails id_gems4;
    public ProductDetails id_gems5;
    public ProductDetails id_gems6;
    public ProductDetails id_pets_food1;
    public ProductDetails id_pets_food2;
    public ProductDetails id_pets_food3;
    public ProductDetails id_pets_food4;
    public ProductDetails id_pets_food5;
    public ProductDetails id_pets_food6;
    public ProductDetails id_pets_food7;
    public ProductDetails id_dice_roll1;
    public ProductDetails id_dice_roll2;
    public ProductDetails id_dice_roll3;
    public ProductDetails id_bundles0;
    public ProductDetails id_bundles1;
    public ProductDetails id_bundles2;
    public ProductDetails id_bundles3;
    public ProductDetails id_bundles4;
    public ProductDetails id_bundles5;
    public ProductDetails id_bundles6;
    public ProductDetails trivia_star_bundle1;
    public ProductDetails id_keyPack1;
    public ProductDetails id_keyPack2;
    public ProductDetails id_keyPack3;
    public ProductDetails id_spins1;
    public ProductDetails id_spins2;
    public ProductDetails id_spins3;
    public ProductDetails id_spins4;
    public ProductDetails id_spins5;
    public ProductDetails id_spins6;
    public ProductDetails restaurant_rivals_ooc_bundle;
    public ProductDetails restaurant_rivals_oos_free1;
    public ProductDetails restaurant_rivals_oos_free2;
    public ProductDetails restaurant_rivals_oos_paid1;
    public ProductDetails restaurant_rivals_oos_paid2;
    public ProductDetails restaurant_rivals_oos_paid3;
    public ProductDetails id_piggybank_raid_1;
    public ProductDetails id_piggybank_raid_2;
    public ProductDetails id_piggybank_raid_3;
    public ProductDetails id_piggybank_raid_4;
    public ProductDetails id_piggybank_raid_5;
    public ProductDetails id_season_plus_pass;
    public ProductDetails progressive_sale_1;
    public ProductDetails progressive_sale_2;
    public ProductDetails progressive_sale_3;
    public ProductDetails progressive_sale_4;
    public ProductDetails progressive_sale_5;
    public ProductDetails progressive_sale_6;
    public ProductDetails progressive_sale_7;
    public ProductDetails progressive_sale_8;
    public ProductDetails progressive_sale_9;
    private string[] skus;
    private System.Collections.Generic.Dictionary<ProductDetails.Category, System.Collections.Generic.List<string>> prodSkus;
    private string[] ids;
    private ProductDetails[] prodDetails;
    
    // Methods
    public string GetSku(string internalId)
    {
        string val_2;
        if((this.GetProductByInternalId(internalId:  internalId)) == null)
        {
                return val_2;
        }
        
        val_2 = val_1.sku;
        return val_2;
    }
    public string GetId(string sku)
    {
        string val_2;
        if((this.GetProductBySku(sku:  sku)) == null)
        {
                return val_2;
        }
        
        val_2 = val_1.internalId;
        return val_2;
    }
    public ProductDetails GetProductByInternalId(string internalId)
    {
        ProductDetails val_3;
        if(val_1.Length >= 1)
        {
                var val_3 = 0;
            do
        {
            val_3 = this.GetProductDetails()[val_3];
            if((val_1[0x0][0].internalId.Equals(value:  internalId)) == true)
        {
                return (ProductDetails)val_3;
        }
        
            val_3 = val_3 + 1;
        }
        while(val_3 < val_1.Length);
        
        }
        
        val_3 = 0;
        return (ProductDetails)val_3;
    }
    public ProductDetails GetProductBySku(string sku)
    {
        string val_7;
        var val_8;
        ProductDetails val_9;
        val_7 = sku;
        if(val_1.Length >= 1)
        {
                val_8 = 0;
            do
        {
            val_9 = this.GetProductDetails()[val_8];
            if((val_1[0x0][0].sku.Equals(value:  val_7)) == true)
        {
                return (ProductDetails)val_9;
        }
        
            if((((System.String.op_Equality(a:  val_1[0x0][0].sku, b:  "word_game_removeads1")) != true) ? "word_game_removeAds1" : val_1[0x0][0].sku.Equals(value:  val_7)) == true)
        {
                return (ProductDetails)val_9;
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < val_1.Length);
        
        }
        
        val_7 = "StoreConfig No Internal Id for SKU:"("StoreConfig No Internal Id for SKU:") + val_7;
        UnityEngine.Debug.LogError(message:  val_7);
        val_9 = 0;
        return (ProductDetails)val_9;
    }
    public string[] GetSkus()
    {
        if(this.skus != null)
        {
                if(this.skus.Length != 0)
        {
                return (System.String[])val_3;
        }
        
        }
        
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(val_2.Length >= 1)
        {
                var val_5 = 0;
            do
        {
            ProductDetails val_4 = this.GetProductDetails()[val_5];
            val_1.Add(item:  val_2[0x0][0].sku);
            val_5 = val_5 + 1;
        }
        while(val_5 < val_2.Length);
        
        }
        
        T[] val_3 = val_1.ToArray();
        this.skus = val_3;
        return (System.String[])val_3;
    }
    public string[] GetSkusBy(ProductDetails.Category cat)
    {
        System.Collections.Generic.List<System.String> val_7;
        var val_8;
        if((this.prodSkus.ContainsKey(key:  cat)) != false)
        {
                val_7 = 1152921515800787040;
            System.Collections.Generic.List<System.String> val_2 = this.prodSkus.Item[cat];
            if(1152921515800781920 >= 1)
        {
                System.Collections.Generic.List<System.String> val_3 = this.prodSkus.Item[cat];
            val_8 = 1152921509851233392;
            return val_4.ToArray();
        }
        
        }
        
        System.Collections.Generic.List<System.String> val_4 = null;
        val_7 = val_4;
        val_4 = new System.Collections.Generic.List<System.String>();
        if(val_5.Length >= 1)
        {
                var val_8 = 0;
            do
        {
            if((this.GetProductDetails()[val_8].isCategory(cat:  cat)) != false)
        {
                val_4.Add(item:  val_5[0x0][0].sku);
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < val_5.Length);
        
        }
        
        this.prodSkus.Add(key:  cat, value:  val_4);
        val_8 = 1152921509851233392;
        return val_4.ToArray();
    }
    public string[] GetIds()
    {
        if(this.ids != null)
        {
                if(this.ids.Length != 0)
        {
                return (System.String[])val_3;
        }
        
        }
        
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(val_2.Length >= 1)
        {
                var val_5 = 0;
            do
        {
            ProductDetails val_4 = this.GetProductDetails()[val_5];
            val_1.Add(item:  val_2[0x0][0].internalId);
            val_5 = val_5 + 1;
        }
        while(val_5 < val_2.Length);
        
        }
        
        T[] val_3 = val_1.ToArray();
        this.ids = val_3;
        return (System.String[])val_3;
    }
    public ProductDetails[] GetProductDetails()
    {
        var val_9;
        ProductDetails[] val_10;
        System.Type val_11;
        var val_12;
        val_9 = this;
        val_10 = this.prodDetails;
        if(val_10 != null)
        {
                if(this.prodDetails.Length != 0)
        {
                return (ProductDetails[])val_8;
        }
        
        }
        
        System.Collections.Generic.List<ProductDetails> val_1 = new System.Collections.Generic.List<ProductDetails>();
        val_11 = this.GetType();
        if(null >= 1)
        {
                val_12 = 1152921504894545920;
            var val_10 = 0;
            do
        {
            var val_9 = 0;
            if(((1179403647 != 0) && ((System.String.IsNullOrEmpty(value:  System.Type.__il2cppRuntimeField_byval_arg + 24)) != true)) && ((System.Type.__il2cppRuntimeField_byval_arg + 24.Contains(value:  "?")) != true))
        {
                if((System.String.op_Equality(a:  System.Type.__il2cppRuntimeField_byval_arg + 24, b:  "not currently used")) != true)
        {
                .internalId = System.Type.__il2cppRuntimeField_byval_arg;
            .sku = System.Type.__il2cppRuntimeField_byval_arg + 24;
            .productType = System.Type.__il2cppRuntimeField_byval_arg + 32;
            val_1.Add(item:  new ProductDetails());
            val_12 = val_12;
            val_9 = val_9;
            val_11 = val_11;
        }
        
        }
        
            val_9 = val_9 + 1;
            val_10 = val_10 + 1;
        }
        while(val_10 < (val_2 + 24));
        
        }
        
        T[] val_8 = val_1.ToArray();
        this.prodDetails = val_8;
        return (ProductDetails[])val_8;
    }
    private void OverrideIOSspecificPackageNames()
    {
    
    }
    public StoreConfig()
    {
        this.MostPopularPackPrice = 19.99f;
        this.ScratchCardPriceThreshold = 9.99f;
        this.prodSkus = new System.Collections.Generic.Dictionary<Category, System.Collections.Generic.List<System.String>>();
    }

}
