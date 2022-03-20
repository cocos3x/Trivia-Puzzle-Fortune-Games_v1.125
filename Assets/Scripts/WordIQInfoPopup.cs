using UnityEngine;
public class WordIQInfoPopup : MonoBehaviour
{
    // Fields
    private const string info_1 = "Studies have shown that playing Word Collect can help improve Your Word IQ";
    private const string info_2 = "Learn New Words, complete your collection and advance your intellectual prowess";
    private const string info_3 = "Gain more Word IQ by clearing levels accurately";
    private UnityEngine.UI.Text info;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void Start()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordIQInfoPopup::<Start>b__5_0()));
    }
    private void OnEnable()
    {
        int val_6;
        int val_7;
        string[] val_1 = new string[5];
        val_6 = val_1.Length;
        val_1[0] = Localization.Localize(key:  "word_iq_info_popup_text_1", defaultValue:  "Studies have shown that playing Word Collect can help improve Your Word IQ", useSingularKey:  false);
        val_6 = val_1.Length;
        val_1[1] = "\n\n";
        val_7 = val_1.Length;
        val_1[2] = Localization.Localize(key:  "word_iq_info_popup_text_2", defaultValue:  "Learn New Words, complete your collection and advance your intellectual prowess", useSingularKey:  false);
        val_7 = val_1.Length;
        val_1[3] = "\n\n";
        val_1[4] = Localization.Localize(key:  "word_iq_info_popup_text_3", defaultValue:  "Gain more Word IQ by clearing levels accurately", useSingularKey:  false);
        string val_5 = +val_1;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public WordIQInfoPopup()
    {
    
    }
    private void <Start>b__5_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
