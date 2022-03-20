using UnityEngine;
public class BingoEventPopup : MonoBehaviour
{
    // Fields
    private const float AUTO_CLOSE_SEC = 3;
    private bool isNewCard;
    private UnityEngine.UI.Text descText;
    private UnityEngine.GameObject bingoCard;
    private UnityEngine.GameObject bingoCompletedGroup;
    private UnityEngine.GameObject levelGroup;
    private UnityEngine.Transform ballsParent;
    private UnityEngine.UI.Text ballsCount;
    private UnityEngine.UI.Button levelButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.GameObject ball;
    private UnityEngine.GameObject daub;
    private UnityEngine.Sprite bingoBaubSprite;
    private UnityEngine.Sprite[] ballsSprites;
    private UnityEngine.GameObject collectGroup;
    private UnityEngine.UI.Text prizeText;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text timerText;
    private BingoCell[] bingoCells;
    private BingoEventHandler eventHandler;
    private System.Collections.Generic.List<int> collectedBalls;
    private System.Collections.Generic.List<int> completedBingo;
    private System.Collections.Generic.Dictionary<int, BingoCell> cellPos;
    private bool isGameScene;
    private UnityEngine.UI.Button activePopupButton;
    private const float BALL_PUNCH_DURATION = 0.5;
    private const float BALL_MOVE_DURATION = 0.8;
    private const float BALL_MOVE_DELAY = 0.7;
    private const float COMBINATION_DURATION = 3;
    private const float COLLECT_PRIZE_DELAY = 1.5;
    private const float BALLS_DISTANCE = 1.15;
    private const int MAX_BALLS = 4;
    
