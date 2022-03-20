using UnityEngine;
public class WFOLightningLevelsEventHandler : LightningLevelsEventHandler
{
    // Methods
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return (bool)(~dailyChallengeState) & 1;
    }
    protected override void ShowLightningUI()
    {
        LightningLevelsUIController val_1 = MonoSingleton<LightningLevelsUIController>.Instance;
        mem2[0] = 0;
        this = ???;
        goto typeof(LightningLevelsUIController).__il2cppRuntimeField_180;
    }
    public override void OnBeforeLevelComplete(int levelsProgressed = 1)
    {
        UnityEngine.Object val_11 = this;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.IsLightningValidAndSuccess() == false)
        {
                return;
        }
        
        val_11 = MonoSingleton<LightningLevelsUIController>.Instance;
        if(val_11 == 0)
        {
                return;
        }
        
        val_11 = MonoSingleton<LightningLevelsUIController>.Instance.EventProgressUI;
        if(val_11 == 0)
        {
                return;
        }
        
        MonoSingleton<LightningLevelsUIController>.Instance.EventProgressUI.DoCompleteAnimation();
    }
    protected override void ExecuteLevelCompleteSuccessAction()
    {
    
    }
    public string GetNextLightningEventProgress(bool spaced = False)
    {
        LightingEventProgress val_1 = this.EventProgress;
        int val_4 = val_1.CompletedCount;
        val_4 = val_4 + 1;
        return (string)System.String.Format(format:  "{0}{1}{2}", arg0:  val_4, arg1:  (spaced != true) ? " / " : "/", arg2:  (val_1.CompletedCount + 1) + 24);
    }
    public float GetNextEventProgressValue()
    {
        LightingEventProgress val_1 = this.EventProgress;
        float val_3 = 1.152922E+18f;
        val_3 = ((float)val_1.CompletedCount + 1) / val_3;
        return (float)val_3;
    }
    public override string GetMainMenuButtonText()
    {
        if(W9 == 805306368)
        {
                if(this.IsRewardReadyToCollect() != false)
        {
                return Localization.Localize(key:  "reward_upper", defaultValue:  "REWARD", useSingularKey:  false);
        }
        
        }
        
        if(this.GetEventProgressValue() > 0f)
        {
                this = ???;
        }
    
    }
    public override string GetGameButtonText()
    {
        System.TimeSpan val_1 = this.GetLightningElapsed();
        return (string)System.String.Format(format:  "{0:0}:{1:00}", arg0:  val_1._ticks.Minutes, arg1:  val_1._ticks.Seconds);
    }
    public override string GetEventDisplayName()
    {
        return "LIGHTNING";
    }
    public override string GetLightningEventProgress(bool spaced = False)
    {
        return (string)System.String.Format(format:  "{0}{1}{2}", arg0:  true, arg1:  (spaced != true) ? " / " : "/", arg2:  38021);
    }
    public WFOLightningLevelsEventHandler()
    {
    
    }

}
