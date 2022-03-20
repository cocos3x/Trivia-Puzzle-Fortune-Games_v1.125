using UnityEngine;
public class FPHPhraseOfTheDayController : MonoSingleton<FPHPhraseOfTheDayController>
{
    // Fields
    private FPHQotdStatus <Status>k__BackingField;
    private const string LEVEL_PROGRESS_KEY = "qotdLvlProg";
    private int maxPOTDLevels;
    
    // Properties
    public FPHQotdStatus Status { get; set; }
    
    // Methods
    public FPHQotdStatus get_Status()
    {
        return (FPHQotdStatus)this.<Status>k__BackingField;
    }
    public void set_Status(FPHQotdStatus value)
    {
        this.<Status>k__BackingField = value;
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        this.<Status>k__BackingField = new FPHQotdStatus();
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  public System.Void FPHPhraseOfTheDayController::OnSceneLoaded(SceneType scene)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        return;
        label_6:
    }
    public FPHQOTDPhrase GetReward()
    {
        FPHQOTDPhrase val_3;
        if((this.<Status>k__BackingField.qotdProgress) <= 1)
        {
                FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
            val_3 = val_1.QotdNormalReward;
            return (FPHQOTDPhrase)mem[val_2.QotdBonusReward];
        }
        
        FPHEcon val_2 = App.GetGameSpecificEcon<FPHEcon>();
        val_3 = val_2.QotdBonusReward;
        return (FPHQOTDPhrase)mem[val_2.QotdBonusReward];
    }
    public void CheckQOTD()
    {
        this.CheckLPN();
    }
    public void Play()
    {
        var val_8;
        ulong val_9;
        this.<Status>k__BackingField.IsPlaying = true;
        val_8 = null;
        val_8 = null;
        FPHGameplayController.currentGameplayMode = true;
        System.DateTime val_1 = this.<Status>k__BackingField.LastPlayedTime.Date;
        System.DateTime val_2 = DateTimeCheat.Now;
        System.DateTime val_3 = val_2.dateData.Date;
        val_9 = val_3.dateData;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_9})) != false)
        {
                System.DateTime val_5 = DateTimeCheat.Now;
            val_9 = 0;
            System.DateTime val_6 = val_5.dateData.Date;
            this.<Status>k__BackingField.LastPlayedTime = val_6;
            this.<Status>k__BackingField.qotdProgress = 0;
            this.<Status>k__BackingField.savedLevelData = System.String.alignConst;
        }
        
        GameBehavior val_7 = App.getBehavior;
    }
    public void OnSceneLoaded(SceneType scene)
    {
        if(scene != 1)
        {
                return;
        }
        
        if((this.<Status>k__BackingField) != null)
        {
                this.<Status>k__BackingField.IsPlaying = false;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void Complete()
    {
        this.<Status>k__BackingField.IsPlaying = false;
        this.<Status>k__BackingField.qotdProgress = this.maxPOTDLevels;
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void CompleteQuestion(bool correctAnswer)
    {
        MetaGameBehavior val_7;
        var val_8;
        string val_9;
        if(correctAnswer != false)
        {
                int val_7 = this.<Status>k__BackingField.qotdProgress;
            val_7 = val_7 + 1;
            this.<Status>k__BackingField.qotdProgress = val_7;
            GameBehavior val_1 = App.getBehavior;
            val_7 = val_1.<metaGameBehavior>k__BackingField;
            FPHGameplayController val_3 = FPHGameplayController.Instance;
            val_8 = 1;
            val_9 = 0;
        }
        else
        {
                this.<Status>k__BackingField.qotdProgress = this.maxPOTDLevels;
            GameBehavior val_4 = App.getBehavior;
            val_7 = val_4.<metaGameBehavior>k__BackingField;
            val_8 = 0;
            val_9 = "Incorrect Guess";
        }
        
        FPHGameplayController.Instance.TrackLevelComplete(isSuccess:  false, failReason:  val_9);
    }
    public void CollectReward()
    {
        FPHQOTDPhrase val_1 = this.GetReward();
        if(val_1.rewardType != 1)
        {
                if(val_1.rewardType != 0)
        {
                return;
        }
        
            decimal val_3 = System.Decimal.op_Implicit(value:  val_1.rewardAmount);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Daily Phrases", subSource:  0, externalParams:  0, doTrack:  true);
            return;
        }
        
        App.Player.AddGems(amount:  val_1.rewardAmount, source:  "Daily Phrases", subsource:  0);
        App.Player.TrackNonCoinReward(source:  "Daily Phrases", subSource:  0, rewardType:  "Gems", rewardAmount:  val_1.rewardAmount.ToString(), additionalParams:  0);
    }
    public bool IsPlaying()
    {
        if((this.<Status>k__BackingField) == null)
        {
                return false;
        }
        
        return (bool)((this.<Status>k__BackingField.IsPlaying) == true) ? 1 : 0;
    }
    public bool IsEligible()
    {
        if(this.IsFeatureEnabled() == false)
        {
                return false;
        }
        
        FPHEcon val_3 = App.GetGameSpecificEcon<FPHEcon>();
        if(App.Player < val_3.qotdUnlockLevel)
        {
                return false;
        }
        
        System.DateTime val_4 = this.<Status>k__BackingField.LastPlayedTime.Date;
        System.DateTime val_5 = DateTimeCheat.Now;
        System.DateTime val_6 = val_5.dateData.Date;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = val_6.dateData})) != false)
        {
                return false;
        }
        
        var val_8 = ((this.<Status>k__BackingField.qotdProgress) < this.maxPOTDLevels) ? 1 : 0;
        return false;
    }
    public bool IsFeatureEnabled()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        if((val_1.qotdUnlockLevel & 2147483648) != 0)
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        return System.String.op_Equality(a:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public void SetupLevel(ref FPHGameplayState newGame)
    {
        FPHGameplayState val_21;
        FPHGameplayState val_22;
        FPHGameplayState val_23;
        var val_24;
        char val_25;
        val_22 = 1152921515986923280;
        if((this.<Status>k__BackingField) != null)
        {
                val_23 = 0;
            if((System.String.IsNullOrEmpty(value:  this.<Status>k__BackingField.savedLevelData)) != true)
        {
                val_23 = val_22;
            bool val_3 = FPHGameplayState.Deserialize(dataString:  this.<Status>k__BackingField.savedLevelData, stateToLoad: ref  FPHGameplayState val_2 = newGame);
            if(val_3 != false)
        {
                int val_4 = newGame.<levelIndex>k__BackingField;
            <levelData>k__BackingField = val_3.GetNextFPHQOTDLevel(definedIndex: ref  val_4);
            <levelIndex>k__BackingField = val_4;
            return;
        }
        
            this.<Status>k__BackingField.savedLevelData = System.String.alignConst;
        }
        
        }
        
        trackingLevel = App.Player;
        <levelData>k__BackingField = System.String.IsNullOrEmpty(value:  this.<Status>k__BackingField.savedLevelData).GetNextFPHQOTDLevel(definedIndex: ref  0);
        <levelIndex>k__BackingField = 0;
        if((this.<Status>k__BackingField.qotdProgress) <= 0)
        {
            goto label_18;
        }
        
        FPHEcon val_10 = App.GetGameSpecificEcon<FPHEcon>();
        label_54:
        <tokensRemaining>k__BackingField = val_10.QotdBonusReward.tokensAmount;
        phraseSlotState = new System.Collections.Generic.List<FPHLetterSlotState>();
        val_21 = val_2;
        var val_21 = 0;
        label_45:
        if(val_21 >= (newGame.<levelData>k__BackingField.<phrase>k__BackingField.m_stringLength))
        {
            goto label_28;
        }
        
        if(((newGame.<levelData>k__BackingField.<phrase>k__BackingField.Chars[0]) & 65535) != ' ')
        {
                if((FPHKeyboard.IsLetter(value:  newGame.<levelData>k__BackingField.<phrase>k__BackingField.Chars[0])) != false)
        {
                newGame.phraseSlotState.Add(item:  0);
            val_24 = public System.Void System.Collections.Generic.List<System.Char>::Add(System.Char item);
            val_25 = 32;
        }
        else
        {
                newGame.phraseSlotState.Add(item:  1);
            val_24 = public System.Void System.Collections.Generic.List<System.Char>::Add(System.Char item);
            val_25 = newGame.<levelData>k__BackingField.<phrase>k__BackingField.Chars[0];
        }
        
            newGame.phraseSlotDisplayValue.Add(item:  val_25);
        }
        
        val_21 = val_21 + 1;
        if(val_2 != null)
        {
            goto label_45;
        }
        
        label_28:
        phraseSlotCorrectValue = newGame.<levelData>k__BackingField.<phrase>k__BackingField.Replace(oldValue:  " ", newValue:  "");
        val_22 = val_2;
        chestType = App.GetGameSpecificEcon<FPHEcon>().GetChestType();
        return;
        label_18:
        FPHEcon val_20 = App.GetGameSpecificEcon<FPHEcon>();
        if(val_20.QotdNormalReward != null)
        {
            goto label_54;
        }
        
        throw new NullReferenceException();
    }
    private FPHLevelObject GetNextFPHQOTDLevel(ref int definedIndex)
    {
        int val_9;
        var val_10;
        int val_22;
        System.Collections.Generic.IEnumerable<T> val_23;
        int val_24;
        var val_25;
        var val_27;
        FPHDataParser val_1 = MonoSingleton<FPHDataParser>.Instance;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = 0;
        System.Collections.Generic.List<FPHLevelObject> val_2 = val_1.LoadQOTDLevelData();
        val_24 = definedIndex;
        if((val_24 & 2147483648) != 0)
        {
            goto label_6;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_24 >= 1152921515932693872)
        {
            goto label_6;
        }
        
        if(1152921515932693872 <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_25 = 1152921515932693872 + ((definedIndex) << 3);
        goto label_36;
        label_6:
        System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.List<System.Object> val_4 = new System.Collections.Generic.List<System.Object>();
        bool val_5 = CPlayerPrefs.HasKey(key:  "qotdLvlProg");
        val_23 = 0;
        object val_7 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "qotdLvlProg", defaultValue:  "[]"));
        if(val_7 == null)
        {
            goto label_44;
        }
        
        List.Enumerator<T> val_8 = val_7.GetEnumerator();
        label_18:
        val_23 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_10.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_22 = val_9;
        if(val_22 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_23 = null;
        val_3.Add(item:  val_22);
        goto label_18;
        label_14:
        val_23 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_10.Dispose();
        label_44:
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Clear();
        System.Collections.Generic.List<System.Int32> val_13 = null;
        val_27 = val_13;
        val_13 = new System.Collections.Generic.List<System.Int32>(collection:  System.Linq.Enumerable.Range(start:  0, count:  44397495));
        List.Enumerator<T> val_14 = val_3.GetEnumerator();
        label_25:
        val_23 = public System.Boolean List.Enumerator<System.Int32>::MoveNext();
        if(val_10.MoveNext() == false)
        {
            goto label_22;
        }
        
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_13.Contains(item:  val_9)) == false)
        {
            goto label_25;
        }
        
        bool val_17 = val_13.Remove(item:  val_9);
        goto label_25;
        label_22:
        val_23 = public System.Void List.Enumerator<System.Int32>::Dispose();
        val_10.Dispose();
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Void List.Enumerator<System.Int32>::Dispose()) == 0)
        {
                UnityEngine.Debug.LogError(message:  "zero available QOTD levels, this should never happen");
            val_3.Clear();
            var val_21 = null;
            System.Collections.Generic.List<System.Int32> val_19 = null;
            val_23 = System.Linq.Enumerable.Range(start:  0, count:  44397495);
            val_27 = val_19;
            val_19 = new System.Collections.Generic.List<System.Int32>(collection:  val_23);
            if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        int val_20 = UnityEngine.Random.Range(min:  0, max:  val_23);
        val_24 = val_20;
        if(val_21 <= val_20)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_21 = val_21 + (val_24 << 2);
        UnityEngine.Debug.LogError(message:  "getting an out of range QOTD, defaulting to 0");
        if("getting an out of range QOTD, defaulting to 0" == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        label_36:
         =  + 32;
        return (FPHLevelObject);
    }
    public void StartNextQOTDQuestion()
    {
        this.<Status>k__BackingField.savedLevelData = System.String.alignConst;
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void UpdateSavedGame(FPHGameplayState state)
    {
        var val_7;
        FPHQotdStatus val_8;
        val_7 = this;
        val_8 = this.<Status>k__BackingField;
        if(state != null)
        {
                this.<Status>k__BackingField.savedLevelData = state.Serialize();
            val_7 = ???;
            val_8 = ???;
        }
        else
        {
                mem2[0] = System.String.alignConst;
        }
    
    }
    private void CheckLPN()
    {
        ulong val_14;
        System.DateTime val_1 = this.<Status>k__BackingField.LastLPNSetupTime.Date;
        System.DateTime val_2 = DateTimeCheat.Now;
        System.DateTime val_3 = val_2.dateData.Date;
        val_14 = val_3.dateData;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_14})) == false)
        {
            goto label_6;
        }
        
        System.DateTime val_5 = DateTimeCheat.Now;
        if(val_5.dateData.Hour < 16)
        {
            goto label_9;
        }
        
        label_6:
        if((this.<Status>k__BackingField.LastPlayedTime.Hour) > 15)
        {
                return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "Killing LPN due to completing QOTD before LPN trigger time");
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  26);
        return;
        label_9:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_10.Add(key:  "notification_type", value:  "daily_phrases");
        System.DateTime val_11 = DateTimeCheat.Today;
        System.DateTime val_12 = val_11.dateData.AddHours(value:  16);
        val_14 = val_12.dateData;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  26, when:  new System.DateTime() {dateData = val_14}, interval:  0, optTitle:  "Daily Phrases", optMessage:  "Daily Phrases are now available!", extraData:  val_10, priority:  0, useTimeModifier:  true);
        System.DateTime val_13 = System.DateTime.Today;
        this.<Status>k__BackingField.LastLPNSetupTime = val_13;
    }
    private void OnDisable()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  public System.Void FPHPhraseOfTheDayController::OnSceneLoaded(SceneType scene)));
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
    public FPHPhraseOfTheDayController()
    {
        this.maxPOTDLevels = 2;
    }

}
