using UnityEngine;
public class UnlockableUIAlphabet : WGUnlockableUIElement
{
    // Properties
    protected override int UnlockLevel { get; }
    protected override bool FeatureHidden { get; }
    
    // Methods
    protected override int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ab_unlockLevel;
    }
    protected override bool get_FeatureHidden()
    {
        UnityEngine.Object val_10;
        GameEcon val_1 = App.getGameEcon;
        if((val_1.alphButtonDisplayLevel & 2147483648) != 0)
        {
                return true;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return true;
        }
        
        val_10 = MonoSingleton<Alphabet2Manager>.Instance;
        if(val_10 == 0)
        {
                return true;
        }
        
        GameEcon val_6 = App.getGameEcon;
        if(App.Player >= val_6.ab_unlockLevel)
        {
                return true;
        }
        
        GameEcon val_8 = App.getGameEcon;
        var val_9 = (App.Player < val_8.alphButtonDisplayLevel) ? 1 : 0;
        return true;
    }
    protected override void OnClickUnlocked()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionPopup>(showNext:  false);
    }
    public UnlockableUIAlphabet()
    {
    
    }

}
