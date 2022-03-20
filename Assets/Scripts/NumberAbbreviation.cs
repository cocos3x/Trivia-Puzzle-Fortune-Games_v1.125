using UnityEngine;
public static class NumberAbbreviation
{
    // Methods
    public static string GetNumber(decimal num)
    {
        int val_24;
        var val_25;
        int val_26;
        int val_27;
        string val_29;
        int val_30;
        int val_31;
        val_24 = num.lo;
        decimal val_1 = new System.Decimal(value:  232);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = num.flags, hi = num.hi, lo = val_24, mid = num.mid}, d2:  new System.Decimal() {flags = val_1.flags, hi = val_1.flags, lo = val_1.lo, mid = val_1.lo})) != false)
        {
                string val_3 = num.flags.ToString();
            return (string)val_25;
        }
        
        val_26 = num.lo;
        decimal val_4 = new System.Decimal(value:  232);
        val_27 = val_4.lo;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = num.flags, hi = num.hi, lo = val_26, mid = num.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.flags, lo = val_27, mid = val_27})) == false)
        {
            goto label_10;
        }
        
        val_26 = num.lo;
        decimal val_6 = new System.Decimal(value:  1000000);
        val_27 = val_6.lo;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = num.flags, hi = num.hi, lo = val_26, mid = num.mid}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_27, mid = val_27})) == false)
        {
            goto label_10;
        }
        
        val_24 = num.flags;
        decimal val_8 = new System.Decimal(value:  232);
        decimal val_9 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_24, hi = num.hi, lo = num.lo, mid = num.mid}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo});
        string val_10 = val_9.flags.ToString(format:  "F1");
        val_29 = "K";
        goto label_22;
        label_10:
        val_30 = num.lo;
        decimal val_11 = new System.Decimal(value:  1000000);
        val_31 = val_11.lo;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = num.flags, hi = num.hi, lo = val_30, mid = num.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.flags, lo = val_31, mid = val_31})) == false)
        {
            goto label_19;
        }
        
        val_30 = num.lo;
        decimal val_13 = new System.Decimal(value:  1000000000);
        val_31 = val_13.lo;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = num.flags, hi = num.hi, lo = val_30, mid = num.mid}, d2:  new System.Decimal() {flags = val_13.flags, hi = val_13.flags, lo = val_31, mid = val_31})) == false)
        {
            goto label_19;
        }
        
        val_24 = num.flags;
        decimal val_15 = new System.Decimal(value:  1000000);
        decimal val_16 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_24, hi = num.hi, lo = num.lo, mid = num.mid}, d2:  new System.Decimal() {flags = val_15.flags, hi = val_15.flags, lo = val_15.lo, mid = val_15.lo});
        string val_17 = val_16.flags.ToString(format:  "F1");
        val_29 = "M";
        goto label_22;
        label_19:
        val_24 = num.flags;
        decimal val_18 = new System.Decimal(value:  1000000000);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_24, hi = num.hi, lo = num.lo, mid = num.mid}, d2:  new System.Decimal() {flags = val_18.flags, hi = val_18.flags, lo = val_18.lo, mid = val_18.lo})) == false)
        {
            goto label_25;
        }
        
        val_24 = num.flags;
        decimal val_20 = new System.Decimal(value:  1000000000);
        decimal val_21 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_24, hi = num.hi, lo = num.lo, mid = num.mid}, d2:  new System.Decimal() {flags = val_20.flags, hi = val_20.flags, lo = val_20.lo, mid = val_20.lo});
        val_29 = "B";
        label_22:
        string val_23 = val_21.flags.ToString(format:  "F1")(val_21.flags.ToString(format:  "F1")) + val_29;
        return (string)val_25;
        label_25:
        val_25 = "";
        return (string)val_25;
    }

}
