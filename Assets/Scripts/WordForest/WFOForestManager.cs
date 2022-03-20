using UnityEngine;

namespace WordForest
{
    public class WFOForestManager : MonoSingleton<WordForest.WFOForestManager>
    {
        // Fields
        private System.Collections.Generic.List<WordForest.WFOForestContent> forestContentList;
        private WordForest.WFODigAnimation digAnimationPrefab;
        private UnityEngine.ParticleSystem prefabEfxTreeChoppedSmoke;
        private System.Collections.Generic.List<WordForest.WFOForestData> forestDataList;
        private WordForest.WFOPlayer _player;
        
        // Properties
        public static bool IsFeatureUnlocked { get; }
        public System.Collections.Generic.List<WordForest.WFOForestData> ForestDataList { get; }
        public WordForest.WFOForestData CurrentForestData { get; }
        public WordForest.WFODigAnimation DigAnimationPrefan { get; }
        public UnityEngine.ParticleSystem ChoppedTreeSmokeEfxPrefab { get; }
        public int CurrentForestID { get; }
        public int CurrentForestGrowth { get; }
        public bool CurrentForestContainsDamagedTrees { get; }
        public int CurrentMaxGrowth { get; }
        public int CurrentGrowthCost { get; }
        public int CurrentForestLevel { get; }
        public string CurrentForestName { get; }
        public WordForest.WFOBackgroundType CurrentBGType { get; }
        public bool IsAtMaxGrowth { get; }
        public bool IsForestChestCollected { get; }
        public bool IsAtLastForest { get; }
        public int AffordableGrowthStages { get; }
        private WordForest.WFOPlayer player { get; }
        
