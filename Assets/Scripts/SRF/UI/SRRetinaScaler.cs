using UnityEngine;

namespace SRF.UI
{
    public class SRRetinaScaler : SRMonoBehaviour
    {
        // Fields
        private float _retinaScale;
        private int _thresholdDpi;
        private bool _disablePixelPerfect;
        
        // Properties
        public int ThresholdDpi { get; }
        public float RetinaScale { get; }
        
        // Methods
        public int get_ThresholdDpi()
        {
            return (int)this._thresholdDpi;
        }
        public float get_RetinaScale()
        {
            return (float)this._retinaScale;
        }
        private void Start()
        {
            float val_1 = UnityEngine.Screen.dpi;
            if(val_1 <= 0f)
            {
                    return;
            }
            
            if(val_1 <= (float)this._thresholdDpi)
            {
                    return;
            }
            
            val_2.m_UiScaleMode = 0;
            this.GetComponent<UnityEngine.UI.CanvasScaler>().scaleFactor = this._retinaScale;
            if(this._disablePixelPerfect == false)
            {
                    return;
            }
            
            this.GetComponent<UnityEngine.Canvas>().pixelPerfect = false;
        }
        public SRRetinaScaler()
        {
            this._retinaScale = 2f;
            this._thresholdDpi = 250;
        }
    
    }

}
