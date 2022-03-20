using UnityEngine;
public class AggregateEventCalculator
{
    // Fields
    private decimal aggregate;
    private string name;
    
    // Properties
    public decimal Aggregate { get; }
    private System.Collections.Generic.Dictionary<string, object> JSONDictionary { get; }
    
    // Methods
    public decimal get_Aggregate()
    {
        return new System.Decimal() {flags = this.aggregate, hi = this.aggregate};
    }
    private System.Collections.Generic.Dictionary<string, object> get_JSONDictionary()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "name", value:  this.name);
        val_1.Add(key:  "aggregate", value:  this.aggregate);
        return val_1;
    }
    public AggregateEventCalculator(string name)
    {
        string val_1 = "aggregate_event_calculator_" + name;
        this.name = val_1;
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_1)) == false)
        {
                return;
        }
        
        this.Load();
    }
    private void Load()
    {
        var val_6;
        var val_7;
        object val_2 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this.name));
        val_6 = 0;
        new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  null);
        val_7 = null;
        val_7 = null;
        decimal val_5 = new twelvegigs.storage.JsonDictionary().getDecimal(key:  "aggregate", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.aggregate = val_5;
        mem[1152921515547933336] = val_5.lo;
        mem[1152921515547933340] = val_5.mid;
    }
    public void Calculate(decimal valueToAggregate, bool autoFlush = False)
    {
        string val_6;
        string val_7;
        int val_8;
        val_6 = autoFlush;
        val_7 = this;
        decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.aggregate, hi = this.aggregate, lo = X24, mid = X24}, d2:  new System.Decimal() {flags = valueToAggregate.flags, hi = valueToAggregate.hi, lo = valueToAggregate.lo, mid = valueToAggregate.mid});
        val_8 = val_1.flags;
        decimal val_2 = new System.Decimal(lo:  0, mid:  0, hi:  0, isNegative:  false, scale:  0);
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_8, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo})) == true)
        {
            goto label_3;
        }
        
        if(val_6 == false)
        {
            goto label_4;
        }
        
        this.aggregate = 0m;
        mem[1152921515548078344] = 0;
        val_6 = this.name;
        UnityEngine.PlayerPrefs.SetString(key:  val_6, value:  this);
        label_3:
        val_8 = this.aggregate;
        decimal val_4 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_8, hi = val_8, lo = val_6, mid = val_6}, d2:  new System.Decimal() {flags = valueToAggregate.flags, hi = valueToAggregate.hi, lo = valueToAggregate.lo, mid = valueToAggregate.mid});
        this.aggregate = val_4;
        mem[1152921515548078344] = val_4.lo;
        mem[1152921515548078348] = val_4.mid;
        UnityEngine.PlayerPrefs.SetString(key:  this.name, value:  this);
        return;
        label_4:
        val_7 = System.String.Format(format:  "Won\'t aggregate {0} any longer since it\'s reached max size. Did you forget to flush?", arg0:  this.name);
        UnityEngine.Debug.LogError(message:  val_7);
    }
    public void Flush()
    {
        this.aggregate = 0m;
        mem[1152921515548210824] = 0;
        UnityEngine.PlayerPrefs.SetString(key:  this.name, value:  this);
    }
    public override string ToString()
    {
        return MiniJSON.Json.Serialize(obj:  this.JSONDictionary);
    }

}
