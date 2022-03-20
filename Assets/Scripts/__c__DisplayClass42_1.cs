using UnityEngine;
private sealed class WADChapterManager.<>c__DisplayClass42_1
{
    // Fields
    public System.Collections.Generic.List<GameLevel> levelSkipLevels;
    public int levelSkipStartIndex;
    
    // Methods
    public WADChapterManager.<>c__DisplayClass42_1()
    {
    
    }
    internal bool <GetGameLevelForPlayerLevelFromChapter>b__4(SkippedLevel skippedLevel)
    {
        bool val_1 = true;
        if(val_1 <= this.levelSkipStartIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + ((this.levelSkipStartIndex) << 3);
        return skippedLevel.word.Equals(value:  (true + (this.levelSkipStartIndex) << 3) + 32 + 64);
    }

}
