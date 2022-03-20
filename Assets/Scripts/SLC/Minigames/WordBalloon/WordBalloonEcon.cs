using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonEcon
    {
        // Fields
        public const int USED_CATEGORIES_HISTORY_SIZE = 50;
        
        // Properties
        public static decimal HintCost { get; }
        
        // Methods
        public static decimal get_HintCost()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return new System.Decimal() {flags = val_1.hintCost, hi = val_1.hintCost};
        }
        public static int GetAmountOfWords(int gameLevel)
        {
            if(gameLevel < 6)
            {
                    return 3;
            }
            
            if(gameLevel < 11)
            {
                    return 4;
            }
            
            if(gameLevel < 26)
            {
                    return 5;
            }
            
            if(gameLevel < 51)
            {
                    return 6;
            }
            
            if(gameLevel < 101)
            {
                    return 7;
            }
            
            if(gameLevel < 176)
            {
                    return 8;
            }
            
            if(gameLevel < 251)
            {
                    return 9;
            }
            
            if(gameLevel < 351)
            {
                    return 10;
            }
            
            return (int)(gameLevel > 425) ? (11 + 1) : 11;
        }
        public WordBalloonEcon()
        {
        
        }
    
    }

}
