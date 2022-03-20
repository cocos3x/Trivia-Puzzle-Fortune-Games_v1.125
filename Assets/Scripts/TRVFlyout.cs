using UnityEngine;
public class TRVFlyout : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject flyoutObject;
    private UnityEngine.UI.Text flyoutText;
    
    // Methods
    public System.Collections.IEnumerator DisplayFlyout(string text, float seconds = 3)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .text = text;
        .seconds = seconds;
        return (System.Collections.IEnumerator)new TRVFlyout.<DisplayFlyout>d__2();
    }
    public TRVFlyout()
    {
    
    }

}
