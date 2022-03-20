using UnityEngine;
public class WUTGameAcornStatView : GoldenApplesStatView
{
    // Methods
    protected override decimal GetCountUpBalance()
    {
        int val_5;
        var val_6;
        int val_7;
        var val_8;
        var val_9;
        val_5 = this;
        val_6 = null;
        val_6 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41963520, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return new System.Decimal() {flags = val_7, hi = val_7, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_5 = 1152921504893161472;
        WordStreak val_2 = MonoSingleton<WordStreak>.Instance;
        if(val_2.currentLevel != null)
        {
                WordStreak val_3 = MonoSingleton<WordStreak>.Instance;
            val_5 = val_3.currentLevel.goldenApplesStreaks;
            val_7 = val_5;
            val_8 = 0;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_7);
            return new System.Decimal() {flags = val_7, hi = val_7, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        UnityEngine.Debug.LogWarning(message:  "Current level is null");
        val_9 = null;
        val_9 = null;
        val_7 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_7, hi = val_7, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    public WUTGameAcornStatView()
    {
    
    }

}
