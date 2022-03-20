using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WFLComb
    {
        // Fields
        private int size;
        private System.Collections.Generic.List<int> wordLengthCounts;
        private System.Collections.Generic.List<string> buildDirectives;
        
        // Methods
        public WFLComb(string data)
        {
            System.Collections.Generic.List<System.Int32> val_11;
            this.wordLengthCounts = new System.Collections.Generic.List<System.Int32>();
            this.buildDirectives = new System.Collections.Generic.List<System.String>();
            var val_14 = 0;
            do
            {
                this.wordLengthCounts.Add(item:  0);
                val_14 = val_14 + 1;
            }
            while(val_14 < 10);
            
            char[] val_3 = new char[1];
            val_3[0] = 124;
            System.String[] val_4 = data.Split(separator:  val_3);
            char[] val_5 = new char[1];
            val_5[0] = '+';
            int val_16 = val_6.Length;
            if(val_16 >= 1)
            {
                    var val_17 = 0;
                val_16 = val_16 & 4294967295;
                do
            {
                int val_7 = System.Int32.Parse(s:  null);
                val_11 = this.wordLengthCounts;
                if(val_16 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_16 = val_16 + (val_7 << 2);
                val_11.set_Item(index:  val_7, value:  (((val_6.Length & 4294967295) + (val_7) << 2) + 32) + 1);
                int val_18 = this.size;
                val_17 = val_17 + 1;
                val_18 = val_18 + val_7;
                this.size = val_18;
            }
            while(val_17 < (val_6.Length << ));
            
            }
            
            if((System.Linq.Enumerable.Count<System.String>(source:  val_4)) <= 1)
            {
                    return;
            }
            
            val_11 = 1152921509851232320;
            do
            {
                var val_10 = 5 - 4;
                this.buildDirectives.Add(item:  val_4[1]);
                var val_13 = 5 + 1;
            }
            while((5 - 3) < ((System.Linq.Enumerable.Count<System.String>(source:  val_4)) << ));
        
        }
        public bool CanSupport(SLC.Minigames.WordFill.WFCategory cat)
        {
            var val_2;
            System.Collections.Generic.List<System.Int32> val_3;
            var val_4;
            bool val_2 = true;
            val_2 = 0;
            label_10:
            val_3 = this.wordLengthCounts;
            if(val_2 >= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + 0;
            var val_3 = (true + 0) + 32;
            if(val_3 < 1)
            {
                goto label_3;
            }
            
            System.Collections.Generic.List<System.String> val_1 = cat.words.Item[0];
            val_3 = this.wordLengthCounts;
            if(val_2 >= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + 0;
            if(W24 < (((true + 0) + 32 + 0) + 32))
            {
                goto label_9;
            }
            
            label_3:
            val_2 = val_2 + 1;
            if(val_2 < 10)
            {
                goto label_10;
            }
            
            val_4 = 1;
            return (bool)val_4;
            label_9:
            val_4 = 0;
            return (bool)val_4;
        }
        public SLC.Minigames.WordFill.WordFillLevel CreateLevel(SLC.Minigames.WordFill.WFCategory cat, System.Collections.Generic.Dictionary<string, SLC.Minigames.WordFill.WFLShapeDef> shapeDefs)
        {
            int val_28 = this.size;
            SLC.Minigames.WordFill.WordFillLevel val_1 = new SLC.Minigames.WordFill.WordFillLevel(size:  val_28 = this.size);
            int val_2 = RandomSet.singleInRange(lowest:  0, highest:  -1970268913);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            char[] val_3 = new char[1];
            val_3[0] = ',';
            System.String[] val_4 = (RandomSet.__il2cppRuntimeField_cctor_finished + (val_2) << 3) + 32.Split(separator:  val_3);
            if(val_4.Length < 1)
            {
                goto label_9;
            }
            
            var val_29 = 0;
            label_45:
            val_28 = val_4[val_29];
            int val_7 = System.Int32.Parse(s:  val_28.Chars[0].ToString());
            System.Collections.Generic.List<System.String> val_8 = cat.words.Item[val_7];
            System.Collections.Generic.List<System.String> val_9 = cat.words.Item[val_7];
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            label_30:
            if(((SLC.Minigames.WordFill.WordFillLevel)[1152921519816487440].answers.Contains(item:  0)) == false)
            {
                goto label_22;
            }
            
            System.Collections.Generic.List<System.String> val_14 = cat.words.Item[val_7];
            System.Collections.Generic.List<System.String> val_15 = cat.words.Item[val_7];
            int val_17 = RandomSet.singleInRange(lowest:  0, highest:  (RandomSet.singleInRange(lowest:  0, highest:  val_4 - 1)) - 1);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((SLC.Minigames.WordFill.WordFillLevel)[1152921519816487440].answers != null)
            {
                goto label_30;
            }
            
            label_22:
            if(val_4[0x0][0].m_stringLength < 3)
            {
                goto label_34;
            }
            
            var val_28 = 2;
            label_43:
            char val_23 = val_28.Chars[2] & 65535;
            if(val_23 == 'v')
            {
                goto label_35;
            }
            
            if(val_23 == 'r')
            {
                goto label_41;
            }
            
            if(val_23 != 'h')
            {
                goto label_37;
            }
            
            goto label_41;
            label_35:
            label_41:
            label_37:
            val_28 = val_28 + 1;
            if(val_28 < val_4[0x0][0].m_stringLength)
            {
                goto label_43;
            }
            
            label_34:
            val_1.AddShape(shape:  shapeDefs.Item[val_28.Substring(startIndex:  0, length:  2)].GenerateShape(word:  0));
            (SLC.Minigames.WordFill.WordFillLevel)[1152921519816487440].answers.Add(item:  0);
            val_29 = val_29 + 1;
            if(val_29 < (val_4 + 24))
            {
                goto label_45;
            }
            
            label_9:
            int val_24 = RandomSet.singleInRange(lowest:  0, highest:  2);
            if(val_24 != 2)
            {
                    if(val_24 == 1)
            {
                
            }
            
            }
            
            int val_25 = RandomSet.singleInRange(lowest:  0, highest:  3);
            if(val_25 < 1)
            {
                    return val_1;
            }
            
            int val_26 = val_25 + 1;
            do
            {
                val_26 = val_26 - 1;
            }
            while(val_26 >= 2);
            
            return val_1;
        }
    
    }

}
