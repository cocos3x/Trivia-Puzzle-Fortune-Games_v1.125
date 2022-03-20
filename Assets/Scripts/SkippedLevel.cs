using UnityEngine;
public class SkippedLevel
{
    // Fields
    public string word;
    public int index;
    public int avgCompletionTime;
    public int skipTriggerCompletionTime;
    
    // Methods
    public SkippedLevel()
    {
    
    }
    public SkippedLevel(string word, int index, int avgCompletionTime, int skipTriggerCompletionTime)
    {
        this.word = word;
        this.index = index;
        this.avgCompletionTime = avgCompletionTime;
        this.skipTriggerCompletionTime = skipTriggerCompletionTime;
    }
    public string ToDebugString()
    {
        int val_5;
        object[] val_1 = new object[4];
        val_5 = val_1.Length;
        val_1[0] = this.index;
        if(this.word != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[1] = this.word;
        float val_5 = (float)this.avgCompletionTime;
        val_5 = val_5 / 1000f;
        val_1[2] = val_5.ToString(format:  "##,###.00");
        float val_6 = (float)this.skipTriggerCompletionTime;
        val_6 = val_6 / 1000f;
        val_1[3] = val_6.ToString(format:  "##,###.00");
        return (string)System.String.Format(format:  "{0}: {1}\t\t{2}sec\t\tSkip Trigger: {3}sec", args:  val_1);
    }
    public override string ToString()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "word", value:  this.word);
        val_1.Add(key:  "index", value:  this.index);
        val_1.Add(key:  "avgCompletionTime", value:  this.avgCompletionTime);
        val_1.Add(key:  "skipTriggerCompletionTime", value:  this.skipTriggerCompletionTime);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public void Decode(System.Collections.Generic.Dictionary<string, object> encoded)
    {
        this.word = encoded.Item["word"];
        this.index = System.Int32.Parse(s:  encoded.Item["index"]);
        this.avgCompletionTime = System.Int32.Parse(s:  encoded.Item["avgCompletionTime"]);
        this.skipTriggerCompletionTime = System.Int32.Parse(s:  encoded.Item["skipTriggerCompletionTime"]);
    }

}
