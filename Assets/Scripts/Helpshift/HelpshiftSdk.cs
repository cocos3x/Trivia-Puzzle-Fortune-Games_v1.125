using UnityEngine;

namespace Helpshift
{
    public class HelpshiftSdk
    {
        // Fields
        public const string HS_RATE_ALERT_CLOSE = "HS_RATE_ALERT_CLOSE";
        public const string HS_RATE_ALERT_FEEDBACK = "HS_RATE_ALERT_FEEDBACK";
        public const string HS_RATE_ALERT_SUCCESS = "HS_RATE_ALERT_SUCCESS";
        public const string HS_RATE_ALERT_FAIL = "HS_RATE_ALERT_FAIL";
        public const string HSTAGSKEY = "hs-tags";
        public const string HSCUSTOMMETADATAKEY = "hs-custom-metadata";
        public const string UNITY_GAME_OBJECT = "unityGameObject";
        public const string ENABLE_IN_APP_NOTIFICATION = "enableInAppNotification";
        public const string ENABLE_DEFAULT_FALLBACK_LANGUAGE = "enableDefaultFallbackLanguage";
        public const string ENABLE_LOGGING = "enableLogging";
        public const string ENABLE_INBOX_POLLING = "enableInboxPolling";
        public const string ENABLE_AUTOMATIC_THEME_SWITCHING = "enableAutomaticThemeSwitching";
        public const string DISABLE_ENTRY_EXIT_ANIMATIONS = "disableEntryExitAnimations";
        public const string DISABLE_ERROR_REPORTING = "disableErrorReporting";
        public const string HSCUSTOMISSUEFIELDKEY = "hs-custom-issue-field";
        public const string HSTAGSMATCHINGKEY = "withTagsMatching";
        public const string CONTACT_US_ALWAYS = "always";
        public const string CONTACT_US_NEVER = "never";
        public const string CONTACT_US_AFTER_VIEWING_FAQS = "after_viewing_faqs";
        public const string CONTACT_US_AFTER_MARKING_ANSWER_UNHELPFUL = "after_marking_answer_unhelpful";
        public const string HSUserAcceptedTheSolution = "User accepted the solution";
        public const string HSUserRejectedTheSolution = "User rejected the solution";
        public const string HSUserSentScreenShot = "User sent a screenshot";
        public const string HSUserReviewedTheApp = "User reviewed the app";
        public const string HsFlowTypeDefault = "defaultFlow";
        public const string HsFlowTypeConversation = "conversationFlow";
        public const string HsFlowTypeFaqs = "faqsFlow";
        public const string HsFlowTypeFaqSection = "faqSectionFlow";
        public const string HsFlowTypeSingleFaq = "singleFaqFlow";
        public const string HsFlowTypeNested = "dynamicFormFlow";
        public const string HsCustomContactUsFlows = "customContactUsFlows";
        public const string HsFlowType = "type";
        public const string HsFlowConfig = "config";
        public const string HsFlowData = "data";
        public const string HsFlowTitle = "title";
        private static Helpshift.HelpshiftSdk instance;
        private static Helpshift.HelpshiftAndroid nativeSdk;
        
        // Methods
        private HelpshiftSdk()
        {
        
        }
        public static Helpshift.HelpshiftSdk getInstance()
        {
            Helpshift.HelpshiftAndroid val_3;
            var val_4;
            var val_5;
            val_4 = null;
            val_4 = null;
            if(Helpshift.HelpshiftSdk.instance == null)
            {
                    val_5 = null;
                val_5 = null;
                Helpshift.HelpshiftSdk.instance = new Helpshift.HelpshiftSdk();
                Helpshift.HelpshiftAndroid val_2 = null;
                val_3 = val_2;
                val_2 = new Helpshift.HelpshiftAndroid();
                val_4 = null;
                Helpshift.HelpshiftSdk.nativeSdk = val_3;
            }
            
            val_4 = null;
            return (Helpshift.HelpshiftSdk)Helpshift.HelpshiftSdk.instance;
        }
        public void install(string apiKey, string domainName, string appId, System.Collections.Generic.Dictionary<string, object> config)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3;
            var val_4;
            val_3 = config;
            if(val_3 == null)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
                val_3 = val_1;
                val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            }
            
