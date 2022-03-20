using UnityEngine;
public class ForestFrenzyMonolithProxy : MonoBehaviour
{
    // Fields
    public static ForestFrenzyMonolithProxy Instance;
    
    // Methods
    private void Awake()
    {
        ForestFrenzyMonolithProxy.Instance = this;
    }
    private void OnEnable()
    {
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  val_1.<metaGameBehavior>k__BackingField, mode:  1);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public ForestFrenzyMonolithProxy()
    {
    
    }

}
