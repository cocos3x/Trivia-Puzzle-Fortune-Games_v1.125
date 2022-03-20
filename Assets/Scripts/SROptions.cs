using UnityEngine;
public class SROptions
{
    // Fields
    private static readonly SROptions _current;
    private SROptionsPropertyChanged PropertyChanged;
    
    // Properties
    public static SROptions Current { get; }
    
    // Methods
    public static SROptions get_Current()
    {
        null = null;
        return (SROptions)SROptions._current;
    }
    public void add_PropertyChanged(SROptionsPropertyChanged value)
    {
        do
        {
            if((System.Delegate.Combine(a:  this.PropertyChanged, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.PropertyChanged != 1152921516983312080);
        
        return;
        label_2:
    }
    public void remove_PropertyChanged(SROptionsPropertyChanged value)
    {
        do
        {
            if((System.Delegate.Remove(source:  this.PropertyChanged, value:  value)) != null)
        {
                if(null != "GBK")
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.PropertyChanged != 1152921516983448656);
        
        return;
        label_2:
    }
    public void OnPropertyChanged(string propertyName)
    {
        if(this.PropertyChanged == null)
        {
                return;
        }
        
        this.PropertyChanged.Invoke(sender:  this, propertyName:  propertyName);
    }
    public SROptions()
    {
    
    }
    private static SROptions()
    {
        SROptions._current = new SROptions();
    }

}
