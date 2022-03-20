using UnityEngine;
public class WGLevelChallengePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text mainText;
    private UnityEngine.UI.Text coinsRewardText;
    private UnityEngine.UI.Text goldenCurrencyRewardText;
    private UnityEngine.UI.Text winsRemainingText;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.Button button_play;
    private UnityEngine.UI.Button buttonContinue;
    private UnityEngine.UI.Text playButtonText;
    private int players;
    private int levels;
    private int reward;
    private int winsRemaining;
    
    // Methods
    private void Awake()
    {
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLevelChallengePopup::OnClick_Close()));
        this.button_play.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLevelChallengePopup::OnClick_Play()));
        this.buttonContinue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLevelChallengePopup::OnClick_Play()));
    }
    private void OnEnable()
    {
        this.UpdateUI();
    }
    private void UpdateUI()
    {
        this.players = LevelChallengeHandler.NumWinners;
        mem[1152921517902968476] = LevelChallengeHandler.RequiredLevels;
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "first_#_players_to_complete_#_levels_win", defaultValue:  "First {0} players to complete {1} levels win!", useSingularKey:  false), arg0:  this.players.ToString(), arg1:  mem[1152921517902968476].ToString());
        string val_8 = LevelChallengeHandler.Reward.ToString();
        string val_10 = LevelChallengeHandler.RewardGoldenCurrency.ToString();
        string val_12 = LevelChallengeHandler.GetWinsRemaining().ToString();
        GameBehavior val_14 = App.getBehavior;
        this.button_play.gameObject.SetActive(value:  ((val_14.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        GameBehavior val_17 = App.getBehavior;
        this.buttonContinue.gameObject.SetActive(value:  ((val_17.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        string val_21 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
    }
    private void OnClick_Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto typeof(System.Int32).__il2cppRuntimeField_540;
    }
    private void OnClick_Play()
    {
        if(LevelChallengeHandler.InGame != true)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public WGLevelChallengePopup()
    {
    
    }

}
