using UnityEngine;
public class TRVPromoCategoriesHandler : LocalGameEventSpawner<TRVPromoCategoriesHandler>
{
    // Fields
    public static bool QAHACK_OnlyShowPicQuestions;
    private static System.Collections.Generic.List<string> supportLangs;
    private const string prefs_seen_promos_key = "seen_promos";
    private System.Collections.Generic.List<int> _SeenPromos;
    private const string prefs_promo_quiz_completed_key = "promo_prgss";
    private static System.Collections.Generic.Dictionary<string, int> _PromoQuizzesCompleted;
    private System.Collections.Generic.List<TRVPromoCategory> currentPromos;
    private UnityEngine.Sprite genericIcon;
    private System.Collections.Generic.Dictionary<string, UnityEngine.Sprite> cachedLoadedSprites;
    public static TRVPromoCategory CurrentlyShownPromo;
    private bool isRequesting;
    private System.DateTime lastSuccessfulResponse;
    private static bool logPromoLogic;
    private static string log;
    
    // Properties
    private System.Collections.Generic.List<int> SeenPromos { get; }
    private static System.Collections.Generic.Dictionary<string, int> PromoQuizzesCompleted { get; }
    
    // Methods
    private System.Collections.Generic.List<int> get_SeenPromos()
    {
        if(this._SeenPromos != null)
        {
                return val_2;
        }
        
        System.Collections.Generic.List<System.Int32> val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "seen_promos", defaultValue:  "[]"));
        this._SeenPromos = val_2;
        return val_2;
    }
    private static System.Collections.Generic.Dictionary<string, int> get_PromoQuizzesCompleted()
    {
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_3;
        var val_4 = null;
        if(TRVPromoCategoriesHandler._PromoQuizzesCompleted == null)
        {
                val_4 = null;
            val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "promo_prgss", defaultValue:  "{}"));
            val_4 = null;
            TRVPromoCategoriesHandler._PromoQuizzesCompleted = val_3;
        }
        
        val_4 = null;
        return (System.Collections.Generic.Dictionary<System.String, System.Int32>)TRVPromoCategoriesHandler._PromoQuizzesCompleted;
    }
    public override void InitSpwaner()
    {
        TRVDataParser.AddCategorySelectFunction(newfunction:  new FeatureCategorySelectFunction(highPriority:  0, functionToDo:  new System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.List<System.String>>(object:  this, method:  System.Collections.Generic.List<System.String> TRVPromoCategoriesHandler::TryAddingPromoCategories(System.Collections.Generic.List<string> selectedCategories)), owner:  this));
        this.RequestPromos();
    }
    public bool EventShouldShow()
    {
        null = null;
        GameBehavior val_1 = App.getBehavior;
        return TRVPromoCategoriesHandler.supportLangs.Contains(item:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
    }
    public TRVCategorySelectionInfo GetCurrentlyShownSubCategory()
    {
        var val_2 = null;
        .categoryName = TRVPromoCategoriesHandler.CurrentlyShownPromo.subCategoryName;
        return (TRVCategorySelectionInfo)new TRVCategorySelectionInfo();
    }
    public string GetPrimaryCategory()
    {
        return "PromoCategory";
    }
    public bool IsActivePromo(string subCategoryName)
    {
        .subCategoryName = subCategoryName;
        if(this.currentPromos == null)
        {
                return false;
        }
        
        if(1152921504954716160 < 1)
        {
                return false;
        }
        
        return this.currentPromos.Exists(match:  new System.Predicate<TRVPromoCategory>(object:  new TRVPromoCategoriesHandler.<>c__DisplayClass20_0(), method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass20_0::<IsActivePromo>b__0(TRVPromoCategory p)));
    }
    public TRVQuizProgress LoadQuiz(string subCategory, string primaryCategory)
    {
        TRVSubCategoryData val_8;
        var val_9;
        if((this.IsActivePromo(subCategoryName:  subCategory)) != false)
        {
                TRVSubCategoryData val_3 = null;
            val_8 = val_3;
            val_3 = new TRVSubCategoryData(textBlock:  val_2.questionsDataBlock, subCategoryName:  subCategory);
            TRVPromoCategoriesQuiz val_7 = null;
            val_9 = val_7;
            val_7 = new TRVPromoCategoriesQuiz(quizCategoryData:  val_3, quizLength:  this.GetQuizLength(promoCategory:  this.GetPromoCategory(subCategoryName:  subCategory)), quizLevel:  0, chestType:  MonoSingleton<TRVDataParser>.Instance.GetChestType(), isPromo:  true);
            return (TRVQuizProgress)val_9;
        }
        
        val_9 = 0;
        return (TRVQuizProgress)val_9;
    }
    public TRVPromoCategory GetPromoCategory(string subCategoryName)
    {
        .subCategoryName = subCategoryName;
        return System.Linq.Enumerable.FirstOrDefault<TRVPromoCategory>(source:  this.currentPromos, predicate:  new System.Func<TRVPromoCategory, System.Boolean>(object:  new TRVPromoCategoriesHandler.<>c__DisplayClass22_0(), method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass22_0::<GetPromoCategory>b__0(TRVPromoCategory p)));
    }
    private int GetQuizLength(TRVPromoCategory promoCategory)
    {
        int val_4;
        var val_5;
        var val_10;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = promoCategory.quizLenngthLevelUnlocks.Keys.GetEnumerator();
        val_10 = 3;
        goto label_4;
        label_5:
        label_4:
        if(val_5.MoveNext() == true)
        {
            goto label_5;
        }
        
        val_5.Dispose();
        return (int)UnityEngine.Mathf.Max(a:  3, b:  ((this.GetActivePromoProgress(subcategory:  promoCategory.subCategoryName)) < promoCategory.quizLenngthLevelUnlocks.Item[val_4]) ? (val_10) : (val_4));
    }
    public int GetActivePromoProgress(string subcategory)
    {
        if((TRVPromoCategoriesHandler.PromoQuizzesCompleted.ContainsKey(key:  subcategory)) == false)
        {
                return 0;
        }
        
        return TRVPromoCategoriesHandler.PromoQuizzesCompleted.Item[subcategory];
    }
    public System.Collections.Generic.Dictionary<int, int> GetPromoRewards(string promoCategory)
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_4 = 0;
        if((System.String.IsNullOrEmpty(value:  promoCategory)) == true)
        {
                return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)val_4;
        }
        
        if((this.IsActivePromo(subCategoryName:  promoCategory)) != false)
        {
                TRVPromoCategory val_3 = this.GetPromoCategory(subCategoryName:  promoCategory);
            val_4 = val_3.rewards;
            return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)val_4;
        }
        
        val_4 = 0;
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)val_4;
    }
    public int[] GetQuizDifficultyArray(string quizCategory)
    {
        var val_10;
        int val_2 = this.GetQuizLength(promoCategory:  this.GetPromoCategory(subCategoryName:  quizCategory));
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = val_1.quizDifficultyOrders.Keys.GetEnumerator();
        val_10 = 0;
        goto label_5;
        label_6:
        if(0 == val_2)
        {
                val_10 = val_1.quizDifficultyOrders.Item[val_2];
        }
        
        label_5:
        if(0.MoveNext() == true)
        {
            goto label_6;
        }
        
        0.Dispose();
        if(val_10 != null)
        {
                return (System.Int32[])val_10;
        }
        
        val_10 = val_1.quizDifficultyOrders.Item[System.Linq.Enumerable.Max(source:  val_1.quizDifficultyOrders.Keys)];
        return (System.Int32[])val_10;
    }
    public int GetNextQuestionDifficulty(int quizProgress, TRVPromoCategoriesQuiz quiz)
    {
        var val_1;
        bool val_1 = true;
        if(38021 > quizProgress)
        {
                val_1 = val_1 + (quizProgress << 2);
            val_1 = mem[(true + (quizProgress) << 2) + 32];
            val_1 = (true + (quizProgress) << 2) + 32;
            return (int)val_1;
        }
        
        TRVPromoCategoriesHandler.LogLogic(logic:  "GetNextQuestionDifficulty Requesting a promo categories quiz out of difficulty array bounds, defaulting to diff 0", color:  "ffffff");
        val_1 = 0;
        return (int)val_1;
    }
    public void HandleCategorySelected(string categoryName)
    {
        string val_6;
        if((this.IsActivePromo(subCategoryName:  categoryName)) == false)
        {
            goto label_1;
        }
        
        TRVPromoCategory val_2 = this.GetPromoCategory(subCategoryName:  categoryName);
        if(val_2 == null)
        {
            goto label_2;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_3.<metaGameBehavior>k__BackingField.SetupWithPromo(promo:  val_2, hidePaidEntry:  true, returnToCategorySelectOnButtonClose:  true, continueToNextLevel:  true);
        return;
        label_1:
        val_6 = "HandleCategorySelected Error: No active promo found for ";
        goto label_8;
        label_2:
        val_6 = "HandleCategorySelected Error: No promo found for ";
        label_8:
        TRVPromoCategoriesHandler.LogError(error:  val_6 + categoryName);
    }
    public void OnCategoryQuizComplete(TRVQuizProgress quiz)
    {
        if((TRVPromoCategoriesHandler.PromoQuizzesCompleted.ContainsKey(key:  quiz.quizCategory)) != false)
        {
                System.Collections.Generic.Dictionary<System.String, System.Int32> val_3 = TRVPromoCategoriesHandler.PromoQuizzesCompleted;
            val_3.set_Item(key:  quiz.quizCategory, value:  val_3.Item[quiz.quizCategory] + 1);
        }
        else
        {
                TRVPromoCategoriesHandler.PromoQuizzesCompleted.Add(key:  quiz.quizCategory, value:  1);
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "promo_prgss", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TRVPromoCategoriesHandler.PromoQuizzesCompleted));
        bool val_9 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public UnityEngine.Sprite GetIcon(TRVPromoCategory promoCategory)
    {
        UnityEngine.Sprite val_6;
        if(((System.String.IsNullOrEmpty(value:  promoCategory.iconSpriteName)) != true) && (((System.String.op_Equality(a:  promoCategory.iconSpriteName.ToLower(), b:  "generic")) != true) && (this.cachedLoadedSprites != null)))
        {
                if((this.cachedLoadedSprites.ContainsKey(key:  promoCategory.iconSpriteName)) != false)
        {
                UnityEngine.Sprite val_5 = this.cachedLoadedSprites.Item[promoCategory.iconSpriteName];
            return val_6;
        }
        
        }
        
        val_6 = this.genericIcon;
        return val_6;
    }
    public UnityEngine.Sprite GetIcon(string subCategoryName)
    {
        return this.GetIcon(promoCategory:  this.GetPromoCategory(subCategoryName:  subCategoryName));
    }
    public UnityEngine.Sprite GetQuestionImageFromID(string subCategory, string questionID)
    {
        System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_6;
        TRVPromoCategoriesHandler.LogLogic(logic:  "GetQuestionImageFromID " + subCategory + " " + questionID, color:  "ffffff");
        TRVPromoCategoriesHandler.LogLogic(logic:  "cachedLoadedSprites: "("cachedLoadedSprites: ") + PrettyPrint.printJSON(obj:  this.cachedLoadedSprites, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  this.cachedLoadedSprites, types:  false, singleLineOutput:  false)), color:  "ffffff");
        val_6 = this.cachedLoadedSprites;
        if(val_6 == null)
        {
                return (UnityEngine.Sprite)val_6;
        }
        
        if((val_6.ContainsKey(key:  questionID)) != false)
        {
                UnityEngine.Sprite val_5 = this.cachedLoadedSprites.Item[questionID];
            return (UnityEngine.Sprite)val_6;
        }
        
        val_6 = 0;
        return (UnityEngine.Sprite)val_6;
    }
    public bool ShouldShowEndOfQuiz(TRVQuizProgress progress)
    {
        var val_4;
        if((this.GetCurrentQuizReward(progress:  progress)) <= 0)
        {
                return (bool)((this.GetRemainingLevels(progress:  progress)) < 1) ? 1 : 0;
        }
        
        val_4 = 1;
        return (bool)((this.GetRemainingLevels(progress:  progress)) < 1) ? 1 : 0;
    }
    public int GetRemainingLevels(TRVQuizProgress progress)
    {
        TRVPromoCategory val_1 = this.GetPromoCategory(subCategoryName:  progress.quizCategory);
        return val_1.GetRemainingLevelsForPromo(currentPromo:  val_1);
    }
    public int GetRemainingLevelsForPromo(TRVPromoCategory currentPromo)
    {
        System.Collections.Generic.IEnumerable<TSource> val_7;
        System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<System.Int32>(source:  currentPromo.rewards.Keys);
        .currentPromoProgress = val_3.GetActivePromoProgress(subcategory:  currentPromo.subCategoryName);
        val_7 = val_3;
        if((System.Linq.Enumerable.FirstOrDefault<System.Int32>(source:  val_7, predicate:  new System.Func<System.Int32, System.Boolean>(object:  new TRVPromoCategoriesHandler.<>c__DisplayClass35_0(), method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass35_0::<GetRemainingLevelsForPromo>b__0(int x)))) == 0)
        {
                if((public static System.Int32 System.Linq.Enumerable::FirstOrDefault<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = mem[222179988];
        }
        
        val_7 = val_7 - ((TRVPromoCategoriesHandler.<>c__DisplayClass35_0)[1152921517193927440].currentPromoProgress);
        return (int)val_7;
    }
    public bool IsRewardReadyToCollect(TRVQuizProgress progress)
    {
        return (bool)((this.GetCurrentQuizReward(progress:  progress)) > 0) ? 1 : 0;
    }
    public int GetCurrentQuizReward(TRVQuizProgress progress)
    {
        TRVPromoCategory val_1 = this.GetPromoCategory(subCategoryName:  progress.quizCategory);
        if(val_1 == null)
        {
                return 0;
        }
        
        progress = val_1.GetActivePromoProgress(subcategory:  progress.quizCategory);
        if(val_1.rewards == null)
        {
                return 0;
        }
        
        if((val_1.rewards.ContainsKey(key:  progress)) == false)
        {
                return 0;
        }
        
        return val_1.rewards.Item[progress];
    }
    public void CollectReward(TRVQuizProgress progress)
    {
        int val_16;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_17;
        TRVPromoCategory val_1 = this.GetPromoCategory(subCategoryName:  progress.quizCategory);
        if(val_1 == null)
        {
                return;
        }
        
        val_16 = val_1.GetActivePromoProgress(subcategory:  progress.quizCategory);
        val_17 = val_1.rewards;
        if(val_17 == null)
        {
                return;
        }
        
        if((val_17.ContainsKey(key:  val_16)) != false)
        {
                if(val_1.promoCategoryType != 0)
        {
                string val_8 = System.String.Format(format:  "Special Category \'{0}\' Tier {1}", arg0:  val_1.subCategoryName, arg1:  (System.Linq.Enumerable.ToList<System.Int32>(source:  val_1.rewards.Keys).IndexOf(item:  val_16)) + 1);
        }
        else
        {
                string val_9 = System.String.Format(format:  "Promotional Special Category \'{0}\'", arg0:  val_1.subCategoryName);
        }
        
            int val_10 = val_1.rewards.Item[val_16];
            App.Player.AddGems(amount:  val_10, source:  val_9, subsource:  0);
            val_16 = App.Player;
            val_17 = val_16;
            val_17.TrackNonCoinReward(source:  val_9, subSource:  0, rewardType:  "GEMS", rewardAmount:  val_10.ToString(), additionalParams:  0);
        }
        
        if((val_17.IsPromoComplete(currentPromo:  val_1)) == false)
        {
                return;
        }
        
        if(val_1.promoCategoryType != 1)
        {
                return;
        }
        
        this.PutCategoryComplete(categoryId:  val_1.promoId);
        bool val_15 = this.currentPromos.Remove(item:  val_1);
    }
    public string GetExpertForSpecialCategory(string subCategory)
    {
        TRVPromoCategory val_1 = this.GetPromoCategory(subCategoryName:  subCategory);
        TRVPromoCategoriesHandler.LogLogic(logic:  "GetExpertForSpecialCategory " + subCategory + " = "(" = ") + val_1.expertCategoryName, color:  "ff0000");
        return (string)val_1.expertCategoryName;
    }
    public void RequestPromosFromServer()
    {
        this.RequestPromos();
    }
    public static System.Collections.Generic.List<string> GetSpecialCategoriesWithProgress()
    {
        var val_4;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = TRVPromoCategoriesHandler.<>c.<>9__41_0;
        if(val_6 != null)
        {
                return System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String>(source:  TRVPromoCategoriesHandler.PromoQuizzesCompleted, selector:  System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String> val_2 = null));
        }
        
        val_6 = val_2;
        val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String>(object:  TRVPromoCategoriesHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.String TRVPromoCategoriesHandler.<>c::<GetSpecialCategoriesWithProgress>b__41_0(System.Collections.Generic.KeyValuePair<string, int> i));
        TRVPromoCategoriesHandler.<>c.<>9__41_0 = val_6;
        return System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String>(source:  TRVPromoCategoriesHandler.PromoQuizzesCompleted, selector:  val_2));
    }
    private void RequestPromos()
    {
        var val_10;
        System.DateTime val_1 = System.DateTime.Now;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.lastSuccessfulResponse});
        if(val_2._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        if(this.isRequesting == true)
        {
                return;
        }
        
        this.isRequesting = true;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "platform", value:  val_4.GetPlatform());
        Player val_6 = App.Player;
        val_4.Add(key:  "bucket", value:  val_6.playerBucket);
        val_10 = null;
        val_10 = null;
        Player val_7 = App.Player;
        App.networkManager.DoGet(path:  System.String.Format(format:  "/api/special_categories/{0}", arg0:  val_7.id), onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void TRVPromoCategoriesHandler::OnRequestPromoResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), destroy:  false, immediate:  false, getParams:  val_4, timeout:  20);
    }
    private void OnRequestPromoResponse(string url, System.Collections.Generic.Dictionary<string, object> response)
    {
        string val_12;
        var val_13;
        string val_92;
        string val_93;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_94;
        var val_95;
        var val_96;
        string val_97;
        var val_98;
        var val_99;
        System.Collections.IEnumerable val_100;
        var val_101;
        var val_102;
        val_93 = url;
        this.isRequesting = false;
        if((this.CheckResponse(url:  val_93, response:  response)) == false)
        {
                return;
        }
        
        val_93 = val_93 + "\n" + PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false));
        TRVPromoCategoriesHandler.LogLogic(logic:  val_93, color:  "CFC9FC");
        if(response == null)
        {
                throw new NullReferenceException();
        }
        
        val_92 = "special_categories";
        val_94 = 1152921510222861648;
        if((response.ContainsKey(key:  "special_categories")) == false)
        {
                return;
        }
        
        val_93 = 1152921510214912464;
        if(response.Item["special_categories"] == null)
        {
                return;
        }
        
        object val_6 = response.Item["special_categories"];
        if(val_6 != null)
        {
                val_93 = val_6;
        }
        
        val_92 = "OnRequestPromoResponse Error: Failed to parse "("OnRequestPromoResponse Error: Failed to parse ") + PrettyPrint.printJSON(obj:  response.Item["special_categories"], types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  response.Item["special_categories"], types:  false, singleLineOutput:  false));
        TRVPromoCategoriesHandler.LogError(error:  val_92);
        return;
        label_116:
        val_96 = 1152921510214912464;
        if(val_13.MoveNext() == false)
        {
            goto label_16;
        }
        
        TRVPromoCategory val_15 = null;
        .promoId = 0;
        val_15 = new TRVPromoCategory();
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.ContainsKey(key:  "id")) != false)
        {
                object val_17 = val_12.Item["id"];
            if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
            .promoId = System.Int32.Parse(s:  val_17);
        }
        
        if((val_12.ContainsKey(key:  "name")) != false)
        {
                object val_20 = val_12.Item["name"];
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            .subCategoryName = val_20;
        }
        
        if((val_12.ContainsKey(key:  "reward_url")) != false)
        {
                val_97 = "reward_url";
            object val_22 = val_12.Item[val_97];
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            .rewardUrl = val_22;
        }
        
        if((val_12.ContainsKey(key:  "end_time")) != false)
        {
                val_97 = "end_time";
            object val_24 = val_12.Item[val_97];
            if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
            System.DateTime val_25 = SLCDateTime.Parse(dateTime:  val_24);
            .timeEnd = val_25;
        }
        
        if((val_12.ContainsKey(key:  "questions")) != false)
        {
                object val_27 = val_12.Item["questions"];
            if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
            .questionsDataBlock = val_27;
        }
        
        if(((val_12.ContainsKey(key:  "asset_path")) != false) && (val_12.Item["asset_path"] != null))
        {
                val_97 = "asset_path";
            object val_30 = val_12.Item[val_97];
            if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.String.op_Inequality(a:  val_30, b:  "null")) != false)
        {
                val_97 = "asset_path";
            object val_32 = val_12.Item[val_97];
            if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
            .iconUrlPath = val_32;
            string val_92 = "/";
            val_92 = (val_32.LastIndexOf(value:  val_92)) + 1;
            .iconSpriteName = val_32.Substring(startIndex:  val_92);
            val_96 = 1152921510214912464;
        }
        
        }
        
        if((val_12.ContainsKey(key:  "weight")) != false)
        {
                object val_36 = val_12.Item["weight"];
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            .rollWeight = System.Int32.Parse(s:  val_36);
        }
        
        if((val_12.ContainsKey(key:  "difficulty_arrays")) == false)
        {
            goto label_39;
        }
        
        object val_39 = val_12.Item["difficulty_arrays"];
        val_99 = 0;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_41 = null;
        val_94 = val_41;
        val_41 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>();
        .quizDifficultyOrders = val_94;
        Dictionary.Enumerator<TKey, TValue> val_42 = GetEnumerator();
        label_50:
        if(val_13.MoveNext() == false)
        {
            goto label_44;
        }
        
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_94 = (TRVPromoCategory)[1152921517195507152].quizDifficultyOrders;
        if(val_12 == 0)
        {
            goto label_46;
        }
        
        if(X0 == true)
        {
            goto label_47;
        }
        
        throw new NullReferenceException();
        label_46:
        val_100 = 0;
        label_47:
        if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
        val_94.Add(key:  System.Int32.Parse(s:  val_12), value:  System.Linq.Enumerable.ToArray<System.Int32>(source:  System.Linq.Enumerable.Cast<System.Int32>(source:  val_100)));
        goto label_50;
        label_44:
        val_94 = 0;
        val_95 =  + 1;
        mem2[0] = 646;
        val_13.Dispose();
        if(val_94 != 0)
        {
                throw val_94;
        }
        
        if(val_95 != 1)
        {
                var val_48 = ((-296326928 + ((val_95 + 1)) << 2) == 646) ? 1 : 0;
            val_48 = ((val_95 >= 0) ? 1 : 0) & val_48;
            val_95 = val_95 - val_48;
        }
        
        val_94 = 1152921510222861648;
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "Promo category {0} parsed quiz difficulty orders {1} from \"difficulty_arrays\" {2}", arg0:  (TRVPromoCategory)[1152921517195507152].subCategoryName, arg1:  PrettyPrint.printJSON(obj:  (TRVPromoCategory)[1152921517195507152].quizDifficultyOrders, types:  false, singleLineOutput:  true), arg2:  PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  true)), color:  "15EAC1");
        label_39:
        if((val_12.ContainsKey(key:  "unlock_levels")) == false)
        {
            goto label_57;
        }
        
        object val_54 = val_12.Item["unlock_levels"];
        val_101 = 0;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_56 = null;
        val_94 = val_56;
        val_56 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        .quizLenngthLevelUnlocks = val_94;
        Dictionary.Enumerator<TKey, TValue> val_57 = GetEnumerator();
        label_66:
        if(val_13.MoveNext() == false)
        {
            goto label_62;
        }
        
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_94 = (TRVPromoCategory)[1152921517195507152].quizLenngthLevelUnlocks;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
        val_94.Add(key:  System.Int32.Parse(s:  val_12), value:  System.Int32.Parse(s:  val_12));
        goto label_66;
        label_62:
        val_94 = 0;
        val_95 = val_95 + 1;
        mem2[0] = 829;
        val_13.Dispose();
        if(val_94 != 0)
        {
                throw val_94;
        }
        
        if(val_95 != 1)
        {
                var val_61 = ((-296326928 + ((((val_95 + 1) - (val_95 >= 0x0 ? 1 : 0 & -296326928 + ((val_95 + 1)) << 2 == 0x286 ? 1 : 0)) + 1)) << 2) == 829) ? 1 : 0;
            val_61 = ((val_95 >= 0) ? 1 : 0) & val_61;
            val_95 = val_95 - val_61;
        }
        
        val_94 = 1152921510222861648;
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "Promo category {0} parsed quiz length lvl unlocks {1} from \"unlock_levels\" {2}", arg0:  (TRVPromoCategory)[1152921517195507152].subCategoryName, arg1:  PrettyPrint.printJSON(obj:  (TRVPromoCategory)[1152921517195507152].quizLenngthLevelUnlocks, types:  false, singleLineOutput:  true), arg2:  PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  true)), color:  "15EAC1");
        label_57:
        if((val_12.ContainsKey(key:  "rewards")) == false)
        {
            goto label_73;
        }
        
        object val_67 = val_12.Item["rewards"];
        val_102 = 0;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_69 = null;
        val_94 = val_69;
        val_69 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        .rewards = val_94;
        Dictionary.Enumerator<TKey, TValue> val_70 = GetEnumerator();
        label_82:
        if(val_13.MoveNext() == false)
        {
            goto label_78;
        }
        
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_94 = (TRVPromoCategory)[1152921517195507152].rewards;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
        val_94.Add(key:  System.Int32.Parse(s:  val_12), value:  System.Int32.Parse(s:  val_12));
        goto label_82;
        label_78:
        val_94 = 0;
        val_95 = val_95 + 1;
        mem2[0] = 1012;
        val_13.Dispose();
        if(val_94 != 0)
        {
            goto label_83;
        }
        
        if(val_95 != 1)
        {
                var val_74 = ((-296326928 + ((((((val_95 + 1) - (val_95 >= 0x0 ? 1 : 0 & -296326928 + ((val_95 + 1)) << 2 == 0x286 ? 1 : 0)) + 1) - (val_95 >= 0x0 ? 1 : 0 & -296326928 + ((((val_95 + 1) - (val_95 >= 0x0 ? 1 : 0 & -296326928 + ((v) << 2) == 1012) ? 1 : 0;
            val_74 = ((val_95 >= 0) ? 1 : 0) & val_74;
            val_95 = val_95 - val_74;
        }
        
        val_94 = 1152921510222861648;
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "Promo category {0} parsed rewards {1} from \"rewards\" {2}", arg0:  (TRVPromoCategory)[1152921517195507152].subCategoryName, arg1:  PrettyPrint.printJSON(obj:  (TRVPromoCategory)[1152921517195507152].rewards, types:  false, singleLineOutput:  true), arg2:  PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  true)), color:  "15EAC1");
        label_73:
        if((((val_12.ContainsKey(key:  "images")) != false) && (val_12.Item["images"] != null)) && ((val_12.Item["images"] != null) && (null >= 1)))
        {
                val_94 = 0;
            if(null <= val_94)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.LoadQuestionImage(promoCategory:  val_15, imageName:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg);
            val_94 = val_94 + 1;
        }
        
        if((val_12.ContainsKey(key:  "expert")) != false)
        {
                if((val_12.ContainsKey(key:  "expert")) != false)
        {
                val_97 = "expert";
            object val_84 = val_12.Item[val_97];
            if(val_84 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            .expertCategoryName = val_84;
        }
        
        }
        
        if((val_12.ContainsKey(key:  "promotion_type")) != false)
        {
                object val_87 = val_12.Item["promotion_type"];
            if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
            val_97 = val_87;
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_97, ignoreCase:  true)) == null)
        {
                throw new NullReferenceException();
        }
        
            val_97 = null;
            .promoCategoryType = null;
        }
        
        if( == null)
        {
                throw new NullReferenceException();
        }
        
        Add(item:  val_15);
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.IsNullOrEmpty(value:  (TRVPromoCategory)[1152921517195507152].iconSpriteName)) != true)
        {
                this.LoadIcon(promoCategory:  val_15);
        }
        
        System.DateTime val_90 = System.DateTime.Now;
        mem[1152921517195434256] = val_90.dateData;
        goto label_116;
        label_16:
        var val_91 =  + 1;
        mem2[0] = 1336;
        val_13.Dispose();
        return;
        label_83:
        val_98 = val_94;
        val_97 = 0;
        throw val_98;
    }
    private void PutCategoryComplete(int categoryId)
    {
        var val_8;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "special_category_id", value:  categoryId);
        val_1.Add(key:  "rewarded", value:  true);
        val_1.Add(key:  "platform", value:  val_1.GetPlatform());
        Player val_3 = App.Player;
        val_1.Add(key:  "bucket", value:  val_3.playerBucket);
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "Category {0} Complete! This user will no longer hear about this category from the server!", arg0:  categoryId), color:  "819EEE");
        val_8 = null;
        val_8 = null;
        Player val_5 = App.Player;
        App.networkManager.DoPut(path:  System.String.Format(format:  "/api/special_categories/{0}", arg0:  val_5.id), postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void TRVPromoCategoriesHandler::OnGenericResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    private void OnGenericResponse(string url, System.Collections.Generic.Dictionary<string, object> response)
    {
        bool val_1 = this.CheckResponse(url:  url, response:  response);
    }
    private bool CheckResponse(string url, System.Collections.Generic.Dictionary<string, object> response)
    {
        string val_9;
        var val_10;
        string val_13;
        val_9 = url;
        if((response == null) || (response.Count <= 0))
        {
            goto label_2;
        }
        
        if((response.ContainsKey(key:  "success")) == false)
        {
            goto label_3;
        }
        
        if((System.Boolean.Parse(value:  response.Item["success"])) == false)
        {
            goto label_7;
        }
        
        val_10 = 1;
        return (bool)val_10;
        label_2:
        string val_5 = "PROMO RESPONSE ERROR: "("PROMO RESPONSE ERROR: ") + val_9 + "\n-- NO RESPONSE DATA --"("\n-- NO RESPONSE DATA --");
        goto label_9;
        label_3:
        string val_6 = PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false);
        val_13 = "PROMO RESPONSE ERROR: ";
        goto label_12;
        label_7:
        val_13 = "PROMO RESPONSE FAILURE: ";
        label_12:
        label_9:
        val_9 = val_13 + val_9 + "\n" + PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false));
        TRVPromoCategoriesHandler.LogError(error:  val_9);
        val_10 = 0;
        return (bool)val_10;
    }
    private string GetPlatform()
    {
        return (string)(UnityEngine.Application.isEditor != true) ? "android" : DeviceProperties.Platform;
    }
    private System.Collections.Generic.List<string> TryAddingPromoCategories(System.Collections.Generic.List<string> selectedCategories)
    {
        var val_5;
        var val_6;
        var val_27;
        var val_29;
        string val_30;
        int val_31;
        int val_32;
        string val_2 = System.String.Format(format:  "TRVPromoCategoriesHandler :: TryAddingPromoCategories() starting with pre-selected categories {0} ... ", arg0:  PrettyPrint.printJSON(obj:  selectedCategories, types:  false, singleLineOutput:  true));
        TRVPromoCategoriesHandler.LogLogic(logic:  val_2, color:  "56BB46");
        if(val_2.EventShouldShow() == false)
        {
            goto label_5;
        }
        
        if((this.currentPromos == null) || (null <= 0))
        {
            goto label_7;
        }
        
        List.Enumerator<T> val_4 = this.currentPromos.GetEnumerator();
        label_11:
        if(val_6.MoveNext() == false)
        {
            goto label_8;
        }
        
        val_27 = val_5;
        System.Collections.Generic.List<System.Int32> val_8 = this.SeenPromos;
        if(val_27 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8.Contains(item:  val_5 + 40)) == true)
        {
            goto label_11;
        }
        
        TRVPromoCategoriesHandler.LogLogic(logic:  "... Found an unseen promo " + val_5 + 32(val_5 + 32), color:  "56BB46");
        val_29 = 1;
        goto label_14;
        label_5:
        val_30 = "... Event should not show for some reason. Aborting and won\'t show a promo category for this roll.";
        goto label_58;
        label_7:
        val_30 = "... No current promos. Aborting and won\'t show a promo category for this roll.";
        label_58:
        TRVPromoCategoriesHandler.LogLogic(logic:  val_30, color:  "56BB46");
        return (System.Collections.Generic.List<System.String>)selectedCategories;
        label_8:
        val_29 = 0;
        val_27 = 0;
        label_14:
        val_6.Dispose();
        if(val_27 != 0)
        {
            goto label_20;
        }
        
        System.Predicate<TRVPromoCategory> val_12 = new System.Predicate<TRVPromoCategory>(object:  this, method:  System.Boolean TRVPromoCategoriesHandler::<TryAddingPromoCategories>b__48_0(TRVPromoCategory p));
        var val_27 = 1152921517196451232;
        int val_13 = new System.Collections.Generic.List<TRVPromoCategory>(collection:  this.currentPromos).RemoveAll(match:  val_12);
        if(val_12 <= 0)
        {
            goto label_58;
        }
        
        int val_14 = UnityEngine.Random.Range(min:  0, max:  -295166880);
        if(val_27 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_27 = val_27 + (val_14 << 3);
        val_27 = mem[(1152921517196451232 + (val_14) << 3) + 32];
        val_27 = (1152921517196451232 + (val_14) << 3) + 32;
        TRVPromoCategoriesHandler.LogLogic(logic:  "... No unseen promo, but found an incomplete promo " + (1152921517196451232 + (val_14) << 3) + 32 + 32((1152921517196451232 + (val_14) << 3) + 32 + 32), color:  "56BB46");
        label_20:
        System.Collections.Generic.List<System.String> val_16 = new System.Collections.Generic.List<System.String>(collection:  selectedCategories);
        if(val_29 != 0)
        {
                val_16.RemoveAt(index:  0);
            val_16.Add(item:  (1152921517196451232 + (val_14) << 3) + 32 + 32);
            this.AddSeenPromo(promoId:  (1152921517196451232 + (val_14) << 3) + 32 + 40);
            return (System.Collections.Generic.List<System.String>)selectedCategories;
        }
        
        TRVEcon val_17 = App.GetGameSpecificEcon<TRVEcon>();
        Dictionary.Enumerator<TKey, TValue> val_18 = val_17.primaryCategoryOdds.GetEnumerator();
        goto label_34;
        label_35:
        var val_28 = val_5;
        val_28 = 0 + val_28;
        label_34:
        if(val_6.MoveNext() == true)
        {
            goto label_35;
        }
        
        val_6.Dispose();
        RandomSet val_20 = new RandomSet();
        val_20.add(item:  0, weight:  (float)val_28);
        val_20.add(item:  1, weight:  (float)(1152921517196451232 + (val_14) << 3) + 32 + 88);
        int val_21 = val_20.roll(unweighted:  false);
        object[] val_22 = new object[4];
        val_31 = val_22.Length;
        val_22[0] = val_28.ToString();
        if(((1152921517196451232 + (val_14) << 3) + 32 + 32) != 0)
        {
                val_31 = val_22.Length;
        }
        
        val_22[1] = (1152921517196451232 + (val_14) << 3) + 32 + 32;
        val_32 = val_22.Length;
        val_22[2] = (1152921517196451232 + (val_14) << 3) + 32 + 88.ToString();
        object val_25 = (val_21 == 1) ? "Add promo category." : "Keep existing categories.";
        if(val_25 != 0)
        {
                val_32 = val_22.Length;
        }
        
        val_22[3] = val_25;
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "... Rolling to add seen promo.\nKeep existing categories weight: {0}\n{1} promo roll weight: {2}\nRoll result: {3}", args:  val_22), color:  "56BB46");
        if(val_21 != 1)
        {
                return (System.Collections.Generic.List<System.String>)selectedCategories;
        }
        
        val_16.RemoveAt(index:  0);
        val_16.Add(item:  (1152921517196451232 + (val_14) << 3) + 32 + 32);
        return (System.Collections.Generic.List<System.String>)selectedCategories;
    }
    private bool IsPromoComplete(TRVPromoCategory currentPromo)
    {
        System.Collections.Generic.IEnumerable<TSource> val_9;
        .promoProgress = currentPromo.RequiredQuizzesToComplete.GetActivePromoProgress(subcategory:  currentPromo.subCategoryName);
        val_9 = System.Linq.Enumerable.ToList<System.Int32>(source:  currentPromo.rewards.Keys);
        if((System.Linq.Enumerable.FirstOrDefault<System.Int32>(source:  val_9, predicate:  new System.Func<System.Int32, System.Boolean>(object:  new TRVPromoCategoriesHandler.<>c__DisplayClass49_0(), method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass49_0::<IsPromoComplete>b__0(int x)))) == 0)
        {
                if((public static System.Int32 System.Linq.Enumerable::FirstOrDefault<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = mem[222179988];
        }
        
        int val_9 = (TRVPromoCategoriesHandler.<>c__DisplayClass49_0)[1152921517196768768].promoProgress;
        val_9 = val_9 - val_9;
        return (bool)(val_9 < 1) ? 1 : 0;
    }
    private void AddSeenPromo(int promoId)
    {
        this.SeenPromos.Add(item:  promoId);
        UnityEngine.PlayerPrefs.SetString(key:  "seen_promos", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.SeenPromos));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected override object AddProxyEventHandler(ref System.Collections.Generic.List<WGEventHandler> existingEventHandlers)
    {
        TRVPromoCategory val_2;
        var val_3;
        string val_14;
        GameEventV2 val_15;
        TRVPromoCategoriesHandler.LogLogic(logic:  "AddProxyEventHandler! ...", color:  "ffffff");
        if(this.currentPromos == null)
        {
                return 0;
        }
        
        if(("AddProxyEventHandler! ...") < 1)
        {
                return 0;
        }
        
        List.Enumerator<T> val_1 = this.currentPromos.GetEnumerator();
        label_25:
        if(val_3.MoveNext() == false)
        {
            goto label_5;
        }
        
        TRVPromoCategoriesHandler.<>c__DisplayClass51_0 val_5 = null;
        val_15 = 0;
        val_5 = new TRVPromoCategoriesHandler.<>c__DisplayClass51_0();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        .promoCategory = val_2;
        WGEventHandler val_7 = System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  existingEventHandlers, predicate:  new System.Func<WGEventHandler, System.Boolean>(object:  val_5, method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass51_0::<AddProxyEventHandler>b__0(WGEventHandler p)));
        TRVPromoCategoriesProxyEventHandler val_8 = new TRVPromoCategoriesProxyEventHandler();
        GameEventV2 val_9 = null;
        val_15 = 0;
        val_9 = new GameEventV2();
        if(((TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        .timeEnd = (TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory.timeEnd;
        if(((TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory) == null)
        {
                throw new NullReferenceException();
        }
        
        .timeExpire = (TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory.timeEnd;
        val_14 = this;
        .type = val_14;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        .PromoCategory = (TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory;
        val_8.PreInit(eventV2:  val_9);
        val_15 = val_9;
        val_8.Init(eventV2:  val_9);
        val_14 = existingEventHandlers;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_8;
        val_14.Add(item:  val_8);
        if(((TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory) == null)
        {
                throw new NullReferenceException();
        }
        
        TRVPromoCategoriesHandler.LogLogic(logic:  "... ADDED proxy event handler for " + (TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory.subCategoryName((TRVPromoCategoriesHandler.<>c__DisplayClass51_0)[1152921517197133312].promoCategory.subCategoryName), color:  "ffffff");
        goto label_25;
        label_5:
        val_3.Dispose();
        return 0;
    }
    protected override object RemoveExpiredProxyEventHandler(ref System.Collections.Generic.List<WGEventHandler> existingEventHandlers)
    {
        var val_13;
        var val_14;
        TRVPromoCategoriesProxyEventHandler val_15;
        TRVPromoCategoriesHandler.LogLogic(logic:  "RemoveExpiredProxyEventHandler! ...", color:  "ffffff");
        System.Collections.Generic.List<WGEventHandler> val_1 = new System.Collections.Generic.List<WGEventHandler>();
        if(existingEventHandlers == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = 4;
        label_26:
        var val_2 = val_13 - 4;
        if(val_2 >= (mem[existingEventHandlers + 24]))
        {
            goto label_4;
        }
        
        TRVPromoCategoriesHandler.<>c__DisplayClass52_0 val_3 = new TRVPromoCategoriesHandler.<>c__DisplayClass52_0();
        if(existingEventHandlers == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_2 >= (mem[existingEventHandlers + 24]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[existingEventHandlers + 16] + 32) == 0)
        {
            goto label_22;
        }
        
        if(existingEventHandlers == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_2 >= (mem[existingEventHandlers + 24]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = mem[mem[existingEventHandlers + 16] + 32];
        val_14 = mem[existingEventHandlers + 16] + 32;
        if(val_14 != 0)
        {
                val_14 = 0;
        }
        
        .handlerToCheck = ;
        if(mem[1152921517197321072] == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15 = (TRVPromoCategoriesHandler.<>c__DisplayClass52_0)[1152921517197361152].handlerToCheck;
        if((mem[1152921517197321072].Exists(match:  new System.Predicate<TRVPromoCategory>(object:  val_3, method:  System.Boolean TRVPromoCategoriesHandler.<>c__DisplayClass52_0::<RemoveExpiredProxyEventHandler>b__0(TRVPromoCategory p)))) == false)
        {
            goto label_17;
        }
        
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVPromoCategoriesHandler.<>c__DisplayClass52_0)[1152921517197361152].handlerToCheck.PromoCategory) == null)
        {
                throw new NullReferenceException();
        }
        
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.TimeSpan val_8 = (TRVPromoCategoriesHandler.<>c__DisplayClass52_0)[1152921517197361152].handlerToCheck.PromoCategory.timeEnd.Subtract(value:  new System.DateTime() {dateData = val_7.dateData});
        if(val_8._ticks.TotalSeconds > 0f)
        {
            goto label_22;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = (TRVPromoCategoriesHandler.<>c__DisplayClass52_0)[1152921517197361152].handlerToCheck;
        goto label_24;
        label_17:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        label_24:
        val_1.Add(item:  val_15);
        label_22:
        val_13 = val_13 + 1;
        if(existingEventHandlers != null)
        {
            goto label_26;
        }
        
        throw new NullReferenceException();
        label_4:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = val_1.GetEnumerator();
        label_33:
        if(0.MoveNext() == false)
        {
            goto label_28;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        TRVPromoCategoriesHandler.LogLogic(logic:  "... REMOVED proxy event handler for " + 0, color:  "ffffff");
        bool val_13 = existingEventHandlers.Remove(item:  0);
        goto label_33;
        label_28:
        0.Dispose();
        return 0;
    }
    protected override string GetProxyEventTrackingName()
    {
        return "Special Categories";
    }
    private void LoadIcon(TRVPromoCategory promoCategory)
    {
        if(promoCategory == null)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  promoCategory.iconSpriteName)) != false)
        {
                return;
        }
        
        this.LoadImage(urlPath:  promoCategory.iconUrlPath, filename:  promoCategory.iconSpriteName);
    }
    private void LoadQuestionImage(TRVPromoCategory promoCategory, string imageName)
    {
        this.LoadImage(urlPath:  System.String.Format(format:  "trivia/category_promos/{0}/{1}.jpg", arg0:  promoCategory.subCategoryName, arg1:  imageName), filename:  imageName);
    }
    private void LoadImage(string urlPath, string filename)
    {
        TRVPromoCategoriesHandler val_13;
        object val_14;
        System.Action<System.String, UnityEngine.Texture2D> val_15;
        string val_16;
        UnityEngine.Texture2D val_17;
        val_13 = this;
        .filename = filename;
        .<>4__this = val_13;
        val_14 = "https://cdn.12gigs.com/"("https://cdn.12gigs.com/") + urlPath;
        val_15 = "ffffff";
        TRVPromoCategoriesHandler.LogLogic(logic:  System.String.Format(format:  "url: {0} - filename: {1}", arg0:  val_14, arg1:  (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename), color:  "ffffff");
        UnityEngine.Texture2D val_4 = 0;
        if((twelvegigs.net.ImageRequest.LoadFromPreCache(filename:  (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename, textureToSet: out  val_4)) == false)
        {
            goto label_6;
        }
        
        val_14 = "Loading pre cached " + (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename((TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename);
        TRVPromoCategoriesHandler.LogLogic(logic:  val_14, color:  "ffffff");
        val_16 = (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename;
        val_17 = val_4;
        goto label_9;
        label_6:
        if((twelvegigs.net.ImageRequest.ImageInLocal(imgPath:  (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename)) == false)
        {
            goto label_12;
        }
        
        TRVPromoCategoriesHandler.LogLogic(logic:  "Loading local " + (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename((TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename), color:  "ffffff");
        val_17 = twelvegigs.net.ImageRequest.LoadLocally(remoteURL:  val_14, fileName:  (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename);
        val_16 = (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename;
        label_9:
        this.OnImageLoaded(filename:  val_16, texture:  val_17);
        return;
        label_12:
        System.Action<System.String, UnityEngine.Texture2D> val_10 = null;
        val_15 = val_10;
        val_10 = new System.Action<System.String, UnityEngine.Texture2D>(object:  this, method:  System.Void TRVPromoCategoriesHandler::OnImageLoaded(string filename, UnityEngine.Texture2D texture));
        System.Action val_11 = null;
        val_13 = val_11;
        val_11 = new System.Action(object:  new TRVPromoCategoriesHandler.<>c__DisplayClass56_0(), method:  System.Void TRVPromoCategoriesHandler.<>c__DisplayClass56_0::<LoadImage>b__0());
        twelvegigs.net.ImageRequest val_12 = new twelvegigs.net.ImageRequest(url:  val_14, filename:  (TRVPromoCategoriesHandler.<>c__DisplayClass56_0)[1152921517197979856].filename, imgComplete:  val_10, imgError:  val_11, showErrors:  false, destroy:  false, cached:  true, save:  true);
    }
    private void OnImageLoaded(string filename, UnityEngine.Texture2D texture)
    {
        UnityEngine.Object val_11;
        string val_12;
        System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_13;
        val_11 = texture;
        if(val_11 == 0)
        {
                val_12 = "Failed to load texture for " + filename;
            TRVPromoCategoriesHandler.LogError(error:  val_12);
            return;
        }
        
        UnityEngine.Rect val_5 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)val_11.width, height:  (float)val_11.height);
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        val_13 = this.cachedLoadedSprites;
        val_11 = UnityEngine.Sprite.Create(texture:  val_11, rect:  new UnityEngine.Rect() {m_XMin = val_5.m_XMin, m_YMin = val_5.m_YMin, m_Width = val_5.m_Width, m_Height = val_5.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y}, pixelsPerUnit:  100f);
        if(val_13 == null)
        {
                System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_8 = null;
            val_13 = val_8;
            val_8 = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite>();
            this.cachedLoadedSprites = val_13;
        }
        
        if((val_8.ContainsKey(key:  filename)) != false)
        {
                this.cachedLoadedSprites.set_Item(key:  filename, value:  val_11);
        }
        else
        {
                this.cachedLoadedSprites.Add(key:  filename, value:  val_11);
        }
        
        val_12 = "Successfully loaded " + filename;
        TRVPromoCategoriesHandler.LogLogic(logic:  val_12, color:  "ffffff");
    }
    private void OnImageLoaded(string filename, UnityEngine.Sprite sprite)
    {
        System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_4;
        if(sprite == 0)
        {
                return;
        }
        
        val_4 = this.cachedLoadedSprites;
        if(val_4 == null)
        {
                System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite> val_2 = null;
            val_4 = val_2;
            val_2 = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite>();
            this.cachedLoadedSprites = val_4;
        }
        
        if((val_2.ContainsKey(key:  filename)) != false)
        {
                this.cachedLoadedSprites.set_Item(key:  filename, value:  sprite);
            return;
        }
        
        this.cachedLoadedSprites.Add(key:  filename, value:  sprite);
    }
    private static void LogError(string error)
    {
        var val_6;
        UnityEngine.Debug.LogError(message:  "PROMO CATEGORIES: "("PROMO CATEGORIES: ") + error);
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_6 = null;
        val_6 = null;
        TRVPromoCategoriesHandler.log = TRVPromoCategoriesHandler.log + System.String.Format(format:  "<color=#{0}>{1}</color>\n", arg0:  "ff0000", arg1:  error)(System.String.Format(format:  "<color=#{0}>{1}</color>\n", arg0:  "ff0000", arg1:  error));
    }
    private static void LogLogic(string logic, string color = "ffffff")
    {
        string val_6;
        var val_7;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        if(TRVPromoCategoriesHandler.logPromoLogic != false)
        {
                UnityEngine.Debug.Log(message:  "PROMO CATEGORIES: "("PROMO CATEGORIES: ") + logic);
            val_7 = null;
        }
        
        val_7 = null;
        val_6 = TRVPromoCategoriesHandler.log;
        TRVPromoCategoriesHandler.log = val_6 + System.String.Format(format:  "<color=#{0}>{1}</color>\n", arg0:  color, arg1:  logic)(System.String.Format(format:  "<color=#{0}>{1}</color>\n", arg0:  color, arg1:  logic));
    }
    public static string GetLogicLog()
    {
        null = null;
        return (string)TRVPromoCategoriesHandler.log;
    }
    public TRVPromoCategoriesHandler()
    {
        var val_2;
        this.currentPromos = new System.Collections.Generic.List<TRVPromoCategory>();
        val_2 = null;
        val_2 = null;
        this.lastSuccessfulResponse = System.DateTime.MinValue;
    }
    private static TRVPromoCategoriesHandler()
    {
        TRVPromoCategoriesHandler.prefs_promo_quiz_completed_key = 0;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "en");
        TRVPromoCategoriesHandler.supportLangs = val_1;
        TRVPromoCategoriesHandler.CurrentlyShownPromo = 0;
        TRVPromoCategoriesHandler.logPromoLogic = true;
    }
    private bool <TryAddingPromoCategories>b__48_0(TRVPromoCategory p)
    {
        TRVPromoCategory val_6;
        var val_7;
        val_6 = p;
        if((this.IsPromoComplete(currentPromo:  val_6)) != false)
        {
                val_7 = 1;
            return (bool)(val_3._ticks.TotalSeconds <= 0f) ? 1 : 0;
        }
        
        val_6 = p.timeEnd;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = val_6.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        return (bool)(val_3._ticks.TotalSeconds <= 0f) ? 1 : 0;
    }

}
