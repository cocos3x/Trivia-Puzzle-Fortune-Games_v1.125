using UnityEngine;
private sealed class WGExtraChapterEventProgressPopup.<Start>d__5 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGExtraChapterEventProgressPopup <>4__this;
    private UnityEngine.RectTransform <myTransform>5__2;
    private UnityEngine.Vector2 <startPos>5__3;
    private float <progress>5__4;
    private float <timeToFall>5__5;
    private int <second>5__6;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGExtraChapterEventProgressPopup.<Start>d__5(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_31;
        if((this.<>1__state) <= 5)
        {
                var val_28 = 32497672 + (this.<>1__state) << 2;
            val_28 = val_28 + 32497672;
        }
        else
        {
                val_31 = 0;
            return (bool);
        }
    
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
