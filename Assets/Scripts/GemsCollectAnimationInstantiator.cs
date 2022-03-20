using UnityEngine;
public class GemsCollectAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(W9 != 0)
        {
                ThemesHandler val_1 = App.ThemesHandler;
            return val_1.theme.GemCurrencyStatViewPrefab_anchored;
        }
        
        ThemesHandler val_2 = App.ThemesHandler;
        return val_2.theme.GemCurrencyStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.GemCurrencyParticleSystem;
    }
    protected override bool ShouldCreate()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_860;
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9C0;
    }
    public GemsCollectAnimationInstantiator()
    {
    
    }

}
