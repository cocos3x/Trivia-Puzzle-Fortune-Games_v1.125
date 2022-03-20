using UnityEngine;
public class ThemedText : MonoBehaviour
{
    // Fields
    public string textTypeTag;
    
    // Methods
    public void ApplyThemeTextSettings(ThemeTextSettings newText)
    {
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        string val_24;
        string val_25;
        UnityEngine.UI.Text val_1 = this.GetComponent<UnityEngine.UI.Text>();
        val_1.font = newText.font;
        val_1.color = new UnityEngine.Color() {r = newText.color};
        int val_18 = val_2.Length;
        val_19 = this.GetComponents<UnityEngine.UI.Shadow>();
        if(val_18 < 1)
        {
            goto label_4;
        }
        
        val_20 = 0;
        val_21 = 0;
        var val_19 = 0;
        val_18 = val_18 & 4294967295;
        label_36:
        val_22 = 0;
        if( == 0)
        {
            goto label_11;
        }
        
        enabled = newText.outline;
        if(newText.outline == false)
        {
            goto label_13;
        }
        
        effectColor = new UnityEngine.Color() {r = newText.outlineColor};
        effectDistance = new UnityEngine.Vector2() {x = newText.outlineOffset};
        val_21 = 1;
        goto label_31;
        label_11:
        if(1152921506205249424 == 0)
        {
            goto label_31;
        }
        
        1152921506205249424.enabled = newText.shadow;
        if(newText.shadow == false)
        {
            goto label_21;
        }
        
        1152921506205249424.effectColor = new UnityEngine.Color() {r = newText.shadowColor};
        1152921506205249424.effectDistance = new UnityEngine.Vector2() {x = newText.shadowOffset};
        val_20 = 1;
        goto label_31;
        label_13:
        if(UnityEngine.Application.isPlaying == true)
        {
            goto label_31;
        }
        
        string val_8 = NGUITools.GetHierarchy(obj:  this.gameObject);
        val_24 = newText.useCaseName;
        val_25 = "You can remove Outline from ";
        goto label_30;
        label_21:
        if(UnityEngine.Application.isPlaying == true)
        {
            goto label_31;
        }
        
        val_24 = newText.useCaseName;
        val_25 = "You can remove Shadow from ";
        label_30:
        UnityEngine.Debug.LogError(message:  val_25 + NGUITools.GetHierarchy(obj:  this.gameObject)(NGUITools.GetHierarchy(obj:  this.gameObject)) + " because it won\'t be used for " + val_24);
        label_31:
        val_19 = val_19 + 1;
        if(val_19 < (val_2.Length << ))
        {
            goto label_36;
        }
        
        if((val_21 & 1) == 0)
        {
            goto label_37;
        }
        
        goto label_40;
        label_4:
        val_20 = 0;
        if((0 & 1) != 0)
        {
            goto label_40;
        }
        
        label_37:
        if(newText.outline != false)
        {
                UnityEngine.UI.Outline val_14 = this.gameObject.AddComponent<UnityEngine.UI.Outline>();
            val_19 = val_14;
            val_14.effectColor = new UnityEngine.Color() {r = newText.outlineColor};
            val_19.effectDistance = new UnityEngine.Vector2() {x = newText.outlineOffset};
        }
        
        label_40:
        if(newText.shadow == false)
        {
                return;
        }
        
        if((val_20 ^ 1 & 1) == 0)
        {
                return;
        }
        
        UnityEngine.UI.Shadow val_17 = this.gameObject.AddComponent<UnityEngine.UI.Shadow>();
        val_17.effectColor = new UnityEngine.Color() {r = newText.shadowColor};
        val_17.effectDistance = new UnityEngine.Vector2() {x = newText.shadowOffset};
    }
    public void UpdateThemeTextSettings(ThemeTextSettings themeText)
    {
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        UnityEngine.UI.Text val_1 = this.GetComponent<UnityEngine.UI.Text>();
        themeText.font = val_1.font;
        UnityEngine.Color val_3 = val_1.color;
        themeText.color = val_3;
        mem2[0] = val_3.g;
        mem2[0] = val_3.b;
        mem2[0] = val_3.a;
        int val_12 = val_4.Length;
        if(val_12 < 1)
        {
            goto label_4;
        }
        
        val_13 = 0;
        val_14 = 0;
        var val_13 = 0;
        val_12 = val_12 & 4294967295;
        do
        {
            if(null != null)
        {
                val_12 = null;
        }
        
            val_15 = 0;
            if( != 0)
        {
                themeText.outline = enabled;
            val_14 = 1;
            themeText.outlineColor = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_12 ? 1152921506205249424 : 0 + 32;
            themeText.outlineOffset = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_12 ? 1152921506205249424 : 0 + 48;
            mem2[0] = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_12 ? 1152921506205249424 : 0 + 48 + 4;
        }
        else
        {
                if(1152921506205249424 != 0)
        {
                themeText.shadow = 1152921506205249424.enabled;
            themeText.shadowColor = T[].__il2cppRuntimeField_byval_arg;
            val_13 = 1;
            themeText.shadowOffset = T[].__il2cppRuntimeField_this_arg;
        }
        
        }
        
            val_13 = val_13 + 1;
        }
        while(val_13 < (val_4.Length << ));
        
        if((val_14 & 1) != 0)
        {
            goto label_28;
        }
        
        label_27:
        themeText.outline = false;
        label_28:
        if((val_13 & 1) != 0)
        {
                return;
        }
        
        themeText.shadow = false;
        return;
        label_4:
        if((0 & 1) == 0)
        {
            goto label_27;
        }
        
        goto label_28;
    }
    public ThemedText()
    {
        this.textTypeTag = "";
    }

}
