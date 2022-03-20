using UnityEngine;
public class SuperLuckySROptionsController
{
    // Methods
    public static void OpenGameSpecificOptionsController()
    {
        var val_9;
        GameBehavior val_2 = App.getBehavior;
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_9 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  val_2.<hackBehavior>k__BackingField);
        AppConfigs val_4 = App.Configuration;
        if(val_4.minigamesConfig.minigames < 1)
        {
                return;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_9 = 12;
        SRDebug.Instance.AddOptionContainer(container:  new MinigameOptionsButton());
    }
    public SuperLuckySROptionsController()
    {
    
    }

}
