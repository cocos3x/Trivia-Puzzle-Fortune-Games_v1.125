using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesUIController : MonoSingleton<SLC.Minigames.MinigamesUIController>
    {
        // Fields
        private const string pref_seen_game_over_count = "mini_gmovr_ct";
        private int _GameOverSeenCt;
        public System.Action<bool> ToggleExclusivePopup;
        
        // Properties
        private int GameOverSeenCt { get; set; }
        
        // Methods
        private int get_GameOverSeenCt()
        {
            int val_2 = this._GameOverSeenCt;
            if(val_2 != 1)
            {
                    return val_1;
            }
            
            val_2 = "mini_gmovr_ct";
            int val_1 = UnityEngine.PlayerPrefs.GetInt(key:  val_2, defaultValue:  0);
            this._GameOverSeenCt = val_1;
            return val_1;
        }
        private void set_GameOverSeenCt(int value)
        {
            this._GameOverSeenCt = value;
        }
        public override void InitMonoSingleton()
        {
            SLC.Minigames.MinigamesWindowManager val_1 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance;
            AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.MinigamesUIController::OnMonolithWindowOpened(bool exclusive)));
            SLC.Minigames.MinigamesWindowManager val_3 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance;
            AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesUIController::OnMonolithWindowClosed()));
        }
        private void OnMonolithWindowClosed()
        {
            if(this.ToggleExclusivePopup == null)
            {
                    return;
            }
            
            this.ToggleExclusivePopup.Invoke(obj:  false);
        }
        private void OnMonolithWindowOpened(bool exclusive)
        {
            if(exclusive == false)
            {
                    return;
            }
            
            if(this.ToggleExclusivePopup == null)
            {
                    return;
            }
            
            this.ToggleExclusivePopup.Invoke(obj:  true);
        }
        public void ShowCheckpoint()
        {
            SLC.Minigames.MinigamesWindowManager val_2 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<SLC.Minigames.MinigamesCheckpoint_Window>(showNext:  false);
        }
        public void ShowRankup()
        {
            SLC.Minigames.MinigamesWindowManager val_2 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<SLC.Minigames.MinigamesRankup_Window>(showNext:  false);
        }
        public void ShowContinue()
        {
            SLC.Minigames.MinigamesWindowManager val_2 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<SLC.Minigames.MinigamesContinue_Window>(showNext:  false);
        }
        public void ShowGameOver()
        {
            this._GameOverSeenCt = this.GameOverSeenCt + 1;
            SLC.Minigames.MinigamesWindowManager val_4 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<SLC.Minigames.MinigamesGameOver_Window>(showNext:  false);
        }
        public bool ShowRedirect()
        {
            return false;
        }
        public void ShowMessage(string titleTxt, string messageTxt, bool[] shownButtons, string[] buttonTexts, bool showClose = True, System.Func<bool>[] buttonCallbacks)
        {
            var val_3 = null;
            showClose = showClose;
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  titleTxt, messageTxt:  messageTxt, shownButtons:  shownButtons, buttonTexts:  buttonTexts, showClose:  showClose, buttonCallbacks:  buttonCallbacks, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public MinigamesUIController()
        {
            this._GameOverSeenCt = 0;
        }
    
    }

}
