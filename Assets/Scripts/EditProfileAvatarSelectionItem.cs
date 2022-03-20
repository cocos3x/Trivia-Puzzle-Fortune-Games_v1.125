using UnityEngine;
public class EditProfileAvatarSelectionItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Image avatarImage;
    private UnityEngine.GameObject selectedAvatarIdentifier;
    private int thisAvatarId;
    private string myAvatarIdString;
    public System.Action<EditProfileAvatarSelectionItem> OnAvatarSelection;
    
    // Properties
    public int AvatarId { get; }
    public string AvatarIDString { get; }
    
    // Methods
    public int get_AvatarId()
    {
        return (int)this.thisAvatarId;
    }
    public string get_AvatarIDString()
    {
        return (string)this.myAvatarIdString;
    }
    private void Awake()
    {
    
    }
    public void Setup(int avatarId)
    {
        this.gameObject.name = "Avatar_" + avatarId.ToString();
        this.thisAvatarId = avatarId;
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void EditProfileAvatarSelectionItem::OnAvatarClicked()));
        this.avatarImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetAvatarSpriteByID(id:  avatarId, portraitID:  0);
    }
    public void Setup(string avatarId)
    {
        this.gameObject.name = "Avatar_" + avatarId;
        this.myAvatarIdString = avatarId;
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void EditProfileAvatarSelectionItem::OnAvatarClicked()));
        this.avatarImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  avatarId);
    }
    public void Refresh()
    {
        bool val_10;
        this.selectedAvatarIdentifier.SetActive(value:  false);
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.IsNullOrEmpty(value:  val_2.Portrait_ID)) != false)
        {
                SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            var val_6 = (val_5.AvatarId == this.thisAvatarId) ? 1 : 0;
        }
        else
        {
                SLC.Social.Profile val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_10 = System.String.op_Equality(a:  val_8.Portrait_ID, b:  this.myAvatarIdString);
        }
        
        this.selectedAvatarIdentifier.SetActive(value:  val_10);
    }
    private void OnAvatarClicked()
    {
        if(this.OnAvatarSelection == null)
        {
                return;
        }
        
        this.OnAvatarSelection.Invoke(obj:  this);
    }
    public EditProfileAvatarSelectionItem()
    {
        this.thisAvatarId = 0;
        this.myAvatarIdString = "";
    }

}
