using UnityEngine;
public class WADPetsUIController : MonoSingleton<WADPetsUIController>
{
    // Methods
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAbilityTriggered");
    }
    public void UpdateHintButtonUI()
    {
        HintFeatureManager val_1 = MonoSingleton<HintFeatureManager>.Instance;
        val_1.<wgHbutton>k__BackingField.UpdateDisplay();
    }
    public void ShowFTUX(System.Collections.Generic.List<WADPets.WADPet> pets)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WADPetsFtuxPopup>(showNext:  true).SetupFtux(pets:  pets);
    }
    public WADPetsUIController()
    {
    
    }

}
