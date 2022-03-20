using UnityEngine;
public class WGPortraitCollectionUIController : MonoSingleton<WGPortraitCollectionUIController>
{
    // Fields
    private UnityEngine.GameObject spinPiecePrefab;
    private const string KEY_WORD_INDEX_KEY = "key_word_index";
    private const string KEY_LETTER_INDEX_KEY = "key_letter_index";
    private const string KEY_PIECE_OBTAINED_KEY = "key_obtained";
    private const string SAVED_LANGUAGE_KEY = "key_saved_lang";
    private const string KEY_AVAILABLE_KEY = "key_lost";
    private const int DEFAULT_KEY_WORD_INDEX = -1;
    private const int DEFAULT_KEY_LETTER_INDEX = -1;
    private const bool DEFAULT_OBTAINED_KEY_PIECE = False;
    private const bool DEFAULT_IS_KEY_PIECE_AVAILABLE = True;
    public UnityEngine.GameObject keyPiece;
    private LineWord word;
    private Cell letter;
    
    // Properties
    private int keyWordIndex { get; set; }
    private int keyLetterIndex { get; set; }
    private bool obtainedKeyPiece { get; set; }
    private string SavedLanguage { get; set; }
    private bool IsKeyPieceAvailable { get; set; }
    public int GetKeyWordIndex { get; }
    
