using UnityEngine;
public class HackBehavior
{
    // Methods
    public virtual string SR_ChapterName()
    {
        return "Sr_chapter overload not set";
    }
    public virtual void ReloadGameplayLevel()
    {
        UnityEngine.Debug.LogError(message:  "ReloadGameplayLevel not implemented for current game.");
    }
    public virtual void Hack_CompleteLevelBehavior()
    {
        UnityEngine.Debug.LogError(message:  "Complete Level Hack Not Implemented");
    }
    public virtual void Hack_CompleteChapterBehavior()
    {
        UnityEngine.Debug.LogError(message:  "Complete Chapter Hack Not Implemented");
    }
    public virtual void Hack_RestartLevel()
    {
        UnityEngine.Debug.LogError(message:  "Restart Level Hack Not Implemented");
    }
    public virtual void Hack_OnLevelChanged()
    {
        if((MonoSingleton<WGChallengeWordsManager>.Instance) == 0)
        {
                return;
        }
        
        if(WGChallengeWordsManager.IsFeatureUnlocked == false)
        {
                return;
        }
        
        MonoSingleton<WGChallengeWordsManager>.Instance.Hack_OnLevelChanged();
    }
    public virtual SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance;
    }
    public virtual void SetInfinityMode(bool setTo)
    {
        null = null;
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Infinite Freeplay debug button not implemented for " + App.game, displayTime:  3f);
    }
    public virtual void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        UnityEngine.Debug.LogWarning(message:  "trying to append game level info but no behavior has been specified for this game");
    }
    public virtual void AppendCategoriesInfo(ref System.Text.StringBuilder builder)
    {
        UnityEngine.Debug.LogWarning(message:  "trying to append categories info but no behavior has been specified for this game");
    }
    public virtual void ResetPlayer()
    {
    
    }
    public HackBehavior()
    {
    
    }

}
