using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class WordLadderKeyboardLetter : WordLadderLetter
    {
        // Methods
        public override void OnClick()
        {
            SLC.Minigames.Ladder.WordLadderController val_1 = MonoSingleton<SLC.Minigames.Ladder.WordLadderController>.Instance;
            if(val_1.IsGameOver != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.SubmitLetter(item:  this);
        }
        public WordLadderKeyboardLetter()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
