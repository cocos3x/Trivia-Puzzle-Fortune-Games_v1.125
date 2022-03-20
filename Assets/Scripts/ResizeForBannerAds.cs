using UnityEngine;
public class ResizeForBannerAds : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform contentRT;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnCanvasResized");
    }
    private void Start()
    {
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
            UnityEngine.Events.UnityAction val_4 = null;
            1152921504893161472 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ResizeForBannerAds::OnAdToggled());
            val_3.onAdToggled.AddListener(call:  val_4);
        }
        
        this.OnCanvasResized();
    }
    private void OnDestroy()
    {
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
            UnityEngine.Events.UnityAction val_4 = null;
            1152921504893161472 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ResizeForBannerAds::OnAdToggled());
            val_3.onAdToggled.RemoveListener(call:  val_4);
        }
        
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnCanvasResized");
    }
    private void OnAdToggled()
    {
        this.OnCanvasResized();
    }
    private void OnCanvasResized()
    {
        UnityEngine.RectTransform val_17 = this;
        if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.GetBannerAdCanvasHeight()) != 0f)
        {
            goto label_9;
        }
        
        val_17 = this.contentRT;
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
        if(val_17 != null)
        {
            goto label_12;
        }
        
        label_9:
        UnityEngine.Rect val_7 = this.GetComponent<UnityEngine.RectTransform>().rect;
        val_17 = this.contentRT;
        float val_15 = val_7.m_XMin.height / (MonoSingleton<AdsUIController>.Instance.GetBannerAdCanvasHeight());
        val_15 = val_15 * (MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight());
        UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  0f, y:  val_15);
        label_12:
        val_17.offsetMin = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
    }
    public ResizeForBannerAds()
    {
    
    }

}
