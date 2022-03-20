using UnityEngine;
private sealed class SRTabController.<>c__DisplayClass15_0
{
    // Fields
    public SRDebugger.UI.Other.SRTabController <>4__this;
    public SRDebugger.UI.Other.SRTab tab;
    
    // Methods
    public SRTabController.<>c__DisplayClass15_0()
    {
    
    }
    internal void <AddTab>b__0()
    {
        if((this.<>4__this) != null)
        {
                this.<>4__this.MakeActive(tab:  this.tab);
            return;
        }
        
        throw new NullReferenceException();
    }

}
