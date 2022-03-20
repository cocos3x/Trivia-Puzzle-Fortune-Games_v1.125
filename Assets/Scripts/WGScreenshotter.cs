using UnityEngine;
public class WGScreenshotter : MonoSingletonSelfGenerating<WGScreenshotter>
{
    // Fields
    public UnityEngine.Texture2D tex;
    public System.Action OnScreenshotTaken;
    
    // Properties
    public static string urlShare { get; }
    
    // Methods
    public void DoTakeScreenshot(bool share = True, bool postToFacebook = False)
    {
        if(share != false)
        {
                System.Collections.IEnumerator val_1 = this.TakeScreenshot(postToFacebook:  false);
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.TakeQuickScreenShot());
    }
    public void ClearScreenshot()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.tex)) == false)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.tex);
    }
    private System.Collections.IEnumerator TakeQuickScreenShot()
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGScreenshotter.<TakeQuickScreenShot>d__4(<>1__state:  0);
    }
    private System.Collections.IEnumerator TakeScreenshot(bool postToFacebook = False)
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGScreenshotter.<TakeScreenshot>d__5(<>1__state:  0);
    }
    public void ShareDefault()
    {
        string val_2 = System.IO.Path.Combine(path1:  UnityEngine.Application.persistentDataPath, path2:  "share-default.png");
        if((System.IO.File.Exists(path:  val_2)) != true)
        {
                UnityEngine.Texture2D val_4 = WGResources.Load<UnityEngine.Texture2D>(fileName:  "Default/share-default", extension:  ".png", errorLog:  true);
            if(val_4 != 0)
        {
                System.IO.File.WriteAllBytes(path:  val_2, bytes:  UnityEngine.ImageConversion.EncodeToPNG(tex:  val_4));
        }
        
        }
        
        AppConfigs val_7 = App.Configuration;
        GameBehavior val_10 = App.getBehavior;
        string val_11 = System.String.Format(format:  val_10.<metaGameBehavior>k__BackingField, arg0:  System.String.Format(format:  "#{0}", arg0:  val_7.appConfig.gameName.Replace(oldValue:  " ", newValue:  System.String.alignConst)));
        TrackingComponent.CurrentIntent = 7;
        twelvegigs.plugins.SharePlugin.Share(text:  val_11, url:  this.CurrentLevelLink(), subject:  val_11, emailBody:  "", imgPath:  val_2);
    }
    public string CurrentLevelLink()
    {
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        System.Comparison<System.String> val_28;
        val_20 = null;
        val_20 = null;
        if(App.game == 1)
        {
            goto label_12;
        }
        
        val_21 = null;
        val_21 = null;
        if(App.game == 4)
        {
            goto label_12;
        }
        
        val_22 = null;
        val_22 = null;
        if(App.game != 18)
        {
            goto label_18;
        }
        
        label_12:
        GameLevel val_1 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false);
        val_23 = 0;
        if(WordRegion.instance != 0)
        {
                val_23 = WordRegion.instance.GetCompletedWords();
        }
        
        val_24 = CUtils.BuildListFromString<System.String>(values:  val_1.answers, split:  '|');
        if(1152921515450531344 >= 1)
        {
                val_25 = 1152921504622235648;
            var val_20 = 0;
            if(1152921515450531344 <= val_20)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_24.set_Item(index:  0, value:  Replace(oldValue:  "*", newValue:  System.String.alignConst));
            val_20 = val_20 + 1;
        }
        
        val_26 = null;
        val_26 = null;
        val_28 = WGScreenshotter.<>c.<>9__7_0;
        if(val_28 == null)
        {
                System.Comparison<System.String> val_8 = null;
            val_28 = val_8;
            val_8 = new System.Comparison<System.String>(object:  WGScreenshotter.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGScreenshotter.<>c::<CurrentLevelLink>b__7_0(string x, string y));
            WGScreenshotter.<>c.<>9__7_0 = val_28;
        }
        
        val_24.Sort(comparison:  val_8);
        if(1152921517956291424 >= 9)
        {
                val_24 = val_24.GetRange(index:  0, count:  8);
        }
        
        if(1152921515899221072 < 1)
        {
            goto label_44;
        }
        
        val_25 = 1152921516945301216;
        var val_21 = 0;
        label_49:
        if(val_23 == null)
        {
            goto label_45;
        }
        
        if(val_21 >= 1152921515899221072)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((val_23.Contains(item:  "K")) == true)
        {
            goto label_47;
        }
        
        label_45:
        if(val_21 >= 44214472)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24.set_Item(index:  0, value:  this.ReplaceAll(input:  "K", target:  '0'));
        label_47:
        val_21 = val_21 + 1;
        if(val_21 < 44214472)
        {
            goto label_49;
        }
        
        label_44:
        System.Collections.Generic.Dictionary<System.String, System.String> val_12 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_12.set_Item(key:  "chars", value:  val_1.word.Replace(oldValue:  "|", newValue:  ""));
        val_12.set_Item(key:  "level", value:  val_1.lvlName);
        val_12.set_Item(key:  "words", value:  System.String.Join(separator:  "_", value:  val_24.ToArray()));
        string val_16 = WGScreenshotter.urlShare;
        return System.Uri.EscapeUriString(stringToEscape:  val_16 + val_16.ToGetParams(parameters:  val_12)(val_16.ToGetParams(parameters:  val_12)));
        label_18:
        string val_19 = WGScreenshotter.urlShare;
        return System.Uri.EscapeUriString(stringToEscape:  val_16 + val_16.ToGetParams(parameters:  val_12)(val_16.ToGetParams(parameters:  val_12)));
    }
    private string ReplaceAll(string input, char target)
    {
        int val_3;
        System.Text.StringBuilder val_1 = null;
        val_3 = input.m_stringLength;
        val_1 = new System.Text.StringBuilder(capacity:  val_3);
        if(input.m_stringLength >= 1)
        {
                var val_3 = 0;
            do
        {
            val_3 = target;
            System.Text.StringBuilder val_2 = val_1.Append(value:  val_3);
            val_3 = val_3 + 1;
        }
        while(val_3 < input.m_stringLength);
        
        }
    
    }
    private string ToGetParams(System.Collections.Generic.Dictionary<string, string> parameters)
    {
        var val_4;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_6;
        if(parameters == null)
        {
                return (string)System.String.alignConst;
        }
        
        val_4 = null;
        val_4 = null;
        val_6 = WGScreenshotter.<>c.<>9__9_0;
        if(val_6 != null)
        {
                return System.String.Join(separator:  "&", value:  System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String>(source:  parameters, selector:  System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_1 = null)));
        }
        
        val_6 = val_1;
        val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String>(object:  WGScreenshotter.<>c.__il2cppRuntimeField_static_fields, method:  System.String WGScreenshotter.<>c::<ToGetParams>b__9_0(System.Collections.Generic.KeyValuePair<string, string> kvp));
        WGScreenshotter.<>c.<>9__9_0 = val_6;
        return System.String.Join(separator:  "&", value:  System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String>(source:  parameters, selector:  val_1)));
    }
    public static string get_urlShare()
    {
        string val_9;
        AppConfigs val_1 = App.Configuration;
        val_9 = val_1.gameConfig.recommenderUrl;
        AppConfigs val_2 = App.Configuration;
        if(val_2.appConfig.IsProduction() != true)
        {
                char[] val_4 = new char[1];
            val_4[0] = '.';
            System.String[] val_5 = val_9.Split(separator:  val_4);
            val_5[0] = System.String.Format(format:  "{0}-stage", arg0:  val_5[0]);
            val_9 = System.String.Join(separator:  ".", value:  val_5);
        }
        
        GameBehavior val_8 = App.getBehavior;
        return System.String.Format(format:  val_8.<metaGameBehavior>k__BackingField, arg0:  val_9);
    }
    public WGScreenshotter()
    {
    
    }

}
