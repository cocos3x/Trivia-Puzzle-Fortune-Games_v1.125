using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class FlyKeyBoardLetter : MonoBehaviour
    {
        // Fields
        private SLC.Minigames.Ladder.WordLadderKeyboardLetter keyboardLettet;
        
        // Methods
        private void Start()
        {
            this.gameObject.SetActive(value:  false);
        }
        public void setUp(string letter, UnityEngine.Vector2 posStart, UnityEngine.Vector2 posStop, System.Action callback)
        {
            UnityEngine.Vector3 val_5 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  posStart.x, y:  posStart.y, z:  val_5.z);
            this.gameObject.transform.position = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            this.gameObject.SetActive(value:  true);
            mem2[0] = 0;
            mem2[0] = letter;
            UnityEngine.Vector3 val_9 = this.transform.position;
            UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  posStop.x, y:  posStop.y, z:  val_9.z);
            UnityEngine.Coroutine val_12 = this.StartCoroutine(routine:  this.FlyTo(posStop:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, callback:  callback));
        }
        private System.Collections.IEnumerator FlyTo(UnityEngine.Vector3 posStop, System.Action callback)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .posStop = posStop;
            mem[1152921519801536876] = posStop.y;
            mem[1152921519801536880] = posStop.z;
            .callback = callback;
            return (System.Collections.IEnumerator)new FlyKeyBoardLetter.<FlyTo>d__3();
        }
        public FlyKeyBoardLetter()
        {
        
        }
    
    }

}
