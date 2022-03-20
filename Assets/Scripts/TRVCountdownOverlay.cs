using UnityEngine;
public class TRVCountdownOverlay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.UI.Image timeRemainingBar;
    
    // Methods
    public System.Collections.IEnumerator countDown(int time)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .time = time;
        return (System.Collections.IEnumerator)new TRVCountdownOverlay.<countDown>d__2();
    }
    public TRVCountdownOverlay()
    {
    
    }

}
