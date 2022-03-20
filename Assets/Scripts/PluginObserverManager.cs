using UnityEngine;
public class PluginObserverManager : MonoSingletonSelfGenerating<PluginObserverManager>
{
    // Fields
    private System.Collections.Generic.List<PluginObserver> pluginObservers;
    public static bool isPurchaseValidationWorking;
    
    // Properties
    public System.Collections.Generic.List<PluginObserver> Observers { get; }
    
    // Methods
    public System.Collections.Generic.List<PluginObserver> get_Observers()
    {
        return (System.Collections.Generic.List<PluginObserver>)this.pluginObservers;
    }
    private void _init()
    {
        this.pluginObservers = new System.Collections.Generic.List<PluginObserver>();
    }
    private void Awake()
    {
        this._init();
    }
    public void AddObserver(PluginObserver observer)
    {
        if(this.pluginObservers == null)
        {
                this._init();
        }
        
        this.pluginObservers.Add(item:  observer);
    }
    public System.Collections.Generic.Dictionary<string, string> Status(PluginObserverManager.ObserverType _type)
    {
        var val_3;
        var val_4;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        if(this.pluginObservers == null)
        {
                return val_1;
        }
        
        List.Enumerator<T> val_2 = this.pluginObservers.GetEnumerator();
        label_24:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_12 = val_3;
        if((val_3 + 294) == 0)
        {
            goto label_7;
        }
        
        var val_10 = val_3 + 176;
        var val_11 = 0;
        val_10 = val_10 + 8;
        label_6:
        if(((val_3 + 176 + 8) + -8) == null)
        {
            goto label_5;
        }
        
        val_11 = val_11 + 1;
        val_10 = val_10 + 16;
        if(val_11 < (val_3 + 294))
        {
            goto label_6;
        }
        
        goto label_7;
        label_5:
        val_12 = val_12 + (((val_3 + 176 + 8)) << 4);
        val_11 = val_12 + 304;
        label_7:
        if(val_3.getType() == _type)
        {
            goto label_8;
        }
        
        var val_15 = val_3;
        if((val_3 + 294) == 0)
        {
            goto label_12;
        }
        
        var val_13 = val_3 + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_11:
        if(((val_3 + 176 + 8) + -8) == null)
        {
            goto label_10;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (val_3 + 294))
        {
            goto label_11;
        }
        
        goto label_12;
        label_10:
        val_15 = val_15 + (((val_3 + 176 + 8)) << 4);
        val_12 = val_15 + 304;
        label_12:
        if((_type > 1) || (val_3.getType() != 2))
        {
            goto label_24;
        }
        
        label_8:
        var val_19 = val_3;
        if((val_3 + 294) == 0)
        {
            goto label_18;
        }
        
        var val_16 = val_3 + 176;
        var val_17 = 0;
        val_16 = val_16 + 8;
        label_17:
        if(((val_3 + 176 + 8) + -8) == null)
        {
            goto label_16;
        }
        
        val_17 = val_17 + 1;
        val_16 = val_16 + 16;
        if(val_17 < (val_3 + 294))
        {
            goto label_17;
        }
        
        goto label_18;
        label_16:
        var val_18 = val_16;
        val_18 = val_18 + 1;
        val_19 = val_19 + val_18;
        val_13 = val_19 + 304;
        label_18:
        var val_23 = val_3;
        if((val_3 + 294) == 0)
        {
            goto label_22;
        }
        
        var val_20 = val_3 + 176;
        var val_21 = 0;
        val_20 = val_20 + 8;
        label_21:
        if(((val_3 + 176 + 8) + -8) == null)
        {
            goto label_20;
        }
        
        val_21 = val_21 + 1;
        val_20 = val_20 + 16;
        if(val_21 < (val_3 + 294))
        {
            goto label_21;
        }
        
        goto label_22;
        label_20:
        var val_22 = val_20;
        val_22 = val_22 + 2;
        val_23 = val_23 + val_22;
        val_14 = val_23 + 304;
        label_22:
        val_1.Add(key:  val_3.pluginName(), value:  val_3.errorMessage());
        goto label_24;
        label_2:
        val_4.Dispose();
        return val_1;
    }
    public PluginObserverManager()
    {
    
    }
    private static PluginObserverManager()
    {
        PluginObserverManager.isPurchaseValidationWorking = true;
    }

}
