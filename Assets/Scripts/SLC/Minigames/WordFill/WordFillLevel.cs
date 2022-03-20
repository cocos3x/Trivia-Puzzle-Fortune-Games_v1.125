using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WordFillLevel : WFLShape
    {
        // Fields
        public System.Collections.Generic.List<string> answers;
        public System.Collections.Generic.List<System.Collections.Generic.HashSet<int>> answerPaths;
        
        // Methods
        public WordFillLevel(int size)
        {
            double val_4;
            var val_5;
            var val_6;
            this.answers = new System.Collections.Generic.List<System.String>();
            this.answerPaths = new System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Int32>>();
            this = new System.Object();
            if(size <= 9)
            {
                goto label_1;
            }
            
            if(size == 12)
            {
                goto label_2;
            }
            
            if(size != 16)
            {
                goto label_6;
            }
            
            val_4 = 4;
            val_5 = 4;
            val_6 = 4;
            goto label_9;
            label_1:
            if(size == 6)
            {
                goto label_5;
            }
            
            if(size != 9)
            {
                goto label_6;
            }
            
            val_4 = 3;
            val_5 = 3;
            val_6 = 3;
            goto label_9;
            label_6:
            val_4 = 1.06099789568026E-313;
            val_6 = 4;
            val_5 = 5;
            goto label_9;
            label_2:
            val_4 = 8.48798316534329E-314;
            val_6 = 3;
            val_5 = 4;
            goto label_9;
            label_5:
            val_4 = 4.24399158341274E-314;
            val_6 = 3;
            val_5 = 2;
            label_9:
            mem[1152921519814447640] = val_4;
            mem[1152921519814447632] = null;
            if(W11 < 1)
            {
                    return;
            }
            
            var val_5 = 0;
            do
            {
                if(1152921518057479184 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_4 = val_4 + 1;
            }
            while(val_4 < 44318472);
            
            }
            
                val_5 = val_5 + 1;
            }
            while(val_5 < (val_4 << ));
        
        }
        public void AddShape(SLC.Minigames.WordFill.WFLShape shape)
        {
            var val_13;
            var val_14;
            int val_15;
            var val_16;
            int val_17;
            System.Collections.Generic.HashSet<System.Int32> val_1 = new System.Collections.Generic.HashSet<System.Int32>();
            var val_2 = W9 * 1152921510529772608;
            if(val_2 < 1)
            {
                goto label_1;
            }
            
            val_13 = 0;
            val_14 = 0;
            label_6:
            var val_18 = X11 + 16 + 16;
            val_18 = 0 + (val_18 * 0);
            var val_3 = X11 + (((X11 + 16 + 16 * 0) + 0) << 1);
            if(((X11 + ((X11 + 16 + 16 * 0) + 0) << 1) + 32) == 32)
            {
                goto label_7;
            }
            
            var val_4 = val_13 + 1;
            val_4 = ((val_4 == 1152921510529772608) ? 0 : (val_13 + 1)) + (1152921510529772608 * ((val_4 == 1152921510529772608) ? (val_14 + 1) : (val_14)));
            if(val_4 < val_2)
            {
                goto label_6;
            }
            
            goto label_7;
            label_1:
            val_14 = 0;
            val_13 = 0;
            label_7:
            val_15 = shape.width;
            int val_7 = val_15 - 1;
            if(val_7 < 1)
            {
                goto label_9;
            }
            
            val_16 = 0;
            label_14:
            var val_19 = X12 + 16;
            val_19 = val_19 * 0;
            if(shape.grid[val_19] != ('-'))
            {
                goto label_15;
            }
            
            val_16 = val_16 + 1;
            if(val_16 < val_7)
            {
                goto label_14;
            }
            
            goto label_15;
            label_9:
            val_16 = 0;
            label_15:
            val_17 = shape.height;
            if(val_16 < (val_17 * val_15))
            {
                    do
            {
                var val_21 = (shape.height * shape.width) + 16;
                val_21 = 0 + (val_21 * 0);
                char val_22 = shape.grid[val_21];
                if(val_22 != ('-'))
            {
                    var val_23 = shape.width + 16 + 16;
                val_23 = ((long)0 + val_14) + (val_23 * ((long)val_16 + (val_13 - val_16)));
                val_15 = val_15 + (((shape.width + 16 + 16 * (long)(int)((val_16 + (val_13 - val_16)))) + (long)(int)((0 + val_14))) << 1);
                mem2[0] = val_22;
                bool val_13 = val_1.Add(item:  ((long)val_16 + (val_13 - val_16)) + (val_15 * ((long)0 + val_14)));
                val_15 = shape.width;
                val_17 = shape.height;
            }
            
                var val_14 = val_16 + 1;
                val_14 = ((val_14 == val_15) ? 0 : (val_16 + 1)) + (val_15 * ((val_14 == val_15) ? (0 + 1) : 0));
            }
            while(val_14 < (val_17 * val_15));
            
            }
            
            this.answerPaths.Add(item:  val_1);
        }
        public override void HFlip()
        {
            this.HFlip();
            this.PathMod(type:  0);
        }
        public override void VFlip()
        {
            this.VFlip();
            this.PathMod(type:  1);
        }
        public override void Rot()
        {
            this.Rot();
            this.PathMod(type:  2);
        }
        public void PathMod(int type)
        {
            var val_3;
            var val_4;
            var val_23;
            var val_24;
            var val_25;
            System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Int32>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Int32>>();
            List.Enumerator<T> val_2 = this.answerPaths.GetEnumerator();
            var val_26 = 0;
            label_17:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_23 = val_3;
            System.Collections.Generic.HashSet<System.Int32> val_6 = new System.Collections.Generic.HashSet<System.Int32>();
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            HashSet.Enumerator<T> val_7 = val_23.GetEnumerator();
            label_13:
            if(val_4.MoveNext() == false)
            {
                goto label_4;
            }
            
            var val_23 = val_3;
            if(type == 2)
            {
                goto label_5;
            }
            
            if(type == 1)
            {
                goto label_6;
            }
            
            if(type != 0)
            {
                goto label_13;
            }
            
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = val_23 - ((val_23 / W9) * W9);
            var val_24 = ~val_23;
            val_24 = (W9 + val_23) + val_24;
            bool val_12 = val_6.Add(item:  val_24 - val_23);
            goto label_13;
            label_5:
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = val_23 / W9;
            var val_25 = ~val_13;
            val_25 = W10 + val_25;
            val_23 = val_23 - (val_13 * W9);
            bool val_15 = val_6.Add(item:  val_25 + (val_23 * W10));
            goto label_13;
            label_6:
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = val_23 / W9;
            val_23 = val_23 - (val_16 * W9);
            bool val_19 = val_6.Add(item:  val_23 + ((W10 + (~val_16)) * W9));
            goto label_13;
            label_4:
            val_23 = 0;
            val_26 = val_26 + 1;
            mem2[0] = 131;
            val_24 = public System.Void HashSet.Enumerator<System.Int32>::Dispose();
            val_4.Dispose();
            if(val_23 != 0)
            {
                goto label_14;
            }
            
            if(val_26 != 1)
            {
                    var val_20 = ((1152921519815195088 + ((0 + 1)) << 2) == 131) ? 1 : 0;
                val_20 = ((val_26 >= 0) ? 1 : 0) & val_20;
                val_26 = val_26 - val_20;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_6);
            goto label_17;
            label_2:
            var val_22 = val_26 + 1;
            mem2[0] = 163;
            val_4.Dispose();
            this.answerPaths = val_1;
            return;
            label_14:
            val_25 = val_23;
            val_24 = 0;
            throw val_25;
        }
        public int PathHFlip(int i)
        {
            int val_1 = i / W8;
            val_1 = i - (val_1 * W8);
            int val_2 = W8 + i;
            val_2 = val_2 + (~val_1);
            return (int)val_2 - val_1;
        }
        public int PathVFlip(int i)
        {
            int val_1 = i / W8;
            val_1 = i - (val_1 * W8);
            return (int)val_1 + ((W9 + (~val_1)) * W8);
        }
        public int PathRot(int i)
        {
            int val_1 = i / W8;
            var val_4 = ~val_1;
            val_4 = W9 + val_4;
            return (int)val_4 + ((i - (val_1 * W8)) * W9);
        }
        public void DebugPrintLevel()
        {
            System.Collections.Generic.List<System.String> val_6;
            string val_7;
            val_6 = this.answers;
            val_7 = "" + "answers: "("answers: ") + PrettyPrint.printJSON(obj:  val_6, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_6, types:  false, singleLineOutput:  false)) + "\n\ngrid:"("\n\ngrid:");
            if(("answers: ") >= 1)
            {
                    do
            {
                val_7 = val_7 + "\n";
                if(("answers: ") >= 1)
            {
                    var val_6 = 0;
                do
            {
                val_6 = val_6 + 1;
                val_7 = val_7 + ToString() + "  ";
            }
            while(val_6 < 44187272);
            
            }
            
                val_6 = 0 + 1;
            }
            while(val_6 < 44187272);
            
            }
            
            UnityEngine.Debug.LogError(message:  val_7);
        }
    
    }

}
