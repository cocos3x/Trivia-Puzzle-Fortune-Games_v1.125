using UnityEngine;
public class WGManagerLoader : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject[] managers;
    public static bool hasLoadedManagers;
    
    // Methods
    private void Awake()
    {
        var val_13;
        UnityEngine.Object val_14;
        val_13 = null;
        val_13 = null;
        if(WGManagerLoader.hasLoadedManagers != false)
        {
                val_14 = this.gameObject;
            UnityEngine.Object.Destroy(obj:  val_14);
            return;
        }
        
        label_26:
        if(0 >= this.managers.Length)
        {
            goto label_8;
        }
        
        if(this.managers[0] == 0)
        {
                UnityEngine.Debug.LogError(message:  "Missing Manager index: "("Missing Manager index: ") + 0.ToString(), context:  this);
        }
        else
        {
                UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.managers[0], parent:  this.transform);
            if((val_6.tag.Contains(value:  "PreserveInMinigames")) != false)
        {
                val_6.transform.parent = 0;
            UnityEngine.Object.DontDestroyOnLoad(target:  val_6.gameObject);
        }
        
        }
        
        var val_11 = 0 + 1;
        if(this.managers != null)
        {
            goto label_26;
        }
        
        throw new NullReferenceException();
        label_8:
        this.transform.SetParent(p:  0);
        val_14 = this.gameObject;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_14);
    }
    private void Start()
    {
        null = null;
        WGManagerLoader.hasLoadedManagers = true;
    }
    public void KillYourself()
    {
        null = null;
        WGManagerLoader.hasLoadedManagers = false;
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public WGManagerLoader()
    {
    
    }
    private static WGManagerLoader()
    {
    
    }

}
