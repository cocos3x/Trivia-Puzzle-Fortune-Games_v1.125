using UnityEngine;
public class WGChallengeController : MonoSingletonSelfGenerating<WGChallengeController>
{
    // Fields
    private bool initialized;
    private string prefkey;
    private System.Collections.Generic.List<ChallengeTask> taskList;
    private const string initialReqLookup = "init";
    private const string incrementLookup = "inc";
    private const string maxRequirementLookup = "max";
    private bool gotKnobs;
    private int _unlockLevel;
    private int _challengeReward;
    private int _flyoutFrequency;
    public System.Action<bool, ChallengeType> onAnyChallengeProgress;
    private System.Collections.Generic.Dictionary<ChallengeType, System.Collections.Generic.Dictionary<string, object>> goalKnobData;
    
    // Properties
    public bool Initialized { get; }
    public System.Collections.Generic.List<ChallengeTask> getAllTasks { get; }
    public int unlockLevel { get; }
    public int challengeReward { get; }
    public bool featureEnabled { get; }
    public bool shouldShowProgressPopup { get; }
    
    // Methods
    public bool get_Initialized()
    {
        return (bool)this.initialized;
    }
    public System.Collections.Generic.List<ChallengeTask> get_getAllTasks()
    {
        return (System.Collections.Generic.List<ChallengeTask>)this.taskList;
    }
    public int get_unlockLevel()
    {
        return (int)this._unlockLevel;
    }
    public int get_challengeReward()
    {
        return (int)this._challengeReward;
    }
    public bool get_featureEnabled()
    {
        if((this._unlockLevel & 2147483648) != 0)
        {
                return false;
        }
        
        GameBehavior val_1 = App.getBehavior;
        return System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public bool get_shouldShowProgressPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        if(App.Player < this._unlockLevel)
        {
                return false;
        }
        
        int val_6 = this._flyoutFrequency;
        val_6 = val_6 + (CPlayerPrefs.GetInt(key:  "lastChallengeReminder", defaultValue:  0));
        if(App.Player < val_6)
        {
                return false;
        }
        
        CPlayerPrefs.SetInt(key:  "lastChallengeReminder", val:  App.Player);
        return false;
    }
    private void Awake()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  this.onAnyChallengeProgress, b:  new System.Action<System.Boolean, ChallengeType>(object:  this, method:  System.Void WGChallengeController::OnProgress(bool completed, ChallengeType type)));
        if(val_2 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        this.onAnyChallengeProgress = val_2;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDataReady");
        System.Delegate val_5 = System.Delegate.Combine(a:  GoldenApplesManager.OnAppleAwarded, b:  new System.Action<System.Int32>(object:  this, method:  public System.Void WGChallengeController::OnSecondaryCurrencyGained(int numGained)));
        if(val_5 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        GoldenApplesManager.OnAppleAwarded = val_5;
    }
    private void Start()
    {
        if((MonoSingleton<WGInviteManager>.Instance) != 0)
        {
                System.Delegate val_4 = System.Delegate.Combine(a:  WGInviteManager.onInviteSent, b:  new System.Action(object:  this, method:  public System.Void WGChallengeController::OnInviteSent()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
            WGInviteManager.onInviteSent = val_4;
        }
        
        this.init();
        return;
        label_7:
    }
    private void OnApplicationPause(bool paused)
    {
        this.storeData();
    }
    public void CheckSceneLoading()
    {
        var val_16;
        System.Func<ChallengeTask, System.Boolean> val_18;
        if(this.featureEnabled == false)
        {
                return;
        }
        
        this.storeData();
        if(App.Player < this._unlockLevel)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if((val_3.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<WGChallengeWindow>()) == true)
        {
                return;
        }
        
        val_16 = null;
        val_16 = null;
        val_18 = WGChallengeController.<>c.<>9__27_0;
        if(val_18 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_8 = null;
            val_18 = val_8;
            val_8 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CheckSceneLoading>b__27_0(ChallengeTask x));
            WGChallengeController.<>c.<>9__27_0 = val_18;
        }
        
        if((System.Linq.Enumerable.Any<ChallengeTask>(source:  this.taskList, predicate:  val_8)) != false)
        {
                MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeFlyout>(showNext:  false).PlayCompleteFlyout();
            CPlayerPrefs.SetInt(key:  "lastChallengeReminder", val:  App.Player);
            return;
        }
        
        if(this.shouldShowProgressPopup == false)
        {
                return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeFlyout>(showNext:  false).PlayProgressFlyout();
    }
    private void OnProgress(bool completed, ChallengeType type)
    {
        var val_15;
        UnityEngine.Object val_16;
        var val_17;
        val_16 = completed;
        if(this.featureEnabled == false)
        {
                return;
        }
        
        if(val_16 == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        val_15 = 1152921513412338272;
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<WGChallengeWindow>()) == true)
        {
                return;
        }
        
        val_17 = 1152921504893161472;
        val_16 = MonoSingleton<DifficultySettingManager>.Instance;
        if(val_16 != 0)
        {
                DifficultySettingManager val_9 = MonoSingleton<DifficultySettingManager>.Instance;
            if((val_9.<Setting>k__BackingField.FeatureStatus.IsFtuxLevel) == true)
        {
                return;
        }
        
        }
        
        val_17 = 1152921504877826048;
        val_16 = MainController.instance;
        if(val_16 != 0)
        {
                MainController val_12 = MainController.instance;
            if(val_12.isGameComplete != false)
        {
                return;
        }
        
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeFlyout>(showNext:  false).PlayCompleteFlyout();
    }
    private void init()
    {
        var val_8;
        var val_9;
        var val_13;
        var val_14;
        ChallengeTask val_15;
        System.Collections.IDictionary val_16;
        if(this.initialized == true)
        {
                return;
        }
        
        this.ParseKnobs();
        Player val_1 = App.Player;
        if((System.String.op_Equality(a:  val_1._challengeData, b:  "")) != false)
        {
                this.CreateOrUpdatePlayer();
        }
        
        Player val_3 = App.Player;
        if((System.String.op_Inequality(a:  val_3._challengeData, b:  "")) == false)
        {
            goto label_9;
        }
        
        Player val_5 = App.Player;
        val_14 = null;
        List.Enumerator<T> val_7 = MiniJSON.Json.Deserialize(json:  val_5._challengeData).GetEnumerator();
        label_22:
        if(val_9.MoveNext() == false)
        {
            goto label_16;
        }
        
        val_15 = val_8;
        if(val_15 == 0)
        {
            goto label_17;
        }
        
        val_16 = X0;
        if(X0 == true)
        {
            goto label_18;
        }
        
        goto label_19;
        label_17:
        val_16 = 0;
        label_18:
        ChallengeTask val_11 = null;
        val_15 = val_11;
        val_11 = new ChallengeTask();
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.deserialize(data:  val_16);
        if(this.taskList == null)
        {
                throw new NullReferenceException();
        }
        
        this.taskList.Add(item:  val_11);
        goto label_22;
        label_16:
        val_9.Dispose();
        this.CreateOrUpdatePlayer();
        label_9:
        this.initialized = true;
        return;
        label_19:
        val_13 = val_15;
        val_14 = X22;
        throw new NullReferenceException();
    }
    private void CreateOrUpdatePlayer()
    {
        var val_43;
        System.Func<ChallengeTask, System.Boolean> val_45;
        var val_46;
        System.Func<ChallengeTask, System.Boolean> val_48;
        var val_49;
        System.Func<ChallengeTask, System.Boolean> val_51;
        var val_52;
        System.Func<ChallengeTask, System.Boolean> val_54;
        var val_55;
        System.Func<ChallengeTask, System.Boolean> val_57;
        var val_58;
        System.Func<ChallengeTask, System.Boolean> val_60;
        if(this.gotKnobs != true)
        {
                this.ParseKnobs();
        }
        
        val_43 = null;
        val_43 = null;
        val_45 = WGChallengeController.<>c.<>9__30_0;
        if(val_45 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_1 = null;
            val_45 = val_1;
            val_1 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_0(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_0 = val_45;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_1)) == 0)
        {
                decimal val_6 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[0].Item["init"]));
            int val_7 = this.addChallenge(subject:  0, target:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        }
        
        val_46 = null;
        val_46 = null;
        val_48 = WGChallengeController.<>c.<>9__30_1;
        if(val_48 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_8 = null;
            val_48 = val_8;
            val_8 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_1(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_1 = val_48;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_8)) == 0)
        {
                decimal val_13 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[1].Item["init"]));
            int val_14 = this.addChallenge(subject:  1, target:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid});
        }
        
        val_49 = null;
        val_49 = null;
        val_51 = WGChallengeController.<>c.<>9__30_2;
        if(val_51 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_15 = null;
            val_51 = val_15;
            val_15 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_2(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_2 = val_51;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_15)) == 0)
        {
                decimal val_20 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[2].Item["init"]));
            int val_21 = this.addChallenge(subject:  2, target:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid});
        }
        
        val_52 = null;
        val_52 = null;
        val_54 = WGChallengeController.<>c.<>9__30_3;
        if(val_54 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_22 = null;
            val_54 = val_22;
            val_22 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_3(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_3 = val_54;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_22)) == 0)
        {
                decimal val_27 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[3].Item["init"]));
            int val_28 = this.addChallenge(subject:  3, target:  new System.Decimal() {flags = val_27.flags, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid});
        }
        
        val_55 = null;
        val_55 = null;
        val_57 = WGChallengeController.<>c.<>9__30_4;
        if(val_57 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_29 = null;
            val_57 = val_29;
            val_29 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_4(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_4 = val_57;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_29)) == 0)
        {
                decimal val_34 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[4].Item["init"]));
            int val_35 = this.addChallenge(subject:  4, target:  new System.Decimal() {flags = val_34.flags, hi = val_34.hi, lo = val_34.lo, mid = val_34.mid});
        }
        
        val_58 = null;
        val_58 = null;
        val_60 = WGChallengeController.<>c.<>9__30_5;
        if(val_60 == null)
        {
                System.Func<ChallengeTask, System.Boolean> val_36 = null;
            val_60 = val_36;
            val_36 = new System.Func<ChallengeTask, System.Boolean>(object:  WGChallengeController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeController.<>c::<CreateOrUpdatePlayer>b__30_5(ChallengeTask x));
            WGChallengeController.<>c.<>9__30_5 = val_60;
        }
        
        if((System.Linq.Enumerable.Count<ChallengeTask>(source:  this.taskList, predicate:  val_36)) == 0)
        {
                decimal val_41 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  this.goalKnobData.Item[5].Item["init"]));
            int val_42 = this.addChallenge(subject:  5, target:  new System.Decimal() {flags = val_41.flags, hi = val_41.hi, lo = val_41.lo, mid = val_41.mid});
        }
        
        if(this.taskList == W23)
        {
                return;
        }
        
        this.storeData();
    }
    private void ParseKnobs()
    {
        object val_38;
        if(this.gotKnobs == true)
        {
                return;
        }
        
        this.gotKnobs = true;
        GameEcon val_1 = App.getGameEcon;
        if(val_1.goalsHashes == null)
        {
                return;
        }
        
        GameEcon val_2 = App.getGameEcon;
        if((val_2.goalsHashes.ContainsKey(key:  "goals")) != false)
        {
                GameEcon val_4 = App.getGameEcon;
            object val_5 = val_4.goalsHashes.Item["goals"];
            val_38 = "Error Parsing all goal knobs, defaulting to econ values";
        }
        else
        {
                val_38 = "no goal data found in challenge knobs";
        }
        
        UnityEngine.Debug.LogWarning(message:  val_38);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        GameEcon val_7 = App.getGameEcon;
        val_6.Add(key:  "init", value:  val_7.InitialExtraWordsReq);
        GameEcon val_8 = App.getGameEcon;
        val_6.Add(key:  "inc", value:  val_8.ExtraWordsIncrement);
        GameEcon val_9 = App.getGameEcon;
        val_6.Add(key:  "max", value:  val_9.ExtraWordsMaxReq);
        this.goalKnobData.set_Item(key:  0, value:  val_6);
        GameEcon val_10 = App.getGameEcon;
        if((val_10.goalsHashes.ContainsKey(key:  "rew")) == false)
        {
            goto label_32;
        }
        
        GameEcon val_12 = App.getGameEcon;
        if((System.Int32.TryParse(s:  val_12.goalsHashes.Item["rew"], result: out  this._challengeReward)) == true)
        {
            goto label_38;
        }
        
        label_32:
        UnityEngine.Debug.LogError(message:  "unable to parse goal reward value");
        label_38:
        GameEcon val_16 = App.getGameEcon;
        if((val_16.goalsHashes.ContainsKey(key:  "lvl")) == false)
        {
            goto label_45;
        }
        
        GameEcon val_18 = App.getGameEcon;
        if((System.Int32.TryParse(s:  val_18.goalsHashes.Item["lvl"], result: out  this._unlockLevel)) == true)
        {
            goto label_51;
        }
        
        label_45:
        UnityEngine.Debug.LogError(message:  "unable to parse goal unlock level");
        label_51:
        GameEcon val_22 = App.getGameEcon;
        if((val_22.goalsHashes.ContainsKey(key:  "fly_frq")) != false)
        {
                GameEcon val_24 = App.getGameEcon;
            if((System.Int32.TryParse(s:  val_24.goalsHashes.Item["fly_frq"], result: out  this._flyoutFrequency)) == true)
        {
                return;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "unable to parse goal flyout frequency");
    }
    private void CheckAndSetKnobDictionary(System.Collections.Generic.Dictionary<string, object> datas, ChallengeType cType)
    {
        if(((datas.ContainsKey(key:  "inc")) != false) && ((datas.ContainsKey(key:  "init")) != false))
        {
                if((datas.ContainsKey(key:  "max")) != false)
        {
                this.goalKnobData.set_Item(key:  cType, value:  datas);
            return;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "Challenge Knobs not set properly for challenge " + cType.ToString());
    }
    public void resetData()
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  this.prefkey);
        this.taskList.Clear();
        this.initialized = false;
        this.init();
    }
    public void storeData()
    {
        string val_8;
        object val_9;
        var val_10;
        if(this.initialized == false)
        {
                return;
        }
        
        if(this.featureEnabled == false)
        {
                return;
        }
        
        System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
        List.Enumerator<T> val_3 = this.taskList.GetEnumerator();
        label_7:
        val_9 = public System.Boolean List.Enumerator<ChallengeTask>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_10 = 0;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_9 = val_10.serialize();
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  val_9);
        goto label_7;
        label_4:
        0.Dispose();
        val_8 = MiniJSON.Json.Serialize(obj:  val_2);
        Player val_7 = App.Player;
        val_7._challengeData = val_8;
    }
    public int addChallenge(ChallengeType subject, decimal target)
    {
        .id = subject;
        .subject = subject;
        .target = target;
        mem[1152921515997617936] = target.lo;
        mem[1152921515997617940] = target.mid;
        if((this.goalKnobData.Item[subject].ContainsKey(key:  "m_d")) != false)
        {
                if((this.goalKnobData.Item[subject].ContainsKey(key:  "d")) != false)
        {
                System.DateTime val_6 = DateTimeCheat.UtcNow;
            .lastCompletedAt = val_6;
        }
        
        }
        
        this.taskList.Add(item:  new ChallengeTask());
        return (int)(ChallengeTask)[1152921515997617888].id;
    }
    public void OnDataReady()
    {
    
    }
    public void removeChallenge(int id)
    {
        this.removeChallenge(ct:  this.getChallenge(id:  id));
    }
    public void removeChallenge(ChallengeTask ct)
    {
        if(ct == null)
        {
                return;
        }
        
        bool val_1 = this.taskList.Remove(item:  ct);
    }
    public ChallengeTask getChallenge(int id)
    {
        var val_3;
        var val_4;
        val_3 = id;
        List.Enumerator<T> val_1 = this.taskList.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_4 = 0;
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(11993091 != val_3)
        {
            goto label_4;
        }
        
        goto label_5;
        label_2:
        val_4 = 0;
        label_5:
        0.Dispose();
        return (ChallengeTask)val_4;
    }
    public float getChallengePercent(int id)
    {
        ChallengeTask val_1 = this.getChallenge(id:  id);
        if(val_1 == null)
        {
                return 0f;
        }
        
        return val_1.getPercent();
    }
    public bool isChallengeComplete(int id)
    {
        ChallengeTask val_1 = this.getChallenge(id:  id);
        if(val_1 == null)
        {
                return (bool)val_1;
        }
        
        return val_1.isComplete();
    }
    public void CompleteChallenge(int id)
    {
        ChallengeTask val_1 = this.getChallenge(id:  id);
        if(val_1 == null)
        {
                return;
        }
        
        bool val_2 = val_1.gainProgress(amt:  new System.Decimal() {flags = val_1.target, hi = val_1.target});
        if(this.onAnyChallengeProgress == null)
        {
                return;
        }
        
        this.onAnyChallengeProgress.Invoke(arg1:  true, arg2:  val_1.subject);
    }
    private void gainProgress(ChallengeType t, decimal amt)
    {
        if(App.Player < this._unlockLevel)
        {
                return;
        }
        
        if(this.featureEnabled == false)
        {
                return;
        }
        
        List.Enumerator<T> val_3 = this.taskList.GetEnumerator();
        label_13:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(1 != t)
        {
            goto label_13;
        }
        
        bool val_5 = 0.gainProgress(amt:  new System.Decimal() {flags = amt.flags, hi = amt.hi, lo = amt.lo, mid = amt.mid});
        if(this.onAnyChallengeProgress == null)
        {
            goto label_13;
        }
        
        this.onAnyChallengeProgress.Invoke(arg1:  System.Decimal.op_Equality(d1:  new System.Decimal() {flags = 9733424, lo = 64}, d2:  new System.Decimal() {flags = 41868256, mid = 3670080}), arg2:  t);
        goto label_13;
        label_7:
        0.Dispose();
    }
    private void clearProgress(ChallengeType t)
    {
        List.Enumerator<T> val_1 = this.taskList.GetEnumerator();
        goto label_4;
        label_5:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(1 == t)
        {
                mem[24] = 0;
            mem[32] = 0;
        }
        
        label_4:
        if(0.MoveNext() == true)
        {
            goto label_5;
        }
        
        0.Dispose();
    }
    public void debugMakeComplete(int id)
    {
        ChallengeTask val_1 = this.getChallenge(id:  id);
        val_1.debugMakeComplete(ct:  val_1);
    }
    public void debugMakeComplete(ChallengeTask ct)
    {
        if(ct == null)
        {
                return;
        }
        
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = ct.progress, hi = ct.progress, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = ct.target, hi = ct.target, lo = 41967616})) == false)
        {
                return;
        }
        
        ct.progress = ct.target;
    }
    public bool CheckChallengeAvailable(ChallengeType cType)
    {
        if(cType == 5)
        {
                return this.twitterPostAvailable();
        }
        
        if(cType != 4)
        {
                return true;
        }
        
        return this.friendInviteAvailable();
    }
    private bool friendInviteAvailable()
    {
        var val_21;
        var val_22;
        ulong val_23;
        val_22 = 0;
        if(WGInviteManager.IsEnabled == false)
        {
                return (bool)val_22;
        }
        
        val_21 = this.getChallenge(id:  4);
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        val_23 = val_3.dateData;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_23}, t2:  new System.DateTime() {dateData = val_2.lastCompletedAt})) == true)
        {
            goto label_26;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = this.goalKnobData.Item[4];
        val_23 = "m_d";
        if(((val_5.ContainsKey(key:  "m_d")) == false) || ((val_5.ContainsKey(key:  "d")) == false))
        {
            goto label_26;
        }
        
        if((System.Int32.TryParse(s:  val_5.Item["m_d"], result: out  999)) == false)
        {
            goto label_21;
        }
        
        System.DateTime val_11 = DateTimeCheat.UtcNow;
        val_23 = val_2.lastCompletedAt;
        System.DateTime val_12 = val_23.AddDays(value:  999);
        if((System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_11.dateData}, t2:  new System.DateTime() {dateData = val_12.dateData})) == false)
        {
            goto label_18;
        }
        
        label_29:
        val_22 = 1;
        return (bool)val_22;
        label_18:
        if((System.Int32.TryParse(s:  val_5.Item["d"], result: out  999)) == false)
        {
            goto label_21;
        }
        
        System.DateTime val_17 = DateTimeCheat.UtcNow;
        System.DateTime val_18 = val_23.AddDays(value:  1998);
        val_23 = val_18.dateData;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_17.dateData}, t2:  new System.DateTime() {dateData = val_23})) == false)
        {
            goto label_26;
        }
        
        System.DateTime val_20 = DateTimeCheat.UtcNow;
        val_2.lastCompletedAt = val_20;
        goto label_29;
        label_21:
        UnityEngine.Debug.LogError(message:  "not finding proper friend invite goal knob data, failing gracefully");
        label_26:
        val_22 = 0;
        return (bool)val_22;
    }
    private bool twitterPostAvailable()
    {
        ulong val_20;
        var val_21;
        ChallengeTask val_1 = this.getChallenge(id:  5);
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_20 = val_2.dateData;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_20}, t2:  new System.DateTime() {dateData = val_1.lastCompletedAt})) == true)
        {
            goto label_25;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = this.goalKnobData.Item[5];
        val_20 = "m_d";
        if(((val_4.ContainsKey(key:  "m_d")) == false) || ((val_4.ContainsKey(key:  "d")) == false))
        {
            goto label_25;
        }
        
        if((System.Int32.TryParse(s:  val_4.Item["m_d"], result: out  999)) == false)
        {
            goto label_20;
        }
        
        System.DateTime val_10 = DateTimeCheat.UtcNow;
        val_20 = val_1.lastCompletedAt;
        System.DateTime val_11 = val_20.AddDays(value:  999);
        if((System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_10.dateData}, t2:  new System.DateTime() {dateData = val_11.dateData})) == false)
        {
            goto label_17;
        }
        
        label_28:
        val_21 = 1;
        return (bool)val_21;
        label_17:
        if((System.Int32.TryParse(s:  val_4.Item["d"], result: out  999)) == false)
        {
            goto label_20;
        }
        
        System.DateTime val_16 = DateTimeCheat.UtcNow;
        System.DateTime val_17 = val_20.AddDays(value:  1998);
        val_20 = val_17.dateData;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_16.dateData}, t2:  new System.DateTime() {dateData = val_20})) == false)
        {
            goto label_25;
        }
        
        System.DateTime val_19 = DateTimeCheat.UtcNow;
        val_1.lastCompletedAt = val_19;
        goto label_28;
        label_20:
        UnityEngine.Debug.LogError(message:  "not finding proper friend invite goal knob data, failing gracefully");
        label_25:
        val_21 = 0;
        return (bool)val_21;
    }
    public bool TryCompleteChallenge(ChallengeType chalToComplete)
    {
        var val_21;
        ChallengeTask val_1 = this.getChallenge(id:  chalToComplete);
        if(val_1 == null)
        {
                return false;
        }
        
        val_21 = val_1;
        if(val_1.isComplete() == false)
        {
                return false;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = this.goalKnobData.Item[chalToComplete];
        if(val_3 == null)
        {
            goto label_4;
        }
        
        if(chalToComplete > 5)
        {
            goto label_7;
        }
        
        var val_21 = 32555340 + (chalToComplete) << 2;
        val_21 = val_21 + 32555340;
        goto (32555340 + (chalToComplete) << 2 + 32555340);
        label_4:
        this = "no knob data for " + chalToComplete.ToString() + ", can\'t collect";
        UnityEngine.Debug.LogError(message:  this);
        return false;
        label_7:
        UnityEngine.Debug.Log(message:  "Challenge Type not found for Goal completed.");
        decimal val_16 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  val_3.Item["inc"]));
        decimal val_17 = System.Decimal.op_Implicit(value:  System.Int32.Parse(s:  val_3.Item["max"]));
        val_21.Complete(currentIncrement:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, currentMax:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid});
        decimal val_19 = System.Decimal.op_Implicit(value:  this._challengeReward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, source:  val_19.flags.getChallengeTrackingID(cType:  chalToComplete), subSource:  0, externalParams:  0, doTrack:  true);
        this.storeData();
        return false;
    }
    public void OnSecondaryCurrencyGained(int numGained)
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  numGained);
        this.gainProgress(t:  1, amt:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
    }
    public void OnDailyChallengeComplete()
    {
        null = null;
        this.gainProgress(t:  3, amt:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
    }
    public void OnAnyHintUsed()
    {
        null = null;
        this.gainProgress(t:  2, amt:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
    }
    public void OnExtraWordFound()
    {
        null = null;
        this.gainProgress(t:  0, amt:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
    }
    public void OnInviteSent()
    {
        var val_11;
        var val_12;
        val_11 = this;
        if(this.friendInviteAvailable() == false)
        {
                return;
        }
        
        val_12 = null;
        val_12 = null;
        this.gainProgress(t:  4, amt:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        if((this.isChallengeComplete(id:  4)) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = this.goalKnobData.Item[4];
        if((val_3.ContainsKey(key:  "d")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["d"], result: out  999);
        }
        
        val_11 = this.getChallenge(id:  4);
        System.DateTime val_9 = DateTimeCheat.UtcNow;
        System.DateTime val_10 = val_9.dateData.AddDays(value:  999);
        val_8.lastCompletedAt = val_10;
    }
    public void OnTweetSent()
    {
        var val_11;
        var val_12;
        val_11 = this;
        if(this.twitterPostAvailable() == false)
        {
                return;
        }
        
        val_12 = null;
        val_12 = null;
        this.gainProgress(t:  5, amt:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        if((this.isChallengeComplete(id:  5)) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = this.goalKnobData.Item[5];
        if((val_3.ContainsKey(key:  "d")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["d"], result: out  999);
        }
        
        val_11 = this.getChallenge(id:  5);
        System.DateTime val_9 = DateTimeCheat.UtcNow;
        System.DateTime val_10 = val_9.dateData.AddDays(value:  999);
        val_8.lastCompletedAt = val_10;
    }
    public string getChallengeTrackingID(ChallengeType cType)
    {
        if(cType <= 5)
        {
                var val_3 = 32555364 + (cType) << 2;
            val_3 = val_3 + 32555364;
        }
        else
        {
                string val_2 = "Challenge Type Tracking Tag Not Set for " + cType.ToString();
            return (string);
        }
    
    }
    public WGChallengeController()
    {
        this.prefkey = "ChallengeTrackerData";
        this.taskList = new System.Collections.Generic.List<ChallengeTask>();
        this._unlockLevel = 25;
        this._challengeReward = 0;
        this._flyoutFrequency = 7;
        System.Collections.Generic.Dictionary<ChallengeType, System.Collections.Generic.Dictionary<System.String, System.Object>> val_2 = new System.Collections.Generic.Dictionary<ChallengeType, System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "init", value:  "10");
        val_3.Add(key:  "inc", value:  "2");
        val_3.Add(key:  "max", value:  "100");
        val_2.Add(key:  0, value:  val_3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "init", value:  "3");
        val_4.Add(key:  "inc", value:  "1");
        val_4.Add(key:  "max", value:  "15");
        val_2.Add(key:  2, value:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "init", value:  "100");
        val_5.Add(key:  "inc", value:  "50");
        val_5.Add(key:  "max", value:  "2500");
        val_2.Add(key:  1, value:  val_5);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "init", value:  "1");
        val_6.Add(key:  "inc", value:  "1");
        val_6.Add(key:  "max", value:  "5");
        val_2.Add(key:  3, value:  val_6);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7.Add(key:  "init", value:  "1");
        val_7.Add(key:  "inc", value:  "1");
        val_7.Add(key:  "max", value:  "5");
        val_2.Add(key:  4, value:  val_7);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_8.Add(key:  "init", value:  "1");
        val_8.Add(key:  "inc", value:  "1");
        val_8.Add(key:  "max", value:  "5");
        val_2.Add(key:  5, value:  val_8);
        this.goalKnobData = val_2;
        WFOWordChestDisplay.<BeginChestReadyFlowCoroutine>d__58 val_9 = this;
    }

}
