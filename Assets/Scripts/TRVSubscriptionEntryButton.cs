using UnityEngine;
public class TRVSubscriptionEntryButton : MonoBehaviour
{
    // Fields
    public UGUINetworkedButton targetButton;
    private System.Action<bool> OnConnectionClick;
    private bool awaitingPing;
    private UnityEngine.CanvasGroup cg;
    private UnityEngine.UI.LayoutElement layoutElement;
    
    // Methods
    private void OnEnable()
    {
        this.layoutElement = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.LayoutElement>(gameObject:  this.gameObject);
        this.cg = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        this.targetButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void TRVSubscriptionEntryButton::onClickButton(bool result));
        FrameSkipper val_7 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_7.updateLogic = new System.Action(object:  this, method:  System.Void TRVSubscriptionEntryButton::UpdateButtonStatus());
    }
    public void onClickButton(bool result)
    {
        object val_11;
        System.Action val_12;
        int val_13;
        var val_14;
        val_11 = this;
        if(result != false)
        {
                WGSubscriptionManager._subEntryPoint = 89;
            GameBehavior val_1 = App.getBehavior;
            mem2[0] = 0;
            System.Action val_3 = null;
            val_12 = val_3;
            val_3 = new System.Action(object:  this, method:  System.Void TRVSubscriptionEntryButton::OnEnable());
            mem2[0] = val_12;
            return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_11 = val_4.<metaGameBehavior>k__BackingField;
        val_12 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_13 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_13 = val_9.Length;
        val_9[1] = "NULL";
        val_14 = null;
        val_14 = null;
        val_11.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  val_12, shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void UpdateButtonStatus()
    {
    
    }
    public TRVSubscriptionEntryButton()
    {
    
    }

}
