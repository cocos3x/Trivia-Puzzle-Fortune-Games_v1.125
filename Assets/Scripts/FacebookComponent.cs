using UnityEngine;
public class FacebookComponent : AppComponent
{
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public FacebookComponent(string gameName, string gameObjectName)
    {
        mem[1152921515588153376] = "FacebookComponent";
    }
    public override void initializeOnMainThread()
    {
        ulong val_9;
        System.DateTime val_1 = System.DateTime.UtcNow;
        val_9 = val_1.dateData;
        this.Log(message:  "InitFacebookComponent!");
        this.ConfigureAudienceNetwork();
        FacebookPlugin.init(gameObjectName:  X21, gameName:  this);
        string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "facebook_app_user_id", defaultValue:  "default");
        if((System.String.op_Inequality(a:  val_2, b:  "default")) != false)
        {
                if((System.String.op_Inequality(a:  val_2, b:  "sent")) == true)
        {
                return;
        }
        
        }
        
        FacebookPlugin.requestAppUserId();
        System.DateTime val_5 = System.DateTime.UtcNow;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime() {dateData = val_9});
        val_9 = "PROFILING, Facebook ends in " + val_6._ticks.TotalMilliseconds;
        UnityEngine.Debug.Log(message:  val_9);
    }
    public void ConfigureAudienceNetwork()
    {
        AudienceNetwork.AdSettings.SetDataProcessingOptions(dataProcessingOptions:  new string[0]);
    }
    public override void onApplicationPause(bool pauseStatus)
    {
        this.onApplicationPause(pauseStatus:  pauseStatus);
    }

}
