using UnityEngine;
public class ScreenFader : MonoBehaviour
{
    // Fields
    public static ScreenFader instance;
    public const float DURATION = 0.37;
    public bool isFading;
    public bool isLoadingScene;
    private UnityEngine.UI.Image bgImage;
    private const float fadeOutTime = 0.2;
    private const float fadeInTime = 0.2;
    
    // Methods
    private void Awake()
    {
        ScreenFader.fadeInTime = this;
        this.bgImage = this.GetComponent<UnityEngine.UI.Image>();
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
        this.bgImage.enabled = true;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bgImage, endValue:  1f, duration:  null), action:  new DG.Tweening.TweenCallback(object:  new ScreenFader.<>c__DisplayClass8_0(), method:  System.Void ScreenFader.<>c__DisplayClass8_0::<FadeOut>b__0())), autoKillOnCompletion:  true);
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
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bgImage, endValue:  0f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  new ScreenFader.<>c__DisplayClass9_0(), method:  System.Void ScreenFader.<>c__DisplayClass9_0::<FadeIn>b__0())), autoKillOnCompletion:  true);
        this.bgImage.sprite = 0;
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
        
        this.FadeOut(onComplete:  new System.Action(object:  new ScreenFader.<>c__DisplayClass10_0(), method:  System.Void ScreenFader.<>c__DisplayClass10_0::<GotoScene>b__0()));
    }
    private System.Collections.IEnumerator LoadTheSceneAsync(string sceneName)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .sceneName = sceneName;
        return (System.Collections.IEnumerator)new ScreenFader.<LoadTheSceneAsync>d__11();
    }
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ScreenFader::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ScreenFader::OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
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
        
        if(this.bgImage == 0)
        {
                return;
        }
        
        this.FadeIn(onComplete:  0);
    }
    public ScreenFader()
    {
    
    }

}
