using UnityEngine;
public class TRVStarChampionshipEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject popupHolder;
    private UnityEngine.UI.Text description_top;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Button closeButton;
    private TRVStarChampionshipProgressBar progressBar;
    private UnityEngine.UI.Text description_bottom;
    private UnityEngine.GameObject rewardGroup;
    private UnityEngine.UI.Text rewardText;
    private GemsCollectAnimationInstantiator gemAnim;
    private System.Action onEnableAction;
    
    // Methods
    private void OnEnable()
    {
        if(this.onEnableAction != null)
        {
                this.onEnableAction.Invoke();
        }
        
        this.onEnableAction = 0;
    }
    public void ShowRewardPopup(TRVStarChampionshipRewardUIParam param)
    {
        .<>4__this = this;
        .param = param;
        if(this.gameObject.activeSelf != false)
        {
                UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.DelayShowingRewardPopup(param:  (TRVStarChampionshipEventPopup.<>c__DisplayClass12_0)[1152921517393594448].param));
            return;
        }
        
        this.onEnableAction = new System.Action(object:  new TRVStarChampionshipEventPopup.<>c__DisplayClass12_0(), method:  System.Void TRVStarChampionshipEventPopup.<>c__DisplayClass12_0::<ShowRewardPopup>b__0());
    }
    public void ShowProgressPopup(TRVStarChampionshipProgressUIParam param)
    {
        this.description_bottom.gameObject.SetActive(value:  true);
        this.progressBar.UpdateProgressBar(progress:  null, tier:  1);
        this.rewardGroup.SetActive(value:  false);
        string val_2 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVStarChampionshipEventPopup::Close()));
        this.closeButton.gameObject.SetActive(value:  true);
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVStarChampionshipEventPopup::Close()));
    }
    private System.Collections.IEnumerator DelayShowingRewardPopup(TRVStarChampionshipRewardUIParam param)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .param = param;
        return (System.Collections.IEnumerator)new TRVStarChampionshipEventPopup.<DelayShowingRewardPopup>d__14();
    }
    private void CollectReward(int reward, int tier)
    {
        this.button.interactable = false;
        App.Player.AddGems(amount:  reward, source:  "TRV Star Championship Reward", subsource:  0);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  System.String.Format(format:  "Star Championship Tier {0}", arg0:  tier + 1), value:  reward);
        App.Player.TrackNonCoinReward(source:  "TRV Star Championship", subSource:  0, rewardType:  "Gems", rewardAmount:  reward.ToString(), additionalParams:  val_2);
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVStarChampionshipEventPopup::Close());
        Player val_8 = App.Player;
        Player val_9 = App.Player;
        decimal val_10 = System.Decimal.op_Implicit(value:  val_9._gems);
        this.gemAnim.Play(fromValue:  val_8._gems - reward, toValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if((TRVStarChampionshipEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        TRVStarChampionshipEventHandler.<Instance>k__BackingField.OnMyEventPopupClosed();
    }
    public TRVStarChampionshipEventPopup()
    {
    
    }

}
