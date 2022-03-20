using UnityEngine;
public class WGPuzzleCompletePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image puzzleImage;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private UnityEngine.GameObject rewardCoinObject;
    private UnityEngine.UI.Text reward;
    private UnityEngine.GameObject rewardBonusGameObject;
    private UnityEngine.UI.Text rewardBonusGameLabel;
    private UnityEngine.UI.Image rewardBonusGameIcon;
    private UnityEngine.Sprite bonusIconWheel;
    private UnityEngine.Sprite bonusIconSlots;
    private const string FREE_COIN_SOURCE = "Puzzle Collect Reward";
    private const string NON_COIN_SOURCE_ID = "Puzzle Collection";
    private UnityEngine.Sprite tempSprite;
    private string puzzleImagePath;
    
    // Methods
    private void Awake()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPuzzleCompletePopup::OnClicked_Collect()));
        this.coinsAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGPuzzleCompletePopup::OnCoinsAnimFinished());
    }
    private void OnEnable()
    {
        if(this.puzzleImage != 0)
        {
                if((System.String.op_Equality(a:  PuzzleCollectionHandler.CurrentPuzzleName, b:  "academy")) != false)
        {
                UnityEngine.Sprite val_4 = UnityEngine.Resources.Load<UnityEngine.Sprite>(path:  "game/WordAddict/Events/PuzzleCollection/academy");
        }
        else
        {
                string val_7 = UnityEngine.Application.temporaryCachePath + "/"("/") + PuzzleCollectionHandler.LastPuzzleName + ".png";
            this.puzzleImagePath = val_7;
            UnityEngine.Sprite val_8 = ImageLoadingController.GetSprite(path:  val_7);
        }
        
            this.tempSprite = val_8;
            this.puzzleImage.sprite = val_8;
        }
        
        this.UpdateRewardInfo();
    }
    private void OnDisable()
    {
        if((System.String.op_Inequality(a:  PuzzleCollectionHandler.CurrentPuzzleName, b:  "academy")) == false)
        {
                return;
        }
        
        UnityEngine.Object.DestroyImmediate(obj:  this.tempSprite);
    }
    private void UpdateRewardInfo()
    {
        UnityEngine.UI.Text val_7;
        UnityEngine.Sprite val_8;
        val_7 = this;
        GameEventRewardType val_1 = PuzzleCollectionHandler.RewardType;
        if(val_1 == 1)
        {
                this.rewardCoinObject.SetActive(value:  true);
            this.rewardBonusGameObject.SetActive(value:  false);
            val_7 = this.reward;
            string val_3 = PuzzleCollectionHandler.RewardValue.ToString();
            return;
        }
        
        if((val_1 - 3) > 1)
        {
                return;
        }
        
        this.rewardCoinObject.SetActive(value:  false);
        this.rewardBonusGameObject.SetActive(value:  true);
        if(val_1 == 3)
        {
                string val_5 = Localization.Localize(key:  "bonus_wheel_upper", defaultValue:  "BONUS WHEEL", useSingularKey:  false);
            val_8 = this.bonusIconWheel;
        }
        else
        {
                string val_6 = Localization.Localize(key:  "bonus_spin_upper", defaultValue:  1152921504614887424, useSingularKey:  false);
            val_8 = this.bonusIconSlots;
        }
        
        this.rewardBonusGameIcon.sprite = val_8;
    }
    private void OnClicked_Collect()
    {
        IntPtr val_13;
        this.collectButton.interactable = false;
        GameEventRewardType val_1 = PuzzleCollectionHandler.RewardType;
        if(val_1 != 4)
        {
                if(val_1 != 3)
        {
                if(val_1 != 1)
        {
                return;
        }
        
            Player val_2 = App.Player;
            int val_3 = PuzzleCollectionHandler.RewardValue;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_3);
            val_2.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  "Puzzle Collect Reward", subSource:  0, externalParams:  0, doTrack:  true);
            val_2.MarkRewarded();
            if(this.coinsAnimControl == 0)
        {
                return;
        }
        
            Player val_6 = App.Player;
            decimal val_8 = System.Decimal.op_Implicit(value:  PuzzleCollectionHandler.RewardValue);
            decimal val_9 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = val_3, mid = val_3}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            Player val_10 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, toValue:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
            val_13 = 1152921517937505248;
        }
        else
        {
                System.Action val_11 = null;
            val_13 = 1152921517937510368;
        }
        
        val_11 = new System.Action(object:  this, method:  val_13);
        this.Close(onClose:  val_11);
    }
    private void MarkRewarded()
    {
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.MarkRewarded();
    }
    private void OnCoinsAnimFinished()
    {
        var val_2;
        System.Action val_4;
        val_2 = null;
        val_2 = null;
        val_4 = WGPuzzleCompletePopup.<>c.<>9__20_0;
        if(val_4 == null)
        {
                System.Action val_1 = null;
            val_4 = val_1;
            val_1 = new System.Action(object:  WGPuzzleCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGPuzzleCompletePopup.<>c::<OnCoinsAnimFinished>b__20_0());
            WGPuzzleCompletePopup.<>c.<>9__20_0 = val_4;
        }
        
        this.Close(onClose:  val_1);
    }
    private void Close(System.Action onClose)
    {
        if(onClose != null)
        {
                System.Delegate val_3 = System.Delegate.Combine(a:  this.gameObject.GetComponent<WGWindow>(), b:  onClose);
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
            mem2[0] = val_3;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_5:
    }
    public WGPuzzleCompletePopup()
    {
    
    }
    private void <OnClicked_Collect>b__18_0()
    {
        System.Action val_5;
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        System.Action val_3 = null;
        val_5 = val_3;
        val_3 = new System.Action(object:  this, method:  System.Void WGPuzzleCompletePopup::MarkRewarded());
        mem2[0] = val_5;
        mem2[0] = "PuzzleCollection";
        val_6 = null;
        val_6 = null;
        val_8 = WGPuzzleCompletePopup.<>c.<>9__18_2;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WGPuzzleCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGPuzzleCompletePopup.<>c::<OnClicked_Collect>b__18_2());
            WGPuzzleCompletePopup.<>c.<>9__18_2 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.SetOnClose(onClose:  val_4);
    }
    private void <OnClicked_Collect>b__18_1()
    {
        System.Action val_5;
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        System.Action val_3 = null;
        val_5 = val_3;
        val_3 = new System.Action(object:  this, method:  System.Void WGPuzzleCompletePopup::MarkRewarded());
        mem2[0] = val_5;
        mem2[0] = "PuzzleCollection";
        val_6 = null;
        val_6 = null;
        val_8 = WGPuzzleCompletePopup.<>c.<>9__18_3;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WGPuzzleCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGPuzzleCompletePopup.<>c::<OnClicked_Collect>b__18_3());
            WGPuzzleCompletePopup.<>c.<>9__18_3 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.SetOnClose(onClose:  val_4);
    }

}
