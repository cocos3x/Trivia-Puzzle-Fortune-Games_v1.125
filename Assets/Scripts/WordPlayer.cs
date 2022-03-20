using UnityEngine;
public class WordPlayer : Player
{
    // Fields
    private EasySaver<WordPlayer> mySaver;
    
    // Methods
    public override void BuildReflectedLists()
    {
        this.mySaver = new EasySaver<WordPlayer>(incInstance:  this);
    }
    public override void AddHardSaves(ref System.Collections.Generic.Dictionary<string, object> incDic)
    {
        this.mySaver.AddHardSavesToDictionary(refdic: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = incDic);
    }
    public override void SoftSave()
    {
        this.mySaver.SoftSaveLite();
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected override void Save()
    {
        this.mySaver.SoftSaveFull();
    }
    public WordPlayer()
    {
    
    }

}
