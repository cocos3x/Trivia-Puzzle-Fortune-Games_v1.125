using UnityEngine;
public class TRVCategoryRankController
{
    // Methods
    public static void ProcessCategoryRank(string categoryName, TRVSubCategoryProgress subcategoryProgress)
    {
        int val_15;
        string val_16;
        val_15 = subcategoryProgress;
        val_16 = categoryName;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(subcategoryProgress.rank == val_1.TRVCategoryRankEcon.Count)
        {
                return;
        }
        
        int val_3 = subcategoryProgress.rankProgress + 1;
        subcategoryProgress.rankProgress = val_3;
        int val_4 = subcategoryProgress.rank + 1;
        TRVCategoryRankInfo val_5 = val_1.TRVCategoryRankEcon.Item[val_4];
        if(val_3 == val_5.goal)
        {
                int val_15 = subcategoryProgress.rank;
            val_15 = val_15 + 1;
            subcategoryProgress.rank = val_15;
            subcategoryProgress.rankProgress = 0;
            val_15 = 0;
            if(val_4 != val_1.TRVCategoryRankEcon.Count)
        {
                TRVCategoryRankInfo val_8 = val_1.TRVCategoryRankEcon.Item[subcategoryProgress.rank + 2];
            val_15 = val_8.goal;
        }
        
            GameBehavior val_9 = App.getBehavior;
            val_16 = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  val_16);
            TRVCategoryRankInfo val_13 = val_1.TRVCategoryRankEcon.Item[val_4];
            val_9.<metaGameBehavior>k__BackingField.Init(categorySp:  val_16, currentRank:  subcategoryProgress.rank, nextProgressGoal:  val_15, rewardAmount:  val_13.reward);
        }
        
        TRVDataParser val_14 = MonoSingleton<TRVDataParser>.Instance;
        val_14.<playerPersistance>k__BackingField.SaveProgress();
    }
    public static float GetCategoryProcess(TRVSubCategoryProgress subcategoryProgress)
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(subcategoryProgress.rank == val_1.TRVCategoryRankEcon.Count)
        {
                return (float)val_6;
        }
        
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        TRVCategoryRankInfo val_5 = val_3.TRVCategoryRankEcon.Item[subcategoryProgress.rank + 1];
        float val_6 = (float)val_5.goal;
        val_6 = (float)subcategoryProgress.rankProgress / val_6;
        return (float)val_6;
    }
    public static void CollectReward(int reward)
    {
        decimal val_2 = System.Decimal.op_Implicit(value:  reward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Category Rank Complete", subSource:  0, externalParams:  0, doTrack:  true);
    }
    public static bool CanRankUpCategory(string subCategory)
    {
        var val_7;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != false)
        {
                label_14:
            val_7 = 0;
            return (bool)val_7;
        }
        
        if((MonoSingleton<TRVPromoCategoriesHandler>.Instance) != 0)
        {
                if((MonoSingleton<TRVPromoCategoriesHandler>.Instance.IsActivePromo(subCategoryName:  subCategory)) == true)
        {
            goto label_14;
        }
        
        }
        
        val_7 = 1;
        return (bool)val_7;
    }
    public TRVCategoryRankController()
    {
    
    }

}
