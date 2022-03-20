using UnityEngine;
public class WGAudioController : MonoSingleton<WGAudioController>
{
    // Fields
    public WGSoundController sound;
    public WGMusicController music;
    private WGAudioDefinition definition;
    
    // Methods
    public WGAudioDefinition GetDefinition()
    {
        if(this.definition != 0)
        {
                return (WGAudioDefinition)this.definition;
        }
        
        this.LoadDefinition();
        return (WGAudioDefinition)this.definition;
    }
    public bool IsSoundEnabled()
    {
        if(this.sound == 0)
        {
                return false;
        }
        
        return this.sound.IsEnabled();
    }
    public bool IsMusicEnabled()
    {
        if(this.music == 0)
        {
                return false;
        }
        
        return this.music.IsEnabled();
    }
    public bool IsMusicPlaying()
    {
        if(this.music == 0)
        {
                return false;
        }
        
        return this.music.IsPlaying();
    }
    public void ToggleMute(bool mute)
    {
        if(this.music != 0)
        {
                this.music.ToggleMute(mute:  mute);
        }
        
        if(this.sound == 0)
        {
                return;
        }
        
        this.sound.ToggleMute(mute:  mute);
    }
    private void LoadDefinition()
    {
        object val_7;
        var val_8;
        int val_9;
        val_7 = this;
        val_8 = null;
        val_8 = null;
        string val_1 = App.game.ToString();
        string[] val_2 = new string[5];
        val_9 = val_2.Length;
        val_2[0] = "game/";
        if(val_1 != null)
        {
                val_9 = val_2.Length;
        }
        
        val_2[1] = val_1;
        val_9 = val_2.Length;
        val_2[2] = "/";
        if(val_1 != null)
        {
                val_9 = val_2.Length;
        }
        
        val_2[3] = val_1;
        val_9 = val_2.Length;
        val_2[4] = "_AudioDefinition";
        WGAudioDefinition val_4 = UnityEngine.Resources.Load<WGAudioDefinition>(path:  +val_2);
        this.definition = val_4;
        if(val_4 != 0)
        {
                return;
        }
        
        val_7 = "Audio Definition not found! Please ensure you have included "("Audio Definition not found! Please ensure you have included ") + val_1 + "_AudioDefinition in \'Assets/WordGame/Games/"("_AudioDefinition in \'Assets/WordGame/Games/") + val_1;
        UnityEngine.Debug.LogError(message:  val_7);
    }
    public WGAudioController()
    {
    
    }

}
