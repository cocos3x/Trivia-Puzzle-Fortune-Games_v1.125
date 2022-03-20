using UnityEngine;

namespace CrosswordCreator.Crossword
{
    public class CrosswordGenerator
    {
        // Fields
        private const float emptySquarePercentThreshold = 0.75;
        public System.Action<CrosswordCreator.Crossword.Crossword, float, System.Collections.Generic.List<string>> OnCrosswordCreated;
        private System.Collections.Generic.List<string> _words;
        private System.Collections.Generic.Queue<string> _order;
        private System.Collections.Generic.List<string> droppedWords;
        private CrosswordCreator.Crossword.Crossword _board;
        
        // Properties
        public bool usedAllWords { get; }
        
        // Methods
        public bool get_usedAllWords()
        {
            return (bool)(this.droppedWords == 0) ? 1 : 0;
        }
        public CrosswordCreator.Crossword.Crossword GetBoard()
        {
            return (CrosswordCreator.Crossword.Crossword)this._board;
        }
        public void Generate(System.Collections.Generic.List<string> words, int maxWidth, int maxHeight)
        {
            this._words = words;
            this._board = new CrosswordCreator.Crossword.Crossword(maxWidth:  maxWidth, maxHeight:  maxHeight);
            PluginExtension.Shuffle<System.String>(list:  this._words, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            this._order = new System.Collections.Generic.Queue<System.String>(collection:  this._words);
            this.GenCrossword();
        }
        private void GenCrossword()
        {
            this.droppedWords.Clear();
            this._board.Reset();
            var val_4 = 0;
            label_14:
            if(((this._board.HasAvailableCrosspoints() == false) || (1152921515450536464 < 1)) || (this.droppedWords != null))
            {
                goto label_8;
            }
            
            string val_2 = this._order.Dequeue();
            if((this._board.AddWord(word:  val_2)) == true)
            {
                goto label_17;
            }
            
            if(val_4 <= this._board)
            {
                goto label_12;
            }
            
            this.droppedWords.Add(item:  val_2);
            label_17:
            if(this._board != null)
            {
                goto label_14;
            }
            
            goto label_17;
            label_12:
            this._order.Enqueue(item:  val_2);
            val_4 = val_4 + 1;
            goto label_17;
            label_8:
            this._board.Trim();
        }
        public CrosswordGenerator()
        {
            this.droppedWords = new System.Collections.Generic.List<System.String>();
        }
    
    }

}
