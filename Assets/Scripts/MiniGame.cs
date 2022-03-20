using UnityEngine;
[Serializable]
public class MiniGame
{
    // Fields
    public string id;
    public string name;
    public string scene;
    public string sprite;
    public int unlockLevel;
    public string dlcPack;
    public int deeplinkIndex;
    public bool enabled;
    
    // Properties
    public int UnlockLevel { get; }
    
    // Methods
    public int get_UnlockLevel()
    {
        int val_7;
        GameEcon val_1 = App.getGameEcon;
        if((val_1.minigameUnlockLevels != null) && (val_1.minigameUnlockLevels.Count >= 1))
        {
                if((val_1.minigameUnlockLevels.ContainsKey(key:  this.id)) != false)
        {
                int val_5 = 0;
            bool val_6 = System.Int32.TryParse(s:  val_1.minigameUnlockLevels.Item[this.id], result: out  val_5);
            val_7 = val_5;
            if((val_7 & 2147483648) == 0)
        {
                return val_7;
        }
        
        }
        
        }
        
        val_7 = this.unlockLevel;
        return val_7;
    }
    public MiniGame()
    {
        this.enabled = true;
    }

}
