using UnityEngine;
private sealed class Alphabet2Manager.<>c__DisplayClass142_0
{
    // Fields
    public string word;
    public int letterIndex;
    
    // Methods
    public Alphabet2Manager.<>c__DisplayClass142_0()
    {
    
    }
    internal bool <HasCollectedWordAtIndex>b__0(string x)
    {
        if((x.StartsWith(value:  this.word)) == false)
        {
                return false;
        }
        
        return System.Linq.Enumerable.ToArray<System.Char>(source:  System.Linq.Enumerable.Skip<System.Char>(source:  x, count:  this.word.m_stringLength))[(this.letterIndex) << 1][32].Equals(obj:  '1');
    }

}
