using UnityEngine;
public class TRVScreenBlocker : MonoSingleton<TRVScreenBlocker>
{
    // Methods
    public void SetActive(bool active)
    {
        this.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = active;
    }
    public TRVScreenBlocker()
    {
    
    }

}
