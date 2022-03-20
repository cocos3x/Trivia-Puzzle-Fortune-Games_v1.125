using UnityEngine;
private sealed class TRVUtils.<>c__DisplayClass5_1
{
    // Fields
    public string cat;
    public System.Func<string, bool> <>9__2;
    
    // Methods
    public TRVUtils.<>c__DisplayClass5_1()
    {
    
    }
    internal bool <Init>b__0(TRVIconConfig.TRVIcon x)
    {
        var val_7;
        System.Func<System.String, System.Boolean> val_8;
        if((System.String.op_Equality(a:  x.name.ToLower(), b:  this.cat.ToLower())) != false)
        {
                val_7 = 1;
            return (bool)((System.Linq.Enumerable.Count<System.String>(source:  x.translations, predicate:  System.Func<System.String, System.Boolean> val_4 = null)) > 0) ? 1 : 0;
        }
        
        val_8 = this.<>9__2;
        if(val_8 != null)
        {
                return (bool)((System.Linq.Enumerable.Count<System.String>(source:  x.translations, predicate:  val_4)) > 0) ? 1 : 0;
        }
        
        val_8 = val_4;
        val_4 = new System.Func<System.String, System.Boolean>(object:  this, method:  System.Boolean TRVUtils.<>c__DisplayClass5_1::<Init>b__2(string z));
        this.<>9__2 = val_8;
        return (bool)((System.Linq.Enumerable.Count<System.String>(source:  x.translations, predicate:  val_4)) > 0) ? 1 : 0;
    }
    internal bool <Init>b__2(string z)
    {
        return System.String.op_Equality(a:  z.ToLower(), b:  this.cat.ToLower());
    }

}
