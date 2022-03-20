using UnityEngine;
public class UIParasite : MonoBehaviour
{
    // Fields
    private UIParasite.UIType toOverride;
    private string bundleName;
    private string assetName;
    
    // Methods
    public void Setup(UIParasite.UIType uiToOverride, string bundleName, string assetName)
    {
        this.toOverride = uiToOverride;
        this.bundleName = bundleName;
        this.assetName = assetName;
    }
    private void Awake()
    {
        if(this.toOverride == 0)
        {
            goto label_1;
        }
        
        if(this.toOverride == 1)
        {
            goto label_2;
        }
        
        if(this.toOverride != 2)
        {
            goto label_15;
        }
        
        this.gameObject.GetComponent<UnityEngine.UI.Text>().font = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetFontFromBundle(bundleName:  this.bundleName, fontName:  this.assetName);
        goto label_15;
        label_2:
        this.gameObject.GetComponent<UnityEngine.UI.RawImage>().texture = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetTextureFromBundle(bundleName:  this.bundleName, textureName:  this.assetName);
        goto label_15;
        label_1:
        this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetSpriteFromBundle(bundleName:  this.bundleName, spriteName:  this.assetName);
        label_15:
        UnityEngine.Object.Destroy(obj:  this);
    }
    public UIParasite()
    {
    
    }

}
