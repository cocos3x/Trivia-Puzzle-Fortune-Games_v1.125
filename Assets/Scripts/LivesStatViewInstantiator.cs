using UnityEngine;
public class LivesStatViewInstantiator : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject livesStatViewPrefab;
    private UnityEngine.GameObject parentContainer;
    
    // Methods
    private void Start()
    {
        if(this.parentContainer != 0)
        {
            goto label_3;
        }
        
        UnityEngine.GameObject val_2 = this.gameObject;
        this.parentContainer = val_2;
        if(val_2 != null)
        {
            goto label_4;
        }
        
        label_3:
        label_4:
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.livesStatViewPrefab, parent:  this.parentContainer.transform);
    }
    public LivesStatViewInstantiator()
    {
    
    }

}
