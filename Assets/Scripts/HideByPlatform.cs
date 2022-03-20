using UnityEngine;
public class HideByPlatform : MonoBehaviour
{
    // Fields
    public bool hideOnIphone;
    public bool hideOnAndroid;
    public bool hideOnAutopilot;
    public bool hideInEditor;
    public bool hideWebGL;
    
    // Methods
    private void Start()
    {
        this.DoHideCheck();
    }
    private void OnEnable()
    {
        this.DoHideCheck();
    }
    private void DoHideCheck()
    {
        if(this.hideOnAndroid == false)
        {
                return;
        }
        
        NGUITools.SetActive(go:  this.gameObject, state:  false);
    }
    public HideByPlatform()
    {
    
    }

}
