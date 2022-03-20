using UnityEngine;
public class WGSerialTracker : MonoSingleton<WGSerialTracker>
{
    // Fields
    private bool initialized;
    private string prefkeyBalance;
    private string prefkeyLoginFirst;
    private string prefkeyLoginStart;
    private string prefkeyLoginNext;
    public decimal recordWinAmount;
    public decimal recordCreditBalance;
    public System.DateTime loginStreakFirst;
    public System.DateTime loginStreakStart;
    public System.DateTime loginStreakNext;
    
    // Properties
    public bool Initialized { get; }
    
    // Methods
    public bool get_Initialized()
    {
        return (bool)this.initialized;
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void WGSerialTracker::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        this.init();
    }
    private void OnApplicationPause(bool paused)
    {
        if(paused != false)
        {
                return;
        }
        
        this.storeData();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.storeData();
    }
    private void init()
    {
        if(this.initialized == true)
        {
                return;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  this.prefkeyBalance)) != false)
        {
                decimal val_3 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  this.prefkeyBalance));
            this.recordCreditBalance = val_3;
            mem[1152921517960032408] = val_3.lo;
            mem[1152921517960032412] = val_3.mid;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  this.prefkeyLoginFirst)) != false)
        {
                System.DateTime val_6 = System.DateTime.UtcNow;
            System.DateTime val_7 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  this.prefkeyLoginFirst), defaultValue:  new System.DateTime() {dateData = val_6.dateData});
            this.loginStreakFirst = val_7;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  this.prefkeyLoginStart)) != false)
        {
                System.DateTime val_10 = System.DateTime.UtcNow;
            System.DateTime val_11 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  this.prefkeyLoginStart), defaultValue:  new System.DateTime() {dateData = val_10.dateData});
            this.loginStreakStart = val_11;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  this.prefkeyLoginNext)) != false)
        {
                System.DateTime val_14 = System.DateTime.UtcNow;
            System.DateTime val_15 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  this.prefkeyLoginNext), defaultValue:  new System.DateTime() {dateData = val_14.dateData});
            this.loginStreakNext = val_15;
        }
        
        this.initialized = true;
    }
    public void resetData()
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  this.prefkeyBalance);
        UnityEngine.PlayerPrefs.DeleteKey(key:  this.prefkeyLoginFirst);
        UnityEngine.PlayerPrefs.DeleteKey(key:  this.prefkeyLoginStart);
        UnityEngine.PlayerPrefs.DeleteKey(key:  this.prefkeyLoginNext);
        this.initialized = false;
        this.init();
    }
    public void storeData()
    {
        if(this.initialized == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  this.prefkeyBalance, value:  this.recordCreditBalance.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  this.prefkeyLoginFirst, value:  this.loginStreakFirst.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  this.prefkeyLoginStart, value:  this.loginStreakStart.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  this.prefkeyLoginNext, value:  this.loginStreakNext.ToString());
    }
    public void OnDeferredReady()
    {
        if(this.initialized == false)
        {
                return;
        }
        
        this.PlayerReturned();
    }
    public void PlayerReturned()
    {
        float val_10;
        TrackerManager val_26;
        var val_27;
        float val_28;
        long val_29;
        var val_30;
        float val_32;
        long val_33;
        var val_34;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        val_26 = this;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = this.loginStreakNext});
        double val_3 = val_2._ticks.TotalDays;
        if(val_3 <= 1)
        {
            goto label_3;
        }
        
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        this.loginStreakStart = val_4;
        goto label_6;
        label_3:
        if(val_3 <= 0f)
        {
            goto label_7;
        }
        
        label_6:
        System.DateTime val_5 = this.loginStreakNext.AddDays(value:  1);
        this.loginStreakNext = val_5;
        label_7:
        val_27 = 1152921504884269056;
        Player val_6 = App.Player;
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.TimeSpan val_8 = val_7.dateData.Subtract(value:  new System.DateTime() {dateData = this.loginStreakStart});
        double val_9 = val_8._ticks.TotalDays;
        if(val_9 >= 0f)
        {
            goto label_14;
        }
        
        if(val_9 != (-0.5))
        {
            goto label_15;
        }
        
        val_28 = val_10;
        val_29 = (long)val_28;
        val_30 = val_28 + (-1);
        goto label_16;
        label_14:
        if(val_9 != 0.5)
        {
            goto label_17;
        }
        
        val_28 = val_10;
        val_29 = (long)val_28;
        val_30 = val_28 + 1;
        label_16:
        var val_11 = ((val_29 & 1) != 0) ? (val_28) : (val_30);
        goto label_19;
        label_15:
        val_28 = val_9 + (-0.5);
        goto label_19;
        label_17:
        val_28 = val_9 + 0.5;
        label_19:
        System.DateTime val_12 = DateTimeCheat.UtcNow;
        System.TimeSpan val_13 = val_12.dateData.Subtract(value:  new System.DateTime() {dateData = val_6.created_at});
        double val_14 = val_13._ticks.TotalDays;
        if(val_14 >= 0f)
        {
            goto label_21;
        }
        
        if(val_14 != (-0.5))
        {
            goto label_22;
        }
        
        val_32 = val_10;
        val_33 = (long)val_32;
        val_34 = val_32 + (-1);
        goto label_23;
        label_21:
        if(val_14 != 0.5)
        {
            goto label_24;
        }
        
        val_32 = val_10;
        val_33 = (long)val_32;
        val_34 = val_32 + 1;
        label_23:
        var val_15 = ((val_33 & 1) != 0) ? (val_32) : (val_34);
        goto label_26;
        label_22:
        val_14 = val_14 + (-0.5);
        goto label_26;
        label_24:
        val_14 = val_14 + 0.5;
        label_26:
        if((val_14 == 1) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d1")) != true))
        {
                if(D9 == 1)
        {
                val_36 = null;
            val_36 = null;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D1);
        }
        
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d1", value:  1);
        }
        
        if((val_14 == 2) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d2")) != true))
        {
                if(D9 == 2)
        {
                val_37 = null;
            val_37 = null;
            App.trackerManager.track(eventName:  Events.RETENTION_D2_CONSECUTIVE);
        }
        
            val_38 = null;
            val_38 = null;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D2);
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d2", value:  1);
        }
        
        if((val_14 == 3) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d3")) != true))
        {
                if(D9 == 3)
        {
                val_39 = null;
            val_39 = null;
            App.trackerManager.track(eventName:  Events.RETENTION_D3_CONSECUTIVE);
        }
        
            val_40 = null;
            val_40 = null;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D3);
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d3", value:  1);
        }
        
        if((val_14 == 6) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d6")) != true))
        {
                if(D9 == 6)
        {
                val_41 = null;
            val_41 = null;
            App.trackerManager.track(eventName:  Events.RETENTION_D6_CONSECUTIVE);
        }
        
            val_42 = null;
            val_42 = null;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D6);
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d6", value:  1);
        }
        
        if((val_14 == 7) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d7")) != true))
        {
                if(D9 == 7)
        {
                val_43 = null;
            val_43 = null;
            App.trackerManager.track(eventName:  Events.RETENTION_D7_CONSECUTIVE);
        }
        
            val_44 = null;
            val_44 = null;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D7);
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d7", value:  1);
        }
        
        if((val_14 == 30) && ((UnityEngine.PlayerPrefs.HasKey(key:  "ret_d30")) != true))
        {
                val_45 = null;
            val_45 = null;
            val_27 = 1152921504883736576;
            val_26 = App.trackerManager;
            val_26.track(eventName:  Events.RETENTION_D30);
            UnityEngine.PlayerPrefs.SetInt(key:  "ret_d30", value:  1);
        }
        
        PurchaseAndRetention();
        PlayerLevelAndRetention();
        AdsAndRetention();
    }
    public void debugLoginDayAdvance()
    {
        System.DateTime val_1 = this.loginStreakStart.AddDays(value:  -1);
        this.loginStreakStart = val_1;
        System.DateTime val_2 = this.loginStreakNext.AddDays(value:  -1);
        this.loginStreakNext = val_2;
    }
    public void PurchaseTrackHour()
    {
        Player val_1 = App.Player;
        if(val_1.num_purchase > 1)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = val_2.dateData.Subtract(value:  new System.DateTime() {dateData = val_1.created_at});
        double val_4 = val_3._ticks.TotalHours;
    }
    public void PurchaseAndRetention()
    {
        float val_5;
        TrackerManager val_18;
        float val_19;
        double val_20;
        string val_22;
        var val_23;
        string val_24;
        var val_25;
        var val_26;
        var val_27;
        val_18 = App.Player;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = val_2.dateData.Subtract(value:  new System.DateTime() {dateData = val_1.created_at});
        double val_4 = val_3._ticks.TotalDays;
        if(val_4 >= 0f)
        {
            goto label_8;
        }
        
        if(val_4 != (-0.5))
        {
            goto label_9;
        }
        
        val_19 = val_5;
        val_20 = -1;
        goto label_10;
        label_8:
        if(val_4 != 0.5)
        {
            goto label_11;
        }
        
        val_19 = val_5;
        val_20 = 1;
        label_10:
        val_20 = val_19 + val_20;
        val_19 = (((long)val_19 & 1) != 0) ? (val_19) : (val_20);
        goto label_13;
        label_9:
        double val_6 = val_4 + (-0.5);
        goto label_13;
        label_11:
        double val_7 = val_4 + 0.5;
        label_13:
        if(val_7 == 7)
        {
                Player val_8 = App.Player;
            if(val_8.num_purchase < 10)
        {
                return;
        }
        
            val_22 = "pur_ret_1007";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "pur_ret_1007")) == true)
        {
                return;
        }
        
            val_23 = null;
            val_23 = null;
            val_18 = App.trackerManager;
            val_24 = Events.PUR_RET_1007;
        }
        else
        {
                if(val_7 == 3)
        {
                val_22 = "d3_pur_sub";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d3_pur_sub")) == true)
        {
                return;
        }
        
            Player val_11 = App.Player;
            val_18 = val_11.properties.numSubscriptionsPurchased;
            Player val_12 = App.Player;
            int val_18 = val_12.properties.numSubscriptionsPurchased_Silver;
            val_18 = val_18 + val_18;
            if(val_18 < 1)
        {
                return;
        }
        
            val_25 = null;
            val_25 = null;
            val_18 = App.trackerManager;
            val_24 = Events.D3_SUB_PURCHASE;
        }
        else
        {
                if(val_7 != 1)
        {
                return;
        }
        
            Player val_13 = App.Player;
            if(val_13.num_purchase >= 1)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "pur_ret_0101")) != true)
        {
                val_26 = null;
            val_26 = null;
            val_18 = App.trackerManager;
            val_18.track(eventName:  Events.PUR_RET_0101);
            UnityEngine.PlayerPrefs.SetInt(key:  "pur_ret_0101", value:  1);
        }
        
        }
        
            val_22 = "d1_pur_sub";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d1_pur_sub")) == true)
        {
                return;
        }
        
            Player val_16 = App.Player;
            val_18 = val_16.properties.numSubscriptionsPurchased;
            Player val_17 = App.Player;
            int val_19 = val_17.properties.numSubscriptionsPurchased_Silver;
            val_19 = val_19 + val_18;
            if(val_19 < 1)
        {
                return;
        }
        
            val_27 = null;
            val_27 = null;
            val_18 = App.trackerManager;
            val_24 = Events.D1_SUB_PURCHASE;
        }
        
        }
        
        val_18.track(eventName:  val_24);
        UnityEngine.PlayerPrefs.SetInt(key:  val_22, value:  1);
    }
    public void PlayerLevelAndRetention()
    {
        float val_5;
        TrackerManager val_12;
        float val_13;
        double val_14;
        string val_16;
        var val_17;
        string val_18;
        var val_19;
        val_12 = App.Player;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = val_2.dateData.Subtract(value:  new System.DateTime() {dateData = val_1.created_at});
        double val_4 = val_3._ticks.TotalDays;
        if(val_4 >= 0f)
        {
            goto label_8;
        }
        
        if(val_4 != (-0.5))
        {
            goto label_9;
        }
        
        val_13 = val_5;
        val_14 = -1;
        goto label_10;
        label_8:
        if(val_4 != 0.5)
        {
            goto label_11;
        }
        
        val_13 = val_5;
        val_14 = 1;
        label_10:
        val_14 = val_13 + val_14;
        val_13 = (((long)val_13 & 1) != 0) ? (val_13) : (val_14);
        goto label_13;
        label_9:
        double val_6 = val_4 + (-0.5);
        goto label_13;
        label_11:
        double val_7 = val_4 + 0.5;
        label_13:
        if(val_7 == 3)
        {
                val_16 = "d3_lvl_100";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d3_lvl_100")) == true)
        {
                return;
        }
        
            GameBehavior val_9 = App.getBehavior;
            if((val_9.<metaGameBehavior>k__BackingField) < 100)
        {
                return;
        }
        
            val_17 = null;
            val_17 = null;
            val_12 = App.trackerManager;
            val_18 = Events.D3_LEVEL_100;
        }
        else
        {
                if(val_7 != 1)
        {
                return;
        }
        
            val_16 = "d1_lvl_100";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d1_lvl_100")) == true)
        {
                return;
        }
        
            GameBehavior val_11 = App.getBehavior;
            if((val_11.<metaGameBehavior>k__BackingField) < 100)
        {
                return;
        }
        
            val_19 = null;
            val_19 = null;
            val_12 = App.trackerManager;
            val_18 = Events.D1_LEVEL_100;
        }
        
        val_12.track(eventName:  val_18);
        UnityEngine.PlayerPrefs.SetInt(key:  val_16, value:  1);
    }
    public void AdsAndRetention()
    {
        float val_5;
        TrackerManager val_16;
        float val_17;
        double val_18;
        var val_20;
        string val_21;
        var val_22;
        string val_23;
        var val_24;
        var val_25;
        val_16 = App.Player;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = val_2.dateData.Subtract(value:  new System.DateTime() {dateData = val_1.created_at});
        double val_4 = val_3._ticks.TotalDays;
        if(val_4 >= 0f)
        {
            goto label_8;
        }
        
        if(val_4 != (-0.5))
        {
            goto label_9;
        }
        
        val_17 = val_5;
        val_18 = -1;
        goto label_10;
        label_8:
        if(val_4 != 0.5)
        {
            goto label_11;
        }
        
        val_17 = val_5;
        val_18 = 1;
        label_10:
        val_18 = val_17 + val_18;
        val_17 = (((long)val_17 & 1) != 0) ? (val_17) : (val_18);
        goto label_13;
        label_9:
        double val_6 = val_4 + (-0.5);
        goto label_13;
        label_11:
        double val_7 = val_4 + 0.5;
        label_13:
        if(val_7 == 3)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "d3_ad_10")) != true)
        {
                Player val_9 = App.Player;
            if(val_9.num_ad_clicks >= 10)
        {
                val_20 = null;
            val_20 = null;
            val_16 = App.trackerManager;
            val_16.track(eventName:  Events.D3_AD_CLICKED_10);
            UnityEngine.PlayerPrefs.SetInt(key:  "d3_ad_10", value:  1);
        }
        
        }
        
            val_21 = "d3_vid_5";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d3_vid_5")) == true)
        {
                return;
        }
        
            Player val_11 = App.Player;
            if(val_11.properties.incentivisedVideosWatched < 5)
        {
                return;
        }
        
            val_22 = null;
            val_22 = null;
            val_16 = App.trackerManager;
            val_23 = Events.D3_REW_VID_05;
        }
        else
        {
                if(val_7 != 1)
        {
                return;
        }
        
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d1_ad_10")) != true)
        {
                Player val_13 = App.Player;
            if(val_13.num_ad_clicks >= 10)
        {
                val_24 = null;
            val_24 = null;
            val_16 = App.trackerManager;
            val_16.track(eventName:  Events.D1_AD_CLICKED_10);
            UnityEngine.PlayerPrefs.SetInt(key:  "d1_ad_10", value:  1);
        }
        
        }
        
            val_21 = "d1_vid_5";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "d1_vid_5")) == true)
        {
                return;
        }
        
            Player val_15 = App.Player;
            if(val_15.properties.incentivisedVideosWatched < 5)
        {
                return;
        }
        
            val_25 = null;
            val_25 = null;
            val_16 = App.trackerManager;
            val_23 = Events.D1_REW_VID_05;
        }
        
        val_16.track(eventName:  val_23);
        UnityEngine.PlayerPrefs.SetInt(key:  val_21, value:  1);
    }
    public WGSerialTracker()
    {
        this.prefkeyBalance = "ChallengeTrackerBalance";
        this.prefkeyLoginFirst = "ChallengeTrackerLoginFirst";
        this.prefkeyLoginStart = "ChallengeTrackerLoginStart";
        this.prefkeyLoginNext = "ChallengeTrackerLoginNext";
    }

}
