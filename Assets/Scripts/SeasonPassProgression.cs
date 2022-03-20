using UnityEngine;
public class SeasonPassProgression : EventProgression
{
    // Fields
    private const string SeasonPassPrefKey = "SEASON_PASS_PROGRESSION";
    public int currentEventId;
    public int initLevel;
    public int currentTier;
    public bool hasPass;
    public System.Collections.Generic.List<int> freeAwardsCollected;
    public System.Collections.Generic.List<int> passAwardsCollected;
    
    // Properties
    public int CurrentChestTier { get; }
    
    // Methods
    public int get_CurrentChestTier()
    {
        int val_1 = UnityEngine.Mathf.Max(a:  0, b:  this.currentTier);
        return UnityEngine.Mathf.Min(a:  2, b:  UnityEngine.Mathf.FloorToInt(f:  0f));
    }
    public void InitEvent(int eventId, int playerLevel)
    {
        this.currentEventId = eventId;
        this.initLevel = playerLevel;
        this.hasPass = false;
        this.freeAwardsCollected.Clear();
        this.passAwardsCollected.Clear();
    }
    public override void LoadFromJSON()
    {
        var val_22;
        var val_23;
        System.Collections.Generic.List<System.Int32> val_24;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "SEASON_PASS_PROGRESSION")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "SEASON_PASS_PROGRESSION", defaultValue:  "{}"));
        val_22 = 0;
        UnityEngine.Debug.Log(message:  PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  false));
        val_23 = 1152921510214912464;
        bool val_8 = System.Int32.TryParse(s:  Item["eventId"], result: out  this.currentEventId);
        bool val_11 = System.Int32.TryParse(s:  Item["initLevel"], result: out  this.initLevel);
        bool val_14 = System.Int32.TryParse(s:  Item["currTier"], result: out  this.currentTier);
        bool val_17 = System.Boolean.TryParse(value:  Item["hasPass"], result: out  this.hasPass);
        val_24 = Item["freeCollected"];
        if(null >= 1)
        {
                var val_22 = 0;
            if(null <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.freeAwardsCollected.Add(item:  System.Int32.Parse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg));
            val_22 = val_22 + 1;
        }
        
        object val_20 = Item["passCollected"];
        if(null < 1)
        {
                return;
        }
        
        val_23 = 1152921510479955696;
        var val_23 = 0;
        val_24 = this.passAwardsCollected;
        if(null <= val_23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24.Add(item:  System.Int32.Parse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg));
        val_23 = val_23 + 1;
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "eventId", value:  this.currentEventId);
        val_1.Add(key:  "initLevel", value:  this.initLevel);
        val_1.Add(key:  "currTier", value:  this.currentTier);
        val_1.Add(key:  "hasPass", value:  this.hasPass);
        val_1.Add(key:  "freeCollected", value:  this.freeAwardsCollected);
        val_1.Add(key:  "passCollected", value:  this.passAwardsCollected);
        UnityEngine.PlayerPrefs.SetString(key:  "SEASON_PASS_PROGRESSION", value:  MiniJSON.Json.Serialize(obj:  val_1));
    }
    public override void Delete()
    {
        this.DeleteKey(key:  "SEASON_PASS_PROGRESSION");
    }
    public long EncodeProgression(bool pass)
    {
        int val_4;
        var val_5;
        var val_1 = (pass != true) ? 40 : 32;
        System.Collections.BitArray val_2 = new System.Collections.BitArray(length:  31, defaultValue:  false);
        List.Enumerator<T> val_3 = 1152921504933842944.GetEnumerator();
        label_5:
        if(val_5.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_4 > 30)
        {
            goto label_5;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.set_Item(index:  val_4, value:  true);
        goto label_5;
        label_2:
        val_5.Dispose();
        byte[] val_7 = new byte[8];
        val_2.CopyTo(array:  val_7, index:  0);
        return (long)System.BitConverter.ToInt64(value:  val_7, startIndex:  0);
    }
    public void DecodeProgression(bool pass, string progression)
    {
        var val_9;
        long val_1 = 0;
        bool val_2 = System.Int64.TryParse(s:  progression, result: out  val_1);
        val_9 = val_1;
        if((this.EncodeProgression(pass:  pass)) > 0)
        {
                UnityEngine.Debug.LogError(message:  "SeasonPassProgression: Ignore server saved progression");
            return;
        }
        
        System.Collections.BitArray val_6 = null;
        val_9 = val_6;
        val_6 = new System.Collections.BitArray(bytes:  System.BitConverter.GetBytes(value:  0));
        System.Collections.Generic.List<System.Int32> val_7 = new System.Collections.Generic.List<System.Int32>();
        if((System.Collections.BitArray)[1152921516697596032].m_length >= 1)
        {
                var val_9 = 0;
            do
        {
            if(val_6.Item[0] != false)
        {
                val_7.Add(item:  0);
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < (System.Collections.BitArray)[1152921516697596032].m_length);
        
        }
        
        if(pass != false)
        {
                this.passAwardsCollected = val_7;
            return;
        }
        
        this.freeAwardsCollected = val_7;
    }
    public SeasonPassProgression()
    {
        this.freeAwardsCollected = new System.Collections.Generic.List<System.Int32>();
        this.passAwardsCollected = new System.Collections.Generic.List<System.Int32>();
    }

}