    // Methods
    public void Awake()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BingoEventPopup::OnCollectClick()));
        this.levelButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BingoEventPopup::OnLevelClick()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void BingoEventPopup::Close()));
        this.bingoCells = this.bingoCard.GetComponentsInChildren<BingoCell>();
    }
    public void Start()
    {
        this.eventHandler = BingoEventHandler.<Instance>k__BackingField;
        if((BingoEventHandler.<Instance>k__BackingField) != null)
        {
                GameBehavior val_1 = App.getBehavior;
            this.isGameScene = ((val_1.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0;
            this.Init();
            return;
        }
        
        this.Close();
    }
    public void Close()
    {
        this.CancelInvoke();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Init()
    {
        BingoEventHandler val_23;
        State val_24;
        val_23 = this.eventHandler;
        if((this.eventHandler.<progression>k__BackingField.ballsCollected) >= 1)
        {
                val_23 = this.eventHandler;
            this.collectedBalls = val_23.CallCollectedBalls();
            val_24 = 1;
        }
        else
        {
                val_24 = 0;
        }
        
        if(val_23.BingoCombinationCompleted() != null)
        {
                val_24 = 1;
            this.completedBingo = this.eventHandler.BingoCombinationCompleted();
        }
        
        this.UpdateTimerText();
        FrameSkipper val_5 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_5.updateLogic = new System.Action(object:  this, method:  System.Void BingoEventPopup::UpdateTimerText());
        string val_7 = this.eventHandler.econ.basePrize.ToString();
        UnityEngine.UI.Text val_8 = this.levelButton.GetComponentInChildren<UnityEngine.UI.Text>();
        string val_11 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        GameBehavior val_13 = App.getBehavior;
        this.levelButton.gameObject.SetActive(value:  ((val_13.<metaGameBehavior>k__BackingField) != 2) ? 1 : 0);
        GameBehavior val_16 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_16.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0);
        GameBehavior val_18 = App.getBehavior;
        this.activePopupButton = ((val_18.<metaGameBehavior>k__BackingField) == 2) ? (this.continueButton) : (this.levelButton);
        this.PopulateCard();
        this.UpdateUI(state:  val_24);
        if(val_24 != 0)
        {
                System.Collections.IEnumerator val_20 = this.CollectBallsAnimation();
        }
        
        UnityEngine.Coroutine val_22 = this.StartCoroutine(routine:  this.CombinationsAnimation());
    }
    private void UpdateUI(BingoEventPopup.State state)
    {
        this.levelGroup.SetActive(value:  true);
        this.collectGroup.SetActive(value:  false);
        if(state == 2)
        {
            goto label_2;
        }
        
        if(state == 1)
        {
            goto label_3;
        }
        
        if(state != 0)
        {
            goto label_13;
        }
        
        label_2:
        this.ballsParent.gameObject.SetActive(value:  false);
        this.closeButton.gameObject.SetActive(value:  true);
        this.descText.gameObject.SetActive(value:  true);
        this.activePopupButton.gameObject.SetActive(value:  true);
        goto label_13;
        label_3:
        this.ballsParent.gameObject.SetActive(value:  true);
        this.closeButton.gameObject.SetActive(value:  false);
        this.descText.gameObject.SetActive(value:  false);
        this.activePopupButton.gameObject.SetActive(value:  false);
        string val_10 = this.GetCollectedBalls().ToString();
        label_13:
        this.bingoCompletedGroup.SetActive(value:  false);
    }
    private void PopulateCard()
    {
        int val_3;
        var val_4;
        System.Collections.Generic.List<System.Int32> val_15;
        System.Collections.Generic.HashSet<System.Int32> val_1 = new System.Collections.Generic.HashSet<System.Int32>();
        if(this.eventHandler == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.eventHandler.<progression>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = this.eventHandler.<progression>k__BackingField.balls;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = val_15.GetEnumerator();
        label_6:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        bool val_6 = val_1.Add(item:  val_3);
        goto label_6;
        label_4:
        val_4.Dispose();
        if(this.eventHandler == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.eventHandler.<progression>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        this.cellPos = new System.Collections.Generic.Dictionary<System.Int32, BingoCell>();
        var val_22 = 0;
        label_35:
        var val_21 = 0;
        label_34:
        if(this.bingoCells == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.eventHandler.<progression>k__BackingField.currentCard) == null)
        {
                throw new NullReferenceException();
        }
        
        BingoCell val_16 = this.bingoCells[0 + val_21];
        if((this.eventHandler.<progression>k__BackingField.currentCard[val_22 + ((this.bingoCells.Length + 16) * val_21)]) == 0)
        {
            goto label_30;
        }
        
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        string val_10 = this.eventHandler.<progression>k__BackingField.currentCard[(this.bingoCells.Length + 16 * 0) + 0] + 32.ToString();
        if((this.bingoCells[(0 + 0)][0].numberText) == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = this.cellPos;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.Add(key:  this.eventHandler.<progression>k__BackingField.currentCard[0], value:  val_16);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventHandler.<progression>k__BackingField.currentCard[0] = val_22 + ((this.eventHandler.<progression>k__BackingField.currentCard[0]) * val_21);
        if((val_1.Contains(item:  this.eventHandler.<progression>k__BackingField.currentCard[this.eventHandler.<progression>k__BackingField.currentCard[0]])) == false)
        {
            goto label_23;
        }
        
        val_15 = this.collectedBalls;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventHandler.<progression>k__BackingField.currentCard[this.eventHandler.<progression>k__BackingField.currentCard[0]] = val_22 + ((this.eventHandler.<progression>k__BackingField.currentCard[this.eventHandler.<progression>k__BackingField.currentCard[0]]) * val_21);
        if((val_15.Contains(item:  this.eventHandler.<progression>k__BackingField.currentCard[this.eventHandler.<progression>k__BackingField.currentCard[this.eventHandler.<progression>k__BackingField.currentCard[0]]])) == false)
        {
            goto label_27;
        }
        
        label_23:
        val_15 = this.bingoCells[(0 + 0)][0].cellImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_13 = val_15.gameObject;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.SetActive(value:  false);
        val_16.StopBingoAnima();
        goto label_30;
        label_27:
        val_15 = this.bingoCells[(0 + 0)][0].cellImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_14 = val_15.gameObject;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.SetActive(value:  true);
        val_15 = this.bingoCells[(0 + 0)][0].cellImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.sprite = this.bingoBaubSprite;
        label_30:
        val_21 = val_21 + 1;
        if(val_21 < 4)
        {
            goto label_34;
        }
        
        val_22 = val_22 + 1;
        var val_15 = 0 + val_21;
        if(val_22 <= 3)
        {
            goto label_35;
        }
    
    }
    private System.Collections.IEnumerator CollectBallsAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new BingoEventPopup.<CollectBallsAnimation>d__40();
    }
    private System.Collections.IEnumerator CombinationsAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new BingoEventPopup.<CombinationsAnimation>d__41();
    }
    private void ShowBingoCompleted()
    {
        bool val_4 = true;
        var val_5 = 8;
        label_10:
        var val_1 = val_5 - 8;
        if(val_1 >= val_4)
        {
            goto label_2;
        }
        
        val_4 = val_4 & 4294967295;
        if(val_1 >= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((this.cellPos.ContainsKey(key:  (true & 4294967295) + 32)) != false)
        {
                if(val_1 >= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.cellPos.Item[(true & 4294967295) + 32].StartBingoAnima();
        }
        
        val_5 = val_5 + 1;
        if(this.completedBingo != null)
        {
            goto label_10;
        }
        
        label_2:
        this.bingoCompletedGroup.SetActive(value:  true);
    }
    private void ShowCollectReward()
    {
        this.collectButton.interactable = true;
        this.levelGroup.SetActive(value:  false);
        this.collectGroup.SetActive(value:  true);
    }
    private void UpdateTimerText()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.eventHandler}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days;
        val_3[1] = val_2._ticks.Hours;
        val_3[2] = val_2._ticks.Minutes;
        val_3[3] = val_2._ticks.Seconds;
        string val_8 = System.String.Format(format:  "{0}d {1:00}h {2:00}m {3:00}s", args:  val_3);
        if(val_2._ticks.TotalSeconds >= 0)
        {
                return;
        }
        
        if(this.completedBingo != null)
        {
                return;
        }
        
        this.Close();
    }
    private UnityEngine.GameObject GenerateBall(int number)
    {
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.ball, parent:  this.ballsParent);
        val_1.SetActive(value:  true);
        val_1.GetComponent<UnityEngine.UI.Image>().sprite = this.ballsSprites[this.SpriteColorIndex(number:  number)];
        UnityEngine.UI.Text val_4 = val_1.GetComponentInChildren<UnityEngine.UI.Text>();
        string val_5 = number.ToString();
        return val_1;
    }
    private int GetCollectedBalls()
    {
        return (int)(this.eventHandler.<progression>k__BackingField.ballsCollected) + this.collectedBalls;
    }
    private int SpriteColorIndex(int number)
    {
        int val_1 = number - 1;
        var val_3 = 0;
        val_1 = val_3 + val_1;
        val_3 = val_1 >> 3;
        val_1 = val_3 + (val_1 >> 31);
        int val_2 = UnityEngine.Mathf.FloorToInt(f:  (float)val_1);
        val_3 = val_2 / this.ballsSprites.Length;
        val_2 = val_2 - (val_3 * this.ballsSprites.Length);
        return (int)val_2;
    }
    private void OnLevelClick()
    {
        this.Close();
        if(this.isGameScene != false)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_410;
    }
    private void OnCollectClick()
    {
        decimal val_3 = System.Decimal.op_Implicit(value:  this.eventHandler.econ.basePrize);
        .Amount = val_3;
        mem[1152921516091054544] = val_3.lo;
        mem[1152921516091054548] = val_3.mid;
        .Type = 0;
        new System.Collections.Generic.List<GiftReward>().Add(item:  new GiftReward());
        GameBehavior val_4 = App.getBehavior;
        this.eventHandler.CollectRewardAndNewCard();
        this.Close();
    }
    private void OnCoinsAnimFinished()
    {
        if((this.eventHandler & 1) != 0)
        {
                this.Close();
            return;
        }
        
        this.Init();
    }
    public BingoEventPopup()
    {
        this.collectedBalls = new System.Collections.Generic.List<System.Int32>();
    }

}
