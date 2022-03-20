using UnityEngine;

namespace SRF.UI
{
    public class CopyPreferredSize : LayoutElement
    {
        // Fields
        public UnityEngine.RectTransform CopySource;
        public float PaddingHeight;
        public float PaddingWidth;
        
        // Properties
        public override float preferredWidth { get; }
        public override float preferredHeight { get; }
        public override int layoutPriority { get; }
        
        // Methods
        public override float get_preferredWidth()
        {
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetPreferredWidth(rect:  this.CopySource)) + this.PaddingWidth;
            return (float)-1f;
        }
        public override float get_preferredHeight()
        {
            if(this.CopySource == 0)
            {
                    return (float)-1f;
            }
            
            if(this.IsActive() == false)
            {
                    return (float)-1f;
            }
            
            -1f = (UnityEngine.UI.LayoutUtility.GetPreferredHeight(rect:  this.CopySource)) + this.PaddingHeight;
            return (float)-1f;
        }
        public override int get_layoutPriority()
        {
            return 2;
        }
        public CopyPreferredSize()
        {
        
        }
    
    }

}
