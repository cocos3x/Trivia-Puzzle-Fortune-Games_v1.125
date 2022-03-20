using UnityEngine;
public class ChallengeTask
{
    // Fields
    public int id;
    public ChallengeType subject;
    public decimal progress;
    public decimal target;
    public System.DateTime lastCompletedAt;
    
    // Methods
    public void reset()
    {
        this.progress = 0m;
        mem[1152921516001961520] = 0;
    }
    public bool gainProgress(decimal amt)
    {
        decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = 41971712}, d2:  new System.Decimal() {flags = amt.flags, hi = amt.hi, lo = amt.lo, mid = amt.mid});
        this.progress = val_1;
        mem[1152921516002073520] = val_1.lo;
        mem[1152921516002073524] = val_1.mid;
        return System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this.target, hi = this.target, lo = amt.lo, mid = amt.mid});
    }
    public bool setProgress(decimal amt)
    {
        decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = 41971712}, d2:  new System.Decimal() {flags = amt.flags, hi = amt.hi, lo = amt.lo, mid = amt.mid});
        this.progress = val_1;
        mem[1152921516002185520] = val_1.lo;
        mem[1152921516002185524] = val_1.mid;
        return System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this.target, hi = this.target, lo = amt.lo, mid = amt.mid});
    }
    public float getPercent()
    {
        int val_6;
        decimal val_7;
        val_6 = this;
        val_7 = this.target;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_7, hi = val_7, lo = 41971712})) != false)
        {
                return (float)(float)System.Convert.ToDouble(value:  new System.Decimal() {flags = val_6, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        }
        
        decimal val_2 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = val_7, mid = val_7}, d2:  new System.Decimal() {flags = this.target, hi = this.target, lo = -1489451376, mid = 268435458});
        val_7 = System.Decimal.Zero;
        decimal val_3 = System.Math.Max(val1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, val2:  new System.Decimal() {flags = val_7, hi = val_7, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10});
        decimal val_4 = System.Math.Min(val1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, val2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        val_6 = val_4.flags;
        return (float)(float)System.Convert.ToDouble(value:  new System.Decimal() {flags = val_6, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
    }
    public bool isComplete()
    {
        return System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = this.target, hi = this.target, lo = -1489339376, mid = 268435458});
    }
    public void Complete(decimal currentIncrement, decimal currentMax)
    {
        decimal val_6;
        int val_7;
        if(this.isComplete() == false)
        {
                return;
        }
        
        val_6 = this.target;
        goto label_2;
        label_9:
        decimal val_2 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = X26, mid = X26}, d2:  new System.Decimal() {flags = this.target, hi = this.target, lo = val_6, mid = val_6});
        this.progress = val_2;
        mem[1152921516002521520] = val_2.lo;
        mem[1152921516002521524] = val_2.mid;
        decimal val_3 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.target, hi = this.target, lo = X9, mid = X9}, d2:  new System.Decimal() {flags = currentIncrement.flags, hi = currentIncrement.hi, lo = currentIncrement.lo, mid = currentIncrement.mid});
        decimal val_4 = System.Math.Min(val1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, val2:  new System.Decimal() {flags = currentMax.flags, hi = currentMax.hi, lo = currentMax.lo, mid = currentMax.mid});
        val_6 = val_4.flags;
        val_7 = val_4.lo;
        this.target = val_4;
        mem[1152921516002521536] = val_4.lo;
        mem[1152921516002521540] = val_4.mid;
        label_2:
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = this.progress, hi = this.progress, lo = X26, mid = X26}, d2:  new System.Decimal() {flags = val_6, hi = val_4.hi, lo = val_7, mid = val_4.mid})) == true)
        {
            goto label_9;
        }
    
    }
    public System.Collections.Generic.Dictionary<string, object> serialize()
    {
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "id", value:  this.id);
        val_1.Add(key:  "pr", value:  this.progress.ToString());
        val_1.Add(key:  "t", value:  this.target.ToString());
        val_6 = null;
        val_6 = null;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.lastCompletedAt}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return val_1;
        }
        
        val_1.Add(key:  "lc", value:  this.lastCompletedAt.ToString());
        return val_1;
    }
    public void deserialize(System.Collections.IDictionary data)
    {
        var val_11;
        var val_13;
        var val_15;
        object val_16;
        var val_18;
        var val_15 = 0;
        val_15 = val_15 + 1;
        val_11 = public System.Object System.Collections.IDictionary::get_Item(object key);
        int val_3 = System.Int32.Parse(s:  data.Item["id"]);
        this.id = val_3;
        this.subject = val_3;
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_11 = 0;
        val_13 = public System.Object System.Collections.IDictionary::get_Item(object key);
        decimal val_6 = System.Decimal.Parse(s:  data.Item["pr"]);
        this.progress = val_6;
        mem[1152921516002790816] = val_6.lo;
        mem[1152921516002790820] = val_6.mid;
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_13 = 0;
        val_15 = public System.Object System.Collections.IDictionary::get_Item(object key);
        decimal val_9 = System.Decimal.Parse(s:  data.Item["t"]);
        this.target = val_9;
        mem[1152921516002790832] = val_9.lo;
        mem[1152921516002790836] = val_9.mid;
        val_16 = "lc";
        var val_18 = 0;
        val_18 = val_18 + 1;
        val_15 = 4;
        val_18 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  val_16)) == false)
        {
                return;
        }
        
        val_16 = "lc";
        var val_19 = 0;
        val_19 = val_19 + 1;
        val_18 = 0;
        System.DateTime val_14 = SLCDateTime.Parse(dateTime:  data.Item[val_16]);
        this.lastCompletedAt = val_14;
    }
    public ChallengeTask()
    {
        var val_1;
        var val_2;
        val_1 = null;
        val_1 = null;
        this.target = System.Decimal.One;
        val_2 = null;
        val_2 = null;
        this.lastCompletedAt = System.DateTime.MinValue;
    }

}
