using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLGameplayUIController : MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>
    {
        // Fields
        private UnityEngine.CanvasGroup topStatViewCanvasGroup;
        private UnityEngine.CanvasGroup topGameplayCanvasGroup;
        private UnityEngine.CanvasGroup powerupUiCanvasGroup;
        private UnityEngine.UI.Button buttonTapEnd;
        private UnityEngine.UI.Text buttonEndText;
        private UnityEngine.UI.Text levelLabel;
        private BlockPuzzleMagic.BBLPowerupShapeButton buttonPowerupBomb;
        private BlockPuzzleMagic.BBLPowerupShapeButton buttonPowerupFill;
        private BlockPuzzleMagic.BBLTrashShapeButton buttonPowerupTrash;
        private BlockPuzzleMagic.PowerupEarthquakeButton buttonPowerupEarthquake;
        private UnityEngine.GameObject freeCoinsButton;
        private UnityEngine.GameObject howToPlayButton;
        private UnityEngine.CanvasGroup ftuxTopBannerCanvasGroup;
        private UnityEngine.GameObject ftuxTopBannerCrate;
        private UnityEngine.GameObject ftuxTopBannerStone;
        private UnityEngine.GameObject ftuxTopBannerMetal;
        private bool isIntroAnimQueued;
        private bool levelContainsStones;
        private bool levelContainsDots;
        private bool suppressFtuxWindows;
        private BBLLevelIntroPopup levelIntroPopup;
        
        // Properties
        public UnityEngine.CanvasGroup TopStatViewCanvasGroup { get; }
        public UnityEngine.CanvasGroup TopGameplayCanvasGroup { get; }
        public UnityEngine.CanvasGroup PowerupUiCanvasGroup { get; }
        public BlockPuzzleMagic.BBLPowerupShapeButton ButtonPowerupBomb { get; }
        public BlockPuzzleMagic.BBLPowerupShapeButton ButtonPowerupFill { get; }
        public BlockPuzzleMagic.BBLTrashShapeButton ButtonPowerupTrash { get; }
        public BlockPuzzleMagic.PowerupEarthquakeButton ButtonPowerupEarthquake { get; }
        public bool IsFtuxTopBannerActive { get; }
        
        // Methods
        public UnityEngine.CanvasGroup get_TopStatViewCanvasGroup()
        {
            return (UnityEngine.CanvasGroup)this.topStatViewCanvasGroup;
        }
        public UnityEngine.CanvasGroup get_TopGameplayCanvasGroup()
        {
            return (UnityEngine.CanvasGroup)this.topGameplayCanvasGroup;
        }
        public UnityEngine.CanvasGroup get_PowerupUiCanvasGroup()
        {
            return (UnityEngine.CanvasGroup)this.powerupUiCanvasGroup;
        }
        public BlockPuzzleMagic.BBLPowerupShapeButton get_ButtonPowerupBomb()
        {
            return (BlockPuzzleMagic.BBLPowerupShapeButton)this.buttonPowerupBomb;
        }
        public BlockPuzzleMagic.BBLPowerupShapeButton get_ButtonPowerupFill()
        {
            return (BlockPuzzleMagic.BBLPowerupShapeButton)this.buttonPowerupFill;
        }
        public BlockPuzzleMagic.BBLTrashShapeButton get_ButtonPowerupTrash()
        {
            return (BlockPuzzleMagic.BBLTrashShapeButton)this.buttonPowerupTrash;
        }
        public BlockPuzzleMagic.PowerupEarthquakeButton get_ButtonPowerupEarthquake()
        {
            return (BlockPuzzleMagic.PowerupEarthquakeButton)this.buttonPowerupEarthquake;
        }
        public bool get_IsFtuxTopBannerActive()
        {
            var val_4;
            if(this.ftuxTopBannerCanvasGroup.isActiveAndEnabled != false)
            {
                    var val_3 = (this.ftuxTopBannerCanvasGroup.alpha >= 1f) ? 1 : 0;
                return (bool)val_4;
            }
            
            val_4 = 0;
            return (bool)val_4;
        }
        public override void InitMonoSingleton()
        {
            this.powerupUiCanvasGroup.alpha = 0f;
            this.powerupUiCanvasGroup.interactable = false;
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  false);
            this.ftuxTopBannerCanvasGroup.alpha = 0f;
            this.ftuxTopBannerCrate.SetActive(value:  false);
            this.ftuxTopBannerCrate.SetActive(value:  false);
            this.ftuxTopBannerCrate.SetActive(value:  false);
            BlockPuzzleMagic.BBLGameplayUIController val_2 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_2.topStatViewCanvasGroup.alpha = 0f;
            BlockPuzzleMagic.BBLGameplayUIController val_3 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_3.topGameplayCanvasGroup.alpha = 0f;
        }
        private void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_1.OnLevelDataInitialized = val_3;
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnGameOver, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnGameOver(bool success)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_4.OnGameOver = val_6;
            BlockPuzzleMagic.GamePlay val_7 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnShapePlaced, b:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shapeInfo)));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_7.OnShapePlaced = val_9;
            BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_10.OnShapesChecked, b:  new System.Action<System.Boolean>(object:  this, method:  public System.Void BlockPuzzleMagic.BBLGameplayUIController::OnShapesChecked(bool canFit)));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_10.OnShapesChecked = val_12;
            BlockPuzzleMagic.GamePlay val_13 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_15 = System.Delegate.Combine(a:  val_13.OnPowerupUsed, b:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnPowerupUsed(BlockPuzzleMagic.PowerUpType powerupUsed)));
            if(val_15 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_13.OnPowerupUsed = val_15;
            System.Delegate val_18 = System.Delegate.Combine(a:  val_16.OnPowerupMode, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnPowerupMode(bool isModeEntered)));
            if(val_18 != null)
            {
                    if(null != null)
            {
                goto label_20;
            }
            
            }
            
            val_16.OnPowerupMode = val_18;
            WGWindowManager val_19 = MonoSingleton<WGWindowManager>.Instance;
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnWindowClosed()));
            this.buttonTapEnd.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnButtonTapToEndClicked()));
            BlockPuzzleMagic.BBLDataParser val_22 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance;
            val_22.Initialize();
            UnityEngine.Coroutine val_24 = this.StartCoroutine(routine:  val_22.DelayedGameplayInit());
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == true)
            {
                    return;
            }
            
            GameBehavior val_27 = App.getBehavior;
            if((val_27.<metaGameBehavior>k__BackingField) < 2)
            {
                    return;
            }
            
            this.levelIntroPopup = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BBLLevelIntroPopup>(showNext:  false);
            this.isIntroAnimQueued = true;
            return;
            label_20:
        }
        private System.Collections.IEnumerator DelayedGameplayInit()
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new BBLGameplayUIController.<DelayedGameplayInit>d__39();
        }
        private void OnDestroy()
        {
            System.Action<System.Boolean> val_24;
            WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
            if(val_1 != 0)
            {
                    WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance;
                val_1.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnWindowClosed()));
            }
            
            if(this.buttonTapEnd != 0)
            {
                    this.buttonTapEnd.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnButtonTapToEndClicked()));
            }
            
            val_24 = 1152921504893161472;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_9 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_11 = System.Delegate.Remove(source:  val_9.OnLevelDataInitialized, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)));
            if(val_11 != null)
            {
                    if(null != null)
            {
                goto label_36;
            }
            
            }
            
            val_9.OnLevelDataInitialized = val_11;
            BlockPuzzleMagic.GamePlay val_12 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_14 = System.Delegate.Remove(source:  val_12.OnGameOver, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnGameOver(bool success)));
            if(val_14 != null)
            {
                    if(null != null)
            {
                goto label_36;
            }
            
            }
            
            val_12.OnGameOver = val_14;
            BlockPuzzleMagic.GamePlay val_15 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_17 = System.Delegate.Remove(source:  val_15.OnShapesChecked, value:  new System.Action<System.Boolean>(object:  this, method:  public System.Void BlockPuzzleMagic.BBLGameplayUIController::OnShapesChecked(bool canFit)));
            if(val_17 != null)
            {
                    if(null != null)
            {
                goto label_36;
            }
            
            }
            
            val_15.OnShapesChecked = val_17;
            BlockPuzzleMagic.GamePlay val_18 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_20 = System.Delegate.Remove(source:  val_18.OnPowerupUsed, value:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnPowerupUsed(BlockPuzzleMagic.PowerUpType powerupUsed)));
            if(val_20 != null)
            {
                    if(null != null)
            {
                goto label_36;
            }
            
            }
            
            val_18.OnPowerupUsed = val_20;
            BlockPuzzleMagic.GamePlay val_21 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_24 = val_21.OnPowerupMode;
            System.Delegate val_23 = System.Delegate.Remove(source:  val_24, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::OnPowerupMode(bool isModeEntered)));
            if(val_23 != null)
            {
                    if(null != null)
            {
                goto label_36;
            }
            
            }
            
            val_21.OnPowerupMode = val_23;
            return;
            label_36:
        }
        private void OnLevelInitialized(BlockPuzzleMagic.Level currentLevel)
        {
            int val_21;
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() != false)
            {
                    val_21 = 1;
            }
            else
            {
                    val_21 = currentLevel.levelId;
            }
            
            string val_3 = System.String.Format(format:  "LEVEL {0}", arg0:  val_21);
            this.howToPlayButton.SetActive(value:  false);
            this.freeCoinsButton.SetActive(value:  false);
            if((UnityEngine.Object.op_Implicit(exists:  this.levelIntroPopup)) != false)
            {
                    this.levelIntroPopup.Init();
            }
            
            this.levelContainsStones = currentLevel.gridLayout.GridContainsNodeType(_nodeType:  4);
            this.levelContainsDots = currentLevel.gridLayout.GridContainsNodeType(_nodeType:  2);
            int val_10 = BestBlocksPlayer.Instance.level;
            if(val_10 <= 5)
            {
                goto label_16;
            }
            
            if(val_10 >= BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart)
            {
                    if(val_10 <= BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd)
            {
                    if(currentLevel.movesMade <= 0)
            {
                goto label_19;
            }
            
            }
            
            }
            
            if(val_10 >= BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart)
            {
                    if(val_10 <= BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd)
            {
                    if(currentLevel.movesMade <= 0)
            {
                goto label_22;
            }
            
            }
            
            }
            
            this.powerupUiCanvasGroup.alpha = 1f;
            this.powerupUiCanvasGroup.blocksRaycasts = true;
            this.powerupUiCanvasGroup.interactable = true;
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  false);
            this.ftuxTopBannerCanvasGroup.alpha = 0f;
            goto label_29;
            label_16:
            if(val_10 == 1)
            {
                goto label_29;
            }
            
            this.powerupUiCanvasGroup.alpha = 0f;
            this.powerupUiCanvasGroup.blocksRaycasts = false;
            this.powerupUiCanvasGroup.interactable = false;
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  true);
            this.ftuxTopBannerCanvasGroup.alpha = 1f;
            label_53:
            this.ftuxTopBannerCrate.SetActive(value:  true);
            label_29:
            this.suppressFtuxWindows = false;
            if((this.CheckShowFTUX(currentLevel:  currentLevel)) != true)
            {
                    this.topStatViewCanvasGroup.alpha = 1f;
                this.topGameplayCanvasGroup.alpha = 1f;
            }
            
            this.buttonTapEnd.gameObject.SetActive(value:  false);
            return;
            label_19:
            this.powerupUiCanvasGroup.alpha = 0f;
            this.powerupUiCanvasGroup.blocksRaycasts = false;
            this.powerupUiCanvasGroup.interactable = false;
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  true);
            this.ftuxTopBannerCanvasGroup.alpha = 1f;
            if(this.ftuxTopBannerStone != null)
            {
                goto label_53;
            }
            
            label_22:
            this.powerupUiCanvasGroup.alpha = 0f;
            this.powerupUiCanvasGroup.blocksRaycasts = false;
            this.powerupUiCanvasGroup.interactable = false;
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  true);
            this.ftuxTopBannerCanvasGroup.alpha = 1f;
            if(this.ftuxTopBannerMetal != null)
            {
                goto label_53;
            }
            
            throw new NullReferenceException();
        }
        private void OnShapePlaced(BlockPuzzleMagic.ShapeInfo shapeInfo)
        {
            int val_2 = BestBlocksPlayer.Instance.level;
            if(val_2 >= BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart)
            {
                    if(val_2 <= BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd)
            {
                goto label_3;
            }
            
            }
            
            if(val_2 < BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart)
            {
                    return;
            }
            
            if(val_2 > BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd)
            {
                    return;
            }
            
            label_3:
            if(this.ftuxTopBannerCanvasGroup.isActiveAndEnabled == false)
            {
                    return;
            }
            
            this.powerupUiCanvasGroup.alpha = 0f;
            DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.ftuxTopBannerCanvasGroup, endValue:  0f, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::<OnShapePlaced>b__42_0()));
            DG.Tweening.Tweener val_11 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.powerupUiCanvasGroup, endValue:  1f, duration:  0.5f);
            this.powerupUiCanvasGroup.blocksRaycasts = true;
            this.powerupUiCanvasGroup.interactable = true;
        }
        public void OnShapesChecked(bool canFit)
        {
            int val_3 = DG.Tweening.DOTween.Complete(targetOrId:  this.buttonTapEnd.gameObject.transform, withCallbacks:  true);
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if((this.CheckShowFTUXOnInputResolved(currentLevel:  val_4.currentLevel)) != 0)
            {
                    return;
            }
            
            if(this.buttonTapEnd.gameObject.activeSelf ^ canFit == true)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  1f, y:  (canFit != true) ? 1f : 0f, z:  1f);
            this.buttonTapEnd.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            this.buttonTapEnd.gameObject.SetActive(value:  true);
            this.UpdateTapToEndButtonText();
            if(canFit != false)
            {
                    DG.Tweening.Tweener val_20 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScaleY(target:  this.buttonTapEnd.gameObject.transform, endValue:  (canFit != true) ? 0f : 1f, duration:  0.2f), ease:  4), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::<OnShapesChecked>b__43_0()));
                return;
            }
            
            this.buttonPowerupTrash.trashIconShake.ShakeNow();
        }
        private void OnPowerupUsed(BlockPuzzleMagic.PowerUpType powerupUsed)
        {
            if(this.buttonTapEnd.gameObject.activeSelf == false)
            {
                    return;
            }
            
            this.UpdateTapToEndButtonText();
        }
        private void OnPowerupMode(bool isModeEntered)
        {
            if((MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GameBoardGenerator val_3 = MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance;
            val_3.gridBackgroundImage.gameObject.SetActive(value:  isModeEntered);
        }
        private void OnButtonTapToEndClicked()
        {
            WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BBLGameOverScreen>(showNext:  false);
        }
        private void OnGameOver(bool success)
        {
            var val_8;
            var val_9;
            DG.Tweening.TweenCallback val_11;
            var val_12;
            this.suppressFtuxWindows = true;
            if(success == false)
            {
                    return;
            }
            
            UnityEngine.Color val_1 = UnityEngine.Color.clear;
            val_8 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a}, setBgColorInstantly:  true, contentToShow:  public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 184);
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == true)
            {
                goto label_14;
            }
            
            BlockPuzzleMagic.LevelManager val_4 = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance;
            if(val_4.currentChapter.chapterId < 1)
            {
                goto label_14;
            }
            
            val_9 = null;
            val_9 = null;
            val_11 = BBLGameplayUIController.<>c.<>9__47_0;
            if(val_11 != null)
            {
                goto label_23;
            }
            
            DG.Tweening.TweenCallback val_5 = null;
            val_11 = val_5;
            val_5 = new DG.Tweening.TweenCallback(object:  BBLGameplayUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLGameplayUIController.<>c::<OnGameOver>b__47_0());
            BBLGameplayUIController.<>c.<>9__47_0 = val_11;
            goto label_23;
            label_14:
            val_12 = null;
            val_12 = null;
            val_11 = BBLGameplayUIController.<>c.<>9__47_1;
            if(val_11 == null)
            {
                    DG.Tweening.TweenCallback val_6 = null;
                val_11 = val_6;
                val_6 = new DG.Tweening.TweenCallback(object:  BBLGameplayUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLGameplayUIController.<>c::<OnGameOver>b__47_1());
                BBLGameplayUIController.<>c.<>9__47_1 = val_11;
            }
            
            label_23:
            DG.Tweening.Tween val_7 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.85f, callback:  val_6, ignoreTimeScale:  true);
        }
        private void OnWindowClosed()
        {
            if(this.isIntroAnimQueued != false)
            {
                    if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) <= 0)
            {
                    BlockPuzzleMagic.BBLGameplayUIHelper.PlayLevelIntroAnimation(pulseOrigin:  40);
                this.isIntroAnimQueued = false;
            }
            
            }
            
            this.CheckShowFTUXDelayed();
        }
        private void UpdateTapToEndButtonText()
        {
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void CheckShowFTUXDelayed()
        {
            if(this.suppressFtuxWindows != false)
            {
                    return;
            }
            
            DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.BBLGameplayUIController::<CheckShowFTUXDelayed>b__50_0()), ignoreTimeScale:  true);
        }
        private bool CheckShowFTUX(BlockPuzzleMagic.Level currentLevel)
        {
            var val_14;
            int val_15;
            BlockPuzzleMagic.FtuxId val_16;
            if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) > 0)
            {
                    return false;
            }
            
            if(this.suppressFtuxWindows != false)
            {
                    return false;
            }
            
            BestBlocksPlayer val_3 = BestBlocksPlayer.Instance;
            GameBehavior val_4 = App.getBehavior;
            if((BlockPuzzleMagic.BBLFtuxData.IsEligibleForCuratedFtuxLevels(playerLevel:  val_4.<metaGameBehavior>k__BackingField)) == false)
            {
                goto label_12;
            }
            
            val_14 = null;
            val_14 = null;
            val_15 = BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel;
            if(val_15 != 1)
            {
                goto label_15;
            }
            
            val_16 = 1;
            goto label_38;
            label_12:
            if((currentLevel.levelId != (BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  0))) || ((val_3.tutorialCompleted & 64) != 0))
            {
                goto label_23;
            }
            
            val_16 = 6;
            goto label_38;
            label_23:
            if((currentLevel.levelId != (BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  1))) || ((val_3.tutorialCompleted & 16) != 0))
            {
                goto label_30;
            }
            
            val_16 = 4;
            goto label_38;
            label_30:
            if((currentLevel.levelId != (BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  2))) || ((val_3.tutorialCompleted & 32) != 0))
            {
                    return false;
            }
            
            val_16 = 5;
            goto label_38;
            label_15:
            val_15 = BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel;
            if(val_15 != 2)
            {
                    return false;
            }
            
            val_16 = 2;
            label_38:
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<FTUXDemoWindow>(showNext:  false).ShowFTUXStep(stage:  val_16, targetGO:  0);
            return false;
        }
        private BlockPuzzleMagic.FtuxId CheckShowFTUXOnInputResolved(BlockPuzzleMagic.Level currentLevel)
        {
            float val_14;
            BlockPuzzleMagic.ShapeInfo val_15;
            var val_16;
            var val_17;
            var val_18;
            if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) > 0)
            {
                    return 0;
            }
            
            if(this.suppressFtuxWindows != false)
            {
                    return 0;
            }
            
            BestBlocksPlayer val_4 = BestBlocksPlayer.Instance;
            .stageToShow = 0;
            .target = 0;
            val_14 = 0f;
            if(((BlockPuzzleMagic.ShapeInfo.IsRotationAllowed == false) || ((this.suppressFtuxWindows & 64) != 0)) || (currentLevel.levelId != 1))
            {
                goto label_31;
            }
            
            val_15 = 0;
            val_16 = 0;
            val_17 = 4;
            goto label_12;
            label_30:
            BlockPuzzleMagic.BlockShapeSpawner val_6 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
            if(val_6.spawnedShapes[0] != 0)
            {
                    BlockPuzzleMagic.BlockShapeSpawner val_8 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
                val_15 = val_8.spawnedShapes[0];
                val_16 = 1;
            }
            
            val_17 = 5;
            label_12:
            BlockPuzzleMagic.BlockShapeSpawner val_9 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
            if((val_17 - 4) < val_9.spawnedShapes.Length)
            {
                goto label_30;
            }
            
            if(val_16 == 1)
            {
                    .stageToShow = 14;
                val_14 = 0.2f;
                .target = val_15.gameObject;
            }
            
            label_31:
            BlockPuzzleMagic.FtuxId val_16 = (BBLGameplayUIController.<>c__DisplayClass52_0)[1152921520111088272].stageToShow;
            if(val_16 == 0)
            {
                    return 0;
            }
            
            val_16 = 1 << val_16;
            if(val_4.tutorialCompleted != val_16)
            {
                    return 0;
            }
            
            UnityEngine.Color val_12 = UnityEngine.Color.clear;
            val_18 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_18 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            val_18 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_18 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_12.r, g = val_12.g, b = val_12.b, a = val_12.a}, setBgColorInstantly:  true, contentToShow:  public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 184);
            DG.Tweening.Tween val_14 = DG.Tweening.DOVirtual.DelayedCall(delay:  val_14, callback:  new DG.Tweening.TweenCallback(object:  new BBLGameplayUIController.<>c__DisplayClass52_0(), method:  System.Void BBLGameplayUIController.<>c__DisplayClass52_0::<CheckShowFTUXOnInputResolved>b__0()), ignoreTimeScale:  true);
            return 0;
        }
        public void OnPowerupsBuy()
        {
            this.buttonTapEnd.gameObject.SetActive(value:  false);
        }
        public BBLGameplayUIController()
        {
        
        }
        private void <OnShapePlaced>b__42_0()
        {
            this.ftuxTopBannerCanvasGroup.gameObject.SetActive(value:  false);
        }
        private void <OnShapesChecked>b__43_0()
        {
            this.buttonTapEnd.gameObject.SetActive(value:  false);
        }
        private void <CheckShowFTUXDelayed>b__50_0()
        {
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if((this.CheckShowFTUX(currentLevel:  val_3.currentLevel)) != false)
            {
                    return;
            }
            
            this.topStatViewCanvasGroup.alpha = 1f;
            BlockPuzzleMagic.BBLGameplayUIController val_5 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_5.topGameplayCanvasGroup.alpha = 1f;
        }
    
    }

}
