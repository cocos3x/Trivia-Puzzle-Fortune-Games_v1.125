using UnityEngine;
public class PurchaseModel : JsonSerializable<PurchaseModel>
{
    // Fields
    private string <Sku>k__BackingField;
    private string id;
    private bool vipApplied;
    private decimal vipAddedCredits;
    private decimal vipAddedGems;
    private decimal vipAddedGoldenCurrency;
    private int vipLevel;
    private int vipContribution;
    private int vipFriendsGiftAmount;
    private bool clubsApplied;
    private int clubsContribution;
    private string price;
    private float sale_price;
    private float targetSalePrice;
    private int trackerPurchasePoint;
    private string ltoModifier;
    private string extraInfo;
    private int purchaseScale;
    private int defaultPackage;
    private string promoType;
    private bool isSubscription;
    private System.Collections.Generic.List<PurchaseCommands> PurchaseInstructions;
    private System.Collections.Generic.Dictionary<string, object> _PurchaseTrackingInfo;
    private System.Collections.Generic.Dictionary<string, System.Decimal> rewards;
    private bool <isPromoActivated>k__BackingField;
    private string <originalPrice>k__BackingField;
    public PurchaseUserInfo PrePurchaseUserInfo;
    
    // Properties
    public string Sku { get; set; }
    public System.Collections.Generic.Dictionary<string, object> PurchaseTrackingInfo { get; }
    public decimal Credits { get; }
    public decimal Gems { get; }
    public decimal PetsFood { get; }
    public decimal PetCards { get; }
    public decimal DiceRolls { get; }
    public decimal GoldenCurrency { get; }
    public decimal Keys { get; }
    public decimal Spins { get; }
    public string InternalId { get; set; }
    public bool VipApplied { get; set; }
    public decimal VipAddedCredits { get; set; }
    public decimal VipAddedGems { get; set; }
    public decimal VipAddedGoldenCurrency { get; set; }
    public int VipLevel { get; set; }
    public int VipContribution { get; set; }
    public int VipFriendsGiftAmount { get; set; }
    public bool ClubsApplied { get; set; }
    public int ClubsContribution { get; set; }
    public string LocalPrice { get; set; }
    public float SalePrice { get; set; }
    public int DefaultPackage { get; set; }
    public int PurchaseScale { get; }
    public float TargetSalePrice { get; set; }
    public TrackerPurchasePoints TrackerPurchasePoint { get; set; }
    public string LTOModifier { get; set; }
    public string ExtraInfo { get; set; }
    public string PromoType { get; set; }
    public bool isPromoActivated { get; set; }
    public string originalPrice { get; set; }
    public bool IsSubscription { get; set; }
    public decimal VipAddedAmount { get; }
    
