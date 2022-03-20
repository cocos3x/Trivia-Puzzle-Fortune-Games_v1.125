using UnityEngine;
private sealed class ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0
{
    // Fields
    public TMPro.TextMeshProUGUI target;
    
    // Methods
    public ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0()
    {
    
    }
    internal UnityEngine.Color <DOFaceFade>b__0()
    {
        UnityEngine.Color32 val_1 = this.target.faceColor;
        val_1.r = val_1.r & 4294967295;
        return UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_1.r, g = val_1.r, b = val_1.r, a = val_1.r});
    }
    internal void <DOFaceFade>b__1(UnityEngine.Color x)
    {
        UnityEngine.Color32 val_1 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = x.r, g = x.g, b = x.b, a = x.a});
        this.target.faceColor = new UnityEngine.Color32() {r = val_1.r & 4294967295, g = val_1.r & 4294967295, b = val_1.r & 4294967295, a = val_1.r & 4294967295};
    }

}
