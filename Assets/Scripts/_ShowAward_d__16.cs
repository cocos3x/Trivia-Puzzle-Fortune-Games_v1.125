using UnityEngine;
private sealed class DeeplinkDelegate.<ShowAward>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DeeplinkDelegate <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DeeplinkDelegate.<ShowAward>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        bool val_3;
        DeeplinkComponent val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_3 = true;
        this.<>4__this.isShowingAward = val_3;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  7f);
        this.<>1__state = val_3;
        return (bool)val_3;
        label_1:
        this.<>1__state = 0;
        val_4 = this.<>4__this.deeplinkComponent;
        if((this.<>4__this.deeplinkComponent.helper.currentRewards) != null)
        {
                MonoSingleton<AwardController>.Instance.AddAwards(awards:  this.<>4__this.deeplinkComponent.helper.currentRewards);
            val_4 = this.<>4__this.deeplinkComponent;
        }
        
        val_3 = 0;
        this.<>4__this.deeplinkComponent.helper.currentRewards = 0;
        this.<>4__this.isShowingAward = false;
        return (bool)val_3;
        label_2:
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
