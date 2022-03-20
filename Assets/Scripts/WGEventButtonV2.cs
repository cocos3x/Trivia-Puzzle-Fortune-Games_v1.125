using UnityEngine;
public class WGEventButtonV2 : MonoBehaviour
{
    // Fields
    protected UnityEngine.CanvasGroup canvasGroup;
    protected UnityEngine.UI.Image icon;
    protected UnityEngine.UI.Image notifBadgeIcon;
    protected UGUINetworkedButton eventButton;
    protected UnityEngine.UI.Text buttonLabel;
    protected UnityEngine.ParticleSystem efxUpdate;
    protected WGEventHandler eventHandler;
    public int slotIndex;
    
    // Properties
    public UnityEngine.CanvasGroup CanvasGroup { get; }
    public UnityEngine.UI.Image Icon { get; }
    public UGUINetworkedButton Button { get; }
    public UnityEngine.UI.Text Label { get; }
    public UnityEngine.ParticleSystem EfxUpdate { get; }
    public WGEventHandler EventHandler { get; }
    public string EventType { get; }
    
    // Methods
    public UnityEngine.CanvasGroup get_CanvasGroup()
    {
        return (UnityEngine.CanvasGroup)this.canvasGroup;
    }
    public UnityEngine.UI.Image get_Icon()
    {
        return (UnityEngine.UI.Image)this.icon;
    }
    public UGUINetworkedButton get_Button()
    {
        return (UGUINetworkedButton)this.eventButton;
    }
    public UnityEngine.UI.Text get_Label()
    {
        return (UnityEngine.UI.Text)this.buttonLabel;
    }
    public UnityEngine.ParticleSystem get_EfxUpdate()
    {
        return (UnityEngine.ParticleSystem)this.efxUpdate;
    }
    public WGEventHandler get_EventHandler()
    {
        return (WGEventHandler)this.eventHandler;
    }
    public string get_EventType()
    {
        var val_2;
        if(this.eventHandler != null)
        {
                val_2 = mem[this.eventHandler.myEvent == null ? "" : this.eventHandler.myEvent.type];
            val_2 = (this.eventHandler.myEvent == 0) ? "" : this.eventHandler.myEvent.type;
            return (string)val_2;
        }
        
        val_2 = 0;
        return (string)val_2;
    }
    protected virtual void Start()
    {
        if(this.eventButton == 0)
        {
                return;
        }
        
        System.Delegate val_3 = System.Delegate.Combine(a:  this.eventButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  typeof(WGEventButtonV2).__il2cppRuntimeField_1A8));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        this.eventButton.OnConnectionClick = val_3;
        return;
        label_6:
    }
    public virtual void Initialize(WGEventHandler handler)
    {
        this.eventHandler = handler;
    }
    public virtual void Refresh()
    {
        if(this.eventHandler == null)
        {
                return;
        }
        
        this.notifBadgeIcon.gameObject.SetActive(value:  this.eventHandler & 1);
    }
    protected virtual void OnButtonClick(bool isConnected)
    {
        var val_6;
        var val_7;
        val_6 = this;
        if(this.eventHandler != null)
        {
                val_7 = isConnected;
            if((this.eventHandler & 1) == 0)
        {
                if((this.eventHandler & 1) == 0)
        {
            goto label_3;
        }
        
        }
        
        }
        
        val_6 = ???;
        val_7 = ???;
        goto typeof(WGEventButtonV2).__il2cppRuntimeField_1B0;
        label_3:
        var val_3 = val_7 & 1;
        goto val_6 + 72 + 592;
    }
    public virtual void OnEventEnded()
    {
        UnityEngine.Transform val_2 = this.gameObject.transform;
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_2, endValue:  -500f, duration:  1f, snapping:  false), ease:  26), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventButtonV2::<OnEventEnded>b__26_0()));
        return;
        label_3:
    }
    public virtual void ShowIntroAnimation()
    {
        this.canvasGroup.alpha = 0f;
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void WGEventButtonV2::<ShowIntroAnimation>b__27_0()), count:  1);
    }
    public WGEventButtonV2()
    {
        this.slotIndex = 0;
    }
    private void <OnEventEnded>b__26_0()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void <ShowIntroAnimation>b__27_0()
    {
        UnityEngine.Transform val_2 = this.gameObject.transform;
        if(null == null)
        {
                UnityEngine.Vector2 val_3 = val_2.anchoredPosition;
            UnityEngine.Vector2 val_4 = val_2.anchoredPosition;
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  500f, y:  0f);
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, b:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
            val_2.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
            DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  val_2, endValue:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, duration:  1f, snapping:  false), ease:  27);
            DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  1f);
            return;
        }
    
    }

}
