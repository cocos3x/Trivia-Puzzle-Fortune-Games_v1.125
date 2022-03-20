using UnityEngine;
public class ForestFrenzyEcon
{
    // Fields
    public static int UnlockLevel;
    public static int LevelsToPlay;
    public static int LevelsToPlayCooldownSeconds;
    public static decimal ForestCompleteReward;
    public static int[] CostPerGrowthStage;
    private static System.Collections.Generic.List<WordForest.WFOForestData> forests;
    
    // Properties
    public static System.Collections.Generic.List<WordForest.WFOForestData> Forests { get; }
    
    // Methods
    public static System.Collections.Generic.List<WordForest.WFOForestData> get_Forests()
    {
        null = null;
        return (System.Collections.Generic.List<WordForest.WFOForestData>)ForestFrenzyEcon.forests;
    }
    public static WordForest.WFOForestData GetForestEconData(int forestId)
    {
        var val_3;
        .forestId = forestId;
        val_3 = null;
        val_3 = null;
        return ForestFrenzyEcon.forests.Find(match:  new System.Predicate<WordForest.WFOForestData>(object:  new ForestFrenzyEcon.<>c__DisplayClass8_0(), method:  System.Boolean ForestFrenzyEcon.<>c__DisplayClass8_0::<GetForestEconData>b__0(WordForest.WFOForestData n)));
    }
    public static WordForest.Map CreateStartingMap()
    {
        return ForestFrenzyEcon.CreateMap(forestLevel:  1, growthLevel:  0, growthPercent:  0f);
    }
    public static WordForest.Map CreateMap(int forestLevel, int growthLevel = 0, float growthPercent = 0)
    {
        var val_10;
        object val_11;
        var val_12;
        System.Predicate<T> val_13;
        var val_14;
        var val_15;
        val_10 = growthLevel;
        ForestFrenzyEcon.<>c__DisplayClass10_0 val_1 = null;
        val_11 = val_1;
        val_1 = new ForestFrenzyEcon.<>c__DisplayClass10_0();
        .forestLevel = forestLevel;
        System.Collections.Generic.List<WordForest.MapItem> val_2 = new System.Collections.Generic.List<WordForest.MapItem>();
        val_12 = null;
        val_12 = null;
        System.Predicate<WordForest.WFOForestData> val_3 = null;
        val_13 = val_3;
        val_3 = new System.Predicate<WordForest.WFOForestData>(object:  val_1, method:  System.Boolean ForestFrenzyEcon.<>c__DisplayClass10_0::<CreateMap>b__0(WordForest.WFOForestData n));
        int val_4 = ForestFrenzyEcon.forests.FindIndex(match:  val_3);
        if((val_4 & 2147483648) == 0)
        {
                val_11 = val_4;
            val_14 = null;
            val_14 = null;
            if((ForestFrenzyEcon.forests + 24) <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_10 = ForestFrenzyEcon.forests + 16;
            val_10 = val_10 + (((long)(int)(val_4)) << 5);
            val_15 = mem[(ForestFrenzyEcon.forests + 16 + ((long)(int)(val_4)) << 5) + 56];
            val_15 = (ForestFrenzyEcon.forests + 16 + ((long)(int)(val_4)) << 5) + 56;
        }
        else
        {
                val_15 = 20;
        }
        
        if((val_10 <= 0) && (growthPercent > 0f))
        {
                float val_5 = UnityEngine.Mathf.Clamp(value:  growthPercent, min:  0f, max:  1f);
            val_5 = val_5 * 20f;
            val_10 = UnityEngine.Mathf.FloorToInt(f:  val_5);
        }
        
        if(20 < 1)
        {
                return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
        }
        
        do
        {
            val_2.Add(item:  new WordForest.MapItem(mType:  "tree", mId:  0, mStatus:  (0 < val_10) ? 1 : 0));
            val_11 = 0 + 1;
        }
        while(val_11 < 20);
        
        return (WordForest.Map)new WordForest.Map(initialAreaItems:  val_2);
    }
    public ForestFrenzyEcon()
    {
    
    }
    private static ForestFrenzyEcon()
    {
        ForestFrenzyEcon.UnlockLevel = 25;
        ForestFrenzyEcon.LevelsToPlay = 5;
        ForestFrenzyEcon.LevelsToPlayCooldownSeconds = 600;
        decimal val_1 = new System.Decimal(value:  250);
        ForestFrenzyEcon.ForestCompleteReward = val_1.flags;
        ForestFrenzyEcon.CostPerGrowthStage = new int[20] {14, 18, 22, 26, 30, 34, 38, 41, 45, 49, 53, 57, 61, 65, 69, 73, 77, 80, 84, 88};
        System.Collections.Generic.List<WordForest.WFOForestData> val_3 = new System.Collections.Generic.List<WordForest.WFOForestData>();
        WordForest.WFOForestData val_4 = new WordForest.WFOForestData(_level:  1, _costIncrease:  30, _initialCost:  140, _name:  "forest_location_ti", _stages:  20, _bgType:  4);
        val_3.Add(item:  new WordForest.WFOForestData() {level = val_4.level, initialCost = val_4.initialCost, bgType = ???});
        ForestFrenzyEcon.forests = val_3;
    }

}
