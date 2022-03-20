using UnityEngine;
public class WordDropUIController : MonoSingleton<WordDropUIController>
{
    // Fields
    private UnityEngine.Canvas canvas;
    private UnityEngine.Canvas pauseCanvas;
    private UnityEngine.GameObject blur;
    private BlurCanvas blurCanvas;
    private UnityEngine.UI.Button pauseButton;
    private UnityEngine.UI.Button resumeButton;
    private UnityEngine.UI.Button quitButton;
    private SLC.Minigames.MinigameLivesDisplay minigameLivesDisplay;
    private UnityEngine.UI.Text scoopsDisplay;
    private InputEventsHandler inputEventsHandler;
    
    // Properties
    public InputEventsHandler GetInputEventsHandler { get; }
    
    // Methods
    public InputEventsHandler get_GetInputEventsHandler()
    {
        return (InputEventsHandler)this.inputEventsHandler;
    }
    private void Start()
    {
        this.pauseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordDropUIController::OnClick_Pause()));
        this.resumeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordDropUIController::OnClick_Resume()));
        this.quitButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordDropUIController::OnClick_Quit()));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void UpdateLivesDisplay(int updatedLives)
    {
        MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        this.minigameLivesDisplay.UpdateLivesDisplay(currentHearts:  updatedLives);
    }
    public void UpdateScoopsDisplay(int updatedScoops)
    {
        string val_2 = "Scoops: "("Scoops: ") + updatedScoops.ToString();
    }
    private void OnClick_Pause()
    {
        this.blur.SetActive(value:  true);
        this.blurCanvas.DoBlur();
        this.pauseCanvas.enabled = true;
        WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
        bool val_2 = val_1.isPaused;
        val_2 = val_2 ^ 1;
        val_1.isPaused = val_2;
    }
    private void OnClick_Resume()
    {
        this.blur.SetActive(value:  false);
        this.blurCanvas.StopBlur();
        this.pauseCanvas.enabled = false;
        WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
        bool val_2 = val_1.isPaused;
        val_2 = val_2 ^ 1;
        val_1.isPaused = val_2;
    }
    private void OnClick_Quit()
    {
        MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleHomeClicked(redirectToGameplay:  false);
    }
    public void ToggleUI(bool show)
    {
        if(this.canvas != null)
        {
                this.canvas.enabled = show;
            return;
        }
        
        throw new NullReferenceException();
    }
    public WordDropUIController()
    {
    
    }

}
