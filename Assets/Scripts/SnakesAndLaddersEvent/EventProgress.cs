using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class EventProgress : EventProgression
    {
        // Fields
        private const string EVENT_PROGRESS = "snl_evt_prg";
        private const string DICE_BALANCE = "dice_balance";
        private const string BOARDS_STATUS = "boards";
        private const string EVENT_TIMESTAMP = "timestamp";
        private const string LAST_PRG_TIMESTAMP = "last_prg_timestamp";
        private const string STARTER_PACK_STATUS = "starter_pack_status";
        private const string DICE_PROGRESS = "dice_progress";
        private const string DICE_ROLLED = "dice_rolled";
        public int DiceBalance;
        public int DiceRolled;
        public int Timestamp;
        public int LastProgressTimestamp;
        public System.Collections.Generic.List<SnakesAndLaddersEvent.Board> Boards;
        public SnakesAndLaddersEvent.StarterDicePackStatus StarterPackStatus;
        public SnakesAndLaddersEvent.MovingDiceRollProgress DiceRollProgress;
        
        // Methods
        public EventProgress()
        {
            .IsShown = false;
            .IsPurchased = false;
            .StartTime = 0;
            this.StarterPackStatus = new SnakesAndLaddersEvent.StarterDicePackStatus();
            this.DiceRollProgress = new SnakesAndLaddersEvent.MovingDiceRollProgress();
        }
        public void Initialize()
        {
            null = null;
            this.DiceBalance = SnakesAndLaddersEvent.Econ.DefaultDiceRolls;
            this.DiceRolled = 0;
            this.InitBoards();
        }
        public override void LoadFromJSON()
        {
            SnakesAndLaddersEvent.MovingDiceRollProgress val_30;
            string val_1 = CPlayerPrefs.GetString(key:  "snl_evt_prg");
            if((System.String.IsNullOrEmpty(value:  val_1)) == true)
            {
                    return;
            }
            
            object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
            if((val_3.ContainsKey(key:  "dice_balance")) != false)
            {
                    bool val_7 = System.Int32.TryParse(s:  val_3.Item["dice_balance"], result: out  this.DiceBalance);
            }
            
            if((val_3.ContainsKey(key:  "dice_rolled")) != false)
            {
                    bool val_11 = System.Int32.TryParse(s:  val_3.Item["dice_rolled"], result: out  this.DiceRolled);
            }
            
            if((val_3.ContainsKey(key:  "timestamp")) != false)
            {
                    bool val_15 = System.Int32.TryParse(s:  val_3.Item["timestamp"], result: out  this.Timestamp);
            }
            
            if((val_3.ContainsKey(key:  "last_prg_timestamp")) != false)
            {
                    bool val_19 = System.Int32.TryParse(s:  val_3.Item["last_prg_timestamp"], result: out  this.LastProgressTimestamp);
            }
            
            if((val_3.ContainsKey(key:  "boards")) != false)
            {
                    object val_22 = MiniJSON.Json.Deserialize(json:  val_3.Item["boards"]);
                if(null >= 1)
            {
                    var val_29 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(null <= val_29)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 + 0) + 32.LoadProgress(data:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg);
                val_29 = val_29 + 1;
            }
            
            }
            
            if((val_3.ContainsKey(key:  "starter_pack_status")) != false)
            {
                    this.StarterPackStatus = new SnakesAndLaddersEvent.StarterDicePackStatus(data:  val_3.Item["starter_pack_status"]);
            }
            
            val_30 = "dice_progress";
            if((val_3.ContainsKey(key:  "dice_progress")) == false)
            {
                    return;
            }
            
            SnakesAndLaddersEvent.MovingDiceRollProgress val_28 = null;
            val_30 = val_28;
            val_28 = new SnakesAndLaddersEvent.MovingDiceRollProgress(data:  val_3.Item["dice_progress"]);
            this.DiceRollProgress = val_30;
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "dice_balance", value:  this.DiceBalance);
            val_1.Add(key:  "dice_rolled", value:  this.DiceRolled);
            val_1.Add(key:  "timestamp", value:  this.Timestamp);
            val_1.Add(key:  "last_prg_timestamp", value:  this.LastProgressTimestamp);
            val_1.Add(key:  "boards", value:  MiniJSON.Json.Serialize(obj:  this.Boards));
            val_1.Add(key:  "starter_pack_status", value:  this.StarterPackStatus);
            val_1.Add(key:  "dice_progress", value:  this.DiceRollProgress);
            CPlayerPrefs.SetString(key:  "snl_evt_prg", val:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public override void Delete()
        {
            CPlayerPrefs.DeleteKey(key:  "snl_evt_prg");
        }
        public void ResetBoardProgress()
        {
            List.Enumerator<T> val_1 = this.Boards.GetEnumerator();
            goto label_2;
            label_4:
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            mem[24] = 0;
            mem[28] = 0;
            label_2:
            if(0.MoveNext() == true)
            {
                goto label_4;
            }
            
            0.Dispose();
        }
        private void InitBoards()
        {
            var val_3;
            var val_4;
            this.Boards = new System.Collections.Generic.List<SnakesAndLaddersEvent.Board>();
            val_3 = 0;
            goto label_1;
            label_10:
            if(val_3 >= (SnakesAndLaddersEvent.Econ.BoardDefinitions + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_3 = SnakesAndLaddersEvent.Econ.BoardDefinitions + 16;
            val_3 = val_3 + 0;
            this.Boards.Add(item:  new SnakesAndLaddersEvent.Board(definition:  (SnakesAndLaddersEvent.Econ.BoardDefinitions + 16 + 0) + 32));
            val_3 = 1;
            label_1:
            val_4 = null;
            val_4 = null;
            if(val_3 < (SnakesAndLaddersEvent.Econ.BoardDefinitions + 24))
            {
                goto label_10;
            }
        
        }
    
    }

}
