using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class MovingDiceRollProgress
    {
        // Fields
        private const string LINEWORD_INDEX = "word_index";
        private const string CELL_INDEX = "cell_index";
        private const string LAST_LEVEL = "last_level";
        private const string IS_COLLECTED = "collected";
        private const string IS_MISSED = "missed";
        public int LinewordIndex;
        public int CellIndex;
        public int LastLevel;
        public bool IsCollected;
        public bool IsMissed;
        
        // Methods
        public MovingDiceRollProgress()
        {
        
        }
        public MovingDiceRollProgress(string data)
        {
            object val_1 = MiniJSON.Json.Deserialize(json:  data);
            if((val_1.ContainsKey(key:  "word_index")) != false)
            {
                    bool val_5 = System.Int32.TryParse(s:  val_1.Item["word_index"], result: out  this.LinewordIndex);
            }
            
            if((val_1.ContainsKey(key:  "cell_index")) != false)
            {
                    bool val_9 = System.Int32.TryParse(s:  val_1.Item["cell_index"], result: out  this.CellIndex);
            }
            
            if((val_1.ContainsKey(key:  "last_level")) != false)
            {
                    bool val_13 = System.Int32.TryParse(s:  val_1.Item["last_level"], result: out  this.LastLevel);
            }
            
            if((val_1.ContainsKey(key:  "collected")) != false)
            {
                    bool val_17 = System.Boolean.TryParse(value:  val_1.Item["collected"], result: out  this.IsCollected);
            }
            
            if((val_1.ContainsKey(key:  "missed")) == false)
            {
                    return;
            }
            
            bool val_21 = System.Boolean.TryParse(value:  val_1.Item["missed"], result: out  this.IsMissed);
        }
        public override string ToString()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "word_index", value:  this.LinewordIndex);
            val_1.Add(key:  "cell_index", value:  this.CellIndex);
            val_1.Add(key:  "last_level", value:  this.LastLevel);
            val_1.Add(key:  "collected", value:  this.IsCollected);
            val_1.Add(key:  "missed", value:  this.IsMissed);
            return (string)MiniJSON.Json.Serialize(obj:  val_1);
        }
    
    }

}
