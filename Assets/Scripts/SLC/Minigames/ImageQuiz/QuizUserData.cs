using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    [Serializable]
    public class QuizUserData
    {
        // Fields
        public System.Collections.Generic.List<int> usedLevels;
        
        // Methods
        public QuizUserData()
        {
            this.usedLevels = new System.Collections.Generic.List<System.Int32>();
        }
    
    }

}
