using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class TwistyUIController : MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>
    {
        // Fields
        private UnityEngine.CanvasGroup MainCanvas;
        private UnityEngine.GameObject GameScreen;
        private UnityEngine.GameObject PauseScreen;
        private UnityEngine.UI.Text InfoText;
        private UnityEngine.UI.Button TapArea;
        private UnityEngine.GameObject CheckMark;
        private UnityEngine.GameObject XMark;
        private SLC.Minigames.MinigameLivesDisplay HeartsDisplay;
        private UnityEngine.UI.Button ButtonContinue;
        private UnityEngine.UI.Button ButtonQuit;
        private UnityEngine.UI.Button ButtonResume;
        
        // Methods
        public override void InitMonoSingleton()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.TogglePopupWindow, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::TogglePopupWindow(bool showing)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_1.TogglePopupWindow = val_3;
            SLC.Minigames.TwistyArrow.TwistyGameManager val_4 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnPlayingStateChanged, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnPlayingStateChanged(bool isPlaying)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_4.OnPlayingStateChanged = val_6;
            this.TapArea.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnTapped()));
            SLC.Minigames.TwistyArrow.TwistyGameManager val_8 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            if(val_8.inMinigameFramework != true)
            {
                    this.ButtonContinue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnContinueButtonClicked()));
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_12 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                1152921504893161472 = 1152921504614301696;
                System.Delegate val_14 = System.Delegate.Combine(a:  val_12.OnPauseClicked, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnPauseClicked()));
                if(val_14 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
                val_12.OnPauseClicked = val_14;
                SLC.Minigames.MinigameManager val_15 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                System.Delegate val_17 = System.Delegate.Combine(a:  val_15.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnRestartClicked()));
                if(val_17 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
                val_15.OnRestartMinigame = val_17;
            }
            
            this.ButtonQuit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnQuitButtonClicked()));
            this.ButtonResume.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyUIController::OnResumeButtonClicked()));
            return;
            label_29:
        }
        public void SetActiveInfoText(bool active)
        {
            this.InfoText.gameObject.SetActive(value:  active);
        }
        public void UpdateUIHearts(int currentHearts)
        {
            this.ButtonContinue.gameObject.SetActive(value:  false);
            this.HeartsDisplay.UpdateLivesDisplay(currentHearts:  currentHearts);
        }
        public void ShowCheck()
        {
            if(this.CheckMark.activeSelf == true)
            {
                    return;
            }
            
            if(this.XMark.activeSelf != false)
            {
                    return;
            }
            
            this.CheckMark.SetActive(value:  true);
            this.Invoke(methodName:  "HideFeedbacks", time:  0.5f);
        }
        public void ShowX()
        {
            if(this.CheckMark.activeSelf == true)
            {
                    return;
            }
            
            if(this.XMark.activeSelf != false)
            {
                    return;
            }
            
            this.XMark.SetActive(value:  true);
            this.Invoke(methodName:  "HideFeedbacks", time:  0.5f);
        }
        public void HideFeedbacks()
        {
            this.XMark.SetActive(value:  false);
            this.CheckMark.SetActive(value:  false);
        }
        private void OnTapped()
        {
            SLC.Minigames.TwistyArrow.TwistyGameManager val_1 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            if(val_1._IsPlaying == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyArrowLogic>.Instance.FireArrow();
            if(this.InfoText.gameObject.activeSelf == false)
            {
                    return;
            }
            
            this.SetActiveInfoText(active:  false);
        }
        private void OnPauseClicked()
        {
            this.GameScreen.SetActive(value:  false);
            this.PauseScreen.SetActive(value:  true);
        }
        private void OnQuitButtonClicked()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void OnRestartClicked()
        {
            this.PauseScreen.SetActive(value:  false);
            this.GameScreen.SetActive(value:  true);
        }
        private void OnResumeButtonClicked()
        {
            this.PauseScreen.SetActive(value:  false);
            this.GameScreen.SetActive(value:  true);
        }
        private void OnContinueButtonClicked()
        {
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance.StartNewLevel();
        }
        private void OnPlayingStateChanged(bool isPlaying)
        {
            SLC.Minigames.TwistyArrow.TwistyGameManager val_1 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            if(val_1.inMinigameFramework == true)
            {
                    return;
            }
            
            if(isPlaying == true)
            {
                    return;
            }
            
            this.ButtonContinue.gameObject.SetActive(value:  true);
        }
        private void TogglePopupWindow(bool showing)
        {
            if(this.MainCanvas != null)
            {
                    this.MainCanvas.alpha = (showing != true) ? 0f : 1f;
                return;
            }
            
            throw new NullReferenceException();
        }
        public TwistyUIController()
        {
        
        }
    
    }

}
