using UnityEngine;
private sealed class WFOWordChestDisplay.<BeginChestFtuxFlow>d__59 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordForest.WFOWordChestDisplay <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOWordChestDisplay.<BeginChestFtuxFlow>d__59(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_11;
        int val_12;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.Color val_2 = UnityEngine.Color.clear;
        System.Nullable<UnityEngine.Color> val_3 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        val_11 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
        val_11 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
        val_11 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
        val_11 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 184);
        val_12 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1.35f);
        this.<>1__state = val_12;
        return (bool)val_12;
        label_1:
        this.<>1__state = 0;
        UnityEngine.Coroutine val_9 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.DoNewChestAnimationSequence(isFtux:  true));
        label_2:
        val_12 = 0;
        return (bool)val_12;
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
