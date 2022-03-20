using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_OnClickButton : MonoBehaviour
    {
        // Methods
        private void Start()
        {
            if((this.gameObject.GetComponent<UnityEngine.UI.Button>()) == 0)
            {
                    UnityEngine.Debug.LogError(message:  "No Button Component Found On: "("No Button Component Found On: ") + this.gameObject.name);
                return;
            }
            
            val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(SLC.Social.Leagues.LeaguesUI_OnClickButton).__il2cppRuntimeField_178));
        }
        protected virtual void OnClickAction()
        {
            UnityEngine.Debug.LogError(message:  "No Override");
        }
        public LeaguesUI_OnClickButton()
        {
        
        }
    
    }

}
