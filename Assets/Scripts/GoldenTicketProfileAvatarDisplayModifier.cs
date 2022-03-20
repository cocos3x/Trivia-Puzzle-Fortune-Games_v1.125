using UnityEngine;
public class GoldenTicketProfileAvatarDisplayModifier : ProfileAvatarDisplayModifier
{
    // Fields
    private UnityEngine.Sprite subscriberButtonSprite;
    private UnityEngine.Vector3 avatarPositionOffset;
    
    // Methods
    public override bool IsActive()
    {
        return true;
    }
    public override bool AppendAvatarDisplay(AvatarSlotUGUI avatarDisplay, SLC.Social.Profile profile)
    {
        UnityEngine.Object val_16;
        var val_17;
        val_16 = profile;
        if((this.IsMe(serverId:  profile.ServerId)) == false)
        {
            goto label_2;
        }
        
        val_17 = 0;
        bool val_2 = WGSubscriptionManager.HasSubscribedGoldenTicket;
        if(val_2 == true)
        {
            goto label_3;
        }
        
        label_2:
        if(((val_2.IsMe(serverId:  profile.ServerId)) == true) || (profile.hasSubscriptionActive == false))
        {
                return false;
        }
        
        label_3:
        val_16 = avatarDisplay.transform.parent;
        if(val_16 == 0)
        {
                return false;
        }
        
        val_16 = avatarDisplay.transform.parent.GetComponent<EditProfileButton>();
        if(val_16 == 0)
        {
                return false;
        }
        
        EditProfileButton val_13 = avatarDisplay.transform.parent.GetComponent<EditProfileButton>();
        if(val_13.button == 0)
        {
                return false;
        }
        
        val_13.button.image.sprite = this.subscriberButtonSprite;
        val_13.button.spriteState = new UnityEngine.UI.SpriteState() {m_HighlightedSprite = this.subscriberButtonSprite, m_PressedSprite = this.subscriberButtonSprite, m_SelectedSprite = this.subscriberButtonSprite, m_DisabledSprite = this.subscriberButtonSprite};
        return false;
    }
    private bool IsMe(int serverId)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        return (bool)(val_2.ServerId == serverId) ? 1 : 0;
    }
    public GoldenTicketProfileAvatarDisplayModifier()
    {
    
    }

}
