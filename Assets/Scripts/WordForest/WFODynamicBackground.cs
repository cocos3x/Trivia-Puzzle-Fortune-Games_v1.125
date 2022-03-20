using UnityEngine;

namespace WordForest
{
    public class WFODynamicBackground : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.RawImage backgroundImage;
        private System.Collections.Generic.List<UnityEngine.Texture> backgroundTextures;
        
        // Methods
        private void Start()
        {
            this.SetCurrentForestBackground();
        }
        public void SetCurrentForestBackground()
        {
            var val_3;
            UnityEngine.Texture val_5;
            if(true == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = System.Void Dictionary.KeyCollection.Enumerator<System.Int32Enum, System.Object>::System.Collections.IEnumerator.Reset();
            WordForest.WFOForestData val_2 = MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestData;
            if(1152921518115417023 >= val_3)
            {
                    if(val_2 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_4 = val_2 + ((val_3) << 3);
                val_5 = mem[(val_2 + (val_3) << 3) + 32];
                val_5 = (val_2 + (val_3) << 3) + 32;
            }
            
            this.backgroundImage.texture = val_5;
        }
        public WFODynamicBackground()
        {
        
        }
    
    }

}
