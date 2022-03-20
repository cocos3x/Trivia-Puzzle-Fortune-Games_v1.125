using UnityEngine;

namespace EpicToonFX
{
    public class ETFXPitchRandomizer : MonoBehaviour
    {
        // Fields
        public float randomPercent;
        
        // Methods
        private void Start()
        {
            UnityEngine.AudioSource val_2 = this.transform.GetComponent<UnityEngine.AudioSource>();
            float val_6 = this.randomPercent;
            float val_5 = -100f;
            val_5 = val_6 / val_5;
            val_6 = val_6 / 100f;
            float val_4 = UnityEngine.Random.Range(min:  val_5, max:  val_6);
            val_4 = val_4 + 1f;
            val_4 = val_2.pitch * val_4;
            val_2.pitch = val_4;
        }
        public ETFXPitchRandomizer()
        {
            this.randomPercent = 10f;
        }
    
    }

}
