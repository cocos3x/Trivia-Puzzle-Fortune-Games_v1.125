using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class HandleManager : SRMonoBehaviour
    {
        // Fields
        private bool _hasSet;
        public UnityEngine.GameObject BottomHandle;
        public UnityEngine.GameObject BottomLeftHandle;
        public UnityEngine.GameObject BottomRightHandle;
        public SRDebugger.PinAlignment DefaultAlignment;
        public UnityEngine.GameObject LeftHandle;
        public UnityEngine.GameObject RightHandle;
        public UnityEngine.GameObject TopHandle;
        public UnityEngine.GameObject TopLeftHandle;
        public UnityEngine.GameObject TopRightHandle;
        
        // Methods
        private void Start()
        {
            if(this._hasSet != false)
            {
                    return;
            }
            
            this.SetAlignment(alignment:  this.DefaultAlignment);
        }
        public void SetAlignment(SRDebugger.PinAlignment alignment)
        {
            UnityEngine.GameObject val_7;
            this._hasSet = true;
            if(alignment < 2)
            {
                goto label_0;
            }
            
            if((alignment & 4294967294) != 2)
            {
                goto label_1;
            }
            
            this.SetActive(obj:  this.BottomHandle, active:  false);
            this.SetActive(obj:  this.TopHandle, active:  true);
            this.SetActive(obj:  this.BottomLeftHandle, active:  false);
            val_7 = this.BottomRightHandle;
            goto label_2;
            label_0:
            this.SetActive(obj:  this.BottomHandle, active:  true);
            this.SetActive(obj:  this.TopHandle, active:  false);
            this.SetActive(obj:  this.TopLeftHandle, active:  false);
            val_7 = this.TopRightHandle;
            label_2:
            this.SetActive(obj:  val_7, active:  false);
            label_1:
            if(alignment > 3)
            {
                    return;
            }
            
            var val_7 = 32557848;
            val_7 = (32557848 + (alignment) << 2) + val_7;
            goto (32557848 + (alignment) << 2 + 32557848);
        }
        private void SetActive(UnityEngine.GameObject obj, bool active)
        {
            if(obj == 0)
            {
                    return;
            }
            
            obj.SetActive(value:  active);
        }
        public HandleManager()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
