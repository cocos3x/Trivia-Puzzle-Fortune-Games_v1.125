using UnityEngine;
public struct Award
{
    // Fields
    public string id;
    public string kind;
    public decimal amount;
    public string text;
    
    // Methods
    public override string ToString()
    {
        int val_3;
        object[] val_1 = new object[6];
        val_3 = val_1.Length;
        val_1[0] = "Award: id=";
        if(new Award() != 0)
        {
                val_3 = val_1.Length;
        }
        
        val_1[1] = null;
        val_3 = val_1.Length;
        val_1[2] = ", kind=";
        if(this.kind != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[3] = this.kind;
        val_3 = val_1.Length;
        val_1[4] = ", amount=";
        val_1[5] = this.amount;
        return (string)+val_1;
    }

}
