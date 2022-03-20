using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackWord
    {
        // Fields
        public string word;
        public bool incorrect;
        
        // Methods
        public WhackWord(string word, bool incorrect)
        {
            this.word = word;
            this.incorrect = incorrect;
        }
        public override string ToString()
        {
            return (string)System.String.Format(format:  "word {0}, incorrect {1}", arg0:  this.word, arg1:  this.incorrect);
        }
    
    }

}
