using UnityEngine;
public class WGMyToggle : MonoBehaviour
{
    // Fields
    protected UnityEngine.Sprite on;
    protected UnityEngine.Sprite off;
    protected UnityEngine.UI.Toggle toggle;
    protected bool initialized;
    
    // Methods
    protected virtual void Start()
    {
        UnityEngine.UI.Toggle val_1 = this.GetComponent<UnityEngine.UI.Toggle>();
        this.toggle = val_1;
        if(val_1 == 0)
        {
                return;
        }
        
        this.on = val_2 + 192;
        this.off = val_2 + 192;
        this.toggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  typeof(WGMyToggle).__il2cppRuntimeField_188));
        this.initialized = true;
    }
    public virtual void OnToggleChange(bool state)
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
        bool val_2 = state;
        goto typeof(WGMyToggle).__il2cppRuntimeField_190;
    }
    public virtual void UpdateVisual(bool state)
    {
        UnityEngine.Sprite val_2;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  41963520, y:  0);
        if(val_1 == false)
        {
                return;
        }
        
        if(state == false)
        {
            goto label_12;
        }
        
        val_2 = this.off;
        if(val_1 == true)
        {
            goto label_16;
        }
        
        return;
        label_12:
        val_2 = this.on;
        label_16:
        val_1.sprite = mem[this.on];
    }
    public WGMyToggle()
    {
    
    }

}
