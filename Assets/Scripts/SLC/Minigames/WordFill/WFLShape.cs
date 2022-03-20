using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WFLShape
    {
        // Fields
        public char[,] grid;
        public int width;
        public int height;
        
        // Methods
        public virtual void HFlip()
        {
            int val_3;
            val_3 = this.height;
            if(val_3 < 1)
            {
                    return;
            }
            
            int val_4 = this.width;
            var val_11 = 0;
            do
            {
                if(val_4 >= 2)
            {
                    var val_9 = 0;
                var val_10 = 0;
                do
            {
                val_4 = val_4 + val_10;
                var val_5 = (long)val_4;
                val_5 = val_11 + ((X12 + 16) * val_5);
                mem2[0] = this.grid[val_5];
                int val_7 = this.width;
                val_7 = val_10 + val_7;
                var val_8 = (long)val_7;
                val_8 = val_11 + ((X12 + 16) * val_8);
                this.grid[val_8] = this.grid[val_11 + ((X12 + 16) * val_9)];
                val_9 = val_9 + 1;
                val_10 = val_10 - 1;
                var val_2 = (this.width < 0) ? (this.width + 1) : this.width;
                val_2 = val_2 >> 1;
            }
            while(val_9 < (val_2 << ));
            
                val_3 = this.height;
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < (val_3 << ));
        
        }
        public virtual void VFlip()
        {
            int val_4;
            val_4 = this.width;
            if(val_4 < 1)
            {
                    return;
            }
            
            int val_5 = this.height;
            var val_11 = 0;
            do
            {
                if(val_5 >= 2)
            {
                    var val_9 = 0;
                var val_10 = 0;
                do
            {
                System.Char[,] val_8 = this.grid;
                var val_1 = (X12 + 16) * val_11;
                val_5 = val_5 + val_10;
                val_5 = val_1 + (val_5 << );
                mem2[0] = val_8[val_5];
                int val_7 = this.height;
                val_7 = val_10 + val_7;
                val_8 = (long)val_7 + (val_8 * val_11);
                this.grid[val_8] = val_8[val_9 + val_1];
                val_9 = val_9 + 1;
                val_10 = val_10 - 1;
                var val_3 = (this.height < 0) ? (this.height + 1) : this.height;
                val_3 = val_3 >> 1;
            }
            while(val_9 < (val_3 << ));
            
                val_4 = this.width;
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < (val_4 << ));
        
        }
        public virtual void Rot()
        {
            int val_3;
            int val_4;
            System.Char[,] val_5;
            val_3 = this.height;
            if(val_3 <= 0)
            {
                goto label_1;
            }
            
            val_4 = this.width;
            var val_6 = 0;
            val_5 = this.grid;
            var val_7 = 0;
            label_12:
            if(val_4 < 1)
            {
                goto label_9;
            }
            
            var val_4 = mem[this.grid];
            var val_5 = 0;
            label_10:
            var val_3 = mem[this.grid] + 16 + 16;
            int val_1 = val_3 + val_6;
            val_3 = val_6 + (val_3 * val_5);
            val_4 = val_4 + (((mem[this.grid] + 16 + 16 * 0) + 0) << 1);
            val_3 = val_7 + val_3;
            mem2[0] = (mem[this.grid] + ((mem[this.grid] + 16 + 16 * 0) + 0) << 1) + 32;
            val_3 = this.height;
            val_5 = val_5 + 1;
            val_4 = (long)this.width;
            if(val_5 < val_4)
            {
                    if(mem[this.grid] != 0)
            {
                goto label_10;
            }
            
            }
            
            label_9:
            val_6 = val_6 + 1;
            val_7 = val_7 - 1;
            if(val_6 < (val_3 << ))
            {
                goto label_12;
            }
            
            goto label_13;
            label_1:
            val_4 = this.width;
            val_5 = this.grid;
            label_13:
            this.width = val_3;
            this.height = val_4;
            mem2[0] = null;
        }
        public void DebugPrint()
        {
            string val_5 = "" + "grid:"("grid:");
            if(this.height >= 1)
            {
                    var val_6 = 0;
                do
            {
                val_5 = val_5 + "\n";
                if(this.width >= 1)
            {
                    var val_5 = 0;
                do
            {
                val_5 = val_5 + 1;
                val_5 = val_5 + this.grid[0][32].ToString() + "  ";
            }
            while(val_5 < this.width);
            
            }
            
                val_6 = val_6 + 1;
            }
            while(val_6 < this.height);
            
            }
            
            UnityEngine.Debug.LogError(message:  val_5);
        }
        public WFLShape()
        {
        
        }
    
    }

}
