using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameHomeButton : MonoBehaviour
    {
        // Methods
        private void Awake()
        {
            UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
            val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigameHomeButton::OnButtonClick()));
        }
        private void OnButtonClick()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleHomeClicked(redirectToGameplay:  false);
        }
        public MinigameHomeButton()
        {
        
        }
    
    }

}
