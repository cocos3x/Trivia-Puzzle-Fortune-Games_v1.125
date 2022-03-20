using UnityEngine;
public class WGChallengeWordsManager.ChallengeWordsProgress
{
    // Fields
    private const string LEVEL_KEY = "Words_Level_Key";
    private const string WORD_INDEX_KEY = "Word_Index_Key";
    private int _level;
    private int _wordIndex;
    private bool inited;
    
    // Properties
    public int Level { get; set; }
    public int WordIndex { get; set; }
    
    // Methods
    public int get_Level()
    {
        if(this.inited == true)
        {
                return (int)this._level;
        }
        
        this.InitProgress();
        return (int)this._level;
    }
    public void set_Level(int value)
    {
        this._level = value;
        this.SaveProgress();
    }
    public int get_WordIndex()
    {
        if(this.inited == true)
        {
                return (int)this._wordIndex;
        }
        
        this.InitProgress();
        return (int)this._wordIndex;
    }
    public void set_WordIndex(int value)
    {
        this._wordIndex = value;
        this.SaveProgress();
    }
    private void SaveProgress()
    {
        var val_5;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Words_Level_Key", value:  this._level);
        val_1.Add(key:  "Word_Index_Key", value:  this._wordIndex);
        val_5 = null;
        val_5 = null;
        UnityEngine.PlayerPrefs.SetString(key:  "ChallengeWordsProgress" + App.game, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void InitProgress()
    {
        var val_13;
        null = null;
        string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "ChallengeWordsProgress" + App.game);
        if((System.String.IsNullOrEmpty(value:  val_2)) == true)
        {
                return;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  val_2);
        val_13 = 1152921510222861648;
        if((val_4.ContainsKey(key:  "Words_Level_Key")) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  val_4.Item["Words_Level_Key"], result: out  this._level);
        }
        
        if((val_4.ContainsKey(key:  "Word_Index_Key")) != false)
        {
                bool val_12 = System.Int32.TryParse(s:  val_4.Item["Word_Index_Key"], result: out  this._wordIndex);
        }
        
        this.inited = true;
    }
    public WGChallengeWordsManager.ChallengeWordsProgress()
    {
        this._wordIndex = 0;
    }

}
