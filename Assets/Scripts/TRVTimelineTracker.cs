using UnityEngine;
public class TRVTimelineTracker : WGTimelineTracker
{
    // Properties
    protected override int LevelGenerationVersion { get; }
    
    // Methods
    protected override int get_LevelGenerationVersion()
    {
        return 1;
    }
    public override void LevelStarted(string levelword, string levelWords, MainController.GameModeForTracking gameMode, string levelLanguage)
    {
        System.DateTime val_1 = System.DateTime.Now;
        mem[1152921517664325712] = val_1.dateData;
        mem[1152921517664325736] = levelword;
        mem[1152921517664325744] = levelWords;
        mem[1152921517664325768] = gameMode;
        mem[1152921517664325752] = levelLanguage;
    }
    public virtual void LevelComplete(System.Collections.Generic.Dictionary<string, object> levelCompleteProperties)
    {
        this.TrackEvent(eventProperties:  levelCompleteProperties, tipo:  4);
    }
    private void TrackEvent(System.Collections.Generic.Dictionary<string, object> eventProperties, TimelineEvent.Type tipo)
    {
        string val_4;
        TRVTimelineTracker val_5;
        var val_13;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Dictionary.Enumerator<TKey, TValue> val_2 = eventProperties.GetEnumerator();
        label_4:
        if(val_5.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_4, value:  val_4);
        goto label_4;
        label_2:
        val_5.Dispose();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5 = this;
        val_7.Add(key:  "version", value:  val_5);
        val_7.Add(key:  "game", value:  "trivia");
        GameBehavior val_8 = App.getBehavior;
        val_7.Add(key:  "lang", value:  val_8.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        val_7.Add(key:  "type", value:  tipo.ToString());
        val_13 = null;
        val_13 = null;
        val_7.Add(key:  "iso_lang", value:  TRVDataParser.desiredLocale);
        val_7.Add(key:  "platform", value:  DeviceProperties.Platform);
        val_7.Add(key:  "event_data", value:  val_1);
        string val_12 = MiniJSON.Json.Serialize(obj:  val_7);
        UnityEngine.Debug.LogError(message:  val_12);
        val_12.DoPut(path:  System.String.alignConst, postBody:  val_7, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false);
    }
    public TRVTimelineTracker()
    {
    
    }

}
