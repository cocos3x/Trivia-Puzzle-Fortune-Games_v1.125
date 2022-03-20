using UnityEngine;
public class NetworkThreadingHandler : MonoBehaviour
{
    // Fields
    private const int MIN_DELAY = 3;
    private const int MAX_DELAY = 4;
    public static bool HackThrottle;
    public twelvegigs.net.JsonRequest Request;
    private System.Action dequeueLogic;
    private int delayRequest;
    private int delayResponse;
    private string loadedScene;
    
    // Properties
    set; }
    
    // Methods
    public void set_DequeueLogic(System.Action value)
    {
        this.dequeueLogic = value;
    }
    private void Awake()
    {
        this.loadedScene = UnityEngine.Application.loadedLevelName;
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NetworkThreadingHandler::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new NetworkThreadingHandler.<Start>d__12();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if(this.Request == null)
        {
                return;
        }
        
        if(this.Request._destroy == false)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  this.loadedScene, b:  UnityEngine.Application.loadedLevelName)) == false)
        {
                return;
        }
        
        this.Request = 0;
        if(this.dequeueLogic != null)
        {
                this.dequeueLogic.Invoke();
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void Dequeue()
    {
        if(this.dequeueLogic == null)
        {
                return;
        }
        
        this.dequeueLogic.Invoke();
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NetworkThreadingHandler::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private System.Collections.IEnumerator SitIdle()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new NetworkThreadingHandler.<SitIdle>d__16();
    }
    private System.Collections.IEnumerator ExecuteRequest()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new NetworkThreadingHandler.<ExecuteRequest>d__17();
    }
    private void CleanupRequest()
    {
        this.Request = 0;
        UnityEngine.Object.Destroy(obj:  this.gameObject);
        if(this.dequeueLogic == null)
        {
                return;
        }
        
        this.dequeueLogic.Invoke();
    }
    public NetworkThreadingHandler()
    {
        this.loadedScene = System.String.alignConst;
    }
    private static NetworkThreadingHandler()
    {
    
    }

}
