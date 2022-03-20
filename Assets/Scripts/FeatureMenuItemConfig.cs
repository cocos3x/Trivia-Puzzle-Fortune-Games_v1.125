using UnityEngine;
public class WGFeatureMenu.FeatureMenuItemConfig
{
    // Fields
    public System.Action onClickAction;
    public bool enabled;
    public UnityEngine.Sprite itemSprite;
    public string featureNameText;
    public int featureUnlockLevel;
    public bool featureActionable;
    public System.Collections.Generic.List<UnityEngine.Sprite> customActionableIcons;
    
    // Methods
    public WGFeatureMenu.FeatureMenuItemConfig()
    {
        this.featureNameText = "NULL";
        this.customActionableIcons = new System.Collections.Generic.List<UnityEngine.Sprite>();
    }

}
