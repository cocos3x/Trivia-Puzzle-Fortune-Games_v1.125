using UnityEngine;
public class FPHQotdButton : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.GameObject indicatorBadge;
    private UnityEngine.UI.Text playText;
    private UGUINetworkedButton button;
    
    // Properties
    protected override int UnlockLevel { get; }
    protected override bool FeatureHidden { get; }
    
    // Methods
    protected override int get_UnlockLevel()
    {
        this.UpdateUI();
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.qotdUnlockLevel;
    }
    protected override bool get_FeatureHidden()
    {
        bool val_2 = MonoSingleton<FPHPhraseOfTheDayController>.Instance.IsFeatureEnabled();
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    private void Awake()
    {
        this.button = this.gameObject.GetComponent<UGUINetworkedButton>();
        AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHQotdButton::OnClick()));
    }
    private void OnClick()
    {
        this.Play();
    }
    private void Play()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public FPHQotdPopup MetaGameBehavior::ShowUGUIMonolith<FPHQotdPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void UpdateUI()
    {
        bool val_3 = MonoSingleton<FPHPhraseOfTheDayController>.Instance.IsEligible();
        this.button.interactable = val_3;
        this.indicatorBadge.SetActive(value:  val_3);
    }
    public FPHQotdButton()
    {
    
    }

}
