using UnityEngine;
public class Cell : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text letterText;
    protected UnityEngine.GameObject letterGroup;
    private UnityEngine.GameObject starredCoinGroup;
    private UnityEngine.UI.Image sharedDynamicImage;
    private UnityEngine.Sprite uncoloredBackground;
    public string letter;
    public bool isShown;
    private bool isStarred;
    private UnityEngine.Vector3 originLetterScale;
    private UnityEngine.Vector3 finalLetterScale;
    private UnityEngine.Animator animator;
    public UnityEngine.CanvasGroup cellCanvasGroup;
    public System.Action CellClickedAction;
    
    // Properties
    public UnityEngine.GameObject getLetter { get; }
    public UnityEngine.UI.Image DynamicImage { get; }
    
    // Methods
    public UnityEngine.GameObject get_getLetter()
    {
        return (UnityEngine.GameObject)this.letterGroup;
    }
    public UnityEngine.UI.Image get_DynamicImage()
    {
        return (UnityEngine.UI.Image)this.sharedDynamicImage;
    }
    public void Start()
    {
        this.animator = this.GetComponent<UnityEngine.Animator>();
    }
    private void OnEnable()
    {
        if(this.animator != 0)
        {
                return;
        }
        
        this.animator = this.GetComponent<UnityEngine.Animator>();
    }
    public void Animate(UnityEngine.Transform from, UnityEngine.Transform fromParent)
    {
        float val_33;
        DG.Tweening.TweenCallback val_34;
        UnityEngine.Vector3 val_1 = from.position;
        val_33 = val_1.z;
        UnityEngine.Vector3 val_3 = this.letterGroup.transform.localScale;
        this.originLetterScale = val_3;
        mem[1152921515432946896] = val_3.y;
        mem[1152921515432946900] = val_3.z;
        UnityEngine.Vector3 val_5 = fromParent.transform.position;
        UnityEngine.Vector3 val_6 = CUtils.GetMiddlePoint(begin:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_33}, end:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, delta:  -0.3f);
        UnityEngine.Vector3[] val_7 = new UnityEngine.Vector3[3];
        val_7[0] = val_1;
        val_7[0] = val_1.y;
        val_7[1] = val_33;
        val_7[1] = val_6;
        val_7[2] = val_6.y;
        val_7[2] = val_6.z;
        UnityEngine.Vector3 val_9 = fromParent.transform.position;
        val_7[3] = val_9;
        val_7[3] = val_9.y;
        val_7[4] = val_9.z;
        this.SetText();
        this.letterGroup.transform.position = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_33};
        UnityEngine.Vector3 val_12 = from.localScale;
        this.letterGroup.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
        this.letterGroup.transform.SetParent(p:  fromParent);
        DG.Tweening.TweenCallback val_17 = null;
        val_34 = val_17;
        val_17 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void Cell::OnMoveToComplete());
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> val_18 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  DG.Tweening.ShortcutExtensions.DOPath(target:  this.letterGroup.gameObject.transform, path:  val_7, duration:  0.2f, pathType:  0, pathMode:  1, resolution:  10, gizmoColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}), action:  val_17);
        DG.Tweening.Tweener val_21 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.letterGroup.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = this.originLetterScale, y = val_12.y, z = val_12.z}, duration:  0.2f);
        if(this.isStarred == false)
        {
                return;
        }
        
        UnityEngine.Vector3 val_24 = this.starredCoinGroup.transform.position;
        val_33 = val_24.y;
        UnityEngine.Vector3 val_25 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_26 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_24.x, y = val_33, z = val_24.z}, b:  new UnityEngine.Vector3() {x = val_25.x, y = val_25.y, z = val_25.z});
        DG.Tweening.Tweener val_27 = DG.Tweening.ShortcutExtensions.DOMove(target:  this.starredCoinGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z}, duration:  0.2f, snapping:  false);
        DG.Tweening.TweenCallback val_30 = null;
        val_34 = val_30;
        val_30 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void Cell::DisableStarSprite());
        DG.Tweening.Tweener val_31 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.starredCoinGroup.GetComponent<UnityEngine.UI.Image>(), endValue:  0f, duration:  0.4f), action:  val_30);
        WGAudioController val_32 = MonoSingleton<WGAudioController>.Instance;
        val_32.sound.PlayGameSpecificSound(id:  "WordStarredSuccess", clipIndex:  0);
    }
    private void DisableStarSprite()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.starredCoinGroup)) == false)
        {
                return;
        }
        
        this.starredCoinGroup.gameObject.SetActive(value:  false);
    }
    public void SetScale(UnityEngine.Vector3 newScale)
    {
        this.finalLetterScale = newScale;
        mem[1152921515433347068] = newScale.y;
        mem[1152921515433347072] = newScale.z;
        this.letterGroup.transform.localScale = new UnityEngine.Vector3() {x = newScale.x, y = newScale.y, z = newScale.z};
    }
    private void OnMoveToComplete()
    {
        this.letterGroup.transform.SetParent(p:  this.transform);
        UnityEngine.Vector3 val_5 = this.transform.position;
        this.letterGroup.transform.position = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.originLetterScale, y = V9.16B, z = V8.16B}, d:  1.3f);
        DG.Tweening.Tweener val_11 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.letterGroup.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  0.15f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Cell::OnScaleUpComplete()));
        this.animator.SetTrigger(name:  "Highlight");
    }
    private void OnScaleUpComplete()
    {
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.letterGroup.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = this.originLetterScale}, duration:  0.15f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Cell::OnScaleDownComplete()));
    }
    private void OnScaleDownComplete()
    {
        this.letterGroup.transform.localScale = new UnityEngine.Vector3() {x = this.finalLetterScale};
    }
    public void ShowHint()
    {
        this.isShown = true;
        UnityEngine.Vector3 val_2 = this.letterGroup.transform.localScale;
        this.originLetterScale = val_2;
        mem[1152921515433985616] = val_2.y;
        mem[1152921515433985620] = val_2.z;
        this.SetText();
        this.OnMoveToComplete();
    }
    public void ShowStarred()
    {
        if(this.starredCoinGroup == 0)
        {
                return;
        }
        
        this.starredCoinGroup.SetActive(value:  true);
        this.isStarred = true;
    }
    public void HideStarred()
    {
        if(this.starredCoinGroup == 0)
        {
                return;
        }
        
        this.starredCoinGroup.SetActive(value:  false);
    }
    public void ShowDynamicImage(UnityEngine.Sprite sprite)
    {
        if(this.sharedDynamicImage == 0)
        {
                return;
        }
        
        this.sharedDynamicImage.sprite = sprite;
        this.sharedDynamicImage.gameObject.SetActive(value:  true);
    }
    public void HideDynamicImage()
    {
        if(this.sharedDynamicImage == 0)
        {
                return;
        }
        
        this.sharedDynamicImage.gameObject.SetActive(value:  false);
    }
    public void SetAndShowText()
    {
        this.isShown = true;
        this.SetText();
    }
    private void SetText()
    {
        this.letterGroup.SetActive(value:  (~(System.String.IsNullOrEmpty(value:  this.letter))) & 1);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void ShowExists()
    {
        this.animator.SetTrigger(name:  "AlreadyFound");
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.letterGroup.gameObject.transform, duration:  0.75f, strength:  10f, vibrato:  10, randomness:  90f, snapping:  false, fadeOut:  true);
        DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.letterGroup.gameObject.transform, duration:  1f, strength:  10f, vibrato:  10, randomness:  90f, fadeOut:  true), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Cell::ResetLetterGroup()));
    }
    private void ResetLetterGroup()
    {
        UnityEngine.Vector3 val_3 = this.transform.position;
        this.letterGroup.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Quaternion val_5 = UnityEngine.Quaternion.identity;
        this.letterGroup.transform.rotation = new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w};
    }
    public virtual void RecolorCell()
    {
    
    }
    public void SetNewBackgroundAndColor(UnityEngine.Color32 bgColor, float bgAlpha = 1)
    {
        byte val_5 = bgColor.r;
        this.letterGroup.GetComponent<UnityEngine.UI.Image>().sprite = this.uncoloredBackground;
        val_5 = val_5 & 4294967295;
        UnityEngine.Color val_2 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_5, g = val_5, b = val_5, a = val_5});
        this.letterText.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
        UnityEngine.Color val_3 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_5, g = val_5, b = val_5, a = val_5});
        this.letterGroup.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = bgAlpha};
    }
    public virtual void SetPickerHintSpriteSwap(bool state)
    {
        this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = state;
    }
    public void TryDisplayWord()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.TryShowWordDefinition(selectedCell:  this);
    }
    public void TryCellClickedAction()
    {
        if(this.CellClickedAction == null)
        {
                return;
        }
        
        this.CellClickedAction.Invoke();
    }
    public Cell()
    {
    
    }

}
