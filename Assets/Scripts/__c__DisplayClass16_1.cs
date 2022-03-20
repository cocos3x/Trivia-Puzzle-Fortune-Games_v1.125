using UnityEngine;
private sealed class GiftRewardUI.<>c__DisplayClass16_1
{
    // Fields
    public UnityEngine.GameObject petCardGroup;
    public WADPets.WADPet pet;
    public float endProgressValue;
    public WADPets.WADPetUpgradeRequirement upgradeRequirement;
    
    // Methods
    public GiftRewardUI.<>c__DisplayClass16_1()
    {
    
    }
    internal void <CreateRewardReveals>b__3()
    {
        this.petCardGroup.GetComponent<GiftRewardUI_PetCard>().OnPetCardRewardAction(pet:  this.pet, endProgressValue:  this.endProgressValue, upgradeRequirement:  this.upgradeRequirement);
    }
    internal void <CreateRewardReveals>b__4()
    {
        WADPets.WADPet val_7;
        if((this.endProgressValue.Equals(obj:  1f)) == false)
        {
            goto label_1;
        }
        
        val_7 = this.pet;
        if(this.pet.IsUnlocked == false)
        {
            goto label_3;
        }
        
        label_1:
        WADPets.WADPet val_3 = MonoSingleton<WADPetsManager>.Instance.GetAnyUpgradeablePet(onlyUnlockable:  true);
        val_7 = val_3;
        if(val_3 == null)
        {
            goto label_7;
        }
        
        label_3:
        MonoSingleton<WADPetsManager>.Instance.ShowPetUnlockedPopup(pet:  val_7);
        label_7:
        if(WADPetsManager.IsAnyPetHungry() == false)
        {
                return;
        }
        
        MonoSingleton<WADPetsManager>.Instance.ShowFeedYourPetsPopup();
    }

}
