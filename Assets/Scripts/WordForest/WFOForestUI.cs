using UnityEngine;

namespace WordForest
{
    public class WFOForestUI : MonoSingleton<WordForest.WFOForestUI>
    {
        // Fields
        private UnityEngine.CanvasGroup titleGroup;
        private UnityEngine.CanvasGroup eventButtonsGroup;
        private UnityEngine.CanvasGroup growGroup;
        private UnityEngine.CanvasGroup congratulationsGroup;
        private UnityEngine.CanvasGroup continueGroup;
        private UnityEngine.UI.Image darkOverlay;
        private UnityEngine.UI.Image bottomBackground;
        private UnityEngine.ParticleSystem congratParticleLeft;
        private UnityEngine.ParticleSystem congratParticleRight;
        private UnityEngine.Transform forestContentParent;
        private UnityEngine.UI.Text forestNameText;
        private UnityEngine.UI.Text growthProgressText;
        private UnityEngine.UI.Slider growthProgress;
        private UnityEngine.UI.Text growthCostText;
        private UnityEngine.UI.Text currentLevelText;
        private UnityEngine.UI.Button homeButton;
        private UnityEngine.UI.Button forestInfoButton;
        private UGUINetworkedButtonMultiGraphic growButton;
        private UnityEngine.UI.Text growButtonText;
        private UnityEngine.UI.Button playButton;
        private UnityEngine.UI.Button forestNameButton;
        private UnityEngine.UI.Button continueButton;
        private UnityEngine.UI.Button forestChestButton;
        private WordForest.WFOForestContent forestContent;
        private UnityEngine.GameObject FTUXTooltip_1;
        private UnityEngine.GameObject FTUXTooltip_3;
        private UnityEngine.GameObject FTUXPointer;
        private UnityEngine.UI.Image growButtonGlow;
        private UnityEngine.UI.Button tooltipContinueButton;
        private UnityEngine.Transform forestChestPointerScaler;
        private UnityEngine.UI.Image continueButtonGlow;
        private UnityEngine.Transform continueButtonPointerScaler;
        private WordForest.WFOSeedParticles seedParticlesPrefab;
        private UGUINetworkedButtonMultiGraphic prefabButtonFixTree;
        private DG.Tweening.Sequence forestChestPointerSequence;
        private WordForest.WFOForestManager forestManager;
        private UGUINetworkedButtonMultiGraphic buttonFixTree;
        private int currentHighlightedFixTreeId;
        
        // Methods
        private void OnPlayerDataUpdated()
        {
            this.InitialiseForestLayout();
            this.InitializeUI();
            this.UpdateForestInfo(animated:  false, skipButtonStates:  false);
        }
        private void Start()
        {
            var val_16;
            int val_36;
            this.forestManager = MonoSingleton<WordForest.WFOForestManager>.Instance;
            if(this.forestInfoButton != 0)
            {
                    this.forestInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnForestInfoButtonClicked()));
            }
            
