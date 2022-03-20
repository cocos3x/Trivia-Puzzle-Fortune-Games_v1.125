using UnityEngine;
public class EventListItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text viewEventButtonText;
    private UGUINetworkedButton button;
    private PrefabsFromFolder prefabs;
    private WGEventHandler myHandler;
    
    // Methods
    public void InitWithEventHandler(WGEventHandler handler)
    {
        IntPtr val_16;
        UnityEngine.UI.Text val_17;
        .handler = handler;
        this.myHandler = handler;
        if(SceneDictator.IsInGameScene() != false)
        {
                System.Action<System.Boolean> val_3 = new System.Action<System.Boolean>(object:  (EventListItem.<>c__DisplayClass6_0)[1152921516227263664].handler, method:  typeof(WGEventHandler).__il2cppRuntimeField_268);
            System.Delegate val_4 = System.Delegate.Combine(a:  this.button.OnConnectionClick, b:  null);
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
            this.button.OnConnectionClick = val_4;
            val_16 = 1152921516227135984;
        }
        else
        {
                System.Action<System.Boolean> val_5 = new System.Action<System.Boolean>(object:  (EventListItem.<>c__DisplayClass6_0)[1152921516227263664].handler, method:  typeof(WGEventHandler).__il2cppRuntimeField_258);
            System.Delegate val_6 = System.Delegate.Combine(a:  this.button.OnConnectionClick, b:  null);
            if(val_6 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
            this.button.OnConnectionClick = val_6;
            UnityEngine.Events.UnityAction val_7 = null;
            val_16 = 1152921516227149296;
        }
        
        val_7 = new UnityEngine.Events.UnityAction(object:  new EventListItem.<>c__DisplayClass6_0(), method:  val_16);
        this.button.OnConnectionClick.AddListener(call:  val_7);
        string val_10 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  (EventListItem.<>c__DisplayClass6_0)[1152921516227263664].handler);
        val_17 = this.viewEventButtonText;
        if((UnityEngine.Object.op_Implicit(exists:  val_17)) != false)
        {
                val_17 = this.viewEventButtonText;
        }
        
        this.SetTimerText(timeEnd:  new System.DateTime() {dateData = (EventListItem.<>c__DisplayClass6_0)[1152921516227263664].handler});
        UnityEngine.Coroutine val_13 = this.StartCoroutine(routine:  this.UpdateItem());
        return;
        label_13:
    }
    private System.Collections.IEnumerator UpdateItem()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new EventListItem.<UpdateItem>d__7();
    }
    private void SetTimerText(System.DateTime timeEnd)
    {
        object val_13;
        UnityEngine.UI.Text val_14;
        var val_15;
        WGEventHandler val_16;
        val_14 = this;
        if((System.String.IsNullOrEmpty(value:  this.myHandler)) == false)
        {
            goto label_2;
        }
        
        val_13 = 1152921504616751104;
        val_15 = null;
        val_15 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = timeEnd.dateData}, d2:  new System.DateTime() {dateData = System.DateTime.MaxValue})) == false)
        {
            goto label_5;
        }
        
        return;
        label_2:
        val_16 = this.myHandler;
        val_14 = this.timerText;
        if(val_14 != null)
        {
                return;
        }
        
        label_5:
        val_14 = this.timerText;
        object[] val_3 = new object[4];
        val_3[0] = this.myHandler.Days.ToString(format:  "0");
        val_3[1] = this.myHandler.Hours.ToString(format:  "0");
        val_3[2] = this.myHandler.Minutes.ToString(format:  "0");
        val_13 = this.myHandler.Seconds.ToString(format:  "0");
        val_3[3] = val_13;
        string val_12 = System.String.Format(format:  "{0}d {1}h {2}m {3}s", args:  val_3);
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public EventListItem()
    {
    
    }

}
