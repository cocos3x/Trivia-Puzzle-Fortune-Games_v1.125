using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class StarterDicePackStatus
    {
        // Fields
        private const string IS_SHOWN = "shown";
        private const string IS_PURCHASED = "purchased";
        private const string START_TIME = "time";
        public bool IsShown;
        public bool IsPurchased;
        public System.DateTime StartTime;
        
        // Methods
        public StarterDicePackStatus()
        {
            this.IsShown = false;
            this.IsPurchased = false;
            this.StartTime = 0;
        }
        public StarterDicePackStatus(string data)
        {
            object val_1 = MiniJSON.Json.Deserialize(json:  data);
            if((val_1.ContainsKey(key:  "shown")) != false)
            {
                    bool val_5 = System.Boolean.TryParse(value:  val_1.Item["shown"], result: out  this.IsShown);
            }
            
            if((val_1.ContainsKey(key:  "purchased")) != false)
            {
                    bool val_9 = System.Boolean.TryParse(value:  val_1.Item["purchased"], result: out  this.IsPurchased);
            }
            
            if((val_1.ContainsKey(key:  "time")) == false)
            {
                    return;
            }
            
            bool val_12 = System.DateTime.TryParse(s:  val_1.Item["time"], result: out  new System.DateTime() {dateData = this.StartTime});
        }
        public System.TimeSpan GetTimeLeft()
        {
            null = null;
            System.DateTime val_1 = this.StartTime.AddMinutes(value:  (double)SnakesAndLaddersEvent.Econ.StarterDicePackDurationInMinutes);
            System.DateTime val_2 = DateTimeCheat.Now;
            return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        }
        public bool IsOutOfTime()
        {
            var val_5;
            if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.StartTime}, d2:  new System.DateTime())) != false)
            {
                    val_5 = 0;
                return (bool)(val_2._ticks.TotalSeconds <= 0f) ? 1 : 0;
            }
            
            System.TimeSpan val_2 = this.GetTimeLeft();
            return (bool)(val_2._ticks.TotalSeconds <= 0f) ? 1 : 0;
        }
        public override string ToString()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "shown", value:  this.IsShown);
            val_1.Add(key:  "purchased", value:  this.IsPurchased);
            val_1.Add(key:  "time", value:  this.StartTime.ToString());
            return (string)MiniJSON.Json.Serialize(obj:  val_1);
        }
    
    }

}
