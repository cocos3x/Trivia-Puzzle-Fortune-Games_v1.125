using UnityEngine;

namespace SLC.Minigames.SnackBlock
{
    public class SnakeBlockBlock : MonoBehaviour
    {
        // Fields
        public SLC.Minigames.SnackBlock.SnakeGridSpaceType myType;
        private TMPro.TextMeshPro wordText;
        
        // Methods
        public void SetupFromData(int row, int column)
        {
            TMPro.TextMeshPro val_5;
            string val_7;
            val_5 = this;
            if(this.myType != 3)
            {
                    if(this.myType != 2)
            {
                    return;
            }
            
                val_7 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.GetWordForRowColumnIndex(row:  row, column:  0);
            }
            else
            {
                    val_5 = this.wordText;
                column = column + 1;
                val_7 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.GetWordForRowColumnIndex(row:  row, column:  column);
            }
            
            val_5.text = val_7;
        }
        public bool RemoveLastLetter()
        {
            string val_2 = this.wordText.text;
            this.wordText.text = this.wordText.text.Remove(startIndex:  val_2.m_stringLength - 1);
            return System.String.IsNullOrEmpty(value:  this.wordText.text);
        }
        public SnakeBlockBlock()
        {
        
        }
    
    }

}
