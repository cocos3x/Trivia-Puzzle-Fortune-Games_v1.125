using UnityEngine;
private sealed class TRVTriviaPursuitCategoryDisplay.<AnimatingCategory>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public System.Collections.Generic.List<string> incCats;
    public TRVTriviaPursuitCategoryDisplay <>4__this;
    public TRVTriviaPursuitCategoryDisplayInfo finalInfo;
    private System.Collections.Generic.List<string> <allCategories>5__2;
    private float <animationDuration>5__3;
    private System.DateTime <startTime>5__4;
    private int <cat>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVTriviaPursuitCategoryDisplay.<AnimatingCategory>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_15;
        if((this.<>1__state) <= 6)
        {
                var val_15 = 32561312 + (this.<>1__state) << 2;
            val_15 = val_15 + 32561312;
        }
        else
        {
                val_15 = 0;
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
