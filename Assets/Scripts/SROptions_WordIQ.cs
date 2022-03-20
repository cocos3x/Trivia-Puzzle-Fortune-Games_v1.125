using UnityEngine;
public class SROptions_WordIQ : SuperLuckySROptionsParent<SROptions_WordIQ>, INotifyPropertyChanged
{
    // Properties
    public string Level { get; }
    public string SetLevel { get; set; }
    
    // Methods
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
    public void IQGameplayHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "IQ Gameplay HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetIQGameplayInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void IQLogicHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "IQ Maths HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetIQMathsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PopulatedHistoryHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Populated History", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetIQPopulatedWordHistory()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ActualHistoryHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Actual History", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetIQActualWordHistory()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_Level()
    {
        return (string)MonoSingleton<WordIQManager>.Instance.PlayerIQ.ToString();
    }
    public void AddPlayerIQ_0005()
    {
        this.AddIQPoints(iqPoints:  0.005f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_001()
    {
        this.AddIQPoints(iqPoints:  0.01f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_01()
    {
        this.AddIQPoints(iqPoints:  0.1f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_1()
    {
        this.AddIQPoints(iqPoints:  1f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_10()
    {
        this.AddIQPoints(iqPoints:  10f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_n0005()
    {
        this.AddIQPoints(iqPoints:  -0.005f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_n001()
    {
        this.AddIQPoints(iqPoints:  -0.01f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_n01()
    {
        this.AddIQPoints(iqPoints:  -0.1f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_n1()
    {
        this.AddIQPoints(iqPoints:  -1f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void AddPlayerIQ_n10()
    {
        this.AddIQPoints(iqPoints:  -10f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public void set_SetLevel(string value)
    {
        float val_2 = MonoSingleton<WordIQManager>.Instance.PlayerIQ;
        if((System.Single.TryParse(s:  value, result: out  float val_3 = -8.40643E+19f)) == false)
        {
                return;
        }
        
        if(val_2 == (MonoSingleton<WordIQManager>.Instance.PlayerIQ))
        {
                return;
        }
        
        MonoSingleton<WordIQManager>.Instance.Hack_SetIQ(points:  val_2);
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Player IQ to " + val_2, displayTime:  3f);
        SROptions_WordIQ.NotifyPropertyChanged(propertyName:  "IQ Points");
    }
    public string get_SetLevel()
    {
        return (string)MonoSingleton<WordIQManager>.Instance.PlayerIQ.ToString();
    }
    private void AddIQPoints(float iqPoints)
    {
        MonoSingleton<WordIQManager>.Instance.Hack_AddIQ(points:  iqPoints);
    }
    public SROptions_WordIQ()
    {
    
    }

}
