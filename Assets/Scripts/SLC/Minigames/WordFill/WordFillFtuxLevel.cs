using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WordFillFtuxLevel : WordFillLevel
    {
        // Methods
        public WordFillFtuxLevel(int lev)
        {
            if(lev != 1)
            {
                    if(lev != 0)
            {
                    return;
            }
            
                this.CreateFtuxLevel0();
                return;
            }
            
            this.CreateFtuxLevel1();
        }
        private void CreateFtuxLevel0()
        {
            bool val_9 = true;
            mem[33] = 69;
            val_9 = val_9 + ((mem[3458764513837365008]) << 1);
            mem2[0] = 82;
            val_9 = val_9 + (((true + (mem[3458764513837365008]) << 1) + 16 + 16) << 2);
            mem2[0] = 84;
            mem2[0] = 68;
            val_9 = val_9 + ((((true + (mem[3458764513837365008]) << 1) + ((true + (mem[3458764513837365008]) << 1) + 16 + 16) << 2) + 16 + 16) << 1);
            mem2[0] = 78;
            val_9 = val_9 + 2;
            mem2[0] = 65;
            37863.Add(item:  "RED");
            37863.Add(item:  "TAN");
            System.Collections.Generic.HashSet<System.Int32> val_1 = new System.Collections.Generic.HashSet<System.Int32>();
            bool val_2 = val_1.Add(item:  1);
            bool val_3 = val_1.Add(item:  0);
            val_1.Add(item:  3).Add(item:  val_1);
            System.Collections.Generic.HashSet<System.Int32> val_5 = new System.Collections.Generic.HashSet<System.Int32>();
            bool val_6 = val_5.Add(item:  2);
            bool val_7 = val_5.Add(item:  5);
            val_5.Add(item:  4).Add(item:  val_5);
        }
        private void CreateFtuxLevel1()
        {
            bool val_9 = true;
            mem[33] = 76;
            val_9 = val_9 + ((mem[3458764513837365008]) << 1);
            mem2[0] = 72;
            val_9 = val_9 + (((true + (mem[3458764513837365008]) << 1) + 16 + 16) << 2);
            mem2[0] = 69;
            mem2[0] = 87;
            val_9 = val_9 + ((((true + (mem[3458764513837365008]) << 1) + ((true + (mem[3458764513837365008]) << 1) + 16 + 16) << 2) + 16 + 16) << 1);
            mem2[0] = 79;
            val_9 = val_9 + 2;
            mem2[0] = 78;
            37864.Add(item:  "OWL");
            37864.Add(item:  "HEN");
            System.Collections.Generic.HashSet<System.Int32> val_1 = new System.Collections.Generic.HashSet<System.Int32>();
            bool val_2 = val_1.Add(item:  4);
            bool val_3 = val_1.Add(item:  3);
            val_1.Add(item:  0).Add(item:  val_1);
            System.Collections.Generic.HashSet<System.Int32> val_5 = new System.Collections.Generic.HashSet<System.Int32>();
            bool val_6 = val_5.Add(item:  1);
            bool val_7 = val_5.Add(item:  2);
            val_5.Add(item:  5).Add(item:  val_5);
        }
    
    }

}