    // Methods
    private int get_keyWordIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "key_word_index", defaultValue:  0);
    }
    private void set_keyWordIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "key_word_index", value:  value);
        App.Player.SaveState();
    }
    private int get_keyLetterIndex()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "key_letter_index", defaultValue:  0);
    }
    private void set_keyLetterIndex(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "key_letter_index", value:  value);
        App.Player.SaveState();
    }
    private bool get_obtainedKeyPiece()
    {
        return PlayerPrefsX.GetBool(name:  "key_obtained", defaultValue:  false);
    }
    private void set_obtainedKeyPiece(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "key_obtained", value:  value);
        App.Player.SaveState();
    }
    private string get_SavedLanguage()
    {
        GameBehavior val_1 = App.getBehavior;
        return UnityEngine.PlayerPrefs.GetString(key:  "key_saved_lang", defaultValue:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
    }
    private void set_SavedLanguage(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "key_saved_lang", value:  value);
    }
    private bool get_IsKeyPieceAvailable()
    {
        return PlayerPrefsX.GetBool(name:  "key_lost", defaultValue:  true);
    }
    private void set_IsKeyPieceAvailable(bool value)
    {
        value = value;
        bool val_1 = PlayerPrefsX.SetBool(name:  "key_lost", value:  value);
        App.Player.SaveState();
    }
    public int get_GetKeyWordIndex()
    {
        return this.keyWordIndex;
    }
    public void OnWordRegionLoaded()
    {
        var val_8;
        var val_9;
        var val_10;
        val_9 = this;
        val_10 = 1152921504930222080;
        if(PortraitCollectionEventHandler.COLLECTION_KEY == null)
        {
                return;
        }
        
        if(PortraitCollectionEventHandler.COLLECTION_KEY.IsEventExpired() != false)
        {
                this.DestroyKeyPiece();
            val_8 = ???;
            val_9 = ???;
            val_10 = ???;
        }
        else
        {
                if((val_8 + 2416) == 0)
        {
                mem2[0] = 1;
        }
        
            if((val_10 + 184.PlayingChallenge) == false)
        {
                return;
        }
        
            val_9.InitializeKeyPiece();
        }
    
    }
    private void OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        if(PortraitCollectionEventHandler.COLLECTION_KEY == null)
        {
                return;
        }
        
        if(PortraitCollectionEventHandler.COLLECTION_KEY.IsEventExpired() == true)
        {
                return;
        }
        
        bool val_2 = PortraitCollectionEventHandler.COLLECTION_KEY.PlayingChallenge;
        if(val_2 == false)
        {
                return;
        }
        
        if(val_2.IsKeyPlacementDataValid() == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        1152921504930222080 = 1152921504879157248;
        int val_6 = WordRegion.instance.keyWordIndex;
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
    public void DestroyKeyPiece()
    {
        if(this.keyPiece == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.keyPiece);
        this.keyPiece = 0;
    }
    private void CollectKeyPiece()
    {
        bool val_1 = UnityEngine.Object.op_Equality(x:  this.keyPiece, y:  0);
        if(val_1 == true)
        {
                return;
        }
        
        if(val_1.obtainedKeyPiece != false)
        {
                return;
        }
        
        this.ShowKeyPiece();
        mem2[0] = true;
        WordRegion.instance.obtainedKeyPiece = true;
        PortraitCollectionEventHandler.EarnedKeyPiece = true;
        PortraitCollectionEventHandler.COLLECTION_KEY.CollectKey();
        this.DestroyKeyPiece();
    }
    public void ShiftKeyPiece()
    {
        var val_11;
        WordRegion val_1 = WordRegion.instance;
        bool val_2 = UnityEngine.Object.op_Equality(x:  this.keyPiece, y:  0);
        if(val_2 == true)
        {
                return;
        }
        
        if(val_2.obtainedKeyPiece != false)
        {
                return;
        }
        
        val_11 = this;
        this.ShowKeyPiece();
        if(this.word.isShown != false)
        {
                this.CollectKeyPiece();
            return;
        }
        
        int val_4 = this.keyLetterIndex;
        val_4.keyLetterIndex = val_4 + 1;
        int val_6 = val_4.keyLetterIndex;
        LineWord val_11 = this.word;
        if(val_6 >= val_11)
        {
            goto label_13;
        }
        
        label_19:
        int val_7 = val_6.keyLetterIndex;
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
        
        int val_8 = this.keyLetterIndex;
        val_8.keyLetterIndex = val_8 + 1;
        if(val_8.keyLetterIndex < this.word)
        {
            goto label_19;
        }
        
        this.DestroyKeyPiece();
        goto label_20;
        label_13:
        this.DestroyKeyPiece();
        this.FixStarredCoinUI();
        label_20:
        this.IsKeyPieceAvailable = false;
        PortraitCollectionEventHandler.EarnedKeyPiece = false;
        return;
        label_16:
        this.letter = (this.word + (val_7) << 3).cellSize;
        this.AdjustKeyPieceUI();
        this.FixStarredCoinUI();
    }
    private bool IsKeyPlacementDataValid()
    {
        var val_6;
        int val_1 = this.keyWordIndex;
        if((val_1 & 2147483648) == 0)
        {
                int val_2 = val_1.keyWordIndex;
            var val_5 = (WordRegion.instance.keyLetterIndex == 0) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public void InitializeKeyPiece()
    {
        string val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_34;
        if(PortraitCollectionEventHandler.COLLECTION_KEY.PlayingChallenge == false)
        {
                return;
        }
        
        bool val_2 = PortraitCollectionEventHandler.COLLECTION_KEY.IsSolvingInProgress();
        if(val_2 == false)
        {
            goto label_6;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_29 = val_2.SavedLanguage;
        bool val_6 = System.String.op_Inequality(a:  val_29, b:  val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        if(val_6 == false)
        {
            goto label_11;
        }
        
        label_6:
        val_30 = 1152921504884269056;
        GameBehavior val_8 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_6.SavedLanguage, b:  val_8.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                GameBehavior val_11 = App.getBehavior;
            string val_12 = val_11.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
            val_12.SavedLanguage = val_12;
            bool val_13 = val_12.obtainedKeyPiece;
            if(val_13 == true)
        {
                return;
        }
        
        }
        
        val_13.ResetKeyLevelUI();
        RandomSet val_14 = new RandomSet();
        val_30 = WordRegion.instance.getAvailableLineIndices;
        var val_29 = 0;
        WordRegion val_17 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_31 = mem[(WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32];
        val_31 = (WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32;
        if((X26 + 24) <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        WordRegion val_18 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_31 = mem[((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40];
        val_31 = ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_14.add(item:  (((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 40 + 16 + 32 + 72 + 0) + 32, weight:  1f);
        val_29 = val_29 + 1;
        if(val_14.count() == 0)
        {
                return;
        }
        
        int val_20 = val_14.roll(unweighted:  false);
        val_20.keyWordIndex = val_20;
        val_32 = 0;
        goto label_51;
        label_69:
        int val_22 = WordRegion.instance.keyWordIndex;
        if(((0 + 1) + 24) <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_30 = (0 + 1) + 16;
        val_30 = val_30 + (val_22 << 3);
        val_34 = mem[((0 + 1) + 16 + (val_22) << 3) + 32 + 40];
        val_34 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40;
        if((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 24) <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_31 = ((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16;
        val_31 = val_31 + 0;
        if(((((0 + 1) + 16 + (val_22) << 3) + 32 + 40 + 16 + 0) + 32 + 72) == 0)
        {
            goto label_61;
        }
        
        val_32 = 1;
        label_51:
        int val_24 = WordRegion.instance.keyWordIndex;
        val_34 = val_24;
        if(((0 + 1) + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_32 = (0 + 1) + 16;
        val_32 = val_32 + (val_34 << 3);
        if(val_32 < (((0 + 1) + 16 + (val_24) << 3) + 32 + 40 + 24))
        {
            goto label_69;
        }
        
        goto label_70;
        label_11:
        bool val_25 = val_6.obtainedKeyPiece;
        if(val_25 == true)
        {
                return;
        }
        
        if(val_25.IsKeyPieceAvailable != true)
        {
                val_29 = this.keyPiece;
            bool val_27 = UnityEngine.Object.op_Inequality(x:  val_29, y:  0);
            if(val_27 == true)
        {
                return;
        }
        
        }
        
        if(val_27.IsKeyPlacementDataValid() == false)
        {
                return;
        }
        
        this.ShowKeyPiece();
        this.FixStarredCoinUI();
        return;
        label_61:
        this.keyLetterIndex = 0;
        label_70:
        this.ShowKeyPiece();
        this.FixStarredCoinUI();
        PortraitCollectionEventHandler.COLLECTION_KEY.SaveData();
    }
    public void ShowKeyPiece()
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
        if(val_2.IsKeyPlacementDataValid() == false)
        {
            goto label_9;
        }
        
        int val_5 = WordRegion.instance.keyWordIndex;
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
        
        int val_7 = val_6.keyWordIndex;
        val_18 = "SpinKingUIController attempting to ShowSpinPiece but no word exists for SpinWordIndex ";
        goto label_18;
        label_9:
        val_16 = "SpinKingUIController attempting to ShowSpinPiece but associated word/letter index is outdated!";
        label_8:
        UnityEngine.Debug.LogError(message:  val_16);
        return;
        label_17:
        LineWord val_16 = this.word;
        int val_8 = val_6.keyLetterIndex;
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
        UnityEngine.Debug.LogError(message:  val_18 + val_9.keyLetterIndex);
        return;
        label_26:
        if(this.keyPiece == 0)
        {
                val_15 = this.letter.transform;
            this.keyPiece = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.spinPiecePrefab, parent:  val_15);
        }
        
        this.AdjustKeyPieceUI();
    }
    public void OnWordSubmitted(string submitWord)
    {
        if((this.word.answer.Equals(value:  submitWord)) != false)
        {
                UnityEngine.Debug.LogError(message:  "gottem?");
            this.CollectKeyPiece();
            return;
        }
        
        this.ShiftKeyPiece();
    }
    private void AdjustKeyPieceUI()
    {
        if(this.keyPiece == 0)
        {
                return;
        }
        
        if(this.keyPiece.transform.parent == 0)
        {
                return;
        }
        
        if(this.letter == 0)
        {
                return;
        }
        
        this.keyPiece.transform.parent = this.letter.transform;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.keyPiece.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Vector2 val_12 = this.letter.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y}, d:  0.9f);
        this.keyPiece.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
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
        this.DestroyKeyPiece();
    }
    private void ResetKeyLevelUI()
    {
        this.keyWordIndex = 0;
        this.keyLetterIndex = 0;
        this.obtainedKeyPiece = false;
        this.IsKeyPieceAvailable = true;
    }
    private void OnGameEventHandlerProgress()
    {
    
    }
    public WGPortraitCollectionUIController()
    {
    
    }

}
