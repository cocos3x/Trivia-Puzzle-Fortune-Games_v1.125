using UnityEngine;
private sealed class MainController.<>c__DisplayClass77_0
{
    // Fields
    public System.Action<SceneType> onSceneLoaded;
    
    // Methods
    public MainController.<>c__DisplayClass77_0()
    {
    
    }
    internal void <OnCategoryPackCompletedClosed>b__0(SceneType s)
    {
        CategoryPacksMenuUI.ShowMainScreen();
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_2 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  this.onSceneLoaded);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_2;
        return;
        label_5:
    }

}
