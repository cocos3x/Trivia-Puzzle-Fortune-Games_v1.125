using UnityEngine;
private sealed class PortraitCollectionProgressBar.<UpdateUI>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PortraitCollectionProgressBar <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PortraitCollectionProgressBar.<UpdateUI>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.UI.Text val_8;
        int val_9;
        val_8 = this;
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 1)
        {
                val_9 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_9;
        }
        
            this.<>1__state = 0;
            val_9 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.4f);
            this.<>1__state = val_9;
            return (bool)val_9;
        }
        
            this.<>1__state = 0;
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.progressText.coinText, endValue:  0f, duration:  0.5f);
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.75f);
            this.<>1__state = 2;
            val_9 = 1;
            return (bool)val_9;
        }
        
        this.<>1__state = 0;
        val_8 = this.<>4__this.progressText.coinText;
        Player val_4 = App.Player;
        GameEcon val_5 = App.getGameEcon;
        string val_6 = val_4._stars.ToString(format:  val_5.numberFormatInt);
        DG.Tweening.Tweener val_7 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.progressText.coinText, endValue:  1f, duration:  0.2f);
        val_9 = 0;
        return (bool)val_9;
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
