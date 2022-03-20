using UnityEngine;
private sealed class WordQuizUIController.<>c__DisplayClass30_0
{
    // Fields
    public SLC.Minigames.WordQuiz.WordQuizLetterTile currentHintAnswerTile;
    
    // Methods
    public WordQuizUIController.<>c__DisplayClass30_0()
    {
    
    }
    internal bool <ShowHint>b__0(SLC.Minigames.WordQuiz.WordQuizLetterTile x)
    {
        return x.letter.Equals(value:  this.currentHintAnswerTile.letter);
    }

}
