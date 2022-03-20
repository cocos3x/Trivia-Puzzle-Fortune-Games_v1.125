using UnityEngine;
public class TRVExpertsController : MonoSingleton<TRVExpertsController>
{
    // Fields
    private const string expertsDataKey = "ExpertsData";
    private TRVExpertEcon myEcon;
    private bool initd;
    private System.Collections.Generic.Dictionary<string, TRVExpert> expertBaseData;
    private System.Collections.Generic.Dictionary<string, TRVExpertProgressData> myExperts;
    
    // Properties
    public TRVExpertEcon getEcon { get; }
    public System.Collections.Generic.Dictionary<string, TRVExpertProgressData> getProgress { get; }
    
    // Methods
    public TRVExpertEcon get_getEcon()
    {
        return (TRVExpertEcon)this.myEcon;
    }
    public System.Collections.Generic.Dictionary<string, TRVExpertProgressData> get_getProgress()
    {
        return (System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData>)this.myExperts;
    }
    private void Start()
    {
        if(this.initd != false)
        {
                return;
        }
        
        this.LoadData();
        this.initd = true;
    }
    private void Init()
    {
        if(this.initd != false)
        {
                return;
        }
        
        this.LoadData();
        this.initd = true;
    }
    private void LoadData()
    {
        string val_7;
        var val_8;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_16;
        this.myExperts = new System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData>();
        if((CPlayerPrefs.HasKey(key:  "ExpertsData")) == false)
        {
            goto label_30;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "ExpertsData"));
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_6 = val_4.Keys.GetEnumerator();
        label_13:
        if(val_8.MoveNext() == false)
        {
            goto label_10;
        }
        
        TRVExpertProgressData val_10 = new TRVExpertProgressData();
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Deserialize(incData:  val_4.Item[val_7]);
        val_16 = this.myExperts;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16.Add(key:  val_7, value:  val_10);
        goto label_13;
        label_10:
        val_8.Dispose();
        label_30:
        if(this.myExperts != null)
        {
                if(this.myExperts.Count != 0)
        {
                return;
        }
        
        }
        
        List.Enumerator<T> val_13 = this.myEcon.defaultUnlockedExperts.GetEnumerator();
        label_19:
        if(0.MoveNext() == false)
        {
            goto label_18;
        }
        