            this.forestInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnGrowButtonClicked()));
            this.forestNameButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnForestNameClicked()));
            this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnContinueButtonClicked()));
            this.forestChestButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnChestButtonClicked()));
            this.tooltipContinueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnTooltipContinueButtonClicked()));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  0.ToString());
            string val_13 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player.ToString());
            this.InitialiseForestLayout();
            this.InitializeUI();
            this.UpdateForestInfo(animated:  false, skipButtonStates:  false);
            val_36 = this.CurrentForestGrowth;
            WordForest.WFOForestData val_15 = this.forestManager.CurrentForestData;
            if(val_36 >= val_16)
            {
                    if(this.forestManager.IsAtLastForest != true)
            {
                    this.OnContinueButtonClicked();
            }
            
            }
            
            if(this.forestManager.IsForestChestCollected != true)
            {
                    this.CueForestChestPointerAnim(delay:  3f);
            }
            
            WordForest.WFOPlayer val_19 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_19.tutorialCompleted, bit:  2)) != false)
            {
                    if((MonoExtensions.IsBitSet(value:  val_19.tutorialCompleted, bit:  3)) == true)
            {
                goto label_37;
            }
            
            }
            
            if(val_19.currentForestID <= 1)
            {
                    if((val_19.forestMapData.CurrentForestGrowth(includeDamagedTrees:  true)) < 1)
            {
                goto label_37;
            }
            
            }
            
            int val_23 = MonoExtensions.SetBit(value:  val_19.tutorialCompleted, bit:  5);
            val_19.tutorialCompleted = val_23;
            int val_24 = MonoExtensions.SetBit(value:  val_23, bit:  2);
            val_19.tutorialCompleted = val_24;
            val_19.tutorialCompleted = MonoExtensions.SetBit(value:  val_24, bit:  3);
            label_37:
            WordForest.WFOPlayer val_26 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_26.tutorialCompleted, bit:  2)) == false)
            {
                goto label_39;
            }
            
            WordForest.WFOPlayer val_28 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_28.tutorialCompleted, bit:  3)) == false)
            {
                goto label_41;
            }
            
            WordForest.WFOPlayer val_30 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_30.tutorialCompleted, bit:  4)) == true)
            {
                goto label_50;
            }
            
            val_36 = val_32._stars;
            if(val_36 < (this.forestManager.GetGrowOrFixCost(growthLevel:  App.Player.CurrentForestGrowth)))
            {
                goto label_50;
            }
            
            this.StartFTUX_3();
            goto label_50;
            label_39:
            this.StartFTUX_1();
            goto label_50;
            label_41:
            this.StartFTUX_2();
            label_50:
            DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestUI::OnAndroidBackButtonClicked()));
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  0.ToString());
        }
        private void OnDisable()
        {
            DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestUI::OnAndroidBackButtonClicked()));
        }
        private DG.Tweening.Sequence DoCompleteForestSequence()
        {
            var val_52;
            var val_53;
            DG.Tweening.TweenCallback val_55;
            float val_56;
            DG.Tweening.TweenCallback val_57;
            val_52 = 1152921504797421568;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.titleGroup, endValue:  0f, duration:  0.5f));
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.eventButtonsGroup, endValue:  0f, duration:  0.5f));
            val_53 = null;
            val_53 = null;
            val_55 = WFOForestUI.<>c.<>9__42_0;
            if(val_55 == null)
            {
                    DG.Tweening.TweenCallback val_6 = null;
                val_55 = val_6;
                val_6 = new DG.Tweening.TweenCallback(object:  WFOForestUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOForestUI.<>c::<DoCompleteForestSequence>b__42_0());
                WFOForestUI.<>c.<>9__42_0 = val_55;
            }
            
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_6);
            val_56 = 1f;
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.darkOverlay, endValue:  val_56, duration:  0.5f));
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.congratulationsGroup, endValue:  val_56, duration:  0.5f));
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<DoCompleteForestSequence>b__42_1()));
            DG.Tweening.TweenCallback val_14 = null;
            val_57 = val_14;
            val_14 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<DoCompleteForestSequence>b__42_2());
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_14);
            if(this.forestManager.IsAtLastForest != false)
            {
                    GameBehavior val_17 = App.getBehavior;
                return val_1;
            }
            
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.continueGroup, endValue:  1f, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<DoCompleteForestSequence>b__42_3())));
            DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  3f);
            DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  2f);
            DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.darkOverlay, endValue:  0f, duration:  0.5f));
            DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<DoCompleteForestSequence>b__42_4()));
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<DoCompleteForestSequence>b__42_5()));
            val_57 = DG.Tweening.DOTween.Sequence();
            val_52 = 1152921509727915456;
            DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_57, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.continueButtonGlow, endValue:  0.8f, duration:  0.65f), ease:  7));
            DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_57, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.continueButtonGlow, endValue:  0.4f, duration:  0.65f), ease:  7));
            DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_57, loops:  231, loopType:  0);
            DG.Tweening.Sequence val_39 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_43 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_39, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.continueButtonPointerScaler.transform, endValue:  0.8f, duration:  0.5f), ease:  5));
            val_56 = 1f;
            DG.Tweening.Sequence val_47 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_39, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.continueButtonPointerScaler.transform, endValue:  val_56, duration:  0.5f), ease:  5));
            DG.Tweening.Sequence val_48 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_39, interval:  val_56);
            DG.Tweening.Sequence val_49 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_39, loops:  231, loopType:  0);
            DG.Tweening.Sequence val_50 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  val_57);
            DG.Tweening.Sequence val_51 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  val_39);
            return val_1;
        }
        private void StartFTUX_1()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  5)) != true)
            {
                    WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
                int val_5 = MonoExtensions.SetBit(value:  val_4.tutorialCompleted, bit:  5);
                val_3.tutorialCompleted = val_5;
                val_5.TrackAmplitudeInitialForestEntry();
            }
            
            this.FTUXTooltip_1.SetActive(value:  true);
            this.FTUXPointer.SetActive(value:  true);
            this.growButtonGlow.gameObject.SetActive(value:  true);
            this.homeButton.interactable = false;
            if(this.forestInfoButton != 0)
            {
                    this.forestInfoButton.interactable = false;
            }
            
            this.forestNameButton.interactable = false;
            this.playButton.interactable = false;
            this.StartGrowButtonPointerAnim();
        }
        private void EndFTUX_1()
        {
            this.FTUXTooltip_1.SetActive(value:  false);
            this.FTUXPointer.SetActive(value:  false);
            this.growButtonGlow.gameObject.SetActive(value:  false);
            this.growButton.interactable = false;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            val_2.tutorialCompleted = MonoExtensions.SetBit(value:  val_3.tutorialCompleted, bit:  2);
            DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  2.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::StartFTUX_2()), ignoreTimeScale:  true);
        }
        private void StartFTUX_2()
        {
            this.growButton.interactable = true;
            this.growButtonGlow.gameObject.SetActive(value:  true);
            this.FTUXPointer.SetActive(value:  true);
            this.homeButton.interactable = false;
            if(this.forestInfoButton != 0)
            {
                    this.forestInfoButton.interactable = false;
            }
            
            this.forestNameButton.interactable = false;
            this.playButton.interactable = false;
            this.StartGrowButtonPointerAnim();
        }
        private void EndFTUX_2()
        {
            this.FTUXPointer.SetActive(value:  false);
            this.growButton.interactable = false;
            this.growButtonGlow.gameObject.SetActive(value:  false);
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            val_2.tutorialCompleted = MonoExtensions.SetBit(value:  val_3.tutorialCompleted, bit:  3);
            DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  2.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<EndFTUX_2>b__46_0()), ignoreTimeScale:  true);
        }
        private void StartFTUX_3()
        {
            this.FTUXTooltip_3.SetActive(value:  true);
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_2.tutorialCompleted, bit:  4);
        }
        private void InitializeUI()
        {
            var val_3;
            float val_13;
            var val_14;
            var val_15;
            float val_16;
            float val_17;
            int val_1 = this.CurrentForestGrowth;
            WordForest.WFOForestData val_2 = this.forestManager.CurrentForestData;
            bool val_4 = this.forestManager.IsForestChestCollected;
            if(val_1 >= val_3)
            {
                    bool val_5 = this.forestManager.IsAtLastForest;
                val_13 = 1f;
                val_14 = 0f;
                val_15 = val_5 ^ 1;
                var val_6 = (val_5 != true) ? (val_14) : (val_13);
                val_17 = 0f;
            }
            else
            {
                    val_13 = 0f;
                val_17 = 1f;
                val_15 = 0;
                float val_7 = (val_4 != true) ? (val_17) : (val_13);
                val_16 = 0f;
            }
            
            this.congratulationsGroup.alpha = val_13;
            PluginExtension.SetColorAlpha(graphic:  this.darkOverlay, a:  val_13);
            this.continueGroup.alpha = val_16;
            this.continueGroup.blocksRaycasts = val_15 & 1;
            this.titleGroup.alpha = val_17;
            this.eventButtonsGroup.alpha = val_17;
            this.growGroup.alpha = val_7;
            this.growGroup.blocksRaycasts = (val_1 < val_3) ? 1 : 0;
            PluginExtension.SetColorAlpha(graphic:  this.bottomBackground, a:  val_7);
            this.forestChestButton.gameObject.SetActive(value:  val_4 ^ 1);
        }
        private void InitialiseForestLayout()
        {
            int val_4;
            if(this.forestContent != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.forestContent.gameObject);
                this.forestContent = 0;
            }
            
            WordForest.WFOForestData val_3 = this.forestManager.CurrentForestData;
            WordForest.WFOForestContent val_6 = UnityEngine.Object.Instantiate<WordForest.WFOForestContent>(original:  this.forestManager.GetForestLayout(forestId:  val_4), parent:  this.forestContentParent);
            this.forestContent = val_6;
            WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
            val_6.Initialize(forestMap:  val_7.forestMapData);
        }
        private void UpdateForestInfo(bool animated = False, bool skipButtonStates = False)
        {
            object val_4;
            int val_9;
            object val_12;
            UnityEngine.Events.UnityAction val_41;
            var val_42;
            UGUINetworkedButtonMultiGraphic val_43;
            var val_44;
            WordForest.WFOTree[] val_45;
            int val_2 = WordForest.WFOPlayer.Instance.CurrentForestGrowth;
            WordForest.WFOForestData val_3 = this.forestManager.CurrentForestData;
            val_41 = this.forestManager.CurrentForestContainsDamagedTrees;
            this.growButton.WaitingStatus(waiting:  false);
            if(skipButtonStates != true)
            {
                    this.growButton.interactable = (val_2 < val_4) ? 1 : 0;
                this.continueButton.interactable = (val_2 >= val_4) ? 1 : 0;
            }
            
            WordForest.WFOForestData val_8 = this.forestManager.CurrentForestData;
            WordForest.WFOForestData val_11 = this.forestManager.CurrentForestData;
            string val_13 = System.String.Format(format:  "{0}. {1}", arg0:  val_9.ToString(), arg1:  val_12);
            val_9 = val_2;
            string val_14 = System.String.Format(format:  "GROWTH {0}/{1}", arg0:  val_9, arg1:  val_4);
            GameEcon val_17 = App.getGameEcon;
            string val_18 = this.forestManager.GetGrowOrFixCost(growthLevel:  this.growthProgressText.CurrentForestGrowth).ToString(format:  val_17.numberFormatInt);
            this.growthCostText.alignByGeometry = ((this.forestManager.GetGrowOrFixCost(growthLevel:  this.growthCostText.CurrentForestGrowth)) > 999) ? 1 : 0;
            var val_22 = (val_41 != true) ? "FIX" : "GROW";
            if(animated != false)
            {
                    float val_41 = (float)val_2;
                val_41 = val_41 / (float)val_4;
                DG.Tweening.Tweener val_23 = DG.Tweening.ShortcutExtensions46.DOValue(target:  this.growthProgress, endValue:  val_41, duration:  0.3f, snapping:  false);
            }
            else
            {
                    float val_42 = (float)val_2;
                val_42 = val_42 / (float)val_4;
            }
            
            val_42 = 1152921504765632512;
            val_43 = this.buttonFixTree;
            val_44 = null;
            if(val_41 == false)
            {
                goto label_24;
            }
            
            if(val_43 == 0)
            {
                    this.buttonFixTree = UnityEngine.Object.Instantiate<UGUINetworkedButtonMultiGraphic>(original:  this.prefabButtonFixTree, parent:  this.gameObject.transform);
                UnityEngine.Events.UnityAction val_28 = null;
                val_41 = val_28;
                val_28 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestUI::OnFixTreeButtonClicked());
                this.prefabButtonFixTree.AddListener(call:  val_28);
            }
            
            this.buttonFixTree.interactable = true;
            this.buttonFixTree.WaitingStatus(waiting:  false);
            UnityEngine.Vector3 val_30 = UnityEngine.Vector3.zero;
            this.buttonFixTree.transform.localScale = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
            val_43 = this.buttonFixTree.transform;
            val_12 = 0;
            val_9 = 0;
            UnityEngine.Vector3 val_32 = new UnityEngine.Vector3(x:  0.5f, y:  0.5f, z:  1f);
            DG.Tweening.Tweener val_34 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_43, endValue:  new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z}, duration:  0.3f), ease:  27);
            val_45 = this.forestContent.trees;
            label_46:
            if(0 >= this.forestContent.trees.Length)
            {
                    return;
            }
            
            val_41 = 0;
            WordForest.WFOTree val_43 = val_45[val_41];
            if(this.forestContent.trees[0x0][0].growthState == 2)
            {
                goto label_45;
            }
            
            val_42 = 0 + 1;
            if(val_45 != null)
            {
                goto label_46;
            }
            
            throw new NullReferenceException();
            label_24:
            if(val_43 != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.buttonFixTree.gameObject);
            }
            
            this.currentHighlightedFixTreeId = 0;
            return;
            label_45:
            val_41 = this.forestContent.trees[val_41].transform;
            val_12 = 0;
            val_9 = 0;
            UnityEngine.Vector3 val_39 = new UnityEngine.Vector3(x:  0f, y:  -55f, z:  0f);
            if(null == null)
            {
                    UnityEngine.Vector3 val_40 = val_41.TransformPoint(position:  new UnityEngine.Vector3() {x = val_39.x, y = val_39.y, z = val_39.z});
                this.buttonFixTree.transform.position = new UnityEngine.Vector3() {x = val_40.x, y = val_40.y, z = val_40.z};
                this.currentHighlightedFixTreeId = 0;
                return;
            }
        
        }
        private void PlayPlantingAnimation(UnityEngine.Transform treeTransform)
        {
            UnityEngine.Vector3 val_3 = treeTransform.position;
            UnityEngine.Object.Instantiate<WordForest.WFOSeedParticles>(original:  this.seedParticlesPrefab, parent:  this.growButton.transform).PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, particleCount:  3);
        }
        private void OnForestInfoButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            goto mem[(1152921504946249728 + (public WordForest.WFOForestInfoPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFOForestInfoPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        private void OnGrowButtonClicked()
        {
            var val_9;
            WordForest.WFOForestUI val_32;
            object val_33;
            var val_34;
            var val_35;
            var val_36;
            val_32 = this;
            WFOForestUI.<>c__DisplayClass53_0 val_1 = null;
            val_33 = val_1;
            val_1 = new WFOForestUI.<>c__DisplayClass53_0();
            .<>4__this = val_32;
            if((this.currentHighlightedFixTreeId & 2147483648) == 0)
            {
                    this.OnFixTreeButtonClicked();
                return;
            }
            
            val_34 = this.forestManager;
            if(W22 >= (val_34.GetGrowOrFixCost(growthLevel:  WordForest.WFOPlayer.Instance.CurrentForestGrowth)))
            {
                goto label_5;
            }
            
            GameBehavior val_5 = App.getBehavior;
            val_34 = val_5.<metaGameBehavior>k__BackingField;
            val_33 = ???;
            val_32 = ???;
            goto mem[(1152921504946249728 + (public WordForest.WFONotEnoughAcornsPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFONotEnoughAcornsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
            label_5:
            WordForest.WFOForestData val_8 = val_32 + 304.CurrentForestData;
            if(val_34.CurrentForestGrowth >= val_9)
            {
                goto label_11;
            }
            
            val_32 + 304.AddGrowth(damagedTreeIdToFix:  0, onServerResponse:  0);
            WordForest.WFOPlayer val_10 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_10.tutorialCompleted, bit:  2)) == false)
            {
                goto label_14;
            }
            
            WordForest.WFOPlayer val_12 = WordForest.WFOPlayer.Instance;
            val_35 = (~(MonoExtensions.IsBitSet(value:  val_12.tutorialCompleted, bit:  3))) & 1;
            goto label_16;
            label_11:
            val_32.OnContinueButtonClicked();
            return;
            label_14:
            val_35 = 1;
            label_16:
            mem2[0] = val_35;
            val_32 + 160.interactable = false;
            val_32 + 160.WaitingStatus(waiting:  true);
            System.Collections.Generic.List<UnityEngine.Transform> val_20 = val_32 + 208.AddGrowth(addGrowth:  1);
            if(val_35 >= 1)
            {
                    var val_31 = 0;
                do
            {
                if(val_31 >= val_35)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_36 = val_32;
                val_35 = val_35 + 0;
                val_36.PlayPlantingAnimation(treeTransform:  (val_35 + 0) + 32);
                val_31 = val_31 + 1;
            }
            while(val_31 < val_35);
            
            }
            
            WordForest.WFOForestData val_22 = val_32 + 304.CurrentForestData;
            if(val_36.CurrentForestGrowth >= val_9)
            {
                    val_32 + 232.SetActive(value:  false);
                val_32 + 208.AddAnimationSequence(nextSequence:  val_32.DoCompleteForestSequence());
                val_32 + 40.blocksRaycasts = false;
                DG.Tweening.Tweener val_24 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_32 + 40, endValue:  0f, duration:  0.5f);
            }
            
            DG.Tweening.Tween val_26 = DG.Tweening.DOVirtual.DelayedCall(delay:  2f, callback:  new DG.Tweening.TweenCallback(object:  val_33, method:  System.Void WFOForestUI.<>c__DisplayClass53_0::<OnGrowButtonClicked>b__0()), ignoreTimeScale:  true);
            WordForest.WFOPlayer val_27 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_27.tutorialCompleted, bit:  2)) == false)
            {
                goto label_30;
            }
            
            WordForest.WFOPlayer val_29 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_29.tutorialCompleted, bit:  3)) == false)
            {
                goto label_32;
            }
            
            return;
            label_30:
            val_32.EndFTUX_1();
            return;
            label_32:
            val_32.EndFTUX_2();
        }
        private void UnlockNewForest()
        {
            bool val_1 = this.forestManager.ContinueNextForest();
            this.InitialiseForestLayout();
            this.InitializeUI();
            this.UpdateForestInfo(animated:  false, skipButtonStates:  false);
        }
        private void OnForestNameClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            val_1.<metaGameBehavior>k__BackingField.SetOnTweenInCompleteCallback(callback:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestUI::<OnForestNameClicked>b__55_0()));
            val_1.<metaGameBehavior>k__BackingField.SetOnTweenOutBeginCallback(callback:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestUI::<OnForestNameClicked>b__55_1()));
        }
        private void OnContinueButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            mem2[0] = 1;
            val_1.<metaGameBehavior>k__BackingField.SetOnTweenInCompleteCallback(callback:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestUI::UnlockNewForest()));
            this.CueForestChestPointerAnim(delay:  8f);
        }
        private void OnChestButtonClicked()
        {
            var val_10;
            var val_11;
            IntPtr val_13;
            this.StopForestChestPointerAnim();
            if((((ForestMasterEventHandler.<Instance>k__BackingField) == null) || (ForestMasterEventHandler.IsEventActive == false)) || ((ForestMasterEventHandler.<Instance>k__BackingField.GetAcornReward(showCurrentLevel:  false)) < 1))
            {
                goto label_11;
            }
            
            decimal val_3 = ForestMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showCurrentLevel:  false);
            val_10 = null;
            val_10 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
            {
                goto label_11;
            }
            
            GameBehavior val_5 = App.getBehavior;
            val_11 = val_5.<metaGameBehavior>k__BackingField;
            val_13 = 1152921518135870880;
            goto label_16;
            label_11:
            GameBehavior val_7 = App.getBehavior;
            val_11 = val_7.<metaGameBehavior>k__BackingField;
            System.Action val_9 = null;
            val_13 = 1152921518135884192;
            label_16:
            val_9 = new System.Action(object:  this, method:  val_13);
            val_11.AddOnCollectCallback(callback:  val_9);
        }
        private void OnFixTreeButtonClicked()
        {
            var val_13;
            if((this.currentHighlightedFixTreeId & 2147483648) != 0)
            {
                    return;
            }
            
            int val_3 = this.forestManager.GetGrowOrFixCost(growthLevel:  WordForest.WFOPlayer.Instance.CurrentForestGrowth);
            if(W21 < val_3)
            {
                    GameBehavior val_4 = App.getBehavior;
                this = ???;
            }
            else
            {
                    WordForest.WFOForestData val_12 = this.forestManager.CurrentForestData;
                if(val_3.CurrentForestGrowth < val_13)
            {
                    this.growButton.interactable = false;
                this.buttonFixTree.interactable = false;
                this.buttonFixTree.WaitingStatus(waiting:  true);
                this.growButton.WaitingStatus(waiting:  true);
                UnityEngine.Vector3 val_15 = UnityEngine.Vector3.zero;
                DG.Tweening.Tweener val_18 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.buttonFixTree.transform, endValue:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, duration:  0.3f), ease:  26), delay:  1.6f);
                this.forestManager.AddGrowth(damagedTreeIdToFix:  this.currentHighlightedFixTreeId, onServerResponse:  0);
                this.PlayPlantingAnimation(treeTransform:  this.forestContent.FixTree(treeIndex:  this.currentHighlightedFixTreeId));
                WordForest.WFOForestData val_21 = this.forestManager.CurrentForestData;
                if(this.CurrentForestGrowth >= val_13)
            {
                    this.forestContent.AddAnimationSequence(nextSequence:  this.DoCompleteForestSequence());
            }
            
                DG.Tweening.Tween val_24 = DG.Tweening.DOVirtual.DelayedCall(delay:  2f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<OnFixTreeButtonClicked>b__58_0()), ignoreTimeScale:  true);
                return;
            }
            
                this.OnContinueButtonClicked();
            }
        
        }
        private void OnAndroidBackButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
        }
        private void StartGrowButtonPointerAnim()
        {
            int val_1 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.growButtonGlow, complete:  false);
            PluginExtension.SetColorAlpha(graphic:  this.growButtonGlow, a:  0.4f);
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.growButtonGlow, endValue:  0.8f, duration:  0.65f), ease:  7));
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.growButtonGlow, endValue:  0.4f, duration:  0.65f), ease:  7));
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_2, loops:  0, loopType:  0);
            int val_11 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.FTUXPointer.transform, complete:  false);
            DG.Tweening.Sequence val_12 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_12, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.FTUXPointer.transform, endValue:  0.8f, duration:  0.5f), ease:  5));
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_12, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.FTUXPointer.transform, endValue:  1f, duration:  0.5f), ease:  5));
            DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_12, interval:  1f);
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_12, loops:  0, loopType:  0);
        }
        private void CueForestChestPointerAnim(float delay = 0)
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.forestChestPointerSequence = val_1;
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  delay);
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.forestChestPointerSequence, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestUI::<CueForestChestPointerAnim>b__61_0()));
            DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.forestChestPointerScaler, endValue:  0.8f, duration:  0.5f), ease:  5));
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.forestChestPointerScaler, endValue:  1f, duration:  0.5f), ease:  6));
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_5, interval:  1f);
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_5, loops:  231, loopType:  0);
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.forestChestPointerSequence, t:  val_5);
        }
        private void StopForestChestPointerAnim()
        {
            DG.Tweening.TweenExtensions.Kill(t:  this.forestChestPointerSequence, complete:  false);
            this.forestChestPointerScaler.gameObject.SetActive(value:  false);
        }
        private void OnTooltipContinueButtonClicked()
        {
            if(this.FTUXTooltip_3 != null)
            {
                    this.FTUXTooltip_3.SetActive(value:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void TrackAmplitudeInitialForestEntry()
        {
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "Forest FTUX Clickthrough", value:  (AmplitudePluginHelper.lastFeatureAccessPoint == 97) ? 1 : 0);
            val_4 = null;
            val_4 = null;
            App.trackerManager.track(eventName:  "Initial Forest Entry", data:  val_2);
        }
        public WFOForestUI()
        {
            this.currentHighlightedFixTreeId = 0;
        }
        private void <DoCompleteForestSequence>b__42_1()
        {
            if(this.congratParticleLeft != null)
            {
                    this.congratParticleLeft.Play();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <DoCompleteForestSequence>b__42_2()
        {
            if(this.congratParticleRight != null)
            {
                    this.congratParticleRight.Play();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <DoCompleteForestSequence>b__42_3()
        {
            if(this.continueGroup != null)
            {
                    this.continueGroup.blocksRaycasts = true;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <DoCompleteForestSequence>b__42_4()
        {
            this.continueButtonGlow.gameObject.SetActive(value:  true);
        }
        private void <DoCompleteForestSequence>b__42_5()
        {
            this.continueButtonPointerScaler.gameObject.SetActive(value:  true);
        }
        private void <EndFTUX_2>b__46_0()
        {
            this.growButton.interactable = true;
            this.homeButton.interactable = true;
            if(this.forestInfoButton != 0)
            {
                    this.forestInfoButton.interactable = true;
            }
            
            this.forestNameButton.interactable = true;
            this.playButton.interactable = true;
        }
        private void <OnForestNameClicked>b__55_0()
        {
            this.gameObject.SetActive(value:  false);
        }
        private void <OnForestNameClicked>b__55_1()
        {
            this.gameObject.SetActive(value:  true);
        }
        private void <OnChestButtonClicked>b__57_0()
        {
            ForestMasterEventHandler.<Instance>k__BackingField.ShowRewardCollection();
            this.InitializeUI();
        }
        private void <OnFixTreeButtonClicked>b__58_0()
        {
            this.UpdateForestInfo(animated:  true, skipButtonStates:  false);
        }
        private void <CueForestChestPointerAnim>b__61_0()
        {
            this.forestChestPointerScaler.gameObject.SetActive(value:  true);
        }
    
    }

}
