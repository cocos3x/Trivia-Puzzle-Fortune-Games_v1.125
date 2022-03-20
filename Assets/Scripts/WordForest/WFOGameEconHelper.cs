using UnityEngine;

namespace WordForest
{
    public class WFOGameEconHelper
    {
        // Fields
        private static System.Collections.Generic.List<WordForest.WFOForestData> _forests;
        
        // Properties
        public static System.Collections.Generic.List<WordForest.WFOForestData> Forests { get; }
        
        // Methods
        public static System.Collections.Generic.List<WordForest.WFOForestData> get_Forests()
        {
            var val_2;
            System.Collections.Generic.List<WordForest.WFOForestData> val_3;
            var val_4;
            if(WordForest.WFOGameEconHelper._forests != null)
            {
                    return (System.Collections.Generic.List<WordForest.WFOForestData>)WordForest.WFOGameEconHelper._forests;
            }
            
            val_2 = null;
            val_2 = null;
            if(App.game == 18)
            {
                    WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
                val_3 = val_1.forests;
            }
            else
            {
                    val_4 = null;
                val_4 = null;
                val_3 = 1152921504916009000;
            }
            
            WordForest.WFOGameEconHelper._forests = val_3;
            return (System.Collections.Generic.List<WordForest.WFOForestData>)WordForest.WFOGameEconHelper._forests;
        }
        public static WordForest.WFOForestData GetForestEconData(int forestId)
        {
            .forestId = forestId;
            return WordForest.WFOGameEconHelper.Forests.Find(match:  new System.Predicate<WordForest.WFOForestData>(object:  new WFOGameEconHelper.<>c__DisplayClass3_0(), method:  System.Boolean WFOGameEconHelper.<>c__DisplayClass3_0::<GetForestEconData>b__0(WordForest.WFOForestData n)));
        }
        public static System.Collections.Generic.List<WordForest.WFORewardData> GetMysteryRewards(int acornSmall, int acornMedium, int acornLarge, int coinSmall, int coinMedium)
        {
            System.Collections.Generic.List<WordForest.WFORewardData> val_1 = new System.Collections.Generic.List<WordForest.WFORewardData>();
            WordForest.WFORewardData val_2 = new WordForest.WFORewardData(rType:  5, rAmt:  1);
            val_1.Add(item:  new WordForest.WFORewardData() {id = val_2.id, amount = new System.Decimal() {flags = val_2.rewardType, hi = val_2.rewardType, lo = val_2.rewardType}, transformToId = ???});
            WordForest.WFORewardData val_3 = new WordForest.WFORewardData(rType:  6, rAmt:  1);
            val_1.Add(item:  new WordForest.WFORewardData() {id = val_3.id, amount = new System.Decimal() {flags = val_3.rewardType, hi = val_3.rewardType, lo = val_3.rewardType}, transformToId = ???});
            WordForest.WFORewardData val_4 = new WordForest.WFORewardData(rType:  4, rAmt:  1);
            val_1.Add(item:  new WordForest.WFORewardData() {id = val_4.id, amount = new System.Decimal() {flags = val_4.rewardType, hi = val_4.rewardType, lo = val_4.rewardType}, transformToId = ???});
            do
            {
                WordForest.WFORewardData val_5 = new WordForest.WFORewardData(rType:  1, rAmt:  acornSmall);
                val_1.Add(item:  new WordForest.WFORewardData() {id = val_5.id, amount = new System.Decimal() {flags = val_5.rewardType, hi = val_5.rewardType, lo = val_5.rewardType}, transformToId = ???});
                var val_6 = 5 - 1;
            }
            while();
            
            var val_11 = 3;
            do
            {
                WordForest.WFORewardData val_7 = new WordForest.WFORewardData(rType:  1, rAmt:  acornMedium);
                val_1.Add(item:  new WordForest.WFORewardData() {id = val_7.id, amount = new System.Decimal() {flags = val_7.rewardType, hi = val_7.rewardType, lo = val_7.rewardType}, transformToId = ???});
                val_11 = val_11 - 1;
            }
            while();
            
            WordForest.WFORewardData val_8 = new WordForest.WFORewardData(rType:  1, rAmt:  acornLarge);
            val_1.Add(item:  new WordForest.WFORewardData() {id = val_8.id, amount = new System.Decimal() {flags = val_8.rewardType, hi = val_8.rewardType, lo = val_8.rewardType}, transformToId = ???});
            var val_12 = 2;
            do
            {
                WordForest.WFORewardData val_9 = new WordForest.WFORewardData(rType:  2, rAmt:  coinSmall);
                val_1.Add(item:  new WordForest.WFORewardData() {id = val_9.id, amount = new System.Decimal() {flags = val_9.rewardType, hi = val_9.rewardType, lo = val_9.rewardType}, transformToId = ???});
                val_12 = val_12 - 1;
            }
            while();
            
            WordForest.WFORewardData val_10 = new WordForest.WFORewardData(rType:  2, rAmt:  coinMedium);
            val_1.Add(item:  new WordForest.WFORewardData() {id = val_10.id, amount = new System.Decimal() {flags = val_10.rewardType, hi = val_10.rewardType, lo = val_10.rewardType}, transformToId = ???});
            return val_1;
        }
        public static WordForest.Map MapDataV1ToV2Migration(int oldForestId, int oldForestGrowth)
        {
            var val_6;
            bool val_6 = true;
            val_6 = WordForest.WFOGameEconHelper.Forests;
            if(val_6 <= oldForestId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (((long)(int)(oldForestId)) << 5);
            System.Collections.Generic.List<WordForest.MapItem> val_2 = new System.Collections.Generic.List<WordForest.MapItem>();
            if(((true + ((long)(int)(oldForestId)) << 5) + 56) < 1)
            {
                    return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
            }
            
            do
            {
                val_2.Add(item:  new WordForest.MapItem(mType:  "tree", mId:  0, mStatus:  (0 < oldForestGrowth) ? 1 : 0));
                val_6 = 0 + 1;
            }
            while(val_6 < ((true + ((long)(int)(oldForestId)) << 5) + 56));
            
            return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
        }
        public static WordForest.Map CreateStartingMap()
        {
            return WordForest.WFOGameEconHelper.CreateMap(forestLevel:  1, growthLevel:  0, growthPercent:  0f, dummyProfile:  false);
        }
        public static WordForest.Map CreateMap(int forestLevel, int growthLevel = 0, float growthPercent = 0, bool dummyProfile = False)
        {
            WordForest.MapItem val_14;
            var val_15;
            val_14 = growthLevel;
            .forestLevel = forestLevel;
            System.Collections.Generic.List<WordForest.MapItem> val_2 = new System.Collections.Generic.List<WordForest.MapItem>();
            var val_14 = 1152921516241408720;
            int val_5 = WordForest.WFOGameEconHelper.Forests.FindIndex(match:  new System.Predicate<WordForest.WFOForestData>(object:  new WFOGameEconHelper.<>c__DisplayClass7_0(), method:  System.Boolean WFOGameEconHelper.<>c__DisplayClass7_0::<CreateMap>b__0(WordForest.WFOForestData n)));
            if((val_5 & 2147483648) == 0)
            {
                    System.Collections.Generic.List<WordForest.WFOForestData> val_6 = WordForest.WFOGameEconHelper.Forests;
                if(val_14 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_14 = val_14 + (((long)(int)(val_5)) << 5);
                val_15 = mem[(1152921516241408720 + ((long)(int)(val_5)) << 5) + 56];
                val_15 = (1152921516241408720 + ((long)(int)(val_5)) << 5) + 56;
            }
            else
            {
                    val_15 = 20;
            }
            
            if((val_14 <= 0) && (growthPercent > 0f))
            {
                    float val_7 = UnityEngine.Mathf.Clamp(value:  growthPercent, min:  0f, max:  1f);
                val_7 = val_7 * 20f;
                val_14 = UnityEngine.Mathf.FloorToInt(f:  val_7);
            }
            
            var val_9 = (val_14 > 2) ? 1 : 0;
            val_9 = val_9 | (~dummyProfile);
            if(20 < 1)
            {
                    return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
            }
            
            var val_15 = 0;
            do
            {
                WordForest.MapItem val_12 = null;
                val_14 = val_12;
                val_12 = new WordForest.MapItem(mType:  "tree", mId:  0, mStatus:  (val_15 < ((val_9 != true) ? (val_14) : 3)) ? 1 : 0);
                val_2.Add(item:  val_12);
                val_15 = val_15 + 1;
            }
            while(val_15 < 20);
            
            return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
        }
        public static UnityEngine.Vector2Int GetRaidEligibleAcornsMinMax(int forestLevel)
        {
            var val_6;
            var val_7;
            var val_13;
            WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
            if((val_1.raidEligibleAcornsMinMax.ContainsKey(key:  forestLevel)) == false)
            {
                goto label_3;
            }
            
            val_13 = forestLevel;
            goto label_13;
            label_3:
            WordForest.WFOGameEcon val_3 = WordForest.WFOGameEcon.Instance;
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_5 = val_3.raidEligibleAcornsMinMax.Keys.GetEnumerator();
            val_13 = 2;
            goto label_8;
            label_9:
            label_8:
            if(val_7.MoveNext() == true)
            {
                goto label_9;
            }
            
            val_7.Dispose();
            label_13:
            WordForest.WFOGameEcon val_10 = WordForest.WFOGameEcon.Instance;
            UnityEngine.Vector2Int val_11 = val_10.raidEligibleAcornsMinMax.Item[(val_6 <= forestLevel) ? (val_13) : (val_6)];
            return new UnityEngine.Vector2Int() {m_X = val_11.m_X, m_Y = val_11.m_Y};
        }
        public static int GetRandomRaidEligibleAcorns(int forestLevel)
        {
            UnityEngine.Vector2Int val_1 = WordForest.WFOGameEconHelper.GetRaidEligibleAcornsMinMax(forestLevel:  forestLevel);
            int val_4 = val_1.m_X.y - val_1.m_X.x;
            val_4 = val_4 >> 32;
            int val_9 = UnityEngine.Random.Range(min:  0, max:  (val_4 + (val_4 >> 63)) + 1);
            val_9 = val_1.m_X.x + (val_9 * 6);
            return (int)val_9;
        }
        public static System.Collections.Generic.List<int> GeneratePickerOptionsFromEligibleAcorns(int eligibleAcorns)
        {
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            val_1.Add(item:  0);
            val_1.Add(item:  0);
            val_1.Add(item:  0);
            val_1.Add(item:  0);
            PluginExtension.Shuffle<System.Int32>(list:  val_1, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            return val_1;
        }
        public WFOGameEconHelper()
        {
        
        }
    
    }

}
