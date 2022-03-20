using UnityEngine;
private sealed class WFOWordChestDisplay.<>c__DisplayClass60_0
{
    // Fields
    public WordForest.WFOWordChestDisplay <>4__this;
    public bool showFtux;
    public System.Action <>9__1;
    
    // Methods
    public WFOWordChestDisplay.<>c__DisplayClass60_0()
    {
    
    }
    internal void <DoNewChestAnimationSequence>b__0()
    {
        System.Action val_3;
        this.<>4__this.parentCanvasGroup.blocksRaycasts = true;
        val_3 = this.<>9__1;
        if(val_3 == null)
        {
                System.Action val_2 = null;
            val_3 = val_2;
            val_2 = new System.Action(object:  this, method:  System.Void WFOWordChestDisplay.<>c__DisplayClass60_0::<DoNewChestAnimationSequence>b__1());
            this.<>9__1 = val_3;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  val_2);
    }
    internal void <DoNewChestAnimationSequence>b__1()
    {
        this.<>4__this.gameObject.transform.SetParent(p:  this.<>4__this.originalParent);
        this.<>4__this.isAnimationActive = false;
        if(this.showFtux != false)
        {
                WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            val_3.tutorialCompleted = MonoExtensions.SetBit(value:  val_4.tutorialCompleted, bit:  1);
            GameBehavior val_6 = App.getBehavior;
        }
        
        WordForest.WFOWordChestDisplay.<isChestReadyFlowActivated>k__BackingField = false;
    }

}
