using UnityEngine;

namespace SLC.Minigames.WordQuiz
{
    public class WordQuizFTUXManager : MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>
    {
        // Fields
        private SLC.Minigames.WordQuiz.WordQuizUIController wordQuizUIController;
        private UnityEngine.GameObject FTUXLetterTileOverlay;
        private const float WAIT_TIME = 3;
        private SLC.Minigames.WordQuiz.WordQuizLetterTile currentLetter;
        
        // Methods
        public void ShowFTUX()
        {
            this.StopAllCoroutines();
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            SLC.Minigames.WordQuiz.WordQuizLetterTile val_2 = this.wordQuizUIController.GetNextLetterInFTUX(index:  val_1.answerProgress);
            this.currentLetter = val_2;
            UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.FTUXLetterTileOverlay, parent:  val_2.transform).transform.SetAsFirstSibling();
            this.wordQuizUIController.DisableOtherLetterTiles(currentFTUXLetterTile:  this.currentLetter);
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.ShowHand());
        }
        public void Stop()
        {
            this.StopAllCoroutines();
        }
        private System.Collections.IEnumerator ShowHand()
        {
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordQuizFTUXManager.<ShowHand>d__6(<>1__state:  0);
        }
        public WordQuizFTUXManager()
        {
        
        }
    
    }

}
