using UnityEngine;

namespace WordForest
{
    public class AttackScreenMain : MonoSingleton<WordForest.AttackScreenMain>
    {
        // Fields
        private UnityEngine.RectTransform forestContainer;
        private UnityEngine.RectTransform adsArea;
        private UGUINetworkedButtonMultiGraphic buttonRevenge;
        private UGUINetworkedButtonMultiGraphic buttonFriends;
        private UnityEngine.CanvasGroup uiStatePicking;
        private UnityEngine.CanvasGroup uiStateReward;
        private UnityEngine.UI.Image opponentAvatarImage;
        private UnityEngine.UI.Text forestLabel;
        private UnityEngine.UI.Button prefabButtonAttackSpot;
        private UnityEngine.ParticleSystem efxChopAction;
        private UnityEngine.UI.RawImage blockShieldImage;
        private UnityEngine.UI.RawImage axeImage;
        private UnityEngine.UI.Text rewardBodyLabel;
        private UnityEngine.UI.Button buttonRewardOkay;
        private UnityEngine.GameObject ftuxRoot;
        private UnityEngine.UI.Button ftuxButtonClose;
        private UnityEngine.UI.Text ftuxText;
        private UnityEngine.GameObject ftuxCursorPrefab;
        private UnityEngine.GameObject revengeFtux;
        private UGUINetworkedButtonMultiGraphic revengeFtuxButton;
        private UnityEngine.UI.Button ftuxHighlightedObject;
        private UnityEngine.GameObject ftuxCursor;
        private WordForest.UserForestProfile opponent;
        private WordForest.AttackScreenMain.AttackOpponentType opponentType;
        private WordForest.WFOForestContent forestContent;
        private System.Collections.Generic.List<UnityEngine.UI.Button> buttonAttackSpots;
        private System.Collections.Generic.List<DG.Tweening.Tween> buttonAttackSpotsIdleSeq;
        private System.Collections.Generic.List<DG.Tweening.Tween> buttonAttackSpotsIdle2Seq;
        private WordForest.UserForestProfile initialRandomOpponent;
        private bool isSuccessful;
        private int acornsRewarded;
        private bool isAttackFtux;
        private bool isAttackBlockedFtux;
        private bool isReadyToShowRevengeFtux;
        
