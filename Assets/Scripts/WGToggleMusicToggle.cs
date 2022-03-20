using UnityEngine;
public class WGToggleMusicToggle : WGMyToggle
{
    // Methods
    protected override void Start()
    {
        this.Start();
        if(41963520 == 0)
        {
                return;
        }
        
        isOn = (~(MonoSingleton<WGAudioController>.Instance.IsMusicEnabled())) & 1;
        this.UpdateVisual(state:  ~(val_3) + 280);
        mem[1152921517701673776] = 1;
    }
    public override void OnToggleChange(bool state)
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        state = (~state) & 1;
        val_1.music.SetEnabled(enabled:  state, updateMusic:  true);
        this.OnToggleChange(state:  state);
    }
    public WGToggleMusicToggle()
    {
    
    }

}
