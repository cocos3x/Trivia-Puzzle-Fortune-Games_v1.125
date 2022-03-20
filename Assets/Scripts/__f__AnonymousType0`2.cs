using UnityEngine;
internal sealed class __f__AnonymousType0__value_j__TPar, _index_j__TPar_
{
    // Fields
    private readonly <value>j__TPar <value>i__Field;
    private readonly <index>j__TPar <index>i__Field;
    
    // Properties
    public <value>j__TPar value { get; }
    public <index>j__TPar index { get; }
    
    // Methods
    public <value>j__TPar get_value()
    {
        return (StarTier)this;
    }
    public <index>j__TPar get_index()
    {
        return (int)this;
    }
    public __f__AnonymousType0__value_j__TPar, _index_j__TPar_(<value>j__TPar value, <index>j__TPar index)
    {
        mem[1152921513385287312] = value;
        mem[1152921513385287320] = index;
    }
    public override bool Equals(object value)
    {
        var val_7;
        var val_8;
        val_7 = value;
        val_8 = this;
        if(X0 == false)
        {
                return false;
        }
        
        val_7 = X0;
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 8) & 1) == 0)
        {
                return false;
        }
        
        val_8 = ???;
        val_7 = ???;
        goto __RuntimeMethodHiddenParam + 24 + 192 + 32 + 432;
    }
    public override int GetHashCode()
    {
        var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 32;
        val_2 = (val_2 + ((__RuntimeMethodHiddenParam + 24 + 192 + 8) * 2773833001)) + 1743440079;
        return (int)val_2;
    }
    public override string ToString()
    {
        object[] val_1 = new object[2];
        if(null == 0)
        {
            goto label_1;
        }
        
        label_10:
        val_1[0] = 1152921505054202560;
        val_1[1] = val_1.Length.ToString();
        return (string)System.String.Format(provider:  0, format:  "{{ value = {0}, index = {1} }}", args:  val_1);
        label_1:
        if(val_1 != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
    }

}
