using UnityEngine;
public class HintManiaEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject infoPopupParent;
    private UnityEngine.GameObject collectPopupParent;
    private UnityEngine.GameObject coinValueParent;
    private UnityEngine.GameObject appleValueParent;
    private UnityEngine.UI.Text eventDescirption;
    private UnityEngine.UI.Text eventTimerText;
    private UnityEngine.UI.Text coinValueText;
    private UnityEngine.UI.Text appleValueText;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Text playButtonText;
    private GridCoinCollectAnimationInstantiator coinCollector;
    private GoldenCurrencyCollectAnimationInstantiator goldenCollector;
    
    // Methods
    private void OnEnable()
    {
        this.infoPopupParent.SetActive(value:  false);
        this.collectPopupParent.SetActive(value:  false);
        if((HintManiaEventHandler.HINT_MANIA_ID & 1) != 0)
        {
                this.InitCollect();
            return;
        }
        
        this.InitInfo();
    }
    private void InitInfo()
    {
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintManiaEventPopup::PlayButtonPressed()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintManiaEventPopup::PlayButtonPressed()));
        GameBehavior val_4 = App.getBehavior;
        this.playButton.gameObject.SetActive(value:  ((val_4.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        GameBehavior val_7 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_7.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintManiaEventPopup::Close()));
        string val_11 = System.String.Format(format:  Localization.Localize(key:  "hm_events_popup", defaultValue:  "Every Hint has a {0}% chance of granting a reward.  Use more Hints to win more prizes!", useSingularKey:  false), arg0:  HintManiaEventHandler.HINT_MANIA_ID + 36);
        string val_14 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        this.infoPopupParent.SetActive(value:  true);
        FrameSkipper val_16 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_16.updateLogic = new System.Action(object:  this, method:  System.Void HintManiaEventPopup::UpdateTimerText());
    }
    private void InitCollect()
    {
        this.collectPopupParent.SetActive(value:  true);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void HintManiaEventPopup::CollectButtonPressed()));
    }
    private void PlayButtonPressed()
    {
        this.UpdateFeaturePoint();
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        this.Close();
    }
    private void UpdateTimerText()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = HintManiaEventHandler.HINT_MANIA_ID.m_stringLength + 40}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days;
        val_3[1] = val_2._ticks.Hours;
        val_3[2] = val_2._ticks.Minutes;
        val_3[3] = val_2._ticks.Seconds;
        string val_8 = System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_3);
        if(val_2._ticks.TotalSeconds >= 0)
        {
                return;
        }
        
        this.Close();
    }
    private void CollectButtonPressed()
    {
        object val_17;
        GridCoinCollectAnimationInstantiator val_18;
        int val_19;
        val_17 = this;
        val_18 = 1152921504924045312;
        this.collectButton.interactable = false;
        if((HintManiaEventHandler.HINT_MANIA_ID + 32) == 2)
        {
            goto label_4;
        }
        
        if((HintManiaEventHandler.HINT_MANIA_ID + 32) != 1)
        {
            goto label_5;
        }
        
        Player val_1 = App.Player;
        this.coinValueParent.SetActive(value:  true);
        HintManiaEventHandler.HINT_MANIA_ID.CollectReward();
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = 1152921504924045312}, d2:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21});
        string val_4 = val_3.flags.ToString();
        val_18 = this.coinCollector;
        this.coinCollector.OnCompleteCallback = new System.Action(object:  this, method:  System.Void HintManiaEventPopup::Close());
        val_17 = this.coinCollector;
        Player val_6 = App.Player;
        val_17.Play(fromValue:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, toValue:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_4:
        Player val_7 = App.Player;
        decimal val_8 = System.Decimal.op_Implicit(value:  val_7._stars);
        val_19 = val_8.lo;
        this.appleValueParent.SetActive(value:  true);
        HintManiaEventHandler.HINT_MANIA_ID.CollectReward();
        val_18 = this.goldenCollector;
        mem2[0] = new System.Action(object:  this, method:  System.Void HintManiaEventPopup::Close());
        Player val_10 = App.Player;
        decimal val_11 = System.Decimal.op_Implicit(value:  val_10._stars);
        decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_19, mid = val_8.mid});
        string val_13 = val_12.flags.ToString();
        val_17 = this.goldenCollector;
        Player val_15 = App.Player;
        decimal val_16 = System.Decimal.op_Implicit(value:  val_15._stars);
        val_17.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_19, mid = val_8.mid}), toValue:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_5:
        HintManiaEventHandler.HINT_MANIA_ID.CollectReward();
        this.Close();
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
            val_5 = 71;
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
            val_5 = 72;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 72;
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public HintManiaEventPopup()
    {
    
    }

}
