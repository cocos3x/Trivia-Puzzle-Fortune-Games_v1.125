using UnityEngine;
public class WGExtraChapterRewardsPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button CloseButton;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text descriptionText;
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.UI.Text playButtonText;
    
    // Methods
    public void Init(bool particpating)
    {
        string val_6;
        var val_7;
        if(particpating != false)
        {
                val_6 = Localization.Localize(key:  "chapter_rewards_unlocked", defaultValue:  "{0}X Chapter Rewards unlocked for a limited time!", useSingularKey:  false);
            GameEcon val_2 = App.getGameEcon;
            val_7 = 1152921504622129152;
        }
        else
        {
                val_6 = Localization.Localize(key:  "complete_chapter", defaultValue:  "Complete a Chapter to unlock {0}X Chapter Rewards!", useSingularKey:  false);
            GameEcon val_4 = App.getGameEcon;
            val_7 = 1152921504622129152;
        }
        
        string val_5 = System.String.Format(format:  val_6, arg0:  val_4.extraChapterEventMultiplier);
    }
    private void UpdateTimeRemaining()
    {
        if(ExtraChapterEventHandler._Instance != null)
        {
                System.TimeSpan val_1 = ExtraChapterEventHandler._Instance.TimeRemaining;
            if(val_1._ticks.TotalSeconds > 0f)
        {
                this = this.timeRemainingText;
            string val_3 = ExtraChapterEventHandler._Instance.TimeRemainingFormatted;
            return;
        }
        
        }
        
        this.playButton.gameObject.SetActive(value:  false);
        this.continueButton.gameObject.SetActive(value:  false);
        this.CancelInvoke(methodName:  "UpdateTimeRemaining");
    }
    private void OnEnable()
    {
        this.InvokeRepeating(methodName:  "UpdateTimeRemaining", time:  0f, repeatRate:  1f);
        this.CloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGExtraChapterRewardsPopup::PressCloseButton()));
        GameBehavior val_3 = App.getBehavior;
        this.playButton.gameObject.SetActive(value:  ((val_3.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        GameBehavior val_6 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_6.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGExtraChapterRewardsPopup::PressPlayButton()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGExtraChapterRewardsPopup::PressPlayButton()));
        if(this.playButtonText == 0)
        {
                UnityEngine.Debug.LogError(message:  "Play button text not set on Extra Chapter Rewards Popup");
            return;
        }
        
        GameBehavior val_11 = App.getBehavior;
        if((val_11.<metaGameBehavior>k__BackingField) == 1)
        {
                string val_14 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
            return;
        }
        
        string val_15 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
    }
    private void PressCloseButton()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(ExtraChapterEventHandler._Instance == null)
        {
                return;
        }
        
        goto typeof(ExtraChapterEventHandler).__il2cppRuntimeField_540;
    }
    private void PressPlayButton()
    {
        this.gameObject.SetActive(value:  false);
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 2)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public WGExtraChapterRewardsPopup()
    {
    
    }

}
