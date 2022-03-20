using UnityEngine;
public abstract class StatViewInstantiatior : MonoBehaviour
{
    // Fields
    protected UnityEngine.Transform statViewParent;
    private bool enabledByDefault;
    private bool interactableByDefault;
    private CurrencyStatView <StatView>k__BackingField;
    protected UnityEngine.GameObject statViewObject;
    protected TweenCoinsText statViewTextTween;
    protected bool hasCreated;
    protected Anchor anchorOverride;
    protected bool useNewAnchorsAndStatViews;
    public System.Action onCreated;
    
    // Properties
    public CurrencyStatView StatView { get; set; }
    public bool SetEnabledByDefault { set; }
    public bool created { get; }
    
    // Methods
    public CurrencyStatView get_StatView()
    {
        return (CurrencyStatView)this.<StatView>k__BackingField;
    }
    private void set_StatView(CurrencyStatView value)
    {
        this.<StatView>k__BackingField = value;
    }
    public void set_SetEnabledByDefault(bool value)
    {
        this.enabledByDefault = value;
    }
    public bool get_created()
    {
        return (bool)this.hasCreated;
    }
    private void Awake()
    {
        this.Create();
    }
    public void Create()
    {
        var val_20;
        UnityEngine.Transform val_21;
        if((this & 1) == 0)
        {
                return;
        }
        
        if(this.hasCreated != false)
        {
                return;
        }
        
        if(this.useNewAnchorsAndStatViews != true)
        {
                if((this.anchorOverride != 0) && ((this.GetComponent<UnityEngine.RectTransform>()) != 0))
        {
                MonoExtensions.SetUIAnchor_WRONGLY(rect:  this.GetComponent<UnityEngine.RectTransform>(), anchor:  this.anchorOverride);
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
            this.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.zero;
            val_20 = 0;
            this.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        }
        else
        {
                val_20 = this.GetComponent<UnityEngine.RectTransform>();
        }
        
        }
        
        if(this.statViewParent != 0)
        {
                val_21 = this.statViewParent;
        }
        else
        {
                val_21 = this.transform;
        }
        
        UnityEngine.GameObject val_11 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this, parent:  val_21);
        this.statViewObject = val_11;
        CurrencyStatView val_12 = val_11.GetComponent<CurrencyStatView>();
        this.<StatView>k__BackingField = val_12;
        if(val_12 != 0)
        {
                this.<StatView>k__BackingField.Interactable = this.interactableByDefault;
        }
        
        this.statViewObject.SetActive(value:  this.enabledByDefault);
        if((this.useNewAnchorsAndStatViews != false) && (this.anchorOverride != 0))
        {
                val_21 = 1152921515816500288;
            if((this.statViewObject.GetComponent<UnityEngine.RectTransform>()) != 0)
        {
                MonoExtensions.SetUIAnchor(rect:  this.statViewObject.GetComponent<UnityEngine.RectTransform>(), anchor:  this.anchorOverride);
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.zero;
            this.statViewObject.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_18.x, y = val_18.y};
        }
        
        }
        
        this.statViewTextTween = this.statViewObject.GetComponentInChildren<TweenCoinsText>();
        this.hasCreated = true;
        if(this.onCreated == null)
        {
                return;
        }
        
        this.onCreated.Invoke();
    }
    public void SetStatViewValue(int instantValue)
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  instantValue);
        this.statViewTextTween.Set(instantValue:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
    }
    public void SetStoreButtonAction()
    {
    
    }
    protected abstract void SetupAnimatedElements(); // 0
    protected abstract UnityEngine.GameObject GetPrefabFromTheme(); // 0
    protected virtual void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
    
    }
    protected virtual bool ShouldCreate()
    {
        return true;
    }
    protected StatViewInstantiatior()
    {
        this.enabledByDefault = true;
        this.anchorOverride = true;
    }

}
