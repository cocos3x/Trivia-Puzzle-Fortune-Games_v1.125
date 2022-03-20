using UnityEngine;
private sealed class TRVTimerDisplay.<CheckTimeRemaining>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVTimerDisplay <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVTimerDisplay.<CheckTimeRemaining>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        ulong val_16;
        float val_17;
        int val_18;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_39;
        }
        
        this.<>1__state = 0;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        val_16 = val_1.dateData;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_16}, d2:  new System.DateTime() {dateData = this.<>4__this.startTime});
        val_17 = (float)val_2._ticks.TotalSeconds;
        goto label_40;
        label_1:
        this.<>1__state = 0;
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = this.<>4__this.startTime});
        val_16 = this.<>4__this.pointsText;
        string val_7 = this.<>4__this.TimeRemainingText();
        if(((System.String.op_Inequality(a:  val_16, b:  "")) != false) && ((System.String.op_Inequality(a:  this.<>4__this.pointsText, b:  val_16)) != false))
        {
                if((System.String.op_Equality(a:  this.<>4__this.pointsText, b:  "3")) != true)
        {
                if((System.String.op_Equality(a:  this.<>4__this.pointsText, b:  "2")) != true)
        {
                if((System.String.op_Equality(a:  this.<>4__this.pointsText, b:  "1")) == false)
        {
            goto label_26;
        }
        
        }
        
        }
        
            WGAudioController val_13 = MonoSingleton<WGAudioController>.Instance;
            val_13.sound.PlayGameSpecificSound(id:  "Counting Down", clipIndex:  0);
        }
        
        label_26:
        float val_16 = this.<>4__this.quizDuration;
        val_17 = (float)val_5._ticks.TotalSeconds;
        if(val_16 >= 0)
        {
            goto label_31;
        }
        
        MonoSingleton<TRVMainController>.Instance.OnAnswerClicked(selectedAnswer:  "!");
        WGAudioController val_15 = MonoSingleton<WGAudioController>.Instance;
        val_15.sound.PlayGameSpecificSound(id:  "Time Up", clipIndex:  0);
        this.<>4__this.enabled = false;
        goto label_39;
        label_31:
        if((this.<>4__this.OnTick) != null)
        {
                val_16 = val_16 - val_17;
            val_16 = (val_16 == Infinityf) ? (-(double)val_16) : ((double)val_16);
            this.<>4__this.OnTick.Invoke(obj:  (int)val_16);
        }
        
        label_40:
        if(val_17 < 0)
        {
            goto label_41;
        }
        
        label_39:
        val_18 = 0;
        return (bool)val_18;
        label_41:
        val_18 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_18;
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
