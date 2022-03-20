using UnityEngine;
private sealed class ImageQuizDisplayWord.<RefreshUIAfterAnimation>d__33 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.ImageQuiz.ImageQuizDisplayWord <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageQuizDisplayWord.<RefreshUIAfterAnimation>d__33(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        if((this.<>1__state) == 1)
        {
            goto label_0;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        this.<>4__this.<AllowInput>k__BackingField = false;
        this.<>4__this.<AllowErase>k__BackingField = false;
        goto label_3;
        label_0:
        this.<>1__state = 0;
        label_3:
        if((this.<>4__this.IsTilesAnimating()) != false)
        {
                val_2 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_2;
            return (bool)val_2;
        }
        
        this.<>4__this.<AllowInput>k__BackingField = true;
        this.<>4__this.<AllowErase>k__BackingField = true;
        this.<>4__this.RefreshUI();
        label_1:
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
