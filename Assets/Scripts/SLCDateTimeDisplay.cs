using UnityEngine;
public class SLCDateTimeDisplay : MonoSingleton<SLCDateTimeDisplay>
{
    // Fields
    private UnityEngine.GameObject uiobject;
    private UnityEngine.UI.Text label;
    
    // Methods
    private void OnEnable()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(DateTimeCheat._mSeconds != 0)
        {
                val_3 = 1;
        }
        else
        {
                val_3 = 0;
        }
        
        this.uiobject.SetActive(value:  false);
        string val_1 = DateTimeCheat.GetSimulatedDate();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public static void UpdateDateTimeDisplay()
    {
        var val_7;
        var val_8;
        if((MonoSingleton<SLCDateTimeDisplay>.Instance) == 0)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        if(DateTimeCheat._mSeconds != 0)
        {
                SLCDateTimeDisplay val_3 = MonoSingleton<SLCDateTimeDisplay>.Instance;
            val_8 = 1;
        }
        else
        {
                SLCDateTimeDisplay val_4 = MonoSingleton<SLCDateTimeDisplay>.Instance;
            val_8 = 0;
        }
        
        val_4.uiobject.SetActive(value:  false);
        SLCDateTimeDisplay val_5 = MonoSingleton<SLCDateTimeDisplay>.Instance;
        string val_6 = DateTimeCheat.GetSimulatedDate();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public SLCDateTimeDisplay()
    {
    
    }

}
