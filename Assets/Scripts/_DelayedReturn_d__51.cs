using UnityEngine;
private sealed class Just2EmojisUIController.<DelayedReturn>d__51 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.Just2Emojis.Just2EmojisUIController <>4__this;
    public int index;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Just2EmojisUIController.<DelayedReturn>d__51(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_8;
        int val_9;
        int val_10;
        System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisAnswer> val_11;
        int val_6 = this.<>1__state;
        if(val_6 == 1)
        {
            goto label_1;
        }
        
        if(val_6 != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.shouldDisable = true;
        val_8 = this;
        val_9 = (this.<>4__this.answerBlocks) - 1;
        this.<i>5__2 = val_9;
        if((this.<>4__this) != null)
        {
            goto label_5;
        }
        
        label_1:
        val_8 = this.<i>5__2;
        this.<>1__state = 0;
        goto label_27;
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_35:
        val_11 = this.<>4__this.answerBlocks;
        if(val_6 <= 41971712)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + 335773696;
        var val_7 = (this.<>1__state + 335773696) + 32 + 56;
        if(val_7 == 0)
        {
                if(val_7 <= X23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + ((X23) << 3);
            var val_8 = ((this.<>1__state + 335773696) + 32 + 56 + (X23) << 3) + 32;
            if(W9 <= X23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + ((X23) << 3);
            (((this.<>1__state + 335773696) + 32 + 56 + (X23) << 3) + 32 + (X23) << 3) + 32.Empty();
            val_11 = this.<>4__this.answerBlocks;
            if(val_8 <= X23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + ((X23) << 3);
            ((((this.<>1__state + 335773696) + 32 + 56 + (X23) << 3) + 32 + (X23) << 3) + (X23) << 3) + 32 + 48.sprite = this.<>4__this.answerEmptySprite;
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.ClearCurrentAnswerChar(index:  X23);
            if((this.<>4__this.letters.Length) >= 1)
        {
                var val_9 = 0;
            do
        {
            val_11 = this.<>4__this.letters[val_9];
            if(((System.String.op_Equality(a:  this.<>4__this.letters[0x0][0].letter, b:  ((this.<>1__state + 335773696) + 32 + 56 + (X23) << 3) + 32 + 24)) != false) && ((this.<>4__this.letters[0x0][0].isHidden) != false))
        {
                if((this.<>4__this.letters[0x0][0].isHinted) == false)
        {
            goto label_32;
        }
        
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < (this.<>4__this.letters.Length));
        
        }
        
        }
        
        label_27:
        val_9 = X23 - 1;
        mem2[0] = val_9;
        label_5:
        if(val_9 >= this.index)
        {
            goto label_35;
        }
        
        val_10 = 0;
        this.<>4__this.shouldDisable = false;
        return (bool)val_10;
        label_32:
        val_11.Show();
        bool val_3 = this.<>4__this.progressBlocks.Remove(item:  val_11);
        MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.05f);
        this.<>1__state = val_10;
        return (bool)val_10;
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
