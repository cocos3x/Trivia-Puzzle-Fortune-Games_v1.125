using UnityEngine;
public class BBLTooltip : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleText;
    private UnityEngine.UI.Text messageText;
    private UnityEngine.UI.Button button;
    
    // Methods
    public void SetOnClicked(System.Action onClicked)
    {
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  onClicked, method:  public System.Void System.Action::Invoke()));
    }
    public BBLTooltip()
    {
    
    }

}
