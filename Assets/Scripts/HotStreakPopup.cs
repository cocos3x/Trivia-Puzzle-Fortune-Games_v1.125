using UnityEngine;
public class HotStreakPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject promoPopupParent;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text promoRewardText;
    private UnityEngine.UI.Text playButtonText;
    private UnityEngine.GameObject rewardPopupParent;
    private UnityEngine.UI.Text coinText;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinAnimator;
    
    // Methods
    private void OnEnable()
    {
        this.promoPopupParent.SetActive(value:  false);
        this.rewardPopupParent.SetActive(value:  false);
        if((HotStreakEventHandler.HOT_STREAK_ID & 1) != 0)
        {
                this.InitEventCollectPopup();
        }
        else
        {
                this.InitEventInfoPopup();
        }
        
        this.UpdateFeaturePoint();
    }
    private void InitEventInfoPopup()
    {
        this.promoPopupParent.SetActive(value:  true);
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void HotStreakPopup::UpdateTimerText());
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HotStreakPopup::OnPlayButtonPressed()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HotStreakPopup::OnPlayButtonPressed()));
        string val_8 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        GameBehavior val_10 = App.getBehavior;
        this.playButton.gameObject.SetActive(value:  ((val_10.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        GameBehavior val_13 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_13.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        string val_15 = System.String.Format(format:  "{0}", arg0:  HotStreakEventHandler.HOT_STREAK_ID + 104);
    }
    private void InitEventCollectPopup()
    {
        this.rewardPopupParent.SetActive(value:  true);
        string val_1 = HotStreakEventHandler.HOT_STREAK_ID + 104.ToString();
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HotStreakPopup::CollectButtonClick()));
        this.coinAnimator.OnCompleteCallback = new System.Action(object:  this, method:  public System.Void HotStreakPopup::Close());
    }
    private void CollectButtonClick()
    {
        this.coinAnimator.gameObject.SetActive(value:  true);
        this.collectButton.interactable = false;
        Player val_2 = App.Player;
        HotStreakEventHandler.HOT_STREAK_ID.CollectReward();
        Player val_3 = App.Player;
        this.coinAnimator.Play(fromValue:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = 41967616}, toValue:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
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
            val_5 = 66;
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
            val_5 = 67;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 67;
    }
    private void UpdateTimerText()
    {
        UnityEngine.UI.Text val_10;
        ulong val_11;
        val_10 = this;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        val_11 = val_1.dateData;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = HotStreakEventHandler.HOT_STREAK_ID.m_stringLength + 40}, d2:  new System.DateTime() {dateData = val_11});
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
    public HotStreakPopup()
    {
    
    }

}
