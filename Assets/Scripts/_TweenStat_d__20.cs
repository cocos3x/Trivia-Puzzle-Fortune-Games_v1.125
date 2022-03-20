using UnityEngine;
private sealed class WordIQLevelCompleteDisplayAnim.<TweenStat>d__20 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordIQLevelCompleteDisplayAnim <>4__this;
    private float <endAmount>5__2;
    private float <incrementPerSecond>5__3;
    private bool <showMilestoneUpgrade>5__4;
    private int <statDisplayMilestone>5__5;
    private float <statDisplayAmount>5__6;
    private int <milestoneReached>5__7;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordIQLevelCompleteDisplayAnim.<TweenStat>d__20(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_28;
        float val_29;
        float val_30;
        float val_31;
        UnityEngine.UI.Text val_32;
        var val_33;
        val_28 = this;
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
            goto label_22;
        }
        
        this.<>1__state = 0;
        float val_1 = UnityEngine.Time.time;
        float val_2 = UnityEngine.Time.time;
        WordIQManagerUI val_3 = MonoSingleton<WordIQManagerUI>.Instance;
        val_29 = val_3._IQPointsAtStartOfLevel;
        float val_5 = MonoSingleton<WordIQManager>.Instance.PlayerIQ;
        val_30 = val_28;
        this.<endAmount>5__2 = val_5;
        val_5 = val_5 - val_29;
        val_5 = val_5 / (this.<>4__this.statTweenDuration);
        mem[1152921516840115836] = val_5;
        int val_7 = MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  val_29);
        val_31 = val_28;
        this.<statDisplayAmount>5__6 = val_29;
        mem[1152921516840115840] = (val_7 != (MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  this.<endAmount>5__2))) ? 1 : 0;
        mem[1152921516840115844] = val_7;
        goto label_14;
        label_2:
        this.<>1__state = 0;
        this.<statDisplayMilestone>5__5 = this.<milestoneReached>5__7;
        if((this.<>4__this) != null)
        {
            goto label_15;
        }
        
        label_1:
        val_31 = this.<statDisplayAmount>5__6;
        val_30 = this.<endAmount>5__2;
        this.<>1__state = 0;
        label_14:
        if(val_31 < 0)
        {
            goto label_17;
        }
        
        val_32 = this.<>4__this.iqStat;
        val_28 = this.<>4__this.iqStat;
        string val_11 = WordIQManagerUI.FormatPoints(iqPoints:  val_30);
        if((System.String.op_Inequality(a:  val_28, b:  this.<>4__this.iqStat)) != false)
        {
                WGAudioController val_13 = MonoSingleton<WGAudioController>.Instance;
            val_13.sound.PlayGameSpecificSound(id:  "UpdateIQProgress", clipIndex:  0);
        }
        
        label_22:
        val_33 = 0;
        return (bool)val_33;
        label_17:
        float val_14 = UnityEngine.Time.deltaTime;
        val_29 = val_14;
        val_14 = (this.<incrementPerSecond>5__3) * val_29;
        float val_16 = UnityEngine.Mathf.Min(a:  val_14, b:  (this.<endAmount>5__2) - (this.<statDisplayAmount>5__6));
        val_16 = val_31 + val_16;
        this.<statDisplayAmount>5__6 = val_16;
        if((this.<showMilestoneUpgrade>5__4) != false)
        {
                if((MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  this.<statDisplayAmount>5__6)) != (this.<statDisplayMilestone>5__5))
        {
            goto label_34;
        }
        
        }
        
        label_15:
        val_32 = this.<>4__this.iqStat;
        string val_19 = WordIQManagerUI.FormatPoints(iqPoints:  this.<statDisplayAmount>5__6);
        if((System.String.op_Inequality(a:  val_32, b:  this.<>4__this.iqStat)) != false)
        {
                WGAudioController val_21 = MonoSingleton<WGAudioController>.Instance;
            val_21.sound.PlayGameSpecificSound(id:  "UpdateIQProgress", clipIndex:  0);
        }
        
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_33 = 1;
        return (bool)val_33;
        label_34:
        this.<milestoneReached>5__7 = MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  this.<statDisplayAmount>5__6);
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.ShowMilestoneReached(milestoneIndex:  this.<milestoneReached>5__7, milestoneAmount:  MonoSingleton<WordIQManager>.Instance.GetMilestoneAmount(milestoneIndex:  this.<milestoneReached>5__7)));
        this.<>1__state = 1;
        return (bool)val_33;
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
