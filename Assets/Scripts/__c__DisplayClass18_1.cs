using UnityEngine;
private sealed class TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1
{
    // Fields
    public int i;
    public TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0 CS$<>8__locals1;
    
    // Methods
    public TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1()
    {
    
    }
    internal bool <GetEventsRegisteredCategories>b__0(TriviaPursuitCategory x)
    {
        TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0 val_1 = this.CS$<>8__locals1;
        if(val_1 <= this.i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + ((this.i) << 3);
        return System.String.op_Equality(a:  x.CategoryName, b:  (this.CS$<>8__locals1 + (this.i) << 3).categories);
    }

}
