using UnityEngine;
public class WGGenericNotificationsManager : MonoSingleton<WGGenericNotificationsManager>
{
    // Fields
    private const string PREFS_1_HOUR = "1_hour_engagement_notif";
    public static bool hint48Enabled;
    public static bool hint1Enabled;
    public static bool dailyBonusEnable;
    public static bool postAdEnabled;
    public static bool levelAnswerEnabled;
    private static int hint1Hours;
    private static int hint2Hours;
    private static string urlEngagementImg;
    private static string urlEngagementBase;
    private static int levelAnswerHours;
    private static string urlDailyBonusImg;
    public static bool dcMorningReminderEnabled;
    public static bool dcEveningReminderEnabled;
    private static string urlPostAdImg;
    private static bool postedNotif;
    private WGRecaptureNotifications recaptureNotifications;
    private WGNotificationLifecycle lifecycle;
    private static string <LastNextWord>k__BackingField;
    
    // Properties
    public static string UrlDailyBonusImg { get; }
    public static string LastNextWord { get; set; }
    
    // Methods
    public static string get_UrlDailyBonusImg()
    {
        null = null;
        return (string)WGGenericNotificationsManager.urlDailyBonusImg;
    }
    public override void InitMonoSingleton()
    {
        var val_4;
        GameBehavior val_1 = App.getBehavior;
        val_4 = null;
        val_4 = null;
        WGGenericNotificationsManager.urlDailyBonusImg = val_1.<metaGameBehavior>k__BackingField;
        GameBehavior val_2 = App.getBehavior;
        WGGenericNotificationsManager.urlPostAdImg = val_2.<metaGameBehavior>k__BackingField;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
    }
    private void Start()
    {
        WGGenericNotificationsManager.ReadFromKnobs();
        if(WGNotificationLifecycle.IsEnabled() == false)
        {
                return;
        }
        
        if(this.lifecycle != 0)
        {
                return;
        }
        
        WGNotificationLifecycle val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<WGNotificationLifecycle>(child:  this);
        this.lifecycle = val_3;
        val_3.Init();
    }
    private void OnServerSync()
    {
        WGGenericNotificationsManager.ReadFromKnobs();
    }
    public static void ReadFromKnobs()
    {
        string val_5;
        var val_6;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        val_34 = 1152921504884269056;
        val_35 = null;
        val_35 = null;
        System.Collections.IDictionary val_1 = getGenericNofications();
        if(val_1 == null)
        {
                return;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_3 = (((System.Collections.IDictionary.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_1) : 0.GetEnumerator();
        label_14:
        val_34 = 0;
        label_13:
        if(val_6.MoveNext() == false)
        {
            goto label_12;
        }
        
        if((System.String.op_Equality(a:  val_5, b:  "word_addict_notifications")) == false)
        {
            goto label_13;
        }
        
        new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
        goto label_14;
        label_12:
        val_6.Dispose();
        if(val_34 == 0)
        {
                return;
        }
        
        val_36 = null;
        val_36 = null;
        WGGenericNotificationsManager.hint48Enabled = val_34.getBool(key:  "free_hint_48_enable");
        WGGenericNotificationsManager.hint1Enabled = val_34.getBool(key:  "free_hint_1_enable");
        WGGenericNotificationsManager.dailyBonusEnable = val_34.getBool(key:  "daily_bonus_enable");
        WGGenericNotificationsManager.postAdEnabled = val_34.getBool(key:  "post_ad_enable");
        WGGenericNotificationsManager.levelAnswerEnabled = val_34.getBool(key:  "level_answer_enabled");
        WGGenericNotificationsManager.dcMorningReminderEnabled = val_34.getBool(key:  "dc_morning_reminder_enable");
        val_37 = null;
        WGGenericNotificationsManager.dcEveningReminderEnabled = val_34.getBool(key:  "dc_evening_reminder_enable");
        if(WGGenericNotificationsManager.hint48Enabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  5);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.hint1Enabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  6);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.dailyBonusEnable != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  2);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.postAdEnabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  7);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.levelAnswerEnabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  15);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.dcMorningReminderEnabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  16);
            val_37 = null;
        }
        
        val_37 = null;
        if(WGGenericNotificationsManager.dcEveningReminderEnabled != true)
        {
                WGGenericNotificationsManager.CancelDisabledNotification(type:  17);
            val_37 = null;
        }
        
        val_37 = null;
        WGGenericNotificationsManager.hint1Hours = val_34.getInt(key:  "engagement_1", defaultValue:  WGGenericNotificationsManager.hint1Hours);
        WGGenericNotificationsManager.hint2Hours = val_34.getInt(key:  "engagement_2", defaultValue:  WGGenericNotificationsManager.hint2Hours);
        WGGenericNotificationsManager.urlEngagementImg = val_34.getString(key:  "engagement_image", defaultValue:  WGGenericNotificationsManager.urlEngagementImg);
        WGGenericNotificationsManager.urlEngagementBase = val_34.getString(key:  "level_image_url", defaultValue:  WGGenericNotificationsManager.urlEngagementBase);
        WGGenericNotificationsManager.levelAnswerHours = val_34.getInt(key:  "level_answer_hours", defaultValue:  WGGenericNotificationsManager.levelAnswerHours);
        WGGenericNotificationsManager.urlDailyBonusImg = val_34.getString(key:  "daily_bonus_image", defaultValue:  WGGenericNotificationsManager.urlDailyBonusImg);
        WGGenericNotificationsManager.urlPostAdImg = val_34.getString(key:  "post_ad_image", defaultValue:  WGGenericNotificationsManager.urlPostAdImg);
        val_34 = NotificationCenter.DefaultCenter;
        val_34.RemoveObserver(observer:  MonoSingleton<WGGenericNotificationsManager>.Instance, name:  "OnServerSync");
    }
    public static void SendEngagementNotifications(bool QAHACK_Force = False)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_14;
        var val_15;
        var val_17;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18;
        object val_19;
        var val_20;
        var val_22;
        var val_23;
        val_14 = QAHACK_Force;
        val_15 = null;
        val_15 = null;
        if(WGGenericNotificationsManager.hint48Enabled != true)
        {
                if(val_14 == false)
        {
            goto label_4;
        }
        
        }
        
        if(val_14 != false)
        {
                System.DateTime val_1 = DateTimeCheat.Now;
            System.DateTime val_2 = val_1.dateData.AddSeconds(value:  8);
        }
        else
        {
                System.DateTime val_3 = DateTimeCheat.Now;
            val_17 = null;
            val_17 = null;
            System.DateTime val_4 = val_3.dateData.AddHours(value:  (double)WGGenericNotificationsManager.hint2Hours);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
        val_18 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_19 = 1152921515419383392;
        val_5.Add(key:  "scene", value:  1);
        val_5.Add(key:  "hint", value:  1);
        val_5.Add(key:  "notification_type", value:  "free_hint_reengage");
        val_20 = null;
        val_20 = null;
        GameBehavior val_6 = App.getBehavior;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotifWithImage(type:  5, when:  new System.DateTime() {dateData = val_4.dateData}, interval:  0, title:  0, message:  "Almost there! Here’s a FREE Hint to keep you going!", extraData:  val_5, imageUrl:  System.String.Format(format:  "{0}{1}.png", arg0:  WGGenericNotificationsManager.urlEngagementBase, arg1:  val_6.<metaGameBehavior>k__BackingField), priority:  0, useTimeModifier:  true);
        val_15 = null;
        label_4:
        val_15 = null;
        if(WGGenericNotificationsManager.hint1Enabled != true)
        {
                if(val_14 == false)
        {
                return;
        }
        
        }
        
        if(val_14 != false)
        {
                System.DateTime val_8 = DateTimeCheat.Now;
            System.DateTime val_9 = val_8.dateData.AddSeconds(value:  8);
        }
        else
        {
                System.DateTime val_10 = DateTimeCheat.Now;
            val_22 = null;
            val_22 = null;
            System.DateTime val_11 = val_10.dateData.AddHours(value:  (double)WGGenericNotificationsManager.hint1Hours);
        }
        
        if((CPlayerPrefs.HasKey(key:  "1_hour_engagement_notif")) != false)
        {
                if(val_14 == false)
        {
                return;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = null;
        val_14 = val_13;
        val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_19 = 1;
        val_13.Add(key:  "scene", value:  val_19);
        val_13.Add(key:  "hint", value:  val_19);
        val_13.Add(key:  "notification_type", value:  "free_hint_first");
        val_23 = null;
        val_23 = null;
        val_18 = WGGenericNotificationsManager.urlEngagementImg;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotifWithImage(type:  6, when:  new System.DateTime() {dateData = val_11.dateData}, interval:  0, title:  "Free Welcome Hint to help you get started", message:  "Good luck!", extraData:  val_13, imageUrl:  val_18, priority:  0, useTimeModifier:  true);
        CPlayerPrefs.SetBool(key:  "1_hour_engagement_notif", value:  true);
        CPlayerPrefs.Save();
    }
    public static void SendPostAdNotification(bool QAHACK_Force = False)
    {
        string val_7;
        var val_8;
        var val_9;
        if(QAHACK_Force != false)
        {
                System.DateTime val_1 = DateTimeCheat.Now;
            System.DateTime val_2 = val_1.dateData.AddSeconds(value:  8);
        }
        else
        {
                System.DateTime val_3 = DateTimeCheat.Now;
            System.DateTime val_4 = val_3.dateData.AddMinutes(value:  5);
        }
        
        val_7 = 1152921504977879040;
        val_8 = null;
        val_8 = null;
        if(WGGenericNotificationsManager.postAdEnabled != true)
        {
                if(QAHACK_Force == false)
        {
                return;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "scene", value:  1);
        val_5.Add(key:  "notification_type", value:  "postad");
        val_9 = null;
        val_9 = null;
        val_7 = WGGenericNotificationsManager.urlPostAdImg;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotifWithImage(type:  7, when:  new System.DateTime() {dateData = val_4.dateData}, interval:  0, title:  "YOU\'RE ALMOST THERE", message:  "Come back to finish the level!", extraData:  val_5, imageUrl:  val_7, priority:  1, useTimeModifier:  false);
    }
    public static void SendDailyBonusNotification(bool QAHACK_Force = False)
    {
        ulong val_9;
        string val_10;
        var val_11;
        var val_13;
        val_9 = QAHACK_Force;
        val_10 = 1152921504977879040;
        val_11 = null;
        val_11 = null;
        if(WGGenericNotificationsManager.dailyBonusEnable != true)
        {
                if(val_9 == false)
        {
                return;
        }
        
        }
        
        if(val_9 != false)
        {
                System.DateTime val_1 = DateTimeCheat.Now;
            System.DateTime val_2 = val_1.dateData.AddSeconds(value:  8);
        }
        else
        {
                System.DateTime val_3 = DateTimeCheat.Now;
            GameEcon val_4 = App.getGameEcon;
            System.DateTime val_5 = val_3.dateData.AddHours(value:  (double)val_4.dailyBonusHours);
        }
        
        val_9 = val_5.dateData;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "notification_type", value:  "daily_reward");
        GameBehavior val_7 = App.getBehavior;
        GameBehavior val_8 = App.getBehavior;
        val_13 = null;
        val_13 = null;
        val_10 = WGGenericNotificationsManager.urlDailyBonusImg;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotifWithImage(type:  2, when:  new System.DateTime() {dateData = val_9}, interval:  0, title:  val_7.<metaGameBehavior>k__BackingField, message:  val_8.<metaGameBehavior>k__BackingField, extraData:  val_6, imageUrl:  val_10, priority:  0, useTimeModifier:  true);
    }
    public static string get_LastNextWord()
    {
        null = null;
        return (string)WGGenericNotificationsManager.<LastNextWord>k__BackingField;
    }
    private static void set_LastNextWord(string value)
    {
        null = null;
        WGGenericNotificationsManager.<LastNextWord>k__BackingField = value;
    }
    public static void SendLevelAnwserNotification(string nextWord, bool QAHACK_Force = False)
    {
        ulong val_19;
        var val_20;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        val_20 = null;
        val_20 = null;
        if((WGGenericNotificationsManager.levelAnswerEnabled == false) || ((System.String.IsNullOrEmpty(value:  nextWord)) == true))
        {
            goto label_22;
        }
        
        if(QAHACK_Force != false)
        {
                System.DateTime val_2 = DateTimeCheat.Now;
            System.DateTime val_3 = val_2.dateData.AddSeconds(value:  8);
        }
        else
        {
                System.DateTime val_4 = DateTimeCheat.Now;
            val_22 = null;
            val_22 = null;
            System.DateTime val_5 = val_4.dateData.AddHours(value:  (double)WGGenericNotificationsManager.levelAnswerHours);
        }
        
        val_19 = "last_level_answer_time";
        val_23 = null;
        val_23 = null;
        System.DateTime val_7 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "last_level_answer_time"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        System.DateTime val_8 = DateTimeCheat.Now;
        if((val_8.dateData.CompareTo(value:  new System.DateTime() {dateData = val_7.dateData})) < 1)
        {
            goto label_17;
        }
        
        System.DateTime val_10 = DateTimeCheat.Now;
        System.DateTime val_11 = val_7.dateData.AddDays(value:  1);
        if(((val_10.dateData.CompareTo(value:  new System.DateTime() {dateData = val_11.dateData})) & 2147483648) != 0)
        {
            goto label_20;
        }
        
        label_17:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_13.Add(key:  "scene", value:  1);
        val_13.Add(key:  "notification_type", value:  "levelcomplete_answer");
        if((System.String.op_Inequality(a:  nextWord, b:  System.String.alignConst)) != false)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "last_level_answer_time", value:  val_5.dateData.ToString());
            val_19 = val_5.dateData;
            GameBehavior val_16 = App.getBehavior;
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  15, when:  new System.DateTime() {dateData = val_19}, interval:  0, optTitle:  "HERE\'S A HINT", optMessage:  System.String.Format(format:  "Clear level {0}, the answer is {1}!", arg0:  val_16.<metaGameBehavior>k__BackingField.ToString(), arg1:  nextWord), extraData:  val_13, priority:  1, useTimeModifier:  false);
            val_24 = null;
            val_24 = null;
            WGGenericNotificationsManager.postedNotif = true;
        }
        
        label_22:
        val_25 = null;
        val_25 = null;
        WGGenericNotificationsManager.<LastNextWord>k__BackingField = nextWord;
        return;
        label_20:
        UnityEngine.Debug.LogWarning(message:  "WGGenericNotificationsManager: Already sent/scheduled a levelcomplete_answer notif today, not sending again.");
    }
    public static void SendDailyChallengeMorningReminder(int hour, bool QAHACK_Force = False)
    {
        var val_15;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_16;
        var val_17;
        val_15 = QAHACK_Force;
        val_16 = 1152921504977879040;
        val_17 = null;
        val_17 = null;
        if(WGGenericNotificationsManager.dcMorningReminderEnabled != true)
        {
                if(val_15 == false)
        {
                return;
        }
        
        }
        
        WGGenericNotificationsManager.CancelDailyChallengeNotification();
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = DateTimeCheat.Today;
        System.DateTime val_3 = val_2.dateData.AddHours(value:  (double)hour);
        System.DateTime val_4 = val_3.dateData.AddMinutes(value:  -10);
        if(((val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_4.dateData})) & 2147483648) == 0)
        {
                System.DateTime val_6 = DateTimeCheat.Today;
            System.DateTime val_7 = val_6.dateData.AddDays(value:  1);
        }
        else
        {
                System.DateTime val_8 = DateTimeCheat.Today;
        }
        
        System.DateTime val_9 = val_8.dateData.AddHours(value:  (double)hour);
        System.DateTime val_10 = val_9.dateData.AddMinutes(value:  -10);
        if(val_15 != false)
        {
                System.DateTime val_11 = DateTimeCheat.Now;
            System.DateTime val_12 = val_11.dateData.AddSeconds(value:  8);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = null;
        val_16 = val_13;
        val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_13.Add(key:  "daily_challenge", value:  true);
        val_13.Add(key:  "notification_type", value:  "AMChallenge_ending");
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  16, when:  new System.DateTime() {dateData = val_12.dateData}, interval:  (val_15 != true) ? 0 : 86400, optTitle:  "MORNING CHALLENGE ENDING", optMessage:  "Hurry, the Morning Challenge ends soon!", extraData:  val_13, priority:  0, useTimeModifier:  true);
    }
    public static void SendDailyChallengeEveningReminder(int hour, bool QAHACK_Force = False)
    {
        var val_13;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_14;
        var val_15;
        val_13 = QAHACK_Force;
        val_14 = 1152921504977879040;
        val_15 = null;
        val_15 = null;
        if(WGGenericNotificationsManager.dcEveningReminderEnabled != true)
        {
                if(val_13 == false)
        {
                return;
        }
        
        }
        
        WGGenericNotificationsManager.CancelDailyChallengeEveningNotification();
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = DateTimeCheat.Today;
        System.DateTime val_3 = val_2.dateData.AddHours(value:  (double)hour);
        if(((val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_3.dateData})) & 2147483648) == 0)
        {
                System.DateTime val_5 = DateTimeCheat.Today;
            System.DateTime val_6 = val_5.dateData.AddDays(value:  1);
        }
        else
        {
                System.DateTime val_7 = DateTimeCheat.Today;
        }
        
        System.DateTime val_8 = val_7.dateData.AddHours(value:  (double)hour);
        if(val_13 != false)
        {
                System.DateTime val_9 = DateTimeCheat.Now;
            System.DateTime val_10 = val_9.dateData.AddSeconds(value:  8);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = null;
        val_14 = val_11;
        val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_11.Add(key:  "daily_challenge", value:  true);
        val_11.Add(key:  "notification_type", value:  "PMChallenge_ending");
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  17, when:  new System.DateTime() {dateData = val_10.dateData}, interval:  (val_13 != true) ? 0 : 86400, optTitle:  "EVENING CHALLENGE ENDING", optMessage:  "The Evening Challenge is wrapping up soon!", extraData:  val_11, priority:  0, useTimeModifier:  true);
    }
    public static void CancelLevelAnswerNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  15);
    }
    public static void CancelPostAdNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  7);
    }
    public static void CancelDailyChallengeNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  16);
    }
    public static void CancelDailyChallengeEveningNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  17);
    }
    public static void CancelDisabledNotification(twelvegigs.plugins.NotificationType type)
    {
        UnityEngine.Debug.Log(message:  "WG Notifications-- cancel disabled: "("WG Notifications-- cancel disabled: ") + type.ToString());
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  type);
    }
    public WGGenericNotificationsManager()
    {
    
    }
    private static WGGenericNotificationsManager()
    {
        WGGenericNotificationsManager.hint48Enabled = false;
        WGGenericNotificationsManager.hint1Enabled = false;
        WGGenericNotificationsManager.dailyBonusEnable = true;
        WGGenericNotificationsManager.postAdEnabled = true;
        WGGenericNotificationsManager.levelAnswerEnabled = true;
        WGGenericNotificationsManager.hint1Hours = true;
        WGGenericNotificationsManager.hint2Hours = 48;
        WGGenericNotificationsManager.urlEngagementImg = "https://s3-us-west-1.amazonaws.com/12gcontent/WordAddictRpnImg/FreeHint1hr.png";
        WGGenericNotificationsManager.urlEngagementBase = "https://s3-us-west-1.amazonaws.com/12gcontent/WordAddictRpnImg/levels/";
        WGGenericNotificationsManager.levelAnswerHours = true;
        WGGenericNotificationsManager.dcMorningReminderEnabled = true;
        WGGenericNotificationsManager.dcEveningReminderEnabled = true;
        WGGenericNotificationsManager.postedNotif = false;
    }

}
