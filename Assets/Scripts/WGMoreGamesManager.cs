using UnityEngine;
public class WGMoreGamesManager : MonoSingleton<WGMoreGamesManager>
{
    // Fields
    private const string pref_next_show_time = "prefs_moregames_time";
    private const string pref_no_install_consecutive_days = "moregames_n_i_d";
    private const string pref_next_collect_time = "moregames_n_c";
    private static int _unlockLevel;
    private static int amountPerInstall;
    private static int consecutiveDaysPauseThreshold;
    private static int nonPurchaserDelay;
    private static int purchaserDelay;
    private static int totalBonus;
    private static int gamesInstalled;
    private static bool popupShowingFromBonusCollect;
    private static System.Collections.Generic.Dictionary<string, object> DebugData;
    public static System.Action RefreshUI;
    private static System.DateTime _NextMoreGamesBonusShowTime;
    private static System.DateTime _NextMoreGamesCollectTime;
    private static int _ConsecutiveNoInstallDays;
    
    // Properties
    public static int AmountPerInstall { get; }
    public static int GetTotalBonus { get; }
    public static int unlockLevel { get; }
    public static bool IsAvailable { get; }
    public static bool CanShowMoreGames { get; }
    public static System.DateTime NextMoreGamesBonusShowTime { get; set; }
    public static System.DateTime NextMoreGamesCollectTime { get; set; }
    private static int ConsecutiveNoInstallDays { get; set; }
    
