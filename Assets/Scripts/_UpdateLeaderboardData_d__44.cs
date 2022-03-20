using UnityEngine;
private sealed class WordGameEventsController.<UpdateLeaderboardData>d__44 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordGameEventsController <>4__this;
    public int seconds;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordGameEventsController.<UpdateLeaderboardData>d__44(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        if((this.<>1__state) <= 1)
        {
                this.<>1__state = 0;
            this.<>4__this.OnAppleAwarded(appleAwarded:  0);
            val_2 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  (float)this.seconds);
            this.<>1__state = val_2;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
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
