using UnityEngine;

namespace WordForest
{
    public class WFOMysteryChestDisplay : MonoSingleton<WordForest.WFOMysteryChestDisplay>
    {
        // Fields
        protected UnityEngine.CanvasGroup parentCanvasGroup;
        protected UnityEngine.RectTransform chestRootTransform;
        protected UnityEngine.UI.Button button;
        protected UnityEngine.UI.Text labelTapToOpen;
        protected UnityEngine.UI.Image lockImage;
        protected UnityEngine.GameObject chestOverlay;
        protected UnityEngine.UI.Image pointerImage;
        protected UnityEngine.UI.Button buttonClose;
        protected UnityEngine.GameObject radialRayObject;
        protected UnityEngine.RectTransform questionChest;
        protected CoinCurrencyStatView coinStatViewAnimObj;
        protected WordForest.WFOShieldStatView shieldStatViewObj;
        protected WordForest.MysteryChestStatView mysteryChestStatView;
        protected WordForest.WFOGameAcornStatView acornStatViewObj;
        protected EventButtonPanel eventButtonPanelTab;
        protected UnityEngine.UI.Text acornMultiplierLabel;
        private UnityEngine.GameObject ftuxRoot;
        private FtuxTooltip ftuxTooltip;
        protected UnityEngine.UI.Image chestImageBase;
        protected UnityEngine.UI.Image chestImageUpper;
        protected UnityEngine.UI.Image chestImageUpperClose;
        protected UnityEngine.UI.Image chestImageLower;
        protected UnityEngine.CanvasGroup chestCanvasGroupClosed;
        protected UnityEngine.CanvasGroup chestCanvasGroupOpened;
        protected UnityEngine.UI.Image chestOpenRay;
        protected UnityEngine.GameObject prefabItem;
        protected WordForest.WFOAcornMultiplierTrailParticle prefabItemTrailEfx;
        protected WordForest.WFOAcornMultiplierTrailParticle prefabAcornMultiplierEfx;
        protected UnityEngine.Sprite spriteChestGoldBase;
        protected UnityEngine.Sprite spriteChestGoldUpper;
        protected UnityEngine.Sprite spriteChestGoldUpperClose;
        protected UnityEngine.Sprite spriteChestGoldLower;
        protected UnityEngine.Sprite spriteChestSilverBase;
        protected UnityEngine.Sprite spriteChestSilverUpper;
        protected UnityEngine.Sprite spriteChestSilverUpperClose;
        protected UnityEngine.Sprite spriteChestSilverLower;
        protected UnityEngine.Sprite spriteChestBronzeBase;
        protected UnityEngine.Sprite spriteChestBronzeUpper;
        protected UnityEngine.Sprite spriteChestBronzeUpperClose;
        protected UnityEngine.Sprite spriteChestBronzeLower;
        protected WordForest.WFOWordChestType currentChestType;
        protected System.Collections.Generic.List<WordForest.WFORewardData> rewardItems;
        protected System.Collections.Generic.List<WordForest.WFORewardData> rewardItemModified;
        protected System.Collections.Generic.List<WordForest.WFOWordChestType> chestTypeSet;
        protected System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>> rewardItemsSet;
        protected System.Collections.Generic.List<DG.Tweening.Sequence> itemDisplaySeqList;
        private int rewardItemIdThatTriggeredPause;
        protected UnityEngine.GameObject tableObj;
        protected System.Collections.Generic.List<UnityEngine.Transform> itemPlacementCoords;
        protected bool isInteractable;
        protected bool isAnimationActive;
        protected bool isAwaitingPlayerInputForItems;
        protected decimal creditsBeforeChestOpen;
        protected System.Nullable<UnityEngine.Vector3> originalDisplayScale;
        protected DG.Tweening.Tween pointerSequence;
        protected DG.Tweening.Tween tapToOpenTween;
        protected System.Action onOpenChestAnimationComplete;
        private int statViewCurrentValueAcorns;
        private decimal statViewCurrentValueCoins;
        private int statViewCurrentValueShields;
        private int statViewTotalChests;
        private int chestIndex;
        
        // Properties
        protected virtual bool IsFirstTimeOpeningChest { get; set; }
        
