using UnityEngine;
public class FacebookPlugin
{
    // Fields
    private const int MAX_PER_INVITE = 50;
    private static bool initialized;
    private static string gameObjectName;
    private static string gameName;
    private static string _userFbid;
    private static string _userAccessToken;
    private static bool accessTokenRefreshed;
    private static string _userFbName;
    private static string[] appFriendsIdsArray;
    private static string nextInvitableFriends;
    private static int nextInvitableFriendsCount;
    public const string OnFacebookPluginUpdate = "OnFacebookPluginUpdate";
    public const string OnSDKError = "OnSDKError";
    public static System.Collections.Generic.List<string> loginReadPermissions;
    private static System.Collections.Generic.List<FacebookPlugin.FBTasks> AvailableTasks;
    private static System.Collections.Generic.List<FacebookPlugin.FBTasks> CompletedTasks;
    
    // Properties
    public static string UserAccessToken { get; set; }
    public static bool AccessTokenRefreshed { get; set; }
    public static string[] userFriendsIds { get; }
    public static bool PluginInitialized { get; }
    public static bool IsLoggedIn { get; }
    public static string AppPageID { get; }
    public static string userFbid { get; }
    
    // Methods
    public static string get_UserAccessToken()
    {
        null = null;
        return (string)FacebookPlugin._userAccessToken;
    }
    private static void set_UserAccessToken(string value)
    {
        string val_5;
        var val_6;
        var val_7;
        val_5 = value;
        Player val_1 = App.Player;
        if((System.String.op_Equality(a:  val_1.properties.fb_access_token, b:  val_5)) == true)
        {
                return;
        }
        
        val_6 = null;
        val_6 = null;
        FacebookPlugin._userAccessToken = val_5;
        Player val_3 = App.Player;
        val_3.properties.fb_access_token = FacebookPlugin._userAccessToken;
        Player val_4 = App.Player;
        val_5 = true;
        val_4.properties.Save(writePrefs:  true);
        val_7 = null;
        val_7 = null;
        FacebookPlugin.accessTokenRefreshed = true;
    }
    public static bool get_AccessTokenRefreshed()
    {
        null = null;
        return (bool)FacebookPlugin.accessTokenRefreshed;
    }
    private static void set_AccessTokenRefreshed(bool value)
    {
        null = null;
        FacebookPlugin.accessTokenRefreshed = value;
    }
    public static string[] get_userFriendsIds()
    {
        null = null;
        return (System.String[])FacebookPlugin.appFriendsIdsArray;
    }
    public static bool get_PluginInitialized()
    {
        null = null;
        return (bool)FacebookPlugin.OnSDKError;
    }
    public static bool get_IsLoggedIn()
    {
        return false;
    }
    public static string get_AppPageID()
    {
        AppConfigs val_1 = App.Configuration;
        return (string)val_1.appConfig.facebook_page_id;
    }
    public static void MakeTaskAvailable(FacebookPlugin.FBTasks newlyAvailableTask)
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = null;
        val_4 = null;
        if((FacebookPlugin.CompletedTasks.Contains(item:  newlyAvailableTask)) != false)
        {
                val_5 = null;
            val_5 = null;
            bool val_2 = FacebookPlugin.CompletedTasks.Remove(item:  newlyAvailableTask);
        }
        
