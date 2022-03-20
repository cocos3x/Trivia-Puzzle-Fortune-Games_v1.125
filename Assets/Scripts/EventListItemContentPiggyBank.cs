using UnityEngine;
public class EventListItemContentPiggyBank : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.GameObject bankFullGlow;
    
    // Methods
    public override void SetupSlider(string sliderText, float sliderValue)
    {
        this.SetupSlider(sliderText:  sliderText, sliderValue:  sliderValue);
        if(this.bankFullGlow != 0)
        {
                this.bankFullGlow.SetActive(value:  (sliderValue >= 1f) ? 1 : 0);
        }
        
        if(PiggyBankV2Handler.minDowngradeTier == 0)
        {
                return;
        }
        
        this = ???;
        goto mem[7094576787992085536];
    }
    public EventListItemContentPiggyBank()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
