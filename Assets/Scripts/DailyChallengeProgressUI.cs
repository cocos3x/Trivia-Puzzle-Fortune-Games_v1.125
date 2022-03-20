using UnityEngine;
public class DailyChallengeProgressUI : MonoBehaviour
{
    // Fields
    private const float progressBarTickRate = 0.3;
    private const float transitionFadeDuration = 0.8;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressBarText;
    private UGUINetworkedButton collectButton;
    private UnityEngine.UI.Text collectButtonText;
    private UnityEngine.Transform giftTransform;
    private System.Action onCollectClicked;
    private int currentProgress;
    private int maxProgress;
    
    // Methods
    private void Start()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  this.collectButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void DailyChallengeProgressUI::OnCollectButtonClicked(bool connected)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.collectButton.OnConnectionClick = val_2;
        return;
        label_3:
    }
    public void InitializeWeeklyProgress(int starsToAnimate = 0)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        this.UpdateUI(currentProgress:  UnityEngine.Mathf.Max(a:  val_1.weekHistory.stars - starsToAnimate, b:  0), maxProgress:  val_1.<Econ>k__BackingField.RequiredWeeklyStars, onCollect:  new System.Action(object:  val_1, method:  public System.Void WGDailyChallengeManager::CollectWeeklyReward()), rewardAvailable:  val_1.IsWeekRewardAvailable());
    }
    public void InitializeMonthlyProgress(int starsToAnimate = 0)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        this.UpdateUI(currentProgress:  UnityEngine.Mathf.Max(a:  val_1.monthHistory.stars - starsToAnimate, b:  0), maxProgress:  val_1.<Econ>k__BackingField.RequiredMonthlyStars, onCollect:  new System.Action(object:  val_1, method:  public System.Void WGDailyChallengeManager::CollectMonthlyReward()), rewardAvailable:  val_1.IsMonthRewardAvailable());
    }
    public void UpdateUI(int currentProgress, int maxProgress, System.Action onCollect, bool rewardAvailable)
    {
        this.currentProgress = UnityEngine.Mathf.Min(a:  currentProgress, b:  maxProgress);
        this.maxProgress = maxProgress;
        this.onCollectClicked = 0;
        System.Delegate val_2 = System.Delegate.Combine(a:  0, b:  onCollect);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        this.onCollectClicked = val_2;
        string val_3 = val_2.GetProgressBarText(currentAmount:  currentProgress, maxAount:  maxProgress);
        float val_10 = (float)currentProgress;
        val_10 = val_10 / (float)maxProgress;
        this.progressBar.gameObject.SetActive(value:  (currentProgress < maxProgress) ? 1 : 0);
        this.collectButton.gameObject.SetActive(value:  (currentProgress >= maxProgress) ? 1 : 0);
        this.collectButton.interactable = rewardAvailable;
        var val_9 = (rewardAvailable != true) ? "TAP TO COLLECT!" : "COMPLETED";
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_4:
    }
    public void TweenProgressBar(int amount, float delay = 0)
    {
        DG.Tweening.Tweener val_14;
        DailyChallengeProgressUI val_15;
        val_14 = amount;
        val_15 = this;
        DailyChallengeProgressUI.<>c__DisplayClass14_0 val_1 = new DailyChallengeProgressUI.<>c__DisplayClass14_0();
        .<>4__this = val_15;
        .delay = delay;
        if(val_14 < 1)
        {
                return;
        }
        
        int val_14 = this.currentProgress;
        val_14 = val_14 - val_14;
        .previousProgress = (float)val_14;
        string val_2 = val_1.GetProgressBarText(currentAmount:  (int)(float)val_14, maxAount:  this.maxProgress);
        float val_15 = (DailyChallengeProgressUI.<>c__DisplayClass14_0)[1152921517472212256].previousProgress;
        val_15 = val_15 / (float)this.maxProgress;
        this.progressBar.gameObject.SetActive(value:  true);
        this.collectButton.gameObject.SetActive(value:  false);
        float val_16 = 0.3f;
        val_16 = (float)val_14 * val_16;
        val_14 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single DailyChallengeProgressUI.<>c__DisplayClass14_0::<TweenProgressBar>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void DailyChallengeProgressUI.<>c__DisplayClass14_0::<TweenProgressBar>b__1(float x)), endValue:  (float)this.currentProgress, duration:  val_16), delay:  (DailyChallengeProgressUI.<>c__DisplayClass14_0)[1152921517472212256].delay);
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  0.2f, y:  0.2f, z:  0.2f);
        DG.Tweening.Tweener val_11 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.giftTransform, punch:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.4f, vibrato:  2, elasticity:  0f), delay:  (DailyChallengeProgressUI.<>c__DisplayClass14_0)[1152921517472212256].delay);
        if(this.currentProgress < this.maxProgress)
        {
                return;
        }
        
        DG.Tweening.TweenCallback val_12 = null;
        val_15 = val_12;
        val_12 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void DailyChallengeProgressUI.<>c__DisplayClass14_0::<TweenProgressBar>b__2());
        DG.Tweening.Tweener val_13 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_14, action:  val_12);
    }
    private void OnCollectButtonClicked(bool connected)
    {
        if(connected == false)
        {
                return;
        }
        
        this.collectButton.interactable = false;
        if(this.onCollectClicked == null)
        {
                return;
        }
        
        this.onCollectClicked.Invoke();
    }
    private string GetProgressBarText(int currentAmount, int maxAount)
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  currentAmount, arg1:  maxAount);
    }
    public DailyChallengeProgressUI()
    {
    
    }

}
