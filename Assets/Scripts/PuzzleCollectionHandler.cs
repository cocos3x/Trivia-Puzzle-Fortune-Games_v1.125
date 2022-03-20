using UnityEngine;
public class PuzzleCollectionHandler : WGEventHandler
{
    // Fields
    private static PuzzleCollectionHandler _Instance;
    public const string PUZZLE_COLLECTION_EVENT_ID = "PuzzleCollection";
    public const int DEFAULT_PIECES_TOTAL_COUNT = 16;
    public const string DEFAULT_PUZZLE_IMAGE_FILE_EXTENSION = "png";
    private const string LAST_COLLECTED_PIECES_COUNT_KEY = "pzl_pc_last_ct";
    private const string COLLECTED_PIECES_COUNT_KEY = "pzl_pc_ct";
    private const string PUZZLE_PROGRESS_KEY = "pzl_pc_rvld";
    private const string NEW_PUZZLE_PIECES_KEY = "pzl_pcs_new";
    private const string REWARD_TYPE_KEY = "pzl_rwdtype";
    private const string REWARD_VALUE_KEY = "pzl_rwd";
    private const string BASEURL_KEY = "pzl_base_url";
    private const string PUZZLE_COLLECTION_EVENT_SERVER_TIME_STAMP_KEY = "pzl_evt_svr_tmstmp";
    private const string PUZZLE_COLLECTION_EVENT_IS_NEW_CYCLE_KEY = "pzl_evt_nw_ccl";
    private const string PUZZLES_KEY = "pzl_pzls";
    private const string COMPLETED_PUZZLES_KEY = "pzl_cmpltd_pzls";
    private const string CURRENT_PUZZLE_NAME_KEY = "pzl_crt_nm";
    private const string NEXT_PUZZLE_NAME_KEY = "pzl_nxt_nm";
    private const string IS_FTUX_KEY = "pzl_ftux";
    private const string EARNED_PUZZLE_PIECE_KEY = "pzl_earned_pc";
    private const string LEVEL_RESET_KEY = "pzl_lvl_rst";
    private const string LIFETIME_PUZZLES_COMPLETED_KEY = "lftm_pzl_cmpltd";
    private const string LAST_PROGRESS_STAMP_KEY = "pzl_lst_prog_ts";
    private const string LAST_PUZZLE_NAME_KEY = "pzl_last_nm";
    private const string pref_is_ready_to_reward = "pzl_is_ready_rw";
    private const string ECONOMY = "economy";
    private const string REWARD = "reward_v2";
    private const string BASE_URL = "base_url";
    private const string PUZZLES = "puzzles";
    private const string REWARD_COINS = "coins";
    private const string REWARD_BONUS_WHEEL = "bonus_wheel";
    private const string REWARD_BONUS_SPIN = "bonus_spin";
    private const string INTERVALS = "intervals";
    private const string PUZZLE_TIME_UPPER = "PUZZLE TIME";
    private const GameEventRewardType DEFAULT_REWARD_TYPE = 1;
    private const int DEFAULT_REWARD_VALUE = 35;
    private const string DEFAULT_BASE_URL = "https://cdn.12gigs.com/guess_the_word_pngs/REPLACEME.png";
    private const string DEFAULT_EVENT_TIME_STAMP = "";
    private const bool DEFAULT_IS_NEW_CYCLE = True;
    private const string DEFAULT_INIT_PUZZLE_NAME = "";
    private const bool DEFAULT_IS_FTUX = True;
    private const bool DEFAULT_EARNED_PUZZLE_PIECE = False;
    private const bool DEFAULT_LEVEL_RESET = False;
    private const int DEFAULT_LIFETIME_PUZZLES_COMPLETED = 0;
    private bool shownCompletePopup;
    private PuzzleCollectionV2_EventProgress eventProgress;
    public System.Action OnPuzzlePieceCollected;
    public System.Action OnPuzzlePieceGivenAdditionalChance;
    
