using UnityEngine;
private sealed class WordHuntEvent.<>c__DisplayClass105_0
{
    // Fields
    public LineWord wordLine;
    
    // Methods
    public WordHuntEvent.<>c__DisplayClass105_0()
    {
    
    }
    internal bool <GetEventWordsAvailableInLevel>b__0(string x)
    {
        if(this.wordLine != null)
        {
                return System.String.op_Equality(a:  x, b:  this.wordLine.answer);
        }
        
        throw new NullReferenceException();
    }

}
