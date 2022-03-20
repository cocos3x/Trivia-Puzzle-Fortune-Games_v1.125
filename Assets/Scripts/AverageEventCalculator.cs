using UnityEngine;
public class AverageEventCalculator
{
    // Fields
    private float average;
    private int total;
    private string name;
    
    // Properties
    public float Average { get; }
    private System.Collections.Generic.Dictionary<string, object> JSONDictionary { get; }
    
    // Methods
    public float get_Average()
    {
        return (float)this.average;
    }
    private System.Collections.Generic.Dictionary<string, object> get_JSONDictionary()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "name", value:  this.name);
        val_1.Add(key:  "average", value:  this.average);
        val_1.Add(key:  "total", value:  this.total);
        return val_1;
    }
    public AverageEventCalculator(string name)
    {
        string val_1 = "average_event_calculator_" + name;
        this.name = val_1;
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_1)) == false)
        {
                return;
        }
        
        this.Load();
    }
    private void Load()
    {
        var val_7;
        object val_2 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this.name));
        val_7 = 0;
        new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  null);
        this.total = new twelvegigs.storage.JsonDictionary().getInt(key:  "total", defaultValue:  0);
        this.average = new twelvegigs.storage.JsonDictionary().getFloat(key:  "average", defaultValue:  0f);
    }
    public void Calculate(float valueToAdd)
    {
        int val_1 = this.total;
        if(val_1 == 2147483647)
        {
                val_1 = 1;
            this.total = val_1;
        }
        
        float val_1 = this.average;
        val_1 = val_1 + 1;
        val_1 = val_1 * 1f;
        valueToAdd = val_1 + valueToAdd;
        valueToAdd = valueToAdd / (float)val_1;
        this.total = val_1;
        this.average = valueToAdd;
        UnityEngine.PlayerPrefs.SetString(key:  this.name, value:  this);
    }
    public float CalculateCurrent(float valueToAdd)
    {
        int val_1 = this.total;
        if(val_1 == 2147483647)
        {
                val_1 = 1;
            this.total = val_1;
        }
        
        float val_1 = this.average;
        val_1 = val_1 + 1;
        val_1 = val_1 * 1f;
        valueToAdd = val_1 + valueToAdd;
        valueToAdd = valueToAdd / (float)val_1;
        return (float)valueToAdd;
    }
    public override string ToString()
    {
        return MiniJSON.Json.Serialize(obj:  this.JSONDictionary);
    }

}
