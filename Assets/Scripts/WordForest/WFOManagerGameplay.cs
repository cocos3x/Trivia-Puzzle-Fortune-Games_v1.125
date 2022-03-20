using UnityEngine;

namespace WordForest
{
    public class WFOManagerGameplay : MonoSingleton<WordForest.WFOManagerGameplay>
    {
        // Fields
        public const string PLAYER_MOVE_UPDATED = "OnPlayerMoveUpdated";
        public const string ACORN_LEVEL_BALANCE_UPDATED = "OnAcornLevelBalanceUpdated";
        public const string ACORN_MULTIPLIER_TRAIL_PARTICLE_COMPLETED = "OnAcornMultiplierTrailParticleCompleted";
        public const string SHIELD_BALANCE_UPDATED = "OnShieldBalanceUpdated";
        private const string PREFKEY_LETTERS_RESOLVED = "pp_wfo_ltr_rs";
        public System.Collections.Generic.Queue<System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int>>> acornAwardedAnimQueue;
        private System.Collections.Generic.Dictionary<GameplayMode, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>> levelLettersResolved;
        private GameplayMode currentGameplayMode;
        private WordRegion wordRegion;
        private int <lastCompletedAcornsBase>k__BackingField;
        private int <lastCompletedWordStreak>k__BackingField;
        private int <lastCompletedOtherMultipliers>k__BackingField;
        private int <lastCompletedAcornsTotal>k__BackingField;
        
        // Properties
        public int lastCompletedAcornsBase { get; set; }
        public int lastCompletedWordStreak { get; set; }
        public int lastCompletedOtherMultipliers { get; set; }
        public int lastCompletedAcornsTotal { get; set; }
        public int TotalAdditionalMultipliers { get; }
        
        // Methods
        public int get_lastCompletedAcornsBase()
        {
            return (int)this.<lastCompletedAcornsBase>k__BackingField;
        }
        private void set_lastCompletedAcornsBase(int value)
        {
            this.<lastCompletedAcornsBase>k__BackingField = value;
        }
        public int get_lastCompletedWordStreak()
        {
            return (int)this.<lastCompletedWordStreak>k__BackingField;
        }
        private void set_lastCompletedWordStreak(int value)
        {
            this.<lastCompletedWordStreak>k__BackingField = value;
        }
        public int get_lastCompletedOtherMultipliers()
        {
            return (int)this.<lastCompletedOtherMultipliers>k__BackingField;
        }
        private void set_lastCompletedOtherMultipliers(int value)
        {
            this.<lastCompletedOtherMultipliers>k__BackingField = value;
        }
        public int get_lastCompletedAcornsTotal()
        {
            return (int)this.<lastCompletedAcornsTotal>k__BackingField;
        }
        private void set_lastCompletedAcornsTotal(int value)
        {
            this.<lastCompletedAcornsTotal>k__BackingField = value;
        }
        public int get_TotalAdditionalMultipliers()
        {
            if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == false)
            {
                    return 0;
            }
            
