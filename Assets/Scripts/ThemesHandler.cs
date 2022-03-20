using UnityEngine;
public class ThemesHandler : MonoSingleton<ThemesHandler>
{
    // Fields
    private const string pref_theme_key = "chosen_theme";
    public const string Notification_OnThemeChanged = "Notification_OnThemeChanged";
    private static string[] excludedNames;
    private bool initialized;
    private UITheme theme;
    private static ThemeAssetTable assetsTable;
    
    // Properties
    public string CurrentThemeName { get; }
    public UITheme CurrentTheme { get; }
    
    // Methods
    public string get_CurrentThemeName()
    {
        var val_2;
        if(this.theme.themeType != 0)
        {
                val_2 = this.theme + 24.ToString();
            mem2[0] = this.theme + 24;
            return (string)val_2;
        }
        
        val_2 = "";
        return (string)val_2;
    }
    public UITheme get_CurrentTheme()
    {
        return (UITheme)this.theme;
    }
    public void SwapTheme(Themes swapTo)
    {
        .swapTo = swapTo;
        AppConfigs val_2 = App.Configuration;
        UITheme val_4 = val_2.Themes.themes.Find(match:  new System.Predicate<UITheme>(object:  new ThemesHandler.<>c__DisplayClass10_0(), method:  System.Boolean ThemesHandler.<>c__DisplayClass10_0::<SwapTheme>b__0(UITheme x)));
        if(val_4 == 0)
        {
                mem[1152921517092276576] = .swapTo;
            UnityEngine.Debug.LogError(message:  "ThemesHandler.SwapTheme(). Could not find theme: "("ThemesHandler.SwapTheme(). Could not find theme: ") + .swapTo.ToString());
            return;
        }
        
        this.theme = val_4;
        mem[1152921517092276576] = mem[1152921517092276576];
        UnityEngine.PlayerPrefs.SetString(key:  "chosen_theme", value:  mem[1152921517092276576].ToString());
        GameBehavior val_9 = App.getBehavior;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "Notification_OnThemeChanged");
    }
    private void Start()
    {
        this.Initialize();
    }
    private void Initialize()
    {
        System.Collections.Generic.List<UITheme> val_13;
        if(this.initialized == true)
        {
                return;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "chosen_theme")) != false)
        {
                object val_5 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  UnityEngine.PlayerPrefs.GetString(key:  "chosen_theme"));
            .prefTheme = null;
            AppConfigs val_6 = App.Configuration;
            val_13 = val_6.Themes.themes;
            this.theme = val_13.Find(match:  new System.Predicate<UITheme>(object:  new ThemesHandler.<>c__DisplayClass12_0(), method:  System.Boolean ThemesHandler.<>c__DisplayClass12_0::<Initialize>b__0(UITheme x)));
        }
        else
        {
                val_13 = 1152921504884269056;
            AppConfigs val_9 = App.Configuration;
            if((UnityEngine.Object.op_Implicit(exists:  val_9.Themes)) != false)
        {
                AppConfigs val_11 = App.Configuration;
            if(val_11.Themes == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.theme = val_11.Themes;
        }
        else
        {
                this.theme = new UITheme();
        }
        
        }
        
        this.initialized = true;
    }
    public ThemesHandler()
    {
    
    }
    private static ThemesHandler()
    {
        int val_2;
        string[] val_1 = new string[3];
        val_2 = val_1.Length;
        val_1[0] = "managers";
        val_2 = val_1.Length;
        val_1[1] = "background";
        val_2 = val_1.Length;
        val_1[2] = "leagues";
        ThemesHandler.excludedNames = val_1;
    }

}
