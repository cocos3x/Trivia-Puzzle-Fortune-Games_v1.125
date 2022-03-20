using UnityEngine;
private sealed class ImageQuizDisplayWord.<SubmittingWord>d__39 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.ImageQuiz.ImageQuizDisplayWord <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageQuizDisplayWord.<SubmittingWord>d__39(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        SLC.Minigames.ImageQuiz.ImageQuizDisplayWord val_4;
        int val_5;
        if((this.<>1__state) < 2)
        {
                val_4 = this.<>4__this;
            this.<>1__state = 0;
            if(val_4.IsTilesAnimating() != false)
        {
                val_5 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_5;
            return (bool)val_5;
        }
        
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.SubmitWord(word:  val_4.GetCurrentInput());
        }
        
        val_5 = 0;
        return (bool)val_5;
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
