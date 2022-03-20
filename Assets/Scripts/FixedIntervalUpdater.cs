using UnityEngine;
public class FixedIntervalUpdater : MonoBehaviour
{
    // Fields
    public System.Action updateLogic;
    public float updateInterval;
    
    // Methods
    private void Start()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FixedIntervalUpdate());
    }
    protected System.Collections.IEnumerator FixedIntervalUpdate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FixedIntervalUpdater.<FixedIntervalUpdate>d__3();
    }
    protected virtual void UpdateLogic()
    {
    
    }
    public FixedIntervalUpdater()
    {
        var val_2;
        System.Action val_4;
        val_2 = null;
        val_2 = null;
        val_4 = FixedIntervalUpdater.<>c.<>9__5_0;
        if(val_4 == null)
        {
                System.Action val_1 = null;
            val_4 = val_1;
            val_1 = new System.Action(object:  FixedIntervalUpdater.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FixedIntervalUpdater.<>c::<.ctor>b__5_0());
            FixedIntervalUpdater.<>c.<>9__5_0 = val_4;
        }
        
        this.updateLogic = val_4;
        this.updateInterval = 1f;
    }

}
