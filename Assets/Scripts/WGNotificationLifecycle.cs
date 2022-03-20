using UnityEngine;
public class WGNotificationLifecycle : MonoBehaviour
{
    // Fields
    private const int GIFT_SMALL = 120;
    private System.Collections.Generic.List<string> FeatureTeaser;
    private int[] FeaureLevels;
    private System.Collections.Generic.Dictionary<string, string[]> eventsNotifications;
    private System.DateTime localInstalledDate;
    private bool initialized;
    private bool knobEnabled;
    
    // Methods
    public static bool IsEnabled()
    {
        ulong val_7;
        ulong val_8;
        val_7 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Player val_2 = App.Player;
            System.DateTime val_3 = val_2.created_at.ToLocalTime();
            System.DateTime val_4 = val_3.dateData.AddDays(value:  2);
            val_7 = val_4.dateData;
            System.DateTime val_5 = DateTimeCheat.Now;
            val_8 = val_7;
            bool val_6 = System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_8}, t2:  new System.DateTime() {dateData = val_5.dateData});
        }
        else
        {
                val_8 = 0;
        }
        
        val_8 = val_8 & 1;
        return (bool)val_8;
    }
    public void Init()
    {
        var val_8;
        bool val_9;
        if(this.initialized == true)
        {
                return;
        }
        
        val_8 = null;
        val_8 = null;
        if(getGameplayKnobs() == null)
        {
                return;
        }
        
        val_9 = "push_notification_lifecycle";
        if((val_1.dataSource.ContainsKey(key:  "push_notification_lifecycle")) != false)
        {
                val_9 = this.knobEnabled;
            bool val_5 = System.Boolean.TryParse(value:  val_1.dataSource.Item["push_notification_lifecycle"], result: out  val_9);
        }
        
        Player val_6 = App.Player;
        System.DateTime val_7 = val_6.created_at.ToLocalTime();
        this.localInstalledDate = val_7;
        this.initialized = true;
    }
    private void OnApplicationPause(bool pause)
    {
        if(this.knobEnabled == false)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = this.localInstalledDate});
        double val_3 = val_2._ticks.TotalDays;
        if(val_3 > 2)
        {
                return;
        }
        
        bool val_4 = pause;
        this.ScheduleDripNotification(pause:  val_4, totalDays:  val_3);
        this.ScheduleConditionalNotification(pause:  val_4, totalDays:  val_3);
    }
    private void ScheduleDripNotification(bool pause, double totalDays)
    {
        if(totalDays > 1)
        {
                return;
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  22);
        if(pause == false)
        {
                return;
        }
        
        Player val_1 = App.Player;
        if(val_1.lifetimePlays <= 0)
        {
                System.DateTime val_2 = System.DateTime.Now;
            System.DateTime val_3 = val_2.dateData.AddMinutes(value:  30);
            val_3.dateData.SendNotification(when:  new System.DateTime() {dateData = val_3.dateData}, message:  "Welcome! QUICK FACT: Playing every day can improve your memory!", ampTag:  "drip1_pnl", extraData:  0, ntype:  22);
        }
        
        System.DateTime val_4 = this.localInstalledDate.AddDays(value:  1);
        System.DateTime val_5 = val_4.dateData.Date;
        System.DateTime val_6 = val_5.dateData.AddHours(value:  12);
        val_6.dateData.SendNotification(when:  new System.DateTime() {dateData = val_6.dateData}, message:  "Keep it up! Puzzles become more challenging at higher levels!", ampTag:  "drip2_pnl", extraData:  0, ntype:  22);
    }
    private void ScheduleConditionalNotification(bool pause, double totalDays)
    {
        if(totalDays > 2)
        {
                return;
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  23);
        if(pause == false)
        {
                return;
        }
        
        Player val_1 = App.Player;
        if(val_1.lifetimePlays <= 0)
        {
                System.DateTime val_2 = DateTimeCheat.Now;
            this.ConditionalNotifications(day:  1, when:  new System.DateTime() {dateData = val_2.dateData});
        }
        
        System.DateTime val_3 = this.localInstalledDate.AddDays(value:  1);
        System.DateTime val_4 = val_3.dateData.Date;
        System.DateTime val_5 = val_4.dateData.AddHours(value:  12);
        System.DateTime val_6 = DateTimeCheat.Now;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_6.dateData}, t2:  new System.DateTime() {dateData = val_5.dateData})) == false)
        {
                return;
        }
        
        this.ConditionalNotifications(day:  2, when:  new System.DateTime() {dateData = val_5.dateData});
    }
    private void ConditionalNotifications(int day, System.DateTime when)
    {
        string val_13;
        int val_14;
        var val_15;
        val_13 = day;
        Player val_1 = App.Player;
        decimal val_2 = new System.Decimal(value:  120);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo})) != false)
        {
                System.DateTime val_4 = when.dateData.AddHours(value:  2);
            val_4.dateData.GenericNotification(genericType:  1, when:  new System.DateTime() {dateData = val_4.dateData});
            val_14 = App.Player;
        }
        else
        {
                val_14 = App.Player;
        }
        
        System.DateTime val_7 = when.dateData.AddHours(value:  2);
        this.FeatureNotification(level:  val_14, when:  new System.DateTime() {dateData = val_7.dateData});
        System.DateTime val_8 = when.dateData.AddHours(value:  4);
        this.EventsNotification(when:  new System.DateTime() {dateData = val_8.dateData});
        System.DateTime val_9 = when.dateData.AddHours(value:  6);
        val_9.dateData.GenericNotification(genericType:  0, when:  new System.DateTime() {dateData = val_9.dateData});
        if(val_13 != 2)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        val_13 = WGGenericNotificationsManager.<LastNextWord>k__BackingField;
        if((System.String.IsNullOrEmpty(value:  val_13)) != true)
        {
                System.DateTime val_11 = when.dateData.AddHours(value:  1);
            val_11.dateData.SendLevelAnwserNotification(when:  new System.DateTime() {dateData = val_11.dateData}, nextWord:  val_13);
        }
        
        System.DateTime val_12 = when.dateData.AddHours(value:  6);
        val_12.dateData.GenericNotification(genericType:  2, when:  new System.DateTime() {dateData = val_12.dateData});
    }
    private void GenericNotification(WGNotificationLifecycle.GenericType genericType, System.DateTime when)
    {
        var val_3;
        string val_4;
        string val_5;
        if(genericType != 0)
        {
                if(genericType != 2)
        {
                if(genericType != 1)
        {
                return;
        }
        
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_3 = 1152921504619999232;
            val_1.Add(key:  "credits", value:  120);
            string val_2 = System.String.Format(format:  "You’ve been gifted {0} Coins! Come back and PLAY!", arg0:  120);
            val_2.SendNotification(when:  new System.DateTime() {dateData = when.dateData}, message:  val_2, ampTag:  "coins_sml_pnl", extraData:  val_1, ntype:  23);
            return;
        }
        
            val_4 = "Which one of your friends is playing? Join a Club to find out!";
            val_5 = "soc_pnl";
        }
        else
        {
                val_4 = "Looking for a bigger challenge? Take on the Daily Challenge twice a day to earn EXCLUSIVE PRIZES!";
            val_5 = "daily_ch_pnl";
        }
        
        this.SendNotification(when:  new System.DateTime() {dateData = when.dateData}, message:  val_4, ampTag:  val_5, extraData:  0, ntype:  23);
    }
    private void FeatureNotification(int level, System.DateTime when)
    {
        System.Collections.Generic.List<System.String> val_4;
        var val_5;
        val_4 = level;
        if((this.FeaureLevels.Length << 32) < 1)
        {
            goto label_2;
        }
        
        var val_5 = 0;
        do
        {
            val_5 = val_5 + 1;
        }
        while(val_5 < (long)this.FeaureLevels.Length);
        
        if((((null < val_4) ? (val_5) : 0) & 2147483648) == 0)
        {
            goto label_5;
        }
        
        return;
        label_2:
        val_5 = 0;
        if((val_5 & 2147483648) != 0)
        {
                return;
        }
        
        label_5:
        if(val_5 >= this.FeatureTeaser)
        {
                return;
        }
        
        val_4 = this.FeatureTeaser;
        if("feat_unlk{0}_pnl" <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.SendNotification(when:  new System.DateTime() {dateData = when.dateData}, message:  "feat_unlk{0}_pnl".__il2cppRuntimeField_20, ampTag:  System.String.Format(format:  "feat_unlk{0}_pnl", arg0:  val_5 + 1), extraData:  0, ntype:  23);
    }
    private void EventsNotification(System.DateTime when)
    {
        var val_4;
        var val_5;
        MetaGameBehavior val_12;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_1.<metaGameBehavior>k__BackingField;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_12 & 1) == 0)
        {
                return;
        }
        
        if((MonoSingleton<GameEventsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_2.eventList;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_3 = val_12.GetEnumerator();
        label_23:
        if(val_5.MoveNext() == false)
        {
            goto label_10;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = when.dateData}, t2:  new System.DateTime() {dateData = val_4 + 32})) == true) || ((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = when.dateData}, t2:  new System.DateTime() {dateData = val_4 + 40})) == true))
        {
            goto label_23;
        }
        
        val_12 = this.eventsNotifications;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.ContainsKey(key:  val_4 + 72)) == false)
        {
            goto label_23;
        }
        
        System.String[] val_10 = this.eventsNotifications.Item[val_4 + 72];
        if(val_10 == null)
        {
            goto label_23;
        }
        
        val_10.SendNotification(when:  new System.DateTime() {dateData = when.dateData}, message:  val_10[1], ampTag:  val_10[0], extraData:  0, ntype:  23);
        goto label_23;
        label_10:
        val_5.Dispose();
    }
    private void SendLevelAnwserNotification(System.DateTime when, string nextWord)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "scene", value:  1);
        GameBehavior val_2 = App.getBehavior;
        string val_4 = System.String.Format(format:  "HERE\'S A HINT Clear level {0}, the answer is {1}!", arg0:  val_2.<metaGameBehavior>k__BackingField.ToString(), arg1:  nextWord);
        val_4.SendNotification(when:  new System.DateTime() {dateData = when.dateData}, message:  val_4, ampTag:  "levelcomplete_answer", extraData:  val_1, ntype:  23);
    }
    private void SendNotification(System.DateTime when, string message, string ampTag, System.Collections.Generic.Dictionary<string, object> extraData, twelvegigs.plugins.NotificationType ntype = 23)
    {
        twelvegigs.plugins.NotificationType val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7;
        object val_8;
        int val_9;
        val_6 = ntype;
        val_7 = extraData;
        val_8 = ampTag;
        if(val_7 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_7 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        val_1.Add(key:  "notification_type", value:  val_8);
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_4 = new object[3];
            val_9 = val_4.Length;
            val_4[0] = ntype.ToString();
            if(message != null)
        {
                val_9 = val_4.Length;
        }
        
            val_4[1] = message;
            val_8 = when;
            val_4[2] = val_8;
            UnityEngine.Debug.LogFormat(format:  "{0}: {1} at {2}", args:  val_4);
            val_6 = ntype;
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  val_6, when:  new System.DateTime() {dateData = when.dateData}, interval:  0, optTitle:  0, optMessage:  message, extraData:  val_1, priority:  1, useTimeModifier:  false);
    }
    public WGNotificationLifecycle()
    {
        int val_13;
        int val_14;
        int val_15;
        int val_16;
        int val_17;
        int val_18;
        int val_19;
        int val_20;
        int val_21;
        var val_22;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "Keep playing! ABC Collections unlock soon!");
        val_1.Add(item:  "Keep playing to unlock special Events and earn BIG PRIZES!");
        val_1.Add(item:  "Goals unlock soon. Keep going!");
        val_1.Add(item:  "Leagues unlock soon! Keep playing to join your friends and complete!");
        val_1.Add(item:  "Categories mode is almost unlocked! Find themed words and earn MORE COINS!");
        this.FeatureTeaser = val_1;
        this.FeaureLevels = new int[6] {6, 12, 25, 50, 100, 150};
        System.Collections.Generic.Dictionary<System.String, System.String[]> val_3 = new System.Collections.Generic.Dictionary<System.String, System.String[]>();
        string[] val_4 = new string[2];
        val_13 = val_4.Length;
        val_4[0] = "wild_wknd_pnl";
        val_13 = val_4.Length;
        val_4[1] = "Wild Word Weekend is available. Beat levels to earn a big prize!";
        val_3.Add(key:  "WildWordWeekend", value:  val_4);
        string[] val_5 = new string[2];
        val_14 = val_5.Length;
        val_5[0] = "level_ch_pnl";
        val_14 = val_5.Length;
        val_5[1] = "A special Level Challenge event is now active!";
        val_3.Add(key:  "LevelChallenge", value:  val_5);
        string[] val_6 = new string[2];
        val_15 = val_6.Length;
        val_6[0] = "word_hnt_pnl";
        val_15 = val_6.Length;
        val_6[1] = "The monthly Word Hunt event is now available! Come play!";
        val_3.Add(key:  "WordHunt", value:  val_6);
        string[] val_7 = new string[2];
        val_16 = val_7.Length;
        val_7[0] = "light_wrd_pnl";
        val_16 = val_7.Length;
        val_7[1] = "The Lightning Words event is now active! Beat the timer to earn prizes!";
        val_3.Add(key:  "LightningWords", value:  val_7);
        string[] val_8 = new string[2];
        val_17 = val_8.Length;
        val_8[0] = "puzzle_cl_pnl";
        val_17 = val_8.Length;
        val_8[1] = "The Puzzle Challenge is live! Find all the pieces to earn a big prize!";
        val_3.Add(key:  "PuzzleCollection", value:  val_8);
        string[] val_9 = new string[2];
        val_18 = val_9.Length;
        val_9[0] = "leadrbrd_pnl";
        val_18 = val_9.Length;
        val_9[1] = "Leaderboards are active! Come compete to earn coins!";
        val_3.Add(key:  "Leaderboard", value:  val_9);
        string[] val_10 = new string[2];
        val_19 = val_10.Length;
        val_10[0] = "sup_stk_pnl";
        val_19 = val_10.Length;
        val_10[1] = "The Super Streak event is now live!";
        val_3.Add(key:  "SuperStreak", value:  val_10);
        string[] val_11 = new string[2];
        val_20 = val_11.Length;
        val_11[0] = "hot_stk_pnl";
        val_20 = val_11.Length;
        val_11[1] = "The Hot Streaks event is now live!";
        val_3.Add(key:  "HotStreak", value:  val_11);
        string[] val_12 = new string[2];
        val_21 = val_12.Length;
        val_12[0] = "extra_chp_pnl";
        val_21 = val_12.Length;
        val_12[1] = "Extra Chapter Rewards are now available! Earn DOUBLE the coins for every Chapter completed!";
        val_3.Add(key:  "ExtraChapterRewards", value:  val_12);
        this.eventsNotifications = val_3;
        val_22 = null;
        val_22 = null;
        this.localInstalledDate = System.DateTime.MinValue;
    }

}
