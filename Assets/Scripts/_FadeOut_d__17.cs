using UnityEngine;
private sealed class WGMusicController.<FadeOut>d__17 : IEnumerator<object>, IEnumerator, IDisposable
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
    public WGMusicController.<FadeOut>d__17(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_2;
        int val_3;
        if((this.<>1__state) == 1)
        {
            goto label_0;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        val_2 = 0f;
        this.<duration>5__2 = 1f;
        this.<t>5__3 = 0f;
        if((this.<>4__this) != null)
        {
            goto label_2;
        }
        
        label_0:
        val_2 = this.<t>5__3;
        this.<>1__state = 0;
        label_2:
        if(val_2 <= (this.<>4__this.musicVolume))
        {
            goto label_5;
        }
        
        this.<>4__this.source.Stop();
        label_1:
        val_3 = 0;
        return (bool)val_3;
        label_5:
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 * (this.<>4__this.musicVolume);
        val_1 = val_1 / (this.<duration>5__2);
        val_1 = val_2 + val_1;
        this.<t>5__3 = val_1;
        val_1 = (this.<>4__this.musicVolume) - val_1;
        this.<>4__this.source.volume = val_1;
        val_3 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_3;
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
