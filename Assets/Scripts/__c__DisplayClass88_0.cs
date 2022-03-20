using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass88_0
{
    // Fields
    public WordForest.WFOMysteryChestDisplay <>4__this;
    public int itemIndex;
    public DG.Tweening.Sequence seqSegment;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass88_0()
    {
    
    }
    internal void <CreateMiniSeqSegmentShowItemIntro>b__0()
    {
        WordForest.WFOMysteryChestDisplay val_15;
        bool val_15 = true;
        val_15 = this.<>4__this;
        if(val_15 <= this.itemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_15 = this.<>4__this;
        }
        
        val_15 = val_15 + (this.itemIndex * 28);
        WordForest.WFOWordChestItemIcon val_1 = val_15.InstantiateObjectItem(rewardData:  new WordForest.WFORewardData() {id = (this.itemIndex * 28) + true + 32, rewardType = (this.itemIndex * 28) + true + 32, amount = new System.Decimal() {flags = (this.itemIndex * 28) + true + 32, hi = (this.itemIndex * 28) + true + 32, lo = (this.itemIndex * 28) + true + 32}, transformToId = (this.itemIndex * 28) + true + 32}, itemIndex:  this.itemIndex, forOutro:  false);
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        val_1.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        WordForest.WFOAcornMultiplierTrailParticle val_5 = UnityEngine.Object.Instantiate<WordForest.WFOAcornMultiplierTrailParticle>(original:  this.<>4__this.prefabItemTrailEfx, parent:  this.<>4__this.transform);
        UnityEngine.Vector3 val_8 = this.<>4__this.transform.position;
        val_5.transform.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        WordForest.WFOMysteryChestDisplay val_16 = this.<>4__this;
        if(val_16 <= this.itemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_16 = val_16 + ((this.itemIndex) << 3);
        UnityEngine.Vector3 val_9 = (this.<>4__this + (this.itemIndex) << 3).chestRootTransform.position;
        val_5.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, particleCount:  1, animateStatView:  true);
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.seqSegment, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_1.gameObject.transform, endValue:  1f, duration:  0.2f), ease:  30));
    }

}
