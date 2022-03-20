using UnityEngine;
public class ReturnGameGiftManager : MonoSingleton<ReturnGameGiftManager>
{
    // Fields
    private const string LASTPLAYEDTIMEKEY = "rrv_returngametime";
    private bool hackedNotifications;
    
    // Methods
    public override void InitMonoSingleton()
    {
        this.CheckReturnGameGiftReward();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        pauseStatus = (~pauseStatus) & 1;
        this.OnPauseGame(returnedToGame:  pauseStatus);
    }
    private void OnApplicationQuit()
    {
        this.OnPauseGame(returnedToGame:  false);
    }
    public static void Reset()
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  "ReturnGameGiftTimer");
    }
    private void OnPauseGame(bool returnedToGame)
    {
        if(returnedToGame != false)
        {
                this.CheckReturnGameGiftReward();
            return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        UnityEngine.PlayerPrefs.SetString(key:  "rrv_returngametime", value:  SLCDateTime.SerializeInvariant(dateTime:  new System.DateTime() {dateData = val_1.dateData}));
        this.ScheduleNotifications();
    }
    private void CheckReturnGameGiftReward()
    {
        this.KillNotifications();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CheckReturnGameGiftAvailable());
    }
    private System.Collections.IEnumerator CheckReturnGameGiftAvailable()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new ReturnGameGiftManager.<CheckReturnGameGiftAvailable>d__8();
    }
    private void KillNotifications()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  32);
    }
    private void ScheduleNotifications()
    {
        if(this.hackedNotifications == true)
        {
                return;
        }
        
        this.KillNotifications();
        System.Collections.Generic.List<System.Int32> val_1 = null;
        this = val_1;
        val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  16);
        val_1.Add(item:  24);
        val_1.Add(item:  48);
        val_1.Add(item:  168);
        if(1152921510062986752 < 1)
        {
                return;
        }
        
        var val_11 = 8;
        do
        {
            Player val_3 = App.Player;
            var val_4 = val_11 - 8;
            if(val_4 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_5 = System.DateTime.UtcNow;
            if(val_4 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_6 = val_5.dateData.AddHours(value:  (double)System.DateTime.__il2cppRuntimeField_byval_arg);
            string val_7 = this.GetNotificationMessage(reward:  App.getGameEcon);
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  32, when:  new System.DateTime() {dateData = val_6.dateData}, interval:  0, optTitle:  "Restaurant Rivals", optMessage:  val_7, extraData:  val_7.GetExtraData(tier:  val_11 - 7), priority:  0, useTimeModifier:  true);
            val_11 = val_11 + 1;
        }
        while((val_11 - 7) < null);
    
    }
    private string GetNotificationTitle()
    {
        return "Restaurant Rivals";
    }
    private string GetNotificationMessage(ReturnGameGiftReward reward)
    {
        object val_4;
        var val_8;
        int val_4 = reward.<tier>k__BackingField;
        val_4 = val_4 - 1;
        if(val_4 <= 3)
        {
                var val_5 = 32562356 + ((reward.<tier>k__BackingField - 1)) << 2;
            val_4 = reward.<coins>k__BackingField.ToString();
            val_5 = val_5 + 32562356;
        }
        else
        {
                val_8 = "";
            return (string)val_8;
        }
    
    }
    private System.Collections.Generic.Dictionary<string, object> GetExtraData(int tier)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "notification_type", value:  System.String.Format(format:  "return_gift_{0}", arg0:  tier));
        return val_1;
    }
    public void TestReturnGameGiftNotifications()
    {
        var val_9;
        this.hackedNotifications = true;
        this.KillNotifications();
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_9 = 1152921510479955696;
        val_1.Add(item:  16);
        val_1.Add(item:  24);
        val_1.Add(item:  48);
        val_1.Add(item:  168);
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        val_2.Add(item:  15);
        val_2.Add(item:  30);
        val_2.Add(item:  45);
        val_2.Add(item:  60);
        if(true < 1)
        {
                return;
        }
        
        var val_12 = 8;
        val_9 = 23465;
        do
        {
            Player val_4 = App.Player;
            var val_5 = val_12 - 8;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_6 = System.DateTime.UtcNow;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_7 = val_6.dateData.AddSeconds(value:  (double)System.DateTime.__il2cppRuntimeField_byval_arg);
            string val_8 = this.GetNotificationMessage(reward:  App.getGameEcon);
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  32, when:  new System.DateTime() {dateData = val_7.dateData}, interval:  0, optTitle:  "Restaurant Rivals", optMessage:  val_8, extraData:  val_8.GetExtraData(tier:  val_12 - 7), priority:  0, useTimeModifier:  true);
            val_12 = val_12 + 1;
        }
        while((val_12 - 7) < null);
    
    }
    public void TestReturnGameGiftNotifications2()
    {
        var val_9;
        this.hackedNotifications = true;
        this.KillNotifications();
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_9 = 1152921510479955696;
        val_1.Add(item:  16);
        val_1.Add(item:  24);
        val_1.Add(item:  48);
        val_1.Add(item:  168);
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        val_2.Add(item:  1);
        val_2.Add(item:  2);
        val_2.Add(item:  3);
        val_2.Add(item:  4);
        if(true < 1)
        {
                return;
        }
        
        var val_12 = 8;
        val_9 = 23465;
        do
        {
            Player val_4 = App.Player;
            var val_5 = val_12 - 8;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_6 = System.DateTime.UtcNow;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_7 = val_6.dateData.AddMinutes(value:  (double)System.DateTime.__il2cppRuntimeField_byval_arg);
            string val_8 = this.GetNotificationMessage(reward:  App.getGameEcon);
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  32, when:  new System.DateTime() {dateData = val_7.dateData}, interval:  0, optTitle:  "Restaurant Rivals", optMessage:  val_8, extraData:  val_8.GetExtraData(tier:  val_12 - 7), priority:  0, useTimeModifier:  true);
            val_12 = val_12 + 1;
        }
        while((val_12 - 7) < null);
    
    }
    public void TestReturnGameGiftNotifications3()
    {
        var val_9;
        this.hackedNotifications = true;
        this.KillNotifications();
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_9 = 1152921510479955696;
        val_1.Add(item:  16);
        val_1.Add(item:  24);
        val_1.Add(item:  48);
        val_1.Add(item:  168);
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        val_2.Add(item:  5);
        val_2.Add(item:  10);
        val_2.Add(item:  15);
        val_2.Add(item:  20);
        if(true < 1)
        {
                return;
        }
        
        var val_12 = 8;
        val_9 = 23465;
        do
        {
            Player val_4 = App.Player;
            var val_5 = val_12 - 8;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_6 = System.DateTime.UtcNow;
            if(val_5 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.DateTime val_7 = val_6.dateData.AddMinutes(value:  (double)System.DateTime.__il2cppRuntimeField_byval_arg);
            string val_8 = this.GetNotificationMessage(reward:  App.getGameEcon);
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  32, when:  new System.DateTime() {dateData = val_7.dateData}, interval:  0, optTitle:  "Restaurant Rivals", optMessage:  val_8, extraData:  val_8.GetExtraData(tier:  val_12 - 7), priority:  0, useTimeModifier:  true);
            val_12 = val_12 + 1;
        }
        while((val_12 - 7) < null);
    
    }
    public void ClearHacks()
    {
        this.KillNotifications();
        this.hackedNotifications = false;
    }
    public ReturnGameGiftManager()
    {
    
    }

}
