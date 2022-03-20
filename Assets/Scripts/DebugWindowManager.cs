using UnityEngine;
public class DebugWindowManager : MonoSingleton<DebugWindowManager>
{
    // Fields
    private PrefabsFromFolder prefabsFromFolder;
    private System.Collections.Generic.Dictionary<string, UnityEngine.GameObject> loadedWindows;
    
    // Methods
    private void Start()
    {
    
    }
    public T ShowWindow<T>()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this)) == false)
        {
                return (object)this;
        }
        
        this.gameObject.SetActive(value:  true);
        return (object)this;
    }
    private T GetWindow<T>()
    {
        var val_18;
        var val_19;
        var val_20;
        val_18 = __RuntimeMethodHiddenParam;
        val_19 = this;
        if(this.prefabsFromFolder == 0)
        {
                this.prefabsFromFolder = this.GetComponent<PrefabsFromFolder>();
        }
        
        val_20 = 1152921504623353856;
        if(((this.loadedWindows.ContainsKey(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}))) != false) && ((this.loadedWindows.Item[System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48})]) != 0))
        {
                val_19 = ???;
            val_18 = ???;
            val_20 = ???;
        }
        else
        {
                val_19 + 32.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_18 + 48}), value:  val_19 + 24.gameObject);
            return (object)val_19 + 24;
        }
    
    }
    public DebugWindowManager()
    {
        this.loadedWindows = new System.Collections.Generic.Dictionary<System.String, UnityEngine.GameObject>();
    }

}
