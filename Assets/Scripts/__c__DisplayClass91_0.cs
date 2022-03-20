using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass91_0
{
    // Fields
    public WordForest.WFOMysteryChestDisplay <>4__this;
    public DG.Tweening.Sequence nestedLoopSeq;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass91_0()
    {
    
    }
    internal void <DoAnimatedPointer>b__0()
    {
        this.<>4__this.pointerImage.gameObject.SetActive(value:  true);
        this.<>4__this.pointerSequence = this.nestedLoopSeq;
        DG.Tweening.Tween val_2 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Tween>(t:  this.<>4__this.pointerSequence);
    }

}
