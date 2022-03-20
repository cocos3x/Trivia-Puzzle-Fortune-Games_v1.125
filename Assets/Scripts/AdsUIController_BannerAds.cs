using UnityEngine;
public class AdsUIController_BannerAds : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject adsRegion;
    private UnityEngine.GameObject adsRegionCanvas;
    private bool dontResizeAgainOnceShown;
    private UnityEngine.UI.LayoutElement _BannerLayout;
    private bool hasInit;
    private const float referenceCanvasScale = 0.005208333;
    
    // Properties
    private UnityEngine.UI.LayoutElement BannerLayout { get; }
    private UnityEngine.GameObject getAdsRegionCanvas { get; }
    
    // Methods
    private UnityEngine.UI.LayoutElement get_BannerLayout()
    {
        if(this._BannerLayout != 0)
        {
                return (UnityEngine.UI.LayoutElement)this._BannerLayout;
        }
        
        if(this.adsRegion == 0)
        {
                return (UnityEngine.UI.LayoutElement)this._BannerLayout;
        }
        
        this._BannerLayout = this.adsRegion.GetComponent<UnityEngine.UI.LayoutElement>();
        return (UnityEngine.UI.LayoutElement)this._BannerLayout;
    }
    private UnityEngine.GameObject get_getAdsRegionCanvas()
    {
        UnityEngine.GameObject val_4;
        if(this.adsRegionCanvas == 0)
        {
                this.adsRegionCanvas = this.GetComponentInParent<UnityEngine.Canvas>().gameObject;
            return val_4;
        }
        
        val_4 = this.adsRegionCanvas;
        return val_4;
    }
    private void Start()
    {
        if(this.hasInit != false)
        {
                return;
        }
        
        this.Init();
    }
    private void Init()
    {
        ApplovinMaxPlugin val_1 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.BannerAdsStateChanged, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void AdsUIController_BannerAds::OnBannerStateChanged(bool isShowing)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.BannerAdsStateChanged = val_3;
        this.hasInit = true;
        return;
        label_5:
    }
    private void OnDestroy()
    {
        if((MonoSingleton<ApplovinMaxPlugin>.Instance) == 0)
        {
                return;
        }
        
        ApplovinMaxPlugin val_3 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        1152921504893161472 = val_3.BannerAdsStateChanged;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void AdsUIController_BannerAds::OnBannerStateChanged(bool isShowing)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.BannerAdsStateChanged = val_5;
        return;
        label_10:
    }
    private void OnBannerStateChanged(bool isShowing)
    {
        if(isShowing != false)
        {
                ApplovinMaxPlugin val_1 = MonoSingleton<ApplovinMaxPlugin>.Instance;
            float val_2 = val_1.bannerDimenions.height;
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            this.AdjustSize(height:  (int)val_2);
        }
        
        this.BannerAdStateChange(state:  isShowing);
    }
    private void BannerAdStateChange(bool state)
    {
        if(state == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.BannerAdsAllowed) == true)
        {
            goto label_11;
        }
        
        UnityEngine.Debug.LogWarning(message:  "AdsUIController: Heyzap had non-zero banner dimensions when !BannerAdsAllowed");
        MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
        goto label_11;
        label_1:
        if(this.dontResizeAgainOnceShown == true)
        {
            goto label_12;
        }
        
        label_11:
        state = state;
        this.adsRegion.SetActive(value:  state);
        label_12:
        AdsUIController val_4 = MonoSingleton<AdsUIController>.Instance;
        val_4.onAdToggled.Invoke();
    }
    public float GetBannerHeight()
    {
        if(this.adsRegion.activeSelf == false)
        {
                return 0f;
        }
        
        UnityEngine.UI.LayoutElement val_2 = this.BannerLayout;
        goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_340;
    }
    public float GetBannerCanvasHeight()
    {
        if(this.getAdsRegionCanvas == 0)
        {
                return (float)val_5.m_XMin.height;
        }
        
        UnityEngine.Rect val_5 = this.getAdsRegionCanvas.GetComponent<UnityEngine.RectTransform>().rect;
        return (float)val_5.m_XMin.height;
    }
    public void ShowOrHideBanner()
    {
        if(this.hasInit != true)
        {
                this.Init();
        }
        
        if((MonoSingleton<AdsUIController>.Instance.BannerAdsAllowed) != false)
        {
                MonoSingleton<ApplovinMaxPlugin>.Instance.ShowBanner();
            return;
        }
        
        if((MonoSingleton<ApplovinMaxPlugin>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
    }
    private void AdjustSize(int height)
    {
        UnityEngine.Object val_14 = this.getAdsRegionCanvas;
        if(val_14 == 0)
        {
                return;
        }
        
        val_14 = this.getAdsRegionCanvas.GetComponent<UnityEngine.UI.CanvasScaler>();
        if(val_14 == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_7 = val_14.transform.localScale;
        val_14 = UnityEngine.Screen.height;
        if(this.BannerLayout == 0)
        {
                return;
        }
        
        UnityEngine.UI.LayoutElement val_11 = this.BannerLayout;
        float val_15 = 0.005208333f;
        float val_14 = (float)val_14;
        val_14 = S9 / val_14;
        val_15 = val_15 / val_7.y;
        val_14 = val_15 * val_14;
        val_14 = val_14 * (float)height;
        var val_12 = (val_14 == Infinityf) ? (-(double)val_14) : ((double)val_14);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnCanvasResized");
    }
    public AdsUIController_BannerAds()
    {
    
    }

}
