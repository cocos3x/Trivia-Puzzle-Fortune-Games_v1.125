using UnityEngine;
public class TournamentsProfileAvatarDisplayModifier : ProfileAvatarDisplayModifier
{
    // Fields
    private UnityEngine.GameObject stupidCrownPrefab;
    
    // Methods
    public override bool IsActive()
    {
        return false;
    }
    public override bool AppendAvatarDisplay(AvatarSlotUGUI avatarDisplay, SLC.Social.Profile profile)
    {
        UnityEngine.GameObject val_5;
        var val_6;
        val_5 = profile;
        if((profile.Name.ToLower().Contains(value:  "s")) != false)
        {
                val_5 = this.stupidCrownPrefab;
            this.stupidCrownPrefab = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_5, parent:  avatarDisplay.transform);
            val_6 = 1;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public TournamentsProfileAvatarDisplayModifier()
    {
    
    }

}
