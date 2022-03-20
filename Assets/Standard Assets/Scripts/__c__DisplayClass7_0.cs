using UnityEngine;
private sealed class ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0
{
    // Fields
    public TMPro.TextMeshProUGUI target;
    
    // Methods
    public ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0()
    {
    
    }
    internal float <DOFontSize>b__0()
    {
        if(this.target != null)
        {
                return (float)S0;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOFontSize>b__1(float x)
    {
        if(this.target != null)
        {
                this.target.fontSize = x;
            return;
        }
        
        throw new NullReferenceException();
    }

}