        val_6 = null;
        val_6 = null;
        if((FacebookPlugin.AvailableTasks.Contains(item:  newlyAvailableTask)) != false)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        FacebookPlugin.AvailableTasks.Add(item:  newlyAvailableTask);
    }
    public static void MakeTaskComplete(FacebookPlugin.FBTasks newlyCompletedTask)
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = null;
        val_4 = null;
        if((FacebookPlugin.AvailableTasks.Contains(item:  newlyCompletedTask)) != false)
        {
                val_5 = null;
            val_5 = null;
            bool val_2 = FacebookPlugin.AvailableTasks.Remove(item:  newlyCompletedTask);
        }
        
        val_6 = null;
        val_6 = null;
        if((FacebookPlugin.CompletedTasks.Contains(item:  newlyCompletedTask)) != false)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        FacebookPlugin.CompletedTasks.Add(item:  newlyCompletedTask);
    }
    public static bool TaskAvailable(FacebookPlugin.FBTasks taskToCheck)
    {
        null = null;
        return FacebookPlugin.AvailableTasks.Contains(item:  taskToCheck);
    }
    public static bool TaskComplete(FacebookPlugin.FBTasks taskToCheck)
    {
        null = null;
        return FacebookPlugin.CompletedTasks.Contains(item:  taskToCheck);
    }
    public static string get_userFbid()
    {
        var val_5;
        var val_6;
        System.Action val_7;
        PlayerProperties val_8;
        var val_9;
        val_5 = 1152921504888901632;
        val_6 = null;
        val_6 = null;
        if((System.String.IsNullOrEmpty(value:  FacebookPlugin._userFbid)) == false)
        {
            goto label_3;
        }
        
        val_5 = 1152921504884269056;
        Player val_2 = App.Player;
        val_7 = 0;
        if((System.String.IsNullOrEmpty(value:  val_2.properties.offline_fb_id)) == true)
        {
                return (string)val_7;
        }
        
        Player val_4 = App.Player;
        val_8 = val_4.properties;
        if(val_8 != null)
        {
            goto label_12;
        }
        
        throw new NullReferenceException();
        label_3:
        val_9 = null;
        label_12:
        val_7 = App.onAppQuitAction;
        return (string)val_7;
    }
    public static void init(string gameObjectName, string gameName)
    {
        string val_7;
        var val_8;
        var val_9;
        var val_11;
        val_7 = gameName;
        val_8 = null;
        val_8 = null;
        val_9 = val_8;
        if(FacebookPlugin.OnSDKError != null)
        {
                return;
        }
        
        val_9 = null;
        FacebookPlugin.gameObjectName = gameObjectName;
        FacebookPlugin.gameName = val_7;
        val_7 = 1152921504884269056;
        AppConfigs val_1 = App.Configuration;
        if((System.String.IsNullOrEmpty(value:  val_1.appConfig.facebook_permissions)) != false)
        {
                val_11 = null;
        }
        else
        {
                AppConfigs val_3 = App.Configuration;
            char[] val_4 = new char[1];
            val_4[0] = ',';
            System.Collections.Generic.List<System.String> val_6 = null;
            val_7 = val_6;
            val_6 = new System.Collections.Generic.List<System.String>(collection:  val_3.appConfig.facebook_permissions.Split(separator:  val_4));
            val_11 = null;
            val_11 = null;
            FacebookPlugin.loginReadPermissions = val_7;
        }
        
        val_11 = null;
        FacebookPlugin.OnSDKError = 1;
    }
    public static void SendAccessToken()
    {
        twelvegigs.net.JsonApiRequester val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = 1152921504888901632;
        val_5 = null;
        val_5 = null;
        if(FacebookPlugin.accessTokenRefreshed == false)
        {
                return;
        }
        
        val_6 = null;
        val_6 = null;
        FacebookPlugin.accessTokenRefreshed = false;
        val_7 = null;
        val_7 = null;
        val_4 = App.networkManager;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        Player val_3 = App.Player;
        val_1.Add(key:  "access_token", value:  val_3.properties.fb_access_token);
        val_4.DoPost(path:  "/facebook/credentials", postBody:  val_1, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private static void InitComplete()
    {
    
    }
    private static void OnLoginActions()
    {
        var val_3;
        Player val_1 = App.Player;
        val_1.properties.online_fb_id = FacebookPlugin._userFbid;
        FacebookPlugin.MakeTaskComplete(newlyCompletedTask:  1);
        FacebookPlugin.RetrieveBasicInfo();
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
        val_3 = null;
        val_3 = null;
        App.trackerManager.track(eventName:  Events.FB_LOGIN);
    }
    public static void PerformFirstAvailableTask()
    {
        var val_1;
        System.Collections.Generic.List<FBTasks> val_2;
        val_1 = null;
        val_1 = null;
        val_2 = FacebookPlugin.AvailableTasks;
        if((FacebookPlugin.AvailableTasks + 24) < 1)
        {
                return;
        }
        
        val_2 = FacebookPlugin.AvailableTasks;
        val_2.Sort();
        if((FacebookPlugin.AvailableTasks + 24) != 0)
        {
                return;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
    }
    public static void PerformTask(FacebookPlugin.FBTasks task)
    {
    
    }
    public static void RetrieveBasicInfo()
    {
        null = null;
        if((System.String.IsNullOrEmpty(value:  FacebookPlugin._userFbid)) != false)
        {
                return;
        }
        
        string val_2 = System.Uri.EscapeUriString(stringToEscape:  "/me?fields=first_name,last_name,picture");
    }
    public static void GetUserFriends()
    {
    
    }
    private static void NotifyRequestCompleted(FacebookPlugin.FBRequest request, bool success)
    {
        bool val_1 = success;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFacebookPluginUpdate", aData:  new System.Collections.Hashtable());
    }
    public static void requestAppUserId()
    {
    
    }
    public static void ShareDialog(string url, System.Action<bool> successCallback, string message = "Play this awesome game with me!")
    {
        string val_3;
        var val_4;
        val_3 = url;
        val_4 = null;
        val_4 = null;
        if(FacebookPlugin.OnSDKError == null)
        {
                return;
        }
        
        if(val_3 == null)
        {
                AppConfigs val_1 = App.Configuration;
            val_3 = val_1.gameConfig.facebookRecommenderUrl;
        }
        
        System.Uri val_2 = new System.Uri(uriString:  val_3);
    }
    public static void FeedDialog(string toId = "", string linkToShare, System.Action<bool> successCallback)
    {
    
    }
    public static void PostScreenshot(byte[] screenshot)
    {
        null = null;
        if(FacebookPlugin.OnSDKError == null)
        {
                return;
        }
        
        new UnityEngine.WWWForm().AddBinaryData(fieldName:  "image", contents:  screenshot, fileName:  "Screenshot.png");
    }
    public static void AppInvite()
    {
        UnityEngine.Debug.LogError(message:  "FacebookPlugin: AppInvite is deprecated on current plugin");
    }
    public FacebookPlugin()
    {
    
    }
    private static FacebookPlugin()
    {
        FacebookPlugin.OnSDKError = 0;
        FacebookPlugin._userFbid = System.String.alignConst;
        FacebookPlugin._userAccessToken = System.String.alignConst;
        FacebookPlugin.accessTokenRefreshed = false;
        FacebookPlugin._userFbName = System.String.alignConst;
        FacebookPlugin.appFriendsIdsArray = 0;
        FacebookPlugin.nextInvitableFriends = System.String.alignConst;
        FacebookPlugin.nextInvitableFriendsCount = 0;
        FacebookPlugin.loginReadPermissions = new System.Collections.Generic.List<System.String>();
        FacebookPlugin.AvailableTasks = new System.Collections.Generic.List<FBTasks>();
        FacebookPlugin.CompletedTasks = new System.Collections.Generic.List<FBTasks>();
    }

}
