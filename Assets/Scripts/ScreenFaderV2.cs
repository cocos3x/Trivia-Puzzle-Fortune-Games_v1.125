using UnityEngine;
public class ScreenFaderV2 : MonoSingleton<ScreenFaderV2>
{
    // Fields
    public static ScreenFaderV2 instance;
    public const float DURATION = 0.37;
    public bool isFading;
    public bool isLoadingScene;
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.GameObject backgroundCopy;
    private const float fadeOutTime = 0.2;
    private const float fadeInTime = 0.2;
    
    // Methods
    public override void InitMonoSingleton()
    {
        ScreenFaderV2.fadeInTime = this;
        UnityEngine.CanvasGroup val_1 = this.GetComponent<UnityEngine.CanvasGroup>();
        this.canvasGroup = val_1;
        val_1.enabled = true;
    }
    public void FadeOut(System.Action onComplete)
    {
        .<>4__this = this;
        .onComplete = onComplete;
        if(this.isFading != false)
        {
                return;
        }
        
        this.isFading = true;
        this.canvasGroup.interactable = true;
        this.canvasGroup.blocksRaycasts = true;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  new ScreenFaderV2.<>c__DisplayClass9_0(), method:  System.Void ScreenFaderV2.<>c__DisplayClass9_0::<FadeOut>b__0())), autoKillOnCompletion:  true);
    }
    public void FadeIn(System.Action onComplete)
    {
        .<>4__this = this;
        .onComplete = onComplete;
        if(this.isFading != false)
        {
                return;
        }
        
        this.isFading = true;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  0f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  new ScreenFaderV2.<>c__DisplayClass10_0(), method:  System.Void ScreenFaderV2.<>c__DisplayClass10_0::<FadeIn>b__0())), autoKillOnCompletion:  true);
    }
    public void GotoScene(string sceneName)
    {
        .<>4__this = this;
        .sceneName = sceneName;
        if(this.isFading == true)
        {
                return;
        }
        
        if(this.isLoadingScene != false)
        {
                return;
        }
        
        this.FindNewBackground();
        this.FadeOut(onComplete:  new System.Action(object:  new ScreenFaderV2.<>c__DisplayClass11_0(), method:  System.Void ScreenFaderV2.<>c__DisplayClass11_0::<GotoScene>b__0()));
    }
    private System.Collections.IEnumerator LoadTheSceneAsync(string sceneName)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .sceneName = sceneName;
        return (System.Collections.IEnumerator)new ScreenFaderV2.<LoadTheSceneAsync>d__12();
    }
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ScreenFaderV2::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ScreenFaderV2::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.isLoadingScene = false;
        if(this == 0)
        {
                return;
        }
        
        if(this.gameObject == 0)
        {
                return;
        }
        
        if(this.canvasGroup == 0)
        {
                return;
        }
        
        this.FadeIn(onComplete:  0);
    }
    private void FindNewBackground()
    {
        if(this.backgroundCopy != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.backgroundCopy);
        }
        
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  UnityEngine.GameObject.FindWithTag(tag:  "background_image"), parent:  this.transform);
        this.backgroundCopy = val_4;
        UnityEngine.Canvas val_5 = val_4.GetComponent<UnityEngine.Canvas>();
        if(val_5 != 0)
        {
                UnityEngine.Object.Destroy(obj:  val_5);
        }
        
        this.backgroundCopy.tag = "Untagged";
    }
    public ScreenFaderV2()
    {
    
    }

}
