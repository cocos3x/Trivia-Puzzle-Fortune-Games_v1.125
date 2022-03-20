using UnityEngine;
public class MyButton : MonoBehaviour
{
    // Fields
    protected bool useCustomSound;
    protected UnityEngine.UI.Button button;
    
    // Methods
    protected virtual void Start()
    {
        UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
        this.button = val_1;
        if(val_1 == 0)
        {
                return;
        }
        
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(MyButton).__il2cppRuntimeField_188));
    }
    public virtual void OnButtonClick()
    {
        if((MonoSingleton<WGAudioController>.Instance) == 0)
        {
                return;
        }
        
        if(this.useCustomSound != false)
        {
                return;
        }
        
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
    }
    public MyButton()
    {
    
    }

}
