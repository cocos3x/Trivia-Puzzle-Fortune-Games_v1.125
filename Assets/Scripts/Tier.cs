using UnityEngine;
[Serializable]
public class SeasonPassEcon.Tier
{
    // Fields
    public SeasonPassEcon.Item PassItem;
    public int AwardPass;
    public SeasonPassEcon.Item FreeItem;
    public int AwardFree;
    
    // Methods
    public bool IsTierChest(bool isPass)
    {
        var val_1 = (isPass != true) ? 16 : 24;
        return (bool)(null == 5) ? 1 : 0;
    }
    public SeasonPassEcon.Tier()
    {
    
    }

}
