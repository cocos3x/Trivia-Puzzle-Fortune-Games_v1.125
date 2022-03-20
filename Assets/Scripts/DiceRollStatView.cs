using UnityEngine;
public class DiceRollStatView : CurrencyStatView
{
    // Methods
    private void OnDiceRollsBalanceUpdated(Notification notif)
    {
        var val_4;
        if(notif.data != null)
        {
                val_4 = (System.Boolean.Parse(value:  notif.data.ToString())) ^ 1;
        }
        else
        {
                val_4 = 1;
        }
        
        var val_3 = val_4 & 1;
        goto typeof(DiceRollStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        int val_4;
        var val_5;
        decimal val_6;
        var val_7;
        var val_8;
        val_4 = this;
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
            goto label_2;
        }
        
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41975808, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_5;
        }
        
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
        label_2:
        val_4 = 1152921504617017344;
        val_8 = null;
        val_8 = null;
        val_6 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
        label_5:
        val_4 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        val_6 = val_4;
        val_7 = 0;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_6);
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "OnDiceRollsBalanceUpdated";
    }
    protected override void OnTouchAreaClicked()
    {
    
    }
    public DiceRollStatView()
    {
    
    }

}
