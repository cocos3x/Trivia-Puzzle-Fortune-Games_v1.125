using UnityEngine;
public class MinigameAudioController : MonoSingleton<MinigameAudioController>
{
    // Fields
    private MinigameAudioDefinition definition;
    private UnityEngine.AudioSource musicSource;
    private UnityEngine.AudioSource soundSource;
    private UnityEngine.AudioClip coinCollectSFX;
    
    // Methods
    private void Start()
    {
        UnityEngine.Object val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = this.definition;
        if(val_4 == 0)
        {
                val_4 = "No audio definition found!";
            UnityEngine.Debug.LogError(message:  val_4);
        }
        
        if(IsSoundEnabled() != false)
        {
                val_5 = this.soundSource;
            val_6 = 0;
        }
        else
        {
                val_6 = 1;
            val_5 = this.soundSource;
        }
        
        val_5.mute = true;
        if(val_5.IsMusicEnabled() != false)
        {
                val_7 = 0;
        }
        else
        {
                val_7 = 1;
        }
        
        this.musicSource.mute = true;
    }
    public void StartMusic(int clipIndex = 0)
    {
        if(this.IsMusicEnabled() == false)
        {
                return;
        }
        
        this.musicSource.Stop();
        MinigameAudioDefinition val_2 = this.definition;
        if(val_2 <= clipIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (clipIndex << 3);
        this.musicSource.clip = (this.definition + (clipIndex) << 3).buttonClickClips;
        this.musicSource.Play();
    }
    public void StopMusic()
    {
        if(this.musicSource != null)
        {
                this.musicSource.Stop();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void PlayButtonSound(int clipIndex = 0, float volumeScale = 1)
    {
        if(this.IsSoundEnabled() == false)
        {
                return;
        }
        
        MinigameAudioDefinition val_2 = this.definition;
        if(val_2 <= clipIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (clipIndex << 3);
        this.PlayOneShot(clip:  (this.definition + (clipIndex) << 3).buttonClickClips, volumeScale:  volumeScale);
    }
    public void PlayGameSpecificSound(string id, int clipIndex = 0, float volumeScale = 1)
    {
        MinigameAudioController.<>c__DisplayClass8_0 val_1 = new MinigameAudioController.<>c__DisplayClass8_0();
        .id = id;
        if(val_1.IsSoundEnabled() == false)
        {
                return;
        }
        
        if((this.definition.gameSpecificClips.Find(match:  new System.Predicate<ClipObjects>(object:  val_1, method:  System.Boolean MinigameAudioController.<>c__DisplayClass8_0::<PlayGameSpecificSound>b__0(ClipObjects x)))) != null)
        {
                this.PlayOneShot(clip:  val_4.clips[clipIndex], volumeScale:  volumeScale);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "PlayGameSpecificSound for Sound ID: "("PlayGameSpecificSound for Sound ID: ") + (MinigameAudioController.<>c__DisplayClass8_0)[1152921515822411952].id((MinigameAudioController.<>c__DisplayClass8_0)[1152921515822411952].id) + " not found! Please ensure you that you are using the right Sound ID!"(" not found! Please ensure you that you are using the right Sound ID!"));
    }
    public void PlayGameSpecificSound(string id, float volumeScale)
    {
        MinigameAudioController.<>c__DisplayClass9_0 val_1 = new MinigameAudioController.<>c__DisplayClass9_0();
        .id = id;
        if(val_1.IsSoundEnabled() == false)
        {
                return;
        }
        
        if((this.definition.gameSpecificClips.Find(match:  new System.Predicate<ClipObjects>(object:  val_1, method:  System.Boolean MinigameAudioController.<>c__DisplayClass9_0::<PlayGameSpecificSound>b__0(ClipObjects x)))) != null)
        {
                this.PlayOneShot(clip:  val_4.clips[0], volumeScale:  volumeScale);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "PlayGameSpecificSound for Sound ID: "("PlayGameSpecificSound for Sound ID: ") + (MinigameAudioController.<>c__DisplayClass9_0)[1152921515822672432].id((MinigameAudioController.<>c__DisplayClass9_0)[1152921515822672432].id) + " not found! Please ensure you that you are using the right Sound ID!"(" not found! Please ensure you that you are using the right Sound ID!"));
    }
    public void PlayGameSpecificSound(string id, bool randomIndex, float volumeScale = 1)
    {
        var val_7;
        MinigameAudioController.<>c__DisplayClass10_0 val_1 = new MinigameAudioController.<>c__DisplayClass10_0();
        .id = id;
        if(val_1.IsSoundEnabled() == false)
        {
                return;
        }
        
        if((this.definition.gameSpecificClips.Find(match:  new System.Predicate<ClipObjects>(object:  val_1, method:  System.Boolean MinigameAudioController.<>c__DisplayClass10_0::<PlayGameSpecificSound>b__0(ClipObjects x)))) == null)
        {
            goto label_5;
        }
        
        if(randomIndex == false)
        {
            goto label_6;
        }
        
        val_7 = (long)UnityEngine.Random.Range(min:  0, max:  val_4.clips.Length);
        goto label_8;
        label_5:
        UnityEngine.Debug.LogError(message:  "PlayGameSpecificSound for Sound ID: "("PlayGameSpecificSound for Sound ID: ") + (MinigameAudioController.<>c__DisplayClass10_0)[1152921515822969776].id((MinigameAudioController.<>c__DisplayClass10_0)[1152921515822969776].id) + " not found! Please ensure you that you are using the right Sound ID!"(" not found! Please ensure you that you are using the right Sound ID!"));
        return;
        label_6:
        val_7 = 0;
        label_8:
        this.PlayOneShot(clip:  val_4.clips[val_7], volumeScale:  volumeScale);
    }
    public void PlayCoinCollect()
    {
        if(this.IsSoundEnabled() == false)
        {
                return;
        }
        
        if(this.coinCollectSFX != 0)
        {
                this.PlayOneShot(clip:  this.coinCollectSFX, volumeScale:  1f);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "PlayCoinCollect SFX is null! Please hook up the WAD coin collect SFX to your audio manager");
    }
    private void PlayOneShot(UnityEngine.AudioClip clip, float volumeScale = 1)
    {
        this.soundSource.pitch = 1f;
        this.soundSource.PlayOneShot(clip:  clip, volumeScale:  volumeScale);
    }
    public bool IsSoundMuted()
    {
        bool val_1 = this.IsSoundEnabled();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsSoundEnabled()
    {
        return CPlayerPrefs.GetBool(key:  "sound_enabled", defaultValue:  true);
    }
    public bool IsMusicMuted()
    {
        bool val_1 = this.IsMusicEnabled();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsMusicEnabled()
    {
        return CPlayerPrefs.GetBool(key:  "music_enabled", defaultValue:  true);
    }
    public MinigameAudioController()
    {
    
    }

}
