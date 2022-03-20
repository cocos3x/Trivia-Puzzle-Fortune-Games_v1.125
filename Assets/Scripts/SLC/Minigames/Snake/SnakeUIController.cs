using UnityEngine;

namespace SLC.Minigames.Snake
{
    public class SnakeUIController : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text pauseText;
        private UnityEngine.UI.Text levelText;
        private UnityEngine.UI.Text objText;
        private UnityEngine.UI.Button failButton;
        private UnityEngine.UI.Button winButton;
        private UnityEngine.UI.Button objButton;
        private UnityEngine.UI.Button pauseButton;
        
        // Methods
        public void UpdateUI(bool paused, int currLevel, int currObjs, int reqObjs)
        {
            var val_1 = (paused != true) ? "PAUSED" : "";
            string val_2 = System.String.Format(format:  "Lvl {0}", arg0:  currLevel);
            string val_3 = System.String.Format(format:  "{0}/{1}", arg0:  currObjs, arg1:  reqObjs);
        }
        private void Start()
        {
            this.failButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeUIController::OnClick_Fail()));
            this.winButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeUIController::OnClick_Win()));
            this.objButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeUIController::OnClick_Obj()));
            this.pauseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeUIController::OnClick_Pause()));
        }
        private void OnClick_Fail()
        {
            MonoSingleton<SLC.Minigames.Snake.SnakeGameManager>.Instance.HandleFailed();
        }
        private void OnClick_Win()
        {
            val_1._snakeObjectivesCount = val_1._snakeObjectivesReq;
            MonoSingleton<SLC.Minigames.Snake.SnakeGameManager>.Instance.HandleCollectedObjective();
        }
        private void OnClick_Obj()
        {
            MonoSingleton<SLC.Minigames.Snake.SnakeGameManager>.Instance.HandleCollectedObjective();
        }
        private void OnClick_Pause()
        {
            MonoSingleton<SLC.Minigames.Snake.SnakeGameManager>.Instance.OnPauseInput();
        }
        public SnakeUIController()
        {
        
        }
    
    }

}
