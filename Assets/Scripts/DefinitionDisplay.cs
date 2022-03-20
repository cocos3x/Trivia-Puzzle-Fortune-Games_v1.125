using UnityEngine;
public class DefinitionDisplay : MonoBehaviour
{
    // Fields
    private float waitTime;
    private float fadeTime;
    private UnityEngine.CanvasGroup group;
    
    // Methods
    public void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.WaitThenFade());
    }
    private System.Collections.IEnumerator WaitThenFade()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DefinitionDisplay.<WaitThenFade>d__4();
    }
    public DefinitionDisplay()
    {
        this.waitTime = 2f;
        this.fadeTime = 0.5f;
    }

}
