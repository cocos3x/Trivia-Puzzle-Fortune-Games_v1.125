using UnityEngine;

namespace SRF.UI
{
    public sealed class Unselectable : SRMonoBehaviour, ISelectHandler, IEventSystemHandler
    {
        // Fields
        private bool _suspectedSelected;
        
        // Methods
        public void OnSelect(UnityEngine.EventSystems.BaseEventData eventData)
        {
            this._suspectedSelected = true;
        }
        private void Update()
        {
            if(this._suspectedSelected == false)
            {
                    return;
            }
            
            UnityEngine.EventSystems.EventSystem val_1 = UnityEngine.EventSystems.EventSystem.current;
            if(val_1.m_CurrentSelected == this.CachedGameObject)
            {
                    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(selected:  0);
            }
            
            this._suspectedSelected = false;
        }
        public Unselectable()
        {
        
        }
    
    }

}
