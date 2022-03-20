using UnityEngine;
public class AvatarSlotUGUI : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Image avatarImage;
    protected UnityEngine.UI.RawImage facebookImage;
    protected bool alwaysMe;
    
    // Methods
    private void OnEnable()
    {
        if(this.alwaysMe == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
    }
    public virtual void Setup(SLC.Social.Profile profile)
    {
        this.facebookImage.gameObject.SetActive(value:  false);
        this.avatarImage.sprite = MonoSingleton<ProfileAvatarManager>.Instance.ProfileAvatarConfig.GetAvatarSpriteByID(id:  profile.AvatarId, portraitID:  profile.Portrait_ID);
        MonoSingleton<ProfileAvatarManager>.Instance.AppendAvatarDisplay(avatarDisplay:  this, profile:  profile);
    }
    private void OnMyProfileUpdate()
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        goto typeof(AvatarSlotUGUI).__il2cppRuntimeField_170;
    }
    public AvatarSlotUGUI()
    {
    
    }

}
