using UnityEngine;
public class LockedCategoryPacksComparer : IComparer<CategoryPackInfo>
{
    // Methods
    public int Compare(CategoryPackInfo a, CategoryPackInfo b)
    {
        decimal val_6;
        var val_7;
        val_6 = b.cost;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = a.cost, hi = a.cost, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = val_6, hi = val_6, lo = X22, mid = X22})) != false)
        {
                val_7 = 0;
            return (int)val_7;
        }
        
        val_6 = b.cost;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = a.cost, hi = a.cost, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = val_6, hi = val_6, lo = X22, mid = X22})) == false)
        {
                return System.String.Compare(strA:  a.FullTitle, strB:  b.FullTitle, comparisonType:  2);
        }
        
        val_7 = 1;
        return (int)val_7;
    }
    public LockedCategoryPacksComparer()
    {
    
    }

}
