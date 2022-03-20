using UnityEngine;
public class SLCDateTime
{
    // Methods
    public static System.DateTime Parse(string dateTime)
    {
        System.DateTime val_1 = System.DateTime.Parse(s:  dateTime);
        return (System.DateTime)val_1.dateData;
    }
    public static System.DateTime Parse(string dateTime, System.DateTime defaultValue)
    {
        bool val_1 = System.DateTime.TryParse(s:  dateTime, result: out  new System.DateTime() {dateData = defaultValue.dateData});
        return (System.DateTime)defaultValue.dateData;
    }
    public static string SerializeInvariant(System.DateTime dateTime)
    {
        return (string)dateTime.dateData.ToString(provider:  System.Globalization.CultureInfo.InvariantCulture);
    }
    public static System.DateTime ParseInvariant(string dateTime, System.DateTime defaultValue)
    {
        bool val_2 = System.DateTime.TryParse(s:  dateTime, provider:  System.Globalization.CultureInfo.InvariantCulture, styles:  0, result: out  new System.DateTime() {dateData = defaultValue.dateData});
        return (System.DateTime)defaultValue.dateData;
    }
    public SLCDateTime()
    {
    
    }

}
