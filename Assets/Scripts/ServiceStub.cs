using UnityEngine;
[Serializable]
private class SRServiceManager.ServiceStub
{
    // Fields
    public System.Func<object> Constructor;
    public System.Type InterfaceType;
    public System.Func<System.Type> Selector;
    public System.Type Type;
    
    // Methods
    public override string ToString()
    {
        object val_4;
        System.Type val_5;
        object val_6;
        val_4 = this.InterfaceType + " (";
        if((System.Type.op_Inequality(left:  this.Type, right:  0)) != false)
        {
                val_5 = this.Type;
            val_6 = "Type: ";
        }
        else
        {
                val_5 = this.Selector;
            if(val_5 != null)
        {
                val_6 = "Selector: ";
        }
        else
        {
                val_5 = this.Constructor;
            if(val_5 == null)
        {
                return val_4 + ")";
        }
        
            val_6 = "Constructor: ";
        }
        
        }
        
        val_4 = val_4 + val_6 + val_5;
        return val_4 + ")";
    }
    public SRServiceManager.ServiceStub()
    {
    
    }

}