    // Methods
    public string get_Sku()
    {
        return (string)this.<Sku>k__BackingField;
    }
    public void set_Sku(string value)
    {
        this.<Sku>k__BackingField = value;
    }
    public System.Collections.Generic.Dictionary<string, object> get_PurchaseTrackingInfo()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this._PurchaseTrackingInfo;
    }
    public decimal get_Credits()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "credits")) != false)
        {
                val_4 = this.rewards;
            val_5 = "credits";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_Gems()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "gems")) != false)
        {
                val_4 = this.rewards;
            val_5 = "gems";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_PetsFood()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "pets_food")) != false)
        {
                val_4 = this.rewards;
            val_5 = "pets_food";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_PetCards()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "pet_cards")) != false)
        {
                val_4 = this.rewards;
            val_5 = "pet_cards";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_DiceRolls()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "dice_rolls")) != false)
        {
                val_4 = this.rewards;
            val_5 = "dice_rolls";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_GoldenCurrency()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "golden_currency")) != false)
        {
                val_4 = this.rewards;
            val_5 = "golden_currency";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_Keys()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "keys")) != false)
        {
                val_4 = this.rewards;
            val_5 = "keys";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public decimal get_Spins()
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = this;
        if((this.rewards.ContainsKey(key:  "spins")) != false)
        {
                val_4 = this.rewards;
            val_5 = "spins";
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public string get_InternalId()
    {
        return (string)this.id;
    }
    public void set_InternalId(string value)
    {
        this.id = value;
    }
    public bool get_VipApplied()
    {
        return (bool)this.vipApplied;
    }
    public void set_VipApplied(bool value)
    {
        this.vipApplied = value;
    }
    public decimal get_VipAddedCredits()
    {
        return new System.Decimal() {flags = this.vipAddedCredits, hi = this.vipAddedCredits};
    }
    public void set_VipAddedCredits(decimal value)
    {
        this.vipAddedCredits = value;
        mem[1152921515766786652] = value.lo;
        mem[1152921515766786656] = value.mid;
    }
    public decimal get_VipAddedGems()
    {
        return new System.Decimal() {flags = this.vipAddedGems, hi = this.vipAddedGems};
    }
    public void set_VipAddedGems(decimal value)
    {
        this.vipAddedGems = value;
        mem[1152921515767010668] = value.lo;
        mem[1152921515767010672] = value.mid;
    }
    public decimal get_VipAddedGoldenCurrency()
    {
        return new System.Decimal() {flags = this.vipAddedGoldenCurrency, hi = this.vipAddedGoldenCurrency};
    }
    public void set_VipAddedGoldenCurrency(decimal value)
    {
        this.vipAddedGoldenCurrency = value;
        mem[1152921515767234684] = value.lo;
        mem[1152921515767234688] = value.mid;
    }
    public int get_VipLevel()
    {
        return (int)this.vipLevel;
    }
    public void set_VipLevel(int value)
    {
        this.vipLevel = value;
    }
    public int get_VipContribution()
    {
        return (int)this.vipContribution;
    }
    public void set_VipContribution(int value)
    {
        this.vipContribution = value;
    }
    public int get_VipFriendsGiftAmount()
    {
        return (int)this.vipFriendsGiftAmount;
    }
    public void set_VipFriendsGiftAmount(int value)
    {
        this.vipFriendsGiftAmount = value;
    }
    public bool get_ClubsApplied()
    {
        return (bool)this.clubsApplied;
    }
    public void set_ClubsApplied(bool value)
    {
        this.clubsApplied = value;
    }
    public int get_ClubsContribution()
    {
        return (int)this.clubsContribution;
    }
    public void set_ClubsContribution(int value)
    {
        this.clubsContribution = value;
    }
    public string get_LocalPrice()
    {
        if(this.price == null)
        {
                return this.sale_price.ToString(format:  "$0.00");
        }
        
        return (string)this.price;
    }
    public void set_LocalPrice(string value)
    {
        this.price = value;
    }
    public float get_SalePrice()
    {
        return (float)this.sale_price;
    }
    public void set_SalePrice(float value)
    {
        this.sale_price = value;
    }
    public int get_DefaultPackage()
    {
        return (int)this.defaultPackage;
    }
    public void set_DefaultPackage(int value)
    {
        this.defaultPackage = value;
    }
    public int get_PurchaseScale()
    {
        if((this.purchaseScale & 2147483648) == 0)
        {
                return val_3;
        }
        
        int val_3 = System.Int32.Parse(s:  this.id.Substring(startIndex:  this.id.m_stringLength - 1, length:  1));
        this.purchaseScale = val_3;
        return val_3;
    }
    public float get_TargetSalePrice()
    {
        return (float)this.targetSalePrice;
    }
    public void set_TargetSalePrice(float value)
    {
        this.targetSalePrice = value;
    }
    public TrackerPurchasePoints get_TrackerPurchasePoint()
    {
        return (TrackerPurchasePoints)this.trackerPurchasePoint;
    }
    public void set_TrackerPurchasePoint(TrackerPurchasePoints value)
    {
        this.trackerPurchasePoint = value;
    }
    public string get_LTOModifier()
    {
        return (string)this.ltoModifier;
    }
    public void set_LTOModifier(string value)
    {
        this.ltoModifier = value;
    }
    public string get_ExtraInfo()
    {
        return (string)this.extraInfo;
    }
    public void set_ExtraInfo(string value)
    {
        this.extraInfo = value;
    }
    public string get_PromoType()
    {
        return (string)this.promoType;
    }
    public void set_PromoType(string value)
    {
        this.promoType = value;
    }
    public bool get_isPromoActivated()
    {
        return (bool)this.<isPromoActivated>k__BackingField;
    }
    public void set_isPromoActivated(bool value)
    {
        this.<isPromoActivated>k__BackingField = value;
    }
    public string get_originalPrice()
    {
        return (string)this.<originalPrice>k__BackingField;
    }
    public void set_originalPrice(string value)
    {
        this.<originalPrice>k__BackingField = value;
    }
    public bool get_IsSubscription()
    {
        return (bool)this.isSubscription;
    }
    public void set_IsSubscription(bool value)
    {
        this.isSubscription = value;
    }
    public decimal get_VipAddedAmount()
    {
        int val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = this;
        val_3 = 1152921515771149220;
        val_4 = null;
        val_4 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.vipAddedCredits, hi = this.vipAddedCredits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
                return new System.Decimal() {flags = val_2, hi = val_2, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
        }
        
        val_5 = null;
        val_5 = null;
        val_2 = 1152921504617021448;
        val_3 = 1152921504617021456;
        return new System.Decimal() {flags = val_2, hi = val_2, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
    }
    public bool ContainsInstruction(PurchaseCommands instruction)
    {
        if(this.PurchaseInstructions == null)
        {
                return (bool)this.PurchaseInstructions;
        }
        
        return this.PurchaseInstructions.Contains(item:  instruction);
    }
    public void AddInstruction(PurchaseCommands instruction)
    {
        System.Collections.Generic.List<PurchaseCommands> val_3 = this.PurchaseInstructions;
        if(val_3 == null)
        {
                System.Collections.Generic.List<PurchaseCommands> val_1 = null;
            val_3 = val_1;
            val_1 = new System.Collections.Generic.List<PurchaseCommands>();
            this.PurchaseInstructions = val_3;
        }
        
        if((val_1.Contains(item:  instruction)) != false)
        {
                return;
        }
        
        this.PurchaseInstructions.Add(item:  instruction);
    }
    public void RemoveInstruction(PurchaseCommands instruction)
    {
        if(this.PurchaseInstructions == null)
        {
                return;
        }
        
        if((this.PurchaseInstructions.Contains(item:  instruction)) == false)
        {
                return;
        }
        
        bool val_2 = this.PurchaseInstructions.Remove(item:  instruction);
    }
    public void AddTrackingInfo(string infoKey, object infoValue)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = this._PurchaseTrackingInfo;
        if(val_2 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this._PurchaseTrackingInfo = val_2;
        }
        
        val_1.Add(key:  infoKey, value:  infoValue);
    }
    public PurchaseModel()
    {
        this.ltoModifier = "slc_default";
        this.purchaseScale = -1;
        this.defaultPackage = -1;
        this.extraInfo = "";
        this.promoType = "";
        this.PurchaseInstructions = new System.Collections.Generic.List<PurchaseCommands>();
        this._PurchaseTrackingInfo = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.PrePurchaseUserInfo = new PurchaseUserInfo();
        this.rewards = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
    }
    public PurchaseModel(PurchaseModel purchaseToClone)
    {
        this.ltoModifier = "slc_default";
        this.purchaseScale = -1;
        this.defaultPackage = -1;
        this.extraInfo = "";
        this.promoType = "";
        this.PurchaseInstructions = new System.Collections.Generic.List<PurchaseCommands>();
        this._PurchaseTrackingInfo = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.PrePurchaseUserInfo = new PurchaseUserInfo();
        this.<Sku>k__BackingField = purchaseToClone.<Sku>k__BackingField;
        this.id = purchaseToClone.id;
        this.price = purchaseToClone.price;
        this.sale_price = purchaseToClone.sale_price;
        this.trackerPurchasePoint = purchaseToClone.trackerPurchasePoint;
        this.PurchaseInstructions = new System.Collections.Generic.List<PurchaseCommands>(collection:  purchaseToClone.PurchaseInstructions);
        this._PurchaseTrackingInfo = new System.Collections.Generic.Dictionary<System.String, System.Object>(dictionary:  purchaseToClone._PurchaseTrackingInfo);
        this.rewards = new System.Collections.Generic.Dictionary<System.String, System.Decimal>(dictionary:  purchaseToClone.rewards);
    }
    public PurchaseModel(twelvegigs.storage.JsonDictionary json)
    {
        var val_16;
        this.ltoModifier = "slc_default";
        this.purchaseScale = -1;
        this.defaultPackage = -1;
        this.extraInfo = "";
        this.promoType = "";
        this.PurchaseInstructions = new System.Collections.Generic.List<PurchaseCommands>();
        this._PurchaseTrackingInfo = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.PrePurchaseUserInfo = new PurchaseUserInfo();
        this.id = json.getString(key:  "id", defaultValue:  "");
        this.rewards = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
        val_16 = null;
        val_16 = null;
        decimal val_6 = json.getDecimal(key:  "credits", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        decimal val_7 = json.getDecimal(key:  "gems", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "gems", amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        decimal val_8 = json.getDecimal(key:  "pets_food", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "pets_food", amount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
        decimal val_9 = json.getDecimal(key:  "golden_currency", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "golden_currency", amount:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        decimal val_10 = json.getDecimal(key:  "dice_rolls", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "dice_rolls", amount:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
        decimal val_11 = json.getDecimal(key:  "keys", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "keys", amount:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
        decimal val_12 = json.getDecimal(key:  "spins", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.AddReward(rewardType:  "spins", amount:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid});
        this.sale_price = json.getFloat(key:  "sale_price", defaultValue:  1f);
        this.price = json.getString(key:  "regular_price", defaultValue:  this.sale_price.ToString(format:  "$#,##0.00"));
    }
    public PurchaseModel(System.Collections.Generic.Dictionary<string, object> packageDefinition)
    {
        this.ltoModifier = "slc_default";
        this.purchaseScale = -1;
        this.defaultPackage = -1;
        this.extraInfo = "";
        this.promoType = "";
        this.PurchaseInstructions = new System.Collections.Generic.List<PurchaseCommands>();
        this._PurchaseTrackingInfo = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.PrePurchaseUserInfo = new PurchaseUserInfo();
        if((packageDefinition.ContainsKey(key:  "id")) != false)
        {
                this.id = packageDefinition.Item["id"];
        }
        
        if((packageDefinition.ContainsKey(key:  "sale_price")) != false)
        {
                this.sale_price = System.Single.Parse(s:  packageDefinition.Item["sale_price"]);
        }
        
        if((packageDefinition.ContainsKey(key:  "regular_price")) != false)
        {
                this.price = packageDefinition.Item["regular_price"];
        }
        
        this.rewards = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
        if((packageDefinition.ContainsKey(key:  "credits")) != false)
        {
                decimal val_14 = System.Decimal.Parse(s:  packageDefinition.Item["credits"]);
            this.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid});
        }
        
        if((packageDefinition.ContainsKey(key:  "gems")) != false)
        {
                decimal val_17 = System.Decimal.Parse(s:  packageDefinition.Item["gems"]);
            this.AddReward(rewardType:  "gems", amount:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid});
        }
        
        if((packageDefinition.ContainsKey(key:  "pets_food")) != false)
        {
                decimal val_20 = System.Decimal.Parse(s:  packageDefinition.Item["pets_food"]);
            this.AddReward(rewardType:  "pets_food", amount:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid});
        }
        
        if((packageDefinition.ContainsKey(key:  "golden_currency")) != false)
        {
                decimal val_23 = System.Decimal.Parse(s:  packageDefinition.Item["golden_currency"]);
            this.AddReward(rewardType:  "golden_currency", amount:  new System.Decimal() {flags = val_23.flags, hi = val_23.hi, lo = val_23.lo, mid = val_23.mid});
        }
        
        if((packageDefinition.ContainsKey(key:  "pet_cards")) != false)
        {
                decimal val_26 = System.Decimal.Parse(s:  packageDefinition.Item["pet_cards"]);
            this.AddReward(rewardType:  "pet_cards", amount:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid});
        }
        
        if((packageDefinition.ContainsKey(key:  "dice_rolls")) == false)
        {
                return;
        }
        
        decimal val_29 = System.Decimal.Parse(s:  packageDefinition.Item["dice_rolls"]);
        this.AddReward(rewardType:  "dice_rolls", amount:  new System.Decimal() {flags = val_29.flags, hi = val_29.hi, lo = val_29.lo, mid = val_29.mid});
    }
    public void AddReward(string rewardType, decimal amount)
    {
        if((this.rewards.ContainsKey(key:  rewardType)) != false)
        {
                decimal val_2 = this.rewards.Item[rewardType];
            decimal val_3 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
            this.rewards.set_Item(key:  rewardType, value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            return;
        }
        
        this.rewards.Add(key:  rewardType, value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
    }
    public decimal GetReward(string rewardType)
    {
        string val_3;
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_4;
        string val_5;
        var val_6;
        val_3 = rewardType;
        if((this.rewards.ContainsKey(key:  val_3)) != false)
        {
                val_4 = this.rewards;
            val_5 = val_3;
            decimal val_2 = val_4.Item[val_5];
            return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_3 = 1152921504617017344;
        val_6 = null;
        val_6 = null;
        val_4 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_4, hi = val_4, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public override string ToString()
    {
        return this.ToCustomString();
    }
    public string ToCustomString()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this, formatting:  1);
    }
    public string ToShortString()
    {
        return (string)System.String.Format(format:  "InternalId:{0}, sale_price:{1}, rewards:{2}", arg0:  this.id, arg1:  this.sale_price, arg2:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.rewards, formatting:  1));
    }

}
