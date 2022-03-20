using UnityEngine;
public class WGPuzzleProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text puzzleTimeEnds;
    private UnityEngine.UI.Image puzzleImage;
    private UnityEngine.Transform puzzleBoard;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button earnPuzzlePiecesButton;
    private float revealingPuzzlePieceSpeed;
    private UnityEngine.GameObject rewardCoinObject;
    private UnityEngine.UI.Text reward;
    private UnityEngine.GameObject rewardBonusGameObject;
    private UnityEngine.UI.Text rewardBonusGameLabel;
    private UnityEngine.UI.Image rewardBonusGameIcon;
    private UnityEngine.Sprite bonusIconWheel;
    private UnityEngine.Sprite bonusIconSlots;
    private UnityEngine.UI.Text playButtonText;
    private UnityEngine.UI.Button continueButton;
    private const int TRUE = 1;
    private const int FALSE = 0;
    private UnityEngine.Sprite tempSprite;
    
    // Methods
    private void Awake()
    {
    
    }
    private void OnEnable()
    {
        this.UpdatePuzzleBoard();
        this.UpdateRewardInfo();
        this.earnPuzzlePiecesButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPuzzleProgressPopup::OnClick_EarnPuzzlePieces()));
        GameBehavior val_3 = App.getBehavior;
        this.earnPuzzlePiecesButton.gameObject.SetActive(value:  ((val_3.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPuzzleProgressPopup::OnClick_EarnPuzzlePieces()));
        GameBehavior val_7 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_7.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        string val_11 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
    }
    private void OnDisable()
    {
        if((System.String.op_Inequality(a:  PuzzleCollectionHandler.CurrentPuzzleName, b:  "academy")) == false)
        {
                return;
        }
        
        UnityEngine.Object.DestroyImmediate(obj:  this.tempSprite);
    }
    private void Update()
    {
        this.UpdatePuzzleEndTime();
    }
    private void UpdateRewardInfo()
    {
        UnityEngine.UI.Text val_17;
        object val_18;
        val_17 = this;
        GameEventRewardType val_1 = PuzzleCollectionHandler.RewardType;
        if(val_1 != 1)
        {
            goto label_1;
        }
        
        this.rewardCoinObject.SetActive(value:  true);
        this.rewardBonusGameObject.SetActive(value:  false);
        string val_3 = PuzzleCollectionHandler.RewardValue.ToString();
        val_17 = this.description;
        val_18 = PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.GetEventExpireDayOfWeek();
        label_22:
        string val_7 = System.String.Format(format:  Localization.Localize(key:  "puzzle_time_popup_info", defaultValue:  "Complete the Puzzle by {0} at {1} to earn bonus Rewards!", useSingularKey:  false), arg0:  val_18, arg1:  PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.GetEventExpireTime());
        return;
        label_1:
        val_18 = val_1;
        if((val_1 - 3) > 1)
        {
                return;
        }
        
        this.rewardCoinObject.SetActive(value:  false);
        this.rewardBonusGameObject.SetActive(value:  true);
        if(val_18 != 3)
        {
            goto label_14;
        }
        
        string val_9 = Localization.Localize(key:  "bonus_wheel_upper", defaultValue:  "BONUS WHEEL", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconWheel;
        string val_10 = Localization.Localize(key:  "puzzle_event_bonus_wheel_desc", defaultValue:  "Complete the Puzzle for a chance to earn up to {0} Coins or {1} Golden Apples on the Bonus Wheel!", useSingularKey:  false);
        int val_12 = App.getGameEcon.maxBonusGameWheelAwardCoins;
        int val_14 = App.getGameEcon.maxBonusGameWheelAwardGoldenCurrency;
        goto label_22;
        label_14:
        string val_15 = Localization.Localize(key:  "bonus_spin_upper", defaultValue:  "BONUS SPIN", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconSlots;
        string val_16 = Localization.Localize(key:  "puzzle_event_bonus_slots_desc", defaultValue:  "Complete the Puzzle for a chance to earn up to 900 Coins and Golden Apples on the Bonus Spinner!", useSingularKey:  false);
        if(this.description != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private void UpdatePuzzleEndTime()
    {
        int val_12;
        int val_13;
        int val_14;
        System.TimeSpan val_1 = PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.GetRemainingTime();
        string[] val_2 = new string[7];
        val_12 = val_2.Length;
        val_2[0] = val_1._ticks.Days.ToString(format:  "00");
        val_12 = val_2.Length;
        val_2[1] = ":";
        val_13 = val_2.Length;
        val_2[2] = val_1._ticks.Hours.ToString(format:  "00");
        val_13 = val_2.Length;
        val_2[3] = ":";
        val_14 = val_2.Length;
        val_2[4] = val_1._ticks.Minutes.ToString(format:  "00");
        val_14 = val_2.Length;
        val_2[5] = ":";
        val_2[6] = val_1._ticks.Seconds.ToString(format:  "00");
        string val_11 = +val_2;
    }
    private void UpdatePuzzleBoard()
    {
        System.Collections.Generic.IEnumerable<T> val_25;
        if(this.puzzleImage != 0)
        {
                if((System.String.op_Equality(a:  PuzzleCollectionHandler.CurrentPuzzleName, b:  "academy")) != false)
        {
                UnityEngine.Sprite val_4 = UnityEngine.Resources.Load<UnityEngine.Sprite>(path:  "game/WordAddict/Events/PuzzleCollection/academy");
        }
        else
        {
                UnityEngine.Sprite val_8 = ImageLoadingController.GetSprite(path:  UnityEngine.Application.temporaryCachePath + "/"("/") + PuzzleCollectionHandler.CurrentPuzzleName + ".png");
        }
        
            this.tempSprite = val_8;
            this.puzzleImage.sprite = val_8;
        }
        
        if(val_9.Length >= 1)
        {
                var val_26 = 0;
            do
        {
            this.puzzleBoard.GetChild(index:  0).gameObject.SetActive(value:  (null == null) ? 1 : 0);
            val_26 = val_26 + 1;
        }
        while(val_26 < val_9.Length);
        
        }
        
        val_25 = PuzzleCollectionHandler.NewPuzzlePieces;
        System.Collections.Generic.List<System.Int32> val_14 = new System.Collections.Generic.List<System.Int32>(collection:  val_25);
        if(null >= 1)
        {
                var val_27 = 8;
            do
        {
            var val_15 = val_27 - 8;
            if(val_15 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_25 = this.puzzleBoard.GetChild(index:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg).gameObject;
            if(val_15 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.puzzleBoard.GetChild(index:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg).gameObject.SetActive(value:  true);
            UnityEngine.Coroutine val_21 = this.StartCoroutine(routine:  this.FadeOutPuzzlePiece(pc:  val_25));
            val_27 = val_27 + 1;
        }
        while((val_27 - 7) < null);
        
        }
        
        System.Collections.Generic.List<System.Int32> val_24 = new System.Collections.Generic.List<System.Int32>(collection:  PuzzleCollectionHandler.NewPuzzlePieces);
        val_24.Clear();
        PuzzleCollectionHandler.NewPuzzlePieces = val_24.ToArray();
    }
    private System.Collections.IEnumerator FadeOutPuzzlePiece(UnityEngine.GameObject pc)
    {
        .<>1__state = 0;
        .pc = pc;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGPuzzleProgressPopup.<FadeOutPuzzlePiece>d__25();
    }
    private void OnClick_EarnPuzzlePieces()
    {
        if(App.Player == 3)
        {
            goto label_9;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_9;
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PlayingChallenge == false)
        {
            goto label_12;
        }
        
        MonoSingleton<PuzzleCollectionUIController>.Instance.ShowToolTip();
        label_9:
        this.Close();
        return;
        label_12:
        GameBehavior val_5 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        this = ???;
        goto typeof(System.Int32).__il2cppRuntimeField_540;
    }
    public WGPuzzleProgressPopup()
    {
        this.revealingPuzzlePieceSpeed = 0.5f;
    }

}
