using UnityEngine;
public class UGUIFadeCanvasGroup : MonoBehaviour
{
    // Fields
    public float fadeFrom;
    public float fadeTo;
    public float duration;
    public float delay;
    public bool runOnce;
    public bool runOnEnable;
    public bool doOnDeferredDataReady;
    public bool alwaysRunOnSceneLoad;
    public bool setInterativeOnComplete;
    public bool setBlockRayCastOnComplete;
    private bool ranAlready;
    private UnityEngine.CanvasGroup canvasGroup;
    private DG.Tweening.Tweener fadeTweener;
    
    // Methods
    private void Awake()
    {
        var val_8;
        System.Action<SceneType> val_9;
        this.canvasGroup = this.GetComponent<UnityEngine.CanvasGroup>();
        if(this.doOnDeferredDataReady != false)
        {
                val_8 = null;
            val_8 = null;
            WordApp.DeferredGameUIReadyEvent.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UGUIFadeCanvasGroup::WordAppStartedEvent()));
        }
        
        val_9 = 1152921504893267968;
        if((MonoSingletonSelfGenerating<SceneDictator>.Instance) == 0)
        {
                return;
        }
        
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        val_9 = val_5.OnSceneLoaded;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_9, b:  new System.Action<SceneType>(object:  this, method:  typeof(UGUIFadeCanvasGroup).__il2cppRuntimeField_178));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_5.OnSceneLoaded = val_7;
        return;
        label_14:
    }
    private void WordAppStartedEvent()
    {
        this.Execute();
    }
    public virtual void SceneLoaded(SceneType sceneType)
    {
        var val_1;
        if(this.alwaysRunOnSceneLoad == false)
        {
            goto label_1;
        }
        
        label_8:
        this.Execute();
        return;
        label_1:
        if(this.doOnDeferredDataReady == false)
        {
                return;
        }
        
        val_1 = null;
        val_1 = null;
        if(WordApp.deferredEventHasFired == true)
        {
            goto label_8;
        }
    
    }
    private void OnEnable()
    {
        if(this.runOnEnable == false)
        {
                return;
        }
        
        this.Execute();
    }
    public void Execute()
    {
        if((this.runOnce != false) && (this.ranAlready != false))
        {
                return;
        }
        
        this.ranAlready = true;
        if(this.delay == 0f)
        {
                this.TweenIt();
            return;
        }
        
        this.canvasGroup.alpha = this.fadeFrom;
        this.CancelInvoke();
        this.Invoke(methodName:  "TweenIt", time:  this.delay);
    }
    private void TweenIt()
    {
        this.canvasGroup.alpha = this.fadeFrom;
        this.fadeTweener = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  this.fadeTo, duration:  this.duration), ease:  1), action:  new DG.Tweening.TweenCallback(object:  this, method:  typeof(UGUIFadeCanvasGroup).__il2cppRuntimeField_188)), autoKillOnCompletion:  true);
    }
    protected virtual void OnCompletedTween()
    {
        if(this.setInterativeOnComplete != false)
        {
                this.canvasGroup.interactable = true;
        }
        
        if(this.setBlockRayCastOnComplete == false)
        {
                return;
        }
        
        this.canvasGroup.blocksRaycasts = true;
    }
    private void OnDestroy()
    {
        var val_7;
        if(this.fadeTweener != null)
        {
                DG.Tweening.TweenExtensions.Complete(t:  this.fadeTweener, withCallbacks:  true);
        }
        
        if((MonoSingletonSelfGenerating<SceneDictator>.Instance) != 0)
        {
                SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  typeof(UGUIFadeCanvasGroup).__il2cppRuntimeField_178));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
            val_3.OnSceneLoaded = val_5;
        }
        
        val_7 = null;
        val_7 = null;
        WordApp.DeferredGameUIReadyEvent.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UGUIFadeCanvasGroup::WordAppStartedEvent()));
        return;
        label_11:
    }
    public UGUIFadeCanvasGroup()
    {
        this.fadeTo = 1;
        this.runOnEnable = true;
    }

}
