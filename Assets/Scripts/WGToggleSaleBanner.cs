using UnityEngine;
public class WGToggleSaleBanner : MonoBehaviour
{
    // Fields
    public const string NO_ADS_NOTIF_PROGRESS = "noAdsNotifProg";
    private UnityEngine.CanvasGroup cg;
    
    // Methods
    private void OnEnable()
    {
        this.cg = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        FrameSkipper val_4 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_4.updateLogic = new System.Action(object:  this, method:  System.Void WGToggleSaleBanner::UpdateDisplay());
        val_4._framesToSkip = 200;
        this.UpdateDisplay();
    }
    private bool ShouldShowBanner()
    {
        UnityEngine.Object val_12;
        var val_13;
        if(WGStarterPackController.featureRelavent == false)
        {
            goto label_1;
        }
        
        label_26:
        val_13 = 1;
        return (bool)val_13;
        label_1:
        val_12 = MonoSingleton<LimitedTimeBundlesManager>.Instance;
        if(val_12 != 0)
        {
                if((MonoSingleton<LimitedTimeBundlesManager>.Instance.HaveBundlesToShow()) == true)
        {
            goto label_26;
        }
        
        }
        
        if((CPlayerPrefs.GetInt(key:  "noAdsNotifProg", defaultValue:  0)) == 2)
        {
            goto label_18;
        }
        
        val_12 = 1152921504884269056;
        if(App.Player.RemovedAds == true)
        {
            goto label_18;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_12 = val_9.<metaGameBehavior>k__BackingField;
        GameEcon val_10 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_12, knobValue:  val_10.adsControlPopupLevel)) == true)
        {
            goto label_26;
        }
        
        label_18:
        val_13 = 0;
        return (bool)val_13;
    }
    private void UpdateDisplay()
    {
        this.cg.alpha = (this.ShouldShowBanner() != true) ? 1f : 0f;
    }
    public WGToggleSaleBanner()
    {
    
    }

}
