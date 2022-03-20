using UnityEngine;
private sealed class GameEcon.<>c__DisplayClass315_0
{
    // Fields
    public int currPackId;
    
    // Methods
    public GameEcon.<>c__DisplayClass315_0()
    {
    
    }
    internal bool <ReadFromKnobs>b__0(CategoryPackInfo obj)
    {
        if(obj != null)
        {
                return (bool)(obj.packId == this.currPackId) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
