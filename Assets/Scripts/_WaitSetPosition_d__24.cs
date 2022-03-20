using UnityEngine;
private sealed class WGHintButtonDemoPopup.<WaitSetPosition>d__24 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGHintButtonDemoPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGHintButtonDemoPopup.<WaitSetPosition>d__24(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_5;
        int val_6;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_5 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_6 = 1;
        this.<>2__current = val_5;
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        val_5 = this.<>4__this;
        this.<>1__state = 0;
        this.<>4__this.Transform_UseHint.gameObject.SetActive(value:  true);
        UnityEngine.Coroutine val_4 = val_5.StartCoroutine(routine:  val_5.HoldPosition());
        label_2:
        val_6 = 0;
        return (bool)val_6;
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
