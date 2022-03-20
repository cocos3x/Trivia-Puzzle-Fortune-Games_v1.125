using UnityEngine;
public static class CPlayerPrefs
{
    // Fields
    private static System.Collections.Generic.Dictionary<string, string> keyHashs;
    private static System.Collections.Generic.Dictionary<string, int> xorOperands;
    private static int salt;
    private static bool _useRijndael;
    private static bool _useHashKey;
    private static bool _useXor;
    
    // Methods
    public static bool HasKey(string key)
    {
        return UnityEngine.PlayerPrefs.HasKey(key:  CPlayerPrefs.hashedKey(key:  key));
    }
    public static void DeleteKey(string key)
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  CPlayerPrefs.hashedKey(key:  key));
    }
    public static void DeleteAll()
    {
        UnityEngine.PlayerPrefs.DeleteAll();
    }
    public static void Save()
    {
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void SetInt(string key, int val)
    {
        int val_6;
        var val_7;
        val_6 = val;
        string val_1 = CPlayerPrefs.hashedKey(key:  key);
        val_7 = null;
        if(CPlayerPrefs._useXor != false)
        {
                int val_2 = CPlayerPrefs.computeXorOperand(key:  key, cryptedKey:  val_1);
            val_7 = null;
            int val_3 = val_2 & (val_2 << 1);
            val_3 = val_3 + val_6;
            val_6 = val_3 ^ val_2;
        }
        
        val_7 = null;
        if(CPlayerPrefs._useRijndael != false)
        {
                UnityEngine.PlayerPrefs.SetString(key:  val_1, value:  CPlayerPrefs.encrypt(cKey:  val_1, data:  System.String.alignConst + val_6));
            return;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  val_1, value:  val_6);
    }
    public static void SetLong(string key, long val)
    {
        CPlayerPrefs.SetString(key:  key, val:  val.ToString());
    }
    public static void SetString(string key, string val)
    {
        string val_9;
        string val_10;
        var val_11;
        string val_12;
        string val_13;
        string val_14;
        val_9 = val;
        val_10 = key;
        string val_1 = CPlayerPrefs.hashedKey(key:  val_10);
        val_11 = null;
        if(CPlayerPrefs._useXor != false)
        {
                int val_2 = CPlayerPrefs.computeXorOperand(key:  val_10, cryptedKey:  val_1);
            val_12 = "";
            if(val.m_stringLength >= 1)
        {
                val_10 = val_2;
            var val_9 = 0;
            do
        {
            int val_5 = (val_2 & (val_2 << 1)) + val_9.Chars[0];
            val_5 = val_5 ^ val_10;
            val_9 = val_9 + 1;
            val_12 = val_12 + val_5.ToString();
        }
        while(val_9 < val.m_stringLength);
        
        }
        
            val_11 = null;
            val_9 = val_12;
        }
        
        val_11 = null;
        if(CPlayerPrefs._useRijndael != false)
        {
                val_13 = CPlayerPrefs.encrypt(cKey:  val_1, data:  val_9);
            val_14 = val_1;
        }
        else
        {
                val_14 = val_1;
            val_13 = val_9;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  val_14, value:  val_13);
    }
    public static void SetFloat(string key, float val)
    {
        CPlayerPrefs.SetString(key:  key, val:  val.ToString());
    }
    public static void SetBool(string key, bool value)
    {
        CPlayerPrefs.SetInt(key:  key, val:  value);
    }
    public static int GetInt(string key, int defaultValue)
    {
        var val_9;
        var val_10;
        string val_11;
        var val_12;
        val_9 = defaultValue;
        string val_1 = CPlayerPrefs.hashedKey(key:  key);
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_1)) == false)
        {
                return (int)val_9;
        }
        
        val_10 = null;
        val_10 = null;
        if(CPlayerPrefs._useRijndael != false)
        {
                int val_4 = System.Int32.Parse(s:  CPlayerPrefs.decrypt(cKey:  val_1));
        }
        else
        {
                val_11 = val_1;
        }
        
        val_9 = UnityEngine.PlayerPrefs.GetInt(key:  val_11);
        val_12 = null;
        val_12 = null;
        if(CPlayerPrefs._useXor == false)
        {
                return (int)val_9;
        }
        
        int val_6 = CPlayerPrefs.computeXorOperand(key:  key, cryptedKey:  val_1);
        val_9 = val_6 ^ val_9 - (val_6 & (val_6 << 1));
        return (int)val_9;
    }
    public static int GetInt(string key)
    {
        return CPlayerPrefs.GetInt(key:  key, defaultValue:  0);
    }
    public static long GetLong(string key, long defaultValue)
    {
        return (long)System.Int64.Parse(s:  CPlayerPrefs.GetString(key:  key, defaultValue:  defaultValue.ToString()));
    }
    public static long GetLong(string key)
    {
        return CPlayerPrefs.GetLong(key:  key, defaultValue:  0);
    }
    public static string GetString(string key, string defaultValue)
    {
        string val_11;
        string val_12;
        var val_13;
        var val_15;
        val_11 = defaultValue;
        val_12 = key;
        string val_1 = CPlayerPrefs.hashedKey(key:  val_12);
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_1)) == false)
        {
                return (string)val_11;
        }
        
        val_13 = null;
        val_13 = null;
        if(CPlayerPrefs._useRijndael != false)
        {
                string val_3 = CPlayerPrefs.decrypt(cKey:  val_1);
        }
        else
        {
                string val_4 = UnityEngine.PlayerPrefs.GetString(key:  val_1);
        }
        
        val_15 = null;
        val_15 = null;
        if(CPlayerPrefs._useXor != false)
        {
                int val_5 = CPlayerPrefs.computeXorOperand(key:  val_12, cryptedKey:  val_1);
            val_11 = "";
            if(val_4.m_stringLength < 1)
        {
                return (string)val_11;
        }
        
            val_12 = val_5;
            var val_11 = 0;
            do
        {
            int val_8 = val_12 ^ val_4.Chars[0];
            val_8 = val_8 - (val_5 & (val_5 << 1));
            val_11 = val_11 + 1;
            val_11 = val_11 + val_8.ToString();
        }
        while(val_11 < val_4.m_stringLength);
        
            return (string)val_11;
        }
        
        val_11 = val_4;
        return (string)val_11;
    }
    public static string GetString(string key)
    {
        return CPlayerPrefs.GetString(key:  key, defaultValue:  "");
    }
    public static float GetFloat(string key, float defaultValue)
    {
        return (float)System.Single.Parse(s:  CPlayerPrefs.GetString(key:  key, defaultValue:  defaultValue.ToString()));
    }
    public static float GetFloat(string key)
    {
        return CPlayerPrefs.GetFloat(key:  key, defaultValue:  0f);
    }
    public static bool GetBool(string key, bool defaultValue = False)
    {
        bool val_4 = defaultValue;
        if((CPlayerPrefs.HasKey(key:  key)) != false)
        {
                int val_2 = CPlayerPrefs.GetInt(key:  key);
        }
        
        val_2 = ((val_2 == 1) ? 1 : 0) & 1;
        return (bool)val_2;
    }
    public static void SetDouble(string key, double value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  key, value:  CPlayerPrefs.DoubleToString(target:  value));
    }
    public static double GetDouble(string key, double defaultValue)
    {
        return CPlayerPrefs.StringToDouble(target:  UnityEngine.PlayerPrefs.GetString(key:  key, defaultValue:  CPlayerPrefs.DoubleToString(target:  defaultValue)));
    }
    public static double GetDouble(string key)
    {
        return CPlayerPrefs.GetDouble(key:  key, defaultValue:  0);
    }
    private static string DoubleToString(double target)
    {
        return (string)target.ToString(format:  "R");
    }
    private static double StringToDouble(string target)
    {
        if((System.String.IsNullOrEmpty(value:  target)) == false)
        {
                return System.Double.Parse(s:  target);
        }
        
        return 0;
    }
    private static string encrypt(string cKey, string data)
    {
        return ZKW.CryptoPlayerPrefs.Helper.EncryptString(clearText:  data, Password:  CPlayerPrefs.getEncryptionPassword(pw:  cKey));
    }
    private static string decrypt(string cKey)
    {
        return ZKW.CryptoPlayerPrefs.Helper.DecryptString(cipherText:  UnityEngine.PlayerPrefs.GetString(key:  cKey), Password:  CPlayerPrefs.getEncryptionPassword(pw:  cKey));
    }
    private static string hashedKey(string key)
    {
        string val_5;
        var val_6;
        var val_8;
        var val_9;
        val_5 = key;
        val_6 = null;
        val_6 = null;
        if(CPlayerPrefs._useHashKey == false)
        {
                return (string)val_5;
        }
        
        val_6 = null;
        if(CPlayerPrefs.__il2cppRuntimeField_static_fields == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_8 = null;
            val_8 = null;
            CPlayerPrefs.keyHashs = val_1;
            val_6 = null;
        }
        
        val_6 = null;
        val_9 = null;
        if((val_1.ContainsKey(key:  val_5)) != false)
        {
                val_9 = null;
            val_5 = val_1.Item[val_5];
            return (string)val_5;
        }
        
        string val_4 = CPlayerPrefs.hashSum(strToEncrypt:  val_5);
        val_1.Add(key:  val_5, value:  val_4);
        val_5 = val_4;
        return (string)val_5;
    }
    private static int computeXorOperand(string key, string cryptedKey)
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        val_6 = null;
        val_6 = null;
        if(CPlayerPrefs.xorOperands == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Int32> val_1 = null;
            val_5 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
            val_6 = null;
            val_6 = null;
            CPlayerPrefs.xorOperands = val_5;
        }
        
        val_6 = null;
        if((val_1.ContainsKey(key:  key)) != false)
        {
                val_7 = null;
            val_7 = null;
            return val_1.Item[key];
        }
        
        if(cryptedKey.m_stringLength >= 1)
        {
                do
        {
            val_5 = 0 + 1;
            val_8 = 0 + cryptedKey.Chars[0];
        }
        while(val_5 < cryptedKey.m_stringLength);
        
        }
        else
        {
                val_8 = 0;
        }
        
        val_9 = null;
        val_9 = null;
        int val_4 = CPlayerPrefs.salt + val_8;
        val_1.Add(key:  key, value:  val_4);
        return val_4;
    }
    private static int computePlusOperand(int xor)
    {
        xor = xor & (xor << 1);
        return (int)xor;
    }
    public static string hashSum(string strToEncrypt)
    {
        string val_7;
        int val_7 = val_3.Length;
        val_7 = "";
        if(val_7 < 1)
        {
                return val_7.PadLeft(totalWidth:  32, paddingChar:  '0');
        }
        
        var val_8 = 0;
        val_7 = val_7 & 4294967295;
        do
        {
            val_8 = val_8 + 1;
            val_7 = val_7 + System.Convert.ToString(value:  192, toBase:  16).PadLeft(totalWidth:  2, paddingChar:  '0')(System.Convert.ToString(value:  192, toBase:  16).PadLeft(totalWidth:  2, paddingChar:  '0'));
        }
        while(val_8 < (val_3.Length << ));
        
        return val_7.PadLeft(totalWidth:  32, paddingChar:  '0');
    }
    private static string getEncryptionPassword(string pw)
    {
        null = null;
        return (string)CPlayerPrefs.hashSum(strToEncrypt:  pw + CPlayerPrefs.salt);
    }
    public static void setSalt(int s)
    {
        null = null;
        CPlayerPrefs.salt = s;
    }
    public static void useRijndael(bool use)
    {
        null = null;
        CPlayerPrefs._useRijndael = use;
    }
    public static void useXor(bool use)
    {
        null = null;
        CPlayerPrefs._useXor = use;
    }
    private static CPlayerPrefs()
    {
        CPlayerPrefs.salt = 2147483647;
        CPlayerPrefs._useRijndael = true;
        CPlayerPrefs._useHashKey = false;
        CPlayerPrefs._useXor = false;
    }

}
