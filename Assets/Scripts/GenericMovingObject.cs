using UnityEngine;
public class GenericMovingObject : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject itemGroup;
    private UnityEngine.GameObject item;
    private UnityEngine.ParticleSystem particle;
    private float flyToPreDelay;
    private float flyToDuration;
    private float flyToAfterDelay;
    private DG.Tweening.Ease easeX;
    private DG.Tweening.Ease easeY;
    public UnityEngine.GameObject eventButton;
    
    // Methods
    public void Init(UnityEngine.GameObject eventButton)
    {
        this.eventButton = eventButton;
    }
    public void ShiftToCell(Cell newParent)
    {
        if(newParent == 0)
        {
                return;
        }
        
        this.transform.SetParent(p:  newParent.transform);
        PluginExtension.SetLocalX(transform:  this.GetComponent<UnityEngine.RectTransform>(), x:  0f);
        PluginExtension.SetLocalY(transform:  this.GetComponent<UnityEngine.RectTransform>(), y:  0f);
    }
    public void Collect()
    {
        if(this.eventButton == 0)
        {
                return;
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.FlyAndHide());
    }
    public void Remove()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private System.Collections.IEnumerator FlyAndHide()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new GenericMovingObject.<FlyAndHide>d__13();
    }
    public GenericMovingObject()
    {
        this.flyToPreDelay = 0.2f;
        this.flyToDuration = 1f;
        this.flyToAfterDelay = 0.2f;
    }

}
