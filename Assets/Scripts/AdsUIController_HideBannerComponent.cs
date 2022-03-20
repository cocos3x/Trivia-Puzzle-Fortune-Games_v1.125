using UnityEngine;
public class AdsUIController_HideBannerComponent : MonoBehaviour
{
    // Methods
    private void OnEnable()
    {
        if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
                return;
        }
        
        AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
        int val_5 = val_3.bannerAdsUnblocked;
        val_5 = val_5 + 1;
        val_3.bannerAdsUnblocked = val_5;
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    private void OnDisable()
    {
        if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
                return;
        }
        
        AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
        int val_5 = val_3.bannerAdsUnblocked;
        val_5 = val_5 - 1;
        val_3.bannerAdsUnblocked = val_5;
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    public AdsUIController_HideBannerComponent()
    {
    
    }

}
