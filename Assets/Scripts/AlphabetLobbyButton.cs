using UnityEngine;
public class AlphabetLobbyButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Button lockedButton;
    private UnityEngine.GameObject lockIcon;
    private UnityEngine.UI.Text lockText;
    private UnityEngine.GameObject lockedTooltip;
    
    // Methods
    private void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AlphabetLobbyButton::onClick_Button()));
    }
    private void onClick_Button()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionPopup>(showNext:  false);
    }
    private void OnDeferredReady()
    {
        var val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<Alphabet2Manager>.Instance) == 0))
        {
            goto label_14;
        }
        
        GameEcon val_4 = App.getGameEcon;
        if(val_4.ab_unlockLevel == 1)
        {
            goto label_14;
        }
        
        val_8 = null;
        if(Alphabet2Manager.IsAvailable == false)
        {
            goto label_17;
        }
        
        this.gameObject.SetActive(value:  true);
        val_9 = 1;
        goto label_20;
        label_14:
        this.gameObject.SetActive(value:  false);
        return;
        label_17:
        val_9 = 0;
        label_20:
        this.button.interactable = false;
    }
    private void OnEnable()
    {
        this.OnDeferredReady();
    }
    public AlphabetLobbyButton()
    {
    
    }

}
