using UnityEngine;
public class PuzzleCollectionUIController : MonoSingleton<PuzzleCollectionUIController>
{
    // Fields
    private UnityEngine.Transform wordRegion;
    private UnityEngine.GameObject eventButton;
    private EventButtonPanel eventButtonPanel;
    private UnityEngine.GameObject puzzlePiecePrefab;
    private UnityEngine.GameObject toolTipPrefab;
    private UnityEngine.GameObject toolTipPickPrefab;
    private UnityEngine.GameObject glow;
    private UnityEngine.Vector3 glowEffectOffset;
    private float puzzlePieceMoveDuration;
    private float glowDuration;
    private const string PUZZLE_LAST_LEVEL_INDEX_KEY = "puzzle_last_level_inxex";
    private const string PUZZLE_WORD_INDEX_KEY = "puzzle_word_index";
    private const string PUZZLE_LETTER_INDEX_KEY = "puzzle_letter_index";
    private const string PUZZLE_PIECE_OBTAINED_KEY = "puzzle_piece_obtained";
    private const string PUZZLE_PIECE_AVAILABLE_KEY = "puzzle_piece_lost";
    private const string SAVED_LANGUAGE_KEY = "puzzle_saved_lang";
    private const int DEFAULT_PUZZLE_WORD_INDEX = -1;
    private const int DEFAULT_PUZZLE_LETTER_INDEX = 0;
    private const bool DEFAULT_OBTAINED_PUZZLE_PIECE = False;
    private const bool DEFAULT_IS_PUZZLE_PIECE_AVAILABLE = True;
    public UnityEngine.GameObject puzzlePiece;
    private LineWord word;
    private Cell letter;
    private Cell lastLetter;
    private UnityEngine.GameObject toolTipBase;
    private UnityEngine.ParticleSystem glowEffect;
    private UnityEngine.Coroutine destroyTooltipUponClick;
    private bool hasLevelFinishedLoading;
    
    // Properties
    private int PuzzleWordIndex { get; set; }
    private int PuzzleLetterIndex { get; set; }
    private bool ObtainedPuzzlePiece { get; set; }
    private bool IsPuzzlePieceAvailable { get; set; }
    private string SavedLanguage { get; set; }
    public int GetPuzzleWordIndex { get; }
    
