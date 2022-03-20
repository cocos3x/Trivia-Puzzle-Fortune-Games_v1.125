using UnityEngine;
public class WGInviteManager : MonoSingleton<WGInviteManager>
{
    // Fields
    private const string rf_invite_sent = "friend_invite_sent";
    private const string pp_checked_install = "wfi_checkedInstall";
    private const string InstallCodeKey = "wfi_amb_code";
    private const string IsInvitedKey = "wfi_is_invited";
    private const string InvitesSendKey = "wfi_invites_send";
    private const string CodeManuallyEnteredKey = "wfi_code_manually_entered";
    private const string pp_friendinvite_ftux = "wfi_ftux";
    private const string pp_reward_progression = "wfi_reward_progression";
    public const string ON_INVITES_READY = "OnInvitesReady";
    private int <MemberId>k__BackingField;
    private string <InstallCode>k__BackingField;
    private string <InviteCode>k__BackingField;
    private int <LastInviteTierCollected>k__BackingField;
    private int <LastIndexTierRewardCollected>k__BackingField;
    private System.Collections.Generic.List<int> coinedFriendIDs;
    private System.Collections.Generic.List<int> needCoinedFriendIDs;
    private System.DateTime lastProfileSync;
    public static System.Action onInviteSent;
    private static string <LastResponse>k__BackingField;
    private static bool <IsWhatsAppInstalled>k__BackingField;
    private System.Action<string> codeResponse;
    private bool HACKFakeInvitedAdded;
    
    // Properties
    public int MemberId { get; set; }
    public string InstallCode { get; set; }
    public string InviteCode { get; set; }
    public int LastInviteTierCollected { get; set; }
    public int LastIndexTierRewardCollected { get; set; }
    public int InvitesCollected { get; }
    public int RewardCoinsCount { get; }
    public int PendingInvites { get; }
    public static bool RewardAvailable { get; }
    public static bool isInvited { get; }
    public static int invitesSend { get; }
    public static bool CodeManuallyEntered { get; }
    public static bool IsEnabled { get; }
    public static int ProfileSyncSec { get; }
    public static int TotalValidInvites { get; }
    public static string LastResponse { get; set; }
    public static bool InviteSent { get; set; }
    public static bool IsWhatsAppInstalled { get; set; }
    public static bool isV2 { get; }
    
