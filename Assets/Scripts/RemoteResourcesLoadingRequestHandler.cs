using UnityEngine;
public class RemoteResourcesLoadingRequestHandler : MonoBehaviour
{
    // Fields
    public UnityEngine.Networking.UnityWebRequest req;
    public System.Action<bool, byte[]> callback;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
    }
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new RemoteResourcesLoadingRequestHandler.<Start>d__3();
    }
    private System.Collections.IEnumerator ExecuteRequest()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new RemoteResourcesLoadingRequestHandler.<ExecuteRequest>d__4();
    }
    private void CleanupRequest()
    {
        this.req = 0;
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public RemoteResourcesLoadingRequestHandler()
    {
    
    }

}
