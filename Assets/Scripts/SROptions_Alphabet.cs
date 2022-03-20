using UnityEngine;
public class SROptions_Alphabet : SuperLuckySROptionsParent<SROptions_Alphabet>, INotifyPropertyChanged
{
    // Properties
    public bool AlwaysPostLevel { get; set; }
    public string CurrentTile { get; }
    public string CurrentBox { get; }
    public string CurrentProg { get; }
    public string CurrentLang { get; }
    public string CurrentCollectionIndex { get; }
    public string CurrentLevelIndex { get; }
    
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
        var val_8;
        var val_11;
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_8 = 13;
        val_11 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_11 = 12;
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
    }
    public void GetLetterTile()
    {
        MonoSingleton<Alphabet2Manager>.Instance.QAHACK_GetTile();
        SROptions_Alphabet.NotifyPropertyChanged(propertyName:  "CurrentBox");
    }
    public void AddLetterTile()
    {
        MonoSingleton<Alphabet2Manager>.Instance.QAHACK_AddTile();
        SROptions_Alphabet.NotifyPropertyChanged(propertyName:  "CurrentTile");
    }
    public void GetFullBox()
    {
        MonoSingleton<Alphabet2Manager>.Instance.QAHACK_FillBoxAndCollect();
        SROptions_Alphabet.NotifyPropertyChanged(propertyName:  "CurrentBox");
    }
    public void GetFullCollection()
    {
        MonoSingleton<Alphabet2Manager>.Instance.QAHACK_CompleteCurrentCollection();
        SROptions_Alphabet.NotifyPropertyChanged(propertyName:  "CurrentProg");
    }
    public bool get_AlwaysPostLevel()
    {
        Alphabet2Manager val_1 = MonoSingleton<Alphabet2Manager>.Instance;
        return (bool)val_1.QAHACK_alwaysPostLevelTile;
    }
    public void set_AlwaysPostLevel(bool value)
    {
        Alphabet2Manager val_1 = MonoSingleton<Alphabet2Manager>.Instance;
        val_1.QAHACK_alwaysPostLevelTile = value;
        SROptions_Alphabet.NotifyPropertyChanged(propertyName:  "AlwaysPostLevel");
    }
    public void RunSample()
    {
        MonoSingleton<Alphabet2Manager>.Instance.QAHACK_SampleTileCollection();
    }
    public string get_CurrentTile()
    {
        object val_10;
        if((System.String.IsNullOrEmpty(value:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionLetter)) != false)
        {
                val_10 = "None";
            return (string)System.String.Format(format:  "{0} : {1}", arg0:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionLetter, arg1:  val_10 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRarity().ToString());
        }
        
        return (string)System.String.Format(format:  "{0} : {1}", arg0:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionLetter, arg1:  val_10);
    }
    public string get_CurrentBox()
    {
        return PrettyPrint.printJSON(obj:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox, types:  false, singleLineOutput:  false);
    }
    public string get_CurrentProg()
    {
        return PrettyPrint.printJSON(obj:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionProgress, types:  false, singleLineOutput:  false);
    }
    public string get_CurrentLang()
    {
        Player val_1 = App.Player;
        return (string)val_1.properties.ab_currentLanguage;
    }
    public string get_CurrentCollectionIndex()
    {
        Player val_1 = App.Player;
        return val_1.properties.ab_currentCollectionIndex.ToString();
    }
    public string get_CurrentLevelIndex()
    {
        return PrettyPrint.printJSON(obj:  MonoSingleton<Alphabet2Manager>.Instance.GetLevelTracking(), types:  false, singleLineOutput:  false);
    }
    public SROptions_Alphabet()
    {
    
    }

}
