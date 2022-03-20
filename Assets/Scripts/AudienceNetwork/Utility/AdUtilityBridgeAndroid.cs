using UnityEngine;

namespace AudienceNetwork.Utility
{
    internal class AdUtilityBridgeAndroid : AdUtilityBridge
    {
        // Methods
        private T GetPropertyOfDisplayMetrics<T>(string property)
        {
            var val_6;
            var val_7;
            var val_8;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaObject val_5 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            goto __RuntimeMethodHiddenParam + 48;
        }
        private double Density()
        {
            return (double)(double)this.GetPropertyOfDisplayMetrics<System.Single>(property:  "density");
        }
        public override double DeviceWidth()
        {
            return (double)(double)this.GetPropertyOfDisplayMetrics<System.Int32>(property:  "widthPixels");
        }
        public override double DeviceHeight()
        {
            return (double)(double)this.GetPropertyOfDisplayMetrics<System.Int32>(property:  "heightPixels");
        }
        public override double Width()
        {
            int val_1 = UnityEngine.Screen.width;
            goto typeof(AudienceNetwork.Utility.AdUtilityBridgeAndroid).__il2cppRuntimeField_210;
        }
        public override double Height()
        {
            int val_1 = UnityEngine.Screen.height;
            goto typeof(AudienceNetwork.Utility.AdUtilityBridgeAndroid).__il2cppRuntimeField_210;
        }
        public override double Convert(double deviceSize)
        {
            double val_1 = this.Density();
            val_1 = deviceSize / val_1;
            return (double)val_1;
        }
        public override void Prepare()
        {
            var val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            new UnityEngine.AndroidJavaClass(className:  "android.os.Looper").CallStatic(methodName:  "prepare", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public AdUtilityBridgeAndroid()
        {
            this = new System.Object();
        }
    
    }

}
