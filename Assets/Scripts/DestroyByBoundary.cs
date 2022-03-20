using UnityEngine;
public class DestroyByBoundary : MonoBehaviour
{
    // Methods
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        UnityEngine.Object.Destroy(obj:  other.gameObject);
    }
    public DestroyByBoundary()
    {
    
    }

}
