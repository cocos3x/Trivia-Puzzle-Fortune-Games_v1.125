using UnityEngine;

namespace twelvegigs.plugins
{
    public class IntentPlugin : MonoBehaviour
    {
        // Fields
        private static twelvegigs.plugins.IntentPlugin.Goal[] availableTask;
        public static GlobalGameNames.GameNames[] VIPEarlyUnlockGames;
        
        // Properties
        public static twelvegigs.plugins.IntentPlugin.Goal[] AvailableTask { get; }
        
        // Methods
        public static twelvegigs.plugins.IntentPlugin.Goal[] get_AvailableTask()
        {
            null = null;
            return (Goal[])twelvegigs.plugins.IntentPlugin.availableTask;
        }
        public static bool isTaskAvailable(twelvegigs.plugins.IntentPlugin.Goal goal)
        {
            var val_1;
            var val_2;
            val_1 = null;
            val_1 = null;
            if(twelvegigs.plugins.IntentPlugin.availableTask.Length < 1)
            {
                goto label_4;
            }
            
            var val_1 = 0;
            label_7:
            if((X11 + 32) == goal)
            {
                goto label_6;
            }
            
            val_1 = val_1 + 1;
            if(val_1 < twelvegigs.plugins.IntentPlugin.availableTask.Length)
            {
                goto label_7;
            }
            
            label_4:
            val_2 = 0;
            return (bool)val_2;
            label_6:
            val_2 = 1;
            return (bool)val_2;
        }
        public static void showCalendar(string machineName, string machineDisplayName)
        {
        
        }
        public static void showIntent(twelvegigs.plugins.IntentPlugin.Network network, string text = "", string filePath, System.Collections.Generic.Dictionary<string, object> intentParams)
        {
            var val_6;
            int val_7;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_5 = new object[3];
            val_7 = val_5.Length;
            val_5[0] = network.ToString().ToUpper();
            if(text != null)
            {
                    val_7 = val_5.Length;
            }
            
            val_5[1] = text;
            if(filePath != null)
            {
                    val_7 = val_5.Length;
            }
            
            val_5[2] = filePath;
            new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.IntentPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call(methodName:  "showIntent", args:  val_5);
        }
        public static bool isAppInstalledInDevice(twelvegigs.plugins.IntentPlugin.Network network)
        {
            var val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            if(network == 0)
            {
                    return new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.IntentPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<System.Boolean>(methodName:  "isTwitterInstalled", args:  new object[0]);
            }
            
            return false;
        }
        private static string defaultMachineName(string key)
        {
            var val_3;
            if((System.String.op_Equality(a:  key, b:  "RichardIII")) != false)
            {
                    val_3 = "Richard III";
                return (string)val_3;
            }
            
            if((System.String.op_Equality(a:  key, b:  "Maan")) == false)
            {
                    return System.Text.RegularExpressions.Regex.Replace(input:  key, pattern:  "(\\B[A-Z])", replacement:  " $1");
            }
            
            val_3 = "Much Ado About Nothing";
            return (string)val_3;
        }
        public static void mediaScanIntent(string filePath)
        {
            var val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_3 = new object[1];
            val_3[0] = filePath;
            new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.IntentPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call(methodName:  "mediaScanIntent", args:  val_3);
        }
        public IntentPlugin()
        {
        
        }
        private static IntentPlugin()
        {
            twelvegigs.plugins.IntentPlugin.availableTask = new Goal[1];
            GlobalGameNames.GameNames[] val_2 = new GlobalGameNames.GameNames[1];
            val_2[0] = 4;
            twelvegigs.plugins.IntentPlugin.VIPEarlyUnlockGames = val_2;
        }
    
    }

}