    // Methods
    public static int get_AmountPerInstall()
    {
        null = null;
        return (int)WGMoreGamesManager.amountPerInstall;
    }
    public static int get_GetTotalBonus()
    {
        null = null;
        return (int)WGMoreGamesManager.totalBonus;
    }
    public static int get_unlockLevel()
    {
        null = null;
        return (int)WGMoreGamesManager._unlockLevel;
    }
    public static bool get_IsAvailable()
    {
        var val_2 = null;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  WGMoreGamesManager._unlockLevel);
    }
    public static bool get_CanShowMoreGames()
    {
        var val_15;
        bool val_16;
        var val_17;
        var val_18;
        object[] val_1 = new object[4];
        val_1[0] = WGMoreGamesManager.IsAvailable;
        val_15 = null;
        val_15 = null;
        val_1[1] = twelvegigs.plugins.InstalledAppsPlugin.fetched;
        val_1[2] = (twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck != null) ? 1 : 0;
        if(twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck != null)
        {
                GameApp[] val_7 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            var val_8 = (val_7.Length != 0) ? 1 : 0;
        }
        else
        {
                val_16 = false;
        }
        
        val_1[3] = val_16;
        WGMoreGamesManager.UpdateDebugData(key:  "Can Show", value:  System.String.Format(format:  "\n\t\tlevel met: {0},\n\t\tfetched installed apps: {1},\n\t\tpackages to check != null: {2},\n\t\tpackages to check > 0: {3}", args:  val_1));
        if(WGMoreGamesManager.IsAvailable != false)
        {
                val_17 = null;
            val_17 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.fetched != false)
        {
                if(twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck == null)
        {
                return (bool)val_18;
        }
        
            GameApp[] val_12 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            var val_13 = (val_12.Length != 0) ? 1 : 0;
            return (bool)val_18;
        }
        
        }
        
        val_18 = 0;
        return (bool)val_18;
    }
    public static bool ReadyToShowInBonusFlow()
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        val_8 = null;
        if(WGMoreGamesManager.IsAvailable != false)
        {
                val_9 = null;
            if(WGMoreGamesManager.CanShowMoreGames != false)
        {
                val_10 = null;
            if(WGMoreGamesManager.CanCollect() != false)
        {
                System.DateTime val_4 = DateTimeCheat.UtcNow;
            System.DateTime val_5 = WGMoreGamesManager.NextMoreGamesBonusShowTime;
            var val_7 = ((val_4.dateData.CompareTo(value:  new System.DateTime() {dateData = val_5.dateData})) > 0) ? 1 : 0;
            return (bool)val_11;
        }
        
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    public static System.DateTime get_NextMoreGamesBonusShowTime()
    {
        var val_3;
        var val_4;
        val_3 = null;
        val_3 = null;
        System.DateTime val_2 = SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "prefs_moregames_time"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        val_4 = null;
        val_4 = null;
        WGMoreGamesManager._NextMoreGamesBonusShowTime = val_2.dateData;
        WGMoreGamesManager.UpdateDebugData(key:  "Next Show Time", value:  val_2);
        return (System.DateTime)WGMoreGamesManager._NextMoreGamesBonusShowTime;
    }
    public static void set_NextMoreGamesBonusShowTime(System.DateTime value)
    {
        WGMoreGamesManager.UpdateDebugData(key:  "Next Show Time", value:  value);
        WGMoreGamesManager._NextMoreGamesBonusShowTime = value.dateData;
        CPlayerPrefs.SetString(key:  "prefs_moregames_time", val:  WGMoreGamesManager._NextMoreGamesBonusShowTime.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static System.DateTime get_NextMoreGamesCollectTime()
    {
        var val_3;
        var val_4;
        val_3 = null;
        val_3 = null;
        System.DateTime val_2 = SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "moregames_n_c"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        val_4 = null;
        val_4 = null;
        WGMoreGamesManager._NextMoreGamesCollectTime = val_2.dateData;
        WGMoreGamesManager.UpdateDebugData(key:  "Next Collect Time", value:  val_2);
        return (System.DateTime)WGMoreGamesManager._NextMoreGamesCollectTime;
    }
    public static void set_NextMoreGamesCollectTime(System.DateTime value)
    {
        WGMoreGamesManager.UpdateDebugData(key:  "Next Collect Time", value:  value);
        WGMoreGamesManager._NextMoreGamesCollectTime = value.dateData;
        CPlayerPrefs.SetString(key:  "moregames_n_c", val:  WGMoreGamesManager._NextMoreGamesCollectTime.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private static int get_ConsecutiveNoInstallDays()
    {
        int val_2;
        var val_3 = null;
        if(WGMoreGamesManager._ConsecutiveNoInstallDays == 1)
        {
                val_3 = null;
            val_2 = UnityEngine.PlayerPrefs.GetInt(key:  "moregames_n_i_d", defaultValue:  0);
            val_3 = null;
            WGMoreGamesManager._ConsecutiveNoInstallDays = val_2;
        }
        
        val_3 = null;
        WGMoreGamesManager.UpdateDebugData(key:  "Consecutive No Install Days", value:  WGMoreGamesManager._ConsecutiveNoInstallDays);
        return WGMoreGamesManager._ConsecutiveNoInstallDays;
    }
    private static void set_ConsecutiveNoInstallDays(int value)
    {
        WGMoreGamesManager.UpdateDebugData(key:  "Consecutive No Install Days", value:  value);
        WGMoreGamesManager._ConsecutiveNoInstallDays = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "moregames_n_i_d", value:  WGMoreGamesManager._ConsecutiveNoInstallDays);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void DigestMoreGamesKnobs(System.Collections.Generic.Dictionary<string, object> knobs)
    {
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        if((knobs.ContainsKey(key:  "lvl")) != false)
        {
                val_22 = null;
            val_22 = null;
            bool val_3 = System.Int32.TryParse(s:  knobs.Item["lvl"], result: out  void* val_3 = WGMoreGamesManager.__il2cppRuntimeField_static_fields);
        }
        
        if((knobs.ContainsKey(key:  "rew")) != false)
        {
                val_23 = null;
            val_23 = null;
            bool val_7 = System.Int32.TryParse(s:  knobs.Item["rew"], result: out  1152921504973623300);
        }
        
        if((knobs.ContainsKey(key:  "c_days")) != false)
        {
                val_24 = null;
            val_24 = null;
            bool val_11 = System.Int32.TryParse(s:  knobs.Item["c_days"], result: out  1152921504973623304);
        }
        
        if((knobs.ContainsKey(key:  "np_del")) != false)
        {
                val_25 = null;
            val_25 = null;
            bool val_15 = System.Int32.TryParse(s:  knobs.Item["np_del"], result: out  1152921504973623308);
        }
        
        if((knobs.ContainsKey(key:  "p_del")) != false)
        {
                val_26 = null;
            val_26 = null;
            bool val_19 = System.Int32.TryParse(s:  knobs.Item["p_del"], result: out  1152921504973623312);
        }
        
        WGMoreGamesManager.UpdateDebugData(key:  "knobs", value:  knobs);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_20 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_27 = null;
        val_27 = null;
        val_20.Add(key:  "lvl", value:  WGMoreGamesManager._unlockLevel);
        val_20.Add(key:  "rew", value:  WGMoreGamesManager.amountPerInstall);
        val_20.Add(key:  "c_days", value:  WGMoreGamesManager.consecutiveDaysPauseThreshold);
        val_20.Add(key:  "np_del", value:  WGMoreGamesManager.nonPurchaserDelay);
        val_20.Add(key:  "p_del", value:  WGMoreGamesManager.purchaserDelay);
        WGMoreGamesManager.UpdateDebugData(key:  "parsed knobs", value:  val_20);
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void WGMoreGamesManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnInstalledAppsResponded");
    }
    public void OnInstalledAppsResponded()
    {
        var val_2;
        twelvegigs.plugins.InstalledAppsPlugin.UpdateInstalledApps();
        val_2 = null;
        bool val_1 = WGMoreGamesManager.CanShowMoreGames;
        if(val_1 == false)
        {
                return;
        }
        
        val_1.Refresh();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)
    {
        var val_2 = null;
        bool val_1 = WGMoreGamesManager.CanShowMoreGames;
        if(val_1 == false)
        {
                return;
        }
        
        val_1.Refresh();
    }
    private void OnApplicationPause(bool pauseState)
    {
        var val_2;
        if(pauseState == true)
        {
                return;
        }
        
        twelvegigs.plugins.InstalledAppsPlugin.UpdateInstalledApps();
        val_2 = null;
        bool val_1 = WGMoreGamesManager.CanShowMoreGames;
        if(val_1 == false)
        {
                return;
        }
        
        val_1.Refresh();
    }
    public void Refresh()
    {
        var val_4;
        var val_5;
        System.Action val_6;
        var val_7;
        var val_8;
        var val_9;
        val_4 = null;
        val_4 = null;
        WGMoreGamesManager.gamesInstalled = 0;
        WGMoreGamesManager.totalBonus = 0;
        GameApp[] val_1 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
        if(val_1.Length == 0)
        {
                val_5 = null;
            val_5 = null;
            val_6 = WGMoreGamesManager.RefreshUI;
            if(val_6 != null)
        {
                val_6 = WGMoreGamesManager.RefreshUI;
            val_6.Invoke();
        }
        
        }
        
        val_7 = 0;
        goto label_13;
        label_24:
        if(twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[3] != 0)
        {
                val_8 = null;
            val_8 = null;
            WGMoreGamesManager.gamesInstalled = 1;
            int val_5 = WGMoreGamesManager.totalBonus;
            val_5 = WGMoreGamesManager.amountPerInstall + val_5;
            WGMoreGamesManager.totalBonus = val_5;
        }
        
        val_7 = 1;
        label_13:
        GameApp[] val_3 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
        if(val_7 < val_3.Length)
        {
            goto label_24;
        }
        
        val_9 = null;
        val_9 = null;
        WGMoreGamesManager.UpdateDebugData(key:  "games installed", value:  WGMoreGamesManager.gamesInstalled);
        if(WGMoreGamesManager.RefreshUI == null)
        {
                return;
        }
        
        WGMoreGamesManager.RefreshUI.Invoke();
    }
    public void ShowPopupDuringBonusCollectFlow()
    {
        var val_4;
        var val_5;
        val_4 = null;
        if(WGMoreGamesManager.ReadyToShowInBonusFlow() == false)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        WGMoreGamesManager.popupShowingFromBonusCollect = true;
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMoreGamesPopup>(showNext:  false);
    }
    public static void HandlePopupClosed()
    {
        ulong val_7;
        var val_8;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        val_8 = null;
        val_8 = null;
        if(WGMoreGamesManager.popupShowingFromBonusCollect == false)
        {
                return;
        }
        
        val_11 = 0;
        if(WGMoreGamesManager.gamesInstalled != 0)
        {
                WGMoreGamesManager.ConsecutiveNoInstallDays = 0;
            val_7 = 1152921504616751104;
            val_12 = null;
            val_12 = null;
            WGMoreGamesManager._NextMoreGamesBonusShowTime = System.DateTime.MinValue;
            CPlayerPrefs.DeleteKey(key:  "prefs_moregames_time");
        }
        else
        {
                int val_1 = WGMoreGamesManager.ConsecutiveNoInstallDays;
            val_1 = val_1 + 1;
            WGMoreGamesManager.ConsecutiveNoInstallDays = val_1;
            if(WGMoreGamesManager.ConsecutiveNoInstallDays == WGMoreGamesManager.consecutiveDaysPauseThreshold)
        {
                Player val_3 = App.Player;
            val_13 = null;
            if(val_3.total_purchased > 0f)
        {
                val_14 = null;
            val_15 = 1152921504973623312;
        }
        else
        {
                val_16 = null;
            val_15 = 1152921504973623308;
        }
        
            System.DateTime val_4 = DateTimeCheat.UtcNow;
            System.DateTime val_5 = val_4.dateData.AddDays(value:  (double)val_15);
            val_7 = val_5.dateData;
            WGMoreGamesManager.NextMoreGamesBonusShowTime = new System.DateTime() {dateData = val_7};
            WGMoreGamesManager.ConsecutiveNoInstallDays = 0;
        }
        
        }
        
        val_17 = null;
        val_17 = null;
        WGMoreGamesManager.popupShowingFromBonusCollect = false;
    }
    public static void HandlePopupCollected()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  24);
        WGMoreGamesManager.NextMoreGamesCollectTime = new System.DateTime() {dateData = val_2.dateData};
    }
    public static bool CanCollect()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = WGMoreGamesManager.NextMoreGamesCollectTime;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        return (bool)(val_3._ticks.TotalSeconds > 0f) ? 1 : 0;
    }
    private static void UpdateDebugData(string key, object value)
    {
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = null;
        val_2 = null;
        val_3 = null;
        if((WGMoreGamesManager.DebugData.ContainsKey(key:  key)) != false)
        {
                val_4 = null;
            WGMoreGamesManager.DebugData.set_Item(key:  key, value:  value);
            return;
        }
        
        val_5 = null;
        WGMoreGamesManager.DebugData.Add(key:  key, value:  value);
    }
    public static string GetDebugData()
    {
        null = null;
        return PrettyPrint.printJSON(obj:  WGMoreGamesManager.DebugData, types:  false, singleLineOutput:  false);
    }
    public WGMoreGamesManager()
    {
    
    }
    private static WGMoreGamesManager()
    {
        var val_2;
        var val_3;
        WGMoreGamesManager._unlockLevel = 20;
        WGMoreGamesManager.amountPerInstall = 5;
        WGMoreGamesManager.consecutiveDaysPauseThreshold = 7;
        WGMoreGamesManager.nonPurchaserDelay = 14;
        WGMoreGamesManager.purchaserDelay = 21;
        WGMoreGamesManager.totalBonus = 0;
        WGMoreGamesManager.gamesInstalled = 0;
        WGMoreGamesManager.popupShowingFromBonusCollect = false;
        val_2 = null;
        WGMoreGamesManager.DebugData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3 = null;
        val_3 = null;
        val_2 = 1152921504973619384;
        WGMoreGamesManager._NextMoreGamesBonusShowTime = System.DateTime.MinValue;
        WGMoreGamesManager._NextMoreGamesCollectTime = System.DateTime.MinValue;
        WGMoreGamesManager._ConsecutiveNoInstallDays = 0;
    }

}