        // Methods
        private void OnAttackSpotClicked(int treeId)
        {
            this.buttonFriends.interactable = false;
            this.buttonRevenge.interactable = false;
            if((UnityEngine.Object.op_Implicit(exists:  this.ftuxCursor)) != false)
            {
                    this.ftuxCursor.SetActive(value:  false);
            }
            
            this.EndAttack(treeId:  treeId);
        }
        private void OnRevengeButtonClicked(bool isConnected)
        {
            this.revengeFtux.SetActive(value:  false);
            if(isConnected != false)
            {
                    MonoSingleton<WordForest.RaidAttackManager>.Instance.GetRevengeOpponentPool(onRevengeListRetrieved:  new System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>>(object:  this, method:  System.Void WordForest.AttackScreenMain::<OnRevengeButtonClicked>b__36_0(System.Collections.Generic.List<WordForest.UserForestProfile> revengeList)));
                return;
            }
            
            MonoSingleton<RaidAttackScreenUI>.Instance.ShowConnectionRequired();
        }
        private void OnFriendsButtonClicked(bool isConnected)
        {
            var val_4;
            var val_5;
            System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>> val_7;
            if(isConnected != false)
            {
                    val_4 = null;
                val_4 = null;
                val_5 = null;
                val_5 = null;
                val_7 = AttackScreenMain.<>c.<>9__37_0;
                if(val_7 == null)
            {
                    System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>> val_2 = null;
                val_7 = val_2;
                val_2 = new System.Action<System.Collections.Generic.List<WordForest.UserForestProfile>>(object:  AttackScreenMain.<>c.__il2cppRuntimeField_static_fields, method:  System.Void AttackScreenMain.<>c::<OnFriendsButtonClicked>b__37_0(System.Collections.Generic.List<WordForest.UserForestProfile> list));
                AttackScreenMain.<>c.<>9__37_0 = val_7;
            }
            
                MonoSingleton<WordForest.RaidAttackManager>.Instance.GetFriendsOpponentPool(friendFbidList:  FacebookPlugin.appFriendsIdsArray, onListRetrieved:  val_2);
                return;
            }
            
            MonoSingleton<RaidAttackScreenUI>.Instance.ShowConnectionRequired();
        }
        private void Start()
        {
            float val_26;
            System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Int32> val_27;
            var val_28;
            var val_29;
            WordForest.UserForestProfile val_30;
            System.Delegate val_2 = System.Delegate.Combine(a:  static_value_02806000, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WordForest.AttackScreenMain::OnRevengeButtonClicked(bool isConnected)));
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            mem2[0] = val_2;
            System.Delegate val_4 = System.Delegate.Combine(a:  static_value_02806000, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WordForest.AttackScreenMain::OnRevengeButtonClicked(bool isConnected)));
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            mem2[0] = val_4;
            System.Delegate val_6 = System.Delegate.Combine(a:  static_value_02806000, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WordForest.AttackScreenMain::OnFriendsButtonClicked(bool isConnected)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            mem2[0] = val_6;
            this.buttonRewardOkay.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.AttackScreenMain::OnExitScreenClicked()));
            this.ftuxButtonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.AttackScreenMain::OnFtuxButtonClicked()));
            WordForest.WFOPlayer val_9 = WordForest.WFOPlayer.Instance;
            bool val_25 = ~(MonoExtensions.IsBitSet(value:  val_9.tutorialCompleted, bit:  10));
            val_25 = val_25 & 1;
            this.isAttackFtux = val_25;
            WordForest.WFOPlayer val_11 = WordForest.WFOPlayer.Instance;
            bool val_13 = (MonoExtensions.IsBitSet(value:  val_11.tutorialCompleted, bit:  11)) ^ 1;
            this.isAttackBlockedFtux = val_13;
            if((this.isAttackFtux == true) || (val_13 == true))
            {
                goto label_17;
            }
            
            WordForest.WFOPlayer val_15 = WordForest.WFOPlayer.Instance;
            bool val_16 = MonoExtensions.IsBitSet(value:  val_15.tutorialCompleted, bit:  12);
            bool val_26 = ~val_16;
            val_26 = val_26 & 1;
            this.isReadyToShowRevengeFtux = val_26;
            if(val_16 == true)
            {
                goto label_22;
            }
            
            this.ftuxButtonClose.m_OnClick.RemoveAllListeners();
            goto label_22;
            label_17:
            this.isReadyToShowRevengeFtux = false;
            label_22:
            if(this.isAttackFtux == false)
            {
                goto label_23;
            }
            
            WordForest.WFOGameEcon val_17 = WordForest.WFOGameEcon.Instance;
            val_26 = val_17.ftuxForestGrowthPercent.Item[10];
            WordForest.WFOGameEcon val_19 = WordForest.WFOGameEcon.Instance;
            val_27 = val_19.ftuxForestInitDestroyedTrees;
            val_28 = 10;
            goto label_28;
            label_23:
            if(this.isAttackBlockedFtux == false)
            {
                goto label_29;
            }
            
            WordForest.WFOGameEcon val_20 = WordForest.WFOGameEcon.Instance;
            val_26 = val_20.ftuxForestGrowthPercent.Item[11];
            WordForest.WFOGameEcon val_22 = WordForest.WFOGameEcon.Instance;
            val_27 = val_22.ftuxForestInitDestroyedTrees;
            val_28 = 11;
            label_28:
            val_29 = val_27.Item[11];
            if(this.isAttackFtux != true)
            {
                    if(this.isAttackBlockedFtux == false)
            {
                goto label_35;
            }
            
            }
            
            val_30 = WordForest.UserForestProfile.CreateDummyProfile(baseLevel:  2, flexibleBaseLevel:  false, minTreesNormalized:  val_26, maxTreesNormalized:  val_26);
            goto label_36;
            label_29:
            val_29 = 0;
            label_35:
            val_30 = 0;
            label_36:
            this.ShowUserForest(targetForest:  val_30, opponType:  0, initDestroyedTrees:  0);
            this.CheckShowFtux();
            return;
            label_9:
        }
        private void OnEnable()
        {
            if((MonoSingleton<AdsUIController>.Instance) == 0)
            {
                    return;
            }
            
            this.adsArea.gameObject.SetActive(value:  ((MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight()) > 0f) ? 1 : 0);
        }
        public void ShowUserForest(WordForest.UserForestProfile targetForest, WordForest.AttackScreenMain.AttackOpponentType opponType = 0, int initDestroyedTrees = 0)
        {
            WordForest.UserForestProfile val_11;
            UnityEngine.RectTransform val_12;
            this.Clear();
            this.opponentType = opponType;
            if(targetForest != null)
            {
                    this.opponent = targetForest;
            }
            else
            {
                    val_11 = this.initialRandomOpponent;
                if(val_11 == null)
            {
                    WordForest.UserForestProfile val_2 = MonoSingleton<WordForest.RaidAttackManager>.Instance.GetAttackRandomOpponent();
                this.initialRandomOpponent = val_2;
            }
            
                this.opponent = val_2;
            }
            
            val_12 = this.forestContainer;
            WordForest.WFOForestContent val_5 = UnityEngine.Object.Instantiate<WordForest.WFOForestContent>(original:  MonoSingleton<WordForest.WFOForestManager>.Instance.GetForestLayout(forestId:  this.opponent.level), parent:  val_12);
            this.forestContent = val_5;
            val_5.Initialize(forestMap:  this.opponent.map);
            if(initDestroyedTrees < 1)
            {
                goto label_28;
            }
            
            RandomSet val_6 = null;
            val_12 = val_6;
            val_6 = new RandomSet();
            var val_11 = 0;
            label_20:
            if(val_11 >= this.forestContent.trees.Length)
            {
                goto label_18;
            }
            
            val_6.add(item:  0, weight:  1f);
            val_11 = val_11 + 1;
            if(this.forestContent != null)
            {
                goto label_20;
            }
            
            label_18:
            if(initDestroyedTrees < 1)
            {
                goto label_28;
            }
            
            var val_13 = 0;
            label_29:
            DG.Tweening.Sequence val_8 = this.forestContent.trees[val_6.roll(unweighted:  false)].SetGrowthState(state:  2, instant:  true, delayGrowth:  false, shadowParent:  0);
            val_13 = val_13 + 1;
            if(val_13 >= initDestroyedTrees)
            {
                goto label_28;
            }
            
            if(this.forestContent != null)
            {
                goto label_29;
            }
            
            throw new NullReferenceException();
            label_28:
            WordForest.RaidAttackManager val_9 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            this.opponentAvatarImage.sprite = val_9.avatarConfig.GetAvatarSpriteByID(id:  this.opponent.avatarId, portraitID:  this.opponent.portraitID);
            this.InitializeAttackSpots();
        }
        private void Clear()
        {
            DG.Tweening.Tween val_2;
            var val_3;
            if(this.buttonAttackSpotsIdleSeq == null)
            {
                goto label_27;
            }
            
            List.Enumerator<T> val_1 = this.buttonAttackSpotsIdleSeq.GetEnumerator();
            label_3:
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            DG.Tweening.TweenExtensions.Kill(t:  val_2, complete:  false);
            goto label_3;
            label_2:
            val_3.Dispose();
            label_27:
            if(this.buttonAttackSpotsIdle2Seq == null)
            {
                goto label_24;
            }
            
            List.Enumerator<T> val_5 = this.buttonAttackSpotsIdle2Seq.GetEnumerator();
            label_6:
            if(val_3.MoveNext() == false)
            {
                goto label_5;
            }
            
            DG.Tweening.TweenExtensions.Kill(t:  val_2, complete:  false);
            goto label_6;
            label_5:
            val_3.Dispose();
            label_24:
            if(this.buttonAttackSpots == null)
            {
                goto label_30;
            }
            
            List.Enumerator<T> val_7 = this.buttonAttackSpots.GetEnumerator();
            label_12:
            if(0.MoveNext() == false)
            {
                goto label_8;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  0.gameObject);
            goto label_12;
            label_8:
            0.Dispose();
            label_30:
            if(this.forestContent == 0)
            {
                    return;
            }
            
            this = this.forestContent.gameObject;
            UnityEngine.Object.Destroy(obj:  this);
        }
        private void InitializeAttackSpots()
        {
            object val_32;
            int val_33;
            WordForest.WFOForestContent val_34;
            this.buttonAttackSpots = new System.Collections.Generic.List<UnityEngine.UI.Button>();
            val_32 = 1152921504687730688;
            this.buttonAttackSpotsIdleSeq = new System.Collections.Generic.List<DG.Tweening.Tween>();
            this.buttonAttackSpotsIdle2Seq = new System.Collections.Generic.List<DG.Tweening.Tween>();
            var val_36 = 4;
            do
            {
                val_33 = val_36 - 4;
                if(val_33 >= this.forestContent.trees.Length)
            {
                    return;
            }
            
                AttackScreenMain.<>c__DisplayClass42_0 val_4 = null;
                val_32 = val_4;
                val_4 = new AttackScreenMain.<>c__DisplayClass42_0();
                .<>4__this = this;
                val_34 = this.forestContent;
                WordForest.WFOTree val_32 = this.forestContent.trees[0];
                if(this.forestContent.trees[0].growthState == 1)
            {
                    .spotId = val_33;
                UnityEngine.UI.Button val_5 = UnityEngine.Object.Instantiate<UnityEngine.UI.Button>(original:  this.prefabButtonAttackSpot, parent:  this.forestContainer);
                UnityEngine.Transform val_6 = this.forestContent.trees[0].transform;
                if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
                UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  0f, y:  100f, z:  0f);
                UnityEngine.Vector3 val_9 = val_6.TransformPoint(position:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
                val_5.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
                UnityEngine.Vector3 val_11 = UnityEngine.Vector3.one;
                val_5.transform.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
                UnityEngine.Events.UnityAction val_12 = null;
                val_33 = val_12;
                val_12 = new UnityEngine.Events.UnityAction(object:  val_4, method:  System.Void AttackScreenMain.<>c__DisplayClass42_0::<InitializeAttackSpots>b__0());
                val_5.m_OnClick.AddListener(call:  val_12);
                this.buttonAttackSpots.Add(item:  val_5);
                DG.Tweening.Sequence val_13 = DG.Tweening.DOTween.Sequence();
                DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_13, loops:  0, loopType:  0);
                float val_34 = 2.5f;
                val_34 = (UnityEngine.Random.Range(min:  0.8f, max:  1.2f)) * val_34;
                DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_13, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_5.transform, endValue:  0.85f, duration:  val_34), ease:  1));
                float val_35 = 0.25f;
                val_35 = (UnityEngine.Random.Range(min:  0.8f, max:  1.2f)) * val_35;
                DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_13, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_5.transform, endValue:  1f, duration:  val_35), ease:  27));
                this.buttonAttackSpotsIdleSeq.Add(item:  val_13);
                val_32 = this.buttonAttackSpotsIdle2Seq;
                UnityEngine.Vector3 val_26 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -360f);
                val_32.Add(item:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  val_5.transform, endValue:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z}, duration:  (UnityEngine.Random.Range(min:  0.75f, max:  1f)) * 16f, mode:  3), ease:  1), loops:  0, loopType:  0));
                val_34 = this.forestContent;
            }
            
                val_36 = val_36 + 1;
            }
            while(val_34 != null);
            
            throw new NullReferenceException();
            label_17:
        }
        private void EndAttack(int treeId)
        {
            int val_9;
            int val_10;
            bool val_62;
            var val_63;
            bool val_65;
            int val_66;
            int val_67;
            var val_68;
            .<>4__this = this;
            .attackedTree = this.forestContent.trees[treeId];
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            if(this.opponent.IsDummyAccount == false)
            {
                goto label_6;
            }
            
            val_62 = this.isAttackFtux;
            if((val_62 == true) || (this.isAttackBlockedFtux == true))
            {
                goto label_10;
            }
            
            int val_4 = UnityEngine.Random.Range(min:  0, max:  101);
            val_62 = ((val_4 != 0) ? 1 : 0) & ((val_2.attackSuccessRate >= (float)val_4) ? 1 : 0);
            goto label_10;
            label_6:
            bool val_7 = (this.opponent.shields < 1) ? 1 : 0;
            label_10:
            this.isSuccessful = val_7;
            val_63 = null;
            val_63 = null;
            WordForest.RaidAttackManager.lastAttackResult = val_7;
            Dictionary.Enumerator<TKey, TValue> val_8 = val_2.attackRewardAcorns.GetEnumerator();
            label_19:
            if(val_10.MoveNext() == false)
            {
                goto label_16;
            }
            
            int val_12 = UnityEngine.Mathf.Max(a:  val_9, b:  0);
            goto label_19;
            label_16:
            val_10.Dispose();
            WordForest.WFOPlayer val_13 = WordForest.WFOPlayer.Instance;
            int val_14 = (val_13.currentForestID > 0) ? 0 : val_13.currentForestID;
            if((val_2.attackRewardAcorns.ContainsKey(key:  val_14)) != false)
            {
                    UnityEngine.Vector2Int val_16 = val_2.attackRewardAcorns.Item[val_14];
                if(this.isSuccessful != false)
            {
                    int val_17 = val_16.m_X.y;
            }
            
                this.acornsRewarded = val_16.m_X.x;
            }
            
            if(this.isSuccessful != false)
            {
                    if(((AttackScreenMain.<>c__DisplayClass43_0)[1152921518068167920].attackedTree) != null)
            {
                goto label_28;
            }
            
            }
            
            label_28:
            UnityEngine.Vector3 val_21 = this.blockShieldImage.transform.position;
            this.efxChopAction.transform.position = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
            if(this.opponent.IsDummyAccount != false)
            {
                    WordForest.RaidAttackManager val_23 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_10 = 0;
                System.Nullable<System.Boolean> val_24 = new System.Nullable<System.Boolean>(value:  this.isSuccessful);
                val_65 = val_24.HasValue;
                val_66 = this.opponent.serverId;
                val_67 = treeId;
            }
            else
            {
                    val_66 = this.opponent.serverId;
                val_67 = treeId;
                val_65 = 0;
            }
            
            MonoSingleton<WordForest.RaidAttackManager>.Instance.ResolveAttack(opponentId:  val_66, treeId:  val_67, autoSuccess:  new System.Nullable<System.Boolean>() {HasValue = false});
            val_10 = this.acornsRewarded;
            WordForest.RaidAttackManager val_27 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            val_27.notifyController.Notify(note:  4, data:  new System.Collections.Hashtable());
            WordForest.WFOPlayer val_28 = WordForest.WFOPlayer.Instance;
            val_28.starsLevelBalance = this.acornsRewarded + val_28.starsLevelBalance;
            WordForest.WFOPlayer.Instance.TrackNonCoinReward(source:  "Attack", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  this.acornsRewarded.ToString(), additionalParams:  0);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_33 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if(this.opponent.IsDummyAccount != true)
            {
                    val_10 = this.opponent.serverId;
                val_33.Add(key:  "Attacked Opponent ID", value:  val_10);
            }
            
            val_10 = this.isSuccessful;
            val_33.Add(key:  "Attack Successful", value:  val_10);
            mem2[0] = this.opponentType;
            val_33.Add(key:  "Type", value:  this.opponentType.ToString());
            val_68 = null;
            val_68 = null;
            App.trackerManager.track(eventName:  "Attack Complete", data:  val_33);
            var val_64 = 4;
            label_82:
            var val_36 = val_64 - 4;
            if(val_36 >= 30105600)
            {
                goto label_64;
            }
            
            if(30105600 <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            48.interactable = false;
            if(val_36 < 30105600)
            {
                    if(30105600 <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(48 != 0)
            {
                    if(48 <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                DG.Tweening.TweenExtensions.Kill(t:  mem[240518168656], complete:  false);
            }
            
            }
            
            if(val_36 < 48)
            {
                    if(48 <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(mem[240518168656] != 0)
            {
                    if(mem[240518168656] <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                DG.Tweening.TweenExtensions.Kill(t:  mem[240518168656] + 32, complete:  false);
            }
            
            }
            
            if(mem[240518168656] <= val_36)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            float val_63 = 3f;
            val_63 = (UnityEngine.Random.Range(min:  1f, max:  val_63)) * 0.1f;
            DG.Tweening.Tweener val_40 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  mem[240518168656] + 32.transform, endValue:  0f, duration:  val_63), ease:  26);
            val_64 = val_64 + 1;
            if(this.buttonAttackSpots != null)
            {
                goto label_82;
            }
            
            throw new NullReferenceException();
            label_64:
            DG.Tweening.Sequence val_41 = DG.Tweening.DOTween.Sequence();
            val_10 = 0;
            UnityEngine.Vector3 val_43 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  40f);
            DG.Tweening.Sequence val_46 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_41, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.axeImage.transform, endValue:  new UnityEngine.Vector3() {x = val_43.x, y = val_43.y, z = val_43.z}, duration:  0.7f, mode:  0), ease:  7));
            UnityEngine.Vector3 val_48 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -31f);
            DG.Tweening.Sequence val_51 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_41, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.axeImage.transform, endValue:  new UnityEngine.Vector3() {x = val_48.x, y = val_48.y, z = val_48.z}, duration:  0.13f, mode:  0), ease:  6));
            DG.Tweening.Sequence val_53 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_41, callback:  new DG.Tweening.TweenCallback(object:  new AttackScreenMain.<>c__DisplayClass43_0(), method:  System.Void AttackScreenMain.<>c__DisplayClass43_0::<EndAttack>b__0()));
            UnityEngine.Vector3 val_55 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  0f);
            DG.Tweening.Sequence val_58 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_41, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.axeImage.transform, endValue:  new UnityEngine.Vector3() {x = val_55.x, y = val_55.y, z = val_55.z}, duration:  0.35f, mode:  0), ease:  27));
            DG.Tweening.Sequence val_59 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_41, interval:  1.5f);
            DG.Tweening.Sequence val_61 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_41, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.AttackScreenMain::ShowResultScreen()));
        }
        private void ShowResultScreen()
        {
            string val_5;
            if(this.isSuccessful != false)
            {
                    val_5 = "You attacked {0}\'s village and won {1} Acorns.";
            }
            else
            {
                    val_5 = "{0} blocked your attack. You won {1} Acorns.";
            }
            
            string val_1 = System.String.Format(format:  val_5, arg0:  this.opponent.name, arg1:  this.acornsRewarded);
            this.uiStateReward.alpha = 0f;
            this.uiStateReward.gameObject.SetActive(value:  true);
            DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.uiStateReward, endValue:  1f, duration:  0.15f);
        }
        private void OnExitScreenClicked()
        {
            this.buttonRewardOkay.interactable = false;
            MonoSingleton<RaidAttackScreenUI>.Instance.BackButtonPressed();
        }
        private void CheckShowFtux()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.RaidAttackManager val_2 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            if((val_2.isEligibleForRevengeFtux != false) && (this.isReadyToShowRevengeFtux != false))
            {
                    WordForest.RaidAttackManager val_3 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_3.isEligibleForRevengeFtux = false;
                val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_1.tutorialCompleted, bit:  12);
                this.revengeFtux.SetActive(value:  true);
                return;
            }
            
            if(this.isAttackFtux != true)
            {
                    if(this.isAttackBlockedFtux == false)
            {
                    return;
            }
            
            }
            
            this.buttonRevenge.gameObject.SetActive(value:  false);
            this.buttonFriends.gameObject.SetActive(value:  false);
            if(this.isAttackFtux != false)
            {
                    val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_1.tutorialCompleted, bit:  10);
                string val_8 = System.String.Format(format:  "You’ve entered {0}\'s Village. Tap any tree to cut it down!", arg0:  this.opponent.name);
            }
            else
            {
                    val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_1.tutorialCompleted, bit:  11);
            }
            
            this.ftuxRoot.SetActive(value:  true);
            int val_10 = UnityEngine.Random.Range(min:  0, max:  1);
            if(null <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.UI.Text val_11 = 1152921504814993408 + (val_10 << 3);
            this.ftuxHighlightedObject = mem[(1152921504814993408 + (val_10) << 3) + 32];
            mem[(1152921504814993408 + (val_10) << 3) + 32] + 248.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.AttackScreenMain::OnFtuxButtonClicked()));
            DG.Tweening.Tween val_14 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.05f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.AttackScreenMain::<CheckShowFtux>b__46_0()), ignoreTimeScale:  true);
        }
        private void OnFtuxButtonClicked()
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.ftuxHighlightedObject)) != false)
            {
                    this.ftuxHighlightedObject.transform.SetParent(p:  this.forestContainer);
            }
            
            this.ftuxRoot.SetActive(value:  false);
        }
        public AttackScreenMain()
        {
        
        }
        private void <OnRevengeButtonClicked>b__36_0(System.Collections.Generic.List<WordForest.UserForestProfile> revengeList)
        {
            MonoSingleton<RaidAttackWindowManager>.Instance.ShowUGUIMonolith<WordForest.WFORevengePopup>(showNext:  false).Initialize(randomUser:  this.initialRandomOpponent, revengeUserList:  revengeList);
        }
        private void <CheckShowFtux>b__46_0()
        {
            this.ftuxHighlightedObject.transform.SetParent(p:  this.ftuxRoot.transform);
            if(this.ftuxCursor != 0)
            {
                    UnityEngine.Object.DestroyImmediate(obj:  this.ftuxCursor);
            }
            
            UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.ftuxCursorPrefab, parent:  this.ftuxHighlightedObject.transform);
            this.ftuxCursor = val_5;
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
            val_5.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  100f, y:  -100f);
            this.ftuxCursor.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            this.ftuxCursor.transform.parent = this.ftuxRoot.transform;
        }
    
    }

}
