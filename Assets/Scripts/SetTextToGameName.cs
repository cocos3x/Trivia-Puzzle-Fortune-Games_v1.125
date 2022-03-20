using UnityEngine;
public class SetTextToGameName : MonoBehaviour
{
    // Methods
    private void Start()
    {
        var val_13;
        var val_14;
        val_13 = this;
        val_14 = 1152921504884269056;
        if(App.Configuration == 0)
        {
                return;
        }
        
        AppConfigs val_3 = App.Configuration;
        if(val_3.appConfig == 0)
        {
                return;
        }
        
        UnityEngine.UI.Text val_5 = this.GetComponent<UnityEngine.UI.Text>();
        AppConfigs val_6 = App.Configuration;
        val_13 = ???;
        val_14 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public SetTextToGameName()
    {
    
    }

}
