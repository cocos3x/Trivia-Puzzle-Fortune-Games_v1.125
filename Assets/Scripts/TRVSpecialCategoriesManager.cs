using UnityEngine;
public class TRVSpecialCategoriesManager : MonoSingleton<TRVSpecialCategoriesManager>
{
    // Properties
    private TRVSpecialCategoriesEventHandler SpecialEventHandler { get; }
    private TRVPromoCategoriesHandler PromoHandler { get; }
    
    // Methods
    private TRVSpecialCategoriesEventHandler get_SpecialEventHandler()
    {
        return (TRVSpecialCategoriesEventHandler)TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID;
    }
    private TRVPromoCategoriesHandler get_PromoHandler()
    {
        return MonoSingleton<TRVPromoCategoriesHandler>.Instance;
    }
    public static bool IsSpecialCategory(string subcategory)
    {
        var val_12;
        if((MonoSingleton<TRVSpecialCategoriesManager>.Instance) != 0)
        {
                if((MonoSingleton<TRVSpecialCategoriesManager>.Instance.PromoHandler) != 0)
        {
                if((MonoSingleton<TRVSpecialCategoriesManager>.Instance.PromoHandler.IsActivePromo(subCategoryName:  subcategory)) == true)
        {
            goto label_16;
        }
        
        }
        
            TRVSpecialCategoriesManager val_9 = MonoSingleton<TRVSpecialCategoriesManager>.Instance;
            if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID != null)
        {
                TRVSpecialCategoriesManager val_10 = MonoSingleton<TRVSpecialCategoriesManager>.Instance;
            if((System.String.op_Equality(a:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64, b:  subcategory)) != false)
        {
                label_16:
            val_12 = 1;
            return (bool)val_12;
        }
        
        }
        
        }
        
