using UnityEngine;
public class FPHMultiplierChestChestUI : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image chestQualityImage;
    private UnityEngine.GameObject lostImage;
    private UnityEngine.GameObject incorrectSection;
    private UnityEngine.GameObject incorrectEx1;
    private UnityEngine.GameObject incorrectEx2;
    private UnityEngine.UI.Outline8 outlineComponent;
    
    // Methods
    private void Start()
    {
        UnityEngine.UI.Button val_2 = this.gameObject.AddComponent<UnityEngine.UI.Button>();
        val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHMultiplierChestChestUI::<Start>b__6_0()));
    }
    public void SetState(bool isLost, bool isFuture, int incorrects)
    {
        UnityEngine.UI.Image val_5;
        float val_6;
        if(isLost == false)
        {
            goto label_0;
        }
        
        this.lostImage.SetActive(value:  true);
        this.incorrectSection.SetActive(value:  false);
        val_5 = this.chestQualityImage;
        val_6 = 0.5f;
        goto label_3;
        label_0:
        this.lostImage.SetActive(value:  false);
        if(isFuture == false)
        {
            goto label_6;
        }
        
        this.incorrectSection.SetActive(value:  false);
        val_5 = this.chestQualityImage;
        val_6 = 0.7f;
        label_3:
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  val_6, g:  val_6, b:  val_6);
        val_5.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        this.outlineComponent.enabled = false;
        return;
        label_6:
        this.incorrectSection.SetActive(value:  true);
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.chestQualityImage.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
        this.incorrectEx1.SetActive(value:  (incorrects > 0) ? 1 : 0);
        this.incorrectEx2.SetActive(value:  (incorrects > 1) ? 1 : 0);
        this.outlineComponent.enabled = true;
    }
    public FPHMultiplierChestChestUI()
    {
    
    }
    private void <Start>b__6_0()
    {
        this.gameObject.GetComponentInParent<FPHMultiplerChestGameplayUI>().OnChestsUIButtonClicked();
    }

}
