using UnityEngine;
public class WindowTransitionTween : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup windowCanvasGroup;
    private WindowTransitionTween.Direction enterDirection;
    private UnityEngine.RectTransform rectTransform;
    private bool postWindowCloseNotification;
    private float tweenDuration;
    private WGWindow wgWindow;
    private DG.Tweening.Ease easeType;
    
    // Methods
    private UnityEngine.Vector2 GetPosition(WindowTransitionTween.Direction direction)
    {
        var val_12 = this;
        if(direction <= 4)
        {
                var val_11 = 32497904 + (direction) << 2;
            val_11 = val_11 + 32497904;
        }
        else
        {
                UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            return new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
        }
    
    }
    private void Awake()
    {
        this.rectTransform = this.GetComponent<UnityEngine.RectTransform>();
        this.windowCanvasGroup = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        if(this.postWindowCloseNotification == false)
        {
                return;
        }
        
        WGWindow val_4 = this.GetComponent<WGWindow>();
        this.wgWindow = val_4;
        if((UnityEngine.Object.op_Implicit(exists:  val_4)) != false)
        {
                mem2[0] = 0;
            return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "WindowTransitionTween \'" + this.gameObject.name + "\' doesn\'t have a WGWindow component");
    }
    private void OnEnable()
    {
        this.windowCanvasGroup.interactable = false;
        this.SetInitialPosition();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.EnableLate());
    }
    private void Start()
    {
        this.SetInitialPosition();
    }
    private void SetInitialPosition()
    {
        if(this.enterDirection == 99)
        {
                return;
        }
        
        if(this.enterDirection == 4)
        {
                UnityEngine.Vector2 val_1 = this.GetPosition(direction:  this.enterDirection);
            this.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
            this.rectTransform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
            this.windowCanvasGroup.alpha = 0f;
            return;
        }
        
        UnityEngine.Vector2 val_3 = this.GetPosition(direction:  this.enterDirection);
        this.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }
    private System.Collections.IEnumerator EnableLate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WindowTransitionTween.<EnableLate>d__13();
    }
    public void TweenOffScreenAndDisable()
    {
        Direction val_19;
        float val_20;
        DG.Tweening.TweenCallback val_21;
        val_19 = this.enterDirection;
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) <= 1)
        {
            goto label_8;
        }
        
        if(val_19 > 3)
        {
            goto label_25;
        }
        
        var val_19 = 32497924 + (this.enterDirection) << 2;
        val_19 = val_19 + 32497924;
        goto (32497924 + (this.enterDirection) << 2 + 32497924);
        label_8:
        UnityEngine.Vector2 val_3 = this.GetPosition(direction:  null);
        val_20 = val_3.x;
        label_25:
        if((UnityEngine.Object.op_Implicit(exists:  this.wgWindow)) != false)
        {
                val_21 = NotificationCenter.DefaultCenter;
            val_21.PostNotification(aSender:  this.wgWindow, aName:  SLCWindowManager<T>.color_show_available_popups);
        }
        
        if(this.enterDirection == 99)
        {
            goto label_17;
        }
        
        if(this.enterDirection != 4)
        {
            goto label_18;
        }
        
        UnityEngine.Vector3 val_7 = this.transform.localScale;
        val_20 = val_7.x;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_20, y = val_7.y, z = val_7.z}, d:  0.95f);
        DG.Tweening.TweenCallback val_11 = null;
        val_21 = val_11;
        val_11 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WindowTransitionTween::TweenOffScreenComplete());
        DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.rectTransform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  this.tweenDuration), ease:  this.easeType), action:  val_11);
        DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.windowCanvasGroup, endValue:  0f, duration:  this.tweenDuration), ease:  this.easeType);
        goto label_23;
        label_17:
        this.TweenOffScreenComplete();
        goto label_23;
        label_18:
        DG.Tweening.TweenCallback val_17 = null;
        val_21 = val_17;
        val_17 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WindowTransitionTween::TweenOffScreenComplete());
        DG.Tweening.Tweener val_18 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.rectTransform, endValue:  new UnityEngine.Vector2() {x = val_20, y = val_3.y}, duration:  this.tweenDuration, snapping:  false), ease:  this.easeType), action:  val_17);
        label_23:
        this.windowCanvasGroup.interactable = false;
    }
    private void TweenOffScreenComplete()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void SetInteractable()
    {
        if(this.windowCanvasGroup != null)
        {
                this.windowCanvasGroup.interactable = true;
            return;
        }
        
        throw new NullReferenceException();
    }
    public WindowTransitionTween()
    {
        this.enterDirection = 4;
        this.postWindowCloseNotification = true;
        this.tweenDuration = 0.3f;
        this.easeType = 6;
    }

}
