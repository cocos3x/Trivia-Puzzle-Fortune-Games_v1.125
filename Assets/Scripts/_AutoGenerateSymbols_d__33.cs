using UnityEngine;
private sealed class WFOEventPointGainAnimationV2.<AutoGenerateSymbols>d__33 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int count;
    public WFOEventPointGainAnimationV2 <>4__this;
    private float <scale>5__2;
    private int <i>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOEventPointGainAnimationV2.<AutoGenerateSymbols>d__33(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WFOEventPointGainAnimationV2 val_19;
        int val_20;
        int val_21;
        UnityEngine.Transform val_22;
        int val_23;
        val_19 = this.<>4__this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        if(this.count < 1)
        {
            goto label_3;
        }
        
        UnityEngine.Vector2 val_2 = this.<>4__this.progress.icon.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_4 = this.<>4__this.prefabPointImage.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_4.x = val_2.x / val_4.x;
        this.<scale>5__2 = val_4.x;
        val_20 = 10;
        val_21 = 0;
        this.count = UnityEngine.Mathf.Min(a:  10, b:  this.count);
        this.<i>5__3 = 0;
        goto label_12;
        label_1:
        val_20 = this.count;
        this.<>1__state = 0;
        val_21 = (this.<i>5__3) + 1;
        this.<i>5__3 = val_21;
        label_12:
        if(val_21 < (val_20 - 1))
        {
                UnityEngine.Transform val_7 = UnityEngine.Object.Instantiate<UnityEngine.Transform>(original:  this.<>4__this.symbolPrefab, parent:  this.<>4__this.symbolParent);
            val_22 = val_7;
            val_7.position = new UnityEngine.Vector3() {x = this.<>4__this.originalCentralSymbolPos};
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, d:  this.<>4__this.symbolScale);
            val_22.localScale = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            val_23 = 1;
            val_22.gameObject.SetActive(value:  true);
            DG.Tweening.Sequence val_11 = val_19.MoveSymbol(scale:  this.<scale>5__2, trans:  val_22, dest:  this.<>4__this.target, destroy:  true);
            UnityEngine.WaitForSeconds val_12 = null;
            val_19 = val_12;
            val_12 = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this.symbolInterval);
            this.<>2__current = val_19;
            this.<>1__state = val_23;
            return (bool)val_23;
        }
        
        DG.Tweening.Sequence val_13 = val_19.MoveSymbol(scale:  this.<scale>5__2, trans:  this.<>4__this.centralSymbolTransform, dest:  this.<>4__this.target, destroy:  false);
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_13, callback:  new DG.Tweening.TweenCallback(object:  val_19, method:  System.Void WFOEventPointGainAnimationV2::<AutoGenerateSymbols>b__33_0()));
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_13, interval:  0.5f);
        DG.Tweening.TweenCallback val_17 = null;
        val_22 = val_17;
        val_17 = new DG.Tweening.TweenCallback(object:  val_19, method:  System.Void WFOEventPointGainAnimationV2::<AutoGenerateSymbols>b__33_1());
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_13, action:  val_17);
        label_3:
        val_23 = 0;
        return (bool)val_23;
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
