using UnityEngine;
public class StarTiers
{
    // Fields
    public System.Collections.Generic.List<StarTier> Tiers;
    
    // Methods
    public StarTiers(System.Collections.Generic.List<object> sourceData)
    {
        var val_4;
        var val_11;
        System.Collections.Generic.List<StarTier> val_12;
        string val_13;
        this.Tiers = new System.Collections.Generic.List<StarTier>();
        List.Enumerator<T> val_2 = sourceData.GetEnumerator();
        label_13:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_11 = 0;
        StarTier val_7 = null;
        val_13 = 0;
        val_7 = new StarTier();
        val_13 = "max";
        object val_8 = Item[val_13];
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = 0;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .MaximumIndex = System.Int32.Parse(s:  val_8);
        object val_10 = Item["prob"];
        val_13 = 0;
        val_7.Decode(sourceData:  null);
        val_12 = this.Tiers;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(item:  val_7);
        goto label_13;
        label_2:
        val_4.Dispose();
    }

}
