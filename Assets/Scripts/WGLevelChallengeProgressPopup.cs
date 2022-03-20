using UnityEngine;
public class WGLevelChallengeProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text levelsCompleteText;
    private UnityEngine.UI.Text prizeCoinsText;
    private UnityEngine.UI.Text prizeGoldenCurrencyText;
    private UnityEngine.UI.Text winsRemainingText;
    private UnityEngine.GameObject windowGroup;
    private const float DEFAULT_DELAY_BEFORE_SHOW_POPUP_IN_SECONDS = 2.5;
    private const float DEFAULT_SHOW_POPUP_IN_SECONDS = 3;
    private const float FROM_GAME_BUTTON_SHOW_POPUP_DELAY_IN_SECONDS = 0;
    private const float FROM_GAME_BUTTON_SHOW_POPUP_DURATION_IN_SECONDS = 3.5;
    private float delayShowInSeconds;
    private float durationInSeconds;
    
    // Methods
    private void Awake()
    {
        if(this.windowGroup != null)
        {
                this.windowGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnEnable()
    {
        this.UpdateUI();
        this.delayShowInSeconds = 2.5f;
        this.durationInSeconds = 3f;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ShowPopup(delay:  2.5f, duration:  3f));
    }
    private System.Collections.IEnumerator PlayFallAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLevelChallengeProgressPopup.<PlayFallAnimation>d__13();
    }
    private System.Collections.IEnumerator ShowPopup(float delay, float duration)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .delay = delay;
        .duration = duration;
        return (System.Collections.IEnumerator)new WGLevelChallengeProgressPopup.<ShowPopup>d__14();
    }
    private System.Collections.IEnumerator PlayUnFallAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLevelChallengeProgressPopup.<PlayUnFallAnimation>d__15();
    }
    private void UpdateUI()
    {
        int val_14;
        int val_15;
        string[] val_1 = new string[5];
        val_14 = val_1.Length;
        val_1[0] = LevelChallengeHandler.CompletedLevels.ToString();
        val_14 = val_1.Length;
        val_1[1] = "/";
        val_15 = val_1.Length;
        val_1[2] = LevelChallengeHandler.RequiredLevels.ToString();
        val_15 = val_1.Length;
        val_1[3] = " ";
        val_1[4] = Localization.Localize(key:  "levels", defaultValue:  "Levels", useSingularKey:  false);
        string val_7 = +val_1;
        string val_9 = LevelChallengeHandler.Reward.ToString();
        string val_11 = LevelChallengeHandler.RewardGoldenCurrency.ToString();
        string val_13 = LevelChallengeHandler.GetWinsRemaining().ToString();
    }
    private void Update()
    {
        if(UnityEngine.Input.touchCount <= 0)
        {
                if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
                return;
        }
        
        }
        
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLevelChallengeProgressPopup()
    {
    
    }

}
