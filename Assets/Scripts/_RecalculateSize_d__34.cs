using UnityEngine;
private sealed class Pan.<RecalculateSize>d__34 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Pan <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Pan.<RecalculateSize>d__34(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_9;
        int val_10;
        var val_11;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_9 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_10 = 1;
        this.<>2__current = val_9;
        this.<>1__state = val_10;
        return (bool)val_10;
        label_1:
        this.<>1__state = 0;
        val_11 = 0;
        var val_9 = 0;
        label_12:
        if(val_9 >= (this.<>4__this.tileStrings))
        {
            goto label_6;
        }
        
        if(val_9 >= (this.<>4__this.tileStrings))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null != null)
        {
            goto label_10;
        }
        
        UnityEngine.Vector3 val_2 = this.<>4__this.centerPoint.TransformPoint(position:  new UnityEngine.Vector3() {x = UnityEngine.Transform.__il2cppRuntimeField_byval_arg, y = typeof(UnityEngine.Transform).__il2cppRuntimeField_24, z = typeof(UnityEngine.Transform).__il2cppRuntimeField_28});
        this.<>4__this.letterPositions.set_Item(index:  0, value:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        val_9 = val_9 + 1;
        val_11 = val_11 + 12;
        if((this.<>4__this.tileStrings) != null)
        {
            goto label_12;
        }
        
        throw new NullReferenceException();
        label_6:
        LineDrawer.instance.letterPositions = this.<>4__this.letterPositions;
        UnityEngine.Rect val_4 = this.<>4__this.GetComponent<UnityEngine.RectTransform>().rect;
        float val_5 = val_4.m_XMin.height;
        float val_10 = val_5;
        GameBehavior val_6 = App.getBehavior;
        val_10 = val_10 / val_5;
        val_9 = this.<>4__this.centerPoint.transform;
        UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  val_10, y:  val_10, z:  1f);
        val_9.localScale = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_10:
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
