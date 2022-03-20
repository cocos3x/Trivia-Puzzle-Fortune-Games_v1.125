using UnityEngine;
private sealed class ImageQuizDataManager.<>c__DisplayClass29_0
{
    // Fields
    public string word;
    
    // Methods
    public ImageQuizDataManager.<>c__DisplayClass29_0()
    {
    
    }
    internal bool <FindLevelIndexOfWord>b__0(SLC.Minigames.ImageQuiz.QuizLevelData data)
    {
        return System.String.op_Equality(a:  data.word.ToLowerInvariant(), b:  this.word.ToLowerInvariant());
    }

}
