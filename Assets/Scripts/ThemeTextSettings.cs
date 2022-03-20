using UnityEngine;
public class ThemeTextSettings : ScriptableObject
{
    // Fields
    public UnityEngine.Font font;
    public UnityEngine.Color color;
    public int size;
    public bool outline;
    public UnityEngine.Color outlineColor;
    public UnityEngine.Vector2 outlineOffset;
    public bool shadow;
    public UnityEngine.Color shadowColor;
    public UnityEngine.Vector2 shadowOffset;
    public string useCaseName;
    public System.Collections.Generic.List<string> usedBy;
    
    // Methods
    public void Populate(UnityEngine.UI.Text newText)
    {
        var val_16;
        var val_17;
        this.usedBy.Add(item:  NGUITools.GetHierarchy(obj:  newText.gameObject));
        this.font = newText.font;
        UnityEngine.Color val_4 = newText.color;
        this.color = val_4;
        mem[1152921517090690836] = val_4.g;
        mem[1152921517090690840] = val_4.b;
        mem[1152921517090690844] = val_4.a;
        this.size = newText.fontSize;
        this.shadow = false;
        this.outline = false;
        if(val_6.Length == 0)
        {
                return;
        }
        
        if(val_6.Length < 1)
        {
                return;
        }
        
        var val_16 = 0;
        do
        {
            if(null != null)
        {
                val_16 = null;
        }
        
            val_17 = 0;
            if( != 0)
        {
                if(this.outline != false)
        {
                UnityEngine.Debug.LogError(message:  "Found more than one outline when constructing a new ThemeTextSetting for " + NGUITools.GetHierarchy(obj:  newText.gameObject)(NGUITools.GetHierarchy(obj:  newText.gameObject)));
        }
        
            this.outline = true;
            this.outlineColor = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_16 ? 1152921506205249424 : 0 + 32;
            this.outlineOffset = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_16 ? 1152921506205249424 : 0 + 48;
            mem[1152921517090690876] = (mem[null + 200] + (UnityEngine.UI.Outline.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == val_16 ? 1152921506205249424 : 0 + 48 + 4;
        }
        else
        {
                if(1152921506205249424 != 0)
        {
                if(this.shadow != false)
        {
                UnityEngine.Debug.LogError(message:  "Found more than one shadow when constructing a new ThemeTextSetting for " + NGUITools.GetHierarchy(obj:  newText.gameObject)(NGUITools.GetHierarchy(obj:  newText.gameObject)));
        }
        
            this.shadow = true;
            this.shadowColor = T[].__il2cppRuntimeField_byval_arg;
            this.shadowOffset = T[].__il2cppRuntimeField_this_arg;
        }
        
        }
        
            val_16 = val_16 + 1;
        }
        while(val_16 < (val_6.Length << ));
    
    }
    public bool Matches(ThemeTextSettings other)
    {
        if(this.font != other.font)
        {
                return false;
        }
        
        if((UnityEngine.Color.op_Inequality(lhs:  new UnityEngine.Color() {r = this.color}, rhs:  new UnityEngine.Color() {r = other.color})) == true)
        {
                return false;
        }
        
        var val_3 = (this.outline == true) ? 1 : 0;
        val_3 = val_3 ^ ((other.outline == true) ? 1 : 0);
        if((val_3 & 1) != 0)
        {
                return false;
        }
        
        var val_7 = ((this.shadow == false) ? 1 : 0) ^ ((other.shadow == true) ? 1 : 0);
        return false;
    }
    public string GetDescriptiveName(string colorHex)
    {
        int val_5;
        object[] val_1 = new object[4];
        val_5 = val_1.Length;
        val_1[0] = this.font.name;
        if(colorHex != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[1] = colorHex;
        object val_3 = (this.outline == false) ? "" : "_O";
        if(val_3 != 0)
        {
                val_5 = val_1.Length;
        }
        
        val_1[2] = val_3;
        object val_4 = (this.shadow == false) ? "" : "_S";
        if(val_4 != 0)
        {
                val_5 = val_1.Length;
        }
        
        val_1[3] = val_4;
        return System.String.Format(format:  "{0}_{1}{2}{3}", args:  val_1);
    }
    public ThemeTextSettings()
    {
        this.usedBy = new System.Collections.Generic.List<System.String>();
    }

}
