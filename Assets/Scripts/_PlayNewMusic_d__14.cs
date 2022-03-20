using UnityEngine;
private sealed class Music.<PlayNewMusic>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Music.Type type;
    public Music <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Music.<PlayNewMusic>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_9;
        int val_10;
        int val_11;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_37;
        }
        
        this.<>1__state = 0;
        object[] val_1 = new object[5];
        val_1[0] = "Playing new music (";
        val_9 = val_1.Length;
        val_1[1] = this.type;
        val_9 = val_1.Length;
        val_1[2] = ") <COLOR=#DDFF99>";
        val_10 = val_1.Length;
        val_1[3] = this.<>4__this.musicClips[this.type].name;
        val_10 = val_1.Length;
        val_1[4] = "</COLOR>";
        UnityEngine.Debug.Log(message:  +val_1, context:  this.<>4__this.musicClips[this.type]);
        if((this.<>4__this.fadeBetweenTracks) == false)
        {
            goto label_27;
        }
        
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.FadeOut());
        val_11 = 1;
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        label_27:
        this.<>4__this.audioSource.Stop();
        this.<>4__this.currentType = this.type;
        this.<>4__this.audioSource.clip = this.<>4__this.musicClips[this.type];
        if((this.<>4__this.audioSource.IsEnabled()) != false)
        {
                this.<>4__this.audioSource.Play();
        }
        
        if((this.<>4__this.fadeBetweenTracks) != false)
        {
                UnityEngine.Coroutine val_8 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.FadeIn());
        }
        else
        {
                this.<>4__this.audioSource.volume = 1f;
        }
        
        label_37:
        val_11 = 0;
        return (bool)val_11;
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
