using UnityEngine;

namespace SLC.Minigames
{
    [Serializable]
    public class MinigameRankData
    {
        // Fields
        public System.Collections.Generic.List<SLC.Minigames.MinigameLevelRank> ranks;
        
        // Methods
        public MinigameRankData()
        {
            System.Collections.Generic.List<SLC.Minigames.MinigameLevelRank> val_1 = new System.Collections.Generic.List<SLC.Minigames.MinigameLevelRank>();
            decimal val_2 = new System.Decimal(value:  85);
            System.Collections.Generic.List<System.Object> val_3 = new System.Collections.Generic.List<System.Object>();
            val_3.Add(item:  5);
            val_3.Add(item:  15);
            val_3.Add(item:  25);
            val_3.Add(item:  35);
            val_3.Add(item:  50);
            val_3.Add(item:  75);
            val_3.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  0, percentage:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo}, name:  "None", checkpoints:  val_3));
            decimal val_5 = new System.Decimal(value:  60);
            System.Collections.Generic.List<System.Object> val_6 = new System.Collections.Generic.List<System.Object>();
            val_6.Add(item:  5);
            val_6.Add(item:  15);
            val_6.Add(item:  25);
            val_6.Add(item:  35);
            val_6.Add(item:  50);
            val_6.Add(item:  75);
            val_6.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  100, percentage:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo}, name:  "Gold", checkpoints:  val_6));
            decimal val_8 = new System.Decimal(value:  30);
            System.Collections.Generic.List<System.Object> val_9 = new System.Collections.Generic.List<System.Object>();
            val_9.Add(item:  5);
            val_9.Add(item:  15);
            val_9.Add(item:  25);
            val_9.Add(item:  35);
            val_9.Add(item:  50);
            val_9.Add(item:  75);
            val_9.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  200, percentage:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo}, name:  "Platinum", checkpoints:  val_9));
            decimal val_11 = new System.Decimal(value:  10);
            System.Collections.Generic.List<System.Object> val_12 = new System.Collections.Generic.List<System.Object>();
            val_12.Add(item:  5);
            val_12.Add(item:  15);
            val_12.Add(item:  25);
            val_12.Add(item:  35);
            val_12.Add(item:  50);
            val_12.Add(item:  75);
            val_12.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  44, percentage:  new System.Decimal() {flags = val_11.flags, hi = val_11.flags, lo = val_11.lo, mid = val_11.lo}, name:  "Ruby", checkpoints:  val_12));
            decimal val_14 = new System.Decimal(lo:  5, mid:  0, hi:  0, isNegative:  false, scale:  1);
            System.Collections.Generic.List<System.Object> val_15 = new System.Collections.Generic.List<System.Object>();
            val_15.Add(item:  5);
            val_15.Add(item:  15);
            val_15.Add(item:  25);
            val_15.Add(item:  35);
            val_15.Add(item:  50);
            val_15.Add(item:  75);
            val_15.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  144, percentage:  new System.Decimal() {flags = val_14.flags, hi = val_14.flags, lo = val_14.lo, mid = val_14.lo}, name:  "Diamond", checkpoints:  val_15));
            decimal val_17 = new System.Decimal(lo:  5, mid:  0, hi:  0, isNegative:  false, scale:  1);
            System.Collections.Generic.List<System.Object> val_18 = new System.Collections.Generic.List<System.Object>();
            val_18.Add(item:  5);
            val_18.Add(item:  15);
            val_18.Add(item:  25);
            val_18.Add(item:  35);
            val_18.Add(item:  50);
            val_18.Add(item:  75);
            val_18.Add(item:  100);
            val_1.Add(item:  new SLC.Minigames.MinigameLevelRank(level:  244, percentage:  new System.Decimal() {flags = val_17.flags, hi = val_17.flags, lo = val_17.lo, mid = val_17.lo}, name:  "Master", checkpoints:  val_18));
            mem[1152921519748708848] = val_1;
            val_18 = new System.Object();
        }
    
    }

}
