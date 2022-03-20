using UnityEngine;
public class CurrencyStatViewInstantiator : StatViewInstantiatior
{
    // Fields
    private CurrencyStatViewInstantiator.CurrencyType currencyType;
    
    // Methods
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        if(this.currencyType > 4)
        {
                return 0;
        }
        
        var val_27 = 32562240 + (this.currencyType) << 2;
        val_27 = val_27 + 32562240;
        goto (32562240 + (this.currencyType) << 2 + 32562240);
    }
    protected override void SetupAnimatedElements()
    {
    
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        UnityEngine.RectTransform val_10 = rectTransform;
        if(this.currencyType > 4)
        {
                return;
        }
        
        var val_10 = 32562260 + (this.currencyType) << 2;
        val_10 = val_10 + 32562260;
        goto (32562260 + (this.currencyType) << 2 + 32562260);
    }
    public CurrencyStatViewInstantiator()
    {
    
    }

}
