using UnityEngine;
public class FadeToBGTag : MonoBehaviour
{
    // Methods
    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void FadeToBGTag::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        UnityEngine.GameObject val_1 = UnityEngine.GameObject.FindWithTag(tag:  "background_image");
        if(val_1 == 0)
        {
                return;
        }
        
        UnityEngine.UI.Image val_4 = val_1.GetComponent<UnityEngine.UI.Image>();
        this.GetComponent<UnityEngine.UI.Image>().sprite = val_4.m_Sprite;
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void FadeToBGTag::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    public FadeToBGTag()
    {
    
    }

}
