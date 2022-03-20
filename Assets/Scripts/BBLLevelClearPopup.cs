using UnityEngine;
public class BBLLevelClearPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image background;
    private UnityEngine.CanvasGroup contentGroup;
    private UnityEngine.UI.Text progressPercentText;
    private UnityEngine.UI.Image rainbowProgressOutline;
    private UnityEngine.UI.Text chapterIndexText;
    private UnityEngine.UI.Text rewardAmountText;
    private ExtraProgress chapterProgressBar;
    private UnityEngine.UI.Text chapterProgressBarText;
    private UnityEngine.GameObject levelClearContent;
    private UnityEngine.GameObject chapterClearContent;
    private UnityEngine.GameObject freeCoinGroup;
    private UnityEngine.UI.Button freeCoinsButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.CanvasGroup continueCanvasGroup;
    private UnityEngine.UI.Image[] levelStars;
    private GridCoinCollectAnimationInstantiator coinAnimation;
    private bool chapterComplete;
    
    // Methods
    private void Awake()
    {
        if(this.freeCoinsButton != 0)
        {
                this.freeCoinsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLLevelClearPopup::OnFreeCoinsButtonClicked()));
        }
        
        UnityEngine.SceneManagement.SceneManager.add_sceneUnloaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void BBLLevelClearPopup::OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)));
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneUnloaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void BBLLevelClearPopup::OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)));
    }
    private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnEnable()
    {
        this.continueCanvasGroup.alpha = 0f;
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  0f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLLevelClearPopup::<OnEnable>b__20_0()), ignoreTimeScale:  true);
        DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  2.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLLevelClearPopup::<OnEnable>b__20_1()), ignoreTimeScale:  true);
        DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  2.8f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLLevelClearPopup::<OnEnable>b__20_2()), ignoreTimeScale:  true);
        DG.Tweening.Tween val_8 = DG.Tweening.DOVirtual.DelayedCall(delay:  3.8f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLLevelClearPopup::<OnEnable>b__20_3()), ignoreTimeScale:  true);
    }
    public void Setup(bool isChapterComplete, int chapterId, int chapterPlayerLevel, int chapterMinLevel, int chapterMaxLevel, int movesMade)
    {
        BBLLevelClearPopup val_36;
        var val_37;
        val_36 = this;
        BBLLevelClearPopup.<>c__DisplayClass21_0 val_1 = new BBLLevelClearPopup.<>c__DisplayClass21_0();
        .<>4__this = val_36;
        this.chapterComplete = isChapterComplete;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelOffer()) != false)
        {
                GameBehavior val_6 = App.getBehavior;
            if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelRewardedVideo(playerLevel:  (val_6.<metaGameBehavior>k__BackingField) - 1)) != false)
        {
                if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) == false)
        {
            goto label_17;
        }
        
        }
        
        }
        
        label_59:
        string val_11 = System.String.Format(format:  "Chapter {0}", arg0:  chapterId);
        .startingLevelVal = UnityEngine.Mathf.InverseLerp(a:  (float)chapterMinLevel - 1, b:  (float)chapterMaxLevel, value:  (float)chapterPlayerLevel - 1);
        this.chapterProgressBar.target = 1f;
        this.chapterProgressBar.current = (BBLLevelClearPopup.<>c__DisplayClass21_0)[1152921513405187936].startingLevelVal;
        int val_37 = 1;
        val_37 = val_37 - chapterMinLevel;
        val_37 = val_37 + chapterMaxLevel;
        .maxLevel = val_37;
        string val_18 = System.String.Format(format:  "{0}/{1} Levels", arg0:  chapterPlayerLevel - chapterMinLevel, arg1:  .maxLevel.ToString());
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_22 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single BBLLevelClearPopup.<>c__DisplayClass21_0::<Setup>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void BBLLevelClearPopup.<>c__DisplayClass21_0::<Setup>b__1(float x)), endValue:  UnityEngine.Mathf.InverseLerp(a:  (float)chapterMinLevel - 1, b:  (float)chapterMaxLevel, value:  (float)chapterPlayerLevel), duration:  1f), delay:  2.8f);
        BlockPuzzleMagic.BestBlocksGameEcon val_23 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        if(val_23.starThreshold1 < movesMade)
        {
                BlockPuzzleMagic.BestBlocksGameEcon val_24 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            var val_25 = (val_24.starThreshold2 >= movesMade) ? (1 + 1) : 1;
        }
        else
        {
                val_37 = 3;
        }
        
        var val_40 = 4;
        label_45:
        var val_26 = val_40 - 4;
        if(val_26 >= this.levelStars.Length)
        {
            goto label_35;
        }
        
        this.levelStars[0].gameObject.SetActive(value:  (val_26 < val_37) ? 1 : 0);
        UnityEngine.Vector3 val_30 = UnityEngine.Vector3.zero;
        this.levelStars[0].rectTransform.localScale = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
        val_40 = val_40 + 1;
        if(this.levelStars != null)
        {
            goto label_45;
        }
        
        label_35:
        this.levelClearContent.SetActive(value:  (this.chapterComplete == false) ? 1 : 0);
        this.chapterClearContent.SetActive(value:  this.chapterComplete);
        this.freeCoinGroup.SetActive(value:  (0 != 0) ? 1 : 0);
        if(0 != 0)
        {
                MonoSingleton<AdsUIController>.Instance.SawPostLevelOffer();
        }
        
        if(this.chapterComplete == false)
        {
                return;
        }
        
        val_36 = this.rewardAmountText;
        BlockPuzzleMagic.BestBlocksGameEcon val_34 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        string val_35 = val_34.chapterClearedReward.ToString(format:  "##");
        return;
        label_17:
        bool val_36 = this.chapterComplete ^ 1;
        goto label_59;
    }
    private System.Collections.IEnumerator ClearSequence()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new BBLLevelClearPopup.<ClearSequence>d__22();
    }
    public void OnContinuePressed()
    {
        this.continueButton.interactable = false;
        this.continueCanvasGroup.alpha = 0f;
        if(this.chapterComplete != false)
        {
                MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.OnLevelClearClosed();
            return;
        }
        
        MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.OnChapterClearClosed();
    }
    public void OnCollectPressed()
    {
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_1.chapterClearedReward, hi = val_1.chapterClearedReward}, source:  "Chapter Complete", externalParams:  0, animated:  false);
        Player val_2 = App.Player;
        BlockPuzzleMagic.BestBlocksGameEcon val_3 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3.chapterClearedReward, hi = val_3.chapterClearedReward, lo = X24, mid = X24});
        Player val_5 = App.Player;
        this.coinAnimation.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        this.levelClearContent.SetActive(value:  true);
        this.chapterClearContent.SetActive(value:  false);
    }
    private void OnFreeCoinsButtonClicked()
    {
        var val_3;
        var val_4;
        val_3 = null;
        val_3 = null;
        PurchaseProxy.currentPurchasePoint = 49;
        val_4 = null;
        val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 34;
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
    }
    public BBLLevelClearPopup()
    {
    
    }
    private void <OnEnable>b__20_0()
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.background, endValue:  1f, duration:  2.5f), ease:  17);
    }
    private void <OnEnable>b__20_1()
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroup, endValue:  1f, duration:  0.3f);
    }
    private void <OnEnable>b__20_2()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ClearSequence());
    }
    private void <OnEnable>b__20_3()
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.continueCanvasGroup, endValue:  1f, duration:  0.25f);
        this.continueButton.interactable = true;
    }

}
