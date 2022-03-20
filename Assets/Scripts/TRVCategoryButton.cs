using UnityEngine;
public class TRVCategoryButton : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Image categoryImage;
    private UnityEngine.UI.Text categoryName;
    private UnityEngine.GameObject categoryRankNotification;
    private UnityEngine.UI.Text categoryRank;
    private UnityEngine.UI.Image eventIcon;
    private UnityEngine.UI.Text timeRemaining;
    private UnityEngine.GameObject promoCategoryHighlight;
    private bool showPromoEndTime;
    private System.DateTime endTime;
    public bool animating;
    private string myCat;
    private UnityEngine.UI.Button myButton;
    
    // Properties
    public string getCat { get; }
    public UnityEngine.UI.Button MyButton { get; }
    
    // Methods
    public string get_getCat()
    {
        return (string)this.myCat;
    }
    public UnityEngine.UI.Button get_MyButton()
    {
        UnityEngine.UI.Button val_3;
        if(this.myButton == 0)
        {
                this.myButton = this.GetComponent<UnityEngine.UI.Button>();
            return val_3;
        }
        
        val_3 = this.myButton;
        return val_3;
    }
    public void SetCategoryButton(UnityEngine.Sprite image, string name, int rank = 0, UnityEngine.Sprite eventIcon, bool hasEndTime = False, System.DateTime endTime, bool showPromoHighlight = False)
    {
        string val_16;
        var val_18;
        val_16 = name;
        this.myCat = val_16;
        if(image != 0)
        {
                this.categoryImage.sprite = image;
        }
        
        this.categoryImage.preserveAspect = true;
        if((val_16.Contains(value:  "FTUX")) != false)
        {
                val_16 = val_16.Replace(oldValue:  "FTUX", newValue:  "");
        }
        
        if((System.String.IsNullOrEmpty(value:  val_16)) != false)
        {
            
        }
        else
        {
                string val_5 = TRVCategorySelection.ToUpperCategory(category:  val_16);
        }
        
        string val_6 = rank.ToString();
        this.categoryRankNotification.SetActive(value:  (rank > 0) ? 1 : 0);
        this.showPromoEndTime = hasEndTime;
        this.endTime = endTime;
        if(this.timeRemaining != 0)
        {
                this.timeRemaining.gameObject.SetActive(value:  this.showPromoEndTime);
            this.UpdateTimeRemaining();
        }
        
        if(this.promoCategoryHighlight != 0)
        {
                this.promoCategoryHighlight.SetActive(value:  showPromoHighlight);
        }
        
        if(eventIcon == 0)
        {
                UnityEngine.GameObject val_14 = this.eventIcon.gameObject;
            val_18 = 0;
        }
        else
        {
                this.eventIcon.sprite = eventIcon;
            val_18 = 1;
        }
        
        this.eventIcon.gameObject.SetActive(value:  true);
    }
    public void SetCategoryName(string name)
    {
        string val_3 = name;
        if((val_3.Contains(value:  "FTUX")) != false)
        {
                val_3 = val_3.Replace(oldValue:  "FTUX", newValue:  "");
        }
    
    }
    protected override void UpdateLogic()
    {
        this.UpdateTimeRemaining();
    }
    private void UpdateTimeRemaining()
    {
        var val_7;
        if(this.animating != false)
        {
                return;
        }
        
        if(this.showPromoEndTime == false)
        {
                return;
        }
        
        if(this.timeRemaining == 0)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = this.endTime.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        string val_4 = val_3._ticks.GetDateString(difference:  new System.TimeSpan() {_ticks = val_3._ticks});
        val_7 = null;
        val_7 = null;
        System.TimeSpan val_7 = System.TimeSpan.Zero;
        val_7 = System.TimeSpan.op_GreaterThan(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = val_7});
        this.MyButton.interactable = val_7;
    }
    private string GetDateString(System.TimeSpan difference)
    {
        long val_14;
        var val_15;
        var val_16;
        object val_17;
        string val_19;
        val_14 = difference._ticks;
        val_15 = null;
        val_15 = null;
        if((System.TimeSpan.op_LessThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_14}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_16 = "0m 0s";
            return (string)System.String.Format(format:  val_19 = "{0}h {1}m {2}s", arg0:  int val_7 = difference._ticks.Hours, arg1:  int val_8 = difference._ticks.Minutes, arg2:  difference._ticks.Seconds);
        }
        
        if(difference._ticks.Days >= 1)
        {
                val_14 = difference._ticks.Days;
            val_17 = difference._ticks.Hours;
            int val_5 = difference._ticks.Minutes;
            val_19 = "{0}d {1}h {2}m";
            return (string)System.String.Format(format:  val_19, arg0:  val_7, arg1:  val_8, arg2:  difference._ticks.Seconds);
        }
        
        if(difference._ticks.Hours >= 1)
        {
                val_14 = val_7;
            val_17 = val_8;
            return (string)System.String.Format(format:  val_19, arg0:  val_7, arg1:  val_8, arg2:  difference._ticks.Seconds);
        }
        
        string val_13 = System.String.Format(format:  "{0}m {1}s", arg0:  difference._ticks.Minutes, arg1:  difference._ticks.Seconds);
        return (string)System.String.Format(format:  val_19, arg0:  val_7, arg1:  val_8, arg2:  difference._ticks.Seconds);
    }
    public TRVCategoryButton()
    {
    
    }

}
