using UnityEngine;
public class SuperStreakPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject infoPopupParent;
    private UnityEngine.UI.Text descriptionText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.GameObject coinInfoBox;
    private UnityEngine.GameObject wheelInfoBox;
    private UnityEngine.GameObject spinInfoBox;
    private UnityEngine.UI.Text coinInfoText;
    private UnityEngine.GameObject timerParent;
    private UnityEngine.GameObject collectPopupParent;
    private UnityEngine.GameObject coinRewardBox;
    private UnityEngine.GameObject wheelRewardBox;
    private UnityEngine.GameObject spinRewardBox;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Text coinText;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private UnityEngine.UI.Text playButtonText;
    
    // Methods
    private void OnEnable()
    {
        if((SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE & 1) != 0)
        {
                this.infoPopupParent.SetActive(value:  false);
            this.ShowCanCollectPopup();
        }
        else
        {
                this.collectPopupParent.SetActive(value:  false);
            this.ShowInfoPopup();
        }
        
        this.UpdateFeaturePoint();
    }
    private void UpdateFeaturePoint()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 64;
        }
        else
        {
                GameBehavior val_2 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
            val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 65;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 65;
    }
    private void ShowInfoPopup()
    {
        this.coinInfoBox.SetActive(value:  false);
        this.spinInfoBox.SetActive(value:  false);
        this.wheelInfoBox.SetActive(value:  false);
        this.timerParent.SetActive(value:  true);
        this.infoPopupParent.gameObject.SetActive(value:  true);
        GameEventRewardType val_2 = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetRewardType();
        if(val_2 == 4)
        {
            goto label_9;
        }
        
        if(val_2 == 3)
        {
            goto label_10;
        }
        
        if(val_2 != 1)
        {
            goto label_21;
        }
        
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "ssw_event_popup_coins", defaultValue:  "During Super Streak Levels, get streaks of {0} or more correct answers in a row. Complete {1} Super Streak levels to earn a big reward!", useSingularKey:  false), arg0:  SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 64, arg1:  SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 48);
        this.coinInfoBox.SetActive(value:  true);
        string val_6 = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetCoinRewardForTier().ToString();
        goto label_21;
        label_10:
        object[] val_8 = new object[4];
        val_8[0] = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 64;
        val_8[1] = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 48;
        val_8[2] = App.getGameEcon.maxBonusGameWheelAwardCoins;
        val_8[3] = App.getGameEcon.maxBonusGameWheelAwardGoldenCurrency;
        string val_13 = System.String.Format(format:  Localization.Localize(key:  "ssw_event_popup_bonus_wheel", defaultValue:  "During Super Streak Levels, get streaks of {0} or more correct answers in a row. Complete {1} Super Streak levels for a chance to earn up to {2} coins and {3} golden apples on the Bonus Wheel!", useSingularKey:  false), args:  val_8);
        if(this.wheelInfoBox != null)
        {
            goto label_44;
        }
        
        label_9:
        string val_15 = System.String.Format(format:  Localization.Localize(key:  "ssw_event_popup_bonus_spin", defaultValue:  "During Super Streak Levels, get streaks of {0} or more correct answers in a row. Complete {1} Super Streak levels for a chance to earn up to 900 coins or golden apples on the Bonus Spinner!", useSingularKey:  false), arg0:  SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 64, arg1:  SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE + 48);
        label_44:
        this.spinInfoBox.SetActive(value:  true);
        label_21:
        FrameSkipper val_17 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_17.updateLogic = new System.Action(object:  this, method:  System.Void SuperStreakPopup::UpdateTimerText());
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SuperStreakPopup::OnPlayButtonPressed()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SuperStreakPopup::OnPlayButtonPressed()));
        string val_23 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        GameBehavior val_25 = App.getBehavior;
        this.playButton.gameObject.SetActive(value:  ((val_25.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        GameBehavior val_28 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_28.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
    }
    private void ShowCanCollectPopup()
    {
        this.collectPopupParent.gameObject.SetActive(value:  true);
        this.timerParent.SetActive(value:  false);
        this.coinRewardBox.SetActive(value:  false);
        this.wheelRewardBox.SetActive(value:  false);
        this.spinRewardBox.SetActive(value:  false);
        GameEventRewardType val_2 = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetRewardType();
        if(val_2 == 4)
        {
            goto label_9;
        }
        
        if(val_2 == 3)
        {
            goto label_10;
        }
        
        if(val_2 != 1)
        {
            goto label_16;
        }
        
        this.coinRewardBox.SetActive(value:  true);
        string val_4 = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetCoinRewardForTier().ToString();
        goto label_16;
        label_9:
        if(this.spinRewardBox != null)
        {
            goto label_17;
        }
        
        label_10:
        label_17:
        this.wheelRewardBox.SetActive(value:  true);
        label_16:
        string val_5 = Localization.Localize(key:  "super_streak_completed_exc", defaultValue:  "Super Streak Completed!", useSingularKey:  false);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SuperStreakPopup::OnClickCollect()));
    }
    private void UpdateTimerText()
    {
        UnityEngine.UI.Text val_10;
        ulong val_11;
        val_10 = this;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        val_11 = val_1.dateData;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.m_stringLength + 40}, d2:  new System.DateTime() {dateData = val_11});
        if(val_2._ticks.TotalSeconds < 0)
        {
                this.Close();
            return;
        }
        
        val_10 = this.timerText;
        object[] val_4 = new object[4];
        val_4[0] = val_2._ticks.Days;
        val_4[1] = val_2._ticks.Hours;
        val_4[2] = val_2._ticks.Minutes;
        val_11 = val_2._ticks.Seconds;
        val_4[3] = val_11;
        string val_9 = System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_4);
    }
    private void OnClickCollect()
    {
        if(SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetRewardType() == 1)
        {
                if(SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.GetCoinRewardForTier() >= 1)
        {
                this.collectButton.interactable = false;
            Player val_3 = App.Player;
            SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.CollectReward();
            this.coinAnim.gameObject.SetActive(value:  true);
            this.coinAnim.OnCompleteCallback = new System.Action(object:  this, method:  public System.Void SuperStreakPopup::Close());
            Player val_6 = App.Player;
            this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = 41963520}, toValue:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        }
        
        SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.CollectReward();
        this.Close();
    }
    private void OnPlayButtonPressed()
    {
        this.UpdateFeaturePoint();
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        this.Close();
    }
    public void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public SuperStreakPopup()
    {
    
    }

}
