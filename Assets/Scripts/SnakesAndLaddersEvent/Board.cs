using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class Board
    {
        // Fields
        private const string NUMBER_SPACE = "num";
        private const string IS_SEEN = "seen";
        public readonly SnakesAndLaddersEvent.BoardDefinition Definition;
        public int CurrentNumberSpace;
        public bool IsSeen;
        
        // Methods
        public Board(SnakesAndLaddersEvent.BoardDefinition definition)
        {
            this.Definition = definition;
            this.CurrentNumberSpace = 0;
            this.IsSeen = false;
        }
        public float GetPercentProgress()
        {
            if(this.Definition != null)
            {
                    float val_1 = (float)this.CurrentNumberSpace;
                val_1 = val_1 / (float)this.Definition.MaxSpaceCount;
                return (float)val_1;
            }
            
            throw new NullReferenceException();
        }
        public bool IsFinished()
        {
            float val_3 = (float)this.CurrentNumberSpace;
            val_3 = val_3 / (float)this.Definition.MaxSpaceCount;
            return (bool)val_3.Equals(obj:  1f);
        }
        public int GetIndex()
        {
            null = null;
            return SnakesAndLaddersEvent.Econ.BoardDefinitions.FindIndex(match:  new System.Predicate<SnakesAndLaddersEvent.BoardDefinition>(object:  this, method:  System.Boolean SnakesAndLaddersEvent.Board::<GetIndex>b__8_0(SnakesAndLaddersEvent.BoardDefinition x)));
        }
        public void LoadProgress(string data)
        {
            object val_1 = MiniJSON.Json.Deserialize(json:  data);
            if((val_1.ContainsKey(key:  "num")) != false)
            {
                    bool val_5 = System.Int32.TryParse(s:  val_1.Item["num"], result: out  this.CurrentNumberSpace);
            }
            
            if((val_1.ContainsKey(key:  "seen")) == false)
            {
                    return;
            }
            
            bool val_9 = System.Boolean.TryParse(value:  val_1.Item["seen"], result: out  this.IsSeen);
        }
        public override string ToString()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "num", value:  this.CurrentNumberSpace);
            val_1.Add(key:  "seen", value:  this.IsSeen);
            return (string)MiniJSON.Json.Serialize(obj:  val_1);
        }
        private bool <GetIndex>b__8_0(SnakesAndLaddersEvent.BoardDefinition x)
        {
            return (bool)(x.MaxSpaceCount == this.Definition.MaxSpaceCount) ? 1 : 0;
        }
    
    }

}
