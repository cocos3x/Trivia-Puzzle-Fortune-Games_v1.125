using UnityEngine;
public class WGLobbyRightColUIController : MonoBehaviour
{
    // Fields
    private bool isLevelComplete;
    private UnityEngine.GameObject petsButton;
    private UnityEngine.GameObject removeAdsButton;
    
    // Methods
    private void OnEnable()
    {
        if(this.isLevelComplete != false)
        {
                if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
            val_3.levelCompleteRightColUIController = this;
        }
        
        }
        
        this.ToggleTopSlotButtons();
    }
    public void ToggleTopSlotButtons()
    {
        if(this.removeAdsButton == 0)
        {
                return;
        }
        
        this.removeAdsButton.SetActive(value:  AdsManager.ShowAdsControlButtons(fromSettings:  false));
        if(this.petsButton == 0)
        {
                return;
        }
        
        this.petsButton.SetActive(value:  (~this.removeAdsButton.activeSelf) & 1);
    }
    public WGLobbyRightColUIController()
    {
    
    }

}
