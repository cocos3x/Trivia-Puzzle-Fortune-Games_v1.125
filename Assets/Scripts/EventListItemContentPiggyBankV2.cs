using UnityEngine;
public class EventListItemContentPiggyBankV2 : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.GameObject maxLabel;
    
    // Methods
    public override void SetupSlider(string sliderText, float sliderValue)
    {
        this.maxLabel.SetActive(value:  (sliderValue >= 1f) ? 1 : 0);
        goto typeof(UnityEngine.GameObject).__il2cppRuntimeField_5E0;
    }
    public EventListItemContentPiggyBankV2()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
