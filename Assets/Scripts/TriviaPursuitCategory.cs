using UnityEngine;
public class TriviaPursuitCategory
{
    // Fields
    private const string KEY_CATEGORY = "category";
    private const string KEY_PROGRESS = "progress";
    public string CategoryName;
    public int Progress;
    
    // Methods
    public bool IsCompleted()
    {
        return (bool)(this.GetProgress() >= 1f) ? 1 : 0;
    }
    public float GetProgress()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        float val_2 = (float)val_1.TriviaPursuitEventEcon.requirement;
        val_2 = (float)this.Progress / val_2;
        return (float)val_2;
    }
    public string GetProgressText()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.Progress, arg1:  val_1.TriviaPursuitEventEcon.requirement);
    }
    public void Parse(string data)
    {
        var val_9;
        if((System.String.IsNullOrEmpty(value:  data)) == true)
        {
                return;
        }
        
        object val_2 = MiniJSON.Json.Deserialize(json:  data);
        val_9 = 1152921510222861648;
        if((val_2.ContainsKey(key:  "category")) != false)
        {
                this.CategoryName = val_2.Item["category"];
        }
        
        if((val_2.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        bool val_8 = System.Int32.TryParse(s:  val_2.Item["progress"], result: out  this.Progress);
    }
    public override string ToString()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "category", value:  this.CategoryName);
        val_1.Add(key:  "progress", value:  this.Progress);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public TriviaPursuitCategory()
    {
    
    }

}
