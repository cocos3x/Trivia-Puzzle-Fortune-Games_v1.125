using UnityEngine;
public class DiceRollAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(W9 != 0)
        {
                ThemesHandler val_1 = App.ThemesHandler;
            return val_1.theme.DiceRollStatViewPrefab_anchored;
        }
        
        ThemesHandler val_2 = App.ThemesHandler;
        return val_2.theme.DiceRollStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.DiceRollCurrencyParticleSystem;
    }
    public DiceRollAnimationInstantiator()
    {
    
    }

}
