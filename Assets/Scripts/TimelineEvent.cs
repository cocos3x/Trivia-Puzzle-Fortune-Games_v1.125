using UnityEngine;
public struct TimelineEvent
{
    // Fields
    public TimelineEvent.Type type;
    public MainController.GameModeForTracking gameMode;
    public string word;
    public string levelWord;
    public string levelWords;
    public string language;
    public double stamp;
    public double delta;
    public bool isLevelWord;
    
    // Methods
    public override string ToString()
    {
        int val_3;
        int val_4;
        object[] val_1 = new object[9];
        val_1[0] = null;
        val_3 = val_1.Length;
        val_1[1] = this.gameMode;
        if(this.word != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[2] = this.word;
        if(this.levelWord != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[3] = this.levelWord;
        val_4 = val_1.Length;
        val_1[4] = this.isLevelWord;
        if(this.levelWords != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[5] = this.levelWords;
        if(this.language != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[6] = this.language;
        val_1[7] = this.stamp;
        val_1[8] = this.delta;
        return (string)System.String.Format(format:  "[TimelineEvent: type: {0} gameMode: {1} word: {2} levelWord: {3} isLevelword: {4} levelWords: {5} language: {6} stamp: {7} delta: {8}]", args:  val_1);
    }

}
