using UnityEngine;
public class ApplicationConfig : ScriptableObject
{
    // Fields
    public string gameName;
    public string gamePathName;
    public string internalAcronym;
    public ApplicationConfig.BonusCollectType bonusCollectType;
    public string facebook_app_id;
    public string facebook_display_name;
    public string facebook_page_id;
    public string facebook_permissions;
    public string amplitudeApiKey;
    public string companyName;
    public string gmsAppId;
    public string googleAnalyticsTrackingId;
    public string deeplinkScheme;
    public string domainName;
    public string vip_email;
    public bool uploadLevelGenerationStatistics;
    public AndroidConfig Free_Android;
    public IosConfig Free_Ios;
    public WebGLConfig Free_Webgl;
    public string APPLOVIN_SDK_KEY;
    public string propertiesFile;
    public string antProjectName;
    public string gameObjectName;
    private string StagingServerURL;
    private string ProductionServerURL;
    public string ResourcesDataPath;
    public System.Collections.Generic.List<string> EnabledScenes;
    public string[] ResourcesToDisable;
    public bool isUmbrella;
    public bool deprecated;
    public int priority;
    public string googleSheetForMachines;
    public string staging_path;
    public string BuildTime;
    public string GitBranch;
    public string GDPR_TOS_URL;
    public string GDPR_Privacy_URL;
    
    // Properties
    public string Environment { get; }
    
    // Methods
    public string Key(string key)
    {
        if((System.String.op_Equality(a:  key, b:  "applovinSdkKey")) == false)
        {
                return this.GetPropertyForPlatform(key:  key);
        }
        
        return (string)this.APPLOVIN_SDK_KEY;
    }
    public string GetSupportEmail(int amountPurchased)
    {
        if(amountPurchased < 91)
        {
                return this.GetPropertyForPlatform(key:  "supportEmail");
        }
        
        return (string)this.vip_email;
    }
    public string GetSupportUrl()
    {
        if(this.Free_Android != null)
        {
                return (string)this.Free_Android.supportUrl;
        }
        
        throw new NullReferenceException();
    }
    private string GetPropertyForPlatform(string key)
    {
        string val_5 = key;
        if(this.Free_Android == null)
        {
                return 0;
        }
        
        System.Reflection.FieldInfo val_3 = (((AndroidConfig.__il2cppRuntimeField_typeHierarchy + (AndroidConfig.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? this.Free_Android : 0.GetType().GetField(name:  val_5 = key);
        val_5 = val_3;
        if((System.Reflection.FieldInfo.op_Inequality(left:  val_3, right:  0)) == false)
        {
                return 0;
        }
        
        return val_5.ToString();
    }
    private ProductConfig ChooseConfig()
    {
        return (ProductConfig)this.Free_Android;
    }
    public bool HasCustomEndpoint()
    {
        return false;
    }
    public string GetServerURL()
    {
        return (string)this.ProductionServerURL;
    }
    public string GetServerProductionURL()
    {
        return (string)this.ProductionServerURL;
    }
    public string GetAdminURL()
    {
        return System.String.Copy(str:  this.ProductionServerURL).Replace(oldValue:  "api", newValue:  "admin");
    }
    public bool IsProduction()
    {
        return true;
    }
    public string get_Environment()
    {
        return "PRODUCTION";
    }
    public ApplicationConfig()
    {
        this.gameName = "";
        this.gamePathName = "";
        this.internalAcronym = "";
        this.facebook_app_id = "";
        this.facebook_display_name = "";
        this.facebook_page_id = "";
        this.facebook_permissions = "email";
        this.amplitudeApiKey = "";
        this.googleAnalyticsTrackingId = "";
        this.deeplinkScheme = "";
        this.domainName = "";
        this.vip_email = "";
        this.companyName = "Super Lucky Casino";
        this.gmsAppId = "";
        this.APPLOVIN_SDK_KEY = "SDK Key for AppLovin";
        this.propertiesFile = "(PROG) Ant Properties File";
        this.antProjectName = "(PROG) Ant Project Name";
        this.gameObjectName = "(PROG) Game Obj Name";
        this.StagingServerURL = "Staging Server URL";
        this.ProductionServerURL = "Production Server URL";
        this.ResourcesDataPath = "Resources Data path for this game";
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "override_me");
        this.EnabledScenes = val_1;
        string[] val_2 = new string[1];
        val_2[0] = "override_me";
        this.ResourcesToDisable = val_2;
        this.priority = 1;
        this.googleSheetForMachines = "";
        this.staging_path = "";
        this.BuildTime = "";
        this.GitBranch = "";
        this.GDPR_TOS_URL = "";
        this.GDPR_Privacy_URL = "";
    }

}
