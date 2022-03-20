using UnityEngine;

namespace SLC.Minigames.WordQuiz
{
    public class WordQuizLevel
    {
        // Fields
        public string word;
        public string definition;
        public int keyboardLetterNum;
        
        // Methods
        public override string ToString()
        {
            return (string)System.String.Format(format:  "Word: {0} | Definition: {1} | KeyboardLetterNum | {2}", arg0:  this.word, arg1:  this.definition, arg2:  this.keyboardLetterNum);
        }
        public WordQuizLevel()
        {
        
        }
    
    }

}
