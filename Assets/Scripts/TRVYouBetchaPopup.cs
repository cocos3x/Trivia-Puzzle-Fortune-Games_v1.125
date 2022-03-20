using UnityEngine;
public class TRVYouBetchaPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button okayButton;
    private UnityEngine.UI.Text topText;
    private UnityEngine.UI.Text descText;
    
    // Methods
    private void OnEnable()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVYouBetchaPopup::Close()));
        this.okayButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVYouBetchaPopup::Close()));
        string val_3 = Localization.Localize(key:  "you_betcha_event_popup_prompt", defaultValue:  "Know it all?", useSingularKey:  false);
        float val_6 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 48;
        val_6 = val_6 + 1f;
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "you_betcha_event_popup", defaultValue:  "Earn {0}x more coins\nby betting at the start\nof select levels!", useSingularKey:  false), arg0:  val_6);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    public TRVYouBetchaPopup()
    {
    
    }

}
