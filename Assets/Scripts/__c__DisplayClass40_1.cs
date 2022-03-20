using UnityEngine;
private sealed class BingoEventPopup.<>c__DisplayClass40_1
{
    // Fields
    public UnityEngine.GameObject prevBall;
    public BingoEventPopup.<>c__DisplayClass40_0 CS$<>8__locals1;
    
    // Methods
    public BingoEventPopup.<>c__DisplayClass40_1()
    {
    
    }
    internal void <CollectBallsAnimation>b__0()
    {
        this.prevBall.SetActive(value:  false);
        bool val_1 = this.CS$<>8__locals1.goBalls.Remove(item:  this.prevBall);
    }

}
