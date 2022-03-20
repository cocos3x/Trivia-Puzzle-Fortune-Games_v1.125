using UnityEngine;

namespace WordForest
{
    public class ChestData
    {
        // Fields
        public int WordIndex;
        public int CellIndex;
        private int collected;
        
        // Properties
        public bool Collected { get; set; }
        
        // Methods
        public bool get_Collected()
        {
            return (bool)(this.collected == 1) ? 1 : 0;
        }
        public void set_Collected(bool value)
        {
            if(this != null)
            {
                    this.collected = ((value & true) != 0) ? (-1) : 1;
                return;
            }
            
            throw new NullReferenceException();
        }
        public string Serialize()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this);
        }
        public ChestData()
        {
            this.collected = 0;
        }
        public ChestData(int wordIndex, int cellIndex, bool isCollected)
        {
            this.collected = 0;
            this.WordIndex = wordIndex;
            this.CellIndex = cellIndex;
            this.collected = ((isCollected & true) != 0) ? (-1) : 1;
        }
        public ChestData(string serialized)
        {
            this.collected = 0;
            WordForest.ChestData val_1 = Newtonsoft.Json.JsonConvert.DeserializeObject<WordForest.ChestData>(value:  serialized);
            this.WordIndex = val_1.WordIndex;
            this.CellIndex = val_1.CellIndex;
            this.collected = val_1.collected;
        }
    
    }

}
