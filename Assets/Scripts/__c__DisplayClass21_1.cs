using UnityEngine;
private sealed class WordQuizUIController.<>c__DisplayClass21_1
{
    // Fields
    public SLC.Minigames.WordQuiz.WordQuizLetterTile tile;
    public SLC.Minigames.WordQuiz.WordQuizUIController <>4__this;
    
    // Methods
    public WordQuizUIController.<>c__DisplayClass21_1()
    {
    
    }
    internal void <InitializeLevel>b__1()
    {
        if((MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.ShouldShowFTUX()) != false)
        {
                return;
        }
        
        this.<>4__this.OnTileDeselected(tile:  this.tile, fromHint:  false);
        this.tile.SetHiddenState(hidden:  true);
    }

}
