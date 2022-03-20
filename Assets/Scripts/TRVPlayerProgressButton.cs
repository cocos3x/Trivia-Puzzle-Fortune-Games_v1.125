using UnityEngine;
public class TRVPlayerProgressButton : MonoBehaviour
{
    // Methods
    private void OnEnable()
    {
        UnityEngine.UI.Button val_2 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVPlayerProgressButton::OnClick()));
    }
    private void OnClick()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVPlayerProgressWindow MetaGameBehavior::ShowUGUIMonolith<TRVPlayerProgressWindow>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public TRVPlayerProgressButton()
    {
    
    }

}
