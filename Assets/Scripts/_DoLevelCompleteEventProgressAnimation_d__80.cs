using UnityEngine;
private sealed class WordHuntEvent.<DoLevelCompleteEventProgressAnimation>d__80 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordHuntEvent <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public WGEventButtonV2 eventButton;
    private WordHuntEvent.<>c__DisplayClass80_1 <>8__1;
    private WordHuntEvent.<>c__DisplayClass80_2 <>8__2;
    private UnityEngine.Vector2 <startSize>5__2;
    private UnityEngine.Vector2 <dest>5__3;
    private float <duration>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordHuntEvent.<DoLevelCompleteEventProgressAnimation>d__80(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WordHuntEvent val_49;
        int val_50;
        if((this.<>1__state) <= 3)
        {
                var val_49 = 32555448 + (this.<>1__state) << 2;
            val_49 = this.<>4__this;
            val_49 = val_49 + 32555448;
        }
        else
        {
                val_50 = 0;
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
