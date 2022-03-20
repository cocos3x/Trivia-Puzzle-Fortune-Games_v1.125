using UnityEngine;
public class WGExtraChapterEventProgressPopup : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
    // Fields
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.UI.Text currentMultiplierText;
    private bool canClick;
    private int frameSkips;
    
    // Methods
    public void Init(float currentMultiplier)
    {
        string val_1 = ExtraChapterEventHandler._Instance.TimeRemainingFormatted;
        this.canClick = false;
    }
    public System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGExtraChapterEventProgressPopup.<Start>d__5();
    }
    private void Update()
    {
        if(UnityEngine.Input.touchCount <= 0)
        {
                if((UnityEngine.Input.GetMouseButton(button:  0)) != true)
        {
                if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
            goto label_3;
        }
        
        }
        
        }
        
        if(this.canClick == false)
        {
            goto label_3;
        }
        
        int val_5 = this.frameSkips;
        if(val_5 < 2)
        {
            goto label_4;
        }
        
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
        return;
        label_3:
        this.frameSkips = 0;
        return;
        label_4:
        val_5 = val_5 + 1;
        this.frameSkips = val_5;
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData data)
    {
        this.canClick = false;
        this.frameSkips = 0;
    }
    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.canClick = false;
        this.frameSkips = 0;
    }
    public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.canClick = true;
    }
    public WGExtraChapterEventProgressPopup()
    {
    
    }

}
