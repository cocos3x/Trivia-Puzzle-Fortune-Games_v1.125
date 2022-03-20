using UnityEngine;
public class NetworkConnectivityPinger : MonoSingleton<NetworkConnectivityPinger>
{
    // Fields
    private static bool _LastPingSuccess;
    public const string NOTIF_NETWORK_CONNECT_RESPONSE = "OnNetworkConnectivityResponse";
    public System.Action<bool> OnPingDone;
    private float time_between_pings;
    private float time_out;
    private float time_accum;
    private bool alreadyPinging;
    private UnityEngine.Coroutine routine;
    
    // Properties
    public static bool Connected { get; }
    
    // Methods
    public static bool get_Connected()
    {
        null = null;
        return (bool)NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE;
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus != false)
        {
                if(this.routine != null)
        {
                this.StopCoroutine(routine:  this.routine);
        }
        
            this.alreadyPinging = false;
            return;
        }
        
        this.PingGoogle();
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.time_accum + val_1;
        this.time_accum = val_1;
        if(val_1 < this.time_between_pings)
        {
                return;
        }
        
        this.PingGoogle();
    }
    public void PingGoogle()
    {
        this.time_accum = 0f;
        if(this.alreadyPinging == true)
        {
                return;
        }
        
        this.alreadyPinging = true;
        if(this.routine != null)
        {
                this.StopCoroutine(routine:  this.routine);
        }
        
        this.routine = this.StartCoroutine(routine:  this.DoPingGoogle());
    }
    private System.Collections.IEnumerator DoPingGoogle()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new NetworkConnectivityPinger.<DoPingGoogle>d__13();
    }
    private void DoLog(string text)
    {
    
    }
    private void OnDestroy()
    {
    
    }
    public NetworkConnectivityPinger()
    {
        this.time_accum = 60f;
        this.time_between_pings = 60f;
        this.time_out = 10f;
    }
    private static NetworkConnectivityPinger()
    {
    
    }

}
