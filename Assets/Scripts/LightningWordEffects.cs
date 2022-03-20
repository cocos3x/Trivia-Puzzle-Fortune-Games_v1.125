using UnityEngine;
public class LightningWordEffects : MonoBehaviour
{
    // Fields
    private UnityEngine.Animation anim;
    
    // Methods
    private void Awake()
    {
        this.anim = this.GetComponent<UnityEngine.Animation>();
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.PlayLightningEffects());
    }
    private System.Collections.IEnumerator PlayLightningEffects()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new LightningWordEffects.<PlayLightningEffects>d__3();
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public LightningWordEffects()
    {
    
    }

}