    // Methods
    private int get_PuzzleWordIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "puzzle_word_index", defaultValue:  0);
    }
    private void set_PuzzleWordIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "puzzle_word_index", value:  value);
        App.Player.SaveState();
    }
    private int get_PuzzleLetterIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "puzzle_letter_index", defaultValue:  0);
    }
    private void set_PuzzleLetterIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "puzzle_letter_index", value:  value);
        App.Player.SaveState();
    }
    private bool get_ObtainedPuzzlePiece()
    {
        return PlayerPrefsX.GetBool(name:  "puzzle_piece_obtained", defaultValue:  false);
    }
    private void set_ObtainedPuzzlePiece(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "puzzle_piece_obtained", value:  value);
        App.Player.SaveState();
    }
    private bool get_IsPuzzlePieceAvailable()
    {
        return PlayerPrefsX.GetBool(name:  "puzzle_piece_lost", defaultValue:  true);
    }
    private void set_IsPuzzlePieceAvailable(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "puzzle_piece_lost", value:  value);
        App.Player.SaveState();
    }
    private string get_SavedLanguage()
    {
        GameBehavior val_1 = App.getBehavior;
        return UnityEngine.PlayerPrefs.GetString(key:  "puzzle_saved_lang", defaultValue:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
    }
    private void set_SavedLanguage(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "puzzle_saved_lang", value:  value);
    }
    public int get_GetPuzzleWordIndex()
    {
        return this.PuzzleWordIndex;
    }
    private void Start()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnPreprocessPlayerTurnAction(callback:  new System.Action<System.Boolean, System.String, LineWord, Cell>(object:  this, method:  System.Void PuzzleCollectionUIController::OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)));
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void PuzzleCollectionUIController::onWordRegionWordFound(string wordCompleted)));
        WordRegion.instance.addOnHintUsedAtLocation(callback:  new System.Action<UnityEngine.Vector3>(object:  this, method:  System.Void PuzzleCollectionUIController::onWordRegionHintUsed(UnityEngine.Vector3 location)));
    }
    public void LevelFinishedLoading()
    {
        this.hasLevelFinishedLoading = true;
        this.UpdatePuzzleCollectionUI();
    }
    public void UpdatePuzzleCollectionUI()
    {
        var val_8;
        var val_9;
        var val_10;
        if(this.hasLevelFinishedLoading == false)
        {
                return;
        }
        
        val_9 = this;
        val_10 = 1152921504920158208;
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED == 0)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.IsEventExpired() != false)
        {
                this.DestroyPuzzlePiece();
            val_8 = ???;
            val_9 = ???;
            val_10 = ???;
        }
        else
        {
                if((val_8 + 2417) == 0)
        {
                mem2[0] = 1;
        }
        
            if((val_10 + 184.PlayingChallenge) == false)
        {
                return;
        }
        
            val_9.InitializePuzzlePiece();
        }
    
    }
    private void OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED == 0)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.IsEventExpired() == true)
        {
                return;
        }
        
        bool val_2 = PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PlayingChallenge;
        if(val_2 == false)
        {
                return;
        }
        
        if(val_2.IsPuzzlePlacementDataValid() == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        1152921504920158208 = 1152921504879157248;
        int val_6 = WordRegion.instance.PuzzleWordIndex;
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
    private void onWordRegionWordFound(string wordCompleted)
    {
        var val_8;
        var val_9;
        var val_10;
        val_9 = this;
        val_10 = 1152921504920158208;
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED == 0)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.IsEventExpired() != false)
        {
                this.DestroyPuzzlePiece();
            val_8 = ???;
            val_9 = ???;
            val_10 = ???;
        }
        else
        {
                if((val_8 + 2417) == 0)
        {
                mem2[0] = 1;
        }
        
            if((val_10 + 184.PlayingChallenge) == false)
        {
                return;
        }
        
            val_9.UpdatePuzzlePiece(hackPuzzleSolution:  false);
        }
    
    }
    private void onWordRegionHintUsed(UnityEngine.Vector3 location)
    {
        double val_18;
        double val_19;
        double val_20;
        var val_21;
        var val_22;
        var val_23;
        double val_24;
        val_18 = location.z;
        val_19 = location.y;
        val_20 = location.x;
        val_21 = this;
        val_23 = 1152921504920158208;
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED == 0)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.IsEventExpired() != false)
        {
                this.DestroyPuzzlePiece();
            val_22 = ???;
            val_21 = ???;
            val_23 = ???;
            val_19 = ???;
            val_18 = ???;
            val_20 = ???;
            val_24 = ???;
        }
        else
        {
                if((val_22 + 2417) == 0)
        {
                mem2[0] = 1;
        }
        
            if((val_23 + 184.PlayingChallenge) == false)
        {
                return;
        }
        
            if((val_21 + 104) == 0)
        {
                return;
        }
        
            UnityEngine.Vector3 val_5 = val_21 + 104.transform.position;
            val_24 = val_5.y;
            if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_20, y = val_19, z = val_18}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_24, z = val_5.z})) == false)
        {
                return;
        }
        
            val_21.UpdatePuzzlePiece(hackPuzzleSolution:  false);
        }
    
    }
    private bool IsPuzzlePlacementDataValid()
    {
        var val_9;
        var val_10;
        int val_1 = this.PuzzleWordIndex;
        if((val_1 & 2147483648) == 0)
        {
                val_9 = val_1.PuzzleWordIndex;
            int val_4 = WordRegion.instance.PuzzleLetterIndex;
            if((val_4 & 2147483648) == 0)
        {
                val_9 = val_4.PuzzleLetterIndex;
            int val_7 = WordRegion.instance.PuzzleWordIndex;
            if((X21 + 24) <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_9 = X21 + 16;
            val_9 = val_9 + (val_7 << 3);
            var val_8 = (val_9 < ((X21 + 16 + (val_7) << 3) + 32 + 40 + 24)) ? 1 : 0;
            return (bool)val_10;
        }
        
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    private void InitializePuzzlePiece()
    {
        var val_37;
        var val_38;
        var val_40;
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PlayingChallenge == false)
        {
                return;
        }
        
        if(PuzzleCollectionHandler.IsNewCycle != false)
        {
                PuzzleCollectionHandler.IsNewCycle = false;
            this.DestroyPuzzlePiece();
            this.DestroyTooltip();
        }
        
        bool val_3 = PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.IsSolvingInProgress();
        if(val_3 == false)
        {
            goto label_7;
        }
        
        GameBehavior val_5 = App.getBehavior;
        bool val_7 = System.String.op_Inequality(a:  val_3.SavedLanguage, b:  val_5.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        if(val_7 == false)
        {
            goto label_12;
        }
        
        label_7:
        val_37 = 1152921504884269056;
        GameBehavior val_9 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_7.SavedLanguage, b:  val_9.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                GameBehavior val_12 = App.getBehavior;
            string val_13 = val_12.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
            val_13.SavedLanguage = val_13;
            bool val_14 = val_13.ObtainedPuzzlePiece;
            if(val_14 == true)
        {
                return;
        }
        
        }
        
        val_14.ResetPuzzleLevelUI();
        RandomSet val_15 = new RandomSet();
        val_37 = WordRegion.instance.getAvailableLineIndices;
        var val_37 = 0;
        WordRegion val_18 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_15.add(item:  ((X26 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 56 + 0) + 32, weight:  1f);
        val_37 = val_37 + 1;
        if(val_15.count() == 0)
        {
                return;
        }
        
        int val_20 = val_15.roll(unweighted:  false);
        val_20.PuzzleWordIndex = val_20;
        val_38 = 0;
        goto label_41;
        label_59:
        int val_22 = WordRegion.instance.PuzzleWordIndex;
        if(((0 + 1) + 24) <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_38 = (0 + 1) + 16;
        val_38 = val_38 + (val_22 << 3);
        val_40 = mem[((0 + 1) + 16 + (val_22) << 3) + 32 + 40];
        val_40 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40;
        if((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 24) <= val_38)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_39 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16;
        val_39 = val_39 + 0;
        if(((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16 + 0) + 32 + 72) == 0)
        {
            goto label_51;
        }
        
        val_38 = 1;
        label_41:
        int val_24 = WordRegion.instance.PuzzleWordIndex;
        val_40 = val_24;
        if(((0 + 1) + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_40 = (0 + 1) + 16;
        val_40 = val_40 + (val_40 << 3);
        if(val_38 < (((0 + 1) + 16 + (val_24) << 3) + 32 + 40 + 24))
        {
            goto label_59;
        }
        
        goto label_60;
        label_12:
        bool val_25 = val_7.ObtainedPuzzlePiece;
        if(val_25 == true)
        {
                return;
        }
        
        if(val_25.IsPuzzlePieceAvailable == false)
        {
                return;
        }
        
        bool val_27 = UnityEngine.Object.op_Inequality(x:  this.puzzlePiece, y:  0);
        if(val_27 == true)
        {
                return;
        }
        
        if(val_27.IsPuzzlePlacementDataValid() == false)
        {
                return;
        }
        
        this.ShowPuzzlePiece();
        this.FixStarredCoinUI();
        if(this.IsFTUX() == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_31 = this.StartCoroutine(routine:  this.ShowTooltip(parent:  this.wordRegion));
        return;
        label_51:
        this.PuzzleLetterIndex = 0;
        label_60:
        this.ShowPuzzlePiece();
        this.FixStarredCoinUI();
        if(this.IsFTUX() != false)
        {
                UnityEngine.Coroutine val_36 = this.StartCoroutine(routine:  this.ShowTooltip(parent:  WordRegion.instance.SafeTransform));
        }
        
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.SaveEventProgress();
    }
    public void UpdatePuzzlePiece(bool hackPuzzleSolution = False)
    {
        UnityEngine.GameObject val_38;
        UnityEngine.GameObject val_39;
        var val_40;
        System.Collections.Generic.List<Cell> val_41;
        System.Collections.Generic.List<Cell> val_42;
        var val_43;
        System.Predicate<WGEventButtonV2> val_45;
        UnityEngine.GameObject val_46;
        val_38 = this;
        val_39 = this.puzzlePiece;
        bool val_1 = UnityEngine.Object.op_Equality(x:  val_39, y:  0);
        if(val_1 != true)
        {
                if(val_1.ObtainedPuzzlePiece == false)
        {
            goto label_4;
        }
        
        }
        
        val_38 = this.puzzlePiece;
        if(val_38 != 0)
        {
                return;
        }
        
        PuzzleCollectionHandler.IsFTUX = false;
        return;
        label_4:
        val_40 = val_38;
        this.ShowPuzzlePiece();
        if((this.word.isShown == true) || (hackPuzzleSolution == true))
        {
            goto label_10;
        }
        
        int val_4 = this.PuzzleLetterIndex;
        val_4.PuzzleLetterIndex = val_4 + 1;
        int val_6 = val_4.PuzzleLetterIndex;
        LineWord val_38 = this.word;
        val_41 = this.word.cells;
        if(val_6 >= val_38)
        {
            goto label_13;
        }
        
        label_19:
        int val_7 = val_6.PuzzleLetterIndex;
        if(val_38 <= val_7)
        {
                val_40 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_38 = val_38 + (val_7 << 3);
        if(((this.word + (val_7) << 3).cellSize + 72) == 0)
        {
            goto label_16;
        }
        
        int val_8 = this.PuzzleLetterIndex;
        val_8.PuzzleLetterIndex = val_8 + 1;
        val_42 = this.word.cells;
        if(val_8.PuzzleLetterIndex < this.word)
        {
            goto label_19;
        }
        
        this.DestroyPuzzlePiece();
        goto label_20;
        label_10:
        this.DestroyTooltip();
        PuzzleCollectionHandler.IsFTUX = false;
        this.ObtainedPuzzlePiece = true;
        PuzzleCollectionHandler.EarnedPuzzlePiece = true;
        if((PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED + 48) != 0)
        {
                PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED + 48.Invoke();
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.HandleCurrentPuzzleProgression() != false)
        {
                PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.HandleCurrentPuzzleSolved();
        }
        
        if(this.eventButtonPanel == 0)
        {
            goto label_32;
        }
        
        val_43 = null;
        val_43 = null;
        val_45 = PuzzleCollectionUIController.<>c.<>9__53_0;
        if(val_45 == null)
        {
                System.Predicate<WGEventButtonV2> val_13 = null;
            val_45 = val_13;
            val_13 = new System.Predicate<WGEventButtonV2>(object:  PuzzleCollectionUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PuzzleCollectionUIController.<>c::<UpdatePuzzlePiece>b__53_0(WGEventButtonV2 x));
            PuzzleCollectionUIController.<>c.<>9__53_0 = val_45;
        }
        
        UnityEngine.GameObject val_15 = this.eventButtonPanel.btnList.Find(match:  val_13).gameObject;
        val_39 = val_38;
        val_46 = val_15;
        this.eventButton = val_15;
        goto label_41;
        label_13:
        this.DestroyPuzzlePiece();
        this.DestroyTooltip();
        this.FixStarredCoinUI();
        label_20:
        this.IsPuzzlePieceAvailable = false;
        PuzzleCollectionHandler.EarnedPuzzlePiece = false;
        return;
        label_32:
        val_39 = val_38;
        val_46 = this.eventButton;
        label_41:
        if(val_46 == 0)
        {
                return;
        }
        
        this.puzzlePiece.transform.parent = this.eventButton.transform;
        UnityEngine.Vector3 val_21 = this.eventButton.transform.position;
        DG.Tweening.TweenCallback val_23 = null;
        val_39 = val_23;
        val_23 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void PuzzleCollectionUIController::OnPuzzlePieceMoveComplete());
        DG.Tweening.Tweener val_24 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.puzzlePiece.transform, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, duration:  this.puzzlePieceMoveDuration, snapping:  false), action:  val_23);
        UnityEngine.Vector3 val_27 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (float)UnityEngine.Random.Range(min:  719, max:  208));
        DG.Tweening.Tweener val_29 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  this.puzzlePiece.transform, endValue:  new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z}, duration:  this.puzzlePieceMoveDuration, mode:  0), ease:  5);
        UnityEngine.Vector3 val_31 = new UnityEngine.Vector3(x:  0.3f, y:  0.3f, z:  0f);
        DG.Tweening.Tweener val_32 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.puzzlePiece.transform, endValue:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, duration:  this.puzzlePieceMoveDuration);
        return;
        label_16:
        this.letter = (this.word + (val_7) << 3).cellSize;
        this.AdjustPuzzlePieceUI();
        this.FixStarredCoinUI();
        this.DestroyTooltip();
        if(this.IsFTUX() == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_37 = this.StartCoroutine(routine:  this.ShowTooltip(parent:  WordRegion.instance.SafeTransform));
    }
    public UnityEngine.GameObject CreatePuzzlePiece(UnityEngine.Transform parent)
    {
        UnityEngine.GameObject val_3;
        UnityEngine.GameObject val_4;
        val_3 = this.puzzlePiece;
        if(val_3 == 0)
        {
                val_3 = this.puzzlePiecePrefab;
            this.puzzlePiece = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_3, parent:  parent);
            return val_4;
        }
        
        val_4 = this.puzzlePiece;
        return val_4;
    }
    public UnityEngine.Transform GetLetterTransform()
    {
        LineWord val_2 = this.word;
        int val_1 = this.PuzzleLetterIndex;
        if(val_2 <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (val_1 << 3);
        return (this.word + (val_1) << 3).cellSize.transform;
    }
    public void ShowToolTip()
    {
        if(this.toolTipBase != 0)
        {
                return;
        }
        
        if(this.puzzlePiece == 0)
        {
                return;
        }
        
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.ShowTooltip(parent:  WordRegion.instance.SafeTransform));
    }
    public void DestroyTooltip()
    {
        if(this.toolTipBase == 0)
        {
                return;
        }
        
        UnityEngine.Object.DestroyImmediate(obj:  this.toolTipBase);
    }
    public void ResetUIProgress()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "puzzle_word_index")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "puzzle_word_index");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "puzzle_letter_index")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "puzzle_letter_index");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "puzzle_piece_obtained")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "puzzle_piece_obtained");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "puzzle_piece_lost")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "puzzle_piece_lost");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "puzzle_saved_lang")) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "puzzle_saved_lang");
    }
    private void DeletePlayerPref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    private System.Collections.IEnumerator DestroyTooltipUponClick()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PuzzleCollectionUIController.<DestroyTooltipUponClick>d__60();
    }
    public void ShowPuzzlePiece()
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
        
        val_16 = "PuzzleCollectionUIController attempting to ShowPuzzlePiece but no WordRegion exists!";
        goto label_8;
        label_5:
        if(val_2.IsPuzzlePlacementDataValid() == false)
        {
            goto label_9;
        }
        
        int val_5 = WordRegion.instance.PuzzleWordIndex;
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
        
        int val_7 = val_6.PuzzleWordIndex;
        val_18 = "PuzzleCollectionUIController attempting to ShowPuzzlePiece but no word exists for PuzzleWordIndex ";
        goto label_18;
        label_9:
        val_16 = "PuzzleCollectionUIController attempting to ShowPuzzlePiece but associated word/letter index is outdated!";
        label_8:
        UnityEngine.Debug.LogError(message:  val_16);
        return;
        label_17:
        LineWord val_16 = this.word;
        int val_8 = val_6.PuzzleLetterIndex;
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
        
        val_18 = "PuzzleCollectionUIController attempting to ShowPuzzlePiece but no letter exists for PuzzleLetterIndex ";
        label_18:
        UnityEngine.Debug.LogError(message:  val_18 + val_9.PuzzleLetterIndex);
        return;
        label_26:
        if(this.puzzlePiece == 0)
        {
                val_15 = this.letter.transform;
            this.puzzlePiece = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.puzzlePiecePrefab, parent:  val_15);
        }
        
        this.AdjustPuzzlePieceUI();
    }
    private void AdjustPuzzlePieceUI()
    {
        if(this.puzzlePiece == 0)
        {
                return;
        }
        
        if(this.puzzlePiece.transform.parent == 0)
        {
                return;
        }
        
        if(this.letter == 0)
        {
                return;
        }
        
        this.puzzlePiece.transform.parent = this.letter.transform;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.puzzlePiece.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Vector2 val_12 = this.letter.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y}, d:  0.9f);
        this.puzzlePiece.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
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
        
        if(this.puzzlePiece != 0)
        {
            goto label_8;
        }
        
        this.lastLetter = this.letter;
        if(this.letter != null)
        {
            goto label_9;
        }
        
        label_8:
        label_9:
        this.letter.HideStarred();
        if(this.lastLetter != 0)
        {
                this.lastLetter.ShowStarred();
        }
        
        this.lastLetter = this.letter;
    }
    private void DestroyPuzzlePiece()
    {
        if(this.puzzlePiece == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.puzzlePiece);
        this.puzzlePiece = 0;
    }
    private bool IsFTUX()
    {
        var val_5;
        bool val_1 = PuzzleCollectionHandler.IsFTUX;
        if(val_1 != false)
        {
                int val_2 = val_1.PuzzleLetterIndex;
            System.Collections.Generic.List<Cell> val_5 = this.word.cells;
            val_5 = val_5 - 1;
            if(val_2 != val_5)
        {
                return (bool)(val_2.PuzzleLetterIndex == 0) ? 1 : 0;
        }
        
            val_5 = 1;
            return (bool)(val_2.PuzzleLetterIndex == 0) ? 1 : 0;
        }
        
        val_5 = 0;
        return (bool)(val_2.PuzzleLetterIndex == 0) ? 1 : 0;
    }
    private System.Collections.IEnumerator ShowTooltip(UnityEngine.Transform parent)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .parent = parent;
        return (System.Collections.IEnumerator)new PuzzleCollectionUIController.<ShowTooltip>d__66();
    }
    private void OnPuzzlePieceMoveComplete()
    {
        this.DestroyPuzzlePiece();
        UnityEngine.ParticleSystem val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.glow, parent:  this.eventButton.transform).GetComponent<UnityEngine.ParticleSystem>();
        this.glowEffect = val_3;
        val_3.transform.localPosition = new UnityEngine.Vector3() {x = this.glowEffectOffset};
        this.glowEffect.Play();
        this.Invoke(methodName:  "OnCollectedPuzzlePiece", time:  this.glowDuration);
    }
    private void OnCollectedPuzzlePiece()
    {
        UnityEngine.Object.DestroyImmediate(obj:  this.glowEffect.transform.gameObject);
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PuzzlePieceAnimationComplete();
    }
    private void ResetPuzzleLevelUI()
    {
        this.PuzzleWordIndex = 0;
        this.PuzzleLetterIndex = 0;
        this.ObtainedPuzzlePiece = false;
        this.IsPuzzlePieceAvailable = true;
    }
    private void ClearUIProgress()
    {
        this.DestroyPuzzlePiece();
        this.DestroyTooltip();
    }
    public PuzzleCollectionUIController()
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  -40f, y:  0f, z:  0f);
        this.glowEffectOffset = val_1.x;
        mem[1152921517615257336] = val_1.z;
        this.puzzlePieceMoveDuration = 1f;
        this.glowDuration = 0.5f;
    }

}
