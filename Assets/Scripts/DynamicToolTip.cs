using UnityEngine;
public class DynamicToolTip : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject topTTParent;
    private UnityEngine.GameObject bottomTTParent;
    private UnityEngine.RectTransform topToolTipBox;
    private UnityEngine.RectTransform bottomToolTipBox;
    private UnityEngine.UI.Text topToolTipText;
    private UnityEngine.UI.Text bottomToolTipText;
    private UnityEngine.RectTransform topToolTipPick;
    private UnityEngine.RectTransform bottomToolTipPick;
    private UnityEngine.UI.Button topGotItButton;
    private UnityEngine.UI.Button bottomGotItButton;
    private UnityEngine.GameObject topGotItGroup;
    private UnityEngine.GameObject bottomGotItGroup;
    private System.Action GotItButtonAction;
    private UnityEngine.CanvasGroup cGroup;
    public System.Action onDestroyAction;
    
    // Methods
    public void Dismiss()
    {
        int val_1 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.cGroup, complete:  false);
        DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.cGroup, endValue:  0f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void DynamicToolTip::DestroyMe()));
    }
    private void Awake()
    {
        this.gameObject.layer = UnityEngine.LayerMask.NameToLayer(layerName:  "UI");
        if((UnityEngine.Object.op_Implicit(exists:  this.topGotItButton)) != false)
        {
                this.topGotItButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DynamicToolTip::HandleGotItClicked()));
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bottomGotItButton)) == false)
        {
                return;
        }
        
        this.bottomGotItButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DynamicToolTip::HandleGotItClicked()));
    }
    public void ShowToolTip(UnityEngine.GameObject objToToolTip, string text, bool topToolTip = True, float displayDuration = 3.5, float width = 0, float height = 0, float tooltipOffsetX = 0, float tooltipOffsetY = 0, PopupViewportSettings viewportSettings, bool showGotItButton = False, System.Action gotItCallback, bool showPick = True, int maxFontSize = -1)
    {
        float val_34;
        float val_35;
        UnityEngine.RectTransform val_36;
        UnityEngine.RectTransform val_39;
        val_34 = tooltipOffsetX;
        val_35 = tooltipOffsetY;
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  val_34, y:  val_35);
        if(width <= 0f)
        {
            goto label_1;
        }
        
        if(topToolTip == false)
        {
            goto label_2;
        }
        
        val_36 = this.topToolTipBox;
        if(val_36 != null)
        {
            goto label_3;
        }
        
        label_2:
        val_36 = this.bottomToolTipBox;
        label_3:
        UnityEngine.Rect val_2 = val_36.rect;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  width, y:  val_2.m_XMin.height);
        val_34 = val_4.x;
        val_35 = val_4.y;
        val_36.sizeDelta = new UnityEngine.Vector2() {x = val_34, y = val_35};
        label_1:
        if(height <= 0f)
        {
            goto label_6;
        }
        
        if(topToolTip == false)
        {
            goto label_7;
        }
        
        val_39 = this.topToolTipBox;
        if(val_39 != null)
        {
            goto label_8;
        }
        
        label_7:
        val_39 = this.bottomToolTipBox;
        label_8:
        UnityEngine.Rect val_5 = val_39.rect;
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_5.m_XMin.width, y:  height);
        val_35 = val_7.y;
        val_39.sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_35};
        label_6:
        this.topTTParent.gameObject.SetActive(value:  topToolTip);
        this.bottomTTParent.gameObject.SetActive(value:  (~topToolTip) & 1);
        if(maxFontSize != 1)
        {
                this.topToolTipText.resizeTextMaxSize = maxFontSize;
            this.bottomToolTipText.resizeTextMaxSize = maxFontSize;
        }
        
        this.PlaceToolTip(objToToolTip:  objToToolTip, topTT:  topToolTip, viewportSettings:  viewportSettings, tooltipOffset:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y});
        UnityEngine.CanvasGroup val_14 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        this.cGroup = val_14;
        val_14.alpha = 0f;
        DG.Tweening.Tweener val_15 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.cGroup, endValue:  1f, duration:  0.1f);
        if((displayDuration > 0f) && (gotItCallback == null))
        {
                DG.Tweening.Tweener val_19 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.cGroup, endValue:  0f, duration:  0.2f), delay:  displayDuration), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void DynamicToolTip::DestroyMe()));
        }
        
        this.gameObject.SetActive(value:  true);
        UnityEngine.Canvas val_22 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.Canvas>(gameObject:  this.gameObject);
        val_22.overrideSorting = true;
        val_22.sortingLayerName = "Immediate";
        if(this.topGotItButton == 0)
        {
                return;
        }
        
        UnityEngine.UI.GraphicRaycaster val_25 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.GraphicRaycaster>(gameObject:  val_22.gameObject);
        this.topGotItGroup.gameObject.SetActive(value:  showGotItButton);
        this.bottomGotItGroup.gameObject.SetActive(value:  showGotItButton);
        this.GotItButtonAction = gotItCallback;
        this.topToolTipPick.gameObject.SetActive(value:  showPick);
        this.bottomToolTipPick.gameObject.SetActive(value:  showPick);
    }
    private void PlaceToolTip(UnityEngine.GameObject objToToolTip, bool topTT, PopupViewportSettings viewportSettings, UnityEngine.Vector2 tooltipOffset)
    {
        var val_42;
        var val_43;
        var val_44;
        float val_45;
        float val_48;
        float val_51;
        float val_52;
        val_42 = topTT;
        this.transform.SetParent(p:  objToToolTip.transform);
        MonoExtensions.ResetLocal(trans:  this.transform);
        if(val_42 != false)
        {
                UnityEngine.RectTransform val_4 = this.topTTParent.GetComponent<UnityEngine.RectTransform>();
            val_43 = val_4;
            UnityEngine.Vector2 val_5 = val_4.anchoredPosition;
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.up;
            val_44 = this;
            val_45 = val_6.x;
            UnityEngine.Rect val_7 = this.topToolTipBox.rect;
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_45, y = val_6.y}, d:  val_7.m_XMin.height);
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Division(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, d:  2f);
            val_48 = val_5.x;
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_48, y = val_5.y}, b:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y});
        }
        else
        {
                UnityEngine.RectTransform val_12 = this.bottomTTParent.GetComponent<UnityEngine.RectTransform>();
            val_43 = val_12;
            UnityEngine.Vector2 val_13 = val_12.anchoredPosition;
            UnityEngine.Vector2 val_14 = UnityEngine.Vector2.up;
            val_44 = this;
            val_45 = val_14.x;
            UnityEngine.Rect val_15 = this.bottomToolTipBox.rect;
            UnityEngine.Vector2 val_17 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_45, y = val_14.y}, d:  val_15.m_XMin.height);
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.op_Division(a:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y}, d:  2f);
            val_48 = val_13.x;
            UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_48, y = val_13.y}, b:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y});
        }
        
        UnityEngine.Vector2 val_20 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y}, b:  new UnityEngine.Vector2() {x = tooltipOffset.x, y = tooltipOffset.y});
        val_43.anchoredPosition = new UnityEngine.Vector2() {x = val_20.x, y = val_20.y};
        UnityEngine.Vector3 val_23 = objToToolTip.transform.position;
        UnityEngine.Vector3 val_24 = SLCWindowManager<WGWindowManager>.gameplayCamera.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z});
        val_51 = val_24.x + (-0.5f);
        UnityEngine.Rect val_25 = this.bottomToolTipBox.rect;
        UnityEngine.Vector2 val_28 = this.bottomToolTipBox.anchoredPosition;
        val_52 = val_28.x;
        UnityEngine.Vector2 val_29 = UnityEngine.Vector2.right;
        UnityEngine.Vector2 val_31 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y}, d:  -(val_51 * (val_25.m_XMin.width * 0.9f)));
        UnityEngine.Vector2 val_32 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_52, y = val_28.y}, b:  new UnityEngine.Vector2() {x = val_31.x, y = val_31.y});
        this.bottomToolTipBox.anchoredPosition = new UnityEngine.Vector2() {x = val_32.x, y = val_32.y};
        if(viewportSettings == null)
        {
                return;
        }
        
        UnityEngine.Camera val_33 = SLCWindowManager<WGWindowManager>.monolithPopupCamera;
        if(val_42 != false)
        {
                if(this.topToolTipBox != null)
        {
            goto label_26;
        }
        
        }
        
        label_26:
        UnityEngine.Vector3 val_35 = this.bottomToolTipBox.transform.position;
        UnityEngine.Vector3 val_36 = val_33.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z});
        val_45 = viewportSettings.minX;
        val_52 = val_36.z;
        val_51 = UnityEngine.Mathf.Clamp(value:  val_36.y, min:  viewportSettings.minY, max:  viewportSettings.maxY);
        if(val_42 != false)
        {
                if(this.topToolTipBox != null)
        {
            goto label_34;
        }
        
        }
        
        label_34:
        val_42 = this.bottomToolTipBox.transform;
        UnityEngine.Vector3 val_40 = val_33.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = UnityEngine.Mathf.Clamp(value:  val_36.x, min:  val_45, max:  viewportSettings.maxX), y = val_51, z = val_52});
        val_42.position = new UnityEngine.Vector3() {x = val_40.x, y = val_40.y, z = val_40.z};
    }
    private void DestroyMe()
    {
        if(this.onDestroyAction != null)
        {
                this.onDestroyAction.Invoke();
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void HandleGotItClicked()
    {
        if(this.GotItButtonAction == null)
        {
                return;
        }
        
        this.GotItButtonAction.Invoke();
    }
    public DynamicToolTip()
    {
    
    }

}
