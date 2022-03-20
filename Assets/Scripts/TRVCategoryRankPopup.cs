using UnityEngine;
public class TRVCategoryRankPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image categoryIcon;
    private UnityEngine.UI.Text rank;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text reward;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private int currentRank;
    private int rewardAmount;
    
    // Methods
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AnimateRankup());
    }
    public void Init(UnityEngine.Sprite categorySp, int currentRank, int nextProgressGoal, int rewardAmount)
    {
        this.currentRank = currentRank;
        this.rewardAmount = rewardAmount;
        string val_1 = currentRank.ToString();
        this.categoryIcon.sprite = categorySp;
        if(nextProgressGoal != 0)
        {
                string val_3 = System.String.Format(format:  Localization.Localize(key:  "trv_category_increase", defaultValue:  "Next Increase In:\n{0} Correct Answers", useSingularKey:  false), arg0:  nextProgressGoal);
        }
        else
        {
                string val_4 = Localization.Localize(key:  "congratulations", defaultValue:  "Congratulations!", useSingularKey:  false);
        }
        
        string val_5 = rewardAmount.ToString();
        this.collectButton.interactable = true;
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategoryRankPopup::CollectReward()));
    }
    private System.Collections.IEnumerator AnimateRankup()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVCategoryRankPopup.<AnimateRankup>d__10();
    }
    private void CollectReward()
    {
        TRVCategoryRankController.CollectReward(reward:  this.rewardAmount);
        this.coinAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void TRVCategoryRankPopup::Close());
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  this.rewardAmount);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = this.coinAnim, mid = this.coinAnim}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_5 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        this.collectButton.interactable = false;
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVCategoryRankPopup()
    {
    
    }

}
