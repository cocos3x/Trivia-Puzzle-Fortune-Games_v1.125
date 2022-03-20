using UnityEngine;
private sealed class HorizontalRecyclingSystem.<InitCoroutine>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public HorizontalRecyclingSystem <>4__this;
    public int startPos;
    public bool centered;
    public System.Action onInitialized;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public HorizontalRecyclingSystem.<InitCoroutine>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_11;
        float val_12;
        int val_13;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.SetLeftAnchor(rectTransform:  null);
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        val_11 = val_1.x;
        val_12 = val_1.z;
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_11, y = val_1.y, z = val_12});
        this.<>4__this.anchoredPosition = new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
        val_13 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_13;
        return (bool)val_13;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.SetRecyclingBounds();
        this.<>4__this.currentItemCount = this.startPos;
        this.<>4__this.CreateCellPool();
        this.<>4__this.leftMostCellIndex = 0;
        this.<>4__this.rightMostCellIndex = W9 - 1;
        float val_10 = (float)W21;
        val_10 = val_10 / ((float)this.<>4__this._rows);
        val_11 = val_10 * ((float)UnityEngine.Mathf.CeilToInt(f:  val_10));
        UnityEngine.Vector2 val_5 = X21.sizeDelta;
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_11, y:  val_5.y);
        float val_11 = val_6.x;
        X21.sizeDelta = new UnityEngine.Vector2() {x = val_11, y = val_6.y};
        if(this.centered != false)
        {
                val_11 = val_11 * (-0.5f);
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_11, y:  0f);
            UnityEngine.Vector2 val_8 = X21.anchoredPosition;
            val_12 = val_7.x;
            val_11 = val_8.x;
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_11, y = val_8.y}, b:  new UnityEngine.Vector2() {x = val_12, y = val_7.y});
            X21.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        }
        
        this.<>4__this.SetLeftAnchor(rectTransform:  typeof(HorizontalRecyclingSystem).__il2cppRuntimeField_188);
        val_13 = this.onInitialized;
        if(val_13 == null)
        {
                return (bool)val_13;
        }
        
        val_13.Invoke();
        label_2:
        val_13 = 0;
        return (bool)val_13;
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
