using UnityEngine;
public class SpinsCollectAnimationInstantiator : CurrencyCollectAnimationInstantiator
{
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.SpinCurrencyStatViewPrefab;
    }
    protected override UnityEngine.GameObject GetParticleSystemPrefabFromTheme()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return val_1.theme.SpinCurrencyParticleSystem;
    }
    protected override bool ShouldCreate()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_5A0;
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9E0;
    }
    public SpinsCollectAnimationInstantiator()
    {
    
    }

}
