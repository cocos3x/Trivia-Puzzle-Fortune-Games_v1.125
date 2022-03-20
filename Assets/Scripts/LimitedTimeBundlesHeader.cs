using UnityEngine;
public class LimitedTimeBundlesHeader : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text text_description;
    private UnityEngine.UI.Text text_time_remaining;
    private bool showTimer;
    private System.DateTime offerEndTime;
    private FrameSkipper _FrameSkipper;
    
    // Properties
    private FrameSkipper FrameSkipper { get; }
    
    // Methods
    private FrameSkipper get_FrameSkipper()
    {
        FrameSkipper val_3;
        if(this._FrameSkipper == 0)
        {
                this._FrameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this);
            return val_3;
        }
        
        val_3 = this._FrameSkipper;
        return val_3;
    }
    private void Awake()
    {
        if(this.showTimer == false)
        {
                return;
        }
        
        FrameSkipper val_1 = this.FrameSkipper;
        val_1.updateLogic = new System.Action(object:  this, method:  System.Void LimitedTimeBundlesHeader::UpdateLogic());
    }
    public void Setup(string freeAmount, System.DateTime endTime)
    {
        object val_15;
        var val_16;
        val_15 = freeAmount;
        val_16 = this;
        if(this.text_description != 0)
        {
                string val_3 = System.String.Format(format:  Localization.Localize(key:  "get_x_pct_more_free_upper", defaultValue:  "GET {0}% MORE FREE!", useSingularKey:  false), arg0:  val_15);
        }
        
        this.offerEndTime = endTime;
        if(this.text_time_remaining == 0)
        {
                return;
        }
        
        System.DateTime val_5 = DateTimeCheat.Now;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.offerEndTime}, d2:  new System.DateTime() {dateData = val_5.dateData});
        string val_7 = val_6._ticks.FormatTime(timeSpan:  new System.TimeSpan() {_ticks = val_6._ticks});
        val_16 = ???;
        val_15 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UpdateLogic()
    {
        UnityEngine.UI.Text val_10 = this.text_time_remaining;
        if(val_10 == 0)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.Now;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.offerEndTime}, d2:  new System.DateTime() {dateData = val_2.dateData});
        string val_4 = val_3._ticks.FormatTime(timeSpan:  new System.TimeSpan() {_ticks = val_3._ticks});
        val_10 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private string FormatTime(System.TimeSpan timeSpan)
    {
        int val_6 = 24;
        val_6 = timeSpan._ticks.Hours + (timeSpan._ticks.Days * val_6);
        return (string)System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_6, arg1:  timeSpan._ticks.Minutes, arg2:  timeSpan._ticks.Seconds);
    }
    public LimitedTimeBundlesHeader()
    {
        this.showTimer = true;
    }

}
