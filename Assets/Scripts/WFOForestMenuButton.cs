using UnityEngine;
public class WFOForestMenuButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button forestButton;
    
    // Methods
    private void Awake()
    {
        var val_7;
        UnityEngine.Events.UnityAction val_9;
        UnityEngine.UI.Button val_2 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        this.forestButton = val_2;
        if(val_2 == 0)
        {
                this.enabled = false;
            return;
        }
        
        if(WordForest.WFOForestManager.IsFeatureUnlocked != true)
        {
                this.forestButton.interactable = false;
            this.gameObject.SetActive(value:  false);
        }
        
        val_7 = null;
        val_7 = null;
        val_9 = WFOForestMenuButton.<>c.<>9__1_0;
        if(val_9 == null)
        {
                UnityEngine.Events.UnityAction val_6 = null;
            val_9 = val_6;
            val_6 = new UnityEngine.Events.UnityAction(object:  WFOForestMenuButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOForestMenuButton.<>c::<Awake>b__1_0());
            WFOForestMenuButton.<>c.<>9__1_0 = val_9;
        }
        
        this.forestButton.m_OnClick.AddListener(call:  val_6);
    }
    public WFOForestMenuButton()
    {
    
    }

}
