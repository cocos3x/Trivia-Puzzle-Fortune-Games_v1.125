using UnityEngine;
private sealed class WGFreeHintPopup.<SetStrkeOutLinePos_coroutine>d__51 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGFreeHintPopup <>4__this;
    public string textToStrike;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGFreeHintPopup.<SetStrkeOutLinePos_coroutine>d__51(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.LineRenderer val_17;
        int val_18;
        val_17 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_18 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_18;
        return (bool)val_18;
        label_1:
        this.<>1__state = 0;
        UnityEngine.UIVertex[] val_5 = this.<>4__this.desc_text.cachedTextGenerator.GetVerticesArray();
        float val_7 = this.<>4__this.desc_text.canvas.scaleFactor;
        int val_8 = (this.<>4__this.desc_text.Replace(oldValue:  " ", newValue:  "").IndexOf(value:  this.textToStrike)) << 2;
        int val_9 = val_5 + (val_8 * 76);
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = ((val_3 << 2) * 76) + val_5 + 32, y = ((val_3 << 2) * 76) + val_5 + 32 + 4, z = ((val_3 << 2) * 76) + val_5 + 40}, d:  val_7);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.back;
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, b:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        this.<>4__this.strikeoutLine.SetPosition(index:  0, position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
        int val_17 = this.textToStrike.m_stringLength;
        val_17 = (val_8 | 2) + (val_17 << 2);
        val_17 = val_17 - 4;
        val_17 = val_5 + (val_17 * 76);
        val_17 = this.<>4__this.strikeoutLine;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = (((((val_3 << 2) | 2) + (this.textToStrike.m_stringLength) << 2) - 4) * 76) + val_5 + 32, y = (((((val_3 << 2) | 2) + (this.textToStrike.m_stringLength) << 2) - 4) * 76) + val_5 + 32 + 4, z = (((((val_3 << 2) | 2) + (this.textToStrike.m_stringLength) << 2) - 4) * 76) + val_5 + 40}, d:  val_7);
        UnityEngine.Vector3 val_15 = UnityEngine.Vector3.back;
        UnityEngine.Vector3 val_16 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, b:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z});
        val_17.SetPosition(index:  1, position:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        label_2:
        val_18 = 0;
        return (bool)val_18;
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
