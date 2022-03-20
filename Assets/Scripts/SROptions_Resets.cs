using UnityEngine;
public class SROptions_Resets : SuperLuckySROptionsParent<SROptions_Resets>, INotifyPropertyChanged
{
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_8;
        var val_11;
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_8 = 13;
        val_11 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_11 = 12;
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
    }
    public void ResetInvites()
    {
        null = null;
        Player val_1 = App.Player;
        App.networkManager.DoPost(path:  System.String.Format(format:  "/api/word/resets/{0}/recruits", arg0:  val_1.id), postBody:  0, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    public SROptions_Resets()
    {
    
    }

}
