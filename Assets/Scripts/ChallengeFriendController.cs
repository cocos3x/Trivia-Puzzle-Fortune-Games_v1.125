using UnityEngine;
public class ChallengeFriendController : MonoSingleton<ChallengeFriendController>
{
    // Fields
    private string deeplinkData;
    private string challengeToBeatUniqueId;
    private ChallengeFriendController.ChallengeFriendPacket challengeToBeat;
    private System.TimeSpan challenge_time_taken;
    private int questionIndex;
    private bool waitingForLobby;
    private ChallengeFriendController.ChallengeFriendPacket challengeToShare;
    private string sharableLinkerAppUrl;
    private bool initializedGameScene;
    private const string pref_results_key = "f_c_results";
    private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> loadedChallengeResults;
    
    // Properties
    public ChallengeFriendController.ChallengeFriendPacket ChallengeToShare { get; }
    private int unlockLevel { get; }
    private int levelsBetweenChallengeGen { get; }
    private decimal challengeVictoryReward { get; }
    private bool PlayingChallenge { get; }
    
    // Methods
    public ChallengeFriendController.ChallengeFriendPacket get_ChallengeToShare()
    {
        return (ChallengeFriendPacket)this.challengeToShare;
    }
    private int get_unlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.caf_unlockLevel;
    }
    private int get_levelsBetweenChallengeGen()
    {
        GameEcon val_1 = App.getGameEcon;
        return System.Math.Max(val1:  1, val2:  val_1.caf_frequencyShown);
    }
    private decimal get_challengeVictoryReward()
    {
        GameEcon val_1 = App.getGameEcon;
        return new System.Decimal() {flags = val_1.caf_reward_coins, hi = val_1.caf_reward_coins};
    }
    private bool get_PlayingChallenge()
    {
        return (bool)(this.challengeToBeat != 0) ? 1 : 0;
    }
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ChallengeFriendController::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)));
    }
    public void HandleLinkerAppDeeplink(string linkerUrlDataSerialized)
    {
        SLCDebug.Log(logMessage:  "HandleLinkerAppDeeplink " + linkerUrlDataSerialized, colorHash:  "#FFFFFF", isError:  false);
        object val_2 = MiniJSON.Json.Deserialize(json:  linkerUrlDataSerialized);
        bool val_3 = System.String.IsNullOrEmpty(value:  linkerUrlDataSerialized);
        UnityEngine.Debug.LogError(message:  "ChallengeFriendController Failed to parse deeplink: "("ChallengeFriendController Failed to parse deeplink: ") + linkerUrlDataSerialized);
    }
    public void LevelCompleteClosed()
    {
        this.challengeToShare = 0;
        this.challengeToBeat = 0;
        this.challenge_time_taken = 0;
        mem[1152921516142259621] = 0;
        this.deeplinkData = "";
    }
    public System.TimeSpan GetChallengeToBeatTimeSpan()
    {
        if(this.challengeToBeat == null)
        {
                return 0;
        }
        
        return (System.TimeSpan)this.challengeToBeat.timespan;
    }
    public System.TimeSpan GetMyTimeTakenOnChallenge()
    {
        return (System.TimeSpan)this.challenge_time_taken;
    }
    public void ShareChallenge()
    {
        string val_2 = System.String.Format(format:  "I beat this {0} trivia quiz in {1} seconds. Can you beat my time?", arg0:  this.challengeToShare.subcategory, arg1:  this.challengeToShare.timespan.TotalSeconds);
        twelvegigs.plugins.SharePlugin.Share(text:  val_2, url:  this.sharableLinkerAppUrl, subject:  "Can You Beat My Time?", emailBody:  System.String.Format(format:  "I beat this {0} trivia quiz in {1} seconds. Can you beat my time?", arg0:  this.challengeToShare.subcategory, arg1:  this.challengeToShare.timespan.TotalSeconds), imgPath:  0);
        val_2.TrackChallengeIssued();
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause != false)
        {
                return;
        }
        
        this.DoChallengeChecks();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)
    {
        this.DoChallengeChecks();
    }
    private void DoChallengeChecks()
    {
        if(this.waitingForLobby == true)
        {
            goto label_1;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                this.CheckForChallengeResults();
        }
        
        if(this.waitingForLobby == false)
        {
            goto label_12;
        }
        
        label_1:
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 1)
        {
                this.LoadGameScene();
        }
        
        label_12:
        this.Init();
    }
    private void Init()
    {
        bool val_18;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                if(this.initializedGameScene == true)
        {
                return;
        }
        
            TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
            System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnQuizBegin, b:  new System.Action(object:  this, method:  System.Void ChallengeFriendController::OnQuizBegin()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
            val_2.OnQuizBegin = val_4;
            TRVMainController val_5 = MonoSingleton<TRVMainController>.Instance;
            System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnQuizComplete, b:  new System.Action<System.Boolean, TRVQuizProgress>(object:  this, method:  System.Void ChallengeFriendController::OnQuizComplete(bool success, TRVQuizProgress completedQuizData)));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
            val_5.OnQuizComplete = val_7;
            TRVMainController val_8 = MonoSingleton<TRVMainController>.Instance;
            val_8.GetNewQuizFromFeature = new System.Func<TRVQuizProgress>(object:  this, method:  TRVQuizProgress ChallengeFriendController::GetChallengeFriendQuiz());
            TRVMainController val_10 = MonoSingleton<TRVMainController>.Instance;
            val_10.GetExternalFeatureQuestion = new System.Func<QuestionData>(object:  this, method:  QuestionData ChallengeFriendController::GetNextQuestion());
            TRVMainController val_12 = MonoSingleton<TRVMainController>.Instance;
            val_12.ShowLevelComplete = new System.Func<System.Boolean>(object:  this, method:  System.Boolean ChallengeFriendController::HandleShowingLevelComplete());
            TRVMainController val_14 = MonoSingleton<TRVMainController>.Instance;
            val_14.ShowLevelFailed = new System.Func<System.Boolean>(object:  this, method:  System.Boolean ChallengeFriendController::HandleShowingLevelFailed());
            TRVMainController val_16 = MonoSingleton<TRVMainController>.Instance;
            val_18 = 1;
            val_16.PlayingChallenge = new System.Func<System.Boolean>(object:  this, method:  System.Boolean ChallengeFriendController::CheckPlayingChallenge());
        }
        else
        {
                val_18 = false;
        }
        
        this.initializedGameScene = val_18;
        return;
        label_14:
    }
    private void OnQuizBegin()
    {
    
    }
    private void OnQuizComplete(bool success, TRVQuizProgress completedQuizData)
    {
        var val_2;
        var val_3;
        System.Collections.Generic.List<TRVQuestionHistory> val_23;
        float val_25;
        int val_26;
        float val_28;
        if(this.challengeToBeat == null)
        {
            goto label_1;
        }
        
        if(completedQuizData == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = completedQuizData.previousQuestions;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_1 = val_23.GetEnumerator();
        val_25 = 0f;
        goto label_4;
        label_6:
        val_23 = val_2;
        if(val_23 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_25 = val_25 + val_23.questionTimeTaken;
        label_4:
        if(val_3.MoveNext() == true)
        {
            goto label_6;
        }
        
        val_3.Dispose();
        System.TimeSpan val_6 = System.TimeSpan.FromSeconds(value:  (double)val_25);
        this.challenge_time_taken = val_6;
        return;
        label_1:
        Player val_7 = App.Player;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = val_7.unlockLevel;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_7, knobValue:  val_26)) == false)
        {
            goto label_15;
        }
        
        Player val_10 = App.Player;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_11 = val_10.unlockLevel;
        int val_12 = val_11.levelsBetweenChallengeGen;
        Player val_13 = val_10 - val_11;
        val_13 = val_13 - ((val_13 / val_12) * val_12);
        if(val_13 == null)
        {
            goto label_19;
        }
        
        label_15:
        this.challengeToShare = 0;
        this.deeplinkData = "";
        this.challengeToBeat = 0;
        mem[1152921516143621216] = 0;
        mem[1152921516143621221] = 0;
        return;
        label_19:
        ChallengeFriendController.ChallengeFriendPacket val_15 = new ChallengeFriendController.ChallengeFriendPacket();
        if(completedQuizData == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        .category = completedQuizData.quizCategory;
        if((completedQuizData.<myData>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        .subcategory = completedQuizData.<myData>k__BackingField.subCategory;
        val_23 = completedQuizData.previousQuestions;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_16 = val_23.GetEnumerator();
        val_28 = 0f;
        goto label_25;
        label_29:
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_2.answeredCorrectly != false)
        {
                (ChallengeFriendController.ChallengeFriendPacket)[1152921516143673648].questionIDs.Add(item:  val_2 + 16);
        }
        
        val_28 = val_28 + val_2.questionTimeTaken;
        label_25:
        if(val_3.MoveNext() == true)
        {
            goto label_29;
        }
        
        val_26 = public System.Void List.Enumerator<TRVQuestionHistory>::Dispose();
        val_3.Dispose();
        System.TimeSpan val_20 = System.TimeSpan.FromSeconds(value:  (double)val_28);
        .timespan = val_20;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        .challengerSupportId = val_21.support;
        this.challengeToShare = val_15;
        this.NotifyServerChallengeGenerated();
    }
    private bool HandleShowingLevelComplete()
    {
        var val_14;
        int val_15;
        string val_16;
        int val_17;
        string val_18;
        var val_19;
        var val_20;
        if(this.challengeToBeat == null)
        {
            goto label_1;
        }
        
        this.NotifyServerChallengeCompleted(failedToComplete:  false);
        if((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = this.challenge_time_taken}, t2:  new System.TimeSpan() {_ticks = this.challengeToBeat.timespan})) == 1)
        {
            goto label_4;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_14 = null;
        val_14 = null;
        val_16 = System.String.Format(format:  "You Lost the {0} Challenge Against your Friend", arg0:  this.challengeToBeat.subcategory);
        val_17 = System.Decimal.Powers10.__il2cppRuntimeField_10;
        val_18 = val_16;
        val_2.<metaGameBehavior>k__BackingField.Setup(reward:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = val_17, mid = val_17}, message:  val_18, windowConclusionCallback:  new System.Action(object:  this, method:  System.Void ChallengeFriendController::OnResultsConclusion()));
        val_19 = 0;
        goto label_15;
        label_1:
        val_20 = 0;
        return (bool)val_20;
        label_4:
        Player val_6 = App.Player;
        decimal val_7 = val_6.challengeVictoryReward;
        val_6.AddCredits(amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  "Friend Challenge", subSource:  0, externalParams:  0, doTrack:  true);
        GameBehavior val_8 = App.getBehavior;
        decimal val_10 = val_8.<metaGameBehavior>k__BackingField.challengeVictoryReward;
        val_15 = val_10.flags;
        val_16 = System.String.Format(format:  "You Won the {0} Challenge Against your Friend", arg0:  this.challengeToBeat.subcategory);
        val_17 = val_10.lo;
        val_18 = val_16;
        val_8.<metaGameBehavior>k__BackingField.Setup(reward:  new System.Decimal() {flags = val_15, hi = val_10.hi, lo = val_17, mid = val_10.mid}, message:  val_18, windowConclusionCallback:  new System.Action(object:  this, method:  System.Void ChallengeFriendController::OnResultsConclusion()));
        decimal val_13 = val_8.<metaGameBehavior>k__BackingField.challengeVictoryReward;
        val_19 = 1;
        label_15:
        val_13.flags.TrackChallengeConcluded(won:  true, award:  new System.Decimal() {flags = val_17, hi = val_10.mid, lo = val_18, mid = val_18}, otherPlayerSupportId:  this.challengeToBeat.challengerSupportId);
        val_20 = 1;
        return (bool)val_20;
    }
    private void OnResultsConclusion()
    {
        this.challengeToShare = 0;
        mem[1152921516144040213] = 0;
        this.challengeToBeat = 0;
        this.challenge_time_taken = 0;
        this.deeplinkData = "";
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_280;
    }
    private bool HandleShowingLevelFailed()
    {
        var val_5;
        var val_6;
        if(this.challengeToBeat != null)
        {
                this.NotifyServerChallengeCompleted(failedToComplete:  true);
            GameBehavior val_1 = App.getBehavior;
            val_5 = null;
            val_5 = null;
            val_1.<metaGameBehavior>k__BackingField.Setup(reward:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10}, message:  System.String.Format(format:  "You Lost the {0} Challenge Against your Friend", arg0:  this.challengeToBeat.subcategory), windowConclusionCallback:  new System.Action(object:  this, method:  System.Void ChallengeFriendController::OnResultsConclusion()));
            val_6 = 1;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    private TRVQuizProgress GetChallengeFriendQuiz()
    {
        var val_7 = 0;
        if((System.String.IsNullOrEmpty(value:  this.deeplinkData)) == true)
        {
                return (TRVQuizProgress)val_7;
        }
        
        if((ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].questionIDs >= 1)
        {
                val_7 = 0;
            if((System.String.IsNullOrEmpty(value:  (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].category)) == true)
        {
                return (TRVQuizProgress)val_7;
        }
        
            TRVQuizProgress val_6 = null;
            val_7 = val_6;
            val_6 = new TRVQuizProgress(quizCategoryData:  MonoSingleton<TRVDataParser>.Instance.LoadSubCategoryData(subcategory:  (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].subcategory, primaryCategory:  ""));
            .quizLength = (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].questionIDs;
            .correctAnswerRequirement = (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].questionIDs;
            .quizCategory = (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].category;
            .quizLevel = (ChallengeFriendController.ChallengeFriendPacket)[1152921516144419040].difficultyLevel;
            this.challengeToBeat = new ChallengeFriendController.ChallengeFriendPacket(serialized:  this.deeplinkData);
            return (TRVQuizProgress)val_7;
        }
        
        val_7 = 0;
        return (TRVQuizProgress)val_7;
    }
    private QuestionData GetNextQuestion()
    {
        string val_4;
        var val_5;
        val_4 = this;
        if((this.challengeToBeat != null) && (this.questionIndex < this.challengeToBeat.questionIDs))
        {
                ChallengeFriendPacket val_4 = this.challengeToBeat;
            if(this.questionIndex <= this.questionIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_4 = val_4 + ((this.questionIndex) << 3);
            int val_5 = this.questionIndex;
            val_5 = val_5 + 1;
            this.questionIndex = val_5;
            val_5 = MonoSingleton<TRVDataParser>.Instance.GetQuestionFromID(category:  this.challengeToBeat.category, subCategory:  this.challengeToBeat.subcategory, questionID:  (this.challengeToBeat + (this.questionIndex) << 3).timespan);
            val_4 = "ChallengeFriendController.GetNextQuestion() got question id: "("ChallengeFriendController.GetNextQuestion() got question id: ") + val_2.<questionID>k__BackingField(val_2.<questionID>k__BackingField);
            SLCDebug.Log(logMessage:  val_4, colorHash:  "#FFFFFF", isError:  false);
            return (QuestionData)val_5;
        }
        
        val_5 = 0;
        return (QuestionData)val_5;
    }
    private bool CheckPlayingChallenge()
    {
        return (bool)(this.challengeToBeat != 0) ? 1 : 0;
    }
    private void DumpCachedData()
    {
        this.challengeToShare = 0;
        this.challengeToBeat = 0;
        this.challenge_time_taken = 0;
        mem[1152921516144854357] = 0;
        this.deeplinkData = "";
    }
    private void LoadGameScene()
    {
        var val_5;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        val_5 = null;
        val_5 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 4;
        GameBehavior val_4 = App.getBehavior;
        this.waitingForLobby = false;
    }
    private float GenerateScoreFromTimestamp(System.TimeSpan time)
    {
        float val_2 = (float)time._ticks.TotalSeconds;
        val_2 = 1f / val_2;
        val_2 = val_2 * 100f;
        return (float)val_2;
    }
    private void NotifyServerChallengeGenerated()
    {
        var val_6;
        UnityEngine.Debug.LogError(message:  "Notify server of challenge created so a unique id can be generated, with score conversion from timestamp and possibly level data");
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "level_data", value:  this.challengeToShare.Serialize());
        Player val_3 = App.Player;
        val_1.Add(key:  "user_id", value:  val_3.id);
        float val_6 = (float)this.challengeToShare.timespan.TotalSeconds;
        val_6 = 1f / val_6;
        val_6 = val_6 * 100f;
        val_1.Add(key:  "score", value:  val_6);
        val_6 = null;
        val_6 = null;
        App.networkManager.DoPost(path:  "/api/challenges", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void ChallengeFriendController::<NotifyServerChallengeGenerated>b__41_0(string url, System.Collections.Generic.Dictionary<string, object> responseObj)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void NotifyServerChallengeCompleted(bool failedToComplete = False)
    {
        var val_6;
        float val_7;
        var val_8;
        var val_9;
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_11;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "unique_id", value:  this.challengeToBeatUniqueId);
        val_6 = 1152921504884269056;
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        val_7 = 0f;
        if(failedToComplete != true)
        {
                float val_6 = (float)this.challenge_time_taken.TotalSeconds;
            val_6 = 1f / val_6;
            val_7 = val_6 * 100f;
        }
        
        val_1.Add(key:  "score", value:  val_7);
        val_8 = null;
        val_8 = null;
        val_9 = null;
        val_9 = null;
        val_11 = ChallengeFriendController.<>c.<>9__42_0;
        if(val_11 == null)
        {
                System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_5 = null;
            val_11 = val_5;
            val_5 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  ChallengeFriendController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ChallengeFriendController.<>c::<NotifyServerChallengeCompleted>b__42_0(string url, System.Collections.Generic.Dictionary<string, object> responseObj));
            ChallengeFriendController.<>c.<>9__42_0 = val_11;
        }
        
        App.networkManager.DoPut(path:  System.String.Format(format:  "/api/challenges/{0}", arg0:  this.challengeToBeatUniqueId), postBody:  val_1, onCompleteFunction:  val_5, timeout:  20, destroy:  false, immediate:  false);
    }
    private void CheckForChallengeResults()
    {
        var val_4;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        val_4 = null;
        val_4 = null;
        App.networkManager.DoGet(path:  "/api/challenges", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void ChallengeFriendController::<CheckForChallengeResults>b__43_0(string url, System.Collections.Generic.Dictionary<string, object> responseObj)), destroy:  false, immediate:  false, getParams:  val_1, timeout:  20);
        this.ShowResults();
    }
    private void ShowResults()
    {
        var val_18;
        var val_19;
        string val_20;
        int val_21;
        int val_22;
        var val_23;
        if(this.waitingForLobby == true)
        {
                return;
        }
        
        val_18 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        this.LoadChallengeResults();
        ChallengeFriendController.ChallengeFriendPacket val_3 = null;
        val_19 = val_3;
        val_3 = new ChallengeFriendController.ChallengeFriendPacket(serialized:  X22.Item["level_data"]);
        bool val_6 = System.Boolean.Parse(value:  X22.Item["is_winner"]);
        if(val_6 != false)
        {
                Player val_7 = App.Player;
            decimal val_8 = val_7.challengeVictoryReward;
            val_7.AddCredits(amount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  "Friend Challenge", subSource:  0, externalParams:  0, doTrack:  true);
            GameBehavior val_9 = App.getBehavior;
            val_18 = val_9.<metaGameBehavior>k__BackingField;
            decimal val_11 = val_9.<metaGameBehavior>k__BackingField.challengeVictoryReward;
            val_20 = System.String.Format(format:  "You Won the {0} Challenge Against your Friend", arg0:  (ChallengeFriendController.ChallengeFriendPacket)[1152921516145845680].subcategory);
            val_21 = val_11.flags;
            val_22 = val_11.lo;
        }
        else
        {
                GameBehavior val_13 = App.getBehavior;
            val_18 = val_13.<metaGameBehavior>k__BackingField;
            val_23 = null;
            val_23 = null;
            val_20 = System.String.Format(format:  "You Lost the {0} Challenge Against your Friend", arg0:  (ChallengeFriendController.ChallengeFriendPacket)[1152921516145845680].subcategory);
            val_21 = System.Decimal.Zero;
            val_22 = System.Decimal.Powers10.__il2cppRuntimeField_10;
        }
        
        val_18.Setup(reward:  new System.Decimal() {flags = val_21, hi = val_21, lo = val_22, mid = val_22}, message:  val_20, windowConclusionCallback:  0);
        decimal val_16 = val_18.challengeVictoryReward;
        val_16.flags.TrackChallengeConcluded(won:  val_6, award:  new System.Decimal() {flags = val_22, hi = val_22, lo = val_20, mid = val_20}, otherPlayerSupportId:  X22.Item["challenged_support"]);
        this.loadedChallengeResults.RemoveAt(index:  0);
        this.SaveChallengeResults();
    }
    private string GenerateShareChallengeUrl(string uniqueId)
    {
        int val_12;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "unique_id", value:  uniqueId);
        val_1.Add(key:  "challenge", value:  this.challengeToShare.Serialize());
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "challenge_friend", value:  val_1);
        string val_5 = DeeplinkAction.Base64ForUrlEncode(str:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_3));
        object[] val_6 = new object[4];
        AppConfigs val_7 = App.Configuration;
        val_6[0] = val_7.appConfig.deeplinkScheme;
        AppConfigs val_8 = App.Configuration;
        val_6[1] = (val_8.appConfig.IsProduction() != true) ? "" : "-stage";
        AppConfigs val_11 = App.Configuration;
        val_12 = val_6.Length;
        val_6[2] = val_11.appConfig.domainName;
        if(val_5 != null)
        {
                val_12 = val_6.Length;
        }
        
        val_6[3] = val_5;
        return System.String.Format(format:  "https://{0}-invite{1}.{2}/?c={3}", args:  val_6);
    }
    private void HandleNewChallengeData(string data)
    {
        SLCDebug.Log(logMessage:  "HandleNewChallengeData :: "("HandleNewChallengeData :: ") + data, colorHash:  "#FFFFFF", isError:  false);
        GameBehavior val_2 = App.getBehavior;
        this.deeplinkData = data;
        if((val_2.<metaGameBehavior>k__BackingField) != null)
        {
                this.LoadGameScene();
            return;
        }
        
        this.waitingForLobby = true;
    }
    private void LoadChallengeResults()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_5;
        if((this.loadedChallengeResults == null) && ((UnityEngine.PlayerPrefs.HasKey(key:  "f_c_results")) != false))
        {
                val_5 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "f_c_results", defaultValue:  31047704));
        }
        else
        {
                System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_4 = null;
            val_5 = val_4;
            val_4 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        }
        
        this.loadedChallengeResults = val_5;
    }
    private void SaveChallengeResults()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_4 = this.loadedChallengeResults;
        if(val_4 == null)
        {
                return;
        }
        
        if(true > 0)
        {
            goto label_2;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "f_c_results")) == false)
        {
            goto label_3;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "f_c_results");
        goto label_4;
        label_3:
        val_4 = this.loadedChallengeResults;
        label_2:
        UnityEngine.PlayerPrefs.SetString(key:  "f_c_results", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_4));
        label_4:
        this.loadedChallengeResults = 0;
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void TrackChallengeConcluded(bool won, decimal award, string otherPlayerSupportId)
    {
        var val_4;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "Friend Challenge Won", value:  won);
        decimal val_3 = val_2.challengeVictoryReward;
        val_2.Add(key:  "Award", value:  val_3);
        val_2.Add(key:  "Challenger ID", value:  otherPlayerSupportId);
        val_4 = null;
        val_4 = null;
        App.trackerManager.track(eventName:  "Challenge Friend End", data:  val_2);
    }
    private void TrackChallengeIssued()
    {
        TrackingComponent.CurrentIntent = 10;
    }
    public ChallengeFriendController()
    {
        this.deeplinkData = "";
        this.sharableLinkerAppUrl = "";
    }
    private void <NotifyServerChallengeGenerated>b__41_0(string url, System.Collections.Generic.Dictionary<string, object> responseObj)
    {
        UnityEngine.Debug.LogError(message:  "POST " + url + " :\n"(" :\n") + PrettyPrint.printJSON(obj:  responseObj, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  responseObj, types:  false, singleLineOutput:  false)));
        if((responseObj.ContainsKey(key:  "unique_id")) == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  responseObj.Item["unique_id"])) != false)
        {
                return;
        }
        
        object val_6 = responseObj.Item["unique_id"];
        string val_7 = this.GenerateShareChallengeUrl(uniqueId:  val_6);
        this.sharableLinkerAppUrl = val_7;
        SLCDebug.Log(logMessage:  "unique challenge id = "("unique challenge id = ") + val_6 + "\nsharableLinkerAppUrl = "("\nsharableLinkerAppUrl = ") + val_7, colorHash:  "#FFFFFF", isError:  false);
    }
    private void <CheckForChallengeResults>b__43_0(string url, System.Collections.Generic.Dictionary<string, object> responseObj)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9;
        var val_10;
        string val_16;
        string val_17;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_19;
        val_16 = "GET " + url + " :\n"(" :\n") + PrettyPrint.printJSON(obj:  responseObj, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  responseObj, types:  false, singleLineOutput:  false));
        SLCDebug.Log(logMessage:  val_16, colorHash:  "#FFFFFF", isError:  false);
        if(responseObj == null)
        {
                return;
        }
        
        val_16 = "unrewarded_challenges";
        if((responseObj.ContainsKey(key:  "unrewarded_challenges")) == false)
        {
                return;
        }
        
        val_17 = "unrewarded_challenges";
        object val_4 = responseObj.Item[val_17];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.IsNullOrEmpty(value:  val_4)) == true)
        {
                return;
        }
        
        val_17 = "unrewarded_challenges";
        object val_6 = responseObj.Item[val_17];
        if(val_6 == null)
        {
                return;
        }
        
        List.Enumerator<T> val_8 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_6) : 0.GetEnumerator();
        label_23:
        if(val_10.MoveNext() == false)
        {
            goto label_14;
        }
        
        ChallengeFriendController.<>c__DisplayClass43_0 val_12 = null;
        val_17 = 0;
        val_12 = new ChallengeFriendController.<>c__DisplayClass43_0();
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18 = val_9;
        if(val_18 != 0)
        {
                val_17 = null;
        }
        
        .unresolvedChallengeResult = val_18;
        val_18 = this;
        this.LoadChallengeResults();
        val_19 = this.loadedChallengeResults;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_19.Exists(match:  new System.Predicate<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_12, method:  System.Boolean ChallengeFriendController.<>c__DisplayClass43_0::<CheckForChallengeResults>b__1(System.Collections.Generic.Dictionary<string, object> x)))) == true)
        {
            goto label_23;
        }
        
        val_19 = this.loadedChallengeResults;
        val_19.Add(item:  (ChallengeFriendController.<>c__DisplayClass43_0)[1152921516147304528].unresolvedChallengeResult);
        goto label_23;
        label_14:
        val_10.Dispose();
        this.SaveChallengeResults();
        this.ShowResults();
    }

}
