using UnityEngine;
public class AdConfig
{
    // Fields
    public int UnlockLevel;
    public int InterstitialSeconds;
    public bool Enabled;
    public System.DateTime LastInterstitial;
    public System.Collections.Generic.List<InterstitialContext> AllowedContext;
    
    // Methods
    public override string ToString()
    {
        var val_5;
        object[] val_1 = new object[4];
        val_1[0] = this.Enabled;
        val_1[1] = this.UnlockLevel;
        val_1[2] = this.InterstitialSeconds;
        val_1[3] = MiniJSON.Json.Serialize(obj:  this.AllowedContext);
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        return (string)System.String.Format(format:  System.String.Format(format:  "[AdConfig] Enabled: {0}, UnlockLevel: {1}, Seconds: {2}, AllowedContext: {3}", args:  val_1), args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public AdConfig()
    {
        var val_2;
        this.Enabled = true;
        this.UnlockLevel = 26;
        this.InterstitialSeconds = 60;
        val_2 = null;
        val_2 = null;
        this.LastInterstitial = System.DateTime.MinValue;
        System.Collections.Generic.List<InterstitialContext> val_1 = new System.Collections.Generic.List<InterstitialContext>();
        val_1.Add(item:  1);
        val_1.Add(item:  2);
        val_1.Add(item:  3);
        this.AllowedContext = val_1;
    }

}
