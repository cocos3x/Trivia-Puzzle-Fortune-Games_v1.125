using UnityEngine;
public class TRVSpecialCategoriesQuiz : TRVQuizProgress
{
    // Fields
    public bool isPromoQuiz;
    
    // Properties
    public override bool quizLevelsPlayer { get; }
    
    // Methods
    public override bool get_quizLevelsPlayer()
    {
        return false;
    }
    public TRVSpecialCategoriesQuiz(TRVSubCategoryData quizCategoryData, bool isPromo = False)
    {
        this.isPromoQuiz = isPromo;
        mem[1152921517315014272] = quizCategoryData;
        mem[1152921517315014224] = quizCategoryData.subCategory;
        mem[1152921517315014232] = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetNewQuizLength(isPromo:  this.isPromoQuiz);
        mem[1152921517315014292] = MonoSingleton<TRVDataParser>.Instance.GetChestType();
        mem[1152921517315014264] = 1152921515677607024;
        mem[1152921517315014240] = new TRVGameplayState();
        mem[1152921517315014284] = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetNewQuizLevel(isPromo:  this.isPromoQuiz);
    }
    protected override void GetNextQuestion(bool extraLifeQuestion)
    {
        if(extraLifeQuestion != true)
        {
                mem[1152921517315171324] = 2;
        }
        
        TRVDataParser val_3 = MonoSingleton<TRVDataParser>.Instance;
        mem[1152921517315171304] = val_3.<playerPersistance>k__BackingField.GetQuestion(myData:  extraLifeQuestion, subCat:  this.isPromoQuiz, desiredDifficulty:  MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetNewQuestionDifficulty(quizProgressIndex:  extraLifeQuestion, isPromo:  this.isPromoQuiz), completedThisDifficulty: ref  1152921517315171392);
    }

}