    // Properties
    public static PuzzleCollectionHandler Instance { get; }
    public static bool EarnedPuzzlePiece { get; set; }
    public static int CollectedPiecesCount { get; }
    public static int[] CurrentPuzzleProgress { get; set; }
    public static int[] NewPuzzlePieces { get; set; }
    public static GameEventRewardType RewardType { get; set; }
    public static int RewardValue { get; set; }
    public static bool IsNewCycle { get; set; }
    public static string CurrentPuzzleName { get; set; }
    public static string LastPuzzleName { get; set; }
    public static bool IsFTUX { get; set; }
    public static int LifetimePuzzlesCompleted { get; set; }
    public bool PlayingChallenge { get; }
    private string PuzzleCollectionEventServerTimeStamp { get; set; }
    private string BaseURL { get; set; }
    private string[] Puzzles { get; set; }
    private string[] CompletedPuzzles { get; set; }
    private string NextPuzzleName { get; set; }
    private bool LevelIsReset { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    private bool isReadyToReward { get; set; }
    
    // Methods
    public static PuzzleCollectionHandler get_Instance()
    {
        return (PuzzleCollectionHandler)PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED;
    }
    public static bool get_EarnedPuzzlePiece()
    {
        return PlayerPrefsX.GetBool(name:  "pzl_earned_pc", defaultValue:  false);
    }
    public static void set_EarnedPuzzlePiece(bool value)
    {
        bool val_2 = PlayerPrefsX.SetBool(name:  "pzl_earned_pc", value:  value);
    }
    public static int get_CollectedPiecesCount()
    {
        var val_3;
        System.Func<System.Int32, System.Boolean> val_5;
        val_3 = null;
        val_3 = null;
        val_5 = PuzzleCollectionHandler.<>c.<>9__10_0;
        if(val_5 != null)
        {
                return System.Linq.Enumerable.Count<System.Int32>(source:  PuzzleCollectionHandler.CurrentPuzzleProgress, predicate:  System.Func<System.Int32, System.Boolean> val_2 = null);
        }
        
        val_5 = val_2;
        val_2 = new System.Func<System.Int32, System.Boolean>(object:  PuzzleCollectionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PuzzleCollectionHandler.<>c::<get_CollectedPiecesCount>b__10_0(int x));
        PuzzleCollectionHandler.<>c.<>9__10_0 = val_5;
        return System.Linq.Enumerable.Count<System.Int32>(source:  PuzzleCollectionHandler.CurrentPuzzleProgress, predicate:  val_2);
    }
    public static int[] get_CurrentPuzzleProgress()
    {
        return PlayerPrefsX.GetIntArray(key:  "pzl_pc_rvld", defaultValue:  0, defaultSize:  16);
    }
    public static void set_CurrentPuzzleProgress(int[] value)
    {
        bool val_1 = PlayerPrefsX.SetIntArray(key:  "pzl_pc_rvld", intArray:  value);
    }
    public static int[] get_NewPuzzlePieces()
    {
        return PlayerPrefsX.GetIntArray(key:  "pzl_pcs_new", defaultValue:  0, defaultSize:  0);
    }
    public static void set_NewPuzzlePieces(int[] value)
    {
        bool val_1 = PlayerPrefsX.SetIntArray(key:  "pzl_pcs_new", intArray:  value);
    }
    public static GameEventRewardType get_RewardType()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_rwdtype")) == false)
        {
                return 1;
        }
        
        return UnityEngine.PlayerPrefs.GetInt(key:  "pzl_rwdtype");
    }
    public static void set_RewardType(GameEventRewardType value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pzl_rwdtype", value:  value);
    }
    public static int get_RewardValue()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "pzl_rwd", defaultValue:  35);
    }
    public static void set_RewardValue(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pzl_rwd", value:  value);
    }
    public static bool get_IsNewCycle()
    {
        return PlayerPrefsX.GetBool(name:  "pzl_evt_nw_ccl", defaultValue:  true);
    }
    public static void set_IsNewCycle(bool value)
    {
        bool val_2 = PlayerPrefsX.SetBool(name:  "pzl_evt_nw_ccl", value:  value);
    }
    public static string get_CurrentPuzzleName()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "pzl_crt_nm", defaultValue:  "");
    }
    public static void set_CurrentPuzzleName(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pzl_crt_nm", value:  value);
    }
    public static string get_LastPuzzleName()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "pzl_last_nm", defaultValue:  "");
    }
    public static void set_LastPuzzleName(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pzl_last_nm", value:  value);
    }
    public static bool get_IsFTUX()
    {
        return PlayerPrefsX.GetBool(name:  "pzl_ftux", defaultValue:  true);
    }
    public static void set_IsFTUX(bool value)
    {
        bool val_2 = PlayerPrefsX.SetBool(name:  "pzl_ftux", value:  value);
    }
    public static int get_LifetimePuzzlesCompleted()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "lftm_pzl_cmpltd", defaultValue:  0);
    }
    public static void set_LifetimePuzzlesCompleted(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "lftm_pzl_cmpltd", value:  value);
    }
    public bool get_PlayingChallenge()
    {
        int val_4;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                val_4 = PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED;
            if(val_4 == 0)
        {
                return (bool)val_4;
        }
        
            if(((val_4 & 1) == 0) && (SceneDictator.IsInGameScene() != false))
        {
                if((this.eventProgress.levelsLapsed & 2147483648) == 0)
        {
                if(this.eventProgress.levelsLapsed <= this.eventProgress.levelInterval)
        {
                return this.IsSolvingInProgress();
        }
        
        }
        
            val_4 = 1;
            return (bool)val_4;
        }
        
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    private string get_PuzzleCollectionEventServerTimeStamp()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "pzl_evt_svr_tmstmp", defaultValue:  "");
    }
    private void set_PuzzleCollectionEventServerTimeStamp(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pzl_evt_svr_tmstmp", value:  value);
    }
    private string get_BaseURL()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "pzl_base_url", defaultValue:  "https://cdn.12gigs.com/guess_the_word_pngs/REPLACEME.png");
    }
    private void set_BaseURL(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pzl_base_url", value:  value);
    }
    private string[] get_Puzzles()
    {
        return PlayerPrefsX.GetStringArray(key:  "pzl_pzls");
    }
    private void set_Puzzles(string[] value)
    {
        bool val_1 = PlayerPrefsX.SetStringArray(key:  "pzl_pzls", stringArray:  value);
    }
    private string[] get_CompletedPuzzles()
    {
        return PlayerPrefsX.GetStringArray(key:  "pzl_cmpltd_pzls");
    }
    private void set_CompletedPuzzles(string[] value)
    {
        bool val_1 = PlayerPrefsX.SetStringArray(key:  "pzl_cmpltd_pzls", stringArray:  value);
    }
    private string get_NextPuzzleName()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "pzl_nxt_nm", defaultValue:  "");
    }
    private void set_NextPuzzleName(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pzl_nxt_nm", value:  value);
    }
    private bool get_LevelIsReset()
    {
        return PlayerPrefsX.GetBool(name:  "pzl_lvl_rst", defaultValue:  false);
    }
    private void set_LevelIsReset(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "pzl_lvl_rst", value:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "pzl_lst_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pzl_lst_prog_ts", value:  value);
    }
    private bool get_isReadyToReward()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "pzl_is_ready_rw", defaultValue:  0)) == 1) ? 1 : 0;
    }
    private void set_isReadyToReward(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "pzl_is_ready_rw", value:  value);
    }
    private void RefreshPuzzleCollectionInfo(GameEventV2 eventV2)
    {
        mem[1152921516349707216] = eventV2;
        if(eventV2 == null)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  eventV2.type, b:  "PuzzleCollection")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        bool val_4 = this.IsEventNewCycle();
        if(val_4 != false)
        {
                this.ClearEventProgress();
            this.SetupServerTimestamp();
        }
        else
        {
                bool val_5 = val_4.isReadyToReward;
            if((val_5 != false) && (this.shownCompletePopup != true))
        {
                val_5.ShowPuzzleCompletePopup();
        }
        
        }
        
        this.InitPuzzleCollectionInfo(data:  this.shownCompletePopup + 104);
        this.RefreshCurrentPuzzleInfo(data:  this.shownCompletePopup + 104);
        this = MonoSingleton<PuzzleCollectionUIController>.Instance;
        if(this == 0)
        {
                return;
        }
        
        MonoSingleton<PuzzleCollectionUIController>.Instance.UpdatePuzzleCollectionUI();
    }
    private void CheckIfCurrentPuzzleImageExists()
    {
        bool val_5 = UnityEngine.Object.op_Equality(x:  ImageLoadingController.GetSprite(path:  UnityEngine.Application.temporaryCachePath + "/"("/") + PuzzleCollectionHandler.CurrentPuzzleName + ".png"), y:  0);
        if(val_5 == false)
        {
                return;
        }
        
        RemoteResourcesLoadingController.DownloadItem(uri:  val_5.BaseURL.Replace(oldValue:  "REPLACEME", newValue:  PuzzleCollectionHandler.CurrentPuzzleName), fileName:  PuzzleCollectionHandler.CurrentPuzzleName, fileExtention:  "png", localDirectory:  UnityEngine.Application.temporaryCachePath, callback:  new System.Action<System.Boolean, System.Byte[]>(object:  this, method:  System.Void PuzzleCollectionHandler::ImageDownloadCallback(bool isRequestSuccess, byte[] data)));
    }
    private void SetupServerTimestamp()
    {
        string val_2 = X8 + 16.ToString();
        val_2.PuzzleCollectionEventServerTimeStamp = val_2;
    }
    private void InitPuzzleCollectionInfo(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_8;
        string val_9;
        string val_37;
        string val_38;
        var val_39;
        var val_40;
        var val_41;
        GameEventRewardType val_42;
        var val_43;
        System.Collections.Generic.IEnumerable<TSource> val_44;
        var val_45;
        System.Func<System.Object, System.String> val_47;
        int val_48;
        var val_49;
        var val_50;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_36 = data;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = val_36;
        val_38 = "economy";
        if((val_37.ContainsKey(key:  val_38)) == false)
        {
                throw new NullReferenceException();
        }
        
        val_38 = "economy";
        object val_2 = val_36.Item[val_38];
        val_39 = 0;
        if(val_39 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((ContainsKey(key:  "reward_v2")) == false)
        {
            goto label_8;
        }
        
        val_38 = "reward_v2";
        if(Item[val_38] == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_6 = GetEnumerator();
        val_40 = "coins";
        val_41 = "bonus_wheel";
        label_22:
        val_38 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_37 = val_9;
        int val_11 = 0;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_11 < 1) || (((System.Int32.TryParse(s:  val_37, result: out  val_11)) ^ 1) == true))
        {
            goto label_22;
        }
        
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_15 = val_9.Trim().ToLower();
        if((System.String.Compare(strA:  val_15, strB:  "coins")) == 0)
        {
            goto label_20;
        }
        
        if((System.String.Compare(strA:  val_15, strB:  "bonus_wheel")) == 0)
        {
            goto label_21;
        }
        
        if((System.String.Compare(strA:  val_15, strB:  "bonus_spin")) != 0)
        {
            goto label_22;
        }
        
        val_42 = 4;
        goto label_25;
        label_14:
        val_8.Dispose();
        PuzzleCollectionHandler.RewardType = 1;
        val_43 = 35;
        goto label_24;
        label_20:
        val_42 = 1;
        goto label_25;
        label_21:
        val_42 = 3;
        label_25:
        val_8.Dispose();
        PuzzleCollectionHandler.RewardType = val_42;
        val_43 = val_11;
        label_24:
        PuzzleCollectionHandler.RewardValue = 0;
        label_8:
        if((ContainsKey(key:  "base_url")) != false)
        {
                val_38 = "base_url";
            object val_20 = Item[val_38];
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_20.BaseURL = val_20;
        }
        
        val_44 = "puzzles";
        if((ContainsKey(key:  "puzzles")) != false)
        {
                object val_22 = Item["puzzles"];
            val_41 = 1152921504920211456;
            val_44 = System.Linq.Enumerable.Cast<System.Object>(source:  X0);
            val_45 = null;
            val_45 = null;
            val_47 = PuzzleCollectionHandler.<>c.<>9__110_0;
            if(val_47 == null)
        {
                System.Func<System.Object, System.String> val_24 = null;
            val_47 = val_24;
            val_24 = new System.Func<System.Object, System.String>(object:  PuzzleCollectionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.String PuzzleCollectionHandler.<>c::<InitPuzzleCollectionInfo>b__110_0(object x));
            PuzzleCollectionHandler.<>c.<>9__110_0 = val_47;
        }
        
            val_38 = public static TSource[] System.Linq.Enumerable::ToArray<System.String>(System.Collections.Generic.IEnumerable<TSource> source);
            TSource[] val_26 = System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Select<System.Object, System.String>(source:  val_44, selector:  val_24));
            if(this == null)
        {
                throw new NullReferenceException();
        }
        
            val_26.Puzzles = val_26;
        }
        
        val_48 = "intervals";
        if((ContainsKey(key:  "intervals")) == false)
        {
                return;
        }
        
        val_38 = "intervals";
        object val_28 = Item[val_38];
        if(val_28 == null)
        {
                return;
        }
        
        var val_29 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_28) : 0;
        if((val_29.ContainsKey(key:  "min")) != false)
        {
                val_38 = "min";
            object val_31 = val_29.Item[val_38];
            if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = 1152921504920371200;
            val_49 = null;
            val_49 = null;
            PuzzleCollectionEcon.min_lvl_interval = System.Int32.Parse(s:  val_31);
        }
        
        if((val_29.ContainsKey(key:  "max")) == false)
        {
                return;
        }
        
        val_38 = "max";
        object val_34 = val_29.Item[val_38];
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48 = System.Int32.Parse(s:  val_34);
        val_50 = null;
        val_50 = null;
        PuzzleCollectionEcon.max_lvl_interval = val_48;
    }
    private void RefreshCurrentPuzzleInfo(System.Collections.Generic.Dictionary<string, object> data)
    {
        if((data.ContainsKey(key:  "puzzles")) != false)
        {
                object val_2 = data.Item["puzzles"];
        }
        
        if((System.String.IsNullOrEmpty(value:  PuzzleCollectionHandler.CurrentPuzzleName)) != false)
        {
                this.DownloadNewPuzzleImage();
            this.ResetPuzzleProgress();
            return;
        }
        
        this.CheckIfCurrentPuzzleImageExists();
    }
    private bool IsEventNewCycle()
    {
        return System.String.op_Inequality(a:  this.PuzzleCollectionEventServerTimeStamp, b:  X8 + 16.ToString());
    }
    private bool IsPuzzlePoolDepleted()
    {
        System.String[] val_2 = this.CompletedPuzzles.Puzzles;
        return (bool)(val_1.Length == val_2.Length) ? 1 : 0;
    }
    private string GetNewPuzzleName()
    {
        PuzzleCollectionHandler val_13;
        System.Collections.Generic.IEnumerable<TSource> val_14;
        val_13 = this;
        System.Collections.Generic.List<System.String> val_2 = null;
        val_14 = val_2;
        val_2 = new System.Collections.Generic.List<System.String>(collection:  this.Puzzles);
        if(val_2.IsPuzzlePoolDepleted() == true)
        {
            goto label_4;
        }
        
        PuzzleCollectionHandler.<>c__DisplayClass114_0 val_4 = new PuzzleCollectionHandler.<>c__DisplayClass114_0();
        .<>4__this = val_13;
        .i = 0;
        System.String[] val_5 = val_4.CompletedPuzzles;
        val_13 = 0;
        label_5:
        if(val_13 >= val_5.Length)
        {
            goto label_4;
        }
        
        System.Collections.Generic.List<TSource> val_8 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Where<System.String>(source:  val_2, predicate:  new System.Func<System.String, System.Boolean>(object:  val_4, method:  System.Boolean PuzzleCollectionHandler.<>c__DisplayClass114_0::<GetNewPuzzleName>b__0(string n))));
        val_14 = val_8;
        val_13 = ((PuzzleCollectionHandler.<>c__DisplayClass114_0)[1152921516351191488].i) + 1;
        .i = val_13;
        if(val_8.CompletedPuzzles != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_4:
        var val_12 = 1152921504858656768;
        RandomSet val_10 = new RandomSet();
        val_10.addIntRange(lowest:  0, highest:  44364199);
        int val_11 = val_10.roll(unweighted:  false);
        if(val_12 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_12 = val_12 + (val_11 << 3);
        return (string)(1152921504858656768 + (val_11) << 3) + 32;
    }
    private void DownloadNewPuzzleImage()
    {
        string val_1 = this.GetNewPuzzleName();
        val_1.NextPuzzleName = val_1;
        string val_2 = val_1.BaseURL;
        string val_4 = val_2.Replace(oldValue:  "REPLACEME", newValue:  val_2.NextPuzzleName);
        RemoteResourcesLoadingController.DownloadItem(uri:  val_4, fileName:  val_4.NextPuzzleName, fileExtention:  "png", localDirectory:  UnityEngine.Application.temporaryCachePath, callback:  new System.Action<System.Boolean, System.Byte[]>(object:  this, method:  System.Void PuzzleCollectionHandler::ImageDownloadCallback(bool isRequestSuccess, byte[] data)));
    }
    private void ImageDownloadCallback(bool isRequestSuccess, byte[] data)
    {
        if(isRequestSuccess == false)
        {
                return;
        }
        
        if(data.Length == 0)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.IsNewCycle == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_2.<metaGameBehavior>k__BackingField.ShowPuzzleProgressPopup();
    }
    private void ShowPuzzleProgressPopup()
    {
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGPuzzleProgressPopup>(showNext:  false);
    }
    private void ShowPuzzleCompletePopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGPuzzleCompletePopup>(showNext:  true);
    }
    private void ResetPuzzleProgress()
    {
        int[] val_1 = new int[16];
        PuzzleCollectionHandler.CurrentPuzzleProgress = val_1;
        PuzzleCollectionHandler.CurrentPuzzleName = val_1.NextPuzzleName;
    }
    private void ClearEventProgress()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_pc_last_ct")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_pc_last_ct");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_pc_ct")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_pc_ct");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_pc_rvld")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_pc_rvld");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_rwdtype")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_rwdtype");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_rwd")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_rwd");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_base_url")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_base_url");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_evt_svr_tmstmp")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_evt_svr_tmstmp");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_evt_nw_ccl")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_evt_nw_ccl");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_pzls")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_pzls");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_cmpltd_pzls")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_cmpltd_pzls");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_crt_nm")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_crt_nm");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_nxt_nm")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_nxt_nm");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_ftux")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_ftux");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_earned_pc")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_earned_pc");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_lvl_rst")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_lvl_rst");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_lst_prog_ts")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_lst_prog_ts");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_last_nm")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_last_nm");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pzl_is_ready_rw")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pzl_is_ready_rw");
        }
        
        this.eventProgress.Delete();
    }
    private void DeletePlayerpref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    private bool IsNewPuzzlePieceReady()
    {
        if(this.eventProgress != null)
        {
                if((this.eventProgress.levelsLapsed & 2147483648) != 0)
        {
                return true;
        }
        
            return (bool)(this.eventProgress.levelsLapsed > this.eventProgress.levelInterval) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public bool IsCurrentGameModeEqualsPuzzleLastMode()
    {
        var val_6;
        if(this.eventProgress.lastMode != PlayingLevel.CurrentGameplayMode)
        {
            goto label_13;
        }
        
        if(PlayingLevel.CurrentGameplayMode != 4)
        {
            goto label_7;
        }
        
        bool val_4 = System.Int32.TryParse(s:  this.eventProgress.lastModeSecondaryId, result: out  0);
        CategoryPacksManager val_5 = MonoSingleton<CategoryPacksManager>.Instance;
        if((val_5.<CurrentCategoryPackInfo>k__BackingField.packId) != 0)
        {
            goto label_13;
        }
        
        label_7:
        val_6 = 1;
        return (bool)val_6;
        label_13:
        val_6 = 0;
        return (bool)val_6;
    }
    public bool IsSolvingInProgress()
    {
        int val_4;
        var val_5;
        val_4 = this;
        if(this.IsCurrentGameModeEqualsPuzzleLastMode() != false)
        {
                val_4 = this.eventProgress.lastLevel;
            var val_3 = (val_4 == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    private int GetLevelInterval()
    {
        null = null;
        return UnityEngine.Random.Range(min:  PuzzleCollectionEcon.min_lvl_interval, max:  PuzzleCollectionEcon.max_lvl_interval + 1);
    }
    public override void Init(GameEventV2 eventV2)
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                Player val_3 = App.Player;
            UnityEngine.Debug.LogWarning(message:  "Player ID: "("Player ID: ") + val_3.id);
        }
        
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED = this;
        this.eventProgress.Load();
        this.RefreshPuzzleCollectionInfo(eventV2:  eventV2);
    }
    public override void OnGameSceneBegan()
    {
        bool val_1 = this.LevelIsReset;
        if(val_1 == true)
        {
                return;
        }
        
        val_1.LevelIsReset = true;
        if((this & 1) == 0)
        {
                return;
        }
        
        this.ResetPuzzleProgress();
    }
    public override void OnWordRegionLoaded()
    {
        val_1.hasLevelFinishedLoading = true;
        MonoSingleton<PuzzleCollectionUIController>.Instance.UpdatePuzzleCollectionUI();
    }
    public override void OnEventEnded()
    {
        this.ClearEventProgress();
        if((MonoSingleton<PuzzleCollectionUIController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<PuzzleCollectionUIController>.Instance.ResetUIProgress();
    }
    public override string GetMainMenuButtonText()
    {
        int val_10;
        var val_11;
        System.Func<System.Int32, System.Boolean> val_13;
        int val_14;
        object[] val_3 = new object[5];
        val_10 = val_3.Length;
        val_3[0] = Localization.Localize(key:  "puzzle_time_upper", defaultValue:  "PUZZLE TIME", useSingularKey:  false);
        val_10 = val_3.Length;
        val_3[1] = " ";
        val_11 = null;
        val_11 = null;
        val_13 = PuzzleCollectionHandler.<>c.<>9__130_0;
        if(val_13 == null)
        {
                System.Func<System.Int32, System.Boolean> val_5 = null;
            val_13 = val_5;
            val_5 = new System.Func<System.Int32, System.Boolean>(object:  PuzzleCollectionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PuzzleCollectionHandler.<>c::<GetMainMenuButtonText>b__130_0(int x));
            PuzzleCollectionHandler.<>c.<>9__130_0 = val_13;
        }
        
        val_14 = val_3.Length;
        val_3[2] = System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.CurrentPuzzleProgress), predicate:  val_5)).ToString();
        val_14 = val_3.Length;
        val_3[3] = "/";
        val_3[4] = 16;
        return (string)+val_3;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "puzzle_time_upper", defaultValue:  "PUZZLE TIME", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        var val_8;
        System.Func<System.Int32, System.Boolean> val_10;
        val_8 = null;
        val_8 = null;
        val_10 = PuzzleCollectionHandler.<>c.<>9__132_0;
        if(val_10 != null)
        {
                return (string)System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.CurrentPuzzleProgress), predicate:  System.Func<System.Int32, System.Boolean> val_3 = null)).ToString()(System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.CurrentPuzzleProgress), predicate:  System.Func<System.Int32, System.Boolean> val_3 = null)).ToString()) + "/"("/") + 16;
        }
        
        val_10 = val_3;
        val_3 = new System.Func<System.Int32, System.Boolean>(object:  PuzzleCollectionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PuzzleCollectionHandler.<>c::<GetGameButtonText>b__132_0(int x));
        PuzzleCollectionHandler.<>c.<>9__132_0 = val_10;
        return (string)System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.CurrentPuzzleProgress), predicate:  val_3)).ToString()(System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.CurrentPuzzleProgress), predicate:  val_3)).ToString()) + "/"("/") + 16;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 19;
        ShowPuzzleProgressPopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (20 + 1) : 20;
        ShowPuzzleProgressPopup();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.LevelIsReset = false;
        int val_1 = this.eventProgress.levelsLapsed;
        val_1 = val_1 + levelsProgressed;
        this.eventProgress.levelsLapsed = val_1;
        this.eventProgress.Save();
    }
    public override int LastProgressTimestamp()
    {
        return PuzzleCollectionHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        PuzzleCollectionHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        return (bool)(PuzzleCollectionHandler.CollectedPiecesCount == 16) ? 1 : 0;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Puzzle Piece Earned", value:  PuzzleCollectionHandler.EarnedPuzzlePiece);
        System.String[] val_3 = this.CompletedPuzzles;
        currentData.Add(key:  "Puzzles Completed", value:  val_3.Length);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public override bool EventCompleted()
    {
        return this.IsEventExpired();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        var val_8;
        System.Func<System.Int32, System.Boolean> val_10;
        val_8 = null;
        val_8 = null;
        val_10 = PuzzleCollectionHandler.<>c.<>9__142_0;
        if(val_10 == null)
        {
                System.Func<System.Int32, System.Boolean> val_2 = null;
            val_10 = val_2;
            val_2 = new System.Func<System.Int32, System.Boolean>(object:  PuzzleCollectionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PuzzleCollectionHandler.<>c::<LoadEventListItemContent>b__142_0(int x));
            PuzzleCollectionHandler.<>c.<>9__142_0 = val_10;
        }
        
        int val_3 = System.Linq.Enumerable.Count<System.Int32>(source:  PuzzleCollectionHandler.CurrentPuzzleProgress, predicate:  val_2);
        float val_8 = 0.0625f;
        val_8 = (float)val_3 * val_8;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentPuzzle>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  val_3.ToString(), arg1:  16.ToString()), sliderValue:  val_8);
    }
    public System.TimeSpan GetRemainingTime()
    {
        var val_4;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = 163547}, t2:  new System.DateTime() {dateData = val_1.dateData})) != false)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            return Subtract(value:  new System.DateTime() {dateData = val_3.dateData});
        }
        
        val_4 = null;
        val_4 = null;
        return (System.TimeSpan)System.TimeSpan.Zero;
    }
    public string GetEventExpireTime()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = this.GetRemainingTime();
        System.DateTime val_3 = val_1.dateData.Add(value:  new System.TimeSpan() {_ticks = val_2._ticks});
        return (string)val_3.dateData.ToString(format:  "h tt");
    }
    public string GetEventExpireDayOfWeek()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = this.GetRemainingTime();
        System.DateTime val_3 = val_1.dateData.Add(value:  new System.TimeSpan() {_ticks = val_2._ticks});
        return (string)val_3.dateData.DayOfWeek;
    }
    private void SetupNextPuzzle()
    {
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>(collection:  this.CompletedPuzzles);
        val_2.Add(item:  PuzzleCollectionHandler.CurrentPuzzleName);
        T[] val_4 = val_2.ToArray();
        val_4.CompletedPuzzles = val_4;
        if(val_4.IsPuzzlePoolDepleted() != false)
        {
                T[] val_7 = new System.Collections.Generic.List<System.String>().ToArray();
            val_7.CompletedPuzzles = val_7;
        }
        
        this.DownloadNewPuzzleImage();
        this.ResetPuzzleProgress();
    }
    public bool HandleCurrentPuzzleProgression()
    {
        System.Int32[] val_1 = PuzzleCollectionHandler.CurrentPuzzleProgress;
        RandomSet val_2 = new RandomSet();
        int val_7 = val_1.Length;
        if(val_7 >= 1)
        {
                var val_8 = 0;
            val_7 = val_7 & 4294967295;
            do
        {
            if(null != 1)
        {
                val_2.add(item:  0, weight:  1f);
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < (val_1.Length << ));
        
        }
        
        int val_3 = val_2.roll(unweighted:  false);
        val_1[val_3 << 2] = 1;
        PuzzleCollectionHandler.CurrentPuzzleProgress = val_1;
        System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.NewPuzzlePieces);
        val_5.Add(item:  val_3);
        PuzzleCollectionHandler.NewPuzzlePieces = val_5.ToArray();
        goto typeof(PuzzleCollectionHandler).__il2cppRuntimeField_280;
    }
    public void HandleCurrentPuzzleSolved()
    {
        PuzzleCollectionHandler.CurrentPuzzleProgress = System.Linq.Enumerable.ToArray<System.Int32>(source:  System.Linq.Enumerable.Repeat<System.Int32>(element:  1, count:  16));
        string val_3 = PuzzleCollectionHandler.CurrentPuzzleName;
        PuzzleCollectionHandler.LastPuzzleName = val_3;
        val_3.isReadyToReward = true;
        this.shownCompletePopup = true;
        this.SetupNextPuzzle();
        PuzzleCollectionHandler.CurrentPuzzleProgress = new int[16];
        int val_5 = PuzzleCollectionHandler.LifetimePuzzlesCompleted;
        val_5 = val_5 + 1;
        PuzzleCollectionHandler.LifetimePuzzlesCompleted = val_5;
        System.Collections.Generic.List<System.Int32> val_7 = new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.NewPuzzlePieces);
        val_7.Clear();
        PuzzleCollectionHandler.NewPuzzlePieces = val_7.ToArray();
    }
    public void HackPuzzleSolution()
    {
        PuzzleCollectionHandler.EarnedPuzzlePiece = true;
        if((PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED + 48) != 0)
        {
                PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED + 48.Invoke();
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.HandleCurrentPuzzleProgression() != false)
        {
                PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.HandleCurrentPuzzleSolved();
        }
        
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PuzzlePieceAnimationComplete();
    }
    public string GetAllPuzzles()
    {
        System.String[] val_1 = this.Puzzles;
        return (string)val_1.Length + "\n" + System.String.Join(separator:  ", ", value:  val_1.Length.Puzzles)(System.String.Join(separator:  ", ", value:  val_1.Length.Puzzles));
    }
    public string GetCompletedPuzzles()
    {
        System.String[] val_1 = this.CompletedPuzzles;
        return (string)val_1.Length + "\n" + System.String.Join(separator:  ", ", value:  val_1.Length.CompletedPuzzles)(System.String.Join(separator:  ", ", value:  val_1.Length.CompletedPuzzles));
    }
    public int GetCompletedPuzzlesCount()
    {
        System.String[] val_1 = this.CompletedPuzzles;
        return (int)val_1.Length;
    }
    public bool IsNextPuzzleDifferent()
    {
        string val_1 = PuzzleCollectionHandler.CurrentPuzzleName;
        return System.String.op_Inequality(a:  val_1, b:  val_1.NextPuzzleName);
    }
    public bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public void MarkRewarded()
    {
        this.isReadyToReward = false;
        this.shownCompletePopup = false;
    }
    public void SaveEventProgress()
    {
        string val_6;
        GameplayMode val_1 = PlayingLevel.CurrentGameplayMode;
        val_6 = 0;
        if(val_1 == 4)
        {
                CategoryPacksManager val_2 = MonoSingleton<CategoryPacksManager>.Instance;
            val_6 = val_2.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
        }
        
        int val_4 = PlayingLevel.GetCurrentPlayerLevelNumber();
        this.eventProgress.lastLevel = val_4;
        this.eventProgress.levelsLapsed = 0;
        this.eventProgress.levelInterval = val_4.GetLevelInterval();
        this.eventProgress.lastMode = val_1;
        this.eventProgress.lastModeSecondaryId = val_6;
        this.eventProgress.Save();
    }
    public void PuzzlePieceAnimationComplete()
    {
        bool val_1 = this.isReadyToReward;
        if(val_1 == false)
        {
                return;
        }
        
        val_1.ShowPuzzleCompletePopup();
    }
    public override int GetMovingWordIndex()
    {
        if(this.PlayingChallenge == false)
        {
                return 0;
        }
        
        this = MonoSingleton<PuzzleCollectionUIController>.Instance;
        if(this == 0)
        {
                return 0;
        }
        
        return MonoSingleton<PuzzleCollectionUIController>.Instance.PuzzleWordIndex;
    }
    public PuzzleCollectionHandler()
    {
        PuzzleCollectionV2_EventProgress val_1 = null;
        .levelsLapsed = 0;
        .lastMode = 1;
        val_1 = new PuzzleCollectionV2_EventProgress();
        this.eventProgress = val_1;
    }

}
