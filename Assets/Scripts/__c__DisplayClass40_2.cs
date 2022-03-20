using UnityEngine;
private sealed class BingoEventPopup.<>c__DisplayClass40_2
{
    // Fields
    public UnityEngine.GameObject daubGO;
    public BingoCell cell;
    public BingoEventPopup.<>c__DisplayClass40_0 CS$<>8__locals2;
    
    // Methods
    public BingoEventPopup.<>c__DisplayClass40_2()
    {
    
    }
    internal void <CollectBallsAnimation>b__1()
    {
        this.daubGO.SetActive(value:  false);
        this.cell.cellImage.gameObject.SetActive(value:  true);
        this.cell.cellImage.sprite = this.CS$<>8__locals2.<>4__this.bingoBaubSprite;
    }

}
