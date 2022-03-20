using UnityEngine;
private sealed class HintReminderAnimation.<ShineRoutine>d__11 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public HintReminderAnimation <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public HintReminderAnimation.<ShineRoutine>d__11(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_1;
        UnityEngine.WaitForSeconds val_2;
        if((this.<>1__state) == 2)
        {
            goto label_0;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_1 = 1;
        this.<>4__this.shineImage.enabled = true;
        this.<>4__this.shineImage.CrossFadeAlpha(alpha:  1f, duration:  0.3f, ignoreTimeScale:  true);
        val_2 = this.<>4__this.transitionTime;
        this.<>1__state = val_1;
        goto label_6;
        label_1:
        this.<>1__state = 0;
        val_1 = 1;
        this.<>4__this.shineImage.CrossFadeAlpha(alpha:  0f, duration:  0.5f, ignoreTimeScale:  true);
        val_2 = this.<>4__this.transitionTime;
        this.<>1__state = 2;
        label_6:
        this.<>2__current = val_2;
        return (bool)val_1;
        label_0:
        this.<>1__state = 0;
        this.<>4__this.shineImage.enabled = false;
        label_2:
        val_1 = 0;
        return (bool)val_1;
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
