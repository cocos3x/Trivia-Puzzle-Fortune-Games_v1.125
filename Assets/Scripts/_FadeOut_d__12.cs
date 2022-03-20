using UnityEngine;
private sealed class Music.<FadeOut>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Music <>4__this;
    private float <duration>5__2;
    private float <t>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Music.<FadeOut>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        double val_2;
        var val_3;
        float val_4;
        var val_5;
        int val_6;
        if((this.<>1__state) == 1)
        {
            goto label_0;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_1;
        }
        
        val_2 = 5.26354424712089E-315;
        val_3 = this;
        val_4 = 0f;
        this.<duration>5__2 = 1f;
        this.<t>5__3 = 0f;
        val_5 = 1152921515394874268;
        this.<>1__state = 0;
        goto label_3;
        label_0:
        val_5 = this;
        val_4 = this.<t>5__3;
        this.<>1__state = 0;
        val_3 = 1152921515394874268;
        val_2 = this.<duration>5__2;
        if(val_4 <= val_2)
        {
            goto label_3;
        }
        
        this.<>4__this.audioSource.Stop();
        label_1:
        val_6 = 0;
        return (bool)val_6;
        label_3:
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 / (this.<duration>5__2);
        val_1 = val_4 + val_1;
        this.<t>5__3 = val_1;
        val_1 = 1f - val_1;
        this.<>4__this.audioSource.volume = val_1;
        val_6 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_6;
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