            float val_3 = WGSubscriptionManager.GetPointMultiplier();
            val_3 = val_3 + (-1f);
            val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
            0 = (int)val_3;
            return 0;
        }
        private void Start()
        {
            SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnSceneLoaded(SceneType sceneType)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnSceneLoaded = val_3;
            return;
            label_5:
        }
        private void OnSceneLoaded(SceneType sceneType)
        {
            if(sceneType != 2)
            {
                    return;
            }
            
            WordRegion val_1 = WordRegion.instance;
            this.wordRegion = val_1;
            val_1.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnValidWordSubmitted(string word)));
            this.wordRegion.addOnExtraWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnExtraWordFound(string extraWord)));
            this.wordRegion.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)));
            this.wordRegion.addOnHintUsedAtLocation(callback:  new System.Action<UnityEngine.Vector3>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnHintUsedAtLocation(UnityEngine.Vector3 pos)));
            this.wordRegion.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnLevelLoaded(GameLevel level)));
            this.wordRegion.addOnLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WordForest.WFOManagerGameplay::OnLevelComplete(GameLevel gameLevel)));
        }
        private void OnLevelLoaded(GameLevel level)
        {
            System.Collections.Generic.Dictionary<GameplayMode, System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>> val_22;
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>> val_23;
            var val_24;
            var val_25;
            var val_26;
            this.currentGameplayMode = PlayingLevel.CurrentGameplayMode;
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "pp_wfo_ltr_rs", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_2)) != false)
            {
                    System.Collections.Generic.Dictionary<GameplayMode, System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>> val_4 = null;
                val_22 = val_4;
                val_4 = new System.Collections.Generic.Dictionary<GameplayMode, System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>>();
            }
            else
            {
                    val_22 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<GameplayMode, System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>>>(value:  val_2);
            }
            
            this.levelLettersResolved = val_22;
            if((val_22.ContainsKey(key:  this.currentGameplayMode)) != true)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>> val_7 = null;
                val_23 = val_7;
                val_7 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>();
                this.levelLettersResolved.Add(key:  this.currentGameplayMode, value:  val_7);
            }
            
            char[] val_8 = new char[1];
            val_8[0] = 124;
            int val_22 = val_9.Length;
            val_24 = level.answers.Split(separator:  val_8);
            if(val_22 >= 1)
            {
                    val_25 = 1152921518147925600;
                var val_23 = 0;
                val_22 = val_22 & 4294967295;
                do
            {
                if((System.String.IsNullOrEmpty(value:  null)) != true)
            {
                    if((this.levelLettersResolved.Item[this.currentGameplayMode].ContainsKey(key:  null)) != true)
            {
                    this.levelLettersResolved.Item[this.currentGameplayMode].Add(key:  1152921505059157200, value:  new System.Collections.Generic.List<System.Int32>());
            }
            
            }
            
                val_23 = val_23 + 1;
            }
            while(val_23 < (val_9.Length << ));
            
            }
            
            char[] val_15 = new char[1];
            val_15[0] = 124;
            int val_24 = val_16.Length;
            if(val_24 < 1)
            {
                    return;
            }
            
            val_26 = 1152921518147925600;
            var val_25 = 0;
            val_24 = val_24 & 4294967295;
            do
            {
                if((System.String.IsNullOrEmpty(value:  null)) != true)
            {
                    if((this.levelLettersResolved.Item[this.currentGameplayMode].ContainsKey(key:  null)) != true)
            {
                    val_24 = this.levelLettersResolved.Item[this.currentGameplayMode];
                System.Collections.Generic.List<System.Int32> val_21 = null;
                val_23 = val_21;
                val_21 = new System.Collections.Generic.List<System.Int32>();
                val_24.Add(key:  1152921505059157200, value:  val_21);
            }
            
            }
            
                val_25 = val_25 + 1;
            }
            while(val_25 < (val_16.Length << ));
        
        }
        private void OnLevelComplete(GameLevel gameLevel)
        {
            int val_2 = WordForest.WFOPlayer.Instance.starsLevelBalance;
            int val_4 = WordStreak.CurrentStreak - 1;
            int val_6 = UnityEngine.Mathf.Max(a:  val_4 * val_2, b:  0);
            int val_19 = val_6;
            val_4 = val_19 + val_2;
            val_19 = val_4 + (val_6.TotalAdditionalMultipliers * val_2);
            this.<lastCompletedAcornsBase>k__BackingField = val_2;
            int val_8 = WordStreak.CurrentStreak;
            this.<lastCompletedWordStreak>k__BackingField = val_8;
            this.<lastCompletedOtherMultipliers>k__BackingField = val_8.TotalAdditionalMultipliers;
            this.<lastCompletedAcornsTotal>k__BackingField = val_19;
            WordForest.WFOPlayer val_10 = WordForest.WFOPlayer.Instance;
            val_10.starsLevelBalance = 0;
            val_10.TrackGoldenCurrencyEvents();
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
            {
                    GoldenApplesManager val_13 = MonoSingleton<GoldenApplesManager>.Instance;
            }
            
            MonoSingleton<WordForest.RaidAttackManager>.Instance.FlushPlayerData();
            int val_20 = gameLevel.goldenApplesStreaks;
            val_20 = val_20 + val_19;
            gameLevel.goldenApplesStreaks = val_20;
            gameLevel.highestWordStreak = UnityEngine.Mathf.Max(a:  gameLevel.highestWordStreak, b:  WordStreak.CurrentStreak);
            Player val_17 = App.Player;
            val_17.properties.SetLifetimeLargestStreak = WordStreak.CurrentStreak;
            this.levelLettersResolved.Clear();
            UnityEngine.PlayerPrefs.DeleteKey(key:  "pp_wfo_ltr_rs");
        }
        private void TrackGoldenCurrencyEvents()
        {
            int val_2 = UnityEngine.Mathf.Max(a:  1, b:  WordStreak.CurrentStreak);
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            int val_27 = val_3.playingStarsFromGameplay;
            val_27 = val_27 * val_2;
            val_3.playingStarsFromGameplay = val_27;
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            int val_28 = val_4.playingStarsFromMC;
            val_28 = val_28 * val_2;
            val_4.playingStarsFromMC = val_28;
            WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
            int val_29 = val_5.playingStarsFromFC;
            val_29 = val_29 * val_2;
            val_5.playingStarsFromFC = val_29;
            WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
            int val_30 = val_6.playingStarsFromRaid;
            val_30 = val_30 * val_2;
            val_6.playingStarsFromRaid = val_30;
            WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
            if(val_7.playingStarsFromRaid >= 1)
            {
                    WordForest.WFOPlayer val_9 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer.Instance.TrackNonCoinReward(source:  "Raid", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  val_9.playingStarsFromRaid.ToString(), additionalParams:  0);
            }
            
            WordForest.WFOPlayer val_11 = WordForest.WFOPlayer.Instance;
            if(val_11.playingStarsFromGameplay >= 1)
            {
                    WordForest.WFOPlayer val_13 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer.Instance.TrackNonCoinReward(source:  "Gameplay", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  val_13.playingStarsFromGameplay.ToString(), additionalParams:  0);
            }
            
            WordForest.WFOPlayer val_15 = WordForest.WFOPlayer.Instance;
            if(val_15.playingStarsFromMC >= 1)
            {
                    WordForest.WFOPlayer val_17 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer.Instance.TrackNonCoinReward(source:  "Mystery Chest", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  val_17.playingStarsFromMC.ToString(), additionalParams:  0);
            }
            
            WordForest.WFOPlayer val_19 = WordForest.WFOPlayer.Instance;
            if(val_19.playingStarsFromFC >= 1)
            {
                    WordForest.WFOPlayer val_21 = WordForest.WFOPlayer.Instance;
                WordForest.WFOPlayer.Instance.TrackNonCoinReward(source:  "Forest Chest", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  val_21.playingStarsFromFC.ToString(), additionalParams:  0);
            }
            
            WordForest.WFOPlayer val_23 = WordForest.WFOPlayer.Instance;
            val_23.playingStarsFromRaid = 0;
            WordForest.WFOPlayer val_24 = WordForest.WFOPlayer.Instance;
            val_24.playingStarsFromGameplay = 0;
            WordForest.WFOPlayer val_25 = WordForest.WFOPlayer.Instance;
            val_25.playingStarsFromMC = 0;
            WordForest.WFOPlayer val_26 = WordForest.WFOPlayer.Instance;
            val_26.playingStarsFromFC = 0;
        }
        private void CheckLettersFilledForAward()
        {
            System.Collections.Generic.Queue<System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>> val_14;
            var val_15;
            if((X27 + 24) < 1)
            {
                goto label_3;
            }
            
            label_39:
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            val_14 = 0;
            long val_21 = 0;
            goto label_4;
            label_34:
            if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_14 = X27 + 16;
            val_14 = val_14 + 0;
            if((this.levelLettersResolved.Item[this.currentGameplayMode].ContainsKey(key:  (X27 + 16 + 0) + 32 + 24)) != true)
            {
                    if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_15 = X27 + 16;
                val_15 = val_15 + 0;
                this.levelLettersResolved.Item[this.currentGameplayMode].Add(key:  (X27 + 16 + 0) + 32 + 24, value:  new System.Collections.Generic.List<System.Int32>());
            }
            
            if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_16 = X27 + 16;
            val_16 = val_16 + 0;
            if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_17 = X27 + 16;
            val_17 = val_17 + 0;
            if(((X27 + 16 + 0) + 32 + 40 + 24) <= val_14)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_18 = (X27 + 16 + 0) + 32 + 40 + 16;
            val_18 = val_18 + 0;
            var val_9 = ((((X27 + 16 + 0) + 32 + 40 + 16 + 0) + 32 + 72) == 0) ? 1 : 0;
            val_9 = (this.levelLettersResolved.Item[this.currentGameplayMode].Item[(X27 + 16 + 0) + 32 + 24].Contains(item:  0)) | val_9;
            if(val_9 != true)
            {
                    if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_19 = X27 + 16;
                val_19 = val_19 + 0;
                this.levelLettersResolved.Item[this.currentGameplayMode].Item[(X27 + 16 + 0) + 32 + 24].Add(item:  0);
                val_1.Add(item:  0);
            }
            
            val_14 = 1;
            label_4:
            if((X27 + 24) <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_20 = X27 + 16;
            val_20 = val_20 + 0;
            if(val_14 < ((X27 + 16 + 0) + 32 + 40 + 24))
            {
                goto label_34;
            }
            
            if(((X27 + 16 + 0) + 32 + 40 + 24) >= 1)
            {
                    val_14 = this.acornAwardedAnimQueue;
                System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_12 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>();
                val_12.Add(key:  0, value:  val_1);
                val_14.Enqueue(item:  val_12);
            }
            
            val_21 = val_21 + 1;
            val_15 = 1;
            if(val_21 < (X27 + 24))
            {
                goto label_39;
            }
            
            goto label_40;
            label_3:
            val_15 = 0;
            label_40:
            UnityEngine.PlayerPrefs.SetString(key:  "pp_wfo_ltr_rs", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.levelLettersResolved));
            this.UpdateAcornBalance(amountToAdd:  0);
        }
        private void OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)
        {
            this.CheckLettersFilledForAward();
        }
        private void OnHintUsedAtLocation(UnityEngine.Vector3 pos)
        {
            this.CheckLettersFilledForAward();
        }
        private void OnValidWordSubmitted(string word)
        {
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_15;
            .word = word;
            System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
            var val_15 = 0;
            val_15 = 0;
            label_15:
            if(val_15 >= ((WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word.m_stringLength))
            {
                goto label_3;
            }
            
            if((this.levelLettersResolved.Item[this.currentGameplayMode].ContainsKey(key:  (WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word)) != false)
            {
                    if((this.levelLettersResolved.Item[this.currentGameplayMode].Item[(WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word].Contains(item:  0)) != true)
            {
                    this.levelLettersResolved.Item[this.currentGameplayMode].Item[(WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word].Add(item:  0);
                val_15 = val_15 + 1;
                val_2.Add(item:  0);
            }
            
            }
            
            val_15 = val_15 + 1;
            if(((WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word) != null)
            {
                goto label_15;
            }
            
            label_3:
            if(((WFOManagerGameplay.<>c__DisplayClass35_0)[1152921518149500768].word.m_stringLength) >= 1)
            {
                    System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_12 = null;
                val_15 = val_12;
                val_12 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>();
                val_12.Add(key:  val_15.FindIndex(match:  new System.Predicate<LineWord>(object:  new WFOManagerGameplay.<>c__DisplayClass35_0(), method:  System.Boolean WFOManagerGameplay.<>c__DisplayClass35_0::<OnValidWordSubmitted>b__0(LineWord lineword))), value:  val_2);
                this.acornAwardedAnimQueue.Enqueue(item:  val_12);
            }
            
            UnityEngine.PlayerPrefs.SetString(key:  "pp_wfo_ltr_rs", value:  MiniJSON.Json.Serialize(obj:  this.levelLettersResolved));
            this.UpdateAcornBalance(amountToAdd:  0);
            WordForest.WFOPlayer.Instance.SaveState();
        }
        private void OnExtraWordFound(string extraWord)
        {
        
        }
        private void UpdateAcornBalance(int amountToAdd)
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            amountToAdd = val_1.starsLevelBalance + amountToAdd;
            val_1.starsLevelBalance = amountToAdd;
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            int val_5 = val_3.playingStarsFromGameplay;
            val_5 = val_5 + amountToAdd;
            val_3.playingStarsFromGameplay = val_5;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnPlayerMoveUpdated");
        }
        public bool CheckAndShowForestPopup()
        {
            var val_15;
            var val_16;
            var val_17;
            int val_18;
            var val_19;
            System.Func<System.Boolean> val_21;
            var val_22;
            val_15 = App.Player;
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            if(val_15 != val_2.wordForestPopupLevel)
            {
                goto label_5;
            }
            
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_3.tutorialCompleted, bit:  2)) == false)
            {
                goto label_7;
            }
            
            label_5:
            val_16 = 0;
            return (bool)val_16;
            label_7:
            GameBehavior val_5 = App.getBehavior;
            val_15 = val_5.<metaGameBehavior>k__BackingField;
            val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            bool[] val_10 = new bool[2];
            val_10[0] = true;
            string[] val_11 = new string[2];
            val_18 = val_11.Length;
            val_11[0] = Localization.Localize(key:  "go_upper_ex", defaultValue:  "GO!", useSingularKey:  false);
            val_18 = val_11.Length;
            val_11[1] = "OK";
            System.Func<System.Boolean>[] val_13 = new System.Func<System.Boolean>[2];
            val_19 = null;
            val_19 = null;
            val_21 = WFOManagerGameplay.<>c.<>9__38_0;
            if(val_21 == null)
            {
                    System.Func<System.Boolean> val_14 = null;
                val_21 = val_14;
                val_14 = new System.Func<System.Boolean>(object:  WFOManagerGameplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOManagerGameplay.<>c::<CheckAndShowForestPopup>b__38_0());
                WFOManagerGameplay.<>c.<>9__38_0 = val_21;
            }
            
            val_13[0] = val_21;
            val_22 = null;
            val_22 = null;
            val_16 = 1;
            val_15.SetupMessage(titleTxt:  Localization.Localize(key:  "word_forest_upper", defaultValue:  "WORD FOREST", useSingularKey:  false), messageTxt:  System.String.Format(format:  Localization.Localize(key:  "grow_your_forest", defaultValue:  "Grow Your Forest", useSingularKey:  false), args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), shownButtons:  val_10, buttonTexts:  val_11, showClose:  true, buttonCallbacks:  val_13, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            return (bool)val_16;
        }
        public WFOManagerGameplay()
        {
            this.acornAwardedAnimQueue = new System.Collections.Generic.Queue<System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>>();
        }
    
    }

}
