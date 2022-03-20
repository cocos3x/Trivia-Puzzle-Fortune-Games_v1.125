using UnityEngine;
public class SyncShakeExtraWords : MonoBehaviour
{
    // Fields
    private UnityEngine.Animator extraWordAnimator;
    
    // Methods
    private void OnEnable()
    {
        this.extraWordAnimator.SetTrigger(name:  "Reward Available");
    }
    private void OnDisable()
    {
        this.extraWordAnimator.SetTrigger(name:  "Reward Claimed");
    }
    public SyncShakeExtraWords()
    {
    
    }

}
