using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustConfig
    {
        // Fields
        public const string AdjustUrlStrategyChina = "china";
        public const string AdjustUrlStrategyIndia = "india";
        public const string AdjustDataResidencyEU = "data-residency-eu";
        public const string AdjustAdRevenueSourceMopub = "mopub";
        public const string AdjustAdRevenueSourceAdmob = "admob";
        public const string AdjustAdRevenueSourceFbNativeAd = "facebook_native_ad";
        public const string AdjustAdRevenueSourceFbAudienceNetwork = "facebook_audience_network";
        public const string AdjustAdRevenueSourceIronsource = "ironsource";
        public const string AdjustAdRevenueSourceFyber = "fyber";
        public const string AdjustAdRevenueSourceAerserv = "aerserv";
        public const string AdjustAdRevenueSourceAppodeal = "appodeal";
        public const string AdjustAdRevenueSourceAdincube = "adincube";
        public const string AdjustAdRevenueSourceFusePowered = "fusepowered";
        public const string AdjustAdRevenueSourceAddaptr = "addapptr";
        public const string AdjustAdRevenueSourceMillenialMediation = "millennial_mediation";
        public const string AdjustAdRevenueSourceFlurry = "flurry";
        public const string AdjustAdRevenueSourceAdmost = "admost";
        public const string AdjustAdRevenueSourceDeltadna = "deltadna";
        public const string AdjustAdRevenueSourceUpsight = "upsight";
        public const string AdjustAdRevenueSourceUnityads = "unityads";
        public const string AdjustAdRevenueSourceAdtoapp = "adtoapp";
        public const string AdjustAdRevenueSourceTapdaq = "tapdaq";
        internal string appToken;
        internal string sceneName;
        internal string userAgent;
        internal string defaultTracker;
        internal string externalDeviceId;
        internal string urlStrategy;
        internal System.Nullable<long> info1;
        internal System.Nullable<long> info2;
        internal System.Nullable<long> info3;
        internal System.Nullable<long> info4;
        internal System.Nullable<long> secretId;
        internal System.Nullable<double> delayStart;
        internal System.Nullable<bool> isDeviceKnown;
        internal System.Nullable<bool> sendInBackground;
        internal System.Nullable<bool> eventBufferingEnabled;
        internal System.Nullable<bool> allowSuppressLogLevel;
        internal System.Nullable<bool> needsCost;
        internal bool launchDeferredDeeplink;
        internal System.Nullable<com.adjust.sdk.AdjustLogLevel> logLevel;
        internal com.adjust.sdk.AdjustEnvironment environment;
        internal System.Action<string> deferredDeeplinkDelegate;
        internal System.Action<com.adjust.sdk.AdjustEventSuccess> eventSuccessDelegate;
        internal System.Action<com.adjust.sdk.AdjustEventFailure> eventFailureDelegate;
        internal System.Action<com.adjust.sdk.AdjustSessionSuccess> sessionSuccessDelegate;
        internal System.Action<com.adjust.sdk.AdjustSessionFailure> sessionFailureDelegate;
        internal System.Action<com.adjust.sdk.AdjustAttribution> attributionChangedDelegate;
        internal System.Nullable<bool> readImei;
        internal System.Nullable<bool> preinstallTrackingEnabled;
        internal string processName;
        internal System.Nullable<bool> allowiAdInfoReading;
        internal System.Nullable<bool> allowAdServicesInfoReading;
        internal System.Nullable<bool> allowIdfaReading;
        internal System.Nullable<bool> skAdNetworkHandling;
        internal System.Action<string> logDelegate;
        
        // Methods
        public AdjustConfig(string appToken, com.adjust.sdk.AdjustEnvironment environment)
        {
            this.environment = environment;
            this.appToken = appToken;
            this.sceneName = "";
            this.processName = "";
        }
        public AdjustConfig(string appToken, com.adjust.sdk.AdjustEnvironment environment, bool allowSuppressLogLevel)
        {
            this.environment = environment;
            this.appToken = appToken;
            this.sceneName = "";
            this.processName = "";
            System.Nullable<System.Boolean> val_2 = new System.Nullable<System.Boolean>(value:  allowSuppressLogLevel);
            this.allowSuppressLogLevel = val_2.HasValue;
        }
        public void setLogLevel(com.adjust.sdk.AdjustLogLevel logLevel)
        {
            System.Nullable<com.adjust.sdk.AdjustLogLevel> val_1 = new System.Nullable<com.adjust.sdk.AdjustLogLevel>(value:  logLevel);
            this.logLevel = val_1.HasValue;
        }
        public void setDefaultTracker(string defaultTracker)
        {
            this.defaultTracker = defaultTracker;
        }
        public void setExternalDeviceId(string externalDeviceId)
        {
            this.externalDeviceId = externalDeviceId;
        }
        public void setLaunchDeferredDeeplink(bool launchDeferredDeeplink)
        {
            this.launchDeferredDeeplink = launchDeferredDeeplink;
        }
        public void setSendInBackground(bool sendInBackground)
        {
            sendInBackground = sendInBackground;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  sendInBackground);
            this.sendInBackground = val_1.HasValue;
        }
        public void setEventBufferingEnabled(bool eventBufferingEnabled)
        {
            eventBufferingEnabled = eventBufferingEnabled;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  eventBufferingEnabled);
            this.eventBufferingEnabled = val_1.HasValue;
        }
        public void setNeedsCost(bool needsCost)
        {
            needsCost = needsCost;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  needsCost);
            this.needsCost = val_1.HasValue;
        }
        public void setDelayStart(double delayStart)
        {
            System.Nullable<System.Double> val_1 = new System.Nullable<System.Double>(value:  delayStart);
            this.delayStart = val_1.HasValue;
        }
        public void setUserAgent(string userAgent)
        {
            this.userAgent = userAgent;
        }
        public void setIsDeviceKnown(bool isDeviceKnown)
        {
            isDeviceKnown = isDeviceKnown;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  isDeviceKnown);
            this.isDeviceKnown = val_1.HasValue;
        }
        public void setUrlStrategy(string urlStrategy)
        {
            this.urlStrategy = urlStrategy;
        }
        public void deactivateSKAdNetworkHandling()
        {
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  true);
            this.skAdNetworkHandling = val_1.HasValue;
        }
        public void setDeferredDeeplinkDelegate(System.Action<string> deferredDeeplinkDelegate, string sceneName = "Adjust")
        {
            this.deferredDeeplinkDelegate = deferredDeeplinkDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<string> getDeferredDeeplinkDelegate()
        {
            return (System.Action<System.String>)this.deferredDeeplinkDelegate;
        }
        public void setAttributionChangedDelegate(System.Action<com.adjust.sdk.AdjustAttribution> attributionChangedDelegate, string sceneName = "Adjust")
        {
            this.attributionChangedDelegate = attributionChangedDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<com.adjust.sdk.AdjustAttribution> getAttributionChangedDelegate()
        {
            return (System.Action<com.adjust.sdk.AdjustAttribution>)this.attributionChangedDelegate;
        }
        public void setEventSuccessDelegate(System.Action<com.adjust.sdk.AdjustEventSuccess> eventSuccessDelegate, string sceneName = "Adjust")
        {
            this.eventSuccessDelegate = eventSuccessDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<com.adjust.sdk.AdjustEventSuccess> getEventSuccessDelegate()
        {
            return (System.Action<com.adjust.sdk.AdjustEventSuccess>)this.eventSuccessDelegate;
        }
        public void setEventFailureDelegate(System.Action<com.adjust.sdk.AdjustEventFailure> eventFailureDelegate, string sceneName = "Adjust")
        {
            this.eventFailureDelegate = eventFailureDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<com.adjust.sdk.AdjustEventFailure> getEventFailureDelegate()
        {
            return (System.Action<com.adjust.sdk.AdjustEventFailure>)this.eventFailureDelegate;
        }
        public void setSessionSuccessDelegate(System.Action<com.adjust.sdk.AdjustSessionSuccess> sessionSuccessDelegate, string sceneName = "Adjust")
        {
            this.sessionSuccessDelegate = sessionSuccessDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<com.adjust.sdk.AdjustSessionSuccess> getSessionSuccessDelegate()
        {
            return (System.Action<com.adjust.sdk.AdjustSessionSuccess>)this.sessionSuccessDelegate;
        }
        public void setSessionFailureDelegate(System.Action<com.adjust.sdk.AdjustSessionFailure> sessionFailureDelegate, string sceneName = "Adjust")
        {
            this.sessionFailureDelegate = sessionFailureDelegate;
            this.sceneName = sceneName;
        }
        public System.Action<com.adjust.sdk.AdjustSessionFailure> getSessionFailureDelegate()
        {
            return (System.Action<com.adjust.sdk.AdjustSessionFailure>)this.sessionFailureDelegate;
        }
        public void setAppSecret(long secretId, long info1, long info2, long info3, long info4)
        {
            System.Nullable<System.Int64> val_1 = new System.Nullable<System.Int64>(value:  secretId);
            this.secretId = val_1.HasValue;
            System.Nullable<System.Int64> val_2 = new System.Nullable<System.Int64>(value:  info1);
            this.info1 = val_2.HasValue;
            System.Nullable<System.Int64> val_3 = new System.Nullable<System.Int64>(value:  info2);
            this.info2 = val_3.HasValue;
            System.Nullable<System.Int64> val_4 = new System.Nullable<System.Int64>(value:  info3);
            System.Nullable<System.Int64> val_5;
            this.info3 = val_4.HasValue;
            val_5 = new System.Nullable<System.Int64>(value:  info4);
            this.info4 = val_5.HasValue;
        }
        public void setAllowiAdInfoReading(bool allowiAdInfoReading)
        {
            allowiAdInfoReading = allowiAdInfoReading;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  allowiAdInfoReading);
            this.allowiAdInfoReading = val_1.HasValue;
        }
        public void setAllowAdServicesInfoReading(bool allowAdServicesInfoReading)
        {
            allowAdServicesInfoReading = allowAdServicesInfoReading;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  allowAdServicesInfoReading);
            this.allowAdServicesInfoReading = val_1.HasValue;
        }
        public void setAllowIdfaReading(bool allowIdfaReading)
        {
            allowIdfaReading = allowIdfaReading;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  allowIdfaReading);
            this.allowIdfaReading = val_1.HasValue;
        }
        public void setProcessName(string processName)
        {
            this.processName = processName;
        }
        public void setReadMobileEquipmentIdentity(bool readMobileEquipmentIdentity)
        {
        
        }
        public void setPreinstallTrackingEnabled(bool preinstallTrackingEnabled)
        {
            preinstallTrackingEnabled = preinstallTrackingEnabled;
            System.Nullable<System.Boolean> val_1 = new System.Nullable<System.Boolean>(value:  preinstallTrackingEnabled);
            this.preinstallTrackingEnabled = val_1.HasValue;
        }
        public void setLogDelegate(System.Action<string> logDelegate)
        {
            this.logDelegate = logDelegate;
        }
    
    }

}
