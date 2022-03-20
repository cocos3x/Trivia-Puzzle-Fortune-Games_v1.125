using UnityEngine;
public class DestroyOnDisable : MonoBehaviour
{
    // Methods
    private void OnDisable()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public DestroyOnDisable()
    {
    
    }

}
