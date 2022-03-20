using UnityEngine;
public class TRVUtils : MonoSingleton<TRVUtils>
{
    // Fields
    private TRVIconConfig config;
    private System.Collections.Generic.Dictionary<string, UnityEngine.Sprite> categoryIconData;
    private System.Collections.Generic.Dictionary<string, UnityEngine.Sprite> eventIconData;
    private bool hasInit;
    
    // Methods
    private void OnEnable()
    {
        this.Init(forceUpdate:  false);
    }
    public void Init(bool forceUpdate = False)
    {
        string val_5;
        var val_6;
        var val_23;
        System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_24;
        string val_25;
        System.Collections.Generic.List<TRVIcon> val_26;
        System.Func<TRVIcon, System.Boolean> val_28;
        if(this.hasInit != false)
        {
                if(forceUpdate == false)
        {
                return;
        }
        
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = MonoSingleton<TRVDataParser>.Instance.getAllSubCategories.Keys.GetEnumerator();
        goto label_15;
        label_24:
        TRVUtils.<>c__DisplayClass5_0 val_7 = null;
        val_25 = 0;
        val_7 = new TRVUtils.<>c__DisplayClass5_0();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .primaryCategory = val_5;
        TRVDataParser val_8 = MonoSingleton<TRVDataParser>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_9 = val_8.getAllSubCategories;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = (TRVUtils.<>c__DisplayClass5_0)[1152921517358776352].primaryCategory;
        if(val_9.Item[val_25] == null)
        {
                throw new NullReferenceException();
        }
        
        if(1152921516945296096 < 1)
        {
            goto label_15;
        }
        
        var val_22 = 0;
        label_23:
        TRVUtils.<>c__DisplayClass5_1 val_11 = null;
        val_25 = 0;
        val_11 = new TRVUtils.<>c__DisplayClass5_1();
        if(val_22 >= 1152921504963768320)
        {
                val_24 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        .cat = null;
        if(this.config == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = this.config.icons;
        System.Func<TRVIcon, System.Boolean> val_12 = new System.Func<TRVIcon, System.Boolean>(object:  val_11, method:  System.Boolean TRVUtils.<>c__DisplayClass5_1::<Init>b__0(TRVIconConfig.TRVIcon x));
        val_25 = val_12;
        if((System.Linq.Enumerable.FirstOrDefault<TRVIcon>(source:  val_26, predicate:  val_12)) != null)
        {
            goto label_19;
        }
        
        if(this.config == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = (TRVUtils.<>c__DisplayClass5_0)[1152921517358776352].<>9__1;
        val_26 = this.config.icons;
        if(val_28 == null)
        {
                System.Func<TRVIcon, System.Boolean> val_14 = null;
            val_28 = val_14;
            val_14 = new System.Func<TRVIcon, System.Boolean>(object:  val_7, method:  System.Boolean TRVUtils.<>c__DisplayClass5_0::<Init>b__1(TRVIconConfig.TRVIcon x));
            .<>9__1 = val_28;
        }
        
        if((System.Linq.Enumerable.FirstOrDefault<TRVIcon>(source:  val_26, predicate:  val_14)) == null)
        {
            goto label_22;
        }
        
        label_19:
        EnumerableExtentions.SetOrAdd<System.String, UnityEngine.Sprite>(dic:  this.categoryIconData, key:  (TRVUtils.<>c__DisplayClass5_1)[1152921517358796832].cat, newValue:  val_15.sprite);
        label_22:
        val_22 = val_22 + 1;
        if(val_22 < this.categoryIconData)
        {
            goto label_23;
        }
        
        label_15:
        if(val_6.MoveNext() == true)
        {
            goto label_24;
        }
        
        val_6.Dispose();
        List.Enumerator<T> val_17 = this.config.specialCats.GetEnumerator();
        val_23 = 1152921517358685536;
        label_31:
        val_25 = public System.Boolean List.Enumerator<TRVIcon>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_27;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_24 = this.categoryIconData;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_24.ContainsKey(key:  val_5 + 16)) == true)
        {
            goto label_31;
        }
        
        EnumerableExtentions.SetOrAdd<System.String, UnityEngine.Sprite>(dic:  this.categoryIconData, key:  val_5 + 16, newValue:  val_5 + 32);
        goto label_31;
        label_27:
        val_6.Dispose();
        List.Enumerator<T> val_20 = this.config.eventIcons.GetEnumerator();
        label_36:
        val_25 = public System.Boolean List.Enumerator<TRVIcon>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_34;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        EnumerableExtentions.SetOrAdd<System.String, UnityEngine.Sprite>(dic:  this.eventIconData, key:  val_5 + 16, newValue:  val_5 + 32);
        goto label_36;
        label_34:
        val_6.Dispose();
        this.hasInit = true;
    }
    public UnityEngine.Sprite GetCategoryIcon(string category)
    {
        var val_6;
        if(this.hasInit != true)
        {
                this.Init(forceUpdate:  false);
        }
        
        if((this.categoryIconData.ContainsKey(key:  category)) != false)
        {
                UnityEngine.Sprite val_2 = this.categoryIconData.Item[category];
            return (UnityEngine.Sprite)val_6;
        }
        
        if((MonoSingleton<TRVSpecialCategoriesManager>.Instance.IsPromoCategory(subCategoryName:  category)) != false)
        {
                return MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetPromoSprite(subCategoryName:  category);
        }
        
        val_6 = 0;
        return (UnityEngine.Sprite)val_6;
    }
    public UnityEngine.Sprite GetEventIcon(WGEventHandler eventHandler)
    {
        var val_3;
        if(this.hasInit == false)
        {
            goto label_1;
        }
        
        if(eventHandler != null)
        {
            goto label_2;
        }
        
        goto label_6;
        label_1:
        this.Init(forceUpdate:  false);
        if(eventHandler == null)
        {
            goto label_6;
        }
        
        label_2:
        if((this.eventIconData.ContainsKey(key:  eventHandler)) != false)
        {
                UnityEngine.Sprite val_2 = this.eventIconData.Item[eventHandler];
            return (UnityEngine.Sprite)val_3;
        }
        
        label_6:
        val_3 = 0;
        return (UnityEngine.Sprite)val_3;
    }
    public string GetEnglishIconNameForCategory(string cat)
    {
        TRVUtils.<>c__DisplayClass8_0 val_1 = new TRVUtils.<>c__DisplayClass8_0();
        .cat = cat;
        TRVIcon val_3 = System.Linq.Enumerable.FirstOrDefault<TRVIcon>(source:  this.config.icons, predicate:  new System.Func<TRVIcon, System.Boolean>(object:  val_1, method:  System.Boolean TRVUtils.<>c__DisplayClass8_0::<GetEnglishIconNameForCategory>b__0(TRVIconConfig.TRVIcon x)));
        var val_4 = (val_3 == 0) ? (val_1) : (val_3);
        return (string)val_3 == null ? val_1 : val_3 + 16;
    }
    public TRVUtils()
    {
        this.categoryIconData = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite>();
        this.eventIconData = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite>();
    }

}
