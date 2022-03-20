using UnityEngine;
private sealed class Alphabet2Manager.<>c__DisplayClass132_0
{
    // Fields
    public Alphabet2Manager <>4__this;
    public Alphabet2Manager.Rarity rarity;
    
    // Methods
    public Alphabet2Manager.<>c__DisplayClass132_0()
    {
    
    }
    internal bool <RollLettersForRarity>b__0(System.Collections.Generic.KeyValuePair<string, float> kvp)
    {
        var val_5;
        .kvp = X1;
        mem[1152921516028423096] = X2;
        if((this.<>4__this.uncommonThreshold) < 0)
        {
                val_5 = 0;
        }
        else
        {
                if((this.<>4__this.rareThreshold) < 0)
        {
                val_5 = 1;
        }
        
        }
        
        if((((this.<>4__this.superThreshold) < 0) ? 2 : 3) != this.rarity)
        {
                return false;
        }
        
        return System.Linq.Enumerable.Any<System.String>(source:  this.<>4__this.GetCurrentCollection, predicate:  new System.Func<System.String, System.Boolean>(object:  new Alphabet2Manager.<>c__DisplayClass132_1(), method:  System.Boolean Alphabet2Manager.<>c__DisplayClass132_1::<RollLettersForRarity>b__2(string s)));
    }

}
