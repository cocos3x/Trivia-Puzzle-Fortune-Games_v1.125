using UnityEngine;
public class Music : MonoSingleton<Music>
{
    // Fields
    public UnityEngine.AudioSource audioSource;
    public UnityEngine.AudioClip[] musicClips;
    private Music.Type currentType;
    public bool fadeBetweenTracks;
    
    // Methods
    public bool IsMuted()
    {
        bool val_1 = this.IsEnabled();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsEnabled()
    {
        return CPlayerPrefs.GetBool(key:  "music_enabled", defaultValue:  true);
    }
    public void SetEnabled(bool enabled, bool updateMusic = False)
    {
        enabled = enabled;
        CPlayerPrefs.SetBool(key:  "music_enabled", value:  enabled);
        if(updateMusic == false)
        {
                return;
        }
        
        this.UpdateSetting();
    }
    public void Play(Music.Type type)
    {
        if(type == 0)
        {
                return;
        }
        
        if(this.currentType == type)
        {
                if(this.audioSource.isPlaying != false)
        {
                return;
        }
        
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.PlayNewMusic(type:  type));
    }
    public void Play(int trackNumber)
    {
        this.Play(type:  trackNumber);
    }
    public void Play()
    {
        this.Play(type:  this.currentType);
    }
    public void Stop()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FadeOut());
    }
    private System.Collections.IEnumerator FadeOut()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Music.<FadeOut>d__12();
    }
    private System.Collections.IEnumerator FadeIn()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Music.<FadeIn>d__13();
    }
    private System.Collections.IEnumerator PlayNewMusic(Music.Type type)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .type = type;
        return (System.Collections.IEnumerator)new Music.<PlayNewMusic>d__14();
    }
    private void UpdateSetting()
    {
        bool val_1 = UnityEngine.Object.op_Equality(x:  this.audioSource, y:  0);
        if(val_1 != false)
        {
                return;
        }
        
        if(val_1.IsEnabled() != false)
        {
                this.currentType = 0;
            this.Play(type:  this.currentType);
            return;
        }
        
        this.audioSource.Stop();
    }
    public Music()
    {
        this.fadeBetweenTracks = true;
    }

}
