using UnityEngine;
public class SetPreferredHeight : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.LayoutElement layoutElement;
    private UnityEngine.Canvas canvas;
    private UnityEngine.RectTransform canvasRectTransform;
    private bool matchCanvasHeight;
    private float heightOffset;
    
    // Methods
    private void Awake()
    {
        this.layoutElement = this.GetComponent<UnityEngine.UI.LayoutElement>();
        UnityEngine.Canvas val_2 = this.GetComponentInParent<UnityEngine.Canvas>();
        this.canvas = val_2;
        this.canvasRectTransform = val_2.transform.GetComponent<UnityEngine.RectTransform>();
    }
    private void Start()
    {
        this.UpdateUI();
    }
    private void OnRectTransformDimensionsChange()
    {
        this.UpdateUI();
    }
    private void UpdateUI()
    {
        if(this.layoutElement == 0)
        {
                return;
        }
        
        if(this.matchCanvasHeight == false)
        {
                return;
        }
        
        UnityEngine.Rect val_2 = this.canvasRectTransform.rect;
        float val_3 = val_2.m_XMin.height;
        val_3 = val_3 + this.heightOffset;
    }
    public SetPreferredHeight()
    {
    
    }

}
