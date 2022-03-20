using UnityEngine;
public class GameOfTheDayWindowUGUI : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text gameNameLabel;
    private UnityEngine.UI.Text rewardLabel;
    private UnityEngine.UI.RawImage assetIconTexture;
    private UnityEngine.UI.Text rewardDescriptionLabel;
    private string assetName;
    private string gamePackage;
    private bool imageLoaded;
    private int ghostNumber;
    
    // Methods
    private void OnEnable()
    {
        this.Refresh();
    }
    private void Refresh()
    {
        var val_7;
        MonoSingleton<GameOfTheDay>.Instance.JustShown();
        GameOfTheDay val_2 = MonoSingleton<GameOfTheDay>.Instance;
        this.assetName = val_2.<promoIconImageUrl>k__BackingField;
        GameOfTheDay val_3 = MonoSingleton<GameOfTheDay>.Instance;
        this.gamePackage = val_3.<promoPackageName>k__BackingField;
        GameOfTheDay val_4 = MonoSingleton<GameOfTheDay>.Instance;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        GameOfTheDay val_6 = MonoSingleton<GameOfTheDay>.Instance;
        val_5.Add(key:  "Game Shown", value:  val_6.<promoName>k__BackingField);
        val_7 = null;
        val_7 = null;
        App.trackerManager.track(eventName:  "GOTD Shown", data:  val_5);
        this.LoadAsset();
    }
    public void OnInstallButtonClick()
    {
        var val_7;
        var val_8;
        UnityEngine.Debug.Log(message:  "GameOfTheDayWindow : installGameOfTheDay");
        if(this.gamePackage == null)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        string val_1 = App.game.ToString();
        UnityEngine.Debug.Log(message:  "utm_source=gameoftheweek"("utm_source=gameoftheweek") + val_1);
        twelvegigs.plugins.InstalledAppsPlugin.OpenApp(package:  this.gamePackage, referrerMarket:  "utm_source=gameoftheweek"("utm_source=gameoftheweek") + val_1);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        GameOfTheDay val_5 = MonoSingleton<GameOfTheDay>.Instance;
        val_4.Add(key:  "Game Shown", value:  val_5.<promoName>k__BackingField);
        val_8 = null;
        val_8 = null;
        App.trackerManager.track(eventName:  "GOTD Clicked", data:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void LoadAsset()
    {
        object val_13;
        object val_14;
        string val_15;
        UnityEngine.Texture2D val_16;
        var val_17;
        val_14 = this;
        if((System.String.IsNullOrEmpty(value:  this.assetName)) == true)
        {
                return;
        }
        
        if(this.imageLoaded == true)
        {
                return;
        }
        
        val_13 = "https://cdn.12gigs.com/network_games/"("https://cdn.12gigs.com/network_games/") + this.assetName;
        string val_3 = "networkgameicon" + this.assetName;
        UnityEngine.Texture2D val_4 = 0;
        if((twelvegigs.net.ImageRequest.LoadFromPreCache(filename:  val_3, textureToSet: out  val_4)) == false)
        {
            goto label_5;
        }
        
        val_13 = "Loading pre cached " + val_3;
        val_15 = 0;
        UnityEngine.Debug.Log(message:  val_13);
        val_16 = val_4;
        goto label_8;
        label_5:
        if((twelvegigs.net.ImageRequest.ImageInLocal(imgPath:  val_3)) == false)
        {
            goto label_11;
        }
        
        UnityEngine.Debug.Log(message:  "Loading local " + val_3);
        val_15 = val_3;
        val_16 = twelvegigs.net.ImageRequest.LoadLocally(remoteURL:  val_13, fileName:  val_15);
        label_8:
        this.OnImageLoaded(filename:  val_15, t:  val_16);
        return;
        label_11:
        val_17 = null;
        val_17 = null;
        val_14 = GameOfTheDayWindowUGUI.<>c.<>9__11_0;
        if(val_14 == null)
        {
                System.Action val_11 = null;
            val_14 = val_11;
            val_11 = new System.Action(object:  GameOfTheDayWindowUGUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Void GameOfTheDayWindowUGUI.<>c::<LoadAsset>b__11_0());
            GameOfTheDayWindowUGUI.<>c.<>9__11_0 = val_14;
        }
        
        twelvegigs.net.ImageRequest val_12 = new twelvegigs.net.ImageRequest(url:  val_13, filename:  val_3, imgComplete:  new System.Action<System.String, UnityEngine.Texture2D>(object:  this, method:  System.Void GameOfTheDayWindowUGUI::OnImageLoaded(string filename, UnityEngine.Texture2D t)), imgError:  val_11, showErrors:  false, destroy:  false, cached:  true, save:  true);
    }
    private void OnImageLoaded(string filename, UnityEngine.Texture2D t)
    {
        this.imageLoaded = true;
        if(t == 0)
        {
                return;
        }
        
        if(this.assetIconTexture != 0)
        {
                this.assetIconTexture.texture = t;
            this.assetIconTexture.enabled = true;
            return;
        }
        
        int val_4 = this.ghostNumber;
        val_4 = val_4 + 1;
        this.ghostNumber = val_4;
        this = "(GameOfTheDayWindow.cs) Detected zombie ghost object " + val_4 + " time(s), this is OK but potential fix in VPoker as of 09 Mar 2015. Ask Mike/Connor."(" time(s), this is OK but potential fix in VPoker as of 09 Mar 2015. Ask Mike/Connor.");
        UnityEngine.Debug.LogError(message:  this);
    }
    public GameOfTheDayWindowUGUI()
    {
    
    }

}
