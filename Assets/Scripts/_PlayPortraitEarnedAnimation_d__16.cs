using UnityEngine;
private sealed class PortraitCollectionEventPopup.<PlayPortraitEarnedAnimation>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    private PortraitCollectionEventPopup.<>c__DisplayClass16_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PortraitCollectionEventPopup.<PlayPortraitEarnedAnimation>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        PortraitCollectionEventPopup.<>c__DisplayClass16_0 val_10;
        int val_11;
        PortraitCollectionEventPopup.<>c__DisplayClass16_0 val_12;
        val_10 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_21;
        }
        
        this.<>1__state = 0;
        val_11 = 1;
        this.<>2__current = 0;
        this.<>8__1 = new PortraitCollectionEventPopup.<>c__DisplayClass16_0();
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        GameBehavior val_2 = App.getBehavior;
        this.<>8__1.popup = val_2.<metaGameBehavior>k__BackingField;
        val_12 = this.<>8__1;
        FPHPortraitCollectionController val_5 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        this.<>8__1.recentlyUnlocked = System.Linq.Enumerable.Last<System.String>(source:  MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  val_5.progress.chosenCollection));
        this.<>8__1.popup.InitPortraitUnlocked(portraitName:  this.<>8__1.recentlyUnlocked, isCollection:  false);
        FPHPortraitCollectionController val_8 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_8.progress.collectionCompleted != false)
        {
                val_10 = this.<>8__1;
            val_12 = this.<>8__1.popup;
            val_11 = 0;
            this.<>8__1.popup.OnCLose = new System.Action(object:  val_10, method:  System.Void PortraitCollectionEventPopup.<>c__DisplayClass16_0::<PlayPortraitEarnedAnimation>b__0());
            return (bool)val_11;
        }
        
        label_21:
        val_11 = 0;
        return (bool)val_11;
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