        // Methods
        protected virtual bool get_IsFirstTimeOpeningChest()
        {
            return false;
        }
        protected virtual void set_IsFirstTimeOpeningChest(bool value)
        {
        
        }
        public override void InitMonoSingleton()
        {
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WordForest.WFOMysteryChestDisplay).__il2cppRuntimeField_218));
            SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  typeof(WordForest.WFOMysteryChestDisplay).__il2cppRuntimeField_1D8));
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_7;
            }
            
            }
            
            val_2.OnSceneUnloaded = val_4;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  4.ToString());
            this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WordForest.WFOMysteryChestDisplay).__il2cppRuntimeField_208));
            return;
            label_7:
        }
        protected virtual void Start()
        {
            this.buttonClose.gameObject.SetActive(value:  false);
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
            this.buttonClose.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
            val_4.sound.PlayGameSpecificSound(id:  "ChestOpen", clipIndex:  0);
            this.InitTopUI();
            this.Invoke(methodName:  "BeginChestReadyFlow", time:  1f);
        }
        protected virtual void OnDestroy()
        {
            var val_8;
            SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  typeof(WordForest.WFOMysteryChestDisplay).__il2cppRuntimeField_1D8));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_6;
            }
            
            }
            
            val_1.OnSceneUnloaded = val_3;
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  4.ToString());
            this.StopAnimatedPointer();
            val_8 = null;
            val_8 = null;
            MonoSingleton<T>.searchedFailed = false;
            MonoSingleton<T>.searchedFailed.__il2cppRuntimeField_0 = 0;
            return;
            label_6:
        }
        protected virtual void OnSceneUnloaded(SceneType scene)
        {
            if(scene != 11)
            {
                    return;
            }
            
            this.ResumeAllOpenChestSequences();
        }
        protected virtual void OnRaidSent(Notification notif)
        {
            System.Collections.Generic.List<WordForest.WFORewardData> val_3;
            if(notif.data == null)
            {
                    return;
            }
            
            val_3 = "acornsEarned";
            if((notif.data & 1) == 0)
            {
                    return;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = this.rewardItemModified;
            this = this.rewardItemIdThatTriggeredPause;
            WordForest.WFORewardData val_1 = new WordForest.WFORewardData(rType:  5, rAmt:  75878400);
            val_3.set_Item(index:  this, value:  new WordForest.WFORewardData() {id = val_1.id, amount = new System.Decimal() {flags = val_1.rewardType, hi = val_1.rewardType, lo = val_1.rewardType}, transformToId = ???});
        }
        protected virtual void OnAttackSent(Notification notif)
        {
            System.Collections.Generic.List<WordForest.WFORewardData> val_3;
            if(notif.data == null)
            {
                    return;
            }
            
            val_3 = "acornsEarned";
            if((notif.data & 1) == 0)
            {
                    return;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = this.rewardItemModified;
            this = this.rewardItemIdThatTriggeredPause;
            WordForest.WFORewardData val_1 = new WordForest.WFORewardData(rType:  6, rAmt:  75878400);
            val_3.set_Item(index:  this, value:  new WordForest.WFORewardData() {id = val_1.id, amount = new System.Decimal() {flags = val_1.rewardType, hi = val_1.rewardType, lo = val_1.rewardType}, transformToId = ???});
        }
        protected virtual void OnCloseClicked()
        {
            MonoSingleton<ScreenOverlay>.Instance.ToggleDarkener(state:  false, animated:  false, duration:  0.4f);
            this.isAnimationActive = false;
            UnityEngine.Object.Destroy(obj:  this.gameObject);
            MonoSingleton<WordForest.RaidAttackManager>.Instance.GetRaidOpponentPool();
            MonoSingleton<WordForest.RaidAttackManager>.Instance.GetAttackOpponentPool();
            if(this.onOpenChestAnimationComplete != null)
            {
                    this.onOpenChestAnimationComplete.Invoke();
            }
            
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnMysteryChestCollected");
            WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  0);
        }
        public void SetInteractable(bool isInteractable, bool darkenLock = False)
        {
            this.isInteractable = isInteractable;
            bool val_5 = isInteractable;
            val_5 = val_5 ^ 1;
            this.lockImage.gameObject.SetActive(value:  val_5);
            this.chestOverlay.SetActive(value:  val_5);
            if(darkenLock == false)
            {
                    return;
            }
            
            this = this.lockImage;
            UnityEngine.Color val_4 = new UnityEngine.Color(r:  0.65f, g:  0.65f, b:  0.65f);
            this.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        }
        public void Setup(WordForest.WFOWordChestType rarityType = 0, System.Collections.Generic.List<WordForest.WFORewardData> itemData, int collectedChestCount = 1, int totalChestCount = 1, System.Action onComplete)
        {
            int val_24;
            int val_25;
            var val_26;
            val_24 = totalChestCount;
            val_25 = collectedChestCount;
            if((rarityType != 0) && (itemData != null))
            {
                    this.chestTypeSet.Add(item:  rarityType);
                this.rewardItemsSet.Add(item:  itemData);
            }
            else
            {
                    this.rewardItemsSet = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.OpenMysteryChest(chestCount:  val_25, chestTypeSet: out  this.chestTypeSet);
            }
            
            this.onOpenChestAnimationComplete = onComplete;
            if(val_25 >= 1)
            {
                    val_26 = 0;
                var val_27 = 0;
                do
            {
                var val_26 = 0;
                val_24 = 0;
                do
            {
                if(1152921515420673872 <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(W9 <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_26 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = (((public System.Void Dictionary.Enumerator<System.String, GameLevel>::Dispose().__il2cppRuntimeField_18 + 0) + 32 + 16 + 0) + 32 + 16 + 36) + 4, hi = (((public System.Void Dictionary.Enumerator<System.String, GameLevel>::Dispose().__il2cppRuntimeField_18 + 0) + 32 + 16 + 0) + 32 + 16 + 36) + 4, lo = (((public System.Void Dictionary.Enumerator<System.String, GameLevel>::Dispose().__il2cppRuntimeField_18 + 0) + 32 + 16 + 0) + 32 + 16 + 36) + 12, mid = (((public System.Void Dictionary.Enumerator<System.String, GameLevel>::Dispose().__il2cppRuntimeField_18 + 0) + 32 + 16 + 0) + 32 + 16 + 36) + 12})) + val_26;
                val_26 = val_26 + 1;
                var val_9 = 36 + 28;
            }
            while(this.rewardItemsSet != null);
            
                val_25 = val_25;
                val_27 = val_27 + 1;
            }
            while(val_27 < val_25);
            
            }
            else
            {
                    val_26 = 0;
            }
            
            this.statViewCurrentValueAcorns = WordForest.WFOPlayer.Instance.starsLevelBalance - val_26;
            WordForest.WFOPlayer val_13 = WordForest.WFOPlayer.Instance;
            decimal val_14 = System.Decimal.op_Implicit(value:  0);
            decimal val_15 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = itemData, hi = itemData, lo = val_24, mid = val_24}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid});
            mem2[0] = val_15.flags;
            mem[4] = val_15.hi;
            mem[1152921518154825260] = val_15.lo;
            mem[1152921518154825264] = val_15.mid;
            WordForest.WFOPlayer val_16 = WordForest.WFOPlayer.Instance;
            int val_28 = val_16.shields;
            this.statViewTotalChests = val_24;
            val_28 = val_28 - 0;
            this.statViewCurrentValueShields = val_28;
            this.SetInteractable(isInteractable:  true, darkenLock:  false);
            if(val_28 == 0)
            {
                    UnityEngine.Vector3 val_17 = this.chestRootTransform.localScale;
                System.Nullable<UnityEngine.Vector3> val_18 = new System.Nullable<UnityEngine.Vector3>(value:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z});
                mem2[0] = val_18.HasValue;
            }
            
            this.labelTapToOpen.gameObject.SetActive(value:  false);
            this.TakeNextChestData();
            this.ResetChestVisualState();
            this.button.gameObject.SetActive(value:  false);
            this.questionChest.gameObject.SetActive(value:  false);
            MonoSingleton<WordForest.RaidAttackManager>.Instance.GetRaidOpponentPool();
            MonoSingleton<WordForest.RaidAttackManager>.Instance.GetAttackOpponentPool();
        }
        private bool IsNextChestAvailable()
        {
            return (bool)(this.chestTypeSet > 0) ? 1 : 0;
        }
        private void TakeNextChestData()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>> val_2;
            if(true < 1)
            {
                    return;
            }
            
            this.currentChestType = 0;
            this.chestTypeSet.RemoveAt(index:  0);
            val_2 = this.rewardItemsSet;
            if((public System.Void System.Collections.Generic.List<WordForest.WFOWordChestType>::RemoveAt(int index)) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_2 = this.rewardItemsSet;
            }
            
            this.rewardItems = "RemoteActivationService.rem";
            if("RemoteActivationService.rem" == null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.rewardItemModified = new System.Collections.Generic.List<WordForest.WFORewardData>(collection:  "RemoteActivationService.rem".__il2cppRuntimeField_20);
            this.rewardItemsSet.RemoveAt(index:  0);
        }
        private void ResetChestVisualState()
        {
            UnityEngine.UI.Image val_7;
            UnityEngine.Sprite val_8;
            if(this.tableObj != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.tableObj);
                this.tableObj = 0;
            }
            
            UnityEngine.Vector3 val_2 = this.originalDisplayScale.Value;
            this.chestRootTransform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
            this.chestCanvasGroupClosed.alpha = 1f;
            this.chestCanvasGroupClosed.gameObject.SetActive(value:  true);
            this.chestCanvasGroupOpened.gameObject.SetActive(value:  false);
            this.chestCanvasGroupOpened.alpha = 0f;
            this.chestOpenRay.fillAmount = 0f;
            UnityEngine.Color val_5 = this.labelTapToOpen.color;
            this.labelTapToOpen.color = new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = 1f};
            this.labelTapToOpen.gameObject.SetActive(value:  false);
            if(this.currentChestType == 1)
            {
                goto label_18;
            }
            
            if(this.currentChestType == 2)
            {
                goto label_19;
            }
            
            if(this.currentChestType != 3)
            {
                goto label_20;
            }
            
            val_7 = this;
            this.chestImageBase.sprite = this.spriteChestGoldBase;
            this.chestImageLower.sprite = this.spriteChestGoldLower;
            this.chestImageUpper.sprite = this.spriteChestGoldUpper;
            val_8 = this.spriteChestGoldUpperClose;
            goto label_30;
            label_18:
            val_7 = this;
            this.chestImageBase.sprite = this.spriteChestBronzeBase;
            this.chestImageLower.sprite = this.spriteChestBronzeLower;
            this.chestImageUpper.sprite = this.spriteChestBronzeUpper;
            val_8 = this.spriteChestBronzeUpperClose;
            goto label_30;
            label_19:
            val_7 = this;
            this.chestImageBase.sprite = this.spriteChestSilverBase;
            this.chestImageLower.sprite = this.spriteChestSilverLower;
            this.chestImageUpper.sprite = this.spriteChestSilverUpper;
            val_8 = this.spriteChestSilverUpperClose;
            label_30:
            this.chestImageUpperClose.sprite = val_8;
            goto typeof(UnityEngine.UI.Image).__il2cppRuntimeField_400;
            label_20:
            val_7 = this.chestImageBase;
            goto typeof(UnityEngine.UI.Image).__il2cppRuntimeField_400;
        }
        protected virtual void OnChestClicked()
        {
            if(this.isInteractable == false)
            {
                    return;
            }
            
            if(this.isAnimationActive != false)
            {
                    if(this.isAwaitingPlayerInputForItems != false)
            {
                    this.isAwaitingPlayerInputForItems = false;
            }
            
                this.StopAnimatedPointer();
                return;
            }
            
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            mem2[0] = ???;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this);
        }
        protected virtual void BeginChestReadyFlow()
        {
            UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
        }
        protected virtual System.Collections.IEnumerator BeginChestReadyFlowCoroutine()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WFOMysteryChestDisplay.<BeginChestReadyFlowCoroutine>d__79();
        }
        protected virtual void DoRevealChestAnimation()
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.labelTapToOpen, endValue:  0f, duration:  0.1f));
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOMysteryChestDisplay::<DoRevealChestAnimation>b__80_0()));
            if(this.chestCanvasGroupOpened.alpha >= 0)
            {
                    if(this.chestCanvasGroupOpened.gameObject.activeInHierarchy == true)
            {
                goto label_7;
            }
            
            }
            
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOMysteryChestDisplay::<DoRevealChestAnimation>b__80_1()));
            label_7:
            UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  1.22f, y:  0.83f, z:  1f);
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  0.08f));
            UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  0.9f, y:  1.22f, z:  1f);
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, duration:  0.15f));
            UnityEngine.Vector3 val_23 = new UnityEngine.Vector3(x:  1f, y:  1f, z:  1f);
            DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z}, duration:  0.08f));
        }
        protected void InitTopUI()
        {
            this.questionChest.SetSiblingIndex(index:  this.questionChest.parent.childCount - 1);
            mem2[0] = 0;
            mem2[0] = 0;
            decimal val_4 = System.Decimal.op_Implicit(value:  this.statViewCurrentValueAcorns);
            this.acornStatViewObj.SetBalanceNow(newBalance:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
            string val_9 = System.String.Format(format:  "x{0}", arg0:  (MonoSingleton<WordForest.WFOManagerGameplay>.Instance.TotalAdditionalMultipliers) + WordStreak.CurrentStreak);
            this.coinStatViewAnimObj.SetBalanceNow(newBalance:  new System.Decimal() {flags = this.statViewCurrentValueCoins.flags, hi = this.statViewCurrentValueCoins.flags, lo = 397070336, mid = 268435456});
            this.mysteryChestStatView.autoUpdate = false;
            this.mysteryChestStatView.SetBalanceNow(collected:  this.rewardItemsSet + 1, total:  this.statViewTotalChests);
            this.shieldStatViewObj.artificalTargetBalance = this.statViewCurrentValueShields;
            this.shieldStatViewObj.UpdateUI(instantly:  true);
        }
        protected void ToggleTapToOpenLabel(bool isVisible)
        {
            if(this.tapToOpenTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.tapToOpenTween, complete:  false);
            }
            
            if(isVisible != false)
            {
                    this.tapToOpenTween = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.labelTapToOpen, endValue:  1f, duration:  0.1f);
                this.DoAnimatedPointer(pointAt:  this.button.gameObject, delayedShow:  false);
                return;
            }
            
            this.tapToOpenTween = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.labelTapToOpen, endValue:  0f, duration:  0.1f);
            this.StopAnimatedPointer();
        }
        protected void DoChestSquashStretchBounce()
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  1.22f, y:  0.83f, z:  1f);
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, duration:  0.08f));
            UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  0.9f, y:  1.22f, z:  1f);
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.15f));
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  1f, y:  1f, z:  1f);
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestCanvasGroupOpened.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, duration:  0.08f));
        }
        private void PauseAllOpenChestSequences(int triggerItemIndex)
        {
            bool val_3 = true;
            this.rewardItemIdThatTriggeredPause = triggerItemIndex;
            this.button.interactable = false;
            this.buttonClose.interactable = false;
            var val_4 = 4;
            do
            {
                var val_1 = val_4 - 4;
                if(val_1 >= val_3)
            {
                    return;
            }
            
                val_3 = val_3 & 4294967295;
                if(val_1 >= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(((true & 4294967295) + 32) != 0)
            {
                    if(val_1 >= ((true & 4294967295) + 32))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                DG.Tweening.Sequence val_2 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  (true & 4294967295) + 32 + 32);
            }
            
                val_4 = val_4 + 1;
            }
            while(this.itemDisplaySeqList != null);
            
            throw new NullReferenceException();
        }
        private void ResumeAllOpenChestSequences()
        {
            bool val_3 = true;
            this.buttonClose.interactable = true;
            this.button.interactable = true;
            var val_4 = 4;
            do
            {
                var val_1 = val_4 - 4;
                if(val_1 >= val_3)
            {
                    return;
            }
            
                val_3 = val_3 & 4294967295;
                if(val_1 >= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(((true & 4294967295) + 32) != 0)
            {
                    if(val_1 >= ((true & 4294967295) + 32))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                DG.Tweening.Sequence val_2 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  (true & 4294967295) + 32 + 32);
            }
            
                val_4 = val_4 + 1;
            }
            while(this.itemDisplaySeqList != null);
            
            throw new NullReferenceException();
        }
        protected virtual System.Collections.IEnumerator DoOpenChestAnimationSequence()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WFOMysteryChestDisplay.<DoOpenChestAnimationSequence>d__86();
        }
        private void ExecutePerChestCallbacks()
        {
            var val_7;
            System.Predicate<WordForest.WFORewardData> val_9;
            var val_10;
            System.Predicate<WordForest.WFORewardData> val_12;
            val_7 = null;
            val_7 = null;
            val_9 = WFOMysteryChestDisplay.<>c.<>9__87_0;
            if(val_9 == null)
            {
                    System.Predicate<WordForest.WFORewardData> val_1 = null;
                val_9 = val_1;
                val_1 = new System.Predicate<WordForest.WFORewardData>(object:  WFOMysteryChestDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestDisplay.<>c::<ExecutePerChestCallbacks>b__87_0(WordForest.WFORewardData n));
                WFOMysteryChestDisplay.<>c.<>9__87_0 = val_9;
            }
            
            if((this.rewardItems.FindIndex(match:  val_1)) != 1)
            {
                    val_9 = 1152921504999550976;
                MonoSingleton<GoalsManager>.Instance.NotifyAttackCompleted(isAttackSuccessful:  WordForest.RaidAttackManager.lastAttackResult);
            }
            
            val_10 = null;
            val_10 = null;
            val_12 = WFOMysteryChestDisplay.<>c.<>9__87_1;
            if(val_12 == null)
            {
                    System.Predicate<WordForest.WFORewardData> val_4 = null;
                val_12 = val_4;
                val_4 = new System.Predicate<WordForest.WFORewardData>(object:  WFOMysteryChestDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestDisplay.<>c::<ExecutePerChestCallbacks>b__87_1(WordForest.WFORewardData n));
                WFOMysteryChestDisplay.<>c.<>9__87_1 = val_12;
            }
            
            if((this.rewardItems.FindIndex(match:  val_4)) == 1)
            {
                    return;
            }
            
            MonoSingleton<GoalsManager>.Instance.NotifyRaidCompleted(isRaidPerfect:  WordForest.RaidAttackManager.lastRaidPerfect);
        }
        private DG.Tweening.Sequence CreateMiniSeqSegmentShowItemIntro(int itemIndex)
        {
            .<>4__this = this;
            .itemIndex = itemIndex;
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            .seqSegment = val_2;
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  new WFOMysteryChestDisplay.<>c__DisplayClass88_0(), method:  System.Void WFOMysteryChestDisplay.<>c__DisplayClass88_0::<CreateMiniSeqSegmentShowItemIntro>b__0()));
            return (DG.Tweening.Sequence)(WFOMysteryChestDisplay.<>c__DisplayClass88_0)[1152921518157763648].seqSegment;
        }
        private DG.Tweening.Sequence CreateMiniSeqSegmentShowItemOuttro(int itemIndex)
        {
            .<>4__this = this;
            .itemArrIndex = itemIndex;
            .itemIndex = itemIndex;
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  new WFOMysteryChestDisplay.<>c__DisplayClass89_0(), method:  System.Void WFOMysteryChestDisplay.<>c__DisplayClass89_0::<CreateMiniSeqSegmentShowItemOuttro>b__0()));
            return val_2;
        }
        private WordForest.WFOWordChestItemIcon InstantiateObjectItem(WordForest.WFORewardData rewardData, int itemIndex, bool forOutro = False)
        {
            UnityEngine.Transform val_17;
            bool val_17 = true;
            if(val_17 <= itemIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_17 = val_17 + (itemIndex << 3);
            UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.prefabItem, parent:  (true + (itemIndex) << 3) + 32);
            val_17 = val_1;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
            val_1.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            WordForest.WFOWordChestItemIcon val_4 = val_17.GetComponent<WordForest.WFOWordChestItemIcon>();
            val_4.Initialize(rewardData:  new WordForest.WFORewardData() {id = rewardData.id, amount = new System.Decimal() {hi = 268435459}, transformToId = rewardData.id});
            if(forOutro == true)
            {
                    return val_4;
            }
            
            UnityEngine.Vector3 val_7 = this.button.transform.position;
            UnityEngine.Vector3 val_9 = this.button.transform.position;
            UnityEngine.Vector3 val_11 = val_17.transform.position;
            UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  val_7.x, y:  val_9.y, z:  val_11.z);
            val_17.transform.position = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            val_17 = val_17.transform;
            UnityEngine.Vector3 val_14 = UnityEngine.Vector3.zero;
            DG.Tweening.Tweener val_16 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  val_17, endValue:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, duration:  0.3f, snapping:  false), ease:  27);
            return val_4;
        }
        protected void DoAnimatedPointer(UnityEngine.GameObject pointAt, bool delayedShow)
        {
            bool val_25 = delayedShow;
            .<>4__this = this;
            this.StopAnimatedPointer();
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  100f, y:  -125f, z:  0f);
            UnityEngine.Vector3 val_4 = pointAt.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            this.pointerImage.transform.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            this.pointerSequence = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_7 = DG.Tweening.DOTween.Sequence();
            .nestedLoopSeq = val_7;
            UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  40f, y:  -40f, z:  0f);
            UnityEngine.Vector3 val_11 = this.pointerImage.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.pointerImage.transform, endValue:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, duration:  0.35f, snapping:  false), ease:  7));
            DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Append(s:  (WFOMysteryChestDisplay.<>c__DisplayClass91_0)[1152921518158413984].nestedLoopSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.pointerImage.transform, endValue:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, duration:  0.35f, snapping:  false), ease:  7));
            DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  (WFOMysteryChestDisplay.<>c__DisplayClass91_0)[1152921518158413984].nestedLoopSeq, loops:  0, loopType:  0);
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  (WFOMysteryChestDisplay.<>c__DisplayClass91_0)[1152921518158413984].nestedLoopSeq);
            if(val_25 != false)
            {
                    DG.Tweening.TweenCallback val_21 = null;
                val_25 = val_21;
                val_21 = new DG.Tweening.TweenCallback(object:  new WFOMysteryChestDisplay.<>c__DisplayClass91_0(), method:  System.Void WFOMysteryChestDisplay.<>c__DisplayClass91_0::<DoAnimatedPointer>b__0());
                this.pointerSequence = DG.Tweening.DOVirtual.DelayedCall(delay:  2f, callback:  val_21, ignoreTimeScale:  true);
                return;
            }
            
            this.pointerImage.gameObject.SetActive(value:  true);
            this.pointerSequence = (WFOMysteryChestDisplay.<>c__DisplayClass91_0)[1152921518158413984].nestedLoopSeq;
            DG.Tweening.Tween val_24 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Tween>(t:  (WFOMysteryChestDisplay.<>c__DisplayClass91_0)[1152921518158413984].nestedLoopSeq);
        }
        protected void StopAnimatedPointer()
        {
            if(this.pointerSequence != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.pointerSequence, complete:  false);
            }
            
            this.pointerImage.gameObject.SetActive(value:  false);
        }
        private void InitItemCardPlacementCoords(int itemsToShow)
        {
            float val_27;
            var val_28;
            var val_29;
            var val_30;
            var val_31;
            UnityEngine.Transform val_32;
            int val_29 = itemsToShow;
            if(this.tableObj != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.tableObj);
            }
            
            this.itemPlacementCoords = new System.Collections.Generic.List<UnityEngine.Transform>();
            UnityEngine.Rect val_4 = WordRegion.instance.getSafeAreaRect;
            UnityEngine.Vector3 val_7 = WordRegion.instance.transform.position;
            val_27 = val_7.x;
            UnityEngine.Vector3 val_9 = this.transform.position;
            UnityEngine.GameObject val_11 = this.CreateTableRoot(parent:  this.transform);
            this.tableObj = val_11;
            UnityEngine.Transform val_12 = val_11.transform;
            if(null != null)
            {
                goto label_14;
            }
            
            val_12.position = new UnityEngine.Vector3() {x = val_27, y = val_7.y, z = val_9.z};
            val_12.SetSizeWithCurrentAnchors(axis:  0, size:  val_4.m_XMin.width);
            val_12.SetSizeWithCurrentAnchors(axis:  1, size:  val_4.m_XMin.height);
            if(val_29 == 7)
            {
                goto label_15;
            }
            
            if(val_29 == 5)
            {
                goto label_16;
            }
            
            if(val_29 != 3)
            {
                goto label_17;
            }
            
            System.Collections.Generic.List<System.Int32> val_15 = null;
            val_28 = val_15;
            val_15 = new System.Collections.Generic.List<System.Int32>();
            val_29 = 3;
            val_30 = public System.Void System.Collections.Generic.List<System.Int32>::Add(System.Int32 item);
            goto label_19;
            label_16:
            System.Collections.Generic.List<System.Int32> val_16 = null;
            val_28 = val_16;
            val_16 = new System.Collections.Generic.List<System.Int32>();
            val_31 = 1152921510479955696;
            goto label_21;
            label_15:
            System.Collections.Generic.List<System.Int32> val_17 = null;
            val_28 = val_17;
            val_17 = new System.Collections.Generic.List<System.Int32>();
            val_31 = 1152921510479955696;
            val_17.Add(item:  2);
            label_21:
            val_17.Add(item:  3);
            val_30 = public System.Void System.Collections.Generic.List<System.Int32>::Add(System.Int32 item);
            val_29 = 2;
            label_19:
            val_17.Add(item:  2);
            label_41:
            if(1152921510062986752 < 1)
            {
                    return;
            }
            
            val_27 = 270f;
            var val_28 = 0;
            do
            {
                if(val_28 >= 30134272)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(740701304 >= 1)
            {
                    var val_27 = 0;
                do
            {
                UnityEngine.Transform val_20 = this.CreateTableRow(parent:  this.tableObj.transform).transform;
                UnityEngine.Transform val_22 = val_20.CreateEmptyGameObject(gName:  0, gParent:  val_20).transform;
                if(val_22 != null)
            {
                    var val_23 = (null == null) ? (val_22) : 0;
            }
            else
            {
                    val_32 = 0;
            }
            
                UnityEngine.Vector2 val_24 = new UnityEngine.Vector2(x:  val_27, y:  0f);
                val_32.sizeDelta = new UnityEngine.Vector2() {x = val_24.x, y = val_24.y};
                this.itemPlacementCoords.Add(item:  val_32);
                val_27 = val_27 + 1;
            }
            while(val_27 < 740701304);
            
            }
            
                val_28 = val_28 + 1;
            }
            while(val_28 < 30134272);
            
            return;
            label_17:
            if(val_29 < 1)
            {
                goto label_41;
            }
            
            do
            {
                int val_26 = UnityEngine.Mathf.Min(a:  val_29, b:  3);
                val_29 = val_29 - val_26;
                new System.Collections.Generic.List<System.Int32>().Add(item:  val_26);
            }
            while(val_29 > 0);
            
            goto label_41;
            label_14:
        }
        private UnityEngine.GameObject CreateTableRoot(UnityEngine.Transform parent)
        {
            UnityEngine.GameObject val_1 = this.CreateEmptyGameObject(gName:  "ItemTable", gParent:  parent);
            DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (null == null) ? val_1.transform : 0, endValue:  350f, duration:  0.01f, snapping:  false);
            UnityEngine.UI.VerticalLayoutGroup val_5 = val_1.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            val_5.childAlignment = 4;
            val_5.childControlHeight = true;
            val_5.childControlWidth = true;
            val_5.childForceExpandWidth = true;
            return val_1;
        }
        private UnityEngine.GameObject CreateTableRow(UnityEngine.Transform parent)
        {
            UnityEngine.GameObject val_1 = this.CreateEmptyGameObject(gName:  "Row", gParent:  parent);
            UnityEngine.UI.HorizontalLayoutGroup val_2 = val_1.AddComponent<UnityEngine.UI.HorizontalLayoutGroup>();
            val_2.childAlignment = 4;
            val_2.childControlWidth = false;
            val_2.childForceExpandWidth = false;
            return val_1;
        }
        private UnityEngine.GameObject CreateEmptyGameObject(string gName, UnityEngine.Transform gParent)
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  gName);
            if(gParent != 0)
            {
                    val_1.transform.SetParent(p:  gParent);
            }
            
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
            val_1.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
            val_1.transform.localPosition = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            UnityEngine.RectTransform val_8 = val_1.AddComponent<UnityEngine.RectTransform>();
            return val_1;
        }
        private void ShowFtux(WordForest.FtuxId ftuxId)
        {
            .ftuxId = ftuxId;
            .<>4__this = this;
            .player = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_2.tutorialCompleted, bit:  (WFOMysteryChestDisplay.<>c__DisplayClass97_0)[1152921518159564368].ftuxId)) != false)
            {
                    return;
            }
            
            this.ftuxRoot.SetActive(value:  (((WFOMysteryChestDisplay.<>c__DisplayClass97_0)[1152921518159564368].ftuxId) != 11) ? 1 : 0);
            DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.02f, callback:  new DG.Tweening.TweenCallback(object:  new WFOMysteryChestDisplay.<>c__DisplayClass97_0(), method:  System.Void WFOMysteryChestDisplay.<>c__DisplayClass97_0::<ShowFtux>b__0()), ignoreTimeScale:  true);
        }
        private void OnFtuxButtonClicked()
        {
            this.ftuxRoot.SetActive(value:  false);
            this.ResumeAllOpenChestSequences();
        }
        public WFOMysteryChestDisplay()
        {
            this.chestTypeSet = new System.Collections.Generic.List<WordForest.WFOWordChestType>();
            this.rewardItemsSet = new System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>();
            this.itemDisplaySeqList = new System.Collections.Generic.List<DG.Tweening.Sequence>();
            this.rewardItemIdThatTriggeredPause = 0;
        }
        private bool <BeginChestReadyFlowCoroutine>b__79_0()
        {
            return (bool)(this.isAnimationActive == false) ? 1 : 0;
        }
        private void <BeginChestReadyFlowCoroutine>b__79_1()
        {
            if(this.button != null)
            {
                    this.button.interactable = true;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <DoRevealChestAnimation>b__80_0()
        {
            this.StopAnimatedPointer();
        }
        private void <DoRevealChestAnimation>b__80_1()
        {
            this.chestCanvasGroupClosed.alpha = 0f;
            this.chestCanvasGroupOpened.gameObject.SetActive(value:  true);
            this.chestCanvasGroupOpened.alpha = 1f;
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFillAmount(target:  this.chestOpenRay, endValue:  1f, duration:  0.1f);
        }
    
    }

}
