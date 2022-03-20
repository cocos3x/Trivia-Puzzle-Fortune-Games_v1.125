using UnityEngine;
private sealed class WordChainUIController.<>c__DisplayClass17_1
{
    // Fields
    public SLC.Minigames.WordChain.WordChainLetterTile tile;
    public SLC.Minigames.WordChain.WordChainUIController <>4__this;
    
    // Methods
    public WordChainUIController.<>c__DisplayClass17_1()
    {
    
    }
    internal void <InitializeLevel>b__1()
    {
        if((this.<>4__this) != null)
        {
                this.<>4__this.OnTileDeselected(tile:  this.tile);
            return;
        }
        
        throw new NullReferenceException();
    }

}
