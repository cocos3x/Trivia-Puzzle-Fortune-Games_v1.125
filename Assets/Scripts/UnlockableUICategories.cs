using UnityEngine;
public class UnlockableUICategories : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.GameObject badgeNew;
    
    // Properties
    private bool CanShowUnlockedTooltip { get; set; }
    protected override bool FeatureHidden { get; }
    protected override int UnlockLevel { get; }
    
    // Methods
    private bool get_CanShowUnlockedTooltip()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "cat_home_ulck_tip_shown", defaultValue:  0)) == 0) ? 1 : 0;
    }
    private void set_CanShowUnlockedTooltip(bool value)
    {
        value = (~value) & 1;
        UnityEngine.PlayerPrefs.SetInt(key:  "cat_home_ulck_tip_shown", value:  value);
    }
    protected override bool get_FeatureHidden()
    {
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        val_11 = this;
        GameEcon val_1 = App.getGameEcon;
        if((val_1.categoriesButtonDisplayLevel & 2147483648) != 0)
        {
            goto label_4;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_9;
        }
        
        val_12 = (~CategoryPacksManager.FeatureAvailable) & 1;
        goto label_12;
        label_4:
        val_13 = 1;
        return (bool)(val_14 == true) ? 1 : 0;
        label_9:
        val_12 = 1;
        label_12:
        val_11 = val_11;
        Player val_5 = App.Player;
        GameEcon val_6 = App.getGameEcon;
        var val_7 = (val_5 < val_6.categoriesButtonDisplayLevel) ? 1 : 0;
        if((App.Player < val_11) && (val_5 >= val_6.categoriesButtonDisplayLevel))
        {
                GameEcon val_8 = App.getGameEcon;
            val_14 = val_8.categoryShowButtonLocked ^ 1;
        }
        
        val_14 = val_14 | val_12;
        return (bool)(val_14 == true) ? 1 : 0;
    }
    protected override int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.categoryUnlockLevel;
    }
    protected override void UpdateButton()
    {
        if(true != 3)
        {
                return;
        }
        
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        bool val_5 = val_1.hasNewlyDiscoveredPacks;
        val_5 = ((val_5 == true) ? 1 : 0) ^ this.badgeNew.activeSelf;
        if(val_5 == false)
        {
                return;
        }
        
        CategoryPacksManager val_4 = MonoSingleton<CategoryPacksManager>.Instance;
        this.badgeNew.SetActive(value:  val_4.hasNewlyDiscoveredPacks);
    }
    protected override void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
        if(newState != 3)
        {
                return;
        }
        
        if(this.CanShowUnlockedTooltip == false)
        {
                return;
        }
        
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void UnlockableUICategories::<SetNewState>b__9_0()), count:  1);
    }
    protected override void OnClickUnlocked()
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 61;
        CategoryPacksMenuUI.ShowMainScreen();
    }
    public UnlockableUICategories()
    {
    
    }
    private void <SetNewState>b__9_0()
    {
        DynamicToolTip val_3 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_3.ShowToolTip(objToToolTip:  gameObject, text:  Localization.Localize(key:  "new_feature_unlocked_e_upper", defaultValue:  "NEW FEATURE UNLOCKED!", useSingularKey:  false), topToolTip:  false, displayDuration:  3.5f, width:  0f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
        val_3.CanShowUnlockedTooltip = false;
    }

}
