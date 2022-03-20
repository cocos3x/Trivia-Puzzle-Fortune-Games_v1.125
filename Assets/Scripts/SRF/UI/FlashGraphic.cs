using UnityEngine;

namespace SRF.UI
{
    public class FlashGraphic : UIBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
    {
        // Fields
        public float DecayTime;
        public UnityEngine.Color DefaultColor;
        public UnityEngine.Color FlashColor;
        public UnityEngine.UI.Graphic Target;
        
        // Methods
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.Target != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.Target != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_420;
        }
        protected void Update()
        {
        
        }
        public void Flash()
        {
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_420;
        }
        public FlashGraphic()
        {
            this.DecayTime = 0.15f;
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
            this.DefaultColor = val_1.r;
            UnityEngine.Color val_2 = UnityEngine.Color.white;
            this.FlashColor = val_2;
            mem[1152921519462238208] = val_2.g;
            mem[1152921519462238212] = val_2.b;
            mem[1152921519462238216] = val_2.a;
        }
    
    }

}
