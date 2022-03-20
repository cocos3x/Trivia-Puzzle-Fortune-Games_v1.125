using UnityEngine;
public class WGPortraitDataController : MonoSingleton<WGPortraitDataController>
{
    // Fields
    private const string COLLECTION_KEY = "Portrait_Collection";
    public PortraitCollectionEcon getEcon;
    private System.Collections.Generic.Dictionary<string, object> progressData;
    private bool hasInit;
    
    // Methods
    private void Start()
    {
        this.Init();
    }
    private void Init()
    {
        if(this.hasInit != false)
        {
                return;
        }
        
        if(this.LoadProgressData() != true)
        {
                this.CreateNewProgressData();
        }
        
        this.hasInit = true;
    }
    private bool LoadProgressData()
    {
        string val_10;
        var val_11;
        var val_29;
        object val_31;
        var val_32;
        var val_33;
        if((CPlayerPrefs.HasKey(key:  "Portrait_Collection")) != false)
        {
                if((System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  "Portrait_Collection"))) != true)
        {
                object val_5 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "Portrait_Collection"));
            if(val_5 == null)
        {
                return (bool)val_29;
        }
        
            var val_6 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_5) : 0;
        }
        
        }
        
        label_20:
        val_29 = 0;
        return (bool)val_29;
        label_18:
        if(val_11.MoveNext() == false)
        {
            goto label_15;
        }
        
        WGPortraitDataController.<>c__DisplayClass6_0 val_13 = null;
        val_31 = val_13;
        val_13 = new WGPortraitDataController.<>c__DisplayClass6_0();
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        .key = val_10;
        if(this.getEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Linq.Enumerable.Any<CollectionEcon>(source:  this.getEcon.MyCollections, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  val_13, method:  System.Boolean WGPortraitDataController.<>c__DisplayClass6_0::<LoadProgressData>b__0(CollectionEcon x)))) == true)
        {
            goto label_18;
        }
        
        val_32 = 315;
        goto label_19;
        label_15:
        val_32 = 162;
        label_19:
        val_11.Dispose();
        if(162 == 315)
        {
            goto label_20;
        }
        
        var val_16 = (162 == 162) ? -1 : 0;
        this.progressData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_19 = val_6.Keys.GetEnumerator();
        label_36:
        if(val_11.MoveNext() == false)
        {
            goto label_22;
        }
        
        val_31 = val_10;
        val_33 = val_6.Item[val_31];
        System.Collections.Generic.List<System.String> val_22 = new System.Collections.Generic.List<System.String>();
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_24 = GetEnumerator();
        label_32:
        if(val_11.MoveNext() == false)
        {
            goto label_28;
        }
        
        if(val_10 != 0)
        {
                if(val_10 != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.Add(item:  val_10);
        goto label_32;
        label_28:
        val_33 = 0;
        val_16 = val_16 + 1;
        mem2[0] = 273;
        val_11.Dispose();
        if(val_33 != 0)
        {
                throw val_33;
        }
        
        if(val_16 != 1)
        {
                var val_26 = ((1152921516648743648 + ((0xA2 == 0xA2 ? -1 : 0 + 1)) << 2) == 273) ? 1 : 0;
            val_26 = ((val_16 >= 0) ? 1 : 0) & val_26;
            val_16 = val_16 - val_26;
        }
        
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.Add(key:  val_31, value:  val_22);
        goto label_36;
        label_22:
        var val_28 = val_16 + 1;
        mem2[0] = 313;
        val_11.Dispose();
        return (bool)val_29;
    }
    private void CreateNewProgressData()
    {
        var val_5;
        this.progressData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        List.Enumerator<T> val_2 = this.getEcon.MyCollections.GetEnumerator();
        label_6:
        val_5 = public System.Boolean List.Enumerator<CollectionEcon>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_4 = null;
        val_5 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_4 = new System.Collections.Generic.List<System.String>();
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.Add(key:  11993091, value:  val_4);
        goto label_6;
        label_3:
        0.Dispose();
        this.SaveProgressData();
    }
    private void SaveProgressData()
    {
        CPlayerPrefs.SetString(key:  "Portrait_Collection", val:  MiniJSON.Json.Serialize(obj:  this.progressData));
        CPlayerPrefs.Save();
    }
    public System.Collections.Generic.List<string> GetFullyUnlockedCollections()
    {
        var val_3;
        var val_4;
        System.Collections.Generic.List<CollectionEcon> val_11;
        string val_12;
        if(this.progressData == null)
        {
                this.Init();
        }
        
        System.Collections.Generic.List<System.String> val_1 = null;
        val_12 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_1 = new System.Collections.Generic.List<System.String>();
        if(this.getEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = this.getEcon.MyCollections;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = val_11.GetEnumerator();
        label_19:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_11 = this.progressData;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.ContainsKey(key:  val_3 + 16)) == false)
        {
            goto label_19;
        }
        
        val_11 = this.progressData;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = mem[val_3 + 16];
        val_12 = val_3 + 16;
        object val_7 = val_11.Item[val_12];
        if((val_7 == null) || (null == 0))
        {
            goto label_19;
        }
        
        if((val_3 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_10 = val_3 + 32 + 24;
        if(val_10 < 1)
        {
            goto label_14;
        }
        
        var val_11 = 0;
        val_10 = val_10 & 4294967295;
        var val_8 = (val_3 + 32) + 32;
        label_17:
        if((val_7.Contains(item:  (val_3 + 32 + 32) + 0)) == false)
        {
            goto label_19;
        }
        
        val_11 = val_11 + 1;
        if(val_11 < ((val_3 + 32 + 24) << ))
        {
            goto label_17;
        }
        
        label_14:
        val_1.Add(item:  val_3 + 16);
        goto label_19;
        label_4:
        val_4.Dispose();
        return val_1;
    }
    public System.Collections.Generic.List<string> GetUnlockedPortraitsByCollection(string collection)
    {
        var val_4;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if((this.progressData.ContainsKey(key:  collection)) == false)
        {
                return val_1;
        }
        
        object val_3 = this.progressData.Item[collection];
        val_4 = 0;
        val_1.AddRange(collection:  null);
        return val_1;
    }
    public System.Collections.Generic.List<string> GetPortraitNamesByCollection(string collection)
    {
        .collection = collection;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        if((System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  this.getEcon.MyCollections, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  new WGPortraitDataController.<>c__DisplayClass11_0(), method:  System.Boolean WGPortraitDataController.<>c__DisplayClass11_0::<GetPortraitNamesByCollection>b__0(CollectionEcon x)))) == null)
        {
                return val_2;
        }
        
        val_2.AddRange(collection:  val_4.progressPortraits);
        return val_2;
    }
    public System.Collections.Generic.List<string> GetAllUnlockedPortraits()
    {
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.progressData.Keys.GetEnumerator();
        label_10:
        val_6 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, System.Object>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        val_7 = this.progressData;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_5 = val_7.Item[0];
        val_6 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.AddRange(collection:  null);
        goto label_10;
        label_3:
        0.Dispose();
        return val_1;
    }
    public bool IsCollectionFullyUnlocked(string collection)
    {
        string val_7;
        var val_8;
        val_7 = collection;
        .collection = val_7;
        if((this.progressData.ContainsKey(key:  val_7)) != false)
        {
                System.Collections.Generic.List<System.String> val_3 = this.GetUnlockedPortraitsByCollection(collection:  (WGPortraitDataController.<>c__DisplayClass13_0)[1152921516650032656].collection);
            System.Func<CollectionEcon, System.Boolean> val_4 = null;
            val_7 = val_4;
            val_4 = new System.Func<CollectionEcon, System.Boolean>(object:  new WGPortraitDataController.<>c__DisplayClass13_0(), method:  System.Boolean WGPortraitDataController.<>c__DisplayClass13_0::<IsCollectionFullyUnlocked>b__0(CollectionEcon x));
            CollectionEcon val_5 = System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  this.getEcon.MyCollections, predicate:  val_4);
            var val_6 = (W22 >= val_5.progressPortraits.Length) ? 1 : 0;
            return (bool)val_8;
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    public void UnlockNextPortraitInCollection(string collection)
    {
        string val_9 = collection;
        .collection = val_9;
        if((this.progressData.ContainsKey(key:  val_9 = collection)) == false)
        {
                return;
        }
        
        val_9 = this.getEcon.MyCollections;
        if((System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  val_9, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  new WGPortraitDataController.<>c__DisplayClass14_0(), method:  System.Boolean WGPortraitDataController.<>c__DisplayClass14_0::<UnlockNextPortraitInCollection>b__0(CollectionEcon x)))) == null)
        {
                return;
        }
        
        val_9 = this.GetUnlockedPortraitsByCollection(collection:  (WGPortraitDataController.<>c__DisplayClass14_0)[1152921516650317952].collection);
        if(1152921516610876880 >= val_4.progressPortraits.Length)
        {
                return;
        }
        
        val_9.Add(item:  val_4.progressPortraits[1152921516610876880]);
        this.progressData.set_Item(key:  (WGPortraitDataController.<>c__DisplayClass14_0)[1152921516650317952].collection, value:  val_9);
        this.SaveProgressData();
        val_9 = 1152921504884269056;
        App.Player.TrackNonCoinReward(source:  "Portrait Complete", subSource:  0, rewardType:  0, rewardAmount:  0, additionalParams:  0);
        if((this.IsCollectionFullyUnlocked(collection:  (WGPortraitDataController.<>c__DisplayClass14_0)[1152921516650317952].collection)) == false)
        {
                return;
        }
        
        App.Player.TrackNonCoinReward(source:  "Portrait Collection Complete", subSource:  0, rewardType:  0, rewardAmount:  0, additionalParams:  0);
    }
    public WGPortraitDataController()
    {
    
    }

}
