using UnityEngine;
public class ObserveExample : MonoBehaviour
{
    // Fields
    public string hoge;
    public ObserveExample.Test test;
    
    // Methods
    public void Callback()
    {
        UnityEngine.Debug.Log(message:  "call");
    }
    private void Callback2()
    {
        UnityEngine.Debug.Log(message:  "call2");
    }
    public ObserveExample()
    {
    
    }

}
