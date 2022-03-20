using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLGameplayUIZenController : MonoSingleton<BlockPuzzleMagic.BBLGameplayUIZenController>
    {
        // Fields
        private UnityEngine.UI.Text scoreBestLabel;
        private UnityEngine.UI.Text scoreCurrentLabel;
        private UnityEngine.CanvasGroup multiLineCelebrationGroup;
        private UnityEngine.UI.Text multiLineCelebrationText;
        private UnityEngine.CanvasGroup highScoreCelebrationGroup;
        private UnityEngine.UI.Text highScoreCelebrationText;
        private DG.Tweening.Tweener tweenerScoreCurrent;
        private DG.Tweening.Tweener tweenerScoreBest;
        private DG.Tweening.Sequence celebrationSeq;
        private bool isGameOverShown;
        
        // Properties
        private bool isHighScoreMessageShown { get; set; }
        
        // Methods
        private void set_isHighScoreMessageShown(bool value)
        {
            value = value;
            UnityEngine.PlayerPrefs.SetInt(key:  "bbl_zenhighshown", value:  value);
        }
        private bool get_isHighScoreMessageShown()
        {
            return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "bbl_zenhighshown", defaultValue:  0)) == 1) ? 1 : 0;
        }
        private void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
            val_1.OnLevelDataInitialized = val_3;
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnGameOver, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnGameOver(bool success)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
            val_4.OnGameOver = val_6;
            BlockPuzzleMagic.GamePlay val_7 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnShapePlaced, b:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
            val_7.OnShapePlaced = val_9;
            BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_10.OnShapesChecked, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnShapesChecked(bool canFit)));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
            val_10.OnShapesChecked = val_12;
            BlockPuzzleMagic.GamePlay val_13 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_15 = System.Delegate.Combine(a:  val_13.OnBlocksCleared, b:  new System.Action<System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnBlocksCleared(System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> blocksCleared)));
            if(val_15 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
            val_13.OnBlocksCleared = val_15;
            BlockPuzzleMagic.BBLDataParser val_16 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance;
            val_16.Initialize();
            UnityEngine.Coroutine val_18 = this.StartCoroutine(routine:  val_16.DelayedGameplayInit());
            return;
            label_17:
        }
        private System.Collections.IEnumerator DelayedGameplayInit()
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new BBLGameplayUIZenController.<DelayedGameplayInit>d__14();
        }
        private void OnDestroy()
        {
            System.Action<System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>> val_18;
            var val_19;
            val_18 = 1152921504893161472;
            val_19 = 1152921513393502304;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
            {
                    BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnLevelDataInitialized, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)));
                if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_22;
            }
            
            }
            
                val_3.OnLevelDataInitialized = val_5;
                BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                System.Delegate val_8 = System.Delegate.Remove(source:  val_6.OnGameOver, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnGameOver(bool success)));
                if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_22;
            }
            
            }
            
                val_6.OnGameOver = val_8;
                BlockPuzzleMagic.GamePlay val_9 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                System.Delegate val_11 = System.Delegate.Remove(source:  val_9.OnShapePlaced, value:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)));
                if(val_11 != null)
            {
                    if(null != null)
            {
                goto label_22;
            }
            
            }
            
                val_9.OnShapePlaced = val_11;
                BlockPuzzleMagic.GamePlay val_12 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                System.Delegate val_14 = System.Delegate.Remove(source:  val_12.OnShapesChecked, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnShapesChecked(bool canFit)));
                if(val_14 != null)
            {
                    if(null != null)
            {
                goto label_22;
            }
            
            }
            
                val_12.OnShapesChecked = val_14;
                BlockPuzzleMagic.GamePlay val_15 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_18 = val_15.OnBlocksCleared;
                val_19 = 1152921504614248448;
                System.Delegate val_17 = System.Delegate.Remove(source:  val_18, value:  new System.Action<System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::OnBlocksCleared(System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> blocksCleared)));
                if(val_17 != null)
            {
                    if(null != null)
            {
                goto label_22;
            }
            
            }
            
                val_15.OnBlocksCleared = val_17;
            }
            
            if(this.isGameOverShown != false)
            {
                    return;
            }
            
            val_17.TrackModeComplete(isOutOfMoves:  false);
            return;
            label_22:
        }
        private void ShowMultilineCelebration(int lineCount)
        {
            var val_16;
            if(this.celebrationSeq != null)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  this.celebrationSeq);
            }
            
            if((lineCount - 4) <= 2)
            {
                    val_16 = mem[39724736 + ((lineCount - 4)) << 3];
                val_16 = 39724736 + ((lineCount - 4)) << 3;
            }
            else
            {
                    val_16 = "Good!";
            }
            
            UnityEngine.Transform val_3 = this.multiLineCelebrationGroup.transform;
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            .groupRectTransform = val_3;
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  1500f);
            val_3.anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            (BBLGameplayUIZenController.<>c__DisplayClass16_0)[1152921520115951296].groupRectTransform.gameObject.SetActive(value:  true);
            DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
            this.celebrationSeq = val_6;
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (BBLGameplayUIZenController.<>c__DisplayClass16_0)[1152921520115951296].groupRectTransform, endValue:  0f, duration:  0.5f, snapping:  false), ease:  27));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.celebrationSeq, interval:  1f);
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.celebrationSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (BBLGameplayUIZenController.<>c__DisplayClass16_0)[1152921520115951296].groupRectTransform, endValue:  1500f, duration:  0.5f, snapping:  false), ease:  26));
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.celebrationSeq, action:  new DG.Tweening.TweenCallback(object:  new BBLGameplayUIZenController.<>c__DisplayClass16_0(), method:  System.Void BBLGameplayUIZenController.<>c__DisplayClass16_0::<ShowMultilineCelebration>b__0()));
            return;
            label_8:
        }
        private void ShowHighScoreCelebration()
        {
            BBLGameplayUIZenController.<>c__DisplayClass17_0 val_1 = new BBLGameplayUIZenController.<>c__DisplayClass17_0();
            if(val_1.isHighScoreMessageShown == true)
            {
                    return;
            }
            
            if(this.celebrationSeq != null)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  this.celebrationSeq);
            }
            
            UnityEngine.Transform val_3 = this.highScoreCelebrationGroup.transform;
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_6;
            }
            
            }
            
            .groupRectTransform = val_3;
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  1500f);
            val_3.anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            (BBLGameplayUIZenController.<>c__DisplayClass17_0)[1152921520116240448].groupRectTransform.gameObject.SetActive(value:  true);
            DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
            this.celebrationSeq = val_6;
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (BBLGameplayUIZenController.<>c__DisplayClass17_0)[1152921520116240448].groupRectTransform, endValue:  0f, duration:  0.5f, snapping:  false), ease:  27));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.celebrationSeq, interval:  1f);
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.celebrationSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (BBLGameplayUIZenController.<>c__DisplayClass17_0)[1152921520116240448].groupRectTransform, endValue:  1500f, duration:  0.5f, snapping:  false), ease:  26));
            this = this.celebrationSeq;
            DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void BBLGameplayUIZenController.<>c__DisplayClass17_0::<ShowHighScoreCelebration>b__0())).isHighScoreMessageShown = true;
            return;
            label_6:
        }
        private void TrackModeStart()
        {
            var val_4;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "Resumed", value:  (val_1.zenModeScoreCurrent > 0) ? 1 : 0);
            val_2.Add(key:  "Starting Score", value:  val_1.zenModeScoreCurrent);
            val_4 = null;
            val_4 = null;
            App.trackerManager.track(eventName:  "Zen Mode Start", data:  val_2);
        }
        private void TrackModeComplete(bool isOutOfMoves)
        {
            var val_5;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
            val_1.Add(key:  "Score", value:  val_2.zenModeScoreCurrent);
            BestBlocksPlayer val_3 = BestBlocksPlayer.Instance;
            val_1.Add(key:  "# Pieces Placed", value:  val_3.zenModePiecesPlacedCurrent);
            val_1.Add(key:  "Out Of Moves", value:  isOutOfMoves);
            val_5 = null;
            val_5 = null;
            App.trackerManager.track(eventName:  "Zen Mode Complete", data:  val_1);
        }
        private void OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)
        {
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            string val_2 = System.String.Format(format:  "BEST: {0}", arg0:  val_1.zenModeScoreBest);
            BestBlocksPlayer val_3 = BestBlocksPlayer.Instance;
            string val_4 = System.String.Format(format:  "SCORE: {0}", arg0:  val_3.zenModeScoreCurrent);
            if(val_5.zenModeScoreBest <= 0)
            {
                    BestBlocksPlayer.Instance.isHighScoreMessageShown = true;
            }
            
            this.isGameOverShown = false;
            int val_8 = new int[4] {9, 40, 49, 90}[(UnityEngine.Random.Range(min:  0, max:  val_6.Length)) << 2];
            BlockPuzzleMagic.BBLGameplayUIHelper.PlayLevelIntroAnimation(pulseOrigin:  val_8);
            val_8.TrackModeStart();
        }
        private void OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)
        {
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            shape = val_1.zenBaseScorePerBlock * shape;
            this.UpdatePlayerScore(scoreToAdd:  shape, skipAnimation:  false);
            BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
            int val_3 = val_2.zenModePiecesPlacedCurrent;
            val_3 = val_3 + 1;
            val_2.zenModePiecesPlacedCurrent = val_3;
        }
        private void OnBlocksCleared(System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> blocksCleared)
        {
            var val_3;
            var val_4;
            int val_10;
            List.Enumerator<T> val_2 = blocksCleared.GetEnumerator();
            val_10 = 0;
            goto label_4;
            label_7:
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(BlockPuzzleMagic.BestBlocksGameEcon.Instance == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = val_10 + (val_1.zenBaseScorePerBlock * (val_3 + 24));
            label_4:
            if(val_4.MoveNext() == true)
            {
                goto label_7;
            }
            
            val_4.Dispose();
            List.Enumerator<T> val_6 = val_1.zenLineClearScoreBonus.GetEnumerator();
            label_12:
            if(0.MoveNext() == false)
            {
                goto label_10;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(0.Item["ln"] != 41971712)
            {
                goto label_12;
            }
            
            val_10 = 0.Item["bn"] + val_10;
            label_10:
            0.Dispose();
            if(val_10 >= 1)
            {
                    this.UpdatePlayerScore(scoreToAdd:  val_10, skipAnimation:  false);
            }
            
            if(41971712 < 3)
            {
                    return;
            }
            
            this.ShowMultilineCelebration(lineCount:  41971712);
        }
        private void UpdatePlayerScore(int scoreToAdd, bool skipAnimation = False)
        {
            object val_14;
            var val_15;
            val_14 = this;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            int val_2 = V0.2S + val_1.zenModeScoreCurrent;
            mem2[0] = val_2;
            if(skipAnimation != false)
            {
                    string val_3 = System.String.Format(format:  "SCORE: {0}", arg0:  val_2);
            }
            else
            {
                    if(this.tweenerScoreCurrent != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.tweenerScoreCurrent, complete:  false);
                val_15 = mem[val_1.zenModeScoreCurrent];
                val_15 = val_1.zenModeScoreCurrent;
            }
            else
            {
                    val_15 = val_2;
            }
            
                this.tweenerScoreCurrent = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetSpeedBased<DG.Tweening.Tweener>(t:  DG.Tweening.DOVirtual.Float(from:  (float)val_1.zenModeScoreCurrent, to:  (float)val_15, duration:  9.25f, onVirtualUpdate:  new DG.Tweening.TweenCallback<System.Single>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::<UpdatePlayerScore>b__23_0(float v)))), ease:  1);
            }
            
            if(val_1.zenModeScoreCurrent <= val_1.zenModeScoreBest)
            {
                    return;
            }
            
            val_1.zenModeScoreBest = val_1.zenModeScoreCurrent;
            this.ShowHighScoreCelebration();
            if(skipAnimation != false)
            {
                    val_14 = this.scoreBestLabel;
                string val_8 = System.String.Format(format:  "BEST: {0}", arg0:  val_1.zenModeScoreBest);
                return;
            }
            
            if(this.tweenerScoreBest != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.tweenerScoreBest, complete:  false);
            }
            
            this.tweenerScoreBest = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetSpeedBased<DG.Tweening.Tweener>(t:  DG.Tweening.DOVirtual.Float(from:  (float)val_1.zenModeScoreBest, to:  (float)val_1.zenModeScoreBest, duration:  9.25f, onVirtualUpdate:  new DG.Tweening.TweenCallback<System.Single>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIZenController::<UpdatePlayerScore>b__23_1(float v)))), ease:  1);
        }
        private void OnShapesChecked(bool canFit)
        {
            if(canFit != false)
            {
                    return;
            }
            
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.GameOver(success:  false);
        }
        private void OnGameOver(bool success)
        {
            if(this.isGameOverShown != false)
            {
                    return;
            }
            
            this.TrackModeComplete(isOutOfMoves:  true);
            this.isHighScoreMessageShown = false;
            this.isGameOverShown = true;
            WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BBLGameOverZenScreen>(showNext:  false);
        }
        public BBLGameplayUIZenController()
        {
        
        }
        private void <UpdatePlayerScore>b__23_0(float v)
        {
            string val_2 = System.String.Format(format:  "SCORE: {0}", arg0:  UnityEngine.Mathf.FloorToInt(f:  v));
        }
        private void <UpdatePlayerScore>b__23_1(float v)
        {
            string val_2 = System.String.Format(format:  "BEST: {0}", arg0:  UnityEngine.Mathf.FloorToInt(f:  v));
        }
    
    }

}
