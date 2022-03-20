using UnityEngine;

namespace WordForest
{
    public class RaidScreenMain : MonoSingleton<WordForest.RaidScreenMain>
    {
        // Fields
        private const int MAX_PICK_CHANCES = 3;
        private UnityEngine.RectTransform forestContainer;
        private UnityEngine.RectTransform adsArea;
        private UnityEngine.CanvasGroup uiStatePicking;
        private UnityEngine.CanvasGroup uiStateReward;
        private System.Collections.Generic.List<UnityEngine.UI.Image> pickerIconList;
        private UnityEngine.UI.Image opponentAvatarImage;
        private UnityEngine.UI.Text forestLabel;
        private UnityEngine.UI.Text subtitleLabel;
        private WordForest.WFODigAnimation digAnimation;
        private UnityEngine.GameObject prefabSpotResultLabel;
        private UnityEngine.ParticleSystem prefabEfxAcornSpring;
        private UnityEngine.GameObject perfectBanner;
        private UnityEngine.UI.Text rewardBodyLabel;
        private UnityEngine.UI.Button buttonRewardOkay;
        private UnityEngine.GameObject ftuxRoot;
        private UnityEngine.UI.Button ftuxButtonClose;
        private FtuxTooltip ftuxTooltip;
        private UnityEngine.UI.Text ftuxText;
        private UnityEngine.GameObject ftuxCursorPrefab;
        private WordForest.UserForestProfile opponent;
        private System.Collections.Generic.List<int> chosenRewardIndexes;
        private int acornsRaided;
        private bool isPerfectRaid;
        private int spotsRaided;
        private bool areRaidSpotsInteractable;
        private WordForest.WFOForestContent forestContent;
        private bool isFtux;
        private System.Collections.Generic.List<UnityEngine.GameObject> ftuxCursors;
        private UnityEngine.Coroutine ftuxCoroutine;
        
        // Properties
        private System.Collections.Generic.List<int> pickerRewards { get; }
        
