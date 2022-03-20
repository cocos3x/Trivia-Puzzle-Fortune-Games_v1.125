using UnityEngine;

namespace CrosswordCreator.Crossword
{
    public class WordTuple
    {
        // Fields
        public string word;
        public int x;
        public int y;
        public int dir;
        
        // Methods
        public WordTuple(string word, int x, int y, int dir)
        {
            this.word = word;
            this.x = x;
            this.y = y;
            this.dir = dir;
        }
    
    }

}
