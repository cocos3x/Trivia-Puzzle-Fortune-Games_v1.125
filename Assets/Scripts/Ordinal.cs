using UnityEngine;
public class Ordinal
{
    // Methods
    public static string AddOrdinal(int num)
    {
        var val_1;
        if(((-11) >= 3) && ((-1) <= 2))
        {
                val_1 = 0;
            return (string)val_1;
        }
        
        val_1 = "th";
        return (string)val_1;
    }
    public static string GetOrdinalFormat(int num)
    {
        return (string)num.ToString(format:  "#,##0")(num.ToString(format:  "#,##0")) + Ordinal.AddOrdinal(num:  num)(Ordinal.AddOrdinal(num:  num));
    }
    public Ordinal()
    {
    
    }

}
