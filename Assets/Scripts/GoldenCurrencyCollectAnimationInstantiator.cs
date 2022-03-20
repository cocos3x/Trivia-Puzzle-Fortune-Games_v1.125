using UnityEngine;
public class GoldenCurrencyCollectAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(W9 != 0)
        {
                ThemesHandler val_1 = App.ThemesHandler;
            return val_1.theme.GoldenCurrencyStatViewPrefab_anchored;
        }
        
        ThemesHandler val_2 = App.ThemesHandler;
        return val_2.theme.GoldenCurrencyStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.GoldCurrencyParticleSystem;
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9D0;
    }
    public GoldenCurrencyCollectAnimationInstantiator()
    {
    
    }

}
