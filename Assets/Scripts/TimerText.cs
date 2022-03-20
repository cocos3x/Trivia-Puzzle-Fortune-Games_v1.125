using UnityEngine;
public class TimerText : MonoBehaviour
{
    // Fields
    public bool countUp;
    public bool runOnStart;
    public int timeValue;
    public bool showHour;
    public bool showHourZeroes;
    public bool showMinute;
    public bool showSecond;
    public System.Action onCountDownComplete;
    private bool isRunning;
    
    // Methods
    private void Start()
    {
        if(this.runOnStart == false)
        {
                return;
        }
        
        this.Run();
    }
    public void Run()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.isRunning != false)
        {
                return;
        }
        
        this.isRunning = true;
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.UpdateClockText());
    }
    private System.Collections.IEnumerator UpdateClockText()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TimerText.<UpdateClockText>d__11();
    }
    public void SetTime(int value)
    {
        this.timeValue = value & (~(value >> 31));
        goto typeof(TimerText).__il2cppRuntimeField_170;
    }
    public void AddTime(int value)
    {
        int val_1 = this.timeValue;
        val_1 = val_1 + value;
        this.timeValue = val_1;
        goto typeof(TimerText).__il2cppRuntimeField_170;
    }
    protected virtual void UpdateText()
    {
        object val_14;
        object val_16;
        System.TimeSpan val_1 = System.TimeSpan.FromSeconds(value:  (double)this.timeValue);
        if(this.showHour == false)
        {
            goto label_12;
        }
        
        if(this.showHourZeroes != true)
        {
                if(val_1._ticks.Hours < 1)
        {
            goto label_7;
        }
        
        }
        
        if((this.showMinute == false) || (this.showSecond == false))
        {
            goto label_7;
        }
        
        int val_4 = val_1._ticks.Minutes;
        val_14 = val_4;
        string val_6 = System.String.Format(format:  "{0:D2}:{1:D2}:{2:D2}", arg0:  val_1._ticks.Hours, arg1:  val_4, arg2:  val_1._ticks.Seconds);
        goto label_8;
        label_7:
        if(this.showHour == false)
        {
            goto label_12;
        }
        
        if(this.showHourZeroes != true)
        {
                if(val_1._ticks.Hours < 1)
        {
            goto label_12;
        }
        
        }
        
        if(this.showMinute == false)
        {
            goto label_12;
        }
        
        val_14 = 1152921504619999232;
        val_16 = val_1._ticks.Hours;
        int val_9 = val_1._ticks.Minutes;
        goto label_13;
        label_12:
        int val_10 = val_1._ticks.Minutes;
        val_14 = 1152921504619999232;
        val_16 = val_10;
        label_13:
        label_8:
        CExtension.SetText(obj:  this.gameObject, value:  System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  val_10, arg1:  val_1._ticks.Seconds));
    }
    public void Stop()
    {
        this.StopAllCoroutines();
        this.isRunning = false;
    }
    public TimerText()
    {
        this.countUp = true;
        this.showHourZeroes = true;
        this.showMinute = true;
        this.showSecond = true;
    }

}
