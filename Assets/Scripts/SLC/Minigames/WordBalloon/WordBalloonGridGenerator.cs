using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonGridGenerator
    {
        // Fields
        public const int MAXIMUM_GRID_WIDTH = 9;
        public const int MAXIMUM_GRID_HEIGHT = 11;
        private System.Collections.Generic.List<System.Collections.Generic.List<string>> gridContents;
        private System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface> horizontalSurfaceList;
        private System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface> verticalSurfaceList;
        private System.Collections.Generic.List<string> populatedWordsList;
        private System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordSolutionData> gridSolutionData;
        private System.Collections.Generic.Dictionary<int, string> slotIdToWordCollection;
        private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>> wordToSlotListCollection;
        private float[] weightageRow;
        private float[] weightageColumnModifier;
        private static SLC.Minigames.WordBalloon.WordBalloonGridGenerator instance;
        
        // Properties
        public static SLC.Minigames.WordBalloon.WordBalloonGridGenerator Instance { get; }
        
        // Methods
        public static SLC.Minigames.WordBalloon.WordBalloonGridGenerator get_Instance()
        {
            SLC.Minigames.WordBalloon.WordBalloonGridGenerator val_2;
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            if(SLC.Minigames.WordBalloon.WordBalloonGridGenerator.instance == null)
            {
                    SLC.Minigames.WordBalloon.WordBalloonGridGenerator val_1 = null;
                val_2 = val_1;
                val_1 = new SLC.Minigames.WordBalloon.WordBalloonGridGenerator();
                val_4 = null;
                val_4 = null;
                SLC.Minigames.WordBalloon.WordBalloonGridGenerator.instance = val_2;
                val_3 = null;
            }
            
            val_3 = null;
            return (SLC.Minigames.WordBalloon.WordBalloonGridGenerator)SLC.Minigames.WordBalloon.WordBalloonGridGenerator.instance;
        }
        public WordBalloonGridGenerator()
        {
            this.weightageRow = new float[11];
            this.weightageColumnModifier = new float[9];
            this.InitRandomizerWeights();
        }
        private void InitRandomizerWeights()
        {
            System.Single[] val_6;
            var val_7;
            val_6 = this.weightageColumnModifier;
            var val_7 = 0;
            label_9:
            if(val_7 >= this.weightageColumnModifier.Length)
            {
                goto label_4;
            }
            
            val_6 = this.weightageColumnModifier;
            float val_6 = 0f;
            val_6 = ((float)UnityEngine.Mathf.RoundToInt(f:  4.5f)) ?? val_6;
            val_6 = val_6 / ((float)UnityEngine.Mathf.RoundToInt(f:  4.5f));
            val_6[val_7] = DG.Tweening.DOVirtual.EasedValue(from:  0.05f, to:  1f, lifetimePercentage:  1f - val_6, easeType:  6);
            val_7 = val_7 + 1;
            if(this.weightageColumnModifier != null)
            {
                goto label_9;
            }
            
            label_4:
            val_7 = 0;
            do
            {
                int val_8 = this.weightageRow.Length;
                if(val_7 >= (val_8 << ))
            {
                    return;
            }
            
                val_8 = val_8 - 1;
                float val_5 = DG.Tweening.DOVirtual.EasedValue(from:  0f, to:  1f, lifetimePercentage:  0f / (float)val_8, easeType:  21);
                val_5 = 1f - val_5;
                val_5 = val_5 * 100f;
                this.weightageRow[val_7] = val_5;
                val_7 = val_7 + 1;
            }
            while(this.weightageRow != null);
            
            throw new NullReferenceException();
        }
        private SLC.Minigames.WordBalloon.WordBalloonGridSurface GetRandomSurface(string wordToPlace)
        {
            var val_14;
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface> val_15;
            float val_16;
            WordBalloonGridGenerator.<>c__DisplayClass16_0 val_1 = new WordBalloonGridGenerator.<>c__DisplayClass16_0();
            .wordToPlace = wordToPlace;
            RandomSet val_2 = new RandomSet();
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface> val_3 = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface>();
            this.CalculateHorizontalSurfaces();
            this.CalculateVerticalSurfaces();
            val_14 = 1152921504614887424;
            System.Collections.Generic.List<T> val_5 = this.horizontalSurfaceList.FindAll(match:  new System.Predicate<SLC.Minigames.WordBalloon.WordBalloonGridSurface>(object:  val_1, method:  System.Boolean WordBalloonGridGenerator.<>c__DisplayClass16_0::<GetRandomSurface>b__0(SLC.Minigames.WordBalloon.WordBalloonGridSurface obj)));
            if(1152921519854871376 >= 1)
            {
                    var val_14 = 0;
                do
            {
                if(val_14 >= 1152921519854871376)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3.Add(item:  "{0}{1}={2}");
                val_14 = val_14 + 1;
            }
            while(val_14 < 44367032);
            
            }
            
            val_15 = this.verticalSurfaceList;
            System.Collections.Generic.List<T> val_7 = val_15.FindAll(match:  new System.Predicate<SLC.Minigames.WordBalloon.WordBalloonGridSurface>(object:  val_1, method:  System.Boolean WordBalloonGridGenerator.<>c__DisplayClass16_0::<GetRandomSurface>b__1(SLC.Minigames.WordBalloon.WordBalloonGridSurface obj)));
            if(1152921519854887760 >= 1)
            {
                    do
            {
                if(0 >= 1152921519854887760)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3.Add(item:  static System.Void System.IO.FileStreamAsyncResult::CBWrapper(System.IAsyncResult ares));
                val_15 = 0 + 1;
            }
            while(val_15 < 44258872);
            
            }
            
            if(44258872 >= 1)
            {
                    val_14 = 1152921504762277888;
                var val_18 = 0;
                if(44258872 <= val_18)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_15 = static System.Void System.IO.FileStreamAsyncResult::CBWrapper(System.IAsyncResult ares);
                if(Width >= 1)
            {
                    var val_17 = 0;
                do
            {
                float val_16 = this.weightageColumnModifier[GetColumnIdBySurfaceIndex(index:  0)];
                val_17 = val_17 + 1;
                val_16 = ((this.weightageRow[static System.Void System.IO.FileStreamAsyncResult::CBWrapper(System.IAsyncResult ares).__il2cppRuntimeField_10]) / 9f) * val_16;
                val_16 = 0f + val_16;
            }
            while(val_17 < Width);
            
            }
            else
            {
                    val_16 = 0f;
            }
            
                val_2.add(item:  0, weight:  (float)UnityEngine.Mathf.RoundToInt(f:  val_16));
                val_18 = val_18 + 1;
            }
            
            int val_13 = val_2.roll(unweighted:  false);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            return (SLC.Minigames.WordBalloon.WordBalloonGridSurface)(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + (val_13) << 3) + 32;
        }
        private int GetRandomSurfaceIndexForWord(SLC.Minigames.WordBalloon.WordBalloonGridSurface targetSurface, int wordLength)
        {
            RandomSet val_1 = new RandomSet();
            if((targetSurface.Width - wordLength) < 1)
            {
                    return val_1.roll(unweighted:  false);
            }
            
            var val_10 = 0;
            do
            {
                val_1.add(item:  0, weight:  (float)UnityEngine.Mathf.RoundToInt(f:  (this.weightageColumnModifier[targetSurface.GetColumnIdBySurfaceIndex(index:  0)]) * 100f));
                val_10 = val_10 + 1;
            }
            while(val_10 < (targetSurface.Width - wordLength));
            
            return val_1.roll(unweighted:  false);
        }
        public SLC.Minigames.WordBalloon.WordBalloonLevelData Generate(System.Collections.Generic.List<string> wordList)
        {
            System.Collections.Generic.List<System.String> val_48;
            int val_49;
            int val_50;
            int val_51;
            int val_52;
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_53;
            var val_55;
            var val_56;
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_57;
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_59;
            System.Collections.Generic.List<System.Int32> val_60;
            WordBalloonGridGenerator.<>c__DisplayClass18_0 val_61;
            var val_62;
            System.Collections.Generic.List<System.String> val_63;
            val_48 = wordList;
            this.populatedWordsList = new System.Collections.Generic.List<System.String>();
            this.gridSolutionData = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordSolutionData>();
            this.wordToSlotListCollection = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>();
            this.slotIdToWordCollection = new System.Collections.Generic.Dictionary<System.Int32, System.String>();
            this.gridContents = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
            val_49 = 1152921515860184720;
            var val_57 = 0;
            do
            {
                System.Collections.Generic.List<System.String> val_6 = new System.Collections.Generic.List<System.String>();
                do
            {
                val_6.Add(item:  0);
                var val_7 = 11 - 1;
            }
            while();
            
                this.gridContents.Add(item:  val_6);
                val_57 = val_57 + 1;
            }
            while(val_57 < 8);
            
            if(1152921515860179456 < 1)
            {
                goto label_6;
            }
            
            val_50 = 0;
            label_43:
            if(val_50 >= 1152921515860179456)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            SLC.Minigames.WordBalloon.WordBalloonGridSurface val_8 = this.GetRandomSurface(wordToPlace:  "host");
            if(val_8.orientation != 1)
            {
                goto label_9;
            }
            
            val_50 = val_8.FirstColumnIndex;
            if((val_8.rowIndex != 0) || ((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_50, row:  0))) == true))
            {
                goto label_34;
            }
            
            if(val_50 > 8)
            {
                goto label_12;
            }
            
            val_51 = val_50;
            label_14:
            if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_51, row:  val_8.rowIndex))) == true)
            {
                goto label_13;
            }
            
            val_51 = val_51 + 1;
            if(val_51 < 8)
            {
                goto label_14;
            }
            
            label_12:
            val_51 = 0;
            label_13:
            if((val_51 != 1) || ((val_50 & 2147483648) != 0))
            {
                goto label_17;
            }
            
            val_51 = val_50;
            label_18:
            if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_51, row:  val_8.rowIndex))) == true)
            {
                goto label_17;
            }
            
            val_51 = val_51 - 1;
            if(val_51 > 0)
            {
                goto label_18;
            }
            
            val_51 = 0;
            label_17:
            if(val_51 < 0)
            {
                goto label_19;
            }
            
            if(val_51 <= val_50)
            {
                goto label_34;
            }
            
            do
            {
                val_49 = val_8.rowIndex;
                int val_16 = val_51 - 1;
                if(val_49 <= 10)
            {
                    do
            {
                if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_16, row:  val_49))) != true)
            {
                    this.CutAndPasteGridContent(fromCol:  val_16, fromRow:  val_49, toCol:  0, toRow:  val_49);
            }
            
                val_49 = val_49 + 1;
            }
            while(val_49 != 11);
            
            }
            
            }
            while(val_16 > val_50);
            
            goto label_34;
            label_9:
            SLC.Minigames.WordBalloon.WordBalloonGridSurface val_58 = val_8;
            val_50 = this.GetRandomSurfaceIndexForWord(targetSurface:  val_58, wordLength:  "host".__il2cppRuntimeField_10>>0&0xFFFFFFFF);
            var val_59 = 0;
            val_58 = val_59 + val_50;
            val_52 = val_8.rowIndex;
            val_49 = val_8.GetColumnIdBySurfaceIndex(index:  val_58);
            if(val_52 > 9)
            {
                goto label_28;
            }
            
            label_31:
            int val_23 = 10 - 1;
            if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_49, row:  10))) != false)
            {
                    if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_49, row:  val_23))) == true)
            {
                goto label_30;
            }
            
            }
            
            this.CutAndPasteGridContent(fromCol:  val_49, fromRow:  val_23, toCol:  val_49, toRow:  10);
            label_30:
            val_52 = val_8.rowIndex;
            if(val_23 > val_52)
            {
                goto label_31;
            }
            
            label_28:
            this.SetGridContent(col:  val_49, row:  val_52, newSlotLetterValue:  Chars[0].ToString(), word:  "host", indexOfValueWithinWord:  0);
            val_59 = val_59 + 1;
            goto label_40;
            label_19:
            if(val_51 < val_50)
            {
                    do
            {
                val_49 = val_8.rowIndex;
                int val_28 = val_51 + 1;
                if(val_49 <= 10)
            {
                    do
            {
                if((System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  val_28, row:  val_49))) != true)
            {
                    this.CutAndPasteGridContent(fromCol:  val_28, fromRow:  val_49, toCol:  0, toRow:  val_49);
            }
            
                val_49 = val_49 + 1;
            }
            while(val_49 != 11);
            
            }
            
            }
            while(val_28 != val_50);
            
            }
            
            label_34:
            var val_60 = 0;
            val_49 = val_8.rowIndex;
            this.SetGridContent(col:  val_50, row:  val_60 + val_49, newSlotLetterValue:  Chars[0].ToString(), word:  "host", indexOfValueWithinWord:  0);
            val_60 = val_60 + 1;
            label_40:
            this.populatedWordsList.Add(item:  "host");
            val_48 = val_48;
            var val_61 = wordList + 24;
            if(1 < val_61)
            {
                goto label_43;
            }
            
            label_6:
            val_53 = this.gridContents;
            var val_64 = 0;
            label_55:
            if(val_64 >= "host")
            {
                goto label_45;
            }
            
            val_55 = 0;
            val_56 = 0;
            goto label_46;
            label_54:
            if(val_61 <= val_64)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_61 = val_61 + 0;
            if(val_55 >= ((wordList + 24 + 0) + 32 + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_62 = (wordList + 24 + 0) + 32 + 16;
            val_62 = val_62 + 0;
            val_57 = this.gridContents;
            var val_63 = ~(System.String.IsNullOrEmpty(value:  ((wordList + 24 + 0) + 32 + 16 + 0) + 32));
            val_63 = val_63 & 1;
            val_55 = 1;
            val_56 = val_56 + val_63;
            label_46:
            if(((wordList + 24 + 0) + 32) <= val_64)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_63 = val_63 + 0;
            if(val_55 < (((~(val_34) & 1) + 0) + 32 + 24))
            {
                goto label_54;
            }
            
            var val_35 = (val_56 > 0) ? (val_56) : 0;
            val_64 = val_64 + 1;
            if(this.gridContents != null)
            {
                goto label_55;
            }
            
            label_45:
            if("host" >= 1)
            {
                    val_49 = 1152921515438576048;
                var val_66 = 0;
                do
            {
                if("host" <= val_66)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_61 = val_61 + 0;
                var val_65 = (wordList + 24 + 0) + 32 + 24;
                int val_36 = val_65 - 1;
                if(val_36 >= 0)
            {
                    long val_70 = 0;
                do
            {
                if(val_65 <= val_66)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_65 = val_65 + 0;
                ((wordList + 24 + 0) + 32 + 24 + 0) + 32.RemoveAt(index:  val_36);
                val_36 = val_36 - 1;
            }
            while(val_36 >= 0);
            
            }
            
                val_59 = this.gridContents;
                val_66 = val_66 + 1;
            }
            while(val_66 < val_70);
            
            }
            
            var val_37 = val_70 - 1;
            if(val_66 < 0)
            {
                goto label_97;
            }
            
            int val_71 = (long)val_37;
            label_98:
            if(val_71 >= val_37)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = val_37 + (((long)(int)((0 - 1))) << 3);
            var val_67 = ((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32;
            if(val_67 == 0)
            {
                goto label_74;
            }
            
            if(val_71 >= val_67)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_67 = val_67 + (((long)(int)((0 - 1))) << 3);
            var val_68 = (((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24;
            if(val_68 < 1)
            {
                goto label_74;
            }
            
            if(val_71 >= val_68)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_68 = val_68 + (((long)(int)((0 - 1))) << 3);
            if((((((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24 + ((long)(int)((0 - 1))) << 3) + 32 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_69 = ((((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24 + ((long)(int)((0 - 1))) << 3) + 32 + 16;
            if((System.String.IsNullOrEmpty(value:  ((((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24 + ((long)(int)((0 - 1))) << 3) + 32 + 16 + 32)) == false)
            {
                goto label_79;
            }
            
            label_74:
            if(val_71 >= val_49)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_69 = val_69 + (((long)(int)((0 - 1))) << 3);
            val_59 = mem[(((((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24 + ((long)(int)((0 - 1))) << 3) + 32 + 16 + ((long)(int)((0 - 1))) << 3) + 32 + 24];
            val_59 = (((((0 - 1) + ((long)(int)((0 - 1))) << 3) + 32 + ((long)(int)((0 - 1))) << 3) + 32 + 24 + ((long)(int)((0 - 1))) << 3) + 32 + 16 + ((long)(int)((0 - 1))) << 3) + 32 + 24;
            WordBalloonGridGenerator.<>c__DisplayClass18_0 val_39 = null;
            val_61 = val_39;
            val_39 = new WordBalloonGridGenerator.<>c__DisplayClass18_0();
            val_62 = val_59 * val_49;
            .currSlotId = val_70;
            if(val_70 < val_62)
            {
                    do
            {
                var val_40 = val_70 / val_49;
                val_40 = val_70 - (val_40 * val_49);
                if((this.slotIdToWordCollection.ContainsKey(key:  0)) != false)
            {
                    val_59 = this.slotIdToWordCollection.Item[(WordBalloonGridGenerator.<>c__DisplayClass18_0)[1152921519855789408].currSlotId];
                System.Collections.Generic.List<System.Int32> val_44 = this.wordToSlotListCollection.Item[val_59];
                val_70 = val_70 - ((val_71 == val_40) ? (1 + 1) : 1);
                val_44.set_Item(index:  val_44.FindIndex(match:  new System.Predicate<System.Int32>(object:  val_39, method:  System.Boolean WordBalloonGridGenerator.<>c__DisplayClass18_0::<Generate>b__0(int slotUid))), value:  val_70);
                val_49 = val_49;
                if((this.slotIdToWordCollection.ContainsKey(key:  val_70)) != false)
            {
                    this.slotIdToWordCollection.set_Item(key:  val_70, value:  val_59);
            }
            
                this.slotIdToWordCollection.Add(key:  val_70, value:  val_59);
                val_61 = val_61;
                bool val_48 = this.slotIdToWordCollection.Remove(key:  0);
                val_62 = val_62;
            }
            
                int val_49 = .currSlotId + 1;
                (WordBalloonGridGenerator.<>c__DisplayClass18_0)[1152921519855789408].currSlotId = val_49;
            }
            while(val_49 < val_62);
            
            }
            
            this.gridContents.RemoveAt(index:  val_71);
            label_79:
            val_60 = val_71;
            val_71 = val_71 - 1;
            if((val_71 & 2147483648) == 0)
            {
                    if(this.gridContents != null)
            {
                goto label_98;
            }
            
            }
            
            label_97:
            if(val_66 < 0)
            {
                    return (SLC.Minigames.WordBalloon.WordBalloonLevelData)this.PackageEntireGridAsData();
            }
            
            val_59 = 1152921518147925600;
            val_49 = 1152921505033097216;
            val_48 = 1152921519855576736;
            var val_51 = val_37 - 2;
            var val_52 = ((long)val_37 - 1) + 4;
            do
            {
                val_60 = val_52 - 4;
                if(val_60 >= val_37)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((this.wordToSlotListCollection.ContainsKey(key:  (0 - 1) + (((long)(int)(((0 - 1) - 1)) + 4)) << 3)) != false)
            {
                    val_63 = this.populatedWordsList;
                if(val_60 >= val_37)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_63 = this.populatedWordsList;
            }
            
                if(val_60 >= ((long)val_37 - 1))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_60 = this.wordToSlotListCollection.Item[(0 - 1) + (((long)(int)(((0 - 1) - 1)) + 4)) << 3];
                .word = (0 - 1) + (((long)(int)(((0 - 1) - 1)) + 4)) << 3;
                .slotSequence = val_60;
                this.gridSolutionData.Add(item:  new SLC.Minigames.WordBalloon.WordSolutionData());
            }
            
                if((val_51 & 2147483648) != 0)
            {
                    return (SLC.Minigames.WordBalloon.WordBalloonLevelData)this.PackageEntireGridAsData();
            }
            
                val_51 = val_51 - 1;
                val_52 = val_52 - 1;
            }
            while(this.populatedWordsList != null);
            
            throw new NullReferenceException();
        }
        private void CalculateVerticalSurfaces()
        {
            SLC.Minigames.WordBalloon.WordBalloonGridSurface val_15;
            var val_16;
            bool val_17 = false;
            var val_16 = 0;
            this.verticalSurfaceList = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface>();
            do
            {
                val_16 = val_16 + 1;
                val_17 = val_17 + (System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  0, row:  0)));
            }
            while(val_16 != 9);
            
            var val_20 = 0;
            label_12:
            var val_9 = ((val_17 > false) ? 1 : 0) & ((val_20 == 0) ? 1 : 0);
            var val_19 = 0;
            label_11:
            val_15 = System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  1, row:  0));
            if(val_20 == 0)
            {
                goto label_2;
            }
            
            val_16 = (~(System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  1, row:  val_20 - 1)))) & 1;
            if((val_9 & 1) == 0)
            {
                goto label_3;
            }
            
            goto label_5;
            label_2:
            val_16 = 1;
            if((val_9 & 1) != 0)
            {
                goto label_5;
            }
            
            label_3:
            if(((val_16 & ((val_20 != 0) ? 1 : 0)) != 0) || (val_15 ^ 1 == true))
            {
                goto label_7;
            }
            
            label_5:
            SLC.Minigames.WordBalloon.WordBalloonGridSurface val_15 = null;
            val_15 = val_15;
            val_15 = new SLC.Minigames.WordBalloon.WordBalloonGridSurface(_orientationType:  1, row:  0);
            int val_18 = (SLC.Minigames.WordBalloon.WordBalloonGridSurface)[1152921519856040672].rowIndex;
            val_18 = 11 - val_18;
            .<Height>k__BackingField = val_18;
            (SLC.Minigames.WordBalloon.WordBalloonGridSurface)[1152921519856040672].columnIndexes.Add(item:  1);
            this.verticalSurfaceList.Add(item:  val_15);
            label_7:
            val_19 = val_19 + 1;
            if(val_19 < 8)
            {
                goto label_11;
            }
            
            val_20 = val_20 + 1;
            if(val_20 < 10)
            {
                goto label_12;
            }
        
        }
        private void CalculateHorizontalSurfaces()
        {
            SLC.Minigames.WordBalloon.WordBalloonGridSurface val_8;
            int val_9;
            var val_10;
            var val_11;
            this.horizontalSurfaceList = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonGridSurface>();
            var val_11 = 0;
            label_18:
            val_8 = 0;
            var val_10 = 0;
            label_17:
            if(val_11 == 0)
            {
                goto label_1;
            }
            
            bool val_4 = System.String.IsNullOrEmpty(value:  this.GetGridContent(col:  1, row:  val_11 - 1));
            val_9 = this.GetAmountOfEmptySpacesBelowSlot(slotX:  1, slotY:  0);
            if(val_4 == false)
            {
                goto label_2;
            }
            
            val_10 = (~val_4) & 1;
            goto label_3;
            label_1:
            val_9 = this.GetAmountOfEmptySpacesBelowSlot(slotX:  1, slotY:  0);
            label_2:
            if(val_9 < 1)
            {
                goto label_10;
            }
            
            if(val_8 == 0)
            {
                    SLC.Minigames.WordBalloon.WordBalloonGridSurface val_7 = null;
                val_8 = val_7;
                val_7 = new SLC.Minigames.WordBalloon.WordBalloonGridSurface(_orientationType:  0, row:  0);
                int val_9 = (SLC.Minigames.WordBalloon.WordBalloonGridSurface)[1152921519856193632].rowIndex;
                val_9 = 11 - val_9;
                .<Height>k__BackingField = val_9;
            }
            
            (SLC.Minigames.WordBalloon.WordBalloonGridSurface)[1152921519856193632].columnIndexes.Add(item:  1);
            val_10 = 1;
            label_3:
            if(((val_9 < 1) || (val_10 == 7)) || (val_10 == 0))
            {
                goto label_10;
            }
            
            val_11 = UnityEngine.Mathf.Min(a:  val_9, b:  11);
            goto label_15;
            label_10:
            val_11 = 11;
            if((11 >= 1) && (val_8 != 0))
            {
                    this.horizontalSurfaceList.Add(item:  val_8);
                val_11 = 11;
            }
            
            label_15:
            val_10 = val_10 + 1;
            if(val_10 < 8)
            {
                goto label_17;
            }
            
            val_11 = val_11 + 1;
            if(val_11 < 10)
            {
                goto label_18;
            }
        
        }
        private SLC.Minigames.WordBalloon.WordBalloonLevelData PackageEntireGridAsData()
        {
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            if((public System.Void System.Collections.Generic.List<System.String>::.ctor()) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_6 = 0;
            var val_5 = 4;
            label_24:
            var val_2 = val_5 - 4;
            if(val_2 >= "big_quiz_reward")
            {
                goto label_6;
            }
            
            if("big_quiz_reward" <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((System.String.IsNullOrEmpty(value:  ("big_quiz_reward".__il2cppRuntimeField_20 + 24 + 32 + 16 + 0) + 32)) == false)
            {
                goto label_14;
            }
            
            if(val_1 != null)
            {
                goto label_18;
            }
            
            goto label_18;
            label_14:
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            label_18:
            val_1.Add(item:  ((("big_quiz_reward".__il2cppRuntimeField_20 + 24 + 32 + 16 + 0) + 32 + 16 + 0) + 32));
            val_5 = val_5 + 1;
            if(this.gridContents != null)
            {
                goto label_24;
            }
            
            label_6:
            val_6 = val_6 + 1;
            .gridData = val_1;
            .columnLimit = this.gridContents;
            .requiredWords = this.populatedWordsList;
            .gridSolutionData = this.gridSolutionData;
            return (SLC.Minigames.WordBalloon.WordBalloonLevelData)new SLC.Minigames.WordBalloon.WordBalloonLevelData();
        }
        private int GetAmountOfEmptySpacesBelowSlot(int slotX, int slotY)
        {
            var val_4;
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_5;
            var val_7;
            val_4 = slotY;
            bool val_4 = true;
            val_5 = this.gridContents;
            if(val_4 <= slotX)
            {
                goto label_2;
            }
            
            val_7 = 0;
            var val_1 = X9 + 32;
            goto label_3;
            label_11:
            if(val_4 <= slotX)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + (((long)(int)(slotX)) << 3);
            if(((true + ((long)(int)(slotX)) << 3) + 32 + 24) <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_5 = (true + ((long)(int)(slotX)) << 3) + 32 + 16;
            val_5 = this.gridContents;
            val_4 = val_4 + 1;
            val_7 = val_7 + (System.String.IsNullOrEmpty(value:  (true + ((long)(int)(slotX)) << 3) + 32 + 16 + (X9 + 32)));
            val_1 = val_1 + 8;
            label_3:
            if(val_5 <= slotX)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + (((long)(int)(slotX)) << 3);
            if(val_4 < (((true + ((long)(int)(slotX)) << 3) + 32 + 16 + ((long)(int)(slotX)) << 3) + 32 + 24))
            {
                goto label_11;
            }
            
            return (int)val_7;
            label_2:
            val_7 = 0;
            return (int)val_7;
        }
        private string GetGridContent(int col, int row)
        {
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_1;
            var val_2;
            val_1 = this;
            bool val_1 = true;
            if(val_1 > col)
            {
                    if(val_1 <= col)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + (col << 3);
                var val_2 = (true + (col) << 3) + 32 + 24;
                if(val_2 > row)
            {
                    val_1 = this.gridContents;
                if(val_2 <= col)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + (((long)(int)(col)) << 3);
                if((((true + (col) << 3) + 32 + 24 + ((long)(int)(col)) << 3) + 32 + 24) <= row)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_3 = ((true + (col) << 3) + 32 + 24 + ((long)(int)(col)) << 3) + 32 + 16;
                val_3 = val_3 + (row << 3);
                val_2 = mem[(((true + (col) << 3) + 32 + 24 + ((long)(int)(col)) << 3) + 32 + 16 + (row) << 3) + 32];
                val_2 = (((true + (col) << 3) + 32 + 24 + ((long)(int)(col)) << 3) + 32 + 16 + (row) << 3) + 32;
                return (string)val_2;
            }
            
            }
            
            val_2 = 0;
            return (string)val_2;
        }
        private void SetGridContent(int col, int row, string newSlotLetterValue, string word, int indexOfValueWithinWord)
        {
            int val_2 = (row + (row << 3)) + col;
            if((this.slotIdToWordCollection.ContainsKey(key:  val_2)) != false)
            {
                    this.slotIdToWordCollection.set_Item(key:  val_2, value:  word);
            }
            else
            {
                    this.slotIdToWordCollection.Add(key:  val_2, value:  word);
            }
            
            if((this.wordToSlotListCollection.ContainsKey(key:  word)) != true)
            {
                    System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>();
                if(word.m_stringLength >= 1)
            {
                    var val_7 = 0;
                do
            {
                val_5.Add(item:  0);
                val_7 = val_7 + 1;
            }
            while(val_7 < word.m_stringLength);
            
            }
            
                this.wordToSlotListCollection.Add(key:  word, value:  val_5);
            }
            
            this.wordToSlotListCollection.Item[word].set_Item(index:  indexOfValueWithinWord, value:  val_2);
            this.SetGridContent(col:  col, row:  row, newSlotLetterValue:  newSlotLetterValue);
        }
        private void SetGridContent(int col, int row, string newSlotLetterValue)
        {
            bool val_1 = true;
            if(val_1 <= col)
            {
                    return;
            }
            
            if(val_1 <= col)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + (col << 3);
            var val_2 = (true + (col) << 3) + 32 + 24;
            if(val_2 <= row)
            {
                    return;
            }
            
            if(val_2 <= col)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + (((long)(int)(col)) << 3);
            ((true + (col) << 3) + 32 + 24 + ((long)(int)(col)) << 3) + 32.set_Item(index:  row, value:  newSlotLetterValue);
        }
        private void CutAndPasteGridContent(int fromCol, int fromRow, int toCol, int toRow)
        {
            string val_15;
            var val_16;
            int val_15 = toRow;
            int val_4 = (fromRow + (fromRow << 3)) + fromCol;
            .fromSlotId = val_4;
            if((this.slotIdToWordCollection.ContainsKey(key:  val_4)) != false)
            {
                    val_15 = this.slotIdToWordCollection.Item[(WordBalloonGridGenerator.<>c__DisplayClass26_0)[1152921519857157472].fromSlotId];
            }
            else
            {
                    val_15 = 0;
            }
            
            if((this.wordToSlotListCollection.ContainsKey(key:  val_15)) != false)
            {
                    val_16 = this.wordToSlotListCollection.Item[val_15];
            }
            else
            {
                    val_16 = 0;
            }
            
            val_15 = (val_15 + (val_15 << 3)) + toCol;
            val_16.set_Item(index:  val_16.FindIndex(match:  new System.Predicate<System.Int32>(object:  new WordBalloonGridGenerator.<>c__DisplayClass26_0(), method:  System.Boolean WordBalloonGridGenerator.<>c__DisplayClass26_0::<CutAndPasteGridContent>b__0(int slotUid))), value:  val_15);
            if((this.slotIdToWordCollection.ContainsKey(key:  (WordBalloonGridGenerator.<>c__DisplayClass26_0)[1152921519857157472].fromSlotId)) != false)
            {
                    bool val_13 = this.slotIdToWordCollection.Remove(key:  (WordBalloonGridGenerator.<>c__DisplayClass26_0)[1152921519857157472].fromSlotId);
            }
            
            if((this.slotIdToWordCollection.ContainsKey(key:  val_15)) != false)
            {
                    this.slotIdToWordCollection.set_Item(key:  val_15, value:  val_15);
            }
            
            this.slotIdToWordCollection.Add(key:  val_15, value:  val_15);
            this.SetGridContent(col:  toCol, row:  val_15, newSlotLetterValue:  this.GetGridContent(col:  fromCol, row:  fromRow));
            this.SetGridContent(col:  fromCol, row:  fromRow, newSlotLetterValue:  0);
        }
        private void PrintGridContent()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_8;
            string val_9;
            var val_10;
            val_8 = this.gridContents;
            val_9 = "";
            if(W9 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_9 = 0;
            val_8 = this.gridContents;
            var val_8 = 4;
            label_15:
            var val_1 = val_8 - 4;
            if(val_1 >= (public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current()))
            {
                goto label_6;
            }
            
            if((public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current()) <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = " ";
            if((System.String.IsNullOrEmpty(value:  (public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current().__il2cppRuntimeField_20 + 16 + 0) + 32)) != true)
            {
                    if(val_10 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            string val_5 = val_9 + System.String.Format(format:  "\"{0}\", ", arg0:  ((public System.Void ConditionalWeakTable.CreateValueCallback<System.Object, System.Threading.OSSpecificSynchronizationContext>::.ctor(object object, IntPtr method).__il2cppRuntimeField_10 + 0) + 32))(System.String.Format(format:  "\"{0}\", ", arg0:  ((public System.Void ConditionalWeakTable.CreateValueCallback<System.Object, System.Threading.OSSpecificSynchronizationContext>::.ctor(object object, IntPtr method).__il2cppRuntimeField_10 + 0) + 32)));
            val_8 = val_8 + 1;
            if(this.gridContents != null)
            {
                goto label_15;
            }
            
            label_6:
            val_9 = val_9 + 1;
            val_9 = val_9 + "\n";
            UnityEngine.Debug.Log(message:  "<color=#FF00A4><b>Grid Contents:</b></color>\n<color=#FF00A4>"("<color=#FF00A4><b>Grid Contents:</b></color>\n<color=#FF00A4>") + val_9 + "</color>"("</color>"));
        }
        private static WordBalloonGridGenerator()
        {
        
        }
    
    }

}
