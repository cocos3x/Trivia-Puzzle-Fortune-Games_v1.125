using UnityEngine;
public class FPHPowerupRemoveButton : FPHPowerupButton
{
    // Properties
    protected override int Cost { get; }
    protected override string TrackingSource { get; }
    
    // Methods
    protected override int get_Cost()
    {
        GameBehavior val_1 = App.getBehavior;
        return (int);
    }
    protected override string get_TrackingSource()
    {
        return "Remove Hint";
    }
    protected override bool ExecutePowerup()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        goto typeof(FPHGameplayController).__il2cppRuntimeField_1B0;
    }
    public override void Initialize()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.interactable = ((val_1.<metaGameBehavior>k__BackingField) >= typeof(MetaGameBehavior).__il2cppRuntimeField_5FC) ? 1 : 0;
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void FPHPowerupRemoveButton::<Initialize>b__5_0()), count:  1);
    }
    public FPHPowerupRemoveButton()
    {
    
    }
    private void <Initialize>b__5_0()
    {
        DynamicToolTip val_2 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_2.transform.SetParent(p:  this.gameObject.transform);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        val_2.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        val_2.ShowToolTip(objToToolTip:  this.gameObject, text:  "Use Remove to remove some letters from the keyboard that are not in the answer!\n\nTry it now for free!", topToolTip:  true, displayDuration:  4f, width:  800f, height:  400f, tooltipOffsetX:  0f, tooltipOffsetY:  -50f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }

}
