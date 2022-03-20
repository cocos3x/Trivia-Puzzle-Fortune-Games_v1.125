using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class ScrollRectPatch : MonoBehaviour
    {
        // Fields
        public UnityEngine.RectTransform Content;
        public UnityEngine.UI.Mask ReplaceMask;
        public UnityEngine.RectTransform Viewport;
        
        // Methods
        private void Awake()
        {
            val_1.m_Content = this.Content;
            this.GetComponent<UnityEngine.UI.ScrollRect>().viewport = this.Viewport;
            if(this.ReplaceMask == 0)
            {
                    return;
            }
            
            UnityEngine.GameObject val_3 = this.ReplaceMask.gameObject;
            UnityEngine.Object.Destroy(obj:  val_3.GetComponent<UnityEngine.UI.Graphic>());
            UnityEngine.Object.Destroy(obj:  val_3.GetComponent<UnityEngine.CanvasRenderer>());
            UnityEngine.Object.Destroy(obj:  this.ReplaceMask);
            UnityEngine.UI.RectMask2D val_6 = val_3.AddComponent<UnityEngine.UI.RectMask2D>();
        }
        public ScrollRectPatch()
        {
        
        }
    
    }

}
