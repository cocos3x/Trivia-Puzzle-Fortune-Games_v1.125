using UnityEngine;
public class DebugBanner : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform staticBanner;
    private UnityEngine.UI.Text staticBannerText;
    private UnityEngine.Transform dynamicBanner;
    private UnityEngine.GameObject dynamicLogPrefab;
    private float dynamicLogTime;
    private FrameSkipper frameSkipper;
    private static bool isInitialized;
    
    // Methods
    private void Awake()
    {
        var val_11;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_4;
        }
        
        val_11 = null;
        val_11 = null;
        if(DebugBanner.isInitialized == false)
        {
            goto label_7;
        }
        
        label_4:
        UnityEngine.Object.DestroyImmediate(obj:  this.gameObject);
        return;
        label_7:
        DebugBanner.isInitialized = true;
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_8 = System.Delegate.Combine(a:  val_6.updateLogic, b:  new System.Action(object:  this, method:  System.Void DebugBanner::UpdateStaticLog()));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_17;
        }
        
        }
        
        val_6.updateLogic = val_8;
        MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.dynamicBanner);
        this.ToggleDebugBanner();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "UpdateDynamicLog");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "ToggleDebugBanner");
        return;
        label_17:
    }
    private void UpdateStaticLog()
    {
        Player val_1 = App.Player;
        Player val_3 = App.Player;
        string val_8 = System.String.Format(format:  "{0} {1} {2}", arg0:  (val_1.isHacker == false) ? "" : "Hacker", arg1:  (val_3.isTroll == false) ? "" : "Troll", arg2:  (App.Player.NetworkPurchaser != true) ? "NetworkPurchaser" : "");
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UpdateDynamicLog(Notification notif)
    {
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.dynamicLogPrefab, parent:  this.dynamicBanner);
        string val_2 = notif.data.ToString();
        DebugBannerLog val_3 = val_1.GetComponent<DebugBannerLog>();
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.DestroyLogCoroutine(obj:  val_1));
    }
    private System.Collections.IEnumerator DestroyLogCoroutine(UnityEngine.GameObject obj)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .obj = obj;
        return (System.Collections.IEnumerator)new DebugBanner.<DestroyLogCoroutine>d__10();
    }
    private void ToggleDebugBanner()
    {
        int val_1 = UnityEngine.PlayerPrefs.GetInt(key:  "isDebugBannerShown", defaultValue:  0);
        this.staticBanner.gameObject.SetActive(value:  (val_1 == 1) ? 1 : 0);
        this.dynamicBanner.gameObject.SetActive(value:  (val_1 == 1) ? 1 : 0);
    }
    public DebugBanner()
    {
        this.dynamicLogTime = 3f;
    }
    private static DebugBanner()
    {
    
    }

}
