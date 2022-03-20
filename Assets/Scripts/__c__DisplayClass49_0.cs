using UnityEngine;
private sealed class Guild.<>c__DisplayClass49_0
{
    // Fields
    public int id;
    
    // Methods
    public Guild.<>c__DisplayClass49_0()
    {
    
    }
    internal bool <GetRankInGuildById>b__4(SLC.Social.Profile x)
    {
        if(x != null)
        {
                return (bool)(x.ServerId == this.id) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
