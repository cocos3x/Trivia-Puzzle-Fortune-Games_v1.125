using UnityEngine;
public class DFilters
{
    // Fields
    public const string ALL = "all";
    public const string DEFAULT = "default";
    public static string[] projectFilters;
    
    // Methods
    public DFilters()
    {
    
    }
    private static DFilters()
    {
        int val_2;
        string[] val_1 = new string[7];
        val_2 = val_1.Length;
        val_1[0] = "UI & User Control";
        val_2 = val_1.Length;
        val_1[1] = "General APP";
        val_2 = val_1.Length;
        val_1[2] = "Data / Save & Load";
        val_2 = val_1.Length;
        val_1[3] = "Localization & Language";
        val_2 = val_1.Length;
        val_1[4] = "Scene Management";
        val_2 = val_1.Length;
        val_1[5] = "External Communication";
        val_2 = val_1.Length;
        val_1[6] = "NGUI";
        DFilters.projectFilters = val_1;
    }

}
