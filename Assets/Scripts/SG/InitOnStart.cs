using UnityEngine;

namespace SG
{
    public class InitOnStart : MonoBehaviour
    {
        // Fields
        public int totalCount;
        
        // Methods
        private void Start()
        {
            val_1.totalCount = this.totalCount;
            this.GetComponent<UnityEngine.UI.LoopScrollRect>().RefillCells(offset:  0);
        }
        public InitOnStart()
        {
            this.totalCount = 0;
        }
    
    }

}
