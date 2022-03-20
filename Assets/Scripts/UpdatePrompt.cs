using UnityEngine;
public static class UpdatePrompt
{
    // Fields
    private const string deviceVersionCode = "device_version_code";
    private static string versionCode;
    private static string storeUrl;
    private static twelvegigs.storage.JsonDictionary configuration;
    
    // Methods
    public static void Init(twelvegigs.storage.JsonDictionary serverConfiguration)
    {
        twelvegigs.storage.JsonDictionary val_32;
        int val_33;
        int val_34;
        int val_35;
        int val_36;
        val_32 = serverConfiguration;
        UpdatePrompt.configuration = val_32;
        if(UpdatePrompt.configuration == null)
        {
                return;
        }
        
        UpdatePrompt.versionCode = UpdatePrompt.configuration.getString(key:  "android_version_code", defaultValue:  "");
        UpdatePrompt.storeUrl = UpdatePrompt.configuration.getString(key:  "android_url", defaultValue:  "");
        string val_3 = DeviceIdPlugin.GetClientVersion();
        bool val_5 = UpdatePrompt.versionCode.Contains(value:  "skip");
        bool val_7 = UpdatePrompt.versionCode.Contains(value:  "force");
        bool val_9 = UpdatePrompt.versionCode.Contains(value:  val_3);
        System.Text.RegularExpressions.Regex val_10 = new System.Text.RegularExpressions.Regex(pattern:  "[^\\d]");
        float val_11 = UpdatePrompt.getNumericVersion(versionCode:  val_3);
        var val_13 = ((UpdatePrompt.getNumericVersion(versionCode:  UpdatePrompt.versionCode)) < 0) ? 1 : 0;
        UnityEngine.Debug.Log(message:  "UPDATE PROMPT: versionCode = "("UPDATE PROMPT: versionCode = ") + UpdatePrompt.versionCode + ", clientVersion = "(", clientVersion = ") + val_3);
        string[] val_15 = new string[8];
        val_32 = val_15;
        val_32[0] = "UPDATE PROMPT: skip = ";
        val_33 = val_15.Length;
        val_32[1] = val_5.ToString();
        val_33 = val_15.Length;
        val_32[2] = ", force = ";
        val_34 = val_15.Length;
        val_32[3] = val_7.ToString();
        val_34 = val_15.Length;
        val_32[4] = ", versionMatchesCurrent = ";
        val_35 = val_15.Length;
        val_32[5] = val_9.ToString();
        val_35 = val_15.Length;
        val_32[6] = ", versionLessThanCurrent = ";
        val_32[7] = val_13.ToString();
        UnityEngine.Debug.Log(message:  +val_15);
        if(UnityEngine.Application.isEditor == true)
        {
                return;
        }
        
        val_32 = App.Player;
        if((val_22.playerStats.ContainsKey(key:  "device_version_code")) != false)
        {
                decimal val_24 = val_22.playerStats.Item["device_version_code"];
            val_36 = val_24.lo;
            decimal val_25 = System.Decimal.op_Implicit(value:  UpdatePrompt.versionCode);
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_36, mid = val_24.mid}, d2:  new System.Decimal() {flags = val_25.flags, hi = val_25.hi, lo = val_25.lo, mid = val_25.mid})) == false)
        {
                return;
        }
        
            if(val_7 != true)
        {
                bool val_27 = val_22.playerStats.Remove(key:  "device_version_code");
            val_36 = UpdatePrompt.versionCode;
            decimal val_28 = System.Decimal.op_Implicit(value:  val_36);
            val_22.playerStats.Add(key:  "device_version_code", value:  new System.Decimal() {flags = val_28.flags, hi = val_28.hi, lo = val_28.lo, mid = val_28.mid});
            val_32.SaveState();
        }
        
            bool val_32 = val_5;
            val_32 = val_9 | val_32;
            val_32 = val_32 | val_13;
            if(val_32 == true)
        {
                return;
        }
        
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGUpdatePromptPopup>(showNext:  false).Setup(url:  UpdatePrompt.storeUrl, mustUpdate:  val_7);
            return;
        }
        
        val_36 = UpdatePrompt.versionCode;
        decimal val_31 = System.Decimal.op_Implicit(value:  val_36);
        val_22.playerStats.Add(key:  "device_version_code", value:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_31.lo, mid = val_31.mid});
        val_32.SaveState();
    }
    public static void DebugResetPlayerStatsVersion()
    {
        string val_6 = "device_version_code";
        if((val_1.playerStats.ContainsKey(key:  val_6 = "device_version_code")) != false)
        {
                val_6 = "device_version_code";
            bool val_4 = val_1.playerStats.Remove(key:  val_6);
        }
        
        decimal val_5 = System.Decimal.op_Implicit(value:  DeviceIdPlugin.GetClientVersion());
        val_1.playerStats.Add(key:  "device_version_code", value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        App.Player.SaveState();
    }
    private static float getNumericVersion(string versionCode)
    {
        System.Text.RegularExpressions.Match val_2 = new System.Text.RegularExpressions.Regex(pattern:  "\\d*[0-9]\\.?\\d*[0-9]?").Match(input:  versionCode);
        if(val_2.Success == false)
        {
                return 0f;
        }
        
        return System.Single.Parse(s:  val_2.Item[0].ToString(), provider:  System.Globalization.CultureInfo.InvariantCulture);
    }

}
