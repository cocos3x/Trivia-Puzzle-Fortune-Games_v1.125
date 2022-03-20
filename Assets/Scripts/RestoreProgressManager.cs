using UnityEngine;
public class RestoreProgressManager : MonoSingleton<RestoreProgressManager>
{
    // Fields
    public const string PREVIOUS_PROGRESSION = "rpm_previous_progression";
    public const string SIGNIN_REMINDER_SHOWN = "rpm_sign_in_reminder_shown";
    private const int REQUEST_TIMEOUT = 20;
    private static System.Action<bool> OnServerError;
    private static System.Action<RestoreProgressManager.ServerResponse> OnImportResponded;
    private RestoreProgressManager.Progression <previousProgression>k__BackingField;
    private RestoreProgressManager.LoginMethod <loginMethod>k__BackingField;
    
    // Properties
    public static bool HasPreviousProgression { get; }
    public RestoreProgressManager.Progression previousProgression { get; set; }
    public RestoreProgressManager.LoginMethod loginMethod { get; set; }
    public bool IsLoggedIn { get; }
    public bool ReminderPopupShown { get; set; }
    
    // Methods
    public static void add_OnServerError(System.Action<bool> value)
    {
        if((System.Delegate.Combine(a:  RestoreProgressManager.OnServerError, b:  value)) == null)
        {
                return;
        }
        
        if(null == null)
        {
                return;
        }
    
    }
    public static void remove_OnServerError(System.Action<bool> value)
    {
        if((System.Delegate.Remove(source:  RestoreProgressManager.OnServerError, value:  value)) == null)
        {
                return;
        }
        
        if(null == null)
        {
                return;
        }
    
    }
    public static void add_OnImportResponded(System.Action<RestoreProgressManager.ServerResponse> value)
    {
        do
        {
            if((System.Delegate.Combine(a:  RestoreProgressManager.OnImportResponded, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(RestoreProgressManager.OnImportResponded != 1152921504978788360);
        
        return;
        label_2:
    }
    public static void remove_OnImportResponded(System.Action<RestoreProgressManager.ServerResponse> value)
    {
        do
        {
            if((System.Delegate.Remove(source:  RestoreProgressManager.OnImportResponded, value:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(RestoreProgressManager.OnImportResponded != 1152921504978788360);
        
        return;
        label_2:
    }
    public static bool get_HasPreviousProgression()
    {
        return UnityEngine.PlayerPrefs.HasKey(key:  "rpm_previous_progression");
    }
    public RestoreProgressManager.Progression get_previousProgression()
    {
        return (Progression)this.<previousProgression>k__BackingField;
    }
    private void set_previousProgression(RestoreProgressManager.Progression value)
    {
        this.<previousProgression>k__BackingField = value;
    }
    public RestoreProgressManager.LoginMethod get_loginMethod()
    {
        return (LoginMethod)this.<loginMethod>k__BackingField;
    }
    private void set_loginMethod(RestoreProgressManager.LoginMethod value)
    {
        this.<loginMethod>k__BackingField = value;
    }
    public bool get_IsLoggedIn()
    {
        return (bool)((this.<loginMethod>k__BackingField) != 0) ? 1 : 0;
    }
    public bool get_ReminderPopupShown()
    {
        var val_4;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "rpm_sign_in_reminder_shown")) != false)
        {
                var val_3 = ((UnityEngine.PlayerPrefs.GetInt(key:  "rpm_sign_in_reminder_shown", defaultValue:  0)) > 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public void set_ReminderPopupShown(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "rpm_sign_in_reminder_shown", value:  value);
    }
    private void Start()
    {
        this.UpdateLoginStatus();
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
        if((UnityEngine.PlayerPrefs.HasKey(key:  "rpm_previous_progression")) == false)
        {
                return;
        }
        
        this.<previousProgression>k__BackingField = JsonSerializable<Progression>.Deserialize(serialized:  UnityEngine.PlayerPrefs.GetString(key:  "rpm_previous_progression", defaultValue:  "{}"));
    }
    public void OnServerResponded()
    {
        this.UpdateLoginStatus();
    }
    public void OnEmailLogin(string email)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "email", value:  email);
        this.LoginRequest(loginData:  val_1);
    }
    public void OnAppleLogin(string appleUserId)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "apple_user_id", value:  appleUserId);
        this.LoginRequest(loginData:  val_1);
    }
    public void ConfirmVerificationCode(string code)
    {
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "code", value:  code);
        Player val_2 = App.Player;
        val_1.Add(key:  "email", value:  val_2.email);
        Player val_3 = App.Player;
        val_6 = null;
        val_6 = null;
        App.networkManager.DoPut(path:  System.String.Format(format:  "/api/imports/{0}/verification", arg0:  val_3.id), postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void RestoreProgressManager::OnServerResponse(string request, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    public void ConfirmImport(bool importProgression)
    {
        var val_6;
        if(importProgression != true)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "rpm_previous_progression");
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "import", value:  importProgression);
        Player val_3 = App.Player;
        val_6 = null;
        val_6 = null;
        App.networkManager.DoPut(path:  System.String.Format(format:  "/api/imports/{0}/login", arg0:  val_3.id), postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void RestoreProgressManager::OnServerResponse(string request, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    public void LogoutRequest()
    {
        var val_8;
        Player val_1 = App.Player;
        val_1.email = System.String.alignConst;
        Player val_2 = App.Player;
        val_2.properties.verifiedEmail = false;
        if((this.<loginMethod>k__BackingField) == 2)
        {
                MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.Logout();
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "rpm_previous_progression");
        App.Player.SaveState();
        Player val_5 = App.Player;
        val_8 = null;
        val_8 = null;
        App.networkManager.DoDelete(path:  System.String.Format(format:  "/api/imports/{0}/login", arg0:  val_5.id), onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void RestoreProgressManager::OnServerResponse(string request, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, deleteParams:  0);
    }
    public bool ShouldShowReminder()
    {
        if((this.<loginMethod>k__BackingField) != 0)
        {
                return false;
        }
        
        Player val_1 = App.Player;
        if(val_1 < 85)
        {
                return false;
        }
        
        bool val_2 = val_1.ReminderPopupShown;
        val_2 = (~val_2) & 1;
        return false;
    }
    public void ShowSignInReminder()
    {
        mem2[0] = 1;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGRestoreProgressionPopup>(showNext:  false).ReminderPopupShown = true;
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void UpdateLoginStatus()
    {
        int val_13;
        int val_14;
        LoginMethod val_15;
        var val_1 = ((this.<loginMethod>k__BackingField) != 0) ? 1 : 0;
        string[] val_2 = new string[6];
        val_2[0] = "verifiedEmail: ";
        Player val_3 = App.Player;
        val_13 = val_2.Length;
        val_2[1] = val_3.properties.verifiedEmail.ToString();
        val_13 = val_2.Length;
        val_2[2] = " Email: ";
        Player val_5 = App.Player;
        val_14 = val_2.Length;
        val_2[3] = val_5.email;
        val_14 = val_2.Length;
        val_2[4] = " wasLoggedIn: ";
        val_2[5] = val_1.ToString();
        UnityEngine.Debug.Log(message:  +val_2);
        this.<loginMethod>k__BackingField = 0;
        Player val_8 = App.Player;
        if(val_8.properties.verifiedEmail == false)
        {
            goto label_29;
        }
        
        Player val_9 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_9.email)) == false)
        {
            goto label_33;
        }
        
        label_29:
        if(SignInWithApplePlugin.IsLoggedIn == false)
        {
            goto label_36;
        }
        
        val_15 = 2;
        goto label_37;
        label_33:
        val_15 = 1;
        label_37:
        this.<loginMethod>k__BackingField = val_15;
        label_36:
        if(val_1 == 0)
        {
                return;
        }
        
        if((this.<loginMethod>k__BackingField) != 0)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  "Sign out from leagues");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerImportResponded", aData:  0);
    }
    private void LoginRequest(System.Collections.Generic.Dictionary<string, object> loginData)
    {
        var val_4;
        Player val_1 = App.Player;
        val_4 = null;
        val_4 = null;
        App.networkManager.DoPost(path:  System.String.Format(format:  "/api/imports/{0}/login", arg0:  val_1.id), postBody:  loginData, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void RestoreProgressManager::OnServerResponse(string request, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void OnServerResponse(string request, System.Collections.Generic.Dictionary<string, object> response)
    {
        string val_17;
        object val_18;
        ServerResponse val_19;
        var val_20;
        val_18 = this;
        if((this.IsRequestFail(response:  response)) != false)
        {
                val_18 = "RestoreProgressManager: Login Error :"("RestoreProgressManager: Login Error :") + MiniJSON.Json.Serialize(obj:  response)(MiniJSON.Json.Serialize(obj:  response));
            UnityEngine.Debug.LogError(message:  val_18);
            string val_17 = "error_status";
            if(RestoreProgressManager.OnServerError == null)
        {
                return;
        }
        
            val_17 = response.ContainsKey(key:  val_17);
            RestoreProgressManager.OnServerError.Invoke(obj:  val_17);
            return;
        }
        
        if((response.ContainsKey(key:  "verified")) != false)
        {
                object val_6 = response.Item["verified"];
            if(null != null)
        {
                Player val_7 = App.Player;
            val_7.properties.verifiedEmail = true;
            Player val_8 = App.Player;
            val_8.properties.Save(writePrefs:  true);
            this.UpdateLoginStatus();
        }
        
        }
        
        object val_9 = response.Item["status"];
        val_17 = val_9;
        if(((System.String.op_Equality(a:  val_9, b:  "imported")) == false) || ((response.ContainsKey(key:  "user")) == false))
        {
            goto label_19;
        }
        
        this.ImportUser(response:  response);
        val_19 = 2;
        goto label_30;
        label_19:
        if((System.String.op_Equality(a:  val_17, b:  "progression")) == false)
        {
            goto label_21;
        }
        
        object val_13 = response.Item["progression"];
        val_20 = 0;
        goto label_24;
        label_21:
        if((System.String.op_Equality(a:  val_17, b:  "email_confirmation")) == false)
        {
            goto label_25;
        }
        
        val_19 = 0;
        goto label_30;
        label_25:
        if((System.String.op_Equality(a:  val_17, b:  "logout")) == false)
        {
            goto label_27;
        }
        
        this.UpdateLoginStatus();
        val_19 = 3;
        goto label_30;
        label_24:
        this.ParseProgression(obj:  null);
        val_19 = 4;
        label_30:
        this.CallbackResponse(response:  val_19);
        return;
        label_27:
        if((System.String.op_Equality(a:  val_17, b:  "new_user")) == false)
        {
                return;
        }
        
        this.UpdateLoginStatus();
        goto label_30;
    }
    private void ImportUser(System.Collections.Generic.Dictionary<string, object> response)
    {
        int val_8;
        UnityEngine.PlayerPrefs.DeleteKey(key:  "rpm_previous_progression");
        Player val_1 = App.Player;
        val_1.properties.imported = true;
        Player val_2 = App.Player;
        if((response.ContainsKey(key:  "old_support_id")) == false)
        {
            goto label_7;
        }
        
        object val_4 = response.Item["old_support_id"];
        if(val_2.properties != null)
        {
            goto label_9;
        }
        
        label_7:
        val_8 = System.String.alignConst;
        label_9:
        val_2.properties.oldSupportId = val_8;
        DefaultHandler<ServerHandler>.Instance.UpdatedFromServer(serverResponse:  response, forceUpdate:  true);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerImportResponded", aData:  new System.Collections.Hashtable());
    }
    private void CallbackResponse(RestoreProgressManager.ServerResponse response)
    {
        if(RestoreProgressManager.OnImportResponded == null)
        {
                return;
        }
        
        RestoreProgressManager.OnImportResponded.Invoke(obj:  response);
    }
    private void ParseProgression(System.Collections.Generic.Dictionary<string, object> obj)
    {
        RestoreProgressManager.Progression val_1 = new RestoreProgressManager.Progression();
        this.<previousProgression>k__BackingField = val_1;
        val_1.ParseDic(obj:  obj);
        UnityEngine.PlayerPrefs.SetString(key:  "rpm_previous_progression", value:  this.<previousProgression>k__BackingField.Serialize(format:  0));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private bool IsRequestFail(System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_4;
        if(response != null)
        {
                if((response.ContainsKey(key:  "success")) != false)
        {
                object val_2 = response.Item["success"];
            var val_3 = (null == 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        }
        
        val_4 = 1;
        return (bool)val_4;
    }
    public RestoreProgressManager()
    {
    
    }

}
