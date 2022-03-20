using UnityEngine;
private sealed class WGEventButton_Game.<RemoveFlyoutOnClick>d__68 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.GameObject flyout;
    public WGEventButton_Game <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventButton_Game.<RemoveFlyoutOnClick>d__68(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        goto label_5;
        label_1:
        this.<>1__state = 0;
        if(UnityEngine.Input.touchCount <= 0)
        {
                if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
            goto label_5;
        }
        
        }
        
        this.flyout.SetActive(value:  false);
        if((this.<>4__this.removeFlyoutCoroutine) != null)
        {
                this.<>4__this.StopCoroutine(routine:  this.<>4__this.removeFlyoutCoroutine);
            this.<>4__this.removeFlyoutCoroutine = 0;
        }
        
        MonoSingleton<WGWindowManager>.Instance.GetWindow<WGGameSceneFlyoutProxy>().Close();
        label_5:
        val_5 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_5;
        return (bool)val_5;
        label_2:
        val_5 = 0;
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
