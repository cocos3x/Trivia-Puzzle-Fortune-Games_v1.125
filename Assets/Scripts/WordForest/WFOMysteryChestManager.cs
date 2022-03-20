using UnityEngine;

namespace WordForest
{
    public class WFOMysteryChestManager : MonoSingleton<WordForest.WFOMysteryChestManager>
    {
        // Fields
        private const string MysteryChestFTUXKey = "WFOMysteryChestFTUX";
        public const string ON_MYSTERY_CHEST_COLLECTED = "OnMysteryChestCollected";
        private RandomSet chestCountRandomSet;
        private System.Collections.Generic.Dictionary<string, WordForest.ChestLocData> currentChestLocData;
        private bool hack_isForcedRewardAttack;
        private bool hack_isForcedRewardRaid;
        private int hack_islandParadiseSymbolCount;
        
        // Properties
        public static bool IsFeatureUnlocked { get; }
        public int GetLevelIndex { get; }
        public int GetChestCount { get; }
        public int GetCollectedChestCount { get; }
        public int LastMysteryChestCollectedPlayerLvel { get; set; }
        public int Hack_IslandParadiseSymbolCount { get; }
        
        // Methods
        public static bool get_IsFeatureUnlocked()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            return (bool)(val_1.currentForestID >= val_2.mysteryChestUnlockLevel) ? 1 : 0;
        }
        public override void InitMonoSingleton()
        {
            this.chestCountRandomSet.replacement = true;
            this.chestCountRandomSet.add(item:  1, weight:  30f);
            this.chestCountRandomSet.add(item:  2, weight:  40f);
            this.chestCountRandomSet.add(item:  3, weight:  30f);
        }
        public int GetRandomChestCount()
        {
            if(this.IsFTUXCompleted() == false)
            {
                    return 1;
            }
            
            return this.chestCountRandomSet.roll(unweighted:  false);
        }
        public int get_GetLevelIndex()
        {
            int val_2;
            if((this.GetCurrentChestPlacementData(mode:  1)) != null)
            {
                    val_2 = val_1.GameLevel;
                return (int)val_2;
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        public int get_GetChestCount()
        {
            WordForest.ChestLocData val_1 = this.GetCurrentChestPlacementData(mode:  1);
            if(val_1 == null)
            {
                    return (int)val_1;
            }
            
            return (int)val_1;
        }
        public int get_GetCollectedChestCount()
        {
            var val_4;
            var val_5;
            var val_6;
            val_4 = this;
            bool val_4 = true;
            WordForest.ChestLocData val_1 = this.GetCurrentChestPlacementData(mode:  1);
            if(val_1 != null)
            {
                    val_4 = val_1;
                val_5 = 0;
                val_6 = 0;
                do
            {
                if(val_5 >= val_4)
            {
                    return (int)val_6;
            }
            
                if(val_4 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_4 = val_4 + 0;
                val_6 = val_6 + ((true + 0) + 32.Collected);
                val_5 = val_5 + 1;
            }
            while(val_1.ChestsData != null);
            
                throw new NullReferenceException();
            }
            
            val_6 = 0;
            return (int)val_6;
        }
        public int GetWordIndex(int chestIndex)
        {
            var val_2;
            bool val_2 = true;
            if(((this.GetCurrentChestPlacementData(mode:  1)) != null) && (val_2 > chestIndex))
            {
                    if(val_2 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + (chestIndex << 3);
                val_2 = mem[(true + (chestIndex) << 3) + 32 + 16];
                val_2 = (true + (chestIndex) << 3) + 32 + 16;
                return (int)val_2;
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        public int GetCellIndex(int chestIndex)
        {
            var val_2;
            bool val_2 = true;
            if(((this.GetCurrentChestPlacementData(mode:  1)) != null) && (val_2 > chestIndex))
            {
                    if(val_2 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + (chestIndex << 3);
                val_2 = mem[(true + (chestIndex) << 3) + 32 + 20];
                val_2 = (true + (chestIndex) << 3) + 32 + 20;
                return (int)val_2;
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        public int get_LastMysteryChestCollectedPlayerLvel()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "myschst_last_pl", defaultValue:  0);
        }
        private void set_LastMysteryChestCollectedPlayerLvel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "myschst_last_pl", value:  value);
        }
        public System.Collections.Generic.List<int> GetChestsWordIndexes()
        {
            var val_3;
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            if((this.GetCurrentChestPlacementData(mode:  1)) == null)
            {
                    return val_1;
            }
            
            val_3 = 0;
            do
            {
                if(val_3 >= 1152921510062986752)
            {
                    return val_1;
            }
            
                if(1152921510062986752 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1.Add(item:  "java.lang.Short".__il2cppRuntimeField_10>>0&0xFFFFFFFF);
                val_3 = val_3 + 1;
            }
            while(val_2.ChestsData != null);
            
            throw new NullReferenceException();
        }
        public WordForest.ChestLocData GetCurrentChestPlacementData(GameplayMode mode = 1)
        {
            string val_7;
            var val_8;
            System.Collections.Generic.Dictionary<System.String, WordForest.ChestLocData> val_16;
            string val_17;
            var val_18;
            string val_19;
            var val_20;
            val_16 = this;
            if(this.currentChestLocData.Count > 0)
            {
                goto label_31;
            }
            
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "myschst_curr_chstsloc", defaultValue:  0);
            val_17 = val_2;
            val_18 = 0;
            if((System.String.IsNullOrEmpty(value:  val_2)) == true)
            {
                    return (WordForest.ChestLocData)val_18;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.String> val_4 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.String>>(value:  val_17);
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_5 = val_4.GetEnumerator();
            label_9:
            if(val_8.MoveNext() == false)
            {
                goto label_7;
            }
            
            val_17 = val_7;
            if(this.currentChestLocData == null)
            {
                    throw new NullReferenceException();
            }
            
            this.currentChestLocData.set_Item(key:  val_17, value:  new WordForest.ChestLocData(serialized:  val_7));
            goto label_9;
            label_7:
            val_17 = 0;
            val_8.Dispose();
            if(val_17 != 0)
            {
                    throw val_17;
            }
            
            label_31:
            val_19 = mode.ToString();
            if((this.currentChestLocData.ContainsKey(key:  val_19)) != false)
            {
                    val_16 = this.currentChestLocData;
                val_19 = mode;
                WordForest.ChestLocData val_14 = val_16.Item[mode.ToString()];
                return (WordForest.ChestLocData)val_18;
            }
            
            val_18 = 0;
            return (WordForest.ChestLocData)val_18;
            label_32:
            val_20 = val_17;
            if(0 != 1)
            {
                goto label_26;
            }
            
            if((null & 1) == 0)
            {
                goto label_27;
            }
            
            UnityEngine.Debug.LogWarning(message:  "WFOMysteryChestManager: Can\'t read saved chest data. Will create a new one.");
            this.currentChestLocData.Clear();
            goto label_31;
            label_27:
            mem[8] = val_20;
            goto label_32;
            label_26:
        }
        public void SetCurrentChestLocData(GameplayMode mode, int gameLevel, int lineWordIndex, int cellIndex, bool collected, int chestIndex)
        {
            WordForest.ChestLocData val_14;
            var val_15;
            string val_16;
            if((this.currentChestLocData.ContainsKey(key:  mode.ToString())) == false)
            {
                goto label_3;
            }
            
            val_14 = this.currentChestLocData.Item[mode.ToString()];
            if(val_14 != null)
            {
                goto label_6;
            }
            
            label_3:
            WordForest.ChestLocData val_5 = null;
            val_14 = val_5;
            val_5 = new WordForest.ChestLocData();
            label_6:
            .GameLevel = gameLevel;
            WordForest.ChestData val_7 = new WordForest.ChestData(wordIndex:  lineWordIndex, cellIndex:  cellIndex, isCollected:  collected);
            if(mode > chestIndex)
            {
                    (WordForest.ChestLocData)[1152921518171121856].ChestsData.set_Item(index:  chestIndex, value:  val_7);
            }
            else
            {
                    (WordForest.ChestLocData)[1152921518171121856].ChestsData.Add(item:  val_7);
            }
            
            this.currentChestLocData.set_Item(key:  mode.ToString(), value:  val_5);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Dictionary.Enumerator<TKey, TValue> val_10 = this.currentChestLocData.GetEnumerator();
            label_19:
            val_15 = public System.Boolean Dictionary.Enumerator<System.String, WordForest.ChestLocData>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_15;
            }
            
            val_16 = 0;
            if(val_16 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = mem[282584257677031];
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = 0;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9.Add(key:  val_16, value:  0.Serialize());
            goto label_19;
            label_15:
            0.Dispose();
            UnityEngine.PlayerPrefs.SetString(key:  "myschst_curr_chstsloc", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_9));
        }
        public void ClearChestLocData(GameplayMode mode)
        {
            var val_8;
            string val_9;
            bool val_2 = this.currentChestLocData.Remove(key:  mode.ToString());
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            Dictionary.Enumerator<TKey, TValue> val_4 = this.currentChestLocData.GetEnumerator();
            label_8:
            val_8 = public System.Boolean Dictionary.Enumerator<System.String, WordForest.ChestLocData>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            val_9 = 0;
            if(val_9 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = mem[282584257677031];
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = 0;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_3.Add(key:  val_9, value:  0.Serialize());
            goto label_8;
            label_4:
            0.Dispose();
            UnityEngine.PlayerPrefs.SetString(key:  "myschst_curr_chstsloc", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_3));
        }
        public System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>> OpenMysteryChest(int chestCount, out System.Collections.Generic.List<WordForest.WFOWordChestType> chestTypeSet)
        {
            var val_12;
            var val_13;
            WordForest.WFOWordChestType val_14;
            System.Collections.Generic.List<WordForest.WFOWordChestType> val_1 = new System.Collections.Generic.List<WordForest.WFOWordChestType>();
            chestTypeSet = val_1;
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                goto label_1;
            }
            
            RandomSet val_3 = new RandomSet();
            .replacement = true;
            WordForest.WFOGameEcon val_4 = WordForest.WFOGameEcon.Instance;
            Dictionary.Enumerator<TKey, TValue> val_5 = val_4.wordChestWeight.GetEnumerator();
            val_12 = 1152921518171418800;
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_5;
            }
            
            val_3.add(item:  0, weight:  0f);
            goto label_6;
            label_1:
            val_1.Add(item:  0);
            val_13 = 0;
            return (System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>)val_13;
            label_5:
            0.Dispose();
            if(chestCount >= 1)
            {
                    do
            {
                WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
                if((MonoExtensions.IsBitSet(value:  val_7.tutorialCompleted, bit:  9)) != false)
            {
                    val_14 = val_3.roll(unweighted:  false);
            }
            else
            {
                    val_14 = 1;
            }
            
                val_1.Add(item:  val_14);
                val_12 = 0 + 1;
            }
            while(val_12 < chestCount);
            
            }
            
            val_13 = this.GetRandomRewardForChest(chestTypeSet:  val_1, isMystery:  true);
            int val_11 = PlayingLevel.GetCurrentPlayerLevelNumber();
            val_11.LastMysteryChestCollectedPlayerLvel = val_11;
            return (System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>)val_13;
        }
        public System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>> GetRandomRewardForChest(System.Collections.Generic.List<WordForest.WFOWordChestType> chestTypeSet, bool isMystery)
        {
            var val_86;
            var val_87;
            int val_88;
            var val_89;
            WordForest.WFORewardType val_90;
            var val_91;
            System.Collections.Generic.IList<T> val_92;
            int val_93;
            var val_94;
            var val_95;
            var val_96;
            System.Predicate<WordForest.WFORewardData> val_98;
            var val_99;
            var val_100;
            System.Predicate<WordForest.WFORewardData> val_102;
            int val_104;
            int val_105;
            var val_106;
            var val_107;
            var val_108;
            var val_109;
            bool val_110;
            var val_111;
            string val_112;
            var val_113;
            var val_114;
            if((chestTypeSet == null) || (==0))
            {
                goto label_2;
            }
            
            System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>> val_1 = null;
            val_87 = val_1;
            val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>();
            if(41975808 <= 0)
            {
                goto label_3;
            }
            
            var val_87 = 15084;
            goto label_107;
            label_2:
            val_87 = 0;
            return (System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>)val_87;
            label_94:
            if(this.hack_islandParadiseSymbolCount < 1)
            {
                goto label_88;
            }
            
            var val_86 = 0;
            do
            {
                WordForest.WFORewardData val_2 = new WordForest.WFORewardData(rType:  7, rAmt:  1);
                val_88 = public System.Void System.Collections.Generic.List<WordForest.WFORewardData>::set_Item(int index, WordForest.WFORewardData value);
                X25.set_Item(index:  0, value:  new WordForest.WFORewardData() {id = val_2.id, amount = new System.Decimal() {flags = val_2.rewardType, hi = val_2.rewardType, lo = val_2.rewardType}});
                val_86 = val_86 + 1;
            }
            while(val_86 < this.hack_islandParadiseSymbolCount);
            
            goto label_88;
            label_100:
            val_89 = mem[X25 + 24];
            val_89 = X25 + 24;
            val_90 = 5;
            val_91 = 1;
            goto label_11;
            label_107:
            WordForest.WFOGameEcon val_3 = WordForest.WFOGameEcon.Instance;
            if(0 >= val_87)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_87 = val_87 + 0;
            int val_4 = val_3.wordChestRewardAmount.Item[(15084 + 0) + 32];
            WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
            WordForest.WFOGameEcon val_7 = WordForest.WFOGameEcon.Instance;
            WordForest.WFOGameEcon val_9 = WordForest.WFOGameEcon.Instance;
            if((val_7.mysteryRewards.ContainsKey(key:  val_6.currentForestID)) != false)
            {
                    System.Collections.Generic.List<WordForest.WFORewardData> val_11 = null;
                val_92 = val_11;
                val_11 = new System.Collections.Generic.List<WordForest.WFORewardData>(collection:  val_9.mysteryRewards.Item[val_6.currentForestID]);
            }
            else
            {
                    int val_13 = System.Linq.Enumerable.Last<System.Int32>(source:  val_9.mysteryRewards.Keys);
                WordForest.WFOGameEcon val_14 = WordForest.WFOGameEcon.Instance;
                System.Collections.Generic.List<WordForest.WFORewardData> val_17 = null;
                val_92 = val_17;
                val_17 = new System.Collections.Generic.List<WordForest.WFORewardData>(collection:  val_14.mysteryRewards.Item[UnityEngine.Mathf.Min(a:  val_13, b:  val_6.currentForestID)]);
                object[] val_18 = new object[4];
                val_18[0] = "[MysteryChest] Cannot find reward data for forest ";
                val_93 = val_18.Length;
                val_18[1] = val_6.currentForestID;
                val_93 = val_18.Length;
                val_18[2] = " defaulting to ";
                val_18[3] = UnityEngine.Mathf.Min(a:  val_13, b:  val_6.currentForestID);
                UnityEngine.Debug.LogWarning(message:  +val_18);
            }
            
            if(IslandParadiseEventHandler.IsEventActive != false)
            {
                    if(IslandParadiseEventHandler._Instance.HasCollectedAllRewards() != true)
            {
                    WordForest.WFORewardData val_23 = new WordForest.WFORewardData(rType:  7, rAmt:  1);
                val_17.Add(item:  new WordForest.WFORewardData() {id = val_23.id, amount = new System.Decimal() {flags = val_23.rewardType, hi = val_23.rewardType, lo = val_23.rewardType}});
                WordForest.WFORewardData val_24 = new WordForest.WFORewardData(rType:  7, rAmt:  1);
                val_17.Add(item:  new WordForest.WFORewardData() {id = val_24.id, amount = new System.Decimal() {flags = val_24.rewardType, hi = val_24.rewardType, lo = val_24.rewardType}});
                WordForest.WFORewardData val_25 = new WordForest.WFORewardData(rType:  7, rAmt:  1);
                val_17.Add(item:  new WordForest.WFORewardData() {id = val_25.id, amount = new System.Decimal() {flags = val_25.rewardType, hi = val_25.rewardType, lo = val_25.rewardType}});
            }
            
            }
            
            PluginExtension.Shuffle<WordForest.WFORewardData>(list:  val_17, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            RandomSet val_26 = new RandomSet();
            if(1152921504858656768 < 1)
            {
                goto label_47;
            }
            
            var val_88 = 0;
            label_66:
            WordForest.WFOPlayer val_27 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_27.tutorialCompleted, bit:  9)) == false)
            {
                goto label_49;
            }
            
            label_65:
            if(val_88 >= 1152921504858656768)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_5.shields >= WordForest.WFOGameEcon.Instance.MaxShields)
            {
                goto label_63;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(this.hack_islandParadiseSymbolCount != 1)
            {
                goto label_63;
            }
            
            val_26.add(item:  0, weight:  1f);
            goto label_63;
            label_49:
            if(val_88 >= 1152921504858656768)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_88 >= true)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_94 = mem[1152921504858656768.__il2cppRuntimeField_24 + 36];
                val_94 = 1152921504858656768.__il2cppRuntimeField_24 + 36;
            }
            
