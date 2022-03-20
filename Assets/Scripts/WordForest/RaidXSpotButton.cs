using UnityEngine;

namespace WordForest
{
    public class RaidXSpotButton : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button button;
        private System.Action<WordForest.RaidXSpotButton> onButtonClicked;
        private int <SpotId>k__BackingField;
        
        // Properties
        public UnityEngine.UI.Button Button { get; }
        public int SpotId { get; set; }
        public bool Interactable { get; set; }
        
        // Methods
        public UnityEngine.UI.Button get_Button()
        {
            return (UnityEngine.UI.Button)this.button;
        }
        public int get_SpotId()
        {
            return (int)this.<SpotId>k__BackingField;
        }
        private void set_SpotId(int value)
        {
            this.<SpotId>k__BackingField = value;
        }
        public bool get_Interactable()
        {
            if(this.button != null)
            {
                    return (bool)this;
            }
            
            throw new NullReferenceException();
        }
        public void set_Interactable(bool value)
        {
            if(this.button != null)
            {
                    this.button.interactable = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void Awake()
        {
            this.button = this.gameObject.GetComponent<UnityEngine.UI.Button>();
            val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.RaidXSpotButton::OnClicked()));
        }
        public void Initialize(int id, System.Action<WordForest.RaidXSpotButton> onClicked)
        {
            this.<SpotId>k__BackingField = id;
            System.Delegate val_1 = System.Delegate.Combine(a:  this.onButtonClicked, b:  onClicked);
            if(val_1 != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            this.onButtonClicked = val_1;
            return;
            label_2:
        }
        private void OnClicked()
        {
            if(this.onButtonClicked == null)
            {
                    return;
            }
            
            this.onButtonClicked.Invoke(obj:  this);
        }
        public RaidXSpotButton()
        {
        
        }
    
    }

}
