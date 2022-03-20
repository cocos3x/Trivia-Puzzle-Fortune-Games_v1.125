using UnityEngine;
public class EventListItemContentCCPvP : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Text rightCrownText;
    private UnityEngine.UI.Image playerAvatarImage;
    private UnityEngine.UI.Image aiAvatarImage;
    private UnityEngine.UI.RawImage facebookImage;
    public SLC.Social.AvatarConfig playerAvatarHandler;
    
    // Methods
    public override void SetupSlider(string sliderText, float sliderValue)
    {
        object val_18;
        SLC.Social.AvatarConfig val_21;
        this.SetupSlider(sliderText:  sliderText, sliderValue:  sliderValue);
        if((PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) <= 999)
        {
            goto label_3;
        }
        
        float val_18 = 1000f;
        val_18 = ((float)PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44) / val_18;
        val_18 = val_18.ToString(format:  "######.##");
        if((System.String.Format(format:  "{0}K", arg0:  val_18)) != null)
        {
            goto label_4;
        }
        
        label_3:
        val_18 = 0;
        string val_3 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 44.ToString();
        label_4:
        int val_4 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.getOpponentCrowns();
        if(val_4 > 999)
        {
                float val_19 = 1000f;
            val_19 = (float)val_4 / val_19;
            string val_6 = System.String.Format(format:  "{0}K", arg0:  val_19.ToString(format:  "######.##"));
        }
        else
        {
                string val_7 = val_4.ToString();
        }
        
        this.playerAvatarImage.sprite = this.playerAvatarHandler.GetAvatarSpriteByID(id:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.playerSprite, portraitID:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.playerPortrait);
        val_21 = this.playerAvatarHandler;
        this.aiAvatarImage.sprite = val_21.GetAvatarSpriteByID(id:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.opponentPlayerSprite, portraitID:  0);
        SLC.Social.Profile val_14 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.IsNullOrEmpty(value:  val_14.FacebookId)) == true)
        {
                return;
        }
        
        if(val_14.UseFacebook == false)
        {
                return;
        }
        
        System.Action<System.String, UnityEngine.Texture2D> val_16 = null;
        val_21 = val_16;
        val_16 = new System.Action<System.String, UnityEngine.Texture2D>(object:  this, method:  public System.Void EventListItemContentCCPvP::OnResponseSuccess(string fileName, UnityEngine.Texture2D texture));
        FacebookAvatarHelper.RequestProfilePic(fbid:  val_14.FacebookId, successCallback:  val_16, failureCallback:  new System.Action(object:  this, method:  public System.Void EventListItemContentCCPvP::OnResponseFail()));
    }
    public void OnResponseSuccess(string fileName, UnityEngine.Texture2D texture)
    {
        if(texture != 0)
        {
                if(texture.width > 255)
        {
            goto label_5;
        }
        
        }
        
        label_13:
        this.OnResponseFail();
        return;
        label_5:
        if(this.gameObject == 0)
        {
                return;
        }
        
        if(this.facebookImage == 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  fileName.Replace(oldValue:  "fbavatar_", newValue:  ""))) == true)
        {
            goto label_13;
        }
        
        this.facebookImage.texture = texture;
        this.facebookImage.gameObject.SetActive(value:  true);
    }
    public void OnResponseFail()
    {
        if(this.gameObject == 0)
        {
                return;
        }
        
        if(this.facebookImage == 0)
        {
                return;
        }
        
        this.facebookImage.gameObject.SetActive(value:  false);
    }
    public EventListItemContentCCPvP()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
