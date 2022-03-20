using UnityEngine;
public class PortraitCollectionEntryButton : WGUnlockableUIElement
{
    // Fields
    private bool showFlyout;
    private UnityEngine.UI.Image portraitImage;
    
    // Properties
    protected override bool FeatureHidden { get; }
    protected override bool FeatureLocked { get; }
    protected override int UnlockLevel { get; }
    
    // Methods
    protected override void Start()
    {
        this.Start();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAvatarChanged");
        SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.portraitImage.sprite = MonoSingleton<ProfileAvatarManager>.Instance.ProfileAvatarConfig.GetAvatarSpriteByID(id:  val_3.AvatarId, portraitID:  val_3.Portrait_ID);
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  160f, y:  170.9f);
        this.gameObject.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  120f, y:  120f);
        this.portraitImage.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
        UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  0f, y:  8f);
        this.portraitImage.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
    }
    protected override void UpdateButton()
    {
        this.UpdateButton();
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.portraitImage.sprite = MonoSingleton<ProfileAvatarManager>.Instance.ProfileAvatarConfig.GetAvatarSpriteByID(id:  val_2.AvatarId, portraitID:  val_2.Portrait_ID);
    }
    protected override bool get_FeatureHidden()
    {
        return false;
    }
    protected override bool get_FeatureLocked()
    {
        return false;
    }
    protected override int get_UnlockLevel()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.portriatCollectionUnlockLevel;
    }
    protected override void OnClickUnlocked()
    {
        PortraitCollectionPopup val_11;
        FPHPlayButton val_12;
        .collectionPopup = 0;
        if(this.showFlyout != false)
        {
                GameBehavior val_2 = App.getBehavior;
            val_11 = val_2.<metaGameBehavior>k__BackingField;
        }
        else
        {
                GameBehavior val_4 = App.getBehavior;
            val_11 = val_4.<metaGameBehavior>k__BackingField;
        }
        
        .collectionPopup = val_11;
        val_12 = 1152921504893161472;
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<FPHLevelCompletePopup>()) == false)
        {
                return;
        }
        
        val_12 = (PortraitCollectionEntryButton.<>c__DisplayClass10_0)[1152921516622931632].collectionPopup.playButton;
        (PortraitCollectionEntryButton.<>c__DisplayClass10_0)[1152921516622931632].collectionPopup.playButton.overridePlayButtonClick = new System.Action(object:  new PortraitCollectionEntryButton.<>c__DisplayClass10_0(), method:  System.Void PortraitCollectionEntryButton.<>c__DisplayClass10_0::<OnClickUnlocked>b__0());
    }
    private void OnAvatarChanged()
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.portraitImage.sprite = MonoSingleton<ProfileAvatarManager>.Instance.ProfileAvatarConfig.GetAvatarSpriteByID(id:  val_2.AvatarId, portraitID:  val_2.Portrait_ID);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnAvatarChanged");
    }
    public PortraitCollectionEntryButton()
    {
    
    }

}
