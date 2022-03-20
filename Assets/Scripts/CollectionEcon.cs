using UnityEngine;
[Serializable]
public class CollectionEcon
{
    // Fields
    public string collectionName;
    public UnityEngine.Sprite banner;
    public string[] progressPortraits;
    
    // Methods
    public CollectionEcon()
    {
        this.progressPortraits = new string[12];
    }

}
