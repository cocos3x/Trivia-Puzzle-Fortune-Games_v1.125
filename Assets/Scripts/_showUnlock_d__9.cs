using UnityEngine;
private sealed class PortraitCollectionProgressBar.<showUnlock>d__9 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public string unlocked;
    public PortraitCollectionProgressBar <>4__this;
    private PortraitCollectionProgressBar.<>c__DisplayClass9_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PortraitCollectionProgressBar.<showUnlock>d__9(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        System.Action val_7;
        int val_8;
        IntPtr val_9;
        val_7 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new PortraitCollectionProgressBar.<>c__DisplayClass9_0();
        .unlocked = this.unlocked;
        this.<>8__1.<>4__this = this.<>4__this;
        val_8 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  3f);
        this.<>1__state = val_8;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        GameBehavior val_3 = App.getBehavior;
        this.<>8__1.popup = val_3.<metaGameBehavior>k__BackingField;
        this.<>8__1.popup.InitPortraitUnlocked(portraitName:  this.<>8__1.unlocked, isCollection:  false);
        FPHPortraitCollectionController val_5 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        val_7 = new System.Action();
        if(val_5.progress.collectionCompleted == false)
        {
            goto label_18;
        }
        
        val_9 = 1152921516644365888;
        goto label_19;
        label_2:
        val_8 = 0;
        return (bool)val_8;
        label_18:
        val_9 = 1152921516644366912;
        label_19:
        val_7 = new System.Action(object:  this.<>8__1, method:  val_9);
        val_8 = 0;
        this.<>8__1.popup.OnCLose = val_7;
        return (bool)val_8;
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
