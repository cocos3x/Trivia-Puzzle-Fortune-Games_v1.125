using UnityEngine;
private sealed class WordFillFTUXManager.<ShowFTUXElements>d__29 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordFillFTUXManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordFillFTUXManager.<ShowFTUXElements>d__29(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WordFillFTUXManager val_17;
        int val_18;
        val_17 = this.<>4__this;
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
        UnityEngine.WaitForSeconds val_1 = null;
        val_17 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        val_18 = 1;
        this.<>2__current = val_17;
        this.<>1__state = val_18;
        return (bool)val_18;
        label_2:
        this.<>1__state = 0;
        if((this.<>4__this.ftuxPhase) < (this.<>4__this.ftuxMessages.Length))
        {
                string val_17 = this.<>4__this.ftuxMessages[this.<>4__this.ftuxPhase];
            this.<>4__this.FTUXText.gameObject.SetActive(value:  true);
        }
        
        UnityEngine.WaitForSeconds val_3 = null;
        val_17 = val_3;
        val_3 = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>2__current = val_17;
        this.<>1__state = 2;
        val_18 = 1;
        return (bool)val_18;
        label_1:
        this.<>1__state = 0;
        if((System.String.op_Inequality(a:  this.<>4__this.FTUXText, b:  "")) != false)
        {
                int val_18 = this.<>4__this.ftuxPhase;
            val_18 = val_18 + (val_18 << 1);
            int val_5 = val_18 << 1;
            if(val_5 < (this.<>4__this.ftuxLetterPos.Length))
        {
                var val_19 = (long)val_5;
            val_19 = val_19 | 1;
            val_17.ShowHand(one:  MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance.GetGridPos(x:  this.<>4__this.ftuxLetterPos[val_5], y:  this.<>4__this.ftuxLetterPos[val_19]), two:  MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance.GetGridPos(x:  this.<>4__this.ftuxLetterPos[val_5 + 2], y:  this.<>4__this.ftuxLetterPos[val_5 + 3]), three:  MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance.GetGridPos(x:  this.<>4__this.ftuxLetterPos[val_5 + 4], y:  this.<>4__this.ftuxLetterPos[val_5 + 5]));
        }
        
        }
        
        SLC.Minigames.WordFill.WordFillUIController val_16 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
        val_18 = 0;
        val_16.overlay = false;
        return (bool)val_18;
        label_3:
        val_18 = 0;
        return (bool)val_18;
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
