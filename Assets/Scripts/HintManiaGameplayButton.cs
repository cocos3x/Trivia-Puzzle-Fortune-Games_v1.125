using UnityEngine;
public class HintManiaGameplayButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button hintManiaButton;
    
    // Methods
    private void OnEnable()
    {
        this.hintManiaButton.gameObject.SetActive(value:  false);
        this.hintManiaButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintManiaGameplayButton::OnButtonClicked()));
        if(HintManiaEventHandler.HINT_MANIA_ID == null)
        {
                return;
        }
        
        this.CheckShowButton();
    }
    private void OnButtonClicked()
    {
        if(HintManiaEventHandler.HINT_MANIA_ID == null)
        {
                return;
        }
        
        if((HintManiaEventHandler.HINT_MANIA_ID & 1) == 0)
        {
                return;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HintManiaEventPopup>(showNext:  false);
    }
    public void CheckShowButton()
    {
        if(HintManiaEventHandler.HINT_MANIA_ID == null)
        {
                return;
        }
        
        if((HintManiaEventHandler.HINT_MANIA_ID & 1) == 0)
        {
                return;
        }
        
        this.hintManiaButton.gameObject.SetActive(value:  HintManiaEventHandler.HINT_MANIA_ID & 1);
    }
    public HintManiaGameplayButton()
    {
    
    }

}