            if(val_94 == 4)
            {
                goto label_63;
            }
            
            if(val_88 >= true)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_94 = mem[1152921504858656768.__il2cppRuntimeField_24 + 36 + 36];
                val_94 = 1152921504858656768.__il2cppRuntimeField_24 + 36 + 36;
            }
            
            if(val_94 != 6)
            {
                goto label_65;
            }
            
            label_63:
            val_88 = val_88 + 1;
            var val_31 = 36 + 28;
            if(val_88 < val_94)
            {
                goto label_66;
            }
            
            label_47:
            System.Collections.Generic.List<WordForest.WFORewardData> val_32 = null;
            var val_89 = 1152921518144890864;
            val_32 = new System.Collections.Generic.List<WordForest.WFORewardData>();
            if(val_4 >= 1)
            {
                    var val_90 = 0;
                do
            {
                int val_33 = val_26.roll(unweighted:  false);
                if(val_89 <= val_33)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_89 = val_89 + (val_33 * 28);
                val_32.Add(item:  new WordForest.WFORewardData() {id = (val_33 * 28) + 1152921518144890864 + 32, rewardType = (val_33 * 28) + 1152921518144890864 + 32, amount = new System.Decimal() {flags = (val_33 * 28) + 1152921518144890864 + 32, hi = (val_33 * 28) + 1152921518144890864 + 32, lo = (val_33 * 28) + 1152921518144890864 + 32}});
                val_90 = val_90 + 1;
            }
            while(val_90 < val_4);
            
            }
            
            if(this.hack_isForcedRewardAttack == false)
            {
                goto label_72;
            }
            
            val_95 = 41975808;
            val_96 = null;
            val_96 = null;
            val_98 = WFOMysteryChestManager.<>c.<>9__24_0;
            if(val_98 == null)
            {
                    System.Predicate<WordForest.WFORewardData> val_34 = null;
                val_98 = val_34;
                val_88 = public System.Void System.Predicate<WordForest.WFORewardData>::.ctor(object object, IntPtr method);
                val_34 = new System.Predicate<WordForest.WFORewardData>(object:  WFOMysteryChestManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestManager.<>c::<GetRandomRewardForChest>b__24_0(WordForest.WFORewardData n));
                WFOMysteryChestManager.<>c.<>9__24_0 = val_98;
            }
            
            if((val_32.FindIndex(match:  val_34)) != 1)
            {
                goto label_88;
            }
            
            val_99 = 6;
            goto label_80;
            label_72:
            val_95 = 41975808;
            if(this.hack_isForcedRewardRaid == false)
            {
                goto label_81;
            }
            
            val_100 = null;
            val_100 = null;
            val_102 = WFOMysteryChestManager.<>c.<>9__24_1;
            if(val_102 == null)
            {
                    System.Predicate<WordForest.WFORewardData> val_36 = null;
                val_102 = val_36;
                val_88 = public System.Void System.Predicate<WordForest.WFORewardData>::.ctor(object object, IntPtr method);
                val_36 = new System.Predicate<WordForest.WFORewardData>(object:  WFOMysteryChestManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestManager.<>c::<GetRandomRewardForChest>b__24_1(WordForest.WFORewardData n));
                WFOMysteryChestManager.<>c.<>9__24_1 = val_102;
            }
            
            if((val_32.FindIndex(match:  val_36)) != 1)
            {
                goto label_88;
            }
            
            val_99 = 5;
            label_80:
            WordForest.WFORewardData val_38 = new WordForest.WFORewardData(rType:  5, rAmt:  1);
            val_88 = public System.Void System.Collections.Generic.List<WordForest.WFORewardData>::set_Item(int index, WordForest.WFORewardData value);
            val_104 = 0;
            goto label_89;
            label_81:
            if(this.hack_islandParadiseSymbolCount != 1)
            {
                    if(IslandParadiseEventHandler.IsEventActive != false)
            {
                    if(IslandParadiseEventHandler._Instance.HasCollectedAllRewards() == false)
            {
                goto label_94;
            }
            
            }
            
            }
            
            WordForest.WFOPlayer val_41 = WordForest.WFOPlayer.Instance;
            var val_91 = 0;
            val_91 = val_91 | (MonoExtensions.IsBitSet(value:  val_41.tutorialCompleted, bit:  10));
            if(val_91 == false)
            {
                goto label_96;
            }
            
            WordForest.WFOPlayer val_43 = WordForest.WFOPlayer.Instance;
            var val_92 = 0;
            val_92 = val_92 | (MonoExtensions.IsBitSet(value:  val_43.tutorialCompleted, bit:  8));
            if(val_92 == false)
            {
                goto label_98;
            }
            
            WordForest.WFOPlayer val_45 = WordForest.WFOPlayer.Instance;
            bool val_46 = MonoExtensions.IsBitSet(value:  val_45.tutorialCompleted, bit:  9);
            bool val_93 = true;
            if((val_46 | val_93) == false)
            {
                goto label_100;
            }
            
            val_93 = val_93 | val_46 ^ 1;
            if(val_87 != null)
            {
                goto label_101;
            }
            
            label_96:
            val_90 = 6;
            val_91 = 1;
            label_11:
            WordForest.WFORewardData val_49 = new WordForest.WFORewardData(rType:  val_90, rAmt:  1);
            val_88 = public System.Void System.Collections.Generic.List<WordForest.WFORewardData>::set_Item(int index, WordForest.WFORewardData value);
            goto label_104;
            label_98:
            WordForest.WFORewardData val_50 = new WordForest.WFORewardData(rType:  4, rAmt:  1);
            val_32.set_Item(index:  0, value:  new WordForest.WFORewardData() {id = val_50.id, rewardType = (val_33 * 28) + 1152921518144890864 + 32, amount = new System.Decimal() {flags = val_50.rewardType, hi = val_50.rewardType, lo = val_50.rewardType}});
            WordForest.WFORewardData val_51 = new WordForest.WFORewardData(rType:  6, rAmt:  1);
            val_88 = public System.Void System.Collections.Generic.List<WordForest.WFORewardData>::set_Item(int index, WordForest.WFORewardData value);
            label_104:
            val_104 = val_33 - 1;
            label_89:
            val_32.set_Item(index:  val_104, value:  new WordForest.WFORewardData() {id = val_51.id, rewardType = (val_33 * 28) + 1152921518144890864 + 32, amount = new System.Decimal() {flags = val_51.rewardType, hi = val_51.rewardType, lo = val_51.rewardType}});
            label_88:
            label_101:
            val_1.Add(item:  val_32);
            val_105 = 1;
            if(val_105 < val_95)
            {
                goto label_107;
            }
            
            if(val_95 < 1)
            {
                goto label_108;
            }
            
            val_106 = 0;
            val_107 = 0;
            do
            {
                val_95 = 0;
                val_108 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_105 = 41975808;
                if(IslandParadiseEventHandler.IsEventActive != false)
            {
                    if(IslandParadiseEventHandler._Instance.HasCollectedAllRewards() != true)
            {
                    IslandParadiseEventHandler._Instance.RewardPointsFromSymbols(symbolAmount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_55.flags, hi = val_55.hi, lo = val_55.lo, mid = val_55.mid}));
            }
            
            }
            
            }
            while((0 + 1) < val_105);
            
            goto label_150;
            label_3:
            val_107 = 0;
            val_106 = 0;
            goto label_150;
            label_108:
            val_107 = 0;
            val_106 = 0;
            label_150:
            val_109 = null;
            val_110 = isMystery;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    WordForest.WFOPlayer val_61 = WordForest.WFOPlayer.Instance;
                val_61.starsLevelBalance = (System.Decimal.op_Explicit(value:  new System.Decimal())) + val_61.starsLevelBalance;
                WordForest.WFOPlayer val_65 = WordForest.WFOPlayer.Instance;
                if( != false)
            {
                    val_105 = val_65.playingStarsFromMC;
                val_65.playingStarsFromMC = (System.Decimal.op_Explicit(value:  new System.Decimal())) + val_105;
            }
            else
            {
                    val_105 = val_65.playingStarsFromFC;
                val_65.playingStarsFromFC = (System.Decimal.op_Explicit(value:  new System.Decimal())) + val_105;
            }
            
            }
            
            val_111 = null;
            val_111 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    val_112 = mem[val_110 != true ? "Mystery Chest" : "Forest Chest"];
                val_112 = ( != true) ? "Mystery Chest" : "Forest Chest";
                App.Player.AddCredits(amount:  new System.Decimal(), source:  val_112, subSource:  0, externalParams:  0, doTrack:  true);
            }
            
            val_113 = null;
            val_86 = 0;
            val_114 = 0;
            val_113 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
            {
                    return (System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>)val_87;
            }
            
            WordForest.WFOPlayer val_74 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_75 = WordForest.WFOPlayer.Instance;
            val_74.shields = UnityEngine.Mathf.Clamp(value:  (System.Decimal.op_Explicit(value:  new System.Decimal())) + val_75.shields, min:  0, max:  WordForest.WFOGameEcon.Instance.MaxShields);
            val_110 = isMystery;
            WordForest.WFOPlayer val_82 = WordForest.WFOPlayer.Instance;
            MonoSingleton<WordForest.RaidAttackManager>.Instance.SetShields(amount:  val_82.shields);
            val_86 = WordForest.WFOPlayer.Instance;
            val_114 = "Mystery Chest";
            val_86.TrackNonCoinReward(source:  (val_110 != true) ? (val_114) : "Forest Chest", subSource:  0, rewardType:  "Shield", rewardAmount:  0.ToString(), additionalParams:  0);
            return (System.Collections.Generic.List<System.Collections.Generic.List<WordForest.WFORewardData>>)val_87;
        }
        public bool IsFTUXCompleted()
        {
            return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "WFOMysteryChestFTUX", defaultValue:  0)) != 1) ? 1 : 0;
        }
        public void CompleteFTUX()
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "WFOMysteryChestFTUX", value:  1);
        }
        public void Hack_ForceRewardAttack()
        {
            this.hack_isForcedRewardAttack = true;
        }
        public void Hack_ForceRewardRaid()
        {
            this.hack_isForcedRewardRaid = true;
        }
        public int get_Hack_IslandParadiseSymbolCount()
        {
            return (int)this.hack_islandParadiseSymbolCount;
        }
        public void Hack_ForceIslandParadiseSymbolCount(int value)
        {
            this.hack_islandParadiseSymbolCount = UnityEngine.Mathf.Clamp(value:  value, min:  0, max:  3);
        }
        public void Hack_ClearForcedReward()
        {
            this.hack_isForcedRewardAttack = false;
            this.hack_isForcedRewardRaid = false;
            this.hack_islandParadiseSymbolCount = 0;
        }
        public string Hack_ChestRewardHackStatus()
        {
            string val_6;
            if((this.hack_isForcedRewardAttack != true) && (this.hack_isForcedRewardRaid != true))
            {
                    if(this.hack_islandParadiseSymbolCount == 1)
            {
                    return (string)val_1;
            }
            
            }
            
            System.Text.StringBuilder val_1 = null;
            val_6 = 0;
            val_1 = new System.Text.StringBuilder();
            if(this.hack_isForcedRewardRaid != false)
            {
                    val_6 = "Raid | ";
                System.Text.StringBuilder val_2 = val_1.Append(value:  val_6);
            }
            
            if(this.hack_isForcedRewardAttack != false)
            {
                    val_6 = "Atk | ";
                System.Text.StringBuilder val_3 = val_1.Append(value:  val_6);
            }
            
            if(this.hack_islandParadiseSymbolCount != 1)
            {
                    val_6 = "Island " + this.hack_islandParadiseSymbolCount + "| "("| ");
                System.Text.StringBuilder val_5 = val_1.Append(value:  val_6);
            }
            
            return (string)val_1;
        }
        public WFOMysteryChestManager()
        {
            this.chestCountRandomSet = new RandomSet();
            this.currentChestLocData = new System.Collections.Generic.Dictionary<System.String, WordForest.ChestLocData>();
            this.hack_islandParadiseSymbolCount = 0;
        }
    
    }

}
