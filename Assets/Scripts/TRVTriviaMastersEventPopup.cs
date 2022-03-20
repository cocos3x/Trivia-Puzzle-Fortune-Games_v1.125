using UnityEngine;
public class TRVTriviaMastersEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Image progressBar;
    
    // Methods
    public void SetupUI(string progressText, float progressValue)
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVTriviaMastersEventPopup::Close()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVTriviaMastersEventPopup::Close()));
        this.progressBar.fillAmount = progressValue;
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if((TriviaMastersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        TriviaMastersEventHandler.<Instance>k__BackingField.OnMyEventPopupClosed();
    }
    public TRVTriviaMastersEventPopup()
    {
    
    }

}
