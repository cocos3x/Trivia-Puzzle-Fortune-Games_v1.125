using UnityEngine;
public class SceneDictator : MonoSingletonSelfGenerating<SceneDictator>
{
    // Fields
    public System.Action<SceneType> OnSceneLoaded;
    public System.Action<SceneType> OnSceneUnloaded;
    private static SceneType lastOverlayedScene;
    private readonly System.Collections.Generic.List<SceneType> acceptableActiveSceneTypes;
    
    // Methods
    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void SceneDictator::HandleUnitySceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)));
        UnityEngine.SceneManagement.SceneManager.add_sceneUnloaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void SceneDictator::HandleUnitySceneUnloaded(UnityEngine.SceneManagement.Scene arg0)));
    }
    private void HandleUnitySceneUnloaded(UnityEngine.SceneManagement.Scene arg0)
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        string val_2 = arg0.m_Handle.name;
        if(this.OnSceneUnloaded != null)
        {
                this.OnSceneUnloaded.Invoke(obj:  val_1.<metaGameBehavior>k__BackingField);
        }
        
        GameBehavior val_3 = App.getBehavior;
        UnityEngine.SceneManagement.Scene val_4 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string val_5 = val_4.m_Handle.name;
        val_6 = null;
        val_6 = null;
        SceneDictator.lastOverlayedScene = val_3.<metaGameBehavior>k__BackingField;
    }
    private void HandleUnitySceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        var val_5;
        GameBehavior val_1 = App.getBehavior;
        string val_2 = arg0.m_Handle.name;
        if((this.acceptableActiveSceneTypes.Contains(item:  val_1.<metaGameBehavior>k__BackingField)) != false)
        {
                bool val_4 = UnityEngine.SceneManagement.SceneManager.SetActiveScene(scene:  new UnityEngine.SceneManagement.Scene() {m_Handle = arg0.m_Handle});
        }
        
        val_5 = null;
        val_5 = null;
        SceneDictator.lastOverlayedScene = val_1.<metaGameBehavior>k__BackingField;
        if(this.OnSceneLoaded == null)
        {
                return;
        }
        
        this.OnSceneLoaded.Invoke(obj:  val_1.<metaGameBehavior>k__BackingField);
    }
    public static bool IsInGameScene()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0;
    }
    public static SceneType GetActiveSceneType()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_2B0;
    }
    public static SceneType GetOverlayedSceneType()
    {
        null = null;
        return (SceneType)SceneDictator.lastOverlayedScene;
    }
    public SceneDictator()
    {
        System.Collections.Generic.List<SceneType> val_1 = new System.Collections.Generic.List<SceneType>();
        val_1.Add(item:  1);
        val_1.Add(item:  2);
        val_1.Add(item:  4);
        val_1.Add(item:  3);
        val_1.Add(item:  5);
        this.acceptableActiveSceneTypes = val_1;
    }
    private static SceneDictator()
    {
    
    }

}
