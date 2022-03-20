using UnityEngine;

namespace WordForest
{
    public class WFOWordStreak : WordStreak
    {
        // Fields
        private static string PREFS_LAST_STREAK;
        private UnityEngine.UI.Text labelStreakCounter;
        private UnityEngine.UI.Text labelStreakSaverCounter;
        private UnityEngine.Transform upsellStreakBadge;
        private UnityEngine.Transform upsellStreakBadgeTargetOnButton;
        private UnityEngine.Transform gameplayStreakBadge;
        private UnityEngine.ParticleSystem particles;
        private DG.Tweening.Tweener streakMoverTween;
        private UnityEngine.Vector3 upsellBadgeInitialPos;
        
        // Properties
        public bool IsUnlocked { get; }
        private bool IsTutorialUnlocked { get; }
        
        // Methods
        public bool get_IsUnlocked()
        {
            var val_6;
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            if(val_1.currentForestID < val_2.wordStreakUnlockLevel)
            {
                    val_6 = 0;
                return (bool)((val_3.<metaGameBehavior>k__BackingField) >= (val_4.<metaGameBehavior>k__BackingField)) ? 1 : 0;
            }
            
            GameBehavior val_3 = App.getBehavior;
            GameBehavior val_4 = App.getBehavior;
            return (bool)((val_3.<metaGameBehavior>k__BackingField) >= (val_4.<metaGameBehavior>k__BackingField)) ? 1 : 0;
        }
        private bool get_IsTutorialUnlocked()
        {
            GameBehavior val_1 = App.getBehavior;
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            return (bool)((val_1.<metaGameBehavior>k__BackingField) >= val_2.wordStreakTutorialLevel) ? 1 : 0;
        }
        protected override void OnLevelLoaded(GameLevel level)
        {
            var val_20;
            System.Predicate<LineWord> val_22;
            var val_23;
            var val_24;
            this.OnLevelLoaded(level:  level);
            if(this.IsTutorialUnlocked != false)
            {
                    WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
                bool val_3 = MonoExtensions.IsBitSet(value:  val_2.tutorialCompleted, bit:  7);
                if(val_3 != true)
            {
                    if(val_3.IsUnlocked != false)
            {
                    WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
                val_5.tutorialCompleted = MonoExtensions.SetBit(value:  val_6.tutorialCompleted, bit:  7);
                GameBehavior val_8 = App.getBehavior;
            }
            
            }
            
            }
            
            mem[(1152921504946249728 + (public WordForest.WFOWordStreakInfoPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFOWordStreakInfoPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312] + 248.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WordForest.WFOWordStreak).__il2cppRuntimeField_218));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFadeInBegin");
            WordRegion val_12 = WordRegion.instance;
            val_12.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WordForest.WFOWordStreak::OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)));
            WordRegion val_14 = WordRegion.instance;
            val_20 = null;
            val_20 = null;
            val_22 = WFOWordStreak.<>c.<>9__13_0;
            if(val_22 == null)
            {
                    System.Predicate<LineWord> val_15 = null;
                val_22 = val_15;
                val_15 = new System.Predicate<LineWord>(object:  WFOWordStreak.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOWordStreak.<>c::<OnLevelLoaded>b__13_0(LineWord x));
                WFOWordStreak.<>c.<>9__13_0 = val_22;
            }
            
            if((val_12.Find(match:  val_15)) == 0)
            {
                    val_23 = null;
                val_23 = null;
                if((UnityEngine.PlayerPrefs.GetInt(key:  WordForest.WFOWordStreak.PREFS_LAST_STREAK)) >= 1)
            {
                    val_24 = null;
                val_24 = null;
                mem[1152921519434319752] = UnityEngine.PlayerPrefs.GetInt(key:  WordForest.WFOWordStreak.PREFS_LAST_STREAK);
            }
            
            }
        
        }
        private void OnFadeInBegin()
        {
            this.OnPlayerInput();
        }
        private void OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)
        {
            this.OnPlayerInput();
        }
        private void OnPlayerInput()
        {
            this.CancelStreakSaverAnimation();
            bool val_2 = this.gameObject.activeSelf;
            if(val_2 == false)
            {
                    return;
            }
            
            val_2.gameObject.SetActive(value:  false);
            this.upsellStreakBadge.gameObject.SetActive(value:  false);
        }
        public override void ResetStreak()
        {
            var val_1;
            this.ResetStreak();
            val_1 = null;
            val_1 = null;
            UnityEngine.PlayerPrefs.SetInt(key:  WordForest.WFOWordStreak.PREFS_LAST_STREAK, value:  0);
        }
        protected override void OnValidWordSubmitted(string word, bool extra)
        {
            var val_7;
            if(this.IsUnlocked == false)
            {
                    return;
            }
            
            if(extra != false)
            {
                    GameBehavior val_2 = App.getBehavior;
                if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                    return;
            }
            
            }
            
            mem[1152921519435002664] = 0;
            mem[1152921519435002632] = typeof(MetaGameBehavior).__il2cppRuntimeField_B28;
            val_7 = null;
            val_7 = null;
            UnityEngine.PlayerPrefs.SetInt(key:  WordForest.WFOWordStreak.PREFS_LAST_STREAK, value:  typeof(MetaGameBehavior).__il2cppRuntimeField_B28>>0&0xFFFFFFFF);
            DG.Tweening.TweenCallback val_3 = new DG.Tweening.TweenCallback(object:  this, method:  typeof(WordForest.WFOWordStreak).__il2cppRuntimeField_208);
            DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  val_3, ignoreTimeScale:  true);
            GameBehavior val_5 = App.getBehavior;
            if(val_3 < (val_5.<metaGameBehavior>k__BackingField))
            {
                    this.StopBorderEffects();
                return;
            }
            
            this.PlayBorderEffects(restoreEffects:  false);
        }
        protected override void OnInvalidWordSubmitted()
        {
            if(this.IsUnlocked == false)
            {
                    return;
            }
            
            if(this.StreakSaverEnabled != false)
            {
                    mem[1152921519435147432] = (MonoSingleton<WordForest.WFOManagerGameplay>.Instance.TotalAdditionalMultipliers) + W21;
            }
            
            this.StopBorderEffects();
            this = ???;
            goto typeof(WordForest.WFOWordStreak).__il2cppRuntimeField_200;
        }
        protected override void UpdateStreakCounterLabel()
        {
            UnityEngine.Transform val_40;
            var val_41;
            val_40 = this;
            int val_5 = (MonoSingleton<WordForest.WFOManagerGameplay>.Instance.TotalAdditionalMultipliers) + W23;
            string val_6 = System.String.Format(format:  "{0}X", arg0:  val_5);
            this.gameplayStreakBadge.gameObject.SetActive(value:  (val_5 > 0) ? 1 : 0);
            string val_9 = System.String.Format(format:  "{0}X", arg0:  null);
            decimal val_10 = System.Decimal.op_Implicit(value:  1152921504619999232);
            decimal val_11 = this.CostMultiplier;
            decimal val_12 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
            string val_13 = val_12.flags.ToString();
            this.labelStreakSaverCounter.interactable = true;
            UnityEngine.GameObject val_14 = this.labelStreakSaverCounter.gameObject;
            if(this.StreakSaverEnabled != false)
            {
                    if(val_10.flags >= this.MinOffer)
            {
                goto label_16;
            }
            
            }
            
            val_41 = 0;
            if(val_14 == null)
            {
                    label_16:
            }
            
            val_14.SetActive(value:  (null > val_5) ? 1 : 0);
            this.upsellStreakBadge.gameObject.SetActive(value:  1152921504814993408.gameObject.activeSelf);
            UnityEngine.Vector3 val_22 = this.upsellStreakBadge.position;
            UnityEngine.Vector3 val_24 = this.upsellStreakBadge.transform.position;
            UnityEngine.Vector3 val_25 = this.upsellStreakBadge.position;
            this.upsellBadgeInitialPos = val_26.x;
            mem[1152921519435386480] = val_26.z;
            if(35167.gameObject.activeSelf == true)
            {
                    return;
            }
            
            if((new UnityEngine.Vector3(x:  val_22.x, y:  val_24.y, z:  val_25.z).gameObject.activeSelf) == false)
            {
                    return;
            }
            
            mem[1152921519435386381] = 1;
            UnityEngine.Vector3 val_29 = this.gameplayStreakBadge.position;
            this.upsellStreakBadge.position = new UnityEngine.Vector3() {x = val_29.x, y = val_29.y, z = val_29.z};
            if(this.upsellStreakBadgeTargetOnButton != 0)
            {
                    UnityEngine.Vector3 val_31 = this.upsellStreakBadgeTargetOnButton.position;
            }
            
            UnityEngine.Transform val_34 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.upsellStreakBadge, endValue:  new UnityEngine.Vector3() {x = this.upsellBadgeInitialPos, y = val_29.y, z = val_29.z}, duration:  0.55f, snapping:  false), ease:  7).transform;
            UnityEngine.Vector3 val_35 = UnityEngine.Vector3.zero;
            val_34.localScale = new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z};
            val_40 = val_34.transform;
            UnityEngine.Vector3 val_37 = new UnityEngine.Vector3(x:  1.4f, y:  1.4f, z:  1f);
            DG.Tweening.Tweener val_39 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_40, endValue:  new UnityEngine.Vector3() {x = val_37.x, y = val_37.y, z = val_37.z}, duration:  0.55f), ease:  31);
        }
        protected override void OnStreakSaverButtonClicked()
        {
            var val_12;
            var val_14;
            Player val_1 = App.Player;
            decimal val_2 = System.Decimal.op_Implicit(value:  W22);
            decimal val_3 = this.CostMultiplier;
            decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41967616}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
            {
                    val_12 = null;
                val_12 = null;
                PurchaseProxy.currentPurchasePoint = 121;
                GameBehavior val_6 = App.getBehavior;
                val_6.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
                return;
            }
            
            decimal val_8 = System.Decimal.op_Implicit(value:  41967616);
            decimal val_9 = this.CostMultiplier;
            decimal val_10 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            bool val_11 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, source:  "Streak Saver", externalParams:  0, animated:  false);
            mem[1152921519435633548] = 1;
            mem[1152921519435633544] = val_10.lo;
            val_14 = null;
            val_14 = null;
            UnityEngine.PlayerPrefs.SetInt(key:  WordForest.WFOWordStreak.PREFS_LAST_STREAK, value:  val_10.lo);
            mem[1152921519435633576] = 0;
            WordForest.WFOWordStreak.PREFS_LAST_STREAK.interactable = false;
            this.AnimateStreakSaved();
        }
        private void AnimateStreakSaved()
        {
            UnityEngine.Vector3 val_1 = this.gameplayStreakBadge.position;
            this.streakMoverTween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.upsellStreakBadge, endValue:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOWordStreak::OnAnimComplete())), delay:  0.1f), autoKillOnCompletion:  true);
        }
        private void OnAnimComplete()
        {
            DG.Tweening.TweenExtensions.Kill(t:  this.streakMoverTween, complete:  false);
            this.upsellStreakBadge.gameObject.SetActive(value:  true);
            this.particles.Play();
            this.PlayBorderEffects(restoreEffects:  false);
        }
        private void CancelStreakSaverAnimation()
        {
            DG.Tweening.TweenExtensions.Kill(t:  this.streakMoverTween, complete:  false);
            this.upsellStreakBadge.position = new UnityEngine.Vector3() {x = this.upsellBadgeInitialPos};
            this.upsellStreakBadge.gameObject.SetActive(value:  false);
            this.PlayBorderEffects(restoreEffects:  false);
        }
        public WFOWordStreak()
        {
        
        }
        private static WFOWordStreak()
        {
            WordForest.WFOWordStreak.PREFS_LAST_STREAK = "prefs_wfo_last_streak";
        }
    
    }

}
