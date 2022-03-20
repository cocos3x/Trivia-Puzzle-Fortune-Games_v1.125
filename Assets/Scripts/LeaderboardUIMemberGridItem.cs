using UnityEngine;
public class LeaderboardUIMemberGridItem : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Text rank;
    protected AvatarSlotUGUI profileImage;
    protected UnityEngine.UI.Text profileName;
    protected UnityEngine.UI.Text apples;
    
    // Methods
    public virtual void UpdateUIFromMember(LeaderboardPlayerInfo info)
    {
        string val_1 = info.ToString();
        decimal val_2 = System.Decimal.op_Implicit(value:  info);
        string val_3 = NumberAbbreviation.GetNumber(num:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        SLC.Social.Profile val_4 = new SLC.Social.Profile();
        .AvatarId = info;
        .Portrait_ID = info;
        if((System.String.IsNullOrEmpty(value:  info)) != true)
        {
                .FacebookId = info;
            .UseFacebook = true;
        }
        
        this.gameObject.SetActive(value:  true);
    }
    public LeaderboardUIMemberGridItem()
    {
    
    }

}
