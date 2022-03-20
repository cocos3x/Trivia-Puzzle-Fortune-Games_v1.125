using UnityEngine;
public class CategoryPackWordBank
{
    // Fields
    public int packId;
    public System.Collections.Generic.List<string> allWordsList;
    
    // Properties
    public int Size { get; }
    
    // Methods
    public int get_Size()
    {
        return 5601;
    }
    public CategoryPackWordBank()
    {
        this.allWordsList = new System.Collections.Generic.List<System.String>();
    }

}
