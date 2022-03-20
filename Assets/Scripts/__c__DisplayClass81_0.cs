using UnityEngine;
private sealed class TRVLevelComplete.<>c__DisplayClass81_0
{
    // Fields
    public float progress;
    public TRVLevelComplete <>4__this;
    
    // Methods
    public TRVLevelComplete.<>c__DisplayClass81_0()
    {
    
    }
    internal void <PlayStreakAnimation>b__0(float x)
    {
        this.progress = x;
    }
    internal void <PlayStreakAnimation>b__1()
    {
        decimal val_1 = System.Convert.ToDecimal(value:  this.progress);
        GameEcon val_2 = App.getGameEcon;
        string val_4 = System.String.Format(format:  "{0}", arg0:  val_1.flags.ToString(format:  val_2.numberFormatInt));
    }
    internal void <PlayStreakAnimation>b__2()
    {
        this.<>4__this.Invoke(methodName:  "DisableAfter", time:  0.5f);
    }

}
