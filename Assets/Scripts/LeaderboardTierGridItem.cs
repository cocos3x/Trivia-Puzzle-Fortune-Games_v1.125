using UnityEngine;
public class LeaderboardTierGridItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text tierRank;
    private UnityEngine.UI.Text tierReward;
    
    // Methods
    public void UpdateTier(LeaderboardTier tier)
    {
        UnityEngine.UI.Text val_5;
        if(tier.upperLevel != (tier + 16 + 4))
        {
            goto label_2;
        }
        
        val_5 = this.tierRank;
        string val_1 = tier + 16.ToString();
        if(val_5 != null)
        {
            goto label_6;
        }
        
        label_2:
        val_5 = this.tierRank;
        if((tier + 16 + 4) == 1)
        {
            goto label_5;
        }
        
        string val_2 = tier.upperLevel + "-"("-") + tier.lowerLevel;
        if(val_5 != null)
        {
            goto label_6;
        }
        
        label_5:
        string val_3 = tier.upperLevel + "+"("+");
        label_6:
        string val_4 = tier.reward.ToString();
    }
    public LeaderboardTierGridItem()
    {
    
    }

}