        // Methods
        public static bool get_IsFeatureUnlocked()
        {
            WordForest.WFOGameEcon val_2 = WordForest.WFOGameEcon.Instance;
            return (bool)(App.Player >= val_2.wordForestUnlockLevel) ? 1 : 0;
        }
        public System.Collections.Generic.List<WordForest.WFOForestData> get_ForestDataList()
        {
            return (System.Collections.Generic.List<WordForest.WFOForestData>)this.forestDataList;
        }
        public WordForest.WFOForestData get_CurrentForestData()
        {
            WordForest.WFOForestData val_0;
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            var val_5 = null;
            if(val_5 <= (UnityEngine.Mathf.Clamp(value:  val_1.currentForestID - 1, min:  0, max:  W22 - 1)))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + (((long)(int)(val_4)) << 5);
            val_0.level = (null + ((long)(int)(val_4)) << 5) + 32;
            val_0.initialCost = (null + ((long)(int)(val_4)) << 5) + 32 + 16;
            return val_0;
        }
        public WordForest.WFODigAnimation get_DigAnimationPrefan()
        {
            return (WordForest.WFODigAnimation)this.digAnimationPrefab;
        }
        public UnityEngine.ParticleSystem get_ChoppedTreeSmokeEfxPrefab()
        {
            return (UnityEngine.ParticleSystem)this.prefabEfxTreeChoppedSmoke;
        }
        public int get_CurrentForestID()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return (int)val_1.currentForestID;
        }
        public int get_CurrentForestGrowth()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return val_1.forestMapData.CurrentForestGrowth(includeDamagedTrees:  false);
        }
        public bool get_CurrentForestContainsDamagedTrees()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return val_1.forestMapData.ContainsDamagedTrees;
        }
        public int get_CurrentMaxGrowth()
        {
            var val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return (int)val_2;
        }
        public int get_CurrentGrowthCost()
        {
            return this.GetGrowOrFixCost(growthLevel:  this.CurrentForestGrowth);
        }
        public int get_CurrentForestLevel()
        {
            var val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return (int)val_2;
        }
        public string get_CurrentForestName()
        {
            var val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return (string)val_2;
        }
        public WordForest.WFOBackgroundType get_CurrentBGType()
        {
            var val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return (WordForest.WFOBackgroundType)val_2;
        }
        public bool get_IsAtMaxGrowth()
        {
            var val_3;
            WordForest.WFOForestData val_2 = this.CurrentForestData;
            return (bool)(this.CurrentForestGrowth >= val_3) ? 1 : 0;
        }
        public bool get_IsForestChestCollected()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
            return (bool)(val_1.currentForestID <= val_2.currentChestID) ? 1 : 0;
        }
        public bool get_IsAtLastForest()
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            return (bool)(val_1.currentForestID >= this.forestDataList) ? 1 : 0;
        }
        public int get_AffordableGrowthStages()
        {
            var val_4;
            var val_10;
            int val_10 = WordForest.WFOPlayer.Instance.CurrentForestGrowth;
            WordForest.WFOForestData val_3 = this.CurrentForestData;
            if(val_10 < val_4)
            {
                    do
            {
                int val_5 = this.GetGrowOrFixCost(growthLevel:  val_10);
                var val_7 = W22 - ((W22 < val_5) ? 0 : (val_5));
                var val_8 = (W22 >= val_5) ? (0 + 1) : 0;
                val_10 = val_10 + 1;
                WordForest.WFOForestData val_9 = this.CurrentForestData;
            }
            while(val_10 < val_4);
            
                return (int)val_10;
            }
            
            val_10 = 0;
            return (int)val_10;
        }
        private WordForest.WFOPlayer get_player()
        {
            WordForest.WFOPlayer val_3;
            if(this._player == 0)
            {
                    this._player = WordForest.WFOPlayer.Instance;
                return val_3;
            }
            
            val_3 = this._player;
            return val_3;
        }
        public override void InitMonoSingleton()
        {
            WordForest.WFOGameEcon val_1 = App.GetGameSpecificEcon<WordForest.WFOGameEcon>();
            this.forestDataList = val_1.forests;
        }
        public bool CollectForestChest()
        {
            int val_2;
            int val_3;
            WordForest.WFOForestChestData val_1 = this.GetCurrentChestData();
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2, hi = val_2, lo = val_3, mid = val_3}, source:  "Forest Completed", externalParams:  0, animated:  false);
            GoldenApplesManager val_5 = MonoSingleton<GoldenApplesManager>.Instance;
            WordForest.WFOPlayer val_6 = this.player;
            int val_8 = val_6.currentChestID;
            val_8 = val_8 + 1;
            val_6.currentChestID = val_8;
            this.player.SaveState();
            return true;
        }
        public int GetGrowOrFixCost(int growthLevel)
        {
            var val_2;
            var val_3;
            var val_4;
            int val_9 = growthLevel;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            var val_8 = val_3;
            val_8 = val_8 + (val_4 * val_9);
            val_9 = (val_2 > 1) ? 10 : (val_8);
            WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
            if(val_5.forestMapData.GetForestData().CurrentForestContainsDamagedTrees == false)
            {
                    return (int)val_9;
            }
            
            float val_10 = (float)val_9;
            val_10 = val_10 * 0.5f;
            return UnityEngine.Mathf.RoundToInt(f:  val_10);
        }
        public void AddGrowth(int damagedTreeIdToFix = -1, System.Action<bool> onServerResponse)
        {
            var val_7;
            var val_26;
            System.Predicate<T> val_27;
            var val_28;
            var val_29;
            var val_30;
            .damagedTreeIdToFix = damagedTreeIdToFix;
            int val_4 = this.GetGrowOrFixCost(growthLevel:  this.player.CurrentForestGrowth);
            if(damagedTreeIdToFix < val_4)
            {
                goto label_4;
            }
            
            val_26 = val_4.CurrentForestGrowth;
            WordForest.WFOForestData val_6 = this.CurrentForestData;
            if(val_26 >= val_7)
            {
                goto label_4;
            }
            
            WordForest.WFOPlayer val_8 = WordForest.WFOPlayer.Instance;
            System.Collections.Generic.List<WordForest.MapItem> val_9 = val_8.forestMapData.GetForestData();
            int val_27 = (WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix;
            if((val_27 & 2147483648) != 0)
            {
                goto label_7;
            }
            
            System.Predicate<WordForest.MapItem> val_12 = null;
            val_27 = val_12;
            val_12 = new System.Predicate<WordForest.MapItem>(object:  new WFOForestManager.<>c__DisplayClass44_0(), method:  System.Boolean WFOForestManager.<>c__DisplayClass44_0::<AddGrowth>b__0(WordForest.MapItem n));
            var val_26 = 1152921516252519424;
            int val_13 = val_9.FindIndex(match:  val_12);
            val_28 = val_13;
            if((val_13 & 2147483648) != 0)
            {
                goto label_9;
            }
            
            if(val_26 <= val_28)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_26 = val_26 + (val_28 << 3);
            val_29 = 1;
            goto label_23;
            label_4:
            if(onServerResponse == null)
            {
                    return;
            }
            
            onServerResponse.Invoke(obj:  false);
            return;
            label_7:
            val_28 = 0;
            label_9:
            if(val_27 < 1)
            {
                goto label_15;
            }
            
            val_27 = 0;
            label_22:
            if(val_27 <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_27 = val_27 + 0;
            if((System.String.op_Inequality(a:  ((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 16, b:  "tree")) == true)
            {
                goto label_18;
            }
            
            if((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32) <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_30 = (((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32) + 0;
            if(((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 0) + 32 + 28) != 1)
            {
                goto label_21;
            }
            
            label_18:
            val_27 = val_27 + 1;
            if(val_27 < ((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 0) + 32))
            {
                goto label_22;
            }
            
            label_15:
            val_29 = 0;
            goto label_23;
            label_21:
            if(((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 0) + 32 + 28) <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_30 = (((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 0) + 32) + 0) + 32;
            }
            
            if(val_30 <= val_27)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_30 = val_30 + 0;
                val_30 = val_30 + 32;
            }
            
            val_28 = val_27;
            label_23:
            string val_18 = (((((((((((WFOForestManager.<>c__DisplayClass44_0)[1152921518128362448].damagedTreeIdToFix + 0) + 32 + 0) + 32 + 0) + 32) + 0) + 32) + 28) == 2) ? 1 : 0) != 0) ? "Forest Regrowth" : "Forest Growth";
            MonoSingleton<GoldenApplesManager>.Instance.DebitBalance(debitAmount:  this.GetGrowOrFixCost(growthLevel:  val_9.CurrentForestGrowth), source:  val_18, additionalParams:  0);
            if(val_18 <= val_28)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_18 = val_18 + 0;
            mem2[0] = 1;
            this.player.SaveState();
            if(SLC.Social.Leagues.LeaguesManager.DAO != 0)
            {
                    SLC.Social.Leagues.LeaguesManager.DAO.UpdateLocalProfile();
            }
            
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
            MonoSingleton<WordGameEventsController>.Instance.OnForestUpdated();
        }
        public bool ContinueNextForest()
        {
            var val_3;
            var val_13;
            WordForest.WFOForestData val_2 = this.CurrentForestData;
            if(this.CurrentForestGrowth >= val_3)
            {
                    WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
                if(val_4.currentForestID < this.forestDataList)
            {
                    WordForest.WFOPlayer val_5 = this.player;
                int val_13 = val_5.currentForestID;
                val_13 = val_13 + 1;
                val_5.currentForestID = val_13;
                WordForest.WFOPlayer val_6 = this.player;
                WordForest.WFOPlayer val_7 = this.player;
                val_6.forestMapData = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  val_7.currentForestID, growthLevel:  0, growthPercent:  0f, dummyProfile:  false);
                this.player.SaveState();
                MonoSingleton<GameEventsManager>.Instance.CheckAndRequestServerEvents();
                MonoSingleton<WordGameEventsController>.Instance.OnForestComplete(levelsProgressed:  1);
                val_13 = 1;
                MonoSingleton<WordForest.RaidAttackManager>.Instance.Refresh(forced:  true);
                return (bool)val_13;
            }
            
            }
            
            val_13 = 0;
            return (bool)val_13;
        }
        public WordForest.WFOForestChestData GetCurrentChestData()
        {
            WordForest.WFOForestChestData val_0;
            WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
            var val_5 = 1152921518128724816;
            int val_3 = val_1.forestChests.FindIndex(match:  new System.Predicate<WordForest.WFOForestChestData>(object:  this, method:  System.Boolean WordForest.WFOForestManager::<GetCurrentChestData>b__46_0(WordForest.WFOForestChestData c)));
            WordForest.WFOGameEcon val_4 = WordForest.WFOGameEcon.Instance;
            if(val_3 != 1)
            {
                    if(val_5 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + (((long)(int)(val_3)) << 5);
            }
            else
            {
                    if((public System.Int32 System.Collections.Generic.List<WordForest.WFOForestChestData>::FindIndex(System.Predicate<T> match)) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            }
            
            val_0.forestLevel = "h_p";
            val_0.coins.flags = 268435459;
            val_0.coins.hi = "h_p";
            val_0.coins.lo = 268435459;
            val_0.coins.mid = "Type must be a Pointer.";
            val_0.acorns = 268435459;
            val_0.newRewardTypes = null;
            return val_0;
        }
        public WordForest.WFOForestContent GetCurrentForestLayout()
        {
            int val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return this.GetForestLayout(forestId:  val_2);
        }
        public WordForest.WFOForestContent GetForestLayout(int forestId)
        {
            System.Collections.Generic.List<WordForest.WFOForestContent> val_6;
            UnityEngine.Object val_7;
            val_6 = this;
            .forestId = forestId;
            val_7 = this.forestContentList.Find(match:  new System.Predicate<WordForest.WFOForestContent>(object:  new WFOForestManager.<>c__DisplayClass48_0(), method:  System.Boolean WFOForestManager.<>c__DisplayClass48_0::<GetForestLayout>b__0(WordForest.WFOForestContent n)));
            if(val_7 != 0)
            {
                    return (WordForest.WFOForestContent)val_7;
            }
            
            UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Forest Layout Content for forest {0} not found, loading last forest as a failsafe", arg0:  (WFOForestManager.<>c__DisplayClass48_0)[1152921518129097024].forestId));
            val_6 = this.forestContentList;
            if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = mem[1152921505970741272];
            return (WordForest.WFOForestContent)val_7;
        }
        public void AddFTUXAcorn()
        {
            var val_3;
            var val_4;
            var val_10;
            var val_11;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            int val_5 = this.CurrentForestGrowth;
            WordForest.WFOForestData val_8 = this.CurrentForestData;
            var val_18 = this.CurrentForestGrowth;
            val_18 = val_18 + 1;
            GoldenApplesManager val_15 = MonoSingleton<GoldenApplesManager>.Instance;
            var val_16 = ((val_18 == 4) ? 10 : (val_10 + (val_18 * val_11))) + ((val_5 == 4) ? 10 : (val_3 + (val_5 * val_4)));
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnStarsUpdated");
        }
        public void Hack_SetForestLevel(int level)
        {
            int val_1 = UnityEngine.Mathf.Clamp(value:  level, min:  1, max:  41971712);
            WordForest.WFOPlayer val_2 = this.player;
            val_2.currentForestID = val_1;
            WordForest.WFOPlayer val_3 = this.player;
            val_3.forestMapData = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  val_1, growthLevel:  0, growthPercent:  0f, dummyProfile:  false);
            this.player.SaveState();
        }
        public void Hack_SetForestGrowth(int growth)
        {
        
        }
        public WFOForestManager()
        {
        
        }
        private bool <GetCurrentChestData>b__46_0(WordForest.WFOForestChestData c)
        {
            var val_2;
            WordForest.WFOForestData val_1 = this.CurrentForestData;
            return (bool)(c.forestLevel == val_2) ? 1 : 0;
        }
    
    }

}
