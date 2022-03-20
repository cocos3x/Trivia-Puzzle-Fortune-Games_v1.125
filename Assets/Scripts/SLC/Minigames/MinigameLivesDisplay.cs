using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameLivesDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject HeartPrefab;
        private UnityEngine.Transform HeartsContainer;
        private System.Collections.Generic.List<UnityEngine.UI.Toggle> HeartToggles;
        private bool initialized;
        
        // Methods
        private void Init(int maxHearts)
        {
            System.Collections.Generic.List<UnityEngine.UI.Toggle> val_4;
            this.initialized = true;
            System.Collections.Generic.List<UnityEngine.UI.Toggle> val_1 = null;
            val_4 = val_1;
            val_1 = new System.Collections.Generic.List<UnityEngine.UI.Toggle>();
            this.HeartToggles = val_4;
            if(maxHearts >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_4 = this.HeartsContainer;
                this.HeartToggles.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.HeartPrefab, parent:  val_4).GetComponent<UnityEngine.UI.Toggle>());
                val_4 = val_4 + 1;
            }
            while(val_4 < maxHearts);
            
            }
            
            this.UpdateLivesDisplay(currentHearts:  maxHearts);
        }
        public void UpdateLivesDisplay(int currentHearts)
        {
            var val_2;
            bool val_2 = this.initialized;
            if(val_2 != true)
            {
                    this.Init(maxHearts:  currentHearts);
            }
            
            val_2 = 0;
            do
            {
                if(val_2 >= val_2)
            {
                    return;
            }
            
                if(val_2 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + 0;
                (this.initialized + 0) + 32.isOn = (val_2 < currentHearts) ? 1 : 0;
                val_2 = val_2 + 1;
            }
            while(this.HeartToggles != null);
            
            throw new NullReferenceException();
        }
        public MinigameLivesDisplay()
        {
        
        }
    
    }

}
