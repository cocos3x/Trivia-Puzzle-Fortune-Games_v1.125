using UnityEngine;
public class TRVHintReminderPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject toolTipParent;
    private UnityEngine.RectTransform toolTipBox;
    private UnityEngine.UI.Text toolTipText;
    private System.Collections.Generic.List<UnityEngine.RectTransform> toolTipPick;
    private UnityEngine.CanvasGroup cGroup;
    public System.Action onDestroyAction;
    
    // Methods
    public void Dismiss()
    {
        int val_1 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.cGroup, complete:  false);
        DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.cGroup, endValue:  0f, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void TRVHintReminderPopup::DestroyMe()));
    }
    private void Awake()
    {
        this.gameObject.layer = UnityEngine.LayerMask.NameToLayer(layerName:  "UI");
    }
    public void ShowToolTip(System.Collections.Generic.List<UnityEngine.GameObject> objsToToolTip)
    {
        UnityEngine.CanvasGroup val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        this.cGroup = val_2;
        val_2.alpha = 0f;
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.cGroup, endValue:  1f, duration:  0.1f);
        this.gameObject.SetActive(value:  true);
        UnityEngine.Canvas val_6 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.Canvas>(gameObject:  this.gameObject);
        val_6.overrideSorting = true;
        val_6.sortingLayerName = "Immediate";
    }
    private void PlaceToolTip(UnityEngine.GameObject objToToolTip, bool topTT, PopupViewportSettings viewportSettings, UnityEngine.Vector2 tooltipOffset)
    {
        float val_22;
        var val_23;
        float val_24;
        float val_25;
        var val_26;
        val_22 = tooltipOffset.y;
        val_23 = this;
        this.transform.SetParent(p:  objToToolTip.transform);
        MonoExtensions.ResetLocal(trans:  this.transform);
        UnityEngine.RectTransform val_4 = this.toolTipParent.GetComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector2 val_5 = val_4.anchoredPosition;
        val_24 = val_5.x;
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.up;
        val_25 = val_6.x;
        UnityEngine.Rect val_7 = this.toolTipBox.rect;
        UnityEngine.Vector2 val_9 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_25, y = val_6.y}, d:  val_7.m_XMin.height);
        UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Division(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, d:  2f);
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_24, y = val_5.y}, b:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y});
        UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y}, b:  new UnityEngine.Vector2() {x = tooltipOffset.x, y = val_22});
        val_4.anchoredPosition = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
        val_26 = 1152921504979689472;
        UnityEngine.Camera val_13 = SLCWindowManager<WGWindowManager>.gameplayCamera;
        if(viewportSettings == null)
        {
                return;
        }
        
        val_26 = SLCWindowManager<WGWindowManager>.monolithPopupCamera;
        UnityEngine.Vector3 val_16 = this.toolTipBox.transform.position;
        UnityEngine.Vector3 val_17 = val_26.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        val_25 = viewportSettings.minX;
        val_22 = val_17.z;
        val_24 = UnityEngine.Mathf.Clamp(value:  val_17.x, min:  val_25, max:  viewportSettings.maxX);
        val_23 = this.toolTipBox.transform;
        UnityEngine.Vector3 val_21 = val_26.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_24, y = UnityEngine.Mathf.Clamp(value:  val_17.y, min:  viewportSettings.minY, max:  viewportSettings.maxY), z = val_22});
        val_23.position = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
    }
    private void DestroyMe()
    {
        if(this.onDestroyAction != null)
        {
                this.onDestroyAction.Invoke();
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public TRVHintReminderPopup()
    {
        this.toolTipPick = new System.Collections.Generic.List<UnityEngine.RectTransform>();
    }

}
