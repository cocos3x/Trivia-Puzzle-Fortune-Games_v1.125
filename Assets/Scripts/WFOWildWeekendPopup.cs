using UnityEngine;
public class WFOWildWeekendPopup : WildWeekendPopup
{
    // Methods
    public override void Setup(int levelsCompleted, int totalLevels, bool hasCollected, GameEventRewardType RewardType, System.DateTime eventEndDate, System.Action collectCallback, System.Action firstSeenCallback, WildWeekendHandler handler)
    {
        var val_3 = this;
        hasCollected = hasCollected;
        this.Setup(levelsCompleted:  levelsCompleted, totalLevels:  totalLevels, hasCollected:  hasCollected, RewardType:  RewardType, eventEndDate:  new System.DateTime() {dateData = eventEndDate.dateData}, collectCallback:  collectCallback, firstSeenCallback:  firstSeenCallback, handler:  handler);
        if(totalLevels <= levelsCompleted)
        {
                return;
        }
        
        string val_2 = System.String.Format(format:  "Complete {0} levels and claim a huge coin reward!", arg0:  totalLevels.ToString());
    }
    public WFOWildWeekendPopup()
    {
    
    }

}
