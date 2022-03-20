using UnityEngine;
public class RESRaidMadnessEventHandler : RaidMadnessEventHandler
{
    // Methods
    public override void OnAllReelsStopped()
    {
    
    }
    protected override void OnRaidCompleted(bool isRaidPerfect)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.HasCollectedAllRewards() == false)
        {
            goto typeof(RESRaidMadnessEventHandler).__il2cppRuntimeField_190;
        }
    
    }
    protected override UnityEngine.GameObject ShowRewardCollection()
    {
        return 0;
    }
    public RESRaidMadnessEventHandler()
    {
    
    }

}
