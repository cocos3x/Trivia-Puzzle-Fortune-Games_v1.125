using UnityEngine;

namespace WordForest
{
    public class WFOWordChestDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.CanvasGroup parentCanvasGroup;
        private UnityEngine.RectTransform chestRootTransform;
        private UnityEngine.UI.Button button;
        private UnityEngine.UI.Text labelTapToOpen;
        private UnityEngine.UI.Image lockImage;
        private UnityEngine.GameObject chestOverlay;
        private UnityEngine.GameObject unlockTooltip;
        private UnityEngine.UI.Text unlockTooltipText;
        private UnityEngine.UI.Image pointerImage;
        private UnityEngine.GameObject radialRayObject;
        private UnityEngine.UI.Image chestImageBase;
        private UnityEngine.UI.Image chestImageUpper;
        private UnityEngine.UI.Image chestImageLower;
        private UnityEngine.CanvasGroup chestLabelsCanvasGroup;
        private UnityEngine.UI.Text counterLabel;
        private UnityEngine.UI.Image meterFill;
        private UnityEngine.CanvasGroup chestCanvasGroupClosed;
        private UnityEngine.CanvasGroup chestCanvasGroupOpened;
        private UnityEngine.UI.Image chestOpenRay;
        private UnityEngine.GameObject prefabItem;
        private WordForest.WFOAcornMultiplierTrailParticle prefabItemTrailEfx;
        private WordForest.WFOAcornMultiplierTrailParticle prefabAcornMultiplierEfx;
        private UnityEngine.Sprite spriteChestGoldBase;
        private UnityEngine.Sprite spriteChestGoldUpper;
        private UnityEngine.Sprite spriteChestGoldLower;
        private UnityEngine.Sprite spriteChestSilverBase;
        private UnityEngine.Sprite spriteChestSilverUpper;
        private UnityEngine.Sprite spriteChestSilverLower;
        private UnityEngine.Sprite spriteChestBronzeBase;
        private UnityEngine.Sprite spriteChestBronzeUpper;
        private UnityEngine.Sprite spriteChestBronzeLower;
        private static bool <isChestReadyFlowActivated>k__BackingField;
        private bool isInteractable;
        private bool isAnimationActive;
        private DG.Tweening.Tweener meterFillTweener;
        private decimal creditsBeforeChestOpen;
        private System.Nullable<UnityEngine.Vector3> originalDisplayScale;
        private DG.Tweening.Tween radialRayTween;
        private UnityEngine.Transform originalParent;
        
        // Properties
        private WordForest.WFOWordChestType chestType { get; }
        public static bool isChestReadyFlowActivated { get; set; }
        private bool CanShowFtux { get; }
        protected bool IsFirstTimeOpeningChest { get; set; }
        
