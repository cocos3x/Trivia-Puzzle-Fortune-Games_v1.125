using UnityEngine;
public class WGDailyChallengeDayToggle : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text number;
    private UnityEngine.Color complete_text_color;
    private UnityEngine.Color incomplete_text_color;
    private UnityEngine.GameObject complete_group;
    private UnityEngine.GameObject incomplete_group;
    
    // Methods
    public void SetComplete(bool complete)
    {
        UnityEngine.Color val_3;
        var val_4;
        var val_5;
        var val_6;
        this.complete_group.SetActive(value:  complete);
        this.incomplete_group.SetActive(value:  (~complete) & 1);
        if(complete == false)
        {
            goto label_2;
        }
        
        val_3 = this.complete_text_color;
        val_4 = 1152921517772527716;
        val_5 = 1152921517772527720;
        val_6 = 1152921517772527724;
        if(this.number != null)
        {
            goto label_3;
        }
        
        label_2:
        val_3 = this.incomplete_text_color;
        val_4 = 1152921517772527732;
        val_5 = 1152921517772527736;
        val_6 = 1152921517772527740;
        label_3:
        this.number.color = new UnityEngine.Color() {r = this.incomplete_text_color.r, g = 2.681875E-25f, b = 2.681875E-25f, a = 2.681875E-25f};
    }
    public WGDailyChallengeDayToggle()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.complete_text_color = val_1;
        mem[1152921517772652004] = val_1.g;
        mem[1152921517772652008] = val_1.b;
        mem[1152921517772652012] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.gray;
        this.incomplete_text_color = val_2;
        mem[1152921517772652020] = val_2.g;
        mem[1152921517772652024] = val_2.b;
        mem[1152921517772652028] = val_2.a;
    }

}
