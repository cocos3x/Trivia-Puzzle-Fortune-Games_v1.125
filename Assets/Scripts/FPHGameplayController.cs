using UnityEngine;
public class FPHGameplayController : MonoBehaviour
{
    // Fields
    private static FPHGameplayController _Instance;
    private const string LAST_SHOWN_SOLVE_REMINDER = "solveButtonLastPressed";
    public static FPHGameplayMode currentGameplayMode;
    private static int levelsCompleteWithoutSolveButtonPress;
    public static bool QAHACK_HURRY;
    public static bool QAHACK_CORRECT;
    protected FPHGameplayState currentGame;
    public System.Action<bool> OnAnswerSubmitted;
    public System.Action<bool> OnSolveModeToggled;
    public System.Action OnOutOfTokens;
    public System.Action<bool> OnLetterSubmitted;
    public System.Action<FPHGameplayState> OnLevelLoaded;
    public System.Action<FPHGameplayState> OnLevelSaved;
    private System.Action<char> tutorialActionOnCorrectLetterGuessed;
    private bool <IsSolveModeOn>k__BackingField;
    private int <CaretIndex>k__BackingField;
    
    // Properties
    public static FPHGameplayController Instance { get; }
    public FPHGameplayState getCurrentGame { get; }
    public bool IsSolveModeOn { get; set; }
    public int CaretIndex { get; set; }
    
    // Methods
    public static FPHGameplayController get_Instance()
    {
        var val_4;
        string val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        val_5 = FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER;
        if(val_5 != 0)
        {
                return (FPHGameplayController)FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER;
        }
        
        FPHGameplayController val_2 = UnityEngine.Object.FindObjectOfType<FPHGameplayController>();
        val_5 = val_2;
        if(val_2 == 0)
        {
                return (FPHGameplayController)FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER;
        }
        
        val_6 = null;
        val_6 = null;
        FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER = val_5;
        return (FPHGameplayController)FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER;
    }
    public FPHGameplayState get_getCurrentGame()
    {
        return (FPHGameplayState)this.currentGame;
    }
    public bool get_IsSolveModeOn()
    {
        return (bool)this.<IsSolveModeOn>k__BackingField;
    }
    private void set_IsSolveModeOn(bool value)
    {
        this.<IsSolveModeOn>k__BackingField = value;
    }
    public int get_CaretIndex()
    {
        return (int)this.<CaretIndex>k__BackingField;
    }
    private void set_CaretIndex(int value)
    {
        this.<CaretIndex>k__BackingField = value;
    }
    protected virtual void Start()
    {
        FPHGameplayController val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_11;
        val_6 = this;
        val_7 = null;
        val_7 = null;
        if(FPHGameplayController.currentGameplayMode != 1)
        {
            goto label_3;
        }
        
        val_8 = 0;
        if((UnityEngine.Object.op_Implicit(exists:  this.gameObject.GetComponent<FPHPhraseOfTheDayGameplayController>())) == false)
        {
            goto label_7;
        }
        
        val_8 = public FPHPhraseOfTheDayGameplayController UnityEngine.GameObject::GetComponent<FPHPhraseOfTheDayGameplayController>();
        val_9 = null;
        val_6 = this.gameObject.GetComponent<FPHPhraseOfTheDayGameplayController>();
        val_9 = null;
        goto label_11;
        label_7:
        val_7 = null;
        label_3:
        val_7 = null;
        label_11:
        FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER = val_6;
        val_11 = null;
        val_11 = null;
        goto x2;
    }
    public virtual void Init()
    {
        var val_6;
        FPHGameplayState val_1 = new FPHGameplayState();
        this.currentGame = val_1;
        MonoSingleton<FPHDataParser>.Instance.SetupLevel(state: ref  this.currentGame);
        if(this.OnLevelLoaded != null)
        {
                this.OnLevelLoaded.Invoke(obj:  val_1);
        }
        
        this.OnLevelLoaded.SetupEvents(currentGame: ref  this.currentGame);
        this.SetupTutorial();
        MonoSingleton<FPHGameplayUIController>.Instance.StartGameplay(newState:  val_1);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "Daily Phrases", value:  null);
        val_4.Add(key:  "Phrase ID ", value:  mem[1152921515944188864] + 16);
        if(mem[1152921515944188944] != 0)
        {
                if(mem[1152921515944188944].Count >= 1)
        {
                val_4.Add(key:  "Active Events", value:  mem[1152921515944188944]);
        }
        
        }
        
