using UnityEngine;
private sealed class DefinitionDisplay.<WaitThenFade>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DefinitionDisplay <>4__this;
    private float <progress>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DefinitionDisplay.<WaitThenFade>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_5;
        float val_6;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this.waitTime);
        this.<>1__state = val_5;
        return (bool)val_5;
        label_2:
        this.<>1__state = 0;
        this.<progress>5__2 = this.<>4__this.fadeTime;
        val_6 = this.<>4__this.fadeTime;
        goto label_7;
        label_1:
        this.<>1__state = 0;
        val_6 = this.<progress>5__2;
        label_7:
        if(val_6 > 0f)
        {
            goto label_9;
        }
        
        this.<>4__this.gameObject.SetActive(value:  false);
        label_3:
        val_5 = 0;
        return (bool)val_5;
        label_9:
        val_6 = val_6 / (this.<>4__this.fadeTime);
        this.<>4__this.group.alpha = val_6;
        float val_3 = UnityEngine.Time.fixedDeltaTime;
        val_3 = (this.<progress>5__2) - val_3;
        this.<progress>5__2 = val_3;
        this.<>2__current = new UnityEngine.WaitForFixedUpdate();
        this.<>1__state = 2;
        val_5 = 1;
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
