using UnityEngine;
public class GoldenWordStreakStatView : GoldenApplesStatView
{
    // Methods
    private void OnWordStreakUpdated()
    {
        goto typeof(GoldenWordStreakStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        return System.Decimal.op_Implicit(value:  WordStreak.ApplesFromStreak);
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "OnWordStreakUpdated";
    }
    protected override void OnTouchAreaClicked()
    {
    
    }
    public GoldenWordStreakStatView()
    {
    
    }

}
