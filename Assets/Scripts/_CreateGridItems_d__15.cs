using UnityEngine;
private sealed class UIListViewController.<CreateGridItems>d__15 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UIListViewController <>4__this;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public UIListViewController.<CreateGridItems>d__15(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.GameObject val_7;
        int val_8;
        int val_6 = this.<>1__state;
        if(val_6 == 1)
        {
            goto label_1;
        }
        
        if(val_6 != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.ToggleLoadingPopup(state:  true);
        val_7 = 0;
        this.<i>5__2 = 0;
        if((this.<>4__this) != null)
        {
            goto label_4;
        }
        
        label_1:
        this.<>1__state = 0;
        goto label_6;
        label_2:
        val_8 = 0;
        return (bool)val_8;
        label_15:
        if(W21 >= val_6)
        {
            goto label_13;
        }
        
        if(val_6 <= W21)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + ((W21) << 3);
        if(((this.<>1__state + (W21) << 3) + 32) == 0)
        {
            goto label_13;
        }
        
        label_6:
        val_7 = X22 + 1;
        mem2[0] = val_7;
        label_4:
        if(val_7 < (this.<>4__this.curr_total))
        {
            goto label_15;
        }
        
        if((this.<>4__this.OnFinishedUIUpdate) != null)
        {
                this.<>4__this.OnFinishedUIUpdate.Invoke(obj:  true);
        }
        
        this.<>4__this.ToggleLoadingPopup(state:  false);
        val_8 = 0;
        this.<>4__this.creating = 0;
        return (bool)val_8;
        label_13:
        UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this);
        val_7 = val_2;
        val_2.transform.SetParent(parent:  this.<>4__this.gridRootTransform, worldPositionStays:  false);
        val_7.layer = this.<>4__this.gridRootTransform.gameObject.layer;
        this.<>4__this.memberGridItems.Add(item:  val_7);
        val_8 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_8;
        return (bool)val_8;
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
