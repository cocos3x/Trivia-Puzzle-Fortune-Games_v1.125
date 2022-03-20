using UnityEngine;
public class Sound : MonoBehaviour
{
    // Fields
    public UnityEngine.AudioSource audioSource;
    public UnityEngine.AudioSource loopAudioSource;
    public UnityEngine.AudioClip[] buttonClips;
    public UnityEngine.AudioClip[] otherClips;
    public UnityEngine.AudioClip coinDeposit;
    public UnityEngine.AudioClip coinCollect;
    private static Sound _instance;
    
    // Properties
    public static Sound instance { get; set; }
    
    // Methods
    public static Sound get_instance()
    {
        Sound val_3 = Sound._instance;
        if((UnityEngine.Object.op_Implicit(exists:  val_3 = Sound._instance)) == true)
        {
                return (Sound)Sound._instance;
        }
        
        Sound val_2 = null;
        val_3 = val_2;
        val_2 = new Sound();
        Sound._instance = val_3;
        return (Sound)Sound._instance;
    }
    public static void set_instance(Sound value)
    {
        Sound._instance = value;
    }
    private void Awake()
    {
        Sound._instance = this;
    }
    private void Start()
    {
        this.UpdateSetting();
    }
    public bool IsMuted()
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        bool val_1 = IsEnabled();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsEnabled()
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        return CPlayerPrefs.GetBool(key:  "sound_enabled", defaultValue:  true);
    }
    public void SetEnabled(bool enabled)
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        CPlayerPrefs.SetBool(key:  "sound_enabled", value:  enabled);
        this.UpdateSetting();
    }
    public void Play(UnityEngine.AudioClip clip)
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        this.audioSource.pitch = 1f;
        this.audioSource.PlayOneShot(clip:  clip);
    }
    public void Play(UnityEngine.AudioClip clip, float pitch)
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        this.audioSource.pitch = pitch;
        this.audioSource.PlayOneShot(clip:  clip);
    }
    public void Play(UnityEngine.AudioSource audioSource)
    {
        UnityEngine.Debug.LogError(message:  "THIS CLASS IS BEING DEPRECATED! PLEASE USE WGAUDIOCONTROLLER INSTEAD.");
        if(IsEnabled() == false)
        {
                return;
        }
        
        audioSource.Play();
    }
    public void PlayButton(Sound.Button type = 0)
    {
        this.Play(clip:  this.buttonClips[type]);
    }
    public void Play(Sound.Others type, float volume = 1)
    {
        this.audioSource.volume = volume;
        this.Play(clip:  this.otherClips[type]);
    }
    public void PlayLooping(Sound.Others type, float volume = 1)
    {
        this.loopAudioSource.volume = volume;
        this.loopAudioSource.PlayOneShot(clip:  this.otherClips[type]);
    }
    public void StopLooping()
    {
        if(this.loopAudioSource != null)
        {
                this.loopAudioSource.Stop();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void UpdateSetting()
    {
        this.audioSource.mute = this.IsMuted();
        this.loopAudioSource.mute = this.IsMuted();
    }
    public Sound()
    {
    
    }

}
