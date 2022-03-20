using UnityEngine;
public class StarTier
{
    // Fields
    public int MaximumIndex;
    public System.Collections.Generic.Dictionary<int, float> Probabilities;
    
    // Methods
    public void Decode(System.Collections.Generic.Dictionary<string, object> sourceData)
    {
        string val_7;
        System.Globalization.NumberStyles val_8;
        this.Probabilities = new System.Collections.Generic.Dictionary<System.Int32, System.Single>();
        Dictionary.Enumerator<TKey, TValue> val_2 = sourceData.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_7 = 0;
        val_8 = 511;
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_8 = System.Globalization.CultureInfo.InvariantCulture;
        val_7 = this.Probabilities;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.Add(key:  System.Int32.Parse(s:  val_7, style:  val_8), value:  System.Single.Parse(s:  0, provider:  val_8));
        goto label_7;
        label_2:
        0.Dispose();
    }
    public string ToJSON()
    {
        return (string)System.String.Format(format:  "tier max words: {0}, probabilities: {1}", arg0:  this.MaximumIndex, arg1:  MiniJSON.Json.Serialize(obj:  this.Probabilities));
    }
    public void FromJSON(string json)
    {
        var val_8;
        object val_1 = MiniJSON.Json.Deserialize(json:  json);
        if((val_1.ContainsKey(key:  "tier max words")) != false)
        {
                this.MaximumIndex = System.Int32.Parse(s:  val_1.Item["tier max words"]);
        }
        
        if((val_1.ContainsKey(key:  "probabilities")) == false)
        {
                return;
        }
        
        object val_6 = val_1.Item["probabilities"];
        val_8 = 0;
        this.Probabilities = ;
    }
    public StarTier()
    {
    
    }

}
