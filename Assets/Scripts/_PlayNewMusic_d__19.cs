using UnityEngine;
private sealed class WGMusicController.<PlayNewMusic>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public MusicType type;
    public WGMusicController <>4__this;
    public int track;
    private System.Collections.Generic.List<UnityEngine.AudioClip> <musicClips>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGMusicController.<PlayNewMusic>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_11;
        int val_12;
        object val_13;
        int val_14;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_42;
        }
        
        this.<>1__state = 0;
        this.<musicClips>5__2 = (this.type == 0) ? this.<>4__this.definition.menuMusic : this.<>4__this.definition.gameplayMusic;
        int val_11 = this.type == null ? this.<>4__this.definition.menuMusic : this.<>4__this.definition.gameplayMusic + 24;
        if(val_11 < 1)
        {
            goto label_42;
        }
        
        val_11 = this.track - ((this.track / val_11) * val_11);
        this.track = val_11;
        object[] val_3 = new object[5];
        val_3[0] = "Playing new music (";
        val_11 = val_3.Length;
        val_3[1] = this.type;
        val_11 = val_3.Length;
        string val_12 = ") <COLOR=#DDFF99>";
        val_3[2] = val_12;
        if(val_12 <= this.track)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_12 = val_12 + ((this.track) << 3);
        val_12 = val_3.Length;
        val_3[3] = (") <COLOR=#DDFF99>" + (this.track) << 3) + 32.name;
        val_12 = val_3.Length;
        string val_13 = "</COLOR>";
        val_3[4] = val_13;
        val_13 = +val_3;
        if(val_13 <= this.track)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_13 = val_13 + ((this.track) << 3);
        UnityEngine.Debug.Log(message:  val_13, context:  ("</COLOR>" + (this.track) << 3) + 32);
        if((this.<>4__this.definition.fadeBetweenTracks) == false)
        {
            goto label_31;
        }
        
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.FadeOut());
        val_14 = 1;
        this.<>1__state = val_14;
        return (bool)val_14;
        label_1:
        this.<>1__state = 0;
        label_31:
        this.<>4__this.source.Stop();
        MusicType val_14 = this.type;
        this.<>4__this.currentMusicType = val_14;
        val_13 = this.track;
        this.<>4__this.currentTrack = val_13;
        if(val_14 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_14 = val_14 + ((this.track) << 3);
        this.<>4__this.source.clip = 0;
        if((this.<>4__this.source.IsEnabled()) != false)
        {
                this.<>4__this.source.Play();
        }
        
        if((this.<>4__this.definition.fadeBetweenTracks) != false)
        {
                UnityEngine.Coroutine val_10 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.FadeIn());
        }
        else
        {
                this.<>4__this.source.volume = this.<>4__this.musicVolume;
        }
        
        label_42:
        val_14 = 0;
        return (bool)val_14;
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
