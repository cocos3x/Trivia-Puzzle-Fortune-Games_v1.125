using UnityEngine;
public class LevelDefinition
{
    // Fields
    public int Chapter;
    public int Level;
    public int ChapterLevel;
    
    // Methods
    public override string ToString()
    {
        return (string)System.String.Format(format:  "[Chapter:{0}, Level:{1}, ChapterLevel:{2}]", arg0:  this.Chapter, arg1:  this.Level, arg2:  this.ChapterLevel);
    }
    public LevelDefinition()
    {
    
    }

}
