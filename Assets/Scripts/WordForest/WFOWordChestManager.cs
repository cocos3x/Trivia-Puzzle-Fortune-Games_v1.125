using UnityEngine;

namespace WordForest
{
    public class WFOWordChestManager : MonoSingleton<WordForest.WFOWordChestManager>
    {
        // Fields
        public System.Action OnWordChestUpdated;
        
        // Properties
        public static bool IsFeatureUnlocked { get; }
        public bool IsChestReady { get; }
        public WordForest.WFOWordChestType CurrentWordChestType { get; }
        public int CurrentWordsRequired { get; }
        public int CurrentWordsCompleted { get; set; }
        public int LastForestChestCollectedPlayerLvel { get; set; }
        
        // Methods
        public static bool get_IsFeatureUnlocked()
        {
            return false;
        }
        public bool get_IsChestReady()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            return (bool)(val_1.currentWordChestWordCompleted >= val_2.currentWordChestWordRequired) ? 1 : 0;
        }
        public WordForest.WFOWordChestType get_CurrentWordChestType()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return (WordForest.WFOWordChestType)val_1.currentWordChestType;
        }
        public int get_CurrentWordsRequired()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return (int)val_1.currentWordChestWordRequired;
        }
        public int get_CurrentWordsCompleted()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return (int)val_1.currentWordChestWordCompleted;
        }
        protected void set_CurrentWordsCompleted(int value)
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            val_1.currentWordChestWordCompleted = value;
        }
        public int get_LastForestChestCollectedPlayerLvel()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "forchst_last_pl", defaultValue:  0);
        }
        private void set_LastForestChestCollectedPlayerLvel(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "forchst_last_pl", value:  value);
        }
        public override void InitMonoSingleton()
        {
            this.Init();
        }
        private void InitNewRandomData()
        {
            RandomSet val_1 = new RandomSet();
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            Dictionary.Enumerator<TKey, TValue> val_3 = val_2.wordChestWeight.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.add(item:  0, weight:  0f);
            goto label_5;
            label_3:
            0.Dispose();
            int val_5 = val_1.roll(unweighted:  false);
            val_5.InitNewData(chestType:  val_5);
        }
        private void InitNewData(WordForest.WFOWordChestType chestType)
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            val_1.currentWordChestType = chestType;
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            val_1.currentWordChestWordRequired = val_2.wordChestRequiredWords.Item[chestType];
            val_1.currentWordChestWordCompleted = 0;
        }
        private void Init()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if(val_1.currentWordChestType != 0)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_2.tutorialCompleted, bit:  1)) != false)
            {
                    return;
            }
            
            WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
            if(val_4.currentForestID > val_5.rewardWordChestUnlockLevel)
            {
                    WordForest.WFOPlayer val_6 = WordForest.WFOPlayer.Instance;
                if((MonoExtensions.IsBitSet(value:  val_6.tutorialCompleted, bit:  9)) != false)
            {
                    this.InitNewRandomData();
                return;
            }
            
            }
            
            WordForest.WFOGameEcon.Instance.InitNewData(chestType:  1);
        }
        public void IncrementWord()
        {
        
        }
        public System.Collections.Generic.List<WordForest.WFORewardData> OpenChest()
        {
            return 0;
        }
        public WFOWordChestManager()
        {
        
        }
    
    }

}
