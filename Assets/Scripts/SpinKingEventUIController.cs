using UnityEngine;
public class SpinKingEventUIController : MonoSingleton<SpinKingEventUIController>
{
    // Fields
    private UnityEngine.Transform eventButton;
    private UnityEngine.Transform eventButtonMiddleRoot;
    private UnityEngine.GameObject spinPiecePrefab;
    private EventButtonPanel eventButtonPanel;
    private SpinKingEventButtonTag eventBtnTagPrefab;
    private float spinPieceMoveDuration;
    private const string SPIN_WORD_INDEX_KEY = "spin_word_index";
    private const string SPIN_LETTER_INDEX_KEY = "spin_letter_index";
    private const string SPIN_PIECE_OBTAINED_KEY = "spin_piece_obtained";
    private const string SAVED_LANGUAGE_KEY = "spin_saved_lang";
    private const string SPIN_PIECE_AVAILABLE_KEY = "spin_piece_lost";
    private const int DEFAULT_SPIN_WORD_INDEX = -1;
    private const int DEFAULT_SPIN_LETTER_INDEX = -1;
    private const bool DEFAULT_OBTAINED_SPIN_PIECE = False;
    private const bool DEFAULT_IS_SPIN_PIECE_AVAILABLE = True;
    public UnityEngine.GameObject spinPiece;
    private LineWord word;
    private Cell letter;
    private SpinKingEventButtonTag eventBtnTag;
    private bool hasLevelFinishedLoading;
    
    // Properties
    private int spinWordIndex { get; set; }
    private int spinLetterIndex { get; set; }
    private bool obtainedSpinPiece { get; set; }
    private string SavedLanguage { get; set; }
    private bool IsSpinPieceAvailable { get; set; }
    public int GetSpinWordIndex { get; }
    
