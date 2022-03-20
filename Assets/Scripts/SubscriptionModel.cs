using UnityEngine;
public class SubscriptionModel : JsonSerializable<SubscriptionModel>
{
    // Fields
    private string <InternalId>k__BackingField;
    private string <packageName>k__BackingField;
    private string <token>k__BackingField;
    private string <purchaseId>k__BackingField;
    private decimal <collected_at>k__BackingField;
    private decimal <expire_at>k__BackingField;
    private decimal <start_at>k__BackingField;
    private bool <trial>k__BackingField;
    
    // Properties
    public string InternalId { get; set; }
    public string packageName { get; set; }
    public string token { get; set; }
    public string purchaseId { get; set; }
    public decimal collected_at { get; set; }
    public decimal expire_at { get; set; }
    public decimal start_at { get; set; }
    public bool trial { get; set; }
    public System.DateTime expireTime { get; }
    public System.DateTime startTime { get; }
    public System.DateTime collectedTime { get; }
    public bool IsActive { get; }
    public bool CanCollect { get; }
    
    // Methods
    public string get_InternalId()
    {
        return (string)this.<InternalId>k__BackingField;
    }
    public void set_InternalId(string value)
    {
        this.<InternalId>k__BackingField = value;
    }
    public string get_packageName()
    {
        return (string)this.<packageName>k__BackingField;
    }
    public void set_packageName(string value)
    {
        this.<packageName>k__BackingField = value;
    }
    public string get_token()
    {
        return (string)this.<token>k__BackingField;
    }
    public void set_token(string value)
    {
        this.<token>k__BackingField = value;
    }
    public string get_purchaseId()
    {
        return (string)this.<purchaseId>k__BackingField;
    }
    public void set_purchaseId(string value)
    {
        this.<purchaseId>k__BackingField = value;
    }
    public decimal get_collected_at()
    {
        return new System.Decimal() {flags = this.<collected_at>k__BackingField, hi = this.<collected_at>k__BackingField};
    }
    public void set_collected_at(decimal value)
    {
        this.<collected_at>k__BackingField = value;
        mem[1152921515755751672] = value.lo;
        mem[1152921515755751676] = value.mid;
    }
    public decimal get_expire_at()
    {
        return new System.Decimal() {flags = this.<expire_at>k__BackingField, hi = this.<expire_at>k__BackingField};
    }
    public void set_expire_at(decimal value)
    {
        this.<expire_at>k__BackingField = value;
        mem[1152921515755975688] = value.lo;
        mem[1152921515755975692] = value.mid;
    }
    public decimal get_start_at()
    {
        return new System.Decimal() {flags = this.<start_at>k__BackingField, hi = this.<start_at>k__BackingField};
    }
    public void set_start_at(decimal value)
    {
        this.<start_at>k__BackingField = value;
        mem[1152921515756199704] = value.lo;
        mem[1152921515756199708] = value.mid;
    }
    public bool get_trial()
    {
        return (bool)this.<trial>k__BackingField;
    }
    public void set_trial(bool value)
    {
        this.<trial>k__BackingField = value;
    }
    public System.DateTime get_expireTime()
    {
        return twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = this.<expire_at>k__BackingField, hi = this.<expire_at>k__BackingField});
    }
    public System.DateTime get_startTime()
    {
        return twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = this.<start_at>k__BackingField, hi = this.<start_at>k__BackingField});
    }
    public System.DateTime get_collectedTime()
    {
        return twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = this.<collected_at>k__BackingField, hi = this.<collected_at>k__BackingField});
    }
    public void ParseJsonDic(twelvegigs.storage.JsonDictionary jsonDic)
    {
        null = null;
        decimal val_1 = jsonDic.getDecimal(key:  "start_at", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.<start_at>k__BackingField = val_1;
        mem[1152921515756884280] = val_1.lo;
        mem[1152921515756884284] = val_1.mid;
        decimal val_2 = jsonDic.getDecimal(key:  "expire_at", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.<expire_at>k__BackingField = val_2;
        mem[1152921515756884264] = val_2.lo;
        mem[1152921515756884268] = val_2.mid;
        decimal val_3 = jsonDic.getDecimal(key:  "collected_at", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        decimal val_4 = System.Math.Max(val1:  new System.Decimal() {flags = this.<collected_at>k__BackingField, hi = this.<collected_at>k__BackingField, lo = 1152921504617017344}, val2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        this.<collected_at>k__BackingField = val_4;
        mem[1152921515756884248] = val_4.lo;
        mem[1152921515756884252] = val_4.mid;
        this.<purchaseId>k__BackingField = jsonDic.getString(key:  "product_id", defaultValue:  "");
        this.<packageName>k__BackingField = jsonDic.getString(key:  "package_name", defaultValue:  "");
        if((jsonDic.Contains(key:  "trial")) == false)
        {
                return;
        }
        
        this.<trial>k__BackingField = jsonDic.getBool(key:  "trial");
    }
    public bool get_IsActive()
    {
        System.DateTime val_1 = ServerHandler.ServerTime;
        System.DateTime val_2 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = this.<expire_at>k__BackingField, hi = this.<expire_at>k__BackingField});
        return System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_2.dateData});
    }
    public bool get_CanCollect()
    {
        ulong val_8;
        var val_9;
        val_8 = this;
        if(this.IsActive != false)
        {
                System.DateTime val_2 = ServerHandler.ServerTime;
            System.DateTime val_3 = val_2.dateData.Date;
            val_8 = val_3.dateData;
            System.DateTime val_4 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = this.<collected_at>k__BackingField, hi = this.<collected_at>k__BackingField});
            System.DateTime val_5 = val_4.dateData.Date;
            var val_7 = ((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_8}, t2:  new System.DateTime() {dateData = val_5.dateData})) > 0) ? 1 : 0;
            return (bool)val_9;
        }
        
        val_9 = 0;
        return (bool)val_9;
    }
    public bool isEqual(NativePurchase purchase)
    {
        if(purchase != null)
        {
                return System.String.op_Equality(a:  this.<token>k__BackingField, b:  purchase.token);
        }
        
        throw new NullReferenceException();
    }
    public override string ToString()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this, formatting:  1);
    }
    public SubscriptionModel()
    {
    
    }

}
