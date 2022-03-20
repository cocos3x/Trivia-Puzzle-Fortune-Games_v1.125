using UnityEngine;
public class DailyChallengeZooTilesConfig : ScriptableObject
{
    // Fields
    private UnityEngine.Sprite[] smallTiles;
    private UnityEngine.Sprite[] largeTiles;
    
    // Properties
    private System.Collections.Generic.Dictionary<DailyChallengeZooTilesConfig.DailyChallengeZooTileType, UnityEngine.Sprite[]> zooTilesPool { get; }
    
    // Methods
    private System.Collections.Generic.Dictionary<DailyChallengeZooTilesConfig.DailyChallengeZooTileType, UnityEngine.Sprite[]> get_zooTilesPool()
    {
        System.Collections.Generic.Dictionary<DailyChallengeZooTileType, UnityEngine.Sprite[]> val_1 = new System.Collections.Generic.Dictionary<DailyChallengeZooTileType, UnityEngine.Sprite[]>();
        val_1.Add(key:  0, value:  this.smallTiles);
        val_1.Add(key:  1, value:  this.largeTiles);
        return val_1;
    }
    public UnityEngine.Sprite GetSprite(DailyChallengeZooTilesConfig.DailyChallengeZooTileType type, string name)
    {
        UnityEngine.Sprite val_7;
        if(val_2.Length >= 1)
        {
                var val_7 = 0;
            do
        {
            val_7 = this.zooTilesPool.Item[type][val_7];
            if((val_7.name.ToLower().Contains(value:  name.ToLower())) == true)
        {
                return (UnityEngine.Sprite)val_7;
        }
        
            val_7 = val_7 + 1;
        }
        while(val_7 < val_2.Length);
        
        }
        
        val_7 = 0;
        return (UnityEngine.Sprite)val_7;
    }
    public DailyChallengeZooTilesConfig()
    {
    
    }

}