    // Methods
    public int get_MemberId()
    {
        return (int)this.<MemberId>k__BackingField;
    }
    private void set_MemberId(int value)
    {
        this.<MemberId>k__BackingField = value;
    }
    public string get_InstallCode()
    {
        return (string)this.<InstallCode>k__BackingField;
    }
    private void set_InstallCode(string value)
    {
        this.<InstallCode>k__BackingField = value;
    }
    public string get_InviteCode()
    {
        return (string)this.<InviteCode>k__BackingField;
    }
    private void set_InviteCode(string value)
    {
        this.<InviteCode>k__BackingField = value;
    }
    public int get_LastInviteTierCollected()
    {
        return (int)this.<LastInviteTierCollected>k__BackingField;
    }
    private void set_LastInviteTierCollected(int value)
    {
        this.<LastInviteTierCollected>k__BackingField = value;
    }
    public int get_LastIndexTierRewardCollected()
    {
        return (int)this.<LastIndexTierRewardCollected>k__BackingField;
    }
    private void set_LastIndexTierRewardCollected(int value)
    {
        this.<LastIndexTierRewardCollected>k__BackingField = value;
    }
    public int get_InvitesCollected()
    {
        return (int)this.coinedFriendIDs - (this.<LastIndexTierRewardCollected>k__BackingField);
    }
    public int get_RewardCoinsCount()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.FInviterCoinsReward * this;
    }
    public int get_PendingInvites()
    {
        return 36023;
    }
    public static bool get_RewardAvailable()
    {
        var val_6;
        if((MonoSingleton<WGInviteManager>.Instance) != 0)
        {
                var val_5 = ((MonoSingleton<WGInviteManager>.Instance.RewardCoinsCount) > 0) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public static bool get_isInvited()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "wfi_is_invited", defaultValue:  0)) > 0) ? 1 : 0;
    }
    public static int get_invitesSend()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "wfi_invites_send", defaultValue:  0);
    }
    public static bool get_CodeManuallyEntered()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "wfi_code_manually_entered", defaultValue:  0)) > 0) ? 1 : 0;
    }
    public static bool get_IsEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)val_1.FInviterEnabled;
    }
    public static int get_ProfileSyncSec()
    {
        var val_6;
        AppConfigs val_1 = App.Configuration;
        if(val_1.appConfig.IsProduction() != false)
        {
                var val_5 = (CompanyDevices.Instance.CompanyDevice() != true) ? 20 : 600;
            return (int)val_6;
        }
        
        val_6 = 15;
        return (int)val_6;
    }
    public static int get_TotalValidInvites()
    {
        var val_5;
        if((MonoSingleton<WGInviteManager>.Instance) != 0)
        {
                WGInviteManager val_3 = MonoSingleton<WGInviteManager>.Instance;
            if(val_3.coinedFriendIDs != null)
        {
                WGInviteManager val_4 = MonoSingleton<WGInviteManager>.Instance;
            return (int)val_5;
        }
        
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public static string get_LastResponse()
    {
        return (string)WGInviteManager.<LastResponse>k__BackingField;
    }
    private static void set_LastResponse(string value)
    {
        WGInviteManager.<LastResponse>k__BackingField = value;
    }
    public static bool get_InviteSent()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "friend_invite_sent", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public static void set_InviteSent(bool value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "friend_invite_sent", value:  value);
    }
    public static bool get_IsWhatsAppInstalled()
    {
        return (bool)WGInviteManager.<IsWhatsAppInstalled>k__BackingField;
    }
    private static void set_IsWhatsAppInstalled(bool value)
    {
        WGInviteManager.<IsWhatsAppInstalled>k__BackingField = value;
    }
    public static bool get_isV2()
    {
        return (bool)((WordGames.currentGame == 4) ? 1 : 0) | ((WordGames.currentGame == 1) ? 1 : 0);
    }
    public static bool CanShowFTUX()
    {
        if(WGInviteManager.IsEnabled == false)
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        GameEcon val_4 = App.getGameEcon;
        if(App.Player >= val_4.FInviterFTUX)
        {
                if((UnityEngine.PlayerPrefs.GetInt(key:  "wfi_ftux", defaultValue:  0)) == 0)
        {
                return false;
        }
        
        }
        
        return false;
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        WGInviteManager.<LastResponse>k__BackingField = System.String.alignConst;
        this.LoadProgression();
    }
    public bool ShouldSyncWServer()
    {
        var val_8;
        if(WGInviteManager.IsEnabled != false)
        {
                System.DateTime val_2 = System.DateTime.UtcNow;
            System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = this.lastProfileSync});
            int val_5 = WGInviteManager.ProfileSyncSec;
            if(val_3._ticks.TotalSeconds >= 0)
        {
                if((this.<MemberId>k__BackingField) != 0)
        {
                if(WGInviteManager.isV2 != false)
        {
                bool val_7 = System.String.IsNullOrEmpty(value:  this.<InviteCode>k__BackingField);
        }
        
        }
        
            val_8 = 1;
            return (bool)val_8;
        }
        
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    public void OnServerSync()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnServerSync");
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  public System.Void WGInviteManager::OnSceneLoaded(SceneType obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        WGInviteManager.<IsWhatsAppInstalled>k__BackingField = twelvegigs.plugins.InstalledAppsPlugin.IsInstalled(packageToCheck:  "com.whatsapp");
        if(this.ShouldSyncWServer() != false)
        {
                this.Invoke(methodName:  "GetPlayerProfile", time:  2.5f);
        }
        
        this.ParseInstallCode();
        return;
        label_8:
    }
    public void OnSceneLoaded(SceneType obj)
    {
        if(this.ShouldSyncWServer() == false)
        {
                return;
        }
        
        this.Invoke(methodName:  "GetPlayerProfile", time:  1f);
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
                return;
        }
        
        this.ParseInstallCode();
        if(this.ValidIntentPause() == false)
        {
                return;
        }
        
        if(this.ShouldSyncWServer() == false)
        {
                return;
        }
        
        this.Invoke(methodName:  "GetPlayerProfile", time:  1f);
    }
    private void ParseInstallCode()
    {
        var val_9;
        var val_10;
        this.<InstallCode>k__BackingField = 0;
        val_9 = null;
        val_9 = null;
        if((System.String.IsNullOrEmpty(value:  AdjustPlugin.<clickLabelInstall>k__BackingField)) != true)
        {
                val_10 = null;
            val_10 = null;
            this.<InstallCode>k__BackingField = AdjustPlugin.<clickLabelInstall>k__BackingField;
            UnityEngine.Debug.Log(message:  "WGInviteManager:: trying from Adjust "("WGInviteManager:: trying from Adjust ") + AdjustPlugin.<clickLabelInstall>k__BackingField(AdjustPlugin.<clickLabelInstall>k__BackingField));
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wfi_amb_code")) != false)
        {
                string val_4 = UnityEngine.PlayerPrefs.GetString(key:  "wfi_amb_code");
            this.<InstallCode>k__BackingField = val_4;
            UnityEngine.Debug.Log(message:  "WGInviteManager:: trying from PlayerPrefs "("WGInviteManager:: trying from PlayerPrefs ") + val_4);
        }
        
        if((System.String.IsNullOrEmpty(value:  this.<InstallCode>k__BackingField)) != false)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "wfi_checkedInstall")) == false)
        {
            goto label_18;
        }
        
        }
        
        WGInviteManager.SaveInstallCode(installCodeParam:  this.<InstallCode>k__BackingField);
        if((System.String.IsNullOrEmpty(value:  this.<InstallCode>k__BackingField)) != false)
        {
                return;
        }
        
        this.SendRecruitRequest();
        return;
        label_18:
        UnityEngine.Debug.Log(message:  "WGInviteManager:: Trying to Ping for Ambassador Id!");
        this.PingForInviteID();
    }
    private void PingForInviteID()
    {
        var val_8;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "platform", value:  DeviceProperties.Platform);
        val_1.Add(key:  "os", value:  DeviceProperties.SimpleOSVersion);
        val_1.Add(key:  "device_model", value:  DeviceProperties.SimpleDeviceModel);
        UnityEngine.Debug.Log(message:  "WGInviteManager:: Pinging for AMB Deferred Deeplink: "("WGInviteManager:: Pinging for AMB Deferred Deeplink: ") + MiniJSON.Json.Serialize(obj:  val_1)(MiniJSON.Json.Serialize(obj:  val_1)));
        val_8 = null;
        val_8 = null;
        App.networkManager.DoGet(path:  "/api/ambassador_queues", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGInviteManager::OnCompletePingIntiver(string action, System.Collections.Generic.Dictionary<string, object> responseData)), destroy:  false, immediate:  false, getParams:  val_1, timeout:  20);
    }
    private void OnCompletePingIntiver(string action, System.Collections.Generic.Dictionary<string, object> responseData)
    {
        if((responseData == null) || ((responseData.ContainsKey(key:  "success")) == false))
        {
            goto label_5;
        }
        
        object val_2 = responseData.Item["success"];
        if(null == null)
        {
            goto label_5;
        }
        
        object val_3 = responseData.Item["amb_code"];
        this.<InstallCode>k__BackingField = val_3;
        WGInviteManager.SaveInstallCode(installCodeParam:  val_3);
        if((System.String.IsNullOrEmpty(value:  this.<InstallCode>k__BackingField)) == false)
        {
            goto label_7;
        }
        
        return;
        label_5:
        UnityEngine.Debug.Log(message:  "WGInviteManager:: Not trying to become a recruit, as the server returned false.");
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_checkedInstall", value:  1);
        bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
        return;
        label_7:
        this.SendRecruitRequest();
    }
    private static void SaveInstallCode(string installCodeParam)
    {
        UnityEngine.Debug.Log(message:  "SaveAndSend installCode. ASKING FOR RECRUITS! using "("SaveAndSend installCode. ASKING FOR RECRUITS! using ") + installCodeParam);
        UnityEngine.PlayerPrefs.SetString(key:  "wfi_amb_code", value:  installCodeParam);
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_checkedInstall", value:  1);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void SafeSaveAndSend(string installCodeParam)
    {
        if((System.String.IsNullOrEmpty(value:  installCodeParam)) == true)
        {
                return;
        }
        
        WGInviteManager.SaveInstallCode(installCodeParam:  installCodeParam);
        if((MonoSingleton<WGInviteManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGInviteManager>.Instance.SendRecruitRequest();
    }
    public static WGInvite ShowInvitePopup(WGInvite.WGInviteStatus status = 0)
    {
        var val_7;
        var val_8;
        val_7 = 0;
        if((MonoSingleton<WGInviteManager>.Instance) == 0)
        {
                return (WGInvite)val_7;
        }
        
        if(WGInviteManager.isV2 != false)
        {
                WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance;
            val_8 = 1152921517877921808;
        }
        else
        {
                val_8 = 1152921517877926928;
        }
        
        val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGInvite>(showNext:  false);
        return (WGInvite)val_7;
    }
    private void SendRecruitRequest()
    {
        twelvegigs.net.JsonApiRequester val_10;
        var val_11;
        if((System.String.IsNullOrEmpty(value:  this.<InstallCode>k__BackingField)) == true)
        {
                return;
        }
        
        if((this.<MemberId>k__BackingField) == 0)
        {
                return;
        }
        
        val_10 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_2.id.Trim())) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "id", value:  val_2.id);
        val_5.Add(key:  "amb_code", value:  this.<InstallCode>k__BackingField);
        val_5.Add(key:  "platform", value:  DeviceProperties.Platform);
        val_5.Add(key:  "os", value:  DeviceProperties.SimpleOSVersion);
        val_5.Add(key:  "device_model", value:  DeviceProperties.SimpleDeviceModel);
        val_11 = null;
        val_11 = null;
        val_10 = App.networkManager;
        val_10.DoPost(path:  "/api/recruits", postBody:  val_5, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGInviteManager::OnSendRecruitCompleted(string method, System.Collections.Generic.Dictionary<string, object> responseData)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void OnSendRecruitCompleted(string method, System.Collections.Generic.Dictionary<string, object> responseData)
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  "OnSendRecruitCompleted\n" + PrettyPrint.printJSON(obj:  responseData, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  responseData, types:  false, singleLineOutput:  false)));
        }
        
        if((responseData != null) && ((responseData.ContainsKey(key:  "success")) != false))
        {
                object val_6 = responseData.Item["success"];
            if(null != null)
        {
                UnityEngine.Debug.Log(message:  "AmbMgr: Successfully sent as recruit!!!!! Now check the Ambassador!!");
            UnityEngine.PlayerPrefs.DeleteKey(key:  "wfi_amb_code");
            UnityEngine.PlayerPrefs.SetInt(key:  "wfi_is_invited", value:  1);
            bool val_7 = PrefsSerializationManager.SavePlayerPrefs();
            return;
        }
        
        }
        
        object[] val_8 = new object[1];
        val_8[0] = this.<InstallCode>k__BackingField;
        UnityEngine.Debug.LogErrorFormat(format:  "AmbMgr:  - The amb_code wasn\'t send to the server {0}", args:  val_8);
    }
    private string DeviceModel()
    {
        return DeviceProperties.SimpleDeviceModel;
    }
    private void GetPlayerProfile()
    {
        var val_5;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "id", value:  val_2.id);
        val_5 = null;
        val_5 = null;
        App.networkManager.DoPost(path:  "/api/word/profiles", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGInviteManager::OnPlayerProfileResponse(string path, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
        System.DateTime val_4 = System.DateTime.UtcNow;
        this.lastProfileSync = val_4;
    }
    private void OnPlayerProfileResponse(string path, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_20;
        object val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_20 = null;
            WGInviteManager.<LastResponse>k__BackingField = PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false);
            val_20 = 1152921504991137976;
            val_21 = "OnPlayerProfileResponse\n" + WGInviteManager.<LastResponse>k__BackingField(WGInviteManager.<LastResponse>k__BackingField);
            UnityEngine.Debug.Log(message:  val_21);
        }
        
        if(response == null)
        {
            goto label_11;
        }
        
        val_21 = "profile";
        val_22 = 1152921510222861648;
        if((response.ContainsKey(key:  "profile")) == false)
        {
                return;
        }
        
        if(response.Item["profile"] == null)
        {
                return;
        }
        
        object val_7 = response.Item["profile"];
        if((val_7.ContainsKey(key:  "m_id")) != false)
        {
                if(val_7.Item["m_id"] != null)
        {
                object val_10 = val_7.Item["m_id"];
            this.<MemberId>k__BackingField = null;
        }
        
        }
        
        string val_11 = Base36Library.Base36.Encode(value:  this.<MemberId>k__BackingField);
        this.<InviteCode>k__BackingField = val_11;
        if(val_11.m_stringLength <= 4)
        {
                this.<InviteCode>k__BackingField = System.String.Format(format:  "{0,5}", arg0:  val_11).Replace(oldChar:  ' ', newChar:  '0');
        }
        
        val_23 = response;
        if(((val_23.ContainsKey(key:  "invites")) == false) || (response.Item["invites"] == null))
        {
            goto label_27;
        }
        
        val_22 = 1152921504687730688;
        object val_16 = response.Item["invites"];
        val_24 = 0;
        goto label_30;
        label_11:
        val_25 = null;
        val_25 = null;
        this.lastProfileSync = System.DateTime.MinValue;
        return;
        label_30:
        val_23 = this;
        this.ParseInvitedFrindData(friendsData:  null);
        label_27:
        if(WGInviteManager.RewardAvailable != false)
        {
                WGInvite val_18 = WGInviteManager.ShowInvitePopup(status:  2);
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnInvitesReady");
    }
    private void ParseInvitedFrindData(System.Collections.Generic.List<object> friendsData)
    {
        var val_14;
        var val_15;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                if(this.HACKFakeInvitedAdded == true)
        {
                return;
        }
        
        }
        
        if(this.HACKFakeInvitedAdded >= true)
        {
                this.needCoinedFriendIDs.Clear();
        }
        
        if(1152921515441984688 >= 1)
        {
                var val_14 = 0;
            do
        {
            if(val_14 >= 1152921515441984688)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((ContainsKey(key:  "m_id")) != false)
        {
                val_14 = System.Int32.Parse(s:  Item["m_id"]);
        }
        else
        {
                val_14 = -2147483648;
        }
        
            if((ContainsKey(key:  "level")) != false)
        {
                val_15 = System.Int32.Parse(s:  Item["level"]);
        }
        else
        {
                val_15 = -2147483648;
        }
        
            if((this.coinedFriendIDs.Contains(item:  -2147483648)) != true)
        {
                GameEcon val_10 = App.getGameEcon;
            if(val_15 > val_10.FInviterLevelComplete)
        {
                this.needCoinedFriendIDs.Add(item:  -2147483648);
        }
        
        }
        
            val_14 = val_14 + 1;
        }
        while(val_14 < 1152921510479955696);
        
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wfi_reward_progression")) != false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  "WGInviteManager: Ignore invites: "("WGInviteManager: Ignore invites: ") + PrettyPrint.printJSON(obj:  this.needCoinedFriendIDs, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  this.needCoinedFriendIDs, types:  false, singleLineOutput:  false)));
        this.coinedFriendIDs.AddRange(collection:  this.needCoinedFriendIDs);
        this.<LastIndexTierRewardCollected>k__BackingField = this.coinedFriendIDs;
        this.needCoinedFriendIDs.Clear();
        this.SaveProgression();
    }
    private void LoadProgression()
    {
        string val_13;
        var val_14;
        int val_18;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wfi_reward_progression")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "wfi_reward_progression", defaultValue:  "{}"));
        this.<InviteCode>k__BackingField = val_3.Item["invite_code"];
        this.<MemberId>k__BackingField = System.Int32.Parse(s:  val_3.Item["member_id"]);
        this.<LastInviteTierCollected>k__BackingField = System.Int32.Parse(s:  val_3.Item["last_invites_rwd"]);
        this.<LastIndexTierRewardCollected>k__BackingField = System.Int32.Parse(s:  val_3.Item["index_invites_rwd"]);
        this.coinedFriendIDs.Clear();
        List.Enumerator<T> val_12 = val_3.Item["coined_friend"].GetEnumerator();
        label_16:
        val_18 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_14.MoveNext() == false)
        {
            goto label_13;
        }
        
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_18 = System.Int32.Parse(s:  val_13);
        if(this.coinedFriendIDs == null)
        {
                throw new NullReferenceException();
        }
        
        this.coinedFriendIDs.Add(item:  val_18);
        goto label_16;
        label_13:
        val_14.Dispose();
    }
    private void SaveProgression()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "invite_code", value:  this.<InviteCode>k__BackingField);
        val_1.Add(key:  "member_id", value:  this.<MemberId>k__BackingField);
        val_1.Add(key:  "last_invites_rwd", value:  this.<LastInviteTierCollected>k__BackingField);
        val_1.Add(key:  "index_invites_rwd", value:  this.<LastIndexTierRewardCollected>k__BackingField);
        val_1.Add(key:  "coined_friend", value:  this.coinedFriendIDs);
        UnityEngine.PlayerPrefs.SetString(key:  "wfi_reward_progression", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private bool ValidIntentPause()
    {
        var val_2;
        var val_3;
        var val_4;
        val_2 = 1152921504885227520;
        val_3 = null;
        val_3 = null;
        if(TrackingComponent.lastIntent == 0)
        {
                return (bool)((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == false) ? 1 : 0;
        }
        
        val_4 = 0;
        return (bool)((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == false) ? 1 : 0;
    }
    public void SendWhatsApp()
    {
        this.IncreaseInvitesSend();
        TrackingComponent.CurrentIntent = 8;
        twelvegigs.plugins.SharePlugin.SendWhatsApp(text:  this.GetShareText(useNewLine:  true));
    }
    public void SendEmail()
    {
        this.IncreaseInvitesSend();
        TrackingComponent.CurrentIntent = 8;
        AppConfigs val_1 = App.Configuration;
        twelvegigs.plugins.SharePlugin.SendEmail(subject:  "Come play " + val_1.appConfig.gameName, emailBody:  this.GetShareText(useNewLine:  true), url:  System.String.alignConst, imgPath:  0);
    }
    public void SendText()
    {
        this.IncreaseInvitesSend();
        TrackingComponent.CurrentIntent = 5;
        twelvegigs.plugins.SharePlugin.SendSMS(text:  this.GetShareText(useNewLine:  false), url:  System.String.alignConst);
    }
    public void ShareMore()
    {
        this.IncreaseInvitesSend();
        AppConfigs val_1 = App.Configuration;
        string val_4 = System.String.Format(format:  "I found a new word game! {0}", arg0:  System.String.Format(format:  "#{0}", arg0:  val_1.appConfig.gameName.Replace(oldValue:  " ", newValue:  System.String.alignConst)));
        TrackingComponent.CurrentIntent = 7;
        AppConfigs val_6 = App.Configuration;
        AppConfigs val_9 = App.Configuration;
        string val_10 = System.String.Format(format:  Localization.Localize(key:  "invite_friend_msg", defaultValue:  "Come play {0}! It\'s a fun word game that helps me relax!", useSingularKey:  false), arg0:  val_9.appConfig.gameName);
        twelvegigs.plugins.SharePlugin.Share(text:  val_10, url:  this.GetInviteFriendURL(), subject:  System.String.Format(format:  Localization.Localize(key:  "invite_friend_share_title", defaultValue:  "Play {0}", useSingularKey:  false), arg0:  val_6.appConfig.gameName), emailBody:  val_10, imgPath:  0);
    }
    public void CopyToClipboard()
    {
        twelvegigs.plugins.SharePlugin.CopyToClipBoard(text:  this.GetInviteFriendURL(), label:  "");
    }
    public void RewardInviteSuccessfull()
    {
        int val_6;
        var val_7;
        if((CompanyDevices.Instance.CompanyDevice() != false) && (this.HACKFakeInvitedAdded != false))
        {
                this.HACKFakeInvitedAdded = false;
        }
        
        if(41963520 < 1)
        {
                return;
        }
        
        GameEcon val_3 = App.getGameEcon;
        List.Enumerator<T> val_5 = this.needCoinedFriendIDs.GetEnumerator();
        label_14:
        if(val_7.MoveNext() == false)
        {
            goto label_12;
        }
        
        if(this.coinedFriendIDs == null)
        {
                throw new NullReferenceException();
        }
        
        this.coinedFriendIDs.Add(item:  val_6);
        goto label_14;
        label_12:
        val_7.Dispose();
        decimal val_9 = System.Decimal.op_Implicit(value:  val_3.FInviterCoinsReward * 41963520);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, source:  "Friend Inviter", externalParams:  0, animated:  false);
        this.needCoinedFriendIDs.Clear();
        this.SaveProgression();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnInvitesReady");
    }
    public WGInviteManager.TierReward NextTier()
    {
        int val_4;
        var val_5;
        val_4 = this;
        GameEcon val_1 = App.getGameEcon;
        if((this.<LastInviteTierCollected>k__BackingField) < val_1.FInviter_BR_I)
        {
                val_5 = 0;
            return (TierReward)(val_4 >= val_2.FInviter_SI_I) ? (1 + 1) : 1;
        }
        
        val_4 = this.<LastInviteTierCollected>k__BackingField;
        GameEcon val_2 = App.getGameEcon;
        return (TierReward)(val_4 >= val_2.FInviter_SI_I) ? (1 + 1) : 1;
    }
    public int NextTargetTierReward()
    {
        int[] val_1 = new int[3];
        GameEcon val_2 = App.getGameEcon;
        val_1[0] = val_2.FInviter_BR_R;
        GameEcon val_3 = App.getGameEcon;
        val_1[0] = val_3.FInviter_SI_R;
        GameEcon val_4 = App.getGameEcon;
        val_1[1] = val_4.FInviter_GO_R;
        return (int)val_1[this.NextTier() << 2];
    }
    public int NextTargetTierInvites()
    {
        int[] val_1 = new int[3];
        GameEcon val_2 = App.getGameEcon;
        val_1[0] = val_2.FInviter_BR_I;
        GameEcon val_3 = App.getGameEcon;
        val_1[0] = val_3.FInviter_SI_I;
        GameEcon val_4 = App.getGameEcon;
        val_1[1] = val_4.FInviter_GO_I;
        return (int)val_1[this.NextTier() << 2];
    }
    public string FreeCoinsTracking()
    {
        int val_3;
        string[] val_1 = new string[3];
        val_3 = val_1.Length;
        val_1[0] = "FriendInviter_Bronze";
        val_3 = val_1.Length;
        val_1[1] = "FriendInviter_Silver";
        val_3 = val_1.Length;
        val_1[2] = "FriendInviter_Gold";
        return (string)val_1[this.NextTier()];
    }
    public bool TierRewardAvailable()
    {
        return (bool)(this.InvitesCollected >= this.NextTargetTierInvites()) ? 1 : 0;
    }
    public void CollectNextTierReward()
    {
        int val_9;
        if(this.InvitesCollected < this.NextTargetTierInvites())
        {
                return;
        }
        
        int val_3 = this.NextTargetTierReward();
        val_9 = this.NextTargetTierInvites();
        decimal val_5 = System.Decimal.op_Implicit(value:  val_3);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, source:  this.FreeCoinsTracking(), externalParams:  0, animated:  false);
        GameEcon val_7 = App.getGameEcon;
        if(val_3 == val_7.FInviter_GO_R)
        {
                int val_9 = this.<LastIndexTierRewardCollected>k__BackingField;
            val_9 = val_9 + val_9;
            val_9 = 0;
            this.<LastIndexTierRewardCollected>k__BackingField = val_9;
        }
        
        this.<LastInviteTierCollected>k__BackingField = val_9;
        this.SaveProgression();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnInvitesReady");
    }
    public void SentInviteCode(string inviteCode, System.Action<string> codeResponse)
    {
        var val_8;
        this.codeResponse = codeResponse;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_3 = App.Player;
        val_2.Add(key:  "id", value:  val_3.id);
        val_2.Add(key:  "amb_code", value:  Base36Library.Base36.Decode(value:  inviteCode));
        val_2.Add(key:  "platform", value:  DeviceProperties.Platform);
        val_2.Add(key:  "os", value:  DeviceProperties.SimpleOSVersion);
        val_2.Add(key:  "device_model", value:  DeviceProperties.SimpleDeviceModel);
        val_8 = null;
        val_8 = null;
        App.networkManager.DoPost(path:  "/api/recruits", postBody:  val_2, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGInviteManager::OnSendInviteCodeCompleted(string path, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void OnSendInviteCodeCompleted(string path, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_6;
        string val_7;
        val_6 = "success";
        if((response.ContainsKey(key:  "success")) == false)
        {
            goto label_5;
        }
        
        object val_2 = response.Item["success"];
        if(null == null)
        {
            goto label_5;
        }
        
        if(this.codeResponse == null)
        {
            goto label_13;
        }
        
        this.codeResponse.Invoke(obj:  "success");
        UnityEngine.PlayerPrefs.DeleteKey(key:  "wfi_amb_code");
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_is_invited", value:  1);
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_code_manually_entered", value:  1);
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        goto label_13;
        label_5:
        val_6 = "error_status";
        if((response.ContainsKey(key:  "error_status")) != false)
        {
                val_7 = response.Item["error_status"];
        }
        else
        {
                val_7 = "unknow";
        }
        
        if(this.codeResponse != null)
        {
                this.codeResponse.Invoke(obj:  val_7);
        }
        
        label_13:
        this.codeResponse = 0;
    }
    private string GetShareText(bool useNewLine = True)
    {
        string val_10;
        AppConfigs val_2 = App.Configuration;
        val_10 = System.String.Format(format:  Localization.Localize(key:  "invite_friend_msg", defaultValue:  "Come play {0}! It\'s a fun word game that helps me relax!", useSingularKey:  false), arg0:  val_2.appConfig.gameName)(System.String.Format(format:  Localization.Localize(key:  "invite_friend_msg", defaultValue:  "Come play {0}! It\'s a fun word game that helps me relax!", useSingularKey:  false), arg0:  val_2.appConfig.gameName)) + "\n " + this.GetInviteFriendURL();
        if(WGInviteManager.isV2 != false)
        {
                val_10 = val_10 + "\n" + System.String.Format(format:  Localization.Localize(key:  "my_friend_code", defaultValue:  "My Friend code is: {0}", useSingularKey:  false), arg0:  this.<InviteCode>k__BackingField)(System.String.Format(format:  Localization.Localize(key:  "my_friend_code", defaultValue:  "My Friend code is: {0}", useSingularKey:  false), arg0:  this.<InviteCode>k__BackingField));
        }
        
        if(useNewLine == false)
        {
                return val_10.Replace(oldValue:  "\n", newValue:  " ");
        }
        
        return (string)val_10;
    }
    private void IncreaseInvitesSend()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_invites_send", value:  (UnityEngine.PlayerPrefs.GetInt(key:  "wfi_invites_send", defaultValue:  0)) + 1);
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        if(WGInviteManager.onInviteSent == null)
        {
                return;
        }
        
        WGInviteManager.onInviteSent.Invoke();
    }
    private string GetInviteFriendURL()
    {
        string val_10;
        AppConfigs val_1 = App.Configuration;
        AppConfigs val_2 = App.Configuration;
        AppConfigs val_5 = App.Configuration;
        val_10 = System.String.Format(format:  "https://{0}-invite{1}.{2}/", arg0:  val_1.appConfig.deeplinkScheme, arg1:  (val_2.appConfig.IsProduction() != true) ? "" : "-stage", arg2:  val_5.appConfig.domainName)(System.String.Format(format:  "https://{0}-invite{1}.{2}/", arg0:  val_1.appConfig.deeplinkScheme, arg1:  (val_2.appConfig.IsProduction() != true) ? "" : "-stage", arg2:  val_5.appConfig.domainName)) + "?a="("?a=") + this.<MemberId>k__BackingField(this.<MemberId>k__BackingField);
        if(WGInviteManager.isV2 == false)
        {
                return (string)val_10;
        }
        
        val_10 = val_10 + "&c="("&c=") + this.<InviteCode>k__BackingField(this.<InviteCode>k__BackingField);
        return (string)val_10;
    }
    public void ShowNoInternetPopup()
    {
        int val_5;
        var val_6;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_5 = val_4.Length;
        val_4[0] = "OK";
        val_5 = val_4.Length;
        val_4[1] = "NULL";
        val_6 = null;
        val_6 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  "INTERNET REQUIRED", messageTxt:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void ShowFTUX()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wfi_ftux", value:  1);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        WGInvite val_2 = WGInviteManager.ShowInvitePopup(status:  0);
    }
    private bool IsRecommendPopupAvailable()
    {
        var val_14;
        var val_15;
        var val_16;
        val_14 = 1152921504893161472;
        if((MonoSingleton<GameEventsManager>.Instance) == 0)
        {
            goto label_10;
        }
        
        GameEventsManager val_3 = MonoSingleton<GameEventsManager>.Instance;
        if(val_3.eventList == null)
        {
            goto label_10;
        }
        
        val_14 = 1152921504893161472;
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
            goto label_15;
        }
        
        label_10:
        val_15 = 1;
        label_35:
        GameBehavior val_6 = App.getBehavior;
        if((((val_6.<metaGameBehavior>k__BackingField) & 1) != 0) && (WGInviteManager.IsEnabled != false))
        {
                val_16 = (~WGInviteManager.InviteSent) & 1;
        }
        else
        {
                val_16 = 0;
        }
        
        if((val_16 & val_15) != 0)
        {
                return false;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_15 = val_9.<metaGameBehavior>k__BackingField;
        GameEcon val_10 = App.getGameEcon;
        if(val_15 <= val_10.RecLevel)
        {
                return false;
        }
        
        return SceneDictator.IsInGameScene();
        label_15:
        var val_13 = (~(MonoSingleton<WordGameEventsController>.Instance.ActivelyPlayingEventGameMode())) & 1;
        goto label_35;
    }
    public void ShowRecommendPopupWhenReady()
    {
        string val_22;
        if(this.IsRecommendPopupAvailable() == false)
        {
                return;
        }
        
        if(WGRecommendPopup.ShownTimes == 1)
        {
            goto label_2;
        }
        
        val_22 = WGRecommendPopup.LastShownDate;
        if((System.DateTime.TryParse(s:  val_22, result: out  new System.DateTime())) == false)
        {
                return;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        val_22 = 0;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime());
        double val_7 = val_6._ticks.TotalDays;
        GameEcon val_9 = App.getGameEcon;
        if(val_9.RecInterval > ((int)(val_7 == Infinity) ? (-val_7) : (val_7)))
        {
                return;
        }
        
        val_22 = WGRecommendPopup.ShownTimes;
        GameEcon val_11 = App.getGameEcon;
        int val_22 = val_11.RecLimit;
        val_22 = val_22 - 1;
        if(val_22 != val_22)
        {
            goto label_17;
        }
        
        GameEcon val_12 = App.getGameEcon;
        int val_23 = val_12.RecDelay;
        val_23 = (val_23 << 3) - val_23;
        val_23 = val_23 - 1;
        if(val_23 > ((int)(val_7 == Infinity) ? (-val_7) : (val_7)))
        {
                return;
        }
        
        WGRecommendPopup.ResetRFLogic();
        return;
        label_2:
        WGWindowManager val_15 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGRecommendPopup>(showNext:  false);
        int val_16 = WGRecommendPopup.ShownTimes;
        val_16 = val_16 + 1;
        WGRecommendPopup.ShownTimes = val_16;
        label_31:
        System.DateTime val_17 = DateTimeCheat.UtcNow;
        WGRecommendPopup.LastShownDate = val_17.dateData.ToShortDateString();
        return;
        label_17:
        WGWindowManager val_20 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGRecommendPopup>(showNext:  false);
        int val_21 = WGRecommendPopup.ShownTimes;
        val_21 = val_21 + 1;
        WGRecommendPopup.ShownTimes = val_21;
        goto label_31;
    }
    public void HACKAddFakeInvites(int invites)
    {
        do
        {
            int val_1 = UnityEngine.Random.Range(min:  1, max:  99999);
            if((this.needCoinedFriendIDs.Contains(item:  val_1)) != true)
        {
                if((this.coinedFriendIDs.Contains(item:  val_1)) != true)
        {
                this.needCoinedFriendIDs.Add(item:  val_1);
        }
        
        }
        
            System.Collections.Generic.List<System.Int32> val_4 = this.needCoinedFriendIDs;
            val_4 = val_4 - W22;
        }
        while(val_4 < invites);
        
        this.HACKFakeInvitedAdded = true;
    }
    public WGInviteManager()
    {
        var val_3;
        this.coinedFriendIDs = new System.Collections.Generic.List<System.Int32>();
        this.needCoinedFriendIDs = new System.Collections.Generic.List<System.Int32>();
        val_3 = null;
        val_3 = null;
        this.lastProfileSync = System.DateTime.MinValue;
    }

}
