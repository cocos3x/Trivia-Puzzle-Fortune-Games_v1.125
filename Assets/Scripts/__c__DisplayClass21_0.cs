using UnityEngine;
private sealed class WordQuizUIController.<>c__DisplayClass21_0
{
    // Fields
    public SLC.Minigames.WordQuiz.WordQuizLetterTile tile;
    public SLC.Minigames.WordQuiz.WordQuizUIController <>4__this;
    
    // Methods
    public WordQuizUIController.<>c__DisplayClass21_0()
    {
    
    }
    internal void <InitializeLevel>b__0()
    {
        if((this.<>4__this) != null)
        {
                this.<>4__this.OnTileSelected(tile:  this.tile);
            return;
        }
        
        throw new NullReferenceException();
    }

}
