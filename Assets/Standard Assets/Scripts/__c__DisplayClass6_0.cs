using UnityEngine;
private sealed class ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0
{
    // Fields
    public UnityEngine.Transform t;
    
    // Methods
    public ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0()
    {
    
    }
    internal UnityEngine.Vector3 <DOScale>b__0()
    {
        if(this.t != null)
        {
                return this.t.localScale;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOScale>b__1(UnityEngine.Vector3 x)
    {
        if(this.t != null)
        {
                this.t.localScale = new UnityEngine.Vector3() {x = x.x, y = x.y, z = x.z};
            return;
        }
        
        throw new NullReferenceException();
    }

}
