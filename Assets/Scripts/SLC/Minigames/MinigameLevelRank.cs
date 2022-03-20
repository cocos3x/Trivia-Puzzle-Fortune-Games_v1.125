using UnityEngine;

namespace SLC.Minigames
{
    [Serializable]
    public class MinigameLevelRank
    {
        // Fields
        public static System.Collections.Generic.Dictionary<string, UnityEngine.Color32> RankColors;
        public static System.Collections.Generic.Dictionary<string, UnityEngine.Color32> TitleColors;
        public int rankLevel;
        public decimal percentPlayersComplete;
        public string rankName;
        public System.Collections.Generic.List<int> rankCheckpoints;
        
        // Properties
        public UnityEngine.Color Color { get; }
        public UnityEngine.Color TitleColor { get; }
        public int NumCheckpoints { get; }
        
        // Methods
        public static string RankIndexToName(int index)
        {
            var val_2;
            if(index <= 5)
            {
                    var val_2 = 32560032 + (index) << 2;
                val_2 = val_2 + 32560032;
            }
            else
            {
                    val_2 = null;
                return (string)5.ToString();
            }
        
        }
        public MinigameLevelRank(int level, decimal percentage, string name, System.Collections.Generic.List<object> checkpoints)
        {
            string val_5;
            var val_6;
            int val_9;
            this.rankName = "None";
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            val_1.Add(item:  5);
            val_1.Add(item:  15);
            val_1.Add(item:  25);
            val_1.Add(item:  35);
            val_1.Add(item:  50);
            val_1.Add(item:  75);
            val_1.Add(item:  100);
            this.rankCheckpoints = val_1;
            val_2 = new System.Object();
            this.rankLevel = level;
            this.percentPlayersComplete = percentage;
            mem[1152921519749195004] = percentage.lo;
            mem[1152921519749195008] = percentage.mid;
            this.rankName = val_2;
            this.rankCheckpoints = new System.Collections.Generic.List<System.Int32>();
            List.Enumerator<T> val_4 = checkpoints.GetEnumerator();
            label_6:
            val_9 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_6.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = System.Int32.Parse(s:  val_5);
            if(this.rankCheckpoints == null)
            {
                    throw new NullReferenceException();
            }
            
            this.rankCheckpoints.Add(item:  val_9);
            goto label_6;
            label_3:
            val_6.Dispose();
        }
        public UnityEngine.Color get_Color()
        {
            null = null;
            UnityEngine.Color32 val_1 = SLC.Minigames.MinigameLevelRank.RankColors.Item[this.rankName];
            val_1.r = val_1.r & 4294967295;
            return UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_1.r, g = val_1.r, b = val_1.r, a = val_1.r});
        }
        public UnityEngine.Color get_TitleColor()
        {
            null = null;
            UnityEngine.Color32 val_1 = SLC.Minigames.MinigameLevelRank.TitleColors.Item[this.rankName];
            val_1.r = val_1.r & 4294967295;
            return UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_1.r, g = val_1.r, b = val_1.r, a = val_1.r});
        }
        public int get_NumCheckpoints()
        {
            return 19080;
        }
        private static MinigameLevelRank()
        {
            System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32> val_1 = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32>();
            UnityEngine.Color32 val_3 = new UnityEngine.Color32(r:  98, g:  98, b:  98, a:  255);
            val_1.Add(key:  0.ToString(), value:  new UnityEngine.Color32() {r = val_3.r, g = val_3.r, b = val_3.r, a = val_3.r});
            UnityEngine.Color32 val_5 = new UnityEngine.Color32(r:  189, g:  156, b:  19, a:  255);
            val_1.Add(key:  1.ToString(), value:  new UnityEngine.Color32() {r = val_5.r, g = val_5.r, b = val_5.r, a = val_5.r});
            UnityEngine.Color32 val_7 = new UnityEngine.Color32(r:  128, g:  97, b:  183, a:  255);
            val_1.Add(key:  2.ToString(), value:  new UnityEngine.Color32() {r = val_7.r, g = val_7.r, b = val_7.r, a = val_7.r});
            UnityEngine.Color32 val_9 = new UnityEngine.Color32(r:  225, g:  22, b:  60, a:  255);
            val_1.Add(key:  3.ToString(), value:  new UnityEngine.Color32() {r = val_9.r, g = val_9.r, b = val_9.r, a = val_9.r});
            UnityEngine.Color32 val_11 = new UnityEngine.Color32(r:  98, g:  180, b:  243, a:  255);
            val_1.Add(key:  4.ToString(), value:  new UnityEngine.Color32() {r = val_11.r, g = val_11.r, b = val_11.r, a = val_11.r});
            UnityEngine.Color32 val_13 = new UnityEngine.Color32(r:  255, g:  175, b:  38, a:  255);
            val_1.Add(key:  5.ToString(), value:  new UnityEngine.Color32() {r = val_13.r, g = val_13.r, b = val_13.r, a = val_13.r});
            SLC.Minigames.MinigameLevelRank.RankColors = val_1;
            System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32> val_14 = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32>();
            UnityEngine.Color32 val_16 = new UnityEngine.Color32(r:  0, g:  0, b:  0, a:  0);
            val_14.Add(key:  0.ToString(), value:  new UnityEngine.Color32() {r = val_16.r, g = val_16.r, b = val_16.r, a = val_16.r});
            UnityEngine.Color32 val_18 = new UnityEngine.Color32(r:  252, g:  219, b:  69, a:  255);
            val_14.Add(key:  1.ToString(), value:  new UnityEngine.Color32() {r = val_18.r, g = val_18.r, b = val_18.r, a = val_18.r});
            UnityEngine.Color32 val_20 = new UnityEngine.Color32(r:  180, g:  145, b:  227, a:  255);
            val_14.Add(key:  2.ToString(), value:  new UnityEngine.Color32() {r = val_20.r, g = val_20.r, b = val_20.r, a = val_20.r});
            UnityEngine.Color32 val_22 = new UnityEngine.Color32(r:  255, g:  26, b:  69, a:  255);
            val_14.Add(key:  3.ToString(), value:  new UnityEngine.Color32() {r = val_22.r, g = val_22.r, b = val_22.r, a = val_22.r});
            UnityEngine.Color32 val_24 = new UnityEngine.Color32(r:  163, g:  210, b:  253, a:  255);
            val_14.Add(key:  4.ToString(), value:  new UnityEngine.Color32() {r = val_24.r, g = val_24.r, b = val_24.r, a = val_24.r});
            UnityEngine.Color32 val_26 = new UnityEngine.Color32(r:  255, g:  175, b:  38, a:  255);
            val_14.Add(key:  5.ToString(), value:  new UnityEngine.Color32() {r = val_26.r, g = val_26.r, b = val_26.r, a = val_26.r});
            SLC.Minigames.MinigameLevelRank.TitleColors = val_14;
        }
    
    }

}
