using UnityEngine;

namespace WordForest
{
    public struct WFOForestData
    {
        // Fields
        public int level;
        public string forestName;
        public int initialCost;
        public int costIncrease;
        public int stages;
        public WordForest.WFOBackgroundType bgType;
        
        // Methods
        public WFOForestData(int _level, int _costIncrease, int _initialCost, string _name, int _stages = 20, WordForest.WFOBackgroundType _bgType = 0)
        {
            this = _level;
            this.forestName = _name;
            this.initialCost = _initialCost;
            this.costIncrease = _costIncrease;
            this.stages = _stages;
            this.bgType = _bgType;
        }
        public int GetGrowthCost(int toStage)
        {
            if(new WordForest.WFOForestData() != 1)
            {
                    return (int)(toStage > 4) ? 10 : (this.initialCost + (this.costIncrease * toStage));
            }
            
            return (int)(toStage > 4) ? 10 : (this.initialCost + (this.costIncrease * toStage));
        }
    
    }

}
