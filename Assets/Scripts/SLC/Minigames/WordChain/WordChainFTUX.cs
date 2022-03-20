using UnityEngine;

namespace SLC.Minigames.WordChain
{
    public class WordChainFTUX : MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>
    {
        // Fields
        private SLC.Minigames.WordChain.WordChainUIController wordChainUIController;
        private const float WAIT_TIME = 3;
        private SLC.Minigames.WordChain.WordChainLetterTile currentLetter;
        
        // Methods
        public void ShowFTUX()
        {
            this.StopAllCoroutines();
            SLC.Minigames.WordChain.WordChainManager val_1 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            SLC.Minigames.WordChain.WordChainLetterTile val_2 = this.wordChainUIController.GetNextLetterInFTUX(index:  val_1.answerProgress);
            this.currentLetter = val_2;
            this.wordChainUIController.DisableOtherLetterTiles(currentFTUXLetterTile:  val_2);
            UnityEngine.Coroutine val_4 = this.wordChainUIController.StartCoroutine(routine:  this.ShowHand());
        }
        public void Stop()
        {
            this.StopAllCoroutines();
        }
        private System.Collections.IEnumerator ShowHand()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordChainFTUX.<ShowHand>d__5();
        }
        public WordChainFTUX()
        {
        
        }
    
    }

}
