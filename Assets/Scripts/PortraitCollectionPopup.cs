using UnityEngine;
public class PortraitCollectionPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button editButton;
    private FPHPlayButton playButton;
    private UnityEngine.UI.Text happeningNowCollectionName;
    private UnityEngine.UI.Text happeningNowDesc;
    private UnityEngine.UI.Text playerName;
    private UnityEngine.GameObject happeningNowSection;
    private UnityEngine.UI.Image happeningNowPortraitItem;
    private UnityEngine.UI.Image currentAvatarImage;
    private UnityEngine.UI.Image currentAvatarBackground;
    private UnityEngine.UI.Image coinStatViewOverlay;
    private PortraitCollectionCollectionItem collectionPrefab;
    private UnityEngine.Transform collectionParent;
    
    // Properties
    public FPHPlayButton getPlayButton { get; }
    
    // Methods
    public FPHPlayButton get_getPlayButton()
    {
        return (FPHPlayButton)this.playButton;
    }
    private void Start()
    {
        this.Init();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAvatarChanged");
        this.OnAvatarChanged();
    }
    private void Init()
    {
        var val_20;
        var val_21;
        string val_27;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPopup::Close()));
        SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        val_27 = 1152921504893161472;
        if((MonoSingleton<FPHPortraitCollectionController>.Instance.isEventActive()) != false)
        {
                FPHPortraitCollectionController val_6 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            val_27 = val_6.progress.chosenCollection;
            this.happeningNowSection.SetActive(value:  true);
            this.playButton.onPlayResult = new System.Action<System.Boolean>(object:  this, method:  System.Void PortraitCollectionPopup::OnPressPlayResult(bool result));
            this.playButton.OnAnimationStarted = new System.Action(object:  this, method:  System.Void PortraitCollectionPopup::OnCoinAnimation());
            SLC.Social.Profile val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            System.Collections.Generic.List<System.String> val_12 = MonoSingleton<WGPortraitDataController>.Instance.GetPortraitNamesByCollection(collection:  val_27);
            System.Collections.Generic.List<System.String> val_14 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  val_27);
            this.happeningNowPortraitItem.gameObject.SetActive(value:  true);
            this.happeningNowPortraitItem.sprite = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionBanner(collection:  val_27);
        }
        else
        {
                this.happeningNowSection.SetActive(value:  false);
        }
        
        WGPortraitDataController val_18 = MonoSingleton<WGPortraitDataController>.Instance;
        List.Enumerator<T> val_19 = val_18.getEcon.MyCollections.GetEnumerator();
        label_44:
        if(val_21.MoveNext() == false)
        {
            goto label_39;
        }
        
        PortraitCollectionCollectionItem val_23 = UnityEngine.Object.Instantiate<PortraitCollectionCollectionItem>(original:  this.collectionPrefab, parent:  this.collectionParent);
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23.Init(collectionName:  val_20 + 16);
        goto label_44;
        label_39:
        val_21.Dispose();
        UnityEngine.Object.Instantiate<PortraitCollectionCollectionItem>(original:  this.collectionPrefab, parent:  this.collectionParent).InitDefaultCollection();
        this.editButton.m_OnClick.RemoveAllListeners();
        this.editButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionPopup::OnClickEdit()));
        this.coinStatViewOverlay.gameObject.SetActive(value:  false);
    }
    private void OnCoinAnimation()
    {
        PluginExtension.SetColorAlpha(graphic:  this.coinStatViewOverlay, a:  0f);
        this.coinStatViewOverlay.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.editButton), endValue:  0f, duration:  0.2f);
        DG.Tweening.Tweener val_5 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.closeButton), endValue:  0f, duration:  0.2f);
    }
    private void OnPressPlayResult(bool result)
    {
        System.Action val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) == 1) && (result != true))
        {
                WGStoreProxy val_2 = UnityEngine.Object.FindObjectOfType<WGStoreProxy>();
            if(val_2 != 0)
        {
                val_7 = null;
            val_7 = null;
            val_6 = PortraitCollectionPopup.<>c.<>9__18_0;
            if(val_6 == null)
        {
                System.Action val_4 = null;
            val_6 = val_4;
            val_4 = new System.Action(object:  PortraitCollectionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void PortraitCollectionPopup.<>c::<OnPressPlayResult>b__18_0());
            PortraitCollectionPopup.<>c.<>9__18_0 = val_6;
        }
        
            val_2.Init(outOfCredits:  true, onCloseAction:  val_4);
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickEdit()
    {
        bool val_4 = UnityEngine.Object.op_Inequality(x:  this.gameObject.GetComponent<WGFlyoutWindow>(), y:  0);
        .inFlyoutMode = val_4;
        if(val_4 == false)
        {
            goto label_5;
        }
        
        GameBehavior val_6 = App.getBehavior;
        if((val_6.<metaGameBehavior>k__BackingField) != null)
        {
            goto label_10;
        }
        
        label_5:
        GameBehavior val_8 = App.getBehavior;
        label_10:
        SLCWindow val_10 = val_8.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_10.Action_OnClose = new System.Action(object:  new PortraitCollectionPopup.<>c__DisplayClass19_0(), method:  System.Void PortraitCollectionPopup.<>c__DisplayClass19_0::<OnClickEdit>b__0());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnAvatarChanged()
    {
        SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.currentAvatarImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetAvatarSpriteByID(id:  val_3.AvatarId, portraitID:  val_5.Portrait_ID);
        SLC.Social.Profile val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.currentAvatarBackground.enabled = System.String.IsNullOrEmpty(value:  val_8.Portrait_ID);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnAvatarChanged");
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PortraitCollectionPopup()
    {
    
    }

}
