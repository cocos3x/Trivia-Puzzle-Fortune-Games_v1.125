using UnityEngine;

namespace twelvegigs.plugins
{
    public class InstalledAppsPlugin
    {
        // Fields
        public const string ON_INSTALLEDAPPS_RESPONDED = "OnInstalledAppsResponded";
        private const string SAVE_GAME_NETWORK_KEY = "InstallApp_SavedGameNetwork";
        private const string IMAGE_SERVER_URL = "https://cdn.12gigs.com/network_games/";
        private static twelvegigs.plugins.InstalledAppsPlugin.GameApp[] appsToCheckForPlatform;
        private static System.Collections.Generic.List<object> <NetworkPromos>k__BackingField;
        private static string lastResponse;
        private static bool initialized;
        private static bool fetching;
        private static bool fetched;
        private static UnityEngine.AndroidJavaObject plugin;
        private static string[] availablePackagesAndroid;
        private static string[] availablePackagesKindle;
        private static string[] availablePackagesIOS;
        
        // Properties
        public static twelvegigs.plugins.InstalledAppsPlugin.GameApp[] PackagesToCheck { get; set; }
        public static System.Collections.Generic.List<object> NetworkPromos { get; set; }
        public static string LastResponse { get; }
        public static bool Fetched { get; }
        
        // Methods
        public static twelvegigs.plugins.InstalledAppsPlugin.GameApp[] get_PackagesToCheck()
        {
            twelvegigs.plugins.InstalledAppsPlugin.Init();
            return (GameApp[])twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform;
        }
        public static void set_PackagesToCheck(twelvegigs.plugins.InstalledAppsPlugin.GameApp[] value)
        {
            null = null;
            twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform = value;
        }
        public static System.Collections.Generic.List<object> get_NetworkPromos()
        {
            null = null;
            return (System.Collections.Generic.List<System.Object>)twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField;
        }
        public static void set_NetworkPromos(System.Collections.Generic.List<object> value)
        {
            null = null;
            twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField = value;
        }
        public static string get_LastResponse()
        {
            null = null;
            return (string)twelvegigs.plugins.InstalledAppsPlugin.lastResponse;
        }
        public static bool get_Fetched()
        {
            null = null;
            return (bool)twelvegigs.plugins.InstalledAppsPlugin.fetched;
        }
        private static void InitializeDefaultAppsToCheckFor()
        {
            var val_4;
            var val_5;
            var val_6;
            var val_7;
            twelvegigs.plugins.InstalledAppsPlugin.LoadNetworkGamesInfo();
            if(twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform != null)
            {
                    return;
            }
            
            val_4 = null;
            val_4 = null;
            GameApp[] val_1 = new GameApp[0];
            val_5 = 0;
            val_6 = 32;
            twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform = val_1;
            goto label_10;
            label_19:
            if((val_1[33] & 2) != 0)
            {
                    GameApp val_4 = val_1[24];
            }
            
            InstalledAppsPlugin.GameApp val_2 = new InstalledAppsPlugin.GameApp(gameName:  "", packageName:  X22 + 0, assetName:  "");
            val_5 = 1;
            val_6 = 64;
            mem2[0] = val_2.uniqueName;
            mem2[0] = val_2.assetName;
            label_10:
            val_7 = null;
            val_7 = null;
            if(val_5 < mem[1152921520033981672])
            {
                goto label_19;
            }
        
        }
        public static void Init()
        {
            UnityEngine.AndroidJavaObject val_4;
            var val_5;
            var val_6;
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            val_4 = 1152921504886665216;
            val_5 = null;
            val_5 = null;
            if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
            {
                    return;
            }
            
            val_6 = null;
            val_6 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.initialized != true)
            {
                    val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_8 = null;
                val_4 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.InstalledAppsPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
                val_8 = null;
                twelvegigs.plugins.InstalledAppsPlugin.plugin = val_4;
                twelvegigs.plugins.InstalledAppsPlugin.InitializeDefaultAppsToCheckFor();
                val_6 = null;
                twelvegigs.plugins.InstalledAppsPlugin.initialized = true;
            }
            
