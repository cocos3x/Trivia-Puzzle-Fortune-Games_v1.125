using UnityEngine;
public class ToggleOnAsyncSceneLoad : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject[] GoToToggle;
    private System.Collections.Generic.List<bool> curState;
    private SceneType sceneToWatch;
    
    // Methods
    private void Start()
    {
        if(this.GoToToggle == null)
        {
                return;
        }
        
        if(this.GoToToggle.Length == 0)
        {
                return;
        }
        
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void ToggleOnAsyncSceneLoad::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void ToggleOnAsyncSceneLoad::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        this.curState = new System.Collections.Generic.List<System.Boolean>();
        return;
        label_10:
    }
    private void OnDestroy()
    {
        if(this.GoToToggle == null)
        {
                return;
        }
        
        if(this.GoToToggle.Length == 0)
        {
                return;
        }
        
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void ToggleOnAsyncSceneLoad::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Remove(source:  val_4.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void ToggleOnAsyncSceneLoad::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        return;
        label_10:
    }
    private void Instance_OnSceneLoaded(SceneType obj)
    {
        var val_3;
        if(this.sceneToWatch != obj)
        {
                return;
        }
        
        this.curState.Clear();
        val_3 = 4;
        do
        {
            if((val_3 - 4) >= this.GoToToggle.Length)
        {
                return;
        }
        
            this.curState.Add(item:  this.GoToToggle[0].activeSelf);
            this.GoToToggle[0].SetActive(value:  false);
            val_3 = val_3 + 1;
        }
        while(this.GoToToggle != null);
        
        throw new NullReferenceException();
    }
    private void Instance_OnSceneUnloaded(SceneType obj)
    {
        var val_1;
        if(this.sceneToWatch != obj)
        {
                return;
        }
        
        val_1 = 0;
        do
        {
            if(val_1 >= this.GoToToggle.Length)
        {
                return;
        }
        
            if(this.GoToToggle.Length <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.GoToToggle[val_1].SetActive(value:  this.GoToToggle[val_1][val_1]);
            val_1 = val_1 + 1;
        }
        while(this.GoToToggle != null);
        
        throw new NullReferenceException();
    }
    public ToggleOnAsyncSceneLoad()
    {
        this.sceneToWatch = 4;
    }

}
