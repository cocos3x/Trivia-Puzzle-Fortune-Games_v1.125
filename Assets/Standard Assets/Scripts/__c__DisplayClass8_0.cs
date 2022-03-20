using UnityEngine;
private sealed class ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0
{
    // Fields
    public TMPro.TextMeshProUGUI target;
    
    // Methods
    public ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0()
    {
    
    }
    internal int <DOMaxVisibleCharacters>b__0()
    {
        if(this.target != null)
        {
                return (int)this;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOMaxVisibleCharacters>b__1(int x)
    {
        if(this.target != null)
        {
                this.target.maxVisibleCharacters = x;
            return;
        }
        
        throw new NullReferenceException();
    }

}
