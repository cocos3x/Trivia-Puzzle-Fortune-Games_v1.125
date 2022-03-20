using UnityEngine;
public class SuperLuckySROptionsParent<T> : SROptions
{
    // Fields
    protected static T _Instance;
    private System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    // Properties
    public static T Instance { get; }
    
    // Methods
    public static T get_Instance()
    {
        var val_1;
        var val_2;
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
        {
                val_1 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 302;
            val_2 = __RuntimeMethodHiddenParam + 24;
            if((val_1 & 1) == 0)
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 24];
            val_2 = __RuntimeMethodHiddenParam + 24;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (SROptions_Ads)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        
        return (SROptions_Ads)__RuntimeMethodHiddenParam + 24 + 192 + 184;
    }
    public void add_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value)
    {
        label_4:
        if((System.Delegate.Combine(a:  41947136, b:  value)) == null)
        {
            goto label_1;
        }
        
        if(X0 == true)
        {
            goto label_2;
        }
        
        goto label_3;
        label_1:
        label_2:
        if(41947136 != 1152921516984621912)
        {
            goto label_4;
        }
        
        return;
        label_3:
    }
    public void remove_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value)
    {
        label_4:
        if((System.Delegate.Remove(source:  41947136, value:  value)) == null)
        {
            goto label_1;
        }
        
        if(X0 == true)
        {
            goto label_2;
        }
        
        goto label_3;
        label_1:
        label_2:
        if(41947136 != 1152921516984750296)
        {
            goto label_4;
        }
        
        return;
        label_3:
    }
    public virtual void DoOnPropertyChanged(string propertyName)
    {
        if(==0)
        {
                return;
        }
        
        Invoke(sender:  this, e:  new System.ComponentModel.PropertyChangedEventArgs(propertyName:  propertyName));
    }
    public SuperLuckySROptionsParent<T>()
    {
    
    }

}
