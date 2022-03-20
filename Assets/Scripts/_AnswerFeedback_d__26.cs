using UnityEngine;
private sealed class Just2EmojisManager.<AnswerFeedback>d__26 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public bool correct;
    public SLC.Minigames.Just2Emojis.Just2EmojisManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Just2EmojisManager.<AnswerFeedback>d__26(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_12;
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
            goto label_18;
        }
        
        this.<>1__state = 0;
        if(this.correct == false)
        {
            goto label_4;
        }
        
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.MarkCorrectAnswer();
        goto label_8;
        label_2:
        this.<>1__state = 0;
        if(this.correct == false)
        {
            goto label_9;
        }
        
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) != false)
        {
                MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.SetLettersInteractable(on:  false);
        }
        
        this.<>4__this._continuesUsed = 0;
        this.<>4__this.LoadLevel();
        goto label_18;
        label_1:
        this.<>1__state = 0;
        int val_12 = this.<>4__this._continuesUsed;
        val_12 = val_12 + 1;
        this.<>4__this._continuesUsed = val_12;
        bool val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        SLC.Minigames.Just2Emojis.Just2EmojisUIController val_7 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
        val_7.canvas.enabled = false;
        label_18:
        val_12 = 0;
        return (bool)val_12;
        label_9:
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.DisplayAnswer();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = 2;
        val_12 = 1;
        return (bool)val_12;
        label_4:
        MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.MarkWrongAnswer();
        label_8:
        val_12 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_12;
        return (bool)val_12;
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
