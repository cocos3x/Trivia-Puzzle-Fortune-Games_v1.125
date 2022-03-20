using UnityEngine;
public class TRVQuizProgress
{
    // Fields
    public string quizCategory;
    public int quizLength;
    public TRVGameplayState currentGameplayState;
    public QuestionData currentQuestionData;
    public System.Collections.Generic.List<TRVQuestionHistory> previousQuestions;
    public int correctAnswerRequirement;
    public int quizProgressIndex;
    private TRVSubCategoryData <myData>k__BackingField;
    public bool quizCompleted;
    public int quizLevel;
    public bool removeTwoHintUsed;
    public bool rerollQuestionUsed;
    public ChestType myChest;
    public bool hasCollectedChest;
    public bool hasRerolledChest;
    public int starMultiplierIndex;
    public int finalStarReward;
    public int finalCoinReward;
    public int selectedMulitplier;
    public TRVCategoryRankProgress categoryRankProgress;
    public string associatedEventID;
    public bool justCompletedDifficulty;
    private int[] <myArrayIndex>k__BackingField;
    private System.Collections.Generic.Dictionary<string, object> injectedTrackingInfo;
    
    // Properties
    public TRVSubCategoryData myData { get; set; }
    public virtual bool quizLevelsPlayer { get; }
    public int[] myArrayIndex { get; set; }
    public int correctAnswers { get; }
    public int countedAnswers { get; }
    public System.Collections.Generic.List<TRVQuestionHistory> countedAnswerData { get; }
    public int incorrecctAnswers { get; }
    public int totalPointsGained { get; }
    public int hintsUsedThisQuiz { get; }
    public bool freeHintWasUsedThisQuiz { get; }
    public int rerollsUsedThisQuiz { get; }
    public bool freeRerollWasUsedThisQuiz { get; }
    public int extraLivesUsedThisQuiz { get; }
    public int expertHintWasUsed { get; }
    public bool freeexpertHintWasUsed { get; }
    public bool successfullyCompletedQuiz { get; }
    
