using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass86_1
{
    // Fields
    public int currItemIndex;
    public WordForest.WFOMysteryChestDisplay.<>c__DisplayClass86_0 CS$<>8__locals1;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass86_1()
    {
    
    }
    internal void <DoOpenChestAnimationSequence>b__1()
    {
        WordForest.WFOMysteryChestDisplay val_7 = this.CS$<>8__locals1.<>4__this;
        if(val_7 <= this.currItemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (this.currItemIndex * 28);
        if(((this.currItemIndex * 28) + this.CS$<>8__locals1.<>4__this + 36) != 5)
        {
            goto label_5;
        }
        
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        if((MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  9)) == false)
        {
            goto label_21;
        }
        
        label_5:
        WordForest.WFOMysteryChestDisplay val_8 = this.CS$<>8__locals1.<>4__this;
        if(val_8 <= this.currItemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (this.currItemIndex * 28);
        if(((this.currItemIndex * 28) + this.CS$<>8__locals1.<>4__this + 36) != 6)
        {
            goto label_12;
        }
        
        WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
        if((MonoExtensions.IsBitSet(value:  val_3.tutorialCompleted, bit:  10)) == false)
        {
            goto label_21;
        }
        
        label_12:
        WordForest.WFOMysteryChestDisplay val_9 = this.CS$<>8__locals1.<>4__this;
        if(val_9 <= this.currItemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + (this.currItemIndex * 28);
        if(((this.currItemIndex * 28) + this.CS$<>8__locals1.<>4__this + 36) != 4)
        {
                return;
        }
        
        WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
        if((MonoExtensions.IsBitSet(value:  val_5.tutorialCompleted, bit:  8)) != false)
        {
                return;
        }
        
        label_21:
        this.CS$<>8__locals1.<>4__this.button.interactable = false;
    }
    internal void <DoOpenChestAnimationSequence>b__2()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        this.CS$<>8__locals1.<>4__this.ToggleTapToOpenLabel(isVisible:  false);
        this.CS$<>8__locals1.<>4__this.ShowFtux(ftuxId:  8);
    }
    internal void <DoOpenChestAnimationSequence>b__3()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        this.CS$<>8__locals1.<>4__this.ToggleTapToOpenLabel(isVisible:  false);
        this.CS$<>8__locals1.<>4__this.ShowFtux(ftuxId:  10);
    }
    internal void <DoOpenChestAnimationSequence>b__4()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        this.CS$<>8__locals1.<>4__this.ToggleTapToOpenLabel(isVisible:  false);
        this.CS$<>8__locals1.<>4__this.ShowFtux(ftuxId:  11);
    }
    internal void <DoOpenChestAnimationSequence>b__5()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        RaidAttackScreenUI.ShowAttackScreen();
    }
    internal void <DoOpenChestAnimationSequence>b__6()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        this.CS$<>8__locals1.<>4__this.ShowFtux(ftuxId:  9);
    }
    internal void <DoOpenChestAnimationSequence>b__7()
    {
        this.CS$<>8__locals1.<>4__this.PauseAllOpenChestSequences(triggerItemIndex:  this.currItemIndex);
        RaidAttackScreenUI.ShowRaidScreen();
    }

}
