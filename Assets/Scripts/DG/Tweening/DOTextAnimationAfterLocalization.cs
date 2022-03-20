using UnityEngine;

namespace DG.Tweening
{
    public class DOTextAnimationAfterLocalization : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text text;
        private float duration;
        private float delay;
        private DG.Tweening.Ease ease;
        private DG.Tweening.ScrambleMode scrambleMode;
        private string customScramble;
        private bool richText;
        
        // Methods
        private void Start()
        {
            this.text = this.GetComponent<UnityEngine.UI.Text>();
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.PlayAfterOneFrame());
        }
        private System.Collections.IEnumerator PlayAfterOneFrame()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new DOTextAnimationAfterLocalization.<PlayAfterOneFrame>d__8();
        }
        public DOTextAnimationAfterLocalization()
        {
            this.duration = 1f;
            this.ease = 1;
            this.customScramble = System.String.alignConst;
        }
    
    }

}