            val_1.Add(key:  "sdkType", value:  "unity");
            val_1.Add(key:  "pluginVersion", value:  "5.5.1");
            val_1.Add(key:  "runtimeVersion", value:  UnityEngine.Application.unityVersion);
            val_4 = null;
            val_4 = null;
            Helpshift.HelpshiftSdk.nativeSdk.install(apiKey:  apiKey, domain:  domainName, appId:  appId, configMap:  val_1);
        }
        public void requestUnreadMessagesCount(bool isAsync)
        {
            null = null;
            isAsync = isAsync;
            Helpshift.HelpshiftSdk.nativeSdk.requestUnreadMessagesCount(isAsync:  isAsync);
        }
        public void setNameAndEmail(string userName, string email)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.setNameAndEmail(userName:  userName, email:  email);
        }
        public void setUserIdentifier(string identifier)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.setUserIdentifier(identifier:  identifier);
        }
        public void login(string identifier, string name, string email)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.login(identifier:  identifier, userName:  name, email:  email);
        }
        public void login(Helpshift.HelpshiftUser helpshiftUser)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.login(helpshiftUser:  helpshiftUser);
        }
        public void clearAnonymousUser()
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.clearAnonymousUser();
        }
        public void logout()
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.logout();
        }
        public void registerDeviceToken(string deviceToken)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.registerDeviceToken(deviceToken:  deviceToken);
        }
        public void leaveBreadCrumb(string breadCrumb)
        {
            var val_1;
            if(((0 & 2) != 0) && (0 == 0))
            {
                    val_1 = null;
            }
            
            Helpshift.HelpshiftSdk.nativeSdk.leaveBreadCrumb(breadCrumb:  breadCrumb);
        }
        public void clearBreadCrumbs()
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.clearBreadCrumbs();
        }
        public void showConversation(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showConversation(configMap:  configMap);
        }
        public void showFAQSection(string sectionPublishId, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showFAQSection(sectionPublishId:  sectionPublishId, configMap:  configMap);
        }
        public void showSingleFAQ(string questionPublishId, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showSingleFAQ(questionPublishId:  questionPublishId, configMap:  configMap);
        }
        public void showFAQs(System.Collections.Generic.Dictionary<string, object> configMap)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showFAQs(configMap:  configMap);
        }
        public void updateMetaData(System.Collections.Generic.Dictionary<string, object> metaData)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.updateMetaData(metaData:  metaData);
        }
        public void handlePushNotification(System.Collections.Generic.Dictionary<string, object> pushNotificationData)
        {
            var val_4;
            string val_5;
            var val_10;
            var val_12;
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            Dictionary.Enumerator<TKey, TValue> val_2 = pushNotificationData.GetEnumerator();
            label_5:
            val_10 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_5 != 0)
            {
                goto label_5;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_5);
            goto label_5;
            label_2:
            val_4.Dispose();
            List.Enumerator<T> val_7 = val_1.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_7;
            }
            
            bool val_9 = pushNotificationData.Remove(key:  0);
            goto label_8;
            label_7:
            0.Dispose();
            val_12 = null;
            val_12 = null;
            Helpshift.HelpshiftSdk.nativeSdk.handlePushNotification(pushNotificationData:  pushNotificationData);
        }
        public void showAlertToRateAppWithURL(string url)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showAlertToRateAppWithURL(url:  url);
        }
        public void setSDKLanguage(string locale)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.setSDKLanguage(locale:  locale);
        }
        public void setTheme(string themeName)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.setTheme(themeResourceName:  themeName);
        }
        public void registerDelegates()
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.registerDelegates();
        }
        public void showDynamicForm(string title, System.Collections.Generic.Dictionary<string, object>[] flows)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showDynamicForm(title:  title, flows:  flows);
        }
        public void showDynamicForm(string title, System.Collections.Generic.Dictionary<string, object>[] flows, System.Collections.Generic.Dictionary<string, object> configMap)
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.showDynamicForm(title:  title, flows:  flows);
        }
        public void onApplicationQuit()
        {
            null = null;
            onApplicationQuit();
        }
        public void checkIfConversationActive()
        {
            null = null;
            Helpshift.HelpshiftSdk.nativeSdk.checkIfConversationActive();
        }
        private static HelpshiftSdk()
        {
        
        }
    
    }

}
