using UnityEngine;
public class TRVStreakManager : MonoSingleton<TRVStreakManager>
{
    // Fields
    public const string ON_STREAK_UPDATE = "OnTRVStreakUpdate";
    private const string streakKey = "trvStreak";
    
    // Properties
    private int currentStreak { get; set; }
    public int getCurrentStreak { get; }
    
    // Methods
    private int get_currentStreak()
    {
        return CPlayerPrefs.GetInt(key:  "trvStreak", defaultValue:  0);
    }
    private void set_currentStreak(int value)
    {
        CPlayerPrefs.SetInt(key:  "trvStreak", val:  value);
    }
    public int get_getCurrentStreak()
    {
        return this.currentStreak;
    }
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void TRVStreakManager::OnSceneChanged(UnityEngine.SceneManagement.Scene outgoing, UnityEngine.SceneManagement.Scene incoming)));
    }
    private void OnSceneChanged(UnityEngine.SceneManagement.Scene outgoing, UnityEngine.SceneManagement.Scene incoming)
    {
        System.Action<System.Boolean> val_14;
        var val_15;
        var val_16;
        if((System.String.IsNullOrEmpty(value:  outgoing.m_Handle.name)) == true)
        {
            goto label_6;
        }
        
        GameBehavior val_3 = App.getBehavior;
        string val_4 = outgoing.m_Handle.name;
        if((val_3.<metaGameBehavior>k__BackingField) != 2)
        {
            goto label_6;
        }
        
        val_14 = val_5.OnQuestionAnswered;
        val_15 = 1152921504614248448;
        val_16 = MonoSingleton<TRVMainController>.Instance;
        if((System.Delegate.Remove(source:  val_14, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVStreakManager::OnQuestionAnswered(bool correct)))) != null)
        {
            goto label_10;
        }
        
        goto label_25;
        label_6:
        GameBehavior val_8 = App.getBehavior;
        if((val_8.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_14 = 1152921504893161472;
        if((MonoSingleton<TRVMainController>.Instance) == 0)
        {
                return;
        }
        
        val_14 = val_11.OnQuestionAnswered;
        val_15 = 1152921504614248448;
        val_16 = MonoSingleton<TRVMainController>.Instance;
        System.Delegate val_13 = System.Delegate.Combine(a:  val_14, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVStreakManager::OnQuestionAnswered(bool correct)));
        if(val_13 == null)
        {
            goto label_25;
        }
        
        label_10:
        if(null != val_15)
        {
            goto label_26;
        }
        
        label_25:
        val_11.OnQuestionAnswered = val_13;
        return;
        label_26:
    }
    private void OnQuestionAnswered(bool correct)
    {
        if(correct == false)
        {
                return;
        }
        
        int val_4 = UnityEngine.Mathf.Min(a:  val_1.maxStreak, b:  (App.GetGameSpecificEcon<TRVEcon>().currentStreak) + 1);
        val_4.currentStreak = val_4;
    }
    private void OnLevelComplete(bool successfulLevel, TRVQuizProgress prog)
    {
        if(successfulLevel != false)
        {
                return;
        }
        
        this.currentStreak = 0;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnTRVStreakUpdate");
    }
    public void BreakStreak()
    {
        int val_1 = this.currentStreak;
        val_1.currentStreak = 0;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnTRVStreakUpdate");
        TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
        val_3.currentGame.InjectTrackingInfo(key:  "Broken Streak", value:  val_1);
    }
    public int GetBonusStarReward()
    {
        return this.currentStreak;
    }
    public int AddHackedStreaks(int amount)
    {
        amount = (App.GetGameSpecificEcon<TRVEcon>().currentStreak) + amount;
        int val_3 = UnityEngine.Mathf.Min(a:  val_1.maxStreak, b:  amount);
        val_3.currentStreak = val_3;
        NotificationCenter val_4 = NotificationCenter.DefaultCenter;
        val_4.PostNotification(aSender:  this, aName:  "OnTRVStreakUpdate");
        return val_4.currentStreak;
    }
    public TRVStreakManager()
    {
    
    }

}
