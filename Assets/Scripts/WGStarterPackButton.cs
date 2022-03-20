using UnityEngine;
public class WGStarterPackButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.GameObject opposingButton;
    private bool wasActive;
    private bool thisWasActive;
    
    // Methods
    private void OnEnable()
    {
        if(WGStarterPackController.featureRelavent != false)
        {
                this.thisWasActive = true;
            FrameSkipper val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
            val_3.updateLogic = new System.Action(object:  this, method:  System.Void WGStarterPackButton::UpdateTimerText());
            UnityEngine.UI.Button val_6 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
            val_6.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGStarterPackButton::OnClick()));
            if(this.opposingButton == 0)
        {
                return;
        }
        
            this.wasActive = this.opposingButton.activeSelf;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void UpdateTimerText()
    {
        if(WGStarterPackController.featureRelavent != false)
        {
                if(this.opposingButton != 0)
        {
                this.opposingButton.SetActive(value:  false);
        }
        
            System.TimeSpan val_4 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
            string val_5 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_4._ticks}, formatted:  true);
            this = ???;
        }
        else
        {
                this.gameObject.SetActive(value:  false);
        }
    
    }
    private void OnApplicationPause(bool paused)
    {
        if(WGStarterPackController.featureRelavent != false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnPurchaseCompleted()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnClick()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
        WGStarterPackController val_3 = MonoSingleton<WGStarterPackController>.Instance;
        val_3._ap = 48;
    }
    private void OnDisable()
    {
        if(this.opposingButton == 0)
        {
                return;
        }
        
        if(this.thisWasActive == false)
        {
                return;
        }
        
        this.opposingButton.SetActive(value:  this.wasActive);
    }
    public WGStarterPackButton()
    {
    
    }

}
