using UnityEngine;
public class UGUICalendarDisplay : MonoBehaviour
{
    // Fields
    protected readonly string[] monthNames;
    protected UnityEngine.GameObject dayPrefab;
    protected UnityEngine.Transform dayGrid;
    protected UnityEngine.UI.Text monthText;
    protected int weeksToDisplay;
    protected System.Collections.Generic.List<UGUICalendarDayDisplay> instantiatedDays;
    private int currentMonth;
    private int currentYear;
    
    // Properties
    public int DaysInGrid { get; }
    
    // Methods
    public int get_DaysInGrid()
    {
        return (int)(this.weeksToDisplay << 3) - this.weeksToDisplay;
    }
    private void Awake()
    {
        goto typeof(UGUICalendarDisplay).__il2cppRuntimeField_170;
    }
    private void OnEnable()
    {
        goto typeof(UGUICalendarDisplay).__il2cppRuntimeField_180;
    }
    protected virtual void DoOnAwake()
    {
        UGUIDimensionChangeDetector val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UGUIDimensionChangeDetector>(child:  this.dayGrid);
        val_1.OnDimensionChange = new System.Action(object:  this, method:  System.Void UGUICalendarDisplay::MarkForRebuild());
    }
    protected virtual void DoOnEnable()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        this.currentMonth = val_1.dateData.Month;
        System.DateTime val_3 = DateTimeCheat.Now;
        this.currentYear = val_3.dateData.Year;
    }
    private void MarkForRebuild()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.MarkForRebuildAfterFrame());
    }
    private System.Collections.IEnumerator MarkForRebuildAfterFrame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UGUICalendarDisplay.<MarkForRebuildAfterFrame>d__15();
    }
    protected virtual void RefreshRebuild()
    {
        UnityEngine.RectTransform val_2;
        UnityEngine.Transform val_1 = this.dayGrid.parent;
        if(val_1 != null)
        {
                val_1 = (null == null) ? (val_1) : 0;
        }
        else
        {
                val_2 = 0;
        }
        
        UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  val_2);
    }
    public virtual void Setup(int month, int year, bool selectToday = False)
    {
        var val_11;
        var val_12;
        val_11 = selectToday;
        if(this.instantiatedDays != null)
        {
                if(this.instantiatedDays > 0)
        {
            goto label_2;
        }
        
        }
        
        this.InstantiateDayPrefabs();
        label_2:
        string val_3 = this.monthNames[month].ToUpper() + " " + year.ToString();
        System.Globalization.GregorianCalendar val_4 = new System.Globalization.GregorianCalendar();
        val_12 = val_4.GetDaysInMonth(year:  year, month:  month);
        System.DateTime val_6 = new System.DateTime(year:  year, month:  month, day:  1);
        int val_11 = this.weeksToDisplay;
        val_11 = (val_11 << 3) - val_11;
        if(val_11 < 1)
        {
                return;
        }
        
        System.Globalization.GregorianCalendar val_8 = val_4 + val_12;
        var val_12 = 0;
        val_12 = -1152921517670552079;
        val_11 = val_11;
        label_20:
        if(val_12 >= 178803216)
        {
            goto label_9;
        }
        
        if(val_12 < val_8)
        {
            goto label_13;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        goto label_13;
        label_9:
        if(val_12 >= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_12 >= (long)val_8)
        {
            goto label_16;
        }
        
        goto label_18;
        label_16:
        label_13:
        label_18:
        int val_13 = this.weeksToDisplay;
        val_12 = val_12 + 1;
        val_13 = (val_13 << 3) - val_13;
        if(val_12 < (val_13 << ))
        {
            goto label_20;
        }
    
    }
    private void InstantiateDayPrefabs()
    {
        int val_9 = this.weeksToDisplay;
        val_9 = (val_9 << 3) - val_9;
        if(val_9 < 1)
        {
                return;
        }
        
        do
        {
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.dayPrefab, parent:  this.dayGrid);
            val_2.name = 0.ToString(format:  "00")(0.ToString(format:  "00")) + "_instanced";
            System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnClicked, b:  new System.Action<UGUICalendarDayDisplay>(object:  this, method:  typeof(UGUICalendarDisplay).__il2cppRuntimeField_1B8));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
            val_5.OnClicked = val_7;
            this.instantiatedDays.Add(item:  val_2.GetComponent<UGUICalendarDayDisplay>());
            int val_10 = this.weeksToDisplay;
            val_10 = (val_10 << 3) - val_10;
        }
        while(1 < val_10);
        
        return;
        label_7:
    }
    public virtual void OnDayClicked(UGUICalendarDayDisplay dayClicked)
    {
        var val_3;
        int val_3 = this.weeksToDisplay;
        val_3 = (val_3 << 3) - val_3;
        if(val_3 >= 1)
        {
                do
        {
            if(val_3 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + 0;
            int val_4 = this.weeksToDisplay;
            val_3 = 0 + 1;
            val_4 = (val_4 << 3) - val_4;
        }
        while(val_3 < val_4);
        
        }
    
    }
    public void PrevMonth()
    {
        if()
        {
                this.currentMonth = 12;
            this.currentYear = this.currentYear - 1;
        }
        else
        {
                this.currentMonth = this.currentMonth - 1;
        }
    
    }
    public void NextMonth()
    {
        if(this.currentMonth == 12)
        {
                this.currentMonth = 1;
            this.currentYear = this.currentYear + 1;
        }
        else
        {
                this.currentMonth = this.currentMonth + 1;
        }
    
    }
    public UGUICalendarDisplay()
    {
        int val_3;
        string[] val_1 = new string[13];
        val_3 = val_1.Length;
        val_1[0] = "---";
        val_3 = val_1.Length;
        val_1[1] = "january";
        val_3 = val_1.Length;
        val_1[2] = "february";
        val_3 = val_1.Length;
        val_1[3] = "march";
        val_3 = val_1.Length;
        val_1[4] = "april";
        val_3 = val_1.Length;
        val_1[5] = "may";
        val_3 = val_1.Length;
        val_1[6] = "june";
        val_3 = val_1.Length;
        val_1[7] = "july";
        val_3 = val_1.Length;
        val_1[8] = "august";
        val_3 = val_1.Length;
        val_1[9] = "september";
        val_3 = val_1.Length;
        val_1[10] = "october";
        val_3 = val_1.Length;
        val_1[11] = "november";
        val_3 = val_1.Length;
        val_1[12] = "december";
        this.monthNames = val_1;
        this.weeksToDisplay = 6;
        this.instantiatedDays = new System.Collections.Generic.List<UGUICalendarDayDisplay>();
        this.currentMonth = -1;
        this.currentYear = -1;
    }

}
