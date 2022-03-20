using UnityEngine;
private sealed class ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0
{
    // Fields
    public TMPro.TextMeshProUGUI target;
    
    // Methods
    public ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0()
    {
    
    }
    internal string <DOText>b__0()
    {
        if(this.target != null)
        {
                return this.target.text;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOText>b__1(string x)
    {
        if(this.target != null)
        {
                this.target.text = x;
            return;
        }
        
        throw new NullReferenceException();
    }

}