    // Methods
    public TRVSubCategoryData get_myData()
    {
        return (TRVSubCategoryData)this.<myData>k__BackingField;
    }
    protected void set_myData(TRVSubCategoryData value)
    {
        this.<myData>k__BackingField = value;
    }
    public virtual bool get_quizLevelsPlayer()
    {
        return true;
    }
    public int[] get_myArrayIndex()
    {
        return (System.Int32[])this.<myArrayIndex>k__BackingField;
    }
    protected void set_myArrayIndex(int[] value)
    {
        this.<myArrayIndex>k__BackingField = value;
    }
    public TRVQuizProgress(TRVSubCategoryData quizCategoryData)
    {
        var val_20;
        var val_21;
        System.Int32[] val_22;
        this.quizLength = 7;
        this.previousQuestions = new System.Collections.Generic.List<TRVQuestionHistory>();
        this.correctAnswerRequirement = 7;
        this.quizProgressIndex = -1;
        this.<myData>k__BackingField = quizCategoryData;
        this.quizCategory = quizCategoryData.subCategory;
        this.quizLength = MonoSingleton<TRVDataParser>.Instance.GetQuizLength();
        this.myChest = MonoSingleton<TRVDataParser>.Instance.GetChestType();
        this.correctAnswerRequirement = this.quizLength;
        this.currentGameplayState = new TRVGameplayState();
        this.quizLevel = App.Player;
        this.starMultiplierIndex = TRVMainController.currentMultiplier;
        val_20 = 1152921517192322784;
        System.Int32[] val_12 = MonoSingleton<TRVDataParser>.Instance.getQuizDifficultyOrders.Item[UnityEngine.Mathf.Min(a:  this.quizLength, b:  7)];
        this.<myArrayIndex>k__BackingField = new int[0];
        System.Array.Copy(sourceArray:  MonoSingleton<TRVDataParser>.Instance.getQuizDifficultyOrders.Item[UnityEngine.Mathf.Min(a:  this.quizLength, b:  7)], destinationArray:  this.<myArrayIndex>k__BackingField, length:  this.<myArrayIndex>k__BackingField.Length);
        if(this.starMultiplierIndex < 1)
        {
                return;
        }
        
        val_21 = null;
        val_21 = null;
        if(TRVMainController.noAnswerSelectedCharacter != null)
        {
                return;
        }
        
        val_22 = this.<myArrayIndex>k__BackingField;
        val_20 = 0;
        label_31:
        if(val_20 >= ((this.<myArrayIndex>k__BackingField.Length) << ))
        {
            goto label_27;
        }
        
        if(val_22[val_20] == 0)
        {
                new System.Collections.Generic.List<System.Int32>().Add(item:  0);
            val_22 = this.<myArrayIndex>k__BackingField;
        }
        
        val_20 = val_20 + 1;
        if(val_22 != null)
        {
            goto label_31;
        }
        
        throw new NullReferenceException();
        label_27:
        if(val_20 < 1)
        {
                return;
        }
        
        this.<myArrayIndex>k__BackingField[UnityEngine.Random.Range(min:  0, max:  0)] = 1;
    }
    public int get_correctAnswers()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Boolean> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__34_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  System.Func<TRVQuestionHistory, System.Boolean> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_correctAnswers>b__34_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__34_0 = val_4;
        return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1);
    }
    public int get_countedAnswers()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Boolean> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__36_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  System.Func<TRVQuestionHistory, System.Boolean> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_countedAnswers>b__36_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__36_0 = val_4;
        return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1);
    }
    public System.Collections.Generic.List<TRVQuestionHistory> get_countedAnswerData()
    {
        var val_4;
        System.Func<TRVQuestionHistory, System.Boolean> val_6;
        var val_7;
        if(true != 0)
        {
                val_4 = null;
            val_4 = null;
            val_6 = TRVQuizProgress.<>c.<>9__38_0;
            if(val_6 == null)
        {
                System.Func<TRVQuestionHistory, System.Boolean> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_countedAnswerData>b__38_0(TRVQuestionHistory x));
            TRVQuizProgress.<>c.<>9__38_0 = val_6;
        }
        
            System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<TRVQuestionHistory>(source:  System.Linq.Enumerable.Where<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1));
            return (System.Collections.Generic.List<TRVQuestionHistory>)val_7;
        }
        
        val_7 = 0;
        return (System.Collections.Generic.List<TRVQuestionHistory>)val_7;
    }
    public int get_incorrecctAnswers()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Boolean> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__40_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  System.Func<TRVQuestionHistory, System.Boolean> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_incorrecctAnswers>b__40_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__40_0 = val_4;
        return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1);
    }
    public int get_totalPointsGained()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Int32> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__42_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  System.Func<TRVQuestionHistory, System.Int32> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Int32>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVQuizProgress.<>c::<get_totalPointsGained>b__42_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__42_0 = val_4;
        return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  val_1);
    }
    public int get_hintsUsedThisQuiz()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Int32> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__44_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  System.Func<TRVQuestionHistory, System.Int32> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Int32>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVQuizProgress.<>c::<get_hintsUsedThisQuiz>b__44_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__44_0 = val_4;
        return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  val_1);
    }
    public bool get_freeHintWasUsedThisQuiz()
    {
        var val_4;
        System.Func<TRVQuestionHistory, System.Int32> val_6;
        var val_7;
        if(true != 0)
        {
                val_4 = null;
            val_4 = null;
            val_6 = TRVQuizProgress.<>c.<>9__46_0;
            if(val_6 == null)
        {
                System.Func<TRVQuestionHistory, System.Int32> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<TRVQuestionHistory, System.Int32>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVQuizProgress.<>c::<get_freeHintWasUsedThisQuiz>b__46_0(TRVQuestionHistory x));
            TRVQuizProgress.<>c.<>9__46_0 = val_6;
        }
        
            var val_3 = ((System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  val_1)) > 0) ? 1 : 0;
            return (bool)val_7;
        }
        
        val_7 = 0;
        return (bool)val_7;
    }
    public int get_rerollsUsedThisQuiz()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Boolean> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__48_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  System.Func<TRVQuestionHistory, System.Boolean> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_rerollsUsedThisQuiz>b__48_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__48_0 = val_4;
        return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1);
    }
    public bool get_freeRerollWasUsedThisQuiz()
    {
        var val_2;
        System.Predicate<TRVQuestionHistory> val_4;
        if(true == 0)
        {
                return false;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__50_0;
        if(val_4 != null)
        {
                return this.previousQuestions.Exists(match:  System.Predicate<TRVQuestionHistory> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<TRVQuestionHistory>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_freeRerollWasUsedThisQuiz>b__50_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__50_0 = val_4;
        return this.previousQuestions.Exists(match:  val_1);
    }
    public int get_extraLivesUsedThisQuiz()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Int32> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__52_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  System.Func<TRVQuestionHistory, System.Int32> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Int32>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVQuizProgress.<>c::<get_extraLivesUsedThisQuiz>b__52_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__52_0 = val_4;
        return System.Linq.Enumerable.Sum<TRVQuestionHistory>(source:  this.previousQuestions, selector:  val_1);
    }
    public int get_expertHintWasUsed()
    {
        var val_2;
        System.Func<TRVQuestionHistory, System.Boolean> val_4;
        if(true == 0)
        {
                return 0;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__54_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  System.Func<TRVQuestionHistory, System.Boolean> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<TRVQuestionHistory, System.Boolean>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_expertHintWasUsed>b__54_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__54_0 = val_4;
        return System.Linq.Enumerable.Count<TRVQuestionHistory>(source:  this.previousQuestions, predicate:  val_1);
    }
    public bool get_freeexpertHintWasUsed()
    {
        var val_2;
        System.Predicate<TRVQuestionHistory> val_4;
        if(true == 0)
        {
                return false;
        }
        
        val_2 = null;
        val_2 = null;
        val_4 = TRVQuizProgress.<>c.<>9__56_0;
        if(val_4 != null)
        {
                return this.previousQuestions.Exists(match:  System.Predicate<TRVQuestionHistory> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<TRVQuestionHistory>(object:  TRVQuizProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVQuizProgress.<>c::<get_freeexpertHintWasUsed>b__56_0(TRVQuestionHistory x));
        TRVQuizProgress.<>c.<>9__56_0 = val_4;
        return this.previousQuestions.Exists(match:  val_1);
    }
    public bool get_successfullyCompletedQuiz()
    {
        return (bool)(this.countedAnswers >= this.quizLength) ? 1 : 0;
    }
    public void AdvanceQuiz(bool extraLifeQuestion)
    {
        this.currentGameplayState = new TRVGameplayState();
        bool val_2 = extraLifeQuestion;
        goto typeof(TRVQuizProgress).__il2cppRuntimeField_180;
    }
    protected virtual void GetNextQuestion(bool extraLifeQuestion)
    {
        int val_13;
        int val_14;
        int val_15;
        int val_16;
        if(extraLifeQuestion != true)
        {
                int val_12 = this.quizProgressIndex;
            val_12 = val_12 + 1;
            this.quizProgressIndex = val_12;
        }
        
        val_13 = this.quizProgressIndex;
        val_14 = this.<myArrayIndex>k__BackingField.Length;
        if(val_13 >= val_14)
        {
                val_13 = val_14 - 1;
            this.quizProgressIndex = val_13;
            val_14 = this.<myArrayIndex>k__BackingField.Length;
        }
        
        val_15 = this.<myArrayIndex>k__BackingField[val_13];
        Player val_1 = App.Player;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        int val_3 = (val_1 < val_2.veryEasyLevelLimit) ? 0 : (val_15);
        label_27:
        if((val_1 < val_2.veryEasyLevelLimit) || ((this.<myData>k__BackingField.questionData.ContainsKey(key:  val_3)) == true))
        {
            goto label_12;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_8 = new object[2];
            val_15 = val_8;
            val_15[0] = this.<myData>k__BackingField.subCategory;
            val_15[1] = val_3;
            UnityEngine.Debug.LogErrorFormat(format:  "No {1} difficulty Q\'s for {0}. Attempting to get lower difficulty!", args:  val_8);
        }
        
        val_16 = val_3 - 1;
        if((this.<myData>k__BackingField) != null)
        {
            goto label_27;
        }
        
        throw new NullReferenceException();
        label_12:
        TRVDataParser val_9 = MonoSingleton<TRVDataParser>.Instance;
        this.currentQuestionData = val_9.<playerPersistance>k__BackingField.GetQuestion(myData:  this.<myData>k__BackingField, subCat:  this.quizCategory, desiredDifficulty:  val_16, completedThisDifficulty: ref  this.justCompletedDifficulty);
    }
    public int GetQuizBaseReward()
    {
        int val_12;
        var val_13;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1.variableLevelCompleteRewardEnabled != false)
        {
                val_12 = App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost;
        }
        else
        {
                TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
            val_12 = val_4._quizEntryCost;
        }
        
        TRVEcon val_5 = App.GetGameSpecificEcon<TRVEcon>();
        float val_12 = (float)val_12;
        val_12 = val_5.quizRewardConstant * val_12;
        val_13 = 0;
        if((UnityEngine.Mathf.FloorToInt(f:  val_12)) != 0)
        {
                return 50;
        }
        
        TRVEcon val_7 = App.GetGameSpecificEcon<TRVEcon>();
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        val_12 = System.String.Format(format:  "Quiz Base Reward is being calcuated as zero. Defaulting to 50 as a failsafe. Check your knobs! Dynamic Entry Cost is enabled {0} and cost is {1}, Quiz Reward Constant is {2}", arg0:  val_7.variableLevelCompleteRewardEnabled, arg1:  App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost, arg2:  val_10.quizRewardConstant);
        UnityEngine.Debug.LogError(message:  val_12);
        val_13 = 50;
        return 50;
    }
    public int GetQuizBaseStarReward()
    {
        return this.totalPointsGained;
    }
    public void InjectTrackingInfo(string key, object value)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = this.injectedTrackingInfo;
        if(val_4 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_4 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this.injectedTrackingInfo = val_4;
        }
        
        if((val_1.ContainsKey(key:  key)) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to inject duplicate key of " + key + " to level compelte tracking");
            return;
        }
        
        this.injectedTrackingInfo.Add(key:  key, value:  value);
    }
    public System.Collections.Generic.Dictionary<string, object> GetAdditionalTrackingInfo()
    {
        var val_2;
        if(this.injectedTrackingInfo != null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>(dictionary:  this.injectedTrackingInfo);
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_2;
        }
        
        val_2 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_2;
    }

}
