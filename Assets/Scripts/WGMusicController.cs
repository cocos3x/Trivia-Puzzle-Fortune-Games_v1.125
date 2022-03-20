using UnityEngine;
public class WGMusicController : MonoBehaviour
{
    // Fields
    public UnityEngine.AudioSource source;
    public WGAudioDefinition definition;
    private MusicType currentMusicType;
    private float musicVolume;
    private int currentTrack;
    
    // Properties
    public MusicType CurrentType { get; }
    public int CurrentTrack { get; }
    
    // Methods
    public MusicType get_CurrentType()
    {
        return (MusicType)this.currentMusicType;
    }
    public int get_CurrentTrack()
    {
        return (int)this.currentTrack;
    }
    public bool IsPlaying()
    {
        if(this.source != 0)
        {
                return this.source.isPlaying;
        }
        
        return false;
    }
    private void Start()
    {
        this.source = this.GetComponent<UnityEngine.AudioSource>();
        this.definition = MonoSingleton<WGAudioController>.Instance.GetDefinition();
        this.musicVolume = val_3.defaultMusicVolume;
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
    public void ToggleMute(bool mute)
    {
        object val_3;
        if(this.source == 0)
        {
                return;
        }
        
        this.source.mute = mute;
        if(mute != false)
        {
                val_3 = "MUTE MUSIC";
        }
        else
        {
                val_3 = "UNMUTE MUSIC";
        }
        
        UnityEngine.Debug.LogError(message:  val_3);
    }
    public void FadeOutMusic()
    {
        if(this.source == 0)
        {
                return;
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.FadeOut());
    }
    public void Play(MusicType type, int trackIndex = 0)
    {
        if(type == 2)
        {
                return;
        }
        
        if((this.currentMusicType == type) && (this.currentTrack == trackIndex))
        {
                if(this.source.isPlaying == true)
        {
                return;
        }
        
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.PlayNewMusic(type:  type, track:  trackIndex));
    }
    public void PlayRandomMusicTrack(MusicType type)
    {
        int val_4;
        MusicType val_5;
        if(type == 2)
        {
                return;
        }
        
        if(this.source == 0)
        {
                return;
        }
        
        if(type != 1)
        {
                if(type != 0)
        {
                return;
        }
        
            val_4 = UnityEngine.Random.Range(min:  0, max:  0);
            val_5 = 0;
        }
        else
        {
                val_5 = 1;
            val_4 = UnityEngine.Random.Range(min:  0, max:  0);
        }
        
        this.Play(type:  val_5, trackIndex:  val_4);
    }
    private System.Collections.IEnumerator FadeOut()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGMusicController.<FadeOut>d__17();
    }
    private System.Collections.IEnumerator FadeIn()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGMusicController.<FadeIn>d__18();
    }
    private System.Collections.IEnumerator PlayNewMusic(MusicType type, int track)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .type = type;
        .track = track;
        return (System.Collections.IEnumerator)new WGMusicController.<PlayNewMusic>d__19();
    }
    private void UpdateSetting()
    {
        bool val_1 = UnityEngine.Object.op_Equality(x:  this.source, y:  0);
        if(val_1 != false)
        {
                return;
        }
        
        if(val_1.IsEnabled() != false)
        {
                this.currentMusicType = 2;
            this.Play(type:  this.currentMusicType, trackIndex:  this.currentTrack);
            return;
        }
        
        SLCDebug.Log(logMessage:  "WGMusicController.UpdateSetting :: stop the music", colorHash:  "#FFFFFF", isError:  false);
        this.source.Stop();
    }
    private void StopSource()
    {
        if(this.source != null)
        {
                this.source.Stop();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void PlaySource()
    {
        if(this.source != null)
        {
                this.source.Play();
            return;
        }
        
        throw new NullReferenceException();
    }
    public WGMusicController()
    {
        this.currentMusicType = 2;
    }

}
