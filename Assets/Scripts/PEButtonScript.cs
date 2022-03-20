using UnityEngine;
public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Fields
    private UnityEngine.UI.Button myButton;
    public ButtonTypes ButtonType;
    
    // Methods
    private void Start()
    {
        this.myButton = this.gameObject.GetComponent<UnityEngine.UI.Button>();
    }
    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        UICanvasManager.GlobalAccess.MouseOverButton = true;
        UICanvasManager.GlobalAccess.UpdateToolTip(toolTipType:  this.ButtonType);
    }
    public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        UICanvasManager.GlobalAccess.MouseOverButton = false;
        UICanvasManager.GlobalAccess.ClearToolTip();
    }
    public void OnButtonClicked()
    {
        UICanvasManager.GlobalAccess.UIButtonClick(buttonTypeClicked:  this.ButtonType);
    }
    public PEButtonScript()
    {
    
    }

}
