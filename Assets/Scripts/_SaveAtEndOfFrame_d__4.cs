using UnityEngine;
private sealed class PrefsSerializationManager.<SaveAtEndOfFrame>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PrefsSerializationManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PrefsSerializationManager.<SaveAtEndOfFrame>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_2;
        int val_3;
        var val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_2 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_3 = 1;
        this.<>2__current = val_2;
        this.<>1__state = val_3;
        return (bool)val_3;
        label_1:
        val_2 = this.<>4__this;
        this.<>1__state = 0;
        UnityEngine.PlayerPrefs.Save();
        this.<>4__this.shouldSaveThisFrame = false;
        val_4 = null;
        val_4 = null;
        if(PrefsSerializationManager.LOGGING != false)
        {
                UnityEngine.Debug.LogError(message:  "<<<<<<Saved Prefs this frame.", context:  val_2);
        }
        
        label_7:
        val_3 = 0;
        return (bool)val_3;
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
