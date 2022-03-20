using UnityEngine;
public class AdViewScene : BaseScene
{
    // Fields
    private AudienceNetwork.AdView adView;
    private AudienceNetwork.AdPosition currentAdViewPosition;
    private UnityEngine.ScreenOrientation currentScreenOrientation;
    public UnityEngine.UI.Text statusLabel;
    private AudienceNetwork.AdSize[] adSizeArray;
    private int currentAdSize;
    public UnityEngine.UI.Button loadAdButton;
    
    // Methods
    private void OnDestroy()
    {
        if((AudienceNetwork.AdView.op_Implicit(obj:  this.adView)) != false)
        {
                this.adView.Dispose();
        }
        
        UnityEngine.Debug.Log(message:  "AdViewTest was destroyed!");
    }
    private void Awake()
    {
        AudienceNetwork.AudienceNetworkAds.Initialize();
        this.SetLoadAddButtonText();
        SettingsScene.InitializeSettings();
    }
    private void SetLoadAddButtonText()
    {
        UnityEngine.UI.Text val_1 = this.loadAdButton.GetComponentInChildren<UnityEngine.UI.Text>();
        mem2[0] = null;
        string val_3 = "Load Banner (" + this.adSizeArray[(this.currentAdSize) << 2][32].ToString()(this.adSizeArray[(this.currentAdSize) << 2][32].ToString()) + ")";
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void LoadBanner()
    {
        if((AudienceNetwork.AdView.op_Implicit(obj:  this.adView)) != false)
        {
                this.adView.Dispose();
        }
        
        AudienceNetwork.AdView val_2 = new AudienceNetwork.AdView(placementId:  "YOUR_PLACEMENT_ID", size:  this.adSizeArray[(this.currentAdSize) << 2]);
        this.adView = val_2;
        val_2.Register(gameObject:  this.gameObject);
        this.currentAdViewPosition = 0;
        this.adView.AdViewDidLoad = new AudienceNetwork.FBAdViewBridgeCallback(object:  this, method:  System.Void AdViewScene::<LoadBanner>b__10_0());
        this.adView.AdViewDidFailWithError = new AudienceNetwork.FBAdViewBridgeErrorCallback(object:  this, method:  System.Void AdViewScene::<LoadBanner>b__10_1(string error));
        this.adView.AdViewWillLogImpression = new AudienceNetwork.FBAdViewBridgeCallback(object:  this, method:  System.Void AdViewScene::<LoadBanner>b__10_2());
        this.adView.AdViewDidClick = new AudienceNetwork.FBAdViewBridgeCallback(object:  this, method:  System.Void AdViewScene::<LoadBanner>b__10_3());
        this.adView.LoadAd();
    }
    public void ChangeBannerSize()
    {
        int val_2 = this.currentAdSize;
        val_2 = val_2 + 1;
        this.currentAdSize = val_2;
        if(this.adSizeArray != null)
        {
                val_2 = val_2 - ((val_2 / this.adSizeArray.Length) * this.adSizeArray.Length);
            this.currentAdSize = val_2;
            this.SetLoadAddButtonText();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "RewardedVideoAdScene");
    }
    public void ChangePosition()
    {
        if(this.currentAdViewPosition == 0)
        {
            goto label_0;
        }
        
        if(this.currentAdViewPosition == 2)
        {
            goto label_1;
        }
        
        if(this.currentAdViewPosition != 1)
        {
                return;
        }
        
        this.SetAdViewPosition(adPosition:  2);
        return;
        label_0:
        this.SetAdViewPosition(adPosition:  1);
        return;
        label_1:
        this.SetAdViewPosition(adPosition:  0);
    }
    private void OnRectTransformDimensionsChange()
    {
        if((AudienceNetwork.AdView.op_Implicit(obj:  this.adView)) == false)
        {
                return;
        }
        
        if(UnityEngine.Screen.orientation == this.currentScreenOrientation)
        {
                return;
        }
        
        this.SetAdViewPosition(adPosition:  this.currentAdViewPosition);
        this.currentScreenOrientation = UnityEngine.Screen.orientation;
    }
    private void SetAdViewPosition(AudienceNetwork.AdPosition adPosition)
    {
        AudienceNetwork.AdPosition val_3;
        AudienceNetwork.AdPosition val_4;
        if(adPosition != 0)
        {
                if(adPosition != 2)
        {
                if(adPosition != 1)
        {
                return;
        }
        
            val_3 = 1;
            val_4 = 1;
        }
        else
        {
                val_3 = 2;
            val_4 = 2;
        }
        
            bool val_1 = this.adView.Show(position:  val_3);
        }
        else
        {
                bool val_2 = this.adView.Show(y:  100);
            val_4 = 0;
        }
        
        this.currentAdViewPosition = val_4;
    }
    public AdViewScene()
    {
        if((System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != null)
        {
                if(X0 == false)
        {
            goto label_6;
        }
        
        }
        
        this.adSizeArray = null;
        return;
        label_6:
    }
    private void <LoadBanner>b__10_0()
    {
        this.currentScreenOrientation = UnityEngine.Screen.orientation;
        bool val_2 = this.adView.Show(y:  100);
        string val_5 = "Banner loaded and is " + (this.adView.IsValid() != true) ? "valid" : "invalid"((this.adView.IsValid() != true) ? "valid" : "invalid") + ".";
        UnityEngine.Debug.Log(message:  "Banner loaded");
    }
    private void <LoadBanner>b__10_1(string error)
    {
        string val_1 = "Banner failed to load with error: "("Banner failed to load with error: ") + error;
        UnityEngine.Debug.Log(message:  "Banner failed to load with error: "("Banner failed to load with error: ") + error);
    }
    private void <LoadBanner>b__10_2()
    {
        UnityEngine.Debug.Log(message:  "Banner logged impression.");
    }
    private void <LoadBanner>b__10_3()
    {
        UnityEngine.Debug.Log(message:  "Banner clicked.");
    }

}
