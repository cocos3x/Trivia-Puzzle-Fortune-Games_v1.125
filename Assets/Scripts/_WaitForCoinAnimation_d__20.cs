using UnityEngine;
private sealed class TRVSpecialCategoriesPopup.<WaitForCoinAnimation>d__20 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVSpecialCategoriesPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVSpecialCategoriesPopup.<WaitForCoinAnimation>d__20(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_4;
        int val_5;
        var val_6;
        var val_7;
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
        val_4 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  1.25f);
        val_5 = 1;
        this.<>2__current = val_4;
        this.<>1__state = val_5;
        return (bool)val_5;
        label_1:
        val_4 = this.<>4__this;
        this.<>1__state = 0;
        UUI_EventsController.EnableInputs();
        val_6 = null;
        val_6 = null;
        TRVMainController.noAnswerSelectedCharacter = 2;
        val_7 = null;
        val_7 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 4;
        GameBehavior val_2 = App.getBehavior;
        SLCWindow.CloseWindow(window:  val_4.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_2:
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
