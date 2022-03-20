using UnityEngine;
public class TRVQotdRewardPopup : MonoBehaviour
{
    // Fields
    private const string REWARD_DESCRIPTION = "Great job!\nHere’s your prize!";
    private const string BONUS_QUESTION_DESCRIPTION = "Answer a Bonus Question\nfor another reward!";
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
    
    // Methods
    public void Init(TRVReward reward, bool isBonus)
    {
        .<>4__this = this;
        .reward = reward;
        this.isBonus = isBonus;
        string val_3 = (TRVQotdRewardPopup.<>c__DisplayClass14_0)[1152921517338776240].reward.rewardAmount.ToString();
        var val_4 = (((TRVQotdRewardPopup.<>c__DisplayClass14_0)[1152921517338776240].reward.rewardType) == 1) ? 64 : 56;
        this.rewardImg.sprite = null;
        this.rewardGroup.SetActive(value:  true);
        this.bonusQuestionGroup.SetActive(value:  false);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVQotdRewardPopup.<>c__DisplayClass14_0(), method:  System.Void TRVQotdRewardPopup.<>c__DisplayClass14_0::<Init>b__0()));
    }
    private void SwitchToBonusQuestionState()
    {
        this.bonusQuestionButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQotdRewardPopup::OnClick_BonusQuestion()));
        this.rewardGroup.SetActive(value:  false);
        this.bonusQuestionGroup.SetActive(value:  true);
    }
    private void OnQOTDFinished()
    {
        MonoSingleton<TRVQuestionOfTheDayManager>.Instance.Complete();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Collect(TRVReward reward)
    {
        IntPtr val_12;
        IntPtr val_13;
        this.collectButton.interactable = false;
        MonoSingleton<TRVQuestionOfTheDayManager>.Instance.CollectReward(reward:  reward);
        if(reward.rewardType == 0)
        {
            goto label_6;
        }
        
        if(reward.rewardType != 1)
        {
                return;
        }
        
        if(this.isBonus == false)
        {
            goto label_8;
        }
        
        val_12 = 1152921517339200784;
        goto label_9;
        label_6:
        if(this.isBonus == false)
        {
            goto label_10;
        }
        
        val_13 = 1152921517339200784;
        goto label_11;
        label_8:
        val_12 = 1152921517339210000;
        label_9:
        new System.Action() = new System.Action(object:  this, method:  val_12);
        mem2[0] = new System.Action();
        Player val_3 = App.Player;
        Player val_4 = App.Player;
        decimal val_5 = System.Decimal.op_Implicit(value:  val_4._gems);
        this.gemAnim.Play(fromValue:  val_3._gems - reward.rewardAmount, toValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_10:
        val_13 = 1152921517339210000;
        label_11:
        new System.Action() = new System.Action(object:  this, method:  val_13);
        this.coinAnim.OnCompleteCallback = new System.Action();
        Player val_8 = App.Player;
        decimal val_9 = System.Decimal.op_Implicit(value:  reward.rewardAmount);
        decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_8._credits, hi = val_8._credits, lo = -152428592, mid = 268435458}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        Player val_11 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, toValue:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnClick_BonusQuestion()
    {
        MonoSingleton<TRVMainController>.Instance.StartNextQOTDQuestion();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVQotdRewardPopup()
    {
    
    }

}
