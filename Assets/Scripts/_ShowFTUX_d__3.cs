using UnityEngine;
private sealed class PowerupEarthquakeButton.<ShowFTUX>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public BlockPuzzleMagic.PowerupEarthquakeButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PowerupEarthquakeButton.<ShowFTUX>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_18;
        int val_19;
        var val_20;
        object val_22;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_18 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  0.65f);
        val_19 = 1;
        this.<>2__current = val_18;
        this.<>1__state = val_19;
        return (bool)val_19;
        label_2:
        this.<>1__state = 0;
        val_20 = null;
        val_20 = null;
        val_18 = PowerupEarthquakeButton.<>c.<>9__3_0;
        if(val_18 == null)
        {
                System.Func<System.Boolean> val_2 = null;
            val_18 = val_2;
            val_2 = new System.Func<System.Boolean>(object:  PowerupEarthquakeButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PowerupEarthquakeButton.<>c::<ShowFTUX>b__3_0());
            PowerupEarthquakeButton.<>c.<>9__3_0 = val_18;
        }
        
        UnityEngine.WaitUntil val_3 = null;
        val_22 = val_3;
        val_3 = new UnityEngine.WaitUntil(predicate:  val_2);
        this.<>2__current = val_22;
        this.<>1__state = 2;
        val_19 = 1;
        return (bool)val_19;
        label_1:
        this.<>1__state = 0;
        BBLTooltip val_5 = UnityEngine.Object.Instantiate<BBLTooltip>(original:  this.<>4__this.prefabTooltip, parent:  this.<>4__this.transform);
        this.<>4__this.earthquakeTooltipInstance = val_5;
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  0f, y:  -98f);
        if(null != null)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_5.transform.anchoredPosition = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        this.<>4__this.earthquakeTooltipInstance.SetOnClicked(onClicked:  new System.Action(object:  this.<>4__this, method:  System.Void BlockPuzzleMagic.PowerupEarthquakeButton::<ShowFTUX>b__3_1()));
        UnityEngine.Color val_10 = UnityEngine.Color.clear;
        System.Nullable<UnityEngine.Color> val_11 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        UnityEngine.Transform[] val_15 = new UnityEngine.Transform[1];
        val_18 = val_15;
        val_22 = this.<>4__this.earthquakeTooltipInstance.transform;
        val_18[0] = val_22;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_15);
        label_3:
        val_19 = 0;
        return (bool)val_19;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
