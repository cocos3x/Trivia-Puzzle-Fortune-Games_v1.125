using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizEcon
    {
        // Properties
        public static decimal HintCost { get; }
        
        // Methods
        public static decimal get_HintCost()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return new System.Decimal() {flags = val_1.hintCost, hi = val_1.hintCost};
        }
        public static int GetAmountOfLetterButtons(int gameLevel)
        {
            if(gameLevel < 26)
            {
                    return 8;
            }
            
            if(gameLevel < 76)
            {
                    return 10;
            }
            
            if(gameLevel < 126)
            {
                    return 12;
            }
            
            if(gameLevel < 201)
            {
                    return 14;
            }
            
            if(gameLevel < 301)
            {
                    return 16;
            }
            
            return (int)(gameLevel > 400) ? 21 : 18;
        }
        public ImageQuizEcon()
        {
        
        }
    
    }

}
