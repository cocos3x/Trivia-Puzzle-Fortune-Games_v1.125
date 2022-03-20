using UnityEngine;
private sealed class TRVYouBetchaBetPopup.<WaitForCoinAnimation>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVYouBetchaBetPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVYouBetchaBetPopup.<WaitForCoinAnimation>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_3;
        int val_4;
        var val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_3 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  1.25f);
        val_4 = 1;
        this.<>2__current = val_3;
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        val_3 = this.<>4__this;
        this.<>1__state = 0;
        UUI_EventsController.EnableInputs();
        val_5 = null;
        val_5 = null;
        TRVMainController.noAnswerSelectedCharacter = 0;
        SLCWindow.CloseWindow(window:  val_3.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_2:
        val_4 = 0;
        return (bool)val_4;
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
