using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackLevel
    {
        // Fields
        public int levelIndex;
        public System.Collections.Generic.List<SLC.Minigames.Whack.WhackWord> whackWords;
        public const float timerPercentage = 0.9975852;
        
        // Properties
        public float TimeRemaining { get; }
        
        // Methods
        public float get_TimeRemaining()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            float val_2 = 0.9975852f;
            val_2 = val_2 * 5f;
            return (float)val_2;
        }
        public void SaveRemainingTimer()
        {
        
        }
        public WhackLevel(int index, System.Collections.Generic.List<object> words)
        {
            System.Collections.Generic.List<SLC.Minigames.Whack.WhackWord> val_7;
            val_1 = new System.Object();
            this.levelIndex = index;
            System.Collections.Generic.List<SLC.Minigames.Whack.WhackWord> val_2 = null;
            val_7 = val_2;
            val_2 = new System.Collections.Generic.List<SLC.Minigames.Whack.WhackWord>();
            this.whackWords = val_7;
            if(1152921519872173632 < 1)
            {
                    return;
            }
            
            var val_7 = 0;
            do
            {
                if(1152921519872173632 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((System.String.IsNullOrEmpty(value:  ToString())) != true)
            {
                    val_7 = this.whackWords;
                if(null <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                .word = mem[null + 32];
                .incorrect = (val_7 == 0) ? 1 : 0;
                val_7.Add(item:  new SLC.Minigames.Whack.WhackWord());
            }
            
                val_7 = val_7 + 1;
            }
            while(val_7 < null);
        
        }
        public override string ToString()
        {
            return (string)System.String.Format(format:  "level {0}, words {1}", arg0:  this.levelIndex, arg1:  MiniJSON.Json.Serialize(obj:  this.whackWords));
        }
    
    }

}
