using UnityEngine;
public class CoinCurrencyStatView : CurrencyStatView
{
    // Fields
    public const string COINS_STAT_UPDATE = "CoinsStatViewUpdate";
    
    // Methods
    private void CoinsStatViewUpdate(Notification notif)
    {
        var val_10;
        var val_11;
        val_10 = this;
        if(notif.data != null)
        {
                val_11 = System.Boolean.Parse(value:  notif.data.ToString());
        }
        else
        {
                val_11 = 0;
        }
        
        if(W9 == 0)
        {
                return;
        }
        
        val_10 = ???;
        var val_3 = (val_11 == 0) ? 1 : 0;
        goto typeof(CoinCurrencyStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        decimal val_4;
        var val_5;
        var val_6;
        val_4 = this;
        val_5 = 1152921517459113940;
        val_6 = null;
        val_6 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41975808, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
                return new System.Decimal() {flags = val_2._credits.flags, hi = val_2._credits.flags, lo = 279072768, mid = 268435456};
        }
        
        val_4 = val_2._credits;
        val_5 = App.Player + 104;
        return new System.Decimal() {flags = val_2._credits.flags, hi = val_2._credits.flags, lo = 279072768, mid = 268435456};
    }
    protected override void OnTouchAreaClicked()
    {
        UnityEngine.Debug.LogWarning(message:  "TODO - CoinCurrencyStatView do something when touched?");
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "CoinsStatViewUpdate";
    }
    public CoinCurrencyStatView()
    {
        mem[1152921517459454192] = 1056964608;
        mem[1152921517459454208] = 1;
        this = new UnityEngine.MonoBehaviour();
    }

}
