using UnityEngine;
public class WGDefinitionManager : MonoSingletonSelfGenerating<WGDefinitionManager>
{
    // Fields
    private bool currentlyRequesting;
    private string currentlyRequestedWord;
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> storedWords;
    private const string definitionDirectory = "/Definitions.def";
    private const char dictionaryKeySplitter = '\x3a';
    
    // Properties
    private bool hasSeenDefFtux { get; set; }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> getStoredWords { get; }
    
    // Methods
    private bool get_hasSeenDefFtux()
    {
        return CPlayerPrefs.GetBool(key:  "defFtuxSeen", defaultValue:  false);
    }
    private void set_hasSeenDefFtux(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "defFtuxSeen", value:  value);
    }
    private void Awake()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGDefinitionManager::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        if(this.hasSeenDefFtux == false)
        {
            goto label_1;
        }
        
        GameEcon val_2 = App.getGameEcon;
        if(sceneType != 2)
        {
                return;
        }
        
        if(val_2.definitionFtuxLevel < 1)
        {
            goto label_6;
        }
        
        return;
        label_1:
        if(sceneType != 2)
        {
                return;
        }
        
        label_6:
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnValidWordSubmittedAction(callback:  new System.Action<System.String, System.Boolean>(object:  this, method:  System.Void WGDefinitionManager::OnValidWordSubmitted(string validWord, bool isExtra)));
    }
    public void displayDefinition(string word, bool flyout = False)
    {
        MetaGameBehavior val_9;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_10;
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) == true)
        {
                return;
        }
        
        val_10 = this.storedWords;
        if(val_10 == null)
        {
                this.PopulateStoredWords();
            val_10 = this.storedWords;
        }
        
        if((val_10.ContainsKey(key:  word)) != false)
        {
                if(this.storedWords == null)
        {
                this.PopulateStoredWords();
        }
        
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = this.storedWords.Item[word];
            val_5.GotDefintion(def:  val_5, flyout:  false);
        }
        else
        {
                if(this.currentlyRequesting == true)
        {
                return;
        }
        
            this.currentlyRequestedWord = word;
            GameBehavior val_6 = App.getBehavior;
            val_9 = val_6.<metaGameBehavior>k__BackingField;
            this.currentlyRequesting = true;
            this.RequestWord(word:  word);
        }
        
        Player val_8 = App.Player;
        int val_9 = val_8.properties.LifetimeDefinitionsViewed;
        val_9 = val_9 + 1;
        val_8.properties.LifetimeDefinitionsViewed = val_9;
    }
    private void RequestWord(string word)
    {
        MonoSingleton<WGServerController>.Instance.GetWordDefinition(word:  word, callback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGDefinitionManager::StoreNewDef(System.Collections.Generic.Dictionary<string, object> callbackData)), onFailure:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGDefinitionManager::OnRequestFailure(System.Collections.Generic.Dictionary<string, object> failureData)));
    }
    public void RequestWordVaidator(string word, System.Action<System.Collections.Generic.Dictionary<string, object>> callback, System.Action<System.Collections.Generic.Dictionary<string, object>> failure)
    {
        MonoSingleton<WGServerController>.Instance.GetWordDefinition(word:  word, callback:  callback, onFailure:  failure);
    }
    private void StoreNewDef(System.Collections.Generic.Dictionary<string, object> callbackData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.currentlyRequesting = false;
        object val_2 = callbackData.Item["definition"];
        if((val_2.ContainsKey(key:  "lookup")) != false)
        {
                val_2.set_Item(key:  "lookup", value:  val_2.Item["lookup"].ToUpper());
        }
        
        this.StoreWord(word:  val_2.Item["lookup"], wordData:  val_2);
        bool val_10 = System.String.op_Equality(a:  val_2.Item["lookup"].ToLower(), b:  this.currentlyRequestedWord.ToLower());
        if(val_10 == false)
        {
                return;
        }
        
        val_10.GotDefintion(def:  val_2, flyout:  false);
    }
    private void OnRequestFailure(System.Collections.Generic.Dictionary<string, object> failureData)
    {
        this.currentlyRequesting = false;
        if((System.String.op_Inequality(a:  this.currentlyRequestedWord, b:  System.String.alignConst)) == false)
        {
                return;
        }
        
        this.currentlyRequestedWord = System.String.alignConst;
        GameBehavior val_2 = App.getBehavior;
        val_2.<metaGameBehavior>k__BackingField.OnFailure();
    }
    public void StopWaitingForRequest()
    {
        this.currentlyRequesting = false;
        this.currentlyRequestedWord = System.String.alignConst;
    }
    private void GotDefintion(System.Collections.Generic.Dictionary<string, object> def, bool flyout = False)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_190;
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> get_getStoredWords()
    {
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = this.storedWords;
        if(val_1 != null)
        {
                return val_1;
        }
        
        this.PopulateStoredWords();
        val_1 = this.storedWords;
        return val_1;
    }
    public void StoreWord(string word, System.Collections.Generic.Dictionary<string, object> wordData)
    {
        if((this.storedWords.ContainsKey(key:  word)) != false)
        {
                return;
        }
        
        this.storedWords.Add(key:  word, value:  wordData);
        string val_3 = UnityEngine.Application.persistentDataPath + "/Definitions.def"("/Definitions.def");
        new System.IO.FileInfo(fileName:  val_3).Directory.Create();
        System.IO.File.AppendAllText(path:  val_3, contents:  System.Environment.NewLine + word + ":"(":") + MiniJSON.Json.Serialize(obj:  wordData)(MiniJSON.Json.Serialize(obj:  wordData)));
    }
    private void PopulateStoredWords()
    {
        var val_12;
        this.storedWords = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>();
        string val_3 = UnityEngine.Application.persistentDataPath + "/Definitions.def"("/Definitions.def");
        if((System.IO.File.Exists(path:  val_3)) == false)
        {
                return;
        }
        
        if(val_5.Length < 2)
        {
                return;
        }
        
        var val_13 = 1;
        do
        {
            int val_6 = System.IO.File.ReadAllLines(path:  val_3)[val_13].IndexOf(value:  ':');
            object val_10 = MiniJSON.Json.Deserialize(json:  val_5[0x1] + 32.Substring(startIndex:  val_6 + 1));
            val_12 = 0;
            this.storedWords.Add(key:  val_5[0x1] + 32.Substring(startIndex:  0, length:  val_6), value:  null);
            val_13 = val_13 + 1;
        }
        while(val_13 < val_5.Length);
    
    }
    private void OnValidWordSubmitted(string validWord, bool isExtra)
    {
        bool val_6 = isExtra;
        GameEcon val_1 = App.getGameEcon;
        if(val_1.definitionFtuxLevel < 1)
        {
                return;
        }
        
        GameEcon val_3 = App.getGameEcon;
        if(App.Player < val_3.definitionFtuxLevel)
        {
                return;
        }
        
        if(val_6 == true)
        {
                return;
        }
        
        val_6 = ExtraWord.GAMETYPE_CATEGORY_LEVELS;
        bool val_4 = UnityEngine.Object.op_Equality(x:  val_6, y:  0);
        if(val_4 == true)
        {
                return;
        }
        
        if(val_4.hasSeenDefFtux != false)
        {
                return;
        }
        
        ExtraWord.GAMETYPE_CATEGORY_LEVELS.DisplayDefinitionFlyout();
        ExtraWord.GAMETYPE_CATEGORY_LEVELS.hasSeenDefFtux = true;
        CPlayerPrefs.Save();
    }
    public WGDefinitionManager()
    {
        this.currentlyRequestedWord = System.String.alignConst;
    }

}
