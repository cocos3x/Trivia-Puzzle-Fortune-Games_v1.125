using UnityEngine;
public class FtuxTooltip : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform parentRectTransform;
    private UnityEngine.RectTransform tooltipRectTransform;
    private UnityEngine.RectOffset paddingForSpeechBubble;
    private UnityEngine.UI.Image bubbleTipImage;
    private UnityEngine.UI.Text tooltipText;
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.Canvas parentCanvas;
    
    // Methods
    private void Awake()
    {
        this.parentCanvas = this.GetComponentInChildren<UnityEngine.UI.Graphic>().canvas.rootCanvas;
    }
    public void SetText(string description)
    {
        if(this.tooltipText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void SetupButton(string text, UnityEngine.Events.UnityAction action)
    {
        this.button.gameObject.SetActive(value:  true);
        if(action == null)
        {
                return;
        }
        
        this.button.m_OnClick.RemoveAllListeners();
        this.button.m_OnClick.AddListener(call:  action);
    }
    public void Reposition(UnityEngine.Vector3 worldPos)
    {
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        this.Reposition(worldPos:  new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z}, anchoredOffset:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y});
    }
    public void Reposition(UnityEngine.Vector3 worldPos, UnityEngine.Vector2 anchoredOffset)
    {
        float val_38;
        float val_39;
        if(this.parentCanvas != 0)
        {
            goto label_3;
        }
        
        UnityEngine.Canvas val_4 = this.GetComponentInChildren<UnityEngine.UI.Graphic>().canvas.rootCanvas;
        this.parentCanvas = val_4;
        if(val_4 != null)
        {
            goto label_6;
        }
        
        label_3:
        label_6:
        UnityEngine.Transform val_6 = this.parentCanvas.gameObject.transform;
        UnityEngine.Camera val_7 = this.parentCanvas.worldCamera;
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        UnityEngine.Vector2 val_8 = val_7.WorldToCanvasPosition(canvasRect:  val_6, canvasCamera:  val_7, position:  new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z});
        UnityEngine.Rect val_9 = this.parentRectTransform.rect;
        UnityEngine.Vector2 val_10 = val_9.m_XMin.min;
        UnityEngine.Rect val_11 = this.parentRectTransform.rect;
        UnityEngine.Vector2 val_12 = val_11.m_XMin.max;
        UnityEngine.Rect val_13 = this.tooltipRectTransform.rect;
        UnityEngine.Vector2 val_14 = val_13.m_XMin.min;
        UnityEngine.Vector2 val_15 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y}, b:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
        UnityEngine.Rect val_16 = this.tooltipRectTransform.rect;
        UnityEngine.Vector2 val_17 = val_16.m_XMin.max;
        UnityEngine.Vector2 val_18 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y}, b:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
        UnityEngine.Vector2 val_19 = UnityEngine.Vector2.zero;
        val_38 = val_19.x;
        val_39 = val_19.y;
        float val_38 = (float)this.paddingForSpeechBubble.left;
        val_38 = val_10.x + val_38;
        if(val_15.x < 0)
        {
                float val_39 = (float)this.paddingForSpeechBubble.left;
            val_39 = val_10.x + val_39;
            val_39 = val_39 - val_15.x;
            val_38 = val_38 + val_39;
        }
        
        float val_40 = (float)this.paddingForSpeechBubble.right;
        val_40 = val_12.x - val_40;
        if(val_18.x > val_40)
        {
                float val_41 = (float)this.paddingForSpeechBubble.right;
            val_41 = val_12.x - val_41;
            val_41 = val_18.x - val_41;
            val_38 = val_38 - val_41;
        }
        
        float val_42 = (float)this.paddingForSpeechBubble.bottom;
        val_42 = val_10.y + val_42;
        if(val_15.y < 0)
        {
                float val_43 = (float)this.paddingForSpeechBubble.bottom;
            val_43 = val_10.y + val_43;
            val_43 = val_43 - val_15.y;
            val_39 = val_39 + val_43;
        }
        
        float val_44 = (float)this.paddingForSpeechBubble.top;
        val_44 = val_12.y - val_44;
        if(val_18.y > val_44)
        {
                float val_45 = (float)this.paddingForSpeechBubble.top;
            val_45 = val_12.y - val_45;
            val_45 = val_18.y - val_45;
            val_39 = val_39 - val_45;
        }
        
        UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y}, b:  new UnityEngine.Vector2() {x = val_38, y = val_39});
        UnityEngine.Vector2 val_29 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_28.x, y = val_28.y}, b:  new UnityEngine.Vector2() {x = anchoredOffset.x, y = anchoredOffset.y});
        this.tooltipRectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_29.x, y = val_29.y};
        UnityEngine.Vector2 val_30 = this.tooltipRectTransform.sizeDelta;
        float val_47 = val_30.x;
        UnityEngine.Vector2 val_31 = this.tooltipRectTransform.anchoredPosition;
        float val_46 = 0.8f;
        val_46 = val_47 * val_46;
        val_47 = val_46 * 0.5f;
        UnityEngine.Vector2 val_36 = this.bubbleTipImage.rectTransform.anchoredPosition;
        UnityEngine.Vector2 val_37 = new UnityEngine.Vector2(x:  UnityEngine.Mathf.Clamp(value:  val_8.x - val_31.x, min:  -val_47, max:  val_47), y:  val_36.y);
        this.bubbleTipImage.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_37.x, y = val_37.y};
        return;
        label_12:
    }
    private UnityEngine.Vector2 WorldToCanvasPosition(UnityEngine.RectTransform canvasRect, UnityEngine.Camera canvasCamera, UnityEngine.Vector3 position)
    {
        UnityEngine.Vector3 val_1 = canvasCamera.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = position.x, y = position.y, z = position.z});
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        float val_11 = val_2.x;
        UnityEngine.Vector2 val_3 = canvasRect.sizeDelta;
        val_11 = val_11 * val_3.x;
        UnityEngine.Vector2 val_4 = canvasRect.sizeDelta;
        UnityEngine.Vector2 val_6 = canvasRect.sizeDelta;
        float val_12 = val_6.x;
        UnityEngine.Vector2 val_7 = canvasRect.pivot;
        val_7.x = val_12 * val_7.x;
        val_12 = val_11 - val_7.x;
        UnityEngine.Vector2 val_8 = canvasRect.sizeDelta;
        UnityEngine.Vector2 val_9 = canvasRect.pivot;
        val_9.y = (val_2.y * val_4.y) - (val_8.y * val_9.y);
        return new UnityEngine.Vector2() {x = val_12, y = val_9.y};
    }
    public FtuxTooltip()
    {
    
    }

}
