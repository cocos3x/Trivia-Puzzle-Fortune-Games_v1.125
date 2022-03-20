using UnityEngine;
public class FeatureMenuItem : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<UnityEngine.UI.Image> actionableIcons;
    private UnityEngine.UI.Image featureIcon;
    private UnityEngine.UI.Text featureNameText;
    private UnityEngine.UI.Text featureUnlockLevel;
    private UnityEngine.GameObject lockImage;
    private bool itemInteractable;
    private System.Action myClickAction;
    
    // Methods
    public virtual void Setup(WGFeatureMenu.FeatureMenuItemConfig config)
    {
        var val_16;
        bool val_17;
        var val_18;
        this.featureIcon.sprite = config.itemSprite;
        this.itemInteractable = config.enabled;
        this.myClickAction = config.onClickAction;
        if(W9 > config.customActionableIcons)
        {
                UnityEngine.Debug.LogError(message:  "Actionable icons setup needed in the Feature Menu Item.");
            return;
        }
        
        if(W9 < 1)
        {
            goto label_8;
        }
        
        if(config.customActionableIcons < 1)
        {
            goto label_27;
        }
        
        var val_19 = 4;
        do
        {
            System.Collections.Generic.List<UnityEngine.Sprite> val_18 = config.customActionableIcons;
            var val_1 = val_19 - 4;
            val_18 = val_18 - 1;
            if(val_1 >= config.customActionableIcons)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_1 > (long)val_18)
        {
                UnityEngine.GameObject val_2 = this.actionableIcons.gameObject;
            val_16 = 0;
        }
        else
        {
                if(val_1 >= config.customActionableIcons)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.actionableIcons.sprite = config.itemSprite;
            if(val_1 >= config.customActionableIcons)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_17 = config.enabled;
            if(val_17 != false)
        {
                val_17 = config.featureActionable;
        }
        
        }
        
            0.gameObject.SetActive(value:  (val_17 == true) ? 1 : 0);
            val_19 = val_19 + 1;
        }
        while((val_19 - 3) < val_17);
        
        goto label_27;
        label_8:
        if(config.customActionableIcons < 1)
        {
            goto label_27;
        }
        
        UnityEngine.GameObject val_6 = this.featureIcon.gameObject;
        if(config.enabled == false)
        {
            goto label_29;
        }
        
        var val_7 = (config.featureActionable == true) ? 1 : 0;
        if(val_6 != null)
        {
            goto label_30;
        }
        
        label_29:
        val_18 = 0;
        label_30:
        val_6.SetActive(value:  false);
        label_27:
        this.lockImage.gameObject.SetActive(value:  (config.enabled == false) ? 1 : 0);
        string val_10 = config.featureNameText.ToUpper();
        if(config.enabled != true)
        {
                string val_11 = System.String.Format(format:  "LVL {0}", arg0:  config.featureUnlockLevel);
        }
        
        int val_20 = config.featureUnlockLevel;
        val_20 = val_20 >> 31;
        this.featureUnlockLevel.transform.parent.gameObject.SetActive(value:  val_20 ^ 1);
        UnityEngine.UI.Button val_16 = this.GetComponent<UnityEngine.UI.Button>();
        val_16.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FeatureMenuItem::OnPressed()));
    }
    private void OnPressed()
    {
        if(this.itemInteractable == false)
        {
                return;
        }
        
        if(this.myClickAction == null)
        {
                return;
        }
        
        this.myClickAction.Invoke();
    }
    public FeatureMenuItem()
    {
    
    }

}
