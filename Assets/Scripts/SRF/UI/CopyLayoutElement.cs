using UnityEngine;

namespace SRF.UI
{
    public class CopyLayoutElement : UIBehaviour, ILayoutElement
    {
        // Fields
        public bool CopyMinHeight;
        public bool CopyMinWidth;
        public bool CopyPreferredHeight;
        public bool CopyPreferredWidth;
        public UnityEngine.RectTransform CopySource;
        public float PaddingMinHeight;
        public float PaddingMinWidth;
        public float PaddingPreferredHeight;
        public float PaddingPreferredWidth;
        
        // Properties
        public float preferredWidth { get; }
        public float preferredHeight { get; }
        public float minWidth { get; }
        public float minHeight { get; }
        public int layoutPriority { get; }
        public float flexibleHeight { get; }
        public float flexibleWidth { get; }
        
        // Methods
        public float get_preferredWidth()
        {
            if(this.CopyPreferredWidth == false)
            {
                    return (float)-1f;
            }
            
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetPreferredWidth(rect:  this.CopySource)) + this.PaddingPreferredWidth;
            return (float)-1f;
        }
        public float get_preferredHeight()
        {
            if(this.CopyPreferredHeight == false)
            {
                    return (float)-1f;
            }
            
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetPreferredHeight(rect:  this.CopySource)) + this.PaddingPreferredHeight;
            return (float)-1f;
        }
        public float get_minWidth()
        {
            if(this.CopyMinWidth == false)
            {
                    return (float)-1f;
            }
            
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetMinWidth(rect:  this.CopySource)) + this.PaddingMinWidth;
            return (float)-1f;
        }
        public float get_minHeight()
        {
            if(this.CopyMinHeight == false)
            {
                    return (float)-1f;
            }
            
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetMinHeight(rect:  this.CopySource)) + this.PaddingMinHeight;
            return (float)-1f;
        }
        public int get_layoutPriority()
        {
            return 2;
        }
        public float get_flexibleHeight()
        {
            return -1f;
        }
        public float get_flexibleWidth()
        {
            return -1f;
        }
        public void CalculateLayoutInputHorizontal()
        {
        
        }
        public void CalculateLayoutInputVertical()
        {
        
        }
        public CopyLayoutElement()
        {
        
        }
    
    }

}
