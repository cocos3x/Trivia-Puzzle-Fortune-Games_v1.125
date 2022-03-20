using UnityEngine;
public class AdsUIController_HideBanner : MonoBehaviour
{
    // Methods
    private void Awake()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  public System.Void AdsUIController_HideBanner::OnSceneChanged(SceneType type)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public void OnSceneChanged(SceneType type)
    {
        MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
    }
    public AdsUIController_HideBanner()
    {
    
    }

}
