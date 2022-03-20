using UnityEngine;

namespace BlockPuzzleMagic
{
    public class PowerupEarthquakeButton : BBLPowerupButton
    {
        // Fields
        private BBLTooltip prefabTooltip;
        private BBLTooltip earthquakeTooltipInstance;
        
        // Methods
        protected override void OnLevelInitialized(BlockPuzzleMagic.Level level)
        {
            this.OnLevelInitialized(level:  level);
            if(W8 == 0)
            {
                    return;
            }
            
            if((BestBlocksPlayer.Instance.GetFtuxStatus(ftuxId:  15)) != false)
            {
                    return;
            }
            
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.ShowFTUX());
        }
        private System.Collections.IEnumerator ShowFTUX()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new PowerupEarthquakeButton.<ShowFTUX>d__3();
        }
        protected override void OnButtonClicked()
        {
            if(true == 0)
            {
                    return;
            }
            
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  null, showStoreIfOOC:  true, oocDelay:  0f)) == false)
            {
                    return;
            }
            
            this.ResolveAction();
        }
        private void ResolveAction()
        {
            var val_10;
            this.Interactable = false;
            this.BlockRaycasts = false;
            UnityEngine.Color val_1 = UnityEngine.Color.clear;
            val_10 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            val_10 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a}, setBgColorInstantly:  true, contentToShow:  public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 184);
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UpdateGoalProgress(clearedBlocks:  val_2.cellGrid, skipRowColumnCheck:  true);
            this.PlayEarthquakeAnimation();
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  3, freeUsage:  MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.BuyPowerup(powerupType:  3, freeUsage:  false));
            DG.Tweening.Tween val_9 = DG.Tweening.DOVirtual.DelayedCall(delay:  2.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.PowerupEarthquakeButton::<ResolveAction>b__5_0()), ignoreTimeScale:  true);
        }
        private void PlayEarthquakeAnimation()
        {
            PowerupEarthquakeButton.<>c__DisplayClass6_0 val_1 = new PowerupEarthquakeButton.<>c__DisplayClass6_0();
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            .gridCells = val_2.cellGrid;
            .order = BlockPuzzleMagic.BBLGameplayUIHelper.GetGridRingedPattern(center:  40);
            .animationDelay = 0f;
            BlockPuzzleMagic.GameBoardGenerator val_4 = MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance;
            UnityEngine.UI.Image val_6 = UnityEngine.Object.Instantiate<UnityEngine.UI.Image>(original:  this, parent:  val_4.BoardContent.transform);
            .quakeIcon = val_6;
            val_6.transform.SetAsLastSibling();
            UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
            (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.rectTransform.pivot = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.zero;
            (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
            UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  300f, y:  300f);
            (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.zero;
            (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.rectTransform.localScale = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
            DG.Tweening.Sequence val_16 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.rectTransform, endValue:  1f, duration:  0.35f), ease:  27));
            DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_16, t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.transform, duration:  1f, strength:  100f, vibrato:  100, randomness:  90f, snapping:  false, fadeOut:  true));
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (PowerupEarthquakeButton.<>c__DisplayClass6_0)[1152921520198194976].quakeIcon.transform, endValue:  0f, duration:  0.2f), ease:  26));
            DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_16, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void PowerupEarthquakeButton.<>c__DisplayClass6_0::<PlayEarthquakeAnimation>b__0()));
            DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_16, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void PowerupEarthquakeButton.<>c__DisplayClass6_0::<PlayEarthquakeAnimation>b__1()));
        }
        public PowerupEarthquakeButton()
        {
        
        }
        private void <ShowFTUX>b__3_1()
        {
            MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void BlockPuzzleMagic.PowerupEarthquakeButton::<ShowFTUX>b__3_2()));
        }
        private void <ShowFTUX>b__3_2()
        {
            UnityEngine.Object.Destroy(obj:  this.earthquakeTooltipInstance.gameObject);
        }
        private void <ResolveAction>b__5_0()
        {
            this.Interactable = true;
            this.BlockRaycasts = true;
            BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  false, onOverlayClosed:  0);
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CheckBoardStatus();
        }
    
    }

}
