using UnityEngine;
public class UGUIMonolithTutorialHighlights : MonoBehaviour
{
    // Fields
    protected System.Collections.Generic.List<UnityEngine.Transform> Highlights;
    protected int currentHighlightIndex;
    protected UnityEngine.Transform currentParent;
    protected UnityEngine.Vector3 currentPos;
    protected int currentLayer;
    protected int currentSiblingIndex;
    
    // Methods
    public UnityEngine.Transform HighlightByIndex(int index, UnityEngine.Transform stage, bool disableButton = False)
    {
        bool val_19 = true;
        this.currentHighlightIndex = index;
        if(val_19 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = val_19 + (index << 3);
        this.currentParent = (true + (index) << 3) + 32.parent;
        if(val_19 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = val_19 + (((long)(int)(index)) << 3);
        UnityEngine.Vector3 val_2 = ((true + (index) << 3) + ((long)(int)(index)) << 3) + 32.position;
        this.currentPos = val_2;
        mem[1152921517086686820] = val_2.y;
        mem[1152921517086686824] = val_2.z;
        if(val_19 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = val_19 + (((long)(int)(index)) << 3);
        this.currentLayer = (((true + (index) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.gameObject.layer;
        if(val_19 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = val_19 + (((long)(int)(index)) << 3);
        this.currentSiblingIndex = ((((true + (index) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.GetSiblingIndex();
        var val_20 = null;
        if((this.currentParent.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>()) != 0)
        {
                this.currentParent.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>().enabled = false;
        }
        
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        UnityEngine.Vector3 val_11 = ((null + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.position;
        UnityEngine.Vector3 val_12 = (null + ((long)(int)(index)) << 3) + 32.root.GetComponentInChildren<UnityEngine.Camera>().WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        UnityEngine.Vector3 val_15 = stage.root.GetComponentInChildren<UnityEngine.Camera>().ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        (((null + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.SetParent(p:  stage);
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        ((((null + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.position = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        (((((null + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32.gameObject.layer = stage.gameObject.layer;
        if(val_20 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (((long)(int)(index)) << 3);
        return (UnityEngine.Transform)((((((null + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + ((long)(int)(index)) << 3) + 32;
    }
    public void UnhighlightCurrent()
    {
        bool val_5 = true;
        if(this.currentHighlightIndex == 1)
        {
                return;
        }
        
        if(val_5 <= this.currentHighlightIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.currentHighlightIndex) << 3);
        (true + (this.currentHighlightIndex) << 3) + 32.SetParent(p:  this.currentParent);
        if(val_5 <= this.currentHighlightIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.currentHighlightIndex) << 3);
        ((true + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + 32.position = new UnityEngine.Vector3() {x = this.currentPos};
        if(val_5 <= this.currentHighlightIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.currentHighlightIndex) << 3);
        (((true + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + 32.gameObject.layer = this.currentLayer;
        if(val_5 <= this.currentHighlightIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.currentHighlightIndex) << 3);
        ((((true + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + (this.currentHighlightIndex) << 3) + 32.SetSiblingIndex(index:  this.currentSiblingIndex);
        if((this.currentParent.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>()) == 0)
        {
                return;
        }
        
        this.currentParent.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>().enabled = true;
    }
    public UGUIMonolithTutorialHighlights()
    {
        this.Highlights = new System.Collections.Generic.List<UnityEngine.Transform>();
        this.currentHighlightIndex = 0;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.currentPos = val_2;
        mem[1152921517087091044] = val_2.y;
        mem[1152921517087091048] = val_2.z;
        this.currentLayer = -1;
        this.currentSiblingIndex = -1;
    }

}
