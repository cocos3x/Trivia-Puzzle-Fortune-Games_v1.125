using UnityEngine;

namespace SRF.UI
{
    public class CopySizeIntoLayoutElement : LayoutElement
    {
        // Fields
        public UnityEngine.RectTransform CopySource;
        public float PaddingHeight;
        public float PaddingWidth;
        public bool SetPreferredSize;
        public bool SetMinimumSize;
        
        // Properties
        public override float preferredWidth { get; }
        public override float preferredHeight { get; }
        public override float minWidth { get; }
        public override float minHeight { get; }
        public override int layoutPriority { get; }
        
        // Methods
        public override float get_preferredWidth()
        {
            if(this.SetPreferredSize == false)
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
            
            UnityEngine.Rect val_3 = this.CopySource.rect;
            -1f = val_3.m_XMin.width + this.PaddingWidth;
            return (float)-1f;
        }
        public override float get_preferredHeight()
        {
            if(this.SetPreferredSize == false)
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
            
            UnityEngine.Rect val_3 = this.CopySource.rect;
            -1f = val_3.m_XMin.height + this.PaddingHeight;
            return (float)-1f;
        }
        public override float get_minWidth()
        {
            if(this.SetMinimumSize == false)
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
            
            UnityEngine.Rect val_3 = this.CopySource.rect;
            -1f = val_3.m_XMin.width + this.PaddingWidth;
            return (float)-1f;
        }
        public override float get_minHeight()
        {
            if(this.SetMinimumSize == false)
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
            
            UnityEngine.Rect val_3 = this.CopySource.rect;
            -1f = val_3.m_XMin.height + this.PaddingHeight;
            return (float)-1f;
        }
        public override int get_layoutPriority()
        {
            return 2;
        }
        public CopySizeIntoLayoutElement()
        {
        
        }
    
    }

}
