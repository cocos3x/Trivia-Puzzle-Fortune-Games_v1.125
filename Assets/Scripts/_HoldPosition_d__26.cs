using UnityEngine;
private sealed class WGHintButtonDemoPopup.<HoldPosition>d__26 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGHintButtonDemoPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGHintButtonDemoPopup.<HoldPosition>d__26(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        var val_4;
        var val_5;
        object val_6;
        val_3 = 0;
        if((this.<>1__state) == 0)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        val_4 = 0;
        val_5 = 0;
        if((this.<>1__state) == 2)
        {
            goto label_3;
        }
        
        return (bool)val_5;
        label_2:
        this.<>1__state = 0;
        goto label_6;
        label_1:
        this.<>1__state = val_3;
        label_6:
        if((this.<>4__this.targetButtonObject) != 0)
        {
                UnityEngine.WaitForEndOfFrame val_2 = null;
            val_6 = val_2;
            val_2 = new UnityEngine.WaitForEndOfFrame();
            val_3 = 1;
        }
        else
        {
                val_6 = 0;
            val_3 = 2;
        }
        
        val_4 = 1;
        this.<>2__current = val_6;
        label_3:
        val_5 = val_4;
        this.<>1__state = val_3;
        return (bool)val_5;
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
