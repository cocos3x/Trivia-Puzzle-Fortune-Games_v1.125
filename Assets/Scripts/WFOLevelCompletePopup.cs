using UnityEngine;
public class WFOLevelCompletePopup : LevelCompletePopup
{
    // Fields
    private bool isChapterCleared;
    private System.Nullable<SceneType> <sceneToLoadOnClosed>k__BackingField;
    
    // Properties
    public System.Nullable<SceneType> sceneToLoadOnClosed { get; set; }
    
    // Methods
    public System.Nullable<SceneType> get_sceneToLoadOnClosed()
    {
        return (System.Nullable<SceneType>)this.<sceneToLoadOnClosed>k__BackingField;
    }
    public void set_sceneToLoadOnClosed(System.Nullable<SceneType> value)
    {
        this.<sceneToLoadOnClosed>k__BackingField = value;
    }
    public override void ShowWithEffects()
    {
        this.isChapterCleared = ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player);
        Setup(shouldBeShowing:  true);
    }
    public override void HandleWindowClose(bool isChapterClearWindowClosed)
    {
        UnityEngine.Object val_9;
        var val_10;
        val_9 = this;
        if(((this.<sceneToLoadOnClosed>k__BackingField) & 0) == 0)
        {
                val_10 = this.<sceneToLoadOnClosed>k__BackingField.Value;
        }
        else
        {
                val_10 = 2;
        }
        
        if((this.isChapterCleared != false) && (isChapterClearWindowClosed != true))
        {
                34926.blocksRaycasts = true;
            34926.Setup(shouldBeShowing:  false);
            34926.Setup(shouldBeShowing:  true, showRewards:  true);
            34926.PlayStartAnims();
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        GameBehavior val_3 = App.getBehavior;
        bool val_5 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        val_9 = SLC.Social.Leagues.LeaguesManager.DAO;
        if(val_9 == 0)
        {
                return;
        }
        
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  false);
    }
    public WFOLevelCompletePopup()
    {
    
    }

}
