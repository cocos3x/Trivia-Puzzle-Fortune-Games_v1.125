using UnityEngine;
public class DiceRollTile : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem particles;
    private const float flyToPreDelay = 0.2;
    private const float flyToDuration = 1;
    private const float flyToAfterDelay = 0.2;
    private UnityEngine.GameObject eventButtonGO;
    
    // Methods
    public void Init(UnityEngine.GameObject eventButton)
    {
        this.eventButtonGO = eventButton;
    }
    public void PlayEndingAnimation()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FlyAndHide());
    }
    private System.Collections.IEnumerator FlyAndHide()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DiceRollTile.<FlyAndHide>d__7();
    }
    public DiceRollTile()
    {
    
    }

}
