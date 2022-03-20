using UnityEngine;
public class LineDrawerParticles : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem particleSystem;
    
    // Methods
    private void Start()
    {
        this.particleSystem = this.GetComponent<UnityEngine.ParticleSystem>();
    }
    public void Play(System.Collections.Generic.List<UnityEngine.Vector3> selectedPositions)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.PlayInSequence(selectedPositions:  selectedPositions));
    }
    private System.Collections.IEnumerator PlayInSequence(System.Collections.Generic.List<UnityEngine.Vector3> selectedPositions)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .selectedPositions = selectedPositions;
        return (System.Collections.IEnumerator)new LineDrawerParticles.<PlayInSequence>d__3();
    }
    public LineDrawerParticles()
    {
    
    }

}
