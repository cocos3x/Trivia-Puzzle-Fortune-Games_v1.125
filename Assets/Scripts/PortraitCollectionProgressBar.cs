using UnityEngine;
public class PortraitCollectionProgressBar : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image portraitImage;
    private UnityEngine.UI.Image progressBar;
    private UnityEngine.UI.Image readyToCollectionIcon;
    private TweenCoinsText progressText;
    private System.Action doOnAwake;
    private PortraitCollectionLevelCompleteButton levelCompleteButton;
    
    // Methods
    private void OnEnable()
    {
        if(this.doOnAwake != null)
        {
                this.doOnAwake.Invoke();
        }
        
        this.doOnAwake = 0;
    }
    public void Init(bool animate)
    {
        string val_69;
        float val_70;
        var val_71;
        PortraitCollectionProgressBar.<>c__DisplayClass7_0 val_1 = new PortraitCollectionProgressBar.<>c__DisplayClass7_0();
        .<>4__this = this;
        .animate = animate;
        if(this.gameObject.activeInHierarchy == false)
        {
            goto label_3;
        }
        
        if((((MonoSingleton<FPHPortraitCollectionController>.Instance) == 0) || ((MonoSingleton<FPHPortraitCollectionController>.Instance.IsEnabled()) == false)) || ((MonoSingleton<FPHPortraitCollectionController>.Instance.isEventActive()) == false))
        {
            goto label_16;
        }
        
        FPHPortraitCollectionController val_11 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_11.progress.collectionCompleted == false)
        {
            goto label_21;
        }
        
        this.portraitImage.gameObject.SetActive(value:  false);
        this.progressBar.fillAmount = 0f;
        goto label_25;
        label_3:
        this.doOnAwake = new System.Action(object:  val_1, method:  System.Void PortraitCollectionProgressBar.<>c__DisplayClass7_0::<Init>b__0());
        return;
        label_16:
        this.portraitImage.gameObject.SetActive(value:  false);
        this.progressBar.gameObject.SetActive(value:  false);
        label_25:
        Player val_16 = App.Player;
        decimal val_17 = System.Decimal.op_Implicit(value:  val_16._stars);
        this.progressText.Set(instantValue:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid});
        return;
        label_21:
        .targetStars = 0;
        this.readyToCollectionIcon.gameObject.SetActive(value:  false);
        FPHPortraitCollectionController val_19 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        FPHPortraitCollectionController val_20 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        if(val_20.progress.showUnlockedPortrait != false)
        {
                FPHPortraitCollectionController val_22 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            .targetStars = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionPreviousUnlockCost(collection:  val_22.progress.chosenCollection);
            FPHPortraitCollectionController val_25 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            val_69 = System.Linq.Enumerable.Last<System.String>(source:  MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  val_25.progress.chosenCollection));
            FPHGameplayController val_28 = FPHGameplayController.Instance;
            val_70 = 1f;
            val_71 = (val_19.progress.starsCollected - val_28.currentGame.GetTotalStarReward()) + ((PortraitCollectionProgressBar.<>c__DisplayClass7_0)[1152921516641270144].targetStars);
        }
        else
        {
                .targetStars = MonoSingleton<FPHPortraitCollectionController>.Instance.GetCollectionNextUnlockCost();
            FPHPortraitCollectionController val_33 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            FPHGameplayController val_34 = FPHGameplayController.Instance;
            val_71 = UnityEngine.Mathf.Max(a:  0, b:  val_33.progress.starsCollected - val_34.currentGame.GetTotalStarReward());
            val_69 = MonoSingleton<FPHPortraitCollectionController>.Instance.GetNextUnlockedPortrait();
            FPHPortraitCollectionController val_40 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            val_70 = (float)val_40.progress.starsCollected / ((float)(PortraitCollectionProgressBar.<>c__DisplayClass7_0)[1152921516641270144].targetStars);
        }
        
        this.portraitImage.sprite = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler.GetPortraitSpriteByName(name:  val_69);
        if(((PortraitCollectionProgressBar.<>c__DisplayClass7_0)[1152921516641270144].animate) != false)
        {
                PortraitCollectionProgressBar.<>c__DisplayClass7_1 val_43 = new PortraitCollectionProgressBar.<>c__DisplayClass7_1();
            .CS$<>8__locals1 = val_1;
            float val_67 = (float)(PortraitCollectionProgressBar.<>c__DisplayClass7_0)[1152921516641270144].targetStars;
            val_67 = (float)val_71 / val_67;
            this.progressBar.fillAmount = val_67;
            Player val_44 = App.Player;
            FPHGameplayController val_45 = FPHGameplayController.Instance;
            int val_46 = val_45.currentGame.GetTotalStarReward();
            .progress = (float)val_71;
            DG.Tweening.Tweener val_47 = DG.Tweening.ShortcutExtensions46.DOFillAmount(target:  this.progressBar, endValue:  val_70, duration:  2f);
            float val_68 = (float)(PortraitCollectionProgressBar.<>c__DisplayClass7_1)[1152921516641462656].CS$<>8__locals1.targetStars;
            val_68 = (float)val_71 / val_68;
            DG.Tweening.Tweener val_54 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_43, method:  System.Void PortraitCollectionProgressBar.<>c__DisplayClass7_1::<Init>b__1(float x)), startValue:  val_68, endValue:  val_70, duration:  2f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_43, method:  System.Void PortraitCollectionProgressBar.<>c__DisplayClass7_1::<Init>b__2())), action:  new DG.Tweening.TweenCallback(object:  (PortraitCollectionProgressBar.<>c__DisplayClass7_1)[1152921516641462656].CS$<>8__locals1, method:  System.Void PortraitCollectionProgressBar.<>c__DisplayClass7_0::<Init>b__3()));
            PluginExtension.SetColorAlpha(graphic:  this.readyToCollectionIcon, a:  0f);
            FPHPortraitCollectionController val_55 = MonoSingleton<FPHPortraitCollectionController>.Instance;
            if(val_55.progress.showUnlockedPortrait == false)
        {
                return;
        }
        
            this.readyToCollectionIcon.gameObject.SetActive(value:  true);
            DG.Tweening.Tweener val_58 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.readyToCollectionIcon, endValue:  1f, duration:  0.1f), delay:  2.5f);
            if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
            UnityEngine.Coroutine val_62 = this.StartCoroutine(routine:  this.showUnlock(unlocked:  val_69));
            return;
        }
        
        this.progressBar.fillAmount = val_70;
        Player val_63 = App.Player;
        decimal val_64 = System.Decimal.op_Implicit(value:  val_63._stars);
        this.progressText.Set(instantValue:  new System.Decimal() {flags = val_64.flags, hi = val_64.hi, lo = val_64.lo, mid = val_64.mid});
        FPHPortraitCollectionController val_66 = MonoSingleton<FPHPortraitCollectionController>.Instance;
        this.readyToCollectionIcon.gameObject.SetActive(value:  val_66.progress.showUnlockedPortrait);
    }
    public System.Collections.IEnumerator UpdateUI()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PortraitCollectionProgressBar.<UpdateUI>d__8();
    }
    private System.Collections.IEnumerator showUnlock(string unlocked)
    {
        .<>1__state = 0;
        .unlocked = unlocked;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PortraitCollectionProgressBar.<showUnlock>d__9();
    }
    public PortraitCollectionProgressBar()
    {
    
    }

}
