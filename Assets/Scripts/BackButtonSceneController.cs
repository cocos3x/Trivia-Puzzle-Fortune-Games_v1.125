using UnityEngine;
public class BackButtonSceneController : MonoBehaviour
{
    // Methods
    private void OnEnable()
    {
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void BackButtonSceneController::HandleBackAction()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void BackButtonSceneController::HandleBackAction()));
    }
    private void HandleBackAction()
    {
        var val_14;
        if((MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows()) == true)
        {
            goto label_4;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance;
        if(1152921504893161472 == 0)
        {
            goto label_10;
        }
        
        label_4:
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void BackButtonSceneController::HandleBackAction()));
        return;
        label_10:
        val_14 = 1152921504884269056;
        GameBehavior val_6 = App.getBehavior;
        if((val_6.<metaGameBehavior>k__BackingField) == 1)
        {
                App.Quit();
            return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        if((val_7.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        GameBehavior val_8 = App.getBehavior;
        val_14 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public BackButtonSceneController()
    {
    
    }

}
