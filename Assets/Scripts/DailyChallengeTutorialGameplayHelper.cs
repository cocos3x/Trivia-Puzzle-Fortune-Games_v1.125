using UnityEngine;
public class DailyChallengeTutorialGameplayHelper : MonoSingleton<DailyChallengeTutorialGameplayHelper>
{
    // Fields
    private WGDailyChallengeWordRegion _DCWordRegion;
    private WGDailyChallengeMainController _DCMainController;
    
    // Properties
    private WGDailyChallengeWordRegion DCWordRegion { get; }
    public WGDailyChallengeMainController DCMainController { get; }
    
    // Methods
    private WGDailyChallengeWordRegion get_DCWordRegion()
    {
        WGDailyChallengeWordRegion val_4;
        if(this._DCWordRegion != 0)
        {
            goto label_3;
        }
        
        if(WordRegion.instance == null)
        {
            goto label_8;
        }
        
        val_4 = 0;
        goto label_8;
        label_3:
        val_4 = this._DCWordRegion;
        return (WGDailyChallengeWordRegion);
        label_8:
        this._DCWordRegion = ;
        return (WGDailyChallengeWordRegion);
    }
    public WGDailyChallengeMainController get_DCMainController()
    {
        WGDailyChallengeMainController val_4;
        if(this._DCMainController != 0)
        {
            goto label_3;
        }
        
        if(MainController.instance == null)
        {
            goto label_8;
        }
        
        val_4 = 0;
        goto label_8;
        label_3:
        val_4 = this._DCMainController;
        return (WGDailyChallengeMainController);
        label_8:
        this._DCMainController = ;
        return (WGDailyChallengeMainController);
    }
    public void ShowFirstWord()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.wait_ShowFTUX());
    }
    public void HandleGameplayTutorialComplete()
    {
        DailyChallengeTutorialManager val_1 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        val_1._GameplayTutorialActive = false;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnRefreshNotification");
    }
    private System.Collections.IEnumerator wait_ShowFTUX()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new DailyChallengeTutorialGameplayHelper.<wait_ShowFTUX>d__8();
    }
    public DailyChallengeTutorialGameplayHelper()
    {
    
    }

}
