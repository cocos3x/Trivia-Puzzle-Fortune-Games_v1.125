using UnityEngine;
public class ReturnGameGiftPopup : MonoBehaviour
{
    // Fields
    protected UGUINetworkedButtonMultiGraphic collectButton;
    
    // Methods
    protected void Awake()
    {
        mem2[0] = new System.Action<System.Boolean>(object:  this, method:  typeof(ReturnGameGiftPopup).__il2cppRuntimeField_188);
    }
    protected void Start()
    {
        goto typeof(ReturnGameGiftPopup).__il2cppRuntimeField_170;
    }
    public virtual void Setup(ReturnGameGiftReward reward)
    {
    
    }
    protected virtual void OnConnectionClick(bool connected)
    {
    
    }
    protected virtual void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public ReturnGameGiftPopup()
    {
    
    }

}
