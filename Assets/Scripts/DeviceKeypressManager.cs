using UnityEngine;
public class DeviceKeypressManager : MonoBehaviour
{
    // Fields
    private static System.Collections.Generic.List<System.Action> BackStack;
    
    // Methods
    private void Update()
    {
    
    }
    private static void DoFirstValidBackAction()
    {
        System.Collections.Generic.List<System.Action> val_4;
        var val_5;
        var val_6;
        goto label_9;
        label_14:
        if(((0 & 2) != 0) && (8 == 0))
        {
                val_4 = DeviceKeypressManager.BackStack;
        }
        
        var val_1 = (DeviceKeypressManager.BackStack + 24) - 1;
        if((DeviceKeypressManager.BackStack + 24) != 0)
        {
                val_5 = (DeviceKeypressManager.BackStack + 16) + (val_1 << 3);
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_4 = DeviceKeypressManager.BackStack;
            val_5 = (DeviceKeypressManager.BackStack + 16) + (val_1 << 3);
        }
        
        val_5 = val_5 + 32;
        val_4.RemoveAt(index:  (DeviceKeypressManager.BackStack + 24) - 1);
        if(val_5 != 0)
        {
            goto label_7;
        }
        
        label_9:
        val_6 = null;
        val_6 = null;
        if((DeviceKeypressManager.BackStack + 24) >= 1)
        {
            goto label_14;
        }
        
        return;
        label_7:
        val_5.Invoke();
    }
    public static void AddBackAction(System.Action backAction)
    {
    
    }
    public static void RemoveBackAction(System.Action backAction)
    {
    
    }
    private static string FormatAction(System.Action act)
    {
        return System.String.Format(format:  "{0}.{1}", arg0:  41975808, arg1:  act.Method);
    }
    public DeviceKeypressManager()
    {
    
    }
    private static DeviceKeypressManager()
    {
        DeviceKeypressManager.BackStack = new System.Collections.Generic.List<System.Action>();
    }

}
