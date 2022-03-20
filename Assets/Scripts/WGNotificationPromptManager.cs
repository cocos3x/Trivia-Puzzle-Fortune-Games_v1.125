using UnityEngine;
public class WGNotificationPromptManager : MonoSingleton<WGNotificationPromptManager>
{
    // Fields
    private const string timesPrompted = "notifPromptAppearances";
    private const string notifPromptTracking = "nextNotifAtDate";
    
    // Properties
    private System.DateTime notifyAtDate { get; set; }
    private int numTimesSeen { get; set; }
    private bool promptEnabled { get; }
    
    // Methods
    private System.DateTime get_notifyAtDate()
    {
        var val_3;
        var val_4;
        if((CPlayerPrefs.HasKey(key:  "nextNotifAtDate")) != false)
        {
                val_3 = null;
            val_3 = null;
            return SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "nextNotifAtDate"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        }
        
        val_4 = null;
        val_4 = null;
        return (System.DateTime)System.DateTime.MinValue;
    }
    private void set_notifyAtDate(System.DateTime value)
    {
        CPlayerPrefs.SetString(key:  "nextNotifAtDate", val:  value.dateData.ToString());
    }
    private int get_numTimesSeen()
    {
        return CPlayerPrefs.GetInt(key:  "notifPromptAppearances", defaultValue:  0);
    }
    private void set_numTimesSeen(int value)
    {
        CPlayerPrefs.SetInt(key:  "notifPromptAppearances", val:  value);
    }
    private bool get_promptEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)(val_1.notificationPromptUnlockLevel > 0) ? 1 : 0;
    }
    public bool ShouldShowNotif()
    {
        return false;
    }
    public void SetPromptSeen()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        GameEcon val_2 = App.getGameEcon;
        System.DateTime val_3 = val_1.dateData.AddDays(value:  (double)val_2.notificationUnlockInterval);
        val_3.dateData.notifyAtDate = new System.DateTime() {dateData = val_3.dateData};
        int val_4 = val_3.dateData.numTimesSeen;
        val_4.numTimesSeen = val_4 + 1;
        CPlayerPrefs.Save();
    }
    public void SetNotifVisibility(bool enabled)
    {
        if(enabled == false)
        {
                return;
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.RequestNotificationAccess();
    }
    public WGNotificationPromptManager()
    {
    
    }

}
