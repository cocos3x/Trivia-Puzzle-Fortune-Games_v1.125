using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesLevelData
    {
        // Fields
        private int <LevelIndex>k__BackingField;
        private float <TimeLength>k__BackingField;
        private int <FragmentsCount>k__BackingField;
        
        // Properties
        public int LevelIndex { get; set; }
        public float TimeLength { get; set; }
        public int FragmentsCount { get; set; }
        
        // Methods
        public int get_LevelIndex()
        {
            return (int)this.<LevelIndex>k__BackingField;
        }
        private void set_LevelIndex(int value)
        {
            this.<LevelIndex>k__BackingField = value;
        }
        public float get_TimeLength()
        {
            return (float)this.<TimeLength>k__BackingField;
        }
        private void set_TimeLength(float value)
        {
            this.<TimeLength>k__BackingField = value;
        }
        public int get_FragmentsCount()
        {
            return (int)this.<FragmentsCount>k__BackingField;
        }
        private void set_FragmentsCount(int value)
        {
            this.<FragmentsCount>k__BackingField = value;
        }
        public WordBubblesLevelData(int levelIndex, float timeLen, int fragCount)
        {
            this.<LevelIndex>k__BackingField = levelIndex;
            this.<TimeLength>k__BackingField = timeLen;
            this.<FragmentsCount>k__BackingField = fragCount;
        }
        public override string ToString()
        {
            int val_3;
            int val_4;
            object[] val_1 = new object[6];
            val_1[0] = "Level:";
            val_3 = val_1.Length;
            val_1[1] = this.<LevelIndex>k__BackingField;
            val_3 = val_1.Length;
            val_1[2] = ", time:";
            val_4 = val_1.Length;
            val_1[3] = this.<TimeLength>k__BackingField;
            val_4 = val_1.Length;
            val_1[4] = ", fragCount:";
            val_1[5] = this.<FragmentsCount>k__BackingField;
            return (string)+val_1;
        }
    
    }

}
