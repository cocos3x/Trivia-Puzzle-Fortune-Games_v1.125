using UnityEngine;

namespace CrosswordCreator.Crossword
{
    public class Crossword
    {
        // Fields
        private int wMax;
        private int hMax;
        private int xOffset;
        private int yOffset;
        private int xWindow;
        private int yWindow;
        private char[,] board;
        private bool[,] isAvail;
        private int wDataMax;
        private int hDataMax;
        public System.Collections.Generic.Dictionary<string, CrosswordCreator.Crossword.WordTuple> WordTuples;
        private readonly int[] HORIZGAIN;
        private readonly int[] VERTGAIN;
        private const char EMPTY = '\x20';
        
        // Properties
        public char Item { get; set; }
        public int Width { get; }
        public int Height { get; }
        
        // Methods
        public Crossword(int maxWidth, int maxHeight)
        {
            this.WordTuples = new System.Collections.Generic.Dictionary<System.String, CrosswordCreator.Crossword.WordTuple>();
            int[] val_2 = new int[2];
            val_2[0] = 1;
            this.HORIZGAIN = val_2;
            int[] val_3 = new int[2];
            val_3[0] = 1;
            this.VERTGAIN = val_3;
            int val_4 = maxWidth << 1;
            int val_5 = maxHeight << 1;
            val_4 = val_4 + 7;
            val_5 = val_5 + 7;
            this.wMax = maxWidth;
            this.hMax = maxHeight;
            this.wDataMax = val_4;
            this.hDataMax = val_5;
            this.board = null;
            this.isAvail = null;
            this.Reset();
        }
        public void Reset()
        {
            int val_3 = this.wDataMax;
            this.xWindow = 1;
            this.yWindow = 0;
            int val_1 = (val_3 < 0) ? (val_3 + 1) : (val_3);
            int val_2 = (this.hDataMax < 0) ? (this.hDataMax + 1) : this.hDataMax;
            val_1 = val_1 >> 1;
            val_2 = val_2 >> 1;
            this.xOffset = val_1;
            this.yOffset = val_2;
            if(val_3 >= 1)
            {
                    var val_6 = 0;
                do
            {
                if(this.hDataMax >= 1)
            {
                    var val_5 = 0;
                do
            {
                var val_3 = X13 + 16;
                val_3 = val_5 + (val_6 * val_3);
                this.board[val_3] = 32;
                System.Boolean[,] val_4 = this.isAvail;
                val_4 = val_4 + (val_6 * ((0 * X13 + 16) + 0 + 16));
                val_4 = val_4 + val_5;
                mem2[0] = 1;
                val_5 = val_5 + 1;
            }
            while(val_5 < this.hDataMax);
            
                val_3 = this.wDataMax;
            }
            
                val_6 = val_6 + 1;
            }
            while(val_6 < (val_3 << ));
            
            }
            
            this.WordTuples.Clear();
            Crossword.Crosspoint.Clear();
        }
        public bool HasAvailableCrosspoints()
        {
            var val_4;
            var val_5;
            if(this.WordTuples.Count != 0)
            {
                    val_4 = null;
                var val_3 = (Crossword.Crosspoint.Count > 0) ? 1 : 0;
                return (bool)val_5;
            }
            
            val_5 = 1;
            return (bool)val_5;
        }
        public bool AddWord(string word)
        {
            var val_12;
            var val_13;
            CrosswordCreator.Crossword.WordTuple val_14;
            var val_15;
            var val_16;
            val_12 = this;
            if(this.WordTuples.Count == 0)
            {
                goto label_2;
            }
            
            val_13 = 0;
            goto label_3;
            label_19:
            if(word.m_stringLength >= 1)
            {
                    val_14 = Crossword.Crosspoint.Get(index:  0);
                var val_15 = 0;
                do
            {
                if((word.Chars[0] & 65535) == val_3.l)
            {
                    if((this.CanPlaceWord(word:  word, x:  val_3.x, y:  val_3.y, dir:  val_3.dir, letterindex:  0)) != false)
            {
                    int val_13 = this.HORIZGAIN[(long)val_3.dir];
                int val_14 = this.VERTGAIN[(long)val_3.dir];
                CrosswordCreator.Crossword.WordTuple val_7 = null;
                val_14 = val_3.y - (val_14 * val_15);
                val_13 = val_3.x - (val_13 * val_15);
                val_7 = new CrosswordCreator.Crossword.WordTuple();
                .word = word;
                .x = val_13;
                .y = val_14;
                .dir = val_3.dir;
                new System.Collections.Generic.List<CrosswordCreator.Crossword.WordTuple>().Add(item:  val_7);
                val_12 = val_12;
            }
            
            }
            
                val_15 = val_15 + 1;
            }
            while(val_15 < word.m_stringLength);
            
            }
            
            val_13 = val_13 + 1;
            label_3:
            val_15 = null;
            if(val_13 < Crossword.Crosspoint.Count)
            {
                goto label_19;
            }
            
            if(val_13 == 0)
            {
                goto label_21;
            }
            
            int val_10 = RandomSet.singleInRange(lowest:  0, highest:  val_13 - 1);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.PlaceWord(wt:  (RandomSet.__il2cppRuntimeField_cctor_finished + (val_10) << 3) + 32);
            val_16 = 1;
            return (bool)val_16;
            label_2:
            val_16 = 1;
            CrosswordCreator.Crossword.WordTuple val_12 = null;
            val_14 = val_12;
            val_12 = new CrosswordCreator.Crossword.WordTuple();
            .word = word;
            .x = this.xOffset;
            .dir = RandomSet.singleInRange(lowest:  0, highest:  1);
            this.PlaceWord(wt:  val_12);
            return (bool)val_16;
            label_21:
            val_16 = 0;
            return (bool)val_16;
        }
        public void Trim()
        {
            var val_3;
            var val_4;
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_2 = this.WordTuples.Values.GetEnumerator();
            goto label_3;
            label_5:
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            int val_12 = this.xOffset;
            val_12 = (val_3 + 24) - val_12;
            mem2[0] = val_12;
            int val_13 = this.yOffset;
            val_13 = (val_3 + 24 + 4) - val_13;
            mem2[0] = val_13;
            label_3:
            if(val_4.MoveNext() == true)
            {
                goto label_5;
            }
            
            val_4.Dispose();
            if(this.yWindow <= this.xWindow)
            {
                    return;
            }
            
            this.xWindow = this.yWindow;
            this.yWindow = this.xWindow;
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_7 = this.WordTuples.Values.GetEnumerator();
            this = 1152921504620371968;
            goto label_9;
            label_13:
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            mem2[0] = val_3 + 24;
            var val_8 = (val_3 + 32) - 1;
            mem2[0] = (val_8 < 0) ? (1 - (val_3 + 32)) : (val_8);
            label_9:
            if(val_4.MoveNext() == true)
            {
                goto label_13;
            }
            
            val_4.Dispose();
        }
        public override string ToString()
        {
            int val_7;
            int val_8;
            string val_9;
            val_7 = this.yOffset;
            val_8 = this.yWindow;
            val_9 = "";
            if(val_7 >= (val_8 + val_7))
            {
                    return (string)val_9;
            }
            
            var val_11 = (long)val_7;
            do
            {
                int val_9 = this.xOffset;
                int val_7 = this.xWindow;
                val_7 = val_7 + val_9;
                if(val_9 < val_7)
            {
                    do
            {
                var val_8 = this.yWindow + 16;
                val_8 = val_11 + (val_8 * val_9);
                int val_10 = this.xOffset;
                val_9 = val_9 + 1;
                val_9 = val_9 + this.board[val_8][32].ToString();
                val_10 = this.xWindow + val_10;
            }
            while(val_9 < (val_10 << ));
            
                val_7 = this.yOffset;
                val_8 = this.yWindow;
            }
            
                int val_4 = val_7 + val_8;
                val_4 = val_4 - 1;
                if(val_11 < (val_4 << ))
            {
                    val_7 = this.yOffset;
                val_8 = this.yWindow;
                val_9 = val_9 + "\n";
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < ((val_8 + val_7) << ));
            
            return (string)val_9;
        }
        public char get_Item(int i, int j)
        {
            int val_1 = this.xOffset;
            val_1 = val_1 + i;
            int val_2 = this.yOffset;
            val_2 = val_2 + j;
            var val_3 = (long)val_1;
            val_3 = (long)val_2 + ((X10 + 16) * val_3);
            return (char)this.board[val_3];
        }
        public void set_Item(int i, int j, char value)
        {
            int val_1 = this.xOffset;
            val_1 = val_1 + i;
            int val_2 = this.yOffset;
            val_2 = val_2 + j;
            var val_3 = (long)val_1;
            val_3 = (long)val_2 + ((X10 + 16) * val_3);
            this.board[val_3] = value;
        }
        public int get_Width()
        {
            return (int)this.xWindow;
        }
        public int get_Height()
        {
            return (int)this.yWindow;
        }
        private bool IsValidPosition(int x, int y)
        {
            var val_3;
            int val_4 = this.xOffset;
            int val_3 = this.xWindow;
            val_3 = val_3 + val_4;
            val_3 = val_3 - this.wMax;
            if(val_3 > x)
            {
                    val_3 = 0;
                return (bool)(this.isAvail[val_6] == true) ? 1 : 0;
            }
            
            val_3 = 0;
            if((this.hMax + this.yOffset) <= y)
            {
                    return (bool)(this.isAvail[val_6] == true) ? 1 : 0;
            }
            
            val_4 = this.wMax + val_4;
            if(val_4 <= x)
            {
                    return (bool)(this.isAvail[val_6] == true) ? 1 : 0;
            }
            
            int val_5 = this.yWindow;
            val_5 = val_5 + this.yOffset;
            val_5 = val_5 - this.hMax;
            if(val_5 > y)
            {
                    return (bool)(this.isAvail[val_6] == true) ? 1 : 0;
            }
            
            var val_6 = ((this.yWindow + this.yOffset) - this.hMax) + 16;
            val_6 = (long)y + (val_6 * (long)x);
            return (bool)(this.isAvail[val_6] == true) ? 1 : 0;
        }
        private void ExtendWindow(int x, int y)
        {
            int val_5;
            int val_6;
            val_5 = this.xOffset;
            if()
            {
                    int val_5 = this.xWindow;
                this.xOffset = x;
                val_5 = (val_5 - x) + val_5;
                this.xWindow = val_5;
                val_5 = x;
            }
            
            val_6 = this.yOffset;
            if()
            {
                    int val_6 = this.yWindow;
                this.yOffset = y;
                val_6 = (val_6 - y) + val_6;
                this.yWindow = val_6;
                val_6 = y;
            }
            
            int val_7 = this.xWindow;
            val_7 = val_7 + val_5;
            if(val_7 <= x)
            {
                    val_5 = (x + 1) - val_5;
                this.xWindow = val_5;
            }
            
            int val_8 = this.yWindow;
            val_8 = val_8 + val_6;
            if(val_8 > y)
            {
                    return;
            }
            
            int val_4 = y + 1;
            val_4 = val_4 - val_6;
            this.yWindow = val_4;
        }
        private bool CanPlaceWord(string word, int x, int y, int dir, int letterindex = 0)
        {
            int val_13;
            int val_14;
            int val_15;
            int val_16;
            int val_17;
            int val_18;
            var val_19;
            System.Char[,] val_20;
            System.Int32[] val_21;
            var val_22;
            val_13 = this.HORIZGAIN.Length;
            val_14 = this.VERTGAIN.Length;
            val_15 = this.HORIZGAIN[(long)dir];
            val_16 = this.VERTGAIN[(long)dir];
            val_17 = x - (val_15 * letterindex);
            val_18 = y - (val_16 * letterindex);
            if(word.m_stringLength < 1)
            {
                goto label_5;
            }
            
            val_19 = 0;
            label_31:
            if((this.IsValidPosition(x:  val_17, y:  val_18)) == false)
            {
                goto label_38;
            }
            
            val_20 = this.board;
            var val_18 = val_16;
            var val_11 = this.VERTGAIN[(long)(int)(dir)][0] + 16;
            val_11 = (long)val_18 + (val_11 * (long)val_17);
            char val_12 = val_20[val_11];
            if(val_12 == ' ')
            {
                goto label_10;
            }
            
            if(val_12 != word.Chars[0])
            {
                goto label_38;
            }
            
            val_20 = this.board;
            label_10:
            if((val_20[(long)val_18 + (val_18 * (long)val_17)]) != ' ')
            {
                goto label_15;
            }
            
            val_21 = this.HORIZGAIN;
            int val_14 = this.VERTGAIN[(long)dir];
            int val_15 = val_21[(long)dir];
            var val_16 = (long)val_17 - val_14;
            val_16 = ((long)val_18 - val_15) + (val_18 * val_16);
            if(val_20[val_16] != ' ')
            {
                goto label_38;
            }
            
            val_14 = val_14 + val_17;
            val_18 = ((long)val_15 + val_18) + (val_18 * (long)val_14);
            if(val_20[val_18] == ' ')
            {
                goto label_25;
            }
            
            goto label_38;
            label_15:
            val_21 = this.HORIZGAIN;
            label_25:
            val_13 = this.HORIZGAIN.Length;
            val_14 = this.VERTGAIN.Length;
            val_15 = val_21[(long)dir];
            val_16 = this.VERTGAIN[(long)dir];
            val_19 = val_19 + 1;
            val_17 = val_15 + val_17;
            val_18 = val_16 + val_18;
            if(val_19 < word.m_stringLength)
            {
                goto label_31;
            }
            
            label_5:
            int val_7 = letterindex + 1;
            val_16 = y - (val_16 * val_7);
            var val_20 = (long)val_16;
            val_20 = val_20 + (val_15 * ((long)x - (val_15 * val_7)));
            if(this.board[val_20] == ' ')
            {
                    if((this.IsValidPosition(x:  val_17, y:  val_18)) != false)
            {
                    var val_22 = (this.HORIZGAIN[(long)(int)(dir)][0] * (long)(int)(x - (this.HORIZGAIN[(long)(int)(dir)][0] * (letterindex + 1)))) + (long)(int)(y - (this.VERTGAIN[(long)(int)(dir)][0] * (letterindex + 1))) + 16;
                val_22 = (long)val_18 + (val_22 * (long)val_17);
                var val_10 = (this.board[val_22] == ' ') ? 1 : 0;
                return (bool)val_22;
            }
            
            }
            
            label_38:
            val_22 = 0;
            return (bool)val_22;
        }
        private void PlaceWord(CrosswordCreator.Crossword.WordTuple wt)
        {
            var val_9;
            var val_52;
            int val_53;
            var val_54;
            int val_55;
            System.Char[,] val_56;
            var val_57;
            var val_58;
            var val_59;
            var val_60;
            int val_61;
            var val_62;
            int val_63;
            System.Collections.Generic.List<Crosspoint> val_1 = null;
            val_52 = val_1;
            val_53 = public System.Void System.Collections.Generic.List<Crosspoint>::.ctor();
            val_1 = new System.Collections.Generic.List<Crosspoint>();
            if(wt == null)
            {
                    throw new NullReferenceException();
            }
            
            if(wt.word == null)
            {
                    throw new NullReferenceException();
            }
            
            val_54 = 1152921518060434352;
            var val_46 = 0;
            label_15:
            val_55 = wt.x;
            if(val_46 >= wt.word.m_stringLength)
            {
                goto label_3;
            }
            
            if(this.HORIZGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.VERTGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_45 = wt.y;
            val_56 = this.board;
            val_53 = val_46;
            if(val_56 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_55 = val_55 + (this.HORIZGAIN[wt.dir] * val_46);
            val_45 = val_45 + (this.VERTGAIN[wt.dir] * val_46);
            this.HORIZGAIN[wt.dir] = (long)val_45 + (this.HORIZGAIN[wt.dir] * (long)val_55);
            val_56[this.HORIZGAIN[wt.dir]] = wt.word.Chars[0];
            val_53 = val_45;
            Crosspoint val_3 = Crossword.Crosspoint.GetAt(x:  val_55, y:  val_53);
            if(val_3 != null)
            {
                    if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_53 = val_3;
                val_1.Add(item:  val_53);
            }
            
            val_46 = val_46 + 1;
            if(wt.word != null)
            {
                goto label_15;
            }
            
            throw new NullReferenceException();
            label_3:
            val_53 = val_55;
            this.ExtendWindow(x:  val_53, y:  wt.y);
            if(this.HORIZGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(wt.word == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.VERTGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_49 = wt.word.m_stringLength;
            val_49 = val_49 - 1;
            val_53 = wt.x + (val_49 * this.HORIZGAIN[wt.dir]);
            this.ExtendWindow(x:  val_53, y:  wt.y + (this.VERTGAIN[wt.dir] * val_49));
            if(this.HORIZGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.VERTGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            val_53 = wt.x - this.HORIZGAIN[wt.dir];
            this.MarkUnavailable(x:  val_53, y:  wt.y - this.VERTGAIN[wt.dir]);
            if(this.HORIZGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(wt.word == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.VERTGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            val_53 = wt.x + (wt.word.m_stringLength * this.HORIZGAIN[wt.dir]);
            this.MarkUnavailable(x:  val_53, y:  wt.y + (this.VERTGAIN[wt.dir] * wt.word.m_stringLength));
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_7 = val_1.GetEnumerator();
            val_52 = 1152921518060784560;
            label_42:
            if(val_9.MoveNext() == false)
            {
                goto label_32;
            }
            
            this.MarkUnavailable(x:  val_8 + 16, y:  val_8 + 16 + 4);
            val_57 = mem[val_8 + 16 + 4];
            val_57 = val_8 + 16 + 4;
            if((this.IsLettercorner(x:  (val_8 + 16) - 1, y:  val_57 - 1)) != false)
            {
                    val_57 = mem[val_8 + 16 + 4];
                val_57 = val_8 + 16 + 4;
                this.MarkUnavailable(x:  (val_8 + 16) - 1, y:  val_57 - 1);
            }
            
            val_58 = mem[val_8 + 16 + 4];
            val_58 = val_8 + 16 + 4;
            if((this.IsLettercorner(x:  (val_8 + 16) + 1, y:  val_58 - 1)) != false)
            {
                    val_58 = mem[val_8 + 16 + 4];
                val_58 = val_8 + 16 + 4;
                this.MarkUnavailable(x:  (val_8 + 16) + 1, y:  val_58 - 1);
            }
            
            val_59 = mem[val_8 + 16 + 4];
            val_59 = val_8 + 16 + 4;
            if((this.IsLettercorner(x:  (val_8 + 16) - 1, y:  val_59 + 1)) != false)
            {
                    val_59 = mem[val_8 + 16 + 4];
                val_59 = val_8 + 16 + 4;
                this.MarkUnavailable(x:  (val_8 + 16) - 1, y:  val_59 + 1);
            }
            
            val_60 = mem[val_8 + 16];
            val_60 = val_8 + 16;
            if((this.IsLettercorner(x:  val_60 + 1, y:  (val_8 + 16 + 4) + 1)) != false)
            {
                    val_60 = mem[val_8 + 16];
                val_60 = val_8 + 16;
                this.MarkUnavailable(x:  val_60 + 1, y:  (val_8 + 16 + 4) + 1);
            }
            
            val_61 = (val_8 + 16 + 4) - 1;
            if((this.IsSandwiched(x:  val_8 + 16, y:  val_61, dir:  0)) != false)
            {
                    val_61 = (val_8 + 16 + 4) - 1;
                this.MarkUnavailable(x:  val_8 + 16, y:  val_61);
            }
            
            val_62 = mem[val_8 + 16];
            val_62 = val_8 + 16;
            if((this.IsSandwiched(x:  val_62 + 1, y:  val_8 + 16 + 4, dir:  1)) != false)
            {
                    val_62 = mem[val_8 + 16];
                val_62 = val_8 + 16;
                this.MarkUnavailable(x:  val_62 + 1, y:  val_8 + 16 + 4);
            }
            
            val_63 = (val_8 + 16 + 4) + 1;
            if((this.IsSandwiched(x:  val_8 + 16, y:  val_63, dir:  0)) != false)
            {
                    val_63 = (val_8 + 16 + 4) + 1;
                this.MarkUnavailable(x:  val_8 + 16, y:  val_63);
            }
            
            if((this.IsSandwiched(x:  (val_8 + 16) - 1, y:  val_8 + 16 + 4, dir:  1)) == false)
            {
                goto label_42;
            }
            
            this.MarkUnavailable(x:  (val_8 + 16) - 1, y:  val_8 + 16 + 4);
            goto label_42;
            label_32:
            val_9.Dispose();
            val_53 = wt.word;
            if(val_53 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_56 = 1152921504620371968;
            val_52 = 0;
            label_57:
            if(val_52 >= wt.word.m_stringLength)
            {
                goto label_44;
            }
            
            if(this.HORIZGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.VERTGAIN == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.isAvail == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_39 = wt.x + (this.HORIZGAIN[wt.dir] * val_52);
            var val_56 = wt.x + 16;
            val_55 = wt.y + (this.VERTGAIN[wt.dir] * val_52);
            val_56 = (long)val_55 + (val_56 * (long)val_39);
            if(this.isAvail[val_56] != false)
            {
                    int val_58 = wt.dir;
                int val_41 = val_58 - 1;
                val_58 = (val_41 < 0) ? (1 - val_58) : (val_41);
                Crossword.Crosspoint.Add(x:  val_39, y:  val_55, l:  val_53.Chars[0], dir:  val_58);
                val_53 = wt.word;
            }
            
            val_52 = val_52 + 1;
            if(val_53 != null)
            {
                goto label_57;
            }
            
            throw new NullReferenceException();
            label_44:
            if(this.WordTuples == null)
            {
                    throw new NullReferenceException();
            }
            
            this.WordTuples.Add(key:  val_53, value:  wt);
        }
        private bool IsLettercorner(int x, int y)
        {
            var val_11 = (long)y - 1;
            var val_2 = (X10 + 16) * (long)x;
            val_11 = val_2 + val_11;
            char val_12 = this.board[val_11];
            var val_14 = (long)x + 1;
            if(val_12 != ' ')
            {
                    if((this.board[(long)y + ((X10 + 16) * val_14)]) != ' ')
            {
                    return true;
            }
            
            }
            
            val_14 = (long)y + ((X10 + 16) * val_14);
            int val_5 = y + 1;
            if(this.board[val_14] != ' ')
            {
                    if((this.board[val_2 + (val_5 << )]) != ' ')
            {
                    return true;
            }
            
            }
            
            val_2 = val_2 + (val_5 << );
            int val_7 = x - 1;
            if(this.board[val_2] != ' ')
            {
                    var val_18 = (long)val_7;
                val_18 = (long)y + ((X10 + 16) * val_18);
                if(this.board[val_18] != ' ')
            {
                    return true;
            }
            
            }
            
            var val_20 = (long)val_7;
            val_20 = (long)y + ((X10 + 16) * val_20);
            return (bool)((val_12 != ' ') ? 1 : 0) & ((this.board[val_20] != ' ') ? 1 : 0);
        }
        private bool IsSandwiched(int x, int y, int dir)
        {
            var val_5;
            int val_5 = this.HORIZGAIN[(long)dir];
            var val_7 = (long)x - val_5;
            val_7 = ((long)y - this.VERTGAIN[(long)dir]) + ((X13 + 16) * val_7);
            if(this.isAvail[val_7] != false)
            {
                    val_5 = 0;
                return (bool)(this.isAvail[val_9] == false) ? 1 : 0;
            }
            
            val_5 = val_5 + y;
            var val_9 = (long)val_5;
            val_9 = val_9 + ((X13 + 16) * ((long)val_5 + x));
            return (bool)(this.isAvail[val_9] == false) ? 1 : 0;
        }
        private void MarkUnavailable(int x, int y)
        {
            var val_1 = X9 + 16;
            val_1 = (long)y + (val_1 * (long)x);
            this.isAvail[val_1] = false;
            Crossword.Crosspoint.Remove(x:  x, y:  y);
        }
        public int CountFreeSpaces()
        {
            var val_3;
            int val_7 = this.yOffset;
            int val_1 = this.yWindow + val_7;
            if(val_7 < val_1)
            {
                    int val_3 = this.xWindow;
                val_3 = 0;
                val_3 = val_3 + this.xOffset;
                do
            {
                if(this.xOffset < (long)val_3)
            {
                    int val_6 = this.xOffset;
                do
            {
                var val_4 = X14 + 16;
                val_4 = val_7 + (val_4 * val_6);
                val_6 = val_6 + 1;
                var val_2 = (this.board[val_4] == ' ') ? (val_3 + 1) : (val_3);
            }
            while(val_6 < (long)val_3);
            
            }
            
                val_7 = val_7 + 1;
            }
            while(val_7 < (long)val_1);
            
                return (int)val_3;
            }
            
            val_3 = 0;
            return (int)val_3;
        }
    
    }

}
