using UnityEngine;

namespace SLC.Minigames.SnackBlock
{
    public class SnakeBlockUIController : MonoBehaviour
    {
        // Fields
        private InputEventsHandler dragInput;
        private UnityEngine.CanvasGroup mainCanvasGroup;
        private UnityEngine.Canvas mainCanvas;
        private UnityEngine.Canvas pauseCanvas;
        private UnityEngine.UI.Button quitCanvasButton;
        private UnityEngine.UI.Button resumeCanvasButton;
        private UnityEngine.GameObject FtuxUI;
        private bool showingFtux;
        
        // Properties
        public InputEventsHandler GetDragInput { get; }
        
        // Methods
        public InputEventsHandler get_GetDragInput()
        {
            return (InputEventsHandler)this.dragInput;
        }
        public void UpdateUI(bool paused)
        {
            if(this.pauseCanvas != null)
            {
                    this.pauseCanvas.enabled = paused;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void HideUIForPopup(bool showingPopup)
        {
            if(this.mainCanvasGroup != null)
            {
                    this.mainCanvasGroup.alpha = (showingPopup != true) ? 0f : 1f;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ShowFTUX()
        {
            this.FtuxUI.SetActive(value:  true);
            this.showingFtux = true;
        }
        private void Start()
        {
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_3.OnPauseClicked = new System.Action(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockUIController::OnClick_Pause());
            }
            
            this.quitCanvasButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockUIController::OnClick_Quit()));
            this.resumeCanvasButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockUIController::OnClick_Resume()));
            System.Delegate val_8 = System.Delegate.Combine(a:  this.dragInput.HandleDragAction, b:  new System.Action<System.Single>(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockUIController::DragInput_HandleDragAction(float obj)));
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_15;
            }
            
            }
            
            this.dragInput.HandleDragAction = val_8;
            return;
            label_15:
        }
        private void DragInput_HandleDragAction(float obj)
        {
            if(this.showingFtux == false)
            {
                    return;
            }
            
            this.FtuxUI.SetActive(value:  false);
            this.showingFtux = false;
            MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.OnPauseInput();
        }
        private void OnClick_Fail()
        {
            MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.HandleFailed();
        }
        private void OnClick_Win()
        {
            MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.HandleComplete();
        }
        private void OnClick_Pause()
        {
            if(this.showingFtux != true)
            {
                    MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.OnPauseInput();
            }
            
            this.pauseCanvas.enabled = true;
        }
        private void OnClick_Resume()
        {
            if(this.showingFtux != true)
            {
                    MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.OnPauseInput();
            }
            
            this.pauseCanvas.enabled = false;
        }
        private void OnClick_Quit()
        {
            this.pauseCanvas.enabled = false;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        public SnakeBlockUIController()
        {
        
        }
    
    }

}
