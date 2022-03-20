using UnityEngine;
public class WGEmailCollectManager : MonoSingleton<WGEmailCollectManager>
{
    // Fields
    private System.DateTime _LastRequestedTime;
    
    // Properties
    private System.DateTime LastRequestedTime { get; set; }
    public static bool IsAvailable { get; }
    
    // Methods
    private System.DateTime get_LastRequestedTime()
    {
        var val_5;
        var val_6;
        val_5 = null;
        val_5 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this._LastRequestedTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return (System.DateTime)this._LastRequestedTime;
        }
        
        val_6 = null;
        val_6 = null;
        System.DateTime val_3 = SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "wg_last_email_request"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        this._LastRequestedTime = val_3;
        CPlayerPrefs.SetString(key:  "wg_last_email_request", val:  this._LastRequestedTime.ToString());
        return (System.DateTime)this._LastRequestedTime;
    }
    private void set_LastRequestedTime(System.DateTime value)
    {
        this._LastRequestedTime = value;
        CPlayerPrefs.SetString(key:  "wg_last_email_request", val:  this._LastRequestedTime.ToString());
    }
    public static bool get_IsAvailable()
    {
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_2 = App.getGameEcon;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  val_2.emailCollectPopupLevel);
    }
    public bool CheckAvailable()
    {
        var val_8;
        var val_9;
        val_8 = this;
        if(WGEmailCollectManager.IsAvailable == false)
        {
                return false;
        }
        
        if(this.CanCollect() == false)
        {
                return false;
        }
        
        val_8 = 1152921504886665216;
        val_9 = null;
        val_9 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
                return false;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_8 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_4D0;
    }
    private bool CanCollect()
    {
        var val_23;
        Player val_1 = App.Player;
        UnityEngine.Debug.Log(message:  "Email Collect: |Has Email:"("Email Collect: |Has Email:") + val_1.email + "|"("|"));
        UnityEngine.Debug.Log(message:  "Email Collect: Fb Logged in:"("Email Collect: Fb Logged in:") + FacebookPlugin.IsLoggedIn.ToString());
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.DateTime val_9 = this.LastRequestedTime;
        GameEcon val_10 = App.getGameEcon;
        System.DateTime val_11 = val_9.dateData.AddDays(value:  (double)val_10.emailCollectTimeoutDays);
        UnityEngine.Debug.Log(message:  "Email Collect: Utc Now: "("Email Collect: Utc Now: ") + val_7.dateData.ToString() + " -- TimeoutEnd: "(" -- TimeoutEnd: ") + val_11.dateData.ToString());
        Player val_14 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_14.email.Trim())) != false)
        {
                System.DateTime val_17 = DateTimeCheat.UtcNow;
            System.DateTime val_18 = this.LastRequestedTime;
            GameEcon val_19 = App.getGameEcon;
            System.DateTime val_20 = val_18.dateData.AddDays(value:  (double)val_19.emailCollectTimeoutDays);
            var val_22 = ((val_17.dateData.CompareTo(value:  new System.DateTime() {dateData = val_20.dateData})) > 0) ? 1 : 0;
            return (bool)val_23;
        }
        
        val_23 = 0;
        return (bool)val_23;
    }
    public void HandleResponded()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        this.LastRequestedTime = new System.DateTime() {dateData = val_1.dateData};
        CPlayerPrefs.Save();
    }
    public WGEmailCollectManager()
    {
        null = null;
        this._LastRequestedTime = System.DateTime.MinValue;
    }

}
