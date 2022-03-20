using UnityEngine;
public class PersistentGameObject : MonoBehaviour
{
    // Fields
    public static System.Collections.Generic.List<string> persistentObjects;
    public bool makeRootPersistent;
    public bool unparentFromRootOnStart;
    private string superName;
    
    // Methods
    protected virtual void Awake()
    {
        var val_10;
        var val_11;
        if(this.makeRootPersistent != false)
        {
                if(this.transform.root != null)
        {
            goto label_3;
        }
        
        }
        
        label_3:
        UnityEngine.GameObject val_3 = this.gameObject;
        this.superName = NGUITools.GetHierarchy(obj:  this.gameObject);
        val_10 = null;
        val_10 = null;
        if((PersistentGameObject.persistentObjects.Contains(item:  this.superName)) != false)
        {
                UnityEngine.Object.Destroy(obj:  val_3);
            return;
        }
        
        val_11 = null;
        val_11 = null;
        PersistentGameObject.persistentObjects.Add(item:  this.superName);
        UnityEngine.Object.DontDestroyOnLoad(target:  val_3);
        val_3.name = val_3.name + " (Persistent)";
        if(this.unparentFromRootOnStart == false)
        {
                return;
        }
        
        val_3.transform.parent = 0;
    }
    private void OnDestroy()
    {
        var val_3;
        var val_4;
        val_3 = null;
        val_3 = null;
        if((PersistentGameObject.persistentObjects.Contains(item:  this.superName)) == false)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        bool val_2 = PersistentGameObject.persistentObjects.Remove(item:  this.superName);
    }
    public PersistentGameObject()
    {
        this.superName = "";
    }
    private static PersistentGameObject()
    {
        PersistentGameObject.persistentObjects = new System.Collections.Generic.List<System.String>();
    }

}
