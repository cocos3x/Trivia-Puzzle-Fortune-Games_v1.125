using UnityEngine;
private sealed class CategoryPacksManager.<>c__DisplayClass85_0
{
    // Fields
    public CategoryColorCode colorCode;
    
    // Methods
    public CategoryPacksManager.<>c__DisplayClass85_0()
    {
    
    }
    internal bool <GetColor>b__0(CategoryColor x)
    {
        if(x != null)
        {
                return (bool)(x.colorType == this.colorCode) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
