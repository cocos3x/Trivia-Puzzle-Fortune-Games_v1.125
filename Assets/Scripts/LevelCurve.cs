using UnityEngine;
public class WADataParser.LevelCurve
{
    // Fields
    public string Bucket;
    public string Language;
    public System.Collections.Generic.List<GameLevel> Levels;
    
    // Methods
    public WADataParser.LevelCurve(string language, string bucket, System.Collections.Generic.List<GameLevel> flattenedLevels)
    {
        val_1 = new System.Object();
        this.Bucket = val_1;
        this.Language = language;
        this.Levels = new System.Collections.Generic.List<GameLevel>(collection:  flattenedLevels);
    }

}
