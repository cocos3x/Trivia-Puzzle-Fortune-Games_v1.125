using UnityEngine;

namespace BlockPuzzleMagic
{
    public class ChapterRef
    {
        // Fields
        public int chapterId;
        public System.Collections.Generic.List<BlockPuzzleMagic.LevelRef> levels;
        
        // Properties
        public BlockPuzzleMagic.LevelRef FirstLevel { get; }
        public BlockPuzzleMagic.LevelRef LastLevel { get; }
        
        // Methods
        public BlockPuzzleMagic.LevelRef get_FirstLevel()
        {
            if(true != 0)
            {
                    return 0;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            return 0;
        }
        public BlockPuzzleMagic.LevelRef get_LastLevel()
        {
            bool val_1 = true;
            if(val_1 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            return (BlockPuzzleMagic.LevelRef)(true + 0) + 32;
        }
        public static BlockPuzzleMagic.ChapterRef Parse(string _jsonString)
        {
            BlockPuzzleMagic.ChapterRef val_1 = Newtonsoft.Json.JsonConvert.DeserializeObject<BlockPuzzleMagic.ChapterRef>(value:  _jsonString);
            val_1.Sort();
            return val_1;
        }
        public void Sort()
        {
            var val_2;
            System.Comparison<BlockPuzzleMagic.LevelRef> val_4;
            val_2 = null;
            val_2 = null;
            val_4 = ChapterRef.<>c.<>9__7_0;
            if(val_4 == null)
            {
                    System.Comparison<BlockPuzzleMagic.LevelRef> val_1 = null;
                val_4 = val_1;
                val_1 = new System.Comparison<BlockPuzzleMagic.LevelRef>(object:  ChapterRef.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 ChapterRef.<>c::<Sort>b__7_0(BlockPuzzleMagic.LevelRef x, BlockPuzzleMagic.LevelRef y));
                ChapterRef.<>c.<>9__7_0 = val_4;
            }
            
            this.levels.Sort(comparison:  val_1);
        }
        public ChapterRef()
        {
        
        }
    
    }

}
