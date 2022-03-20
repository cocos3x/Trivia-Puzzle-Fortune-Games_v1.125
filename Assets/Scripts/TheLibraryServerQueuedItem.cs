using UnityEngine;
public class TheLibraryServerQueuedItem
{
    // Fields
    public string[] Skus;
    public bool Purchased;
    
    // Methods
    public TheLibraryServerQueuedItem()
    {
    
    }
    public TheLibraryServerQueuedItem(string sku, bool purchased)
    {
        string[] val_1 = new string[1];
        val_1[0] = sku;
        this.Skus = val_1;
        this.Purchased = purchased;
    }
    public TheLibraryServerQueuedItem(string[] skus, bool purchased)
    {
        this.Skus = skus;
        this.Purchased = purchased;
    }

}
