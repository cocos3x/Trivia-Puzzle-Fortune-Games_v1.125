using UnityEngine;
public class LeaderboardMemberGridItem : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject medalGroup;
    private UnityEngine.UI.Image medalImage;
    private UnityEngine.Sprite goldMedalSp;
    private UnityEngine.Sprite silverMedalSp;
    private UnityEngine.Sprite bronzeMedalSp;
    private UnityEngine.UI.Text rank;
    private AvatarSlotUGUI profileImage;
    private UnityEngine.UI.Text profileName;
    private UnityEngine.UI.Text goldenCurrency;
    
    // Methods
    public void UpdateUIFromMember(LeaderboardPlayerInfo info)
    {
        var val_10;
        UnityEngine.Sprite val_11;
        var val_12;
        var val_13;
        if(info == null)
        {
            goto label_1;
        }
        
        if(info == 3)
        {
            goto label_2;
        }
        
        if(info == 2)
        {
            goto label_3;
        }
        
        if(info != 1)
        {
            goto label_4;
        }
        
        val_11 = this.goldMedalSp;
        goto label_10;
        label_1:
        UnityEngine.GameObject val_1 = this.gameObject;
        val_12 = 0;
        goto label_8;
        label_2:
        val_11 = this.bronzeMedalSp;
        goto label_10;
        label_3:
        val_11 = this.silverMedalSp;
        label_10:
        this.medalImage.sprite = val_11;
        this.medalGroup.SetActive(value:  true);
        UnityEngine.GameObject val_2 = this.rank.gameObject;
        val_13 = 0;
        goto label_15;
        label_4:
        this.medalGroup.SetActive(value:  false);
        string val_3 = info.ToString();
        val_13 = 1;
        label_15:
        this.rank.gameObject.SetActive(value:  true);
        decimal val_5 = System.Decimal.op_Implicit(value:  info);
        string val_6 = NumberAbbreviation.GetNumber(num:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        SLC.Social.Profile val_7 = null;
        val_10 = val_7;
        val_7 = new SLC.Social.Profile();
        .AvatarId = info;
        if((System.String.IsNullOrEmpty(value:  info)) != true)
        {
                .FacebookId = info;
            .UseFacebook = true;
        }
        
        val_12 = 1;
        label_8:
        this.gameObject.SetActive(value:  true);
    }
    public LeaderboardMemberGridItem()
    {
    
    }

}
