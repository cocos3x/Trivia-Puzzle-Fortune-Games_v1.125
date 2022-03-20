using UnityEngine;

namespace SRF.UI
{
    public class InheritColour : SRMonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Graphic _graphic;
        public UnityEngine.UI.Graphic From;
        
        // Properties
        private UnityEngine.UI.Graphic Graphic { get; }
        
        // Methods
        private UnityEngine.UI.Graphic get_Graphic()
        {
            UnityEngine.UI.Graphic val_3;
            if(this._graphic == 0)
            {
                    this._graphic = this.GetComponent<UnityEngine.UI.Graphic>();
                return val_3;
            }
            
            val_3 = this._graphic;
            return val_3;
        }
        private void Refresh()
        {
            if(this.From == 0)
            {
                    return;
            }
            
            UnityEngine.UI.Graphic val_2 = this.Graphic;
            UnityEngine.Color val_4 = this.From.canvasRenderer.GetColor();
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_2A0;
        }
        private void Update()
        {
            this.Refresh();
        }
        private void Start()
        {
            this.Refresh();
        }
        public InheritColour()
        {
        
        }
    
    }

}
