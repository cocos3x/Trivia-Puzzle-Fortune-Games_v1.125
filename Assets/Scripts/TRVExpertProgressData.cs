using UnityEngine;
public class TRVExpertProgressData
{
    // Fields
    private string <name>k__BackingField;
    private int <cardsOwned>k__BackingField;
    private System.DateTime <lastHelpUsed>k__BackingField;
    private System.Collections.Generic.List<TRVCategoryProficiencies> <proficiencies>k__BackingField;
    private bool <unlocked>k__BackingField;
    
    // Properties
    public string name { get; set; }
    public int cardsOwned { get; set; }
    public System.DateTime lastHelpUsed { get; set; }
    public System.Collections.Generic.List<TRVCategoryProficiencies> proficiencies { get; set; }
    public bool unlocked { get; set; }
    public int level { get; }
    public int maxLevel { get; }
    
    // Methods
    public string get_name()
    {
        return (string)this.<name>k__BackingField;
    }
    private void set_name(string value)
    {
        this.<name>k__BackingField = value;
    }
    public int get_cardsOwned()
    {
        return (int)this.<cardsOwned>k__BackingField;
    }
    public void set_cardsOwned(int value)
    {
        this.<cardsOwned>k__BackingField = value;
    }
    public System.DateTime get_lastHelpUsed()
    {
        return (System.DateTime)this.<lastHelpUsed>k__BackingField;
    }
    public void set_lastHelpUsed(System.DateTime value)
    {
        this.<lastHelpUsed>k__BackingField = value;
    }
    public System.Collections.Generic.List<TRVCategoryProficiencies> get_proficiencies()
    {
        return (System.Collections.Generic.List<TRVCategoryProficiencies>)this.<proficiencies>k__BackingField;
    }
    private void set_proficiencies(System.Collections.Generic.List<TRVCategoryProficiencies> value)
    {
        this.<proficiencies>k__BackingField = value;
    }
    public bool get_unlocked()
    {
        return (bool)this.<unlocked>k__BackingField;
    }
    private void set_unlocked(bool value)
    {
        this.<unlocked>k__BackingField = value;
    }
    public int get_level()
    {
        var val_3;
        if(((this.<proficiencies>k__BackingField) == null) || (true == 0))
        {
            goto label_2;
        }
        
        List.Enumerator<T> val_1 = this.<proficiencies>k__BackingField.GetEnumerator();
        val_3 = 0;
        goto label_3;
        label_5:
        val_3 = 64;
        label_3:
        if(0.MoveNext() == true)
        {
            goto label_5;
        }
        
        0.Dispose();
        return (int)val_3;
        label_2:
        UnityEngine.Debug.LogError(message:  "trying to get the level of a master with no proficiencies");
        val_3 = 0;
        return (int)val_3;
    }
    public int get_maxLevel()
    {
        var val_3;
        if(((this.<proficiencies>k__BackingField) == null) || (true == 0))
        {
            goto label_2;
        }
        
        List.Enumerator<T> val_1 = this.<proficiencies>k__BackingField.GetEnumerator();
        val_3 = 0;
        goto label_3;
        label_5:
        val_3 = 0;
        label_3:
        if(0.MoveNext() == true)
        {
            goto label_5;
        }
        
        0.Dispose();
        return (int)val_3;
        label_2:
        UnityEngine.Debug.LogError(message:  "trying to get the level of a master with no proficiencies");
        val_3 = 0;
        return (int)val_3;
    }
    public void SetupNewExpert(TRVExpert me, bool autoUnlock = False)
    {
        var val_5;
        this.<cardsOwned>k__BackingField = 0;
        this.<name>k__BackingField = me.expertName;
        val_5 = null;
        val_5 = null;
        this.<lastHelpUsed>k__BackingField = System.DateTime.MinValue;
        this.<proficiencies>k__BackingField = new System.Collections.Generic.List<TRVCategoryProficiencies>();
        List.Enumerator<T> val_2 = me.myProfs.GetEnumerator();
        goto label_5;
        label_7:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[32] = 9733424;
        label_5:
        if(0.MoveNext() == true)
        {
            goto label_7;
        }
        
        0.Dispose();
        this.<proficiencies>k__BackingField.AddRange(collection:  me.myProfs);
        this.<unlocked>k__BackingField = autoUnlock;
    }
    public void UpgradeExpert()
    {
        var val_5;
        var val_6;
        System.Func<TRVCategoryProficiencies, System.Boolean> val_8;
        int val_9;
        int val_10;
        if((this.<unlocked>k__BackingField) != false)
        {
                System.Collections.Generic.List<TRVCategoryProficiencies> val_1 = null;
            val_5 = val_1;
            val_1 = new System.Collections.Generic.List<TRVCategoryProficiencies>();
            val_6 = null;
            val_6 = null;
            val_8 = TRVExpertProgressData.<>c.<>9__25_0;
            if(val_8 == null)
        {
                System.Func<TRVCategoryProficiencies, System.Boolean> val_2 = null;
            val_8 = val_2;
            val_2 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  TRVExpertProgressData.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVExpertProgressData.<>c::<UpgradeExpert>b__25_0(TRVCategoryProficiencies x));
            TRVExpertProgressData.<>c.<>9__25_0 = val_8;
        }
        
            System.Collections.Generic.IEnumerable<TSource> val_3 = System.Linq.Enumerable.Where<TRVCategoryProficiencies>(source:  this.<proficiencies>k__BackingField, predicate:  val_2);
            var val_5 = 1152921517163725168;
            val_1.AddRange(collection:  val_3);
            int val_4 = UnityEngine.Random.Range(min:  0, max:  val_3);
            if(val_5 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + (val_4 << 3);
            val_9 = ((1152921517163725168 + (val_4) << 3) + 32) + 32;
            val_10 = 1;
        }
        else
        {
                val_9 = this.<cardsOwned>k__BackingField;
            this.<unlocked>k__BackingField = true;
            val_10 = 0;
        }
        
        val_10 = val_9 + val_10;
        mem2[0] = val_10;
    }
    public bool AdviceAvailable()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.<lastHelpUsed>k__BackingField});
        int val_6 = (MonoSingleton<TRVExpertsController>.Instance.getExpertCooldown) * 3600;
        return (bool)(val_2._ticks.TotalSeconds < 0) ? 1 : 0;
    }
    public void Deserialize(object incData)
    {
        string val_21;
        var val_22;
        string val_27;
        string val_28;
        val_27 = incData;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_1 = MiniJSON.Json.Deserialize(json:  val_27);
        if(val_1 != null)
        {
                val_27 = val_1;
        }
        
        UnityEngine.Debug.LogError(message:  "no valid persistant data");
        return;
        label_37:
        if(val_22.MoveNext() == false)
        {
            goto label_31;
        }
        
        val_27 = val_21;
        if(val_27 != 0)
        {
                val_28 = null;
            if(val_27 != val_28)
        {
                throw new NullReferenceException();
        }
        
        }
        
        TRVCategoryProficiencies val_24 = null;
        val_28 = 0;
        val_24 = new TRVCategoryProficiencies();
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_24.Deserialize(data:  val_27)) == false)
        {
            goto label_37;
        }
        
        this.<proficiencies>k__BackingField.Add(item:  val_24);
        goto label_37;
        label_31:
        val_22.Dispose();
    }
    public string Serialize()
    {
        string val_8;
        var val_9;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "n", value:  this.<name>k__BackingField);
        val_1.Add(key:  "ul", value:  this.<unlocked>k__BackingField);
        val_1.Add(key:  "co", value:  this.<cardsOwned>k__BackingField);
        val_1.Add(key:  "lh", value:  this.<lastHelpUsed>k__BackingField.ToString());
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_4 = this.<proficiencies>k__BackingField.GetEnumerator();
        label_6:
        val_8 = public System.Boolean List.Enumerator<TRVCategoryProficiencies>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        val_9 = 0;
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_8 = val_9.Serialize();
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  val_8);
        goto label_6;
        label_3:
        0.Dispose();
        val_1.Add(key:  "pf", value:  val_3);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public TRVExpertProgressData()
    {
    
    }

}
