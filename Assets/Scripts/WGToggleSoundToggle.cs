using UnityEngine;
public class WGToggleSoundToggle : WGMyToggle
{
    // Fields
    private UnityEngine.UI.Toggle musicToggle;
    
    // Methods
    protected override void Start()
    {
        this.Start();
        if(41963520 != 0)
        {
                isOn = (~(MonoSingleton<WGAudioController>.Instance.IsSoundEnabled())) & 1;
            this.UpdateVisual(state:  ~(val_3) + 280);
            mem[1152921517702387760] = 1;
        }
        
        this.musicToggle = this.transform.parent.GetComponentInChildren<WGToggleMusicToggle>().GetComponent<UnityEngine.UI.Toggle>();
    }
    public override void OnToggleChange(bool state)
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        state = (~state) & 1;
        val_1.sound.SetEnabled(enabled:  state, isTracking:  false);
        if(((~state) & 1) == 0)
        {
                if(this.musicToggle != 0)
        {
                this.musicToggle.isOn = true;
        }
        
        }
        
        this.OnToggleChange(state:  state);
    }
    public WGToggleSoundToggle()
    {
    
    }

}
