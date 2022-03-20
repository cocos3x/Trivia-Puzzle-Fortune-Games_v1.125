using UnityEngine;
public class WGFTUXManager : MonoSingleton<WGFTUXManager>
{
    // Fields
    private const string FTUX_SKIP_PROMPTED = "Ftux_Skip_Prompted";
    public twelvegigs.storage.JsonDictionary gameplayKnobs;
    public FTUXDemoWindow currDemoWindow;
    public System.Action<int> SkipToLevelCallback;
    public System.Action SkipTutorialCallback;
    
    // Properties
    public static int FTUX_LEVEL_LIMIT { get; }
    public static bool CanShow { get; }
    public static bool IsShowing { get; }
    private static bool timeToShow { get; }
    private static bool isEnabled { get; }
    public bool DisplaySkipTutorial { get; }
    public bool DisplayAdvancedPlayerPopup { get; }
    public int AdvancedPlayerLevelSkip { get; }
    public int SkipTutorialLevel { get; }
    public int DisplayAdvancedPlayerLevel { get; }
    public int DisplayTutorialSkipLevel { get; }
    public int ReviewPromptLevel { get; }
    
    // Methods
    public static int get_FTUX_LEVEL_LIMIT()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_330;
    }
    public static bool get_CanShow()
    {
        if(WGFTUXManager.timeToShow == false)
        {
                return false;
        }
        
        return WGFTUXManager.isEnabled;
    }
    public static bool get_IsShowing()
    {
        if((MonoSingleton<WGFTUXManager>.Instance) == 0)
        {
                return false;
        }
        
        WGFTUXManager val_3 = MonoSingleton<WGFTUXManager>.Instance;
        return UnityEngine.Object.op_Inequality(x:  val_3.currDemoWindow, y:  0);
    }
    private static bool get_timeToShow()
    {
        UnityEngine.Object val_12;
        var val_13;
        GameBehavior val_1 = App.getBehavior;
        val_12 = val_1.<metaGameBehavior>k__BackingField;
        if(val_12 <= WGFTUXManager.FTUX_LEVEL_LIMIT)
        {
                val_12 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if((UnityEngine.Object.op_Implicit(exists:  val_12)) != false)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
            goto label_17;
        }
        
        }
        
            if(SceneDictator.GetActiveSceneType() == 2)
        {
                if(WordGameEventsController.EventsEnabled == false)
        {
                return (bool)val_13 & 1;
        }
        
            val_13 = (MonoSingleton<WordGameEventsController>.Instance.ActivelyPlayingEventGameMode()) ^ 1;
            return (bool)val_13 & 1;
        }
        
        }
        
        label_17:
        val_13 = 0;
        return (bool)val_13 & 1;
    }
    private static bool get_isEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)val_1.ftuxTutorialEnabled;
    }
    public bool get_DisplaySkipTutorial()
    {
        twelvegigs.storage.JsonDictionary val_3;
        var val_4;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        val_3 = this.gameplayKnobs;
        if(val_3 != null)
        {
            goto label_6;
        }
        
        this.LoadKnobs(forceRefresh:  false);
        val_3 = this.gameplayKnobs;
        if(val_3 == null)
        {
            goto label_8;
        }
        
        label_6:
        if((val_3.Contains(key:  "skip_tutorial")) == false)
        {
            goto label_8;
        }
        
        return this.gameplayKnobs.getBool(key:  "skip_tutorial");
        label_5:
        val_4 = 0;
        return (bool)val_4;
        label_8:
        val_4 = 1;
        return (bool)val_4;
    }
    public bool get_DisplayAdvancedPlayerPopup()
    {
        twelvegigs.storage.JsonDictionary val_4;
        var val_5;
        val_4 = this.gameplayKnobs;
        if(val_4 != null)
        {
            goto label_1;
        }
        
        this.LoadKnobs(forceRefresh:  false);
        val_4 = this.gameplayKnobs;
        if(val_4 == null)
        {
            goto label_2;
        }
        
        label_1:
        if((val_4.Contains(key:  "adv_e")) != false)
        {
                return this.gameplayKnobs.getBool(key:  "adv_e");
        }
        
        val_5 = 1;
        return (bool)(val_2.econConfig.AdvancedPlayerEnabled == true) ? 1 : 0;
        label_2:
        AppConfigs val_2 = App.Configuration;
        return (bool)(val_2.econConfig.AdvancedPlayerEnabled == true) ? 1 : 0;
    }
    public int get_AdvancedPlayerLevelSkip()
    {
        twelvegigs.storage.JsonDictionary val_3;
        int val_4;
        val_3 = this.gameplayKnobs;
        if(val_3 != null)
        {
            goto label_1;
        }
        
        this.LoadKnobs(forceRefresh:  false);
        val_3 = this.gameplayKnobs;
        if(val_3 == null)
        {
            goto label_2;
        }
        
        label_1:
        if((val_3.Contains(key:  "adv_r_l")) != false)
        {
                return this.gameplayKnobs.getInt(key:  "adv_r_l", defaultValue:  0);
        }
        
        val_4 = 50;
        return val_4;
        label_2:
        AppConfigs val_2 = App.Configuration;
        val_4 = val_2.econConfig.AdvancedPlayerLevelToSkip;
        return val_4;
    }
    public int get_SkipTutorialLevel()
    {
        twelvegigs.storage.JsonDictionary val_2 = this.gameplayKnobs;
        if(val_2 == null)
        {
                this.LoadKnobs(forceRefresh:  false);
            val_2 = this.gameplayKnobs;
            if(val_2 == null)
        {
                return 3;
        }
        
        }
        
        if((val_2.Contains(key:  "tutorial_level")) == false)
        {
                return 3;
        }
        
        return this.gameplayKnobs.getInt(key:  "tutorial_level", defaultValue:  0);
    }
    public int get_DisplayAdvancedPlayerLevel()
    {
        twelvegigs.storage.JsonDictionary val_3;
        int val_4;
        val_3 = this.gameplayKnobs;
        if(val_3 != null)
        {
            goto label_1;
        }
        
        this.LoadKnobs(forceRefresh:  false);
        val_3 = this.gameplayKnobs;
        if(val_3 == null)
        {
            goto label_2;
        }
        
        label_1:
        if((val_3.Contains(key:  "adv_d_l")) != false)
        {
                return this.gameplayKnobs.getInt(key:  "adv_d_l", defaultValue:  0);
        }
        
        val_4 = 3;
        return val_4;
        label_2:
        AppConfigs val_2 = App.Configuration;
        val_4 = val_2.econConfig.AdvancedPlayerPopupDisplay;
        return val_4;
    }
    public int get_DisplayTutorialSkipLevel()
    {
        twelvegigs.storage.JsonDictionary val_2 = this.gameplayKnobs;
        if(val_2 == null)
        {
                this.LoadKnobs(forceRefresh:  false);
            val_2 = this.gameplayKnobs;
            if(val_2 == null)
        {
                return 1;
        }
        
        }
        
        if((val_2.Contains(key:  "tutorial_display")) == false)
        {
                return 1;
        }
        
        return this.gameplayKnobs.getInt(key:  "tutorial_display", defaultValue:  0);
    }
    public int get_ReviewPromptLevel()
    {
        int val_4;
        var val_5;
        var val_6;
        val_4 = 1152921504884269056;
        Player val_1 = App.Player;
        if(val_1.properties.AdvancedSkipLevel >= 1)
        {
                Player val_2 = App.Player;
            val_4 = val_2.properties.AdvancedSkipLevel;
            val_5 = null;
            val_5 = null;
            val_6 = WGReviewManager.GOOGLE_API_REVIEW_PREF + val_4;
            return (int)val_6;
        }
        
        val_6 = 0;
        return (int)val_6;
    }
    private void LoadKnobs(bool forceRefresh = False)
    {
        if(forceRefresh != true)
        {
                if(this.gameplayKnobs != null)
        {
                return;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = App.getGameEcon.GetGameplayKnobs();
        if(val_2 == null)
        {
                return;
        }
        
        if(val_2.Keys.Count < 1)
        {
                return;
        }
        
        this.gameplayKnobs = new twelvegigs.storage.JsonDictionary(parsedDictionary:  val_2);
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
    }
    private void OnServerSync()
    {
        this.LoadKnobs(forceRefresh:  true);
    }
    public void OnMainControllerLoaded()
    {
        if(WGFTUXManager.timeToShow != false)
        {
                if(WGFTUXManager.isEnabled != false)
        {
                UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.wait_ShowFTUX());
            return;
        }
        
        }
        
        if(WGFTUXManager.timeToShow == false)
        {
                return;
        }
        
        if(WGFTUXManager.isEnabled == true)
        {
                return;
        }
        
        Player val_7 = App.Player;
        val_7.properties.FTUXWasBlockedByKnob = true;
    }
    public void SkipToLevel(int level)
    {
        if(this.SkipToLevelCallback == null)
        {
                return;
        }
        
        this.SkipToLevelCallback.Invoke(obj:  level);
    }
    public void SkipTutorial()
    {
        this.SkipToLevel(level:  MonoSingleton<WGFTUXManager>.Instance.SkipTutorialLevel);
        Player val_3 = App.Player;
        val_3.properties.SkippedTutorial = true;
        Player val_4 = App.Player;
        val_4.properties.Save(writePrefs:  true);
        if(this.SkipTutorialCallback == null)
        {
                return;
        }
        
        this.SkipTutorialCallback.Invoke();
    }
    public bool CheckAvailable()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        if(SceneDictator.GetActiveSceneType() != 2)
        {
                return false;
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                return false;
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance.ActivelyPlayingEventGameMode()) == true)
        {
                return false;
        }
        
        GameBehavior val_7 = App.getBehavior;
        if((val_7.<metaGameBehavior>k__BackingField) != this.DisplayAdvancedPlayerLevel)
        {
                return false;
        }
        
        return this.DisplayAdvancedPlayerPopup;
    }
    public void ShowAdvancedPlayerPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((UnityEngine.PlayerPrefs.GetInt(key:  "Ftux_Skip_Prompted", defaultValue:  0)) > 0)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "Ftux_Skip_Prompted", value:  1);
        if(this.CheckAvailable() == false)
        {
                return;
        }
        
        WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdvancedPlayerPopup>(showNext:  false);
    }
    private void ShowFTUX()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.wait_ShowFTUX());
    }
    private System.Collections.IEnumerator wait_ShowFTUX()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGFTUXManager.<wait_ShowFTUX>d__38();
    }
    public WGFTUXManager()
    {
    
    }

}
