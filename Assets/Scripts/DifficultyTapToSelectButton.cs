using UnityEngine;
public class DifficultyTapToSelectButton : MonoBehaviour
{
    // Fields
    private DifficultyMode mode;
    private UnityEngine.UI.Button selectButton;
    private UnityEngine.UI.Text selectButtonText;
    private UnityEngine.UI.Image overlayImg;
    private UnityEngine.Sprite selectedSp;
    private UnityEngine.Sprite unselectedSp;
    
    // Methods
    public void Setup()
    {
        DifficultySettingManager val_1 = MonoSingleton<DifficultySettingManager>.Instance;
        var val_2 = (this.mode == (val_1.<Setting>k__BackingField.Mode)) ? 56 : 64;
        this.overlayImg.sprite = null;
        UnityEngine.Color val_4 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  (this.mode == (val_1.<Setting>k__BackingField.Mode)) ? 1f : 0.2f);
        this.overlayImg.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        bool val_5 = (this.mode != (val_1.<Setting>k__BackingField.Mode)) ? 1 : 0;
        this.overlayImg.raycastTarget = val_5;
        this.selectButton.interactable = val_5;
        string val_8 = Localization.Localize(key:  (this.mode == (val_1.<Setting>k__BackingField.Mode)) ? "selected_upper" : "tap_to_select_upper", defaultValue:  (this.mode == (val_1.<Setting>k__BackingField.Mode)) ? "SELECTED" : "TAP TO SELECT", useSingularKey:  false);
    }
    public DifficultyTapToSelectButton()
    {
    
    }

}