    // Methods
    private int get_spinWordIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "spin_word_index", defaultValue:  0);
    }
    private void set_spinWordIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "spin_word_index", value:  value);
        App.Player.SaveState();
    }
    private int get_spinLetterIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "spin_letter_index", defaultValue:  0);
    }
    private void set_spinLetterIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "spin_letter_index", value:  value);
        App.Player.SaveState();
    }
    private bool get_obtainedSpinPiece()
    {
        return PlayerPrefsX.GetBool(name:  "spin_piece_obtained", defaultValue:  false);
    }
    private void set_obtainedSpinPiece(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "spin_piece_obtained", value:  value);
        App.Player.SaveState();
    }
    private string get_SavedLanguage()
    {
        GameBehavior val_1 = App.getBehavior;
        return UnityEngine.PlayerPrefs.GetString(key:  "spin_saved_lang", defaultValue:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
    }
    private void set_SavedLanguage(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "spin_saved_lang", value:  value);
    }
    private bool get_IsSpinPieceAvailable()
    {
        return PlayerPrefsX.GetBool(name:  "spin_piece_lost", defaultValue:  true);
    }
    private void set_IsSpinPieceAvailable(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "spin_piece_lost", value:  value);
        App.Player.SaveState();
    }
    public int get_GetSpinWordIndex()
    {
        return this.spinWordIndex;
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
    }
    private void Start()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnPreprocessPlayerTurnAction(callback:  new System.Action<System.Boolean, System.String, LineWord, Cell>(object:  this, method:  System.Void SpinKingEventUIController::OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)));
    }
    public void LevelFinishedLoading()
    {
        this.hasLevelFinishedLoading = true;
        this.UpdateSpinCollectionUI();
    }
    public void UpdateSpinCollectionUI()
    {
        var val_16;
        var val_17;
        var val_18;
        UnityEngine.GameObject val_19;
        bool val_20;
        val_16 = this;
        if(this.hasLevelFinishedLoading == false)
        {
                return;
        }
        
        val_18 = 1152921504980168704;
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.IsEventExpired() == false)
        {
            goto label_4;
        }
        
        this.DestroySpinPiece();
        val_16 = ???;
        val_17 = ???;
        val_18 = ???;
        goto typeof(System.String).__il2cppRuntimeField_2B0;
        label_4:
        mem2[0] = UnityEngine.Object.Instantiate<SpinKingEventButtonTag>(original:  val_16 + 56, parent:  val_16 + 32).GetComponent<SpinKingEventButtonTag>();
        if((val_17 + 1181) == 0)
        {
                mem2[0] = 1;
        }
        
        val_19 = val_3.max_tag;
        val_19.SetActive(value:  ((val_18 + 184 + 56) >= (val_18 + 184 + 48 + 20)) ? 1 : 0);
        if((val_17 + 1181) == 0)
        {
                mem2[0] = 1;
        }
        
        if((val_18 + 184 + 56) >= (val_18 + 184 + 48 + 20))
        {
            goto label_18;
        }
        
        val_20 = 0;
        if((val_16 + 96) != 0)
        {
            goto label_19;
        }
        
        label_18:
        val_20 = this.obtainedSpinPiece ^ 1;
        label_19:
        val_16 + 96 + 32.SetActive(value:  val_20);
        if((val_17 + 1181) == 0)
        {
                mem2[0] = 1;
        }
        
        if((val_18 + 184.PlayingChallenge) == false)
        {
                return;
        }
        
        val_16.InitializeSpinPiece();
    }
    private void OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.IsEventExpired() == true)
        {
                return;
        }
        
        bool val_2 = SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.PlayingChallenge;
        if(val_2 == false)
        {
                return;
        }
        
        if(val_2.IsSpinPlacementDataValid() == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        1152921504980168704 = 1152921504879157248;
        int val_6 = WordRegion.instance.spinWordIndex;
        if((X22 + 24) <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = X22 + 16;
        val_9 = val_9 + (val_6 << 3);
        if(((X22 + 16 + (val_6) << 3) + 32 + 24.Equals(value:  wordEntered)) == false)
        {
                return;
        }
        
        WordRegion val_8 = WordRegion.instance;
        mem2[0] = 1;
    }
    public void DestroySpinPiece()
    {
        if(this.spinPiece == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.spinPiece);
        this.spinPiece = 0;
    }
    private void CollectSpinPiece()
    {
        var val_23;
        System.Predicate<WGEventButtonV2> val_25;
        DG.Tweening.TweenCallback val_26;
        UnityEngine.Transform val_27;
        bool val_1 = UnityEngine.Object.op_Equality(x:  this.spinPiece, y:  0);
        if(val_1 == true)
        {
                return;
        }
        
        if(val_1.obtainedSpinPiece == true)
        {
                return;
        }
        
        this.ShowSpinPiece();
        mem2[0] = true;
        WordRegion.instance.obtainedSpinPiece = true;
        SpinKingEventHandler.EarnedSpinPiece = true;
        SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.HandleSpinPieceCollected();
        if(this.eventButtonPanel != 0)
        {
                val_23 = null;
            val_23 = null;
            val_25 = SpinKingEventUIController.<>c.<>9__43_0;
            if(val_25 == null)
        {
                System.Predicate<WGEventButtonV2> val_5 = null;
            val_25 = val_5;
            val_5 = new System.Predicate<WGEventButtonV2>(object:  SpinKingEventUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SpinKingEventUIController.<>c::<CollectSpinPiece>b__43_0(WGEventButtonV2 x));
            SpinKingEventUIController.<>c.<>9__43_0 = val_25;
        }
        
            UnityEngine.Transform val_7 = this.eventButtonPanel.btnList.Find(match:  val_5).transform;
            val_26 = this;
            val_27 = val_7;
            this.eventButton = val_7;
        }
        else
        {
                val_26 = this;
            val_27 = this.eventButton;
        }
        
        if(val_27 == 0)
        {
                return;
        }
        
        this.spinPiece.transform.parent = this.eventButton;
        UnityEngine.Vector3 val_11 = this.eventButton.position;
        DG.Tweening.TweenCallback val_13 = null;
        val_26 = val_13;
        val_13 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SpinKingEventUIController::OnSpinPieceMoveComplete());
        DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.spinPiece.transform, endValue:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, duration:  this.spinPieceMoveDuration, snapping:  false), action:  val_13);
        UnityEngine.Vector3 val_17 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (float)UnityEngine.Random.Range(min:  719, max:  208));
        DG.Tweening.Tweener val_19 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  this.spinPiece.transform, endValue:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, duration:  this.spinPieceMoveDuration, mode:  0), ease:  5);
        UnityEngine.Vector3 val_21 = new UnityEngine.Vector3(x:  0.8f, y:  0.8f, z:  0f);
        DG.Tweening.Tweener val_22 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.spinPiece.transform, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, duration:  this.spinPieceMoveDuration);
    }
    public void ShiftSpinPiece()
    {
        var val_11;
        WordRegion val_1 = WordRegion.instance;
        bool val_2 = UnityEngine.Object.op_Equality(x:  this.spinPiece, y:  0);
        if(val_2 == true)
        {
                return;
        }
        
        if(val_2.obtainedSpinPiece != false)
        {
                return;
        }
        
        val_11 = this;
        this.ShowSpinPiece();
        if(this.word.isShown != false)
        {
                this.CollectSpinPiece();
            return;
        }
        
        int val_4 = this.spinLetterIndex;
        val_4.spinLetterIndex = val_4 + 1;
        int val_6 = val_4.spinLetterIndex;
        LineWord val_11 = this.word;
        if(val_6 >= val_11)
        {
            goto label_13;
        }
        
        label_19:
        int val_7 = val_6.spinLetterIndex;
        if(val_11 <= val_7)
        {
                val_11 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = val_11 + (val_7 << 3);
        if(((this.word + (val_7) << 3).cellSize + 72) == 0)
        {
            goto label_16;
        }
        
        int val_8 = this.spinLetterIndex;
        val_8.spinLetterIndex = val_8 + 1;
        if(val_8.spinLetterIndex < this.word)
        {
            goto label_19;
        }
        
        this.DestroySpinPiece();
        goto label_20;
        label_13:
        this.DestroySpinPiece();
        this.FixStarredCoinUI();
        label_20:
        this.IsSpinPieceAvailable = false;
        SpinKingEventHandler.EarnedSpinPiece = false;
        return;
        label_16:
        this.letter = (this.word + (val_7) << 3).cellSize;
        this.AdjustSpinPieceUI();
        this.FixStarredCoinUI();
    }
    private bool IsSpinPlacementDataValid()
    {
        var val_6;
        int val_1 = this.spinWordIndex;
        if((val_1 & 2147483648) == 0)
        {
                int val_2 = val_1.spinWordIndex;
            var val_5 = (WordRegion.instance.spinLetterIndex == 0) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public void InitializeSpinPiece()
    {
        string val_29;
        string val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_35;
        val_29 = SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY;
        if(val_29.PlayingChallenge == false)
        {
                return;
        }
        
        bool val_2 = 26707.IsSolvingInProgress();
        if(val_2 == false)
        {
            goto label_6;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_30 = val_2.SavedLanguage;
        bool val_6 = System.String.op_Inequality(a:  val_30, b:  val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        if(val_6 == false)
        {
            goto label_11;
        }
        
        label_6:
        val_31 = 1152921504884269056;
        GameBehavior val_8 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_6.SavedLanguage, b:  val_8.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                GameBehavior val_11 = App.getBehavior;
            string val_12 = val_11.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
            val_12.SavedLanguage = val_12;
            bool val_13 = val_12.obtainedSpinPiece;
            if(val_13 == true)
        {
                return;
        }
        
        }
        
        val_13.ResetSpinLevelUI();
        RandomSet val_14 = new RandomSet();
        val_31 = WordRegion.instance.getAvailableLineIndices;
        var val_29 = 0;
        WordRegion val_17 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_32 = mem[(WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32];
        val_32 = (WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32;
        if((X26 + 24) <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        WordRegion val_18 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_32 = mem[((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40];
        val_32 = ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_14.add(item:  (((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40 + 16 + 32 + 72 + 0) + 32, weight:  1f);
        val_29 = val_29 + 1;
        if(val_14.count() == 0)
        {
                return;
        }
        
        int val_20 = val_14.roll(unweighted:  false);
        val_20.spinWordIndex = val_20;
        val_33 = 0;
        goto label_51;
        label_69:
        int val_22 = WordRegion.instance.spinWordIndex;
        if(((0 + 1) + 24) <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_30 = (0 + 1) + 16;
        val_30 = val_30 + (val_22 << 3);
        val_35 = mem[((0 + 1) + 16 + (val_22) << 3) + 32 + 40];
        val_35 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40;
        if((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 24) <= val_33)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_31 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16;
        val_31 = val_31 + 0;
        if(((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16 + 0) + 32 + 72) == 0)
        {
            goto label_61;
        }
        
        val_33 = 1;
        label_51:
        int val_24 = WordRegion.instance.spinWordIndex;
        val_35 = val_24;
        if(((0 + 1) + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_32 = (0 + 1) + 16;
        val_32 = val_32 + (val_35 << 3);
        if(val_33 < (((0 + 1) + 16 + (val_24) << 3) + 32 + 40 + 24))
        {
            goto label_69;
        }
        
        goto label_70;
        label_11:
        bool val_25 = val_6.obtainedSpinPiece;
        if(val_25 == true)
        {
                return;
        }
        
        if(val_25.IsSpinPieceAvailable != true)
        {
                val_30 = this.spinPiece;
            bool val_27 = UnityEngine.Object.op_Inequality(x:  val_30, y:  0);
            if(val_27 == true)
        {
                return;
        }
        
        }
        
        if(val_27.IsSpinPlacementDataValid() == false)
        {
                return;
        }
        
        this.ShowSpinPiece();
        this.FixStarredCoinUI();
        return;
        label_61:
        this.spinLetterIndex = 0;
        label_70:
        this.ShowSpinPiece();
        this.FixStarredCoinUI();
        26707.SaveEventProgress();
    }
    public void ShowSpinPiece()
    {
        UnityEngine.Transform val_15;
        object val_16;
        object val_18;
        val_15 = 1152921504765632512;
        bool val_2 = UnityEngine.Object.op_Equality(x:  WordRegion.instance, y:  0);
        if(val_2 == false)
        {
            goto label_5;
        }
        
        val_16 = "SpinKingUIController attempting to ShowSpinPiece but no WordRegion exists!";
        goto label_8;
        label_5:
        if(val_2.IsSpinPlacementDataValid() == false)
        {
            goto label_9;
        }
        
        int val_5 = WordRegion.instance.spinWordIndex;
        if((public System.Void System.Globalization.JapaneseCalendar::.ctor()) <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_15 = System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index);
        val_15 = val_15 + (val_5 << 3);
        this.word = (System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32;
        bool val_6 = UnityEngine.Object.op_Equality(x:  (System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32, y:  0);
        if(val_6 == false)
        {
            goto label_17;
        }
        
        int val_7 = val_6.spinWordIndex;
        val_18 = "SpinKingUIController attempting to ShowSpinPiece but no word exists for SpinWordIndex ";
        goto label_18;
        label_9:
        val_16 = "SpinKingUIController attempting to ShowSpinPiece but associated word/letter index is outdated!";
        label_8:
        UnityEngine.Debug.LogError(message:  val_16);
        return;
        label_17:
        LineWord val_16 = this.word;
        int val_8 = val_6.spinLetterIndex;
        if(val_16 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_16 = val_16 + (val_8 << 3);
        this.letter = (this.word + (val_8) << 3).cellSize;
        bool val_9 = UnityEngine.Object.op_Equality(x:  (this.word + (val_8) << 3).cellSize, y:  0);
        if(val_9 == false)
        {
            goto label_26;
        }
        
        val_18 = "SpinKingUIController attempting to ShowSpinPiece but no letter exists for SpinLetterIndex ";
        label_18:
        UnityEngine.Debug.LogError(message:  val_18 + val_9.spinLetterIndex);
        return;
        label_26:
        if(this.spinPiece == 0)
        {
                val_15 = this.letter.transform;
            this.spinPiece = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.spinPiecePrefab, parent:  val_15);
        }
        
        this.AdjustSpinPieceUI();
    }
    public void OnWordSubmitted(string submitWord)
    {
        .submitWord = submitWord;
        if((this.word.answer.Equals(value:  submitWord = submitWord)) == true)
        {
            goto label_4;
        }
        
        WordRegion val_3 = WordRegion.instance;
        LineWord val_5 = submitWord.Find(match:  new System.Predicate<LineWord>(object:  new SpinKingEventUIController.<>c__DisplayClass48_0(), method:  System.Boolean SpinKingEventUIController.<>c__DisplayClass48_0::<OnWordSubmitted>b__0(LineWord x)));
        if((val_5.cells.Contains(item:  this.letter)) == false)
        {
            goto label_11;
        }
        
        label_4:
        this.CollectSpinPiece();
        return;
        label_11:
        this.ShiftSpinPiece();
    }
    private void AdjustSpinPieceUI()
    {
        if(this.spinPiece == 0)
        {
                return;
        }
        
        if(this.spinPiece.transform.parent == 0)
        {
                return;
        }
        
        if(this.letter == 0)
        {
                return;
        }
        
        this.spinPiece.transform.parent = this.letter.transform;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.spinPiece.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Vector2 val_12 = this.letter.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y}, d:  0.9f);
        this.spinPiece.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
    }
    private void FixStarredCoinUI()
    {
        if(this.word == 0)
        {
                return;
        }
        
        if(this.word.isStarred == false)
        {
                return;
        }
        
        this.letter.HideStarred();
    }
    private void OnSpinPieceMoveComplete()
    {
        this.DestroySpinPiece();
        this.eventBtnTag.max_tag.SetActive(value:  ((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56) >= (SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20)) ? 1 : 0);
        this.eventBtnTag.ShowObtainedRing();
        goto typeof(System.String).__il2cppRuntimeField_2B0;
    }
    private void ResetSpinLevelUI()
    {
        this.spinWordIndex = 0;
        this.spinLetterIndex = 0;
        this.obtainedSpinPiece = false;
        this.IsSpinPieceAvailable = true;
    }
    private void OnGameEventHandlerProgress()
    {
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        this.eventBtnTag.max_tag.SetActive(value:  ((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56) >= (SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20)) ? 1 : 0);
        if((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56) >= (SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20))
        {
                return;
        }
        
        this.eventBtnTag.no_new_spins_ring.SetActive(value:  false);
    }
    public SpinKingEventUIController()
    {
        this.spinPieceMoveDuration = 1f;
    }

}
