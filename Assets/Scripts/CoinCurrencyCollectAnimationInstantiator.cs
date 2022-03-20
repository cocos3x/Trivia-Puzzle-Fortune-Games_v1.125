using UnityEngine;
public class CoinCurrencyCollectAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(W9 != 0)
        {
                ThemesHandler val_1 = App.ThemesHandler;
            return val_1.theme.CoinCurrencyStatViewPrefab_anchored;
        }
        
        ThemesHandler val_2 = App.ThemesHandler;
        return val_2.theme.CoinCurrencyStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.CoinCurrencyParticleSystem;
    }
    protected override bool ShouldCreate()
    {
        return true;
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9B0;
    }
    public CoinCurrencyCollectAnimationInstantiator()
    {
    
    }

}
