using UnityEngine;
public class ForestFrenzyEventProgress : MonoBehaviour
{
    // Fields
    private const string PREFKEY_EVENT_ID = "ffe_id";
    private const string PREFKEY_CURRENCY = "ffe_c";
    private const string PREFKEY_FOREST_MAPDATA = "ffe_map";
    private const string PREFKEY_REWARDED = "ffe_rwd";
    private const int tropical_level_index = 1;
    private static int accumulatedCurrency;
    private static bool hasRewarded;
    public static WordForest.Map forestMapData;
    
    // Properties
    public static int currentForestID { get; }
    public static string forestMapDataJson { get; }
    public static int AccumulatedCurrency { get; }
    public static bool HasRewarded { get; set; }
    
    // Methods
    public static int get_currentForestID()
    {
        return 1;
    }
    public static string get_forestMapDataJson()
    {
        null = null;
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  ForestFrenzyEventProgress.forestMapData);
    }
    public static int get_AccumulatedCurrency()
    {
        null = null;
        return (int)ForestFrenzyEventProgress.accumulatedCurrency;
    }
    public static bool get_HasRewarded()
    {
        null = null;
        return (bool)ForestFrenzyEventProgress.hasRewarded;
    }
    public static void set_HasRewarded(bool value)
    {
        null = null;
        ForestFrenzyEventProgress.hasRewarded = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_rwd", value:  ForestFrenzyEventProgress.hasRewarded);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void Init(GameEventV2 gameEventV2)
    {
        ForestFrenzyEventProgress.LoadFromLocal(gameEventV2:  gameEventV2);
    }
    public static void AddCurrency(int amount)
    {
        null = null;
        int val_2 = ForestFrenzyEventProgress.accumulatedCurrency;
        val_2 = val_2 + amount;
        ForestFrenzyEventProgress.accumulatedCurrency = val_2;
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_c", value:  ForestFrenzyEventProgress.accumulatedCurrency);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void DeductCurrency(int amount)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        int val_2 = ForestFrenzyEventProgress.accumulatedCurrency;
        val_2 = val_2 - amount;
        ForestFrenzyEventProgress.accumulatedCurrency = val_2;
        val_3 = null;
        if((ForestFrenzyEventProgress.accumulatedCurrency & 2147483648) != 0)
        {
                ForestFrenzyEventProgress.accumulatedCurrency = 0;
            val_3 = null;
        }
        
        val_3 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_c", value:  0);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void UpdateForestMapData()
    {
        null = null;
        UnityEngine.PlayerPrefs.SetString(key:  "ffe_map", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  ForestFrenzyEventProgress.forestMapData));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private static void LoadFromLocal(GameEventV2 gameEventV2)
    {
        var val_11;
        var val_12;
        var val_13;
        if(gameEventV2.id == (UnityEngine.PlayerPrefs.GetInt(key:  "ffe_id", defaultValue:  0)))
        {
                string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "ffe_map", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_2)) != true)
        {
                val_11 = null;
            val_11 = null;
            ForestFrenzyEventProgress.forestMapData = Newtonsoft.Json.JsonConvert.DeserializeObject<WordForest.Map>(value:  val_2);
        }
        
            val_12 = null;
            val_12 = null;
            ForestFrenzyEventProgress.accumulatedCurrency = UnityEngine.PlayerPrefs.GetInt(key:  "ffe_c", defaultValue:  0);
            ForestFrenzyEventProgress.hasRewarded = ((UnityEngine.PlayerPrefs.GetInt(key:  "ffe_rwd", defaultValue:  0)) == 1) ? 1 : 0;
            return;
        }
        
        val_13 = null;
        val_13 = null;
        ForestFrenzyEventProgress.forestMapData = ForestFrenzyEcon.CreateMap(forestLevel:  1, growthLevel:  0, growthPercent:  0f);
        ForestFrenzyEventProgress.accumulatedCurrency = 0;
        ForestFrenzyEventProgress.hasRewarded = false;
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_id", value:  gameEventV2.id);
        UnityEngine.PlayerPrefs.SetString(key:  "ffe_map", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  ForestFrenzyEventProgress.forestMapData));
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_c", value:  0);
        UnityEngine.PlayerPrefs.SetInt(key:  "ffe_rwd", value:  0);
        bool val_10 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public ForestFrenzyEventProgress()
    {
    
    }
    private static ForestFrenzyEventProgress()
    {
    
    }

}
