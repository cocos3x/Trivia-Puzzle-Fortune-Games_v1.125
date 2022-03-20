using UnityEngine;
[Serializable]
public class TRVCategoryProficiencies
{
    // Fields
    public string subCat;
    public int defaultPotential;
    public int maxPotential;
    public int currentPotential;
    
    // Methods
    public TRVCategoryProficiencies(string cat, string maxPot, string incDefault)
    {
        int val_8;
        val_1 = new System.Object();
        this.subCat = cat;
        if((System.Int32.TryParse(s:  incDefault, result: out  this.defaultPotential)) != true)
        {
                mem2[0] = 0;
        }
        
        if((System.Int32.TryParse(s:  string val_1 = maxPot, result: out  this.maxPotential)) != true)
        {
                mem2[0] = 0;
        }
        
        this.currentPotential = this.defaultPotential;
        object[] val_6 = new object[4];
        val_8 = val_6.Length;
        val_6[0] = "cat ";
        if(cat != null)
        {
                val_8 = val_6.Length;
        }
        
        val_6[1] = cat;
        val_8 = val_6.Length;
        val_6[2] = " cur ";
        val_6[3] = this.currentPotential;
        UnityEngine.Debug.LogError(message:  +val_6);
    }
    public TRVCategoryProficiencies()
    {
    
    }
    public bool Deserialize(string data)
    {
        object val_1 = MiniJSON.Json.Deserialize(json:  data);
        UnityEngine.Debug.LogError(message:  "broken prof data");
        return false;
    }
    public string Serialize()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "c", value:  this.currentPotential.ToString());
        val_1.Add(key:  "sc", value:  this.subCat);
        val_1.Add(key:  "mp", value:  this.maxPotential.ToString());
        return MiniJSON.Json.Serialize(obj:  val_1);
    }

}
