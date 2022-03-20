using UnityEngine;
public class FPHPhraseOfTheDayRewardPopup : MonoBehaviour
{
    // Fields
    private const string REWARD_DESCRIPTION = "Nice work\nYou answered all daily phrases!";
    private const string BONUS_QUESTION_DESCRIPTION = "Great job!\nOnto the more difficult bonus phrase for an additional reward!";
    private UnityEngine.UI.Text description;
    private UnityEngine.GameObject rewardGroup;
    private UnityEngine.UI.Text rewardValue;
    private UnityEngine.UI.Image rewardImg;
    private UnityEngine.Sprite coinSp;
    private UnityEngine.Sprite gemSp;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.GameObject bonusQuestionGroup;
    private UnityEngine.UI.Button bonusQuestionButton;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private GemsCollectAnimationInstantiator gemAnim;
    private bool isBonus;
    
    // Properties
    public FPHQOTDPhrase reward { get; }
    
    // Methods
    public FPHQOTDPhrase get_reward()
    {
        return MonoSingleton<FPHPhraseOfTheDayController>.Instance.GetReward();
    }
    public void Start()
    {
        var val_8;
        FPHPhraseOfTheDayController val_1 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        if((val_1.<Status>k__BackingField.qotdProgress) < 2)
        {
                val_8 = "Great job!\nOnto the more difficult bonus phrase for an additional reward!";
        }
        else
        {
                val_8 = "Nice work\nYou answered all daily phrases!";
        }
        
        FPHQOTDPhrase val_2 = this.description.reward;
        string val_3 = val_2.rewardAmount.ToString();
        FPHQOTDPhrase val_4 = this.rewardValue.reward;
        var val_5 = (val_4.rewardType == 1) ? 64 : 56;
        this.rewardImg.sprite = null;
        this.rewardGroup.SetActive(value:  true);
        this.bonusQuestionGroup.SetActive(value:  false);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHPhraseOfTheDayRewardPopup::<Start>b__16_0()));
    }
    private void SwitchToBonusQuestionState()
    {
        this.bonusQuestionButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHPhraseOfTheDayRewardPopup::OnClick_BonusQuestion()));
        this.rewardGroup.SetActive(value:  false);
        this.bonusQuestionGroup.SetActive(value:  true);
    }
    private void OnQOTDFinished()
    {
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.Complete();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Collect()
    {
        IntPtr val_18;
        IntPtr val_19;
        this.collectButton.interactable = false;
        FPHPhraseOfTheDayController val_1 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        val_1.CollectReward();
        if(val_2.rewardType != 1)
        {
            goto label_6;
        }
        
        FPHPhraseOfTheDayController val_3 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        if((val_3.<Status>k__BackingField.qotdProgress) < 2)
        {
            goto label_11;
        }
        
        val_18 = 1152921515990925776;
        goto label_12;
        label_6:
        FPHQOTDPhrase val_4 = val_1.reward.reward;
        if(val_4.rewardType == 0)
        {
            goto label_14;
        }
        
        return;
        label_11:
        val_18 = 1152921515990614736;
        label_12:
        new System.Action() = new System.Action(object:  this, method:  val_18);
        mem2[0] = new System.Action();
        FPHQOTDPhrase val_7 = App.Player.reward;
        Player val_8 = App.Player;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8._gems);
        this.gemAnim.Play(fromValue:  val_6._gems - val_7.rewardAmount, toValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_14:
        FPHPhraseOfTheDayController val_11 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        if((val_11.<Status>k__BackingField.qotdProgress) >= 2)
        {
                val_19 = 1152921515990925776;
        }
        else
        {
                val_19 = 1152921515990614736;
        }
        
        new System.Action() = new System.Action(object:  this, method:  val_19);
        this.coinAnim.OnCompleteCallback = new System.Action();
        FPHQOTDPhrase val_14 = App.Player.reward;
        decimal val_15 = System.Decimal.op_Implicit(value:  val_14.rewardAmount);
        decimal val_16 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits, lo = this.coinAnim, mid = this.coinAnim}, d2:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid});
        Player val_17 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, toValue:  new System.Decimal() {flags = val_17._credits, hi = val_17._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnClick_BonusQuestion()
    {
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.StartNextQOTDQuestion();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public FPHPhraseOfTheDayRewardPopup()
    {
    
    }
    private void <Start>b__16_0()
    {
        this.OnClick_Collect();
    }

}
