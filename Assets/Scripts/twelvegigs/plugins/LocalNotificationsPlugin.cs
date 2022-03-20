using UnityEngine;

namespace twelvegigs.plugins
{
    public class LocalNotificationsPlugin
    {
        // Fields
        private const string REGISTER_NOTIFICATION = "local_notification_register_notification";
        private static string GAME_NAME;
        private static bool initialized;
        private static bool enabled;
        private static string[] notification_messages;
        private static bool notification_status;
        private static System.Collections.Generic.List<int> single_instanced;
        private static System.Action<System.Collections.Generic.Dictionary<string, string>> notificationPoster;
        private static System.Action<string, string, string, string> notificationCanceller;
        private static System.Action notificationsKiller;
        private static System.Action notificationsEnabler;
        private static System.Action notificationsClearer;
        private static UnityEngine.AndroidJavaObject plugin;
        public static System.Collections.Generic.List<string> QAHACK_LPNsLog;
        
        // Properties
        public static bool IsInitialized { get; }
        
        // Methods
        public static void Initialize(string gameName, bool available)
        {
            var val_24;
            var val_25;
            System.Delegate val_26;
            var val_27;
            int val_28;
            var val_29;
            var val_30;
            var val_31;
            val_24 = null;
            val_24 = null;
            twelvegigs.plugins.LocalNotificationsPlugin.GAME_NAME = gameName;
            val_25 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_25 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_25 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_25 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_26 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
            val_26 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.LocalNotificationsPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(twelvegigs.plugins.LocalNotificationsPlugin.plugin == null)
            {
                    return;
            }
            
            string val_4 = Localization.Localize(key:  "ignore_upper", defaultValue:  "IGNORE", useSingularKey:  false);
            val_27 = null;
            val_27 = null;
            object[] val_5 = new object[2];
            val_28 = val_5.Length;
            val_5[0] = Localization.Localize(key:  "collect", defaultValue:  "COLLECT", useSingularKey:  false);
            if(val_4 != null)
            {
                    val_28 = val_5.Length;
            }
            
            val_5[1] = val_4;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin.Call(methodName:  "initLocText", args:  val_5);
            System.Action<System.Collections.Generic.Dictionary<System.String, System.String>> val_6 = null;
            val_26 = 1152921520038340304;
            val_6 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.String>>(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::AndroidNotificationPoster(System.Collections.Generic.Dictionary<string, string> _params));
            twelvegigs.plugins.LocalNotificationsPlugin.notificationPoster = val_6;
            System.Action<System.String, System.String, System.String, System.String> val_7 = new System.Action<System.String, System.String, System.String, System.String>(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::AndroidNotificationCanceller(string tipo, string title, string message, string repeats));
            twelvegigs.plugins.LocalNotificationsPlugin.notificationCanceller = val_7;
            System.Action val_8 = new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::AndroidNotificationsDisabler());
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsKiller = val_8;
            System.Action val_9 = new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::AndroidNotificationsEnabler());
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsEnabler = val_9;
            System.Action val_10 = new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::AndroidNotificationsClearer());
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsClearer = val_10;
            val_29 = null;
            if(CompanyDevices.Instance.CompanyDevice() != false)
            {
                    val_30 = null;
                System.Delegate val_14 = System.Delegate.Combine(a:  val_6, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.String>>(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::GeneralNotificationPosterLog(System.Collections.Generic.Dictionary<string, string> _params)));
                if(val_14 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
                twelvegigs.plugins.LocalNotificationsPlugin.notificationPoster = val_14;
                System.Delegate val_16 = System.Delegate.Combine(a:  val_7, b:  new System.Action<System.String, System.String, System.String, System.String>(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::GeneralNotificationCancellerLog(string tipo, string title, string message, string repeats)));
                if(val_16 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
                twelvegigs.plugins.LocalNotificationsPlugin.notificationCanceller = val_16;
                System.Delegate val_18 = System.Delegate.Combine(a:  val_8, b:  new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::GeneralNotificationsDisablerLog()));
                if(val_18 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
                twelvegigs.plugins.LocalNotificationsPlugin.notificationsKiller = val_18;
                System.Delegate val_20 = System.Delegate.Combine(a:  val_9, b:  new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::GeneralNotificationsEnablerLog()));
                if(val_20 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
                twelvegigs.plugins.LocalNotificationsPlugin.notificationsEnabler = val_20;
                System.Action val_21 = null;
                val_26 = val_21;
                val_21 = new System.Action(object:  0, method:  static System.Void twelvegigs.plugins.LocalNotificationsPlugin::GeneralNotificationsClearerLog());
                System.Delegate val_22 = System.Delegate.Combine(a:  val_10, b:  val_21);
                val_31 = null;
                if(val_22 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
                twelvegigs.plugins.LocalNotificationsPlugin.notificationsClearer = val_22;
            }
            
            twelvegigs.plugins.LocalNotificationsPlugin.Setup();
            twelvegigs.plugins.LocalNotificationsPlugin.initialized = true;
            twelvegigs.plugins.LocalNotificationsPlugin.enabled = available;
        }
        private static void Setup()
        {
            var val_3 = null;
            twelvegigs.plugins.LocalNotificationsPlugin.notification_status = ((UnityEngine.PlayerPrefs.GetInt(key:  "player_notification_1", defaultValue:  2)) > 1) ? 1 : 0;
        }
        private static System.DateTime OfficeHours(System.DateTime proposedTime)
        {
            ulong val_5;
            System.DateTime val_1 = proposedTime.dateData.ToLocalTime();
            val_5 = val_1.dateData;
            goto label_1;
            label_4:
            System.DateTime val_2 = 0.AddHours(value:  1);
            val_5 = val_2.dateData;
            label_1:
            if((twelvegigs.plugins.LocalNotificationsPlugin.AtNight(time:  new System.DateTime() {dateData = val_5})) == true)
            {
                goto label_4;
            }
            
            System.DateTime val_4 = val_5.ToUniversalTime();
            return (System.DateTime)val_4.dateData;
        }
        private static bool AtNight(System.DateTime time)
        {
            var val_4;
            if(time.dateData.Hour <= 7)
            {
                    var val_3 = (time.dateData.Hour > 22) ? 1 : 0;
                return (bool)val_4;
            }
            
            val_4 = 0;
            return (bool)val_4;
        }
        public static void PostNotification(twelvegigs.plugins.NotificationType tipo, System.DateTime when, string optMessage, System.Collections.Generic.Dictionary<string, object> extraData)
        {
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotif(tipo:  tipo, when:  new System.DateTime() {dateData = when.dateData}, interval:  0, optTitle:  0, optMessage:  optMessage, useTimeModifier:  true, extraData:  extraData, imgUrl:  0, priority:  0);
        }
        public static void PostNotification(twelvegigs.plugins.NotificationType tipo, System.DateTime when, string optTitle, string optMessage, System.Collections.Generic.Dictionary<string, object> extraData)
        {
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotif(tipo:  tipo, when:  new System.DateTime() {dateData = when.dateData}, interval:  0, optTitle:  optTitle, optMessage:  optMessage, useTimeModifier:  true, extraData:  extraData, imgUrl:  0, priority:  0);
        }
        public static void PostNotification(twelvegigs.plugins.NotificationType tipo, System.DateTime when, twelvegigs.plugins.NotificationInterval interval, string optTitle, string optMessage, System.Collections.Generic.Dictionary<string, object> extraData, twelvegigs.plugins.NotificationPriority priority = 0, bool useTimeModifier = True)
        {
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotif(tipo:  tipo, when:  new System.DateTime() {dateData = when.dateData}, interval:  interval, optTitle:  optTitle, optMessage:  optMessage, useTimeModifier:  useTimeModifier, extraData:  extraData, imgUrl:  0, priority:  priority);
        }
        public static void PostRandomizedNotification(twelvegigs.plugins.NotificationType tipo, System.DateTime when, string optMessage, System.Collections.Generic.Dictionary<string, object> extraData)
        {
            System.DateTime val_1 = twelvegigs.plugins.LocalNotificationsPlugin.OfficeHours(proposedTime:  new System.DateTime() {dateData = when.dateData});
            System.DateTime val_5 = new System.DateTime(year:  val_1.dateData.Year, month:  val_1.dateData.Month, day:  val_1.dateData.Day, hour:  9, minute:  0, second:  0);
            System.DateTime val_7 = val_5.dateData.AddHours(value:  (double)UnityEngine.Random.Range(min:  0f, max:  9f));
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotif(tipo:  tipo, when:  new System.DateTime() {dateData = val_7.dateData}, interval:  0, optTitle:  0, optMessage:  optMessage, useTimeModifier:  false, extraData:  extraData, imgUrl:  0, priority:  0);
        }
        public static void PostNotifWithImage(twelvegigs.plugins.NotificationType type, System.DateTime when, twelvegigs.plugins.NotificationInterval interval = 0, string title, string message, System.Collections.Generic.Dictionary<string, object> extraData, string imageUrl, twelvegigs.plugins.NotificationPriority priority = 0, bool useTimeModifier = True)
        {
            twelvegigs.plugins.LocalNotificationsPlugin.PostNotif(tipo:  type, when:  new System.DateTime() {dateData = when.dateData}, interval:  0, optTitle:  title, optMessage:  message, useTimeModifier:  useTimeModifier, extraData:  extraData, imgUrl:  imageUrl, priority:  priority);
        }
        private static void PostNotif(twelvegigs.plugins.NotificationType tipo, System.DateTime when, twelvegigs.plugins.NotificationInterval interval, string optTitle, string optMessage, bool useTimeModifier = True, System.Collections.Generic.Dictionary<string, object> extraData, string imgUrl, twelvegigs.plugins.NotificationPriority priority = 0)
        {
            string val_20;
            string val_21;
            string val_22;
            twelvegigs.plugins.NotificationInterval val_23;
            var val_24;
            var val_25;
            ulong val_26;
            var val_27;
            var val_28;
            var val_29;
            System.String[] val_30;
            var val_31;
            string val_32;
            val_20 = useTimeModifier;
            val_21 = optMessage;
            val_22 = optTitle;
            val_23 = interval;
            val_24 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.Available() == false)
            {
                    return;
            }
            
            val_25 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.IsNotificationEnabled() == false)
            {
                    return;
            }
            
            if((twelvegigs.plugins.LocalNotificationsPlugin.IsSingleInstanced(tipo:  tipo)) != false)
            {
                    twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  tipo);
            }
            
            System.DateTime val_5 = when.dateData.ToUniversalTime();
            val_26 = val_5.dateData;
            if(val_20 != false)
            {
                    System.DateTime val_6 = twelvegigs.plugins.LocalNotificationsPlugin.OfficeHours(proposedTime:  new System.DateTime() {dateData = val_26});
                val_26 = val_6.dateData;
                val_27 = null;
            }
            else
            {
                    val_27 = null;
            }
            
            System.DateTime val_7 = System.DateTime.UtcNow;
            System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_26}, d2:  new System.DateTime() {dateData = val_7.dateData});
            double val_9 = val_8._ticks.TotalSeconds;
            val_9 = (val_9 == Infinity) ? (-val_9) : (val_9);
            if((System.String.IsNullOrEmpty(value:  val_22)) != false)
            {
                    val_28 = null;
                val_28 = null;
                val_22 = twelvegigs.plugins.LocalNotificationsPlugin.GAME_NAME;
            }
            
            if(val_21 == null)
            {
                goto label_23;
            }
            
            if(extraData == null)
            {
                goto label_35;
            }
            
            label_36:
            val_20 = MiniJSON.Json.Serialize(obj:  extraData);
            goto label_25;
            label_23:
            val_29 = null;
            val_29 = null;
            val_30 = twelvegigs.plugins.LocalNotificationsPlugin.notification_messages;
            if(twelvegigs.plugins.LocalNotificationsPlugin.notification_messages.Length <= tipo)
            {
                goto label_29;
            }
            
            val_30 = twelvegigs.plugins.LocalNotificationsPlugin.notification_messages;
            val_30 = val_30 + (tipo << 3);
            val_21 = twelvegigs.plugins.LocalNotificationsPlugin.LocalizeString(message:  (twelvegigs.plugins.LocalNotificationsPlugin.notification_messages + (tipo) << 3) + 32);
            if(extraData != null)
            {
                goto label_36;
            }
            
            goto label_35;
            label_29:
            val_21 = "";
            if(extraData != null)
            {
                goto label_36;
            }
            
            label_35:
            val_20 = "{}";
            label_25:
            val_31 = null;
            val_31 = null;
            System.Collections.Generic.Dictionary<System.String, System.String> val_13 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_13.Add(key:  "title", value:  val_22);
            val_13.Add(key:  "message", value:  val_21);
            val_13.Add(key:  "interval", value:  val_23.ToString());
            val_13.Add(key:  "type", value:  tipo.ToString());
            val_23 = priority;
            val_13.Add(key:  "withInterval", value:  (val_23 > 0) ? 1 : 0.ToString().ToLower());
            if(((int)val_9 & 2147483648) == 0)
            {
                    val_32 = (int)val_9.ToString();
            }
            else
            {
                    val_32 = "0";
            }
            
            val_13.Add(key:  "seconds", value:  val_32);
            val_13.Add(key:  "extraData", value:  val_20);
            val_13.Add(key:  "image", value:  imgUrl);
            val_13.Add(key:  "priority", value:  val_23.ToString());
            twelvegigs.plugins.LocalNotificationsPlugin.notificationPoster.Invoke(obj:  val_13);
        }
        public static void EnableNotification(twelvegigs.plugins.NotificationType tipo)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2;
            var val_3;
            var val_4;
            val_2 = tipo;
            twelvegigs.plugins.LocalNotificationsPlugin.ToggleNotification(val:  true);
            val_3 = null;
            val_3 = null;
            if(val_2 != 2)
            {
                    return;
            }
            
            if(App.trackerManager == null)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "BonusCreditsNotificationsChanged", value:  true);
            val_4 = null;
            val_4 = null;
            App.trackerManager.track(eventName:  Events.NOTIFICATAION_BONUS_CREDITS, data:  val_1);
        }
        public static void DisableNotification(twelvegigs.plugins.NotificationType tipo)
        {
            twelvegigs.plugins.NotificationType val_2;
            var val_3;
            var val_4;
            val_2 = tipo;
            twelvegigs.plugins.LocalNotificationsPlugin.ToggleNotification(val:  false);
            twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  val_2);
            val_3 = null;
            val_3 = null;
            if(val_2 != 2)
            {
                    return;
            }
            
            if(App.trackerManager == null)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "BonusCreditsNotificationsChanged", value:  null);
            val_4 = null;
            val_4 = null;
            App.trackerManager.track(eventName:  Events.NOTIFICATAION_BONUS_CREDITS, data:  val_1);
        }
        public static void Clear()
        {
            var val_2;
            var val_3;
            val_2 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.Available() == false)
            {
                    return;
            }
            
            val_3 = null;
            val_3 = null;
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsClearer.Invoke();
        }
        public static void EnableNotifications()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3;
            var val_4;
            var val_6;
            val_3 = 1152921505040338944;
            val_4 = null;
            val_4 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.initialized == false)
            {
                    return;
            }
            
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsEnabler.Invoke();
            twelvegigs.plugins.LocalNotificationsPlugin.ToggleNotification(val:  true);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_3 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "AllNotificationsChanged", value:  true);
            val_6 = null;
            val_6 = null;
            App.trackerManager.track(eventName:  Events.NOTIFICATAION_ALL, data:  val_1);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnPushNotificationsChanged");
        }
        public static void DisableNotifications()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4;
            var val_5;
            var val_6;
            var val_7;
            val_4 = 1152921505040338944;
            val_5 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.Available() == false)
            {
                    return;
            }
            
            val_6 = null;
            val_6 = null;
            twelvegigs.plugins.LocalNotificationsPlugin.notificationsKiller.Invoke();
            twelvegigs.plugins.LocalNotificationsPlugin.ToggleNotification(val:  false);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
            val_4 = val_2;
            val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "AllNotificationsChanged", value:  null);
            val_7 = null;
            val_7 = null;
            App.trackerManager.track(eventName:  Events.NOTIFICATAION_ALL, data:  val_2);
            twelvegigs.plugins.LocalNotificationsPlugin.Clear();
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnPushNotificationsChanged");
        }
        public static void KillNotification(twelvegigs.plugins.NotificationType tipo)
        {
            twelvegigs.plugins.NotificationType val_5;
            var val_6;
            var val_7;
            System.String[] val_8;
            string val_9;
            val_5 = tipo;
            val_6 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.Available() == false)
            {
                    return;
            }
            
            val_7 = null;
            val_7 = null;
            val_8 = twelvegigs.plugins.LocalNotificationsPlugin.notification_messages;
            if(twelvegigs.plugins.LocalNotificationsPlugin.notification_messages.Length > val_5)
            {
                    val_8 = twelvegigs.plugins.LocalNotificationsPlugin.notification_messages;
                System.String[] val_2 = val_8 + (val_5 << 3);
                val_7 = null;
                val_9 = twelvegigs.plugins.LocalNotificationsPlugin.LocalizeString(message:  (twelvegigs.plugins.LocalNotificationsPlugin.notification_messages + (tipo) << 3) + 32);
            }
            else
            {
                    val_9 = 0;
            }
            
            val_7 = null;
            val_5 = val_5.ToString();
            twelvegigs.plugins.LocalNotificationsPlugin.notificationCanceller.Invoke(arg1:  val_5, arg2:  twelvegigs.plugins.LocalNotificationsPlugin.GAME_NAME, arg3:  val_9, arg4:  "1");
        }
        private static bool IsSingleInstanced(twelvegigs.plugins.NotificationType tipo)
        {
            null = null;
            return twelvegigs.plugins.LocalNotificationsPlugin.single_instanced.Contains(item:  tipo);
        }
        private static void ToggleNotification(bool val)
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.notification_status = val;
            UnityEngine.PlayerPrefs.SetInt(key:  "player_notification_1", value:  (val != true) ? (1 + 1) : 1);
            bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public static bool IsNotificationEnabled()
        {
            System.Object[] val_6;
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            var val_11;
            val_7 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.Available() != false)
            {
                    val_8 = null;
                val_8 = null;
                if(twelvegigs.plugins.LocalNotificationsPlugin.notification_status != true)
            {
                    object[] val_2 = new object[1];
                val_9 = null;
                val_6 = val_2;
                val_9 = null;
                val_6[0] = twelvegigs.plugins.LocalNotificationsPlugin.notification_status;
                UnityEngine.Debug.LogErrorFormat(format:  "LocalNotifPlugin status {0}", args:  val_2);
                val_8 = null;
            }
            
                val_8 = null;
                var val_3 = (twelvegigs.plugins.LocalNotificationsPlugin.notification_status == true) ? 1 : 0;
                return (bool)val_10;
            }
            
            object[] val_4 = new object[1];
            val_11 = null;
            val_11 = null;
            val_4[0] = twelvegigs.plugins.LocalNotificationsPlugin.enabled;
            UnityEngine.Debug.LogErrorFormat(format:  "LocalNotifPlugin enabled {0}", args:  val_4);
            object[] val_5 = new object[1];
            val_6 = val_5;
            val_6[0] = twelvegigs.plugins.LocalNotificationsPlugin.initialized;
            UnityEngine.Debug.LogErrorFormat(format:  "LocalNotifPlugin init {0}", args:  val_5);
            val_10 = 0;
            return (bool)val_10;
        }
        public static bool Available()
        {
            var val_2;
            var val_4;
            val_2 = null;
            val_2 = null;
            if(twelvegigs.plugins.LocalNotificationsPlugin.enabled != false)
            {
                    var val_1 = (twelvegigs.plugins.LocalNotificationsPlugin.initialized == true) ? 1 : 0;
                return (bool)val_4;
            }
            
            val_4 = 0;
            return (bool)val_4;
        }
        public static bool get_IsInitialized()
        {
            null = null;
            return (bool)twelvegigs.plugins.LocalNotificationsPlugin.initialized;
        }
        public static bool AllOn()
        {
            null = null;
            return (bool)twelvegigs.plugins.LocalNotificationsPlugin.notification_status;
        }
        private static string Repeats(twelvegigs.plugins.NotificationType tipo)
        {
            return "1";
        }
        public static void RequestNotificationAccess()
        {
        
        }
        public static bool PermissionRequested()
        {
            return true;
        }
        private static void GeneralNotificationPosterLog(System.Collections.Generic.Dictionary<string, string> _params)
        {
            var val_10;
            string val_2 = _params.Item["title"];
            string val_3 = _params.Item["message"];
            string val_5 = _params.Item["withInterval"];
            string val_6 = _params.Item["interval"];
            val_10 = null;
            val_10 = null;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog.Add(item:  System.String.Format(format:  "<color=#23D5F5>Posting:</color>\n {0} in {1} seconds", arg0:  System.Int32.Parse(s:  _params.Item["type"]).ToString(), arg1:  _params.Item["seconds"]));
        }
        private static void GeneralNotificationCancellerLog(string tipo, string title, string message, string repeats)
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog.Add(item:  System.String.Format(format:  "<color=#D7F377>Cancelling:</color>\n {0}", arg0:  System.Int32.Parse(s:  tipo).ToString()));
        }
        private static void GeneralNotificationsDisablerLog()
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog.Add(item:  "--Disabling LPNs--");
        }
        private static void GeneralNotificationsEnablerLog()
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog.Add(item:  "--Enabling LPNs--");
        }
        private static void GeneralNotificationsClearerLog()
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog.Add(item:  "--Clearing LPNs--");
        }
        private static void AndroidNotificationPoster(System.Collections.Generic.Dictionary<string, string> _params)
        {
            var val_13;
            int val_14;
            string val_2 = _params.Item["title"];
            string val_3 = _params.Item["message"];
            string val_4 = _params.Item["seconds"];
            string val_5 = _params.Item["withInterval"];
            string val_6 = _params.Item["interval"];
            string val_7 = _params.Item["extraData"];
            string val_8 = _params.Item["image"];
            string val_9 = _params.Item["priority"];
            string val_10 = Localization.Localize(key:  "collect", defaultValue:  "COLLECT", useSingularKey:  false);
            string val_11 = Localization.Localize(key:  "ignore_upper", defaultValue:  "IGNORE", useSingularKey:  false);
            val_13 = null;
            val_13 = null;
            object[] val_12 = new object[9];
            val_14 = val_12.Length;
            val_12[0] = _params.Item["type"];
            if(val_2 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[1] = val_2;
            if(val_3 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[2] = val_3;
            if(val_4 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[3] = val_4;
            if(val_5 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[4] = val_5;
            if(val_6 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[5] = val_6;
            if(val_7 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[6] = val_7;
            if(val_8 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[7] = val_8;
            if(val_9 != null)
            {
                    val_14 = val_12.Length;
            }
            
            val_12[8] = val_9;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin.Call(methodName:  "postNotification", args:  val_12);
        }
        private static void AndroidNotificationCanceller(string tipo, string title, string message, string repeats)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[4];
            val_3 = val_1.Length;
            val_1[0] = tipo;
            if(title != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = title;
            if(message != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[2] = message;
            if(repeats != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[3] = repeats;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin.Call(methodName:  "cancelNotification", args:  val_1);
        }
        private static void AndroidNotificationsDisabler()
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin.Call(methodName:  "disableNotifications", args:  new object[0]);
        }
        private static void AndroidNotificationsEnabler()
        {
            null = null;
            twelvegigs.plugins.LocalNotificationsPlugin.enabled = true;
            twelvegigs.plugins.LocalNotificationsPlugin.plugin.Call(methodName:  "enableNotifications", args:  new object[0]);
        }
        private static void AndroidNotificationsClearer()
        {
        
        }
        private static string LocalizeString(string message)
        {
            return Localization.Localize(key:  message, defaultValue:  "", useSingularKey:  false);
        }
        public static twelvegigs.plugins.NotificationType ConvertIdToNotification(string id)
        {
            return System.Int32.Parse(s:  id);
        }
        public LocalNotificationsPlugin()
        {
        
        }
        private static LocalNotificationsPlugin()
        {
            int val_4;
            twelvegigs.plugins.LocalNotificationsPlugin.GAME_NAME = "";
            twelvegigs.plugins.LocalNotificationsPlugin.initialized = false;
            twelvegigs.plugins.LocalNotificationsPlugin.enabled = false;
            string[] val_1 = new string[33];
            val_4 = val_1.Length;
            val_1[0] = "ALL_NOTS";
            val_4 = val_4;
            val_1[1] = "GENERAL";
            val_4 = val_4;
            val_1[2] = "NM_BONUS";
            val_4 = val_4;
            val_1[3] = "";
            val_4 = val_4;
            val_1[4] = "";
            val_4 = val_4;
            val_1[5] = "NM_FREE_HINT_48";
            val_4 = val_4;
            val_1[6] = "NM_FREE_HINT_1";
            val_4 = val_4;
            val_1[7] = "POST_AD";
            val_4 = val_4;
            val_1[8] = "";
            val_4 = val_4;
            val_1[9] = "";
            val_4 = val_4;
            val_1[10] = "";
            val_4 = val_4;
            val_1[11] = "";
            val_4 = val_4;
            val_1[12] = "";
            val_4 = val_4;
            val_1[13] = "";
            val_4 = val_4;
            val_1[14] = "INSTALL_RECAPTURE";
            val_4 = val_4;
            val_1[15] = "LEVEL_ANSWER";
            val_4 = val_4;
            val_1[16] = "DC_REMINDER_M";
            val_4 = val_4;
            val_1[17] = "DC_REMINDER_E";
            val_4 = val_4;
            val_1[18] = "PB_REMINDER";
            val_4 = val_4;
            val_1[19] = "GT_FREE_TRIAL";
            val_4 = val_4;
            val_1[20] = "";
            val_4 = val_4;
            val_1[21] = "LIVES_REMINDER";
            val_4 = val_4;
            val_1[22] = "";
            val_4 = val_4;
            val_1[23] = "";
            val_4 = val_4;
            val_1[24] = "FEED_YOUR_PET";
            val_4 = val_4;
            val_1[25] = "EXTRA_LIFE_READY";
            val_4 = val_4;
            val_1[26] = "";
            val_4 = val_4;
            val_1[27] = "";
            val_4 = val_4;
            val_1[28] = "TOURNAMENTS_ENDED";
            val_4 = val_4;
            val_1[29] = "";
            val_4 = val_4;
            val_1[30] = "";
            val_4 = val_4;
            val_1[31] = "";
            val_4 = val_4;
            val_1[32] = "";
            twelvegigs.plugins.LocalNotificationsPlugin.notification_messages = val_1;
            twelvegigs.plugins.LocalNotificationsPlugin.notification_status = true;
            System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
            val_2.Add(item:  2);
            val_2.Add(item:  5);
            val_2.Add(item:  6);
            val_2.Add(item:  7);
            val_2.Add(item:  14);
            val_2.Add(item:  15);
            val_2.Add(item:  16);
            val_2.Add(item:  17);
            val_2.Add(item:  25);
            val_2.Add(item:  26);
            val_2.Add(item:  28);
            twelvegigs.plugins.LocalNotificationsPlugin.single_instanced = val_2;
            twelvegigs.plugins.LocalNotificationsPlugin.QAHACK_LPNsLog = new System.Collections.Generic.List<System.String>();
        }
    
    }

}
