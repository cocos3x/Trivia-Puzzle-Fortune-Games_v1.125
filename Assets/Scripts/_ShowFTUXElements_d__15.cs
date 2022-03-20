using UnityEngine;
private sealed class Just2EmojisFTUXManager.<ShowFTUXElements>d__15 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Just2EmojisFTUXManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Just2EmojisFTUXManager.<ShowFTUXElements>d__15(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        Just2EmojisFTUXManager val_6;
        int val_7;
        val_6 = this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        val_7 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_7;
        return (bool)val_7;
        label_2:
        this.<>1__state = 0;
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.StartFTUX();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = 2;
        val_7 = 1;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        val_6 = this.<>4__this;
        val_6.ShowHand(t:  MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.FTUXNewLetterPosition());
        this.<>4__this.FTUXText.enabled = true;
        label_3:
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
