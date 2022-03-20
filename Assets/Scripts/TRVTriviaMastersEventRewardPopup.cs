using UnityEngine;
public class TRVTriviaMastersEventRewardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Image rewardIcon;
    private UnityEngine.Sprite coinSp;
    private UnityEngine.Sprite gemSp;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private GemsCollectAnimationInstantiator gemAnim;
    
    // Methods
    public void SetupUI(int tokens, TRVReward reward)
    {
        UnityEngine.Sprite val_10;
        .<>4__this = this;
        .reward = reward;
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVTriviaMastersEventRewardPopup.<>c__DisplayClass9_0(), method:  System.Void TRVTriviaMastersEventRewardPopup.<>c__DisplayClass9_0::<SetupUI>b__0()));
        if(((TRVTriviaMastersEventRewardPopup.<>c__DisplayClass9_0)[1152921517397442128].reward.rewardType) != 0)
        {
                this.collectButton.m_OnClick.SetActive(value:  false);
            val_10 = this.gemSp;
        }
        else
        {
                this.collectButton.m_OnClick.gameObject.SetActive(value:  false);
            val_10 = this.coinSp;
        }
        
        this.rewardIcon.sprite = val_10;
        string val_7 = System.String.Format(format:  Localization.Localize(key:  "trivia_masters_reward", defaultValue:  "Congratulations, you\'ve earned {0} tokens!", useSingularKey:  false), arg0:  tokens)(System.String.Format(format:  Localization.Localize(key:  "trivia_masters_reward", defaultValue:  "Congratulations, you\'ve earned {0} tokens!", useSingularKey:  false), arg0:  tokens)) + "\n" + Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false)(Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false));
        string val_8 = (TRVTriviaMastersEventRewardPopup.<>c__DisplayClass9_0)[1152921517397442128].reward.rewardAmount.ToString();
        string val_9 = System.String.Format(format:  "{0}/{1}", arg0:  tokens, arg1:  tokens);
    }
    private void CollectReward(TRVReward reward)
    {
        TriviaMastersEventHandler.<Instance>k__BackingField.CollectReward();
        if(reward.rewardType != 0)
        {
                if(reward.rewardType != 1)
        {
                return;
        }
        
            mem2[0] = new System.Action(object:  this, method:  System.Void TRVTriviaMastersEventRewardPopup::Close());
            Player val_2 = App.Player;
            Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
            this.gemAnim.Play(fromValue:  val_2._gems - reward.rewardAmount, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
            return;
        }
        
        this.coinAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void TRVTriviaMastersEventRewardPopup::Close());
        Player val_7 = App.Player;
        int val_8 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits, lo = -94005296, mid = 268435458});
        val_8 = val_8 - reward.rewardAmount;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8);
        Player val_10 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, toValue:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
        if((TriviaMastersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        TriviaMastersEventHandler.<Instance>k__BackingField.OnMyEventPopupClosed();
    }
    public TRVTriviaMastersEventRewardPopup()
    {
    
    }

}
