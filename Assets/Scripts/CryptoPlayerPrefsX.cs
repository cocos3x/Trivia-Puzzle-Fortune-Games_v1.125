using UnityEngine;
public class CryptoPlayerPrefsX
{
    // Fields
    private static int endianDiff1;
    private static int endianDiff2;
    private static int idx;
    private static byte[] byteBlock;
    
    // Methods
    public static bool SetBool(string name, bool value)
    {
        value = value;
        CPlayerPrefs.SetInt(key:  name, val:  value);
        return true;
    }
    public static bool GetBool(string name)
    {
        return (bool)((CPlayerPrefs.GetInt(key:  name)) == 1) ? 1 : 0;
    }
    public static bool GetBool(string name, bool defaultValue)
    {
        if((CPlayerPrefs.HasKey(key:  name)) == false)
        {
                return (bool)defaultValue;
        }
        
        return CryptoPlayerPrefsX.GetBool(name:  name);
    }
    public static bool SetVector2(string key, UnityEngine.Vector2 vector)
    {
        float[] val_1 = new float[2];
        val_1[0] = vector.x;
        val_1[0] = vector.y;
        return CryptoPlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    private static UnityEngine.Vector2 GetVector2(string key)
    {
        System.Single[] val_1 = CryptoPlayerPrefsX.GetFloatArray(key:  key);
        if(val_1.Length > 1)
        {
                UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  val_1[0], y:  val_1[0]);
            return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        }
        
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
        return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }
    public static UnityEngine.Vector2 GetVector2(string key, UnityEngine.Vector2 defaultValue)
    {
        float val_3;
        float val_4;
        val_3 = defaultValue.y;
        val_4 = defaultValue.x;
        if((CPlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Vector2() {x = val_4, y = val_3};
        }
        
        UnityEngine.Vector2 val_2 = CryptoPlayerPrefsX.GetVector2(key:  key);
        val_4 = val_2.x;
        val_3 = val_2.y;
        return new UnityEngine.Vector2() {x = val_4, y = val_3};
    }
    public static bool SetVector3(string key, UnityEngine.Vector3 vector)
    {
        float[] val_1 = new float[3];
        val_1[0] = vector.x;
        val_1[0] = vector.y;
        val_1[1] = vector.z;
        return CryptoPlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Vector3 GetVector3(string key)
    {
        System.Single[] val_1 = CryptoPlayerPrefsX.GetFloatArray(key:  key);
        if(val_1.Length > 2)
        {
                UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  val_1[0], y:  val_1[0], z:  val_1[1]);
            return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static UnityEngine.Vector3 GetVector3(string key, UnityEngine.Vector3 defaultValue)
    {
        float val_3;
        float val_4;
        float val_5;
        val_3 = defaultValue.z;
        val_4 = defaultValue.y;
        val_5 = defaultValue.x;
        if((CPlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Vector3() {x = val_5, y = val_4, z = val_3};
        }
        
        UnityEngine.Vector3 val_2 = CryptoPlayerPrefsX.GetVector3(key:  key);
        val_5 = val_2.x;
        val_4 = val_2.y;
        val_3 = val_2.z;
        return new UnityEngine.Vector3() {x = val_5, y = val_4, z = val_3};
    }
    public static bool SetQuaternion(string key, UnityEngine.Quaternion vector)
    {
        float[] val_1 = new float[4];
        val_1[0] = vector.x;
        val_1[0] = vector.y;
        val_1[1] = vector.z;
        val_1[1] = vector.w;
        return CryptoPlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Quaternion GetQuaternion(string key)
    {
        System.Single[] val_1 = CryptoPlayerPrefsX.GetFloatArray(key:  key);
        if(val_1.Length > 3)
        {
                UnityEngine.Quaternion val_2 = new UnityEngine.Quaternion(x:  val_1[0], y:  val_1[0], z:  val_1[1], w:  val_1[1]);
            return new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
        }
        
        UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.identity;
        return new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
    }
    public static UnityEngine.Quaternion GetQuaternion(string key, UnityEngine.Quaternion defaultValue)
    {
        float val_3;
        float val_4;
        float val_5;
        float val_6;
        val_3 = defaultValue.w;
        val_4 = defaultValue.z;
        val_5 = defaultValue.y;
        val_6 = defaultValue.x;
        if((CPlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Quaternion() {x = val_6, y = val_5, z = val_4, w = val_3};
        }
        
        UnityEngine.Quaternion val_2 = CryptoPlayerPrefsX.GetQuaternion(key:  key);
        val_6 = val_2.x;
        val_5 = val_2.y;
        val_4 = val_2.z;
        val_3 = val_2.w;
        return new UnityEngine.Quaternion() {x = val_6, y = val_5, z = val_4, w = val_3};
    }
    public static bool SetColor(string key, UnityEngine.Color color)
    {
        float[] val_1 = new float[4];
        val_1[0] = color.r;
        val_1[0] = color.g;
        val_1[1] = color.b;
        val_1[1] = color.a;
        return CryptoPlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Color GetColor(string key)
    {
        float val_3;
        float val_4;
        System.Single[] val_1 = CryptoPlayerPrefsX.GetFloatArray(key:  key);
        if(val_1.Length > 3)
        {
                float val_3 = val_1[0];
            val_3 = val_1[0];
            float val_4 = val_1[1];
            val_4 = val_1[1];
        }
        else
        {
                UnityEngine.Color val_2;
            val_3 = 0f;
            val_4 = 0f;
        }
        
        val_2 = new UnityEngine.Color(r:  0f, g:  val_3, b:  0f, a:  val_4);
        return new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
    }
    public static UnityEngine.Color GetColor(string key, UnityEngine.Color defaultValue)
    {
        float val_3;
        float val_4;
        float val_5;
        float val_6;
        val_3 = defaultValue.a;
        val_4 = defaultValue.b;
        val_5 = defaultValue.g;
        val_6 = defaultValue.r;
        if((CPlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Color() {r = val_6, g = val_5, b = val_4, a = val_3};
        }
        
        UnityEngine.Color val_2 = CryptoPlayerPrefsX.GetColor(key:  key);
        val_6 = val_2.r;
        val_5 = val_2.g;
        val_4 = val_2.b;
        val_3 = val_2.a;
        return new UnityEngine.Color() {r = val_6, g = val_5, b = val_4, a = val_3};
    }
    public static bool SetBoolArray(string key, bool[] boolArray)
    {
        System.Array val_11;
        string val_12;
        string val_14;
        val_12 = key;
        int val_11 = boolArray.Length;
        if(val_11 != 0)
        {
                int val_1 = val_11 + 7;
            val_11 = val_11 + 14;
            var val_2 = (val_1 < 0) ? (val_11) : (val_1);
            val_2 = val_2 >> 3;
            var val_3 = val_2 + 5;
            byte[] val_4 = new byte[0];
            val_11 = val_4;
            val_11[0] = System.Convert.ToByte(value:  2);
            var val_12 = 0;
            val_12 = val_12 + 1;
        }
        else
        {
                val_12 = "The bool array cannot have 0 entries when setting " + val_12;
            UnityEngine.Debug.LogError(message:  val_12);
            val_14 = 0;
            return (bool)CryptoPlayerPrefsX.SaveBytes(key:  val_14 = val_12, bytes:  val_4);
        }
        
        new System.Collections.BitArray(values:  boolArray).CopyTo(array:  val_4, index:  5);
        CryptoPlayerPrefsX.Initialize();
        CryptoPlayerPrefsX.ConvertInt32ToBytes(i:  boolArray.Length, bytes:  val_4);
        return (bool)CryptoPlayerPrefsX.SaveBytes(key:  val_14, bytes:  val_4);
    }
    public static bool[] GetBoolArray(string key)
    {
        string val_13;
        string val_15;
        string val_16;
        val_13 = key;
        if((CPlayerPrefs.HasKey(key:  val_13)) == false)
        {
            goto label_3;
        }
        
        System.Byte[] val_3 = System.Convert.FromBase64String(s:  CPlayerPrefs.GetString(key:  val_13));
        if(val_3.Length <= 5)
        {
            goto label_9;
        }
        
        if(val_3[0] != 2)
        {
            goto label_10;
        }
        
        CryptoPlayerPrefsX.Initialize();
        int val_4 = val_3.Length - 5;
        byte[] val_5 = new byte[0];
        System.Array.Copy(sourceArray:  val_3, sourceIndex:  5, destinationArray:  val_5, destinationIndex:  0, length:  val_5.Length);
        System.Collections.BitArray val_6 = new System.Collections.BitArray(bytes:  val_5);
        val_6.Length = CryptoPlayerPrefsX.ConvertBytesToInt32(bytes:  val_3);
        var val_15 = 0;
        val_15 = val_15 + 1;
        goto label_16;
        label_9:
        val_15 = val_13;
        val_16 = "Corrupt preference file for ";
        goto label_17;
        label_10:
        val_16 = val_13;
        val_15 = " is not a boolean array";
        label_17:
        val_13 = val_16 + val_15;
        UnityEngine.Debug.LogError(message:  val_13);
        label_3:
        bool[] val_9 = new bool[0];
        label_16:
        int val_11 = val_6.Count;
        bool[] val_12 = new bool[0];
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_6.CopyTo(array:  val_12, index:  0);
        return (System.Boolean[])val_12;
    }
    public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetBoolArray(key:  key);
        }
        
        bool[] val_2 = new bool[0];
        if(defaultSize < 1)
        {
                return (System.Boolean[])val_2;
        }
        
        var val_4 = 0;
        do
        {
            mem2[0] = defaultValue;
            val_4 = val_4 + 1;
        }
        while(val_4 < (long)defaultSize);
        
        return (System.Boolean[])val_2;
    }
    public static bool SetStringArray(string key, string[] stringArray)
    {
        UnityEngine.PlayerPrefs.SetString(key:  key, value:  MiniJSON.Json.Serialize(obj:  stringArray));
        return true;
    }
    public static string[] GetStringArray(string key)
    {
        string val_7;
        var val_8;
        var val_11;
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return (System.String[])new string[0];
        }
        
        System.Collections.Generic.List<System.String> val_2 = null;
        val_11 = val_2;
        val_2 = new System.Collections.Generic.List<System.String>();
        object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  key, defaultValue:  "[]"));
        return (System.String[])new string[0];
        label_8:
        if(val_8.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_7 == 0)
        {
            goto label_8;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  val_7);
        goto label_8;
        label_5:
        val_8.Dispose();
        T[] val_10 = val_2.ToArray();
        return (System.String[])new string[0];
    }
    public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetStringArray(key:  key);
        }
        
        string[] val_2 = new string[0];
        if(defaultSize < 1)
        {
                return (System.String[])val_2;
        }
        
        var val_3 = 0;
        do
        {
            mem2[0] = defaultValue;
            val_3 = val_3 + 1;
        }
        while(val_3 < (long)defaultSize);
        
        return (System.String[])val_2;
    }
    public static bool SetIntArray(string key, int[] intArray)
    {
        return CryptoPlayerPrefsX.SetValue<System.Int32[]>(key:  key, array:  intArray, arrayType:  1, vectorNumber:  1, convert:  new System.Action<System.Int32[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromInt(int[] array, byte[] bytes, int i)));
    }
    public static bool SetFloatArray(string key, float[] floatArray)
    {
        return CryptoPlayerPrefsX.SetValue<System.Single[]>(key:  key, array:  floatArray, arrayType:  0, vectorNumber:  1, convert:  new System.Action<System.Single[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromFloat(float[] array, byte[] bytes, int i)));
    }
    public static bool SetVector2Array(string key, UnityEngine.Vector2[] vector2Array)
    {
        return CryptoPlayerPrefsX.SetValue<UnityEngine.Vector2[]>(key:  key, array:  vector2Array, arrayType:  4, vectorNumber:  2, convert:  new System.Action<UnityEngine.Vector2[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromVector2(UnityEngine.Vector2[] array, byte[] bytes, int i)));
    }
    public static bool SetVector3Array(string key, UnityEngine.Vector3[] vector3Array)
    {
        return CryptoPlayerPrefsX.SetValue<UnityEngine.Vector3[]>(key:  key, array:  vector3Array, arrayType:  5, vectorNumber:  3, convert:  new System.Action<UnityEngine.Vector3[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromVector3(UnityEngine.Vector3[] array, byte[] bytes, int i)));
    }
    public static bool SetQuaternionArray(string key, UnityEngine.Quaternion[] quaternionArray)
    {
        return CryptoPlayerPrefsX.SetValue<UnityEngine.Quaternion[]>(key:  key, array:  quaternionArray, arrayType:  6, vectorNumber:  4, convert:  new System.Action<UnityEngine.Quaternion[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromQuaternion(UnityEngine.Quaternion[] array, byte[] bytes, int i)));
    }
    public static bool SetColorArray(string key, UnityEngine.Color[] colorArray)
    {
        return CryptoPlayerPrefsX.SetValue<UnityEngine.Color[]>(key:  key, array:  colorArray, arrayType:  7, vectorNumber:  4, convert:  new System.Action<UnityEngine.Color[], System.Byte[], System.Int32>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertFromColor(UnityEngine.Color[] array, byte[] bytes, int i)));
    }
    public static int[] GetIntArray(string key)
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<System.Int32>>(key:  key, list:  val_1, arrayType:  1, vectorNumber:  1, convert:  new System.Action<System.Collections.Generic.List<System.Int32>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToInt(System.Collections.Generic.List<int> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetIntArray(key:  key);
        }
        
        int[] val_2 = new int[0];
        if(defaultSize < 1)
        {
                return (System.Int32[])val_2;
        }
        
        var val_3 = 0;
        do
        {
            mem2[0] = defaultValue;
            val_3 = val_3 + 1;
        }
        while(val_3 < (long)defaultSize);
        
        return (System.Int32[])val_2;
    }
    public static float[] GetFloatArray(string key)
    {
        System.Collections.Generic.List<System.Single> val_1 = new System.Collections.Generic.List<System.Single>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<System.Single>>(key:  key, list:  val_1, arrayType:  0, vectorNumber:  1, convert:  new System.Action<System.Collections.Generic.List<System.Single>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToFloat(System.Collections.Generic.List<float> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetFloatArray(key:  key);
        }
        
        float[] val_2 = new float[0];
        if(defaultSize < 1)
        {
                return (System.Single[])val_2;
        }
        
        var val_3 = 0;
        do
        {
            mem2[0] = defaultValue;
            val_3 = val_3 + 1;
        }
        while(val_3 < (long)defaultSize);
        
        return (System.Single[])val_2;
    }
    public static UnityEngine.Vector2[] GetVector2Array(string key)
    {
        System.Collections.Generic.List<UnityEngine.Vector2> val_1 = new System.Collections.Generic.List<UnityEngine.Vector2>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Vector2>>(key:  key, list:  val_1, arrayType:  4, vectorNumber:  2, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Vector2>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToVector2(System.Collections.Generic.List<UnityEngine.Vector2> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Vector2[] GetVector2Array(string key, UnityEngine.Vector2 defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetVector2Array(key:  key);
        }
        
        UnityEngine.Vector2[] val_2 = new UnityEngine.Vector2[0];
        if(defaultSize < 1)
        {
                return val_2;
        }
        
        var val_3 = 0;
        do
        {
            val_3 = val_3 + 1;
            mem2[0] = defaultValue.x;
            mem2[0] = defaultValue.y;
        }
        while(val_3 < (long)defaultSize);
        
        return val_2;
    }
    public static UnityEngine.Vector3[] GetVector3Array(string key)
    {
        System.Collections.Generic.List<UnityEngine.Vector3> val_1 = new System.Collections.Generic.List<UnityEngine.Vector3>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Vector3>>(key:  key, list:  val_1, arrayType:  5, vectorNumber:  3, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Vector3>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToVector3(System.Collections.Generic.List<UnityEngine.Vector3> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Vector3[] GetVector3Array(string key, UnityEngine.Vector3 defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetVector3Array(key:  key);
        }
        
        UnityEngine.Vector3[] val_2 = new UnityEngine.Vector3[0];
        if(defaultSize < 1)
        {
                return val_2;
        }
        
        var val_3 = 0;
        do
        {
            val_3 = val_3 + 1;
            mem2[0] = defaultValue.x;
            mem2[0] = defaultValue.y;
            mem2[0] = defaultValue.z;
        }
        while(val_3 < (long)defaultSize);
        
        return val_2;
    }
    public static UnityEngine.Quaternion[] GetQuaternionArray(string key)
    {
        System.Collections.Generic.List<UnityEngine.Quaternion> val_1 = new System.Collections.Generic.List<UnityEngine.Quaternion>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Quaternion>>(key:  key, list:  val_1, arrayType:  6, vectorNumber:  4, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Quaternion>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToQuaternion(System.Collections.Generic.List<UnityEngine.Quaternion> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Quaternion[] GetQuaternionArray(string key, UnityEngine.Quaternion defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetQuaternionArray(key:  key);
        }
        
        UnityEngine.Quaternion[] val_2 = new UnityEngine.Quaternion[0];
        if(defaultSize < 1)
        {
                return val_2;
        }
        
        var val_3 = 0;
        do
        {
            val_3 = val_3 + 1;
            mem2[0] = defaultValue.x;
            mem2[0] = defaultValue.y;
            mem2[0] = defaultValue.z;
            mem2[0] = defaultValue.w;
        }
        while(val_3 < (long)defaultSize);
        
        return val_2;
    }
    public static UnityEngine.Color[] GetColorArray(string key)
    {
        System.Collections.Generic.List<UnityEngine.Color> val_1 = new System.Collections.Generic.List<UnityEngine.Color>();
        CryptoPlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Color>>(key:  key, list:  val_1, arrayType:  7, vectorNumber:  4, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Color>, System.Byte[]>(object:  0, method:  static System.Void CryptoPlayerPrefsX::ConvertToColor(System.Collections.Generic.List<UnityEngine.Color> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Color[] GetColorArray(string key, UnityEngine.Color defaultValue, int defaultSize)
    {
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                return CryptoPlayerPrefsX.GetColorArray(key:  key);
        }
        
        UnityEngine.Color[] val_2 = new UnityEngine.Color[0];
        if(defaultSize < 1)
        {
                return val_2;
        }
        
        var val_3 = 0;
        do
        {
            val_3 = val_3 + 1;
            mem2[0] = defaultValue.r;
            mem2[0] = defaultValue.g;
            mem2[0] = defaultValue.b;
            mem2[0] = defaultValue.a;
        }
        while(val_3 < (long)defaultSize);
        
        return val_2;
    }
    private static bool SetValue<T>(string key, T array, CryptoPlayerPrefsX.ArrayType arrayType, int vectorNumber, System.Action<T, byte[], int> convert)
    {
        ArrayType val_11;
        string val_12;
        string val_15;
        val_11 = arrayType;
        val_12 = key;
        var val_14 = 0;
        val_14 = val_14 + 1;
        if(array.Count != 0)
        {
                var val_15 = 0;
            val_15 = val_15 + 1;
        }
        else
        {
                val_12 = "The " + null.ToString() + " array cannot have 0 entries when setting " + val_12;
            UnityEngine.Debug.LogError(message:  val_12);
            val_15 = 0;
            return (bool)CryptoPlayerPrefsX.SaveBytes(key:  val_15 = val_12, bytes:  byte[] val_8 = new byte[1]);
        }
        
        int val_7 = vectorNumber * array.Count;
        val_8[0] = System.Convert.ToByte(value:  val_11);
        CryptoPlayerPrefsX.Initialize();
        val_11 = 0;
        goto label_18;
        label_24:
        val_11 = 1;
        label_18:
        var val_16 = 0;
        val_16 = val_16 + 1;
        if(val_11 < array.Count)
        {
            goto label_24;
        }
        
        return (bool)CryptoPlayerPrefsX.SaveBytes(key:  val_15, bytes:  val_8);
    }
    private static void ConvertFromInt(int[] array, byte[] bytes, int i)
    {
        CryptoPlayerPrefsX.ConvertInt32ToBytes(i:  array[i << 2], bytes:  bytes);
    }
    private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
    {
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[i << 2], bytes:  bytes);
    }
    private static void ConvertFromVector2(UnityEngine.Vector2[] array, byte[] bytes, int i)
    {
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[i], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[(long)i], bytes:  bytes);
    }
    private static void ConvertFromVector3(UnityEngine.Vector3[] array, byte[] bytes, int i)
    {
        var val_1 = 12;
        val_1 = array + (i * val_1);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  (i * 12) + array + 32, bytes:  bytes);
        var val_2 = 12;
        val_2 = array + ((long)i * val_2);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  ((long)(int)(i) * 12) + array + 36, bytes:  bytes);
        var val_3 = 12;
        val_3 = array + ((long)i * val_3);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  ((long)(int)(i) * 12) + array + 40, bytes:  bytes);
    }
    private static void ConvertFromQuaternion(UnityEngine.Quaternion[] array, byte[] bytes, int i)
    {
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[i << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
    }
    private static void ConvertFromColor(UnityEngine.Color[] array, byte[] bytes, int i)
    {
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[i << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        CryptoPlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
    }
    private static void GetValue<T>(string key, T list, CryptoPlayerPrefsX.ArrayType arrayType, int vectorNumber, System.Action<T, byte[]> convert)
    {
        int val_10 = vectorNumber;
        if((CPlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        val_10 = val_10 << 2;
        int val_4 = val_3.Length - 1;
        val_4 = val_4 - ((val_4 / val_10) * val_10);
        if(val_4 != 0)
        {
                UnityEngine.Debug.LogError(message:  "Corrupt preference file for " + key);
            return;
        }
        
        if((System.Convert.FromBase64String(s:  CPlayerPrefs.GetString(key:  key))[0]) == arrayType)
        {
                CryptoPlayerPrefsX.Initialize();
            int val_12 = val_3.Length;
            val_12 = val_12 - 1;
            int val_7 = val_12 / val_10;
            if(val_7 < 1)
        {
                return;
        }
        
            do
        {
            val_7 = val_7 - 1;
        }
        while(val_7 != 1);
        
            return;
        }
        
        __RuntimeMethodHiddenParam = key + " is not a " + null.ToString() + " array";
        UnityEngine.Debug.LogError(message:  __RuntimeMethodHiddenParam);
    }
    private static void ConvertToInt(System.Collections.Generic.List<int> list, byte[] bytes)
    {
        list.Add(item:  CryptoPlayerPrefsX.ConvertBytesToInt32(bytes:  bytes));
    }
    private static void ConvertToFloat(System.Collections.Generic.List<float> list, byte[] bytes)
    {
        list.Add(item:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
    }
    private static void ConvertToVector2(System.Collections.Generic.List<UnityEngine.Vector2> list, byte[] bytes)
    {
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
    }
    private static void ConvertToVector3(System.Collections.Generic.List<UnityEngine.Vector3> list, byte[] bytes)
    {
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), z:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    private static void ConvertToQuaternion(System.Collections.Generic.List<UnityEngine.Quaternion> list, byte[] bytes)
    {
        UnityEngine.Quaternion val_5 = new UnityEngine.Quaternion(x:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), z:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), w:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w});
    }
    private static void ConvertToColor(System.Collections.Generic.List<UnityEngine.Color> list, byte[] bytes)
    {
        UnityEngine.Color val_5 = new UnityEngine.Color(r:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), g:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), b:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), a:  CryptoPlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
    }
    public static void ShowArrayType(string key)
    {
        string val_5 = key;
        if(val_2.Length == 0)
        {
                return;
        }
        
        val_5 = val_5 + " is a " + System.Convert.FromBase64String(s:  CPlayerPrefs.GetString(key:  val_5 = key))[0].ToString()(System.Convert.FromBase64String(s:  CPlayerPrefs.GetString(key:  val_5 = key))[0].ToString()) + " array";
        UnityEngine.Debug.Log(message:  val_5);
    }
    private static void Initialize()
    {
        var val_3 = null;
        bool val_3 = System.BitConverter.IsLittleEndian;
        val_3 = val_3 ^ 1;
        CryptoPlayerPrefsX.endianDiff1 = (val_3 == false) ? 3 : 0;
        CryptoPlayerPrefsX.endianDiff2 = val_3;
        if(CryptoPlayerPrefsX.byteBlock == null)
        {
                CryptoPlayerPrefsX.byteBlock = new byte[4];
        }
        
        CryptoPlayerPrefsX.idx = 1;
    }
    private static bool SaveBytes(string key, byte[] bytes)
    {
        CPlayerPrefs.SetString(key:  key, val:  System.Convert.ToBase64String(inArray:  bytes));
        return true;
    }
    private static void ConvertFloatToBytes(float f, byte[] bytes)
    {
        CryptoPlayerPrefsX.byteBlock = System.BitConverter.GetBytes(value:  f);
        CryptoPlayerPrefsX.ConvertTo4Bytes(bytes:  bytes);
    }
    private static float ConvertBytesToFloat(byte[] bytes)
    {
        CryptoPlayerPrefsX.ConvertFrom4Bytes(bytes:  bytes);
        return System.BitConverter.ToSingle(value:  CryptoPlayerPrefsX.byteBlock, startIndex:  0);
    }
    private static void ConvertInt32ToBytes(int i, byte[] bytes)
    {
        CryptoPlayerPrefsX.byteBlock = System.BitConverter.GetBytes(value:  i);
        CryptoPlayerPrefsX.ConvertTo4Bytes(bytes:  bytes);
    }
    private static int ConvertBytesToInt32(byte[] bytes)
    {
        CryptoPlayerPrefsX.ConvertFrom4Bytes(bytes:  bytes);
        return System.BitConverter.ToInt32(value:  CryptoPlayerPrefsX.byteBlock, startIndex:  0);
    }
    private static void ConvertTo4Bytes(byte[] bytes)
    {
        System.Byte[] val_1 = CryptoPlayerPrefsX.byteBlock;
        val_1 = val_1 + CryptoPlayerPrefsX.endianDiff1;
        bytes[CryptoPlayerPrefsX.idx] = (CryptoPlayerPrefsX.byteBlock + CryptoPlayerPrefsX.endianDiff1) + 32;
        System.Byte[] val_4 = CryptoPlayerPrefsX.byteBlock;
        int val_2 = CryptoPlayerPrefsX.endianDiff2;
        val_2 = val_2 + 1;
        int val_3 = CryptoPlayerPrefsX.idx;
        val_3 = val_3 + 1;
        val_4 = val_4 + (val_2 << );
        bytes[val_3] = (CryptoPlayerPrefsX.byteBlock + ((CryptoPlayerPrefsX.endianDiff2 + 1)) << ) + 32;
        System.Byte[] val_7 = CryptoPlayerPrefsX.byteBlock;
        int val_5 = CryptoPlayerPrefsX.endianDiff2;
        val_5 = 2 - val_5;
        int val_6 = CryptoPlayerPrefsX.idx;
        val_6 = val_6 + 2;
        val_7 = val_7 + (val_5 << );
        bytes[val_6] = (CryptoPlayerPrefsX.byteBlock + ((2 - CryptoPlayerPrefsX.endianDiff2)) << ) + 32;
        System.Byte[] val_10 = CryptoPlayerPrefsX.byteBlock;
        int val_8 = CryptoPlayerPrefsX.endianDiff1;
        val_8 = 3 - val_8;
        int val_9 = CryptoPlayerPrefsX.idx;
        val_9 = val_9 + 3;
        val_10 = val_10 + (val_8 << );
        bytes[val_9] = (CryptoPlayerPrefsX.byteBlock + ((3 - CryptoPlayerPrefsX.endianDiff1)) << ) + 32;
        int val_11 = CryptoPlayerPrefsX.idx;
        val_11 = val_11 + 4;
        CryptoPlayerPrefsX.idx = val_11;
    }
    private static void ConvertFrom4Bytes(byte[] bytes)
    {
        System.Byte[] val_2 = CryptoPlayerPrefsX.byteBlock;
        val_2 = val_2 + CryptoPlayerPrefsX.endianDiff1;
        (CryptoPlayerPrefsX.byteBlock + CryptoPlayerPrefsX.endianDiff1).__unknownFiledOffset_20 = bytes[CryptoPlayerPrefsX.idx];
        int val_3 = CryptoPlayerPrefsX.idx;
        val_3 = val_3 + 1;
        System.Byte[] val_6 = CryptoPlayerPrefsX.byteBlock;
        int val_4 = CryptoPlayerPrefsX.endianDiff2;
        val_4 = val_4 + 1;
        val_6 = val_6 + (val_4 << );
        (CryptoPlayerPrefsX.byteBlock + ((CryptoPlayerPrefsX.endianDiff2 + 1)) << ).__unknownFiledOffset_20 = bytes[val_3];
        int val_7 = CryptoPlayerPrefsX.idx;
        val_7 = val_7 + 2;
        System.Byte[] val_10 = CryptoPlayerPrefsX.byteBlock;
        int val_8 = CryptoPlayerPrefsX.endianDiff2;
        val_8 = 2 - val_8;
        val_10 = val_10 + (val_8 << );
        (CryptoPlayerPrefsX.byteBlock + ((2 - CryptoPlayerPrefsX.endianDiff2)) << ).__unknownFiledOffset_20 = bytes[val_7];
        int val_11 = CryptoPlayerPrefsX.idx;
        val_11 = val_11 + 3;
        System.Byte[] val_14 = CryptoPlayerPrefsX.byteBlock;
        int val_12 = CryptoPlayerPrefsX.endianDiff1;
        val_12 = 3 - val_12;
        val_14 = val_14 + (val_12 << );
        (CryptoPlayerPrefsX.byteBlock + ((3 - CryptoPlayerPrefsX.endianDiff1)) << ).__unknownFiledOffset_20 = bytes[val_11];
        int val_15 = CryptoPlayerPrefsX.idx;
        val_15 = val_15 + 4;
        CryptoPlayerPrefsX.idx = val_15;
    }
    public CryptoPlayerPrefsX()
    {
    
    }

}
