using UnityEngine;
public class TRVStarMultiplierButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button myButton;
    private UnityEngine.UI.Text displayText;
    private System.Action doOnTap;
    
    // Methods
    private void OnEnable()
    {
        this.myButton.m_OnClick.RemoveAllListeners();
        this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVStarMultiplierButton::OnClick()));
    }
    public void Setup(string myText, System.Action onClickAction)
    {
        this.doOnTap = onClickAction;
        if(this.displayText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void SetSelectedUI(bool selected)
    {
        if(this.myButton != null)
        {
                selected = (~selected) & 1;
            this.myButton.interactable = selected;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnClick()
    {
        if(this.doOnTap == null)
        {
                return;
        }
        
        this.doOnTap.Invoke();
    }
    public TRVStarMultiplierButton()
    {
    
    }

}
