using UnityEngine;

namespace WordForest
{
    public class WFOWordStreakFeedback : GoldenApplesFeedbackWord
    {
        // Properties
        protected override bool extraWordsAllowed { get; }
        
        // Methods
        protected override bool get_extraWordsAllowed()
        {
            return true;
        }
        protected override void UpdateText()
        {
            int val_2 = Dequeue();
            bool val_3 = UnityEngine.Object.op_Implicit(exists:  X21);
            bool val_4 = UnityEngine.Object.op_Implicit(exists:  X21);
            if((35159.Dequeue().Equals(value:  Localization.Localize(key:  "extra_word_upper", defaultValue:  "EXTRA WORD", useSingularKey:  false))) != false)
            {
                    if(this != null)
            {
                    return;
            }
            
            }
            
            string val_8 = System.String.Format(format:  "x{0} STREAK", arg0:  WordStreak.CurrentStreak);
        }
        protected override void PlayParticles()
        {
        
        }
        public WFOWordStreakFeedback()
        {
        
        }
    
    }

}
