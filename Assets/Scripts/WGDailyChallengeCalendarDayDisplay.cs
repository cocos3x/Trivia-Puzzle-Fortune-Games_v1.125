using UnityEngine;
public class WGDailyChallengeCalendarDayDisplay : UGUICalendarDayDisplay
{
    // Fields
    private UnityEngine.Color fullStarsBg;
    private UnityEngine.Color lessStarsBg;
    private UnityEngine.Sprite selectedBg;
    private UnityEngine.GameObject entire_group;
    private UnityEngine.UI.Image present_past_bg;
    private UnityEngine.UI.Image outline;
    private DailyChallengeStarGroup starGroup_m;
    private DailyChallengeStarGroup starGroup_e;
    public System.Action<WGDailyChallengeCalendarDayDisplay, bool> OnClicked;
    private DailyChallenge_DayProgress <DayProgress>k__BackingField;
    
    // Properties
    public DailyChallenge_DayProgress DayProgress { get; set; }
    
    // Methods
    public DailyChallenge_DayProgress get_DayProgress()
    {
        return (DailyChallenge_DayProgress)this.<DayProgress>k__BackingField;
    }
    private void set_DayProgress(DailyChallenge_DayProgress value)
    {
        this.<DayProgress>k__BackingField = value;
    }
    public void Setup(int day, int month, int year, bool selectCurrentDate, DailyChallenge_DayProgress dayProgress)
    {
        DailyChallenge_DayProgress val_7 = dayProgress;
        mem[1152921517770896020] = day;
        mem[1152921517770896016] = 0;
        mem[1152921517770896024] = month;
        mem[1152921517770896028] = year;
        if(val_7 == null)
        {
                DailyChallenge_DayProgress val_1 = null;
            val_7 = val_1;
            val_1 = new DailyChallenge_DayProgress();
        }
        
        this.<DayProgress>k__BackingField = val_7;
        UnityEngine.GameObject val_2 = val_1.gameObject;
        if((UnityEngine.Object.op_Implicit(exists:  val_2)) != false)
        {
                string val_4 = mem[1152921517770896020].ToString();
            val_2.gameObject.SetActive(value:  false);
        }
        
        bool val_6 = selectCurrentDate;
        goto typeof(WGDailyChallengeCalendarDayDisplay).__il2cppRuntimeField_200;
    }
    public bool IsDayCompleted()
    {
        if((this.<DayProgress>k__BackingField) != null)
        {
                if((this.<DayProgress>k__BackingField.stars_m) != 3)
        {
                return false;
        }
        
            return (bool)((this.<DayProgress>k__BackingField.stars_e) == 3) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public void ResetUI()
    {
        UnityEngine.Color val_2;
        var val_3;
        var val_4;
        var val_5;
        if(((this.<DayProgress>k__BackingField.stars_m) != 3) || ((this.<DayProgress>k__BackingField.stars_e) != 3))
        {
            goto label_2;
        }
        
        val_2 = this.fullStarsBg;
        val_3 = 1152921517771165092;
        val_4 = 1152921517771165096;
        val_5 = 1152921517771165100;
        if(this.present_past_bg != null)
        {
            goto label_3;
        }
        
        label_2:
        val_2 = this.lessStarsBg;
        val_3 = 1152921517771165108;
        val_4 = 1152921517771165112;
        val_5 = 1152921517771165116;
        label_3:
        this.present_past_bg.color = new UnityEngine.Color() {r = this.lessStarsBg.r, g = 2.668748E-25f, b = 2.668748E-25f, a = 2.668748E-25f};
        this.outline.gameObject.SetActive(value:  false);
    }
    private void SetupDayDisplay()
    {
        UnityEngine.Color val_5;
        var val_6;
        var val_7;
        var val_8;
        if(((this.<DayProgress>k__BackingField.stars_m) != 3) || ((this.<DayProgress>k__BackingField.stars_e) != 3))
        {
            goto label_2;
        }
        
        val_5 = this.fullStarsBg;
        val_6 = 1152921517771350820;
        val_7 = 1152921517771350824;
        val_8 = 1152921517771350828;
        if(this.present_past_bg != null)
        {
            goto label_3;
        }
        
        label_2:
        val_5 = this.lessStarsBg;
        val_6 = 1152921517771350836;
        val_7 = 1152921517771350840;
        val_8 = 1152921517771350844;
        label_3:
        this.present_past_bg.color = new UnityEngine.Color() {r = this.lessStarsBg.r, g = 2.668748E-25f, b = 2.668748E-25f, a = 2.668748E-25f};
        this.starGroup_m.Setup(stars:  this.<DayProgress>k__BackingField.stars_m);
        this.starGroup_e.Setup(stars:  this.<DayProgress>k__BackingField.stars_e);
        this.outline.gameObject.SetActive(value:  false);
        this.starGroup_m.gameObject.SetActive(value:  true);
        this.starGroup_e.gameObject.SetActive(value:  true);
        this.present_past_bg.gameObject.SetActive(value:  true);
    }
    private void OnDayClicked(UGUICalendarDayDisplay display, bool showingTooltip)
    {
        UnityEngine.Color val_2;
        var val_3;
        var val_4;
        var val_5;
        if(((this.<DayProgress>k__BackingField.stars_m) != 3) || ((this.<DayProgress>k__BackingField.stars_e) != 3))
        {
            goto label_2;
        }
        
        val_2 = this.fullStarsBg;
        val_3 = 1152921517771548836;
        val_4 = 1152921517771548840;
        val_5 = 1152921517771548844;
        if(this.present_past_bg != null)
        {
            goto label_3;
        }
        
        label_2:
        val_2 = this.lessStarsBg;
        val_3 = 1152921517771548852;
        val_4 = 1152921517771548856;
        val_5 = 1152921517771548860;
        label_3:
        this.present_past_bg.color = new UnityEngine.Color() {r = this.lessStarsBg.r, g = 2.668748E-25f, b = 2.668748E-25f, a = 2.668748E-25f};
        this.outline.sprite = this.selectedBg;
        this.outline.gameObject.SetActive(value:  true);
    }
    public override void Deselect(bool selectCurrentDate)
    {
        ulong val_8;
        if(true != 0)
        {
                return;
        }
        
        System.DateTime val_1 = new System.DateTime(year:  selectCurrentDate, month:  0, day:  0);
        System.DateTime val_2 = val_1.dateData.AddDays(value:  1);
        System.DateTime val_3 = val_2.dateData.AddSeconds(value:  -1);
        val_8 = val_3.dateData;
        System.DateTime val_4 = DateTimeCheat.Today;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_8}, d2:  new System.DateTime() {dateData = val_4.dateData});
        if(val_5._ticks.TotalSeconds >= 0)
        {
                if((val_5._ticks.TotalHours >= 0) || (selectCurrentDate == false))
        {
            goto label_8;
        }
        
        }
        
        this.SetupDayDisplay();
        return;
        label_8:
        this.SetupAsFuture();
    }
    public override void Select()
    {
        this.Select();
    }
    public override void SetupAsGridPlaceholder()
    {
        this.SetupAsGridPlaceholder();
        this.entire_group.SetActive(value:  false);
    }
    protected override void SetupAsPresent()
    {
        UnityEngine.GameObject val_1 = 35443.gameObject;
        bool val_2 = UnityEngine.Object.op_Implicit(exists:  val_1);
        if(val_2 != false)
        {
                val_2.gameObject.SetActive(value:  false);
        }
        
        bool val_4 = UnityEngine.Object.op_Implicit(exists:  val_1);
        if(val_4 != false)
        {
                val_4.SetActive(value:  false);
        }
        
        bool val_5 = UnityEngine.Object.op_Implicit(exists:  val_1);
        if(val_5 != false)
        {
                val_5.SetActive(value:  true);
        }
        
        bool val_6 = UnityEngine.Object.op_Implicit(exists:  val_1);
        if(val_6 == false)
        {
                return;
        }
        
        val_6.SetActive(value:  false);
    }
    public override void OnButtonClick()
    {
        if(true != 0)
        {
                return;
        }
        
        this.OnButtonClick();
        if(this.OnClicked == null)
        {
                return;
        }
        
        this.OnClicked.Invoke(arg1:  this, arg2:  false);
    }
    private void Awake()
    {
        this.OnClicked = new System.Action<WGDailyChallengeCalendarDayDisplay, System.Boolean>(object:  this, method:  System.Void WGDailyChallengeCalendarDayDisplay::OnDayClicked(UGUICalendarDayDisplay display, bool showingTooltip));
    }
    public WGDailyChallengeCalendarDayDisplay()
    {
    
    }

}
