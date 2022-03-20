using UnityEngine;
public class WGTaskDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text taskText;
    
    // Methods
    private void OnEnable()
    {
        if((MonoSingleton<WGTaskController>.Instance) != 0)
        {
                if((MonoSingleton<WGTaskController>.Instance.isRelevent) != false)
        {
                string val_11 = System.String.Format(format:  Localization.Localize(key:  "new_user_task_field", defaultValue:  "Complete Level {0} to unlock {1}", useSingularKey:  false), arg0:  (MonoSingleton<WGTaskController>.Instance.getNextUnlockLevel()) - 1, arg1:  MonoSingleton<WGTaskController>.Instance.getNextUnlockableEvent());
            return;
        }
        
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public WGTaskDisplay()
    {
    
    }

}
