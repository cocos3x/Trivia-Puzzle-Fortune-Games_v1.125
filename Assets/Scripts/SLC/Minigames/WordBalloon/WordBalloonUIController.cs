using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonUIController : MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonUIController>
    {
        // Fields
        private SLC.Minigames.MinigamesCheckpointSlider checkpointSlider;
        private UnityEngine.UI.Text categoryLabel;
        private SLC.Minigames.WordBalloon.WordBalloonGrid letterGrid;
        private UnityEngine.CanvasGroup levelCompleteOverlay;
        private UnityEngine.UI.Button hintButton;
        private UnityEngine.CanvasGroup flyoutGroup;
        private UnityEngine.UI.Text flyoutLabel;
        private DG.Tweening.Sequence flyoutGroupSeq;
        private UnityEngine.UI.Button pauseButton;
        private UnityEngine.CanvasGroup pauseOverlayGroup;
        private SLC.Minigames.WordBalloon.WordBalloonFTUXPointer ftuxPointer;
        private UnityEngine.UI.Text ftuxMessageBlurb;
        private UnityEngine.UI.Button resetBoardButton;
        private UnityEngine.UI.Button newBoardButton;
        private DG.Tweening.Tween ftuxHighlightTween;
        
        // Methods
        public override void InitMonoSingleton()
        {
            var val_14;
            UnityEngine.Events.UnityAction val_16;
            var val_17;
            UnityEngine.Events.UnityAction val_19;
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnMinigameBegin, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnMinigameBegin()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_1.OnMinigameBegin = val_3;
            SLC.Minigames.WordBalloon.WordBalloonManager val_4 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnMinigameEnd, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnMinigameEnd()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_4.OnMinigameEnd = val_6;
            SLC.Minigames.WordBalloon.WordBalloonManager val_7 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnLevelComplete, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnLevelComplete()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_7.OnLevelComplete = val_9;
            this.hintButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnHintClicked()));
            this.pauseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnPauseClicked()));
            val_14 = null;
            val_14 = null;
            val_16 = WordBalloonUIController.<>c.<>9__14_0;
            if(val_16 == null)
            {
                    UnityEngine.Events.UnityAction val_12 = null;
                val_16 = val_12;
                val_12 = new UnityEngine.Events.UnityAction(object:  WordBalloonUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WordBalloonUIController.<>c::<InitMonoSingleton>b__14_0());
                WordBalloonUIController.<>c.<>9__14_0 = val_16;
            }
            
            this.resetBoardButton.m_OnClick.AddListener(call:  val_12);
            val_17 = null;
            val_17 = null;
            val_19 = WordBalloonUIController.<>c.<>9__14_1;
            if(val_19 == null)
            {
                    UnityEngine.Events.UnityAction val_13 = null;
                val_19 = val_13;
                val_13 = new UnityEngine.Events.UnityAction(object:  WordBalloonUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WordBalloonUIController.<>c::<InitMonoSingleton>b__14_1());
                WordBalloonUIController.<>c.<>9__14_1 = val_19;
            }
            
            this.newBoardButton.m_OnClick.AddListener(call:  val_13);
            return;
            label_11:
        }
        private void Start()
        {
            if(this.checkpointSlider != null)
            {
                    this.checkpointSlider.UpdateUI();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ShowFlyoutStatus(string message)
        {
            if(this.flyoutGroupSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.flyoutGroupSeq, complete:  false);
            }
            
            this.flyoutGroup.alpha = 0f;
            this.flyoutGroup.gameObject.SetActive(value:  true);
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            this.flyoutGroupSeq = val_2;
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.flyoutGroup, endValue:  1f, duration:  0.1f));
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.flyoutGroupSeq, interval:  2.5f);
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.flyoutGroupSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.flyoutGroup, endValue:  0f, duration:  0.3f));
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.flyoutGroupSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::<ShowFlyoutStatus>b__16_0()));
        }
        private void OnMinigameBegin()
        {
            DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.levelCompleteOverlay, endValue:  0f, duration:  0.1f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::<OnMinigameBegin>b__17_0()));
            this.checkpointSlider.UpdateUI();
            SLC.Minigames.WordBalloon.WordBalloonManager val_4 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            this.letterGrid.ClearGrid();
            SLC.Minigames.WordBalloon.WordBalloonManager val_5 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            SLC.Minigames.WordBalloon.WordBalloonManager val_6 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            this.letterGrid.CreateGrid(letterTileData:  val_5.<CurrentLevelData>k__BackingField.gridData, columnLimit:  val_6.<CurrentLevelData>k__BackingField.columnLimit);
            SLC.Minigames.WordBalloon.WordBalloonManager val_8 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            this.hintButton.gameObject.SetActive(value:  ((val_8.<CurrentPlayerLevel>k__BackingField) > 0) ? 1 : 0);
            SLC.Minigames.WordBalloon.WordBalloonManager val_10 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_10.<CurrentPlayerLevel>k__BackingField) > 0)
            {
                    return;
            }
            
            this.StartFTUX();
        }
        private void OnMinigameEnd()
        {
            var val_3;
            DG.Tweening.TweenCallback val_5;
            val_3 = null;
            val_3 = null;
            val_5 = WordBalloonUIController.<>c.<>9__18_0;
            if(val_5 == null)
            {
                    DG.Tweening.TweenCallback val_1 = null;
                val_5 = val_1;
                val_1 = new DG.Tweening.TweenCallback(object:  WordBalloonUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WordBalloonUIController.<>c::<OnMinigameEnd>b__18_0());
                WordBalloonUIController.<>c.<>9__18_0 = val_5;
            }
            
            DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  val_1, ignoreTimeScale:  true);
        }
        private void OnLevelComplete()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnLevelCompleteCoroutine());
        }
        private System.Collections.IEnumerator OnLevelCompleteCoroutine()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordBalloonUIController.<OnLevelCompleteCoroutine>d__20();
        }
        private void ProceedToNewLevel()
        {
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            val_1.InitializeGame(existingData:  0);
            val_1.BeginGame();
        }
        private void OnPauseClicked()
        {
            this.pauseOverlayGroup.alpha = 0f;
            this.pauseOverlayGroup.gameObject.SetActive(value:  true);
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.pauseOverlayGroup, endValue:  1f, duration:  0.15f);
        }
        private void OnHintClicked()
        {
            System.Collections.Generic.List<System.Int32> val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.GetSolvableSlotSequence();
            if(val_2 != null)
            {
                    MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.HighlightSlots(slotsToUse:  val_2);
                return;
            }
            
            this.ShowFlyoutStatus(message:  "No hints found!");
        }
        private void StartFTUX()
        {
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnWordProcessed, b:  new System.Action<System.Boolean, System.String>(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnFTUXWordProcessed(bool isWordValid, string processedWord)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnWordProcessed = val_3;
            DG.Tweening.Tween val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::ShowFTUXStep()), ignoreTimeScale:  true);
            return;
            label_5:
        }
        public void EndFTUX()
        {
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnWordProcessed, value:  new System.Action<System.Boolean, System.String>(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::OnFTUXWordProcessed(bool isWordValid, string processedWord)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnWordProcessed = val_3;
            this.ftuxMessageBlurb.gameObject.SetActive(value:  false);
            this.ftuxPointer.gameObject.SetActive(value:  false);
            this.ftuxPointer.Stop();
            return;
            label_5:
        }
        private void OnFTUXWordProcessed(bool isWordValid, string processedWord)
        {
            if(isWordValid == false)
            {
                    return;
            }
            
            if(this.ftuxHighlightTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.ftuxHighlightTween, complete:  false);
            }
            
            this.ftuxPointer.gameObject.SetActive(value:  false);
            SLC.Minigames.WordBalloon.WordBalloonManager val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_2.<RemainingWords>k__BackingField) > 0)
            {
                    this.ShowFTUXStep();
                return;
            }
            
            this.EndFTUX();
        }
        private void ShowFTUXStep()
        {
            IntPtr val_10;
            DG.Tweening.TweenCallback val_11;
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            SLC.Minigames.WordBalloon.WordBalloonManager val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            System.Collections.Generic.List<System.String> val_9 = val_2.<RemainingWords>k__BackingField;
            val_9 = W21 - val_9;
            if(val_9 == 1)
            {
                goto label_8;
            }
            
            if(val_9 != null)
            {
                goto label_9;
            }
            
            val_2.FtuxSetGridInteractable(blanketState:  false, exclusionList:  0);
            this.ftuxMessageBlurb.gameObject.SetActive(value:  true);
            val_10 = 1152921519868706352;
            goto label_13;
            label_8:
            val_2.FtuxSetGridInteractable(blanketState:  false, exclusionList:  0);
            this.ftuxMessageBlurb.gameObject.SetActive(value:  true);
            DG.Tweening.TweenCallback val_5 = null;
            val_10 = 1152921519868723920;
            label_13:
            val_11 = val_5;
            val_5 = new DG.Tweening.TweenCallback(object:  this, method:  val_10);
            goto label_17;
            label_9:
            val_2.FtuxSetGridInteractable(blanketState:  true, exclusionList:  0);
            this.ftuxMessageBlurb.gameObject.SetActive(value:  false);
            DG.Tweening.TweenCallback val_7 = null;
            val_11 = val_7;
            val_7 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonUIController::<ShowFTUXStep>b__28_2());
            label_17:
            this.ftuxHighlightTween = DG.Tweening.DOVirtual.DelayedCall(delay:  3f, callback:  val_7, ignoreTimeScale:  true);
        }
        private void FtuxHighlightAction(System.Collections.Generic.List<int> slotSequence)
        {
            this.FtuxSetGridInteractable(blanketState:  false, exclusionList:  slotSequence);
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_9 = public static SLC.Minigames.WordBalloon.WordBalloonGrid MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>::get_Instance();
            SLC.Minigames.WordBalloon.WordBalloonGrid val_3 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            if(W24 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + ((W24 - 1) << 2);
            this.ftuxPointer.gameObject.SetActive(value:  true);
            this.ftuxPointer.MoveAlong(startObj:  val_1.letterSlotCollection.Item[MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32].gameObject, endObj:  val_3.letterSlotCollection.Item[(public static SLC.Minigames.WordBalloon.WordBalloonGrid MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>::get_Instance() + ((W24 - 1)) << 2) + 32].gameObject, moveAlongDuration:  1f, moveAlongLoopType:  0, moveAlongEaseType:  1);
        }
        private void FtuxSetGridInteractable(bool blanketState, System.Collections.Generic.List<int> exclusionList)
        {
            var val_4;
            var val_5;
            bool val_14;
            bool val_15;
            val_14 = blanketState;
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            Dictionary.Enumerator<TKey, TValue> val_2 = val_1.letterSlotCollection.GetEnumerator();
            val_15 = val_14;
            goto label_7;
            label_9:
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_4.HasLetterTile != false)
            {
                    if((val_4 + 72) == 0)
            {
                    throw new NullReferenceException();
            }
            
                mem2[0] = val_15;
            }
            
            label_7:
            if(val_5.MoveNext() == true)
            {
                goto label_9;
            }
            
            val_5.Dispose();
            if(exclusionList == null)
            {
                    return;
            }
            
            if(1152921519850367680 < 1)
            {
                    return;
            }
            
            val_15 = 1152921519850198336;
            var val_13 = 0;
            do
            {
                if(val_13 >= 1152921519850367680)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_14 = public System.Int32 System.Collections.Generic.List<System.TypeSpec>::get_Count();
                if((val_1.letterSlotCollection.ContainsKey(key:  -1917569584)) != false)
            {
                    if((val_1.letterSlotCollection.Item[-1917569584].HasLetterTile) != false)
            {
                    SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_12 = val_1.letterSlotCollection.Item[-1917569584];
                val_12.letterTile.interactable = (~val_14) & 1;
            }
            
            }
            
                val_13 = val_13 + 1;
            }
            while(val_13 < val_12.letterTile);
        
        }
        public WordBalloonUIController()
        {
        
        }
        private void <ShowFlyoutStatus>b__16_0()
        {
            this.flyoutGroup.gameObject.SetActive(value:  false);
        }
        private void <OnMinigameBegin>b__17_0()
        {
            this.levelCompleteOverlay.gameObject.SetActive(value:  false);
        }
        private void <ShowFTUXStep>b__28_0()
        {
            this.FtuxHighlightAction(slotSequence:  MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.GetSolvableSlotSequence());
        }
        private void <ShowFTUXStep>b__28_1()
        {
            this.FtuxHighlightAction(slotSequence:  MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.GetSolvableSlotSequence());
        }
        private void <ShowFTUXStep>b__28_2()
        {
            this.FtuxHighlightAction(slotSequence:  MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.GetSolvableSlotSequence());
        }
    
    }

}
