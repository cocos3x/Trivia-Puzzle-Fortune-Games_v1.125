using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WFLShapeDef
    {
        // Fields
        public System.Collections.Generic.List<char> grid;
        public int size;
        public string id;
        public int width;
        public int height;
        
        // Methods
        public WFLShapeDef(string data)
        {
            System.Collections.Generic.List<System.Char> val_13;
            System.Collections.Generic.List<System.Char> val_1 = null;
            val_13 = val_1;
            val_1 = new System.Collections.Generic.List<System.Char>();
            this.grid = val_13;
            char[] val_2 = new char[1];
            val_2[0] = 124;
            System.String[] val_3 = data.Split(separator:  val_2);
            this.size = System.Int32.Parse(s:  val_3[0].Chars[0].ToString());
            this.id = val_3[0];
            if((System.Linq.Enumerable.Count<System.String>(source:  val_3)) < 2)
            {
                    return;
            }
            
            var val_20 = 1;
            do
            {
                char[] val_8 = new char[1];
                val_8[0] = '.';
                val_13 = val_3[val_20].Split(separator:  val_8);
                if(this.width == 0)
            {
                    string val_16 = val_13[0];
                this.width = val_9[0].m_stringLength;
            }
            
                if(this.height == 0)
            {
                    this.height = System.Linq.Enumerable.Count<System.String>(source:  val_13);
            }
            
                if(val_9.Length >= 1)
            {
                    var val_19 = 0;
                do
            {
                if(val_9[0x0][0].m_stringLength >= 1)
            {
                    var val_18 = 0;
                do
            {
                this.grid.Add(item:  val_13[val_19].Chars[0]);
                val_18 = val_18 + 1;
            }
            while(val_18 < val_9[0x0][0].m_stringLength);
            
            }
            
                val_19 = val_19 + 1;
            }
            while(val_19 < val_9.Length);
            
            }
            
                val_20 = val_20 + 1;
            }
            while(val_20 < (System.Linq.Enumerable.Count<System.String>(source:  val_3)));
        
        }
        public SLC.Minigames.WordFill.WFLShape GenerateShape(string word)
        {
            var val_13;
            int val_14;
            var val_15;
            var val_16;
            int val_2 = this.height * this.width;
            if(W23 < (val_2 << 1))
            {
                    val_13 = 0;
            }
            else
            {
                    val_13 = RandomSet.singleInRange(lowest:  0, highest:  (W23 / val_2) - 1);
            }
            
            .width = this.width;
            .height = this.height;
            .grid = null;
            val_14 = this.height;
            if(val_14 < 1)
            {
                    return (SLC.Minigames.WordFill.WFLShape)new SLC.Minigames.WordFill.WFLShape();
            }
            
            int val_14 = this.width;
            var val_17 = 0;
            do
            {
                if(val_14 >= 1)
            {
                    var val_16 = 0;
                do
            {
                int val_13 = this.height;
                val_13 = val_17 + (val_13 * val_13);
                val_14 = val_14 * val_13;
                int val_7 = val_16 + val_14;
                if(this.height <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_14 = val_14 + (val_7 << 1);
                if((((this.width * (this.height * val_5) + 0) + ((0 + (this.width * (this.height * val_5) + 0))) << 1) + 32) == 45)
            {
                    val_15 = 45;
            }
            else
            {
                    if((RandomSet.singleInRange(lowest:  0, highest:  1)) == 1)
            {
                    val_16 = (1 - (System.Int32.Parse(s:  ((this.width * (this.height * val_5) + 0) + ((0 + (this.width * (this.height * val_5) + 0))) << 1) + 32.ToString()))) + this.size;
            }
            
                val_15 = word;
            }
            
                var val_15 = (1 - val_9) + 16;
                val_15 = val_17 + (val_15 * val_16);
                (SLC.Minigames.WordFill.WFLShape)[1152921519813347680].grid[val_15] = val_15.Chars[val_16 - 1];
                val_16 = val_16 + 1;
            }
            while(val_16 < this.width);
            
                val_14 = this.height;
            }
            
                val_17 = val_17 + 1;
            }
            while(val_17 < (val_14 << ));
            
            return (SLC.Minigames.WordFill.WFLShape)new SLC.Minigames.WordFill.WFLShape();
        }
    
    }

}
