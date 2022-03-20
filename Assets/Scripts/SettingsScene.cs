using UnityEngine;
public class SettingsScene : MonoBehaviour
{
    // Fields
    private static string URL_PREFIX_KEY;
    public UnityEngine.UI.InputField urlPrefixInput;
    public UnityEngine.UI.Text sdkVersionText;
    private string urlPrefix;
    
    // Methods
    public static void InitializeSettings()
    {
        null = null;
        AudienceNetwork.AdSettings.SetUrlPrefix(urlPrefix:  UnityEngine.PlayerPrefs.GetString(key:  SettingsScene.URL_PREFIX_KEY, defaultValue:  ""));
    }
    private void Start()
    {
        null = null;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  SettingsScene.URL_PREFIX_KEY, defaultValue:  "");
        this.urlPrefix = val_1;
        this.urlPrefixInput.text = val_1;
        string val_2 = AudienceNetwork.SdkVersion.Build;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void OnEditEnd(string prefix)
    {
        this.urlPrefix = prefix;
        this.SaveSettings();
    }
    public void SaveSettings()
    {
        null = null;
        UnityEngine.PlayerPrefs.SetString(key:  SettingsScene.URL_PREFIX_KEY, value:  this.urlPrefix);
        AudienceNetwork.AdSettings.SetUrlPrefix(urlPrefix:  this.urlPrefix);
    }
    public void AdViewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "AdViewScene");
    }
    public void InterstitialAdScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "InterstitialAdScene");
    }
    public void RewardedVideoAdScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "RewardedVideoAdScene");
    }
    public SettingsScene()
    {
    
    }
    private static SettingsScene()
    {
        SettingsScene.URL_PREFIX_KEY = "URL_PREFIX";
    }

}
