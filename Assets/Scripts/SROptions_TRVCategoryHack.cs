using UnityEngine;
public class SROptions_TRVCategoryHack : SuperLuckySROptionsParent<SROptions_TRVCategoryHack>, INotifyPropertyChanged
{
    // Fields
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> availableSubCategories;
    private int generalCategorySelected;
    private int sportsCategorySelected;
    private int entertainmentCategorySelected;
    
    // Properties
    private System.Collections.Generic.List<string> SelectedCategories { get; set; }
    public string CatInfo { get; }
    public int GeneralCategorySelected { get; set; }
    public int SportsCategorySelected { get; set; }
    public int EntertainmentCategorySelected { get; set; }
    public string CurrentFakeAdjustCampaign { get; set; }
    
    // Methods
    private System.Collections.Generic.List<string> get_SelectedCategories()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        return (System.Collections.Generic.List<System.String>)val_1.<playerPersistance>k__BackingField.availableCategories;
    }
    private void set_SelectedCategories(System.Collections.Generic.List<string> value)
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        val_1.<playerPersistance>k__BackingField.getCurrentAvailableCategories = value;
    }
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public void DisplayCategoriesInfo()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "All Available Categories", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetTRVCategoriesInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_CatInfo()
    {
        TRVQuizProgress val_10;
        UnityEngine.Object val_11;
        var val_12;
        val_10 = 1152921515943153616;
        val_11 = MonoSingleton<TRVMainController>.Instance;
        if(val_11 == 0)
        {
                val_12 = "no current quiz";
            return (string)System.String.Format(format:  "{0}:{1} {2}/{3} Completed", args:  object[] val_4 = new object[4]);
        }
        
        TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
        val_10 = val_3.currentGame;
        val_11 = val_4;
        val_11[0] = val_3.currentGame.quizCategory;
        val_11[1] = val_3.currentGame.currentQuestionData.<difficulty>k__BackingField;
        TRVDataParser val_5 = MonoSingleton<TRVDataParser>.Instance;
        TRVSubCategoryProgress val_6 = val_5.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  val_3.currentGame.quizCategory);
        val_11[2] = val_6.seenQuestions.Item[val_3.currentGame.currentQuestionData.<difficulty>k__BackingField];
        System.Collections.Generic.List<QuestionData> val_8 = val_3.currentGame.<myData>k__BackingField.questionData.Item[val_3.currentGame.currentQuestionData.<difficulty>k__BackingField];
        val_11[3] = 1152921516944745696;
        return (string)System.String.Format(format:  "{0}:{1} {2}/{3} Completed", args:  val_4);
    }
    public void NearlyCompleteCat()
    {
        if((MonoSingleton<TRVMainController>.Instance) == 0)
        {
                return;
        }
        
        TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
        TRVDataParser val_4 = MonoSingleton<TRVDataParser>.Instance;
        TRVSubCategoryProgress val_5 = val_4.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  val_3.currentGame.quizCategory);
        System.Collections.Generic.List<QuestionData> val_7 = val_3.currentGame.<myData>k__BackingField.questionData.Item[val_3.currentGame.currentQuestionData.<difficulty>k__BackingField];
        val_5.seenQuestions.set_Item(key:  val_3.currentGame.currentQuestionData.<difficulty>k__BackingField, value:  44512238 | (val_5.seenQuestions.Item[val_3.currentGame.currentQuestionData.<difficulty>k__BackingField]));
        SROptions_TRVCategoryHack.NotifyPropertyChanged(propertyName:  "Current Category:Difficulty");
    }
    public int get_GeneralCategorySelected()
    {
        return (int)this.generalCategorySelected;
    }
    public void set_GeneralCategorySelected(int value)
    {
        var val_7;
        var val_8;
        string val_9;
        val_7 = this;
        this.generalCategorySelected = value;
        SROptions_TRVCategoryHack.NotifyPropertyChanged(propertyName:  "General");
        if(value != 1)
        {
                if(value < 1)
        {
                return;
        }
        
            System.Collections.Generic.List<System.String> val_2 = MonoSingleton<TRVDataParser>.Instance.HackCategories;
            System.Collections.Generic.List<System.String> val_3 = this.availableSubCategories.Item["General"];
            int val_6 = this.generalCategorySelected;
            val_7 = val_6 - 1;
            if(1152921516945296096 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = 1152921516945301216;
            val_6 = val_6 + (val_7 << 3);
            val_9 = mem[(this.generalCategorySelected + ((this.generalCategorySelected - 1)) << 3) + 32];
            val_9 = (this.generalCategorySelected + ((this.generalCategorySelected - 1)) << 3) + 32;
        }
        else
        {
                val_8 = 1152921516945301216;
            val_9 = "";
        }
        
        MonoSingleton<TRVDataParser>.Instance.HackCategories.set_Item(index:  0, value:  val_9);
    }
    public int get_SportsCategorySelected()
    {
        return (int)this.sportsCategorySelected;
    }
    public void set_SportsCategorySelected(int value)
    {
        var val_7;
        var val_8;
        string val_9;
        var val_10;
        val_7 = this;
        this.sportsCategorySelected = value;
        SROptions_TRVCategoryHack.NotifyPropertyChanged(propertyName:  "Sports");
        if(value != 1)
        {
                if(value < 1)
        {
                return;
        }
        
            System.Collections.Generic.List<System.String> val_2 = MonoSingleton<TRVDataParser>.Instance.HackCategories;
            System.Collections.Generic.List<System.String> val_3 = this.availableSubCategories.Item["Sports"];
            int val_6 = this.sportsCategorySelected;
            val_7 = val_6 - 1;
            if(1152921516945296096 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = 1;
            val_6 = val_6 + (val_7 << 3);
            val_9 = mem[(this.sportsCategorySelected + ((this.sportsCategorySelected - 1)) << 3) + 32];
            val_9 = (this.sportsCategorySelected + ((this.sportsCategorySelected - 1)) << 3) + 32;
            val_10 = public System.Void System.Collections.Generic.List<System.String>::set_Item(int index, System.String value);
        }
        else
        {
                val_8 = 1;
            val_9 = "";
            val_10 = public System.Void System.Collections.Generic.List<System.String>::set_Item(int index, System.String value);
        }
        
        MonoSingleton<TRVDataParser>.Instance.HackCategories.set_Item(index:  1, value:  val_9);
    }
    public int get_EntertainmentCategorySelected()
    {
        return (int)this.entertainmentCategorySelected;
    }
    public void set_EntertainmentCategorySelected(int value)
    {
        var val_7;
        var val_8;
        string val_9;
        var val_10;
        val_7 = this;
        this.entertainmentCategorySelected = value;
        SROptions_TRVCategoryHack.NotifyPropertyChanged(propertyName:  "Entertainment");
        if(value != 1)
        {
                if(value < 1)
        {
                return;
        }
        
            System.Collections.Generic.List<System.String> val_2 = MonoSingleton<TRVDataParser>.Instance.HackCategories;
            System.Collections.Generic.List<System.String> val_3 = this.availableSubCategories.Item["Entertainment"];
            int val_6 = this.entertainmentCategorySelected;
            val_7 = val_6 - 1;
            if(1152921516945296096 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = 2;
            val_6 = val_6 + (val_7 << 3);
            val_9 = mem[(this.entertainmentCategorySelected + ((this.entertainmentCategorySelected - 1)) << 3) + 32];
            val_9 = (this.entertainmentCategorySelected + ((this.entertainmentCategorySelected - 1)) << 3) + 32;
            val_10 = public System.Void System.Collections.Generic.List<System.String>::set_Item(int index, System.String value);
        }
        else
        {
                val_8 = 2;
            val_9 = "";
            val_10 = public System.Void System.Collections.Generic.List<System.String>::set_Item(int index, System.String value);
        }
        
        MonoSingleton<TRVDataParser>.Instance.HackCategories.set_Item(index:  2, value:  val_9);
    }
    public string get_CurrentFakeAdjustCampaign()
    {
        null = null;
        return (string)TRVDataParser.hackedAdjustCampaign;
    }
    public void set_CurrentFakeAdjustCampaign(string value)
    {
        null = null;
        TRVDataParser.hackedAdjustCampaign = value;
    }
    public void PromoCategoriesLogicHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Promo Categories HUD", callbackfunc:  new System.Func<System.String>(object:  0, method:  public static System.String TRVPromoCategoriesHandler::GetLogicLog()));
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_TRVCategoryHack()
    {
        this.availableSubCategories = MonoSingleton<TRVDataParser>.Instance.getAvailableSubCategories;
        this.generalCategorySelected = -1;
        this.sportsCategorySelected = -1;
        this.entertainmentCategorySelected = 0;
    }

}
