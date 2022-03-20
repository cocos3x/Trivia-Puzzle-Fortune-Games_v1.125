using UnityEngine;
public class PortraitCollectionPortraitItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image collectionImage;
    private UnityEngine.UI.Image fillBar;
    private UnityEngine.GameObject loadingBarGroup;
    private UnityEngine.GameObject buttonGroup;
    private UnityEngine.GameObject inUseGroup;
    private UnityEngine.UI.Button useButton;
    private UnityEngine.UI.Text progressText;
    
    // Methods
    public void Init(string portraitName, bool unlocked, bool inUse, float progress = 0)
    {
        .<>4__this = this;
        .portraitName = portraitName;
        this.loadingBarGroup.SetActive(value:  false);
        this.buttonGroup.SetActive(value:  false);
        this.inUseGroup.SetActive(value:  false);
        this.collectionImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  (PortraitCollectionPortraitItem.<>c__DisplayClass7_0)[1152921516639238400].portraitName);
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.collectionImage.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        if(unlocked == false)
        {
            goto label_10;
        }
        
        if(inUse == false)
        {
            goto label_11;
        }
        
        this.inUseGroup.SetActive(value:  true);
        return;
        label_10:
        if(progress <= 0f)
        {
            goto label_13;
        }
        
        this.loadingBarGroup.SetActive(value:  true);
        this.fillBar.fillAmount = progress;
        float val_12 = 100f;
        val_12 = progress * val_12;
        string val_6 = System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.FloorToInt(f:  val_12));
        UnityEngine.Color val_7 = UnityEngine.Color.gray;
        this.collectionImage.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a};
        return;
        label_11:
        this.buttonGroup.SetActive(value:  true);
        this.useButton.m_OnClick.RemoveAllListeners();
        this.useButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new PortraitCollectionPortraitItem.<>c__DisplayClass7_0(), method:  System.Void PortraitCollectionPortraitItem.<>c__DisplayClass7_0::<Init>b__0()));
        return;
        label_13:
        this.collectionImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetAltPortraitSpriteByName(name:  (PortraitCollectionPortraitItem.<>c__DisplayClass7_0)[1152921516639238400].portraitName);
        UnityEngine.Color val_11 = UnityEngine.Color.gray;
        this.collectionImage.color = new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a};
    }
    public void InitCollection(string collectionName, bool unlocked, bool inUse, float progress = 0)
    {
        string val_5;
        var val_6;
        if((unlocked != true) && (inUse != true))
        {
                val_5 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait(collection:  collectionName);
            val_6 = 0;
        }
        else
        {
                val_5 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionRewardPotrait(collection:  collectionName);
            val_6 = 1;
        }
        
        inUse = inUse;
        this.Init(portraitName:  val_5, unlocked:  true, inUse:  inUse, progress:  progress);
    }
    public void Init(int Id, bool inUse)
    {
        .<>4__this = this;
        .Id = Id;
        this.loadingBarGroup.SetActive(value:  false);
        this.buttonGroup.SetActive(value:  false);
        this.inUseGroup.SetActive(value:  false);
        this.collectionImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetAvatarSpriteByID(id:  (PortraitCollectionPortraitItem.<>c__DisplayClass9_0)[1152921516639672320].Id, portraitID:  0);
        if(inUse != false)
        {
                this.inUseGroup.SetActive(value:  true);
            return;
        }
        
        this.buttonGroup.SetActive(value:  true);
        this.useButton.m_OnClick.RemoveAllListeners();
        this.useButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new PortraitCollectionPortraitItem.<>c__DisplayClass9_0(), method:  System.Void PortraitCollectionPortraitItem.<>c__DisplayClass9_0::<Init>b__0()));
    }
    private void UseButtonPress(string myName)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((System.String.op_Inequality(a:  val_2.Portrait_ID, b:  myName)) == false)
        {
                return;
        }
        
        SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_5.Portrait_ID = myName;
        Player val_6 = App.Player;
        int val_10 = val_6.properties.LifetimeProfileAvatarChanges;
        val_10 = val_10 + 1;
        val_6.properties.LifetimeProfileAvatarChanges = val_10;
        System.DateTime val_7 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_7.dateData};
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnAvatarChanged");
    }
    private void UseButtonPress(int id)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if(val_2.AvatarId == id)
        {
                return;
        }
        
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_4.Portrait_ID = System.String.alignConst;
        SLC.Social.Profile val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_6.AvatarId = id;
        Player val_7 = App.Player;
        int val_11 = val_7.properties.LifetimeProfileAvatarChanges;
        val_11 = val_11 + 1;
        val_7.properties.LifetimeProfileAvatarChanges = val_11;
        System.DateTime val_8 = ServerHandler.ServerTime;
        SLC.Social.Leagues.LeaguesTracker.LastAvatarChange = new System.DateTime() {dateData = val_8.dateData};
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnAvatarChanged");
        this.Init(Id:  id, inUse:  true);
    }
    public PortraitCollectionPortraitItem()
    {
    
    }

}