        val_12 = 0;
        return (bool)val_12;
    }
    public static bool IsOldSpecialQuiz(TRVQuizProgress progress)
    {
        var val_2 = 0;
        return (bool);
    }
    public int GetQuizProgress(TRVQuizProgress progress)
    {
        var val_2;
        if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID != null)
        {
                if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  progress)) != false)
        {
                val_2 = mem[TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72];
            val_2 = TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72;
            return (int)val_2;
        }
        
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    public bool IsRewardReadyToCollect(TRVQuizProgress progress)
    {
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  progress)) == false)
        {
                return false;
        }
        
        goto typeof(System.String).__il2cppRuntimeField_280;
    }
    public int GetCurrentReward(TRVQuizProgress progress)
    {
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  progress)) == false)
        {
                return 0;
        }
        
        return TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.getCurrentReward();
    }
    public void CollectReward(TRVQuizProgress progress)
    {
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  progress)) == false)
        {
                return;
        }
        
        TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.CollectReward();
    }
    public int GetNewQuizLength(bool isPromo)
    {
        if(isPromo == true)
        {
                return 0;
        }
        
        if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return 0;
        }
        
        return TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.GetQuizLength();
    }
    public int GetNewQuizLevel(bool isPromo)
    {
        if(isPromo == true)
        {
                return 0;
        }
        
        if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return 0;
        }
        
        return (int)(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72) + 1;
    }
    public int GetNewQuestionDifficulty(int quizProgressIndex, bool isPromo)
    {
        if(isPromo == true)
        {
                return 0;
        }
        
        if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return 0;
        }
        
        return TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.GetQuestionDifficulty(quizProgress:  quizProgressIndex);
    }
    public UnityEngine.Sprite GetPromoSprite(string subCategoryName)
    {
        bool val_1 = this.IsPromoCategory(subCategoryName:  subCategoryName);
        if(val_1 == false)
        {
                return 0;
        }
        
        return val_1.PromoHandler.GetIcon(subCategoryName:  subCategoryName);
    }
    public bool IsPromoCategory(string subCategoryName)
    {
        return this.PromoHandler.IsActivePromo(subCategoryName:  subCategoryName);
    }
    public PromoCategoryType GetPromoType(string subCategoryName)
    {
        PromoCategoryType val_5;
        TRVPromoCategory val_2 = this.PromoHandler.GetPromoCategory(subCategoryName:  subCategoryName);
        if(val_2 != null)
        {
                TRVPromoCategory val_4 = val_2.PromoHandler.GetPromoCategory(subCategoryName:  subCategoryName);
            val_5 = val_4.promoCategoryType;
            return (PromoCategoryType)val_5;
        }
        
        UnityEngine.Debug.LogError(message:  "Error: Tried to GetPromoType on invalid category.");
        val_5 = 1;
        return (PromoCategoryType)val_5;
    }
    public bool IsSpecialQuiz(string subCategoryName)
    {
        var val_3;
        if((this.IsPromoCategory(subCategoryName:  subCategoryName)) != true)
        {
                if((TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID == null) || ((System.String.op_Equality(a:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64, b:  subCategoryName)) == false))
        {
            goto label_3;
        }
        
        }
        
        val_3 = 1;
        return (bool)val_3;
        label_3:
        val_3 = 0;
        return (bool)val_3;
    }
    public System.DateTime GetCategoryEndTime(string subCategoryName)
    {
        string val_10;
        System.DateTime val_11;
        var val_12;
        val_10 = subCategoryName;
        bool val_1 = this.IsPromoCategory(subCategoryName:  val_10);
        if(val_1 != false)
        {
                TRVPromoCategory val_3 = val_1.PromoHandler.GetPromoCategory(subCategoryName:  val_10);
            val_11 = val_3.timeEnd;
            return val_11;
        }
        
        if((TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID != null) && ((System.String.op_Equality(a:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64, b:  val_10)) != false))
        {
            
        }
        else
        {
                val_10 = 1152921504616751104;
            val_12 = null;
            val_12 = null;
            val_11 = System.DateTime.MinValue;
            return val_11;
        }
    
    }
    public void OnCategorySelected(TRVCategorySelectionInfo selectionInfo)
    {
        if(selectionInfo != null)
        {
                this.OnCategorySelected(categoryName:  selectionInfo.categoryName);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void OnCategorySelected(string categoryName)
    {
        bool val_2 = this.PromoHandler.IsActivePromo(subCategoryName:  categoryName);
        if(val_2 == false)
        {
                return;
        }
        
        val_2.PromoHandler.HandleCategorySelected(categoryName:  categoryName);
    }
    public void OnQuizComplete(TRVQuizProgress quiz)
    {
        bool val_1 = this.IsPromoCategory(subCategoryName:  quiz.quizCategory);
        if(val_1 == false)
        {
                return;
        }
        
        val_1.PromoHandler.OnCategoryQuizComplete(quiz:  quiz);
    }
    public void OnQuestionComplete(TRVQuizProgress quiz)
    {
        TRVPromoCategory val_9;
        if((this.IsPromoCategory(subCategoryName:  quiz.quizCategory)) == false)
        {
                return;
        }
        
        int val_2 = quiz.correctAnswers;
        if(val_2 < quiz.correctAnswerRequirement)
        {
                return;
        }
        
        TRVPromoCategory val_4 = val_2.PromoHandler.GetPromoCategory(subCategoryName:  quiz.quizCategory);
        if(val_4 == null)
        {
                return;
        }
        
        val_9 = val_4;
        if((val_4.PromoHandler.ShouldShowEndOfQuiz(progress:  quiz)) == false)
        {
                return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        val_7.<metaGameBehavior>k__BackingField.SetupWithPromo(promo:  val_9, hidePaidEntry:  true, returnToCategorySelectOnButtonClose:  false, continueToNextLevel:  false);
    }
    public void OnLevelCompleteRewarded(TRVQuizProgress quiz)
    {
    
    }
    public UnityEngine.Sprite GetQuestionImageFromID(string subCategory, string questionID)
    {
        bool val_1 = this.IsPromoCategory(subCategoryName:  subCategory);
        if(val_1 == false)
        {
                return 0;
        }
        
        return val_1.PromoHandler.GetQuestionImageFromID(subCategory:  subCategory, questionID:  questionID);
    }
    public string GetExpertForSpecialCategory(string subCategory)
    {
        bool val_1 = this.IsPromoCategory(subCategoryName:  subCategory);
        if(val_1 == false)
        {
                return 0;
        }
        
        return val_1.PromoHandler.GetExpertForSpecialCategory(subCategory:  subCategory);
    }
    private bool IsPromoQuiz(TRVQuizProgress progress)
    {
        return this.PromoHandler.IsActivePromo(subCategoryName:  progress.quizCategory);
    }
    public TRVSpecialCategoriesManager()
    {
    
    }

}
