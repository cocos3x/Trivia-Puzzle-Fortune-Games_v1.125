using UnityEngine;
private sealed class WordHuntEvent.<>c__DisplayClass105_1
{
    // Fields
    public string exWord;
    
    // Methods
    public WordHuntEvent.<>c__DisplayClass105_1()
    {
    
    }
    internal bool <GetEventWordsAvailableInLevel>b__1(string x)
    {
        return System.String.op_Equality(a:  x, b:  this.exWord);
    }

}
