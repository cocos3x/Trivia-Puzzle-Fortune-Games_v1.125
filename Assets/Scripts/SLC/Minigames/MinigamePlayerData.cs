using UnityEngine;

namespace SLC.Minigames
{
    [Serializable]
    public class MinigamePlayerData : EncodableModel
    {
        // Fields
        public int rankIndex;
        public int checkpointLevel;
        public int checkpointsReached;
        private System.Collections.Generic.List<int> rankCheckpoints;
        
        // Methods
        public float LevelsForNextRank()
        {
            float val_2 = (float)S0;
            val_2 = (float)this.GetCheckpointsCompletedInRank() / val_2;
            return (float)val_2;
        }
        public int GetCheckpointsCompletedInRank()
        {
            var val_1;
            var val_2;
            bool val_1 = true;
            val_1 = 0;
            label_5:
            if(val_1 >= 19115)
            {
                    return (int)val_2;
            }
            
            if(19115 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            if(((true + 0) + 32) > this.checkpointLevel)
            {
                goto label_4;
            }
            
            val_1 = val_1 + 1;
            if(this.rankCheckpoints != null)
            {
                goto label_5;
            }
            
            throw new NullReferenceException();
            label_4:
            val_2 = val_1;
            return (int)val_2;
        }
        public MinigamePlayerData()
        {
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            val_1.Add(item:  5);
            val_1.Add(item:  15);
            val_1.Add(item:  25);
            val_1.Add(item:  35);
            val_1.Add(item:  50);
            val_1.Add(item:  75);
            val_1.Add(item:  100);
            this.rankCheckpoints = val_1;
        }
    
    }

}
