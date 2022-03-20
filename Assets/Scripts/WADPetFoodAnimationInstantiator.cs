using UnityEngine;
public class WADPetFoodAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(W9 != 0)
        {
                ThemesHandler val_1 = App.ThemesHandler;
            return val_1.theme.PetsFoodStatViewPrefab_anchored;
        }
        
        ThemesHandler val_2 = App.ThemesHandler;
        return val_2.theme.PetsFoodStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.PetsFoodCurrencyParticleSystem;
    }
    public WADPetFoodAnimationInstantiator()
    {
    
    }

}
