using UnityEngine;
public class WGSoundController : MonoBehaviour
{
    // Fields
    private UnityEngine.AudioSource oneShotSource;
    private UnityEngine.AudioSource prioritySource;
    private WGAudioDefinition definition;
    
    // Methods
    private void Start()
    {
        T[] val_1 = this.GetComponents<UnityEngine.AudioSource>();
        if(val_1.Length != 0)
        {
                this.oneShotSource = val_1[0];
            if(val_1.Length >= 2)
        {
                this.prioritySource = val_1[1];
        }
        
        }
        
        this.definition = MonoSingleton<WGAudioController>.Instance.GetDefinition();
        this.UpdateSetting();
    }
    public void PlayButtonSound(WGAudioDefinition.ButtonClip type = 0, float pitch = 1, float vol = 1)
    {
        this.PlayOneShot(clip:  this.definition.buttonClips[type], pitch:  pitch, vol:  vol);
    }
    public void PlayGeneralSound(WGAudioDefinition.GeneralClip type, bool oneshot = True, float pitch = 1, float vol = 1)
    {
        UnityEngine.AudioClip val_1 = this.definition.generalClips[type];
        if(oneshot != false)
        {
                this.PlayOneShot(clip:  val_1, pitch:  pitch, vol:  vol);
            return;
        }
        
        this.Play(clip:  val_1, pitch:  pitch, vol:  vol);
    }
    public void PlayGameSpecificSound(string id, int clipIndex = 0)
    {
        .id = id;
        if((this.definition.gameSpecificClips.Find(match:  new System.Predicate<ClipObjects>(object:  new WGSoundController.<>c__DisplayClass6_0(), method:  System.Boolean WGSoundController.<>c__DisplayClass6_0::<PlayGameSpecificSound>b__0(ClipObjects x)))) != null)
        {
                this.PlayOneShot(clip:  val_3.clips[clipIndex], pitch:  1f, vol:  1f);
            return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "PlayGameSpecificSound for Sound ID: "("PlayGameSpecificSound for Sound ID: ") + (WGSoundController.<>c__DisplayClass6_0)[1152921517551286256].id((WGSoundController.<>c__DisplayClass6_0)[1152921517551286256].id) + " not found! Please ensure you that you are using the right Sound ID!"(" not found! Please ensure you that you are using the right Sound ID!"));
    }
    public void PlayGameSpecificSound(string id, bool randomIndex, float vol = 1)
    {
        var val_6;
        .id = id;
        if((this.definition.gameSpecificClips.Find(match:  new System.Predicate<ClipObjects>(object:  new WGSoundController.<>c__DisplayClass7_0(), method:  System.Boolean WGSoundController.<>c__DisplayClass7_0::<PlayGameSpecificSound>b__0(ClipObjects x)))) == null)
        {
            goto label_4;
        }
        
        if(randomIndex == false)
        {
            goto label_5;
        }
        
        val_6 = (long)UnityEngine.Random.Range(min:  0, max:  val_3.clips.Length);
        goto label_7;
        label_4:
        UnityEngine.Debug.LogWarning(message:  "PlayGameSpecificSound for Sound ID: "("PlayGameSpecificSound for Sound ID: ") + (WGSoundController.<>c__DisplayClass7_0)[1152921517551583600].id((WGSoundController.<>c__DisplayClass7_0)[1152921517551583600].id) + " not found! Please ensure you that you are using the right Sound ID!"(" not found! Please ensure you that you are using the right Sound ID!"));
        return;
        label_5:
        val_6 = 0;
        label_7:
        this.PlayOneShot(clip:  val_3.clips[val_6], pitch:  1f, vol:  vol);
    }
    public bool IsMuted()
    {
        bool val_1 = this.IsEnabled();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsEnabled()
    {
        return CPlayerPrefs.GetBool(key:  "sound_enabled", defaultValue:  true);
    }
    public bool IsSoundPlaying()
    {
        if(this.oneShotSource != null)
        {
                return this.oneShotSource.isPlaying;
        }
        
        throw new NullReferenceException();
    }
    public bool IsSoundPlaying(WGAudioDefinition.GeneralClip type)
    {
        UnityEngine.AudioSource val_4 = this.prioritySource;
        if(val_4 == 0)
        {
                return false;
        }
        
        val_4 = this.prioritySource.clip;
        if(val_4 != this.definition.generalClips[type])
        {
                return false;
        }
        
        return this.prioritySource.isPlaying;
    }
    public void SetEnabled(bool enabled, bool isTracking = True)
    {
        TrackerManager val_2;
        var val_3;
        var val_4;
        var val_5;
        string val_6;
        var val_7;
        val_2 = isTracking;
        if(val_2 == false)
        {
            goto label_1;
        }
        
        val_3 = null;
        val_3 = null;
        val_2 = App.trackerManager;
        val_4 = null;
        if(enabled == false)
        {
            goto label_7;
        }
        
        val_5 = null;
        val_6 = 1152921504883740984;
        if(val_2 != null)
        {
            goto label_10;
        }
        
        label_7:
        val_7 = null;
        val_6 = 1152921504883740992;
        label_10:
        val_2.track(eventName:  val_6);
        label_1:
        CPlayerPrefs.SetBool(key:  "sound_enabled", value:  enabled);
        this.UpdateSetting();
    }
    public void UpdateSetting()
    {
        this.oneShotSource.mute = (~this.IsEnabled()) & 1;
        UnityEngine.Object val_5 = 0;
        bool val_3 = UnityEngine.Object.op_Inequality(x:  this.prioritySource, y:  val_5);
        if(val_3 == false)
        {
                return;
        }
        
        val_5 = (~val_3.IsEnabled()) & 1;
        this.prioritySource.mute = val_5;
    }
    public void ToggleMute(bool mute)
    {
        if(mute != false)
        {
                UnityEngine.Debug.LogError(message:  "MUTE SOUND");
            this.oneShotSource.mute = true;
            if(this.prioritySource == 0)
        {
                return;
        }
        
            this.prioritySource.mute = true;
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "UNMUTE SOUND");
        this.UpdateSetting();
    }
    private void PlayOneShot(UnityEngine.AudioClip clip, float pitch = 1, float vol = 1)
    {
        if(clip == 0)
        {
                return;
        }
        
        this.oneShotSource.pitch = pitch;
        this.oneShotSource.volume = vol;
        this.oneShotSource.PlayOneShot(clip:  clip);
    }
    private void Play(UnityEngine.AudioClip clip, float pitch = 1, float vol = 1)
    {
        if(this.prioritySource == 0)
        {
                this.PlayOneShot(clip:  clip, pitch:  1f, vol:  1f);
            return;
        }
        
        this.prioritySource.Stop();
        this.prioritySource.pitch = pitch;
        this.prioritySource.volume = vol;
        this.prioritySource.clip = clip;
        this.prioritySource.Play();
    }
    public WGSoundController()
    {
    
    }

}