        this.AddNewExpertProgress(name:  0, save:  false, autoUnlock:  true);
        goto label_19;
        label_18:
        0.Dispose();
        this.SaveData();
    }
    private void SaveData()
    {
        string val_8;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_9;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.myExperts.Keys.GetEnumerator();
        label_7:
        val_8 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, TRVExpertProgressData>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        val_9 = this.myExperts;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8 = 0;
        TRVExpertProgressData val_5 = val_9.Item[val_8];
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  0, value:  val_5.Serialize());
        goto label_7;
        label_3:
        0.Dispose();
        CPlayerPrefs.SetString(key:  "ExpertsData", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
    }
    public void AddNewExpertCard(string name)
    {
        if((this.myExperts.ContainsKey(key:  name)) != true)
        {
                this.AddNewExpertProgress(name:  name, save:  true, autoUnlock:  true);
        }
        
        TRVExpertProgressData val_2 = this.myExperts.Item[name];
        val_2.<cardsOwned>k__BackingField = 0;
        this.SaveData();
    }
    public void AddNewExpertProgress(string name, bool save = True, bool autoUnlock = True)
    {
        string val_6;
        object val_7;
        val_6 = name;
        if((this.myExperts.ContainsKey(key:  val_6)) != false)
        {
                val_7 = "trying to unlock an expert that\'s already unlocked";
        }
        else
        {
                TRVExpert val_2 = this.getExpertBaseData(expertName:  val_6);
            if(val_2 != null)
        {
                TRVExpertProgressData val_3 = new TRVExpertProgressData();
            val_3.SetupNewExpert(me:  val_2, autoUnlock:  autoUnlock);
            this.myExperts.Add(key:  val_6, value:  val_3);
            if(save == false)
        {
                return;
        }
        
            this.SaveData();
            return;
        }
        
            val_6 = "no expert data found for " + val_6;
            val_7 = val_6;
        }
        
        UnityEngine.Debug.LogError(message:  val_7);
    }
    public System.Collections.Generic.List<TRVExpert> DetermineExpertCards(GiftRewardSource source, out bool expertNowReadyToUpgrade, int cardsToPull = 0)
    {
        int val_3;
        var val_4;
        var val_45;
        TRVExpertsController val_46;
        TRVExpertEcon val_47;
        string val_48;
        TRVExpertEcon val_49;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_50;
        int val_51;
        System.Collections.Generic.List<T> val_52;
        var val_53;
        System.Func<TRVExpert, System.Boolean> val_54;
        var val_55;
        val_45 = source;
        val_46 = this;
        mem2[0] = 0;
        if(val_45 <= 2)
        {
            goto label_1;
        }
        
        if(val_45 == 3)
        {
            goto label_2;
        }
        
        if(val_45 == 12)
        {
            goto label_3;
        }
        
        if(val_45 != 13)
        {
            goto label_8;
        }
        
        val_47 = this.myEcon;
        val_48 = "Chapter Rewards Rewarded Video";
        goto label_14;
        label_1:
        if(val_45 == 0)
        {
            goto label_7;
        }
        
        if(val_45 != 1)
        {
            goto label_8;
        }
        
        val_49 = this.myEcon;
        val_48 = "Daily Bonus Rewarded Video";
        goto label_10;
        label_2:
        val_47 = this.myEcon;
        val_48 = "Chapter Rewards";
        goto label_14;
        label_3:
        val_47 = this.myEcon;
        val_48 = "Tournament Reward";
        goto label_14;
        label_7:
        val_49 = this.myEcon;
        val_48 = "Daily Bonus";
        label_10:
        val_50 = this.myEcon.DailyBonusCardProbabilities;
        goto label_16;
        label_8:
        val_47 = this.myEcon;
        val_48 = "Default";
        label_14:
        val_50 = this.myEcon.ChapterRewardCardProbabilities;
        label_16:
        if(cardsToPull != 0)
        {
            goto label_94;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.myEcon.ChapterRewardCardProbabilities.SyncRoot.Keys.GetEnumerator();
        goto label_22;
        label_23:
        val_51 = val_3;
        if((UnityEngine.Random.Range(min:  0, max:  100)) < this.myEcon.ChapterRewardCardProbabilities.SyncRoot.Item[val_51])
        {
                int val_42 = cardsToPull;
            val_42 = val_42 + 1;
        }
        
        label_22:
        if(val_4.MoveNext() == true)
        {
            goto label_23;
        }
        
        val_4.Dispose();
        label_94:
        System.Collections.Generic.List<TRVExpert> val_8 = null;
        val_52 = val_8;
        val_8 = new System.Collections.Generic.List<TRVExpert>();
        if(val_42 < 1)
        {
            goto label_67;
        }
        
        val_45 = 1152921517158280752;
        val_51 = val_8.getCardRarityProbabilities;
        var val_43 = 0;
        label_66:
        RandomSet val_11 = new RandomSet();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_13 = val_51.Keys.GetEnumerator();
        label_30:
        if(val_4.MoveNext() == false)
        {
            goto label_28;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.add(item:  val_3, weight:  (float)val_51.Item[val_3]);
        goto label_30;
        label_28:
        val_43 = val_43 + 1;
        mem2[0] = 339;
        val_4.Dispose();
        if(val_43 == 1)
        {
            goto label_31;
        }
        
        var val_16 = ((-333379616 + ((0 + 1)) << 2) == 339) ? 1 : 0;
        val_16 = ((val_43 >= 0) ? 1 : 0) & val_16;
        val_53 = val_43 - val_16;
        if(val_11 != null)
        {
            goto label_32;
        }
        
        label_31:
        val_53 = 0;
        label_32:
        .chosenRarity = val_11.roll(unweighted:  false);
        System.Collections.Generic.List<TRVExpert> val_19 = null;
        val_46 = val_19;
        val_19 = new System.Collections.Generic.List<TRVExpert>();
        List.Enumerator<T> val_20 = this.myEcon.econs.GetEnumerator();
        label_42:
        if(val_4.MoveNext() == false)
        {
            goto label_38;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_54 = (TRVExpertsController.<>c__DisplayClass15_0)[1152921517158462640].<>9__0;
        if(val_54 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_22 = null;
            val_54 = val_22;
            val_22 = new System.Func<TRVExpert, System.Boolean>(object:  new TRVExpertsController.<>c__DisplayClass15_0(), method:  System.Boolean TRVExpertsController.<>c__DisplayClass15_0::<DetermineExpertCards>b__0(TRVExpert x));
            .<>9__0 = val_54;
        }
        
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19.AddRange(collection:  System.Linq.Enumerable.Where<TRVExpert>(source:  val_3 + 24, predicate:  val_22));
        goto label_42;
        label_38:
        val_53 = val_53 + 1;
        var val_44 = -333379616;
        mem2[0] = 470;
        val_4.Dispose();
        if(val_53 == 1)
        {
            goto label_43;
        }
        
        var val_24 = ((-333379616 + ((val_53 + 1)) << 2) == 470) ? 1 : 0;
        val_24 = ((val_53 >= 0) ? 1 : 0) & val_24;
        val_55 = val_53 - val_24;
        if(val_46 != null)
        {
            goto label_44;
        }
        
        label_43:
        val_55 = 0;
        label_44:
        int val_26 = UnityEngine.Random.Range(min:  0, max:  -337721632);
        if(val_44 <= val_26)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_44 = val_44 + (val_26 << 3);
        if((mem[1152921517158381600].ContainsKey(key:  (-333379616 + (val_26) << 3) + 32 + 16)) == false)
        {
            goto label_50;
        }
        
        if((mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16].level) != (mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16].maxLevel))
        {
                if(expertNowReadyToUpgrade == 0)
        {
            goto label_56;
        }
        
        }
        
        val_46 = 0;
        label_73:
        TRVExpertProgressData val_32 = mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16];
        int val_45 = val_32.<cardsOwned>k__BackingField;
        val_45 = val_45 + 1;
        val_32.<cardsOwned>k__BackingField = val_45;
        if(val_46 == 0)
        {
            goto label_64;
        }
        
        var val_33 = (expertNowReadyToUpgrade != 0) ? 1 : 0;
        val_33 = 0 | val_33;
        if((val_33 & 1) != 0)
        {
            goto label_64;
        }
        
        TRVExpertProgressData val_34 = mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16];
        if((val_34.<cardsOwned>k__BackingField) < 1)
        {
            goto label_64;
        }
        
        mem2[0] = 1;
        goto label_64;
        label_50:
        this.AddNewExpertProgress(name:  (-333379616 + (val_26) << 3) + 32 + 16, save:  false, autoUnlock:  true);
        label_64:
        val_52 = val_52;
        val_8.Add(item:  (-333379616 + (val_26) << 3) + 32);
        if(1 < val_42)
        {
            goto label_66;
        }
        
        goto label_67;
        label_56:
        ExpertLevelReq val_36 = val_47.getReqFromExpert(exp:  (-333379616 + (val_26) << 3) + 32, prog:  mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16]);
        TRVExpertProgressData val_37 = mem[1152921517158381600].Item[(-333379616 + (val_26) << 3) + 32 + 16];
        var val_38 = ((val_37.<cardsOwned>k__BackingField) >= val_36.cardsNeeded) ? 1 : 0;
        goto label_73;
        label_67:
        this.SaveData();
        App.Player.TrackNonCoinReward(source:  val_48, subSource:  0, rewardType:  "Card", rewardAmount:  val_42.ToString(), additionalParams:  0);
        return (System.Collections.Generic.List<TRVExpert>)val_53;
    }
    public bool UpgradeExpert(string name)
    {
        object val_18;
        System.Collections.Generic.List<ExpertCardEcon> val_19;
        var val_20;
        int val_21;
        var val_22;
        var val_23;
        object val_24;
        int val_25;
        val_18 = this;
        .upgradingExpert = this.getExpertBaseData(expertName:  name);
        val_19 = this.myEcon.expertLevelUpEcon;
        val_20 = System.Linq.Enumerable.FirstOrDefault<ExpertCardEcon>(source:  val_19, predicate:  new System.Func<ExpertCardEcon, System.Boolean>(object:  new TRVExpertsController.<>c__DisplayClass16_0(), method:  System.Boolean TRVExpertsController.<>c__DisplayClass16_0::<UpgradeExpert>b__0(ExpertCardEcon x)));
        if((this.myExperts.ContainsKey(key:  name)) == false)
        {
            goto label_4;
        }
        
        if(val_20 == null)
        {
            goto label_6;
        }
        
        val_19 = this.myExperts.Item[name];
        val_20 = this.myEcon.getReqFromExpert(exp:  (TRVExpertsController.<>c__DisplayClass16_0)[1152921517158761104].upgradingExpert, prog:  val_19);
        if((val_6.<cardsOwned>k__BackingField) < val_7.cardsNeeded)
        {
            goto label_16;
        }
        
        Player val_8 = App.Player;
        val_21 = val_7.coinsNeeded;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_21);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_8._credits, hi = val_8._credits, lo = -332987760, mid = 268435458}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid})) == false)
        {
            goto label_16;
        }
        
        int val_18 = val_6.<cardsOwned>k__BackingField;
        val_18 = val_18 - val_7.cardsNeeded;
        val_6.<cardsOwned>k__BackingField = val_18;
        if(val_7.coinsNeeded >= 1)
        {
                decimal val_12 = System.Decimal.op_Implicit(value:  -val_7.coinsNeeded);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, source:  "ExpertUpgrade", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_21 = 1152921504619999232;
        val_13.Add(key:  "Cards Spent", value:  val_7.cardsNeeded);
        val_13.Add(key:  "Current Card Balance", value:  val_6.<cardsOwned>k__BackingField);
        int val_19 = val_6.<cardsOwned>k__BackingField;
        val_19 = val_7.cardsNeeded + val_19;
        val_13.Add(key:  "Previous Card Balance", value:  val_19);
        val_13.Add(key:  "Expert", value:  name);
        val_13.Add(key:  "Expert Level", value:  val_19.level + 1);
        bool val_20 = val_6.<unlocked>k__BackingField;
        val_20 = val_20 ^ 1;
        val_13.Add(key:  "Expert Unlocked", value:  val_20);
        val_13.Add(key:  "Expert Upgraded", value:  val_6.<unlocked>k__BackingField);
        val_22 = null;
        val_22 = null;
        val_20 = 1152921504883736576;
        App.trackerManager.track(eventName:  Events.CARDS_SPENT, data:  val_13);
        val_19.UpgradeExpert();
        this.SaveData();
        val_23 = 1;
        return (bool)val_23;
        label_4:
        val_24 = "can\'t ugprade if we don\'t have data";
        goto label_35;
        label_6:
        object[] val_16 = new object[4];
        val_19 = "issue finding rarity econ for ";
        val_25 = val_16.Length;
        val_16[0] = "issue finding rarity econ for ";
        if(name != null)
        {
                val_25 = val_16.Length;
        }
        
        val_16[1] = name;
        val_25 = val_16.Length;
        val_16[2] = " rarity : ";
        val_16[3] = (TRVExpertsController.<>c__DisplayClass16_0)[1152921517158761104].upgradingExpert.rarity;
        val_18 = +val_16;
        val_24 = val_18;
        label_35:
        UnityEngine.Debug.LogError(message:  val_24);
        label_16:
        val_23 = 0;
        return (bool)val_23;
    }
    public TRVExpert getExpertBaseData(string expertName)
    {
        TRVExpert val_3;
        var val_4;
        object val_12;
        string val_13;
        System.Collections.Generic.Dictionary<System.String, TRVExpert> val_14;
        System.Collections.Generic.Dictionary<System.String, TRVExpert> val_15;
        var val_18;
        val_13 = expertName;
        val_14 = this.expertBaseData;
        if(val_14 != null)
        {
            goto label_1;
        }
        
        System.Collections.Generic.Dictionary<System.String, TRVExpert> val_1 = null;
        val_15 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, TRVExpert>();
        this.expertBaseData = val_15;
        List.Enumerator<T> val_2 = this.myEcon.econs.GetEnumerator();
        val_12 = 1152921517137357856;
        label_14:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 24) == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_6 = val_3 + 24.GetEnumerator();
        label_10:
        if(val_4.MoveNext() == false)
        {
            goto label_7;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(this.expertBaseData == null)
        {
                throw new NullReferenceException();
        }
        
        this.expertBaseData.Add(key:  val_3 + 16, value:  val_3);
        goto label_10;
        label_7:
        var val_8 = 0 + 1;
        val_15 = 0;
        mem2[0] = 109;
        val_4.Dispose();
        if(val_15 != 0)
        {
                throw val_15;
        }
        
        if((val_8 == 1) || ((1152921517158978544 + ((0 + 1)) << 2) != 109))
        {
            goto label_14;
        }
        
        var val_14 = 0;
        val_14 = val_14 ^ (val_8 >> 31);
        var val_9 = val_8 + val_14;
        goto label_14;
        label_4:
        var val_10 = 0 + 1;
        mem2[0] = 134;
        val_4.Dispose();
        val_14 = this.expertBaseData;
        val_13 = val_13;
        label_1:
        if((val_14.ContainsKey(key:  val_13)) != false)
        {
                TRVExpert val_12 = this.expertBaseData.Item[val_13];
            return (TRVExpert)val_18;
        }
        
        val_12 = "unable to find expert " + val_13;
        UnityEngine.Debug.LogError(message:  val_12);
        val_18 = 0;
        return (TRVExpert)val_18;
    }
    public bool AskExpert(TRVExpert exp, string subCat, out TRVExpertOutcomes result)
    {
        TRVExpertOutcomes val_12;
        int val_13;
        string val_25;
        object val_26;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_27;
        string val_28;
        var val_29;
        System.Func<TSource, System.Boolean> val_30;
        object val_31;
        var val_33;
        val_25 = subCat;
        val_26 = this;
        TRVExpertsController.<>c__DisplayClass18_0 val_1 = null;
        val_28 = 0;
        val_1 = new TRVExpertsController.<>c__DisplayClass18_0();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .subCat = val_25;
        result = 0;
        if(exp == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = this.myExperts;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = exp.expertName;
        if((val_27.ContainsKey(key:  val_28)) == false)
        {
            goto label_4;
        }
        
        val_27 = this.myExperts;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = exp.expertName;
        TRVExpertProgressData val_3 = val_27.Item[val_28];
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29 = 1152921504614567936;
        val_25 = val_3;
        System.Func<TRVCategoryProficiencies, System.Boolean> val_4 = null;
        val_30 = val_4;
        val_4 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  val_1, method:  System.Boolean TRVExpertsController.<>c__DisplayClass18_0::<AskExpert>b__0(TRVCategoryProficiencies x));
        if((System.Linq.Enumerable.Any<TRVCategoryProficiencies>(source:  val_3.<proficiencies>k__BackingField, predicate:  val_4)) == false)
        {
            goto label_7;
        }
        
        val_25 = val_3.<proficiencies>k__BackingField;
        System.Func<TRVCategoryProficiencies, System.Boolean> val_6 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  val_1, method:  System.Boolean TRVExpertsController.<>c__DisplayClass18_0::<AskExpert>b__1(TRVCategoryProficiencies x));
        val_28 = val_6;
        if((System.Linq.Enumerable.First<TRVCategoryProficiencies>(source:  val_25, predicate:  val_6)) == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_8 = this.myEcon.getOutcomesByLevel(level:  val_7.currentPotential);
        if(val_8 == null)
        {
            goto label_10;
        }
        
        val_25 = val_8;
        RandomSet val_9 = new RandomSet();
        val_28 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_10 = val_25.Keys;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_11 = val_10.GetEnumerator();
        val_30 = 1152921517159198496;
        val_29 = 1152921517159199520;
        label_14:
        if(val_13.MoveNext() == false)
        {
            goto label_12;
        }
        
        val_9.add(item:  val_12, weight:  (float)val_25.Item[val_12]);
        goto label_14;
        label_4:
        val_31 = "failing to get expert progress data, this should never happen";
        goto label_17;
        label_7:
        string val_16 = "broken proficiency data for " + exp.expertName;
        goto label_18;
        label_12:
        val_28 = public System.Void Dictionary.KeyCollection.Enumerator<TRVExpertOutcomes, System.Int32>::Dispose();
        val_13.Dispose();
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = 0;
        result = val_9.roll(unweighted:  false);
        Player val_18 = App.Player;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        if((App.GetGameSpecificEcon<TRVEcon>()) == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = val_19.PowerupData;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = 2;
        if(val_27.Item[val_28] == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_18 == val_20.ftuxLevel)
        {
                result = 2;
        }
        
        val_27 = this.myExperts;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = exp.expertName;
        System.DateTime val_22 = DateTimeCheat.UtcNow;
        if(val_27.Item[val_28] == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.<lastHelpUsed>k__BackingField = val_22;
        this.SaveData();
        val_33 = 1;
        return (bool)val_33;
        label_10:
        val_13 = val_7.currentPotential;
        label_18:
        val_26 = "no econ defined for prof level of " + val_13;
        val_31 = val_26;
        label_17:
        UnityEngine.Debug.LogError(message:  val_31);
        val_33 = 0;
        return (bool)val_33;
    }
    public System.Collections.Generic.List<TRVExpert> GetExpertsWithProf(string subcat)
    {
        System.Collections.Generic.IEnumerable<T> val_7;
        System.Func<TRVExpert, System.Boolean> val_9;
        .subcat = subcat;
        System.Collections.Generic.List<TRVExpert> val_2 = new System.Collections.Generic.List<TRVExpert>();
        List.Enumerator<T> val_3 = this.myEcon.econs.GetEnumerator();
        label_8:
        val_7 = public System.Boolean List.Enumerator<TRVCategoryExpertEcon>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_9 = (TRVExpertsController.<>c__DisplayClass19_0)[1152921517159571696].<>9__0;
        if(val_9 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_5 = null;
            val_9 = val_5;
            val_5 = new System.Func<TRVExpert, System.Boolean>(object:  new TRVExpertsController.<>c__DisplayClass19_0(), method:  System.Boolean TRVExpertsController.<>c__DisplayClass19_0::<GetExpertsWithProf>b__0(TRVExpert x));
            .<>9__0 = val_9;
        }
        
        val_7 = System.Linq.Enumerable.Where<TRVExpert>(source:  9733424, predicate:  val_5);
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.AddRange(collection:  val_7);
        goto label_8;
        label_4:
        0.Dispose();
        return val_2;
    }
    public string GetOverridenCategoryName(string baseName)
    {
        var val_6;
        var val_7;
        System.Func<TRVCategoryProficiencies, System.Int32> val_30;
        string val_31;
        System.Collections.Generic.List<TRVCategoryExpertEcon> val_32;
        var val_33;
        System.Func<TRVExpert, System.Boolean> val_34;
        var val_35;
        var val_37;
        string val_38;
        var val_39;
        string val_40;
        string val_41;
        string val_42;
        string val_43;
        val_30 = this;
        TRVExpertsController.<>c__DisplayClass20_0 val_1 = null;
        val_31 = 0;
        val_1 = new TRVExpertsController.<>c__DisplayClass20_0();
        TRVSpecialCategoriesManager val_2 = MonoSingleton<TRVSpecialCategoriesManager>.Instance;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = baseName;
        string val_3 = val_2.GetExpertForSpecialCategory(subCategory:  val_31);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = 0;
        .expertName = val_3;
        if((System.String.IsNullOrEmpty(value:  val_3)) == true)
        {
            goto label_77;
        }
        
        if(this.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = this.myEcon.econs;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_32.GetEnumerator();
        val_33 = 1152921517154004704;
        label_11:
        val_31 = public System.Boolean List.Enumerator<TRVCategoryExpertEcon>::MoveNext();
        if(val_7.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_34 = (TRVExpertsController.<>c__DisplayClass20_0)[1152921517159791856].<>9__0;
        if(val_34 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_9 = null;
            val_34 = val_9;
            val_9 = new System.Func<TRVExpert, System.Boolean>(object:  val_1, method:  System.Boolean TRVExpertsController.<>c__DisplayClass20_0::<GetOverridenCategoryName>b__0(TRVExpert x));
            .<>9__0 = val_34;
        }
        
        if((System.Linq.Enumerable.FirstOrDefault<TRVExpert>(source:  val_6 + 24, predicate:  val_9)) == null)
        {
            goto label_11;
        }
        
        val_33 = 1152921504952852480;
        val_35 = null;
        val_35 = null;
        val_30 = TRVExpertsController.<>c.<>9__20_1;
        if(val_30 == null)
        {
                System.Func<TRVCategoryProficiencies, System.Int32> val_11 = null;
            val_30 = val_11;
            val_11 = new System.Func<TRVCategoryProficiencies, System.Int32>(object:  TRVExpertsController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVExpertsController.<>c::<GetOverridenCategoryName>b__20_1(TRVCategoryProficiencies x));
            TRVExpertsController.<>c.<>9__20_1 = val_30;
        }
        
        val_31 = public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<TRVCategoryProficiencies>(System.Collections.Generic.IEnumerable<TSource> source);
        if((System.Linq.Enumerable.ToList<TRVCategoryProficiencies>(source:  System.Linq.Enumerable.OrderByDescending<TRVCategoryProficiencies, System.Int32>(source:  val_10.myProfs, keySelector:  val_11))) == null)
        {
                throw new NullReferenceException();
        }
        
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<TRVCategoryProficiencies>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7.Dispose();
        return (string)((System.String.op_Equality(a:  val_38 = val_16, b:  val_40 = "Celebridades Latinoamericanos")) != true) ? (val_39) : (val_37);
        label_8:
        val_31 = public System.Void List.Enumerator<TRVCategoryExpertEcon>::Dispose();
        val_7.Dispose();
        label_77:
        TRVUtils val_14 = MonoSingleton<TRVUtils>.Instance;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = baseName;
        string val_15 = val_14.GetEnglishIconNameForCategory(cat:  val_31);
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = val_15;
        string val_16 = val_15.ToLower();
        uint val_17 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_16);
        if(val_17 > (-1895419107))
        {
            goto label_25;
        }
        
        if(val_17 > 914013912)
        {
            goto label_26;
        }
        
        if(val_17 > 307769103)
        {
            goto label_27;
        }
        
        if(val_17 == 263667913)
        {
            goto label_28;
        }
        
        if(val_17 != 307769103)
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_38 = val_16;
        bool val_18 = System.String.op_Equality(a:  val_38, b:  "u.k. brands");
        val_39 = "Brands";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_25:
        if(val_17 > (-1170369044))
        {
            goto label_31;
        }
        
        if(val_17 > (-1582349178))
        {
            goto label_32;
        }
        
        if(val_17 == (-1831841111))
        {
            goto label_33;
        }
        
        if(val_17 != (-1582349178))
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_40 = "aussie celebrities";
        goto label_64;
        label_26:
        if(val_17 > (-1984175468))
        {
            goto label_36;
        }
        
        if(val_17 == (-1984175468))
        {
            goto label_37;
        }
        
        if(val_17 != 1452907016)
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_41 = "premier league";
        goto label_39;
        label_31:
        if(val_17 > (-505260449))
        {
            goto label_40;
        }
        
        if(val_17 == (-1100237017))
        {
            goto label_41;
        }
        
        if(val_17 != (-505260449))
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_38 = val_16;
        bool val_19 = System.String.op_Equality(a:  val_38, b:  "uk reality shows");
        val_39 = "Reality TV";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_27:
        if(val_17 == 707037262)
        {
            goto label_44;
        }
        
        if(val_17 != 914013912)
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_40 = "uk celebrities";
        goto label_64;
        label_32:
        if(val_17 == (-1542551710))
        {
            goto label_47;
        }
        
        if(val_17 != (-1170369044))
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_42 = "indian tv";
        goto label_59;
        label_36:
        if(val_17 == (-1974546689))
        {
            goto label_50;
        }
        
        if(val_17 == (-1965371875))
        {
            goto label_51;
        }
        
        if(val_17 != (-1895419107))
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_42 = "telenovelas";
        goto label_59;
        label_40:
        if(val_17 == (-466665155))
        {
            goto label_54;
        }
        
        if(val_17 == (-431898027))
        {
            goto label_55;
        }
        
        if(val_17 != (-5967784))
        {
                return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        }
        
        val_38 = val_16;
        bool val_20 = System.String.op_Equality(a:  val_38, b:  "bollywood");
        val_39 = "Animated Movies";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_28:
        val_38 = val_16;
        bool val_21 = System.String.op_Equality(a:  val_38, b:  "queen");
        val_39 = "Rock Music";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_33:
        val_42 = "uk tv";
        goto label_59;
        label_37:
        val_38 = val_16;
        bool val_22 = System.String.op_Equality(a:  val_38, b:  "rugby");
        val_39 = "Football";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_41:
        val_43 = "musica latinoamericana";
        goto label_61;
        label_44:
        val_43 = "uk music";
        label_61:
        val_38 = val_16;
        bool val_23 = System.String.op_Equality(a:  val_38, b:  val_43);
        val_39 = "Pop Music";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_47:
        val_38 = val_16;
        bool val_24 = System.String.op_Equality(a:  val_38, b:  "pop culture");
        val_39 = "TV 10s";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_51:
        val_40 = "bollywood celebrities";
        goto label_64;
        label_55:
        val_41 = "futbol";
        label_39:
        val_38 = val_16;
        bool val_25 = System.String.op_Equality(a:  val_38, b:  val_41);
        val_39 = "Soccer";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_50:
        val_42 = "aussie tv";
        label_59:
        val_38 = val_16;
        bool val_26 = System.String.op_Equality(a:  val_38, b:  val_42);
        val_39 = "Sitcoms";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
        label_54:
        label_64:
        val_39 = "Celebrities";
        return (string)((System.String.op_Equality(a:  val_38, b:  val_40)) != true) ? (val_39) : (val_37);
    }
    public bool AnyExpertReadyToUpgrade()
    {
        string val_3;
        var val_4;
        string val_11;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_12;
        var val_13;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.myExperts.Keys.GetEnumerator();
        label_12:
        val_11 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, TRVExpertProgressData>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_3;
        }
        
        TRVExpertsController val_6 = MonoSingleton<TRVExpertsController>.Instance;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = val_3;
        val_12 = this.myExperts;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = val_3;
        if(this.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = val_6.getExpertBaseData(expertName:  val_11);
        if((this.myEcon.getReqFromExpert(exp:  val_11, prog:  val_12.Item[val_11])) == null)
        {
            goto label_12;
        }
        
        val_12 = this.myExperts;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = val_3;
        if(val_12.Item[val_11] == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_10.<cardsOwned>k__BackingField) < val_9.cardsNeeded)
        {
            goto label_12;
        }
        
        val_13 = 1;
        goto label_13;
        label_3:
        val_13 = 0;
        label_13:
        val_4.Dispose();
        return (bool)val_13;
    }
    public System.Collections.Generic.List<TRVExpert> GetAllExpertsReadyToUpgrade()
    {
        string val_4;
        var val_5;
        string val_12;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_13;
        System.Collections.Generic.List<TRVExpert> val_1 = new System.Collections.Generic.List<TRVExpert>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.myExperts.Keys.GetEnumerator();
        label_14:
        val_12 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, TRVExpertProgressData>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_3;
        }
        
        TRVExpertsController val_7 = MonoSingleton<TRVExpertsController>.Instance;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_4;
        TRVExpert val_8 = val_7.getExpertBaseData(expertName:  val_12);
        val_13 = this.myExperts;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_4;
        if(this.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_8;
        if((this.myEcon.getReqFromExpert(exp:  val_12, prog:  val_13.Item[val_12])) == null)
        {
            goto label_14;
        }
        
        val_13 = this.myExperts;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_4;
        if(val_13.Item[val_12] == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.<cardsOwned>k__BackingField) < val_10.cardsNeeded)
        {
            goto label_14;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_8);
        goto label_14;
        label_3:
        val_5.Dispose();
        return val_1;
    }
    public TRVExpertsController()
    {
    
    }

}
