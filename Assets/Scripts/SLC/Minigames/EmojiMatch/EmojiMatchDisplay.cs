using UnityEngine;

namespace SLC.Minigames.EmojiMatch
{
    public class EmojiMatchDisplay : MonoBehaviour
    {
        // Fields
        protected UnityEngine.GameObject[] backgrounds;
        protected UnityEngine.GameObject[] circles;
        protected UnityEngine.GameObject correct_check;
        protected UnityEngine.GameObject incorrect_x;
        
        // Methods
        public UnityEngine.Vector3 GetLinePosition()
        {
            return this.circles[0].transform.position;
        }
        protected virtual void SetState(SLC.Minigames.EmojiMatch.MatchDisplayState state)
        {
            var val_5 = 0;
            do
            {
                if(val_5 >= this.backgrounds.Length)
            {
                    return;
            }
            
                this.backgrounds[val_5].SetActive(value:  (state == val_5) ? 1 : 0);
                this.circles[val_5].SetActive(value:  (state == val_5) ? 1 : 0);
                val_5 = val_5 + 1;
            }
            while(this.backgrounds != null);
            
            throw new NullReferenceException();
        }
        public EmojiMatchDisplay()
        {
        
        }
    
    }

}
