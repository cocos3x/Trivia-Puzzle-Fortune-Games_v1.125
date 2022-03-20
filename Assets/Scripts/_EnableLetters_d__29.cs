using UnityEngine;
private sealed class Pan.<EnableLetters>d__29 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public System.Collections.Generic.List<string> tileStrings;
    public System.Collections.Generic.List<int> indexes;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Pan.<EnableLetters>d__29(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_6;
        var val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        val_6 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        MainController val_2 = MainController.instance;
        if((val_2.wordsCompleted.Equals(value:  "|")) == false)
        {
            goto label_10;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_7 = val_4.<metaGameBehavior>k__BackingField;
        goto label_15;
        label_2:
        val_6 = 0;
        return (bool)val_6;
        label_10:
        val_7 = 2147483647;
        label_15:
        val_6 = 0;
        LineDrawer.instance.allowedPositions = MonoSingletonSelfGenerating<WADataParser>.Instance.GetAllowedLetters(level:  2147483647, lettersSize:  1076110768, lettersArray:  this.tileStrings, indexes:  this.indexes);
        return (bool)val_6;
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
