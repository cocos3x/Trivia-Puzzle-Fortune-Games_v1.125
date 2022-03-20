using UnityEngine;
public class TRVStreakStatView : CurrencyStatView
{
    // Fields
    private UnityEngine.GameObject textCrossout;
    
    // Properties
    protected override CurrencyType getMyCurrency { get; }
    
    // Methods
    protected override void OnEnable()
    {
        this.OnEnable();
        if((UnityEngine.Object.op_Implicit(exists:  this.textCrossout)) == false)
        {
                return;
        }
        
        this.textCrossout.SetActive(value:  false);
    }
    public void SetTextCrossout()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.textCrossout)) == false)
        {
                return;
        }
        
        this.textCrossout.SetActive(value:  true);
    }
    private void OnTRVStreakUpdate(Notification notif)
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
        goto typeof(TRVStreakStatView).__il2cppRuntimeField_180;
    }
    protected override void UpdateBalance(bool instantly = False)
    {
        var val_7 = this;
        instantly = instantly;
        this.UpdateBalance(instantly:  instantly);
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if((MonoSingleton<TRVStreakManager>.Instance.currentStreak) != val_3.maxStreak)
        {
                return;
        }
        
        val_7 = mem[val_3.maxStreak + 24];
        val_7 = val_3.maxStreak + 24;
        string val_6 = System.String.Format(format:  "{0} MAX", arg0:  MonoSingleton<TRVStreakManager>.Instance.currentStreak);
    }
    protected override decimal GetCountUpBalance()
    {
        int val_5;
        var val_6;
        int val_7;
        var val_8;
        val_5 = this;
        val_6 = null;
        val_6 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41975808, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid};
        }
        
        val_5 = MonoSingleton<TRVStreakManager>.Instance.currentStreak;
        val_7 = val_5;
        val_8 = 0;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_7);
        return new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid};
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "OnTRVStreakUpdate";
    }
    protected override void OnTouchAreaClicked()
    {
        var val_10 = null;
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) != 0)
        {
                GameBehavior val_3 = App.getBehavior;
        }
        else
        {
                GameBehavior val_4 = App.getBehavior;
        }
    
    }
    protected override CurrencyType get_getMyCurrency()
    {
        return 4;
    }
    public TRVStreakStatView()
    {
    
    }

}
