using UnityEngine;
public class AnimatedTransitionUIElement : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private bool spineAnimation;
    public float outDelay;
    private bool TransitionIn;
    private UnityEngine.Events.UnityAction actionToExecute;
    private Spine.Unity.SkeletonGraphic spineObject;
    
    // Methods
    private void Awake()
    {
        this.canvasGroup = this.GetComponent<UnityEngine.CanvasGroup>();
        this.actionToExecute = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AnimatedTransitionUIElement::OnLevelComplete());
        if(this.spineAnimation == false)
        {
                return;
        }
        
        this.spineObject = this.GetComponent<Spine.Unity.SkeletonGraphic>();
        this.actionToExecute = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AnimatedTransitionUIElement::SpineOnLevelComplete());
    }
    private void Start()
    {
        if(MainController.instance != 0)
        {
                MainController val_3 = MainController.instance;
            val_3.onBeforeLevelComplete.AddListener(call:  this.actionToExecute);
            MainController val_4 = MainController.instance;
            this.outDelay = UnityEngine.Mathf.Min(a:  this.outDelay, b:  val_4.levelCompleteDelay);
            if(this.TransitionIn != false)
        {
                if(this.gameObject.activeInHierarchy != false)
        {
                UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.StartLate());
        }
        
        }
        
        }
        
        if(WordRegion.instance != 0)
        {
                WordRegion val_12 = WordRegion.instance;
            val_12.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AnimatedTransitionUIElement::OnWordRegionLevelComplete()));
        }
        
        if(MainController.instance != 0)
        {
                return;
        }
        
        if(WordRegion.instance != 0)
        {
                return;
        }
        
        this.enabled = false;
    }
    private System.Collections.IEnumerator StartLate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new AnimatedTransitionUIElement.<StartLate>d__8();
    }
    private void OnWordRegionLevelComplete()
    {
        if((this.GetComponent<UnityEngine.UI.Button>()) == 0)
        {
                return;
        }
        
        this.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
    private void OnLevelComplete()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        float val_3 = this.canvasGroup.alpha;
        this.FadeTo(duration:  0.25f, from:  null, to:  0f, doDelay:  true);
    }
    private void FadeTo(float duration, float from, float to, bool doDelay)
    {
        if((this.GetComponent<UnityEngine.UI.Button>()) != 0)
        {
                this.GetComponent<UnityEngine.UI.Button>().interactable = (to > 0f) ? 1 : 0;
        }
        
        DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  to, duration:  duration), delay:  this.outDelay);
    }
    private void SpineOnLevelComplete()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.spineObject)) == false)
        {
                return;
        }
        
        this = this.spineObject;
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOColor(target:  this, endValue:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a}, duration:  0.75f);
    }
    public AnimatedTransitionUIElement()
    {
    
    }

}
