using UnityEngine;
public class SROptions_TRV : SuperLuckySROptionsParent<SROptions_TRV>, INotifyPropertyChanged
{
    // Properties
    public bool HighlightCorrectAnswer { get; set; }
    public bool DisplayCardValue { get; set; }
    public bool FastMode { get; set; }
    public bool AutoAnswer { get; set; }
    public string AnswerPct { get; }
    public string ViewStreaks { get; }
    public bool SpecialCategoryImageQuestions { get; set; }
    public bool Show { get; set; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void CopyErrors()
    {
        var val_6;
        string val_7;
        val_6 = null;
        val_7 = "";
        val_6 = null;
        System.Collections.Generic.IEnumerator<T> val_1 = UnityLoggerListener._allConsoleEntries.GetEnumerator();
        label_14:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        string val_6 = val_7 + val_1.Current;
        goto label_14;
        label_9:
        val_7 = 0;
        if(val_1 != null)
        {
                var val_10 = 0;
            val_10 = val_10 + 1;
            val_1.Dispose();
        }
        
        if(val_7 != 0)
        {
                throw val_7;
        }
        
        ClipboardHelper.clipBoard = val_7;
    }
    public void ShareErrors()
    {
        var val_6;
        string val_7;
        val_6 = null;
        val_7 = "";
        val_6 = null;
        System.Collections.Generic.IEnumerator<T> val_1 = UnityLoggerListener._allConsoleEntries.GetEnumerator();
        label_14:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        string val_6 = val_7 + val_1.Current;
        goto label_14;
        label_9:
        val_7 = 0;
        if(val_1 != null)
        {
                var val_10 = 0;
            val_10 = val_10 + 1;
            val_1.Dispose();
        }
        
        if(val_7 != 0)
        {
                throw val_7;
        }
        
        ClipboardHelper.clipBoard = val_7;
        twelvegigs.plugins.SharePlugin.Share(text:  val_7, url:  "", subject:  "Latest Error Logs", emailBody:  val_7, imgPath:  0);
    }
    public bool get_HighlightCorrectAnswer()
    {
        return CPlayerPrefs.GetBool(key:  "hackAnswer", defaultValue:  false);
    }
    public void set_HighlightCorrectAnswer(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "hackAnswer", value:  value);
    }
    public bool get_DisplayCardValue()
    {
        return CPlayerPrefs.GetBool(key:  "DisplayCardValue", defaultValue:  false);
    }
    public void set_DisplayCardValue(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "DisplayCardValue", value:  value);
    }
    public void General()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_General>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void PlayerCheats()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Player>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DateTime()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DateTime>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Store()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Store>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Ads()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Ads>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DailyBonus()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DailyBonus>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DisplayLevelInfo()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetGameLevelInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void HackCategories()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_TRVCategoryHack>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public bool get_FastMode()
    {
        null = null;
        return (bool)TRVMainController.QAHACK_HURRY;
    }
    public void set_FastMode(bool value)
    {
        null = null;
        TRVMainController.QAHACK_HURRY = value;
    }
    public bool get_AutoAnswer()
    {
        null = null;
        return (bool)TRVMainController.QAHACK_CORRECT;
    }
    public void set_AutoAnswer(bool value)
    {
        null = null;
        TRVMainController.QAHACK_CORRECT = value;
        bool val_2 = (TRVMainController.QAHACK_HURRY == true) ? 1 : 0;
        val_2 = val_2 | value;
        TRVMainController.QAHACK_HURRY = val_2;
        SROptions_TRV.NotifyPropertyChanged(propertyName:  "FastMode");
    }
    public string get_AnswerPct()
    {
        float val_6;
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        TRVDataParser val_2 = MonoSingleton<TRVDataParser>.Instance;
        if((val_1.<playerPersistance>k__BackingField.totalSeenQuestions) >= 1)
        {
                float val_5 = (float)val_2.<playerPersistance>k__BackingField.totalCorrectQuestions;
            val_5 = val_5 / ((float)val_1.<playerPersistance>k__BackingField.totalSeenQuestions);
            val_6 = val_5 * 100f;
            return (string)System.String.Format(format:  "{0} / {1} = {2}", arg0:  val_2.<playerPersistance>k__BackingField.totalCorrectQuestions, arg1:  val_1.<playerPersistance>k__BackingField.totalSeenQuestions, arg2:  UnityEngine.Mathf.RoundToInt(f:  val_6 = 0f));
        }
        
        return (string)System.String.Format(format:  "{0} / {1} = {2}", arg0:  val_2.<playerPersistance>k__BackingField.totalCorrectQuestions, arg1:  val_1.<playerPersistance>k__BackingField.totalSeenQuestions, arg2:  UnityEngine.Mathf.RoundToInt(f:  val_6));
    }
    public void Add10Experts()
    {
        System.Collections.Generic.List<TRVExpert> val_3 = MonoSingleton<TRVExpertsController>.Instance.DetermineExpertCards(source:  3, expertNowReadyToUpgrade: out  false, cardsToPull:  10);
    }
    public void Add100Experts()
    {
        System.Collections.Generic.List<TRVExpert> val_3 = MonoSingleton<TRVExpertsController>.Instance.DetermineExpertCards(source:  3, expertNowReadyToUpgrade: out  false, cardsToPull:  100);
    }
    public void Add10000Experts()
    {
        System.Collections.Generic.List<TRVExpert> val_3 = MonoSingleton<TRVExpertsController>.Instance.DetermineExpertCards(source:  3, expertNowReadyToUpgrade: out  false, cardsToPull:  16);
    }
    public string get_ViewStreaks()
    {
        return (string)MonoSingleton<TRVStreakManager>.Instance.getCurrentStreak.ToString();
    }
    public void Add10Streaks()
    {
        int val_2 = MonoSingleton<TRVStreakManager>.Instance.AddHackedStreaks(amount:  10);
        SROptions_TRV.NotifyPropertyChanged(propertyName:  "Streaks");
    }
    public void ShowEventHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_GameEvents>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowTournamentsHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Tournaments>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public bool get_SpecialCategoryImageQuestions()
    {
        null = null;
        return (bool)TRVPromoCategoriesHandler.prefs_promo_quiz_completed_key;
    }
    public void set_SpecialCategoryImageQuestions(bool value)
    {
        null = null;
        TRVPromoCategoriesHandler.prefs_promo_quiz_completed_key = value;
    }
    public void GenericUIs()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_UIs>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public bool get_Show()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "isDebugBannerShown", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public void set_Show(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "isDebugBannerShown", value:  value);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ToggleDebugBanner");
    }
    public void Locales()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Locales_TRV>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public SROptions_TRV()
    {
    
    }

}
