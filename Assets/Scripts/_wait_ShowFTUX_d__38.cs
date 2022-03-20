using UnityEngine;
private sealed class WGFTUXManager.<wait_ShowFTUX>d__38 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGFTUXManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGFTUXManager.<wait_ShowFTUX>d__38(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Object val_10;
        int val_11;
        val_10 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_11 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        val_10 = WordRegion.instance;
        if(val_10 == 0)
        {
            goto label_13;
        }
        
        System.Collections.Generic.List<System.String> val_5 = WordRegion.instance.GetCompletedWords();
        label_2:
        val_11 = 0;
        return (bool)val_11;
        label_13:
        val_10 = 1152921513412338272;
        MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
        GameBehavior val_7 = App.getBehavior;
        val_11 = 0;
        this.<>4__this.currDemoWindow = MonoSingleton<WGWindowManager>.Instance.GetWindow<FTUXDemoWindow>();
        return (bool)val_11;
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
