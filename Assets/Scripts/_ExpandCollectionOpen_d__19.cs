using UnityEngine;
private sealed class PortraitCollectionCollectionItem.<ExpandCollectionOpen>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PortraitCollectionCollectionItem <>4__this;
    private PortraitCollectionCollectionItem.<>c__DisplayClass19_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PortraitCollectionCollectionItem.<ExpandCollectionOpen>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_23;
        object val_25;
        int val_26;
        string val_27;
        val_23 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool)val_23;
        }
        
        float val_23 = 8.847776E-38f;
        val_23 = (32562176 + (this.<>1__state) << 2) + val_23;
        goto (32562176 + (this.<>1__state) << 2 + 32562176);
        label_20:
        val_27 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, PortraitCollectionPortraitItem>::MoveNext();
        bool val_12 = 0.MoveNext();
        if(val_12 == false)
        {
            goto label_16;
        }
        
        if(val_12 == false)
        {
                throw new NullReferenceException();
        }
        
        val_27 = 0;
        PortraitCollectionPortraitItem val_13 = val_12.Item[val_27];
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = 0;
        UnityEngine.GameObject val_14 = val_13.gameObject;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.SetActive(value:  true);
        goto label_20;
        label_16:
        0.Dispose();
        val_25 = 0;
        val_26 = 2;
        val_23 = 1;
        this.<>2__current = val_25;
        this.<>1__state = val_26;
        return (bool)val_23;
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
