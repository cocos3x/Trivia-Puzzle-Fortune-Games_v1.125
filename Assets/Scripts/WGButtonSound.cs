using UnityEngine;
public class WGButtonSound : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    
    // Methods
    private void Start()
    {
        UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
        this.button = val_1;
        if((UnityEngine.Object.op_Implicit(exists:  val_1)) != false)
        {
                this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGButtonSound::PlaySound()));
            return;
        }
        
        this.enabled = false;
    }
    private void PlaySound()
    {
        if((MonoSingleton<WGAudioController>.Instance) == 0)
        {
                return;
        }
        
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
    }
    public WGButtonSound()
    {
    
    }

}
