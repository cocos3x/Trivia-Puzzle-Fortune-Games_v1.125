using UnityEngine;
public class SpinsStatView : CurrencyStatView
{
    // Fields
    public const string SPIN_STAT_UPDATE = "OnSpinAmountUpdate";
    
    // Properties
    protected override CurrencyType getMyCurrency { get; }
    
    // Methods
    private void OnSpinAmountUpdate(Notification notif)
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
        goto typeof(SpinsStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        int val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = this;
        val_3 = 1152921516740096404;
        val_4 = null;
        val_4 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41967616, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
                return new System.Decimal() {flags = val_2, hi = val_2, lo = mem[1152921504617021472], mid = mem[1152921504617021472]};
        }
        
        val_5 = null;
        val_5 = null;
        val_2 = 1152921504617021464;
        val_3 = 1152921504617021472;
        return new System.Decimal() {flags = val_2, hi = val_2, lo = mem[1152921504617021472], mid = mem[1152921504617021472]};
    }
    protected override void OnTouchAreaClicked()
    {
    
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "OnSpinAmountUpdate";
    }
    protected override CurrencyType get_getMyCurrency()
    {
        return 3;
    }
    public SpinsStatView()
    {
    
    }

}
