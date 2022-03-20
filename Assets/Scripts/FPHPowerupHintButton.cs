using UnityEngine;
public class FPHPowerupHintButton : FPHPowerupButton
{
    // Fields
    private ParticlePositionToPoint prefabEfxHint;
    
    // Properties
    protected override int Cost { get; }
    protected override string TrackingSource { get; }
    
    // Methods
    protected override int get_Cost()
    {
        var val_4;
        if(val_1.currentGame == null)
        {
                return (int)FPHGameplayController.Instance;
        }
        
        FPHGameplayController val_2 = FPHGameplayController.Instance;
        val_4 = 0;
        return (int)FPHGameplayController.Instance;
    }
    protected override string get_TrackingSource()
    {
        return "Hint";
    }
    protected override bool ExecutePowerup()
    {
        if(FPHGameplayController.Instance.DoPowerupHint() == null)
        {
                return (bool)(null > 0) ? 1 : 0;
        }
        
        FPHGameplayUIController val_3 = MonoSingleton<FPHGameplayUIController>.Instance;
        if(1152921515944123344 < 1)
        {
                return (bool)(null > 0) ? 1 : 0;
        }
        
        var val_15 = 0;
        do
        {
            if(1152921504903651328 <= val_15)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(44493336 <= (public System.Object System.Runtime.Remoting.Messaging.RemotingSurrogate::SetObjectData(object obj, System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext sc, System.Runtime.Serialization.ISurrogateSelector selector)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            ParticlePositionToPoint val_6 = UnityEngine.Object.Instantiate<ParticlePositionToPoint>(original:  this.prefabEfxHint, parent:  this.transform);
            .slotEfx = val_6;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.zero;
            val_6.transform.localPosition = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.one;
            (FPHPowerupHintButton.<>c__DisplayClass5_0)[1152921515981198432].slotEfx.transform.localScale = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
            (FPHPowerupHintButton.<>c__DisplayClass5_0)[1152921515981198432].slotEfx.attractionPoint = mem[-9223371945816426696].transform;
            DG.Tweening.Tween val_13 = DG.Tweening.DOVirtual.DelayedCall(delay:  2f, callback:  new DG.Tweening.TweenCallback(object:  new FPHPowerupHintButton.<>c__DisplayClass5_0(), method:  System.Void FPHPowerupHintButton.<>c__DisplayClass5_0::<ExecutePowerup>b__0()), ignoreTimeScale:  true);
            val_15 = val_15 + 1;
        }
        while(val_15 < null);
        
        return (bool)(null > 0) ? 1 : 0;
    }
    public override void Initialize()
    {
        this.Initialize();
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.interactable = ((val_1.<metaGameBehavior>k__BackingField) >= typeof(MetaGameBehavior).__il2cppRuntimeField_5EC) ? 1 : 0;
        this.gameObject.SetActive(value:  true);
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void FPHPowerupHintButton::<Initialize>b__6_0()), count:  1);
    }
    public FPHPowerupHintButton()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }
    private void <Initialize>b__6_0()
    {
        DynamicToolTip val_2 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_2.transform.SetParent(p:  this.gameObject.transform);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        val_2.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        val_2.ShowToolTip(objToToolTip:  this.gameObject, text:  Localization.Localize(key:  "fph_hint_ftux", defaultValue:  "Use a Hint to reveal a letter.\n\nTry it now for free!", useSingularKey:  false), topToolTip:  true, displayDuration:  4f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  -50f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }

}
