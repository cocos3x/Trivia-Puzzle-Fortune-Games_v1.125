using UnityEngine;

namespace SRF.UI
{
    public class SRText : Text
    {
        // Fields
        private System.Action<SRF.UI.SRText> LayoutDirty;
        
        // Methods
        public void add_LayoutDirty(System.Action<SRF.UI.SRText> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.LayoutDirty, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.LayoutDirty != 1152921519468729904);
            
            return;
            label_2:
        }
        public void remove_LayoutDirty(System.Action<SRF.UI.SRText> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.LayoutDirty, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.LayoutDirty != 1152921519468866480);
            
            return;
            label_2:
        }
        public override void SetLayoutDirty()
        {
            this.SetLayoutDirty();
            if(this.LayoutDirty == null)
            {
                    return;
            }
            
            this.LayoutDirty.Invoke(obj:  this);
        }
        public SRText()
        {
        
        }
    
    }

}
