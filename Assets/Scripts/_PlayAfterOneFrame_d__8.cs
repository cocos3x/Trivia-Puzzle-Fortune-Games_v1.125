using UnityEngine;
private sealed class DOTextAnimationAfterLocalization.<PlayAfterOneFrame>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DG.Tweening.DOTextAnimationAfterLocalization <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DOTextAnimationAfterLocalization.<PlayAfterOneFrame>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_5;
        int val_6;
        val_5 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_9;
        }
        
        val_6 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        val_5 = this.<>4__this.text;
        if((UnityEngine.Object.op_Implicit(exists:  this.<>4__this.text)) != false)
        {
                DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOText(target:  this.<>4__this.text, endValue:  val_5, duration:  this.<>4__this.duration, richTextEnabled:  this.<>4__this.richText, scrambleMode:  this.<>4__this.scrambleMode, scrambleChars:  this.<>4__this.customScramble), delay:  this.<>4__this.delay), ease:  this.<>4__this.ease);
        }
        
        label_9:
        val_6 = 0;
        return (bool)val_6;
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
