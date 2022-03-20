using UnityEngine;
public class GemsStatView : CurrencyStatView
{
    // Fields
    public const string GEM_STAT_UPDATE = "GemStatViewUpdate";
    
    // Properties
    protected override CurrencyType getMyCurrency { get; }
    
    // Methods
    private void GemStatViewUpdate(Notification notif)
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
        goto typeof(GemsStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        int val_4;
        var val_5;
        int val_6;
        var val_7;
        val_4 = this;
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41975808, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
        }
        
        Player val_2 = App.Player;
        val_4 = val_2._gems;
        val_6 = val_4;
        val_7 = 0;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_6);
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    protected override void OnTouchAreaClicked()
    {
    
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "GemStatViewUpdate";
    }
    protected override CurrencyType get_getMyCurrency()
    {
        return 1;
    }
    public GemsStatView()
    {
    
    }

}
