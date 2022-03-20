using UnityEngine;

namespace Helpshift
{
    public class HelpshiftAndroid
    {
        // Fields
        private UnityEngine.AndroidJavaClass jc;
        private UnityEngine.AndroidJavaObject currentActivity;
        private UnityEngine.AndroidJavaObject application;
        private UnityEngine.AndroidJavaClass hsHelpshiftClass;
        
        // Methods
        public HelpshiftAndroid()
        {
            var val_5;
            UnityEngine.AndroidJavaClass val_1 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer");
            this.jc = val_1;
            UnityEngine.AndroidJavaObject val_2 = val_1.GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
            this.currentActivity = val_2;
            val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.application = val_2.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplication", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            this.hsHelpshiftClass = new UnityEngine.AndroidJavaClass(className:  "com.helpshift.HelpshiftUnityAPI");
        }
        public void install(string apiKey, string domain, string appId, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            int val_4;
            string val_1 = Json.Serializer.Serialize(obj:  configMap);
            object[] val_2 = new object[5];
            val_4 = val_2.Length;
            val_2[0] = this.application;
            if(apiKey != null)
            {
                    val_4 = val_2.Length;
            }
            
            val_2[1] = apiKey;
            if(domain != null)
            {
                    val_4 = val_2.Length;
            }
            
            val_2[2] = domain;
            if(appId != null)
            {
                    val_4 = val_2.Length;
            }
            
            val_2[3] = appId;
            if(val_1 != null)
            {
                    val_4 = val_2.Length;
            }
            
            val_2[4] = val_1;
            this.hsHelpshiftClass.CallStatic(methodName:  "install", args:  val_2);
            Helpshift.HelpshiftInternalLogger.d(message:  "Install called : Domain : "("Install called : Domain : ") + domain + ", Config : "(", Config : ") + val_1);
        }
        public void requestUnreadMessagesCount(bool isAsync)
        {
            bool val_1 = isAsync;
            Helpshift.HelpshiftInternalLogger.d(message:  "Call requestUnreadMessagesCount: isAsync : "("Call requestUnreadMessagesCount: isAsync : ") + val_1.ToString());
            object[] val_4 = new object[1];
            val_4[0] = val_1;
            this.hsHelpshiftClass.CallStatic(methodName:  "requestUnreadMessagesCount", args:  val_4);
        }
        public void setNameAndEmail(string userName, string email)
        {
            int val_2;
            object[] val_1 = new object[2];
            val_2 = val_1.Length;
            val_1[0] = userName;
            if(email != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[1] = email;
            this.hsHelpshiftClass.CallStatic(methodName:  "setNameAndEmail", args:  val_1);
        }
        public void setUserIdentifier(string identifier)
        {
            object[] val_1 = new object[1];
            val_1[0] = identifier;
            this.hsHelpshiftClass.CallStatic(methodName:  "setUserIdentifier", args:  val_1);
        }
        public void registerDeviceToken(string deviceToken)
        {
            int val_3;
            Helpshift.HelpshiftInternalLogger.d(message:  "Register device token :"("Register device token :") + deviceToken);
            object[] val_2 = new object[2];
            val_3 = val_2.Length;
            val_2[0] = this.currentActivity;
            if(deviceToken != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = deviceToken;
            this.hsHelpshiftClass.CallStatic(methodName:  "registerDeviceToken", args:  val_2);
        }
        public void leaveBreadCrumb(string breadCrumb)
        {
            object[] val_1 = new object[1];
            val_1[0] = breadCrumb;
            this.hsHelpshiftClass.CallStatic(methodName:  "leaveBreadCrumb", args:  val_1);
        }
        public void clearBreadCrumbs()
        {
            var val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.hsHelpshiftClass.CallStatic(methodName:  "clearBreadCrumbs", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public void login(string identifier, string userName, string email)
        {
            int val_3;
            Helpshift.HelpshiftInternalLogger.d(message:  "Login called : "("Login called : ") + userName);
            object[] val_2 = new object[3];
            val_3 = val_2.Length;
            val_2[0] = identifier;
            if(userName != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = userName;
            if(email != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[2] = email;
            this.hsHelpshiftClass.CallStatic(methodName:  "login", args:  val_2);
        }
        public void login(Helpshift.HelpshiftUser helpshiftUser)
        {
            Helpshift.HelpshiftInternalLogger.d(message:  "Login called : "("Login called : ") + helpshiftUser.name);
            object[] val_2 = new object[1];
            val_2[0] = val_2.jsonifyHelpshiftUser(helpshiftUser:  helpshiftUser);
            this.hsHelpshiftClass.CallStatic(methodName:  "loginHelpshiftUser", args:  val_2);
        }
        public void clearAnonymousUser()
        {
            var val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.hsHelpshiftClass.CallStatic(methodName:  "clearAnonymousUser", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public void logout()
        {
            var val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.hsHelpshiftClass.CallStatic(methodName:  "logout", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        private string serializeApiConfig(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            if(configMap == null)
            {
                    return 0;
            }
            
            return Json.Serializer.Serialize(obj:  this.cleanConfig(configMap:  configMap));
        }
        public void showConversation(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            object[] val_1 = new object[2];
            val_1[0] = this.currentActivity;
            val_1[1] = this.serializeApiConfig(configMap:  configMap);
            this.hsHelpshiftClass.CallStatic(methodName:  "showConversationUnity", args:  val_1);
        }
        public void showFAQSection(string sectionPublishId, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            int val_3;
            object[] val_1 = new object[3];
            val_3 = val_1.Length;
            val_1[0] = this.currentActivity;
            if(sectionPublishId != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = sectionPublishId;
            val_1[2] = this.serializeApiConfig(configMap:  configMap);
            this.hsHelpshiftClass.CallStatic(methodName:  "showFAQSectionUnity", args:  val_1);
        }
        public void showSingleFAQ(string questionPublishId, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            int val_3;
            object[] val_1 = new object[3];
            val_3 = val_1.Length;
            val_1[0] = this.currentActivity;
            if(questionPublishId != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = questionPublishId;
            val_1[2] = this.serializeApiConfig(configMap:  configMap);
            this.hsHelpshiftClass.CallStatic(methodName:  "showSingleFAQUnity", args:  val_1);
        }
        public void showFAQs(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            object[] val_1 = new object[2];
            val_1[0] = this.currentActivity;
            val_1[1] = this.serializeApiConfig(configMap:  configMap);
            this.hsHelpshiftClass.CallStatic(methodName:  "showFAQsUnity", args:  val_1);
        }
        public void updateMetaData(System.Collections.Generic.Dictionary<string, object> metaData)
        {
            object[] val_1 = new object[1];
            val_1[0] = Json.Serializer.Serialize(obj:  metaData);
            this.hsHelpshiftClass.CallStatic(methodName:  "setMetaData", args:  val_1);
        }
        private System.Collections.Generic.Dictionary<string, object> cleanConfig(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            if((configMap.ContainsKey(key:  "customIssueFields")) == false)
            {
                    return (System.Collections.Generic.Dictionary<System.String, System.Object>)configMap;
            }
            
            configMap.set_Item(key:  "hs-custom-issue-field", value:  configMap.Item["customIssueFields"]);
            bool val_3 = configMap.Remove(key:  "customIssueFields");
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)configMap;
        }
        public void handlePushNotification(System.Collections.Generic.Dictionary<string, object> pushNotificationData)
        {
            Helpshift.HelpshiftInternalLogger.d(message:  "Handle push notification : data :"("Handle push notification : data :") + pushNotificationData.ToString());
            object[] val_3 = new object[2];
            val_3[0] = this.currentActivity;
            val_3[1] = Json.Serializer.Serialize(obj:  pushNotificationData);
            this.hsHelpshiftClass.CallStatic(methodName:  "handlePush", args:  val_3);
        }
        public void showAlertToRateAppWithURL(string url)
        {
            object[] val_1 = new object[1];
            val_1[0] = url;
            this.hsHelpshiftClass.CallStatic(methodName:  "showAlertToRateApp", args:  val_1);
        }
        public void registerDelegates()
        {
            var val_1;
            Helpshift.HelpshiftInternalLogger.d(message:  "Registering delegates");
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.hsHelpshiftClass.CallStatic(methodName:  "registerDelegates", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public void setSDKLanguage(string locale)
        {
            object[] val_1 = new object[1];
            val_1[0] = locale;
            this.hsHelpshiftClass.CallStatic(methodName:  "setSDKLanguage", args:  val_1);
        }
        public void setTheme(string themeResourceName)
        {
            object[] val_1 = new object[1];
            val_1[0] = themeResourceName;
            this.hsHelpshiftClass.CallStatic(methodName:  "setTheme", args:  val_1);
        }
        public void showDynamicForm(string title, System.Collections.Generic.Dictionary<string, object>[] flows)
        {
            int val_3;
            object[] val_1 = new object[3];
            val_3 = val_1.Length;
            val_1[0] = this.currentActivity;
            if(title != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = title;
            val_1[2] = Json.Serializer.Serialize(obj:  flows);
            this.hsHelpshiftClass.CallStatic(methodName:  "showDynamicFormFromDataJson", args:  val_1);
        }
        public void checkIfConversationActive()
        {
            var val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            this.hsHelpshiftClass.CallStatic(methodName:  "checkIfConversationActive", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public void onApplicationQuit()
        {
            Helpshift.HelpshiftInternalLogger.d(message:  "onApplicationQuit");
        }
        private string jsonifyHelpshiftUser(Helpshift.HelpshiftUser helpshiftUser)
        {
            System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_1.Add(key:  "identifier", value:  helpshiftUser.identifier);
            val_1.Add(key:  "email", value:  helpshiftUser.email);
            val_1.Add(key:  "name", value:  helpshiftUser.name);
            val_1.Add(key:  "authToken", value:  helpshiftUser.authToken);
            return Json.Serializer.Serialize(obj:  val_1);
        }
    
    }

}
