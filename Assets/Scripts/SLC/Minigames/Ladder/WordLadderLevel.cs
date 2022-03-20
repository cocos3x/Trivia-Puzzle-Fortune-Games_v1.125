using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class WordLadderLevel
    {
        // Fields
        private string startingWord;
        private string requiredWord;
        private string chosenWord;
        private System.Collections.Generic.Queue<string> ladder;
        
        // Properties
        public string StartingWord { get; set; }
        public string RequiredWord { get; set; }
        public string ChosenWord { get; set; }
        public System.Collections.Generic.Queue<string> Ladder { get; set; }
        
        // Methods
        public string get_StartingWord()
        {
            return (string)this.startingWord;
        }
        private void set_StartingWord(string value)
        {
            this.startingWord = value;
        }
        public string get_RequiredWord()
        {
            return (string)this.requiredWord;
        }
        private void set_RequiredWord(string value)
        {
            this.requiredWord = value;
        }
        public string get_ChosenWord()
        {
            return (string)this.chosenWord;
        }
        public void set_ChosenWord(string value)
        {
            this.chosenWord = value;
        }
        public System.Collections.Generic.Queue<string> get_Ladder()
        {
            return (System.Collections.Generic.Queue<System.String>)this.ladder;
        }
        public void set_Ladder(System.Collections.Generic.Queue<string> value)
        {
            this.ladder = value;
        }
        public WordLadderLevel(string starting, string required)
        {
            val_1 = new System.Object();
            this.startingWord = starting;
            this.requiredWord = val_1;
            this.ladder = new System.Collections.Generic.Queue<System.String>();
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[WordLadderLevel: StartingWord={0}, RequiredWord={1}]", arg0:  this.startingWord, arg1:  this.requiredWord);
        }
    
    }

}
