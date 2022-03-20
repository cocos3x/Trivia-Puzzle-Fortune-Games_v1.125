using UnityEngine;
private sealed class WGMusicController.<FadeIn>d__18 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGMusicController <>4__this;
    private float <duration>5__2;
    private float <t>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGMusicController.<FadeIn>d__18(int <>1__state)
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
            goto label_0;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        this.<duration>5__2 = 1f;
        this.<t>5__3 = 0f;
        this.<>4__this.source.volume = 0f;
        goto label_4;
        label_0:
        this.<>1__state = 0;
        label_4:
        if((this.<t>5__3) <= (this.<>4__this.musicVolume))
        {
            goto label_6;
        }
        
        label_1:
        val_2 = 0;
        return (bool)val_2;
        label_6:
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 * (this.<>4__this.musicVolume);
        val_1 = val_1 / (this.<duration>5__2);
        val_1 = (this.<t>5__3) + val_1;
        this.<t>5__3 = val_1;
        this.<>4__this.source.volume = val_1;
        val_2 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_2;
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
