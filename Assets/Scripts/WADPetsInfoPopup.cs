using UnityEngine;
public class WADPetsInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text description_4;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsInfoPopup::Close()));
    }
    private void OnEnable()
    {
        var val_3 = null;
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "wadpets_info_desc_4", defaultValue:  "• Each food feeds all pets for {0} hours.", useSingularKey:  false), arg0:  WADPets.WADPetsEcon.FedDurationHours);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WADPetsInfoPopup()
    {
    
    }

}
