using UnityEngine;
public class LightningCountdownButton : MonoBehaviour
{
    // Fields
    private UnityEngine.Sprite lightningWords;
    private UnityEngine.Sprite lightningLevels;
    private UnityEngine.UI.Text countdown;
    private UnityEngine.UI.Button eventButton;
    private int defaultFontSize;
    
    // Methods
    private void Awake()
    {
        this.eventButton = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LightningCountdownButton::ShowEventListPopup()));
        this.defaultFontSize = this.countdown.resizeTextMaxSize;
        List.Enumerator<T> val_9 = System.Linq.Enumerable.ToList<UnityEngine.UI.Image>(source:  System.Linq.Enumerable.Where<UnityEngine.UI.Image>(source:  this.GetComponentsInChildren<UnityEngine.UI.Image>(includeInactive:  true), predicate:  new System.Func<UnityEngine.UI.Image, System.Boolean>(object:  this, method:  System.Boolean LightningCountdownButton::<Awake>b__5_0(UnityEngine.UI.Image x)))).GetEnumerator();
        label_9:
        if(0.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_11 = (LightningWordsHandler.DEFAULT_REWARD_VALUE == 0) ? 32 : 24;
        0.sprite = null;
        goto label_9;
        label_6:
        0.Dispose();
    }
    public void SetupCountdownText(string text, int size = 0)
    {
        this.countdown.resizeTextMaxSize = this.defaultFontSize;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void ShowEventListPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGEventsListPopup>(showNext:  false);
    }
    public LightningCountdownButton()
    {
    
    }
    private bool <Awake>b__5_0(UnityEngine.UI.Image x)
    {
        return UnityEngine.Object.op_Inequality(x:  x.gameObject, y:  this.gameObject);
    }

}
