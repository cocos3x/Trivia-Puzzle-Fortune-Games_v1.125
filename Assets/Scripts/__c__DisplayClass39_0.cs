using UnityEngine;
private sealed class WUTLevelClearPopup.<>c__DisplayClass39_0
{
    // Fields
    public int currentTotal;
    public WUTLevelClearPopup <>4__this;
    
    // Methods
    public WUTLevelClearPopup.<>c__DisplayClass39_0()
    {
    
    }
    internal int <PlayAcornsCreditAnimation>b__0()
    {
        return (int)this.currentTotal;
    }
    internal void <PlayAcornsCreditAnimation>b__1(int x)
    {
        this.currentTotal = x;
    }
    internal void <PlayAcornsCreditAnimation>b__2()
    {
        string val_1 = this.currentTotal.ToString();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    internal void <PlayAcornsCreditAnimation>b__3()
    {
        goto typeof(WUTLevelClearPopup.<>c__DisplayClass39_0).__il2cppRuntimeField_190;
    }
    internal void <PlayAcornsCreditAnimation>b__4()
    {
        UnityEngine.Coroutine val_2 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.PlayEventProgressAnim());
    }

}
