using UnityEngine;
public class BingoEventProgression : EventProgression
{
    // Fields
    private const string BingoEventPrefKey = "BINGO_EVENT_PROGRESSION";
    public int currentEventId;
    public int ballsCollected;
    public int currentLevelBalls;
    public int keyWordIndex;
    public int cellIndex;
    public int lastProgressTimestamp;
    public int[,] currentCard;
    public System.Collections.Generic.List<int> balls;
    public int bingoCalls;
    
    // Methods
    public override void LoadFromJSON()
    {
        var val_31;
        var val_32;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "BINGO_EVENT_PROGRESSION")) == false)
        {
                return;
        }
        
        object val_34 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "BINGO_EVENT_PROGRESSION", defaultValue:  "{}"));
        if((val_34.ContainsKey(key:  "event")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_34.Item["event"], result: out  this.currentEventId);
        }
        
        if((val_34.ContainsKey(key:  "ballsColl")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_34.Item["ballsColl"], result: out  this.ballsCollected);
        }
        
        if((val_34.ContainsKey(key:  "lastProgression")) != false)
        {
                bool val_15 = System.Int32.TryParse(s:  val_34.Item["lastProgression"], result: out  this.lastProgressTimestamp);
        }
        
        if((val_34.ContainsKey(key:  "clBallsColl")) != false)
        {
                bool val_19 = System.Int32.TryParse(s:  val_34.Item["clBallsColl"], result: out  this.currentLevelBalls);
        }
        
        if((val_34.ContainsKey(key:  "bingoCalls")) != false)
        {
                bool val_23 = System.Int32.TryParse(s:  val_34.Item["bingoCalls"], result: out  this.bingoCalls);
        }
        
        object val_24 = val_34.Item["balls"];
        val_31 = 0;
        this.balls = new System.Collections.Generic.List<System.Int32>();
        var val_33 = 0;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        this.balls.Add(item:  System.Int32.Parse(s:  ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_24 : 0 + 16 + 0) + 32));
        val_33 = val_33 + 1;
        object val_28 = val_34.Item["card"];
        val_32 = 0;
        this.currentCard = null;
        var val_35 = 0;
        do
        {
            do
        {
            var val_29 = 0 + 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_32 = 0 + 1;
            this.currentCard[(((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_28 : 0 + 16 + ((0 + 0)) << 3) + 32 + 16 * 0) + 0] = System.Int32.Parse(s:  ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_28 : 0 + 16 + ((0 + 0)) << 3) + 32);
        }
        while(0 < 4);
        
            val_35 = val_35 + 1;
            val_32 = 0 + val_32;
        }
        while(val_35 <= 3);
    
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        var val_7 = 0;
        do
        {
            var val_6 = 0;
            do
        {
            var val_3 = val_6 + 1;
            val_3 = val_7 + ((X10 + 16) * val_3);
            val_2.Add(item:  this.currentCard[val_3]);
            val_6 = val_6 + 1;
        }
        while(val_6 < 4);
        
            val_7 = val_7 + 1;
        }
        while(val_7 <= 3);
        
        val_1.Add(key:  "event", value:  this.currentEventId);
        val_1.Add(key:  "card", value:  val_2);
        val_1.Add(key:  "balls", value:  this.balls);
        val_1.Add(key:  "ballsColl", value:  this.ballsCollected);
        val_1.Add(key:  "clBallsColl", value:  this.currentLevelBalls);
        val_1.Add(key:  "bingoCalls", value:  this.bingoCalls);
        val_1.Add(key:  "lastProgression", value:  this.lastProgressTimestamp);
        UnityEngine.PlayerPrefs.SetString(key:  "BINGO_EVENT_PROGRESSION", value:  MiniJSON.Json.Serialize(obj:  val_1));
    }
    public override void Delete()
    {
        this.DeleteKey(key:  "BINGO_EVENT_PROGRESSION");
    }
    public BingoEventProgression()
    {
        this.keyWordIndex = -1;
        this.cellIndex = -1;
    }

}
