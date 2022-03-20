using UnityEngine;
public class AdSegmentation : MonoSingleton<AdSegmentation>
{
    // Fields
    public const string HIGHVAL = "highval";
    public const string MEDIUMVAL = "mediumval";
    public const string LOWVAL = "lowval";
    public const string ORGANIC = "organic";
    public const string UNKNOWN = "unknown";
    
    // Properties
    public static string Segment { get; }
    public static bool IsOrganic { get; }
    
    // Methods
    public static string get_Segment()
    {
        Player val_1 = App.Player;
        if(val_1.total_purchased > 0f)
        {
                Player val_2 = App.Player;
            val_2.properties.ads_segment = "highval";
        }
        
        Player val_3 = App.Player;
        return (string)val_3.properties.ads_segment;
    }
    public static bool get_IsOrganic()
    {
        return AdSegmentation.Segment.Equals(value:  "organic");
    }
    public static object GetSegementedConfig(string key, System.Collections.Generic.Dictionary<string, object> knobs, bool addSegment = True)
    {
        string val_14;
        string val_15;
        var val_16;
        string val_17;
        var val_18;
        val_14 = key;
        if(addSegment != false)
        {
                val_14 = key + "_segment";
        }
        
        if((knobs.ContainsKey(key:  val_14)) == false)
        {
            goto label_11;
        }
        
        object val_3 = knobs.Item[val_14];
        val_14 = 0;
        if((System.String.IsNullOrEmpty(value:  AdSegmentation.Segment)) != false)
        {
                val_15 = "m";
        }
        else
        {
                val_15 = AdSegmentation.Segment.Chars[0].ToString();
        }
        
        string val_10 = ((System.String.op_Equality(a:  val_15, b:  "u")) != true) ? "m" : (val_15);
        if((ContainsKey(key:  val_10)) == false)
        {
            goto label_11;
        }
        
        val_16 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
        val_17 = val_10;
        goto label_12;
        label_11:
        if((knobs.ContainsKey(key:  key)) == false)
        {
            goto label_13;
        }
        
        val_17 = key;
        val_16 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
        label_12:
        object val_13 = knobs.Item[val_17];
        return (object)val_18;
        label_13:
        val_18 = 0;
        return (object)val_18;
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause != false)
        {
                return;
        }
        
        this.ConsumeAdjustData();
    }
    private void ConsumeAdjustData()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if((System.String.IsNullOrEmpty(value:  AdjustPlugin.<Attribution_campaign>k__BackingField)) != false)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        SetupAdSegementation(campaign:  AdjustPlugin.<Attribution_campaign>k__BackingField);
    }
    private void SetupAdSegementation(string campaign)
    {
        PlayerProperties val_14;
        string val_15;
        Player val_1 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_1.properties.ads_segment)) == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  campaign)) != false)
        {
                Player val_4 = App.Player;
            val_14 = val_4.properties;
            val_15 = "unknown";
        }
        else
        {
                if((campaign.Contains(value:  "highval")) != false)
        {
                Player val_6 = App.Player;
            val_14 = val_6.properties;
            val_15 = "highval";
        }
        else
        {
                if((campaign.Contains(value:  "lowval")) != false)
        {
                Player val_8 = App.Player;
            val_14 = val_8.properties;
            val_15 = "lowval";
        }
        else
        {
                if((campaign.ToLower().Contains(value:  "organic")) != false)
        {
                Player val_11 = App.Player;
            val_14 = val_11.properties;
            val_15 = "organic";
        }
        else
        {
                Player val_12 = App.Player;
            val_14 = val_12.properties;
            val_15 = "mediumval";
        }
        
        }
        
        }
        
        }
        
        val_12.properties.ads_segment = val_15;
        App.Player.SaveState();
    }
    public AdSegmentation()
    {
    
    }

}
