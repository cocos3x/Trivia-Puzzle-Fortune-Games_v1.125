using UnityEngine;
public class DifficultySettingManagerGameplay : MonoSingleton<DifficultySettingManagerGameplay>
{
    // Fields
    public bool ShouldShowGoldenApplesBonus;
    public int GoldenApplesAward;
    private GameLevel currentPlayingLevel;
    
    // Properties
    public static bool IsPlayingDifficultLevel { get; }
    public static int ApplesFromDifficulty { get; }
    
    // Methods
    public static bool get_IsPlayingDifficultLevel()
    {
        var val_6;
        if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) != 0)
        {
                DifficultySettingManagerGameplay val_3 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
            if(val_3.currentPlayingLevel != null)
        {
                DifficultySettingManagerGameplay val_4 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
            var val_5 = (val_4.currentPlayingLevel.isChallengingLevel == true) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public static int get_ApplesFromDifficulty()
    {
        int val_5;
        if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) != 0)
        {
                DifficultySettingManagerGameplay val_3 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
            if(val_3.currentPlayingLevel != null)
        {
                DifficultySettingManagerGameplay val_4 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
            val_5 = val_4.currentPlayingLevel.goldenApplesExtraDifficulty;
            return (int)val_5;
        }
        
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void DifficultySettingManagerGameplay::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public void AwardExtraApples(int earnedAmount)
    {
        if(this.currentPlayingLevel == null)
        {
                return;
        }
        
        if(this.currentPlayingLevel.isChallengingLevel == false)
        {
                return;
        }
        
        int val_1 = this.currentPlayingLevel.goldenApplesExtraDifficulty;
        val_1 = val_1 + earnedAmount;
        this.currentPlayingLevel.goldenApplesExtraDifficulty = val_1;
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        var val_7;
        if(sceneType != 2)
        {
                return;
        }
        
        val_7 = 1152921504879157248;
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void DifficultySettingManagerGameplay::OnLevelLoaded(GameLevel level)));
        WordRegion.instance.addOnLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void DifficultySettingManagerGameplay::OnLevelComplete(GameLevel level)));
    }
    private void OnLevelLoaded(GameLevel level)
    {
        bool val_11;
        this.currentPlayingLevel = level;
        this.ShouldShowGoldenApplesBonus = false;
        DifficultySettingManager val_1 = MonoSingleton<DifficultySettingManager>.Instance;
        if(this.currentPlayingLevel.isChallengingLevel == false)
        {
            goto label_6;
        }
        
        DifficultySettingManager val_2 = MonoSingleton<DifficultySettingManager>.Instance;
        var val_3 = ((val_2.<Setting>k__BackingField.FeatureStatus.IsFtuxSeen) == false) ? 1 : 0;
        if((val_1.<Setting>k__BackingField.FeatureStatus) != null)
        {
            goto label_12;
        }
        
        label_6:
        val_11 = false;
        label_12:
        val_1.<Setting>k__BackingField.FeatureStatus.IsFtuxLevel = val_11;
        if(this.currentPlayingLevel.isChallengingLevel != false)
        {
                DifficultySettingManager val_4 = MonoSingleton<DifficultySettingManager>.Instance;
            if((val_4.<Setting>k__BackingField.FeatureStatus.IsFtuxSeen) != true)
        {
                DifficultySettingManager val_5 = MonoSingleton<DifficultySettingManager>.Instance;
            val_5.<Setting>k__BackingField.FeatureStatus.IsFtuxSeen = true;
            DifficultySettingManager val_6 = MonoSingleton<DifficultySettingManager>.Instance;
            val_6.<Setting>k__BackingField.SaveToJSON();
            MonoSingleton<DifficultySettingUIController_Game>.Instance.ShowTooltip();
        }
        
        }
        
        GameEcon val_9 = App.getGameEcon;
        if(App.Player != val_9.difficultySettingPromptLevel)
        {
                return;
        }
        
        MonoSingleton<DifficultySettingManager>.Instance.ShowOnPromptLevel();
    }
    private void OnLevelComplete(GameLevel level)
    {
        if(GoldenMultiplierManager.IsAvaialable == true)
        {
                return;
        }
        
        if(this.currentPlayingLevel.goldenApplesExtraDifficulty == 0)
        {
                return;
        }
        
        DifficultySettingManager val_2 = MonoSingleton<DifficultySettingManager>.Instance;
        if((val_2.<Setting>k__BackingField.FeatureStatus.IsFtuxSeen) == false)
        {
                return;
        }
        
        if(this.currentPlayingLevel.isChallengingLevel == false)
        {
                return;
        }
        
        this.ShouldShowGoldenApplesBonus = true;
        level.goldenApplesExtraDifficulty = this.currentPlayingLevel.goldenApplesExtraDifficulty;
        this.GoldenApplesAward = this.currentPlayingLevel.goldenApplesExtraDifficulty;
        GoldenApplesManager val_3 = MonoSingleton<GoldenApplesManager>.Instance;
        level = ???;
        goto typeof(GoldenApplesManager).__il2cppRuntimeField_190;
    }
    private void OnDestroy()
    {
        if((MonoSingletonSelfGenerating<SceneDictator>.InstanceExists) == false)
        {
                return;
        }
        
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Remove(source:  val_2.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void DifficultySettingManagerGameplay::OnSceneLoaded(SceneType sceneType)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        return;
        label_8:
    }
    public DifficultySettingManagerGameplay()
    {
    
    }

}
