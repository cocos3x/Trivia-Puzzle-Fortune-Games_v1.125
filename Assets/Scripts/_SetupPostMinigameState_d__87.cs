using UnityEngine;
private sealed class TRVLevelComplete.<SetupPostMinigameState>d__87 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLevelComplete <>4__this;
    private TRVQuizProgress <progress>5__2;
    private bool <shouldAnimate>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<SetupPostMinigameState>d__87(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        TRVLevelComplete val_76;
        int val_77;
        var val_78;
        var val_79;
        int val_80;
        int val_82;
        var val_83;
        int val_84;
        int val_85;
        var val_86;
        System.Action<UnityEngine.GameObject> val_88;
        var val_89;
        var val_90;
        var val_91;
        var val_92;
        Player val_93;
        val_76 = this.<>4__this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        val_77 = 0;
        if((this.<>1__state) != 0)
        {
                return (bool)val_77;
        }
        
        this.<>1__state = 0;
        this.<>4__this.postMinigameNextButton.interactable = true;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        this.<progress>5__2 = val_1.currentGame;
        val_78 = null;
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  val_1.currentGame)) == false)
        {
            goto label_9;
        }
        
        val_79 = null;
        val_80 = TRVLevelComplete.lastEventLevelCompleteAnimShownAt;
        int val_4 = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetQuizProgress(progress:  this.<progress>5__2);
        goto label_15;
        label_2:
        this.<>1__state = 0;
        if(val_76 != null)
        {
            goto label_30;
        }
        
        label_1:
        this.<>1__state = 0;
        if((this.<shouldAnimate>5__3) == false)
        {
            goto label_19;
        }
        
        Player val_5 = App.Player;
        val_82 = val_5._stars - (this.<progress>5__2.finalStarReward);
        goto label_24;
        label_9:
        val_83 = null;
        val_80 = TRVLevelComplete.lastLevelCompleteAnimShownAt;
        label_15:
        this.<shouldAnimate>5__3 = (val_80 != App.Player) ? 1 : 0;
        DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.levelSuccessGroup), endValue:  0f, duration:  0.3f);
        if((this.<shouldAnimate>5__3) != false)
        {
                UnityEngine.WaitForSeconds val_10 = null;
            val_76 = val_10;
            val_10 = new UnityEngine.WaitForSeconds(seconds:  0.3f);
            val_77 = 1;
            this.<>2__current = val_76;
            this.<>1__state = val_77;
            return (bool)val_77;
        }
        
        label_30:
        this.<>4__this.levelSuccessGroup.gameObject.SetActive(value:  false);
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_77 = 1;
        return (bool)val_77;
        label_19:
        Player val_12 = App.Player;
        val_82 = val_12._stars;
        label_24:
        decimal val_13 = System.Decimal.op_Implicit(value:  val_82);
        this.<>4__this.starStatView.artificalTargetBalance = val_13;
        mem2[0] = val_13.lo;
        mem[4] = val_13.mid;
        if((this.<shouldAnimate>5__3) == false)
        {
            goto label_41;
        }
        
        Player val_14 = App.Player;
        decimal val_15 = System.Decimal.op_Implicit(value:  this.<progress>5__2.finalCoinReward);
        val_84 = val_14._credits;
        val_85 = val_82;
        decimal val_16 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_84, hi = val_84, lo = val_85, mid = val_85}, d2:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid});
        if((this.<>4__this.coinStatView) != null)
        {
            goto label_48;
        }
        
        label_41:
        Player val_17 = App.Player;
        val_84 = val_17._credits;
        label_48:
        this.<>4__this.coinStatView.artificalTargetBalance = val_84;
        mem2[0] = val_13.lo;
        mem[4] = val_13.mid;
        val_86 = null;
        val_86 = null;
        val_88 = TRVLevelComplete.<>c.<>9__87_0;
        if(val_88 == null)
        {
                System.Action<UnityEngine.GameObject> val_18 = null;
            val_88 = val_18;
            val_18 = new System.Action<UnityEngine.GameObject>(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<SetupPostMinigameState>b__87_0(UnityEngine.GameObject x));
            TRVLevelComplete.<>c.<>9__87_0 = val_88;
        }
        
        this.<>4__this.statViews.ForEach(action:  val_18);
        UnityEngine.GameObject val_19 = this.<>4__this.homeButton.gameObject;
        val_19.SetActive(value:  (~val_19.ChapterRewardAvailable) & 1);
        .<desc>k__BackingField = Localization.Localize(key:  "coin_reward", defaultValue:  "Coin Reward", useSingularKey:  false);
        .<value>k__BackingField = this.<progress>5__2.finalCoinReward;
        .<rewardType>k__BackingField = 0;
        .<cardMulti>k__BackingField = this.<progress>5__2.selectedMulitplier;
        UnityEngine.Coroutine val_25 = val_76.StartCoroutine(routine:  val_76.SetupReward(parent:  this.<>4__this.levelCompleteRewardParent, reward:  new TRVLevelReward(), anim:  this.<shouldAnimate>5__3));
        .<desc>k__BackingField = Localization.Localize(key:  "star_reward", defaultValue:  "Star Reward", useSingularKey:  false);
        .<value>k__BackingField = this.<progress>5__2.finalStarReward;
        .<rewardType>k__BackingField = 1;
        .<cardMulti>k__BackingField = this.<progress>5__2.selectedMulitplier;
        UnityEngine.Coroutine val_29 = val_76.StartCoroutine(routine:  val_76.SetupReward(parent:  this.<>4__this.levelCompleteRewardParent, reward:  new TRVLevelReward(), anim:  this.<shouldAnimate>5__3));
        this.<>4__this.postMinigameNextButtonGroup.gameObject.SetActive(value:  true);
        this.<>4__this.postMinigameNextButton.gameObject.SetActive(value:  true);
        val_76.HandlePostMinigameEventSetup(animate:  this.<shouldAnimate>5__3);
        if((this.<shouldAnimate>5__3) != false)
        {
                this.<>4__this.postMinigameNextButton.interactable = false;
            if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  this.<progress>5__2)) != false)
        {
                val_89 = null;
            val_89 = null;
            TRVLevelComplete.lastEventLevelCompleteAnimShownAt = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetQuizProgress(progress:  this.<progress>5__2);
        }
        else
        {
                val_90 = null;
            val_90 = null;
            TRVLevelComplete.lastLevelCompleteAnimShownAt = App.Player;
        }
        
            WGAudioController val_36 = MonoSingleton<WGAudioController>.Instance;
            val_36.sound.PlayGameSpecificSound(id:  "TRVQuizCompleteCollect", clipIndex:  0);
            UnityEngine.Coroutine val_38 = val_76.StartCoroutine(routine:  val_76.OnRewardAnimFinished(delay:  1.5f));
        }
        
        string val_41 = App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost.ToString();
        TRVEcon val_42 = App.GetGameSpecificEcon<TRVEcon>();
        val_91 = null;
        string val_45 = System.String.Format(format:  "{0}X {1}", arg0:  val_42.variableMultipliers[TRVMainController.currentMultiplier], arg1:  Localization.Localize(key:  "golden_apples_upper", defaultValue:  "STARS", useSingularKey:  false));
        if((this.<>4__this.postMinigameStarMultiText.ChapterRewardAvailable) != false)
        {
                this.<>4__this.postMinigameStarMultiText.transform.parent.gameObject.SetActive(value:  false);
            this.<>4__this.postMinigameTryAgainCost.transform.parent.gameObject.SetActive(value:  false);
            val_92 = Localization.Localize(key:  "collect_reward_upper", defaultValue:  "COLLECT REWARD", useSingularKey:  false);
            val_93 = this.<>4__this.postMinigameNextGameText;
        }
        else
        {
                string val_54 = Localization.Localize(key:  "next_level_upper", defaultValue:  "NEXT LEVEL", useSingularKey:  false);
            this.<>4__this.postMinigameTryAgainCost.transform.parent.gameObject.SetActive(value:  true);
            UnityEngine.GameObject val_60 = this.<>4__this.postMinigameStarMultiText.transform.parent.gameObject;
            val_92 = 1;
            val_60.SetActive(value:  true);
        }
        
        bool val_61 = val_60.CompletedChapterCycle;
        if(val_61 != false)
        {
                int val_62 = val_61.chapterLength;
        }
        else
        {
                Player val_63 = App.Player;
            int val_64 = val_63.chapterLength;
            val_93 = val_63 - ((val_63 / val_64) * val_64);
        }
        
        string val_67 = System.String.Format(format:  "{0} / {1}", arg0:  val_93, arg1:  val_93.chapterLength);
        if((this.<>4__this.postMinigameChapterProgressText.CompletedChapterCycle) != false)
        {
                if((this.<>4__this.postMinigameChapterProgressBar) != null)
        {
            goto label_123;
        }
        
        }
        
        Player val_69 = App.Player;
        int val_70 = val_69.chapterLength;
        Player val_72 = val_69 / val_70;
        val_72 = val_69 - (val_72 * val_70);
        float val_76 = (float)val_72;
        val_76 = val_76 / (float)val_70.chapterLength;
        label_123:
        this.<>4__this.postMinigameChapterProgressBar.fillAmount = val_76;
        val_76.setChestSprite(image:  this.<>4__this.postMinigameChestImage, closed:  false);
        this.<>4__this.postMinigameNextButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_73 = null;
        val_80 = val_73;
        val_73 = new UnityEngine.Events.UnityAction(object:  val_76, method:  System.Void TRVLevelComplete::NextQuizButtonClicked());
        this.<>4__this.postMinigameNextButton.m_OnClick.AddListener(call:  val_73);
        this.<>4__this.postMinigameGroup.gameObject.SetActive(value:  true);
        val_77 = 0;
        return (bool)val_77;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