        val_6 = null;
        val_6 = null;
        App.trackerManager.track(eventName:  "Level Start", data:  val_4);
        this.LoadSolveButtonPressesTodayData();
    }
    private void LoadSolveButtonPressesTodayData()
    {
        int val_9;
        var val_10;
        var val_11;
        val_9 = App.Player;
        FPHEcon val_2 = App.GetGameSpecificEcon<FPHEcon>();
        bool val_3 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_9, knobValue:  val_2.solveReminderUnlockLevel);
        if(val_3 == false)
        {
                return;
        }
        
        if(val_3.HasSeenSolveReminderToday() == true)
        {
                return;
        }
        
        val_9 = 1152921504901894144;
        val_10 = null;
        val_10 = null;
        if(FPHGameplayController.levelsCompleteWithoutSolveButtonPress < 3)
        {
                return;
        }
        
        val_11 = 1152921504901898252;
        FPHGameplayController.levelsCompleteWithoutSolveButtonPress = 0;
        GameBehavior val_5 = App.getBehavior;
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        val_9 = val_7.dateData.ToString();
        CPlayerPrefs.SetString(key:  "solveButtonLastPressed", val:  val_9);
        CPlayerPrefs.Save();
    }
    private bool HasSeenSolveReminderToday()
    {
        ulong val_9;
        var val_10;
        var val_11;
        val_9 = 1152921504874684416;
        if((System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  "solveButtonLastPressed"))) != true)
        {
                val_10 = null;
            val_10 = null;
            System.DateTime val_4 = SLCDateTime.ParseInvariant(dateTime:  CPlayerPrefs.GetString(key:  "solveButtonLastPressed", defaultValue:  System.String.alignConst), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            System.DateTime val_5 = val_4.dateData.Date;
            val_9 = val_5.dateData;
            System.DateTime val_6 = DateTimeCheat.UtcNow;
            System.DateTime val_7 = val_6.dateData.Date;
            if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_9}, d2:  new System.DateTime() {dateData = val_7.dateData})) != false)
        {
                val_11 = 1;
            return (bool)val_11;
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    private void SetupEvents(ref FPHGameplayState currentGame)
    {
        associatedEvents = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                return;
        }
        
        if(WordGameEventsController.EventsEnabled == false)
        {
                return;
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) < 1)
        {
                return;
        }
        
        WordGameEventsController.InjectEventsTrackingData(data:  currentGame.associatedEvents, onlyTrackEnabledEvents:  false);
    }
    public void OnLetterPressed(char letter)
    {
        System.Predicate<FPHLetterSlotState> val_33;
        var val_34;
        var val_35;
        var val_37;
        var val_39;
        var val_40;
        char val_41;
        var val_42;
        int val_43;
        if((this.<IsSolveModeOn>k__BackingField) == false)
        {
            goto label_1;
        }
        
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGameSpecificSound(id:  "KeyboardStandard", clipIndex:  0);
        if((FPHKeyboard.IsLetter(value:  letter)) == false)
        {
            goto label_8;
        }
        
        if((this.currentGame.phraseSlotState.Contains(item:  0)) == false)
        {
            goto label_122;
        }
        
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  this.<CaretIndex>k__BackingField, value:  letter);
        this.currentGame.phraseSlotState.set_Item(index:  this.<CaretIndex>k__BackingField, value:  2);
        val_34 = 1152921504901947392;
        val_35 = null;
        val_35 = null;
        val_33 = FPHGameplayController.<>c.<>9__31_0;
        if(val_33 == null)
        {
                System.Predicate<FPHLetterSlotState> val_4 = null;
            val_33 = val_4;
            val_4 = new System.Predicate<FPHLetterSlotState>(object:  FPHGameplayController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FPHGameplayController.<>c::<OnLetterPressed>b__31_0(FPHLetterSlotState n));
            FPHGameplayController.<>c.<>9__31_0 = val_33;
        }
        
        this.<CaretIndex>k__BackingField = this.currentGame.phraseSlotState.FindIndex(match:  val_4);
        goto label_122;
        label_1:
        if((FPHKeyboard.IsLetter(value:  letter)) == false)
        {
            goto label_26;
        }
        
        val_33 = App.GetGameSpecificEcon<FPHEcon>();
        bool val_8 = val_7.vowels.Contains(item:  letter);
        var val_9 = (val_8 != true) ? 1512 : 1508;
        if(val_8 >= true)
        {
            goto label_32;
        }
        
        WGAudioController val_11 = MonoSingleton<WGAudioController>.Instance;
        val_11.sound.PlayGameSpecificSound(id:  "KeyboardNegative", clipIndex:  0);
        return;
        label_8:
        char val_12 = letter & 65535;
        if(val_12 == '')
        {
            goto label_38;
        }
        
        if((val_12 != '') || ((this.currentGame.phraseSlotState.Contains(item:  2)) == false))
        {
            goto label_122;
        }
        
        val_34 = 1152921504901947392;
        val_37 = null;
        val_37 = null;
        val_33 = FPHGameplayController.<>c.<>9__31_1;
        if(val_33 == null)
        {
                System.Predicate<FPHLetterSlotState> val_14 = null;
            val_33 = val_14;
            val_14 = new System.Predicate<FPHLetterSlotState>(object:  FPHGameplayController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FPHGameplayController.<>c::<OnLetterPressed>b__31_1(FPHLetterSlotState n));
            FPHGameplayController.<>c.<>9__31_1 = val_33;
        }
        
        int val_15 = this.currentGame.phraseSlotState.FindLastIndex(match:  val_14);
        this.<CaretIndex>k__BackingField = val_15;
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  val_15, value:  ' ');
        this.currentGame.phraseSlotState.set_Item(index:  this.<CaretIndex>k__BackingField, value:  0);
        goto label_122;
        label_26:
        if((letter & 65535) != '')
        {
            goto label_122;
        }
        
        WGAudioController val_17 = MonoSingleton<WGAudioController>.Instance;
        val_17.sound.PlayGameSpecificSound(id:  "KeyboardStandard", clipIndex:  0);
        goto label_60;
        label_38:
        this.SolveModeExit(removePlayerEntries:  true);
        label_60:
        MonoSingleton<FPHGameplayUIController>.Instance.AbortLevel();
        label_122:
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  this.currentGame);
        return;
        label_32:
        this.currentGame.<tokensRemaining>k__BackingField = (this.currentGame.<tokensRemaining>k__BackingField) - 1152921504901681152;
        this.currentGame.lettersPurchased.Add(item:  letter);
        if((FPHKeyboard.IsVowel(value:  letter)) != false)
        {
                int val_33 = this.currentGame.vowelsPurchased;
            val_33 = val_33 + 1;
            this.currentGame.vowelsPurchased = val_33;
        }
        else
        {
                int val_34 = this.currentGame.consonantsPurchased;
            val_34 = val_34 + 1;
            this.currentGame.consonantsPurchased = val_34;
        }
        
        var val_35 = 0;
        label_91:
        if(val_35 >= this.currentGame.phraseSlotState)
        {
            goto label_76;
        }
        
        if((this.currentGame.phraseSlotCorrectValue.Chars[0].Equals(obj:  letter)) == false)
        {
            goto label_79;
        }
        
        this.currentGame.phraseSlotState.set_Item(index:  0, value:  1);
        val_39 = public System.Void System.Collections.Generic.List<System.Char>::set_Item(int index, System.Char value);
        val_40 = val_35;
        val_41 = letter;
        goto label_83;
        label_79:
        if((this.currentGame.phraseSlotCorrectValueNormalized.Chars[0].Equals(obj:  letter)) == false)
        {
            goto label_85;
        }
        
        this.currentGame.phraseSlotState.set_Item(index:  0, value:  1);
        val_39 = public System.Void System.Collections.Generic.List<System.Char>::set_Item(int index, System.Char value);
        val_41 = this.currentGame.phraseSlotCorrectValue.Chars[0];
        val_40 = val_35;
        label_83:
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  0, value:  val_41);
        label_85:
        val_35 = val_35 + 1;
        if(this.currentGame != null)
        {
            goto label_91;
        }
        
        label_76:
        if((0 & 1) == 0)
        {
            goto label_93;
        }
        
        if(this.OnLetterSubmitted != null)
        {
                this.OnLetterSubmitted.Invoke(obj:  true);
        }
        
        WGAudioController val_27 = MonoSingleton<WGAudioController>.Instance;
        val_27.sound.PlayGameSpecificSound(id:  "KeyboardStandard", clipIndex:  0);
        if(this.tutorialActionOnCorrectLetterGuessed != null)
        {
                this.tutorialActionOnCorrectLetterGuessed.Invoke(obj:  letter);
        }
        
        if((this & 1) == 0)
        {
            goto label_100;
        }
        
        FPHEcon val_29 = App.GetGameSpecificEcon<FPHEcon>();
        bool val_30 = GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_29.solveReminderUnlockLevel);
        if((val_30 == false) || (val_30.HasSeenSolveReminderToday() == true))
        {
            goto label_122;
        }
        
        val_42 = null;
        val_42 = null;
        int val_36 = FPHGameplayController.levelsCompleteWithoutSolveButtonPress;
        val_36 = val_36 + 1;
        FPHGameplayController.levelsCompleteWithoutSolveButtonPress = val_36;
        goto label_122;
        label_93:
        if(this.OnLetterSubmitted != null)
        {
                this.OnLetterSubmitted.Invoke(obj:  false);
        }
        
        WGAudioController val_32 = MonoSingleton<WGAudioController>.Instance;
        val_32.sound.PlayGameSpecificSound(id:  "KeyboardNegative", clipIndex:  0);
        label_100:
        int val_37 = this.currentGame.consonantsPurchased;
        val_37 = 21 - val_37;
        if(val_37 > 0)
        {
                val_43 = val_7.consonantCost;
        }
        else
        {
                val_43 = val_7.vowelCost;
        }
        
        if(((this.currentGame.<tokensRemaining>k__BackingField) >= val_43) || (this.OnOutOfTokens == null))
        {
            goto label_122;
        }
        
        this.OnOutOfTokens.Invoke();
        goto label_122;
    }
    public virtual bool CheckAnswer(bool triggerCallbackOnlyOnCorrect = False, bool fromSolveMode = False)
    {
        bool val_8 = fromSolveMode;
        bool val_1 = this.currentGame.IsCurrentDisplayCorrectAnswer();
        this.SolveModeExit(removePlayerEntries:  false);
        if(val_1 != false)
        {
                this.currentGame.solveModeUsedToAnswer = val_8;
            this.currentGame.starsEarned = this.currentGame.<tokensRemaining>k__BackingField;
            Player val_3 = App.Player;
            val_8 = val_3;
            Player val_4 = val_3 + 1;
        }
        else
        {
                if((val_1 | (~triggerCallbackOnlyOnCorrect)) == false)
        {
                return val_1;
        }
        
        }
        
        if(this.OnAnswerSubmitted == null)
        {
                return val_1;
        }
        
        this.OnAnswerSubmitted.Invoke(obj:  val_1);
        return val_1;
    }
    public void SolveModeEnter(bool resetAnyUnconfirmedSlots = False)
    {
        var val_3;
        var val_4;
        System.Predicate<FPHLetterSlotState> val_6;
        if((this.<IsSolveModeOn>k__BackingField) != false)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        FPHGameplayController.levelsCompleteWithoutSolveButtonPress = 0;
        this.<IsSolveModeOn>k__BackingField = true;
        if(resetAnyUnconfirmedSlots != false)
        {
                this.ResetAnyUnconfirmedLetters();
        }
        
        val_4 = null;
        val_4 = null;
        val_6 = FPHGameplayController.<>c.<>9__33_0;
        if(val_6 == null)
        {
                System.Predicate<FPHLetterSlotState> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Predicate<FPHLetterSlotState>(object:  FPHGameplayController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FPHGameplayController.<>c::<SolveModeEnter>b__33_0(FPHLetterSlotState n));
            FPHGameplayController.<>c.<>9__33_0 = val_6;
        }
        
        this.<CaretIndex>k__BackingField = this.currentGame.phraseSlotState.FindIndex(match:  val_1);
        if(this.OnSolveModeToggled == null)
        {
                return;
        }
        
        this.OnSolveModeToggled.Invoke(obj:  this.<IsSolveModeOn>k__BackingField);
    }
    public void SolveModeExit(bool removePlayerEntries)
    {
        if((this.<IsSolveModeOn>k__BackingField) == false)
        {
                return;
        }
        
        this.<IsSolveModeOn>k__BackingField = false;
        this.<CaretIndex>k__BackingField = 0;
        if(removePlayerEntries != false)
        {
                this.ResetAnyUnconfirmedLetters();
        }
        
        if(this.OnSolveModeToggled == null)
        {
                return;
        }
        
        this.OnSolveModeToggled.Invoke(obj:  this.<IsSolveModeOn>k__BackingField);
    }
    public void ResetAnyUnconfirmedLetters()
    {
        var val_3 = 0;
        label_10:
        if(val_3 >= true)
        {
            goto label_3;
        }
        
        var val_2 = 1;
        if(val_3 >= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + 0;
        if(((1 + 0) + 32) != 1)
        {
                this.currentGame.phraseSlotState.set_Item(index:  0, value:  0);
            this.currentGame.phraseSlotDisplayValue.set_Item(index:  0, value:  ' ');
        }
        
        val_3 = val_3 + 1;
        if(this.currentGame != null)
        {
            goto label_10;
        }
        
        label_3:
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  this.currentGame);
    }
    public virtual void RevealAnswer()
    {
        var val_4 = 0;
        label_8:
        if(val_4 >= this.currentGame.phraseSlotState)
        {
            goto label_3;
        }
        
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  0, value:  this.currentGame.phraseSlotCorrectValue.Chars[0]);
        this.currentGame.phraseSlotState.set_Item(index:  0, value:  1);
        val_4 = val_4 + 1;
        if(this.currentGame != null)
        {
            goto label_8;
        }
        
        label_3:
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  this.currentGame);
        this.currentGame.hasCollectedChest = true;
        MonoSingleton<FPHGameplayUIController>.Instance.ShowLevelFail(failReason:  "Incorrect Guess");
    }
    public virtual bool DoPowerupRemove()
    {
        char val_3;
        var val_4;
        var val_19;
        var val_20;
        char val_21;
        System.Collections.Generic.List<System.Char> val_1 = new System.Collections.Generic.List<System.Char>();
        val_19 = null;
        val_19 = null;
        if(FPHKeyboard.LettersPerRow == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = FPHKeyboard.LettersPerRow.GetEnumerator();
        val_20 = 1152921515944751920;
        label_25:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        List.Enumerator<T> val_6 = val_3.GetEnumerator();
        label_21:
        if(val_4.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_21 = val_3;
        if((FPHKeyboard.IsLetter(value:  val_21)) == false)
        {
            goto label_21;
        }
        
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.currentGame.<levelData>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = this.currentGame.<levelData>k__BackingField.<phrase>k__BackingField;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_21.Contains(value:  val_21.ToString())) == true)
        {
            goto label_21;
        }
        
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.currentGame.lettersPurchased == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.currentGame.lettersPurchased.Contains(item:  val_21)) == true)
        {
            goto label_21;
        }
        
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.currentGame.lettersPowerupRemoved == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.currentGame.lettersPowerupRemoved.Contains(item:  val_21)) == true)
        {
            goto label_21;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_21);
        goto label_21;
        label_6:
        var val_13 = 0 + 1;
        val_21 = 0;
        mem2[0] = 158;
        val_4.Dispose();
        if(val_21 != 0)
        {
                throw X21;
        }
        
        if((val_13 == 1) || ((1152921515946184480 + ((0 + 1)) << 2) != 158))
        {
            goto label_25;
        }
        
        var val_21 = 0;
        val_21 = val_21 ^ (val_13 >> 31);
        var val_14 = val_13 + val_21;
        goto label_25;
        label_4:
        var val_15 = 0 + 1;
        mem2[0] = 186;
        val_4.Dispose();
        if((App.GetGameSpecificEcon<FPHEcon>()) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_17 = UnityEngine.Mathf.Min(a:  val_16.powerupRemoveQty, b:  -1545564384);
        val_21 = val_17;
        if(val_17 >= 1)
        {
                val_20 = 1152921509801944976;
            var val_23 = 0;
            do
        {
            int val_18 = UnityEngine.Random.Range(min:  0, max:  -1545564384);
            if(null <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            FPHGameplayState val_22 = this.currentGame;
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.currentGame.lettersPowerupRemoved == null)
        {
                throw new NullReferenceException();
        }
        
            val_22 = val_22 + (val_18 << 1);
            this.currentGame.lettersPowerupRemoved.Add(item:  (this.currentGame + (val_18) << 1).lettersPowerupRemoved);
            val_1.RemoveAt(index:  val_18);
            val_23 = val_23 + 1;
        }
        while(val_23 < val_21);
        
            if(val_21 >= 1)
        {
                if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
            int val_24 = this.currentGame.<removesUsed>k__BackingField;
            val_24 = val_24 + 1;
            this.currentGame.<removesUsed>k__BackingField = val_24;
        }
        
        }
        
        FPHGameplayUIController val_19 = MonoSingleton<FPHGameplayUIController>.Instance;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19.UpdateGameplayState(updatedState:  this.currentGame);
        return (bool)(val_21 > 0) ? 1 : 0;
    }
    public System.Collections.Generic.List<int> DoPowerupHint()
    {
        var val_29;
        System.Collections.Generic.List<System.Char> val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        FPHGameplayState val_29 = this.currentGame;
        val_29 = 1152921509801939856;
        val_30 = 0;
        label_13:
        if(val_30 >= val_29)
        {
            goto label_3;
        }
        
        val_29 = val_29 & 4294967295;
        if(val_30 >= val_29)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_30 >= this.currentGame)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        new System.Collections.Generic.List<System.Char>().Add(item:  this.currentGame.phraseSlotCorrectValue.Chars[0]);
        val_30 = val_30 + 1;
        if(this.currentGame != null)
        {
            goto label_13;
        }
        
        label_3:
        if((public System.Void System.Collections.Generic.List<System.Char>::.ctor()) < 1)
        {
            goto label_16;
        }
        
        int val_3 = UnityEngine.Random.Range(min:  0, max:  900708528);
        if(val_29 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_29 = val_29 + (val_3 << 1);
        val_30 = (this.currentGame + (val_3) << 1).lettersPowerupRemoved;
        this.currentGame.lettersPurchased.Add(item:  this.currentGame.phraseSlotCorrectValueNormalized.Chars[this.currentGame.phraseSlotCorrectValue.IndexOf(value:  val_30)]);
        System.Collections.Generic.List<System.Int32> val_7 = null;
        val_31 = val_7;
        val_7 = new System.Collections.Generic.List<System.Int32>();
        var val_30 = 0;
        label_44:
        if(val_30 >= this.currentGame.phraseSlotState)
        {
            goto label_25;
        }
        
        if((this.currentGame.phraseSlotCorrectValue.Chars[0].Equals(obj:  val_30)) != true)
        {
                if((this.currentGame.phraseSlotCorrectValue.Chars[0].Equals(obj:  this.currentGame.phraseSlotCorrectValueNormalized.Chars[this.currentGame.phraseSlotCorrectValue.IndexOf(value:  val_30)])) != true)
        {
                if((this.currentGame.phraseSlotCorrectValueNormalized.Chars[0].Equals(obj:  val_30)) == false)
        {
            goto label_37;
        }
        
        }
        
        }
        
        this.currentGame.phraseSlotState.set_Item(index:  0, value:  1);
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  0, value:  this.currentGame.phraseSlotCorrectValue.Chars[0]);
        val_7.Add(item:  0);
        label_37:
        val_30 = val_30 + 1;
        if(this.currentGame != null)
        {
            goto label_44;
        }
        
        label_25:
        if(this.currentGame >= 1)
        {
                FPHEcon val_19 = App.GetGameSpecificEcon<FPHEcon>();
            GameBehavior val_20 = App.getBehavior;
            Prefs.UsedHint(free:  ((val_20.<metaGameBehavior>k__BackingField) > val_19.powerupHintFreeUsageLevelLimit) ? 1 : 0);
            int val_31 = this.currentGame.<hintsUsed>k__BackingField;
            val_31 = val_31 + 1;
            this.currentGame.<hintsUsed>k__BackingField = val_31;
            val_32 = null;
            val_32 = null;
            App.trackerManager.track(eventName:  Events.HINT_USED);
            val_33 = null;
            val_33 = null;
            val_30 = App.trackerManager;
            Player val_22 = App.Player;
            val_30.track(eventName:  System.String.Format(format:  "{0}_{1}", arg0:  Events.HINT_USED, arg1:  val_22.properties.LifetimeHints));
        }
        
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  this.currentGame);
        if((this & 1) == 0)
        {
                return (System.Collections.Generic.List<System.Int32>)val_31;
        }
        
        val_30 = App.Player;
        FPHEcon val_26 = App.GetGameSpecificEcon<FPHEcon>();
        bool val_27 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_30, knobValue:  val_26.solveReminderUnlockLevel);
        if(val_27 == false)
        {
                return (System.Collections.Generic.List<System.Int32>)val_31;
        }
        
        if(val_27.HasSeenSolveReminderToday() == true)
        {
                return (System.Collections.Generic.List<System.Int32>)val_31;
        }
        
        val_30 = 1152921504901894144;
        val_34 = null;
        val_34 = null;
        int val_32 = FPHGameplayController.levelsCompleteWithoutSolveButtonPress;
        val_32 = val_32 + 1;
        FPHGameplayController.levelsCompleteWithoutSolveButtonPress = val_32;
        return (System.Collections.Generic.List<System.Int32>)val_31;
        label_16:
        val_31 = 0;
        return (System.Collections.Generic.List<System.Int32>)val_31;
    }
    public virtual void SpendGems(int gems, string source)
    {
        App.Player.AddGems(amount:  -gems, source:  source, subsource:  0);
    }
    public virtual void ProcessLevelComplete(bool success)
    {
        var val_12;
        var val_13;
        val_12 = this;
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.FadeOutMusic();
        val_13 = null;
        if(success != false)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnLevelComplete(levelsProgressed:  1);
            GameBehavior val_3 = App.getBehavior;
            val_13 = val_3.<metaGameBehavior>k__BackingField;
            val_12 = ???;
        }
        else
        {
                MonoSingleton<WordGameEventsController>.Instance.OnLevelComplete(levelsProgressed:  0);
            MonoSingleton<FPHGameplayUIController>.Instance.OnIncorrectAnswerSubmitted();
        }
    
    }
    public void RewardMultiPicked(int multiplier)
    {
        int val_6;
        this.currentGame.rewardMultiplier = multiplier;
        if(this.currentGame.hasCollectedChest != true)
        {
                val_6 = this.currentGame.GetTotalCoinReward();
            if(val_6 >= 1)
        {
                decimal val_4 = System.Decimal.op_Implicit(value:  val_6);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  "Level Complete", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
            if(this.currentGame.GetTotalStarReward() >= 1)
        {
                GoldenApplesManager val_5 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        }
        
        this.currentGame.hasCollectedChest = true;
    }
    public virtual bool IsTutorialLevel()
    {
        if((this & 1) != 0)
        {
                return true;
        }
    
    }
    public virtual bool IsKeyboardTutorial()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0;
    }
    public virtual bool IsTokenFeatureTutorial()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0;
    }
    public virtual void UpdateGameSave(FPHGameplayState updatedData)
    {
        if(this.OnLevelSaved != null)
        {
                this.OnLevelSaved.Invoke(obj:  updatedData);
        }
        
        MonoSingleton<FPHDataParser>.Instance.UpdateSavedLevel(state:  updatedData);
    }
    private void SetupTutorial()
    {
        var val_3;
        System.Action<System.Char> val_5;
        if((this & 1) == 0)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
            goto label_2;
        }
        
        val_3 = null;
        val_3 = null;
        val_5 = FPHGameplayController.<>c.<>9__46_0;
        if(val_5 != null)
        {
            goto label_8;
        }
        
        System.Action<System.Char> val_1 = null;
        val_5 = val_1;
        val_1 = new System.Action<System.Char>(object:  FPHGameplayController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHGameplayController.<>c::<SetupTutorial>b__46_0(char letter));
        FPHGameplayController.<>c.<>9__46_0 = val_5;
        goto label_8;
        label_2:
        this.SetupKeyboardTutorial(letter:  ' ');
        System.Action<System.Char> val_2 = null;
        val_5 = val_2;
        val_2 = new System.Action<System.Char>(object:  this, method:  System.Void FPHGameplayController::SetupKeyboardTutorial(char letter));
        label_8:
        this.tutorialActionOnCorrectLetterGuessed = val_5;
    }
    private void SetupKeyboardTutorial(char letter)
    {
        if((letter & 65535) == ' ')
        {
                if(this.currentGame != null)
        {
            goto label_2;
        }
        
        }
        
        if(this.currentGame.currentTutorialLetter != letter)
        {
                return;
        }
        
        label_2:
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.Char>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
                return;
        }
        
        PluginExtension.Shuffle<System.Char>(list:  System.Linq.Enumerable.ToList<System.Char>(source:  System.Linq.Enumerable.Except<System.Char>(first:  this.currentGame.phraseSlotCorrectValueNormalized, second:  this.currentGame.lettersPurchased)), seed:  new System.Nullable<System.Int32>() {HasValue = false});
        this = this.currentGame;
        if((public static System.Void PluginExtension::Shuffle<System.Char>(System.Collections.Generic.IList<T> list, System.Nullable<int> seed)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.currentGame.currentTutorialLetter = public System.Void System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>::.ctor(System.String key, LitJson.JsonData value);
    }
    public void TrackLevelComplete(bool isSuccess, string failReason)
    {
        TrackerManager val_10;
        var val_11;
        var val_12;
        var val_13;
        val_10 = failReason;
        if(isSuccess != true)
        {
                int val_2 = MonoSingleton<FPHDataParser>.Instance.InitialLevelOffset;
            val_2.InitialLevelOffset = val_2 + 1;
        }
        
        val_11 = null;
        val_11 = null;
        bool val_4 = isSuccess;
        App.trackerManager.track(eventName:  "Level Complete", data:  this);
        GameBehavior val_5 = App.getBehavior;
        if((val_5.<metaGameBehavior>k__BackingField) >= 10)
        {
                GameBehavior val_6 = App.getBehavior;
            if(0 != 0)
        {
                return;
        }
        
        }
        
        val_12 = null;
        val_12 = null;
        val_13 = null;
        val_10 = App.trackerManager;
        val_13 = null;
        GameBehavior val_7 = App.getBehavior;
        val_10.track(eventName:  Events.LEVEL_REACHED + "_" + val_7.<metaGameBehavior>k__BackingField.ToString()(val_7.<metaGameBehavior>k__BackingField.ToString()));
    }
    public virtual System.Collections.Generic.Dictionary<string, object> GatherLevelCompleteTrackingData(bool isSuccess, string failReason)
    {
        string val_6;
        var val_7;
        object val_8;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Consonants Purchased", value:  this.currentGame.consonantsPurchased);
        val_1.Add(key:  "Vowels Purchased", value:  this.currentGame.vowelsPurchased);
        val_1.Add(key:  "Unused Token Balance", value:  this.currentGame.<tokensRemaining>k__BackingField);
        val_1.Add(key:  "Multiplier Awarded", value:  this.currentGame.rewardMultiplier);
        val_1.Add(key:  "Hints Used", value:  this.currentGame.<hintsUsed>k__BackingField);
        val_1.Add(key:  "Remove Hints Used", value:  this.currentGame.<removesUsed>k__BackingField);
        val_1.Add(key:  "Phrase ID", value:  this.currentGame.<levelData>k__BackingField.<id>k__BackingField);
        val_1.Add(key:  "Solve Used", value:  this.currentGame.solveModeUsedToAnswer);
        if(isSuccess != false)
        {
                val_6 = "Level Success";
            val_7 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_8 = true;
        }
        else
        {
                val_6 = "Level Failed";
            val_7 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_8 = failReason;
        }
        
        val_1.Add(key:  val_6, value:  val_8);
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                MonoSingleton<WordGameEventsController>.Instance.AppendLevelCompleteData(curData: ref  val_1);
        }
        
        if(this.currentGame.associatedEvents == null)
        {
                return val_1;
        }
        
        if(this.currentGame.associatedEvents.Count < 1)
        {
                return val_1;
        }
        
        val_1.Add(key:  "Active Events", value:  this.currentGame.associatedEvents);
        return val_1;
    }
    private void OnDisable()
    {
        null = null;
        FPHGameplayController.LAST_SHOWN_SOLVE_REMINDER = 0;
    }
    public void Hack_CompleteLevel()
    {
        var val_3 = 0;
        label_7:
        if(val_3 >= this.currentGame)
        {
            goto label_3;
        }
        
        this.currentGame.phraseSlotState.set_Item(index:  0, value:  1);
        this.currentGame.phraseSlotDisplayValue.set_Item(index:  0, value:  this.currentGame.phraseSlotCorrectValue.Chars[0]);
        val_3 = val_3 + 1;
        if(this.currentGame != null)
        {
            goto label_7;
        }
        
        label_3:
        MonoSingleton<FPHGameplayUIController>.Instance.UpdateGameplayState(updatedState:  this.currentGame);
    }
    public void Hack_CompleteChapter()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        var val_6 = App.Player;
        val_6 = val_6 - ((val_6 / val_1.levelsPerChapter) * val_1.levelsPerChapter);
        var val_7 = ~val_6;
        val_7 = val_1.levelsPerChapter + val_7;
        int val_5 = val_7 + App.Player;
        this.Hack_CompleteLevel();
    }
    public FPHGameplayController()
    {
    
    }
    private static FPHGameplayController()
    {
    
    }

}
