using UnityEngine;
public class DateTimeCheat : FrameSkipper
{
    // Fields
    private static bool initialized;
    private static int _mSeconds;
    
    // Properties
    public static int Seconds { get; }
    private static int mSeconds { get; set; }
    public static int AdjustedSeconds { get; }
    public static System.DateTime Now { get; }
    public static System.DateTime UtcNow { get; }
    public static System.DateTime ServerNow { get; }
    public static System.DateTime Today { get; }
    
    // Methods
    public static int get_Seconds()
    {
        var val_3;
        var val_4;
        var val_5;
        int val_6;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_3 = 1152921504880381952;
            val_4 = null;
            val_4 = null;
            if(DateTimeCheat.initialized != true)
        {
                DateTimeCheat.LoadSeconds();
            val_4 = null;
        }
        
            val_5 = null;
            val_5 = null;
            val_6 = DateTimeCheat._mSeconds;
            return (int)val_6;
        }
        
        val_6 = 0;
        return (int)val_6;
    }
    private static int get_mSeconds()
    {
        null = null;
        return (int)DateTimeCheat._mSeconds;
    }
    private static void set_mSeconds(int value)
    {
        null = null;
        DateTimeCheat._mSeconds = value;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "SimulatedDate");
    }
    public static int get_AdjustedSeconds()
    {
        null = null;
        return (int)DateTimeCheat._mSeconds;
    }
    public static System.DateTime get_Now()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_3 = System.DateTime.Now;
            System.DateTime val_5 = val_3.dateData.AddSeconds(value:  (double)DateTimeCheat.Seconds);
            return (System.DateTime)val_6.dateData;
        }
        
        System.DateTime val_6 = System.DateTime.Now;
        return (System.DateTime)val_6.dateData;
    }
    public static System.DateTime get_UtcNow()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_3 = System.DateTime.UtcNow;
            System.DateTime val_5 = val_3.dateData.AddSeconds(value:  (double)DateTimeCheat.Seconds);
            return (System.DateTime)val_6.dateData;
        }
        
        System.DateTime val_6 = System.DateTime.UtcNow;
        return (System.DateTime)val_6.dateData;
    }
    public static System.DateTime get_ServerNow()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_3 = System.DateTime.UtcNow;
            System.DateTime val_5 = val_3.dateData.AddSeconds(value:  (double)DateTimeCheat.Seconds);
            return (System.DateTime)val_6.dateData;
        }
        
        System.DateTime val_6 = ServerHandler.ServerTime;
        return (System.DateTime)val_6.dateData;
    }
    public static System.DateTime get_Today()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_3 = System.DateTime.Now;
            System.DateTime val_5 = val_3.dateData.AddSeconds(value:  (double)DateTimeCheat.Seconds);
            System.DateTime val_6 = val_5.dateData.Date;
            return (System.DateTime)val_7.dateData;
        }
        
        System.DateTime val_7 = System.DateTime.Today;
        return (System.DateTime)val_7.dateData;
    }
    public static void LoadSeconds()
    {
        var val_2 = null;
        DateTimeCheat._mSeconds = UnityEngine.PlayerPrefs.GetInt(key:  "DebugTimeDateCheat", defaultValue:  0);
        DateTimeCheat.initialized = true;
    }
    private void Start()
    {
        null = null;
        if(DateTimeCheat.initialized != false)
        {
                return;
        }
        
        DateTimeCheat.LoadSeconds();
    }
    public void ResetDate(UnityEngine.GameObject sender)
    {
        DateTimeCheat.mSeconds = 0;
        UnityEngine.PlayerPrefs.DeleteKey(key:  "DebugTimeDateCheat");
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnDeferredReady");
    }
    public static void ResetDateStatic()
    {
        DateTimeCheat.mSeconds = 0;
        UnityEngine.PlayerPrefs.DeleteKey(key:  "DebugTimeDateCheat");
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void AddSeconds(int secondsCount, bool postNotification = True)
    {
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        DateTimeCheat.mSeconds = DateTimeCheat._mSeconds + secondsCount;
        val_5 = null;
        val_5 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "DebugTimeDateCheat", value:  DateTimeCheat._mSeconds);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        if(postNotification == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnDeferredReady");
    }
    public static void AddSecondsStatic(int secondsCount, bool postNotification = True)
    {
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        DateTimeCheat.mSeconds = DateTimeCheat._mSeconds + secondsCount;
        val_5 = null;
        val_5 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "DebugTimeDateCheat", value:  DateTimeCheat._mSeconds);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        if(postNotification == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void AddDays(int daysCount, bool postNotification = True)
    {
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        DateTimeCheat.mSeconds = DateTimeCheat._mSeconds + (daysCount * 86400);
        val_5 = null;
        val_5 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "DebugTimeDateCheat", value:  DateTimeCheat._mSeconds);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        if(postNotification == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnDeferredReady");
    }
    public static void AddDaysStatic(int daysCount, bool postNotification = True)
    {
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        DateTimeCheat.mSeconds = DateTimeCheat._mSeconds + (daysCount * 86400);
        val_5 = null;
        val_5 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "DebugTimeDateCheat", value:  DateTimeCheat._mSeconds);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        if(postNotification == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    private void UpdateLabels()
    {
    
    }
    public static string GetSimulatedDate()
    {
        var val_8;
        var val_9;
        System.DateTime val_1 = System.DateTime.Now;
        val_8 = null;
        val_8 = null;
        System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)DateTimeCheat._mSeconds);
        System.DateTime val_4 = System.DateTime.Now;
        val_9 = null;
        val_9 = null;
        System.DateTime val_5 = val_4.dateData.AddSeconds(value:  (double)DateTimeCheat._mSeconds);
        return (string)val_2.dateData.ToShortDateString() + " " + val_5.dateData.ToShortTimeString();
    }
    public static System.DateTime GetSimulatedDateTime()
    {
        var val_3;
        System.DateTime val_1 = System.DateTime.Now;
        val_3 = null;
        val_3 = null;
        System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)DateTimeCheat._mSeconds);
        return (System.DateTime)val_2.dateData;
    }
    public static System.DateTime GetSimulatedUTCDateTime()
    {
        var val_3;
        System.DateTime val_1 = System.DateTime.UtcNow;
        val_3 = null;
        val_3 = null;
        System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)DateTimeCheat._mSeconds);
        return (System.DateTime)val_2.dateData;
    }
    private void ShowCheatIndicator(bool state)
    {
    
    }
    protected override void UpdateLogic()
    {
    
    }
    public DateTimeCheat()
    {
    
    }
    private static DateTimeCheat()
    {
    
    }

}
