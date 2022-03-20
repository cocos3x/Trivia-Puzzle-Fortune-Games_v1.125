using UnityEngine;
public class TRVLeaderboardUIMemberGridItem : LeaderboardUIMemberGridItem
{
    // Fields
    private UnityEngine.Sprite firstPlaceBadge;
    private UnityEngine.Sprite secondPlaceBadge;
    private UnityEngine.Sprite thirdPlaceBadge;
    private UnityEngine.UI.Image awardImage;
    
    // Methods
    public override void UpdateUIFromMember(LeaderboardPlayerInfo info)
    {
        UnityEngine.Sprite val_6;
        this.UpdateUIFromMember(info:  info);
        string val_1 = info.ToString(format:  "#,##0");
        UnityEngine.GameObject val_2 = this.awardImage.gameObject;
        val_2.SetActive(value:  (info < 4) ? 1 : 0);
        val_2.gameObject.SetActive(value:  (info > 3) ? 1 : 0);
        if(info > 3)
        {
                return;
        }
        
        if(info == 1)
        {
                val_6 = this.firstPlaceBadge;
        }
        else
        {
                if(info == 2)
        {
                val_6 = this.secondPlaceBadge;
        }
        else
        {
                if(info != 3)
        {
                return;
        }
        
            val_6 = this.thirdPlaceBadge;
        }
        
        }
        
        this.awardImage.sprite = val_6;
    }
    public TRVLeaderboardUIMemberGridItem()
    {
    
    }

}
