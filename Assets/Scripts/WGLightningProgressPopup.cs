using UnityEngine;
public class WGLightningProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject windowGroup;
    private UnityEngine.UI.Image lightningIcon;
    private UnityEngine.Sprite lightningWordsSp;
    private UnityEngine.Sprite lightningLevelsSp;
    private const float DEFAULT_POPUP_DURATION_IN_SECONDS = 2.5;
    
    // Methods
    private void Awake()
    {
        if(this.windowGroup != null)
        {
                this.windowGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ShowPopup());
    }
    private System.Collections.IEnumerator ShowPopup()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLightningProgressPopup.<ShowPopup>d__7();
    }
    private System.Collections.IEnumerator PlayFallAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLightningProgressPopup.<PlayFallAnimation>d__8();
    }
    private System.Collections.Generic.Dictionary<LightningEvents, UnityEngine.Sprite> GetLightningIcons()
    {
        System.Collections.Generic.Dictionary<LightningEvents, UnityEngine.Sprite> val_1 = new System.Collections.Generic.Dictionary<LightningEvents, UnityEngine.Sprite>();
        val_1.Add(key:  0, value:  this.lightningWordsSp);
        val_1.Add(key:  1, value:  this.lightningLevelsSp);
        return val_1;
    }
    public void Setup(LightningEvents e)
    {
        this.lightningIcon.sprite = this.GetLightningIcons().Item[e];
    }
    public void ClosePopup()
    {
        this.StopAllCoroutines();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLightningProgressPopup()
    {
    
    }

}
