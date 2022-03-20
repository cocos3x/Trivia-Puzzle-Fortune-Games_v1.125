using UnityEngine;
public class TRVPromoCategoriesQuiz : TRVQuizProgress
{
    // Fields
    public bool isPromoQuiz;
    
    // Properties
    public override bool quizLevelsPlayer { get; }
    
    // Methods
    public override bool get_quizLevelsPlayer()
    {
        return true;
    }
    public TRVPromoCategoriesQuiz(TRVSubCategoryData quizCategoryData, int quizLength, int quizLevel, ChestType chestType, bool isPromo = False)
    {
        System.Collections.Generic.IEnumerable<TSource> val_4;
        var val_5;
        TRVPromoCategoriesQuiz val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        System.Func<QuestionData, System.Boolean> val_25;
        var val_27;
        System.Predicate<QuestionData> val_29;
        val_19 = this;
        mem[1152921517189860448] = quizCategoryData;
        this.isPromoQuiz = isPromo;
        val_20 = 1152921504954662912;
        val_21 = null;
        val_21 = null;
        if(TRVPromoCategoriesHandler.prefs_promo_quiz_completed_key == null)
        {
            goto label_39;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_2 = TRVPromoCategoriesHandler.prefs_promo_quiz_completed_key + 24.GetEnumerator();
        val_20 = 1152921517189772896;
        val_22 = 0;
        goto label_6;
        label_12:
        val_23 = null;
        val_23 = null;
        val_25 = TRVPromoCategoriesQuiz.<>c.<>9__3_0;
        if(val_25 == null)
        {
                System.Func<QuestionData, System.Boolean> val_6 = null;
            val_25 = val_6;
            val_6 = new System.Func<QuestionData, System.Boolean>(object:  TRVPromoCategoriesQuiz.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVPromoCategoriesQuiz.<>c::<.ctor>b__3_0(QuestionData p));
            TRVPromoCategoriesQuiz.<>c.<>9__3_0 = val_25;
        }
        
        val_22 = (System.Linq.Enumerable.Count<QuestionData>(source:  val_4, predicate:  val_6)) + val_22;
        label_6:
        if(val_5.MoveNext() == true)
        {
            goto label_12;
        }
        
        val_5.Dispose();
        val_19 = val_19;
        if(val_22 < 1)
        {
            goto label_39;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_9 = quizCategoryData + 24.GetEnumerator();
        val_20 = 1152921504614887424;
        label_23:
        if(val_5.MoveNext() == false)
        {
            goto label_16;
        }
        
        val_27 = null;
        val_27 = null;
        val_29 = TRVPromoCategoriesQuiz.<>c.<>9__3_1;
        if(val_29 == null)
        {
                System.Predicate<QuestionData> val_11 = null;
            val_29 = val_11;
            val_11 = new System.Predicate<QuestionData>(object:  TRVPromoCategoriesQuiz.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVPromoCategoriesQuiz.<>c::<.ctor>b__3_1(QuestionData p));
            TRVPromoCategoriesQuiz.<>c.<>9__3_1 = val_29;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        int val_12 = val_4.RemoveAll(match:  val_11);
        goto label_23;
        label_16:
        val_5.Dispose();
        label_39:
        mem[1152921517189860400] = quizCategoryData + 16;
        mem[1152921517189860408] = quizLength;
        mem[1152921517189860468] = chestType;
        mem[1152921517189860440] = quizLength;
        mem[1152921517189860416] = new TRVGameplayState();
        mem[1152921517189860460] = quizLevel;
        int[] val_16 = new int[0];
        mem[1152921517189860520] = val_16;
        System.Array.Copy(sourceArray:  MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetQuizDifficultyArray(quizCategory:  mem[1152921517189860400]), destinationArray:  val_16, length:  val_16.Length);
        mem[1152921517189860476] = TRVMainController.currentMultiplier;
    }
    protected override void GetNextQuestion(bool extraLifeQuestion)
    {
        if(extraLifeQuestion != true)
        {
                mem[1152921517190054364] = 2;
        }
        
        TRVDataParser val_3 = MonoSingleton<TRVDataParser>.Instance;
        mem[1152921517190054344] = val_3.<playerPersistance>k__BackingField.GetQuestion(myData:  extraLifeQuestion, subCat:  this, desiredDifficulty:  MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetNextQuestionDifficulty(quizProgress:  extraLifeQuestion, quiz:  this), completedThisDifficulty: ref  1152921517190054432);
    }

}
