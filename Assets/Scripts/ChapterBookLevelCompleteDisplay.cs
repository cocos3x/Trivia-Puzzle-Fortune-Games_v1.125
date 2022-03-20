using UnityEngine;
public class ChapterBookLevelCompleteDisplay : MonoBehaviour
{
    // Fields
    private LevelCompletePopup levelCompletePopupParent;
    private UnityEngine.CanvasGroup thisMainCanvasGroup;
    private UnityEngine.CanvasGroup progressBarCanvasGroup;
    private ChapterBookProgressBar chapterBookProgressBar;
    private UnityEngine.UI.Button progressBarButton;
    private UnityEngine.RectTransform bookRewardAnimate;
    private UnityEngine.RectTransform bookRewardFocusXfm;
    private UnityEngine.RectTransform bookRewardProgressBarXfm;
    private UnityEngine.RectTransform bookRewardFinalXfm;
    private UnityEngine.UI.Image bookRewardBurstGlow;
    private UnityEngine.CanvasGroup bookAnimationGroup;
    private UnityEngine.UI.Text text_levels_until_reward;
    private UnityEngine.CanvasGroup largeBookRewardGroup;
    private LibraryBookDisplay rewardedBookDisplay;
    private UnityEngine.CanvasGroup otherBookRewardInfo;
    private UnityEngine.UI.Button button_Library;
    private UnityEngine.UI.Button button_Continue;
    private UnityEngine.CanvasGroup chooseNextBookDisplay;
    private LibraryBookDisplay[] bookOptions;
    private UnityEngine.UI.Text[] bookOptionCollectionProgress;
    private UnityEngine.UI.Button[] bookOptionButtons;
    private UnityEngine.UI.Button tapToContinueButton;
    private UnityEngine.CanvasGroup tapToContinueCanvasGroup;
    private System.Collections.Generic.List<BookInfo> availableBookOptions;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Events.UnityAction val_6;
        this.progressBarButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChapterBookLevelCompleteDisplay::OnProgressBarClicked()));
        this.button_Library.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChapterBookLevelCompleteDisplay::OnLibraryButtonClicked()));
        UnityEngine.Events.UnityAction val_3 = null;
        val_6 = val_3;
        val_3 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChapterBookLevelCompleteDisplay::OnContinueButtonClicked());
        this.button_Continue.m_OnClick.AddListener(call:  val_3);
        int val_7 = 0;
        do
        {
            if(val_7 >= this.bookOptionButtons.Length)
        {
                return;
        }
        
            .<>4__this = this;
            .index = val_7;
            UnityEngine.UI.Button val_6 = this.bookOptionButtons[val_7];
            val_6 = this.bookOptionButtons[0x0][0].m_OnClick;
            val_6.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new ChapterBookLevelCompleteDisplay.<>c__DisplayClass23_0(), method:  System.Void ChapterBookLevelCompleteDisplay.<>c__DisplayClass23_0::<Awake>b__0()));
            val_7 = val_7 + 1;
        }
        while(this.bookOptionButtons != null);
        
        throw new NullReferenceException();
    }
    public void Display(int currentPlayerLevel = -1, float secondsBeforeDisplay = 3)
    {
        int val_31;
        var val_32;
        string val_33;
        bool val_35;
        var val_36;
        val_31 = currentPlayerLevel;
        this.chooseNextBookDisplay.gameObject.SetActive(value:  false);
        this.chooseNextBookDisplay.alpha = 0f;
        this.thisMainCanvasGroup.alpha = 0f;
        this.progressBarCanvasGroup.gameObject.SetActive(value:  false);
        this.progressBarCanvasGroup.alpha = 0f;
        this.bookAnimationGroup.alpha = 1f;
        this.largeBookRewardGroup.gameObject.SetActive(value:  false);
        this.largeBookRewardGroup.alpha = 0f;
        if(val_31 < 1)
        {
                val_31 = App.Player;
        }
        
        int val_8 = (WADChapterManager.GetNumLevelsInCurrentChapter() + 1) - (WADChapterManager.GetCurrentLevelWithinChapter(level:  0));
        if(val_8 > 1)
        {
                val_32 = 1152921504619999232;
            val_33 = Localization.Localize(key:  "x_levels_until_next_reward", defaultValue:  "{0} levels until next reward!", useSingularKey:  false);
        }
        else
        {
                val_32 = 1152921504619999232;
            val_33 = Localization.Localize(key:  "x_level_until_next_reward", defaultValue:  "{0} level until next reward!", useSingularKey:  false);
        }
        
        string val_11 = System.String.Format(format:  val_33, arg0:  val_8);
        UnityEngine.GameObject val_12 = this.text_levels_until_reward.gameObject;
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  val_31)) == false)
        {
            goto label_22;
        }
        
        val_35 = 0;
        if(val_12 != null)
        {
            goto label_23;
        }
        
        label_22:
        val_35 = (ChapterBookLogic.ShowBookComplete(playerLevel:  val_31)) ^ 1;
        label_23:
        val_12.SetActive(value:  val_35);
        this.chapterBookProgressBar.Setup(playerLevel:  val_31, showIncomplete:  false);
        bool val_16 = ChapterBookLogic.ShowBookComplete(playerLevel:  val_31);
        val_16.MatchTransformToAnother(mover:  this.bookRewardAnimate, toMatch:  this.bookRewardProgressBarXfm);
        this.progressBarCanvasGroup.gameObject.SetActive(value:  true);
        this.progressBarCanvasGroup.alpha = 1f;
        if(val_16 != false)
        {
                val_36 = null;
            val_36 = null;
            this.rewardedBookDisplay.Setup(info:  TheLibraryLogic._LastGrantedBook);
            this.Invoke(methodName:  "PlayBookCompleteAnimation", time:  3.5f);
        }
        else
        {
                this.rewardedBookDisplay.Setup(info:  BookList.BookInfos.Item[TheLibraryLogic.CurrentBookUnlockTarget]);
            var val_30 = ~(ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_31));
            val_30 = val_31 + val_30;
            if(val_30 == 0)
        {
                DG.Tweening.Sequence val_22 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  DG.Tweening.TweenSettingsExtensions.PrependInterval(s:  DG.Tweening.TweenSettingsExtensions.Append(s:  val_22, t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.bookRewardAnimate, duration:  0.75f, strength:  25f, vibrato:  10, randomness:  90f, fadeOut:  true)), interval:  5f), loops:  0);
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  val_22);
        }
        
        }
        
        DG.Tweening.Tweener val_29 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.thisMainCanvasGroup, endValue:  1f, duration:  0.5f), delay:  secondsBeforeDisplay);
    }
    private void PlayBookCompleteAnimation()
    {
        this.levelCompletePopupParent.HideLowerUI(fadeOutDuration:  0.5f, delay:  0f);
        this.levelCompletePopupParent.AnimateBook(book:  this.bookRewardAnimate, target:  this.bookRewardFinalXfm, duration:  1f);
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.progressBarCanvasGroup, endValue:  0f, duration:  0.75f);
        this.ShowRewardedBook();
    }
    private void PlayBookIntroAnimation()
    {
        this.AnimateBook(book:  this.bookRewardAnimate, target:  this.bookRewardProgressBarXfm, duration:  1f);
        this.progressBarCanvasGroup.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.progressBarCanvasGroup, endValue:  1f, duration:  0.5f);
    }
    private void MatchTransformToAnother(UnityEngine.RectTransform mover, UnityEngine.RectTransform toMatch)
    {
        UnityEngine.Vector2 val_1 = toMatch.sizeDelta;
        mover.sizeDelta = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        UnityEngine.Vector3 val_2 = toMatch.localPosition;
        mover.localPosition = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Quaternion val_3 = toMatch.localRotation;
        mover.localRotation = new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
        UnityEngine.Vector3 val_4 = toMatch.localScale;
        mover.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
    }
    private void AnimateBook(UnityEngine.RectTransform book, UnityEngine.RectTransform target, float duration)
    {
        UnityEngine.Vector2 val_1 = target.sizeDelta;
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOSizeDelta(target:  book, endValue:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, duration:  duration, snapping:  false);
        UnityEngine.Vector3 val_3 = target.localPosition;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  book, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  duration, snapping:  false), ease:  7);
        UnityEngine.Quaternion val_6 = target.localRotation;
        UnityEngine.Vector3 val_7 = val_6.x.eulerAngles;
        DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  book, endValue:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  duration, mode:  0), ease:  7);
        UnityEngine.Vector3 val_10 = target.localScale;
        DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  book, endValue:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, duration:  duration), ease:  7);
    }
    private void FadeOutAndDisableGroup(UnityEngine.CanvasGroup group, float duration)
    {
        .group = group;
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  group, endValue:  0f, duration:  duration);
        System.Delegate val_4 = System.Delegate.Combine(a:  X21, b:  new DG.Tweening.TweenCallback(object:  new ChapterBookLevelCompleteDisplay.<>c__DisplayClass29_0(), method:  System.Void ChapterBookLevelCompleteDisplay.<>c__DisplayClass29_0::<FadeOutAndDisableGroup>b__0()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        mem2[0] = val_4;
        return;
        label_4:
    }
    private void ShowRewardedBook()
    {
        this.largeBookRewardGroup.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.largeBookRewardGroup, endValue:  1f, duration:  0.25f);
        this.otherBookRewardInfo.alpha = 0f;
        DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.otherBookRewardInfo, endValue:  1f, duration:  0.5f), delay:  1.25f);
    }
    private void OnProgressBarClicked()
    {
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
    }
    private void OnLibraryButtonClicked()
    {
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
    }
    private void OnContinueButtonClicked()
    {
        this.ShowBookOptions();
    }
    private void ShowBookOptions()
    {
        this.levelCompletePopupParent.HideUpperUI(fadeOutDuration:  0.5f, delay:  0f);
        this.levelCompletePopupParent.FadeOutAndDisableGroup(group:  this.otherBookRewardInfo, duration:  0.5f);
        this.levelCompletePopupParent.FadeOutAndDisableGroup(group:  this.largeBookRewardGroup, duration:  0.5f);
        UnityEngine.CanvasGroup val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.rewardedBookDisplay);
        val_1.FadeOutAndDisableGroup(group:  val_1, duration:  0.5f);
        this.availableBookOptions = TheLibraryLogic.GetBookChoices(currentBookIndex:  0);
        var val_11 = 4;
        do
        {
            string val_3 = val_11 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.bookOptions[0].Setup(info:  TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32);
            UnityEngine.UI.Text val_9 = this.bookOptionCollectionProgress[0];
            if(this.bookOptionCollectionProgress.Length <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.UI.Text val_10 = this.bookOptionCollectionProgress[0];
            if(this.bookOptionCollectionProgress.Length <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            string val_5 = System.String.Format(format:  "{0} {1}", arg0:  this.availableBookOptions, arg1:  TheLibraryLogic.GetProgressForCollection(collectionName:  val_3, showCompletedState:  false));
            val_11 = val_11 + 1;
        }
        while(this.availableBookOptions != null);
        
        this.chooseNextBookDisplay.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_7 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.chooseNextBookDisplay, endValue:  1f, duration:  0.25f);
    }
    private void OnBookOptionClicked(int chosenIndex)
    {
        UnityEngine.RectTransform val_10;
        var val_11 = 0;
        label_6:
        if(val_11 >= this.bookOptionButtons.Length)
        {
            goto label_2;
        }
        
        UnityEngine.UI.Button val_10 = this.bookOptionButtons[val_11];
        this.bookOptionButtons[0x0][0].m_OnClick.RemoveAllListeners();
        val_11 = val_11 + 1;
        if(this.bookOptionButtons != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_2:
        if(this.bookOptionButtons <= chosenIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.UI.Button val_12 = this.bookOptionButtons[chosenIndex];
        TheLibraryLogic.CurrentBookUnlockTarget = this.availableBookOptions;
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        TheLibraryLogic.PostCurrentUnlockTarget(sku:  TheLibraryLogic.CurrentBookUnlockTarget);
        UnityEngine.Transform val_3 = this.bookOptions[(long)chosenIndex].transform;
        val_3.parent = this.bookAnimationGroup.transform;
        val_3.FadeOutAndDisableGroup(group:  this.chooseNextBookDisplay, duration:  0.25f);
        UnityEngine.Transform val_5 = this.bookOptions[(long)chosenIndex].transform;
        if(val_5 != null)
        {
                var val_6 = (null == null) ? (val_5) : 0;
        }
        else
        {
                val_10 = 0;
        }
        
        val_5.AnimateBook(book:  val_10, target:  this.bookRewardProgressBarXfm, duration:  1f);
        this.chapterBookProgressBar.Setup(playerLevel:  App.Player + 1, showIncomplete:  true);
        DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.progressBarCanvasGroup, endValue:  1f, duration:  0.5f);
        this.levelCompletePopupParent.ShowUpperUI(fadeInDuration:  0.5f, delay:  0f);
        this.Invoke(methodName:  "ShowFinalScreen", time:  1f);
    }
    private void ShowFinalScreen()
    {
        this.tapToContinueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChapterBookLevelCompleteDisplay::HandleWindowConcluded()));
        this.tapToContinueButton.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tapToContinueCanvasGroup, endValue:  1f, duration:  0.5f);
    }
    private void HandleWindowConcluded()
    {
        if(this.levelCompletePopupParent != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public ChapterBookLevelCompleteDisplay()
    {
        this.availableBookOptions = new System.Collections.Generic.List<BookInfo>();
    }

}
