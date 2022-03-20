using UnityEngine;
public class EmojiManagerMinigames : MonoSingleton<EmojiManagerMinigames>
{
    // Fields
    private UnityEngine.TextAsset emojiLookupData;
    private System.Collections.Generic.Dictionary<string, object> emojiLookup;
    private System.Collections.Generic.Dictionary<string, UnityEngine.GameObject> prefabLookup;
    private UnityEngine.GameObject[] prefabs;
    
    // Methods
    public void BuildEmojiLookup()
    {
        var val_6;
        object val_2 = MiniJSON.Json.Deserialize(json:  this.emojiLookupData.text);
        val_6 = 0;
        this.emojiLookup = ;
        this.prefabLookup = new System.Collections.Generic.Dictionary<System.String, UnityEngine.GameObject>();
        if(this.prefabs.Length < 1)
        {
                return;
        }
        
        var val_7 = 0;
        do
        {
            UnityEngine.GameObject val_6 = this.prefabs[val_7];
            this.prefabLookup.Add(key:  val_6.name, value:  val_6);
            val_7 = val_7 + 1;
        }
        while(val_7 < this.prefabs.Length);
    
    }
    public UnityEngine.GameObject GetEmojiPrefab(string key)
    {
        string val_12;
        string val_13;
        System.Collections.Generic.Dictionary<System.String, UnityEngine.GameObject> val_14;
        int val_15;
        int val_16;
        string val_1 = key.Trim();
        val_12 = val_1;
        val_13 = "";
        if((this.emojiLookup.ContainsKey(key:  val_1.ToUpper())) != false)
        {
                val_13 = this.emojiLookup.Item[val_12.ToUpper()].ToLower();
        }
        else
        {
                UnityEngine.Debug.LogError(message:  "no translated key value for " + val_12);
        }
        
        if((this.prefabLookup.ContainsKey(key:  val_13)) != false)
        {
                val_14 = this.prefabLookup;
            bool val_9 = val_14.ContainsKey(key:  val_13);
            return (UnityEngine.GameObject)val_14;
        }
        
        string[] val_10 = new string[5];
        val_15 = val_10.Length;
        val_10[0] = "trying to get an emoji with key of ";
        val_15 = val_10.Length;
        val_10[1] = val_13;
        val_13 = " and name of ";
        val_15 = val_10.Length;
        val_10[2] = " and name of ";
        val_16 = val_10.Length;
        val_10[3] = val_12;
        val_16 = val_10.Length;
        val_10[4] = " but we don\'t have a prefab for it";
        val_12 = +val_10;
        UnityEngine.Debug.LogError(message:  val_12);
        val_14 = 0;
        return (UnityEngine.GameObject)val_14;
    }
    public EmojiManagerMinigames()
    {
    
    }

}
