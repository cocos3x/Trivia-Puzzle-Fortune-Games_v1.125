using UnityEngine;
public class BaseScene : MonoBehaviour
{
    // Methods
    private void Update()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        if((UnityEngine.Input.GetKey(key:  27)) == false)
        {
                return;
        }
        
        UnityEngine.Application.Quit();
    }
    public void LoadSettingsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "SettingsScene");
    }
    public BaseScene()
    {
    
    }

}
