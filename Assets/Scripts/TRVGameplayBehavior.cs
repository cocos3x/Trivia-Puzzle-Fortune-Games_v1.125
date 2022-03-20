using UnityEngine;
public class TRVGameplayBehavior : GameplayBehavior
{
    // Methods
    public override bool SupportAdvancedPlayerPopup()
    {
        return false;
    }
    public override string StoreBonusAmountText(decimal rawPercent)
    {
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = rawPercent.flags, hi = rawPercent.hi, lo = rawPercent.lo, mid = rawPercent.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Round(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        return (string)System.String.Format(format:  Localization.Localize(key:  "#_pct_extra_upper", defaultValue:  "{0}% EXTRA", useSingularKey:  false), arg0:  val_4.flags.ToString());
    }
    public override decimal CalculateStoreBonusPercent(PurchaseModel pack, int decimalPlaces)
    {
        var val_13;
        long val_19;
        float val_20;
        var val_21;
        decimal val_1 = pack.Credits;
        decimal val_2 = System.Decimal.op_Explicit(value:  pack.sale_price);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        decimal val_5 = App.getGameEcon.base099CreditPackSize;
        decimal val_6 = new System.Decimal(lo:  99, mid:  0, hi:  0, isNegative:  false, scale:  2);
        decimal val_7 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        decimal val_8 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        decimal val_9 = System.Decimal.Round(d:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, decimals:  2);
        float val_18 = 100f;
        val_18 = ((System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid})) + (-1f)) * val_18;
        float val_12 = val_18 / 5f;
        if(val_12 >= 0f)
        {
            goto label_9;
        }
        
        if((double)val_12 != (-0.5))
        {
            goto label_10;
        }
        
        val_19 = (long)val_13;
        val_20 = (float)val_13;
        val_21 = val_20 + (-1f);
        goto label_11;
        label_9:
        if((double)val_12 != 0.5)
        {
            goto label_12;
        }
        
        val_19 = (long)val_13;
        val_20 = (float)val_13;
        val_21 = val_20 + 1f;
        label_11:
        val_20 = ((val_19 & 1) != 0) ? (val_20) : (val_21);
        goto label_14;
        label_10:
        float val_19 = -0.5f;
        val_19 = val_12 + val_19;
        goto label_14;
        label_12:
        float val_20 = 0.5f;
        val_20 = val_12 + val_20;
        label_14:
        val_20 = val_20 * 5f;
        decimal val_15 = System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_20));
        decimal val_16;
        val_13 = 0;
        val_16 = new System.Decimal(value:  100);
        decimal val_17 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid}, d2:  new System.Decimal() {flags = val_16.flags, hi = val_16.flags, lo = val_16.lo, mid = val_16.lo});
        return new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid};
    }
    public TRVGameplayBehavior()
    {
    
    }

}
