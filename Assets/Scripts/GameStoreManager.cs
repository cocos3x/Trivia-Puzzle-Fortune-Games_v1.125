using UnityEngine;
public class GameStoreManager : MonoSingletonSelfGenerating<GameStoreManager>
{
    // Fields
    private System.Action<bool, bool> currentStoreCloseCallback;
    private System.Action onStoreSceneLoadedAction;
    public static string StoreCategoryFocus;
    
    // Methods
    public void ShowStore(string categoryFocus, System.Action<bool, bool> storeCloseCallback)
    {
        if((System.String.IsNullOrEmpty(value:  categoryFocus)) != true)
        {
                GameStoreManager.StoreCategoryFocus = categoryFocus;
        }
        
        MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.TakeCameraStateSnapshot();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.LoadStoreScene(storeCloseCallback:  storeCloseCallback));
    }
    private System.Collections.IEnumerator LoadStoreScene(System.Action<bool, bool> storeCloseCallback)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .storeCloseCallback = storeCloseCallback;
        return (System.Collections.IEnumerator)new GameStoreManager.<LoadStoreScene>d__4();
    }
    public void HandleStoreClose(bool purchased, bool runCallbacks = True, bool forceClose = False)
    {
        if((MonoSingleton<GameStoreWindowManager>.Instance) != 0)
        {
                GameStoreWindowManager val_3 = MonoSingleton<GameStoreWindowManager>.Instance;
            val_3.canShowWindows = false;
        }
        
        if(runCallbacks == false)
        {
            goto label_9;
        }
        
        if(this.currentStoreCloseCallback == null)
        {
            goto label_11;
        }
        
        this.currentStoreCloseCallback.Invoke(arg1:  purchased, arg2:  forceClose);
        goto label_11;
        label_9:
        this.currentStoreCloseCallback = 0;
        label_11:
        this.currentStoreCloseCallback = 0;
        GameBehavior val_6 = App.getBehavior;
        UnityEngine.AsyncOperation val_7 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_6.<metaGameBehavior>k__BackingField);
        MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.RestoreCameraStateSnapshot();
    }
    public GameStoreManager()
    {
    
    }

}
