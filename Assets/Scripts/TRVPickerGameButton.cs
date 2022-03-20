using UnityEngine;
public class TRVPickerGameButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image myImage;
    public System.Action onClickAction;
    public System.Action onAnimationComplete;
    private UnityEngine.Sprite defaultSprite;
    private UnityEngine.Sprite specificSprite;
    private UnityEngine.UI.Image chosenOutline;
    
    // Properties
    public UnityEngine.UI.Button myButton { get; }
    public UnityEngine.Sprite SetSpecificSprite { get; set; }
    
    // Methods
    public UnityEngine.UI.Button get_myButton()
    {
        return this.gameObject.GetComponent<UnityEngine.UI.Button>();
    }
    public void set_SetSpecificSprite(UnityEngine.Sprite value)
    {
        this.specificSprite = value;
    }
    public UnityEngine.Sprite get_SetSpecificSprite()
    {
        return (UnityEngine.Sprite)this.specificSprite;
    }
    private void Start()
    {
        UnityEngine.UI.Button val_1 = this.myButton;
        val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void TRVPickerGameButton::OnClick()));
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.myImage).alpha = 0f;
        this.chosenOutline.gameObject.SetActive(value:  false);
    }
    public void OnClick()
    {
        if(this.onClickAction == null)
        {
                return;
        }
        
        this.onClickAction.Invoke();
    }
    public void RevealMe(bool selected)
    {
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.doReveal(selected:  selected));
    }
    private System.Collections.IEnumerator doReveal(bool selected)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .selected = selected;
        return (System.Collections.IEnumerator)new TRVPickerGameButton.<doReveal>d__14();
    }
    public void SetImageLocation(UnityEngine.Transform pos)
    {
        this.chosenOutline.gameObject.SetActive(value:  false);
        this.myImage.sprite = this.defaultSprite;
        UnityEngine.Vector3 val_3 = pos.position;
        this.myImage.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.myImage).alpha = 0f;
    }
    public void TweenImageHome(float duration)
    {
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.myImage), endValue:  1f, duration:  duration * 0.4f);
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        DG.Tweening.Tweener val_6 = DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.myImage.transform, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  duration, snapping:  true);
    }
    public TRVPickerGameButton()
    {
    
    }

}
