using UnityEngine;
public class PlayerPrefsX
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
        UnityEngine.PlayerPrefs.SetInt(key:  name, value:  value);
        return true;
    }
    public static bool GetBool(string name)
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  name)) == 1) ? 1 : 0;
    }
    public static bool GetBool(string name, bool defaultValue)
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  name, defaultValue:  defaultValue)) == 1) ? 1 : 0;
    }
    public static long GetLong(string key, long defaultValue)
    {
        int val_5 = UnityEngine.PlayerPrefs.GetInt(key:  key + "_highBits", defaultValue:  defaultValue >> 32);
        return (long)UnityEngine.PlayerPrefs.GetInt(key:  key + "_lowBits", defaultValue:  defaultValue);
    }
    public static long GetLong(string key)
    {
        int val_4 = UnityEngine.PlayerPrefs.GetInt(key:  key + "_highBits");
        return (long)UnityEngine.PlayerPrefs.GetInt(key:  key + "_lowBits");
    }
    private static void SplitLong(long input, out int lowBits, out int highBits)
    {
        lowBits = input;
        highBits = input >> 32;
    }
    public static void SetLong(string key, long value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  key + "_lowBits", value:  value);
        UnityEngine.PlayerPrefs.SetInt(key:  key + "_highBits", value:  value >> 32);
    }
    public static bool SetVector2(string key, UnityEngine.Vector2 vector)
    {
        float[] val_1 = new float[2];
        val_1[0] = vector.x;
        val_1[0] = vector.y;
        return PlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    private static UnityEngine.Vector2 GetVector2(string key)
    {
        System.Single[] val_1 = PlayerPrefsX.GetFloatArray(key:  key);
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
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Vector2() {x = val_4, y = val_3};
        }
        
        UnityEngine.Vector2 val_2 = PlayerPrefsX.GetVector2(key:  key);
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
        return PlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Vector3 GetVector3(string key)
    {
        System.Single[] val_1 = PlayerPrefsX.GetFloatArray(key:  key);
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
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Vector3() {x = val_5, y = val_4, z = val_3};
        }
        
        UnityEngine.Vector3 val_2 = PlayerPrefsX.GetVector3(key:  key);
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
        return PlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Quaternion GetQuaternion(string key)
    {
        System.Single[] val_1 = PlayerPrefsX.GetFloatArray(key:  key);
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
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Quaternion() {x = val_6, y = val_5, z = val_4, w = val_3};
        }
        
        UnityEngine.Quaternion val_2 = PlayerPrefsX.GetQuaternion(key:  key);
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
        return PlayerPrefsX.SetFloatArray(key:  key, floatArray:  val_1);
    }
    public static UnityEngine.Color GetColor(string key)
    {
        float val_3;
        float val_4;
        System.Single[] val_1 = PlayerPrefsX.GetFloatArray(key:  key);
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
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return new UnityEngine.Color() {r = val_6, g = val_5, b = val_4, a = val_3};
        }
        
        UnityEngine.Color val_2 = PlayerPrefsX.GetColor(key:  key);
        val_6 = val_2.r;
        val_5 = val_2.g;
        val_4 = val_2.b;
        val_3 = val_2.a;
        return new UnityEngine.Color() {r = val_6, g = val_5, b = val_4, a = val_3};
    }
    public static bool SetBoolArray(string key, bool[] boolArray)
    {
        int val_9 = boolArray.Length;
        int val_1 = val_9 + 7;
        val_9 = val_9 + 14;
        var val_2 = (val_1 < 0) ? (val_9) : (val_1);
        val_2 = val_2 >> 3;
        var val_3 = val_2 + 5;
        byte[] val_4 = new byte[0];
        val_4[0] = System.Convert.ToByte(value:  2);
        new System.Collections.BitArray(values:  boolArray).CopyTo(array:  val_4, index:  5);
        PlayerPrefsX.Initialize();
        PlayerPrefsX.ConvertInt32ToBytes(i:  boolArray.Length, bytes:  val_4);
        return (bool)PlayerPrefsX.SaveBytes(key:  key, bytes:  val_4);
    }
    private static System.Array CopyTo(System.Collections.BitArray bits, System.Array bytes, int index)
    {
        return 0;
    }
    private static byte getByte(System.Collections.BitArray array, int byteIndex)
    {
        var val_2 = (byteIndex < 0) ? (byteIndex + 3) : byteIndex;
        byteIndex = val_2 >> 2;
        bool val_3 = array.Item[byteIndex];
        var val_5 = 255;
        val_5 = val_5 << val_2;
        val_5 = val_5 & val_3;
        val_3 = val_5 >> val_2;
        return (byte)val_3;
    }
    public static bool[] GetBoolArray(string key)
    {
        string val_11;
        string val_12;
        string val_13;
        val_11 = key;
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_11)) == false)
        {
            goto label_1;
        }
        
        System.Byte[] val_3 = System.Convert.FromBase64String(s:  UnityEngine.PlayerPrefs.GetString(key:  val_11));
        if(val_3.Length <= 4)
        {
            goto label_5;
        }
        
        if(val_3[0] != 2)
        {
            goto label_6;
        }
        
        PlayerPrefsX.Initialize();
        int val_4 = val_3.Length - 5;
        byte[] val_5 = new byte[0];
        System.Array.Copy(sourceArray:  val_3, sourceIndex:  5, destinationArray:  val_5, destinationIndex:  0, length:  val_5.Length);
        System.Collections.BitArray val_6 = new System.Collections.BitArray(bytes:  val_5);
        val_6.Length = PlayerPrefsX.ConvertBytesToInt32(bytes:  val_3);
        bool[] val_8 = new bool[0];
        val_6.CopyTo(array:  val_8, index:  0);
        return (System.Boolean[])val_8;
        label_5:
        val_12 = val_11;
        val_13 = "Corrupt preference file for ";
        goto label_9;
        label_6:
        val_13 = val_11;
        val_12 = " is not a boolean array";
        label_9:
        val_11 = val_13 + val_12;
        UnityEngine.Debug.LogError(message:  val_11);
        label_1:
        bool[] val_10 = new bool[0];
        throw new NullReferenceException();
    }
    public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetBoolArray(key:  key);
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
        string val_9;
        System.Byte[] val_10;
        var val_11;
        string val_12;
        val_9 = key;
        int val_1 = stringArray.Length + 1;
        byte[] val_2 = new byte[0];
        val_10 = val_2;
        val_10[0] = System.Convert.ToByte(value:  3);
        PlayerPrefsX.Initialize();
        if(stringArray.Length < 1)
        {
            goto label_6;
        }
        
        var val_9 = 0;
        label_13:
        if(null == null)
        {
            goto label_8;
        }
        
        PlayerPrefsX.idx = PlayerPrefsX.idx + 1;
        val_9 = val_9 + 1;
        val_10[PlayerPrefsX.idx] = System.String[].__il2cppRuntimeField_name;
        if(val_9 < stringArray.Length)
        {
            goto label_13;
        }
        
        label_6:
        val_10 = System.Convert.ToBase64String(inArray:  val_2);
        UnityEngine.PlayerPrefs.SetString(key:  val_9, value:  val_10 + "|"("|") + System.String.Join(separator:  "", value:  stringArray)(System.String.Join(separator:  "", value:  stringArray)));
        val_11 = 1;
        return (bool)val_11;
        label_8:
        val_12 = "Can\'t save null entries in the string array when setting ";
        val_9 =  + val_9;
        UnityEngine.Debug.LogError(message:  val_9);
        val_11 = 0;
        return (bool)val_11;
    }
    public static string[] GetStringArray(string key)
    {
        string val_15;
        int val_16;
        var val_17;
        string val_18;
        string val_19;
        val_15 = key;
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_15)) == false)
        {
            goto label_1;
        }
        
        string val_2 = UnityEngine.PlayerPrefs.GetString(key:  val_15);
        int val_4 = val_2.IndexOf(value:  Chars[0]);
        if(val_4 <= 3)
        {
            goto label_12;
        }
        
        val_16 = val_4;
        System.Byte[] val_6 = System.Convert.FromBase64String(s:  val_2.Substring(startIndex:  0, length:  val_16));
        if(val_6[0] != 3)
        {
            goto label_9;
        }
        
        PlayerPrefsX.Initialize();
        int val_7 = val_6.Length - 1;
        val_17 = new string[0];
        if(val_7 < 1)
        {
                return (System.String[])val_17;
        }
        
        var val_17 = 0;
        int val_9 = val_16 + 1;
        label_17:
        PlayerPrefsX.idx = PlayerPrefsX.idx + 1;
        byte val_16 = val_6[PlayerPrefsX.idx];
        if((val_9 + val_16) > val_2.m_stringLength)
        {
            goto label_12;
        }
        
        val_16 = val_2.Substring(startIndex:  val_9, length:  val_16);
        mem2[0] = val_16;
        val_17 = val_17 + 1;
        if(val_17 < (long)val_7)
        {
            goto label_17;
        }
        
        return (System.String[])val_17;
        label_12:
        val_18 = val_15;
        val_19 = "Corrupt preference file for ";
        goto label_19;
        label_9:
        val_19 = val_15;
        val_18 = " is not a string array";
        label_19:
        val_15 = val_19 + val_18;
        UnityEngine.Debug.LogError(message:  val_15);
        label_1:
        val_17 = new string[0];
        return (System.String[])val_17;
    }
    public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
    {
        int val_3 = defaultSize;
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetStringArray(key:  key);
        }
        
        string[] val_2 = new string[0];
        if(val_3 < 1)
        {
                return (System.String[])val_2;
        }
        
        var val_3 = 0;
        val_3 = (long)val_3;
        do
        {
            mem2[0] = defaultValue;
            val_3 = val_3 + 1;
        }
        while(val_3 < val_3);
        
        return (System.String[])val_2;
    }
    public static bool SetIntArray(string key, int[] intArray)
    {
        return PlayerPrefsX.SetValue<System.Int32[]>(key:  key, array:  intArray, arrayType:  1, vectorNumber:  1, convert:  new System.Action<System.Int32[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromInt(int[] array, byte[] bytes, int i)));
    }
    public static bool SetFloatArray(string key, float[] floatArray)
    {
        return PlayerPrefsX.SetValue<System.Single[]>(key:  key, array:  floatArray, arrayType:  0, vectorNumber:  1, convert:  new System.Action<System.Single[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromFloat(float[] array, byte[] bytes, int i)));
    }
    public static bool SetVector2Array(string key, UnityEngine.Vector2[] vector2Array)
    {
        return PlayerPrefsX.SetValue<UnityEngine.Vector2[]>(key:  key, array:  vector2Array, arrayType:  4, vectorNumber:  2, convert:  new System.Action<UnityEngine.Vector2[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromVector2(UnityEngine.Vector2[] array, byte[] bytes, int i)));
    }
    public static bool SetVector3Array(string key, UnityEngine.Vector3[] vector3Array)
    {
        return PlayerPrefsX.SetValue<UnityEngine.Vector3[]>(key:  key, array:  vector3Array, arrayType:  5, vectorNumber:  3, convert:  new System.Action<UnityEngine.Vector3[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromVector3(UnityEngine.Vector3[] array, byte[] bytes, int i)));
    }
    public static bool SetQuaternionArray(string key, UnityEngine.Quaternion[] quaternionArray)
    {
        return PlayerPrefsX.SetValue<UnityEngine.Quaternion[]>(key:  key, array:  quaternionArray, arrayType:  6, vectorNumber:  4, convert:  new System.Action<UnityEngine.Quaternion[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromQuaternion(UnityEngine.Quaternion[] array, byte[] bytes, int i)));
    }
    public static bool SetColorArray(string key, UnityEngine.Color[] colorArray)
    {
        return PlayerPrefsX.SetValue<UnityEngine.Color[]>(key:  key, array:  colorArray, arrayType:  7, vectorNumber:  4, convert:  new System.Action<UnityEngine.Color[], System.Byte[], System.Int32>(object:  0, method:  static System.Void PlayerPrefsX::ConvertFromColor(UnityEngine.Color[] array, byte[] bytes, int i)));
    }
    private static bool SetValue<T>(string key, T array, PlayerPrefsX.ArrayType arrayType, int vectorNumber, System.Action<T, byte[], int> convert)
    {
        var val_9;
        var val_10 = 0;
        val_10 = val_10 + 1;
        int val_3 = vectorNumber * array.Count;
        byte[] val_4 = new byte[1];
        val_4[0] = System.Convert.ToByte(value:  arrayType);
        PlayerPrefsX.Initialize();
        val_9 = 0;
        goto label_10;
        label_16:
        val_9 = 1;
        label_10:
        var val_11 = 0;
        val_11 = val_11 + 1;
        if(val_9 < array.Count)
        {
            goto label_16;
        }
        
        return (bool)PlayerPrefsX.SaveBytes(key:  key, bytes:  val_4);
    }
    private static void ConvertFromInt(int[] array, byte[] bytes, int i)
    {
        PlayerPrefsX.ConvertInt32ToBytes(i:  array[i << 2], bytes:  bytes);
    }
    private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
    {
        PlayerPrefsX.ConvertFloatToBytes(f:  array[i << 2], bytes:  bytes);
    }
    private static void ConvertFromVector2(UnityEngine.Vector2[] array, byte[] bytes, int i)
    {
        PlayerPrefsX.ConvertFloatToBytes(f:  array[i], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[(long)i], bytes:  bytes);
    }
    private static void ConvertFromVector3(UnityEngine.Vector3[] array, byte[] bytes, int i)
    {
        var val_1 = 12;
        val_1 = array + (i * val_1);
        PlayerPrefsX.ConvertFloatToBytes(f:  (i * 12) + array + 32, bytes:  bytes);
        var val_2 = 12;
        val_2 = array + ((long)i * val_2);
        PlayerPrefsX.ConvertFloatToBytes(f:  ((long)(int)(i) * 12) + array + 36, bytes:  bytes);
        var val_3 = 12;
        val_3 = array + ((long)i * val_3);
        PlayerPrefsX.ConvertFloatToBytes(f:  ((long)(int)(i) * 12) + array + 40, bytes:  bytes);
    }
    private static void ConvertFromQuaternion(UnityEngine.Quaternion[] array, byte[] bytes, int i)
    {
        PlayerPrefsX.ConvertFloatToBytes(f:  array[i << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
    }
    private static void ConvertFromColor(UnityEngine.Color[] array, byte[] bytes, int i)
    {
        PlayerPrefsX.ConvertFloatToBytes(f:  array[i << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
        PlayerPrefsX.ConvertFloatToBytes(f:  array[((long)(int)(i)) << 4], bytes:  bytes);
    }
    public static int[] GetIntArray(string key)
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        PlayerPrefsX.GetValue<System.Collections.Generic.List<System.Int32>>(key:  key, list:  val_1, arrayType:  1, vectorNumber:  1, convert:  new System.Action<System.Collections.Generic.List<System.Int32>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToInt(System.Collections.Generic.List<int> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetIntArray(key:  key);
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
        PlayerPrefsX.GetValue<System.Collections.Generic.List<System.Single>>(key:  key, list:  val_1, arrayType:  0, vectorNumber:  1, convert:  new System.Action<System.Collections.Generic.List<System.Single>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToFloat(System.Collections.Generic.List<float> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetFloatArray(key:  key);
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
        PlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Vector2>>(key:  key, list:  val_1, arrayType:  4, vectorNumber:  2, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Vector2>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToVector2(System.Collections.Generic.List<UnityEngine.Vector2> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Vector2[] GetVector2Array(string key, UnityEngine.Vector2 defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetVector2Array(key:  key);
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
        PlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Vector3>>(key:  key, list:  val_1, arrayType:  5, vectorNumber:  3, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Vector3>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToVector3(System.Collections.Generic.List<UnityEngine.Vector3> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Vector3[] GetVector3Array(string key, UnityEngine.Vector3 defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetVector3Array(key:  key);
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
        PlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Quaternion>>(key:  key, list:  val_1, arrayType:  6, vectorNumber:  4, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Quaternion>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToQuaternion(System.Collections.Generic.List<UnityEngine.Quaternion> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Quaternion[] GetQuaternionArray(string key, UnityEngine.Quaternion defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetQuaternionArray(key:  key);
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
        PlayerPrefsX.GetValue<System.Collections.Generic.List<UnityEngine.Color>>(key:  key, list:  val_1, arrayType:  7, vectorNumber:  4, convert:  new System.Action<System.Collections.Generic.List<UnityEngine.Color>, System.Byte[]>(object:  0, method:  static System.Void PlayerPrefsX::ConvertToColor(System.Collections.Generic.List<UnityEngine.Color> list, byte[] bytes)));
        return val_1.ToArray();
    }
    public static UnityEngine.Color[] GetColorArray(string key, UnityEngine.Color defaultValue, int defaultSize)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                return PlayerPrefsX.GetColorArray(key:  key);
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
    private static void GetValue<T>(string key, T list, PlayerPrefsX.ArrayType arrayType, int vectorNumber, System.Action<T, byte[]> convert)
    {
        int val_10 = vectorNumber;
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
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
        
        if((System.Convert.FromBase64String(s:  UnityEngine.PlayerPrefs.GetString(key:  key))[0]) == arrayType)
        {
                PlayerPrefsX.Initialize();
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
        list.Add(item:  PlayerPrefsX.ConvertBytesToInt32(bytes:  bytes));
    }
    private static void ConvertToFloat(System.Collections.Generic.List<float> list, byte[] bytes)
    {
        list.Add(item:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
    }
    private static void ConvertToVector2(System.Collections.Generic.List<UnityEngine.Vector2> list, byte[] bytes)
    {
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
    }
    private static void ConvertToVector3(System.Collections.Generic.List<UnityEngine.Vector3> list, byte[] bytes)
    {
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), z:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    private static void ConvertToQuaternion(System.Collections.Generic.List<UnityEngine.Quaternion> list, byte[] bytes)
    {
        UnityEngine.Quaternion val_5 = new UnityEngine.Quaternion(x:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), y:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), z:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), w:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w});
    }
    private static void ConvertToColor(System.Collections.Generic.List<UnityEngine.Color> list, byte[] bytes)
    {
        UnityEngine.Color val_5 = new UnityEngine.Color(r:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), g:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), b:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes), a:  PlayerPrefsX.ConvertBytesToFloat(bytes:  bytes));
        list.Add(item:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
    }
    public static void ShowArrayType(string key)
    {
        string val_5 = key;
        if(val_2.Length == 0)
        {
                return;
        }
        
        val_5 = val_5 + " is a " + System.Convert.FromBase64String(s:  UnityEngine.PlayerPrefs.GetString(key:  val_5 = key))[0].ToString()(System.Convert.FromBase64String(s:  UnityEngine.PlayerPrefs.GetString(key:  val_5 = key))[0].ToString()) + " array";
        UnityEngine.Debug.Log(message:  val_5);
    }
    private static void Initialize()
    {
        var val_3 = null;
        bool val_3 = System.BitConverter.IsLittleEndian;
        val_3 = val_3 ^ 1;
        PlayerPrefsX.endianDiff1 = (val_3 == false) ? 3 : 0;
        PlayerPrefsX.endianDiff2 = val_3;
        if(PlayerPrefsX.byteBlock == null)
        {
                PlayerPrefsX.byteBlock = new byte[4];
        }
        
        PlayerPrefsX.idx = 1;
    }
    private static bool SaveBytes(string key, byte[] bytes)
    {
        UnityEngine.PlayerPrefs.SetString(key:  key, value:  System.Convert.ToBase64String(inArray:  bytes));
        return true;
    }
    private static void ConvertFloatToBytes(float f, byte[] bytes)
    {
        PlayerPrefsX.byteBlock = System.BitConverter.GetBytes(value:  f);
        PlayerPrefsX.ConvertTo4Bytes(bytes:  bytes);
    }
    private static float ConvertBytesToFloat(byte[] bytes)
    {
        PlayerPrefsX.ConvertFrom4Bytes(bytes:  bytes);
        return System.BitConverter.ToSingle(value:  PlayerPrefsX.byteBlock, startIndex:  0);
    }
    private static void ConvertInt32ToBytes(int i, byte[] bytes)
    {
        PlayerPrefsX.byteBlock = System.BitConverter.GetBytes(value:  i);
        PlayerPrefsX.ConvertTo4Bytes(bytes:  bytes);
    }
    private static int ConvertBytesToInt32(byte[] bytes)
    {
        PlayerPrefsX.ConvertFrom4Bytes(bytes:  bytes);
        return System.BitConverter.ToInt32(value:  PlayerPrefsX.byteBlock, startIndex:  0);
    }
    private static void ConvertTo4Bytes(byte[] bytes)
    {
        System.Byte[] val_1 = PlayerPrefsX.byteBlock;
        val_1 = val_1 + PlayerPrefsX.endianDiff1;
        bytes[PlayerPrefsX.idx] = (PlayerPrefsX.byteBlock + PlayerPrefsX.endianDiff1) + 32;
        System.Byte[] val_4 = PlayerPrefsX.byteBlock;
        int val_2 = PlayerPrefsX.endianDiff2;
        val_2 = val_2 + 1;
        int val_3 = PlayerPrefsX.idx;
        val_3 = val_3 + 1;
        val_4 = val_4 + (val_2 << );
        bytes[val_3] = (PlayerPrefsX.byteBlock + ((PlayerPrefsX.endianDiff2 + 1)) << ) + 32;
        System.Byte[] val_7 = PlayerPrefsX.byteBlock;
        int val_5 = PlayerPrefsX.endianDiff2;
        val_5 = 2 - val_5;
        int val_6 = PlayerPrefsX.idx;
        val_6 = val_6 + 2;
        val_7 = val_7 + (val_5 << );
        bytes[val_6] = (PlayerPrefsX.byteBlock + ((2 - PlayerPrefsX.endianDiff2)) << ) + 32;
        System.Byte[] val_10 = PlayerPrefsX.byteBlock;
        int val_8 = PlayerPrefsX.endianDiff1;
        val_8 = 3 - val_8;
        int val_9 = PlayerPrefsX.idx;
        val_9 = val_9 + 3;
        val_10 = val_10 + (val_8 << );
        bytes[val_9] = (PlayerPrefsX.byteBlock + ((3 - PlayerPrefsX.endianDiff1)) << ) + 32;
        int val_11 = PlayerPrefsX.idx;
        val_11 = val_11 + 4;
        PlayerPrefsX.idx = val_11;
    }
    private static void ConvertFrom4Bytes(byte[] bytes)
    {
        System.Byte[] val_2 = PlayerPrefsX.byteBlock;
        val_2 = val_2 + PlayerPrefsX.endianDiff1;
        (PlayerPrefsX.byteBlock + PlayerPrefsX.endianDiff1).__unknownFiledOffset_20 = bytes[PlayerPrefsX.idx];
        int val_3 = PlayerPrefsX.idx;
        val_3 = val_3 + 1;
        System.Byte[] val_6 = PlayerPrefsX.byteBlock;
        int val_4 = PlayerPrefsX.endianDiff2;
        val_4 = val_4 + 1;
        val_6 = val_6 + (val_4 << );
        (PlayerPrefsX.byteBlock + ((PlayerPrefsX.endianDiff2 + 1)) << ).__unknownFiledOffset_20 = bytes[val_3];
        int val_7 = PlayerPrefsX.idx;
        val_7 = val_7 + 2;
        System.Byte[] val_10 = PlayerPrefsX.byteBlock;
        int val_8 = PlayerPrefsX.endianDiff2;
        val_8 = 2 - val_8;
        val_10 = val_10 + (val_8 << );
        (PlayerPrefsX.byteBlock + ((2 - PlayerPrefsX.endianDiff2)) << ).__unknownFiledOffset_20 = bytes[val_7];
        int val_11 = PlayerPrefsX.idx;
        val_11 = val_11 + 3;
        System.Byte[] val_14 = PlayerPrefsX.byteBlock;
        int val_12 = PlayerPrefsX.endianDiff1;
        val_12 = 3 - val_12;
        val_14 = val_14 + (val_12 << );
        (PlayerPrefsX.byteBlock + ((3 - PlayerPrefsX.endianDiff1)) << ).__unknownFiledOffset_20 = bytes[val_11];
        int val_15 = PlayerPrefsX.idx;
        val_15 = val_15 + 4;
        PlayerPrefsX.idx = val_15;
    }
    public PlayerPrefsX()
    {
    
    }

}
