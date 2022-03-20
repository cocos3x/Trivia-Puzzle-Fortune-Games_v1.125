using UnityEngine;
public class MinigameOptionsButton : SuperLuckySROptionsParent<MinigameOptionsButton>, INotifyPropertyChanged
{
    // Methods
    public void MinigamesHacks()
    {
        var val_10;
        var val_12;
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_10 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Minigames>.Instance);
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_10 = 13;
        val_12 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        var val_11 = 0;
        val_11 = val_11 + 1;
        val_12 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
    }
    public MinigameOptionsButton()
    {
    
    }

}
