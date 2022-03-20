using UnityEngine;
public class AppLoader : MonoBehaviour
{
    // Methods
    private void Awake()
    {
        var val_11;
        string val_12;
        GameNames val_3 = WordApp.GetGameEnum(game:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "perGameConfigs/currentGame").text);
        val_11 = null;
        App.game = val_3;
        val_11 = null;
        App.game = val_3;
        val_11 = null;
        val_11 = null;
        val_12 = App.game.ToString();
        UnityEngine.GameObject val_6 = UnityEngine.Resources.Load<UnityEngine.GameObject>(path:  "game/"("game/") + val_12 + "/WordApp_"("/WordApp_") + val_12);
        if(val_6 == 0)
        {
                val_12 = "App.LoadNameAndConfig(): Could not load WordApp_"("App.LoadNameAndConfig(): Could not load WordApp_") + val_12 + ".prefab";
            UnityEngine.Debug.LogError(message:  val_12);
        }
        
        UnityEngine.GameObject val_9 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_6);
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public AppLoader()
    {
    
    }

}
