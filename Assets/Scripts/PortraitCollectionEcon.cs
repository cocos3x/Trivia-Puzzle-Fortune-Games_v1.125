using UnityEngine;
public class PortraitCollectionEcon : ScriptableObject
{
    // Fields
    public System.Collections.Generic.List<CollectionEcon> MyCollections;
    public System.Collections.Generic.List<int> rarityWeights;
    
    // Methods
    public PortraitCollectionEcon()
    {
        this.rarityWeights = new System.Collections.Generic.List<System.Int32>();
    }

}
