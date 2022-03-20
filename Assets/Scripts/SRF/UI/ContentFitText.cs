using UnityEngine;

namespace SRF.UI
{
    public class ContentFitText : UIBehaviour, ILayoutElement
    {
        // Fields
        public SRF.UI.SRText CopySource;
        public UnityEngine.Vector2 Padding;
        
        // Properties
        public float minWidth { get; }
        public float preferredWidth { get; }
        public float flexibleWidth { get; }
        public float minHeight { get; }
        public float preferredHeight { get; }
        public float flexibleHeight { get; }
        public int layoutPriority { get; }
        
        // Methods
        public float get_minWidth()
        {
            if(this.CopySource == 0)
            {
                    return (float)val_3;
            }
            
            float val_3 = UnityEngine.UI.LayoutUtility.GetMinWidth(rect:  this.CopySource.rectTransform);
            val_3 = val_3 + this.Padding;
            return (float)val_3;
        }
        public float get_preferredWidth()
        {
            if(this.CopySource == 0)
            {
                    return (float)val_3;
            }
            
            float val_3 = UnityEngine.UI.LayoutUtility.GetPreferredWidth(rect:  this.CopySource.rectTransform);
            val_3 = val_3 + this.Padding;
            return (float)val_3;
        }
        public float get_flexibleWidth()
        {
            if(this.CopySource != 0)
            {
                    return UnityEngine.UI.LayoutUtility.GetFlexibleWidth(rect:  this.CopySource.rectTransform);
            }
            
            return -1f;
        }
        public float get_minHeight()
        {
            if(this.CopySource == 0)
            {
                    return (float)val_3;
            }
            
            float val_3 = UnityEngine.UI.LayoutUtility.GetFlexibleHeight(rect:  this.CopySource.rectTransform);
            val_3 = val_3 + S1;
            return (float)val_3;
        }
        public float get_preferredHeight()
        {
            if(this.CopySource == 0)
            {
                    return (float)val_3;
            }
            
            float val_3 = UnityEngine.UI.LayoutUtility.GetPreferredHeight(rect:  this.CopySource.rectTransform);
            val_3 = val_3 + S1;
            return (float)val_3;
        }
        public float get_flexibleHeight()
        {
            if(this.CopySource != 0)
            {
                    return UnityEngine.UI.LayoutUtility.GetFlexibleHeight(rect:  this.CopySource.rectTransform);
            }
            
            return -1f;
        }
        public int get_layoutPriority()
        {
            return 0;
        }
        public void CalculateLayoutInputHorizontal()
        {
            if(this.CopySource != null)
            {
                    this.CopySource.CalculateLayoutInputHorizontal();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void CalculateLayoutInputVertical()
        {
            if(this.CopySource != null)
            {
                    this.CopySource.CalculateLayoutInputVertical();
                return;
            }
            
            throw new NullReferenceException();
        }
        protected override void OnEnable()
        {
            this.SetDirty();
            this.CopySource.add_LayoutDirty(value:  new System.Action<SRF.UI.SRText>(object:  this, method:  System.Void SRF.UI.ContentFitText::CopySourceOnLayoutDirty(SRF.UI.SRText srText)));
        }
        private void CopySourceOnLayoutDirty(SRF.UI.SRText srText)
        {
            this.SetDirty();
        }
        protected override void OnTransformParentChanged()
        {
            this.SetDirty();
        }
        protected override void OnDisable()
        {
            this.CopySource.remove_LayoutDirty(value:  new System.Action<SRF.UI.SRText>(object:  this, method:  System.Void SRF.UI.ContentFitText::CopySourceOnLayoutDirty(SRF.UI.SRText srText)));
            this.SetDirty();
        }
        protected override void OnDidApplyAnimationProperties()
        {
            this.SetDirty();
        }
        protected override void OnBeforeTransformParentChanged()
        {
            this.SetDirty();
        }
        protected void SetDirty()
        {
            UnityEngine.RectTransform val_3;
            if(this.IsActive() == false)
            {
                    return;
            }
            
            UnityEngine.Transform val_2 = this.transform;
            if(val_2 != null)
            {
                    val_2 = (null == null) ? (val_2) : 0;
            }
            else
            {
                    val_3 = 0;
            }
            
            UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  val_3);
        }
        public ContentFitText()
        {
        
        }
    
    }

}