            val_6 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.fetched == true)
            {
                    return;
            }
            
            val_6 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.fetching != false)
            {
                    return;
            }
            
            val_9 = 1152921505039917081;
            twelvegigs.plugins.InstalledAppsPlugin.fetching = true;
            val_10 = null;
            val_10 = null;
            App.networkManager.DoGet(path:  "/api/network_games", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void twelvegigs.plugins.InstalledAppsPlugin::onNetworkResponse_MoreGames(string method, System.Collections.Generic.Dictionary<string, object> data)), destroy:  true, immediate:  false, getParams:  0, timeout:  20);
        }
        public static void UpdatePromos()
        {
            var val_1;
            var val_2;
            val_1 = null;
            val_1 = null;
            twelvegigs.plugins.InstalledAppsPlugin.fetched = false;
            val_1 = null;
            val_1 = null;
            if((twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField) != null)
            {
                    val_2 = null;
                val_2 = null;
                twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField.Clear();
                val_1 = null;
            }
            
            twelvegigs.plugins.InstalledAppsPlugin.Init();
        }
        private static void onNetworkResponse_MoreGames(string method, System.Collections.Generic.Dictionary<string, object> data)
        {
            var val_8;
            System.Collections.Generic.List<System.Object> val_9;
            var val_10;
            if(data == null)
            {
                    return;
            }
            
            val_8 = "success";
            val_9 = 1152921510222861648;
            if((data.ContainsKey(key:  "success")) == false)
            {
                    return;
            }
            
            val_8 = 1152921510214912464;
            object val_2 = data.Item["success"];
            if(null == null)
            {
                    return;
            }
            
            if((data.ContainsKey(key:  "network_games")) == false)
            {
                    return;
            }
            
            val_10 = null;
            val_10 = null;
            twelvegigs.plugins.InstalledAppsPlugin.lastResponse = PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false);
            val_9 = data.Item["network_games"];
            twelvegigs.plugins.InstalledAppsPlugin.SaveNetworkGamesInfo(networkGames:  val_9);
            twelvegigs.plugins.InstalledAppsPlugin.CreateGameAppFromNetwork(networkGames:  val_9);
            twelvegigs.plugins.InstalledAppsPlugin.fetched = true;
            twelvegigs.plugins.InstalledAppsPlugin.fetching = false;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnInstalledAppsResponded", aData:  new System.Collections.Hashtable());
        }
        private static void SaveNetworkGamesInfo(System.Collections.Generic.List<object> networkGames)
        {
            UnityEngine.PlayerPrefs.SetString(key:  "InstallApp_SavedGameNetwork", value:  MiniJSON.Json.Serialize(obj:  networkGames));
            bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        }
        private static void LoadNetworkGamesInfo()
        {
            if((UnityEngine.PlayerPrefs.HasKey(key:  "InstallApp_SavedGameNetwork")) == false)
            {
                    return;
            }
            
            twelvegigs.plugins.InstalledAppsPlugin.CreateGameAppFromNetwork(networkGames:  MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "InstallApp_SavedGameNetwork", defaultValue:  "[]")));
        }
        private static void CreateGameAppFromNetwork(System.Collections.Generic.List<object> networkGames)
        {
            string val_3;
            string val_4;
            string val_14;
            var val_15;
            var val_17;
            var val_18;
            val_14 = networkGames;
            val_15 = null;
            val_15 = null;
            twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform = new GameApp[0];
            List.Enumerator<T> val_2 = val_14.GetEnumerator();
            val_17 = 0;
            goto label_4;
            label_18:
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            object val_5 = val_3.Item["name"];
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_6 = val_3.Item["package_name"];
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_8 = val_3.Item["asset"];
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            InstalledAppsPlugin.GameApp val_9 = new InstalledAppsPlugin.GameApp(gameName:  val_5, packageName:  val_6.Trim(), assetName:  val_8);
            val_14 = "networkgameicon" + val_8;
            bool val_12 = twelvegigs.net.ImageRequest.LoadFromPreCache(filename:  val_14, textureToSet: out  0);
            val_18 = null;
            val_18 = null;
            val_4 = val_9.uniqueName;
            val_3 = val_9.assetName;
            if(twelvegigs.plugins.InstalledAppsPlugin.appsToCheckForPlatform == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17 = 1;
            mem[1152921520034807776] = val_4;
            mem[1152921520034807792] = val_3;
            label_4:
            if(val_4.MoveNext() == true)
            {
                goto label_18;
            }
            
            val_4.Dispose();
        }
        public static void UpdateInstalledApps()
        {
            var val_17;
            var val_18;
            var val_19;
            var val_20;
            val_18 = null;
            val_18 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.initialized != true)
            {
                    twelvegigs.plugins.InstalledAppsPlugin.Init();
                val_18 = null;
            }
            
            val_18 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.fetched == false)
            {
                    return;
            }
            
            if(twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck == null)
            {
                    return;
            }
            
            GameApp[] val_2 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            if(val_2.Length == 0)
            {
                    return;
            }
            
            System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
            val_19 = 0;
            goto label_16;
            label_30:
            if((System.String.IsNullOrEmpty(value:  twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[1])) != true)
            {
                    val_3.Add(item:  twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[1]);
            }
            
            val_19 = 1;
            label_16:
            GameApp[] val_7 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            if(val_19 < val_7.Length)
            {
                goto label_30;
            }
            
            val_17 = twelvegigs.plugins.InstalledAppsPlugin.GetInstalledApps(packagesNames:  val_3.ToArray());
            val_20 = 0;
            goto label_34;
            label_50:
            if((val_17.ContainsKey(key:  twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[0])) != false)
            {
                    twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[0] = val_17.Item[twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck[0]];
            }
            
            val_20 = 1;
            label_34:
            GameApp[] val_16 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            if(val_20 < val_16.Length)
            {
                goto label_50;
            }
        
        }
        private static System.Collections.Generic.Dictionary<string, bool> GetInstalledApps(string[] packagesNames)
        {
            var val_10;
            var val_11;
            var val_12;
            System.Collections.Generic.Dictionary<System.String, System.Boolean> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Boolean>();
            val_10 = null;
            val_10 = null;
            object[] val_2 = new object[1];
            val_2[0] = packagesNames;
            if(val_3.m_stringLength >= 1)
            {
                    do
            {
                if(((twelvegigs.plugins.InstalledAppsPlugin.plugin.Call<System.String>(methodName:  "checkInstalledApps", args:  val_2).Chars[0]) & 65535) == '0')
            {
                    val_11 = 0;
            }
            else
            {
                    val_11 = 1;
            }
            
                new System.Collections.Generic.List<System.Boolean>().Add(item:  true);
                val_12 = 0 + 1;
            }
            while(val_12 < val_3.m_stringLength);
            
            }
            
            int val_10 = packagesNames.Length;
            if(val_10 < 1)
            {
                    return val_1;
            }
            
            var val_11 = 0;
            val_10 = val_10 & 4294967295;
            do
            {
                val_12 = val_1.ContainsKey(key:  1152921505059157200);
                if(val_11 >= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_10 = val_10 + val_11;
                if(val_12 != false)
            {
                    val_1.set_Item(key:  1152921505059157200, value:  ((((packagesNames.Length & 4294967295) + 0) + 32) != 0) ? 1 : 0);
            }
            else
            {
                    val_1.Add(key:  1152921505059157200, value:  ((((packagesNames.Length & 4294967295) + 0) + 32) != 0) ? 1 : 0);
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < (packagesNames.Length << ));
            
            return val_1;
        }
        public static bool IsInstalled(string packageToCheck)
        {
            var val_7;
            var val_8;
            val_7 = 0;
            if((System.String.IsNullOrEmpty(value:  packageToCheck)) == true)
            {
                    return (bool)val_7;
            }
            
            val_8 = null;
            val_8 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.initialized != false)
            {
                    string[] val_2 = new string[1];
                val_2[0] = packageToCheck;
                bool val_4 = false;
                if((twelvegigs.plugins.InstalledAppsPlugin.GetInstalledApps(packagesNames:  val_2).TryGetValue(key:  packageToCheck, value: out  val_4)) != false)
            {
                    var val_6 = (val_4 != 0) ? 1 : 0;
                return (bool)val_7;
            }
            
            }
            
            val_7 = 0;
            return (bool)val_7;
        }
        public static void OpenApp(string package, string referrerMarket)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.plugin == null)
            {
                    twelvegigs.plugins.InstalledAppsPlugin.Init();
                val_2 = null;
            }
            
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = package;
            if(referrerMarket != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = referrerMarket;
            twelvegigs.plugins.InstalledAppsPlugin.plugin.Call(methodName:  "openApp", args:  val_1);
        }
        public static string[] defaultPackagesToUse()
        {
            null = null;
            return (System.String[])twelvegigs.plugins.InstalledAppsPlugin.availablePackagesAndroid;
        }
        public InstalledAppsPlugin()
        {
        
        }
        private static InstalledAppsPlugin()
        {
            int val_4;
            int val_5;
            twelvegigs.plugins.InstalledAppsPlugin.lastResponse = "";
            twelvegigs.plugins.InstalledAppsPlugin.initialized = false;
            twelvegigs.plugins.InstalledAppsPlugin.fetching = false;
            twelvegigs.plugins.InstalledAppsPlugin.fetched = false;
            twelvegigs.plugins.InstalledAppsPlugin.plugin = 0;
            twelvegigs.plugins.InstalledAppsPlugin.availablePackagesAndroid = new string[0];
            string[] val_2 = new string[10];
            val_4 = val_2.Length;
            val_2[0] = "com.superluckycasino.doubleup.slots.vegas.kindle.free";
            val_4 = val_2.Length;
            val_2[1] = "com.slotsfavorites.slots.kindle";
            val_4 = val_2.Length;
            val_2[2] = "com.twelvegigs.heaven.bingo.kindle";
            val_4 = val_2.Length;
            val_2[3] = "com.topfreegames.solitaire";
            val_4 = val_2.Length;
            val_2[4] = "com.superluckycasino.nolimit.slots.vegas.kindle.free";
            val_4 = val_2.Length;
            val_2[5] = "com.twelvegigs.heaven.vpoker.kindle";
            val_4 = val_2.Length;
            val_2[6] = "com.genina.android.blackjack.view";
            val_4 = val_2.Length;
            val_2[7] = "com.obamaslots.slots.kindle";
            val_4 = val_2.Length;
            val_2[8] = "com.shakespeare.slots.kindle";
            val_4 = val_2.Length;
            val_2[9] = "com.slotsfairytale.slots.kindle";
            twelvegigs.plugins.InstalledAppsPlugin.availablePackagesKindle = val_2;
            string[] val_3 = new string[10];
            val_5 = val_3.Length;
            val_3[0] = "1050745469";
            val_5 = val_3.Length;
            val_3[1] = "1071897064";
            val_5 = val_3.Length;
            val_3[2] = "836865209";
            val_5 = val_3.Length;
            val_3[3] = "950325630";
            val_5 = val_3.Length;
            val_3[4] = "677489316";
            val_5 = val_3.Length;
            val_3[5] = "485761300";
            val_5 = val_3.Length;
            val_3[6] = "544933682";
            val_5 = val_3.Length;
            val_3[7] = "799157423";
            val_5 = val_3.Length;
            val_3[8] = "594736876";
            val_5 = val_3.Length;
            val_3[9] = "514165346";
            twelvegigs.plugins.InstalledAppsPlugin.availablePackagesIOS = val_3;
        }
    
    }

}
