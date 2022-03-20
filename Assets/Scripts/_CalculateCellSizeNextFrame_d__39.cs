using UnityEngine;
private sealed class WGDailyChallengeWordRegion.<CalculateCellSizeNextFrame>d__39 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeWordRegion <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeWordRegion.<CalculateCellSizeNextFrame>d__39(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_6;
        int val_7;
        UnityEngine.RectTransform val_8;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_6 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_7 = 1;
        this.<>2__current = val_6;
        this.<>1__state = val_7;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        List.Enumerator<T> val_3 = this.<>4__this.GetEnumerator();
        label_8:
        if(0.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[32] = this.<>4__this.CalculateCellSizeForLines();
        0.SetLineWidth();
        0.ReBuild();
        0.MakeVisible(visible:  true);
        goto label_8;
        label_6:
        0.Dispose();
        UnityEngine.Transform val_5 = this.<>4__this.transform;
        val_6 = val_5;
        if(val_6 != null)
        {
                val_5 = (null == null) ? (val_6) : 0;
        }
        else
        {
                val_8 = 0;
        }
        
        UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  val_8);
        label_2:
        val_7 = 0;
        return (bool)val_7;
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
