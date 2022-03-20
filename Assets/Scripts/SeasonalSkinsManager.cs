using UnityEngine;
public class SeasonalSkinsManager : MonoSingleton<SeasonalSkinsManager>
{
    // Fields
    private System.Collections.Generic.Dictionary<SeasonSkinnedFeature, System.Collections.Generic.List<SeasonalSkin>> parsedSkinsForFeatures;
    
    // Methods
    public UnityEngine.Texture GetTexture(string assetName)
    {
        var val_3 = 0;
        if((twelvegigs.net.ImageRequest.ImageInLocal(imgPath:  assetName)) == false)
        {
                return (UnityEngine.Texture)twelvegigs.net.ImageRequest.LoadLocally(remoteURL:  0, fileName:  assetName);
        }
        
        return (UnityEngine.Texture)twelvegigs.net.ImageRequest.LoadLocally(remoteURL:  0, fileName:  assetName);
    }
    public SeasonalSkin IsSkinActive(SeasonSkinnedFeature feature)
    {
        var val_6;
        if((this.parsedSkinsForFeatures.ContainsKey(key:  feature)) == false)
        {
            goto label_2;
        }
        
        List.Enumerator<T> val_3 = this.parsedSkinsForFeatures.Item[feature].GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_5;
        }
        
        val_6 = 0;
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_6.Active() == false)
        {
            goto label_7;
        }
        
        goto label_8;
        label_2:
        val_6 = 0;
        return (SeasonalSkin)val_6;
        label_5:
        val_6 = 0;
        label_8:
        0.Dispose();
        return (SeasonalSkin)val_6;
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void SeasonalSkinsManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode modo)));
        this.ParseKnobs();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode modo)
    {
        this.ParseKnobs();
    }
    private void ParseKnobs()
    {
        string val_6;
        var val_8;
        var val_38;
        var val_39;
        SeasonalSkin val_41;
        var val_43;
        var val_46;
        System.Collections.Generic.Dictionary<TKey, TValue> val_47;
        val_38 = 1152921504884269056;
        val_39 = null;
        val_39 = null;
        twelvegigs.storage.JsonDictionary val_1 = getWordGameplayKnobs();
        if(val_1 == null)
        {
                return;
        }
        
        val_38 = "se_skin";
        if((val_1.Contains(key:  "se_skin")) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<SeasonSkinnedFeature, System.Collections.Generic.List<SeasonalSkin>> val_3 = new System.Collections.Generic.Dictionary<SeasonSkinnedFeature, System.Collections.Generic.List<SeasonalSkin>>();
        mem[1152921516702415880] = val_3;
        Dictionary.Enumerator<TKey, TValue> val_5 = val_1.getDictionary(key:  "se_skin").GetEnumerator();
        val_38 = 1152921510211410768;
        var val_40 = 0;
        label_55:
        bool val_9 = val_8.MoveNext();
        if(val_9 == false)
        {
            goto label_11;
        }
        
        val_41 = val_6;
        System.Collections.Generic.List<SeasonalSkin> val_11 = new System.Collections.Generic.List<SeasonalSkin>();
        if(val_41 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_13 = GetEnumerator();
        label_45:
        if(val_8.MoveNext() == false)
        {
            goto label_17;
        }
        
        val_43 = 0;
        SeasonalSkin val_16 = null;
        val_41 = val_16;
        val_16 = new SeasonalSkin();
        object val_17 = Item["d"];
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        .durationInDays = System.Int32.Parse(s:  val_17, style:  511);
        object val_19 = Item["sd"];
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        char[] val_20 = new char[1];
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_20.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_20[0] = '/';
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        System.String[] val_21 = val_19.Split(separator:  val_20);
        System.DateTime val_22 = DateTimeCheat.Now;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_21.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        System.DateTime val_26 = new System.DateTime(year:  val_22.dateData.Year, month:  System.Int32.Parse(s:  val_21[0], style:  511), day:  System.Int32.Parse(s:  val_21[1], style:  511));
        .activeDate = val_26.dateData;
        object val_27 = Item["h"];
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        .assetNameHead = val_27;
        if(Item["i"] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_30 = GetEnumerator();
        label_41:
        if(val_8.MoveNext() == false)
        {
            goto label_39;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_32 = val_16.GetAssetName(textureId:  val_6);
        val_32.DownloadAsset(assetPath:  val_32);
        goto label_41;
        label_39:
        val_40 = val_40 + 1;
        mem2[0] = 367;
        val_8.Dispose();
        if(0 != 0)
        {
                throw 0;
        }
        
        if(val_40 != 1)
        {
                var val_33 = ((1152921516702403568 + ((0 + 1)) << 2) == 367) ? 1 : 0;
            val_33 = ((val_40 >= 0) ? 1 : 0) & val_33;
            val_40 = val_40 - val_33;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.Add(item:  val_16);
        goto label_45;
        label_17:
        val_40 = val_40 + 1;
        val_41 = 0;
        mem2[0] = 404;
        val_46 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_8.Dispose();
        if(val_41 != 0)
        {
            goto label_52;
        }
        
        if(val_40 != 1)
        {
                var val_35 = ((1152921516702403568 + ((0 + 1)) << 2) == 404) ? 1 : 0;
            val_35 = ((val_40 >= 0) ? 1 : 0) & val_35;
            val_40 = val_40 - val_35;
        }
        
        val_47 = mem[1152921516702415880];
        if(val_47 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3.set_Item(key:  val_9.KnobToFeature(key:  val_6), value:  val_11);
        goto label_55;
        label_11:
        var val_37 = val_40 + 1;
        mem2[0] = 446;
        val_8.Dispose();
        return;
        label_52:
        val_47 = val_41;
        val_46 = 0;
        throw val_47;
    }
    private void DownloadAsset(string assetPath)
    {
        if((twelvegigs.net.ImageRequest.ImageInLocal(imgPath:  assetPath)) != false)
        {
                return;
        }
        
        twelvegigs.net.ImageRequest val_3 = new twelvegigs.net.ImageRequest(url:  System.String.Format(format:  "https://cdn.12gigs.com/se_skins/{0}", arg0:  assetPath), filename:  assetPath, imgComplete:  0, imgError:  0, showErrors:  true, destroy:  false, cached:  true, save:  true);
        goto typeof(twelvegigs.net.ImageRequest).__il2cppRuntimeField_170;
    }
    private SeasonSkinnedFeature KnobToFeature(string key)
    {
        var val_5;
        if((System.String.op_Equality(a:  key, b:  "ac")) != false)
        {
                val_5 = 1;
            return (SeasonSkinnedFeature)val_5;
        }
        
        if((System.String.op_Equality(a:  key, b:  "fm")) == false)
        {
                throw new System.Exception(message:  "SeasonalSkinsManager. Feature: "("SeasonalSkinsManager. Feature: ") + key + " not found.");
        }
        
        val_5 = 2;
        return (SeasonSkinnedFeature)val_5;
    }
    public SeasonalSkinsManager()
    {
        this.parsedSkinsForFeatures = new System.Collections.Generic.Dictionary<SeasonSkinnedFeature, System.Collections.Generic.List<SeasonalSkin>>();
    }

}
