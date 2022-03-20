using UnityEngine;
public class WGSnakesAndLaddersDiceRollAnim : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image pointImg;
    private System.Collections.Generic.List<UnityEngine.Sprite> pointSp;
    
    // Methods
    public void Play(int result)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AnimateRandomPointSp(result:  result));
    }
    private System.Collections.IEnumerator AnimateRandomPointSp(int result)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .result = result;
        return (System.Collections.IEnumerator)new WGSnakesAndLaddersDiceRollAnim.<AnimateRandomPointSp>d__3();
    }
    public WGSnakesAndLaddersDiceRollAnim()
    {
    
    }

}
