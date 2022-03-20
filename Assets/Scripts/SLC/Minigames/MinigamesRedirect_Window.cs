using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesRedirect_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.RawImage main_game_advert;
        private UnityEngine.UI.Text rediret_text;
        private UnityEngine.UI.Button play_now_button;
        private UnityEngine.UI.Button close_button;
        
        // Methods
        private void Awake()
        {
            this.close_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesRedirect_Window::Close()));
            this.play_now_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesRedirect_Window::PlayNow()));
            this.main_game_advert.texture = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetTextureFromBundle(bundleName:  "minigames_framework", textureName:  "Texture_Push_Notification");
            string val_8 = System.String.Format(format:  Localization.Localize(key:  "minigames_new_main_game_challenge", defaultValue:  "You have a new {0} challenge!", useSingularKey:  false), arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetMainGameName());
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void PlayNow()
        {
            this.play_now_button.interactable = false;
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleHomeClicked(redirectToGameplay:  true);
        }
        private void Close()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleGameRestart();
            this.gameObject.SetActive(value:  false);
        }
        public MinigamesRedirect_Window()
        {
        
        }
    
    }

}
