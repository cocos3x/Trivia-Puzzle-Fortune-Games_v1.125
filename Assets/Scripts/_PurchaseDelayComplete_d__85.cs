using UnityEngine;
private sealed class GameStoreUI.<PurchaseDelayComplete>d__85 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float waitTime;
    public System.Action onCompleteAction;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GameStoreUI.<PurchaseDelayComplete>d__85(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_2 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.waitTime);
        this.<>1__state = val_2;
        return (bool)val_2;
        label_1:
        val_2 = this.onCompleteAction;
        this.<>1__state = 0;
        if(val_2 == null)
        {
                return (bool)val_2;
        }
        
        val_2.Invoke();
        label_2:
        val_2 = 0;
        return (bool)val_2;
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
