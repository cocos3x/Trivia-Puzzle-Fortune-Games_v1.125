using UnityEngine;
public class SROptions_General : SuperLuckySROptionsParent<SROptions_General>, INotifyPropertyChanged
{
    // Properties
    public bool Tracking { get; set; }
    public bool SlowInternet { get; set; }
    public string SetLevel { get; set; }
    public string SetDeeplink { get; set; }
    
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
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public bool get_Tracking()
    {
        null = null;
        return (bool)CompanyDevices.TrackingAllowed;
    }
    public void set_Tracking(bool value)
    {
        CompanyDevices.SwitchDevice();
        SROptions_General.NotifyPropertyChanged(propertyName:  "Tracking");
    }
    public void CRASH()
    {
        DebugMessageDisplay.DisplayMessage(msgTxt:  "BLOATING...", displayTime:  3f);
        MonoSingleton<SRDebugger_Instantiator>.Instance.StartBloatTheMemory();
    }
    public void SendAllLocalNotifications()
    {
        MonoSingleton<SRDebugger_Instantiator>.Instance.StartSendingAllNofis();
    }
    public void SendRemoteNotification()
    {
        var val_7;
        var val_8;
        val_7 = null;
        val_7 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "valid", value:  "12g");
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        App.networkManager.DoPost(path:  "/api/hacks/remote_notifications", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SROptions_General::handleResponse(string method, System.Collections.Generic.Dictionary<string, object> data)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
        val_8 = null;
        val_8 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "valid", value:  "12g");
        Player val_5 = App.Player;
        val_4.Add(key:  "support", value:  val_5.support);
        App.networkManager.DoPost(path:  "/api/hacks/remote_notifications", postBody:  val_4, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SROptions_General::handleResponse(string method, System.Collections.Generic.Dictionary<string, object> data)), timeout:  20, destroy:  false, immediate:  false, serverType:  1);
    }
    public void LPNsLogHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "LPNs LOG", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetLPNsLog()));
    }
    public bool get_SlowInternet()
    {
        null = null;
        return (bool)NetworkThreadingHandler.HackThrottle;
    }
    public void set_SlowInternet(bool value)
    {
        null = null;
        NetworkThreadingHandler.HackThrottle = value;
    }
    private void handleResponse(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        if((data != null) && ((data.ContainsKey(key:  "success")) != false))
        {
                object val_2 = data.Item["success"];
            if(null != null)
        {
                return;
        }
        
        }
        
        UnityEngine.Debug.LogWarning(message:  "hack for remote notifications failed");
    }
    public void set_SetLevel(string value)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(App.game != 1)
        {
                return;
        }
        
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set level gen to " + value, displayTime:  3f);
        val_3 = null;
        val_3 = null;
        WADataParser.QAhackedWord = value;
    }
    public string get_SetLevel()
    {
        var val_1;
        var val_2;
        var val_3;
        var val_4;
        val_1 = 1152921504884269056;
        val_2 = null;
        val_2 = null;
        if(App.game == 1)
        {
                val_1 = 1152921504985387008;
            val_3 = null;
            val_3 = null;
            val_4 = 1152921504985391168;
            return (string)val_4;
        }
        
        val_4 = "";
        return (string)val_4;
    }
    public void set_SetDeeplink(string value)
    {
        null = null;
        DeeplinkComponent.HACK_actionString = value;
    }
    public string get_SetDeeplink()
    {
        null = null;
        return (string)DeeplinkComponent.HACK_actionString;
    }
    public void HackCreditsAward()
    {
        decimal val_1 = new System.Decimal(value:  200);
        DefaultHandler<ServerHandler>.Instance.HackAGoddamnAward(awerd:  new Award() {id = UnityEngine.Random.value.ToString(), kind = "credits", amount = new System.Decimal() {flags = val_1.flags, lo = val_1.lo}});
    }
    public void HackGemsAward()
    {
        decimal val_1 = new System.Decimal(value:  200);
        DefaultHandler<ServerHandler>.Instance.HackAGoddamnAward(awerd:  new Award() {id = UnityEngine.Random.value.ToString(), kind = "gems", amount = new System.Decimal() {flags = val_1.flags, lo = val_1.lo}});
    }
    public void HackLevelAward()
    {
        decimal val_1 = new System.Decimal(value:  200);
        DefaultHandler<ServerHandler>.Instance.HackAGoddamnAward(awerd:  new Award() {id = UnityEngine.Random.value.ToString(), kind = "level", amount = new System.Decimal() {flags = val_1.flags, lo = val_1.lo}});
    }
    public void HackNoAdsAward()
    {
        decimal val_1 = new System.Decimal(value:  200);
        DefaultHandler<ServerHandler>.Instance.HackAGoddamnAward(awerd:  new Award() {id = UnityEngine.Random.value.ToString(), kind = "no_ads", amount = new System.Decimal() {flags = val_1.flags, lo = val_1.lo}});
    }
    public void HackPetsFoodAward()
    {
        decimal val_1 = new System.Decimal(value:  20);
        DefaultHandler<ServerHandler>.Instance.HackAGoddamnAward(awerd:  new Award() {id = UnityEngine.Random.value.ToString(), kind = "pets_food", amount = new System.Decimal() {flags = val_1.flags, lo = val_1.lo}});
    }
    public void TextureMemoryInfo()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Texture Memory Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetTextureMemoryInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_General()
    {
    
    }

}
