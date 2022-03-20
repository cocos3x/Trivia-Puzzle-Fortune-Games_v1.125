using UnityEngine;
public class PlayerPrefsExtension
{
    // Fields
    private const string COMMA = ",";
    
    // Methods
    public static void SetStringArray(string key, System.Collections.Generic.List<string> stringArray)
    {
        UnityEngine.PlayerPrefs.SetString(key:  key, value:  MiniJSON.Json.Serialize(obj:  stringArray));
    }
    public static System.Collections.Generic.List<string> GetStringArray(string key, string defaultValue, int defaultSize)
    {
        string val_5;
        var val_6;
        string val_8;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  key, defaultValue:  "[]")).GetEnumerator();
        label_7:
        val_8 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_8 = val_5;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_8);
        goto label_7;
        label_4:
        val_6.Dispose();
        return val_1;
    }
    public static void SetIntArray(string key, System.Collections.Generic.List<int> intArray)
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(1152921509851217984 >= 1)
        {
                var val_6 = 0;
            do
        {
            if(val_6 >= 1152921509851217984)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1.Add(item:  "big_quiz_reward".ToString());
            val_6 = val_6 + 1;
        }
        while(val_6 < "big_quiz_reward");
        
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  key, value:  System.String.Join(separator:  ",", value:  val_1.ToArray())(System.String.Join(separator:  ",", value:  val_1.ToArray())) + ",");
    }
    public static System.Collections.Generic.List<int> GetIntArray(string key, int defaultValue, int defaultSize)
    {
        System.String[] val_8;
        int val_9 = defaultSize;
        val_8 = defaultValue;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) != false)
        {
                string[] val_4 = new string[1];
            val_8 = val_4;
            val_8[0] = ",";
            int val_8 = val_5.Length;
            if(val_8 < 1)
        {
                return val_1;
        }
        
            val_8 = val_8 & 4294967295;
            do
        {
            if((System.Int32.TryParse(s:  null, result: out  0)) != false)
        {
                val_1.Add(item:  0);
        }
        
            val_8 = 0 + 1;
        }
        while(val_8 < (val_5.Length << ));
        
            return val_1;
        }
        
        if(val_9 < 1)
        {
                return val_1;
        }
        
        do
        {
            val_1.Add(item:  val_8);
            val_9 = val_9 - 1;
        }
        while(val_9 != 1);
        
        return val_1;
    }
    public PlayerPrefsExtension()
    {
    
    }

}
