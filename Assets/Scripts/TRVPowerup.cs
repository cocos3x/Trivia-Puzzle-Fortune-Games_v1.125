using UnityEngine;
public class TRVPowerup
{
    // Fields
    public TRVPowerupType type;
    public PowerupEcon econ;
    public float remainingTime;
    public bool forceFree;
    
    // Methods
    public bool IsUnlocked()
    {
        return (bool)(App.Player >= this.econ.unlockLevel) ? 1 : 0;
    }
    public bool IsFreeCost()
    {
        UnityEngine.Object val_8;
        var val_9;
        val_8 = 0;
        if((MonoSingleton<TRVMainController>.Instance) == val_8)
        {
            goto label_5;
        }
        
        val_8 = 0;
        if((MonoSingleton<TRVMainController>.Instance.eventEntryType) == true)
        {
            goto label_10;
        }
        
        label_5:
        if(this.IsUnlocked() != false)
        {
                if(App.Player >= this.econ.freeLevelLimit)
        {
                return (bool)(this.forceFree == true) ? 1 : 0;
        }
        
            val_9 = 1;
            return (bool)(this.forceFree == true) ? 1 : 0;
        }
        
        label_10:
        val_9 = 0;
        return (bool)(this.forceFree == true) ? 1 : 0;
    }
    public TRVPowerup()
    {
    
    }

}
