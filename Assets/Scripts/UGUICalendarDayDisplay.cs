using UnityEngine;
public class UGUICalendarDayDisplay : MyButton
{
    // Fields
    protected UnityEngine.UI.Text dayText;
    protected UnityEngine.GameObject bg_past;
    protected UnityEngine.GameObject bg_present;
    protected UnityEngine.GameObject bg_future;
    public System.Action<UGUICalendarDayDisplay> OnClicked;
    public bool IsPlaceholder;
    public int Day;
    public int Month;
    public int Year;
    
    // Methods
    public override void OnButtonClick()
    {
        if(this.IsPlaceholder != false)
        {
                return;
        }
        
        this.OnButtonClick();
        if(this.OnClicked == null)
        {
                return;
        }
        
        this.OnClicked.Invoke(obj:  this);
    }
    public virtual void SetupAsInactive()
    {
        this.gameObject.SetActive(value:  false);
        this.IsPlaceholder = true;
    }
    public virtual void SetupAsGridPlaceholder()
    {
        this.gameObject.SetActive(value:  true);
        this.IsPlaceholder = true;
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_past)) != false)
        {
                this.bg_past.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_present)) != false)
        {
                this.bg_present.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_future)) != false)
        {
                this.bg_future.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.dayText.gameObject)) == false)
        {
                return;
        }
        
        this.dayText.gameObject.SetActive(value:  false);
    }
    public virtual void Setup(int day, int month, int year, bool selectCurrentDate)
    {
        UnityEngine.UI.Text val_5;
        this.gameObject.SetActive(value:  true);
        this.IsPlaceholder = false;
        this.Day = day;
        this.Month = month;
        this.Year = year;
        val_5 = this.dayText;
        if((UnityEngine.Object.op_Implicit(exists:  val_5)) != false)
        {
                val_5 = this.dayText;
            string val_3 = day.ToString(format:  "##");
        }
        
        bool val_4 = selectCurrentDate;
    }
    protected virtual void SetupAsPast()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.dayText.gameObject)) != false)
        {
                this.dayText.gameObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_past)) != false)
        {
                this.bg_past.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_present)) != false)
        {
                this.bg_present.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_future)) == false)
        {
                return;
        }
        
        this.bg_future.SetActive(value:  false);
    }
    protected virtual void SetupAsPresent()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.dayText.gameObject)) != false)
        {
                this.dayText.gameObject.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_past)) != false)
        {
                this.bg_past.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_present)) != false)
        {
                this.bg_present.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_future)) == false)
        {
                return;
        }
        
        this.bg_future.SetActive(value:  false);
    }
    protected virtual void SetupAsFuture()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.dayText.gameObject)) != false)
        {
                this.dayText.gameObject.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_past)) != false)
        {
                this.bg_past.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_present)) != false)
        {
                this.bg_present.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.bg_future)) == false)
        {
                return;
        }
        
        this.bg_future.SetActive(value:  true);
    }
    public virtual void Select()
    {
        goto typeof(UGUICalendarDayDisplay).__il2cppRuntimeField_1D0;
    }
    public virtual void Deselect(bool selectCurrentDate)
    {
        ulong val_8;
        if(this.IsPlaceholder == true)
        {
                return;
        }
        
        System.DateTime val_1 = new System.DateTime(year:  this.Year, month:  this.Month, day:  this.Day);
        System.DateTime val_2 = val_1.dateData.AddDays(value:  1);
        System.DateTime val_3 = val_2.dateData.AddSeconds(value:  -1);
        val_8 = val_3.dateData;
        System.DateTime val_4 = DateTimeCheat.Today;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_8}, d2:  new System.DateTime() {dateData = val_4.dateData});
        if(val_5._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        if((val_5._ticks.TotalHours >= 0) || (selectCurrentDate == false))
        {
                return;
        }
    
    }
    public UGUICalendarDayDisplay()
    {
        this.IsPlaceholder = true;
        this.Day = -1;
        this.Month = -1;
        this.Year = 0;
    }

}
