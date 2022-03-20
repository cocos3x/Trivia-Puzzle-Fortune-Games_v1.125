using UnityEngine;
private sealed class WGWindowManager.<WaitingForGeneration>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGWindowManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGWindowManager.<WaitingForGeneration>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        if((this.<>1__state) < 2)
        {
                this.<>1__state = 0;
            GameBehavior val_1 = App.getBehavior;
            if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_3 = 1;
            this.<>2__current = new UnityEngine.WaitForEndOfFrame();
            this.<>1__state = val_3;
            return (bool)val_3;
        }
        
            this.<>4__this.ShowAvailablePopups(fromMinimize:  false, entry:  "OnScreenChanged:AfterGeneration");
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
