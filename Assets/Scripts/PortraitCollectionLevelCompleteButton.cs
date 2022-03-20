using UnityEngine;
public class PortraitCollectionLevelCompleteButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text buttonText;
    public UnityEngine.GameObject rewardReadyIcon;
    private UnityEngine.UI.Image portraitImage;
    private UnityEngine.UI.Button myButton;
    
    // Methods
    private void Start()
    {
        this.myButton = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        this.UpdateState();
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  160f, y:  170.9f);
        this.gameObject.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  120f, y:  120f);
        this.portraitImage.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  0f, y:  8f);
        this.portraitImage.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  0f, y:  64f);
        this.buttonText.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
        UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  0f, y:  0f);
        this.buttonText.rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
        UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  1f, y:  0f);
        this.buttonText.rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
        UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  0.5f, y:  0.25f);
        this.buttonText.rectTransform.pivot = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
        UnityEngine.Vector2 val_19 = new UnityEngine.Vector2(x:  0f, y:  0f);
        this.buttonText.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_19.x, y = val_19.y};
    }
    public void UpdateState()
    {
        object val_39;
        var val_40;
        var val_41;
        FPHPortraitProgress val_42;
        UnityEngine.Events.UnityAction val_43;
        var val_44;
        var val_46;
        val_39 = this;
        this.rewardReadyIcon.SetActive(value:  false);
        val_40 = 1152921504893161472;
        val_41 = 1152921516615594896;
        if(((MonoSingleton<FPHPortraitCollectionController>.Instance) == 0) || ((MonoSingleton<FPHPortraitCollectionController>.Instance.IsEnabled()) == false))
        {
            goto label_14;
        }
        
        FPHPortraitCollectionController val_5 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_5.progress == null)
        {
            goto label_14;
        }
        
        FPHPortraitCollectionController val_6 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        val_42 = val_6.progress;
        string val_8 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait();
        if((System.String.IsNullOrEmpty(value:  val_8)) != true)
        {
                this.portraitImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  val_8);
        }
        
        this.myButton.m_OnClick.RemoveAllListeners();
        val_43 = new UnityEngine.Events.UnityAction();
        if(val_6.progress.hasStartedInstance == false)
        {
            goto label_28;
        }
        
        val_43 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionLevelCompleteButton::OpenCollection());
        this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction());
        if(val_6.progress.showUnlockedPortrait == false)
        {
            goto label_30;
        }
        
        FPHPortraitCollectionController val_14 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        this.portraitImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  System.Linq.Enumerable.Last<System.String>(source:  MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  val_14.progress.chosenCollection)));
        val_44 = 1;
        goto label_44;
        label_14:
        val_44 = 0;
        label_44:
        this.gameObject.SetActive(value:  false);
        return;
        label_28:
        val_43 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PortraitCollectionLevelCompleteButton::OpenEventStart());
        this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction());
        val_46 = "EVENT";
        goto label_48;
        label_30:
        if(val_6.progress.collectionCompleted == false)
        {
            goto label_49;
        }
        
        FPHPortraitCollectionController val_22 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        val_43 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionRewardPotrait(collection:  val_22.progress.chosenCollection);
        this.portraitImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  val_43);
        val_46 = "100%";
        label_48:
        val_39 = ???;
        val_41 = ???;
        val_42 = ???;
        val_40 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_49:
        float val_40 = 100f;
        float val_39 = (float)val_42 + 40;
        val_39 = val_39 / ((float)MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCollectionNextUnlockCost(collection:  val_42 + 32));
        val_40 = val_39 * val_40;
        string val_29 = System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.FloorToInt(f:  val_40));
    }
    private void OpenEventStart()
    {
        FPHPlayButton val_9;
        GameBehavior val_2 = App.getBehavior;
        .collectionPopup = val_2.<metaGameBehavior>k__BackingField;
        val_9 = 1152921504893161472;
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<FPHLevelCompletePopup>()) == false)
        {
                return;
        }
        
        val_9 = (PortraitCollectionLevelCompleteButton.<>c__DisplayClass6_0)[1152921516633592704].collectionPopup.playButton;
        (PortraitCollectionLevelCompleteButton.<>c__DisplayClass6_0)[1152921516633592704].collectionPopup.playButton.overridePlayButtonClick = new System.Action(object:  new PortraitCollectionLevelCompleteButton.<>c__DisplayClass6_0(), method:  System.Void PortraitCollectionLevelCompleteButton.<>c__DisplayClass6_0::<OpenEventStart>b__0());
    }
    private void OpenCollection()
    {
        FPHPlayButton val_9;
        GameBehavior val_2 = App.getBehavior;
        .collectionPopup = val_2.<metaGameBehavior>k__BackingField;
        val_9 = 1152921504893161472;
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<FPHLevelCompletePopup>()) == false)
        {
                return;
        }
        
        val_9 = (PortraitCollectionLevelCompleteButton.<>c__DisplayClass7_0)[1152921516633771264].collectionPopup.playButton;
        (PortraitCollectionLevelCompleteButton.<>c__DisplayClass7_0)[1152921516633771264].collectionPopup.playButton.overridePlayButtonClick = new System.Action(object:  new PortraitCollectionLevelCompleteButton.<>c__DisplayClass7_0(), method:  System.Void PortraitCollectionLevelCompleteButton.<>c__DisplayClass7_0::<OpenCollection>b__0());
    }
    public PortraitCollectionLevelCompleteButton()
    {
    
    }

}
