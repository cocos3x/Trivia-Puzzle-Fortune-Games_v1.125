using UnityEngine;
public class PortraitCollectionPorgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image avatarImage;
    private UnityEngine.UI.Image collectionImage;
    private UnityEngine.GameObject portraitGroup;
    private UnityEngine.GameObject collectionGroup;
    private UnityEngine.UI.Button useButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button collectionContinue;
    private UnityEngine.UI.Button collectionClose;
    private UnityEngine.UI.Text collectionTitleText;
    private string unlockedPortrait;
    public System.Action OnCLose;
    
    // Methods
    private void Start()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPorgressPopup::Close()));
        this.useButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPorgressPopup::OnClickUse()));
        this.collectionContinue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPorgressPopup::Close()));
        this.collectionClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPorgressPopup::Close()));
    }
    public void OnEnable()
    {
        MonoSingleton<FPHPortraitCollectionController>.Instance.OnProgressSeen();
        UnityEngine.ParticleSystem val_4 = MonoSingleton<WGSFXController>.Instance.PlaySFX(reqType:  2, parent:  this.avatarImage.rectTransform, playImmediate:  true);
    }
    public void InitPortraitUnlocked(string portraitName, bool isCollection)
    {
        this.unlockedPortrait = portraitName;
        this.portraitGroup.SetActive(value:  (~isCollection) & 1);
        this.collectionGroup.SetActive(value:  isCollection);
        if(isCollection != false)
        {
                FPHPortraitCollectionController val_3 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            this.collectionImage.sprite = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionBanner(collection:  val_3.progress.chosenCollection);
            UnityEngine.ParticleSystem val_8 = MonoSingleton<WGSFXController>.Instance.PlaySFX(reqType:  2, parent:  this.collectionImage.rectTransform, playImmediate:  true);
            return;
        }
        
        this.avatarImage.sprite = MonoSingleton<ProfileAvatarManager>.Instance.ProfileAvatarConfig.GetPortraitSpriteByName(name:  portraitName);
    }
    private void OnClickUse()
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_2.Portrait_ID = this.unlockedPortrait;
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
        Player val_4 = App.Player;
        int val_7 = val_4.properties.LifetimeProfileAvatarChanges;
        val_7 = val_7 + 1;
        val_4.properties.LifetimeProfileAvatarChanges = val_7;
        System.DateTime val_5 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_5.dateData};
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnAvatarChanged");
        this.Close();
    }
    private void Close()
    {
        if(this.OnCLose != null)
        {
                this.OnCLose.Invoke();
            this.OnCLose = 0;
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PortraitCollectionPorgressPopup()
    {
    
    }

}
