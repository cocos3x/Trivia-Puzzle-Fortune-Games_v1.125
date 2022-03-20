using UnityEngine;
public class RestoreProgressManager.Progression : JsonSerializable<RestoreProgressManager.Progression>
{
    // Fields
    private System.DateTime <lastPlayed>k__BackingField;
    private int <level>k__BackingField;
    private decimal <coins>k__BackingField;
    private decimal <goldenCurrency>k__BackingField;
    
    // Properties
    public System.DateTime lastPlayed { get; set; }
    public int level { get; set; }
    public decimal coins { get; set; }
    public decimal goldenCurrency { get; set; }
    
    // Methods
    public System.DateTime get_lastPlayed()
    {
        return (System.DateTime)this.<lastPlayed>k__BackingField;
    }
    public void set_lastPlayed(System.DateTime value)
    {
        this.<lastPlayed>k__BackingField = value;
    }
    public int get_level()
    {
        return (int)this.<level>k__BackingField;
    }
    public void set_level(int value)
    {
        this.<level>k__BackingField = value;
    }
    public decimal get_coins()
    {
        return new System.Decimal() {flags = this.<coins>k__BackingField, hi = this.<coins>k__BackingField};
    }
    public void set_coins(decimal value)
    {
        this.<coins>k__BackingField = value;
        mem[1152921517625779108] = value.lo;
        mem[1152921517625779112] = value.mid;
    }
    public decimal get_goldenCurrency()
    {
        return new System.Decimal() {flags = this.<goldenCurrency>k__BackingField, hi = this.<goldenCurrency>k__BackingField};
    }
    public void set_goldenCurrency(decimal value)
    {
        this.<goldenCurrency>k__BackingField = value;
        mem[1152921517626003124] = value.lo;
        mem[1152921517626003128] = value.mid;
    }
    public void ParseDic(System.Collections.Generic.Dictionary<string, object> obj)
    {
        decimal val_2 = System.Decimal.Parse(s:  obj.Item["last_played"]);
        System.DateTime val_3 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        this.<lastPlayed>k__BackingField = val_3;
        this.<level>k__BackingField = System.Int32.Parse(s:  obj.Item["level"]);
        decimal val_7 = System.Decimal.Parse(s:  obj.Item["coins"]);
        this.<coins>k__BackingField = val_7;
        mem[1152921517626135684] = val_7.lo;
        mem[1152921517626135688] = val_7.mid;
        decimal val_9 = System.Decimal.Parse(s:  obj.Item["golden_currency"]);
        this.<goldenCurrency>k__BackingField = val_9;
        mem[1152921517626135700] = val_9.lo;
        mem[1152921517626135704] = val_9.mid;
    }
    public RestoreProgressManager.Progression()
    {
    
    }

}