        // Methods
        private WordForest.WFOWordChestType get_chestType()
        {
            return MonoSingleton<WordForest.WFOWordChestManager>.Instance.CurrentWordChestType;
        }
        public static bool get_isChestReadyFlowActivated()
        {
            return (bool)WordForest.WFOWordChestDisplay.<isChestReadyFlowActivated>k__BackingField;
        }
        private static void set_isChestReadyFlowActivated(bool value)
        {
            WordForest.WFOWordChestDisplay.<isChestReadyFlowActivated>k__BackingField = value;
        }
        private bool get_CanShowFtux()
        {
            var val_7;
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) == 2)
            {
                    WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
                WordForest.WFOGameEcon val_3 = WordForest.WFOGameEcon.Instance;
                if(val_2.currentForestID == val_3.rewardWordChestUnlockLevel)
            {
                    WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
                val_7 = (MonoExtensions.IsBitSet(value:  val_4.tutorialCompleted, bit:  1)) ^ 1;
                return (bool)val_7 & 1;
            }
            
            }
            
            val_7 = 0;
            return (bool)val_7 & 1;
        }
        protected bool get_IsFirstTimeOpeningChest()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  6);
        }
        protected void set_IsFirstTimeOpeningChest(bool value)
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            val_1.tutorialCompleted = MonoExtensions.SetUnsetBit(value:  val_2.tutorialCompleted, bit:  6, isOn:  value);
        }
        protected void Start()
        {
            this.originalParent = this.gameObject.transform.parent;
            WordForest.WFOWordChestManager val_4 = MonoSingleton<WordForest.WFOWordChestManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnWordChestUpdated, b:  new System.Action(object:  this, method:  System.Void WordForest.WFOWordChestDisplay::OnWordChestUpdated()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_7;
            }
            
            }
            
            val_4.OnWordChestUpdated = val_6;
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordChestDisplay::OnChestClicked()));
            this.Initialize();
            return;
            label_7:
        }
        protected void OnDestroy()
        {
            if((MonoSingleton<WordForest.WFOWordChestManager>.Instance) == 0)
            {
                    return;
            }
            
            WordForest.WFOWordChestManager val_3 = MonoSingleton<WordForest.WFOWordChestManager>.Instance;
            1152921504893161472 = val_3.OnWordChestUpdated;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action(object:  this, method:  System.Void WordForest.WFOWordChestDisplay::OnWordChestUpdated()));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnWordChestUpdated = val_5;
            return;
            label_10:
        }
        public void SetInteractable(bool isInteractable, bool darkenLock = False)
        {
            UnityEngine.UI.Image val_6;
            bool val_6 = isInteractable;
            val_6 = this;
            bool val_2 = val_6;
            this.gameObject.SetActive(value:  val_2);
            this.isInteractable = val_2;
            val_6 = val_6 ^ 1;
            this.lockImage.gameObject.SetActive(value:  val_6);
            this.chestOverlay.SetActive(value:  val_6);
            if(darkenLock == false)
            {
                    return;
            }
            
            val_6 = this.lockImage;
            UnityEngine.Color val_5 = new UnityEngine.Color(r:  0.65f, g:  0.65f, b:  0.65f);
            val_6.color = new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a};
        }
        private void Initialize()
        {
            this.SetInteractable(isInteractable:  WordForest.WFOWordChestManager.IsFeatureUnlocked, darkenLock:  false);
            if(WordForest.WFOWordChestManager.IsFeatureUnlocked == false)
            {
                    return;
            }
            
            if(true == 0)
            {
                    UnityEngine.Vector3 val_6 = this.gameObject.transform.localScale;
                System.Nullable<UnityEngine.Vector3> val_7 = new System.Nullable<UnityEngine.Vector3>(value:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
                this.originalDisplayScale = val_7.HasValue;
            }
            
            this.labelTapToOpen.gameObject.SetActive(value:  false);
            this.ResetChestVisualState();
            if(this.CanShowFtux != false)
            {
                    this.parentCanvasGroup.alpha = 0f;
                UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.BeginChestFtuxFlow());
                return;
            }
            
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void WordForest.WFOWordChestDisplay::OnWordChestUpdated()), count:  1);
        }
        private void OnWordChestUpdated()
        {
            this.UpdateChestLabels(skipAnimation:  false);
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) != 2)
            {
                    return;
            }
            
            if((MonoSingleton<WordForest.WFOWordChestManager>.Instance.IsChestReady) == false)
            {
                    return;
            }
            
            this.BeginChestReadyFlow();
        }
        private void UpdateChestLabels(bool skipAnimation = False)
        {
            DG.Tweening.TweenCallback val_25 = MonoSingleton<WordForest.WFOWordChestManager>.Instance.CurrentWordsCompleted;
            string val_10 = (MonoSingleton<WordForest.WFOWordChestManager>.Instance.CurrentWordsRequired) - (MonoSingleton<WordForest.WFOWordChestManager>.Instance.CurrentWordsCompleted).ToString();
            float val_25 = (float)val_25;
            if(this.meterFillTweener != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.meterFillTweener, complete:  false);
            }
            
            val_25 = val_25 / ((float)MonoSingleton<WordForest.WFOWordChestManager>.Instance.CurrentWordsRequired);
            if(skipAnimation != false)
            {
                    this.meterFill.fillAmount = val_25;
                return;
            }
            
            DG.Tweening.Sequence val_11 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_11, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.button.transform, endValue:  1.15f, duration:  0.2f), ease:  27));
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_11, interval:  1f);
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_11, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.button.transform, endValue:  1f, duration:  0.2f), ease:  27));
            this.isAnimationActive = true;
            DG.Tweening.TweenCallback val_23 = null;
            val_25 = val_23;
            val_23 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOWordChestDisplay::<UpdateChestLabels>b__54_0());
            this.meterFillTweener = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFillAmount(target:  this.meterFill, endValue:  val_25, duration:  1f), ease:  1), action:  val_23);
        }
        private void ResetChestVisualState()
        {
            UnityEngine.UI.Image val_11;
            UnityEngine.Sprite val_12;
            UnityEngine.Vector3 val_3 = this.originalDisplayScale.Value;
            this.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            this.chestCanvasGroupClosed.alpha = 1f;
            this.chestCanvasGroupClosed.gameObject.SetActive(value:  true);
            this.chestCanvasGroupOpened.gameObject.SetActive(value:  false);
            this.chestCanvasGroupOpened.alpha = 0f;
            this.chestOpenRay.fillAmount = 0f;
            this.chestLabelsCanvasGroup.gameObject.SetActive(value:  true);
            UnityEngine.Color val_7 = this.labelTapToOpen.color;
            this.labelTapToOpen.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = 1f};
            this.labelTapToOpen.gameObject.SetActive(value:  false);
            UnityEngine.Color val_9 = this.counterLabel.color;
            this.counterLabel.color = new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = 1f};
            WordForest.WFOWordChestType val_10 = this.counterLabel.chestType;
            if(val_10 == 1)
            {
                goto label_18;
            }
            
            if(val_10 == 2)
            {
                goto label_19;
            }
            
            if(val_10 != 3)
            {
                goto label_20;
            }
            
            val_11 = this;
            this.chestImageBase.sprite = this.spriteChestGoldBase;
            this.chestImageLower.sprite = this.spriteChestGoldLower;
            val_12 = this.spriteChestGoldUpper;
            goto label_28;
            label_18:
            val_11 = this;
            this.chestImageBase.sprite = this.spriteChestBronzeBase;
            this.chestImageLower.sprite = this.spriteChestBronzeLower;
            val_12 = this.spriteChestBronzeUpper;
            goto label_28;
            label_19:
            val_11 = this;
            this.chestImageBase.sprite = this.spriteChestSilverBase;
            this.chestImageLower.sprite = this.spriteChestSilverLower;
            val_12 = this.spriteChestSilverUpper;
            label_28:
            this.chestImageUpper.sprite = val_12;
            goto typeof(UnityEngine.UI.Image).__il2cppRuntimeField_400;
            label_20:
            val_11 = this.chestImageBase;
            goto typeof(UnityEngine.UI.Image).__il2cppRuntimeField_400;
        }
        protected void OnChestClicked()
        {
            var val_17 = this;
            if(this.isInteractable != false)
            {
                    if((MonoSingleton<WordForest.WFOWordChestManager>.Instance.IsChestReady) != false)
            {
                    GameBehavior val_3 = App.getBehavior;
                if((val_3.<metaGameBehavior>k__BackingField) == 2)
            {
                    WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
                this.creditsBeforeChestOpen = new System.Decimal();
                this.BeginChestReadyFlow();
                return;
            }
            
            }
            
                GameBehavior val_5 = App.getBehavior;
                val_17 = ???;
            }
            else
            {
                    GameBehavior val_7 = App.getBehavior;
                if((val_7.<metaGameBehavior>k__BackingField) != 5)
            {
                    return;
            }
            
                WordForest.WFOGameEcon val_8 = WordForest.WFOGameEcon.Instance;
                string val_9 = System.String.Format(format:  "Reach Forest Level {0} to Unlock", arg0:  val_8.rewardWordChestUnlockLevel);
                val_17 = mem[val_17 + 72];
                val_17 = val_17 + 72;
                val_17.SetActive(value:  (~val_17.activeSelf) & 1);
            }
        
        }
        protected void BeginChestReadyFlow()
        {
            if((WordForest.WFOWordChestDisplay.<isChestReadyFlowActivated>k__BackingField) != false)
            {
                    return;
            }
            
            WordForest.WFOWordChestDisplay.<isChestReadyFlowActivated>k__BackingField = true;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.BeginChestReadyFlowCoroutine());
        }
        protected System.Collections.IEnumerator BeginChestReadyFlowCoroutine()
        {
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WFOWordChestDisplay.<BeginChestReadyFlowCoroutine>d__58(<>1__state:  0);
        }
        private System.Collections.IEnumerator BeginChestFtuxFlow()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WFOWordChestDisplay.<BeginChestFtuxFlow>d__59();
        }
        private System.Collections.IEnumerator DoNewChestAnimationSequence(bool isFtux = False)
        {
            .<>4__this = this;
            .isFtux = isFtux;
            return (System.Collections.IEnumerator)new WFOWordChestDisplay.<DoNewChestAnimationSequence>d__60(<>1__state:  0);
        }
        protected void OnOpenChestAnimationSequenceComplete()
        {
            this.ResetChestVisualState();
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DoNewChestAnimationSequence(isFtux:  false));
        }
        public WFOWordChestDisplay()
        {
        
        }
        private void <UpdateChestLabels>b__54_0()
        {
            this.isAnimationActive = false;
        }
        private bool <BeginChestReadyFlowCoroutine>b__58_1()
        {
            return (bool)(this.isAnimationActive == false) ? 1 : 0;
        }
    
    }

}