        // Methods
        private System.Collections.Generic.List<int> get_pickerRewards()
        {
            WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            return (System.Collections.Generic.List<System.Int32>)val_1.<currentRaidPickerOptions>k__BackingField;
        }
        private void Start()
        {
            int val_10;
            this.buttonRewardOkay.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.RaidScreenMain::OnExitScreenClicked()));
            this.ftuxButtonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.RaidScreenMain::CloseFtux()));
            this.digAnimation.gameObject.SetActive(value:  false);
            this.prefabSpotResultLabel.gameObject.SetActive(value:  false);
            this.prefabEfxAcornSpring.gameObject.SetActive(value:  false);
            WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
            bool val_7 = MonoExtensions.IsBitSet(value:  val_6.tutorialCompleted, bit:  9);
            bool val_10 = ~val_7;
            val_10 = val_10 & 1;
            this.isFtux = val_10;
            if(val_7 != false)
            {
                    val_10 = 0;
            }
            else
            {
                    WordForest.WFOGameEcon val_8 = WordForest.WFOGameEcon.Instance;
                val_10 = val_8.ftuxForestInitDestroyedTrees.Item[9];
            }
            
            this.Initialize(initDestroyedTrees:  val_10);
            this.CheckShowFtux();
        }
        private void OnEnable()
        {
            if((MonoSingleton<AdsUIController>.Instance) == 0)
            {
                    return;
            }
            
            this.adsArea.gameObject.SetActive(value:  ((MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight()) > 0f) ? 1 : 0);
        }
        private void Initialize(int initDestroyedTrees)
        {
            UnityEngine.RectTransform val_13;
            this.BeginRaid();
            this.chosenRewardIndexes = new System.Collections.Generic.List<System.Int32>();
            this.isPerfectRaid = true;
            this.RefreshOpponentLabel();
            this.RefreshSubtitle();
            WordForest.RaidAttackManager val_2 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            this.opponentAvatarImage.sprite = val_2.avatarConfig.GetAvatarSpriteByID(id:  this.opponent.avatarId, portraitID:  0);
            if(this.forestContent != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.forestContent.gameObject);
            }
            
            val_13 = this.forestContainer;
            WordForest.WFOForestContent val_8 = UnityEngine.Object.Instantiate<WordForest.WFOForestContent>(original:  MonoSingleton<WordForest.WFOForestManager>.Instance.GetForestLayout(forestId:  this.opponent.level), parent:  val_13);
            this.forestContent = val_8;
            val_8.Initialize(forestMap:  this.opponent.map);
            this.forestContent.ToggleRaidXSpots(isVisible:  true);
            if(initDestroyedTrees < 1)
            {
                goto label_35;
            }
            
            RandomSet val_9 = null;
            val_13 = val_9;
            val_9 = new RandomSet();
            var val_13 = 0;
            label_27:
            if(val_13 >= this.forestContent.trees.Length)
            {
                goto label_25;
            }
            
            val_9.add(item:  0, weight:  1f);
            val_13 = val_13 + 1;
            if(this.forestContent != null)
            {
                goto label_27;
            }
            
            label_25:
            if(initDestroyedTrees < 1)
            {
                goto label_35;
            }
            
            var val_15 = 0;
            label_36:
            DG.Tweening.Sequence val_11 = this.forestContent.trees[val_9.roll(unweighted:  false)].SetGrowthState(state:  2, instant:  true, delayGrowth:  false, shadowParent:  0);
            val_15 = val_15 + 1;
            if(val_15 < initDestroyedTrees)
            {
                    if(this.forestContent != null)
            {
                goto label_36;
            }
            
            }
            
            label_35:
            if(this.forestContent.raidXButtons.Length < 1)
            {
                    return;
            }
            
            var val_16 = 0;
            do
            {
                val_13 = this.forestContent.raidXButtons[val_16];
                val_13.Initialize(id:  0, onClicked:  new System.Action<WordForest.RaidXSpotButton>(object:  this, method:  System.Void WordForest.RaidScreenMain::OnRaidXSpotClicked(WordForest.RaidXSpotButton spotButton)));
                val_16 = val_16 + 1;
            }
            while(val_16 < this.forestContent.raidXButtons.Length);
        
        }
        private void RefreshOpponentLabel()
        {
            string val_3 = System.String.Format(format:  "<color=#FFFAA8>{0}</color>\n is hiding {1}", arg0:  this.opponent.name, arg1:  System.Linq.Enumerable.Sum(source:  this.pickerRewards));
        }
        private void RefreshSubtitle()
        {
            string val_1 = System.String.Format(format:  "You stole: {0}", arg0:  this.acornsRaided);
        }
        private void OnRaidXSpotClicked(WordForest.RaidXSpotButton spotButton)
        {
            WordForest.RaidXSpotButton val_61;
            int val_62;
            var val_63;
            DG.Tweening.TweenCallback val_65;
            val_61 = spotButton;
            RaidScreenMain.<>c__DisplayClass37_0 val_1 = new RaidScreenMain.<>c__DisplayClass37_0();
            .<>4__this = this;
            .spotButton = val_61;
            if(this.chosenRewardIndexes > 2)
            {
                    return;
            }
            
            if(this.areRaidSpotsInteractable == false)
            {
                    return;
            }
            
            spotButton.button.interactable = false;
            this.areRaidSpotsInteractable = false;
            this.chosenRewardIndexes.Add(item:  (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField);
            if(this.isFtux == false)
            {
                goto label_9;
            }
            
            val_62 = this.spotsRaided;
            this.spotsRaided = val_62 + 1;
            if(this.chosenRewardIndexes.pickerRewards != null)
            {
                goto label_10;
            }
            
            label_9:
            WordForest.RaidXSpotButton val_61 = (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton;
            val_62 = (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField;
            label_10:
            if(val_61 <= val_62)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_61 = val_61 + (val_62 << 2);
            int val_62 = this.acornsRaided;
            val_62 = val_62 + (((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton + ((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField) << 2).onButtonClicked);
            this.acornsRaided = val_62;
            if((((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton + ((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField) << 2).onButtonClicked) <= 0)
            {
                    this.isPerfectRaid = false;
            }
            
            System.Collections.Generic.List<System.Int32> val_63 = this.chosenRewardIndexes;
            if(val_63 >= 3)
            {
                    this.EndRaid();
            }
            
            System.Collections.Generic.List<System.Int32> val_4 = val_63 - this.chosenRewardIndexes;
            if((val_63 >= 0) && (val_4 < val_63))
            {
                    if(val_63 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_63 = val_63 + (val_4 << 3);
                DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  0.transform, endValue:  0f, duration:  0.15f), ease:  26);
            }
            
            WordForest.WFODigAnimation val_9 = UnityEngine.Object.Instantiate<WordForest.WFODigAnimation>(original:  this.digAnimation, parent:  this.uiStatePicking.transform);
            .digAnimObj = val_9;
            UnityEngine.Vector3 val_12 = (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.transform.position;
            val_9.transform.position = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].digAnimObj.gameObject.SetActive(value:  true);
            UnityEngine.GameObject val_15 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.prefabSpotResultLabel, parent:  this.uiStatePicking.transform);
            UnityEngine.Vector3 val_18 = (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.transform.position;
            val_15.transform.position = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
            UnityEngine.Vector3 val_20 = UnityEngine.Vector3.zero;
            val_15.transform.localScale = new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z};
            UnityEngine.UI.Text val_21 = val_15.GetComponentInChildren<UnityEngine.UI.Text>();
            string val_22 = ((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton + ((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField) << 2).onButtonClicked.ToString();
            val_15.SetActive(value:  true);
            UnityEngine.ParticleSystem val_24 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  this.prefabEfxAcornSpring, parent:  this.uiStatePicking.transform);
            .acornSpringEfx = val_24;
            UnityEngine.Vector3 val_27 = (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.transform.position;
            val_24.transform.position = new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z};
            (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].acornSpringEfx.gameObject.SetActive(value:  true);
            DG.Tweening.Sequence val_29 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_29, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.transform, endValue:  0f, duration:  0.15f), ease:  26));
            DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void RaidScreenMain.<>c__DisplayClass37_0::<OnRaidXSpotClicked>b__0()));
            if((((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton + ((RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].spotButton.<SpotId>k__BackingField) << 2).onButtonClicked) >= 1)
            {
                    DG.Tweening.Sequence val_36 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_29, interval:  0.35f);
                DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void RaidScreenMain.<>c__DisplayClass37_0::<OnRaidXSpotClicked>b__1()));
                val_63 = null;
                val_63 = null;
                val_65 = RaidScreenMain.<>c.<>9__37_2;
                if(val_65 == null)
            {
                    DG.Tweening.TweenCallback val_39 = null;
                val_65 = val_39;
                val_39 = new DG.Tweening.TweenCallback(object:  RaidScreenMain.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RaidScreenMain.<>c::<OnRaidXSpotClicked>b__37_2());
                RaidScreenMain.<>c.<>9__37_2 = val_65;
            }
            
                DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  val_39);
            }
            
            DG.Tweening.Sequence val_41 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_29, interval:  0.9f);
            DG.Tweening.Sequence val_43 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  new DG.Tweening.TweenCallback(object:  (RaidScreenMain.<>c__DisplayClass37_0)[1152921518093951968].digAnimObj, method:  public System.Void WordForest.WFODigAnimation::FadeHole()));
            DG.Tweening.Sequence val_44 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_29, interval:  0.1f);
            DG.Tweening.Sequence val_48 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_29, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_15.transform, endValue:  1f, duration:  0.15f), ease:  27));
            DG.Tweening.Sequence val_50 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.RaidScreenMain::RefreshSubtitle()));
            DG.Tweening.TweenCallback val_51 = null;
            val_61 = val_51;
            val_51 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void RaidScreenMain.<>c__DisplayClass37_0::<OnRaidXSpotClicked>b__3());
            DG.Tweening.Sequence val_52 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_29, callback:  val_51);
            if(this.isFtux != false)
            {
                    if(this.ftuxCoroutine != null)
            {
                    this.StopCoroutine(routine:  this.ftuxCoroutine);
            }
            
                this.ftuxCoroutine = this.StartCoroutine(routine:  this.ContinueFtuxCoroutine());
            }
            
            if(this.chosenRewardIndexes < 3)
            {
                    return;
            }
            
            var val_65 = 0;
            label_68:
            if(val_65 >= this.forestContent.raidXButtons.Length)
            {
                goto label_65;
            }
            
            DG.Tweening.Tweener val_57 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.forestContent.raidXButtons[val_65].transform, endValue:  0f, duration:  0.15f), ease:  26);
            val_65 = val_65 + 1;
            if(this.forestContent != null)
            {
                goto label_68;
            }
            
            throw new NullReferenceException();
            label_65:
            DG.Tweening.Sequence val_58 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_29, interval:  1.5f);
            DG.Tweening.Sequence val_60 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_29, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.RaidScreenMain::ShowResultScreen()));
        }
        private void BeginRaid()
        {
            if(this.isFtux != false)
            {
                    WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
                WordForest.WFOGameEcon val_3 = WordForest.WFOGameEcon.Instance;
                this.opponent = WordForest.UserForestProfile.CreateDummyProfile(baseLevel:  3, flexibleBaseLevel:  false, minTreesNormalized:  val_1.ftuxForestGrowthPercent.Item[9], maxTreesNormalized:  val_3.ftuxForestGrowthPercent.Item[9]);
                MonoSingleton<WordForest.RaidAttackManager>.Instance.InitializeFtuxRaid(onInitialized:  new System.Action(object:  this, method:  System.Void WordForest.RaidScreenMain::RefreshOpponentLabel()));
                return;
            }
            
            this.opponent = MonoSingleton<WordForest.RaidAttackManager>.Instance.GetRaidRandomOpponent();
            MonoSingleton<WordForest.RaidAttackManager>.Instance.InitializeRaid(opponentId:  this.opponent.serverId, onInitialized:  new System.Action(object:  this, method:  System.Void WordForest.RaidScreenMain::RefreshOpponentLabel()));
        }
        private void EndRaid()
        {
            var val_9;
            var val_10;
            MonoSingleton<WordForest.RaidAttackManager>.Instance.ConcludeRaid(chosenRewardIndexes:  this.chosenRewardIndexes);
            val_9 = null;
            val_9 = null;
            WordForest.RaidAttackManager.lastRaidPerfect = this.isPerfectRaid;
            WordForest.RaidAttackManager val_3 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            val_3.notifyController.Notify(note:  2, data:  new System.Collections.Hashtable());
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            val_4.starsLevelBalance = this.acornsRaided + val_4.starsLevelBalance;
            WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
            int val_9 = val_7.playingStarsFromRaid;
            val_9 = this.acornsRaided + val_9;
            val_7.playingStarsFromRaid = val_9;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if((this.opponent.isDummyAccount != true) && ((this.opponent.<autoCreated>k__BackingField) != true))
            {
                    val_8.Add(key:  "Raided Opponent ID", value:  this.opponent.serverId);
            }
            
            val_10 = null;
            val_10 = null;
            App.trackerManager.track(eventName:  "Raid Complete", data:  val_8);
            if(this.forestContent.raidXButtons.Length < 1)
            {
                    return;
            }
            
            var val_11 = 0;
            do
            {
                WordForest.RaidXSpotButton val_10 = this.forestContent.raidXButtons[val_11];
                this.forestContent.raidXButtons[0x0][0].button.interactable = false;
                val_11 = val_11 + 1;
            }
            while(val_11 < this.forestContent.raidXButtons.Length);
        
        }
        private void ShowResultScreen()
        {
            string val_1 = System.String.Format(format:  "You stole {0} Acorns from {1}!", arg0:  this.acornsRaided, arg1:  this.opponent.name);
            this.perfectBanner.gameObject.SetActive(value:  this.isPerfectRaid);
            this.uiStateReward.alpha = 0f;
            this.uiStateReward.gameObject.SetActive(value:  true);
            DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.uiStateReward, endValue:  1f, duration:  0.15f);
        }
        private void OnExitScreenClicked()
        {
            this.buttonRewardOkay.interactable = false;
            MonoSingleton<RaidAttackScreenUI>.Instance.BackButtonPressed();
        }
        private void CheckShowFtux()
        {
            if(this.isFtux == false)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_1.tutorialCompleted, bit:  9);
            this.UpdateFtuxText();
            this.ftuxRoot.SetActive(value:  true);
            this.ftuxCursors = new System.Collections.Generic.List<UnityEngine.GameObject>();
            var val_11 = 0;
            do
            {
                if(val_11 >= this.forestContent.raidXButtons.Length)
            {
                    return;
            }
            
                UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.ftuxCursorPrefab, parent:  this.forestContent.raidXButtons[val_11].transform);
                UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
                val_5.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
                UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  100f, y:  -100f);
                val_5.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
                this.ftuxCursors.Add(item:  val_5);
                val_11 = val_11 + 1;
            }
            while(this.forestContent != null);
            
            throw new NullReferenceException();
        }
        private System.Collections.IEnumerator ContinueFtuxCoroutine()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new RaidScreenMain.<ContinueFtuxCoroutine>d__43();
        }
        private void UpdateFtuxText()
        {
            string val_1 = System.String.Format(format:  "{0}\'s acorns are buried in their village. Pick 3 locations and try to find them all!", arg0:  this.opponent.name);
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void CloseFtux()
        {
            if(this.ftuxRoot != null)
            {
                    this.ftuxRoot.SetActive(value:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        public RaidScreenMain()
        {
            this.isPerfectRaid = true;
            this.areRaidSpotsInteractable = true;
        }
    
    }

}
