using UnityEngine;
public class WGMoreGamesItem : MonoBehaviour
{
    // Fields
    private UGUINetworkedButtonMultiGraphic entireButton;
    private UGUINetworkedButtonMultiGraphic installButton;
    private UnityEngine.UI.RawImage icon;
    private UnityEngine.UI.Text[] installOrPlayTexts;
    private UnityEngine.GameObject installedGroup;
    private string packageName;
    private twelvegigs.plugins.InstalledAppsPlugin.GameApp myGameApp;
    private bool imageLoaded;
    
    // Methods
    private void Awake()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  41963520, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGMoreGamesItem::InstallOrPlayClicked(bool connectionStatus)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        mem2[0] = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  41963520, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGMoreGamesItem::InstallOrPlayClicked(bool connectionStatus)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        mem2[0] = val_4;
        return;
        label_6:
    }
    public void SetParams(bool state, twelvegigs.plugins.InstalledAppsPlugin.GameApp gameApp)
    {
        UnityEngine.GameObject val_1 = this.gameObject;
        if(state != false)
        {
                val_1.SetActive(value:  true);
            this.packageName = gameApp.packageName;
            this.LoadAsset(_assetName:  gameApp.assetName);
            this.CheckInstallation(isInstalled:  (gameApp.isInstalled == true) ? 1 : 0);
            mem[1152921517930663464] = gameApp.assetName;
            this.myGameApp = gameApp.uniqueName;
            return;
        }
        
        val_1.SetActive(value:  false);
    }
    public void CheckInstallation(bool isInstalled)
    {
        UnityEngine.UI.Text val_7;
        this.installButton.gameObject.SetActive(value:  (~isInstalled) & 1);
        this.installedGroup.SetActive(value:  isInstalled);
        var val_7 = 0;
        do
        {
            if(val_7 >= this.installOrPlayTexts.Length)
        {
                return;
        }
        
            val_7 = this.installOrPlayTexts[val_7];
            string val_6 = Localization.Localize(key:  (isInstalled != true) ? "installed_upper" : "install_upper", defaultValue:  (isInstalled != true) ? "INSTALLED" : "INSTALL", useSingularKey:  false);
            val_7 = val_7 + 1;
        }
        while(this.installOrPlayTexts != null);
        
        throw new NullReferenceException();
    }
    private void InstallOrPlayClicked(bool connectionStatus)
    {
        string val_13;
        string val_14;
        var val_15;
        int val_16;
        var val_17;
        System.Func<System.Boolean> val_19;
        var val_20;
        val_14 = this;
        if(connectionStatus != true)
        {
                if(true == 0)
        {
            goto label_2;
        }
        
        }
        
        if((System.String.IsNullOrEmpty(value:  this.packageName)) == true)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        val_13 = App.game.ToString();
        val_14 = this.packageName;
        twelvegigs.plugins.InstalledAppsPlugin.OpenApp(package:  val_14, referrerMarket:  "utm_source=networkbonus"("utm_source=networkbonus") + val_13);
        return;
        label_2:
        val_14 = MonoSingleton<WGFlyoutManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true);
        val_13 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_16 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_16 = val_9.Length;
        val_9[1] = "NULL";
        System.Func<System.Boolean>[] val_11 = new System.Func<System.Boolean>[2];
        val_17 = null;
        val_17 = null;
        val_19 = WGMoreGamesItem.<>c.<>9__10_0;
        if(val_19 == null)
        {
                System.Func<System.Boolean> val_12 = null;
            val_19 = val_12;
            val_12 = new System.Func<System.Boolean>(object:  WGMoreGamesItem.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGMoreGamesItem.<>c::<InstallOrPlayClicked>b__10_0());
            WGMoreGamesItem.<>c.<>9__10_0 = val_19;
        }
        
        val_11[0] = val_19;
        val_20 = null;
        val_20 = null;
        val_14.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  val_13, shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_11, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void LoadAsset(string _assetName)
    {
        UnityEngine.Texture2D val_7;
        if((System.String.IsNullOrEmpty(value:  _assetName)) == true)
        {
                return;
        }
        
        if(this.imageLoaded == true)
        {
                return;
        }
        
        string val_2 = "networkgameicon" + _assetName;
        UnityEngine.Texture2D val_3 = 0;
        if((twelvegigs.net.ImageRequest.LoadFromPreCache(filename:  val_2, textureToSet: out  val_3)) != false)
        {
                val_7 = val_3;
        }
        else
        {
                if((twelvegigs.net.ImageRequest.ImageInLocal(imgPath:  val_2)) == false)
        {
                return;
        }
        
            val_7 = twelvegigs.net.ImageRequest.LoadLocally(remoteURL:  0, fileName:  val_2);
        }
        
        this.OnImageLoaded(t:  val_7);
    }
    private void OnImageLoaded(UnityEngine.Texture2D t)
    {
        this.imageLoaded = true;
        if(t == 0)
        {
                return;
        }
        
        if(this.icon == 0)
        {
                return;
        }
        
        this.icon.texture = t;
    }
    public WGMoreGamesItem()
    {
    
    }

}
