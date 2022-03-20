using UnityEngine;
public class TRVBigQuizEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text descText;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Text contineButtonText;
    private UnityEngine.UI.Image fillBar;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button continueButton;
    private GemsCollectAnimationInstantiator gemAnim;
    
    // Methods
    private void OnEnable()
    {
        this.SetupUI();
    }
    private void SetupUI()
    {
        object val_25;
        var val_26;
        UnityEngine.UI.Text val_27;
        string val_29;
        string val_30;
        var val_31;
        string val_32;
        val_25 = this;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVBigQuizEventPopup::Close()));
        string val_2 = TRVBigQuizEvent.EVENT_TRACKING_ID + 48.ToString();
        UnityEngine.GameObject val_3 = this.closeButton.gameObject;
        if((TRVBigQuizEvent.EVENT_TRACKING_ID & 1) == 0)
        {
            goto label_8;
        }
        
        val_3.SetActive(value:  false);
        val_26 = null;
        val_26 = null;
        if(App.game != 17)
        {
            goto label_14;
        }
        
        val_27 = this.rewardText;
        val_29 = "+{0}";
        goto label_15;
        label_8:
        val_3.SetActive(value:  true);
        int val_4 = TRVBigQuizEvent.EVENT_TRACKING_ID.eventProgress;
        val_30 = Localization.Localize(key:  "big_quiz_popup", defaultValue:  "Complete {0} levels by {1} at {2} to get a huge reward!", useSingularKey:  false);
        System.DateTime val_7 = TRVBigQuizEvent.EVENT_TRACKING_ID.m_stringLength + 40.ToLocalTime();
        System.DateTime val_10 = TRVBigQuizEvent.EVENT_TRACKING_ID.m_stringLength + 40.ToLocalTime();
        string val_12 = System.String.Format(format:  val_30, arg0:  TRVBigQuizEvent.EVENT_TRACKING_ID + 44, arg1:  val_7.dateData.DayOfWeek, arg2:  val_10.dateData.ToString(format:  "hh:mm tt"));
        if(val_4 == 0)
        {
            goto label_19;
        }
        
        float val_25 = (float)TRVBigQuizEvent.EVENT_TRACKING_ID + 44;
        val_25 = (float)val_4 / val_25;
        if(this.fillBar != null)
        {
            goto label_20;
        }
        
        label_14:
        val_31 = null;
        val_31 = null;
        if(App.game != 19)
        {
            goto label_27;
        }
        
        val_27 = this.rewardText;
        val_29 = "{0}";
        label_15:
        string val_13 = System.String.Format(format:  val_29, arg0:  TRVBigQuizEvent.EVENT_TRACKING_ID + 48);
        label_27:
        this.fillBar.fillAmount = 1f;
        string val_14 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        val_30 = 1152921504619999232;
        string val_15 = System.String.Format(format:  "{0}/{0}", arg0:  TRVBigQuizEvent.EVENT_TRACKING_ID + 44);
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVBigQuizEventPopup::Collect()));
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVBigQuizEventPopup::Close());
        this.gemAnim.Create();
        val_32 = Localization.Localize(key:  "big_quiz_reward", defaultValue:  "Congratulations! You\'ve completed {0} levels!", useSingularKey:  false);
        string val_21 = System.String.Format(format:  val_32, arg0:  TRVBigQuizEvent.EVENT_TRACKING_ID + 44)(System.String.Format(format:  val_32, arg0:  TRVBigQuizEvent.EVENT_TRACKING_ID + 44)) + "\n" + Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false)(Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false));
        return;
        label_19:
        label_20:
        this.fillBar.fillAmount = 0f;
        string val_22 = System.String.Format(format:  "{0}/{1}", arg0:  val_4, arg1:  TRVBigQuizEvent.EVENT_TRACKING_ID + 44);
        UnityEngine.Events.UnityAction val_23 = null;
        val_32 = val_23;
        val_23 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVBigQuizEventPopup::Close());
        this.continueButton.m_OnClick.AddListener(call:  val_23);
        val_25 = this.contineButtonText;
        string val_24 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
    }
    private void Collect()
    {
        this.continueButton.interactable = false;
        Player val_1 = App.Player;
        TRVBigQuizEvent.EVENT_TRACKING_ID.OnCollect();
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2._gems);
        this.gemAnim.Play(fromValue:  val_1._gems, toValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventHandlerProgress");
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if(TRVBigQuizEvent.EVENT_TRACKING_ID == null)
        {
                return;
        }
        
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    public TRVBigQuizEventPopup()
    {
    
    }

}
