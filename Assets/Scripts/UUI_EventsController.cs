using UnityEngine;
public class UUI_EventsController : MonoSingleton<UUI_EventsController>
{
    // Fields
    private UnityEngine.EventSystems.EventSystem eventSystem;
    
    // Methods
    public static void EnableInputs()
    {
        UUI_EventsController val_1 = MonoSingleton<UUI_EventsController>.Instance;
        val_1.eventSystem.enabled = true;
    }
    public static void DisableInputs()
    {
        UUI_EventsController val_1 = MonoSingleton<UUI_EventsController>.Instance;
        val_1.eventSystem.enabled = false;
    }
    private void Start()
    {
        UnityEngine.EventSystems.EventSystem val_5;
        if(this.eventSystem == 0)
        {
                UnityEngine.EventSystems.EventSystem val_2 = this.GetComponent<UnityEngine.EventSystems.EventSystem>();
            val_5 = val_2;
            this.eventSystem = val_2;
        }
        else
        {
                val_5 = this.eventSystem;
        }
        
        if(val_5 != 0)
        {
                UnityEngine.EventSystems.EventSystem.current = this.eventSystem;
        }
        
        UnityEngine.GameObject val_4 = this.gameObject;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_4);
        val_4.SetDragThresholdByDPI();
        val_4.DisallowNavigationEvents();
        UnityEngine.Input.multiTouchEnabled = false;
    }
    private void SetDragThresholdByDPI()
    {
        UnityEngine.EventSystems.EventSystem val_1 = UnityEngine.EventSystems.EventSystem.current;
        UnityEngine.EventSystems.EventSystem val_2 = UnityEngine.EventSystems.EventSystem.current;
        float val_5 = (float)val_1.m_DragThreshold;
        val_5 = UnityEngine.Screen.dpi * val_5;
        val_5 = val_5 / 160f;
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        val_2.m_DragThreshold = UnityEngine.Mathf.Max(a:  val_1.m_DragThreshold, b:  (int)val_5);
    }
    private void DisallowNavigationEvents()
    {
        UnityEngine.EventSystems.EventSystem val_1 = UnityEngine.EventSystems.EventSystem.current;
        val_1.m_sendNavigationEvents = false;
    }
    private void DisallowInputMultiTouch()
    {
        UnityEngine.Input.multiTouchEnabled = false;
    }
    public UUI_EventsController()
    {
    
    }

}
