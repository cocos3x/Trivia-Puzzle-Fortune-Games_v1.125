using UnityEngine;

namespace EpicToonFX
{
    public class ETFXLoopScript : MonoBehaviour
    {
        // Fields
        public UnityEngine.GameObject chosenEffect;
        public float loopTimeLimit;
        public bool spawnWithoutLight;
        public bool spawnWithoutSound;
        
        // Methods
        private void Start()
        {
            this.PlayEffect();
        }
        public void PlayEffect()
        {
            UnityEngine.Coroutine val_1 = this.StartCoroutine(methodName:  "EffectLoop");
        }
        private System.Collections.IEnumerator EffectLoop()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ETFXLoopScript.<EffectLoop>d__6();
        }
        public ETFXLoopScript()
        {
            this.loopTimeLimit = 2f;
            this.spawnWithoutLight = true;
            this.spawnWithoutSound = true;
        }
    
    }

}
